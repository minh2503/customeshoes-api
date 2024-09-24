using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common;

namespace App.Entity.Models
{
    public class SHIPWardModel : IEntity<SHIPWardDTO>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int VNPOSTWardId { get; set; }
        public string DistrictId { get; set; }

        public SHIPWardModel() { }

        public SHIPWardModel(SHIPWardDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            VNPOSTWardId = dto.VNPOSTWardId;
            DistrictId = dto.DistrictId;
        }

        public SHIPWardDTO GetEntity()
        {
            return new SHIPWardDTO
            {
                Id = Id,
                Name = Name,
                VNPOSTWardId = VNPOSTWardId,
                DistrictId = DistrictId
            };
        }
    }
}
