using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common;

namespace App.Entity.Models.Shoes
{
	public class ShoesRequestModel : IEntity<App_ShoesDTO>
	{
		public long Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		[Required(ErrorMessage = "Giá tiền không được để trống.")]
		public double Price { get; set; }
		public bool IsCustomizable { get; set; } = false;
		[Required(ErrorMessage = "Tên hãng giày không được để trống.")]
		public string? BrandName { get; set; }
		[Required(ErrorMessage = "Hãy thêm ít nhất một ảnh cho giày.")]
		public string? Thumbnail { get; set; }
		public bool? IsImageCustomize { get; set; }
		public bool? IsImageUserCustom { get; set; }

		public App_ShoesDTO GetEntity()
		{
			return new App_ShoesDTO
			{
				Id = Id,
				Name = Name,
				Description = Description,
				Price = Price,
				IsCustomizable = IsCustomizable,
				BrandName = BrandName
			};
		}

		public App_ShoesImagesDTO GetImageEntity()
		{
			return new App_ShoesImagesDTO
			{
				Thumbnail = Thumbnail,
				IsCustomize = IsImageCustomize,
				IsUserCustom = IsImageUserCustom
			};
		}
	}
}
