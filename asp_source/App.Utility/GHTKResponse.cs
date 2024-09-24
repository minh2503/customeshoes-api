﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App.Utility
{
	public class GHTKResponse<T>
	{
		public bool Success { get; set; }
		public string Message { get; set; }
		public T Data { get; set; }
	}
}
