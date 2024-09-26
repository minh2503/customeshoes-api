using App.BLL.Interfaces;
using App.DAL.Interfaces;
using App.Entity;
using App.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public async Task<BrandModel> GetBrand(long id)
		{
			var response = await _brandRepository.GetBrand(id);
			if (response == null) return null;
			return new BrandModel(response);
		}
	}
}
