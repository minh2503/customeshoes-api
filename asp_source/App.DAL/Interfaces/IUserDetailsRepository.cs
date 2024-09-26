using App.Entity;
using App.Entity.DTO;
using App.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common.Models;

namespace App.DAL.Interfaces
{
    public interface IUserDetailsRepository
    {
        Task<BaseRepsonse> CreateUpadteUserDetails(App_UserDetailDTO dto, long userId);
        Task<App_UserDetailDTO> GetUserDetail(long userId);
        Task<List<App_UserDetailDTO>> GetAllUsersDetail(PagingModel paging);
        Task<BaseRepsonse> DeleteUserDetail(long userId);
    }
}
