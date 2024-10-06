﻿using App.Entity.DTO;
using App.Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.Models.Orders
{
	public class CreateUpdateOrderModel
	{
		public long OrderId { get; set; }
		public string? Note { get; set; }
		public string? ShipAddress { get; set; }
		public PaymentMethod PaymentMethod { get; set; }
		[Required(ErrorMessage = "ShoesId không được để trống.")]
		public long ShoesId { get; set; }

		[Required(ErrorMessage = "Số lượng không được để trống.")]
		[Range(0, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0.")]
		public int Quantity { get; set; }

		[Required(ErrorMessage = "Ảnh không được để trống.")]
		public string? Thumbnail { get; set; }
		[Required(ErrorMessage = "Size giày không được để trống.")]
		public string Size { get; set; } = null!;
		public OrderStatus Status { get; set; }

		public bool IsOrderStatusValid()
		{
			return Enum.IsDefined(typeof(OrderStatus), Status);
		}

		public bool IsPaymentMethodValid()
		{
			return Enum.IsDefined(typeof(PaymentMethod), PaymentMethod);
		}

		public bool IsPaymentMethodValid(int paymentMethod)
		{
			return Enum.IsDefined(typeof(PaymentMethod), paymentMethod);
		}


		public App_OrderDTO GetOrderEntity()
		{
			return new App_OrderDTO
			{
				Id = OrderId,
				Note = Note,
				ShipAddress = ShipAddress,
				PaymentMethod = (int)PaymentMethod,
				Status = (int)Status,
			};
		}

		public App_OrderItemsDTO GetOrderItemsEntity()
		{
			return new App_OrderItemsDTO
			{
				ShoesId = ShoesId,
				Quantity = Quantity,
				Size = Size,
			};
		}
	}
}
