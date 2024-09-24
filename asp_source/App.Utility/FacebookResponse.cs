﻿namespace App.Utility
{
	public class FacebookResponse<T>
	{
		public T data { get; set; }
		public Paging paging { get; set; }
	}

	public class Paging
	{
		public Cursors cursors { get; set; }
	}

	public class Cursors
	{
		public string before { get; set; }
		public string after { get; set; }
	}
}
