using App.DAL.Interfaces;
using App.Entity;
using App.Entity.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.EntityFramework;

namespace App.DAL.Implements
{
	public class OrderItemsRepository : AppBaseRepository, IOrderItemsRepository
	{
		private readonly ApplicationDbContext _dbAppContext;

		public OrderItemsRepository(IConfiguration config, TFUDbContext dbTFUContext, ApplicationDbContext dbAppContext)
            : base(config, dbTFUContext, dbAppContext)
        {
			this._dbAppContext = dbAppContext;
		}

		public async Task<BaseRepsonse> CreateUpdateOrderItem(App_OrderItemsDTO dto)
		{
			var any = await _dbAppContext.App_OrderItems.AnyAsync(x => x.OrderId.Equals(dto.OrderId) && x.Id.Equals(dto.Id));
			if (any)
			{
				var item = _dbAppContext.App_OrderItems.FirstOrDefault(x => x.Id.Equals(dto.Id));
				if (!item.OrderId.Equals(dto.OrderId)) return new BaseRepsonse { IsSuccess = false, Message = "Không cùng đơn hàng."};
				item.Id = dto.Id;
				item.ShoesId = dto.ShoesId;
				item.Quantity = dto.Quantity;
				item.UnitPrice = dto.UnitPrice;
				item.ShoesImageId = dto.ShoesImageId;
				item.OrderId = dto.OrderId;
				_dbAppContext.App_OrderItems.Update(item);
			}
			else
			{
				var item = new App_OrderItemsDTO
				{
					ShoesImageId = dto.ShoesImageId,
					OrderId = dto.OrderId,
					Quantity = dto.Quantity,
					UnitPrice = dto.UnitPrice,
					ShoesId = dto.ShoesId,
				};
				_dbAppContext.App_OrderItems.Add(item);
			}
			return await SaveAsync();
		}

		public async Task<List<App_OrderItemsDTO>> GetOrderItemsByOrderWithoutPaging(long orderId)
		{
			var loadedRecords = await _dbAppContext.App_OrderItems.Where(x => x.OrderId.Equals(orderId)).ToListAsync();
			return loadedRecords;
		}
	}
}
