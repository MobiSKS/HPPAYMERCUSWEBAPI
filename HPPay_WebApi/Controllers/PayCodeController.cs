using AtallaHSM;
using AtallaHSM.Model;
using HPPay.DataModel.PayCode;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataModel.Transaction;
using HPPay.DataRepository.PayCode;
using HPPay.DataRepository.SMSGetSend;
using HPPay.DataRepository.Transaction;
using HPPay.Infrastructure.CommonClass;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AtallaHSM.Common.LoggerUtility;


namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/hppay/paycode")]
    public class PayCodeController : ControllerBase
    {
        private readonly ILogger<PayCodeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IPayCodeRepository _paycodeRepo;
        private readonly ISMSGetSendRepository _GetSendRepo;

        public PayCodeController(ILogger<PayCodeController> logger, IPayCodeRepository paycodeRepo, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _paycodeRepo = paycodeRepo;
            _GetSendRepo = GetSendRepo;
        }

        [HttpPost]
      [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("generate_paycode")]
        public async Task<IActionResult> GeneratePayCodeDetails([FromBody] PayCodeGeneratePayCodeDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _paycodeRepo.GeneratePayCodeDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<PayCodeGeneratePayCodeDetailsModelOutput>().ToList()[0].Status == 1)
                    {

                        ////Stateted sms sending  code
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
                                        getandInsertSendInputModel.CreatedBy = ObjClass.CreatedBy;
                                        getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                        string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                        TemplateMessage = TemplateMessage.Replace("@Amount", (ObjClass.Amount).ToString())
                                            .Replace("@Paycode", result.Cast<PayCodeGeneratePayCodeDetailsModelOutput>().ToList()[0].Reason).Replace
                                             ("@ExpiryTime", result.Cast<PayCodeGeneratePayCodeDetailsModelOutput>().ToList()[0].ExpiryDate);

                                        getandInsertSendInputModel.SMSText = TemplateMessage;
                                        getandInsertSendInputModel.MobileNo = ObjClass.ObjPayCodeForTypeDespetachDetails[0].MobileNo;
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
                                        string ZOROEmaild = string.Empty; //database

                                        InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                        insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                                        insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                                        insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                                        insertEmailTextEntryInputModel.EmailIdTo = ObjClass.ObjPayCodeForTypeDespetachDetails[0].Email;
                                        insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                        insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                        insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                        string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                        if (ObjClass.ObjPayCodeForTypeDespetachDetails[0].Email == "")
                                        {
                                            ObjClass.ObjPayCodeForTypeDespetachDetails[0].Email = insertEmailTextEntryInputModel.EmailIdCC;
                                        }

                                        EmailTemplateMessage = EmailTemplateMessage.Replace("@Amount", (ObjClass.Amount).ToString())
                                            .Replace("@Paycode", result.Cast<PayCodeGeneratePayCodeDetailsModelOutput>().ToList()[0].Reason).Replace
                                             ("@ExpiryTime", result.Cast<PayCodeGeneratePayCodeDetailsModelOutput>().ToList()[0].ExpiryDate);

                                        insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
                                        insertEmailTextEntryInputModel.CreatedBy = ObjClass.CreatedBy;
                                        await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ControllerContext.ActionDescriptor.ActionName + " :: Email and SMS Error :" + ex.Message);
                        }



                        ////



                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<PayCodeGeneratePayCodeDetailsModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("generate_paycode_for_egv")]
        public async Task<IActionResult> GeneratePayCodeDetailsForEGV([FromBody] PayCodeGeneratePayCodeDetailsForEGVModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _paycodeRepo.GeneratePayCodeDetailsForEGV(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<PayCodeGeneratePayCodeDetailsForEGVModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<PayCodeGeneratePayCodeDetailsForEGVModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_ccmsbalance_for_paycode_generation")]
        public async Task<IActionResult> CheckCCMSBalanceforPaycodeGeneration([FromBody] CheckCCMSBalanceforPaycodeGenerationModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _paycodeRepo.CheckCCMSBalanceforPaycodeGeneration(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CheckCCMSBalanceforPaycodeGenerationModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<CheckCCMSBalanceforPaycodeGenerationModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_cardno_by_vechileno")]
        public async Task<IActionResult> GetCardNoByVechileNo([FromBody] PayCodeGetCardNoByVechileNoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _paycodeRepo.GetCardNoByVechileNo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<PayCodeGetCardNoByVechileNoModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<PayCodeGetCardNoByVechileNoModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
       [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_cardno_by_mobileno")]
        public async Task<IActionResult> GetCardNoByMobileNo([FromBody] GetCardNoByMobileNoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _paycodeRepo.GetCardNoByMobileNo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetCardNoByMobileNoModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<GetCardNoByMobileNoModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
       [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_paycode_status")]
        public async Task<IActionResult> GetPayCodeStatus([FromBody] GetPayCodeStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _paycodeRepo.GetPayCodeStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetPayCodeStatusModelOutput> item = result.Cast<GetPayCodeStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_paycode_status_details")]
        public async Task<IActionResult> GetPaycodeStatusDetails([FromBody] GetPaycodeStatusDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _paycodeRepo.GetPaycodeStatusDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetPaycodeStatusDetailsModelOutput> item = result.Cast<GetPaycodeStatusDetailsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("cancel_paycode")]
        public async Task<IActionResult> CancelPaycode([FromBody] CancelPaycodeModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _paycodeRepo.CancelPaycode(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CancelPaycodeModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<CancelPaycodeModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("Update_ExpiryDate")]
        public async Task<IActionResult> UpdateExpiryDate([FromBody] UpdateExpiryDateModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _paycodeRepo.UpdateExpiryDate(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateExpiryDateModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateExpiryDateModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }




        //[HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        //[Route("GenerateFuelVoucher")]
        //public async Task<IActionResult> GeneratePayCodeForEGVAPI([FromBody] PayCodeGeneratePayCodeDetailsForEGVAPIWithoutStartDateModelIntput ObjClass)
        //{
        //    if (ObjClass == null)
        //    {
        //        return this.BadRequestCustom(ObjClass, null, _logger);
        //    }
        //    else
        //    {
        //        var result = await _paycodeRepo.GeneratePayCodeForEGVAPI(ObjClass);
        //        if (result == null)
        //        {
        //            return this.NotFoundCustom(ObjClass, null, _logger);
        //        }
        //        if (result.voucherDetails.Count > 0)
        //            return this.OkCustom(ObjClass, result, _logger);
        //        else
        //            return this.Fail(ObjClass, result, _logger);
        //    }
        //}



        //[HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        //[Route("GenerateFuelVoucherWithStartDate")]
        //public async Task<IActionResult> GenerateFuelVoucherWithStartDate([FromBody] PayCodeGeneratePayCodeDetailsForEGVAPIModelInput ObjClass)
        //{
        //    if (ObjClass == null)
        //    {
        //        return this.BadRequestCustom(ObjClass, null, _logger);
        //    }
        //    else
        //    {
        //        var result = await _paycodeRepo.GenerateFuelVoucherWithStartDate(ObjClass);
        //        if (result == null)
        //        {
        //            return this.NotFoundCustom(ObjClass, null, _logger);
        //        }
        //        if (result.voucherDetails.Count > 0)
        //            return this.OkCustom(ObjClass, result, _logger);
        //        else
        //            return this.Fail(ObjClass, result, _logger);
        //    }
        //}




        //[HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        //[Route("GetConsumptionData")]
        //public async Task<IActionResult> GetConsumptionData([FromBody] GetPaycodeStatusDetailsModelInput ObjClass)
        //{
        //    if (ObjClass == null)
        //    {
        //        return this.BadRequestCustom(ObjClass, null, _logger);
        //    }
        //    else
        //    {
        //        var result = await _paycodeRepo.GetConsumptionData(ObjClass);
        //        if (result == null)
        //        {
        //            return this.NotFoundCustom(ObjClass, null, _logger);
        //        }
        //        else
        //        {
        //            List<GetPaycodeStatusDetailsModelOutput> item = result.Cast<GetPaycodeStatusDetailsModelOutput>().ToList();
        //            if (item.Count > 0)
        //                return this.OkCustom(ObjClass, result, _logger);
        //            else
        //                return this.Fail(ObjClass, result, _logger);
        //        }
        //    }
        //}




    }
}
