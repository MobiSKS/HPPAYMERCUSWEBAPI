using CCA.Util;
using HPPay.DataModel.HDFCCreditPouch;
using HPPay.DataModel.PayU;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataRepository.HDFCCreditPouch;
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
using System.Text;
using System.Threading.Tasks;
using static HPPay_WebApi.ActionFilters.LoggingFilterAttribute;

namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/dtplus/PCHDFCCreditPouch")]
    public class PCHDFCCreditPouchController : ControllerBase
    {
        private readonly ILogger<PCHDFCCreditPouchController> _logger;
        private readonly IPCCreditPouchRepository _creditPouchRepo;
        private readonly IConfiguration _configuration;
        private readonly ISMSGetSendRepository _GetSendRepo;

        public PCHDFCCreditPouchController(ILogger<PCHDFCCreditPouchController> logger, IPCCreditPouchRepository creditPouchRepo, IConfiguration configuration, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _creditPouchRepo = creditPouchRepo;
            _configuration = configuration;
            _GetSendRepo = GetSendRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("chk_eligibility_for_pc")]
        public async Task<IActionResult> CheckCreditPouchEligibilityForPC([FromBody] CheckCreditPouchEligibilityModelInput ObjClass)
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
                    List<CheckCreditPouchEligibilityModelOutPut> item = result.Cast<CheckCreditPouchEligibilityModelOutPut>().ToList();
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
        public async Task<IActionResult> HDFCInsertCreditPouchDetailsByCustomer([FromBody] InsertCreditPouchDetailsByCustomerModelInput ObjClass)
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
                    if (result.Cast<InsertCreditPouchDetailsByCustomerModelOutput>().ToList()[0].Status == 1)
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
                                                .Replace("[Plan]", result.Cast<InsertCreditPouchDetailsByCustomerModelOutput>().ToList()[0].Plan)
                                                .Replace("[Date]", result.Cast<InsertCreditPouchDetailsByCustomerModelOutput>().ToList()[0].Date);

                                            getandInsertSendInputModel.SMSText = TemplateMessage;
                                            getandInsertSendInputModel.MobileNo = result.Cast<InsertCreditPouchDetailsByCustomerModelOutput>().ToList()[0].Mobile;
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
                                            insertEmailTextEntryInputModel.EmailIdTo = result.Cast<InsertCreditPouchDetailsByCustomerModelOutput>().ToList()[0].EmailId;
                                            insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                            insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                            insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                            string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                            if (result.Cast<InsertCreditPouchDetailsByCustomerModelOutput>().ToList()[0].EmailId == "")
                                            {
                                                ObjClass.RequestedBy = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage
                                                .Replace("@Plan", result.Cast<InsertCreditPouchDetailsByCustomerModelOutput>().ToList()[0].Plan)
                                                .Replace("@Date", result.Cast<InsertCreditPouchDetailsByCustomerModelOutput>().ToList()[0].Date);

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
                        List<InsertCreditPouchDetailsByCustomerModelOutput> item = result.Cast<InsertCreditPouchDetailsByCustomerModelOutput>().ToList();
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
        public async Task<IActionResult> GetCustomerDetailsForCreditPouchByMO([FromBody] GetCustomerDetailsForCreditPouchByMOModelInput ObjClass)
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
                    if (result.GetCustomerInfo.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_plan")]
        public async Task<IActionResult> GetPlan([FromBody] GetPlanNameModelHDFCInput ObjClass)
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
                    List<GetPlanNameModelHDFCOutPut> item = result.Cast<GetPlanNameModelHDFCOutPut>().ToList();
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
        public async Task<IActionResult> HDFCInsertCreditPouchDetailsByMO([FromBody] InsertCreditPouchDetailsModelInput ObjClass)
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
                    if (result.Cast<InsertCreditPouchDetailsModelOutPut>().ToList()[0].Status == 1)
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
                                                .Replace("[Plan]", result.Cast<InsertCreditPouchDetailsByCustomerModelOutput>().ToList()[0].Plan)
                                                .Replace("[Date]", result.Cast<InsertCreditPouchDetailsByCustomerModelOutput>().ToList()[0].Date);

                                            getandInsertSendInputModel.SMSText = TemplateMessage;
                                            getandInsertSendInputModel.MobileNo = result.Cast<InsertCreditPouchDetailsByCustomerModelOutput>().ToList()[0].Mobile;
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
                                            insertEmailTextEntryInputModel.EmailIdTo = result.Cast<InsertCreditPouchDetailsByCustomerModelOutput>().ToList()[0].EmailId;
                                            insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                            insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                            insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                            string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                            if (result.Cast<InsertCreditPouchDetailsByCustomerModelOutput>().ToList()[0].EmailId == "")
                                            {
                                                ObjClass.RequestedBy = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage
                                                .Replace("@Plan", result.Cast<InsertCreditPouchDetailsByCustomerModelOutput>().ToList()[0].Plan)
                                                .Replace("Date", result.Cast<InsertCreditPouchDetailsByCustomerModelOutput>().ToList()[0].Date);

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
                        List<InsertCreditPouchDetailsModelOutPut> item = result.Cast<InsertCreditPouchDetailsModelOutPut>().ToList();
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
        public async Task<IActionResult> ActionOnCreditPouchForPC([FromBody] ActionOnCreditPouchModelInput ObjClass)
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

                    List<ActionOnCreditPouchModelOutput> item = result.Cast<ActionOnCreditPouchModelOutput>().ToList();
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
        public async Task<IActionResult> GetCreditPouchDetalsAtBankForPC([FromBody] GetCreditPouchDetalsAtBankInput ObjClass)
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
                    List<GetCreditPouchDetalsAtBankOutPut> item = result.Cast<GetCreditPouchDetalsAtBankOutPut>().ToList();
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
        public async Task<IActionResult> HDFCAuthActionOnCreditPouch([FromBody] AuthActionOnCreditPouchModelInput ObjClass)
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
                    if (result.Cast<AuthActionOnCreditPouchModelOutput>().ToList()[0].Status == 1)
                    {
                        if (result.Cast<AuthActionOnCreditPouchModelOutput>().ToList()[0].StatusCode == "Approved")
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
                                                    .Replace("[StatusCode]", result.Cast<AuthActionOnCreditPouchModelOutput>().ToList()[0].StatusCode);

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
                                                insertEmailTextEntryInputModel.EmailIdTo = result.Cast<AuthActionOnCreditPouchModelOutput>().ToList()[0].EmailId;
                                                insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                                insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                                insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                                string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                                if (result.Cast<AuthActionOnCreditPouchModelOutput>().ToList()[0].EmailId == "")
                                                {
                                                    result.Cast<AuthActionOnCreditPouchModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                                }

                                                EmailTemplateMessage = EmailTemplateMessage
                                                     .Replace("@StatusCode", result.Cast<AuthActionOnCreditPouchModelOutput>().ToList()[0].StatusCode);

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
        public async Task<IActionResult> GetCreditPouchDetalsForAuthForPC([FromBody] GetCreditPouchDetalsForAuthInput ObjClass)
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
                    List<GetCreditPouchDetalsForAuthOutPut> item = result.Cast<GetCreditPouchDetalsForAuthOutPut>().ToList();
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
        public async Task<IActionResult> GetCreditPouchStatusForPC([FromBody] GetCreditPouchStatusInput ObjClass)
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
                    List<GetCreditPouchStatusOutPut> item = result.Cast<GetCreditPouchStatusOutPut>().ToList();
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
        public async Task<IActionResult> GetCreditPouchStatusReportForPC([FromBody] GetCreditPouchDetalsStatusReportInput ObjClass)
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
                    List<GetCreditPouchStatusReportOutPut> item = result.Cast<GetCreditPouchStatusReportOutPut>().ToList();
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
        public async Task<IActionResult> InitiateCPRechargeForPC([FromBody] InitiateCreditPouchRechargeModelInput ObjClass)
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
                    List<InitiateCreditPouchRechargeModelOutPut> item = result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        //[HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        //[Route("insert_cp_pg_log_for_pc")]
        //public async Task<IActionResult> InsertCPPGApiRequestResponse([FromBody] InitiateCreditPouchRechargeModelInput ObjClass)
        //{

        //    if (ObjClass == null)
        //    {
        //        return this.BadRequestCustom(ObjClass, null, _logger);
        //    }
        //    else
        //    {
        //        var result = await _creditPouchRepo.InitiateCPRechargeForPC(ObjClass);
        //        if (result == null)
        //        {
        //            return this.NotFoundCustom(ObjClass, null, _logger);
        //        }
        //        else
        //        {
        //            if (result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].Status == 1)
        //            {

        //                //------------------------------------------------------

        //                Random rn = new Random();
        //                var tid = rn.Next();
        //                string req = null;
        //                string reqerror = _configuration.GetSection("HDFCPG:ErrorUrl").Value;
        //                string reqresponse = _configuration.GetSection("HDFCPG:ResponseUrl").Value;
        //                string ReqTranportalId = _configuration.GetSection("HDFCPG:MerchentId").Value;
        //                string order_id = result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].OrderId;
        //                string currency = "INR"; decimal amount = ObjClass.Amount; string language = "EN";

        //                Dictionary<string, string> objReq = new Dictionary<string, string> { };
        //                objReq.Add("tid", tid.ToString());
        //                objReq.Add("merchant_id", ReqTranportalId);
        //                objReq.Add("currency", currency);
        //                objReq.Add("amount", amount.ToString());
        //                objReq.Add("order_id", result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].OrderId);
        //                objReq.Add("language", language);
        //                objReq.Add("redirect_url", reqresponse);
        //                objReq.Add("cancel_url", reqerror);

        //                req = "tid=" + tid + "&cancel_url=" + reqerror + "&currency=" + currency + "&amount=" + amount + "&language=" + language + "&redirect_url=" + reqresponse + "&merchant_id=" + ReqTranportalId + "&order_id=" + order_id + "&";


        //                CCACrypto ccaCrypto = new CCACrypto();
        //                if (!string.IsNullOrEmpty(req))
        //                {
        //                    req = ccaCrypto.Encrypt(req, _configuration.GetSection("HDFCPG:Key").Value);

        //                }
        //                //------------------------------------------------------
        //                InitiateCreditPouchRechargeModelOutPut initiateCreditPouchRechargeModelOutPut = new InitiateCreditPouchRechargeModelOutPut();
        //                ApiRequestResponse response = new ApiRequestResponse();
        //                CPPGLoginResponse CPPGLoginResponse = new CPPGLoginResponse();
        //                string apiurl = _configuration.GetSection("HDFCPG:ApiUrl").Value;

        //                HttpResponseMessage apiResponse = Variables.CallPostAPI(apiurl + req, JsonConvert.SerializeObject(objReq), "").Result;
        //                string json = string.Empty;

        //                if (apiResponse.IsSuccessStatusCode)
        //                {
        //                    json = apiResponse.Content.ReadAsStringAsync().Result;
        //                }
        //                initiateCreditPouchRechargeModelOutPut.OrderId = result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].OrderId;
        //                response.BankName = "Parent Customer HDFC PG";
        //                response.apiurl = apiurl;
        //                response.request = JsonConvert.SerializeObject(objReq);
        //                response.response = json;
        //                response.UserId = ObjClass.Userid;
        //                response.TransactionId = result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].OrderId;
        //                response.request_Hash = req;
        //                response.Amount = ObjClass.Amount;
        //                response.accessCode = _configuration.GetSection("HDFCPG:accessCode").Value;
        //                initiateCreditPouchRechargeModelOutPut.Response = response;
        //                //log entry of rqst & rspnce
        //                _creditPouchRepo.InsertCPPGApiRequestResponse(response);

        //                //-------------------------------------------------------------------------//
        //                try
        //                {
        //                    GetSMSValueInputModel ObjSMSValue = new GetSMSValueInputModel();
        //                    ObjSMSValue.MethodName = ControllerContext.ActionDescriptor.ActionName;
        //                    var SMSResult = await _GetSendRepo.GetSMSValue(ObjSMSValue);
        //                    if (SMSResult != null)
        //                    {
        //                        List<GetSMSValueOutputModel> item = SMSResult.Cast<GetSMSValueOutputModel>().ToList();
        //                        for (int i = 0; i < item.Count; i++)
        //                        {
        //                            if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSEmailStatus == "1")
        //                            {

        //                                if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
        //                                {
        //                                    GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
        //                                    getandInsertSendInputModel.CreatedBy = response.UserId;
        //                                    getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

        //                                    string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

        //                                    TemplateMessage = TemplateMessage
        //                                        .Replace("[TranTrackid]", response.TransactionId)
        //                                        .Replace("[Amount]", response.Amount.ToString());

        //                                    getandInsertSendInputModel.SMSText = TemplateMessage;
        //                                    getandInsertSendInputModel.MobileNo = result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].Mobile;
        //                                    getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo;
        //                                    getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateName;
        //                                    getandInsertSendInputModel.Userip = ObjClass.Userip;
        //                                    getandInsertSendInputModel.Userid = ObjClass.Userid;
        //                                    getandInsertSendInputModel.Useragent = ObjClass.Useragent;
        //                                    getandInsertSendInputModel.SenderId = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SenderId;
        //                                    getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSAPIURL;
        //                                    await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);

        //                                }

        //                                if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailStatus == 1)
        //                                {
        //                                    string ZOROEmaild = string.Empty; //database

        //                                    InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
        //                                    insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
        //                                    insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
        //                                    insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
        //                                    insertEmailTextEntryInputModel.EmailIdTo = result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].email;
        //                                    insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
        //                                    insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
        //                                    insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
        //                                    string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

        //                                    if (result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].email == "")
        //                                    {
        //                                        response.UserId = insertEmailTextEntryInputModel.EmailIdCC;
        //                                    }

        //                                    EmailTemplateMessage = EmailTemplateMessage
        //                                        .Replace("@TranTrackid", response.TransactionId)
        //                                        .Replace("@Amount", response.Amount.ToString());

        //                                    insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
        //                                    insertEmailTextEntryInputModel.CreatedBy = response.UserId;
        //                                    await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    _logger.LogError(ControllerContext.ActionDescriptor.ActionName + " :: Email and SMS Error :" + ex.Message);
        //                }
        //                return this.OkCustom(ObjClass, initiateCreditPouchRechargeModelOutPut, _logger);
        //            }
        //            else
        //            {
        //                return this.FailCustom(ObjClass, result, _logger,
        //                result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].Reason);
        //            }
        //        }
        //    }
        //}

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_cp_pg_log_for_pc")]
        public async Task<IActionResult> InsertCPPGApiRequestResponse([FromBody] InitiateCreditPouchRechargeModelInput ObjClass)
        {
            bool possitive = ObjClass.Amount > 0;
            InitiateCreditPouchRechargeModelOutPut initiateCreditPouchRechargeModelOutPut = new InitiateCreditPouchRechargeModelOutPut();
            decimal MinAmt = Convert.ToDecimal(_configuration.GetSection("RechargeSettings:MinimumAmount").Value);
            if (possitive)
            {

                if (ObjClass == null)
                {
                    return this.BadRequestCustom(ObjClass, null, _logger);
                }
                else if (MinAmt > ObjClass.Amount)
                {
                    initiateCreditPouchRechargeModelOutPut.Status = 0;
                    initiateCreditPouchRechargeModelOutPut.Reason = "Minimum amount should be " + _configuration.GetSection("RechargeSettings:MinimumAmount").Value;
                    return this.OkCustom(ObjClass, initiateCreditPouchRechargeModelOutPut, _logger);
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
                        if (result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].Status == 1)
                        {

                            Random rn = new Random();
                            var tid = rn.Next();
                            string req = null;
                            //These value will come from appsettings.json file.//
                            string reqerror = _configuration.GetSection("HDFCPG:ErrorUrl").Value;
                            string reqresponse = _configuration.GetSection("HDFCPG:ResponseUrl").Value;
                            string ReqTranportalId = _configuration.GetSection("HDFCPG:MerchentId").Value;
                            string order_id = result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].OrderId;
                            string currency = "INR"; decimal amount = ObjClass.Amount; string language = "EN";

                            Dictionary<string, string> objReq = new Dictionary<string, string> { };
                            objReq.Add("tid", tid.ToString());
                            objReq.Add("merchant_id", ReqTranportalId);
                            objReq.Add("currency", currency);
                            objReq.Add("amount", amount.ToString());
                            objReq.Add("order_id", result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].OrderId);
                            objReq.Add("language", language);
                            objReq.Add("redirect_url", reqresponse);
                            objReq.Add("cancel_url", reqerror);

                            req = "tid=" + tid + "&cancel_url=" + reqerror + "&currency=" + currency + "&amount=" + amount + "&language=" + language + "&redirect_url=" + reqresponse + "&merchant_id=" + ReqTranportalId + "&order_id=" + order_id + "&";

                            CCACrypto ccaCrypto = new CCACrypto();
                            if (!string.IsNullOrEmpty(req))
                            {
                                req = ccaCrypto.Encrypt(req, _configuration.GetSection("HDFCPG:Key").Value);

                            }
                            
                            ApiRequestResponse response = new ApiRequestResponse();
                            CPPGLoginResponse CPPGLoginResponse = new CPPGLoginResponse();
                            string apiurl = _configuration.GetSection("HDFCPG:ApiUrl").Value;

                            HttpResponseMessage apiResponse = Variables.CallPostAPI(apiurl + req, JsonConvert.SerializeObject(objReq), "").Result;
                            string json = string.Empty;
                            if (apiResponse.IsSuccessStatusCode)
                            {
                                json = apiResponse.Content.ReadAsStringAsync().Result;
                            }
                            initiateCreditPouchRechargeModelOutPut.OrderId = result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].OrderId;
                            response.BankName = "CP HDFC PG";
                            response.apiurl = apiurl;
                            response.request = JsonConvert.SerializeObject(objReq);
                            response.response = json;
                            response.UserId = ObjClass.Userid;
                            response.TransactionId = result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].OrderId;
                            response.request_Hash = req;
                            response.Amount = ObjClass.Amount;
                            response.CustomerId = ObjClass.CustomerId;
                            response.accessCode = _configuration.GetSection("HDFCPG:accessCode").Value;
                            initiateCreditPouchRechargeModelOutPut.Response = response;
                            //log entry of rqst & rspnce
                            _creditPouchRepo.InsertCPPGApiRequestResponse(response);
                            //-------------------------------------------------------------------------//
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
                                                getandInsertSendInputModel.CreatedBy = response.UserId;
                                                getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                                string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                                TemplateMessage = TemplateMessage
                                                    .Replace("[TranTrackid]", response.TransactionId)
                                                    .Replace("[Amount]", response.Amount.ToString());

                                                getandInsertSendInputModel.SMSText = TemplateMessage;
                                                getandInsertSendInputModel.MobileNo = result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].Mobile;
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
                                                insertEmailTextEntryInputModel.EmailIdTo = result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].email;
                                                insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                                insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                                insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                                string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                                if (result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].email == "")
                                                {
                                                    response.UserId = insertEmailTextEntryInputModel.EmailIdCC;
                                                }

                                                EmailTemplateMessage = EmailTemplateMessage
                                                    .Replace("[TranTrackid]", response.TransactionId)
                                                    .Replace("[Amount]", response.Amount.ToString());

                                                insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
                                                insertEmailTextEntryInputModel.CreatedBy = response.UserId;
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
                        else
                        {
                            return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].Reason);
                        }
                    }
                }
            }
            else
            {
                return this.Fail(ObjClass, null, _logger);
            }
        }
        

    }
}

  

