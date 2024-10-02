using App.Entity.DTO;
using App.Entity.Models.ShoesImages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.Models.Shoes
{
	public class ShoesViewModel
	{
		public long Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public double Price { get; set; }
		public bool IsCustomizable { get; set; }
		public DateTime CreatedDate { get; set; }
		public string? CreatedBy { get; set; }
		public DateTime ModifyDate { get; set; }
		public string? BrandName { get; set; }
		public string? ModifyBy { get; set; }
		public List<ShoesImagesViewModel> shoesImagesViewModels { get; set; } = new List<ShoesImagesViewModel>();

        public ShoesViewModel()
        {
            
        }

        public ShoesViewModel(App_ShoesDTO dto)
        {
            Id = dto.Id;
			Name = dto.Name;
			Description = dto.Description;
			Price = dto.Price;
			IsCustomizable = dto.IsCustomizable;
			CreatedDate = dto.CreatedDate;
			ModifyDate = dto.ModifyDate;
			BrandName = dto.BrandName;
			ModifyBy = dto.ModifyBy;
			CreatedBy = dto.CreatedBy;
        }
    }
}
