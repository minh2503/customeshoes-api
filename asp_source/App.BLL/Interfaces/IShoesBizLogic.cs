using App.Entity.Models;
using App.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Interfaces
{
	public interface IShoesBizLogic
	{
		Task<BaseRepsonse> CreateUpadteShoes(ShoesModel model);
		Task<ShoesModel> GetShoesByName(string name);
		Task<ShoesModel> GetShoes(long id);
	}
}
