using HPPay.DataModel.HDFCPG;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataRepository.HDFCPG;
using HPPay.DataRepository.SMSGetSend;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [Route("api/dtplus/PGHDFC")]
    [ApiController]
    public class PGHDFCController : ControllerBase
    {
        private readonly ILogger<PGHDFCController> _logger;
        private readonly IHDFCPGRepository _pghdfcRepo;
        private readonly IConfiguration _configuration;
        private readonly ISMSGetSendRepository _GetSendRepo;
        public PGHDFCController(ILogger<PGHDFCController> logger, IHDFCPGRepository pghdfcRepo, IConfiguration configuration, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _pghdfcRepo = pghdfcRepo;
            _configuration = configuration;
            _GetSendRepo = GetSendRepo;
        }

        

       [HttpPost]
       [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_hdfc_pg_enc_response")]
        public async Task<IActionResult> HDFCGetPGEncResponse([FromBody] GetHDFCPGEncResponseModelInput ObjClass)
        
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var PGRes = _pghdfcRepo.DecryptResponse(ObjClass);

                var result = await _pghdfcRepo.GetHDFCPGResponse(PGRes);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].Status == 1 )
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
                                    if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSEmailStatus == "1" && result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].mobile != null)
                                    {

                                        if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                                        {
                                            GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                                            getandInsertSendInputModel.CreatedBy = result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].CreatedBy;
                                            getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                            string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                            TemplateMessage = TemplateMessage
                                                .Replace("[TrackId]", result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].orderId)
                                                .Replace("[TrasncationInitiatedDate]", result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].TransactionDate)
                                                .Replace("[TrasncationInitiatedTime]", result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].TransactionTime)
                                                .Replace("[RechargeAmount]", result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].RechargeAmount)
                                                .Replace("[Balance]", result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].Balance);

                                            getandInsertSendInputModel.SMSText = TemplateMessage;
                                            getandInsertSendInputModel.MobileNo = result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].mobile;
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
                                            insertEmailTextEntryInputModel.EmailIdTo = result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].email;
                                            insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                            insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                            insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                            string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                            if (result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].email == "")
                                            {
                                                result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].CreatedBy = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage
                                                .Replace("@TrackId", result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].orderId)
                                                .Replace("@TrasncationInitiatedDate", result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].TransactionDate)
                                                .Replace("@TrasncationInitiatedTime", result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].TransactionTime)
                                                .Replace("@RechargeAmount", result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].RechargeAmount)
                                                .Replace("@Balance", result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].Balance);

                                            insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
                                            insertEmailTextEntryInputModel.CreatedBy = result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].CreatedBy;
                                            await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
                                        }
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
                        if (result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].mobile != null)
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
                                        if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSEmailStatus == "0")
                                        {

                                            if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                                            {
                                                GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                                                getandInsertSendInputModel.CreatedBy = result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].CreatedBy;
                                                getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                                string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                                TemplateMessage = TemplateMessage
                                                    .Replace("[TrackId]", result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].orderId)
                                                    .Replace("[TrasncationInitiatedDate]", result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].TransactionDate)
                                                    .Replace("[TrasncationInitiatedTime]", result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].TransactionTime)
                                                    .Replace("[Balance]", result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].Balance);

                                                getandInsertSendInputModel.SMSText = TemplateMessage;
                                                getandInsertSendInputModel.MobileNo = result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].mobile;
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
                                                insertEmailTextEntryInputModel.EmailIdTo = result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].email;
                                                insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                                insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                                insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                                string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                                if (result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].email == "")
                                                {
                                                    result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].CreatedBy = insertEmailTextEntryInputModel.EmailIdCC;
                                                }

                                                EmailTemplateMessage = EmailTemplateMessage
                                                    .Replace("@TrackId", result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].orderId)
                                                    .Replace("@TrasncationInitiatedDate", result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].TransactionDate)
                                                    .Replace("@TrasncationInitiatedTime", result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].TransactionTime)
                                                    .Replace("@Balance", result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].Balance);

                                                insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
                                                insertEmailTextEntryInputModel.CreatedBy = result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].CreatedBy;
                                                await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ControllerContext.ActionDescriptor.ActionName + " :: Email and SMS Error :" + ex.Message);
                            }
                        }
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<GetHDFCPGResponseModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_hdfc_payment_status")]
        public async Task<IActionResult> GetHDFCPaymentStatus([FromBody] GetHDFCPaymentStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _pghdfcRepo.GetHDFCPaymentStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetHDFCPaymentStatusModelOutput> item = result.Cast<GetHDFCPaymentStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

    }

}

