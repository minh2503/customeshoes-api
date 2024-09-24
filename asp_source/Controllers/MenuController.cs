using App.API.Filters;
using App.BLL.Interfaces;
using App.DAL;
using App.Entity.Enums;
using App.Entity.Models;
using App.Utility;
using Microsoft.AspNetCore.Mvc;
using TFU.APIBased;
using TFU.Common;
using TFU.Common.Models;

namespace tapluyen.api.Controllers
{
    /// <summary>
    /// quản lý menu
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : BaseAPIController
    {
        private readonly ILogger<MenuController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMenuBizLogic _menuBizLogic;
        public MenuController(IConfiguration configuration, ILogger<MenuController> logger, ApplicationDbContext dbContext, IMenuBizLogic menuBizLogic)
        {
            _configuration = configuration;
            _logger = logger;
            _menuBizLogic = menuBizLogic;
        }

        [Route("get-page")]
        [HttpPost]
        [TFUAuthorize(SystemMenus.c_ManageMenus, SystemActions.c_Read)]
        public async Task<IActionResult> GetPage(PagingModel paging)
        {
            try
            {
                var result = await _menuBizLogic.GetPage(paging);
                return GetSuccess(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetPage menu failed - {0}", ex.Message);
                return GetError();
            }
        }

        /// <summary>
        /// lấy menu theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("get-by-id/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _menuBizLogic.GetById(id);
                return GetSuccess(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetById menu failed - {0}", ex.Message);
                return GetError();
            }
        }

        /// <summary>
        /// lấy danh sách menu dạng combobox
        /// </summary>
        /// <param name="currentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get-dropdown/{currentId}")]
        public async Task<IActionResult> GetDropDown(int currentId = 0)
        {
            try
            {
                var result = await _menuBizLogic.GetDropDown(currentId);
                return GetSuccess(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetDropDown menu failed - {0}", ex.Message);
                return GetError();
            }
        }

        /// <summary>
        /// lưu menu
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("save")]
        public async Task<IActionResult> Save(MenuModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = SaveResultType.Successfully;
                    if (model.Id == 0)
                        result = await _menuBizLogic.Insert(model);
                    else
                        result = await _menuBizLogic.Update(model);
                    switch (result)
                    {
                        case SaveResultType.Failed:
                            return SaveError(new { message = Constants.SaveDataFailed });
                        case SaveResultType.DuplicateCode:
                            ModelState.AddModelError("FunctionCode", "Mã đã tồn tại");
                            break;
                        case SaveResultType.DuplicateName:
                            ModelState.AddModelError("Name", "Tên đã tồn tại");
                            break;
                        default:
                            return SaveSuccess(result);
                    }
                }
                return ModelInvalid();
            }
            catch (Exception ex)
            {
                _logger.LogError("Save menu failed - {0}", ex.Message);
                return SaveError();
            }
        }

        /// <summary>
        /// set menu cho role
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("save-role-menus")]
        public async Task<IActionResult> SaveRoleMenus(RoleMenuModel model)
        {
            try
            {
                var result = await _menuBizLogic.SaveRoleMenusSync(model);
                return SaveSuccess(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("SaveRoleMenus menu failed - {0}", ex.Message);
                return SaveError();
            }
        }


        /// <summary>
        /// xóa menu
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        public async Task<ActionResult> Delete([FromBody] int[] ids)
        {
            try
            {
                if (ids != null && ids.Length > 0)
                {
                    var result = await _menuBizLogic.Delete(ids);
                    return SaveSuccess(result);
                }
                return SaveError();
            }
            catch (Exception ex)
            {
                _logger.LogError("Delete menu failed - {0}", ex.Message);
                return SaveError();
            }
        }

        [HttpGet("get-menus")]
        [TFUAuthorize]
        public async Task<ActionResult> GetMenuByUser()
        {
            try
            {
                var res = await _menuBizLogic.GetMenuByRole(UserId);
                return GetSuccess(res);
            }
            catch (Exception ex)
            {
                _logger.LogError("Get Menus failed - {0}", ex.Message);
                return GetError();
            }
        }

        [HttpGet("get-all-menus")]
        //[TFUAuthorize]
        public async Task<ActionResult> GetAllMenus()
        {
            try
            {

                var res = await _menuBizLogic.GetAllMenu();
                return GetSuccess(res);
            }
            catch (Exception ex)
            {
                _logger.LogError("Get Menus failed - {0}", ex.Message);
                return GetError();
            }
        }

        /// <summary>
        /// Get actions
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-dropdown-actions")]
        public async Task<IActionResult> GetDropdownActions()
        {
            try
            {
                List<Dropdown> res = await _menuBizLogic.GetDropdownActions();
                return GetSuccess(res);
            }
            catch (Exception ex)
            {
                _logger.LogError("Delete menu failed - {0}", ex.Message);
                return GetError();
            }
        }
    }
}
