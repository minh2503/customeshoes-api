using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common;

namespace App.Entity.Models.Brands
{
	public class BrandRequestModel : IEntity<App_BrandDTO>
	{
		public long Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		[Required(ErrorMessage = "Ảnh không được để trống.")]
		public string? Thumbnail { get; set; }

		public App_BrandDTO GetEntity()
		{
			return new App_BrandDTO
			{
				Id = Id,
				Name = Name,
				Description = Description,
				Thumbnail = Thumbnail
			};
		}
	}
}
