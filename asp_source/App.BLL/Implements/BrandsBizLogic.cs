using App.BLL.Interfaces;
using App.DAL.Implements;
using App.DAL.Interfaces;
using App.Entity;
using App.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common.Models;

namespace App.BLL.Implements
{
	public class BrandsBizLogic : IBrandsBizLogic
	{
		private readonly IBrandRepository _brandRepository;

		public BrandsBizLogic(IBrandRepository brandRepository)
        {
			this._brandRepository = brandRepository;
		}
        public async Task<BaseRepsonse> CreateUpadteBrands(BrandModel model)
		{
			var dto = model.GetEntity();
			var response = await _brandRepository.CreateUpdateBrand(dto);
			return response;
		}

		public async Task<BaseRepsonse> DeleteBrand(long id)
		{
			var response =  await _brandRepository.DeleteBrand(id);
			return response;
		}

		public async Task<BrandModel> GetBrand(long id)
		{
			var response = await _brandRepository.GetBrand(id);
			if (response == null) return null;
			return new BrandModel(response);
		}

		public async Task<BrandModel> GetBrandByName(string name)
		{
			var response = await _brandRepository.GetBrandByName(name);
			if (response == null) return null;
			return new BrandModel(response);
		}

		public async Task<List<BrandModel>> GetListBrands(PagingModel paging)
		{
			var data = await _brandRepository.GetAllBrands(paging);
			if(!data.Any()) return data.Select(b => new BrandModel()).ToList();
			return data.Select(x => new BrandModel(x)).ToList();
		}

		public async Task<List<BrandModel>> GetTop5Brand()
		{
			var data = await _brandRepository.GetTop5Brands();
			if (!data.Any()) return data.Select(b => new BrandModel()).ToList();
			return data.Select(x => new BrandModel(x)).ToList();
		}
	}
}
