using App.DAL.Interfaces;
using App.Entity.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFU.Common;
using TFU.EntityFramework;

namespace App.DAL.Implements
{
    public class AddressRepository : AppBaseRepository, IAddressRepository
    {
        private readonly ApplicationDbContext _dbAppContext;
        public AddressRepository(IConfiguration config, TFUDbContext dbTFUContext, ApplicationDbContext dbAppContext) : base(config, dbTFUContext, dbAppContext)
        {
            _dbAppContext = dbAppContext;
        }

        public async Task<List<SHIPProvinceDTO>> GetAllProvince()
        {
            return await _dbAppContext.ShipProvince.ToListAsync();
        }

        public async Task<List<SHIPDistrictDTO>> GetDistrictDTOByProvinceId(string id)
        {
            return await _dbAppContext.ShipDistrict.Where(x => x.ProvinceId == id).ToListAsync();

        }

        public async Task<List<SHIPWardDTO>> GetWardByDistrictId(string id)
        {
            return await _dbAppContext.ShipWard.Where(x => x.DistrictId == id).ToListAsync();
        }
    }
}
