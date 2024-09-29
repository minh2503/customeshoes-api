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
		Task<App_OrderDTO> GetOrderById(long id);
		Task<App_OrderDTO> GetTheLatestOrder();
		Task<BaseRepsonse> UpdateOrder(App_OrderDTO dto);
		Task<List<App_OrderDTO>> GetAllOrders(PagingModel paging);
	}
}
