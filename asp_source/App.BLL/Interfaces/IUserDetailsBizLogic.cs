using App.Entity;
using App.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common.Models;

namespace App.BLL.Interfaces
{
    public interface IUserDetailsBizLogic
    {
        Task<BaseRepsonse> CreateUpadteUserDetails(UserDetailModel dto, long userId);
        Task<UserDetailModel> GetUserDetail(long userId);
        Task<List<UserDetailModel>> GetListUserDetail(PagingModel paging);
        Task<BaseRepsonse> DeleteUserDetailAsync(long userId);
    }
}
