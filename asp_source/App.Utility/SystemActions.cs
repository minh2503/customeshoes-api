using System;
using System.Collections.Generic;
using System.Text;

namespace App.Utility
{
	public class SystemActions
	{
		public const string c_Read = "READ";
		public const string c_Create_Update = "CREATE_UPDATE";
		public const string c_Delete = "DELETE";
		public const string c_ExportExcel = "EXPORT";
		public const string c_ImportExcel = "IMPORT";
		public const string c_ChangedStatus = "CHANGED_STATUS";
		public const string c_StockInPendingApproval = "StockInPendingApproval";
		public const string c_StockInApproved = "StockInApproved";
		public const string c_StockInPlanning = "StockInPlanning";
		public const string c_StockInProcessing = "StockInProcessing";
		public const string c_StockInFinalApproved = "StockInFinalApproved";
		public const string c_StockInCompletelyTransferred = "StockInCompletelyTransferred";
		public const string c_StockInPartiallyTransferred = "StockInPartiallyTransferred";
		public const string c_StockInCancelled = "StockInCancelled";
		public const string c_SyncFIFO_OPF = "SYNC_FIFO_OPF";
		public const string c_DeleteSync = "DELETE_SYNC";
		public const string c_DeleteMapped = "DELETE_MAPPED";
		public const string c_MappedProducts = "MAPPED_PRODUCTS";
		public const string c_AssignRole = "ASSIGN_ROLE";
		public const string c_ConfirmEmail = "CONFIRMED_EMAIL";
		public const string c_MappedOPF = "MAPPED_OPF";
		public const string c_ChangeBankTransferStatus = "CHANGE_BANK_TRANSFER_STATUS";
		public const string c_ConnectPlatform = "CONNECT_PLATFORM";
		public const string c_ApprovedProductDesign = "APPROVED_PRODUCT_DESIGN";
		public const string c_PushProductDesign = "PUSH_PRODUCT_DESIGN";
		public const string c_Synchronized = "SYNCHRONIZED";
		public const string c_Approved = "APPROVED";
		public const string c_RegisterVoucher = "REGISTER_VOUCHER";
		/// <summary>
		/// quyền đọc/xem
		/// </summary>
		public static FIFOAction Read => new FIFOAction(c_Read, "Xem");
		/// <summary>
		/// quyền xóa
		/// </summary>
		public static FIFOAction Delete => new FIFOAction(c_Delete, "Xóa");
		/// <summary>
		/// quyền thêm và sửa
		/// </summary>
		public static FIFOAction CreateAndUpdate => new FIFOAction(c_Create_Update, "Thêm và sửa");
		/// <summary>
		/// quyền export excel
		/// </summary>
		public static FIFOAction ExportExcel => new FIFOAction(c_ExportExcel, "Xuất file excel");
		/// <summary>
		/// quyền import excel
		/// </summary>
		public static FIFOAction ImportExcel => new FIFOAction(c_ImportExcel, "Tải lên file excel");
		/// <summary>
		/// thay đổi trạng thái
		/// </summary>
		public static FIFOAction ChangedStatus => new FIFOAction(c_ChangedStatus, "Thay đổi trạng thái");
		/// <summary>
		/// chờ xét duyệt nhập kho
		/// </summary>
		public static FIFOAction StockInPendingApproval => new FIFOAction(c_StockInPendingApproval, "Chờ xét duyệt nhập kho");
		/// <summary>
		/// xét duyệt nhập kho
		/// </summary>
		public static FIFOAction StockInApproved => new FIFOAction(c_StockInApproved, "Xét duyệt nhập kho");
		/// <summary>
		/// lên kế hoạch vị trí lưu kho trước khi hàng thực tế về kho
		/// </summary>
		public static FIFOAction StockInPlanning => new FIFOAction(c_StockInPlanning, "Lên kế hoạch nhập kho");
		/// <summary>
		/// trong quá trình nhập kho
		/// </summary>
		public static FIFOAction StockInProcessing => new FIFOAction(c_StockInProcessing, "Xử lý nhập kho");
		/// <summary>
		/// xét duyệt nhập kho lần cuối bởi sếp
		/// sếp duyệt, số lượng lúc này sẽ được cộng vào kho
		/// </summary>
		public static FIFOAction StockInFinalApproved => new FIFOAction(c_StockInFinalApproved, "Nhập SP vào kho");
		/// <summary>
		/// nhập kho hoàn thành
		/// </summary>
		public static FIFOAction StockInCompletelyTransferred => new FIFOAction(c_StockInCompletelyTransferred, "Hoàn thành nhập kho");
		/// <summary>
		/// nhập kho một phần
		/// </summary>
		public static FIFOAction StockInPartiallyTransferred => new FIFOAction(c_StockInPartiallyTransferred, "Nhập một phần SP");
		/// <summary>
		/// hủy bỏ nhập kho
		/// </summary>
		public static FIFOAction StockInCancelled => new FIFOAction(c_StockInCancelled, "Hủy YC nhập kho");
		/// <summary>
		/// đồng bộ qua lại giữa Lotus-TMĐT
		/// </summary>
		public static FIFOAction SyncLotus_OPF => new FIFOAction(c_SyncFIFO_OPF, "Đồng bộ Lotus <=> TMĐT");
		/// <summary>
		/// xóa đồng bộ từ sàn về
		/// </summary>
		public static FIFOAction DeleteSync => new FIFOAction(c_DeleteSync, "Xóa SP đồng bộ từ website TMĐT");
		/// <summary>
		/// xóa mapped
		/// </summary>
		public static FIFOAction DeleteMapped => new FIFOAction(c_DeleteMapped, "Xóa Mapping SP");
		/// <summary>
		///  ghép cặp các sản phẩm
		/// </summary>
		public static FIFOAction MappedProducts => new FIFOAction(c_MappedProducts, "Mapping với sản phẩm FIFO");
		/// <summary>
		/// phân quyền cho người dùng
		/// </summary>
		public static FIFOAction AssignRole => new FIFOAction(c_AssignRole, "Phân quyền");
		/// <summary>
		/// xác thực email cho người dùng
		/// </summary>
		public static FIFOAction ConfirmEmail => new FIFOAction(c_ConfirmEmail, "Xác thực email");
		/// <summary>
		///  mapping
		/// </summary>
		public static FIFOAction MappedOPFToFiFo => new FIFOAction(c_MappedOPF, "Mapping với FIFO");
		/// <summary>
		/// Thay đổi trạng thái đơn rút tiền
		/// </summary>
		public static FIFOAction ChangeBankTransferStatus => new FIFOAction(c_ChangeBankTransferStatus, "Thay đổi trạng thái đơn rút tiền");
		/// <summary>
		/// Kết nối đến sàn TMĐT
		/// </summary>
		public static FIFOAction ConnectPlatform => new FIFOAction(c_ConnectPlatform, "Kết nối đến sàn TMĐT");
		/// <summary>
		/// duyệt sản phẩm design
		/// </summary>
		public static FIFOAction ApprovedProductDesign => new FIFOAction(c_ApprovedProductDesign, "Duyệt sản phẩm Design");
		/// <summary>
		/// Đẩy sản phẩm lên sàn
		/// </summary>
		public static FIFOAction PushProductDesign => new FIFOAction(c_PushProductDesign, "Đẩy sản phẩm");
		/// <summary>
		/// Đồng bộ
		/// </summary>
		public static FIFOAction Synchronized => new FIFOAction(c_Synchronized, "Đồng bộ");
		/// <summary>
		/// duyệt
		/// </summary>
		public static FIFOAction Approved => new FIFOAction(c_Approved, "Duyệt");
		/// <summary>
		/// Đăng ký voucher
		/// </summary>
		public static FIFOAction RegisterVoucher => new FIFOAction(c_RegisterVoucher, "Đăng ký Voucher");
	}

	/// <summary>
	/// the permission
	/// </summary>
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
