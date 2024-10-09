using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.DTO
{
	public class TopSellingShoesDTO
	{
		public long ShoesId { get; set; }
		public int QuantitySold { get; set; }
		public double TotalRevenue { get; set; }
	}
}
