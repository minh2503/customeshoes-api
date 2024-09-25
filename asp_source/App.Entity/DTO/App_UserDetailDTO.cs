using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.DTO
{
    public class App_UserDetailDTO
    {
        public long Id { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public string? Address { get; set; }
        public bool? Gender { get; set; }
        public bool? IsActive { get; set; } = true;
        public long? UserId { get; set; }
    }

}
