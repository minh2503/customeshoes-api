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
	public class ShoesModel : IEntity<App_ShoesDTO>
	{
		public long Id { get; set; }

		[Required(ErrorMessage = "Tên của giày không được để trống.")]
		public string? Name { get; set; }

		public string? Description { get; set; }

		[Required(ErrorMessage = "Giá tiền không được để trống.")]
		public double Price { get; set; }
		public bool IsCustomizable { get; set; } = false;

		[DataType(DataType.Date)]
		public DateTime CreatedDate { get; set; } = DateTime.Now;
		public string? CreatedBy { get; set; }

		[DataType(DataType.Date)]
		public DateTime ModifyDate { get; set; } = DateTime.Now;

		[Required(ErrorMessage = "Tên hãng giày không được để trống.")]
		public string? BrandName { get; set; }
		public bool IsActive { get; set; }
		public string? ModifyBy { get; set; }

		public ShoesModel()
		{

		}

		public ShoesModel(App_ShoesDTO dto)
		{
			Id = dto.Id;
			Name = dto.Name;
			Price = dto.Price;
			Description = dto.Description;
			CreatedDate = dto.CreatedDate;
			CreatedBy = dto.CreatedBy;
			IsActive = dto.IsActive;
			IsCustomizable = dto.IsCustomizable;
			BrandName = dto.BrandName;
			ModifyBy = dto.ModifyBy;
			ModifyDate = dto.ModifyDate;
        }

		public App_ShoesDTO GetEntity()
		{
			return new App_ShoesDTO
			{
				Id = Id,
				Name = Name,
				Price = Price,
				Description = Description,
				CreatedDate = CreatedDate,
				CreatedBy = CreatedBy,
				IsActive = IsActive,
				IsCustomizable = IsCustomizable,
				BrandName = BrandName,
				ModifyBy = ModifyBy,
				ModifyDate = ModifyDate,
			};
		}
	}
}
