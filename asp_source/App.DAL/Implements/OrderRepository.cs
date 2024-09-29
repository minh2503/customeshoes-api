using App.DAL.Interfaces;
using App.Entity;
using App.Entity.DTO;
using App.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common;
using TFU.EntityFramework;

namespace App.DAL.Implements
{
	public class OrderRepository : AppBaseRepository, IOrderRepository
	{
		private readonly ApplicationDbContext _dbAppContext;

		public OrderRepository(IConfiguration config, TFUDbContext dbTFUContext, ApplicationDbContext dbAppContext)
			: base(config, dbTFUContext, dbAppContext)
		{
			this._dbAppContext = dbAppContext;
		}

		public async Task<BaseRepsonse> CreateOrder(App_OrderDTO dto)
		{
			var order = new App_OrderDTO
			{
				UserId = dto.UserId,
				Status = (int)OrderStatus.Pending,
				Note = dto.Note,
				Amount = dto.Amount,
				ShipAddress = dto.ShipAddress,
				ShipedDate = dto.ShipedDate,
				DeliveredDate = dto.DeliveredDate,
				PaymentMethod = (int)PaymentMethod.COD,
				PaymentDate = dto.PaymentDate,
				CreatedDate = dto.CreatedDate,
				OrderId = dto.OrderId,
				ModifyDate = dto.ModifyDate,
				ModifiedBy = dto.ModifiedBy,
			};
			_dbAppContext.App_Orders.Add(order);
			return await SaveAsync();
		}

		public async Task<App_OrderDTO> GetOrderById(long id)
		{
			return await _dbAppContext.App_Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
		}

		public async Task<App_OrderDTO> GetTheLatestOrder()
		{
			var lastOrder = await _dbAppContext.App_Orders
						.OrderByDescending(o => o.OrderId)
						.FirstOrDefaultAsync();
			return lastOrder;
		}
	}
}
