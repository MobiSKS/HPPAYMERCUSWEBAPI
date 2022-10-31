using HPPay.DataModel.HDFCPG;
using HPPay.DataModel.PayU;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataRepository.PayU;
using HPPay.DataRepository.SMSGetSend;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [Route("api/dtplus/PayU")]
    [ApiController]
    public class PayUController : ControllerBase
    {
        private readonly ILogger<PayUController> _logger;
        private readonly IPayURepository _payURepo;
        private readonly IConfiguration _configuration;
        private readonly ISMSGetSendRepository _GetSendRepo;
        public PayUController(ILogger<PayUController> logger, IPayURepository payURepo, IConfiguration configuration, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _payURepo = payURepo;
            _configuration = configuration;
            _GetSendRepo = GetSendRepo;
        }
        [HttpPost]
       // [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("initiate_payU_payment")]
        public async Task<IActionResult> InitiatePayUPaymentRequest([FromBody] InitiatePayUPaymentGatewayModelInput ObjClass)
        {
            PayUPaymentGatewayModelOutPut responseObj = new PayUPaymentGatewayModelOutPut();
            decimal MinAmt = Convert.ToDecimal(_configuration.GetSection("RechargeSettings:MinimumAmount").Value);
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else if(MinAmt > ObjClass.Amount)
            {
                responseObj.Status = 0;
                responseObj.Reason = "Minimum amount should be " + _configuration.GetSection("RechargeSettings:MinimumAmount").Value;
                return this.OkCustom(ObjClass, responseObj, _logger);
            }
            else
            {
                var rslts = _payURepo.GetCustomerDetailsForRecharge(ObjClass).Result;
                if (rslts.Cast<PayUPaymentGatewayModelOutPut>().ToList()[0].Status == 1)
                {
                    string TId = _configuration.GetSection("PayU:TId").Value;
                    string key = _configuration.GetSection("PayU:key").Value;
                    string salt = _configuration.GetSection("PayU:salt").Value;
                    string surl = _configuration.GetSection("PayU:ResponseUrl").Value;
                    string productinfo = "HPPay";
                    string firstname = rslts.Cast<PayUPaymentGatewayModelOutPut>().ToList()[0].firstname;
                    string email = rslts.Cast<PayUPaymentGatewayModelOutPut>().ToList()[0].email; 
                    string txnid = RandomDigits(10);
                    string udf1 = productinfo;
                    string udf2 = email;
                    string udf3 = rslts.Cast<PayUPaymentGatewayModelOutPut>().ToList()[0].phone;
                    string udf4 = rslts.Cast<PayUPaymentGatewayModelOutPut>().ToList()[0].firstname;
                    string udf5 = txnid; 
                    string hashKeyForToken = SHA512(key+"|"+txnid + "|" + ObjClass.Amount + "|" + productinfo + "|" + firstname + "|" + email + "|||||||||||" + salt);

                    
                    responseObj.hash = hashKeyForToken.ToLower();
                    responseObj.salt = salt;
                    responseObj.Key = key;
                    responseObj.txnid = txnid;
                    responseObj.firstname = rslts.Cast<PayUPaymentGatewayModelOutPut>().ToList()[0].firstname;
                    responseObj.lastname = rslts.Cast<PayUPaymentGatewayModelOutPut>().ToList()[0].lastname;
                    responseObj.email = rslts.Cast<PayUPaymentGatewayModelOutPut>().ToList()[0].email;
                    responseObj.Amount = ObjClass.Amount.ToString();
                    responseObj.phone = rslts.Cast<PayUPaymentGatewayModelOutPut>().ToList()[0].phone;
                    responseObj.productinfo = "HPPay Fuel";
                    responseObj.surl = surl;
                    responseObj.furl = surl;
                    responseObj.Status = 1;
                    responseObj.Reason = "Success";
                    responseObj.payLoad = "firstname=" + rslts.Cast<PayUPaymentGatewayModelOutPut>().ToList()[0].firstname +
                        "&lastname=" + rslts.Cast<PayUPaymentGatewayModelOutPut>().ToList()[0].lastname +
                        "&surl=" + surl + "&phone=" + rslts.Cast<PayUPaymentGatewayModelOutPut>().ToList()[0].phone +
                        "&key=" + key + "&hash=" + hashKeyForToken + "&curl=" + surl + "&furl=" + surl +
                        "&txnid=" + txnid + "&productinfo=" + responseObj.productinfo +
                        "&email=" + rslts.Cast<PayUPaymentGatewayModelOutPut>().ToList()[0].email +
                        "&udf1="+ udf1+ "&udf2=" + udf2 + "&udf3=" + udf3 + "&udf4=" + udf4 + "&udf5=" + udf5;

                    responseObj.redirectToUrl= _configuration.GetSection("PayU:ApiUrl").Value;

                    PayUApiRequestResponse payUApiRequestResponse = new PayUApiRequestResponse();
                    payUApiRequestResponse.Amount = Convert.ToDecimal(responseObj.Amount);
                    payUApiRequestResponse.request = responseObj.payLoad;
                    payUApiRequestResponse.BankName = "PayU";
                    payUApiRequestResponse.OrderId = responseObj.txnid;
                    payUApiRequestResponse.TransactionId= responseObj.txnid;
                    payUApiRequestResponse.CustomerId = ObjClass.CustomerId;
                    payUApiRequestResponse.apiurl= _configuration.GetSection("PayU:ApiUrl").Value;
                    payUApiRequestResponse.ActionType = "Add";

                    _payURepo.InsertPayUApiRequestResponse(payUApiRequestResponse);

                    return this.OkCustom(ObjClass, responseObj, _logger);
                }
                else
                {
                    return this.NotFoundCustom(ObjClass, rslts, _logger);
                }
            } 
        }
        
        [HttpPost]
        public static string SHA512(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }

        [HttpPost]
        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_payU_pg_response")]
        public async Task<IActionResult> PayUGetPGResponse([FromBody] PayUResponse ObjClass)

        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                //PayUResponse results = new PayUResponse();
                //string ResponseString = ObjClass.responseString;
                //ObjClass = JsonConvert.DeserializeObject<PayUResponse>(ResponseString);
                //ObjClass.responseString = ResponseString; 
                ObjClass.ActionType = "Update";
                ObjClass.TrnsSource = "PayU";
                var result = await _payURepo.PayUGetPGResponse(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].Status == 1)
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
                                                .Replace("[TrackId]", result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].orderId)
                                                .Replace("[TrasncationInitiatedDate]", result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].TransactionDate)
                                                .Replace("[TrasncationInitiatedTime]", result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].TransactionTime)
                                                .Replace("[RechargeAmount]", result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].RechargeAmount)
                                                .Replace("[Balance]", result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].Balance);

                                            getandInsertSendInputModel.SMSText = TemplateMessage;
                                            getandInsertSendInputModel.MobileNo = result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].mobile;
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

                                            if (result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].email == "")
                                            {
                                                result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].CreatedBy = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage
                                                .Replace("@TrackId", result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].orderId)
                                                .Replace("@TrasncationInitiatedDate", result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].TransactionDate)
                                                .Replace("@TrasncationInitiatedTime", result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].TransactionTime)
                                                .Replace("@RechargeAmount", result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].RechargeAmount)
                                                .Replace("@Balance", result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].Balance);

                                            insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
                                            insertEmailTextEntryInputModel.CreatedBy = result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].CreatedBy;
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
                        if (result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].mobile != null)
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
                                                    .Replace("[TrackId]", result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].orderId)
                                                    .Replace("[TrasncationInitiatedDate]", result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].TransactionDate)
                                                    .Replace("[TrasncationInitiatedTime]", result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].TransactionTime)
                                                    .Replace("[Balance]", result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].Balance);

                                                getandInsertSendInputModel.SMSText = TemplateMessage;
                                                getandInsertSendInputModel.MobileNo = result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].mobile;
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
                                                insertEmailTextEntryInputModel.EmailIdTo = result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].email;
                                                insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                                insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                                insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                                string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                                if (result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].email == "")
                                                {
                                                    result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].CreatedBy = insertEmailTextEntryInputModel.EmailIdCC;
                                                }

                                                EmailTemplateMessage = EmailTemplateMessage
                                                    .Replace("@TrackId", result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].orderId)
                                                    .Replace("@TrasncationInitiatedDate", result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].TransactionDate)
                                                    .Replace("@TrasncationInitiatedTime", result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].TransactionTime)
                                                    .Replace("@Balance", result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].Balance);

                                                insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
                                                insertEmailTextEntryInputModel.CreatedBy = result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].CreatedBy;
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
                            result.Cast<GetPayUPGResponseModelOutput>().ToList()[0].Reason);
                    }
                }
            }
             
        }


    }

}

