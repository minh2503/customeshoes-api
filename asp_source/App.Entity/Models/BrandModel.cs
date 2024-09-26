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
	public class BrandModel : IEntity<App_BrandDTO>
	{
		public long Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public string? Thumbnail { get; set; }

		[DataType(DataType.Date)]
		public DateTime? CreatedDate { get; set; } =  DateTime.Now;
		public DateTime? CreatedBy { get; set; } = DateTime.Now;
		public bool IsActive { get; set; }

        public BrandModel()
        {
            
        }

        public BrandModel(App_BrandDTO dto)
        {
            Id = dto.Id;
			Name = dto.Name;
			Description = dto.Description;
			Thumbnail = dto.Thumbnail;
			CreatedDate = dto.CreatedDate;
			CreatedBy = dto.CreatedBy;
			IsActive = dto.IsActive;
        }

        public App_BrandDTO GetEntity()
		{
			return new App_BrandDTO
			{
				Id = Id,
				Name = Name,
				Description = Description,
				Thumbnail = Thumbnail,
				CreatedDate = CreatedDate,
				CreatedBy = CreatedBy,
				IsActive = IsActive
			};
		}
	}
}
