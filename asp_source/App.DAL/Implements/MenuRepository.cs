using App.DAL.Interfaces;
using App.Entity.DTO;
using App.Entity.DTOs;
using App.Entity.Enums;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data;
using TFU.Common.Extension;
using TFU.Common.Models;
using TFU.EntityFramework;

namespace App.DAL.Implements
{
	public class MenuRepository : AppBaseRepository, IMenuRepository
	{
		private readonly ILogger<MenuRepository> _logger;
		public MenuRepository(ILogger<MenuRepository> logger, TFUDbContext dbTFUContext, ApplicationDbContext dbAppContext, IConfiguration configuration)
			: base(configuration, dbTFUContext, dbAppContext)
		{
			_logger = logger;
			_dbAppContext = dbAppContext;
			_dbContext = dbTFUContext;
		}
		/// <summary>
		/// lấy danh sách các menu
		/// </summary>
		/// <param name="paging"></param>
		/// <returns></returns>
		public async Task<List<SYS_MenuDTO>> GetPage(PagingModel paging)
		{
			try
			{
				List<SYS_MenuDTO> actions = null;
				var filteredData = _dbAppContext.SYS_Menus.Where(x => !x.IsDelete).AsQueryable();
				if (!string.IsNullOrEmpty(paging.Keyword))
					filteredData = filteredData.Where(x => x.Name.Contains(paging.Keyword, StringComparison.OrdinalIgnoreCase)
					|| (!string.IsNullOrEmpty(x.FunctionCode) && x.FunctionCode.Contains(paging.Keyword, StringComparison.OrdinalIgnoreCase))
					|| (!string.IsNullOrEmpty(x.NavigateLink) && x.NavigateLink.Contains(paging.Keyword, StringComparison.OrdinalIgnoreCase))).AsQueryable();
				paging.TotalRecord = await filteredData.AsNoTracking().CountAsync();
				if (paging.TotalRecord > 0)
					actions = filteredData.ToPagedList(paging.PageNumber, paging.PageSize).ToList();
				return actions;
			}
			catch (Exception ex)
			{
				_logger.LogInformation("--ERROR -GetPage menu Failed {0} \n {1}", JsonConvert.SerializeObject(paging), ex.Message);
				throw;
			}
		}

		/// <summary>
		/// lấy menu theo id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<SYS_MenuDTO> GetById(int id)
		{
			try
			{
				var menu = await _dbAppContext.SYS_Menus.FindAsync(id);
				SYS_MenuDTO dto = null;
				if (menu != null)
				{
					dto = await _dbAppContext.SYS_Menus.FindAsync(id);
					string[] actionCodes = await _dbAppContext.SYS_MappingMenuActions.Where(m => m.MenuCode == menu.FunctionCode).Select(m => m.ActionCode).ToArrayAsync();

					var actions = await _dbAppContext.SYS_Actions.Where(m => actionCodes.Contains(m.ActionCode)).ToListAsync();
					dto.Actions = actions;
				}
				return dto;
			}
			catch (Exception ex)
			{
				_logger.LogInformation("--ERROR -GetById menu Failed id: {0} \n {1}", id, ex.Message);
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
				var dto = new List<Dropdown>();
				var menus = await _dbAppContext.SYS_Menus.Where(x => x.Id != currentId && !x.IsDelete).AsNoTracking().ToListAsync();
				if (menus.Count > 0)
				{
					//cấp 1
					foreach (var parent in menus.Where(x => x.ParentId == 0).ToList())
					{
						dto.Add(new Dropdown { Value = parent.Id.ToString(), Text = parent.Name });
						var child = menus.Where(x => x.ParentId == parent.Id).ToList();
						if (child.Count > 0)
						{
							//cấp 2
							foreach (var child1 in child)
							{
								child1.Name = string.Format("__{0}", child1.Name);
								dto.Add(new Dropdown { Value = child1.Id.ToString(), Text = child1.Name });
								var child2 = menus.Where(x => x.ParentId == child1.Id).ToList();
								if (child2.Count > 0)
								{
									// cấp 3
									foreach (var child3 in child2)
									{
										child3.Name = string.Format("____{0}", child3.Name);
										dto.Add(new Dropdown { Value = child3.Id.ToString(), Text = child3.Name });
									}
								}
							}
						}
					}
				}
				return dto;
			}
			catch (Exception ex)
			{
				_logger.LogInformation("--ERROR -GetDropDown menu Failed id: {0} \n {1}", currentId, ex.Message);
				throw;
			}
		}

