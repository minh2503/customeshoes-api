namespace App.Entity.DTOs
{
	/// <summary>
	/// thêm/sửa/xóa/import/....
	/// </summary>
	public class SYS_ActionDTO : BaseDTO<int>
	{
		public SYS_ActionDTO()
		{
		}
		public SYS_ActionDTO(FIFOAction action)
		{
			Name = action.Display;
			ActionCode = action.Code;
			IsDelete = !action.IsActive;
		}
		public string Name { get; set; }
		public string ActionCode { get; set; }
	}

	public struct FIFOAction
	{
		/// <summary>
		/// contructor
		/// </summary>
		/// <param name="code"></param>
		/// <param name="display"></param>
		public FIFOAction(string code, string display, bool active = true)
		{
			Code = code;
			Display = display;
			Checked = false;
			IsActive = active;
		}
		/// <summary>
		/// key
		/// </summary>
		public string Code { get; set; }
		/// <summary>
		/// display
		/// </summary>
		public string Display { get; set; }
		/// <summary>
		/// Active
		/// </summary>
		public bool IsActive { get; set; }
		/// <summary>
		/// checked (true/false)
		/// </summary>
		public bool Checked { get; set; }
	}
}
