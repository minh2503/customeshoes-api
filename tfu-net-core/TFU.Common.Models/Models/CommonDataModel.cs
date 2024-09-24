﻿using System;

namespace TFU.Common.Models
{
	public class CommonDataModel
	{
		public bool IsDelete { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? CreatedDate { get; set; }
		public string ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
	}
}
