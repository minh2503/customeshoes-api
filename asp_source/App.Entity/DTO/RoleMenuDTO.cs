using System.ComponentModel.DataAnnotations;

namespace App.Entity.DTOs
{
    public class RoleMenuDTO
    {
        [Key]
        public long RoleId { get; set; }
        [Key]
        public string MenuCode { get; set; }

        public RoleMenuDTO() { }

        public RoleMenuDTO(Menu menu, long roleId)
        {
            MenuCode = menu.Code;
            RoleId = roleId;
        }
    }
}
