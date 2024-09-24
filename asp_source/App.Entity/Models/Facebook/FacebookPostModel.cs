using Newtonsoft.Json;
using System;

namespace App.Entity.Models.OpenPlatform.Facebook
{
	public class FacebookPostModel
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("message")]
		public string Message { get; set; }

		[JsonProperty("createdTime")]
		public DateTime CreatedTime { get; set; }
	}
}
