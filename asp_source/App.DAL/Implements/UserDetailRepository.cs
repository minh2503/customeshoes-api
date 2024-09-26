using App.DAL.Interfaces;
using App.Entity;
using App.Entity.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common;
using TFU.Common.Extension;
using TFU.Common.Models;
using TFU.EntityFramework;

namespace App.DAL.Implements
{
    public class UserDetailsRepository : AppBaseRepository, IUserDetailsRepository
    {
        private readonly ApplicationDbContext _dbAppContext;

        public UserDetailsRepository(IConfiguration config, TFUDbContext dbTFUContext, ApplicationDbContext dbAppContext) : base(config, dbTFUContext, dbAppContext)
        {
            this._dbAppContext = dbAppContext;
        }

        public async Task<BaseRepsonse> CreateUpadteUserDetails(App_UserDetailDTO dto, long userId)
        {
            var any = await _dbAppContext.App_UserDetails.AnyAsync(x => x.UserId == userId);
            if (any)
            {
                var userDetail = await _dbAppContext.App_UserDetails.FirstOrDefaultAsync(x => x.UserId == userId);
                if (userId != userDetail.UserId) return new BaseRepsonse { IsSuccess = false, Message = Constants.UserNotSame };
                userDetail.DayOfBirth = dto.DayOfBirth;
                userDetail.Address = dto.Address;
                userDetail.Gender = dto.Gender;
                userDetail.IsActive = dto.IsActive;
                _dbAppContext.App_UserDetails.Update(userDetail);
            }
            else
            {
                var userDetail = new App_UserDetailDTO
                {
                    DayOfBirth = dto.DayOfBirth,
                    Address = dto.Address,
                    Gender = dto.Gender,
                    IsActive = dto.IsActive,
                    UserId = userId
                };
                await _dbAppContext.App_UserDetails.AddAsync(userDetail);
            }
            return await SaveAsync();
        }

		public async Task<BaseRepsonse> DeleteUserDetail(long userId)
		{
			var any = await _dbAppContext.App_UserDetails.AnyAsync(x => x.UserId == userId);
			if (any)
			{
				var userDetail = await _dbAppContext.App_UserDetails.FirstOrDefaultAsync(x => x.UserId == userId);
				if (userId != userDetail.UserId) return new BaseRepsonse { IsSuccess = false, Message = Constants.UserNotSame };
                userDetail.IsActive = false;
				_dbAppContext.App_UserDetails.Update(userDetail);
                return await SaveAsync();
			}
            return new BaseRepsonse {IsSuccess = false, Message = Constants.SaveDataFailed};
		}

		public async Task<List<App_UserDetailDTO>> GetAllUsersDetail(PagingModel paging)
        {
            return await _dbAppContext.App_UserDetails.ToPagedList(paging.PageNumber, paging.PageSize).AsNoTracking().ToListAsync();
        }

        public async Task<App_UserDetailDTO> GetUserDetail(long userId)
        {
            return await _dbAppContext.App_UserDetails.FirstOrDefaultAsync(x => x.UserId == userId);
        }


    }
}
