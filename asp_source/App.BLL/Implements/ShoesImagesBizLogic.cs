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
	public class ShoesImagesBizLogic : IShoesImagesBizLogic
	{
		private readonly IShoesImagesRepository _shoesImagesRepository;

		public ShoesImagesBizLogic(IShoesImagesRepository shoesImagesRepository)
        {
			this._shoesImagesRepository = shoesImagesRepository;
		}
        public async Task<BaseRepsonse> CreateUpdateShoesImages(ShoesImagesModel model)
		{
			var dto = model.GetEntity();
			var response = await _shoesImagesRepository.CreateUpdateShoesImages(dto);
			return response;
		}

		public async Task<List<ShoesImagesModel>> GetListShoesImages(PagingModel paging)
		{
			var data = await _shoesImagesRepository.GetAllShoesImages(paging);
			if (!data.Any()) return data.Select(b => new ShoesImagesModel()).ToList();
			return data.Select(x => new ShoesImagesModel(x)).ToList();
		}

		public async Task<ShoesImagesModel> GetShoesImages(long id)
		{
			var response = await _shoesImagesRepository.GetShoesImagesDTO(id);
			if (response == null) return null;
			return new ShoesImagesModel(response);
		}
	}
}