		/// <summary>
		/// thêm mới menu
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		public async Task<SaveResultType> Insert(SYS_MenuDTO dto)
		{
			try
			{
				var check = CheckDuplicate(dto);
				if (check == SaveResultType.Successfully)
				{
					int res = 0;
					using (var tran = _dbAppContext.Database.BeginTransaction())
					{
						_dbAppContext.SYS_Menus.Add(dto);
						res = await _dbAppContext.SaveChangesAsync();
						//insert mapping menu-action
						if (dto.Actions != null && dto.Actions.Count > 0)
						{
							var mapping = new List<SYS_MappingMenuActionDTO>();
							foreach (var action in dto.Actions)
							{
								var actionDb = await _dbAppContext.SYS_Actions.FindAsync(action.Id);
								if (actionDb != null)
									mapping.Add(new SYS_MappingMenuActionDTO
									{
										MenuCode = dto.FunctionCode,
										ActionCode = actionDb.ActionCode
									});
							}
							_dbAppContext.SYS_MappingMenuActions.AddRange(mapping);
							res = await _dbAppContext.SaveChangesAsync();
						}
						tran.Commit();
				}
					return res > 0 ? SaveResultType.Successfully : SaveResultType.Failed;
				}
				return check;
			}
			catch (Exception ex)
			{
				_logger.LogInformation("--ERROR -Insert menu Failed {0} \n {1}", JsonConvert.SerializeObject(dto), ex.Message);
				throw;
			}
		}

