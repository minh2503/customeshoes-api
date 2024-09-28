using App.Entity;
using App.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common.Models;

namespace App.BLL.Interfaces
{
	public interface IShoesImagesBizLogic
	{
		Task<BaseRepsonse> CreateUpdateShoesImages(ShoesImagesModel model);
		Task<ShoesImagesModel> GetShoesImages(long id);
		Task<List<ShoesImagesModel>> GetListShoesImages(PagingModel paging);
		Task<List<ShoesImagesModel>> GetListShoesImagesByShoes(PagingModel paging);
	}
}
