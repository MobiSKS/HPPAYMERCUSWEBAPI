using HPPay.DataModel.SFLAPI;
using HPPay.DataRepository.SFLAPI;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/SFLAPI/SFL")]
    public class SFLAPIController : ControllerBase
    {
        private readonly ILogger<SFLAPIController> _logger;
        private readonly ISFLAPIRepository _SFLApiRepo;

        public SFLAPIController(ILogger<SFLAPIController> logger, ISFLAPIRepository SFLApiRepo)
        {
            _logger = logger;
            _SFLApiRepo = SFLApiRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(SFLAPIAuthenticationFilter))]
        [Route("MapDTPlusCustomer")]
        public async Task<IActionResult> SFLAPIMapDTPlusCustomer([FromBody] SFLAPIMapDTPlusCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.SFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _SFLApiRepo.MapDTPlusCustomer(ObjClass);
                if (result == null)
                {
                    return this.SFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<SFLAPIMapDTPlusCustomerModelOutput> item = result.Cast<SFLAPIMapDTPlusCustomerModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.SFLOkCustom(ObjClass, result, _logger);
                    else
                        return this.SFLFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(SFLAPIAuthenticationFilter))]
        [Route("CreateCard")]
        public async Task<IActionResult> SFLAPICreateCard([FromBody] SFLAPICreateCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.SFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _SFLApiRepo.CreateCard(ObjClass);
                if (result == null)
                {
                    return this.SFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.cardRes.cardDetail.statusCode == "0")
                        return this.SFLOkCustom(ObjClass, result, _logger);
                    else
                        return this.SFLFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(SFLAPIAuthenticationFilter))]
        [Route("UpdateStatus")]
        public async Task<IActionResult> SFLAPIUpdateStatus([FromBody] SFLAPIUpdateStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.SFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _SFLApiRepo.UpdateStatus(ObjClass);
                if (result == null)
                {
                    return this.SFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<CustomerAPIGetProductRSPModelOutput> item = result.Cast<CustomerAPIGetProductRSPModelOutput>().ToList();
                    if (result.customerCardStatusRes.responseCode == "0")
                        return this.SFLOkCustom(ObjClass, result, _logger);
                    else
                        return this.SFLFail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(SFLAPIAuthenticationFilter))]
        [Route("GetConsumptionData")]
        public async Task<IActionResult> SFLAPIGetConsumptionData([FromBody] SFLAPIGetConsumptionDataModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.SFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _SFLApiRepo.GetConsumptionData(ObjClass);
                if (result == null)
                {
                    return this.SFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<CustomerAPIGetProductRSPModelOutput> item = result.Cast<CustomerAPIGetProductRSPModelOutput>().ToList();
                    if (result.consumptionRes.responseCode == "0")
                        return this.SFLOkCustom(ObjClass, result, _logger);
                    else
                        return this.SFLFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(SFLAPIAuthenticationFilter))]
        [Route("GetCardHotlistStatus")]
        public async Task<IActionResult> SFLAPIGetCardHotlistStatus([FromBody] SFLAPIGetCardHotlistStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.SFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _SFLApiRepo.GetCardHotlistStatus(ObjClass);
                if (result == null)
                {
                    return this.SFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<CustomerAPIGetProductRSPModelOutput> item = result.Cast<CustomerAPIGetProductRSPModelOutput>().ToList();
                    if (result.cardHotListResponse.FirstOrDefault().responseCode == "0")
                        return this.SFLOkCustom(ObjClass, result, _logger);
                    else
                        return this.SFLFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpGet]
        [ServiceFilter(typeof(SFLAPIAuthenticationFilter))]
        [Route("GetCustomerHotlistStatus")]
        public async Task<IActionResult> SFLAPIGetCustomerHotlistStatus([FromBody] SFLAPIGetCustomerHotlistStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.SFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _SFLApiRepo.GetCustomerHotlistStatus(ObjClass);
                if (result == null)
                {
                    return this.SFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<CustomerAPIGetProductRSPModelOutput> item = result.Cast<CustomerAPIGetProductRSPModelOutput>().ToList();
                    if (result.customerHotlistDetails.FirstOrDefault().responseCode == "0")
                        return this.SFLOkCustom(ObjClass, result, _logger);
                    else
                        return this.SFLFail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(SFLAPIAuthenticationFilter))]
        [Route("GetHotlistReactivateReason")]
        public async Task<IActionResult> SFLAPIGetHotlistReactivateReason([FromBody] SFLAPIGetHotlistReactivateReasonModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.SFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _SFLApiRepo.GetHotlistReactivateReason(ObjClass);
                if (result == null)
                {
                    return this.SFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<CustomerAPIGetProductRSPModelOutput> item = result.Cast<CustomerAPIGetProductRSPModelOutput>().ToList();
                    if (result.responseCode == "0")
                        return this.SFLOkCustom(ObjClass, result, _logger);
                    else
                        return this.SFLFail(ObjClass, result, _logger);
                }
            }
        }

    }
}
