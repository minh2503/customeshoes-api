using Newtonsoft.Json;

namespace App.Entity.Models.OpenPlatform.Facebook
{
	public class FacebookCommentModel
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("message")]
		public string Message { get; set; }

		[JsonProperty("created_time")]
		public DateTime CreatedTime { get; set; }
	}
}
