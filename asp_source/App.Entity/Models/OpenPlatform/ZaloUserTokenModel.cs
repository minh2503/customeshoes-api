using System;
using System.Collections.Generic;
using System.Text;

namespace App.Entity.Models.OpenPlatform
{
	public class ZaloUserTokenModel
	{
		public string access_token { get; set; }
		public string refresh_token { get; set; }
		public string expires_in { get; set; }
	}
}
