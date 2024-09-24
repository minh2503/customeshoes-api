namespace App.Utility
{
	//public class ShopeeResponse<T>
	//{
	//	public bool Success => string.IsNullOrWhiteSpace(Error);
	//	[JsonProperty("error")]
	//	public string Error { get; set; }

	//	[JsonProperty("msg")]
	//	public string Msg { get; set; }

	//	[JsonProperty("data")]
	//	public T Data { get; set; }
	//}

	public class ShopeeResponse<T>
	{
		public bool Success => string.IsNullOrWhiteSpace(error);
		public string error { get; set; }
		public string message { get; set; }
		public object response { get; set; }
		public string request_id { get; set; }
		public T Data { get; set; }
	}
}
