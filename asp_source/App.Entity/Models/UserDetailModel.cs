using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common;

namespace App.Entity.Models
{
    public class UserDetailModel : IEntity<App_UserDetailDTO>
    {
        public long Id { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public string? Address { get; set; }
        public bool? Gender { get; set; }
        public bool? IsActive { get; set; } = true;
        public long? UserId { get; set; }
        public UserDetailModel()
        {
        }

        public UserDetailModel(App_UserDetailDTO dto)
        {
            Id = dto.Id;
            DayOfBirth = dto.DayOfBirth;
            Address = dto.Address;
            Gender = dto.Gender;
            IsActive = dto.IsActive;
            UserId = dto.UserId;
        }

        public App_UserDetailDTO GetEntity()
        {
            return new App_UserDetailDTO
            {
                Id = Id,
                DayOfBirth = DayOfBirth,
                Address = Address,
                Gender = Gender,
                IsActive = IsActive,
                UserId = UserId
            };
        }
    }
    public class CreateUserDetailModel
    {
        public long Id { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public string? Address { get; set; }
        public bool? Gender { get; set; }
        public bool? IsActive { get; set; }
    }
}
