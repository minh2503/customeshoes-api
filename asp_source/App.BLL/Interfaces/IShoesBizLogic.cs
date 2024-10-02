using App.Entity.Models;
using App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common.Models;
using App.Entity.Models.Shoes;

namespace App.BLL.Interfaces
{
	public interface IShoesBizLogic
	{
		Task<BaseRepsonse> CreateShoes(ShoesRequestModel model, string userName);
		Task<BaseRepsonse> UpdateShoes(ShoesUpdateModel model, string userName);
		Task<ShoesModel> GetShoesByName(string name);
		Task<ShoesModel> GetShoes(long id);
		Task<ShoesViewModel> GetShoesById(long id);
		Task<List<ShoesModel>> GetListShoes(PagingModel paging);
		Task<List<ShoesViewModel>> GetListShoesByBrand(PagingModel paging);
		Task<List<ShoesViewModel>> GetListShoesByPrice(PagingModel paging);
		Task<List<ShoesModel>> GetListShoesByKey(PagingModel paging);
		Task<BaseRepsonse> DeleteShoes(long id);
	}
}
