using App.Entity.Models;
using App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common.Models;
using App.Entity.Models.Brands;

namespace App.BLL.Interfaces
{
	public interface IBrandsBizLogic
	{
		Task<BaseRepsonse> CreateUpadteBrands(BrandRequestModel model, string userName);
		Task<BrandViewModel> GetBrand(long id);
		Task<List<BrandViewModel>> GetListBrands(PagingModel paging);
		Task<List<BrandModel>> GetBrandsWithoutPaging();
		Task<List<BrandModel>> GetTop5Brand();
		Task<BaseRepsonse> DeleteBrand(long id);
		Task<BrandModel> GetBrandByName(string name);
	}
}
