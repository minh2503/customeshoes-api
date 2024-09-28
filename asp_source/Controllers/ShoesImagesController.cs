using App.BLL.Implements;
using App.BLL.Interfaces;
using App.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TFU.APIBased;
using TFU.BLL.Interfaces;

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
	}
}
