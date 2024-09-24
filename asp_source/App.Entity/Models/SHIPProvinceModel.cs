using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common;

namespace App.Entity.Models
{
    public class SHIPProvinceModel : IEntity<SHIPProvinceDTO>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int VNPOSTProvinceId { get; set; }

        public SHIPProvinceModel() { }

        public SHIPProvinceModel(SHIPProvinceDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            VNPOSTProvinceId = dto.VNPOSTProvinceId;
        }

        public SHIPProvinceDTO GetEntity()
        {
            return new SHIPProvinceDTO
            {
                Id = Id,
                Name = Name,
                VNPOSTProvinceId = VNPOSTProvinceId
            };
        }
    }
}
