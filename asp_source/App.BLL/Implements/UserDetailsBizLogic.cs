using App.BLL.Interfaces;
using App.DAL.Interfaces;
using App.Entity;
using App.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common.Models;

namespace App.BLL.Implements
{
    public class UserDetailsBizLogic : IUserDetailsBizLogic
    {
        private readonly IUserDetailsRepository _userDetailsRepository;
        public UserDetailsBizLogic(IUserDetailsRepository userDetailsRepository)
        {
            this._userDetailsRepository = userDetailsRepository;
        }
        public async Task<UserDetailModel> GetUserDetail(long userId)
        {
            var data = await _userDetailsRepository.GetUserDetail(userId);
            return new UserDetailModel(data);
        }

        public async Task<BaseRepsonse> CreateUpadteUserDetails(UserDetailModel model, long userId)
        {
            var dto = model.GetEntity();
            return await _userDetailsRepository.CreateUpadteUserDetails(dto, userId);
        }

        public async Task<List<UserDetailModel>> GetListUserDetail(PagingModel paging)
        {
            var data = await _userDetailsRepository.GetAllUsersDetail(paging);
            return data.Select(x => new UserDetailModel(x)).ToList();
        }

		public async Task<BaseRepsonse> DeleteUserDetailAsync(long userId)
		{
			var response = await _userDetailsRepository.DeleteUserDetail(userId);
            return response;
		}
	}
}
