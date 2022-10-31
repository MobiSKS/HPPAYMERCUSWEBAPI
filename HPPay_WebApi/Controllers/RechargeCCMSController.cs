using AutoMapper.Execution;
using CCA.Util;
using HPPay.DataModel.HDFCCreditPouch;
using HPPay.DataModel.RechargeCCMS;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataModel.Transaction;
using HPPay.DataRepository.RechargeCCMS;
using HPPay.DataRepository.SMSGetSend;
using HPPay.Infrastructure.CommonClass;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/dtplus/RechargeCCMS")]
    public class RechargeCCMSController : ControllerBase
    {
        private readonly ILogger<RechargeCCMSController> _logger;
        private readonly IRechargeCCMSRepository _rechargeCCMSRepo;
        private readonly IConfiguration _configuration;
        private readonly ISMSGetSendRepository _GetSendRepo;

        public RechargeCCMSController(ILogger<RechargeCCMSController> logger, IRechargeCCMSRepository rechargeCCMSRepo, IConfiguration configuration, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _rechargeCCMSRepo = rechargeCCMSRepo;
            _configuration = configuration;
            _GetSendRepo = GetSendRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_details")]
        public async Task<IActionResult> InitiateRechargeCCMS([FromBody] GetDetailsRechargeCCMSModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _rechargeCCMSRepo.InitiateRechargeCCMS(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDetailsRechargeCCMSModelOutPut> item = result.Cast<GetDetailsRechargeCCMSModelOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("GetDetailsForRechargeCCMS")]
        public async Task<IActionResult> GetDetailsForRechargeCCMS([FromBody] InitiateRechargeCCMSModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _rechargeCCMSRepo.GetDetailsForRechargeCCMS(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<InitiateRechargeCCMSModelOutPut> item = result.Cast<InitiateRechargeCCMSModelOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("init_ccms_recharge")]
        public async Task<IActionResult> HDFCInitiateRechargeCCMSInsert([FromBody] InitiateRechargeCCMSModelInput ObjClass)
        {
            bool possitive= ObjClass.Amount > 0;
            InitiateCreditPouchRechargeModelOutPut initiateCreditPouchRechargeModelOutPut = new InitiateCreditPouchRechargeModelOutPut();
            decimal MinAmt = Convert.ToDecimal(_configuration.GetSection("RechargeSettings:MinimumAmount").Value);
            if (MinAmt > ObjClass.Amount)
            {
                initiateCreditPouchRechargeModelOutPut.Status = 0;
                initiateCreditPouchRechargeModelOutPut.Reason = "Minimum amount should be " + _configuration.GetSection("RechargeSettings:MinimumAmount").Value;
                return this.OkCustom(ObjClass, initiateCreditPouchRechargeModelOutPut, _logger);
            }
            else if (possitive)
            {
                string order_id;
                var rslts = _rechargeCCMSRepo.GetDetailsForRechargeCCMS(ObjClass).Result;

                if (rslts.Cast<InitiateRechargeCCMSModelOutPut>().ToList()[0].Status == 1)
                {
                    Random rn = new Random();
                    var tid = rn.Next();
                    CCMSApiRequestResponse InitResponse = new CCMSApiRequestResponse();
                    InitResponse.BankName = "HDFC CCMS";
                    InitResponse.UserId = ObjClass.Userid;
                    InitResponse.TransactionId = tid.ToString();
                    InitResponse.Amount = ObjClass.Amount;
                    InitResponse.CustomerId = ObjClass.CustomerId;
                    InitResponse.ControlCardNo = ObjClass.ControlCardNo;
                    InitResponse.accessCode = _configuration.GetSection("HDFCPG:accessCode").Value;
                    InitResponse.request = "tid=" + tid + "&cancel_url=" + "&amount=" + ObjClass.Amount + "&order_id=" + tid + "&";
                    InitResponse.ActionType = "Add";
                    InitResponse.TrnsSource = "HDFC Bank - CCAvenue";
                    InitResponse.SourceId = Convert.ToInt32(rslts.Cast<InitiateRechargeCCMSModelOutPut>().ToList()[0].Response.SourceId);
                    InitResponse.Formfactor = Convert.ToInt32(rslts.Cast<InitiateRechargeCCMSModelOutPut>().ToList()[0].Response.Formfactor);
                    InitResponse.MerchantId = rslts.Cast<InitiateRechargeCCMSModelOutPut>().ToList()[0].Response.MerchantId;
                    InitResponse.TerminalId = rslts.Cast<InitiateRechargeCCMSModelOutPut>().ToList()[0].Response.TerminalId;
                    _rechargeCCMSRepo.InsertRechargeCCMSApiRequestResponse(InitResponse);
                    string req = null;
                    string reqerror = _configuration.GetSection("HDFCPG:ErrorUrl").Value;
                    string reqresponse = _configuration.GetSection("HDFCPG:ResponseUrl").Value;
                    string ReqTranportalId = _configuration.GetSection("HDFCPG:MerchentId").Value;
                    order_id = tid.ToString();
                    string currency = "INR"; decimal amount = ObjClass.Amount; string language = "EN";

                    Dictionary<string, string> objReq = new Dictionary<string, string> { };
                    objReq.Add("tid", tid.ToString());
                    objReq.Add("merchant_id", ReqTranportalId);
                    objReq.Add("currency", currency);
                    objReq.Add("amount", amount.ToString());
                    objReq.Add("order_id", order_id.ToString());
                    objReq.Add("language", language);
                    objReq.Add("redirect_url", reqresponse);
                    objReq.Add("cancel_url", reqerror);
                    objReq.Add("customer_id", ObjClass.CustomerId);
                    objReq.Add("card_no", ObjClass.ControlCardNo);

                    req = "tid=" + tid + "&cancel_url=" + reqerror + "&currency=" + currency + "&amount=" + amount + "&language=" + language + "&redirect_url=" + reqresponse + "&merchant_id=" + ReqTranportalId + "&order_id=" + order_id + "&";


                    CCACrypto ccaCrypto = new CCACrypto();
                    if (!string.IsNullOrEmpty(req))
                    {
                        req = ccaCrypto.Encrypt(req, _configuration.GetSection("HDFCPG:Key").Value);

                    }
                    //------------------------------------------------------
                    InitiateRechargeCCMSModelOutPut initiateRechargeCCMSModelOutPut = new InitiateRechargeCCMSModelOutPut();
                    CCMSApiRequestResponse response = new CCMSApiRequestResponse();
                    CCMSRechargeLoginResponse CPPGLoginResponse = new CCMSRechargeLoginResponse();
                    string apiurl = _configuration.GetSection("HDFCPG:ApiUrl").Value;

                    HttpResponseMessage apiResponse = Variables.CallPostAPI(apiurl + req, JsonConvert.SerializeObject(objReq), "").Result;
                    string json = string.Empty;

                    if (apiResponse.IsSuccessStatusCode)
                    {
                        json = apiResponse.Content.ReadAsStringAsync().Result;
                    }
                    initiateRechargeCCMSModelOutPut.OrderId = order_id;
                    initiateRechargeCCMSModelOutPut.Status = 1;
                    initiateRechargeCCMSModelOutPut.Reason = "Success";
                    response.BankName = "HDFC CCMS";
                    response.apiurl = apiurl;
                    response.request = JsonConvert.SerializeObject(objReq);
                    response.response = json;
                    response.TransactionId = order_id;
                    response.request_Hash = req;
                    response.accessCode = _configuration.GetSection("HDFCPG:accessCode").Value;
                    response.CustomerId = ObjClass.CustomerId;
                    response.Amount = ObjClass.Amount;
                    response.ControlCardNo = ObjClass.ControlCardNo;
                    response.ActionType = "Update";
                    initiateRechargeCCMSModelOutPut.Response = response;
                    //log entry of rqst & rspnce
                    _rechargeCCMSRepo.InsertRechargeCCMSApiRequestResponse(response);
                    return this.OkCustom(ObjClass, initiateRechargeCCMSModelOutPut, _logger);

                }
                else if (rslts.Cast<InitiateRechargeCCMSModelOutPut>().ToList()[0].Status == 0)
                {
                    return this.OkCustom(ObjClass, rslts, _logger);
                }
                else
                {
                    return this.OkCustom(ObjClass, rslts, _logger);
                }
            }
            else
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("recharge_ccms_account")]
        public async Task<IActionResult> RechargeCCMSAccount([FromBody] CCMSRechargeCCMSAccountModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _rechargeCCMSRepo.RechargeCCMSAccount(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CCMSRechargeCCMSAccountModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<CCMSRechargeCCMSAccountModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("generate_ccms_otp")]
        public async Task<IActionResult> CCMSGenerateOTP([FromBody] WebGenerateOTPModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _rechargeCCMSRepo.CCMSGenerateOTP(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<WebGenerateOTPModelOutput>().ToList()[0].Status == 1)
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
                                    if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSEmailStatus == "1")
                                    {

                                        if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                                        {
                                            GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                                            getandInsertSendInputModel.CreatedBy = ObjClass.Userid;
                                            getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                            string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                            TemplateMessage = TemplateMessage
                                                .Replace("[OTP]", result.Cast<WebGenerateOTPModelOutput>().ToList()[0].OTP)
                                                .Replace("[Amount]", ObjClass.Amount.ToString());

                                            getandInsertSendInputModel.SMSText = TemplateMessage;
                                            getandInsertSendInputModel.MobileNo = ObjClass.Mobileno;
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
                                            string ZOROEmaild = string.Empty;
                                            string EmailId = null;
                                            InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                            insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                                            insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                                            insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                                            insertEmailTextEntryInputModel.EmailIdTo = EmailId;
                                            insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                            insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                            insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                            string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                            //if (EmailId == "")
                                            //{
                                            //    ObjClass.Uemserid = insertEmailTextEntryInputModel.EmailIdCC;
                                            //}

                                            EmailTemplateMessage = EmailTemplateMessage
                                                .Replace("@OTP", result.Cast<WebGenerateOTPModelOutput>().ToList()[0].OTP)
                                                .Replace("@Amount", ObjClass.Amount.ToString());

                                            insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
                                            insertEmailTextEntryInputModel.CreatedBy = ObjClass.Userid;
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
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<WebGenerateOTPModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("ccms_confirm_otp")]
        public async Task<IActionResult> CCMSConfirmOTP([FromBody] CCMSConfirmOTPModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _rechargeCCMSRepo.CCMSConfirmOTP(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CCMSConfirmOTPModelOutPut> item = result.Cast<CCMSConfirmOTPModelOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

    }
}
