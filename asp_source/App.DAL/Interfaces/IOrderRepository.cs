using App.Entity;
using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Interfaces
{
	public interface IOrderRepository
	{
		Task<BaseRepsonse> CreateOrder(App_OrderDTO dto);
		Task<App_OrderDTO> GetTheLatestOrder();
		Task<App_OrderDTO> GetOrderById(long id);
	}
}
