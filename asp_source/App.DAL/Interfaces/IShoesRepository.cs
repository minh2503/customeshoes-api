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
		Task<BaseRepsonse> CreateUpdateShoes(App_ShoesDTO dto);
		Task<App_ShoesDTO> GetShoesByName(string name);
		Task<App_ShoesDTO> GetShoes(long id);
		Task<List<App_ShoesDTO>> GetAllShoes(PagingModel paging);
		Task<BaseRepsonse> DeleteShoes(long id);
	}
}
