using App.BLL.Interfaces;
using App.DAL.Implements;
using App.DAL.Interfaces;
using App.Entity;
using App.Entity.DTO;
using App.Entity.Models;
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
		private readonly IOrderRepository _orderRepository;
		private readonly IOrderItemsRepository _orderItemsRepository;
		private readonly ICheckOutRepository _checkOutRepository;

		public CheckOutBizLogic(IOrderRepository orderRepository,
								IOrderItemsRepository orderItemsRepository,
								ICheckOutRepository checkOutRepository)
        {
			this._orderRepository = orderRepository;
			this._orderItemsRepository = orderItemsRepository;
			this._checkOutRepository = checkOutRepository;
		}
        public async Task<BaseRepsonse> CheckOutAsync(CheckOutModel model, ShoesModel shoesModel)
		{
			try
			{
				var orderDTO = model.GetOrderEntity();
				var orderDetailDTO = model.GetOrderItemsEntity();
				var shoesDTO = shoesModel.GetEntity();

				orderDetailDTO.UnitPrice = shoesDTO.Price * orderDetailDTO.Quantity;
				orderDTO.Amount = orderDetailDTO.UnitPrice;
				orderDTO.OrderId = await GenerateIncrementalOrderIdAsync();

				var response = await _checkOutRepository.CheckOutAsync(orderDTO, orderDetailDTO);
				return response;
			}
			catch (Exception)
			{
				throw;
			}
		}

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

		public async Task<BaseRepsonse> UpdateOrder(OrderModel model)
		{
			var dto = model.GetEntity();
			var repsonse = await _checkOutRepository.UpdateOrder(dto);
			return repsonse;
		}



		#region Private
		private async Task<string> GenerateIncrementalOrderIdAsync()
		{
			string prefix = "G-";
			int nextNumber = 0;

			var latestOrder = await _orderRepository.GetTheLatestOrder();

			if (latestOrder != null)
			{
				string lastOrderId = latestOrder.OrderId;
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
