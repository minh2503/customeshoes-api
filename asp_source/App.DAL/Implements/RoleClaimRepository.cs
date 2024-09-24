using App.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TFU.EntityFramework;
using TFU.Models.IdentityModels;

namespace App.DAL.Implements
{
	public class RoleClaimRepository : AppBaseRepository, IRoleClaimRepository
	{
		private readonly ILogger<RoleClaimRepository> _logger;
		private readonly RoleManager<RoleDTO> _roleManager;
		private readonly UserManager<UserDTO> _userManager;
		public RoleClaimRepository(ILogger<RoleClaimRepository> logger, TFUDbContext dbTFUContext, ApplicationDbContext dbAppContext, IConfiguration configuration, RoleManager<RoleDTO> roleManager)
		  : base(configuration, dbTFUContext, dbAppContext)
		{
			_logger = logger;
			_dbAppContext = dbAppContext;
			_dbContext = dbTFUContext;
			_roleManager = roleManager;
		}

		public async Task<List<RoleClaimDTO>> GetRoleClaimByUserId(long userId)
		{
			var userRoles = await _dbContext.UserRoles.Where(a => a.UserId == userId).ToListAsync();
			if (userRoles != null && userRoles.Count > 0)
			{
				var roleIds = userRoles.Select(x => x.RoleId).ToList();
				return await _dbContext.RoleClaims.Where(x => roleIds.Contains(x.RoleId)).ToListAsync();
			}
			return null;
		}

		public async Task<string[]> GetClaimsByUserId(long userId)
		{
			var claims = await GetRoleClaimByUserId(userId);
			if (claims == null)
				return null;
			return claims.Select(m => m.ClaimValue).Distinct().ToArray();
		}
	}
}
