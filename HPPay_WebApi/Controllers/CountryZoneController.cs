using HPPay.DataModel.CountryZone;
using HPPay.DataRepository.CountryZone;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [Route("api/hppay/countryzone")]
    [ApiController]
    public class CountryZoneController : ControllerBase
    {
        private readonly ILogger<CountryZoneController> _logger;

        private readonly ICountryZoneRepository _CZRepo;
        public CountryZoneController(ILogger<CountryZoneController> logger, ICountryZoneRepository CZRepo)
        {
            _logger = logger;
            _CZRepo = CZRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_country_zone")]
        public async Task<IActionResult> GetCountryZone([FromBody] GetCountryZoneModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _CZRepo.GetCountryZone(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCountryZoneModelOutput> item = result.Cast<GetCountryZoneModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("delete_country_zone")]
        public async Task<IActionResult> DeleteCountryZone([FromBody] DeleteCountryZoneModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _CZRepo.DeleteCountryZone(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<DeleteCountryZoneModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<DeleteCountryZoneModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }
    }

}
