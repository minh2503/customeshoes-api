using App.Entity.Models;
using App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common.Models;

namespace App.BLL.Interfaces
{
	public interface IShoesBizLogic
	{
		Task<BaseRepsonse> CreateUpadteShoes(ShoesModel model);
		Task<ShoesModel> GetShoesByName(string name);
		Task<ShoesModel> GetShoes(long id);
		Task<List<ShoesModel>> GetListShoes(PagingModel paging);
		Task<List<ShoesModel>> GetListShoesByBrand(PagingModel paging);
		Task<List<ShoesModel>> GetListShoesByPrice(PagingModel paging);
		Task<List<ShoesModel>> GetListShoesByKey(PagingModel paging);
		Task<BaseRepsonse> DeleteShoes(long id);
	}
}
