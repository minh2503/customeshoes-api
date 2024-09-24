﻿namespace App.Utility
{
	public class MomoResponse<T>
	{
		public string requestId { get; set; }
		public int errorCode { get; set; }
		public string orderId { get; set; }
		public string message { get; set; }
		public string localMessage { get; set; }
		public string requestType { get; set; }
		public string payUrl { get; set; }
		public string signature { get; set; }
		public bool Success => errorCode == 0;
	}
}
