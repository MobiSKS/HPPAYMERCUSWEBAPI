using HPPay.DataModel.IMPS;
using HPPay.DataRepository.IMPS;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [Route("api/dtplus/IMPS")]
    [ApiController]
    public class IMPSController : ControllerBase
    {
        private readonly ILogger<IMPSController> _logger;

        private readonly IIMPSRepository _IMPSRepo;

        public IMPSController(ILogger<IMPSController> logger, IIMPSRepository IMPSRepo)
        {
            _logger = logger;
            _IMPSRepo = IMPSRepo;
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("imps_recharge_reversal_request")]
        public async Task<IActionResult> IMPSRechargeReversalRequestOutput([FromForm] IMPSRechargeReversalRequestInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _IMPSRepo.IMPSRechargeReversalRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    return this.OkCustom(ObjClass, result, _logger);

                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("imps_view_transaction")]
        public async Task<IActionResult> IMPSTransactionSearch([FromForm] IMPSSearchInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _IMPSRepo.IMPSTransactionSearch(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    return this.OkCustom(ObjClass, result, _logger);

                }
            }
        }
    }
}
