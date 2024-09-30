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
		public DateTime? ShipedDate { get; set; }

		[DataType(DataType.Date)]
		public DateTime? DeliveredDate { get; set; }

		public int PaymentMethod { get; set; }
		[DataType(DataType.Date)]
		public DateTime? PaymentDate { get; set; }

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
            Id = dto.Id;
			UserId = dto.UserId;
			Status = dto.Status;
			Note = dto.Note;
			Amount = dto.Amount;
			ShipAddress = dto.ShipAddress;
			ShipedDate = dto.ShipedDate;
			DeliveredDate = dto.DeliveredDate;
			PaymentMethod = dto.PaymentMethod;
			PaymentDate = dto.PaymentDate;
			CreatedDate = dto.CreatedDate;
			OrderId = dto.OrderId;
			ModifyDate = dto.ModifyDate;
			ModifiedBy = dto.ModifiedBy;
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
				ShipedDate = (DateTime)ShipedDate,
				DeliveredDate = (DateTime)DeliveredDate,
				PaymentMethod = PaymentMethod,
				PaymentDate = (DateTime)PaymentDate,
				OrderId = OrderId,
				CreatedDate = CreatedDate,
				ModifyDate = ModifyDate,
				ModifiedBy = ModifiedBy,
			};
		}
	}
}
