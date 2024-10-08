﻿using App.Entity;
using App.Entity.DTO;
using App.Entity.Models;
using App.Entity.Models.AdminModel;
using App.Entity.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common.Models;

namespace App.BLL.Interfaces
{
    public interface ICheckOutBizLogic
	{
		Task<BaseRepsonse> CheckOutAsync(CheckOutModel model, ShoesModel shoesModel, long userId);
		Task<BaseRepsonse> CreateUpdateOrder(CreateUpdateOrderModel model, ShoesModel shoesModel, long userId);

		#region Order
		Task<BaseRepsonse> UpdateOrder(OrderUpdateModel model, string userName);
		Task<List<OrderDetailModel>> GetAllOrders(PagingModel paging);
		Task<List<OrderDetailModel>> GetAllOrdersByStatus(PagingModel paging);
		Task<List<OrderDetailModel>> GetAllOrdersByKey(PagingModel paging);
		Task<OrderDetailModel> GetOrderById(long id);
		Task<OrderDetailModel> GetOrderByCode(string orderCode);
		Task<List<OrderDetailModel>> GetAllOrdersByUserId(PagingModel paging, long userId);
		#endregion

		#region Admin
		Task<SummaryDataModel> SummaryDataInMonth();
		Task<List<TopSellingShoesModel>> GetTop3SellingShoesInMonth();
		Task<List<MonthlyRevenueModel>> GetMonthlyRevenue();
		#endregion

		#region OrderItem
		Task<OrderItemDetailModel> GetOrderItemById(long id);
		Task<BaseRepsonse> CreateOrderItem(OrderItemCreateModel model, ShoesModel shoesModel);
		Task<BaseRepsonse> DeleteOrderItem(long id);
		Task<BaseRepsonse> UpdateOrderItem(long id, OrderItemUpdateModel model);
		#endregion
	}
}
