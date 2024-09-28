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
	}
}
