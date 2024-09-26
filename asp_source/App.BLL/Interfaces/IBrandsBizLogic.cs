using App.Entity.Models;
using App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Interfaces
{
    public interface IBrandsBizLogic
    {
		Task<BaseRepsonse> CreateUpadteBrands(BrandModel model);
		Task<BrandModel> GetBrand(long id);
	}
}
