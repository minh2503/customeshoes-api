using System.ComponentModel;

namespace App.Entity.Enums
{
	public enum SaveResultType
	{
		/// <summary>
		/// lưu thát bại
		/// </summary>
		[Description("Thất bại")]
		Failed = 0,
		/// <summary>
		/// lưu thành công
		/// </summary>
		[Description("Thành công")]
		Successfully = 1,
		/// <summary>
		/// trùng mã code
		/// </summary>
		[Description("Trùng mã code")]
		DuplicateCode = -1,
		/// <summary>
		/// trùng tên
		/// </summary>
		[Description("Trùng tên")]
		DuplicateName = -2,
		/// <summary>
		/// trùng email
		/// </summary>
		[Description("Trùng email")]
		DuplicateEmail = -3,
		/// <summary>
		/// trùng số điện thoại
		/// </summary>
		[Description("Trùng số điện thoại")]
		DuplicatePhone = -4,
		/// <summary>
		/// trùng dữ liệu
		/// </summary>
		[Description("Trùng dữ liệu")]
		Duplicate = -5,
		/// <summary>
		/// đã được sử dụng
		/// </summary>
		[Description("Đã được sử dụng")]
		AlreadyUsed = -6,
		/// <summary>
		/// đã quá thời hạn để xoá
		/// </summary>
		[Description("Đã quá thời hạn để xoá")]
		OverDate = -7,
		/// <summary>
		/// Còn tồn tại sản phẩm trong slot
		/// </summary>
		[Description("Còn tồn tại sản phẩm trong slot")]
		StillProductInSlot = -8,
		/// <summary>
		/// Chưa đến thời gian nhận quà
		/// </summary>
		[Description("Chưa đến thời gian nhận quà")]
		EarlyDate = -9
	}

	public enum StatusActive
	{
		InActive = 0,
		Active = 1,
		All = 2
	}
}