		/// <summary>
		/// cập nhật menu
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		public async Task<SaveResultType> Update(SYS_MenuDTO dto)
		{
			try
			{
				var check = CheckDuplicate(dto);
				if (check == SaveResultType.Successfully)
				{
					int res = 0;
					using (var tran = _dbAppContext.Database.BeginTransaction())
					{
						_dbAppContext.SYS_Menus.Update(dto);
						//delete mapping menu-action old
						var mappingOlds = _dbAppContext.SYS_MappingMenuActions.Where(x => x.MenuCode == dto.FunctionCode);
						if (mappingOlds.Any()) _dbAppContext.SYS_MappingMenuActions.RemoveRange(mappingOlds);

						//insert mapping menu-action
						if (dto.Actions != null && dto.Actions.Count > 0)
						{
							foreach (var action in dto.Actions)
							{
								var actionDb = await _dbAppContext.SYS_Actions.FindAsync(action.Id);
								if (actionDb != null) _dbAppContext.SYS_MappingMenuActions.Add(new SYS_MappingMenuActionDTO
								{
									MenuCode = dto.FunctionCode,
									ActionCode = actionDb.ActionCode
								});
							}
						}
						res = await _dbAppContext.SaveChangesAsync();
						tran.Commit();
					}
					return res > 0 ? SaveResultType.Successfully : SaveResultType.Failed;
				}
				return check;
			}
			catch (Exception ex)
			{
				_logger.LogInformation("--ERROR -Update menu Failed {0} \n {1}", JsonConvert.SerializeObject(dto), ex.Message);
				throw;
			}
		}
		/// <summary>
		/// check trùng mã
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		private SaveResultType CheckDuplicate(SYS_MenuDTO dto)
		{
			try
			{
				var dataFilter = _dbAppContext.SYS_Menus.Where(x => !x.IsDelete).AsEnumerable();
				if (!string.IsNullOrEmpty(dto.FunctionCode))
				{
					dataFilter = dataFilter.Where(x => !x.FunctionCode.Equals("#") && x.FunctionCode.Equals(dto.FunctionCode, StringComparison.OrdinalIgnoreCase) && x.Id != dto.Id).AsQueryable();
					if (dataFilter.Count() > 0) return SaveResultType.DuplicateCode;
				}
				if (!string.IsNullOrEmpty(dto.Name))
				{
					dataFilter = dataFilter.Where(x => x.Name.Equals(dto.Name, StringComparison.OrdinalIgnoreCase) && x.Id != dto.Id).AsQueryable();
					if (dataFilter.Count() > 0) return SaveResultType.DuplicateName;
				}
				return SaveResultType.Successfully;
			}
			catch (Exception ex)
			{
				_logger.LogInformation("--ERROR -CheckDuplicate Action Failed {0} \n {1}", JsonConvert.SerializeObject(dto), ex.Message);
				return SaveResultType.Successfully;
			}
		}
		/// <summary>
		/// xóa menu (xóa cả cha lẫn con)
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		public async Task<bool> Delete(int[] ids)
		{
			try
			{
				int res = 0;
				using (var tran = _dbAppContext.Database.BeginTransaction())
				{
					var allIds = new List<string>();
					var menus = await _dbAppContext.SYS_Menus.Where(x => ids.Contains(x.Id)).AsNoTracking().ToListAsync();
					foreach (var menu in menus)
					{
						allIds.Add(menu.FunctionCode);
						var child = await _dbAppContext.SYS_Menus.Where(x => x.ParentId == menu.Id).AsNoTracking().ToListAsync();
						if (child.Count > 0)
						{
							foreach (var ch in child)
							{
								allIds.Add(ch.FunctionCode);
								var child1 = await _dbAppContext.SYS_Menus.Where(x => x.ParentId == ch.Id).AsNoTracking().ToListAsync();
								if (child1.Count > 0)
								{
									foreach (var c in child1)
									{
										allIds.Add(c.FunctionCode);
									}
								}
							}
						}
					}
					if (allIds.Count > 0)
					{
						var menusDelete = await _dbAppContext.SYS_Menus.Where(x => allIds.Contains(x.FunctionCode)).AsNoTracking().ToListAsync();
						if (menusDelete.Count > 0)
						{
							_dbAppContext.SYS_Menus.RemoveRange(menusDelete);
							//xóa mapping menu-action
							var mapping = _dbAppContext.SYS_MappingMenuActions.Where(x => allIds.Contains(x.MenuCode));
							_dbAppContext.SYS_MappingMenuActions.RemoveRange(mapping);

							res = await _dbAppContext.SaveChangesAsync();
						}
					}
					tran.Commit();
				}
				return res > 0;
			}
			catch (Exception ex)
			{
				_logger.LogInformation("--ERROR -Delete Action Failed {0} \n {1}", ids, ex.Message);
				throw;
			}
		}
		/// <summary>
		/// lấy toàn bộ menu kèm action
		/// </summary>
		/// <returns></returns>
		public async Task<List<SYS_MenuDTO>> GetAllMenu(bool includeActions)
		{

			var datas = await _dbAppContext.SYS_Menus.Where(m => !m.IsDelete).OrderBy(x => x.Index).ToListAsync();
			if (datas.Count > 0 && includeActions)
			{
				foreach (var data in datas)
				{
					var actions = from mapping in _dbAppContext.SYS_MappingMenuActions
									  join action in _dbAppContext.SYS_Actions on mapping.ActionCode equals action.ActionCode
									  where mapping.MenuCode == data.FunctionCode && !action.IsDelete
									  select new SYS_ActionDTO
									  {
										  Id = action.Id,
										  Name = action.Name,
										  ActionCode = action.ActionCode,
									  };
					if (actions.AsNoTracking().Count() > 0)
					{
						data.Actions = await actions.AsNoTracking().ToListAsync();
					}
				}
			}
			return datas;
		}

