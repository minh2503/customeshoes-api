using App.Entity;
using App.Entity.DTO;
using App.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Interfaces
{
	public interface ICheckOutBizLogic
	{
		Task<BaseRepsonse> CheckOutAsync(CheckOutModel model, ShoesModel shoesModel);
	}
}
