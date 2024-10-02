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
	public class ShoesUpdateModel : IEntity<App_ShoesDTO>
	{
		[Required(ErrorMessage = "Error không được để trống.")]
		public long Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		[Required(ErrorMessage = "Giá tiền không được để trống.")]
		public double Price { get; set; }
		public bool IsCustomizable { get; set; } = false;
		[Required(ErrorMessage = "Tên hãng giày không được để trống.")]
		public string? BrandName { get; set; }
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
	}
}