		public async Task<List<SYS_MenuDTO>> GetMenuParent()
		{
			try
			{
				var menus = await _dbAppContext.SYS_Menus.Where(x => !x.IsDelete && x.ParentId == 0).Select(x => new SYS_MenuDTO
				{
					Id = x.Id,
					Name = x.Name,
					FunctionCode = x.FunctionCode,
					NavigateLink = x.NavigateLink,
					ParentId = x.ParentId,
					Icon = x.Icon
				}).ToListAsync();
				return menus;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		/// <summary>
		/// get role menu by roleId
		/// </summary>
		/// <param name="roleId"></param>
		/// <returns></returns>
		public async Task<string[]> GetRoleMenusAysnc(long roleId)
		{
			var datas = await _dbAppContext.RoleMenus.Where(x => x.RoleId == roleId).ToListAsync();
			if (datas.Count > 0)
				return datas.Select(x => x.MenuCode).ToArray();
			return null;
		}
		/// <summary>
		/// save role menus
		/// </summary>
		/// <param name="dtos"></param>
		/// <returns></returns>
		public async Task<bool> SaveRoleMenusSync(List<RoleMenuDTO> dtos, long roleId)
		{
			var oldRoles = _dbAppContext.RoleMenus.Where(x => x.RoleId == roleId);
			_dbAppContext.RoleMenus.RemoveRange(oldRoles);
			await _dbAppContext.SaveChangesAsync();
			var temp = dtos.Where(x => !string.IsNullOrEmpty(x.MenuCode)).GroupBy(x => x.MenuCode).Select(x => x.FirstOrDefault()).ToList();
			if (temp.Count > 0)
			{
				await _dbAppContext.AddRangeAsync(temp);
				return await _dbAppContext.SaveChangesAsync() > 0;
			}
			return false;

		}
		/// <summary>
		/// kiểm tra quyefn truy cập menu
		/// </summary>
		/// <param name="menuPath"></param>
		/// <returns></returns>
		public async Task<bool> CheckRoleAccessMenu(string menuPath, long userId)
		{
			var userRoles = await _dbContext.UserRoles.Where(x => x.UserId == userId).ToListAsync();
			if (userRoles.Count == 0) return false;
			var menu = await _dbAppContext.SYS_Menus.FirstOrDefaultAsync(x => !string.IsNullOrWhiteSpace(x.NavigateLink) && x.NavigateLink.Equals(menuPath, StringComparison.OrdinalIgnoreCase));
			if (menu == null) return false;
			var functionCode = menu.FunctionCode;
			if (menu.Level == 2)
			{
				var menuParent = await _dbAppContext.SYS_Menus.FindAsync(menu.ParentId);
				if (menuParent != null) functionCode = menuParent.FunctionCode;
			}
			var roleIds = userRoles.Select(m => m.RoleId).ToList();
			var roleMenu = await _dbAppContext.RoleMenus.FirstOrDefaultAsync(x => x.MenuCode.Equals(functionCode, StringComparison.OrdinalIgnoreCase) && roleIds.Contains(x.RoleId));
			if (roleMenu == null) return false;
			return true;
		}

		public async Task<List<SYS_MenuDTO>> GetMenuByRole(long userId)
		{
			List<SYS_MenuDTO> datas = null;
			var param = new DynamicParameters();
			param.Add("@UserId", userId, DbType.Int64, ParameterDirection.Input);
			var result = await Connection.QueryAsync<SYS_MenuDTO>("SYS_Menu_Get_ByUserId", param, commandType: CommandType.StoredProcedure);
			if (result != null) datas = result.ToList();
			return datas;
		}

		public async Task<List<Dropdown>> GetDropDownActions()
		{
			try
			{
				var actions = await _dbAppContext.SYS_Actions.Where(x => !x.IsDelete).AsNoTracking().Select(x => new Dropdown
				{
					Value = x.Id.ToString(),
					Text = x.Name,
				}).ToListAsync();
				return actions;
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		public async Task<SYS_MenuDTO> GetByCode(string code)
		{
			try
			{
				return await _dbAppContext.SYS_Menus.FirstOrDefaultAsync(m => m.FunctionCode == code);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
