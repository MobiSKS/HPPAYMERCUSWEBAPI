using HPPay.DataModel.RegionalOffice;
using HPPay.DataRepository.RegionalOffice;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [Route("api/dtplus/regionaloffice")]
    [ApiController]
    public class RegionalOfficeController : ControllerBase
    {
        private readonly ILogger<RegionalOfficeController> _logger;

        private readonly IRegionalOfficeRepository _RORepo;
        public RegionalOfficeController(ILogger<RegionalOfficeController> logger, IRegionalOfficeRepository RORepo)
        {
            _logger = logger;
            _RORepo = RORepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_regional_office")]
        public async Task<IActionResult> GetRegionalOffice([FromBody] GetRegionalOfficeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _RORepo.GetRegionalOffice(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetRegionalOfficeModelOutput> item = result.Cast<GetRegionalOfficeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("delete_regional_office")]
        public async Task<IActionResult> DeleteRegionalOffice([FromBody] DeleteRegionalOfficeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _RORepo.DeleteRegionalOffice(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<DeleteRegionalOfficeModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<DeleteRegionalOfficeModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_regional_office_by_multiple_zone")]
        public async Task<IActionResult> GetRegionalOfficeByMultipleZone([FromBody] GetRegionalOfficebyMultipleZoneModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _RORepo.GetRegionalOfficeByMultipleZone(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetRegionalOfficeModelOutput> item = result.Cast<GetRegionalOfficeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_regional_office_only_retail")]
        public async Task<IActionResult> GetRegionalOfficeOnlyRetail([FromBody] GetRegionalOfficeOnlyRetailModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _RORepo.GetRegionalOfficeOnlyRetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetRegionalOfficeOnlyRetailModelOutput> item = result.Cast<GetRegionalOfficeOnlyRetailModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

    }
}
