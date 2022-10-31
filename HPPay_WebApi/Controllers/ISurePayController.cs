using HPPay.DataModel.ISurePay;
using HPPay.DataRepository.ISurePay;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [Route("api/dtplus/ISurePay")]
    [ApiController]
    public class ISurePayController : ControllerBase
    {
        private readonly ILogger<ISurePayController> _logger;

        private readonly IISurePayRepository _ISurePayRepo;

        public ISurePayController(ILogger<ISurePayController> logger, IISurePayRepository ISurePayRepo)
        {
            _logger = logger;
            _ISurePayRepo = ISurePayRepo;
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("isurepay_recharge_validation")]
        public async Task<IActionResult> ISUrePayRechargeDetailValidation([FromForm] ISuarePayValidationInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ISurePayRepo.ISUrePayRechargeDetailValidation(ObjClass);
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
        [Route("isurepay_recharge_detail_entry")]
        public async Task<IActionResult> ISUrePayRechargeDataInsert([FromForm] ISuarePayRequestInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ISurePayRepo.ISUrePayRechargeDataInsert(ObjClass);
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
        [Route("isurepay_recharge_pending_approval_search")]
        public async Task<IActionResult> ISurePayRechargePendingForApprovalSearch([FromForm] ISurePayPendingApprovalSearchInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ISurePayRepo.ISurePayRechargePendingForApprovalSearch(ObjClass);
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
        [Route("isurepay_recharge_request_approval")]
        public async Task<IActionResult> ISurePayRechargeRequestApproval([FromBody] ISurePayRechargeApprovalInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ISurePayRepo.ISurePayRechargeRequestApproval(ObjClass);
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
        [Route("isurepay_recharge_request_rejection")]
        public async Task<IActionResult> ISurePayRechargeDetailsRejection([FromBody] ISurePayRechargeRejectionInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ISurePayRepo.ISurePayRechargeDetailsRejection(ObjClass);
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
        [Route("isurepay_recharge_reversal_search")]
        public async Task<IActionResult> ISurePayRechargeReversalSearch([FromForm] ISurePayRechargeReversalSearchInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ISurePayRepo.ISurePayRechargeReversalSearch(ObjClass);
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
        [Route("isurepay_recharge_reversal_request")]
        public async Task<IActionResult> ISurePayRechargeReversalRequest([FromBody] ISurePayRechargeReversalRequestInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ISurePayRepo.ISurePayRechargeReversalRequest(ObjClass);
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
        [Route("isurepay_reversal_pending_approval_search")]
        public async Task<IActionResult> ISurePayReversalPendingApprovalSearch([FromForm] ISurePayReversalPendingApprovalSearchInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ISurePayRepo.ISurePayReversalPendingApprovalSearch(ObjClass);
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
        [Route("isurepay_recharge_reversal_approval")]
        public async Task<IActionResult> ISurePayRechargeReversalApproval([FromBody] ISurePayRechargeReversalApprovalInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ISurePayRepo.ISurePayRechargeReversalApproval(ObjClass);
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
        [Route("isurepay_recharge_reversal_rejection")]
        public async Task<IActionResult> ISurePayRechargeReversalRejection([FromBody] ISurePayReversalRejectionInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ISurePayRepo.ISurePayReversalRejection(ObjClass);
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
        [Route("view_isurepay_request")]
        public async Task<IActionResult> ViewISurePayRequest([FromForm] ISurePayViewRequestInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ISurePayRepo.ViewISurePayRequest(ObjClass);
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
