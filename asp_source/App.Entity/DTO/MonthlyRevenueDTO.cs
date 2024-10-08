using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.DTO
{
	public class MonthlyRevenueDTO
	{
		public int Year { get; set; }
		public int Month { get; set; }
		public double TotalRevenue { get; set; }
	}

}
