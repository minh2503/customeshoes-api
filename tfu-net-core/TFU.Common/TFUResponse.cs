﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace TFU.Common
{
	/// <summary>
	/// Json Response to Client
	/// </summary>
	public class TFUResponse : ActionResult
	{
		/// <summary>
		/// Gets or sets the status code.
		/// </summary>
		/// <value>
		/// The status code.
		/// </value>
		public HttpStatusCode StatusCode { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="TFUResponse"/> is success.
		/// </summary>
		/// <value>
		///   <c>true</c> if success; otherwise, <c>false</c>.
		/// </value>
		public bool Success { get; set; }

		/// <summary>
		/// Gets or sets the data.
		/// </summary>
		/// <value>
		/// The data.
		/// </value>
		public object Data { get; set; }

		/// <summary>
		/// Gets or sets the errors.
		/// </summary>
		/// <value>
		/// The errors.
		/// </value>
		/// <Date>12/6/2018</Date>
		public IEnumerable<KeyValuePair<string, string>> Errors { get; set; }

		/// <summary>
		/// Gets or sets the message.
		/// </summary>
		/// <value>
		/// The message.
		/// </value>
		public string Message { get; set; }
	}
}
