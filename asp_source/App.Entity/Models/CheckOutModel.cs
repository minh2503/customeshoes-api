using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.Models
{
	public class CheckOutModel
	{
		public long UserId { get; set; }
		public int Status { get; set; }
		public string? Note { get; set; }
		public double Amount { get; set; } = 0;
		public string? ShipAddress { get; set; }

		[DataType(DataType.Date)]
		public DateTime ShipedDate { get; set; }

		[DataType(DataType.Date)]
		public DateTime DeliveredDate { get; set; }

		public int PaymentMethod { get; set; }
		[DataType(DataType.Date)]
		public DateTime PaymentDate { get; set; }

		[DataType(DataType.Date)]
		public DateTime CreatedDate { get; set; }

		[DataType(DataType.Date)]
		public DateTime ModifyDate { get; set; }
		public string? ModifiedBy { get; set; }

		public long OrderItemId { get; set; }
		[Required(ErrorMessage = "ShoesId không được để trống.")]

		public long ShoesId { get; set; }

		[Required(ErrorMessage = "Số lượng không được để trống.")]
		[Range(0, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0.")]
		public int Quantity { get; set; }

		public double UnitPrice { get; set; }

		[Required(ErrorMessage = "Ảnh không được để trống.")]
		public long ShoesImageId { get; set; }

		[Required(ErrorMessage = "Mã đơn hàng không được để trống.")]
		public long OrderId { get; set; }

		public App_OrderDTO GetOrderEntity()
		{
			return new App_OrderDTO
			{
				Id = OrderId,
				UserId = UserId,
				Status = Status,
				Note = Note,
				Amount = Amount,
				ShipAddress = ShipAddress,
				ShipedDate = ShipedDate,
				DeliveredDate = DeliveredDate,
				PaymentMethod = PaymentMethod,
				PaymentDate = PaymentDate,
				CreatedDate = CreatedDate,
				ModifiedBy = ModifiedBy,
				ModifyDate = ModifyDate,
			};
		}

		public App_OrderItemsDTO GetOrderItemsEntity()
		{
			return new App_OrderItemsDTO
			{
				Id = OrderItemId,
				ShoesId = ShoesId,
				Quantity = Quantity,
				UnitPrice = UnitPrice,
				ShoesImageId = ShoesImageId,
				OrderId = OrderId,
			};
		}
	}
}
