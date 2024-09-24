namespace App.Entity.Models.OpenPlatform
{
	public class TiktokUserTokenModelRoot
	{
		public TiktokUserTokenModel data { get; set; }
		public string message { get; set; }
	}

	public class TiktokUserTokenModel
	{
		public string access_token { get; set; }
		public string captcha { get; set; }
		public string desc_url { get; set; }
		public string description { get; set; }
		public int error_code { get; set; }
		public long expires_in { get; set; }
		public string log_id { get; set; }
		public string open_id { get; set; }
		public long refresh_expires_in { get; set; }
		public string refresh_token { get; set; }
		public string scope { get; set; }
	}

}




