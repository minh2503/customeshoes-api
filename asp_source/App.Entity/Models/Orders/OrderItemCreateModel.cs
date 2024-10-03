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
	public class OrderItemCreateModel : IEntity<App_OrderItemsDTO>
	{
		[Required(ErrorMessage = "Giày không được để trống.")]
		public long ShoesId { get; set; }
		[Required(ErrorMessage = "Số lượng không được để trống.")]
		public int Quantity { get; set; }
		[Required(ErrorMessage = "Ảnh không được để trống.")]
		public long ShoesImageId { get; set; }
		[Required(ErrorMessage = "Mã đơn hàng không được để trống.")]
		public long OrderId { get; set; }
		[Required(ErrorMessage = "Size giày không được để trống.")]
		public string Size { get; set; } = null!;

        public App_OrderItemsDTO GetEntity()
		{
			return new App_OrderItemsDTO
			{
				ShoesId = ShoesId,
				Quantity = Quantity,
				ShoesImageId = ShoesImageId,
				OrderId = OrderId,
				Size = Size
			};
		}
	}
}
