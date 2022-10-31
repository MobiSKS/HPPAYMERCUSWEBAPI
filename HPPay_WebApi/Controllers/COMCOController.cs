using HPPay.DataModel.COMCO;
using HPPay.DataRepository.COMCO;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HPPay_WebApi.Controllers
{
    [Route("api/dtplus/COMCO")]
    [ApiController]
    public class COMCOController : ControllerBase
    {
        private readonly ILogger<COMCOController> _logger;

        private readonly ICOMCORepository _COMCORepo;
        public COMCOController(ILogger<COMCOController> logger, ICOMCORepository COMCORepo)
        {
            _logger = logger;
            _COMCORepo = COMCORepo;
        }




        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_comco_map_customer_details")]
        public async Task<IActionResult> GetCOMCOMapCustomerDetails([FromBody] GetCOMCOMapCustomerDetailsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.GetCOMCOMapCustomerDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.MerchantDetails.Count > 0 && result.CustomerDetails.Count > 0)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_comco_map_customer")]
        public async Task<IActionResult> UpdateCOMCOMapCustomer([FromBody] UpdateCOMCOMapCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.UpdateCOMCOMapCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateCOMCOMapCustomerModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.Fail(ObjClass, result, _logger);

                    }
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_comco_view_mapped_customer")]
        public async Task<IActionResult> GetCOMCOViewMappedCustomer([FromBody] GetCOMCOViewMappedCustomerModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.GetCOMCOViewMappedCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.MerchantDetails.Count() > 0 && result.MappedDetails.Count > 0 && result.MerchantDetails.ToList()[0].Status == 1)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_view_mapped_customer")]
        public async Task<IActionResult> GetViewMappedCustomer([FromBody] GetViewMappedCustomerModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.GetViewMappedCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetViewMappedCustomerModelOutput> item = result.Cast<GetViewMappedCustomerModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
       [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_comco_limit_set_mode")]
        public async Task<IActionResult> GetCOMCOLimitSetMode([FromBody] GetCOMCOLimitSetModeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.GetCOMCOLimitSetMode(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCOMCOLimitSetModeModelOutput> item = result.Cast<GetCOMCOLimitSetModeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_comco_limit_invoice_interval")]
        public async Task<IActionResult> GetCOMCOLimitSetMode([FromBody] GetCOMCOLimitSetInvoiceIntervalModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.GetCOMCOLimitSetInvoiceInterval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCOMCOLimitSetInvoiceIntervalModelOutput> item = result.Cast<GetCOMCOLimitSetInvoiceIntervalModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("comco_limit_set_request")]
        public async Task<IActionResult> COMCOLimitSetRequest([FromForm] COMCOLimitSetRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.COMCOLimitSetRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<COMCOLimitSetRequestModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.Fail(ObjClass, result, _logger);

                    }
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_comco_limit_set_request_details")]
        public async Task<IActionResult> GetCOMCOLimitSetRequestDetails([FromBody] GetCOMCOLimitSetRequestDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.GetCOMCOLimitSetRequestDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCOMCOLimitSetRequestDetailsModelOutput> item = result.Cast<GetCOMCOLimitSetRequestDetailsModelOutput>().ToList();
                    if (item.Count > 0 || item.Count == 0 || result.Cast<GetCOMCOLimitSetRequestDetailsModelOutput>().ToList()[0].Status ==1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        /// <summary>
        /// Created By : Aditya Kumar Created Date:14 June 2022
        /// </summary>
        /// <param name="ObjClass"></param>
        /// <returns></returns>


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_approval_credit_limit_details")]
        public async Task<IActionResult> GetApprovalCreditLimitDetails([FromBody] GetApprovalCreditLimitDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.GetApprovalCreditLimitDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetApprovalCreditLimitDetailsModelOutput> item = result.Cast<GetApprovalCreditLimitDetailsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_rm_recharge_mode")]
        public async Task<IActionResult> GetRMRechargeMode([FromBody] GetRMRechargeModeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.GetRMRechargeMode(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetRMRechargeModeModelOutput> item = result.Cast<GetRMRechargeModeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }





        /// <summary>
        /// Created By : Aditya Kumar Created Date:15 June 2022
        /// </summary>
        /// <param name="ObjClass"></param>
        /// <returns></returns>

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_approve_reject_credit_limit")]
        public async Task<IActionResult> UpdateApproveRejectCreditLimit([FromBody] UpdateApproveRejectCreditLimitModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.UpdateApproveRejectCreditLimit(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateApproveRejectCreditLimitModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.Fail(ObjClass, result, _logger);

                    }
                }
            }
        }

        /// <summary>
        /// Created By : Aditya Kumar Created Date:15 June 2022
        /// </summary>
        /// <param name="ObjClass"></param>
        /// <returns></returns>

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_credit_limit")]
        public async Task<IActionResult> ViewCreditLimit([FromBody] ViewCreditLimitModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.ViewCreditLimit(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ViewCreditLimitModelOutput> item = result.Cast<ViewCreditLimitModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        /// <summary>
        /// Created By : Aditya Kumar Created Date:16 June 2022
        /// </summary>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_credit_and_caution_limit_history")]
        public async Task<IActionResult> CustomerCreditandCautionLimitHistory([FromBody] CustomerCreditandCautionLimitHistoryModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.CustomerCreditandCautionLimitHistory(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerCreditandCautionLimitHistoryModelOutput> item = result.Cast<CustomerCreditandCautionLimitHistoryModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }





        /// <summary>
        /// Created By : Aditya Kumar Created Date:17 June 2022
        /// </summary>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("comco_credit_account_summary")]
        public async Task<IActionResult> COMCOCreditAccountSummary([FromBody] COMCOCreditAccountSummaryModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.COMCOCreditAccountSummary(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<COMCOCreditAccountSummaryModelOutput> item = result.Cast<COMCOCreditAccountSummaryModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        /// <summary>
        /// Created By : Aditya Kumar Created Date:17 June 2022
        /// </summary>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("comco_credit_customer_account_summary")]
        public async Task<IActionResult> COMCOCreditCustomerAccountSummary([FromBody] COMCOCreditCustomerAccountSummaryModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.COMCOCreditCustomerAccountSummary(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<COMCOCreditCustomerAccountSummaryModelOutput> item = result.Cast<COMCOCreditCustomerAccountSummaryModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        ///// <summary>
        ///// Created By : Aditya Kumar Created Date:17 June 2022
        ///// </summary>
        ///// <param name="ObjClass"></param>
        ///// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("comco_credit_customer_account_details")]
        public async Task<IActionResult> COMCOCreditCustomerAccountDetails([FromBody] COMCOCreditCustomerAccountDetailsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.COMCOCreditCustomerAccountDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.CustomerAccountDetails.Count > 0 && result.TransactionDetails.Count > 0)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_reset_credit_and_caution_limit_detail")]
        public async Task<IActionResult> GetResetCreditandCautionLimitDetail([FromBody] GetResetCreditandCautionLimitDetailInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.GetResetCreditandCautionLimitDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetResetCreditandCautionLimitDetailOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.Fail(ObjClass, result, _logger);

                    }
                }
            }
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("reset_credit_and_caution_limit_request")]
        public async Task<IActionResult> ResetCreditandCautionLimitRequest([FromForm] ResetCreditandCautionLimitRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.ResetCreditandCautionLimitRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ResetCreditandCautionLimitRequestModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.Fail(ObjClass, result, _logger);

                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_premature_closure_detail")]
        public async Task<IActionResult> GetPrematureClosureDetail([FromBody] GetPrematureClosureDetailInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.GetPrematureClosureDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetPrematureClosureDetailOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.Fail(ObjClass, result, _logger);

                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_credit_customer_credit_recharge_payment_mode")]
        public async Task<IActionResult> GetCreditCustomerCreditRechargePaymentModeModelOutput([FromBody] GetCreditCustomerCreditRechargePaymentModeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.GetCreditCustomerCreditRechargePaymentMode(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCreditCustomerCreditRechargePaymentModeModelOutput> item = result.Cast<GetCreditCustomerCreditRechargePaymentModeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_credit_customer_credit_recharge_clubbing_category")]
        public async Task<IActionResult> GetCreditCustomerCreditRechargeClubbingCategory([FromBody] GetCreditCustomerCreditRechargeClubbingCategoryModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.GetCreditCustomerCreditRechargeClubbingCategory(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCreditCustomerCreditRechargeClubbingCategoryModelOutput> item = result.Cast<GetCreditCustomerCreditRechargeClubbingCategoryModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_credit_customer_credit_recharge_details")]
        public async Task<IActionResult> GetCreditCustomerCreditRechargeDetails([FromBody] GetCreditCustomerCreditRechargeDetailsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.GetCreditCustomerCreditRechargeDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCreditCustomerCreditRechargeDetailsModelOutput> item = result.Cast<GetCreditCustomerCreditRechargeDetailsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("credit_customer_credit_recharge")]
        public async Task<IActionResult> CreditCustomerCreditRecharge([FromBody] CreditCustomerCreditRechargeModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.CreditCustomerCreditRecharge(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CreditCustomerCreditRechargeModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.Fail(ObjClass, result, _logger);

                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_customer_credit_recharge")]
        public async Task<IActionResult> ViewCustomerCreditRecharge([FromBody] ViewCustomerCreditRechargeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.ViewCustomerCreditRecharge(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.CreditMerchantDetails.Count > 0 && result.CustomerCreditRecharge.Count > 0)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }




        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("comco_manager_credit_operation_role_request")]
        public async Task<IActionResult> COMCOManagerCreditOperationRoleRequest([FromBody] COMCOManagerCreditOperationRoleRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.COMCOManagerCreditOperationRoleRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<COMCOManagerCreditOperationRoleRequestModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.Fail(ObjClass, result, _logger);

                    }
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_comco_manager_credit_operation_role_request_details")]
        public async Task<IActionResult> GetCOMCOManagerCreditOperationRoleRequestDetails([FromBody] GetCOMCOManagerCreditOperationRoleRequestDetailsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.GetCOMCOManagerCreditOperationRoleRequestDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Count()>0 && result.Cast<GetCOMCOManagerCreditOperationRoleRequestDetailsModelOutput>().ToList()[0].Status == 1)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        //return this.FailCustom(ObjClass, result, _logger, "");
                           // result.Cast<GetCOMCOManagerCreditOperationRoleRequestDetailsModelOutput>().ToList()[0].Reason);
                    return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("approve_reject_comco_manager_credit_operation_role_request")]
        public async Task<IActionResult> ApproveRejectCOMCOManagerCreditOperationRoleRequest([FromBody] ApproveRejectCOMCOManagerCreditOperationRoleRequestModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.ApproveRejectCOMCOManagerCreditOperationRoleRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ApproveRejectCOMCOManagerCreditOperationRoleRequestModelOutput>().ToList()[0].Status == 1)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_download_comco_customer_details")]
        public async Task<IActionResult> ViewDownloadCOMCOCustomerDetails([FromBody] ViewDownloadCOMCOCustomerDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.ViewDownloadCOMCOCustomerDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ViewDownloadCOMCOCustomerDetailsModelOutput> item = result.Cast<ViewDownloadCOMCOCustomerDetailsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_caution_limit")]
        public async Task<IActionResult> UpdateCautionLimit([FromBody] UpdateCautionLimitModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.UpdateCautionLimit(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateCautionLimitModelOutput>().ToList()[0].Status == 1)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("premature_closure_request")]
        public async Task<IActionResult> PrematureClosureRequest([FromBody] PrematureClosureRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.PrematureClosureRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<PrematureClosureRequestModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.Fail(ObjClass, result, _logger);

                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_set_limit_customers")]
        public async Task<IActionResult> ViewSetLimitCustomers([FromBody] ViewSetLimitCustomersModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.ViewSetLimitCustomers(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ViewSetLimitCustomersModelOutput> item = result.Cast<ViewSetLimitCustomersModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        /// <summary>
        /// Created By : Aditya Kumar 
        /// </summary>
        /// <param name="ObjClass"></param>
        /// <returns></returns>

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_credit_customers_web_report")]
        public async Task<IActionResult> GetCreditCustomersWebReport([FromBody] GetCreditCustomersWebReportModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.GetCreditCustomersWebReport(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCreditCustomersWebReportModelOutput> item = result.Cast<GetCreditCustomersWebReportModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        /// <summary>
        /// Created By : Aditya Kumar 
        /// </summary>
        /// <param name="ObjClass"></param>
        /// <returns></returns>

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_comco_customer_cardno_vehicle_details")]
        public async Task<IActionResult> GetCOMCOCustomerCardNoVehicleDetails([FromBody] GetCOMCOCustomerCardNoVehicleDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.GetCOMCOCustomerCardNoVehicleDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCOMCOCustomerCardNoVehicleDetailsModelOutput> item = result.Cast<GetCOMCOCustomerCardNoVehicleDetailsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_comco_customer_statement")]
        public async Task<IActionResult> ViewCOMCOCustomerStatement([FromBody] ViewCOMCOCustomerStatementModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.ViewCOMCOCustomerStatement(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.CreditMerchantCustomerDetails.Count > 0 || result.TransactionStatement.Count > 0)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_authorize_comco_credit_operation_role_requests_details")]
        public async Task<IActionResult> GetAuthorizeCOMCOCreditOperationRoleRequestsDetails([FromBody] GetAuthorizeCOMCOCreditOperationRoleRequestsDetailsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.GetAuthorizeCOMCOCreditOperationRoleRequestsDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Count() > 0)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        //return this.FailCustom(ObjClass, result, _logger, "");
                        // result.Cast<GetCOMCOManagerCreditOperationRoleRequestDetailsModelOutput>().ToList()[0].Reason);
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("authorize_comco_credit_operation_role_requests")]
        public async Task<IActionResult> AuthorizeCOMCOCreditOperationRoleRequests([FromBody] AuthorizeCOMCOCreditOperationRoleRequestsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.AuthorizeCOMCOCreditOperationRoleRequests(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<AuthorizeCOMCOCreditOperationRoleRequestsModelOutput>().ToList()[0].Status == 1)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_comco_merchant_shift_master")]
        public async Task<IActionResult> InsertCOMCOMerchantShiftMaster([FromBody] InsertCOMCOMerchantShiftMasterModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.InsertCOMCOMerchantShiftMaster(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertCOMCOMerchantShiftMasterModelOutput>().ToList()[0].Status == 1)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_comco_merchant_details")]
        public async Task<IActionResult> GetCOMCOMerchantDetails([FromBody] GetCOMCOMerchantDetailsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.GetCOMCOMerchantDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetCOMCOMerchantDetailsModelOutput>().ToList()[0].Status == 1)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_comco_merchant_shift_master")]
        public async Task<IActionResult> GetCOMCOMerchantShiftMaster([FromBody] GetCOMCOMerchantShiftMasterModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _COMCORepo.GetCOMCOMerchantShiftMaster(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetCOMCOMerchantShiftMasterModelOutput>().ToList()[0].Status == 1)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

    }
}
