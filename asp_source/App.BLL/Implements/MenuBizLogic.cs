using App.BLL.Interfaces;
using App.DAL.Interfaces;
using App.Entity.DTOs;
using App.Entity.Enums;
using App.Entity.Models;
using Microsoft.Extensions.Logging;
using TFU.Common.Models;
using TFU.DAL.Interfaces;

namespace App.BLL.Implements
{
	public class MenuBizLogic : IMenuBizLogic
	{
		private readonly IMenuRepository _menuRepository;
		private readonly IRoleClaimRepository _roleClaimRepository;
		private readonly IIdentityRepository _identityRepository;
		private readonly ILogger<MenuBizLogic> _logger;

		public MenuBizLogic(IMenuRepository menuRepository, IRoleClaimRepository roleClaimRepository, ILogger<MenuBizLogic> logger, IIdentityRepository identityRepository
			)
		{
			_menuRepository = menuRepository;
			_logger = logger;
			_roleClaimRepository = roleClaimRepository;
			_identityRepository = identityRepository;
		}
		/// <summary>
		/// lấy danh sách các action
		/// </summary>
		/// <param name="paging"></param>
		/// <returns></returns>
		public async Task<PagingDataModel<MenuModel>> GetPage(PagingModel paging)
		{
			try
			{
				List<MenuModel> models = null;
				var result = await _menuRepository.GetPage(paging);
				if (result != null && result.Count > 0)
					models = result.Select(x => new MenuModel(x)).ToList();
				var datas = new PagingDataModel<MenuModel>(models, paging);
				return datas;
			}
			catch (Exception ex)
			{
				_logger.LogInformation("--ERROR -GetPage menu Failed {0}", ex.Message);
				throw;
			}
		}
		/// <summary>
		/// lấy menu theo id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<MenuModel> GetById(int id)
		{
			try
			{
				MenuModel model = null;
				var result = await _menuRepository.GetById(id);
				if (result != null) model = new MenuModel(result);
				return model;
			}
			catch (Exception ex)
			{
				_logger.LogInformation("--ERROR -GetById menu Failed {0}", ex.Message);
				throw;
			}
		}
		/// <summary>
		/// lấy danh sách menu dạng combobox
		/// </summary>
		/// <param name="currentId"></param>
		/// <returns></returns>
		public async Task<List<Dropdown>> GetDropDown(int currentId = 0)
		{
			try
			{
				var result = await _menuRepository.GetDropDown(currentId);
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogInformation("--ERROR -GetDropDown menu Failed {0}", ex.Message);
				throw;
			}
		}
		/// <summary>
		/// thêm mới menu
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<SaveResultType> Insert(MenuModel model)
		{
			try
			{
				var dto = model.GetEntity();
				return await _menuRepository.Insert(dto);
			}
			catch (Exception ex)
			{
				_logger.LogInformation("--ERROR -Insert menu Failed {0}", ex.Message);
				throw;
			}
		}
		/// <summary>
		/// cập nhật menu
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<SaveResultType> Update(MenuModel model)
		{
			try
			{
				var dto = model.GetEntity();
				return await _menuRepository.Update(dto);
			}
			catch (Exception ex)
			{
				_logger.LogInformation("--ERROR -Update menu Failed {0}", ex.Message);
				throw;
			}
		}
		/// <summary>
		/// xóa menu
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<bool> Delete(int[] ids)
		{
			try
			{
				return await _menuRepository.Delete(ids);
			}
			catch (Exception ex)
			{
				_logger.LogInformation("--ERROR -Delete menu Failed {0}", ex.Message);
				throw;
			}
		}
		/// <summary>
		/// lấy toàn bộ menu kèm action
		/// </summary>
		/// <returns></returns>
		public async Task<List<MenuModel>> GetAllMenu()
		{
			try
			{
				List<MenuModel> models = null;
				var result = await _menuRepository.GetAllMenu(true);
				if (result.Count > 0)
					models = result.Where(x => x.Level != 2).Select(x => new MenuModel(x)).ToList();
				return models;
			}
			catch (Exception ex)
			{
				_logger.LogInformation("--ERROR -GetAllMenu menu Failed {0}", ex.Message);
				throw;
			}
		}
		/// <summary>
		/// get role menu by roleId
		/// </summary>
		/// <param name="roleId"></param>
		/// <returns></returns>
		public async Task<List<MenuModel>> GetRoleMenusByRole(long roleId)
		{
			List<MenuModel> models = null;
			var menus = await _menuRepository.GetAllMenu(false);
			if (menus != null && menus.Count > 0)
			{
				menus = menus.Where(x => x.Level != 2).ToList();
				var roleMenus = await _menuRepository.GetRoleMenusAysnc(roleId);
				models = menus.Select(x => new MenuModel(x)).ToList();
				if (roleMenus != null && roleMenus.Length > 0)
				{
					var menuChecked = models.Where(x => roleMenus.Contains(x.FunctionCode)).ToList();
					if (menuChecked.Count > 0)
					{
						foreach (var menu in menuChecked)
							menu.Checked = true;
					}
				}
			}
			return models;
		}
		/// <summary>
		/// save role menus
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public async Task<bool> SaveRoleMenusSync(RoleMenuModel model)
		{
			var dtos = new List<RoleMenuDTO>
			{
				model.GetEntity()
			};
			if (model.MenuCodes != null && model.MenuCodes.Length > 0)
			{
				dtos = model.MenuCodes.Select(x => new RoleMenuModel().GetEntity(model.RoleId, x)).ToList();
			}
			var result = await _menuRepository.SaveRoleMenusSync(dtos, model.RoleId);
			return result;
		}

		/// <summary>
		/// kiểm tra quyefn truy cập menu
		/// </summary>
		/// <param name="menuPath"></param>
		/// <returns></returns>
		public async Task<bool> CheckRoleAccessMenu(string menuPath, long userId)
		{
			var user = await _identityRepository.GetByIdAsync(userId);
			if (user == null)
				return false;
			if (menuPath.Contains("manage-profile")) return true;
			return await _menuRepository.CheckRoleAccessMenu(menuPath, userId);
		}

		public async Task<List<MenuModel>> GetMenuByRole(long userId)
		{
			var user = await _identityRepository.GetByIdAsync(userId);
			if (user == null)
				return null;

			var dtos = await _menuRepository.GetMenuByRole(userId);
			if (dtos == null) return null;
			var menus = dtos.Select(x => new MenuModel(x)).ToList();
			return menus;
		}

		public async Task<List<Dropdown>> GetDropdownActions()
		{
			return await _menuRepository.GetDropDownActions();
		}
	}
}
