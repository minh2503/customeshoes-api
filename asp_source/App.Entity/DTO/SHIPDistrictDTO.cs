using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.DTO
{
    public class SHIPDistrictDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int VNPOSTDistrictId { get; set; }
        public string ProvinceId { get; set; }
    }
}
