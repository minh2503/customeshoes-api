using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common;

namespace App.Entity.Models
{
	public class ShoesImagesModel : IEntity<App_ShoesImagesDTO>
	{
		public long Id { get; set; }
		[Required(ErrorMessage = "Giày không được để trống.")]
		public long ShoesId { get; set; }
		public string? Thumbnail { get; set; }
		public bool? IsCustomize { get; set; }
		public bool? IsUserCustom { get; set; }

        public ShoesImagesModel()
        {
            
        }

        public ShoesImagesModel(App_ShoesImagesDTO dto)
        {
            Id = dto.Id;
			Thumbnail = dto.Thumbnail;
			IsCustomize = dto.IsCustomize;
			ShoesId = dto.ShoesId;
			IsUserCustom = dto.IsUserCustom;
        }

        public App_ShoesImagesDTO GetEntity()
		{
			return new App_ShoesImagesDTO
			{
				Id = Id,
				Thumbnail = Thumbnail,
				IsCustomize = IsCustomize,
				ShoesId = ShoesId,
				IsUserCustom = IsUserCustom
			};
		}
	}
}
