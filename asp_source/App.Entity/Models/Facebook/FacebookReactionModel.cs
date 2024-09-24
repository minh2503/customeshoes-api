using Newtonsoft.Json;

namespace App.Entity.Models.OpenPlatform.Facebook
{
	public class FacebookReactionModel
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}
