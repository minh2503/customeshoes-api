using App.Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Interfaces
{
    public interface IAddressRepository
    {
        Task<List<SHIPProvinceDTO>> GetAllProvince();
        Task<List<SHIPDistrictDTO>> GetDistrictDTOByProvinceId(string id);
        Task<List<SHIPWardDTO>> GetWardByDistrictId(string id);
    }
}
