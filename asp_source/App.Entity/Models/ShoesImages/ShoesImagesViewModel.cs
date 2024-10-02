using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.Models.ShoesImages
{
	public class ShoesImagesViewModel
	{
		public long Id { get; set; }
		public string? Thumbnail { get; set; }
		public bool? IsCustomize { get; set; }
		public bool? IsUserCustom { get; set; }

        public ShoesImagesViewModel()
        {
            
        }

        public ShoesImagesViewModel(App_ShoesImagesDTO dto)
        {
            Id = dto.Id;
            Thumbnail = dto.Thumbnail;
            IsCustomize = dto.IsCustomize;
            IsUserCustom = dto.IsUserCustom;
        }
    }
}
