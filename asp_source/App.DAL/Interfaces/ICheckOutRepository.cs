using App.Entity;
using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common.Models;

namespace App.DAL.Interfaces
{
	public interface ICheckOutRepository
	{
		Task<BaseRepsonse> CheckOutAsync(App_OrderDTO orderDTO, App_OrderItemsDTO orderItemDTO);
		Task<BaseRepsonse> CreateUpdateOrder(App_OrderDTO orderDTO, App_OrderItemsDTO orderItemDTO, string thumbnail);

		#region Order
		Task<App_OrderDTO> GetOrderById(long id);
		Task<App_OrderDTO> GetTheLatestOrder();
		Task<BaseRepsonse> UpdateOrder(App_OrderDTO dto);
		Task<List<App_OrderDTO>> GetAllOrders(PagingModel paging);
		Task<List<App_OrderDTO>> GetAllOrdersByStatus(PagingModel paging);
		Task<List<App_OrderDTO>> GetAllOrdersByKey(PagingModel paging);
		Task<App_OrderDTO> GetOrderByCode(string orderCode);
		Task<List<App_OrderDTO>> GetAllOrdersByUserId(PagingModel paging, long userId);
		#endregion

		#region OrderItem
		Task<App_OrderItemsDTO> GetOrderItemById(long id);
		Task<List<App_OrderItemsDTO>> GetOrderItemsByOrderId(long id);
		Task<BaseRepsonse> CreateOrderItem (App_OrderItemsDTO orderItemDTO, App_OrderDTO order);
		Task<BaseRepsonse> DeleteOrderItem (App_OrderItemsDTO orderItemsDTO, App_OrderDTO orderDTO);
		Task<BaseRepsonse> UpdateOrderItem (App_OrderItemsDTO orderItemsDTO, App_OrderDTO orderDTO);
		#endregion
	}
}
