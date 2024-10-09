using App.Entity.DTO;
using App.Entity.Models.Shoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common;

namespace App.Entity.Models.AdminModel
{
	public class TopSellingShoesModel
	{
        public ShoesViewModel ShoesViewModel { get; set; } = null!;
        public int QuantitySold { get; set; }
        public double TotalRevenue { get; set; }

        public TopSellingShoesModel(TopSellingShoesDTO topSellingShoesDTO)
        {
            QuantitySold = topSellingShoesDTO.QuantitySold;
            TotalRevenue = topSellingShoesDTO.TotalRevenue;
        }
    }
}
