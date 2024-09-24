using App.Entity.Enums;
using App.Entity.Models;
using TFU.Common.Models;

namespace App.BLL.Interfaces
{
    public interface IMenuBizLogic
    {
        Task<bool> CheckRoleAccessMenu(string menuPath, long userId);
        Task<bool> Delete(int[] ids);
        Task<List<MenuModel>> GetAllMenu();
        Task<MenuModel> GetById(int id);
        Task<List<Dropdown>> GetDropDown(int currentId = 0);
        Task<List<Dropdown>> GetDropdownActions();
        Task<List<MenuModel>> GetMenuByRole(long userId);
        Task<PagingDataModel<MenuModel>> GetPage(PagingModel paging);
        Task<List<MenuModel>> GetRoleMenusByRole(long roleId);
        Task<SaveResultType> Insert(MenuModel model);
        Task<bool> SaveRoleMenusSync(RoleMenuModel model);
        Task<SaveResultType> Update(MenuModel model);
    }
}