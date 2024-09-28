using App.BLL.Implements;
using App.BLL.Interfaces;
using App.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TFU.APIBased;
using TFU.BLL.Interfaces;
using TFU.Common.Models;

namespace tapluyen.api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShoesImagesController : BaseAPIController
	{
		private readonly IShoesImagesBizLogic _shoesImagesBizLogic;
		private readonly IIdentityBizLogic _identityBizLogic;
		private readonly ILogger<ShoesImagesController> _logger;
		private readonly IShoesBizLogic _shoesBizLogic;

		public ShoesImagesController(IShoesImagesBizLogic shoesImagesBizLogic,
                                    IIdentityBizLogic identityBizLogic, ILogger<ShoesImagesController> logger,
									IShoesBizLogic shoesBizLogic)
        {
			this._shoesImagesBizLogic = shoesImagesBizLogic;
			this._identityBizLogic = identityBizLogic;
			this._logger = logger;
			this._shoesBizLogic = shoesBizLogic;
		}

		[HttpPost]
		[Route("create-update-shoes-images")]
		public async Task<IActionResult> CreateUpdateShoesImages([FromBody] ShoesImagesModel model)
		{
			try
			{
				if (!ModelState.IsValid) return ModelInvalid();

				var existedShoes = await _shoesBizLogic.GetShoes(model.ShoesId);
				if(existedShoes == null || existedShoes.IsActive == false)
				{
					ModelState.AddModelError("ShoesId", "Giày không khả dụng.");
					return ModelInvalid();
				}
					
				var response = await _shoesImagesBizLogic.CreateUpdateShoesImages(model);
				if (!response.IsSuccess) return SaveError(response.Message);
				return SaveSuccess(response);
			}
			catch (Exception ex)
			{
				_logger.LogError("CreateUpdateShoesImages: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpGet]
		[Route("get-shoes-images/{id}")]
		public async Task<IActionResult> GetShoesImages([FromRoute] long id)
		{
			try
			{
				var response = await _shoesImagesBizLogic.GetShoesImages(id);
				if (response == null) return GetError("Không tìm thấy ảnh.");
				return GetSuccess(response);
			}

			catch (Exception ex)
			{
				_logger.LogError("GetShoesImages: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPost()]
		[Route("get-all-shoes-images-by-paging")]
		public async Task<IActionResult> GetAllShoesImages([FromBody] PagingModel paging)
		{
			try
			{
				var data = await _shoesImagesBizLogic.GetListShoesImages(paging);
				var result = new PagingDataModel<ShoesImagesModel>(data, paging);
				return GetSuccess(result);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetAllShoesImages: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPost()]
		[Route("get-all-shoes-images-by-shoes-paging")]
		public async Task<IActionResult> GetAllShoesImagesByShoes([FromBody] PagingModel paging)
		{
			try
			{
				if(paging.ShoesId == 0)
				{
					ModelState.AddModelError("ShoesId", "Không được để trống ShoesId.");
					return ModelInvalid();
				}

				var shoes = await _shoesBizLogic.GetShoes(paging.ShoesId);
				if(shoes == null || shoes.IsActive == false)
				{
					ModelState.AddModelError("ShoesId", "Giày không khả dụng.");
					return ModelInvalid();
				}
				var data = await _shoesImagesBizLogic.GetListShoesImagesByShoes(paging);
				var result = new PagingDataModel<ShoesImagesModel>(data, paging);
				return GetSuccess(result);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetAllShoesImagesByShoes: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPost()]
		[Route("get-all-user-custom-shoes-images-by-shoes-paging")]
		public async Task<IActionResult> GetUserCustomShoesImagesByShoes([FromBody] PagingModel paging)
		{
			try
			{
				if (paging.ShoesId == 0)
				{
					ModelState.AddModelError("ShoesId", "Không được để trống ShoesId.");
					return ModelInvalid();
				}

				var shoes = await _shoesBizLogic.GetShoes(paging.ShoesId);
				if (shoes == null || shoes.IsActive == false)
				{
					ModelState.AddModelError("ShoesId", "Giày không khả dụng.");
					return ModelInvalid();
				}
				var data = await _shoesImagesBizLogic.GetUserCustomShoesImagesByShoes(paging);
				var result = new PagingDataModel<ShoesImagesModel>(data, paging);
				return GetSuccess(result);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetUserCustomShoesImagesByShoes: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}
	}
}
