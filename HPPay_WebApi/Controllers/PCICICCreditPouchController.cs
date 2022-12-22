using HPPay.DataModel.ICICICreditPouch;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataRepository.ICICICreditPouch;
using HPPay.DataRepository.PCICICICreditPouch;
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
    [ApiController]
    [Route("/api/hppay/PCICICICreditPouch")]
    public class PCICICICreditPouchController : ControllerBase
    {
        private readonly ILogger<PCICICICreditPouchController> _logger;
        private readonly IPCCreditPouchRepositoryICICI _creditPouchRepo; 
        private readonly IConfiguration _configuration;
        private readonly ISMSGetSendRepository _GetSendRepo;

        public PCICICICreditPouchController(ILogger<PCICICICreditPouchController> logger, IPCCreditPouchRepositoryICICI creditPouchRepo, IConfiguration configuration, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _creditPouchRepo = creditPouchRepo;
            _configuration = configuration;
            _GetSendRepo = GetSendRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("chk_eligibility_for_pc")]
        public async Task<IActionResult> CheckCreditPouchEligibilityForPC([FromBody] CheckICICICreditPouchEligibilityModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.CheckCreditPouchEligibilityForPC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CheckICICICreditPouchEligibilityModelOutPut> item = result.Cast<CheckICICICreditPouchEligibilityModelOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insrt_cp_rqst_by_customer_for_pc")]
        public async Task<IActionResult> ICICIInsertCreditPouchDetailsByCustomer([FromBody] InsertICICICreditPouchDetailsByCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.InsertCreditPouchDetailsByCustomerForPC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertICICICreditPouchDetailsByCustomerModelOutput>().ToList()[0].Status == 1)
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
                                                .Replace("[Plan]", result.Cast<InsertICICICreditPouchDetailsByCustomerModelOutput>().ToList()[0].Plan)
                                                .Replace("[Date]", result.Cast<InsertICICICreditPouchDetailsByCustomerModelOutput>().ToList()[0].Date);

                                            getandInsertSendInputModel.SMSText = TemplateMessage;
                                            getandInsertSendInputModel.MobileNo = result.Cast<InsertICICICreditPouchDetailsByCustomerModelOutput>().ToList()[0].Mobile;
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
                                            insertEmailTextEntryInputModel.EmailIdTo = result.Cast<InsertICICICreditPouchDetailsByCustomerModelOutput>().ToList()[0].EmailId;
                                            insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                            insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                            insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                            string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                            if (result.Cast<InsertICICICreditPouchDetailsByCustomerModelOutput>().ToList()[0].EmailId == "")
                                            {
                                                ObjClass.RequestedBy = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage
                                                .Replace("@Plan", result.Cast<InsertICICICreditPouchDetailsByCustomerModelOutput>().ToList()[0].Plan)
                                                .Replace("@Date", result.Cast<InsertICICICreditPouchDetailsByCustomerModelOutput>().ToList()[0].Date);

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
                        List<InsertICICICreditPouchDetailsByCustomerModelOutput> item = result.Cast<InsertICICICreditPouchDetailsByCustomerModelOutput>().ToList();
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
        [Route("get_dtail_mo_for_pc")]

        public async Task<IActionResult> GetCustomerDetailsForCreditPouchByMOForPC([FromBody] GetICICICustomerDetailsForCreditPouchByMOModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.GetCustomerDetailsForCreditPouchByMOForPC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.ICICICGetCustomerInfo.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_plan_for_pc")]
        public async Task<IActionResult> GetPlan([FromBody] GetPlanNameModelICICIInput ObjClass)
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
                    List<GetPlanNameModelICICIOutPut> item = result.Cast<GetPlanNameModelICICIOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insrt_cp_rqst_for_pc")]
        public async Task<IActionResult> ICICIInsertCreditPouchDetailsByMO([FromBody] InsertICICICreditPouchDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.InsertCreditPouchDetailsForPC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertICICICreditPouchDetailsModelOutPut>().ToList()[0].Status == 1)
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
                                                .Replace("[Plan]", result.Cast<InsertICICICreditPouchDetailsModelOutPut>().ToList()[0].Plan)
                                                .Replace("[Date]", result.Cast<InsertICICICreditPouchDetailsModelOutPut>().ToList()[0].Date);

                                            getandInsertSendInputModel.SMSText = TemplateMessage;
                                            getandInsertSendInputModel.MobileNo = result.Cast<InsertICICICreditPouchDetailsModelOutPut>().ToList()[0].Mobile;
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
                                            insertEmailTextEntryInputModel.EmailIdTo = result.Cast<InsertICICICreditPouchDetailsModelOutPut>().ToList()[0].EmailId;
                                            insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                            insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                            insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                            string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                            if (result.Cast<InsertICICICreditPouchDetailsModelOutPut>().ToList()[0].EmailId == "")
                                            {
                                                ObjClass.RequestedBy = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage
                                                .Replace("@Plan", result.Cast<InsertICICICreditPouchDetailsModelOutPut>().ToList()[0].Plan)
                                                .Replace("@Date", result.Cast<InsertICICICreditPouchDetailsModelOutPut>().ToList()[0].Date);

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
                        List<InsertICICICreditPouchDetailsModelOutPut> item = result.Cast<InsertICICICreditPouchDetailsModelOutPut>().ToList();
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
        [Route("action_cp_for_pc")]
        public async Task<IActionResult> ActionOnCreditPouchForPC([FromBody] ActionOnICICICreditPouchModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.ActionOnCreditPouchForPC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ActionOnICICICreditPouchModelOutput> item = result.Cast<ActionOnICICICreditPouchModelOutput>().ToList();
                    if (item.Count > 0)
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
        [Route("get_cp_by_bank_for_pc")]
        public async Task<IActionResult> GetCreditPouchDetalsAtBankForPC([FromBody] GetICICICreditPouchDetalsAtBankInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.GetCreditPouchDetalsAtBankForPC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetICICICreditPouchDetalsAtBankOutPut> item = result.Cast<GetICICICreditPouchDetalsAtBankOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("auth_action_cp_for_pc")]
        public async Task<IActionResult> ICICIAuthActionOnCreditPouch([FromBody] AuthActionOnICICICreditPouchModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.AuthActionOnCreditPouchForPC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<AuthActionOnICICICreditPouchModelOutput> item = result.Cast<AuthActionOnICICICreditPouchModelOutput>().ToList();
                    if (item.Count > 0)
                    {
                         
                            try
                            {
                                GetSMSValueInputModel ObjSMSValue = new GetSMSValueInputModel();
                                ObjSMSValue.MethodName = ControllerContext.ActionDescriptor.ActionName;
                                var SMSResult = await _GetSendRepo.GetSMSValue(ObjSMSValue);
                                if (SMSResult != null)
                                {
                                    List<GetSMSValueOutputModel> items = SMSResult.Cast<GetSMSValueOutputModel>().ToList();
                                    for (int i = 0; i < items.Count; i++)
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
                                                    .Replace("[StatusCode]", result.Cast<AuthActionOnICICICreditPouchModelOutput>().ToList()[0].StatusCode);

                                                getandInsertSendInputModel.SMSText = TemplateMessage;
                                                getandInsertSendInputModel.MobileNo = result.Cast<AuthActionOnICICICreditPouchModelOutput>().ToList()[0].Mobile;
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
                                                insertEmailTextEntryInputModel.EmailIdTo = result.Cast<AuthActionOnICICICreditPouchModelOutput>().ToList()[0].EmailId;
                                                insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                                insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                                insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                                string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                                if (result.Cast<AuthActionOnICICICreditPouchModelOutput>().ToList()[0].EmailId == "")
                                                {
                                                result.Cast<AuthActionOnICICICreditPouchModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                                }

                                                EmailTemplateMessage = EmailTemplateMessage
                                                     .Replace("[StatusCode]", result.Cast<AuthActionOnICICICreditPouchModelOutput>().ToList()[0].StatusCode);

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
                        return this.Fail(ObjClass, result, _logger);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_cp_by_bank_auth_for_pc")]
        public async Task<IActionResult> GetCreditPouchDetalsForAuthForPC([FromBody] GetICICICreditPouchDetalsForAuthInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.GetCreditPouchDetalsForAuthForPC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetICICICreditPouchDetalsForAuthOutPut> item = result.Cast<GetICICICreditPouchDetalsForAuthOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_cp_status_for_pc")]
        public async Task<IActionResult> GetCreditPouchStatusForPC([FromBody] GetICICICreditPouchStatusInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.GetCreditPouchStatusForPC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetICICICreditPouchStatusOutPut> item = result.Cast<GetICICICreditPouchStatusOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_cp_status_Report_for_pc")]
        public async Task<IActionResult> GetCreditPouchStatusReportForPC([FromBody] GetICICICreditPouchDetalsStatusReportInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.GetCreditPouchStatusReportForPC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetICICICreditPouchStatusReportOutPut> item = result.Cast<GetICICICreditPouchStatusReportOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("initiate_cp_recharge_for_pc")]
        public async Task<IActionResult> InitiateCPRechargeForPC([FromBody] InitiateICICICreditPouchRechargeModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.InitiateCPRechargeForPC(ObjClass);
                if (result == null)
                {

                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<InitiateICICICreditPouchRechargeModelOutPut> item = result.Cast<InitiateICICICreditPouchRechargeModelOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_cp_pg_log_for_pc")]
        public async Task<IActionResult> InsertCPPGApiRequestResponseForPC([FromBody] InitiateICICICreditPouchRechargeModelInput ObjClass)
        {
           
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.InitiateCPRechargeForPC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InitiateICICICreditPouchRechargeModelOutPut>().ToList()[0].Status == 1)
                    {

                        //------------------------------------------------------
                        GenericMethods objgm = new GenericMethods();

                         string req = null; string reqerror = "Hosted_http_result.aspx"; string reqresponse = "Hosted_http_result.aspx"; string ReqTranportalId = "9031158"; string ReqTranportalPassword = "password1"; string error = null;

                        Dictionary<string, string> objReq = new Dictionary<string, string> { };
                        objReq.Add("ReqAction", req);
                        objReq.Add("ReqTranportalId", ReqTranportalId);
                        objReq.Add("ReqTranportalPassword", ReqTranportalPassword);
                        objReq.Add("udf1", "");
                        objReq.Add("udf2", "");
                        objReq.Add("udf3", "");
                        objReq.Add("udf4", "");
                        objReq.Add("udf5", "");
                        objReq.Add("ReqAmt", ObjClass.Amount.ToString());
                        objReq.Add("reqCurrencycode", "356");
                        objReq.Add("reqTrackid", result.Cast<InitiateICICICreditPouchRechargeModelOutPut>().ToList()[0].OrderId);
                        objReq.Add("reqLanguid", "USA");
                        objReq.Add("responseURL", reqresponse);
                        objReq.Add("errorURL", reqerror);

                        string tranreq = objgm.XMLFormation(objReq, "hosted_http");
                        
                        if (!string.IsNullOrEmpty(tranreq))
                        {
                            req = "&trandata=" + objgm.Encrypt(tranreq, "925555866107925555866114");
                            req = req + "&errorURL=" + reqerror + "&responseURL=" + reqresponse + "&tranportalId=" + ReqTranportalId + "&password=" + ReqTranportalPassword;
                        }
                        else
                        {
                             error = "invalid XML format";
                        }
                        //------------------------------------------------------
                        ICICIApiRequestResponse response = new ICICIApiRequestResponse();
                        ICICICPPGLoginResponse CPPGLoginResponse = new ICICICPPGLoginResponse();

                         string apiurl = _configuration.GetSection("ICICIPG:ApiUrl").Value;                         

                        HttpResponseMessage apiResponse = Variables.CallPostAPI(apiurl + req, JsonConvert.SerializeObject(objReq), "").Result;
                        string json = string.Empty;
                        if (apiResponse.IsSuccessStatusCode)
                        {
                            json = apiResponse.Content.ReadAsStringAsync().Result;
                        }                         
                        response.BankName = "ICICI";
                        response.apiurl = apiurl + req;
                        response.request = JsonConvert.SerializeObject(objReq);
                        response.response = apiResponse.Content.ReadAsStringAsync().Result;
                        response.UserId = ObjClass.Userid;
                        response.TransactionId = result.Cast<InitiateICICICreditPouchRechargeModelOutPut>().ToList()[0].OrderId;
                        //log entry of rqst & rspnce
                        _creditPouchRepo.InsertCPPGApiRequestResponseForPC(response); 
                         
                        return this.OkCustom(ObjClass, response.response, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                        result.Cast<InitiateICICICreditPouchRechargeModelOutPut>().ToList()[0].Reason);
                    }
                }
            }
        }
    }
}
