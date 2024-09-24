using App.Entity.DTOs;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Entity.DTO
{
	/// <summary>
	/// menu
	/// </summary>
	public class SYS_MenuDTO : BaseDTO<int>
	{
		public SYS_MenuDTO()
		{
		}
		public SYS_MenuDTO(Menu menu)
		{
			ParentId = menu.GroupId;
			FunctionCode = menu.Code;
			Name = menu.DisplayName;
			NavigateLink = menu.Href;
			IsDelete = !menu.IsActive;
			Index = menu.Index;
			Level = menu.Level;
		}
		public int ParentId { get; set; }
		public string FunctionCode { get; set; }
		public string Name { get; set; }
		public string Icon { get; set; }
		/// <summary>
		/// link điều hướng
		/// </summary>
		public string NavigateLink { get; set; }
		public string Description { get; set; }
		/// <summary>
		/// thứ tự hiển thị
		/// </summary>
		public int Index { get; set; }
		public int Level { get; set; }
		[NotMapped]
		public List<SYS_ActionDTO> Actions { get; set; }
	}
}
