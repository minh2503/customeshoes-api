using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.DTO
{
	public class App_OrderItemsDTO
	{
		public long Id { get; set; }
		public long ShoesId { get; set; }
		public int Quantity { get; set; }
		public double UnitPrice { get; set; }
		public long ShoesImageId { get; set; }
		public long OrderId { get; set; }
        public string? Size { get; set; }
    }
}
