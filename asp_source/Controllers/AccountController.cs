using App.API.Filters;
using App.EcommerceAPI.Email;
using App.Entity;
using App.Entity.Enums;
using App.Entity.Models.Login;
using App.Entity.Models.OpenPlatform;
using App.Entity.Models.OpenPlatform.Facebook;
using App.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Web;
using TFU.APIBased;
using TFU.BLL.Interfaces;
using TFU.Common;
using TFU.Common.Models;
using TFU.Models.IdentityModels;
using TFU.Services;
using TFU.Utility;

namespace tapluyen.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseAPIController
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;
        private readonly SignInManager<UserDTO> _signInManager;
        private readonly IIdentityBizLogic _identityBizLogic;
        private readonly UserManager<UserDTO> _userManager;
        public AccountController(ILogger<AccountController> logger, IConfiguration configuration, IEmailSender emailSender, SignInManager<UserDTO> signInManager, IIdentityBizLogic identityBizLogic, UserManager<UserDTO> userManager)
        {
            this._logger = logger;
            this._configuration = configuration;
            this._emailSender = emailSender;
            this._signInManager = signInManager;
            this._identityBizLogic = identityBizLogic;
            this._userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            try
            {
                if (!Helpers.IsValidEmail(model.Email.Trim()))
                {
                    ModelState.AddModelError("Email", Constants.EmailAddressFormatError);
                    return ModelInvalid();
                }

                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError("Password", "Mật khẩu xác thực không đúng!");
                    return ModelInvalid();
                }

                var userEmail = await _identityBizLogic.GetByEmailAsync(model.Email);
                if (userEmail != null)
                {
                    ModelState.AddModelError("Email", "Email đã tồn tại!");
                    return ModelInvalid();
                }

                var user = new UserDTO
                {
                    UserName = model.Email,
                    Email = model.Email,
                    EmailConfirmed = false,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                };

                var result = await _identityBizLogic.AddUserAsync(user, model.Password);
                if (result > 0)
                {
                    // Gửi email xác nhận tài khoản
                    await SendEmailConfirm(user, model.Email);

                    //trả về thông tin
                    var userData = new UserViewModel()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Username = user.UserName
                    };
                    return SaveSuccess(userData);
                }
                return Error("Có lỗi xảy ra trong quá trình thực hiện. Vui lòng thử lại sau ít phút!");
            }
            catch (System.Exception ex)
            {
                _logger.LogError("Register: {0} {1}", ex.Message, ex.StackTrace);
                return Error("Có lỗi xảy ra trong quá trình thực hiện. Vui lòng thử lại sau ít phút!");
            }
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailModel model)
        {
            try
            {
                var result = await _identityBizLogic.ConfirmEmailAsync(model.UserId.ToString(), model.Token);
                if (result) return SaveSuccess(result);
                return SaveError("Link hiện tại đã hết thời gian. Xin vui lòng đăng ký lại");
            }
            catch (Exception ex)
            {
                _logger.LogError("ConfirmEmail: {0} {1}", ex.Message, ex.StackTrace);
                return SaveError();
            }
        }

        [HttpPost("create-password")]
        public async Task<IActionResult> CreatePassword([FromBody] RefreshPasswordModel model)
        {
            try
            {
                if (String.IsNullOrEmpty(model.NewPassword) || String.IsNullOrEmpty(model.ConfirmPassword))
                {
                    ModelState.AddModelError("Password", "Vui lòng nhập đầy đủ thông tin!");
                    return ModelInvalid();
                }

                if (model.NewPassword != model.ConfirmPassword)
                {
                    ModelState.AddModelError("Password", "Mật khẩu mới và mật khẩu xác nhận không trùng khớp!");
                    return ModelInvalid();
                }

                UserDTO user = await _identityBizLogic.GetByIdAsync(UserId);

                if (user != null)
                {
                    var token = await _identityBizLogic.GeneratePasswordResetTokenAsync(user);
                    token = HttpUtility.UrlEncode(token);
                    var tryAddPassword = await _identityBizLogic.AddPasswordAsync(user, model.NewPassword);
                    if (tryAddPassword != null && tryAddPassword.Succeeded)
                    {
                        // Generate token:
                        var roles = await _userManager.GetRolesAsync(user);
                        string newToken = await _identityBizLogic.GenerateJwtToken(user, false, roles.Contains(SystemRoleConstants.ADMIN));

                        var result = new { Success = tryAddPassword.Succeeded, Token = newToken };

                        return result != null ? SaveSuccess(result) : Error("Có lỗi xảy ra trong quá trình thực hiện. Vui lòng thử lại sau ít phút!");
                    }
                    return null;
                }
                return Error("User does not exist");
            }
            catch (Exception ex)
            {
                _logger.LogError("CreatePassword: {0} {1}", ex.Message, ex.StackTrace);
                return Error("Có lỗi xảy ra trong quá trình thực hiện. Vui lòng thử lại sau ít phút!");
            }
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] RefreshPasswordModel model)
        {
            try
            {
                if (String.IsNullOrEmpty(model.Password) || String.IsNullOrEmpty(model.NewPassword) || String.IsNullOrEmpty(model.ConfirmPassword))
                {
                    ModelState.AddModelError("Password", "Vui lòng nhập đầy đủ thông tin!");
                    return ModelInvalid();
                }

                if (model.NewPassword != model.ConfirmPassword)
                {
                    ModelState.AddModelError("Password", "Mật khẩu mới và mật khẩu xác nhận không trùng khớp!");
                    return ModelInvalid();
                }

                UserDTO user = await _identityBizLogic.GetByIdAsync(UserId);

                if (user != null)
                {
                    var rightPassword = await _identityBizLogic.CheckPasswordAsync(user, model.Password);
                    if (!rightPassword)
                    {
                        ModelState.AddModelError("Password", "Mật khẩu hiện tại không đúng!");
                        return ModelInvalid();
                    }

                    var token = await _identityBizLogic.GeneratePasswordResetTokenAsync(user);
                    token = HttpUtility.UrlEncode(token);

                    var success = await _identityBizLogic.ResetPasswordAsync(UserId.ToString(), token, model.NewPassword);

                    // Generate token:
                    var roles = await _userManager.GetRolesAsync(user);
                    string newToken = await _identityBizLogic.GenerateJwtToken(user, false, roles.Contains(SystemRoleConstants.ADMIN));

                    var result = new { Success = success, Token = newToken };

                    return result != null ? SaveSuccess(result) : Error("Có lỗi xảy ra trong quá trình thực hiện. Vui lòng thử lại sau ít phút!");
                }

                return Error("User does not exist");
            }
            catch (Exception ex)
            {
                _logger.LogError("--ERROR ChangePassword failed - {0}", ex.Message);
                return Error("Có lỗi xảy ra trong quá trình thực hiện. Vui lòng thử lại sau ít phút!");
            }
        }

        [HttpGet]
        [Route("oauth-dialog-social")]
        public async Task<IActionResult> OAuthDialogSocial(Social social)
        {
            try
            {
                var redirectUri = string.Empty;
                if (social != Social.Undefined)
                {
                    var state = Guid.NewGuid().ToString();
                    var callbackUrl = string.Empty;
                    var authorizeUrl = string.Empty;
                    var scope = string.Empty;
                    switch (social)
                    {
                        case Social.Google:
                            state = $"google-{state}";
                            callbackUrl = _configuration.GetValue<string>("Google:CallbackUrl");
                            authorizeUrl = _configuration.GetValue<string>("Google:Authorization");
                            scope = "openid profile email";
                            redirectUri = $"{authorizeUrl}?response_type=code&client_id={ApiHelpers.GoogleClientId}&redirect_uri={callbackUrl}&scope={scope}&state={state}&access_type=offline&include_granted_scopes=true&prompt=consent";
                            break;
                        case Social.Facebook:
                            state = $"facebook-{state}";
                            callbackUrl = _configuration.GetValue<string>("Facebook:CallbackUrl");
                            authorizeUrl = _configuration.GetValue<string>("Facebook:DialogOauth");
                            scope = "email";
                            redirectUri = $"{authorizeUrl}?client_id={ApiHelpers.FacebookAppId}&redirect_uri={callbackUrl}&state={state}&scope={scope}&display=popup&&auth_type=rerequest";
                            break;
                        case Social.Zalo:
                            state = $"zalo-{state}";
                            callbackUrl = _configuration.GetValue<string>("Zalo:CallbackUrl");
                            authorizeUrl = _configuration.GetValue<string>("Zalo:Authorization");
                            string appId = _configuration.GetValue<string>("Zalo:AppId");
                            redirectUri = $"{authorizeUrl}?app_id={appId}&redirect_uri={callbackUrl}&state={state}";
                            break;
                        case Social.Tiktok:
                            state = $"tiktok-{state}";
                            callbackUrl = _configuration.GetValue<string>("Tiktok:CallbackUrl");
                            authorizeUrl = _configuration.GetValue<string>("Tiktok:Authorization");
                            string clientKey = _configuration.GetValue<string>("Tiktok:ClientId");
                            redirectUri = $"{authorizeUrl}?client_key={clientKey}&response_type=code&scope=user.info.basic&redirect_uri={callbackUrl}&state={state}";
                            break;
                    }
                }
                return GetSuccess(redirectUri);
            }
            catch (Exception ex)
            {
                _logger.LogError("--RenderOAuthDialogGoogle - {0}", ex.StackTrace);
                return Error("RenderOAuthDialogGoogle failed");
            }
        }

        [HttpGet]
        [Route("login-social")]
        public async Task<IActionResult> LoginSocial([FromQuery] string code, string urlCallback, string ruuid, Social social)
        {
            try
            {
                //process data
                if (social != Social.Undefined)
                {
                    var request = new RestRequest
                    {
                        Method = Method.Post
                    };
                    var tokenEndpoint = string.Empty;
                    var callbackUrl = string.Empty;
                    switch (social)
                    {
                        case Social.Google:
                            callbackUrl = _configuration.GetValue<string>("Google:CallbackUrl");
                            tokenEndpoint = _configuration.GetValue<string>("Google:TokenEndpoint");
                            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                            request.AddParameter("grant_type", "authorization_code");
                            request.AddParameter("code", code);
                            request.AddParameter("redirect_uri", callbackUrl);
                            request.AddParameter("client_id", ApiHelpers.GoogleClientId);
                            request.AddParameter("client_secret", ApiHelpers.GoogleClientSecret);
                            break;
                        case Social.Facebook:
                            callbackUrl = _configuration.GetValue<string>("Facebook:CallbackUrl");
                            tokenEndpoint = ApiHelpers.FacebookBaseAPI + PlatformConstants.Facebook_GetLongLivedUserToken;
                            request = new RestRequest();
                            request.Method = Method.Get;
                            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                            request.AddParameter("code", code);
                            request.AddParameter("redirect_uri", callbackUrl);
                            request.AddParameter("client_id", ApiHelpers.FacebookAppId);
                            request.AddParameter("client_secret", ApiHelpers.FacebookAppSecret);
                            break;
                        case Social.Zalo:
                            tokenEndpoint = "https://oauth.zaloapp.com/v4/access_token";
                            string appId = _configuration.GetValue<string>("Zalo:AppId");
                            request.Method = Method.Post;
                            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                            request.AddHeader("secret_key", _configuration.GetValue<string>("Zalo:AppSecret"));
                            request.AddParameter("code", code);
                            request.AddParameter("app_id", appId);
                            request.AddParameter("grant_type", "authorization_code");
                            break;
                        case Social.Tiktok:
                            callbackUrl = _configuration.GetValue<string>("Google:CallbackUrl");
                            tokenEndpoint = "https://open-api.tiktok.com/oauth/access_token/";
                            request = new RestRequest();
                            request.Method = Method.Post;
                            request.AddQueryParameter("code", code);
                            request.AddQueryParameter("client_key", _configuration.GetValue<string>("Tiktok:ClientId"));
                            request.AddQueryParameter("client_secret", _configuration.GetValue<string>("Tiktok:ClientSecret"));
                            request.AddQueryParameter("grant_type", "authorization_code");
                            break;
                    }
                    var response = await new RestClient(tokenEndpoint).ExecuteAsync(request);
                    if (response != null)
                    {
                        if (response.ErrorMessage == Constants.ErrorAuth) return SaveError(Constants.ErrorAuth);
                        else if (response.StatusCode == HttpStatusCode.GatewayTimeout) return SaveError("Request Timeout");
                        else
                        {
                            var content = response.Content;
                            if (!string.IsNullOrWhiteSpace(content))
                            {
                                object tokenModel = null;
                                switch (social)
                                {
                                    case Social.Google:
                                        var res = JsonConvert.DeserializeObject<GoogleTokenModel>(content);
                                        if (res != null && !string.IsNullOrWhiteSpace(res.Id_token))
                                            tokenModel = res;
                                        break;
                                    case Social.Facebook:
                                        var tokenResponse = JsonConvert.DeserializeObject<FacebookTokenModel>(content);
                                        if (tokenResponse != null && !string.IsNullOrEmpty(tokenResponse.AccessToken))
                                            tokenModel = tokenResponse;
                                        break;
                                    case Social.Zalo:
                                        ZaloUserTokenModel userTokenModel = JsonConvert.DeserializeObject<ZaloUserTokenModel>(content);
                                        if (userTokenModel != null && !string.IsNullOrEmpty(userTokenModel.access_token))
                                            tokenModel = userTokenModel;
                                        break;
                                    case Social.Tiktok:
                                        TiktokUserTokenModelRoot tiktokUserTokenModel = JsonConvert.DeserializeObject<TiktokUserTokenModelRoot>(content);
                                        if (tiktokUserTokenModel != null && tiktokUserTokenModel.data != null && !string.IsNullOrEmpty(tiktokUserTokenModel.data.access_token))
                                            tokenModel = tiktokUserTokenModel.data;
                                        break;
                                }
                                var responseLogin = await LoginHandler(tokenModel, ruuid, urlCallback, social);
                                if (!responseLogin.Item1) return SaveError(responseLogin.Item2);
                                return SaveSuccess(responseLogin.Item2);
                            }
                        }
                    }
                }
                return SaveError($"Có lỗi xảy ra trong quá trình đăng nhập");
            }
            catch (Exception ex)
            {
                _logger.LogError("LoginSocial {0} {1}", ex.Message, ex.StackTrace);
                return Error("Đăng nhập thất bại");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _identityBizLogic.GetByEmailAsync(model.Email);

            if (user != null)
            {
                var rightPassword = await _identityBizLogic.CheckPasswordAsync(user, model.Password);
                if (!rightPassword)
                {
                    return Error(Constants.PasswordIsInCorrect);
                }

                // Generate token:
                var roles = await _userManager.GetRolesAsync(user);
                string accessToken = await _identityBizLogic.GenerateJwtToken(user, false, roles.Contains(SystemRoleConstants.ADMIN));

                var result = new App_LoginResponse
                {
                    AccessToken = accessToken,
                    Redirect = string.IsNullOrEmpty(model.Redirect) ? "/" : model.Redirect
                };
                return result != null ? SaveSuccess(result) : Error("Có lỗi xảy ra trong quá trình thực hiện. Vui lòng thử lại sau ít phút!");
            }

            return Error("User không tồn tại");

            //var accessToken = await _identityBizLogic.GenerateJwtToken(user, isRemember: false, isAdmin: false);
            //var redirect = string.IsNullOrEmpty(model.Redirect) ? "/" : model.Redirect;
            //var result = new App_LoginResponse
            //{
            //    AccessToken = accessToken,
            //    Redirect = redirect
            //};

            //return GetSuccess(result);

        }

        [HttpPost("get-info-user")]
        [TFUAuthorize]
        public async Task<IActionResult> GetInfoUser()
        {
            try
            {
                var userId = UserId;
                var info = await _identityBizLogic.GetByIdAsync(userId);
                return GetSuccess(info);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetInfoUser: {0} {1}", ex.Message, ex.StackTrace);
                return SaveError();
            }

        }

        [HttpGet("get-html-policy")]
        public IActionResult GetHtmlPolicy()
        {
            try
            {
                var htmlPath = PathConstant.GetFilePath(PathConstant.PrivacyPolicy);
                var html = System.IO.File.ReadAllText(htmlPath);
                return Ok(html);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, "An error occurred while retrieving the HTML policy.");
            }
        }



        #region Private
        private async Task<bool> SendEmailConfirm(UserDTO user, string email)
        {
            var code = await _identityBizLogic.GenerateEmailConfirmationTokenAsync(user);
            var homeUrl = _configuration.GetSection("AppSettings:HomeUrl").Value;
            var callbackUrl = string.Format("{0}/confirm-email?userId={1}&token={2}", homeUrl, user.Id.ToString(), HttpUtility.UrlEncode(code));
            var htmlPath = PathConstant.GetFilePath(PathConstant.BuyerRegister);
            var html = System.IO.File.ReadAllText(htmlPath);
            var contentBuilder = new ContentBuilder(html);
            contentBuilder.BuildCallback(new System.Collections.Generic.List<ObjectReplace>() { new ObjectReplace() { Name = "__calback_url__", Value = callbackUrl } });
            var content = contentBuilder.GetContent() ?? $"Vui lòng xác nhận tài khoản đăng ký bằng cách nhấn vào: <a href='{callbackUrl}'>Xác nhận</a>";
            await _emailSender.SendEmailAsync(email, "Xác nhận email đăng ký tài khoản", content);
            return true;
        }
        private async Task<Tuple<bool, string>> LoginHandler(object tokenModel, string ruuid, string redirect, Social social)
        {
            try
            {
                if (tokenModel == null)
                {
                    _logger.LogError("Social Login {0} - ERROR", social.ToString());
                    return new Tuple<bool, string>(false, "Token rỗng");
                }

                bool isSuccessful = false;
                RestClient client = new RestClient();
                var restRequest = new RestRequest();
                UserDTO userDTO = null;
                var socialid = string.Empty;
                switch (social)
                {
                    case Social.Google:
                        client = new RestClient(ApiHelpers.GoogleOAuthUrl);
                        GoogleTokenModel googleTokenModel = (GoogleTokenModel)tokenModel;
                        restRequest = new RestRequest($"?id_token={googleTokenModel.Id_token}");
                        var response = await client.ExecuteGetAsync<GoogleResponseModel>(restRequest);
                        isSuccessful = response != null && response.StatusCode.Equals(HttpStatusCode.OK) && response.Content != null;
                        if (isSuccessful)
                        {
                            GoogleResponseModel model = JsonConvert.DeserializeObject<GoogleResponseModel>(response.Content);
                            if (!model.Aud.Equals(ApiHelpers.GoogleClientId))
                            {
                                _logger.LogError("GoogleLogin {0}", googleTokenModel.Access_token);
                                return new Tuple<bool, string>(false, "Phiên đăng nhập đang bị giả mạo.");
                            }
                            if (string.IsNullOrEmpty(model.Email))
                            {
                                _logger.LogError("API Google không trả về email {0}", googleTokenModel.Access_token);
                                return new Tuple<bool, string>(false, "API Google không trả về email.");
                            }

                            string email = model.Email;
                            userDTO = new UserDTO
                            {
                                UserName = email,
                                Email = email,
                                NormalizedEmail = email.ToUpper(),
                                NormalizedUserName = email.ToUpper(),
                                FirstName = model.Name,
                                LastName = model.Given_name,
                                Avatar = model.Picture,
                                EmailConfirmed = model.Email_verified,
                                GoogleUserId = model.Sub
                            };
                            socialid = model.Sub;
                        }
                        break;
                    case Social.Facebook:
                        client = new RestClient(ApiHelpers.FacebookGraphAPI);
                        FacebookTokenModel facebookTokenModel = (FacebookTokenModel)tokenModel;
                        restRequest = new RestRequest($"me?access_token={facebookTokenModel.AccessToken}&fields=email,picture,first_name,last_name");
                        var responseFb = await client.ExecuteGetAsync<FacebookUserModel>(restRequest);
                        isSuccessful = responseFb != null && responseFb.IsSuccessful && responseFb.Data != null;
                        if (isSuccessful)
                        {
                            FacebookUserModel model = responseFb.Data;
                            string email = model.Email;
                            if (string.IsNullOrEmpty(email)) email = $"fb.{model.Id}@ranus.vn";
                            userDTO = new UserDTO
                            {
                                UserName = email,
                                NormalizedUserName = email.ToUpper(),
                                FirstName = model.FirstName,
                                LastName = model.LastName,
                                Avatar = model.Picture.Data.Url,
                                EmailConfirmed = !string.IsNullOrEmpty(email),
                                FacebookUserId = model.Id
                            };
                            socialid = model.Id;
                        }
                        break;
                    case Social.Zalo:
                        ZaloUserTokenModel zaloUserTokenModel = (ZaloUserTokenModel)tokenModel;
                        client = new RestClient("https://graph.zalo.me/v2.0/");
                        restRequest = new RestRequest("me?fields=picture,id,name");
                        restRequest.AddHeader("access_token", zaloUserTokenModel.access_token);
                        var ress = await client.ExecuteGetAsync<ZaloUserInfoResponseModel>(restRequest);
                        if (ress.IsSuccessful && ress.Data != null)
                        {
                            isSuccessful = true;
                            ZaloUserInfoResponseModel model = ress.Data;
                            string email = $"zl.{model.id}@ranus.vn";
                            userDTO = new UserDTO
                            {
                                UserName = email,
                                NormalizedUserName = email.ToUpper(),
                                Avatar = model.picture.data.url,
                                EmailConfirmed = true
                            };
                            socialid = model.id;
                            if (!string.IsNullOrEmpty(model.name))
                            {
                                string[] names = model.name.Split(' ');
                                userDTO.FirstName = names.Length > 0 ? names[0] : String.Empty;
                                userDTO.LastName = names.Length > 1 ? names[1] : String.Empty;
                            }
                        }
                        break;
                    case Social.Tiktok:
                        TiktokUserTokenModel tiktokUserTokenModel = (TiktokUserTokenModel)tokenModel;
                        client = new RestClient($"https://open-api.tiktok.com/user/info/?access_token={tiktokUserTokenModel.access_token}");
                        restRequest = new RestRequest();
                        restRequest.Method = Method.Post;
                        restRequest.AddHeader("Content-Type", "application/json");
                        restRequest.AddJsonBody(new
                        {
                            fields = new[] { "open_id", "union_id", "avatar_url", "avatar_url_100", "avatar_url_200", "avatar_large_url", "display_name" }
                        });
                        var res = await client.ExecutePostAsync<TiktokRootobject>(restRequest);
                        if (res.IsSuccessful && res.Data != null)
                        {
                            isSuccessful = true;
                            TiktokUserInfoResponseModel model = res.Data.data.user;
                            string email = $"tt.{model.union_id}@ranus.vn";
                            userDTO = new UserDTO
                            {
                                UserName = email,
                                NormalizedUserName = email.ToUpper(),
                                Avatar = model.avatar_url,
                                EmailConfirmed = true
                            };
                            if (!string.IsNullOrEmpty(model.display_name))
                            {
                                string[] names = model.display_name.Split(' ');
                                userDTO.FirstName = names.Length > 0 ? names[0] : String.Empty;
                                userDTO.LastName = names.Length > 1 ? names[1] : String.Empty;
                            }
                            socialid = model.open_id;
                        }
                        break;
                }

                if (isSuccessful)
                {
                    var user = await _userManager.FindByNameAsync(userDTO.UserName);
                    if (user == null)
                    {
                        long userId = await _identityBizLogic.AddUserAsync(userDTO, string.Empty);
                        if (userId <= 0) return new Tuple<bool, string>(false, "Đăng nhập thất bại.");

                        // Gửi email xác nhận
                        if (!userDTO.EmailConfirmed && !string.IsNullOrEmpty(userDTO.Email))
                            await SendEmailConfirm(userDTO, userDTO.Email);
                        user = userDTO;
                    }

                    switch (social)
                    {
                        case Social.Google:
                            if (string.IsNullOrEmpty(user.GoogleUserId) || user.EmailConfirmed != userDTO.EmailConfirmed)
                            {
                                user.GoogleUserId = socialid;
                                user.EmailConfirmed = userDTO.EmailConfirmed;
                                await _identityBizLogic.UpdateAsync(user);
                            }
                            break;
                        case Social.Facebook:
                            if (string.IsNullOrEmpty(user.FacebookUserId))
                            {
                                user.FacebookUserId = socialid;
                                await _identityBizLogic.UpdateAsync(user);
                            }
                            break;
                    }

                    // Generate Token
                    string token = await _identityBizLogic.GenerateJwtToken(user, isRemember: false, isAdmin: false);

                    // Response User
                    var responseUser = new
                    {
                        token,
                        user = new UserViewModel
                        {
                            Id = user.Id,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            FullName = $"{user.FirstName} {user.LastName}",
                            Avatar = user.Avatar,
                            Email = user.Email,
                            PhoneNumber = user.PhoneNumber,
                            Username = user.UserName
                        },
                        googleUserId = user.GoogleUserId,
                        facebookUserId = user.FacebookUserId,
                        zaloUserId = user.ZaloUserId,
                        tiktokUserId = user.TiktokUserId,
                        emailConfirm = user.EmailConfirmed,
                        redirect = string.IsNullOrEmpty(redirect) ? "/" : redirect
                    };
                    return new Tuple<bool, string>(true, JsonConvert.SerializeObject(responseUser));
                }

                _logger.LogError("Can't create account!");
                return new Tuple<bool, string>(false, "Đăng nhập thất bại.");
            }
            catch (Exception ex)
            {
                _logger.LogError("LoginHandler: {0} {1}", ex.Message, ex.StackTrace);
                return new Tuple<bool, string>(false, "Đăng nhập thất bại.");
            }
        }

        #endregion
    }
}
