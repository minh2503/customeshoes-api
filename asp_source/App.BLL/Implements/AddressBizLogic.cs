using App.BLL.Interfaces;
using App.DAL.Interfaces;
using App.Entity.Models;
using Microsoft.Data.SqlClient.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Implements
{
    public class AddressBizLogic : IAddressBizLogic
    {
        private IAddressRepository _addressRepository;
        public AddressBizLogic() { }
        public AddressBizLogic(IAddressRepository addressRepository)
        {
            this._addressRepository = addressRepository;
        }
        public async Task<List<SHIPProvinceModel>> GetAllProvince()
        {
            var data = await _addressRepository.GetAllProvince();
            return data?.Select(x => new SHIPProvinceModel(x)).ToList();
        }

        public async Task<List<SHIPDistrictModel>> GetDistricByProvinceId(string id)
        {
            var data = await _addressRepository.GetDistrictDTOByProvinceId(id);
            return data?.Select(x => new SHIPDistrictModel(x)).ToList();
        }

        public async Task<List<SHIPWardModel>> GetWardByDistrictId(string id)
        {
            var data = await _addressRepository.GetWardByDistrictId(id);
            return data?.Select(x => new SHIPWardModel(x)).ToList();
        }
    }
}
