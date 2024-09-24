using Newtonsoft.Json;

namespace App.Entity.Models.OpenPlatform.Facebook
{
	public class FacebookFeedModel
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("message")]
		public string message { get; set; }

		[JsonProperty("story")]
		public string Story { get; set; }

		[JsonProperty("updated_time")]
		public DateTime UpdatedTime { get; set; }
	}
}
