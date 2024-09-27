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
	public interface IBrandsBizLogic
	{
		Task<BaseRepsonse> CreateUpadteBrands(BrandModel model);
		Task<BrandModel> GetBrand(long id);
		Task<List<BrandModel>> GetListBrands(PagingModel paging);
		Task<List<BrandModel>> GetTop5Brand();
		Task<BaseRepsonse> DeleteBrand(long id);
	}
}
