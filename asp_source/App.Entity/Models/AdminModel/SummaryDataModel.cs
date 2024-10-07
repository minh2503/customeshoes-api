using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.Models.AdminModel
{
	public class SummaryDataModel
	{
        public double? SummaryRevenueInMonth { get; set; }
        public string? RevenueCompareWithPreviousMonth { get; set; }
        public int? SummaryOrdersInMonth { get; set; }
		public string? OrderCompareWithPreviousMonth { get; set; }
        public int? SummaryConfirmedOrderInMonth { get; set; }
		public string? ConfirmedOrderCompareWithPreviousMonth { get; set; }
        public int? SummaryProccessedOrderInMonth { get; set; }
		public string? ProccessedCompareWithPreviousMonth { get; set; }
	}
}
