using CCA.Util;
using HPPay.DataModel.PayEnrollmentFee;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataRepository.PayEnrollmentFee;
using HPPay.DataRepository.SMSGetSend;
using HPPay.Infrastructure.CommonClass;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
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
    [Route("api/dtplus/PayEnrolmentFee")]
    [ApiController]
    public class PayEnrollmentFeeByHDFCController : ControllerBase
    {
        private readonly ILogger<PayEnrollmentFeeByHDFCController> _logger;
        private readonly IPayEnrollmentFeeByHDFCRepository _payHdfcRepo;
        private readonly IConfiguration _configuration;
        private readonly ISMSGetSendRepository _GetSendRepo;
        public PayEnrollmentFeeByHDFCController(ILogger<PayEnrollmentFeeByHDFCController> logger, IPayEnrollmentFeeByHDFCRepository payHdfcRepo, IConfiguration configuration, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _payHdfcRepo = payHdfcRepo;
            _configuration = configuration;
            _GetSendRepo = GetSendRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_details_by_formNo")]
        public async Task<IActionResult> GetDetailsByFormNo([FromBody] GetDetailsByFormNoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _payHdfcRepo.GetDetailsByFormNo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    List<GetDetailsByFormNoModelOutput> item = result.Cast<GetDetailsByFormNoModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_enrolment_fee_amount")]
        public async Task<IActionResult> GetEnrollmentFeeAmount([FromBody] GetEnrollmentFeeAmountInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _payHdfcRepo.GetEnrollmentFeeAmount(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    List<GetEnrollmentFeeAmountOutPut> item = result.Cast<GetEnrollmentFeeAmountOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_enrolment_fee_payment")]
        public async Task<IActionResult> InsertHDFCPGApiRequest([FromBody] InitiateEnrollmentFeeByHDFCModelInput ObjClass)
        {

                if (ObjClass == null)
                {
                    return this.BadRequestCustom(ObjClass, null, _logger);
                }  
                else
                {
                   var res = await _payHdfcRepo.InsertFeeDetailst(ObjClass);
                
                  if (res.Cast<InitiateEnrollmentFeeByHDFCModelOutPut>().ToList()[0].Status == 1)
                  { 
                    Random rn = new Random();
                    var tid = rn.Next();
                    string req = null;
                    //These value will come from appsettings.json file.//
                    string reqerror = _configuration.GetSection("HDFCPG:ErrorUrl").Value;
                    string reqresponse = _configuration.GetSection("HDFCPG:ResponseUrl").Value;                     
                    string ReqTranportalId = _configuration.GetSection("HDFCPG:MerchentId").Value;
                    string order_id = ObjClass.OrderId;
                    string currency = "INR"; decimal amount = ObjClass.Amount; string language = "EN";
                    Dictionary<string, string> objReq = new Dictionary<string, string> { };
                    objReq.Add("tid", tid.ToString());
                    objReq.Add("merchant_id", ReqTranportalId);
                    objReq.Add("currency", currency);
                    objReq.Add("amount", amount.ToString());
                    objReq.Add("order_id", order_id);
                    objReq.Add("language", language);
                    objReq.Add("redirect_url", reqresponse);
                    objReq.Add("cancel_url", reqerror);

                    req = "tid=" + tid + "&cancel_url=" + reqerror + "&currency=" + currency + "&amount=" + amount + "&language=" + language + "&redirect_url=" + reqresponse + "&merchant_id=" + ReqTranportalId + "&order_id=" + order_id + "&";

                    CCACrypto ccaCrypto = new CCACrypto();
                    if (!string.IsNullOrEmpty(req))
                    {
                        req = ccaCrypto.Encrypt(req, _configuration.GetSection("HDFCPG:Key").Value);

                    }
                    InitiateEnrollmentFeeByHDFCModelOutPut initiateCreditPouchRechargeModelOutPut = new InitiateEnrollmentFeeByHDFCModelOutPut();
                    ApiRequestResponse response = new ApiRequestResponse();
                    RechargeLoginResponse CPPGLoginResponse = new RechargeLoginResponse();
                    string apiurl = _configuration.GetSection("HDFCPG:ApiUrl").Value;

                    HttpResponseMessage apiResponse = Variables.CallPostAPI(apiurl + req, JsonConvert.SerializeObject(objReq), "").Result;
                    string json = string.Empty;
                    if (apiResponse.IsSuccessStatusCode)
                    {
                        json = apiResponse.Content.ReadAsStringAsync().Result;
                    }
                    initiateCreditPouchRechargeModelOutPut.OrderId = order_id;
                    response.BankName = "Enrolment Fee";
                    response.apiurl = apiurl;
                    response.request = JsonConvert.SerializeObject(objReq);
                    response.response = json;
                    response.Userid = ObjClass.Userid;
                    response.TransactionId = order_id;
                    response.request_Hash = req;
                    response.Amount = ObjClass.Amount;
                    response.CustomerId = ObjClass.FormNo;
                    response.ControlCardNo = ObjClass.FormNo;
                    response.accessCode = _configuration.GetSection("HDFCPG:accessCode").Value;
                    initiateCreditPouchRechargeModelOutPut.Response = response;
                    response.email = res.Cast<InitiateEnrollmentFeeByHDFCModelOutPut>().ToList()[0].email;
                    response.Mobile = res.Cast<InitiateEnrollmentFeeByHDFCModelOutPut>().ToList()[0].Mobile;
                    //log entry of rqst & rspnce
                   _payHdfcRepo.InsertEnrolFeeHDFGApiRequest(response);

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
                                        getandInsertSendInputModel.CreatedBy = res.Cast<InitiateEnrollmentFeeByHDFCModelOutPut>().ToList()[0].CreatedBy;
                                        getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                        string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                        TemplateMessage = TemplateMessage
                                            .Replace("[OrderId]", res.Cast<InitiateEnrollmentFeeByHDFCModelOutPut>().ToList()[0].OrderId)
                                            .Replace("[Amount]", res.Cast<InitiateEnrollmentFeeByHDFCModelOutPut>().ToList()[0].Amount)
                                            .Replace("[NoofCard]", res.Cast<InitiateEnrollmentFeeByHDFCModelOutPut>().ToList()[0].NoOfCards);

                                        getandInsertSendInputModel.SMSText = TemplateMessage;
                                        getandInsertSendInputModel.MobileNo = res.Cast<InitiateEnrollmentFeeByHDFCModelOutPut>().ToList()[0].Mobile;
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
                                        insertEmailTextEntryInputModel.EmailIdTo = res.Cast<InitiateEnrollmentFeeByHDFCModelOutPut>().ToList()[0].email;
                                        insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                        insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                        insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                        string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                        if (res.Cast<InitiateEnrollmentFeeByHDFCModelOutPut>().ToList()[0].email == "")
                                        {
                                            res.Cast<InitiateEnrollmentFeeByHDFCModelOutPut>().ToList()[0].CreatedBy = insertEmailTextEntryInputModel.EmailIdCC;
                                        }

                                        EmailTemplateMessage = EmailTemplateMessage
                                            .Replace("@OrderId", res.Cast<InitiateEnrollmentFeeByHDFCModelOutPut>().ToList()[0].OrderId)
                                            .Replace("@Amount", res.Cast<InitiateEnrollmentFeeByHDFCModelOutPut>().ToList()[0].Amount)
                                            .Replace("@NoofCard", res.Cast<InitiateEnrollmentFeeByHDFCModelOutPut>().ToList()[0].NoOfCards);

                                        insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
                                        insertEmailTextEntryInputModel.CreatedBy = res.Cast<InitiateEnrollmentFeeByHDFCModelOutPut>().ToList()[0].CreatedBy;
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
                    return this.OkCustom(ObjClass, initiateCreditPouchRechargeModelOutPut, _logger);
                  }
                return this.Fail(ObjClass, res, _logger);

            }
               
        }

    }
}
