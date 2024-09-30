using App.DAL.Interfaces;
using App.Entity;
using App.Entity.DTO;
using App.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TFU.Common;
using TFU.Common.Extension;
using TFU.Common.Models;
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
					PaymentMethod = (int)PaymentMethod.COD,
					OrderCode = orderDTO.OrderCode,
					ModifiedBy = orderDTO.ModifiedBy,
					CreatedDate =  DateTime.Now,
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

		public async Task<List<App_OrderDTO>> GetAllOrders(PagingModel paging)
		{
			var loadeRecords = _dbAppContext.App_Orders.AsNoTracking().AsQueryable();
			paging.TotalRecord = await loadeRecords.CountAsync();
			return await loadeRecords.ToPagedList(paging.PageNumber, paging.PageSize).ToListAsync();
		}

		public async Task<List<App_OrderDTO>> GetAllOrdersByKey(PagingModel paging)
		{
			var loadedRecord = _dbAppContext.App_Orders.AsNoTracking().AsQueryable();
			if(!string.IsNullOrEmpty(paging.Keyword))
			{
				long userId;
				long.TryParse(paging.Keyword, out userId);
				loadedRecord = loadedRecord.Where(x => x.UserId.Equals(userId));
			}
			paging.TotalRecord = await loadedRecord.CountAsync();
			return await loadedRecord.ToPagedList(paging.PageNumber, paging.PageSize).ToListAsync();
		}

		public async Task<List<App_OrderDTO>> GetAllOrdersByStatus(PagingModel paging)
		{
			var loadedRecord = _dbAppContext.App_Orders.AsNoTracking().AsQueryable();
			if(paging.OrderStatus.HasValue)
			{
				loadedRecord = loadedRecord.Where(x => x.Status == (int)paging.OrderStatus);
			}
			paging.TotalRecord = await loadedRecord.CountAsync();
			return await loadedRecord.ToPagedList(paging.PageNumber, paging.PageSize).ToListAsync();
		}

		public async Task<App_OrderDTO> GetOrderById(long id)
		{
			return await _dbAppContext.App_Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
		}

		public async Task<App_OrderDTO> GetOrdersById(long id)
		{
			return await _dbAppContext.App_Orders.FirstOrDefaultAsync(x => x.Id.Equals(id));
		}

		public async Task<App_OrderDTO> GetTheLatestOrder()
		{
			var lastOrder = await _dbAppContext.App_Orders.AsNoTracking()
						.OrderByDescending(o => o.OrderCode)
						.FirstOrDefaultAsync();
			return lastOrder;
		}

		public async Task<BaseRepsonse> UpdateOrder(App_OrderDTO dto)
		{
			var any = await _dbAppContext.App_Orders.AnyAsync(x => x.Id.Equals(dto.Id));
			if(any)
			{
				var order = _dbAppContext.App_Orders.FirstOrDefault(x => x.Id.Equals(dto.Id));
				if(order == null) return new BaseRepsonse { IsSuccess = false, Message = "Không tìm thấy đơn hàng."};
				order.Id = dto.Id;
				order.UserId = dto.UserId;
				order.Status = dto.Status;
				order.Note = dto.Note;
				order.Amount = dto.Amount;
				order.ShipAddress = dto.ShipAddress;
				order.ShipedDate = dto.ShipedDate;
				order.DeliveredDate = dto.DeliveredDate;
				order.PaymentMethod = dto.PaymentMethod;
				order.PaymentDate = dto.PaymentDate;
				order.CreatedDate = dto.CreatedDate;
				order.ModifyDate = dto.ModifyDate;
				order.ModifiedBy = dto.ModifiedBy;
				_dbAppContext.App_Orders.Update(order);
				return await SaveAsync();
			}

			return new BaseRepsonse { IsSuccess = false, Message = Constants.SaveDataFailed};
		}
	}
}
