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
    public class OrderItemUpdateModel : IEntity<App_OrderItemsDTO>
    {
        [Required(ErrorMessage = "Số lượng không được để trống.")]
        public int Quantity { get; set; }
        public string? Size { get; set; }
        public App_OrderItemsDTO GetEntity()
		{
			return new App_OrderItemsDTO
			{
				Quantity = Quantity,
				Size = Size
			};
		}
	}
}
