using App.Entity.DTO;
using App.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common;

namespace App.Entity.Models.Orders
{
	public class OrderUpdateModel : IEntity<App_OrderDTO>
	{
		[Required(ErrorMessage = "Id không được để trống.")]
		public long Id { get; set; }
		public OrderStatus Status { get; set; }
		public string? Note { get; set; }
		public string? ShipAddress { get; set; }
		public PaymentMethod PaymentMethod { get; set; }
		public double? Amount { get; set; }

		public bool IsPaymentMethodValid()
		{
			return Enum.IsDefined(typeof(PaymentMethod), PaymentMethod);
		}

		public bool IsPaymentMethodValid(int paymentMethod)
		{
			return Enum.IsDefined(typeof(PaymentMethod), paymentMethod);
		}

		public bool IsOrderStatusValid()
		{
			return Enum.IsDefined(typeof(OrderStatus), Status);
		}

		public App_OrderDTO GetEntity()
		{
			return new App_OrderDTO
			{
				Id = Id,
				Status = (int)Status,
				Note = Note,
				ShipAddress = ShipAddress,
				PaymentMethod = (int)PaymentMethod,
				Amount = Amount
			};
		}
	}
}
