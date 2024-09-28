using App.BLL.Interfaces;
using App.Entity.Enums;
using App.Entity.Models;
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
	[Authorize]
	public class ShoesController : BaseAPIController
	{
		private readonly IShoesBizLogic _shoesBizLogic;
		private readonly IIdentityBizLogic _identityBizLogic;
		private readonly ILogger<ShoesController> _logger;
		private readonly IBrandsBizLogic _brandsBizLogic;

		public ShoesController(IShoesBizLogic shoesBizLogic, IIdentityBizLogic identityBizLogic,
								ILogger<ShoesController> logger, IBrandsBizLogic brandsBizLogic)
        {
			this._shoesBizLogic = shoesBizLogic;
			this._identityBizLogic = identityBizLogic;
			this._logger = logger;
			this._brandsBizLogic = brandsBizLogic;
		}

		[HttpPost]
		[Route("create-update-shoes")]
		public async Task<IActionResult> CreateUpdateShoes(ShoesModel model)
		{
			try
			{
				if (!ModelState.IsValid) return ModelInvalid();

				var existedBrand = await _brandsBizLogic.GetBrandByName(model.BrandName);
				if(existedBrand == null)
				{
					ModelState.AddModelError("BrandName", $"Hãng giày {model.BrandName} không tồn tại");
					return ModelInvalid();
				}

				if(!existedBrand.IsActive)
				{
					ModelState.AddModelError("BrandName", $"Hãng giày {model.BrandName} hiện không khả dụng.");
					return ModelInvalid();
				}

				var existedShoes = await _shoesBizLogic.GetShoesByName(model.Name);
				if(existedShoes != null)
				{
					ModelState.AddModelError("Name", $"Tên giày {model.Name} đã tồn tại. Vui lòng chọn tên khác");
					return ModelInvalid();
				}

				var user = await _identityBizLogic.GetByIdAsync(UserId);
				if (user == null) return GetError("Người dùng không tìm thấy.");
				model.CreatedBy = user.UserName;
				model.ModifyBy = user.UserName;

				var response = await _shoesBizLogic.CreateUpadteShoes(model);
				if (!response.IsSuccess) return SaveError(response.Message);
				return SaveSuccess(response);
			}
			catch (Exception ex)
			{
				_logger.LogError("CreateUpdateShoes: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpGet]
		[Route("get-shoes/{id}")]
		public async Task<IActionResult> GetShoes([FromRoute] long id)
		{
			try
			{
				var response = await _shoesBizLogic.GetShoes(id);
				if (response == null || response.IsActive == false) return GetError("Giày không tồn tại");
				return GetSuccess(response);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetShoes: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPost]
		[Route("get-all-shoes-by-paging")]
		public async Task<IActionResult> GetListShoes([FromBody] PagingModel paging)
		{
			try
			{
				var data = await _shoesBizLogic.GetListShoes(paging);
				var result = new PagingDataModel<ShoesModel>(data, paging);
				return GetSuccess(result);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetAllShoes: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPost]
		[Route("delete-shoes/{id}")]
		public async Task<IActionResult> DeleteShoes([FromRoute] long id)
		{
			try
			{
				var response = await _shoesBizLogic.DeleteShoes(id);
				if(!response.IsSuccess) return SaveError(response);
				return SaveSuccess(response);
			}
			catch(Exception ex)
			{
				_logger.LogError("DeleteShoes: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPost]
		[Route("search-shoes-by-key")]
		public async Task<IActionResult> GetListShoesByKey([FromBody] PagingModel paging)
		{
			try
			{
				var data = await _shoesBizLogic.GetListShoesByKey(paging);
				var result = new PagingDataModel<ShoesModel>(data, paging);
				return GetSuccess(result);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetAllShoes: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPost]
		[Route("search-shoes-by-price")]
		public async Task<IActionResult> GetListShoesByPrice([FromBody] PagingModel paging)
		{
			try
			{
				var data = await _shoesBizLogic.GetListShoesByPrice(paging);
				var result = new PagingDataModel<ShoesModel>(data, paging);
				return GetSuccess(result);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetAllShoes: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPost]
		[Route("search-shoes-by-brand")]
		public async Task<IActionResult> GetListShoesByBrand([FromBody] PagingModel paging)
		{
			try
			{
				var data = await _shoesBizLogic.GetListShoesByBrand(paging);
				var result = new PagingDataModel<ShoesModel>(data, paging);
				return GetSuccess(result);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetAllShoes: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}
	}
}
