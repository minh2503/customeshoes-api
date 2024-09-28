using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entity;
using App.Entity.DTO;

namespace App.DAL.Interfaces
{
	public interface IShoesImagesRepository
	{
		Task<BaseRepsonse> CreateUpdateShoesImages(App_ShoesImagesDTO dto);
		Task<App_ShoesImagesDTO> GetShoesImagesDTO(long id);
	}
}
