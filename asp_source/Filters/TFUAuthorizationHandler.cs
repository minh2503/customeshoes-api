using App.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Net;
using System.Security.Claims;
using TFU.BLL.Interfaces;

namespace App.API.Filters
{
	public class TFURolesHandler : AuthorizationHandler<RolesAuthorizationRequirement>
	{
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
		{
			var filterContext = (DefaultHttpContext)context.Resource;
			var httpcontext = filterContext.HttpContext;
			var _identityBizLogic = httpcontext.RequestServices.GetRequiredService<IIdentityBizLogic>();
			long.TryParse(context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out long userId);
			var allowRoles = string.Join(",", requirement.AllowedRoles);
			bool isInrole = _identityBizLogic.IsUserInRoles(userId, allowRoles).Result;
			if (isInrole)
			{
				context.Succeed(requirement);
			}
			else
			{
				context.Fail();
			}
			return Task.CompletedTask;
		}
	}

	public class TFUPermissionHandler : AuthorizationHandler<TFUActionRequirement>
	{
		public TFUPermissionHandler()
		{
		}
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TFUActionRequirement requirement)
		{
			var filterContext = ((DefaultHttpContext)context.Resource);
			var httpcontext = filterContext.HttpContext;
			if (!IsAllowAccess(requirement.FunctionCode, requirement.ActionCode, httpcontext))
			{
				context.Fail();
			}
			else
			{
				context.Succeed(requirement);
			}
			return Task.CompletedTask;
		}

		private bool IsAllowAccess(string function, string action, HttpContext context)
		{
			var _identityBizLogic = context.RequestServices.GetRequiredService<IIdentityBizLogic>();
			var id = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			long userId;
			if (long.TryParse(id, out userId) && _identityBizLogic.IsUserInRoles(userId, SystemRoleConstants.ADMIN).Result)
			{
				return true;
			}
			if (userId > 0)
			{
				return _identityBizLogic.VerifyPermission(userId, function, action).Result;
			}
			return false;
		}
	}

	public class TFUEmailConfirmHandler : AuthorizationHandler<TFUEmailConfirmRequirement>
	{
		public TFUEmailConfirmHandler()
		{
		}

		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TFUEmailConfirmRequirement requirement)
		{
			var filterContext = ((DefaultHttpContext)context.Resource);
			var httpcontext = filterContext.HttpContext;
			var _identityBizLogic = httpcontext.RequestServices.GetRequiredService<IIdentityBizLogic>();
			if (!IsEmailConfirm(httpcontext, _identityBizLogic))
			{
				filterContext.Response.StatusCode = (int)HttpStatusCode.Redirect;
			}
			context.Succeed(requirement);
			return Task.CompletedTask;
		}

		private bool IsEmailConfirm(HttpContext context, IIdentityBizLogic identityBizLogic)
		{
			var id = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			long.TryParse(id, out long userId);
			var user = identityBizLogic.GetByIdAsync(userId).Result;
			if (user != null && user.EmailConfirmed)
				return true;
			return false;
		}
	}
}
