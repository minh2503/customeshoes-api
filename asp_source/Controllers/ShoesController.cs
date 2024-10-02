using App.BLL.Interfaces;
using App.Entity.Enums;
using App.Entity.Models;
using App.Entity.Models.Shoes;
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

		[Authorize]
		[HttpPost]
		[Route("create-shoes")]
		public async Task<IActionResult> CreateShoes(ShoesRequestModel model)
		{
			try
			{
				if (!ModelState.IsValid) return ModelInvalid();

				var response = await _shoesBizLogic.CreateShoes(model, UserName);
				if (!response.IsSuccess) return SaveError(response.Message);
				return SaveSuccess(response);
			}
			catch (Exception ex)
			{
				_logger.LogError("CreateShoes: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[Authorize]
		[HttpPut]
		[Route("update-shoes")]
		public async Task<IActionResult> UpdateShoes(ShoesUpdateModel model)
		{
			try
			{
				if (!ModelState.IsValid) return ModelInvalid();

				var response = await _shoesBizLogic.UpdateShoes(model, UserName);
				if (!response.IsSuccess) return SaveError(response.Message);
				return SaveSuccess(response);
			}
			catch (Exception ex)
			{
				_logger.LogError("CreateShoes: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpGet]
		[Route("get-shoes/{id}")]
		public async Task<IActionResult> GetShoesById([FromRoute] long id)
		{
			try
			{
				var response = await _shoesBizLogic.GetShoesById(id);
				if (response == null) return GetError("Giày không tồn tại");
				return GetSuccess(response);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetShoes: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPost]
		[Route("get-all-shoes")]
		public async Task<IActionResult> GetListShoes([FromBody] PagingModel paging)
		{
			try
			{
				var data = await _shoesBizLogic.GetListShoes(paging);
				var result = new PagingDataModel<ShoesViewModel>(data, paging);
				return GetSuccess(result);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetAllShoes: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpGet]
		[Route("get-random-4-shoes")]
		public async Task<IActionResult> GetRandom4Shoes()
		{
			try
			{
				var data = await _shoesBizLogic.GetRandom4Shoes();
				return GetSuccess(data);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetAllShoes: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[Authorize]
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
		[Route("filter-shoes-by-key")]
		public async Task<IActionResult> GetListShoesByKey([FromBody] PagingModel paging)
		{
			try
			{
				var data = await _shoesBizLogic.GetListShoesByKey(paging);
				var result = new PagingDataModel<ShoesViewModel>(data, paging);
				return GetSuccess(result);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetAllShoes: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPost]
		[Route("filter-shoes-by-price")]
		public async Task<IActionResult> GetListShoesByPrice([FromBody] PagingModel paging)
		{
			try
			{
				var data = await _shoesBizLogic.GetListShoesByPrice(paging);
				var result = new PagingDataModel<ShoesViewModel>(data, paging);
				return GetSuccess(result);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetAllShoes: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPost]
		[Route("filter-shoes-by-brand")]
		public async Task<IActionResult> GetListShoesByBrand([FromBody] PagingModel paging)
		{
			try
			{
				var data = await _shoesBizLogic.GetListShoesByBrand(paging);
				var result = new PagingDataModel<ShoesViewModel>(data, paging);
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
