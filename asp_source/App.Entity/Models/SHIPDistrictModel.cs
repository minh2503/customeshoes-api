using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common;

namespace App.Entity.Models
{
    public class SHIPDistrictModel : IEntity<SHIPDistrictDTO>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int VNPOSTDistrictId { get; set; }
        public string ProvinceId { get; set; }

        public SHIPDistrictModel() { }

        public SHIPDistrictModel(SHIPDistrictDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            VNPOSTDistrictId = dto.VNPOSTDistrictId;
            ProvinceId = dto.ProvinceId;
        }

        public SHIPDistrictDTO GetEntity()
        {
            return new SHIPDistrictDTO
            {
                Id = Id,
                Name = Name,
                VNPOSTDistrictId = VNPOSTDistrictId,
                ProvinceId = ProvinceId
            };
        }
    }
}
