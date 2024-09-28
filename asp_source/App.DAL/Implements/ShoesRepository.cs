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
using TFU.Common.Extension;
using TFU.Common.Models;
using TFU.DAL;
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
        public async Task<BaseRepsonse> CreateUpdateShoes(App_ShoesDTO dto)
		{
			var any = await _dbAppContext.App_Shoes.AnyAsync(x => x.Id.Equals(dto.Id));
			if (any)
			{
				var shoes = _dbAppContext.App_Shoes.FirstOrDefault(x => x.Id.Equals(dto.Id));
				if (shoes == null) return new BaseRepsonse { IsSuccess = false, Message = "Giày không khớp." };
				shoes.Id = dto.Id;
				shoes.Name = dto.Name;
				shoes.Price = dto.Price;
				shoes.Description = dto.Description;
				shoes.CreatedDate = dto.CreatedDate;
				shoes.CreatedBy = dto.CreatedBy;
				shoes.IsActive = dto.IsActive;
				shoes.IsCustomizable = dto.IsCustomizable;
				shoes.BrandName = dto.BrandName;
				shoes.ModifyBy = dto.ModifyBy;
				shoes.ModifyDate = dto.ModifyDate;
				_dbAppContext.App_Shoes.Update(shoes);
			}
			else
			{
				var shoes = new App_ShoesDTO
				{
					Id = dto.Id,
					Name = dto.Name,
					Price = dto.Price,
					Description = dto.Description,
					CreatedDate = dto.CreatedDate,
					CreatedBy = dto.CreatedBy,
					IsActive = dto.IsActive,
					IsCustomizable = dto.IsCustomizable,
					BrandName = dto.BrandName,
					ModifyBy = dto.ModifyBy,
					ModifyDate = dto.ModifyDate,
				};
				_dbAppContext.App_Shoes.Add(shoes);
			}
			return await SaveAsync();
		}

		public async Task<List<App_ShoesDTO>> GetAllShoes(PagingModel paging)
		{
			var loadedRecord = _dbAppContext.App_Shoes.Where(x => x.IsActive == true);
			paging.TotalRecord = await loadedRecord.CountAsync();
			return await loadedRecord.ToPagedList(paging.PageNumber, paging.PageSize).ToListAsync();
		}

		public async Task<App_ShoesDTO> GetShoes(long id)
		{
			return await _dbAppContext.App_Shoes.FirstOrDefaultAsync(x => x.Id.Equals(id) && x.IsActive == true);
		}

		public async Task<App_ShoesDTO> GetShoesByName(string name)
		{
			return await _dbAppContext.App_Shoes.FirstOrDefaultAsync(x => x.Name.Equals(name));
		}
	}
}
