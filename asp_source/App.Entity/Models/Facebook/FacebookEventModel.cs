using Newtonsoft.Json;

namespace App.Entity.Models.OpenPlatform.Facebook
{
	public class FacebookEventModel
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("start_time")]
		public string StartTime { get; set; }
	}
}
