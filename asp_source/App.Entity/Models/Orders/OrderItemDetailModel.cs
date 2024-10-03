using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.Models.Orders
{
	public class OrderItemDetailModel
	{
		public long Id { get; set; }
		public ShoesModel ShoesModel { get; set; }
		public int Quantity { get; set; }
		public double UnitPrice { get; set; }
		public ShoesImagesModel ShoesImage { get; set; }
        public string? Size { get; set; }

        public OrderItemDetailModel(App_OrderItemsDTO dto)
        {
			Id = dto.Id;
			Quantity = dto.Quantity;
			UnitPrice = dto.UnitPrice;
			Size = dto.Size;
            ShoesModel = new ShoesModel();
			ShoesImage = new ShoesImagesModel();
        }

    }
}
