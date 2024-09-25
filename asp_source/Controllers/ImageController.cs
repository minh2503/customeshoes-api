using App.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using System;
using TFU.APIBased;
using TFU.Utility;
using static System.Net.WebRequestMethods;

namespace tapluyen.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : BaseAPIController
    {
        private readonly ILogger<ImageController> _logger;
        private readonly IHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly long _fileSizeLimit = 10 * 1024 * 1024;


        public ImageController(ILogger<ImageController> logger, IHostEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        [HttpPost("upload-customize-photo")]
        public async Task<IActionResult> UploadCustomizePhoto(IFormFile file)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    var extension = Path.GetExtension(file.FileName);
                    _logger.LogInformation("Extension: {0}", extension);
                    var isSvg = extension.Equals(".svg");
                    var isValid = IsValidFileExtension(file.FileName, new string[] { ".jpg", ".png", ".svg", ".jpeg", ".dng" });
                    if (!isValid)
                    {
                        ModelState.AddModelError("File", "Không hỗ trợ định dạng ảnh hiện tại.");
                        return ModelInvalid();
                    }
                    if (file.Length > _fileSizeLimit)
                    {
                        var megabyteSizeLimit = _fileSizeLimit / 1048576;
                        ModelState.AddModelError("File", $"Kích thước ảnh vượt quá quy định cho phép ({megabyteSizeLimit:N1} MB).");
                        return ModelInvalid();
                    }
                    var guidFileName = Path.GetRandomFileName();
                    var guildStringPath = new string[] { "images", IsAdmin ? String.Empty : "stock-photo", $"{guidFileName}{extension}" };
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", Helpers.PathCombine(guildStringPath));
                    string directory = Path.GetDirectoryName(path);
                    if (!Directory.Exists(directory))
                        Directory.CreateDirectory(directory);
                    using (var fileStream = System.IO.File.Create(path))
                    {
                        await fileStream.WriteAsync(memoryStream.ToArray());
                        fileStream.Close();
                    }


                    string cdnhost = _configuration.GetSection("AppSettings").GetValue<string>("CdnUrl");
                    string imageUrl = $"{cdnhost}{Helpers.UrlCombine(guildStringPath)}";
                    string thumbUrl = isSvg ? imageUrl : $"{cdnhost}/{CompressThumbnailWithNew(path)}";
                    return SaveSuccess(new
                    {
                        Success = true,
                        ImageUrl = imageUrl,
                        ThumbnailUrl = thumbUrl
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("UploadStockPhoto: {0} {1}", ex.Message, ex.StackTrace);
                return GetError();
            }
        }
        private bool IsValidFileExtension(string fileName, string[] allowedExtensions)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            return allowedExtensions.Contains(extension);
        }

        private string CompressThumbnailWithNew(string imagePath)
        {

            var thumbnailFileName = Path.GetFileNameWithoutExtension(imagePath) + "_thumb" + Path.GetExtension(imagePath);
            var thumbnailPath = Path.Combine(Path.GetDirectoryName(imagePath), thumbnailFileName);


            return thumbnailPath;
        }
    }




}