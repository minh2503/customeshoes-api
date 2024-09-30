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
		public async Task<List<OrderModel>> GetAllOrders(PagingModel paging)
		{
			var data = await _checkOutRepository.GetAllOrders(paging);
			if (!data.Any()) return data.Select(b => new OrderModel()).ToList();
			return data.Select(x => new OrderModel(x)).ToList();
		}

		public async Task<List<OrderModel>> GetAllOrdersByKey(PagingModel paging)
		{
			var data = await _checkOutRepository.GetAllOrdersByKey(paging);
			if (!data.Any()) return data.Select(b => new OrderModel()).ToList();
			return data.Select(x => new OrderModel(x)).ToList();
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

			var childItems = await _checkOutRepository.GetOrderItemsByOrderId(id);
			List<OrderItemDetailModel> orderItemDetailModels = new List<OrderItemDetailModel>();
			foreach (var item in childItems)
			{
				var itemModel = await GetOrderItemById(item.Id);
				orderItemDetailModels.Add(itemModel);
			}
			var model = new OrderDetailModel(response);
			model.orderItemDetailModels = orderItemDetailModels;
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

			var shoesDTO = await _shoesRepository.GetShoes(response.ShoesId);
			var shoesModel = new ShoesModel(shoesDTO);

			var shoesImageDTo = await _shoesImagesRepository.GetShoesImages(response.ShoesImageId);
			var shoesImageModel = new ShoesImagesModel(shoesImageDTo);
			var model = new OrderItemDetailModel(response);
			model.ShoesModel = shoesModel;
			model.ShoesImage = shoesImageModel;
			return model;
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
		#endregion
	}
}
