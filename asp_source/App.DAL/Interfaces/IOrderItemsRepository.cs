using App.Entity;
using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Interfaces
{
	public interface IOrderItemsRepository
	{
		Task<BaseRepsonse> CreateUpdateOrderItem(App_OrderItemsDTO dto);
		Task<List<App_OrderItemsDTO>> GetOrderItemsByOrderWithoutPaging(long orderId);
	}
}
