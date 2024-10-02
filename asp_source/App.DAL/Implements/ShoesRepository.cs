using App.DAL.Interfaces;
using App.Entity;
using App.Entity.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TFU.Common;
using TFU.Common.Extension;
using TFU.Common.Models;
using TFU.EntityFramework;

namespace App.DAL.Implements
{
	public class ShoesRepository : AppBaseRepository, IShoesRepository
	{
		private readonly ApplicationDbContext _dbAppContext;

		public ShoesRepository(IConfiguration config, TFUDbContext dbTFUContext, ApplicationDbContext dbAppContext) : base(config, dbTFUContext, dbAppContext)
		{
			this._dbAppContext = dbAppContext;
		}
        public async Task<BaseRepsonse> CreateShoes(App_ShoesDTO dto, App_ShoesImagesDTO imageDto, string userName)
		{
			try
			{
				BeginTransaction();
				var shoes = new App_ShoesDTO
				{
					Name = dto.Name,
					Price = dto.Price,
					Description = dto.Description,
					CreatedDate = DateTime.Now,
					CreatedBy = userName,
					IsActive = true,
					IsCustomizable = dto.IsCustomizable,
					BrandName = dto.BrandName,
				};
				_dbAppContext.App_Shoes.Add(shoes);
				await _dbAppContext.SaveChangesAsync();

				var shoesImage = new App_ShoesImagesDTO
				{
					ShoesId = shoes.Id,
					Thumbnail = imageDto.Thumbnail,
					IsCustomize = imageDto.IsCustomize,
					IsUserCustom = imageDto.IsUserCustom,
				};
				_dbAppContext.App_ShoesImages.Add(shoesImage);

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

		public async Task<BaseRepsonse> UpdateShoes(App_ShoesDTO dto, string userName)
		{
			var any = await _dbAppContext.App_Shoes.AnyAsync(x => x.Id.Equals(dto.Id));
			if (any)
			{
				var shoes = _dbAppContext.App_Shoes.AsNoTracking().FirstOrDefault(x => x.Id.Equals(dto.Id));
				if (shoes == null) return new BaseRepsonse { IsSuccess = false, Message = "Không tìm thấy giày này." };

				shoes.Name = dto.Name;
				shoes.Description = dto.Description;
				shoes.Price = dto.Price;
				shoes.IsCustomizable = dto.IsCustomizable;
				shoes.ModifyDate = DateTime.Now;
				shoes.ModifyBy = userName;
				shoes.BrandName = dto.BrandName;
				_dbAppContext.App_Shoes.Update(shoes);
				return await SaveAsync();
			}

			return new BaseRepsonse { IsSuccess = false, Message = Constants.SaveDataFailed };
		}

		public async Task<BaseRepsonse> DeleteShoes(long id)
		{
			var any = await _dbAppContext.App_Shoes.AnyAsync(x => x.Id.Equals(id));
			if (any)
			{
				var shoes = await _dbAppContext.App_Shoes.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
				if (shoes == null) return new BaseRepsonse { IsSuccess = false, Message = Constants.GetDataFailed };
				if(shoes.IsActive == false) return new BaseRepsonse { IsSuccess = false, Message = "Giày không khả dụng." };
				shoes.IsActive = false;
				_dbAppContext.App_Shoes.Update(shoes);
				return await SaveAsync();
			}
			return new BaseRepsonse { IsSuccess = false, Message = Constants.SaveDataFailed };
		}

		public async Task<List<App_ShoesDTO>> GetAllShoes(PagingModel paging)
		{
			var loadedRecord = _dbAppContext.App_Shoes.Where(x => x.IsActive == true);
			paging.TotalRecord = await loadedRecord.CountAsync();
			return await loadedRecord.ToPagedList(paging.PageNumber, paging.PageSize).ToListAsync();
		}

		public async Task<List<App_ShoesDTO>> GetListShoesByBrand(PagingModel paging)
		{
			var loadedRecord = _dbAppContext.App_Shoes.Where(x => x.IsActive == true);
			if(!string.IsNullOrEmpty(paging.BrandName))
			{
				loadedRecord = loadedRecord.Where(x => x.BrandName.Contains(paging.BrandName));
			}
			paging.TotalRecord = await loadedRecord.CountAsync();
			return await loadedRecord.ToPagedList(paging.PageNumber, paging.PageSize).ToListAsync();
		}

		public async Task<List<App_ShoesDTO>> GetListShoesByKey(PagingModel paging)
		{
			var loadedRecord = _dbAppContext.App_Shoes.Where(x => x.IsActive == true);
			if(!string.IsNullOrEmpty(paging.Keyword))
			{
				loadedRecord = loadedRecord.Where(x => x.Name.Contains(paging.Keyword));
			}
			paging.TotalRecord = await loadedRecord.CountAsync();
			return await loadedRecord.ToPagedList(paging.PageNumber, paging.PageSize).ToListAsync();
		}

		public async Task<List<App_ShoesDTO>> GetListShoesByPrice(PagingModel paging)
		{
			var loadedRecord = _dbAppContext.App_Shoes.Where(x => x.IsActive == true);
			if(paging.PriceFilter.HasValue)
			{
				var priceRange = PriceRangeHelper.GetPriceRange(paging.PriceFilter.Value);
				loadedRecord = loadedRecord.Where(x => x.Price >= priceRange.min && x.Price <= priceRange.max);
			}
			paging.TotalRecord = await loadedRecord.CountAsync();
			return await loadedRecord.ToPagedList(paging.PageNumber, paging.PageSize).ToListAsync();
		}

		public async Task<App_ShoesDTO> GetShoes(long id)
		{
			return await _dbAppContext.App_Shoes.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id) && x.IsActive == true);
		}

		public async Task<App_ShoesDTO> GetShoesByName(string name)
		{
			return await _dbAppContext.App_Shoes.AsNoTracking()
								.FirstOrDefaultAsync(x => x.Name.Equals(name) && x.IsActive == true);
		}

	}
}
