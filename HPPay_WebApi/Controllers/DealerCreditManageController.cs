using HPPay.DataModel.DealerCreditManage;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataRepository.DealerCreditManage;
using HPPay.DataRepository.SMSGetSend;
using HPPay.Infrastructure.CommonClass;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace HPPay_WebApi.Controllers
{
    [Route("api/hppay/dealercredit")]
    [ApiController]
    public class DealerCreditManageController : ControllerBase
    {
        private readonly ILogger<DealerCreditManageController> _logger;

        private readonly IDealerCreditManageRepository _DCMRepo;
        private readonly ISMSGetSendRepository _GetSendRepo;
        public DealerCreditManageController(ILogger<DealerCreditManageController> logger, IDealerCreditManageRepository DCMRepo, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _DCMRepo = DCMRepo;
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dealer_credit_mapping_details")]
        public async Task<IActionResult> GetDealerCreditMappingDetails([FromBody] GetDealerCreditMappingDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.GetDealerCreditMappingDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.CustomerCCMSBalanceDetails.Count > 0 && result.CustomerDetails.Count > 0 && result.CustomerMerchantMappedDetails.Count > 0)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_list_credit_close_limit_type")]
        public async Task<IActionResult> GetListCreditCloseLimitType([FromBody] GetListCreditCloseLimitTypeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.GetListCreditCloseLimitType(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetListCreditCloseLimitTypeModelOutput> item = result.Cast<GetListCreditCloseLimitTypeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_list_credit_period")]
        public async Task<IActionResult> GetListCreditPeriod([FromBody] GetListCreditPeriodModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.GetListCreditPeriod(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetListCreditPeriodModelOutput> item = result.Cast<GetListCreditPeriodModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }




        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_merchant_mapping_enable_disable")]
        public async Task<IActionResult> CustomerMerchantMappingEnableDisable([FromBody] CustomerMerchantMappingEnableDisableModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.CustomerMerchantMappingEnableDisable(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CustomerMerchantMappingEnableDisableModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.Fail(ObjClass, result, _logger);
                        //result.Cast<CustomerMerchantMappingEnableDisableModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_map_dealer_for_credit_sale")]
        public async Task<IActionResult> DCMInsertMapDealerForCreditSale([FromBody] DCMInsertMapDealerForCreditSaleModelInput ObjClass)

        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.DCMInsertMapDealerForCreditSale(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<DCMInsertMapDealerForCreditSaleModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.Fail(ObjClass, result, _logger);
                        //result.Cast<DCMInsertMapDealerForCreditSaleModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_dealer_credit_mapping")]
        public async Task<IActionResult> UpdateDealerCreditMapping([FromBody] UpdateDealerCreditMappingModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.UpdateDealerCreditMapping(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateDealerCreditMappingModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.Fail(ObjClass, result, _logger);
                        //result.Cast<UpdateDealerCreditMappingModelOutput>().ToList()[0].Reason);
                    }

                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dealer_credit_sale_statement")]
        public async Task<IActionResult> GetDealerCreditSaleStatement([FromBody] GetDealerCreditSaleStatementModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.GetDealerCreditSaleStatement(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDealerCreditSaleStatementModelOutput> item = result.Cast<GetDealerCreditSaleStatementModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dealer_credit_payment_status")]
        public async Task<IActionResult> DealerCreditPaymentStatus([FromBody] GetDealerCreditPaymentStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.GetDealerCreditPaymentStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDealerCreditPaymentStatusModelOutput> item = result.Cast<GetDealerCreditPaymentStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dealer_credit_sale_view")]
        public async Task<IActionResult> GetDealerCreditSaleView([FromBody] GetDealerCreditSaleViewModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.GetDealerCreditSaleView(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDealerCreditSaleViewModelOutput> item = result.Cast<GetDealerCreditSaleViewModelOutput>().ToList();
                    if (item.Count > 0)
                        //if (result.Cast<GetDealerCreditSaleViewModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
       [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_merchant_dealer_credit_sale_statement")]
        public async Task<IActionResult> GetMerchantDealerCreditSaleStatement([FromBody] GetMerchantDealerCreditSaleStatementModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.GetMerchantDealerCreditSaleStatement(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    if (result.ViewStatementDetails.ToList()[0].Status == 1 && result.TransactionDetails.Count > 0)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_download_merchant_dealer_credit_sale_statement")]
        public async Task<IActionResult> GetDownloadMerchantDealerCreditSaleStatement([FromBody] GetDownloadMerchantDealerCreditSaleStatementModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.GetDownloadMerchantDealerCreditSaleStatement(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    if (result.GetStatementDetails.Count > 0 && result.GetTransactionDetails.Count > 0 && result.ViewCustomerMerchantDetails.Count>0)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
         [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_statement_date_list")]
        public async Task<IActionResult> GetStatementDateList([FromBody] GetStatementDateListModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.GetStatementDateList(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    
                    List<GetStatementDateListModelOutput> item = result.Cast<GetStatementDateListModelOutput>().ToList();
                    if (item.Count > 0 && result.Cast<GetStatementDateListModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
       [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_credit_sale_view")]
        public async Task<IActionResult> GetCreditSaleView([FromBody] GetCreditSaleViewModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.GetCreditSaleView(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCreditSaleViewModelOutput> item = result.Cast<GetCreditSaleViewModelOutput>().ToList();
                    if (item.Count > 0)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_credit_sale_outstanding_details")]
        public async Task<IActionResult> GetCreditSaleOutstandingDetails([FromBody] GetCreditSaleOutstandingDetailsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.GetCreditSaleOutstandingDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    if (result.MerchantDetails.Count > 0 && result.MerchantCustomerMappedDetails.Count > 0)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dealer_credit_sale_details")]
        public async Task<IActionResult> GetDealerCreditSaleDetails([FromBody] GetDealerCreditSaleDetailsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.GetDealerCreditSaleDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDealerCreditSaleDetailsModelOutput> item = result.Cast<GetDealerCreditSaleDetailsModelOutput>().ToList();
                    if (item.Count > 0)
                        //if (result.Cast<GetDealerCreditSaleViewModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dealer_credit_payment_in_bulk")]
        public async Task<IActionResult> GetDealerCreditPaymentInBulk([FromBody] GetDealerCreditPaymentInBulkModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.GetDealerCreditPaymentInBulk(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDealerCreditPaymentInBulkModelOutput> item = result.Cast<GetDealerCreditPaymentInBulkModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_credit_close_payment")]
        public async Task<IActionResult> GetCreditClosePayment([FromBody] GetCreditClosePaymentModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.GetCreditClosePayment(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCreditClosePaymentModelOutput> item = result.Cast<GetCreditClosePaymentModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        /// <summary>
        /// Created by: Aditya kumar Created Date : 21-06-2022
        /// </summary>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("generate_otp_credit_close_payment")]
        public async Task<IActionResult> GenerateOTPCreditClosePayment([FromBody] GenerateOTPCreditClosePaymentModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.GenerateOTPCreditClosePayment(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GenerateOTPCreditClosePaymentModelOutput>().ToList()[0].Status == 1)
                    {
                        try
                        {
                            GetSMSValueInputModel ObjSMSValue = new GetSMSValueInputModel();
                            ObjSMSValue.MethodName = ControllerContext.ActionDescriptor.ActionName;
                            var SMSResult = await _GetSendRepo.GetSMSValue(ObjSMSValue);
                            if (SMSResult != null)
                            {
                                List<GetSMSValueOutputModel> item = SMSResult.Cast<GetSMSValueOutputModel>().ToList();
                                for (int i = 0; i < item.Count; i++)
                                {
                                    if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                                    {
                                        GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                                        getandInsertSendInputModel.CreatedBy = ObjClass.CreatedBy;// from database
                                        getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                        string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                        TemplateMessage = TemplateMessage.Replace("@OTP", result.Cast<GenerateOTPCreditClosePaymentModelOutput>().ToList()[0].OTP)
                                            .Replace("@Amount",ObjClass.Amount.ToString()).
                                            Replace("@OutletName", result.Cast<GenerateOTPCreditClosePaymentModelOutput>().ToList()[0].OutletName);
                                        //TemplateMessage = TemplateMessage.Replace("[RefNo]",
                                        //    result.Cast<CustomerInsertModelOutput>().ToList()[0].FormNumber.ToString()).Replace("@UserName",
                                        //    result.Cast<CustomerInsertModelOutput>().ToList()[0].FormNumber.ToString()).Replace("@Email",
                                        //    ObjClass.CommunicationEmailid);

                                        getandInsertSendInputModel.SMSText = TemplateMessage;
                                        getandInsertSendInputModel.MobileNo = result.Cast<GenerateOTPCreditClosePaymentModelOutput>().ToList()[i].Mobileno;// from database
                                        getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo;
                                        getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateName;
                                        getandInsertSendInputModel.Userip = ObjClass.Userip;
                                        getandInsertSendInputModel.Userid = ObjClass.Userid;
                                        getandInsertSendInputModel.Useragent = ObjClass.Useragent;
                                        getandInsertSendInputModel.SenderId = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SenderId;
                                        getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSAPIURL;
                                        await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);

                                    }

                                    if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailStatus == 1)
                                    {
                                        string ZOROEmaild = String.Empty;
                                        InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                        insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                                        insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                                        insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                                        insertEmailTextEntryInputModel.EmailIdTo = ""; // from database
                                        insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                        insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                        insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                        string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                        //if (ObjClass.CommunicationEmailid == "")
                                        //{
                                        //    ObjClass.CommunicationEmailid = insertEmailTextEntryInputModel.EmailIdCC;
                                        //}

                                        EmailTemplateMessage = EmailTemplateMessage.Replace("", "");

                                        insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");
                                        insertEmailTextEntryInputModel.CreatedBy = ObjClass.CreatedBy;// from database
                                        await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ControllerContext.ActionDescriptor.ActionName + " :: Email and SMS Error :" + ex.Message);
                        }

                        return this.OkCustom(ObjClass, result, _logger);
                        
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<GenerateOTPCreditClosePaymentModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }
        /// <summary>
        /// Created by: Aditya kumar Created Date : 21-06-2022
        /// </summary>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("validate_otp_update_credit_close_payment")]
        public async Task<IActionResult> ValidateOTPUpdateCreditClosePayment([FromBody] ValidateOTPUpdateCreditClosePaymentModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.ValidateOTPUpdateCreditClosePayment(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ValidateOTPUpdateCreditClosePaymentModelOutput>().ToList()[0].Status == 1)
                    {
                        //if (result.Cast<GenerateOTPCreditClosePaymentModelOutput>().ToList()[0].CTID != "")
                        //{
                        //    Variables.SendSMS(4, result.Cast<ValidateOTPUpdateCreditClosePaymentModelOutput>().ToList()[0].CTID,
                        //        result.Cast<ValidateOTPUpdateCreditClosePaymentModelOutput>().ToList()[0].Mobileno,
                        //        ObjClass.CreatedBy,
                        //       ObjClass.CustomerID,
                        //        ObjClass.Amount.ToString());

                        //    }
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
        [Route("update_dealer_credit_payment_in_bulk")]
        public async Task<IActionResult> UpdateDealerCreditPaymentInBulk([FromBody] UpdateDealerCreditPaymentInBulkModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DCMRepo.UpdateDealerCreditPaymentInBulk(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateDealerCreditPaymentInBulkModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);

                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateDealerCreditPaymentInBulkModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }

           
        
       }

    }