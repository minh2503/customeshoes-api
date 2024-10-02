using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.Models.Brands
{
	public class BrandViewModel
	{
		public long Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public string? Thumbnail { get; set; }
		[DataType(DataType.Date)]
		public DateTime? CreatedDate { get; set; }
		public string? CreatedBy { get; set; }

        public BrandViewModel()
        {
            
        }
        public BrandViewModel(App_BrandDTO dto)
        {
            Id = dto.Id;
			Name = dto.Name;
			Description = dto.Description;
			Thumbnail = dto.Thumbnail;
			CreatedDate = dto.CreatedDate;
			CreatedBy = dto.CreatedBy;
        }
    }
}
