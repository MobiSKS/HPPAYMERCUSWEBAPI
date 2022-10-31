using HPPay.DataModel.EFT;
using HPPay.DataRepository.EFT;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [Route("api/dtplus/EFT")]
    [ApiController]
    public class EFTController : ControllerBase
    {
        private readonly ILogger<EFTController> _logger;

        private readonly IEFTRepository _EFTRepo;

        public EFTController(ILogger<EFTController> logger, IEFTRepository EFTRepo)
        {
            _logger = logger;
            _EFTRepo = EFTRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("eft_recharge_filename")]
        public async Task<IActionResult> EFTRechargeFileName([FromBody] EFTRechargeFileNameInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _EFTRepo.EFTRechargeFileName(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<EFTRechargeFileNameOutput> item = result.Cast<EFTRechargeFileNameOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("eft_recharge_detail_validation")]
        public async Task<IActionResult> EFTRechargeDetailValidation([FromForm] EFTRechargeDataValidation ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _EFTRepo.EFTRechargeDetailValidation(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else if (result.Status == 1)
                {
                    return this.OkCustom(ObjClass, result, _logger);
                }
                else
                {
                    return this.FailCustom(ObjClass, result, _logger, result.Reason);

                }
            }


        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("eft_recharge_detail_entry")]
        public async Task<IActionResult> InsertEFTRechargeDetails([FromForm] EFTRechargeDataInsert ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _EFTRepo.InsertEFTRechargeDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<EFTRechargeDataOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<EFTRechargeDataOutput>().ToList()[0].Reason);
                    }
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("eft_recharge_detail_pending_for_approval")]
        public async Task<IActionResult> EFTRechargeDetailsPendingForApproval([FromBody] EFTRechargePendingForApprovalInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _EFTRepo.EFTRechargeDetailsPendingForApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<EFTRechargePendingForApprovalOutput> item = result.Cast<EFTRechargePendingForApprovalOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("eft_recharge_detail_approval")]
        public async Task<IActionResult> EFTRechargeDetailsApproval([FromBody] EFTRechargeApprovalInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _EFTRepo.EFTRechargeDetailsApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<EFTRechargeApprovalOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<EFTRechargeApprovalOutput>().ToList()[0].Reason);
                    }
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("eft_recharge_detail_rejection")]
        public async Task<IActionResult> EFTRechargeDetailsRejection([FromBody] EFTRechargeRejectionInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _EFTRepo.EFTRechargeDetailsRejection(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<EFTRechargeRejectionOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<EFTRechargeRejectionOutput>().ToList()[0].Reason);
                    }
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("eft_recharge_reversal_search")]
        public async Task<IActionResult> EFTRechargeReversalSearch([FromBody] EFTRechargeReversalSearchInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _EFTRepo.EFTRechargeReversalSearch(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<EFTRechargeReversalSearchOutput> item = result.Cast<EFTRechargeReversalSearchOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("eft_recharge_reversal_request")]
        public async Task<IActionResult> EFTRechargeReversalRequest([FromBody] EFTRechargeReversalRequestInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _EFTRepo.EFTRechargeReversalRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<EFTRechargeReversalRequestOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<EFTRechargeReversalRequestOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("eft_recharge_reversal_pending_for_approval")]
        public async Task<IActionResult> EFTRechargeReversalPendingForApproval([FromBody] EFTRechargeReversalPendingForApprovalInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _EFTRepo.EFTRechargeReversalPendingForApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<EFTRechargeReversalPendingForApprovalOutput> item = result.Cast<EFTRechargeReversalPendingForApprovalOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("eft_recharge_reversal_approval")]
        public async Task<IActionResult> EFTRechargeReversalApproval([FromBody] EFTRechargeReversalApprovalInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _EFTRepo.EFTRechargeReversalApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<EFTRechargeReversalApprovalOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<EFTRechargeReversalApprovalOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("eft_recharge_reversal_rejection")]
        public async Task<IActionResult> EFTRechargeReversalRejection([FromBody] EFTReversalRejectionInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _EFTRepo.EFTReversalRejection(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<EFTReversalRejectionOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<EFTReversalRejectionOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_eft_request")]
        public async Task<IActionResult> ViewEFTRequest([FromBody] ViewEFTRequestInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _EFTRepo.ViewEFTRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ViewEFTRequestOutput> item = result.Cast<ViewEFTRequestOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_eft_reverse_detail")]
        public async Task<IActionResult> ViewEFTReverseDetail([FromBody] ViewEFTReverseDetailInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _EFTRepo.ViewEFTReverseDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ViewEFTReverseDetailOutput> item = result.Cast<ViewEFTReverseDetailOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
    }
}
