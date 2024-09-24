using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TFU.Common.Models;

namespace App.Entity.DTOs
{
	public class BaseDTO<TType> : CommonDataModel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public TType Id { get; set; }
	}

	public class BaseDTO : CommonDataModel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
	}
	public struct Menu
	{
		public Menu(string code, string displayName, string href, int group, int index = 9999, int level = 0, bool isactive = true)
		{
			Code = code;
			DisplayName = displayName;
			Href = href;
			GroupId = group;
			IsActive = isactive;
			Index = index;
			Level = level;
		}
		public string Code;
		public string DisplayName;
		public string Href;
		public int GroupId;
		public bool IsActive;
		public int Index { get; set; }
		public int Level { get; set; }
	}
}
