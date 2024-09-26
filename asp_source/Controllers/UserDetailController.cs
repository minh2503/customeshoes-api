using App.BLL.Interfaces;
using App.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TFU.APIBased;
using TFU.Common.Models;

namespace tapluyen.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserDetailController : BaseAPIController
    {
        private readonly IUserDetailsBizLogic _userDetailsBizLogic;
        private readonly ILogger<UserDetailController> _logger;

        public UserDetailController(IUserDetailsBizLogic userDetailsBizLogic, ILogger<UserDetailController> logger)
        {
            _userDetailsBizLogic = userDetailsBizLogic;
            _logger = logger;
        }

        [HttpPost("create-update-user-details")]
        public async Task<IActionResult> CreateUpdateUserDetails([FromBody] UserDetailModel dto)
        {
            try
            {
                if (!ModelState.IsValid) return ModelInvalid();
                var userId = UserId;
                var response = await _userDetailsBizLogic.CreateUpadteUserDetails(dto, userId);
                if (!response.IsSuccess) return SaveError(response.Message);
                return SaveSuccess(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("CreateUpdateUserDetails: {0} {1}", ex.Message, ex.StackTrace);
                return SaveError(ex.Message);
            }
        }

        [HttpGet("get-user-detail")]
        public async Task<IActionResult> GetUserDetail()
        {
            try
            {
                var userId = UserId;
                var response = await _userDetailsBizLogic.GetUserDetail(userId);
                return SaveSuccess(response);
            }

            catch (Exception ex)
            {
                _logger.LogError("GetUserDetail: {0} {1}", ex.Message, ex.StackTrace);
                return SaveError(ex.Message);
            }
        }
        [HttpPost("get-all-user-detail-by-paging")]
        public async Task<IActionResult> GetAllUserDetail([FromBody] PagingModel paging)
        {
            try
            {
                var data = await _userDetailsBizLogic.GetListUserDetail(paging);
                var result = new PagingDataModel<UserDetailModel>(data, paging);
                return SaveSuccess(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetAllUserDetail: {0} {1}", ex.Message, ex.StackTrace);
                return SaveError(ex.Message);
            }
        }

        [HttpPost]
        [Route("delete-user-detail")]
        public async Task<IActionResult> DeleteUserDetailAsync()
        {
            var userId = UserId;
            var response = await _userDetailsBizLogic.DeleteUserDetailAsync(userId);
			if (!response.IsSuccess) return SaveError(response.Message);
			return SaveSuccess(response);
		}
    }
}
