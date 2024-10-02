using App.BLL.Interfaces;
using App.DAL.Implements;
using App.DAL.Interfaces;
using App.Entity;
using App.Entity.DTO;
using App.Entity.Models;
using App.Entity.Models.Orders;
using App.Entity.Models.Shoes;
using App.Entity.Models.ShoesImages;
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
		private readonly IBrandRepository _brandRepository;
		private readonly IShoesImagesRepository _shoesImagesRepository;

		public ShoesBizLogic(IShoesRepository shoesRepository, IBrandRepository brandRepository,
							IShoesImagesRepository shoesImagesRepository)
        {
			this._shoesRepository = shoesRepository;
			this._brandRepository = brandRepository;
			this._shoesImagesRepository = shoesImagesRepository;
		}
        public async Task<BaseRepsonse> CreateShoes(ShoesRequestModel model, string userName)
		{
			var existedBrand = await _brandRepository.GetBrandByName(model.BrandName);
			if (existedBrand == null)
			{
				return new BaseRepsonse { IsSuccess = false, Message = $"Hãng giày {model.BrandName} không tồn tại" };
			}

			var existedShoes = await _shoesRepository.GetShoesByName(model.Name);
			if (existedShoes != null)
			{
				return new BaseRepsonse { IsSuccess = false, Message = $"Tên giày {model.Name} đã tồn tại" };
			}
			var shoesDto = model.GetEntity();
			var shoesImageDto = model.GetImageEntity();
			return await _shoesRepository.CreateShoes(shoesDto, shoesImageDto, userName);
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

		public async Task<ShoesViewModel> GetShoesById(long id)
		{
			var response = await _shoesRepository.GetShoes(id);
			if(response == null) return null;
			var shoesViewModel = new ShoesViewModel(response);
			shoesViewModel.shoesImagesViewModels = await GetShoesImagesViewModels(id);
			return shoesViewModel;
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

		public async Task<List<ShoesViewModel>> GetListShoesByBrand(PagingModel paging)
		{
			paging.BrandName = paging.BrandName.Trim();
			var data = await _shoesRepository.GetListShoesByBrand(paging);
			if (!data.Any()) return data.Select(b => new ShoesViewModel()).ToList();
			var response = await GetShoesViewModels(data);
			return response;
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

		public async Task<BaseRepsonse> UpdateShoes(ShoesUpdateModel model, string userName)
		{
			var existedBrand = await _brandRepository.GetBrandByName(model.BrandName);
			if (existedBrand == null)
			{
				return new BaseRepsonse { IsSuccess = false, Message = $"Hãng giày {model.BrandName} không tồn tại" };
			}

			var existedShoes = await _shoesRepository.GetShoesByName(model.Name);
			if (existedShoes != null)
			{
				return new BaseRepsonse { IsSuccess = false, Message = $"Tên giày {model.Name} đã tồn tại" };
			}
			var shoesDto = model.GetEntity();
			return await _shoesRepository.UpdateShoes(shoesDto, userName);
		}

		#region Private
		private async Task<List<ShoesImagesViewModel>> GetShoesImagesViewModels(long shoesId)
		{
			var shoesIamges = await _shoesImagesRepository.GetListShoesImagesByShoes(shoesId);
			var shoesImagesViewModels = new List<ShoesImagesViewModel>();

			foreach (var item in shoesIamges)
			{
				var shoesViewModel = new ShoesImagesViewModel(item);
				shoesImagesViewModels.Add(shoesViewModel);
			}

			return shoesImagesViewModels;
		}

		private async Task<List<ShoesViewModel>> GetShoesViewModels(List<App_ShoesDTO> shoesDTOs)
		{
			var response = new List<ShoesViewModel>();

			foreach (var shoes in shoesDTOs)
			{
				var shoesViewModel = new ShoesViewModel(shoes);
				shoesViewModel.shoesImagesViewModels = await GetShoesImagesViewModels(shoes.Id);
				response.Add(shoesViewModel);
			}

			return response;
		}
		#endregion
	}
}
