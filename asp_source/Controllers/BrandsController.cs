using App.BLL.Implements;
using App.BLL.Interfaces;
using App.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TFU.APIBased;

namespace tapluyen.api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController : BaseAPIController
	{
		private readonly IBrandsBizLogic _brandsBizLogic;
		private readonly ILogger<BrandsController> _logger;

		public BrandsController(IBrandsBizLogic brandsBizLogic, ILogger<BrandsController> logger)
        {
			this._brandsBizLogic = brandsBizLogic;
			this._logger = logger;
		}

		[HttpPost("create-update-brands")]
		public async Task<IActionResult> CreateUpdateBrands([FromBody] BrandModel model)
		{
			try
			{
				if (!ModelState.IsValid) return ModelInvalid();
				var response = await _brandsBizLogic.CreateUpadteBrands(model);
				if (!response.IsSuccess) return SaveError(response.Message);
				return SaveSuccess(response);
			}
			catch (Exception ex)
			{
				_logger.LogError("CreateUpdateBrands: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpGet]
		[Route("get-brand/{id}")]
		public async Task<IActionResult> GetUserDetail([FromRoute]long id)
		{
			try
			{
				var response = await _brandsBizLogic.GetBrand(id);
				if(response == null) return GetError();
				return SaveSuccess(response);
			}

			catch (Exception ex)
			{
				_logger.LogError("GetUserDetail: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}
	}
}
