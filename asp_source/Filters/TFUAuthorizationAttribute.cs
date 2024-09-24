using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace App.API.Filters
{
	public class TFUAuthorizeAttribute : AuthorizeAttribute
	{
		public TFUAuthorizeAttribute(string function, string action) : this($"{function}.{action}")
		{
		}
		public TFUAuthorizeAttribute(string permission) : this()
		{
			Policy = permission;
		}
		public TFUAuthorizeAttribute() : base()
		{
		}
	}
}
