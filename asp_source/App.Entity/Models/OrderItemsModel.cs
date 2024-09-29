using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TFU.Common;

namespace App.Entity.Models
{
	public class OrderItemsModel : IEntity<App_OrderItemsDTO>
	{
		public long Id { get; set; }
		[Required(ErrorMessage = "ShoesId không được để trống.")]
		public long ShoesId { get; set; }
		[Required(ErrorMessage = "Số lượng không được để trống.")]
		public int Quantity { get; set; }
		[Required(ErrorMessage = "Giá tiền không được để trống.")]
		public double UnitPrice { get; set; }
		[Required(ErrorMessage = "Ảnh không được để trống.")]
		public long ShoesImageId { get; set; }
		[Required(ErrorMessage = "Mã đơn hàng không được để trống.")]
		public long OrderId { get; set; }

        public OrderItemsModel()
        {
            
        }

        public OrderItemsModel(App_OrderItemsDTO dto)
        {
            Id = dto.Id;
            ShoesId = dto.ShoesId;
            Quantity = dto.Quantity;
            UnitPrice = dto.UnitPrice;
            ShoesImageId = dto.ShoesImageId;
            OrderId = dto.OrderId;
        }

		public App_OrderItemsDTO GetEntity()
		{
			return new App_OrderItemsDTO
			{
				Id = Id,
				ShoesId = ShoesId,
				Quantity = Quantity,
				UnitPrice = UnitPrice,
				ShoesImageId = ShoesImageId,
				OrderId = OrderId
			};
		}
	}
}
