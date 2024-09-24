using Newtonsoft.Json;

namespace App.Utility
{
	public class TikiResponse<T>
	{
		[JsonProperty("success")]
		public bool Success => Error == null;

		[JsonProperty("error")]
		public object Error { get; set; }

		[JsonProperty("error_description")]
		public object Message { get; set; }

		[JsonProperty("status_code")]
		public string StatusCode { get; set; }

		[JsonProperty("result")]
		public T Data { get; set; }
	}
}
