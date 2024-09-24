using App.BLL.Interfaces;
using App.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using TFU.APIBased;

namespace tapluyen.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : BaseAPIController
    {
        private readonly ILogger<LocationController> _logger;
        private readonly IAddressBizLogic _addressBizLogic;

        public LocationController(ILogger<LocationController> logger, IAddressBizLogic addressBizLogic)
        {
            this._logger = logger;
            _addressBizLogic = addressBizLogic;
        }

        // controller của device type 
        [HttpGet("get-list-province")]
        public async Task<ActionResult> GetAllProvince()
        {
            try
            {
                var result = await _addressBizLogic.GetAllProvince();
                return GetSuccess(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetAllProvince: {0} {1}", ex.Message, ex.StackTrace);
                return SaveError();
            }
        }

        [HttpGet("get-list-district-by-province-id")]
        public async Task<ActionResult> GetDistrictByProvice(string id)
        {
            try
            {
                var result = await _addressBizLogic.GetDistricByProvinceId(id);
                return GetSuccess(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetDistrictByProvice: {0} {1}", ex.Message, ex.StackTrace);
                return SaveError();
            }
        }

        [HttpGet("get-list-ward-by-district-id")]
        public async Task<ActionResult> GetWardByDistricId(string id)
        {
            try
            {
                var result = await _addressBizLogic.GetWardByDistrictId(id);
                return GetSuccess(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetWardByDistricId: {0} {1}", ex.Message, ex.StackTrace);
                return SaveError();
            }
        }
    }
}
