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
				await _dbAppContext.App_Orders.AddAsync(order);
				await _dbAppContext.SaveChangesAsync();

				var item = new App_OrderItemsDTO
				{
					ShoesImageId = orderItemDTO.ShoesImageId,
					OrderId = order.Id,
					Quantity = orderItemDTO.Quantity,
					UnitPrice = orderItemDTO.UnitPrice,
					ShoesId = orderItemDTO.ShoesId,
					Size = orderItemDTO.Size,
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

		public async Task<BaseRepsonse> CreateUpdateOrder(App_OrderDTO orderDTO, App_OrderItemsDTO orderItemDTO, string thumbnail)
		{
			try
			{
				BeginTransaction();
				var any = await _dbAppContext.App_Orders.AnyAsync(x => x.Id.Equals(orderDTO.Id));
				if (any)
				{
					var order = await _dbAppContext.App_Orders.FirstOrDefaultAsync(x => x.Id.Equals(orderDTO.Id));
					switch (orderDTO.Status)
					{
						case 2: order.PaymentDate = DateTime.Now; break;
						case 3: order.ShipedDate = DateTime.Now; break;
						case 4: order.DeliveredDate = DateTime.Now; break;
						default: break;
					}

					order.Status = orderDTO.Status;
					order.Note = orderDTO.Note;
					order.ShipAddress = orderDTO.ShipAddress;
					order.PaymentMethod = orderDTO.PaymentMethod;
					order.ModifyDate = DateTime.Now;
					order.ModifiedBy = orderDTO.ModifiedBy;
					_dbAppContext.App_Orders.Update(order);
				}
				else
				{
					var order = new App_OrderDTO
					{
						UserId = orderDTO.UserId,
						Status = orderDTO.Status,
						Note = orderDTO.Note,
						Amount = orderDTO.Amount,
						ShipAddress = orderDTO.ShipAddress,
						PaymentMethod = orderDTO.PaymentMethod,
						OrderCode = orderDTO.OrderCode,
						CreatedDate = DateTime.Now,
					};
					await _dbAppContext.App_Orders.AddAsync(order);
					await _dbAppContext.SaveChangesAsync();

					var image = new App_ShoesImagesDTO
					{
						ShoesId = orderItemDTO.ShoesId,
						Thumbnail = thumbnail,
						IsCustomize = true,
						IsUserCustom =  true,
					};
					await _dbAppContext.App_ShoesImages.AddAsync(image);
					await _dbAppContext.SaveChangesAsync();

					var item = new App_OrderItemsDTO
					{
						ShoesImageId = image.Id,
						OrderId = order.Id,
						Quantity = orderItemDTO.Quantity,
						UnitPrice = orderItemDTO.UnitPrice,
						ShoesId = orderItemDTO.ShoesId,
						Size = orderItemDTO.Size,
					};
					_dbAppContext.App_OrderItems.Add(item);
				}
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

		#region Order
		public async Task<List<App_OrderDTO>> GetAllOrders(PagingModel paging)
		{
			var loadeRecords = _dbAppContext.App_Orders.AsNoTracking().AsQueryable();
			paging.TotalRecord = await loadeRecords.CountAsync();
			return await loadeRecords.ToPagedList(paging.PageNumber, paging.PageSize).ToListAsync();
		}

		public async Task<List<App_OrderDTO>> GetAllOrdersByUserId(PagingModel paging, long userId)
		{
			var loadeRecords = _dbAppContext.App_Orders.AsNoTracking().Where(x => x.UserId.Equals(userId));
			if (paging.OrderStatus.HasValue)
			{
				loadeRecords = loadeRecords.Where(x => x.Status == (int)paging.OrderStatus);
			}
			paging.TotalRecord = await loadeRecords.CountAsync();
			return await loadeRecords.ToPagedList(paging.PageNumber, paging.PageSize).ToListAsync();
		}

		public async Task<List<App_OrderDTO>> GetAllOrdersByKey(PagingModel paging)
		{
			var loadedRecord = _dbAppContext.App_Orders.AsNoTracking().AsQueryable();
			if (!string.IsNullOrEmpty(paging.Keyword))
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
			if (paging.OrderStatus.HasValue)
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
			if (any)
			{
				var order = _dbAppContext.App_Orders.FirstOrDefault(x => x.Id.Equals(dto.Id));
				if (order == null) return new BaseRepsonse { IsSuccess = false, Message = "Không tìm thấy đơn hàng." };

				switch(dto.Status)
				{
					case 2: order.PaymentDate = DateTime.Now; break;
					case 3: order.ShipedDate = DateTime.Now; break;
					case 4: order.DeliveredDate = DateTime.Now; break;
					default: break;
				}

				order.Status = dto.Status;
				order.Note = dto.Note;
				order.Amount = dto.Amount;
				order.ShipAddress = dto.ShipAddress;
				order.PaymentMethod = dto.PaymentMethod;
				order.ModifyDate = DateTime.Now;
				order.ModifiedBy = dto.ModifiedBy;
				_dbAppContext.App_Orders.Update(order);
				return await SaveAsync();
			}

			return new BaseRepsonse { IsSuccess = false, Message = Constants.SaveDataFailed };
		}

		public async Task<App_OrderDTO> GetOrderByCode(string orderCode)
		{
			return await _dbAppContext.App_Orders.FirstOrDefaultAsync(x => x.OrderCode.Equals(orderCode));
		}

		#endregion

		#region OrderItem
		public async Task<App_OrderItemsDTO> GetOrderItemById(long id)
		{
			return await _dbAppContext.App_OrderItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
		}

		public async Task<List<App_OrderItemsDTO>> GetOrderItemsByOrderId(long id)
		{
			return await _dbAppContext.App_OrderItems.AsNoTracking().Where(x => x.OrderId.Equals(id)).ToListAsync();
		}

		public async Task<BaseRepsonse> CreateOrderItem(App_OrderItemsDTO orderItemDTO, App_OrderDTO orderDTO)
		{
			try
			{
				BeginTransaction();
				var orderItem = new App_OrderItemsDTO
				{
					Id = orderItemDTO.Id,
					Quantity = orderItemDTO.Quantity,
					UnitPrice = orderItemDTO.UnitPrice,
					ShoesId = orderItemDTO.ShoesId,
					ShoesImageId = orderItemDTO.ShoesImageId,
					OrderId = orderItemDTO.OrderId,
					Size = orderItemDTO.Size,
				};
				await _dbAppContext.App_OrderItems.AddAsync(orderItemDTO);
				_dbAppContext.App_Orders.Update(orderDTO);

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

		public async Task<BaseRepsonse> DeleteOrderItem(App_OrderItemsDTO orderItemsDTO, App_OrderDTO orderDTO)
		{
			try
			{
				BeginTransaction();

				_dbAppContext.App_OrderItems.Remove(orderItemsDTO);
				_dbAppContext.App_Orders.Update(orderDTO);
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

		public async Task<BaseRepsonse> UpdateOrderItem(App_OrderItemsDTO orderItemsDTO, App_OrderDTO orderDTO)
		{
			try
			{
				BeginTransaction();
				_dbAppContext.App_OrderItems.Update(orderItemsDTO);
				_dbAppContext.App_Orders.Update(orderDTO);
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
		#endregion
	}
}
