using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.Models.AdminModel
{
	public class MonthlyRevenueModel
	{
		public int Year { get; set; }
		public int Month { get; set; }
		public double TotalRevenue { get; set; }

        public MonthlyRevenueModel(MonthlyRevenueDTO monthlyRevenueDTO)
        {
            Year = monthlyRevenueDTO.Year;
			Month = monthlyRevenueDTO.Month;
			TotalRevenue = monthlyRevenueDTO.TotalRevenue;
        }
    }
}
