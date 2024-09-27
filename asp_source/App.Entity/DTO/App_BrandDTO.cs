using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.DTO
{
    public class App_BrandDTO
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Thumbnail { get; set; }
        public DateTime?CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
