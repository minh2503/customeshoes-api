using App.Entity;
using App.Entity.DTO;
using App.Entity.Models;
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
		Task<BaseRepsonse> UpdateOrder(OrderModel model);
		Task<List<OrderModel>> GetAllOrders(PagingModel paging);
		Task<List<OrderModel>> GetAllOrdersByStatus(PagingModel paging);
		Task<List<OrderModel>> GetAllOrdersByKey(PagingModel paging);
		Task<OrderModel> GetOrdersById(long id);
	}
}
