using System.ComponentModel.DataAnnotations;

namespace App.Entity.DTOs
{
	public class SYS_MappingMenuActionDTO
	{
		public SYS_MappingMenuActionDTO()
		{
		}
		public SYS_MappingMenuActionDTO(Menu menu, FIFOAction action)
		{
			MenuCode = menu.Code;
			ActionCode = action.Code;
		}
		[Key]
		public string MenuCode { get; set; }

		[Key]
		public string ActionCode { get; set; }
	}
}
