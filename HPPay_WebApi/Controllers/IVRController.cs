using HPPay.DataModel.IVR;
using HPPay.DataModel.JCB;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataModel.Transaction;
using HPPay.DataModel.UserManage;
using HPPay.DataRepository.IVR;
using HPPay.DataRepository.SMSGetSend;
using HPPay.DataRepository.Transaction;
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
    [ApiController]
    [Route("/api/dtplus/IVR")]
    public class IVRController : Controller
    {
        private readonly ILogger<IVRController> _logger;
        private readonly IIVRCustomerRepository _IVRCustRepo;
        private readonly IIVRDriverRepository _IVRDriverRepo;
        private readonly ISMSGetSendRepository _GetSendRepo;
        private readonly IConfiguration _configuration;


        public IVRController(ILogger<IVRController> logger, IIVRCustomerRepository ivrcustRepo, IIVRDriverRepository ivrDriverRepo, ISMSGetSendRepository GetSendRepo, IConfiguration configuration)
        {
            _logger = logger;
            _IVRCustRepo = ivrcustRepo;
            _IVRDriverRepo = ivrDriverRepo;
            _GetSendRepo = GetSendRepo;
            _configuration = configuration;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("validate_customercontrolcard")]
        public async Task<IActionResult> ValidateCustomerControlCard([FromBody] ValidateCustomerConrolCardInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _IVRCustRepo.ValidateCustomerControlCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ValidateCustomerControlCardOutput> item = result.Cast<ValidateCustomerControlCardOutput>().ToList();
                    if (item.Count > 0)
                    {
                        //Security Token Code goes here
                        if (!string.IsNullOrEmpty(ObjClass.ControlCardPIN) || !(ObjClass.ControlCardPIN == "string"))
                        {
                            string SecurityToken = item[0].SecurityToken.ToString();
                            var Tokenresult = await _IVRCustRepo.InsertUpdateIVRSecurityToken(SecurityToken);
                            return this.OkCustom(ObjClass, Tokenresult, _logger);
                        }
                        else
                        {
                            return this.OkCustom(ObjClass, result, _logger);
                        }
                    }
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("validate_customermobile")]
        public async Task<IActionResult> ValidateCustomerMobile([FromBody] ValidateCustomerMobileInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _IVRCustRepo.ValidateCustomerMobile(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ValidateCustomerMobileOutput> items = result.Cast<ValidateCustomerMobileOutput>().ToList();
                    if (items.Count > 0)
                    {
                        if (ObjClass.ValidationMode == "GenerateOTP")
                        {
                            var GenOTPResult = await _IVRCustRepo.GenerateIVROTP(ObjClass);
                            if (GenOTPResult == null)
                            {
                                return this.NotFoundCustom(ObjClass, null, _logger);
                            }
                            else
                            {
                                //Generate OTP
                                try
                                {
                                    GetSMSValueInputModel ObjSMSValue = new GetSMSValueInputModel();
                                    ObjSMSValue.MethodName = "GenerateIVROTP";
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
                                                    getandInsertSendInputModel.CreatedBy = "IVR";
                                                    getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                                    string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                                    TemplateMessage = TemplateMessage.Replace("@OTP",
                                                        GenOTPResult.Cast<ValidateCustomerMobileOutput>().ToList()[0].OTP.ToString());

                                                    getandInsertSendInputModel.SMSText = TemplateMessage;
                                                    getandInsertSendInputModel.MobileNo = ObjClass.MobileNumber.ToString();
                                                    getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo;
                                                    getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateName;
                                                    //getandInsertSendInputModel.Userip = ObjClass.Userip;
                                                    getandInsertSendInputModel.Userid = _configuration.GetSection("IVR:Userid").Value;
                                                    getandInsertSendInputModel.Useragent = _configuration.GetSection("IVR:Useragent").Value;
                                                    getandInsertSendInputModel.SenderId = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SenderId;
                                                    getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSAPIURL;
                                                    await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);
                                                }
                                            }
                                        }
                                    }
                                    else
                                        return this.Fail(ObjClass, SMSResult, _logger);
                                }
                                catch (Exception ex)
                                {
                                    _logger.LogError(ControllerContext.ActionDescriptor.ActionName + " :: SMS Error :" + ex.Message);
                                }                                
                            }
                        }
                        else
                        if (ObjClass.ValidationMode == "ValidateOTP")
                        {
                            try
                            {
                                var ValOTPResult = await _IVRCustRepo.ValidateIVROTP(ObjClass);
                                if (ValOTPResult == null)
                                {
                                    return this.NotFoundCustom(ObjClass, null, _logger);
                                }
                                //Security Token Code goes here
                                if (!string.IsNullOrEmpty(ObjClass.OTP) || !(ObjClass.OTP == "string"))
                                {
                                    string SecurityToken = items[0].SecurityToken.ToString();
                                    var Tokenresult = await _IVRCustRepo.InsertUpdateIVRSecurityToken(SecurityToken);
                                    if (Tokenresult == null)
                                        return this.OkCustom(ObjClass, Tokenresult, _logger);
                                    else
                                        return this.Fail(ObjClass, Tokenresult, _logger);
                                }                                    
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ControllerContext.ActionDescriptor.ActionName + " :: OTP Validation Error :" + ex.Message);
                            }
                        }
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_ccmsbalanceinquiry")]
        public async Task<IActionResult> CustomerCCMSBalanceInquiry([FromBody] CustomerCCMSBalanceInquiryInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _IVRCustRepo.CustomerCCMSBalanceInquiry(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerCCMSBalanceInquiryOutput> item = result.Cast<CustomerCCMSBalanceInquiryOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_resetpassword")]
        public async Task<IActionResult> CustomerResetPassword([FromBody] CustomerResetPasswordInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _IVRCustRepo.CustomerResetPassword(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerResetPasswordOutput> item = result.Cast<CustomerResetPasswordOutput>().ToList();
                    if (item.Count > 0)
                    {
                        //
                        GetSMSValueInputModel ObjSMSValue = new GetSMSValueInputModel();
                        ObjSMSValue.MethodName = ControllerContext.ActionDescriptor.ActionName;
                        var SMSResult = await _GetSendRepo.GetSMSValue(ObjSMSValue);
                        if (SMSResult != null)
                        {
                            List<GetSMSValueOutputModel> item1 = SMSResult.Cast<GetSMSValueOutputModel>().ToList();
                            for (int i = 0; i < item1.Count; i++)
                            {
                                if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSEmailStatus == "1")
                                {
                                    if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                                    {
                                        GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                                        getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                        string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;                                        
                                        getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");
                                        getandInsertSendInputModel.MobileNo = ObjClass.CustomerIdentifier.ToString();
                                        getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateName;
                                        //getandInsertSendInputModel.Userip = ObjClass.Userip;
                                        getandInsertSendInputModel.Userid = _configuration.GetSection("IVR:Userid").Value;
                                        getandInsertSendInputModel.Useragent = _configuration.GetSection("IVR:Useragent").Value;
                                        getandInsertSendInputModel.SenderId = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SenderId;
                                        getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSAPIURL;
                                        await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);

                                    }
                                }
                                if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailStatus == 1)
                                {
                                    string ZOROEmaild = String.Empty;
                                    InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                    insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                                    insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                                    insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                                    insertEmailTextEntryInputModel.EmailIdTo = "";
                                    insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                    insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                    insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                    string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;
                                    insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");                                    
                                    await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
                                }
                            }
                        }
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_blockunblockcard")]
        public async Task<IActionResult> CustomerBlockUnblockCard([FromBody] CustomerBlockUnblockCardInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _IVRCustRepo.CustomerBlockUnblockCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerBlockUnblockCardOutput> item = result.Cast<CustomerBlockUnblockCardOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        
        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_resetcardpin")]
        public async Task<IActionResult> CustomerResetCardPin([FromBody] CustomerResetCardPinInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _IVRCustRepo.CustomerResetCardPin(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerResetCardPinOutput> item = result.Cast<CustomerResetCardPinOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_resetcontrolcardpin")]
        public async Task<IActionResult> CustomerResetControlCardPin([FromBody] CustomerResetControlCardPinInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _IVRCustRepo.CustomerResetControlCardPin(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerResetControlCardPinOutput> item = result.Cast<CustomerResetControlCardPinOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_loyaltyredemption")]
        public async Task<IActionResult> CustomerLoyaltyRedemption([FromBody] CustomerloyaltyRedemptionInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _IVRCustRepo.CustomerLoyaltyRedemption(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerLoyaltyRedemptionOutput> item = result.Cast<CustomerLoyaltyRedemptionOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_starrewards")]
        public async Task<IActionResult> CustomerStarRewards([FromBody] CustomerStarRewardsInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _IVRCustRepo.CustomerStarRewards(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerStarRewardsOutput> item = result.Cast<CustomerStarRewardsOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_generatestatement")]
        public async Task<IActionResult> CustomerGenerateStatement([FromBody] CustomerGenerateStatementInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _IVRCustRepo.CustomerGenerateStatement(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerGenerateStatementOutput> item = result.Cast<CustomerGenerateStatementOutput>().ToList();
                    if (item.Count > 0)
                    {
                        GetSMSValueInputModel ObjSMSValue = new GetSMSValueInputModel();
                        ObjSMSValue.MethodName = "CustomerGenerateStatement";
                        var SMSResult = await _GetSendRepo.GetSMSValue(ObjSMSValue);
                        if (SMSResult != null)
                        {
                            List<GetSMSValueOutputModel> item1 = SMSResult.Cast<GetSMSValueOutputModel>().ToList();
                            for (int i = 0; i < item1.Count; i++)
                            {
                                if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailStatus == 1)
                                {
                                    string ZOROEmaild = String.Empty;
                                    InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                    insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                                    insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                                    insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                                    insertEmailTextEntryInputModel.EmailIdTo = result.Cast<CustomerGenerateStatementOutput>().ToList()[0].Email;
                                    insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                    insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                    insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                    string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;
                                    EmailTemplateMessage = EmailTemplateMessage.Replace("@UserName", "IVR");                                   
                                    insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
                                    insertEmailTextEntryInputModel.CreatedBy = "IVRUser";
                                    await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
                                }
                            }
                        }
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("validate_driver_cardpin")]
        public async Task<IActionResult> ValidateDriverCardPin([FromBody] ValidateDriverCardPinInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _IVRDriverRepo.ValidateDriverCardPin(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ValidateDriverCardPinOutput> item = result.Cast<ValidateDriverCardPinOutput>().ToList();
                    if (item.Count > 0)
                    {
                        //Security Token Code goes here
                        if (!string.IsNullOrEmpty(ObjClass.DriverCardPIN) || !(ObjClass.DriverCardPIN == "string"))
                        {
                            string SecurityToken = item[0].SecurityToken.ToString();
                            var Tokenresult = await _IVRCustRepo.InsertUpdateIVRSecurityToken(SecurityToken);
                            return this.OkCustom(ObjClass, Tokenresult, _logger);
                        }
                        else
                        {
                            return this.OkCustom(ObjClass, result, _logger);
                        }
                    }
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("validate_driver_mobilenumber")]
        public async Task<IActionResult> ValidateDriverMobileNumber([FromBody] ValidateDriverMobileNumberInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _IVRDriverRepo.ValidateDriverMobileNumber(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ValidateDriverMobileNumberOutput> item = result.Cast<ValidateDriverMobileNumberOutput>().ToList();
                    if (item.Count > 0)
                    {
                        if (ObjClass.ValidationMode == "GenerateOTP")
                        {
                            var GenOTPResult = await _IVRCustRepo.GenerateIVROTP(ObjClass);
                            if (GenOTPResult == null)
                            {
                                return this.NotFoundCustom(ObjClass, null, _logger);
                            }
                            else
                            {
                                //Generate OTP
                                try
                                {
                                    GetSMSValueInputModel ObjSMSValue = new GetSMSValueInputModel();
                                    ObjSMSValue.MethodName = "GenerateIVROTP";
                                    var SMSResult = await _GetSendRepo.GetSMSValue(ObjSMSValue);
                                    if (SMSResult != null)
                                    {
                                        List<GetSMSValueOutputModel> item1 = SMSResult.Cast<GetSMSValueOutputModel>().ToList();
                                        for (int i = 0; i < item1.Count; i++)
                                        {
                                            if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSEmailStatus == "1")
                                            {
                                                if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                                                {
                                                    GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                                                    getandInsertSendInputModel.CreatedBy = "IVR";
                                                    getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                                    string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                                    TemplateMessage = TemplateMessage.Replace("@OTP",
                                                        GenOTPResult.Cast<ValidateCustomerMobileOutput>().ToList()[0].OTP.ToString());

                                                    getandInsertSendInputModel.SMSText = TemplateMessage;
                                                    getandInsertSendInputModel.MobileNo = ObjClass.MobileNumber.ToString();
                                                    getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo;
                                                    getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateName;
                                                    //getandInsertSendInputModel.Userip = ObjClass.Userip;
                                                    getandInsertSendInputModel.Userid = _configuration.GetSection("IVR:Userid").Value;
                                                    getandInsertSendInputModel.Useragent = _configuration.GetSection("IVR:Useragent").Value;
                                                    getandInsertSendInputModel.SenderId = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SenderId;
                                                    getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSAPIURL;
                                                    await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);
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
                        }
                        else
                        if (ObjClass.ValidationMode == "ValidateOTP")
                        {
                            var GenOTPResult = await _IVRCustRepo.ValidateIVROTP(ObjClass);
                            if (GenOTPResult == null)
                            {
                                return this.NotFoundCustom(ObjClass, null, _logger);
                            }
                            //Security Token Code goes here
                            if (!string.IsNullOrEmpty(ObjClass.OTP) || !(ObjClass.OTP == "string"))
                            {
                                string SecurityToken = item[0].SecurityToken.ToString();
                                var Tokenresult = await _IVRCustRepo.InsertUpdateIVRSecurityToken(SecurityToken);
                                if (Tokenresult == null)
                                    return this.OkCustom(ObjClass, Tokenresult, _logger);
                                else
                                    return this.Fail(ObjClass, Tokenresult, _logger);
                            }
                        }
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("driver_checkcardbalance")]
        public async Task<IActionResult> DriverCheckCardBalance([FromBody] DriverCheckCardBalanceInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _IVRDriverRepo.DriverCheckCardBalance(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<DriverCheckCardBalanceOutput> item = result.Cast<DriverCheckCardBalanceOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("driver_checkcardlimit")]
        public async Task<IActionResult> DriverCheckCardLimit([FromBody] DriverCheckCardLimitInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _IVRDriverRepo.DriverCheckCardLimit(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<DriverCheckCardLimitOutput> item = result.Cast<DriverCheckCardLimitOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("driver_lasttransactiondetails")]
        public async Task<IActionResult> DriverLastTransactionDetails([FromBody] DriverLastTransactionDetailsInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _IVRDriverRepo.DriverLastTransactionDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<DriverLastTransactionDetailsOutput> item = result.Cast<DriverLastTransactionDetailsOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
    }
}
