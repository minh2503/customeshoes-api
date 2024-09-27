using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.DTO
{
	public class App_ShoesDTO
	{
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public bool IsCustomizable { get; set; } = false;
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public string? CreatedBy { get; set; }
        public DateTime ModifyDate { get; set; } = DateTime.Now;
		public string? BrandName { get; set; }
        public bool IsActive { get; set; }
        public string? ModifyBy { get; set; }
    }
}
