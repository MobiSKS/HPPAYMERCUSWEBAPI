using HPPay.DataModel.CountryRegion;
using HPPay.DataRepository.CountryRegion;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [Route("api/hppay/countryregion")]
    [ApiController]
    public class CountryRegionController : ControllerBase
    {
        private readonly ILogger<CountryRegionController> _logger;

        private readonly ICountryRegionRepository _CRRepo;
        public CountryRegionController(ILogger<CountryRegionController> logger, ICountryRegionRepository CRRepo)
        {
            _logger = logger;
            _CRRepo = CRRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_country_region")]
        public async Task<IActionResult> GetCountryRegion([FromBody] GetCountryRegionModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _CRRepo.GetCountryRegion(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCountryRegionModelOutput> item = result.Cast<GetCountryRegionModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("delete_country_region")]
        public async Task<IActionResult> DeleteCountryRegion([FromBody] DeleteCountryRegionModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _CRRepo.DeleteCountryRegion(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<DeleteCountryRegionModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<DeleteCountryRegionModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }


    }

}
