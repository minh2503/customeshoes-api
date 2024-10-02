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
	public class ShoesImagesRepository : AppBaseRepository, IShoesImagesRepository
	{
		private readonly ApplicationDbContext _dbAppContext;

		public ShoesImagesRepository(IConfiguration config, TFUDbContext dbTFUContext, ApplicationDbContext dbAppContext)
               : base(config, dbTFUContext, dbAppContext)
        {
			this._dbAppContext = dbAppContext;
		}

		public async Task<BaseRepsonse> CreateUpdateShoesImages(App_ShoesImagesDTO dto)
		{
			var any = await _dbAppContext.App_ShoesImages.AnyAsync(x => x.Id.Equals(dto.Id));
			if (any)
			{
				var shoesImage = _dbAppContext.App_ShoesImages.FirstOrDefault(x => x.Id.Equals(dto.Id));
				if(shoesImage == null) return new BaseRepsonse { IsSuccess = false , Message = "Không tìm thấy ảnh."};
				shoesImage.IsCustomize = dto.IsCustomize;
				shoesImage.IsUserCustom = dto.IsUserCustom;
				_dbAppContext.App_ShoesImages.Update(shoesImage);
			}
			else
			{
				var shoesImage = new App_ShoesImagesDTO
				{
					Id = dto.Id,
					ShoesId = dto.ShoesId,
					Thumbnail = dto.Thumbnail,
					IsCustomize = dto.IsCustomize,
					IsUserCustom = dto.IsUserCustom,
				};
				_dbAppContext.App_ShoesImages.Add(shoesImage);
			}
			return await SaveAsync();
		}

		public async Task<List<App_ShoesImagesDTO>> GetAllShoesImages(PagingModel model)
		{
			var loadedRecord = _dbAppContext.App_ShoesImages.AsQueryable();
			model.TotalRecord = await loadedRecord.CountAsync();
			return await loadedRecord.ToPagedList(model.PageNumber, model.PageSize)
								.ToListAsync();
		}

		public async Task<List<App_ShoesImagesDTO>> GetUserCustomShoesImagesByShoes(PagingModel model)
		{
			var loadedRecord = _dbAppContext.App_ShoesImages.AsQueryable();
			loadedRecord = loadedRecord.Where(x => x.ShoesId.Equals(model.ShoesId) && x.IsUserCustom == true);
			model.TotalRecord = await loadedRecord.CountAsync();
			return await loadedRecord.ToPagedList(model.PageNumber, model.PageSize)
								.ToListAsync();
		}

		public async Task<List<App_ShoesImagesDTO>> GetListShoesImagesByShoes(long shoesId)
		{
			var loadedRecord = _dbAppContext.App_ShoesImages.AsQueryable();
			loadedRecord = loadedRecord.Where(x => x.ShoesId.Equals(shoesId));
			return await loadedRecord.ToListAsync();
		}

		public async Task<App_ShoesImagesDTO> GetShoesImages(long id)
		{
			return await _dbAppContext.App_ShoesImages.AsNoTracking().FirstOrDefaultAsync(b => b.Id.Equals(id));
		}

		public async Task<BaseRepsonse> DeleteImage(long id)
		{
			var any = await _dbAppContext.App_ShoesImages.AnyAsync(x => x.Id.Equals(id));
			if (any)
			{
				var shoesImage = await _dbAppContext.App_ShoesImages.FirstOrDefaultAsync(x => x.Id.Equals(id));
				if (shoesImage == null) return new BaseRepsonse { IsSuccess = false, Message = Constants.GetDataFailed };
				if (shoesImage.IsUserCustom == true) return new BaseRepsonse { IsSuccess = false, Message = "Không được phép xóa ảnh custom của khách hàng"};
				_dbAppContext.App_ShoesImages.Remove(shoesImage);
				return await SaveAsync();
			}
			return new BaseRepsonse { IsSuccess = false, Message = Constants.SaveDataFailed };
		}
	}
}
