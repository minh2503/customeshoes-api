using Newtonsoft.Json;

namespace App.Entity.Models.OpenPlatform.Facebook
{
	public class FacebookPageModel
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("access_token")]
		public string AccessToken { get; set; }

		[JsonProperty("category")]
		public string Category { get; set; }

		[JsonProperty("category_list")]
		public List<FacebookCategoryModel> CategoryList { get; set; }

		[JsonProperty("tasks")]
		public List<string> Tasks { get; set; }
	}

	public class FacebookCategoryModel
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
