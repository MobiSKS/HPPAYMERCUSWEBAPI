//using AtallaHSM.Data.DBDapper;
using HPPay.DataRepository.DBDapper;
using HPPay.DataModel.PayCode;
using HPPay.DataRepository.EGVAPI;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{

    [ApiController]
    [Route("/Transaction/")]
    public class EGVAPIController: ControllerBase
    {
        private readonly ILogger<EGVAPIController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IEGVAPIRepository _egvapicodeRepo;
        private readonly DapperContext _context;

        public EGVAPIController(ILogger<EGVAPIController> logger, IEGVAPIRepository egvapicodeRepo, IConfiguration configuration, DapperContext context)
        {
            _logger = logger;
            _egvapicodeRepo = egvapicodeRepo;
            _configuration = configuration;
            _context = context;

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("GenerateFuelVoucher")]
        public async Task<IActionResult> GeneratePayCodeForEGVAPI([FromBody] PayCodeGeneratePayCodeDetailsForEGVAPIWithoutStartDateModelIntput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.EGVAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _egvapicodeRepo.GeneratePayCodeForEGVAPI(ObjClass);
                if (result == null)
                {
                    return this.EGVAPINotFoundCustom(ObjClass, null, _logger);
                }
                if (result.voucherDetails.Count > 0)
                    return this.EGVAPIOkCustom(ObjClass, result, _logger);
                else
                    return this.EGVAPIFail(ObjClass, result, _logger);
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("GenerateFuelVoucherWithStartDate")]
        public async Task<IActionResult> GenerateFuelVoucherWithStartDate([FromBody] PayCodeGeneratePayCodeDetailsForEGVAPIModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.EGVAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _egvapicodeRepo.GenerateFuelVoucherWithStartDate(ObjClass);
                if (result == null)
                {
                    return this.EGVAPINotFoundCustom(ObjClass, null, _logger);
                }
                if (result.voucherDetails.Count > 0)
                    return this.EGVAPIOkCustom(ObjClass, result, _logger);
                else
                    return this.EGVAPIFail(ObjClass, result, _logger);
            }
        }




        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("GetConsumptionData")]
        public async Task<IActionResult> GetConsumptionData([FromBody] PayCodeGetConsumptionDataForEGVAPIModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.EGVAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _egvapicodeRepo.GetConsumptionData(ObjClass);
                if (result == null)
                {
                    return this.EGVAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    
                    GetPayCodeGetConsumptionDataForEGVAPIModelOutput item = result.consumptionRes ;

                    if (item.responseCode == 0)
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);



                }
            }
        }



    }
}
