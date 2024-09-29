using App.DAL.Interfaces;
using App.Entity;
using App.Entity.DTO;
using App.Entity.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.EntityFramework;

namespace App.DAL.Implements
{
	public class CheckOutRepository : AppBaseRepository, ICheckOutRepository
	{
		private readonly ApplicationDbContext _dbAppContext;

		public CheckOutRepository(IConfiguration config, TFUDbContext dbTFUContext, ApplicationDbContext dbAppContext)
                : base(config, dbTFUContext, dbAppContext)
        {
			this._dbAppContext = dbAppContext;
		}

		public async Task<BaseRepsonse> CheckOutAsync(App_OrderDTO orderDTO, App_OrderItemsDTO orderItemDTO)
		{
			try
			{
				BeginTransaction();
				var order = new App_OrderDTO
				{
					UserId = orderDTO.UserId,
					Status = (int)OrderStatus.Pending,
					Note = orderDTO.Note,
					Amount = orderDTO.Amount,
					ShipAddress = orderDTO.ShipAddress,
					ShipedDate = orderDTO.ShipedDate,
					DeliveredDate = orderDTO.DeliveredDate,
					PaymentMethod = (int)PaymentMethod.COD,
					PaymentDate = orderDTO.PaymentDate,
					OrderId = orderDTO.OrderId,
					ModifiedBy = orderDTO.ModifiedBy,
				};
				_dbAppContext.App_Orders.Add(order);
				await _dbAppContext.SaveChangesAsync();

				var item = new App_OrderItemsDTO
				{
					ShoesImageId = orderItemDTO.ShoesImageId,
					OrderId = order.Id,
					Quantity = orderItemDTO.Quantity,
					UnitPrice = orderItemDTO.UnitPrice,
					ShoesId = orderItemDTO.ShoesId,
				};
				_dbAppContext.App_OrderItems.Add(item);

				var saver = await SaveAsync();
				EndTransaction();
				return saver;
			}
			catch (Exception)
			{
				CancelTransaction();
				throw;
			}
		}
	}
}
