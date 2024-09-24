using Newtonsoft.Json;

namespace App.Entity.Models.OpenPlatform.Facebook
{
	public class FacebookTokenModel
	{
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }

		[JsonProperty("expires_in")]
		public int ExpiresIn { get; set; }

		[JsonProperty("token_type")]
		public string TokenType { get; set; }
	}
}
