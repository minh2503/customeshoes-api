using App.BLL.Interfaces;
using App.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TFU.APIBased;
using TFU.BLL.Implements;
using TFU.BLL.Interfaces;
using TFU.Common.Models;

namespace tapluyen.api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class CheckOutController : BaseAPIController
	{
		private readonly IShoesBizLogic _shoesBizLogic;
		private readonly ILogger<CheckOutController> _logger;
		private readonly IShoesImagesBizLogic _shoesImagesBizLogic;
		private readonly ICheckOutBizLogic _checkOutBizLogic;
		private readonly IIdentityBizLogic _identityBizLogic;

		public CheckOutController(IShoesBizLogic shoesBizLogic, ILogger<CheckOutController> logger,
									IShoesImagesBizLogic shoesImagesBizLogic, ICheckOutBizLogic checkOutBizLogic,
									IIdentityBizLogic identityBizLogic)
        {
			this._shoesBizLogic = shoesBizLogic;
			this._logger = logger;
			this._shoesImagesBizLogic = shoesImagesBizLogic;
			this._checkOutBizLogic = checkOutBizLogic;
			this._identityBizLogic = identityBizLogic;
		}

		[HttpPost]
		[Route("check-out")]
		public async Task<IActionResult> CheckOutAsync(CheckOutModel model)
		{
			try
			{
				if (!ModelState.IsValid) return ModelInvalid();

				var user = await _identityBizLogic.GetByIdAsync(UserId);
				if (user == null)
				{
					return Error("Không tìm thấy người dùng");
				}
				model.UserId = user.Id;

				var existedShoes = await _shoesBizLogic.GetShoes(model.ShoesId);
				if (existedShoes == null || existedShoes.IsActive == false)
				{
					ModelState.AddModelError("ShoesId", "Giày không khả dụng.");
					return ModelInvalid();
				}

				var existedImage = await _shoesImagesBizLogic.GetShoesImages(model.ShoesImageId);
				if (!existedImage.ShoesId.Equals(model.ShoesId))
				{
					ModelState.AddModelError("ShoesImageId", "Ảnh không khớp với giày.");
					return ModelInvalid();
				}
				if (existedImage.IsUserCustom == false)
				{
					ModelState.AddModelError("ShoesImageId", "Ảnh không phải do người dùng custom.");
					return ModelInvalid();
				}

				var response = await _checkOutBizLogic.CheckOutAsync(model, existedShoes);
				if (!response.IsSuccess) return SaveError(response.Message);
				return SaveSuccess(response);
			}
			catch (Exception ex)
			{
				_logger.LogError("CheckOutAsync: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPatch]
		[Route("update-order/{id}")]
		public async Task<IActionResult> UpdateOrder(long id, JsonPatchDocument<OrderModel> model)
		{
			try
			{
				if (!ModelState.IsValid) return ModelInvalid();

				var user = await _identityBizLogic.GetByIdAsync(UserId);
				if (user == null)
				{
					return Error("Không tìm thấy người dùng");
				}

				var order = await _checkOutBizLogic.GetOrdersById(id);
				if(order == null)
				{
					return GetError("Không tìm thấy order.");
				}
				model.ApplyTo(order, ModelState);

				var response = await _checkOutBizLogic.UpdateOrder(order);
				if (!response.IsSuccess) return SaveError(response.Message);
				return SaveSuccess(response);
			}
			catch (Exception ex)
			{
				_logger.LogError("UpdateOrder: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPost]
		[Route("get-all-orders-by-paging")]
		public async Task<IActionResult> GetAllOrders([FromBody] PagingModel paging)
		{
			try
			{
				var data = await _checkOutBizLogic.GetAllOrders(paging);
				var result = new PagingDataModel<OrderModel>(data, paging);
				return GetSuccess(result);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetAllOrders: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPost]
		[Route("get-all-orders-by-status")]
		public async Task<IActionResult> GetAllOrdersByStatus([FromBody] PagingModel paging)
		{
			try
			{
				var data = await _checkOutBizLogic.GetAllOrdersByStatus(paging);
				var result = new PagingDataModel<OrderModel>(data, paging);
				return GetSuccess(result);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetAllOrdersByStatus: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPost]
		[Route("get-all-orders-by-userId")]
		public async Task<IActionResult> GetAllOrdersByKey([FromBody] PagingModel paging)
		{
			try
			{
				var data = await _checkOutBizLogic.GetAllOrdersByKey(paging);
				var result = new PagingDataModel<OrderModel>(data, paging);
				return GetSuccess(result);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetAllOrdersByKey: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}
	}
}
