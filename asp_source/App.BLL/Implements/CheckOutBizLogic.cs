using App.BLL.Interfaces;
using App.DAL.Implements;
using App.DAL.Interfaces;
using App.Entity;
using App.Entity.DTO;
using App.Entity.Models;
using App.Entity.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common.Models;

namespace App.BLL.Implements
{
    public class CheckOutBizLogic : ICheckOutBizLogic
	{
		private readonly IShoesRepository _shoesRepository;
		private readonly IShoesImagesRepository _shoesImagesRepository;
		private readonly ICheckOutRepository _checkOutRepository;

		public CheckOutBizLogic(IShoesRepository shoesRepository,
								IShoesImagesRepository shoesImagesRepository,
								ICheckOutRepository checkOutRepository)
        {
			this._shoesRepository = shoesRepository;
			this._shoesImagesRepository = shoesImagesRepository;
			this._checkOutRepository = checkOutRepository;
		}
        public async Task<BaseRepsonse> CheckOutAsync(CheckOutModel model, ShoesModel shoesModel, long userId)
		{
			try
			{
				var orderDTO = model.GetOrderEntity();
				var orderDetailDTO = model.GetOrderItemsEntity();
				var shoesDTO = shoesModel.GetEntity();

				orderDTO.UserId = userId;
				orderDetailDTO.UnitPrice = shoesDTO.Price * orderDetailDTO.Quantity;
				orderDTO.Amount = orderDetailDTO.UnitPrice;
				orderDTO.OrderCode = await GenerateIncrementalOrderIdAsync();

				var response = await _checkOutRepository.CheckOutAsync(orderDTO, orderDetailDTO);
				return response;
			}
			catch (Exception)
			{
				throw;
			}
		}

		#region Order
		public async Task<List<OrderDetailModel>> GetAllOrders(PagingModel paging)
		{
			var data = await _checkOutRepository.GetAllOrders(paging);
			var response = new List<OrderDetailModel>();

			foreach (var order in data)
			{
				var orderDetailModel = new OrderDetailModel(order);
				orderDetailModel.orderItemDetailModels = await GetOrderItemsDetails(order.Id);
				response.Add(orderDetailModel);
			}

			return response;
		}

		public async Task<List<OrderDetailModel>> GetAllOrdersByKey(PagingModel paging)
		{
			var data = await _checkOutRepository.GetAllOrdersByKey(paging);
			var response = new List<OrderDetailModel>();

			foreach (var order in data)
			{
				var orderDetailModel = new OrderDetailModel(order);
				orderDetailModel.orderItemDetailModels = await GetOrderItemsDetails(order.Id);
				response.Add(orderDetailModel);
			}

			return response;
		}

		public async Task<List<OrderModel>> GetAllOrdersByStatus(PagingModel paging)
		{
			var data = await _checkOutRepository.GetAllOrdersByStatus(paging);
			if (!data.Any()) return data.Select(b => new OrderModel()).ToList();
			return data.Select(x => new OrderModel(x)).ToList();
		}

		public async Task<OrderDetailModel> GetOrderById(long id)
		{
			var response = await _checkOutRepository.GetOrderById(id);
			if (response == null) return null;

			var model = new OrderDetailModel(response);
			model.orderItemDetailModels = await GetOrderItemsDetails(id);
			return model;
		}

		public async Task<BaseRepsonse> UpdateOrder(OrderModel model)
		{
			var dto = model.GetEntity();
			var repsonse = await _checkOutRepository.UpdateOrder(dto);
			return repsonse;
		}
		#endregion

		#region OrderItem
		public async Task<OrderItemDetailModel> GetOrderItemById(long id)
		{
			var response = await _checkOutRepository.GetOrderItemById(id);
			if (response == null) return null;

			return await GetOrderItemDetailModel(response);
		}
		#endregion

		#region Private
		private async Task<string> GenerateIncrementalOrderIdAsync()
		{
			string prefix = "G-";
			int nextNumber = 0;

			var latestOrder = await _checkOutRepository.GetTheLatestOrder();

			if (latestOrder != null)
			{
				string lastOrderId = latestOrder.OrderCode;
				string numberPart = lastOrderId.Substring(2);
				if (int.TryParse(numberPart, out int lastNumber))
				{
					nextNumber = lastNumber + 1;
				}
			}

			string orderId = $"{prefix}{nextNumber.ToString("D3")}";

			return orderId;
		}

		private async Task<OrderItemDetailModel> GetOrderItemDetailModel(App_OrderItemsDTO item)
		{
			var shoesDTO = await _shoesRepository.GetShoes(item.ShoesId);
			var shoesModel = new ShoesModel(shoesDTO);

			var shoesImageDTO = await _shoesImagesRepository.GetShoesImages(item.ShoesImageId);
			var shoesImageModel = new ShoesImagesModel(shoesImageDTO);

			var orderItemModel = new OrderItemDetailModel(item)
			{
				ShoesModel = shoesModel,
				ShoesImage = shoesImageModel
			};

			return orderItemModel;
		}

		private async Task<List<OrderItemDetailModel>> GetOrderItemsDetails(long orderId)
		{
			var orderItems = await _checkOutRepository.GetOrderItemsByOrderId(orderId);
			var orderItemDetailModels = new List<OrderItemDetailModel>();

			foreach (var item in orderItems)
			{
				var orderItemModel = await GetOrderItemDetailModel(item);
				orderItemDetailModels.Add(orderItemModel);
			}

			return orderItemDetailModels;
		}


		#endregion
	}
}
