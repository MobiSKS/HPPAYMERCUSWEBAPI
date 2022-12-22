using HPPay.DataModel.Infinity;
using HPPay.DataRepository.Infinity;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [Route("api/hppay/Infinity")]
    [ApiController]
    public class InfinityController : ControllerBase
    {
        private readonly ILogger<InfinityController> _logger;

        private readonly IInfinityRepository _InfinityRepo;

        public InfinityController(ILogger<InfinityController> logger, IInfinityRepository InfinityRepo)
        {
            _logger = logger;
            _InfinityRepo = InfinityRepo;
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("infinity_recharge_detail_validation")]
        public async Task<IActionResult> InfinityRechargeDetailValidation([FromForm] InfinityRechargeValidationInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _InfinityRepo.InfinityRechargeDetailValidation(ObjClass);
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
        [Route("infinity_recharge_detail_entry")]
        public async Task<IActionResult> InsertInfinityRechargeDetails([FromForm] InfinityRechargeDataInsertInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _InfinityRepo.InsertInfinityRechargeDetails(ObjClass);
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
        [Route("infinity_recharge_detail_pending_for_approval")]
        public async Task<IActionResult> InfinityRechargeDetailsPendingForApproval([FromForm] InfinityRechargeApprovalPendingInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _InfinityRepo.InfinityRechargeDetailsPendingForApproval(ObjClass);
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
        [Route("infinity_recharge_detail_approval")]
        public async Task<IActionResult> InfinityRechargeDetailsApproval([FromBody] InfinityRechargeApprovalInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _InfinityRepo.InfinityRechargeDetailsApproval(ObjClass);
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
        [Route("infinity_recharge_detail_rejection")]
        public async Task<IActionResult> InfinityRechargeDetailsRejection([FromBody] InfinityRechargeRejectionInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _InfinityRepo.InfinityRechargeDetailsRejection(ObjClass);
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
        [Route("view_infinity_request")]
        public async Task<IActionResult> ViewInfinityRequest([FromForm] ViewInfinityRequestInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _InfinityRepo.ViewInfinityRequest(ObjClass);
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
