using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace App.Utility
{
	public class LazadaResponse<T>
	{
		public string Code { get; set; }
		public string Message { get; set; }
		public T Data { get; set; }
		public bool Success => Code == "0";
		public string request_id { get; set; }
		public List<JObject> Detail { get; set; }
		public T Result { get; set; }
		public string batch_id { get; set; }
	} 
}
