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

                if (!model.IsPaymentMethodValid())
                {
                    ModelState.AddModelError("PaymentMethod", "Phương thức thanh toán không hợp lệ.");
                    return ModelInvalid();
                }

                var existedShoes = await _shoesBizLogic.GetShoes(model.ShoesId);
                if (existedShoes == null)
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

		[HttpPost]
		[Route("create-update-order")]
		public async Task<IActionResult> CreateUpdateOrder(CreateUpdateOrderModel model)
		{
			try
			{
				if (!ModelState.IsValid) return ModelInvalid();

				if (!model.IsPaymentMethodValid())
				{
					ModelState.AddModelError("PaymentMethod", "Phương thức thanh toán không hợp lệ.");
					return ModelInvalid();
				}

				if (!model.IsOrderStatusValid())
				{
					ModelState.AddModelError("Status", "Trạng thái đơn hàng không hợp lệ.");
					return ModelInvalid();
				}

				var existedShoes = await _shoesBizLogic.GetShoes(model.ShoesId);
				if (existedShoes == null)
				{
					ModelState.AddModelError("ShoesId", "Giày không khả dụng.");
					return ModelInvalid();
				}

				var response = await _checkOutBizLogic.CreateUpdateOrder(model, existedShoes, UserId);
				if (!response.IsSuccess) return SaveError(response.Message);
				return SaveSuccess(response);
			}
			catch (Exception ex)
			{
				_logger.LogError("CheckOutAsync: {0} {1}", ex.Message, ex.StackTrace);
				return SaveError(ex.Message);
			}
		}

		[HttpPut]
        [Route("update-order")]
        public async Task<IActionResult> UpdateOrder(OrderUpdateModel model)
        {
            try
            {
                if (!ModelState.IsValid) return ModelInvalid();

                var response = await _checkOutBizLogic.UpdateOrder(model, UserName);
                if (!response.IsSuccess) return SaveError(response.Message);
                return SaveSuccess(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("UpdateOrder: {0} {1}", ex.Message, ex.StackTrace);
                return SaveError(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("get-all-orders")]
        public async Task<IActionResult> GetAllOrders([FromBody] PagingModel paging)
        {
            try
            {
                var data = await _checkOutBizLogic.GetAllOrders(paging);
                if (data == null) return GetError();
                //if(!data.Any()) return GetSuccess("Chưa có đơn order nào.");
                var result = new PagingDataModel<OrderDetailModel>(data, paging);
                return GetSuccess(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetAllOrders: {0} {1}", ex.Message, ex.StackTrace);
                return GetError(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("get-all-orders-by-userId")]
        public async Task<IActionResult> GetAllOrdersByUserId([FromBody] PagingModel paging)
        {
            try
            {
                var data = await _checkOutBizLogic.GetAllOrdersByUserId(paging, UserId);
                if (data == null) return GetError();
                var result = new PagingDataModel<OrderDetailModel>(data, paging);
                return GetSuccess(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetAllOrders: {0} {1}", ex.Message, ex.StackTrace);
                return GetError(ex.Message);
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
        public async Task<IActionResult> GetOrderById([FromRoute] long id)
        {
            try
            {
                var repsonse = await _checkOutBizLogic.GetOrderById(id);
                if (repsonse == null) return GetError("Đơn hàng không tồn tại.");
                return GetSuccess(repsonse);
            }
            catch (Exception ex)
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
                if (!ModelState.IsValid) return ModelInvalid();

                var existedShoes = await _shoesBizLogic.GetShoes(model.ShoesId);
                if (existedShoes == null || existedShoes.IsActive == false)
                {
                    ModelState.AddModelError("ShoesId", "Giày không khả dụng.");
                    return ModelInvalid();
                }

                var existedImage = await _shoesImagesBizLogic.GetShoesImages(model.ShoesImageId);
                if (existedImage == null)
                {
                    ModelState.AddModelError("ShoesImageId", "Ảnh không tồn tại.");
                    return ModelInvalid();
                }
                if (!existedImage.ShoesId.Equals(model.ShoesId))
                {
                    ModelState.AddModelError("ShoesImageId", "Ảnh không khớp với giày.");
                    return ModelInvalid();
                }
                var response = await _checkOutBizLogic.CreateOrderItem(model, existedShoes);
                if (!response.IsSuccess) return SaveError(response.Message);
                return SaveSuccess(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("AddItemToOrder: {0} {1}", ex.Message, ex.StackTrace);
                return SaveError(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete-order-item-from-order/{id}")]
        public async Task<IActionResult> DeleteOrderItem(long id)
        {
            try
            {

                var response = await _checkOutBizLogic.DeleteOrderItem(id);
                if (!response.IsSuccess) return SaveError(response.Message);
                return SaveSuccess(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("DeleteOrderItem: {0} {1}", ex.Message, ex.StackTrace);
                return SaveError(ex.Message);
            }
        }

        [HttpPut]
        [Route("update-order-item/{id}")]
        public async Task<IActionResult> UpdateOrderItem([FromRoute] long id, [FromBody] OrderItemUpdateModel model)
        {
            try
            {
                if (!ModelState.IsValid) return ModelInvalid();

                var response = await _checkOutBizLogic.UpdateOrderItem(id, model);
                if (!response.IsSuccess) return SaveError(response.Message);
                return SaveSuccess(response);
            }
            catch (Exception ex)
            {
                _logger.LogError("UpdateOrderItem: {0} {1}", ex.Message, ex.StackTrace);
                return SaveError(ex.Message);
            }
        }

		[Authorize]
		[HttpGet]
		[Route("summary-data-in-month")]
		public async Task<IActionResult> SummaryDataInMonth()
		{
			try
			{
				var data = await _checkOutBizLogic.SummaryDataInMonth();
				if (data == null) return GetError();
				return GetSuccess(data);
			}
			catch (Exception ex)
			{
				_logger.LogError("SummaryDataInMonth: {0} {1}", ex.Message, ex.StackTrace);
				return GetError(ex.Message);
			}
		}


	}
}
