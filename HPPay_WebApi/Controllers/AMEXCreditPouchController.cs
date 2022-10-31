using HPPay.DataModel.AmexCreditPouch;
using HPPay.DataModel.AMEXCreditPouch;
using HPPay.DataModel.HDFCCreditPouch;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataRepository.AMEXCreditPouch;
using HPPay.DataRepository.SMSGetSend;
using HPPay.Infrastructure.CommonClass;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/dtplus/AMEXCreditPouch")]
    public class AMEXCreditPouchController : ControllerBase
    {
        private readonly ILogger<AMEXCreditPouchController> _logger;
        private readonly ICreditPouchRepositoryAMEX _creditPouchRepo;
        private readonly IConfiguration _configuration;
        private readonly ISMSGetSendRepository _GetSendRepo;


        public AMEXCreditPouchController(ILogger<AMEXCreditPouchController> logger, ICreditPouchRepositoryAMEX creditPouchRepo, IConfiguration configuration, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _creditPouchRepo = creditPouchRepo;
            _configuration = configuration;
            _GetSendRepo = GetSendRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("chk_eligibility")]
        public async Task<IActionResult> CheckCreditPouchEligibility([FromBody] CheckAMEXCreditPouchEligibilityModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.CheckCreditPouchEligibility(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CheckAMEXCreditPouchEligibilityModelOutPut> item = result.Cast<CheckAMEXCreditPouchEligibilityModelOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insrt_cp_rqst_by_customer")]
        public async Task<IActionResult> AMEXInsertCreditPouchDetailsByCustomer([FromBody] InsertAMEXCreditPouchDetailsByCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.InsertCreditPouchDetailsByCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertAMEXCreditPouchDetailsByCustomerModelOutput>().ToList()[0].Status == 1)
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
                                            getandInsertSendInputModel.CreatedBy = ObjClass.RequestedBy;
                                            getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                            string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                            TemplateMessage = TemplateMessage
                                                .Replace("@Plan", result.Cast<InsertAMEXCreditPouchDetailsByCustomerModelOutput>().ToList()[0].Plan)
                                                .Replace("@Date", result.Cast<InsertAMEXCreditPouchDetailsByCustomerModelOutput>().ToList()[0].Date);

                                            getandInsertSendInputModel.SMSText = TemplateMessage;
                                            getandInsertSendInputModel.MobileNo = result.Cast<InsertAMEXCreditPouchDetailsByCustomerModelOutput>().ToList()[0].Mobile;
                                            getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo;
                                            getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateName;
                                            getandInsertSendInputModel.Userip = ObjClass.Userip;
                                            getandInsertSendInputModel.Userid = ObjClass.RequestedBy;
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
                                            insertEmailTextEntryInputModel.EmailIdTo = result.Cast<InsertAMEXCreditPouchDetailsByCustomerModelOutput>().ToList()[0].EmailId;
                                            insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                            insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                            insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                            string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                            if (result.Cast<InsertAMEXCreditPouchDetailsByCustomerModelOutput>().ToList()[0].EmailId == "")
                                            {
                                                ObjClass.RequestedBy = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage
                                                .Replace("@Plan", result.Cast<InsertAMEXCreditPouchDetailsByCustomerModelOutput>().ToList()[0].Plan)
                                                .Replace("@Date", result.Cast<InsertAMEXCreditPouchDetailsByCustomerModelOutput>().ToList()[0].Date);

                                            insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
                                            insertEmailTextEntryInputModel.CreatedBy = ObjClass.RequestedBy;
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
                        List<InsertAMEXCreditPouchDetailsByCustomerModelOutput> item = result.Cast<InsertAMEXCreditPouchDetailsByCustomerModelOutput>().ToList();
                        if (item.Count > 0)
                            return this.OkCustom(ObjClass, result, _logger);
                        else
                            return this.Fail(ObjClass, result, _logger);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dtail_mo")]

        public async Task<IActionResult> GetCustomerDetailsForCreditPouchByMO([FromBody] GetAMEXCustomerDetailsForCreditPouchByMOModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.GetCustomerDetailsForCreditPouchByMO(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.AMEXGetCustomerInfo.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_plan")]
        public async Task<IActionResult> GetPlan([FromBody] GetPlanNameModelAMEXInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.GetPlan(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetPlanNameModelAMEXOutPut> item = result.Cast<GetPlanNameModelAMEXOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insrt_cp_rqst")]
        public async Task<IActionResult> AMEXInsertCreditPouchDetailsByMO([FromBody] InsertAMEXCreditPouchDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.InsertCreditPouchDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertAMEXCreditPouchDetailsModelOutPut>().ToList()[0].Status == 1)
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
                                            getandInsertSendInputModel.CreatedBy = ObjClass.RequestedBy;
                                            getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                            string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                            TemplateMessage = TemplateMessage
                                                .Replace("[Plan]", result.Cast<InsertAMEXCreditPouchDetailsModelOutPut>().ToList()[0].Plan)
                                                .Replace("[Date]", result.Cast<InsertAMEXCreditPouchDetailsModelOutPut>().ToList()[0].Date);

                                            getandInsertSendInputModel.SMSText = TemplateMessage;
                                            getandInsertSendInputModel.MobileNo = result.Cast<InsertAMEXCreditPouchDetailsModelOutPut>().ToList()[0].Mobile;
                                            getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo;
                                            getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateName;
                                            getandInsertSendInputModel.Userip = ObjClass.Userip;
                                            getandInsertSendInputModel.Userid = ObjClass.RequestedBy;
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
                                            insertEmailTextEntryInputModel.EmailIdTo = result.Cast<InsertAMEXCreditPouchDetailsModelOutPut>().ToList()[0].EmailId;
                                            insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                            insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                            insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                            string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                            if (result.Cast<InsertAMEXCreditPouchDetailsModelOutPut>().ToList()[0].EmailId == "")
                                            {
                                                ObjClass.RequestedBy = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage
                                                .Replace("@Plan", result.Cast<InsertAMEXCreditPouchDetailsModelOutPut>().ToList()[0].Plan)
                                                .Replace("@Date", result.Cast<InsertAMEXCreditPouchDetailsModelOutPut>().ToList()[0].Date);

                                            insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
                                            insertEmailTextEntryInputModel.CreatedBy = ObjClass.RequestedBy;
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
                        List<InsertAMEXCreditPouchDetailsModelOutPut> item = result.Cast<InsertAMEXCreditPouchDetailsModelOutPut>().ToList();
                        if (item.Count > 0)
                            return this.OkCustom(ObjClass, result, _logger);
                        else
                            return this.Fail(ObjClass, result, _logger);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("action_cp")]
        public async Task<IActionResult> ActionOnCreditPouch([FromBody] ActionOnAMEXCreditPouchModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.ActionOnCreditPouch(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ActionOnAMEXCreditPouchModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<ActionOnAMEXCreditPouchModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_cp_by_bank")]
        public async Task<IActionResult> GetCreditPouchDetalsAtBank([FromBody] GetAMEXCreditPouchDetalsAtBankInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.GetCreditPouchDetalsAtBank(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAMEXCreditPouchDetalsAtBankOutPut> item = result.Cast<GetAMEXCreditPouchDetalsAtBankOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("auth_action_cp")]
        public async Task<IActionResult> AMEXAuthActionOnCreditPouch([FromBody] AuthActionOnAMEXCreditPouchModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.AuthActionOnCreditPouch(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<AuthActionOnAMEXCreditPouchModelOutput>().ToList()[0].Status == 1)
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
                                                .Replace("[StatusCode]", result.Cast<AuthActionOnAMEXCreditPouchModelOutput>().ToList()[0].StatusCode);

                                            getandInsertSendInputModel.SMSText = TemplateMessage;
                                            getandInsertSendInputModel.MobileNo = result.Cast<AuthActionOnAMEXCreditPouchModelOutput>().ToList()[0].Mobile;
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
                                            insertEmailTextEntryInputModel.EmailIdTo = result.Cast<AuthActionOnAMEXCreditPouchModelOutput>().ToList()[0].EmailId;
                                            insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                            insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                            insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                            string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                            if (result.Cast<AuthActionOnAMEXCreditPouchModelOutput>().ToList()[0].EmailId == "")
                                            {
                                                result.Cast<AuthActionOnAMEXCreditPouchModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage
                                                 .Replace("@StatusCode", result.Cast<AuthActionOnAMEXCreditPouchModelOutput>().ToList()[0].StatusCode);

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
                            result.Cast<AuthActionOnAMEXCreditPouchModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_cp_by_bank_auth")]
        public async Task<IActionResult> GetCreditPouchDetalsForAuth([FromBody] GetAMEXCreditPouchDetalsForAuthInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.GetCreditPouchDetalsForAuth(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAMEXCreditPouchDetalsForAuthOutPut> item = result.Cast<GetAMEXCreditPouchDetalsForAuthOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_cp_status")]
        public async Task<IActionResult> GetCreditPouchStatus([FromBody] GetAMEXCreditPouchStatusInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.GetCreditPouchStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAMEXCreditPouchStatusOutPut> item = result.Cast<GetAMEXCreditPouchStatusOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_cp_status_Report")]
        public async Task<IActionResult> GetCreditPouchStatusReport([FromBody] GetAMEXCreditPouchDetalsStatusReportInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.GetCreditPouchStatusReport(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAMEXCreditPouchStatusReportOutPut> item = result.Cast<GetAMEXCreditPouchStatusReportOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        } 

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insrt_cp_referral")]
        public async Task<IActionResult> AMEXInsertCreditPouchReferralDetails([FromBody] InsertCreditPouchReferralDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.InsertCreditPouchReferralDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertCreditPouchReferralDetailsModelOutPut>().ToList()[0].Status == 1)
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
                                                .Replace("[StatusCode]", result.Cast<InsertCreditPouchReferralDetailsModelOutPut>().ToList()[0].Status.ToString());

                                            getandInsertSendInputModel.SMSText = TemplateMessage;
                                            getandInsertSendInputModel.MobileNo = result.Cast<AuthActionOnCreditPouchModelOutput>().ToList()[0].Mobile;
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
                                            insertEmailTextEntryInputModel.EmailIdTo = result.Cast<InsertCreditPouchReferralDetailsModelOutPut>().ToList()[0].EmailId;
                                            insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                            insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                            insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                            string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                            if (result.Cast<InsertCreditPouchReferralDetailsModelOutPut>().ToList()[0].EmailId == "")
                                            {
                                                result.Cast<InsertCreditPouchReferralDetailsModelOutPut>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage
                                                 .Replace("@StatusCode", result.Cast<InsertCreditPouchReferralDetailsModelOutPut>().ToList()[0].Status.ToString());

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
                        List<InsertCreditPouchReferralDetailsModelOutPut> item = result.Cast<InsertCreditPouchReferralDetailsModelOutPut>().ToList();
                        if (item.Count > 0)
                            return this.OkCustom(ObjClass, result, _logger);
                        else
                            return this.Fail(ObjClass, result, _logger);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_cp_referral")]
        public async Task<IActionResult> AMEXGetCreditPouchReferral([FromBody] GetCreditPouchDetalsReferralInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.GetCreditPouchReferral(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCreditPouchDetalsReferral> item = result.Cast<GetCreditPouchDetalsReferral>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        // [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("init_amex_pg_recharge")]
        public async Task<IActionResult> InsertAMEXRecharge([FromBody] InitiateAmexRechargeModelInput ObjClass)
        {
            string PaymentResultOutput = null;
            InitiateAmexRechargeModelOutput initiateRechargeModelOutPut = new InitiateAmexRechargeModelOutput();
            decimal MinAmt = Convert.ToDecimal(_configuration.GetSection("RechargeSettings:MinimumAmount").Value);

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }           
            else if (MinAmt > ObjClass.Amount)
            {
                initiateRechargeModelOutPut.Status = 0;
                initiateRechargeModelOutPut.Reason = "Minimum amount should be " + _configuration.GetSection("RechargeSettings:MinimumAmount").Value;
                return this.OkCustom(ObjClass, initiateRechargeModelOutPut, _logger);
            }
            else
            {
                Random rn = new Random();
                var TransactionId = rn.Next();
                var orderId = rn.Next();
                string reqerror = _configuration.GetSection("AMEXPG:ErrorUrl").Value;
                string reqresponse = _configuration.GetSection("AMEXPG:ResponseUrl").Value;
                string MerchentId = _configuration.GetSection("AMEXPG:MerchantId").Value;
                string Gatewayurl = _configuration.GetSection("AMEXPG:ApiUrl").Value;
                string Gatewayurl2 = _configuration.GetSection("AMEXPG:ApiUrl").Value;
                string version = _configuration.GetSection("AMEXPG:version").Value;
                string UserName = _configuration.GetSection("AMEXPG:Username").Value;
                string Password = _configuration.GetSection("AMEXPG:Password").Value; 

                StringBuilder url = new StringBuilder();
                url.Append(Gatewayurl);
                url.Append("/api/rest/version/");
                url.Append(version);
                url.Append("/merchant/");
                url.Append(MerchentId);
                url.Append("/session");
                 

                Gatewayurl = url.ToString();
                using var client = new HttpClient();

                var authToken = Encoding.ASCII.GetBytes($"merchant.TEST8110603677H:d37315224100180e088dff0c625bc5a7");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(authToken));

                var result = await client.PostAsync(Gatewayurl, null);
                var content = await result.Content.ReadAsStringAsync();                

                JObject obj1 = JObject.Parse(JsonConvert.DeserializeObject(content).ToString());
                string respMessage = obj1.ToString();
                JObject obj2 = JObject.Parse(JsonConvert.DeserializeObject(respMessage).ToString());
                getDataForSession SessionId = obj2.ToObject<getDataForSession>();
                string sId = SessionId.session.id;
                //--------------------------------------------------------------//
                url.Append("/"+sId);
                Gatewayurl = url.ToString();

                UpdateSession updateSession = new UpdateSession();
                updateSession.customer.account.id = "0";
                updateSession.customer.account.history.creationDate = DateTime.Today.ToString("yyyy-MM-dd");

                updateSession.sourceOfFunds.type = "CARD";
                updateSession.sourceOfFunds.provided.card.number = ObjClass.CardNumber;
                updateSession.sourceOfFunds.provided.card.expiry.month = ObjClass.month.ToString();
                updateSession.sourceOfFunds.provided.card.expiry.year = ObjClass.year.ToString();
                updateSession.order.id =  orderId.ToString();
                updateSession.order.amount = ObjClass.Amount.ToString();
                updateSession.order.currency = "INR";
                updateSession.order.description = "CP RECHARGE CCMS BY AMEX";
                updateSession.transaction.id = TransactionId.ToString();
                updateSession.authentication.channel = "PAYER_BROWSER";
                updateSession.authentication.purpose = "PAYMENT_TRANSACTION";
                updateSession.authentication.redirectResponseUrl = reqresponse;
                updateSession.authentication.challengePreference = "CHALLENGE_MANDATED";
                var json = JsonConvert.SerializeObject(updateSession);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(authToken));
                string PayAuthMsg = "";
                var Updateresult = await client.PutAsync(Gatewayurl, data);
                var Updatecontent = await Updateresult.Content.ReadAsStringAsync();
                JObject UpdateObj = JObject.Parse(JsonConvert.DeserializeObject(Updatecontent).ToString());
                string UpdateMessage = UpdateObj.ToString();
                JObject Updateobj = JObject.Parse(JsonConvert.DeserializeObject(UpdateMessage).ToString());
                getDataForSession Session = Updateobj.ToObject<getDataForSession>();
                string resMsg= Session.session.updateStatus;
                if (resMsg == "SUCCESS")
                {
                    StringBuilder url2 = new StringBuilder();
                    url2.Append(Gatewayurl2);
                    url2.Append("/api/rest/version/");
                    url2.Append(version);
                    url2.Append("/merchant/");
                    url2.Append(MerchentId);
                    url2.Append("/order/");
                    url2.Append(orderId);
                    url2.Append("/transaction/");
                    url2.Append(TransactionId);
                    Gatewayurl2 = url2.ToString();

                    PaymentSessionAuth paymentSessionAuth = new PaymentSessionAuth();
                    paymentSessionAuth.apiOperation = "INITIATE_AUTHENTICATION";
                    paymentSessionAuth.order.currency = "INR";
                    paymentSessionAuth.session.id = sId;

                    var PayAuthjson = JsonConvert.SerializeObject(paymentSessionAuth);
                    var PayAuthdata = new StringContent(PayAuthjson, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                            Convert.ToBase64String(authToken));

                    var PayAuthResult = await client.PutAsync(Gatewayurl2, PayAuthdata);
                    var PayAuthContent = await PayAuthResult.Content.ReadAsStringAsync();
                    JObject PayAuthObj = JObject.Parse(JsonConvert.DeserializeObject(PayAuthContent).ToString());
                    string PayAuthMessage = PayAuthObj.ToString();
                    JObject PayAuthObjs = JObject.Parse(JsonConvert.DeserializeObject(PayAuthMessage).ToString());
                    PaymentResult PayAuthSession = PayAuthObjs.ToObject<PaymentResult>();
                     PayAuthMsg = PayAuthSession.order.authenticationStatus;

                }
                if (PayAuthMsg == "AUTHENTICATION_AVAILABLE")
                {

                    PaymentSession paymentSession = new PaymentSession();
                    paymentSession.apiOperation = "AUTHENTICATE_PAYER";
                    paymentSession.order.amount = ObjClass.Amount.ToString();
                    paymentSession.order.currency = "INR";
                    paymentSession.session.id = sId;
                    paymentSession.device.browser = "MOZILLA";
                    paymentSession.device.browserDetails.javaEnabled = "true";
                    paymentSession.device.browserDetails.language = "EN";
                    paymentSession.device.browserDetails.screenHeight = "500";
                    paymentSession.device.browserDetails.screenWidth = "500";
                    paymentSession.device.browserDetails.timeZone = "-100";
                    paymentSession.device.browserDetails.colorDepth = "48";
                    paymentSession.device.browserDetails.The3DSecureChallengeWindowSize = "FULL_SCREEN";
                    paymentSession.device.browserDetails.acceptHeaders = "JSON";

                    var Payjson = JsonConvert.SerializeObject(paymentSession);
                    var Paydata = new StringContent(Payjson, Encoding.UTF8, "application/json");

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                            Convert.ToBase64String(authToken));

                    var PayResult = await client.PutAsync(Gatewayurl2, Paydata);
                    var PayContent = await PayResult.Content.ReadAsStringAsync();
                    JObject PayObj = JObject.Parse(JsonConvert.DeserializeObject(PayContent).ToString());
                    string PayMessage = PayObj.ToString();

                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };
                    PayMessage = PayMessage.Replace("'", "''");
                    Root objObject = JsonConvert.DeserializeObject<Root>(PayMessage, settings);
                    PaymentResultOutput = objObject.authentication.redirectHtml.Replace("\"","'");

                    return this.OkCustom(ObjClass, objObject, _logger);
                }




                //---------------------------------------------------------------//
                return this.OkCustom(ObjClass, PaymentResultOutput, _logger);

            }
        }



    }
}
