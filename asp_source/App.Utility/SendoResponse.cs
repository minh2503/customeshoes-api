using Newtonsoft.Json;

namespace App.Utility
{
	public class SendoResponse<T>
	{
		[JsonProperty("success")]
		public bool Success { get; set; }

		[JsonProperty("error")]
		public object Error { get; set; }

		[JsonProperty("status_code")]
		public string StatusCode { get; set; } 

		[JsonProperty("result")]
		public T Data { get; set; }
	}
}
