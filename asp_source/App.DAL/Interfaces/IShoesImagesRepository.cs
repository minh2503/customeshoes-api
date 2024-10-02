using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entity;
using App.Entity.DTO;
using TFU.Common.Models;

namespace App.DAL.Interfaces
{
	public interface IShoesImagesRepository
	{
		Task<BaseRepsonse> CreateUpdateShoesImages(App_ShoesImagesDTO dto);
		Task<App_ShoesImagesDTO> GetShoesImages(long id);
		Task<List<App_ShoesImagesDTO>> GetAllShoesImages(PagingModel model);
		Task<List<App_ShoesImagesDTO>> GetListShoesImagesByShoes(long shoesId);
		Task<List<App_ShoesImagesDTO>> GetUserCustomShoesImagesByShoes(PagingModel model);
		Task<BaseRepsonse> DeleteImage(long id);
	}
}
