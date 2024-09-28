using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.DTO
{
	public class App_ShoesImagesDTO
	{
		public long Id { get; set; }
		public long ShoesId { get; set; }
		public string? Thumbnail {  get; set; }
		public bool? IsCustomize { get; set; }
		public bool? IsUserCustom { get; set; }
	}
}
