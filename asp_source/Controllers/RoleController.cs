using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFU.APIBased;
using TFU.BLL.Interfaces;
using TFU.Common;
using TFU.Models.IdentityModels;

namespace tapluyen.api.Controllers
{
    /// <summary>
    /// quản lý role
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : BaseAPIController
    {
        private readonly ILogger<RoleController> _logger;
        private readonly RoleManager<RoleDTO> _roleManager;
        private readonly IIdentityBizLogic _identityBizLogic;
        public RoleController(RoleManager<RoleDTO> roleManager, ILogger<RoleController> logger, IIdentityBizLogic identityBizLogic)
        {
            this._roleManager = roleManager;
            this._logger = logger;
            this._identityBizLogic = identityBizLogic;
        }

        /// <summary>
        /// create - update role
        /// update theo isAdmin
        /// </summary>
        /// <param name="roleName"></param>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        [HttpPost("create-update-role")]
        public async Task<ActionResult> CreateRole(string roleName, bool isAdmin)
        {
            try
            {
                var result = await _identityBizLogic.CreateUpdateRoleAsync(roleName, isAdmin);
                if (result) return SaveSuccess(result);
                return SaveError(Constants.SomeThingWentWrong);
            }
            catch (Exception ex)
            {
                _logger.LogError("CreateRole failed - {0}", ex.Message);
                return SaveError();
            }
        }

        [HttpGet("get-all-role")]
        public async Task<ActionResult> GetRoles()
        {
            try
            {
                var roles = await _roleManager.Roles.ToListAsync();
                return GetSuccess(roles);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetRoles failed - {0}", ex.Message);
                return GetError();
            }
        }

        [HttpPost("set-role")]
        public async Task<ActionResult> SetRoleByUserId(string userId, string role)
        {
            try
            {
                var result = await _identityBizLogic.AddRoleByNameAsync(userId, role);
                if (result)
                {
                    return SaveSuccess(result);
                }
                return SaveError(Constants.SomeThingWentWrong);
            }
            catch (Exception ex)
            {
                _logger.LogError("SetRole failed - {0}", ex.Message);
                return GetError();
            }
        }
    }

}
