using App.Entity.DTOs; 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
using TFU.Common;

namespace App.Entity.Models
{
	public class RoleMenuModel : IEntity<RoleMenuDTO>
	{
		[Required(ErrorMessage = Constants.Required)]
		public long RoleId { get; set; } 
		public string[] MenuCodes { get; set; }
		public List<MenuModel> AllMenus { get; set; }
		public RoleMenuModel() { }
		public RoleMenuDTO GetEntity(long roleId, string menuCode)
		{
			return new RoleMenuDTO
			{
				RoleId = roleId,
				MenuCode = menuCode
			};
		}
		public RoleMenuDTO GetEntity()
		{ 
			return new RoleMenuDTO
			{
				RoleId = RoleId
			};
		}
	}
}
