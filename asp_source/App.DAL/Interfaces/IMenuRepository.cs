using App.Entity.DTO;
using App.Entity.DTOs;
using App.Entity.Enums;
using TFU.Common.Models;

namespace App.DAL.Interfaces
{
    public interface IMenuRepository
    {
        Task<bool> CheckRoleAccessMenu(string menuPath, long userId);
        Task<bool> Delete(int[] ids);
        Task<List<SYS_MenuDTO>> GetAllMenu(bool includeActions);
        Task<SYS_MenuDTO> GetByCode(string code);
        Task<SYS_MenuDTO> GetById(int id);
        Task<List<Dropdown>> GetDropDown(int currentId = 0);
        Task<List<Dropdown>> GetDropDownActions();
        Task<List<SYS_MenuDTO>> GetMenuByRole(long userId);
        Task<List<SYS_MenuDTO>> GetMenuParent();
        Task<List<SYS_MenuDTO>> GetPage(PagingModel paging);
        Task<string[]> GetRoleMenusAysnc(long roleId);
        Task<SaveResultType> Insert(SYS_MenuDTO dto);
        Task<bool> SaveRoleMenusSync(List<RoleMenuDTO> dtos, long roleId);
        Task<SaveResultType> Update(SYS_MenuDTO dto);
    }
}