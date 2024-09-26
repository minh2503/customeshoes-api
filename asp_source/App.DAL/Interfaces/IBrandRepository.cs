using App.Entity.DTO;
using App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Interfaces
{
    public interface IBrandRepository
    {
		Task<BaseRepsonse> CreateUpdateBrand(App_BrandDTO brandDTO);
		Task<App_BrandDTO> GetBrand(long id);
	}
}
