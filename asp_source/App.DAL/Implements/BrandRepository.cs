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
	public class BrandRepository : AppBaseRepository, IBrandRepository
	{
		private readonly ApplicationDbContext _dbAppContext;

		public BrandRepository(IConfiguration config, TFUDbContext dbTFUContext, ApplicationDbContext dbAppContext) : base(config, dbTFUContext, dbAppContext)
		{
			this._dbAppContext = dbAppContext;
		}

        public async Task<BaseRepsonse> CreateUpdateBrand(App_BrandDTO brandDTO)
		{
			var any = await _dbAppContext.App_Brands.AnyAsync(x => x.Id.Equals(brandDTO.Id));
			if (any)
			{
				var brand = _dbAppContext.App_Brands.FirstOrDefault(x => x.Id.Equals(brandDTO.Id));
				brand.Id = brandDTO.Id;
				brand.Name = brandDTO.Name;
				brand.Thumbnail = brandDTO.Thumbnail;
				brand.Description = brandDTO.Description;
				brand.CreatedDate = brandDTO.CreatedDate;
				brand.CreatedBy = brandDTO.CreatedBy;
				brand.IsActive = brandDTO.IsActive;
				_dbAppContext.App_Brands.Update(brand);
			}
			else
			{
				var brand = new App_BrandDTO
				{
					Id = brandDTO.Id,
					Name = brandDTO.Name,
					Thumbnail = brandDTO.Thumbnail,
					Description = brandDTO.Description,
					CreatedDate = brandDTO.CreatedDate,
					CreatedBy = brandDTO.CreatedBy,
					IsActive = brandDTO.IsActive,
				};
				_dbAppContext.App_Brands.Add(brand);
			}
			return await SaveAsync();
		}

		public async Task<App_BrandDTO> GetBrand(long id)
		{
			return await _dbAppContext.App_Brands.FirstOrDefaultAsync(b => b.Id.Equals(id));
		}
	}
}
