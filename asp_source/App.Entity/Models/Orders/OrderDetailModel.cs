using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common;

namespace App.Entity.Models.Orders
{
	public class OrderDetailModel
	{
		public long Id { get; set; }
		public string UserName { get; set; }
		public int? Status { get; set; }
		public string? Note { get; set; }
		public double? Amount { get; set; }
		public string? ShipAddress
		{
			get; set;
		}
		[DataType(DataType.Date)]
		public DateTime? ShipedDate { get; set; }

		[DataType(DataType.Date)]
		public DateTime? DeliveredDate { get; set; }

		public int? PaymentMethod { get; set; }
		[DataType(DataType.Date)]
		public DateTime? PaymentDate { get; set; }

		[DataType(DataType.Date)]
		public DateTime? CreatedDate { get; set; }

		public string? OrderCode { get; set; }

		[DataType(DataType.Date)]
		public DateTime? ModifyDate { get; set; }
		public string? ModifiedBy { get; set; }

		public List<OrderItemDetailModel> orderItemDetailModels { get; set; }

		public OrderDetailModel(App_OrderDTO dto)
		{
			Id = dto.Id;
			Status = dto.Status;
			Note = dto.Note;
			Amount = dto.Amount;
			ShipAddress = dto.ShipAddress;
			ShipedDate = dto.ShipedDate;
			DeliveredDate = dto.DeliveredDate;
			PaymentMethod = dto.PaymentMethod;
			PaymentDate = dto.PaymentDate;
			CreatedDate = dto.CreatedDate;
			OrderCode = dto.OrderCode;
			ModifyDate = dto.ModifyDate;
			ModifiedBy = dto.ModifiedBy;
			orderItemDetailModels = new List<OrderItemDetailModel>();
		}
	}
}
