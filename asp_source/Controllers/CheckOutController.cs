using App.BLL.Interfaces;
using App.Entity.Models;
using App.Entity.Models.Orders;
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

				if(!model.IsPaymentMethodValid())
				{
					ModelState.AddModelError("PaymentMethod", "Phương thức thanh toán không hợp lệ.");
					return ModelInvalid();
				}

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

				var response = await _checkOutBizLogic.CheckOutAsync(model, existedShoes, UserId);
				if (!response.IsSuccess) return SaveError(response.Message);
				return SaveSuccess(response);
			}
			catch (Exception ex)
			{
				_logger.LogError("CheckOutAsync: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		//[HttpPatch]
		//[Route("update-order/{id}")]
		//public async Task<IActionResult> UpdateOrder(long id, JsonPatchDocument<OrderModel> model)
		//{
		//	try
		//	{
		//		if (!ModelState.IsValid) return ModelInvalid();

		//		var user = await _identityBizLogic.GetByIdAsync(UserId);
		//		if (user == null)
		//		{
		//			return Error("Không tìm thấy người dùng");
		//		}

		//		var order = await _checkOutBizLogic.GetOrderById(id);
		//		if(order == null)
		//		{
		//			return GetError("Không tìm thấy order.");
		//		}
		//		model.ApplyTo(order, ModelState);

		//		var response = await _checkOutBizLogic.UpdateOrder(order);
		//		if (!response.IsSuccess) return SaveError(response.Message);
		//		return SaveSuccess(response);
		//	}
		//	catch (Exception ex)
		//	{
		//		_logger.LogError("UpdateOrder: {0} {1}", ex.Message, ex.StackTrace);
		//		return SaveError(ex.Message);
		//	}
		//}

		[HttpPost]
		[Route("get-all-orders")]
		public async Task<IActionResult> GetAllOrders([FromBody] PagingModel paging)
		{
			try
			{
				var data = await _checkOutBizLogic.GetAllOrders(paging);
				if (data == null) return GetError();
				if(!data.Any()) return GetSuccess("Chưa có đơn order nào.");
				var result = new PagingDataModel<OrderDetailModel>(data, paging);
				return GetSuccess(result);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetAllOrders: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPost]
		[Route("filter-all-orders-by-status")]
		public async Task<IActionResult> GetAllOrdersByStatus([FromBody] PagingModel paging)
		{
			try
			{
				var data = await _checkOutBizLogic.GetAllOrdersByStatus(paging);
				if (data == null) return GetError();
				if (!data.Any()) return GetSuccess("Chưa có đơn order nào.");
				var result = new PagingDataModel<OrderDetailModel>(data, paging);
				return GetSuccess(result);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetAllOrdersByStatus: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPost]
		[Route("filter-all-orders-by-key")]
		public async Task<IActionResult> GetAllOrdersByKey([FromBody] PagingModel paging)
		{
			try
			{
				var data = await _checkOutBizLogic.GetAllOrdersByKey(paging);
				if (data == null) return GetError();
				if (!data.Any()) return GetSuccess("Chưa có đơn order nào.");
				var result = new PagingDataModel<OrderDetailModel>(data, paging);
				return GetSuccess(result);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetAllOrdersByKey: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpGet]
		[Route("get-order-by-id/{id}")]
		public async Task<IActionResult> GetOrderById([FromRoute]long id)
		{
			try
			{
				var repsonse = await _checkOutBizLogic.GetOrderById(id);
				if (repsonse == null) return GetError("Đơn hàng không tồn tại.");
				return GetSuccess(repsonse);
			}
			catch(Exception ex)
			{
				_logger.LogError("GetOrderById: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpGet]
		[Route("get-order-by-code/{code}")]
		public async Task<IActionResult> GetOrderByCode([FromRoute] string code)
		{
			try
			{
				var repsonse = await _checkOutBizLogic.GetOrderByCode(code);
				if (repsonse == null) return GetError("Đơn hàng không tồn tại.");
				return GetSuccess(repsonse);
			}
			catch (Exception ex)
			{
				_logger.LogError("GetOrderByCode: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPost]
		[Route("add-item-to-order")]
		public async Task<IActionResult> AddItemToOrder([FromBody] OrderItemCreateModel model)
		{
			try
			{
				if(!ModelState.IsValid) return ModelInvalid();

				var existedShoes = await _shoesBizLogic.GetShoes(model.ShoesId);
				if (existedShoes == null || existedShoes.IsActive == false)
				{
					ModelState.AddModelError("ShoesId", "Giày không khả dụng.");
					return ModelInvalid();
				}

				var existedImage = await _shoesImagesBizLogic.GetShoesImages(model.ShoesImageId);
				if(existedImage == null)
				{
					ModelState.AddModelError("ShoesImageId", "Ảnh không tồn tại.");
					return ModelInvalid();
				}
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

				var response = await _checkOutBizLogic.CreateOrderItem(model, existedShoes);
				if (!response.IsSuccess) return SaveError(response.Message);
				return SaveSuccess(response);
			}
			catch(Exception ex)
			{
				_logger.LogError("AddItemToOrder: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}
	}
}
