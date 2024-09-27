using App.Entity.DTO;
using App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common.Models;

namespace App.DAL.Interfaces
{
    public interface IBrandRepository
    {
		Task<BaseRepsonse> CreateUpdateBrand(App_BrandDTO brandDTO);
		Task<App_BrandDTO> GetBrand(long id);
		Task<List<App_BrandDTO>> GetAllBrands(PagingModel paging);
		Task<List<App_BrandDTO>> GetTop5Brands();
		Task<List<App_BrandDTO>> GetBrandsWithoutPaging();
		Task<BaseRepsonse> DeleteBrand(long id);
		Task<App_BrandDTO> GetBrandByName(string name);
	}
}
