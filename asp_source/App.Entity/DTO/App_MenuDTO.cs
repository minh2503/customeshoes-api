using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entity.DTO
{
    public class App_MenuDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NavigateLink { get; set; }
        public int RoleId { get; set; }
    }
}
