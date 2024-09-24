using App.Entity.DTO;
using System.ComponentModel.DataAnnotations;
using TFU.Common;

namespace App.Entity.Models
{
	public class MenuModel : IEntity<SYS_MenuDTO>
	{
		public int Id { get; set; }
		public int ParentId { get; set; }
		[Required(ErrorMessage = Constants.Required)]
		public string FunctionCode { get; set; }
		[Required(ErrorMessage = Constants.Required)]
		public string Name { get; set; }
		public string Icon { get; set; }
		/// <summary>
		/// link điều hướng
		/// </summary> 
		public string NavigateLink { get; set; }
		public string Description { get; set; }
		public bool Checked { get; set; }
		public int Level { get; set; }
		public List<ActionModel> Actions { get; set; }
		public MenuModel() { }
		public MenuModel(SYS_MenuDTO dto)
		{
			Id = dto.Id;
			ParentId = dto.ParentId;
			FunctionCode = dto.FunctionCode;
			Name = dto.Name;
			Icon = dto.Icon;
			NavigateLink = dto.NavigateLink;
			Description = dto.Description;
			if (dto.Actions != null && dto.Actions.Count > 0)
				Actions = dto.Actions.Select(x => new ActionModel(x)).ToList();
		}

		public SYS_MenuDTO GetEntity()
		{
			return new SYS_MenuDTO
			{
				Id = Id,
				ParentId = ParentId,
				FunctionCode = FunctionCode,
				Name = Name,
				Icon = Icon,
				NavigateLink = NavigateLink,
				Description = Description,
				Actions = (Actions != null && Actions.Count > 0) ? Actions.Select(x => x.GetEntity()).ToList() : null
			};
		}
	}
}
