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
using TFU.Common;
using TFU.Common.Extension;
using TFU.Common.Models;
using TFU.EntityFramework;

namespace App.DAL.Implements
{
	public class BrandRepository : AppBaseRepository, IBrandRepository
	{
		private readonly ApplicationDbContext _dbAppContext;

		public BrandRepository(IConfiguration config, TFUDbContext dbTFUContext, ApplicationDbContext dbAppContext) : base(config, dbTFUContext, dbAppContext)
		{
			this._dbAppContext = dbAppContext;
		}

        public async Task<BaseRepsonse> CreateUpdateBrand(App_BrandDTO brandDTO, string userName)
		{
			var any = await _dbAppContext.App_Brands.AnyAsync(x => x.Id.Equals(brandDTO.Id));
			if (any)
			{
				var brand = _dbAppContext.App_Brands.AsNoTracking().FirstOrDefault(x => x.Id.Equals(brandDTO.Id));
				brand.Name = brandDTO.Name;
				brand.Thumbnail = brandDTO.Thumbnail;
				brand.Description = brandDTO.Description;
				_dbAppContext.App_Brands.Update(brand);
			}
			else
			{
				var brand = new App_BrandDTO
				{
					Name = brandDTO.Name,
					Thumbnail = brandDTO.Thumbnail,
					Description = brandDTO.Description,
					CreatedDate = DateTime.Now,
					CreatedBy = userName,
					IsActive = true,
				};
				_dbAppContext.App_Brands.Add(brand);
			}
			return await SaveAsync();
		}

		public async Task<BaseRepsonse> DeleteBrand(long id)
		{
			var any = await _dbAppContext.App_Brands.AnyAsync(x => x.Id.Equals(id));
			if (any)
			{
				var brand = await _dbAppContext.App_Brands.FirstOrDefaultAsync(x => x.Id.Equals(id));
				if (brand == null) return new BaseRepsonse { IsSuccess = false, Message = Constants.GetDataFailed };
				if (brand.IsActive == false) return new BaseRepsonse { IsSuccess = false, Message = "Hãng giày không khả dụng." };
				brand.IsActive = false;
				_dbAppContext.App_Brands.Update(brand);
				return await SaveAsync();
			}
			return new BaseRepsonse { IsSuccess = false, Message = Constants.SaveDataFailed };
		}

		public async Task<List<App_BrandDTO>> GetAllBrands(PagingModel paging)
		{
			var loadedRecord = _dbAppContext.App_Brands.Where(x => x.IsActive == true);
			paging.TotalRecord = await loadedRecord.CountAsync();
			return await loadedRecord.ToPagedList(paging.PageNumber, paging.PageSize)
								.ToListAsync();
		}

		public async Task<List<App_BrandDTO>> GetListBrandByName(PagingModel paging)
		{
			var loadedRecord = _dbAppContext.App_Brands.Where(x => x.IsActive == true);
			if(paging.BrandName != null)
			{
				loadedRecord = loadedRecord.Where(x => x.Name.Contains(paging.BrandName));
			}
			paging.TotalRecord = await loadedRecord.CountAsync();
			return await loadedRecord.ToPagedList(paging.PageNumber, paging.PageSize)
								.ToListAsync();
		}

		public async Task<App_BrandDTO> GetBrand(long id)
		{
			return await _dbAppContext.App_Brands.FirstOrDefaultAsync(b => b.Id.Equals(id) && b.IsActive == true);
		}

		public async Task<App_BrandDTO> GetBrandByName(string name)
		{
			return await _dbAppContext.App_Brands.FirstOrDefaultAsync(x => x.Name.Equals(name));
		}

		public Task<List<App_BrandDTO>> GetBrandsWithoutPaging()
		{
			return _dbAppContext.App_Brands.Where(x => x.IsActive == true).ToListAsync();
		}

		public async Task<List<App_BrandDTO>> GetTop5Brands()
		{
			var loadedRecord = _dbAppContext.App_Brands.Where(x => x.IsActive == true);
			return await loadedRecord.Take(5).ToListAsync();
		}
	}
}
