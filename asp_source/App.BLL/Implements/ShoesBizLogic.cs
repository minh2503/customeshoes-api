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
	public class ShoesBizLogic : IShoesBizLogic
	{
		private readonly IShoesRepository _shoesRepository;

		public ShoesBizLogic(IShoesRepository shoesRepository)
        {
			this._shoesRepository = shoesRepository;
		}
        public async Task<BaseRepsonse> CreateUpadteShoes(ShoesModel model)
		{
			var dto = model.GetEntity();
			return await _shoesRepository.CreateUpdateShoes(dto);
		}

		public async Task<List<ShoesModel>> GetListShoes(PagingModel paging)
		{
			var data = await _shoesRepository.GetAllShoes(paging);
			if (!data.Any()) return data.Select(b => new ShoesModel()).ToList();
			return data.Select(x => new ShoesModel(x)).ToList();
		}

		public async Task<ShoesModel> GetShoes(long id)
		{
			var response = await _shoesRepository.GetShoes(id);
			if (response == null) return null;
			return new ShoesModel(response);
		}

		public async Task<ShoesModel> GetShoesByName(string name)
		{
			var response = await _shoesRepository.GetShoesByName(name);
			if (response == null) return null;
			return new ShoesModel(response);
		}

		public async Task<BaseRepsonse> DeleteShoes(long id)
		{
			var respose = await _shoesRepository.DeleteShoes(id);
			return respose;
		}

		public async Task<List<ShoesModel>> GetListShoesByBrand(PagingModel paging)
		{
			paging.BrandName = paging.BrandName.Trim();
			var data = await _shoesRepository.GetListShoesByBrand(paging);
			if (!data.Any()) return data.Select(b => new ShoesModel()).ToList();
			return data.Select(x => new ShoesModel(x)).ToList();
		}

		public async Task<List<ShoesModel>> GetListShoesByPrice(PagingModel paging)
		{
			var data = await _shoesRepository.GetListShoesByPrice(paging);
			if (!data.Any()) return data.Select(b => new ShoesModel()).ToList();
			return data.Select(x => new ShoesModel(x)).ToList();
		}

		public async Task<List<ShoesModel>> GetListShoesByKey(PagingModel paging)
		{
			paging.Keyword = paging.Keyword.Trim();
			var data = await _shoesRepository.GetListShoesByKey(paging);
			if (!data.Any()) return data.Select(b => new ShoesModel()).ToList();
			return data.Select(x => new ShoesModel(x)).ToList();
		}
	}
}
