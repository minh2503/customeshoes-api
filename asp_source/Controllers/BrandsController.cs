using App.BLL.Implements;
using App.BLL.Interfaces;
using App.Entity.Models;
using App.Entity.Models.Brands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TFU.APIBased;
using TFU.BLL.Interfaces;
using TFU.Common.Models;

namespace tapluyen.api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController : BaseAPIController
	{
		private readonly IBrandsBizLogic _brandsBizLogic;
		private readonly ILogger<BrandsController> _logger;
		private readonly IIdentityBizLogic _identityBizLogic;

		public BrandsController(IBrandsBizLogic brandsBizLogic, ILogger<BrandsController> logger, IIdentityBizLogic identityBizLogic)
        {
			this._brandsBizLogic = brandsBizLogic;
			this._logger = logger;
			this._identityBizLogic = identityBizLogic;
		}

		[Authorize]
		[HttpPost("create-update-brands")]
		public async Task<IActionResult> CreateUpdateBrands([FromBody] BrandRequestModel model)
		{
			try
			{
				var response = await _brandsBizLogic.CreateUpadteBrands(model, UserName);
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
		public async Task<IActionResult> GetBrand([FromRoute]long id)
		{
			try
			{
				var response = await _brandsBizLogic.GetBrand(id);
				if(response == null || response.IsActive == false) return GetError("Hãng giày không tìm thấy.");
				return GetSuccess(response);
			}

			catch (Exception ex)
			{
				_logger.LogError("GetBrand: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPost("get-all-brands-by-paging")]
		public async Task<IActionResult> GetAllBrands([FromBody] PagingModel paging)
		{
			try
			{
				var data = await _brandsBizLogic.GetListBrands(paging);
				var result = new PagingDataModel<BrandModel>(data, paging);
				return GetSuccess(result);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetAllBrands: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpGet("get-top-5-brand")]
		public async Task<IActionResult> GetTop5Brand()
		{
			try
			{
				var data = await _brandsBizLogic.GetTop5Brand();
				return GetSuccess(data);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetAllBrands: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[Authorize]
		[HttpPost]
		[Route("delete-brand/{id}")]
		public async Task<IActionResult> DeleteBrand([FromRoute]long id)
		{
			try
			{
				var response = await _brandsBizLogic.DeleteBrand(id);
				if (!response.IsSuccess) return SaveError(response.Message);
				return SaveSuccess(response);
			}
			catch(Exception ex)
			{
				_logger.LogError("DeleteBrand: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}
	}
}
