using System;
using System.Collections.Generic;
using System.Text;

namespace App.Entity.Models.OpenPlatform
{
	public class ZaloUserInfoResponseModel
	{
		public int error { get; set; }
		public string message { get; set; }
		public string id { get; set; }
		public string name { get; set; }
		public Picture picture { get; set; }
	}
	public class Picture
	{
		public Data data { get; set; }
	}

	public class Data
	{
		public string url { get; set; }
	}

}
