using App.Entity.DTO;
using App.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Interfaces
{
    public interface IAddressBizLogic
    {
        Task<List<SHIPProvinceModel>> GetAllProvince();
        Task<List<SHIPDistrictModel>> GetDistricByProvinceId(string id);
        Task<List<SHIPWardModel>> GetWardByDistrictId(string id);
    }
}
