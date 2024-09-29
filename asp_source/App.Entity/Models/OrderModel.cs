using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common;

namespace App.Entity.Models
{
	public class OrderModel :IEntity<App_OrderDTO>
	{
		public long Id { get; set; }
		public long UserId { get; set; }
		public int Status { get; set; }
		public string? Note { get; set; }
		public double Amount { get; set; } = 0;
		public string? ShipAddress { get; set; 
		}
		[DataType(DataType.Date)]
		public DateTime ShipedDate { get; set; }

		[DataType(DataType.Date)]
		public DateTime DeliveredDate { get; set; }

		public int PaymentMethod { get; set; }
		[DataType(DataType.Date)]
		public DateTime PaymentDate { get; set; }

		[DataType(DataType.Date)]
		public DateTime CreatedDate { get; set; }

		public string? OrderId { get; set; }

		[DataType(DataType.Date)]
		public DateTime ModifyDate { get; set; }
		public string? ModifiedBy { get; set; }

		public OrderModel()
        {
            
        }

        public OrderModel(App_OrderDTO dto)
        {
            dto.Id = Id;
			dto.UserId = UserId;
			dto.Status = Status;
			dto.Note = Note;
			dto.Amount = Amount;
			dto.ShipAddress = ShipAddress;
			dto.ShipedDate = ShipedDate;
			dto.DeliveredDate = DeliveredDate;
			dto.PaymentMethod = PaymentMethod;
			dto.PaymentDate = PaymentDate;
			dto.OrderId = OrderId;
			dto.CreatedDate = CreatedDate;
			dto.ModifyDate = ModifyDate;
			dto.ModifiedBy = ModifiedBy;
        }

		public App_OrderDTO GetEntity()
		{
			return new App_OrderDTO
			{
				Id = Id,
				UserId = UserId,
				Status = Status,
				Note = Note,
				Amount = Amount,
				ShipAddress = ShipAddress,
				ShipedDate = ShipedDate,
				DeliveredDate = DeliveredDate,
				PaymentMethod = PaymentMethod,
				PaymentDate = PaymentDate,
				OrderId = OrderId,
				CreatedDate = CreatedDate,
				ModifyDate = ModifyDate,
				ModifiedBy = ModifiedBy,
			};
		}
	}
}
