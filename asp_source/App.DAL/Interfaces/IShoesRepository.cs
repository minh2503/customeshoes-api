using App.Entity;
using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common.Models;

namespace App.DAL.Interfaces
{
	public interface IShoesRepository
	{
		Task<BaseRepsonse> CreateShoes(App_ShoesDTO dto, App_ShoesImagesDTO imageDto, string userName);
		Task<BaseRepsonse> UpdateShoes(App_ShoesDTO dto, string userName);
		Task<App_ShoesDTO> GetShoesByName(string name);
		Task<App_ShoesDTO> GetShoes(long id);
		Task<List<App_ShoesDTO>> GetAllShoes(PagingModel paging);
		Task<List<App_ShoesDTO>> GetListShoesByBrand(PagingModel paging);
		Task<List<App_ShoesDTO>> GetListShoesByPrice(PagingModel paging);
		Task<List<App_ShoesDTO>> GetListShoesByKey(PagingModel paging);
		Task<List<App_ShoesDTO>> GetRandom4Shoes();
		Task<BaseRepsonse> DeleteShoes(long id);
	}
}
