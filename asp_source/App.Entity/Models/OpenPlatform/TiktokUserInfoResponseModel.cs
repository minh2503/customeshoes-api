namespace App.Entity.Models.OpenPlatform
{
	public class TiktokUserInfoResponseModel
	{
		public string open_id { get; set; }
		public string union_id { get; set; }
		public string avatar_url { get; set; }
		public string avatar_url_100 { get; set; }
		public string avatar_url_200 { get; set; }
		public string avatar_large_url { get; set; }
		public string display_name { get; set; }
	}


	public class TiktokRootobject
	{
		public DataTikTok data { get; set; }
		public Error error { get; set; }
	}

	public class DataTikTok
	{
		public TiktokUserInfoResponseModel user { get; set; }
	}

	public class Error
	{
		public int code { get; set; }
		public string message { get; set; }
	}

}
