using CCA.Util;
using HPPay.DataModel.HDFCCreditPouch;
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

namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/hppay/HDFCCreditPouch")]
    public class HDFCCreditPouchController : ControllerBase
    {
        private readonly ILogger<HDFCCreditPouchController> _logger;
        private readonly ICreditPouchRepository _creditPouchRepo;
        private readonly IConfiguration _configuration;
        private readonly ISMSGetSendRepository _GetSendRepo;

        public HDFCCreditPouchController(ILogger<HDFCCreditPouchController> logger, ICreditPouchRepository creditPouchRepo, IConfiguration configuration, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _creditPouchRepo = creditPouchRepo;
            _configuration = configuration;
            _GetSendRepo = GetSendRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("chk_eligibility")]
        public async Task<IActionResult> CheckCreditPouchEligibility([FromBody] CheckCreditPouchEligibilityModelInput ObjClass)
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
        [Route("insrt_cp_rqst_by_customer")]
        public async Task<IActionResult> HDFCInsertCreditPouchDetailsByCustomer([FromBody] InsertCreditPouchDetailsByCustomerModelInput ObjClass)
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
        [Route("get_dtail_mo")]

        public async Task<IActionResult> GetCustomerDetailsForCreditPouchByMO([FromBody] GetCustomerDetailsForCreditPouchByMOModelInput ObjClass)
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
        [Route("insrt_cp_rqst")]
        public async Task<IActionResult> HDFCInsertCreditPouchDetailsByMO([FromBody] InsertCreditPouchDetailsModelInput ObjClass)
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
        [Route("action_cp")]
        public async Task<IActionResult> ActionOnCreditPouch([FromBody] ActionOnCreditPouchModelInput ObjClass)
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
                    //List<ActionOnCreditPouchModelOutput> item = result.Cast<ActionOnCreditPouchModelOutput>().ToList();
                    //if (item.Count > 0)
                    if (result.Cast<ActionOnCreditPouchModelOutput>().ToList()[0].Status == 1)
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
        [Route("get_cp_by_bank")]
        public async Task<IActionResult> GetCreditPouchDetalsAtBank([FromBody] GetCreditPouchDetalsAtBankInput ObjClass)
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
        [Route("auth_action_cp")]
        public async Task<IActionResult> HDFCAuthActionOnCreditPouch([FromBody] AuthActionOnCreditPouchModelInput ObjClass)
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
                    if (result.Cast<AuthActionOnCreditPouchModelOutput>().ToList()[0].Status == 1)
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
                        
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<AuthActionOnCreditPouchModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_cp_by_bank_auth")]
        public async Task<IActionResult> GetCreditPouchDetalsForAuth([FromBody] GetCreditPouchDetalsForAuthInput ObjClass)
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
        [Route("get_cp_status")]
        public async Task<IActionResult> GetCreditPouchStatus([FromBody] GetCreditPouchStatusInput ObjClass)
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
        [Route("get_cp_status_Report")]
        public async Task<IActionResult> GetCreditPouchStatusReport([FromBody] GetCreditPouchDetalsStatusReportInput ObjClass)
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
        [Route("initiate_cp_recharge")]
        public async Task<IActionResult> HDFCInitiateCPRecharge([FromBody] InitiateCreditPouchRechargeModelInput ObjClass)
        {
            bool possitive = ObjClass.Amount > 0;
            if (possitive)
            {
                if (ObjClass == null)
                {
                    return this.BadRequestCustom(ObjClass, null, _logger);
                }
                else
                {
                    var result = await _creditPouchRepo.InitiateCPRecharge(ObjClass);
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
            else
                return this.Fail(ObjClass, null, _logger);
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_cp_pg_log")]
        public async Task<IActionResult> InsertCPPGApiRequestResponse([FromBody] InitiateCreditPouchRechargeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.InitiateCPRecharge(ObjClass);

                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].Status == 1)
                    {
                         
                        ApiRequestResponse InitResponse = new ApiRequestResponse();
                        InitResponse.BankName = "CP HDFC PG";
                        InitResponse.UserId = ObjClass.Userid;
                        InitResponse.TransactionId = result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].OrderId;
                        InitResponse.Amount = ObjClass.Amount;
                        InitResponse.CustomerId = ObjClass.CustomerId;
                        InitResponse.ControlCardNo = result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].CCN;
                        InitResponse.accessCode = _configuration.GetSection("HDFCPG:accessCode").Value;
                        InitResponse.ActionType = "Add";
                        InitResponse.TrnsSource = "HDFC Bank - CCAvenue";
                        InitResponse.SourceId= Convert.ToInt32(result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].SourceId);
                        InitResponse.Formfactor = Convert.ToInt32(result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].FormFactor);
                        InitResponse.MerchantId = result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].MerchantId;
                        InitResponse.TerminalId = result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].TerminalId;
                        _creditPouchRepo.InsertCPPGApiRequestResponse(InitResponse);


                        GenericMethods objgm = new GenericMethods();
                        Random rn = new Random();
                        var tid = rn.Next();
                        string req = null;
                        //These value will come from appsettings.json file.//
                        string ErrorUrl = _configuration.GetSection("CPHDFCPG:ErrorUrl").Value;
                        string ResponseUrl = _configuration.GetSection("CPHDFCPG:ResponseUrl").Value;
                        string ReqTranportalId = _configuration.GetSection("CPHDFCPG:TranportalId").Value;
                        string ReqTranportalPassword = _configuration.GetSection("CPHDFCPG:TranportalPassword").Value;
                        string order_id = result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].OrderId;
                        string currency = "356"; decimal amount = ObjClass.Amount;
                        string ReqAction = "Purchase";
                        Dictionary<string, string> objReq = new Dictionary<string, string> { };
                        objReq.Add("ReqAction", ReqAction);
                        objReq.Add("ReqTranportalId", ReqTranportalId);
                        objReq.Add("ReqTranportalPassword", ReqTranportalPassword);
                        objReq.Add("udf1", "");
                        objReq.Add("udf2", "");
                        objReq.Add("udf3", "");
                        objReq.Add("udf4", "");
                        objReq.Add("udf5", "");
                        objReq.Add("ReqAmt", amount.ToString());
                        objReq.Add("reqCurrencycode", currency);
                        objReq.Add("reqTrackid", order_id);
                        objReq.Add("reqLanguid", "EN");
                        objReq.Add("responseURL", ResponseUrl);
                        objReq.Add("errorURL", ErrorUrl);
                        string tranreq = objgm.XMLFormation(objReq, "hosted_http");

                        string apiurl = null;
                        if (!string.IsNullOrEmpty(tranreq))
                        {
                            req = "&trandata=" + objgm.Encrypt(tranreq, _configuration.GetSection("CPHDFCPG:key").Value);
                            req = req + "&errorURL=" + ErrorUrl + "&responseURL=" + ResponseUrl + "&tranportalId=" + ReqTranportalId + "&password=" + ReqTranportalPassword;    
                            apiurl = _configuration.GetSection("CPHDFCPG:ApiUrl").Value + req;
                        }


                        //Dictionary<string, string> objReq = new Dictionary<string, string> { };
                        //objReq.Add("tid", tid.ToString());
                        //objReq.Add("merchant_id", ReqTranportalId);
                        //objReq.Add("currency", currency);
                        //objReq.Add("amount", amount.ToString());
                        //objReq.Add("order_id", result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].OrderId);
                        //objReq.Add("language", language);
                        //objReq.Add("redirect_url", reqresponse);
                        //objReq.Add("cancel_url", reqerror);

                        //req = "tid=" + tid + "&cancel_url=" + reqerror + "&currency=" + currency + "&amount=" + amount + "&language=" + language + "&redirect_url=" + reqresponse + "&merchant_id=" + ReqTranportalId + "&order_id=" + order_id + "&";

                        //CCACrypto ccaCrypto = new CCACrypto();
                        //if (!string.IsNullOrEmpty(req))
                        //{
                        //    req = ccaCrypto.Encrypt(req, _configuration.GetSection("CPHDFCPG:Key").Value);

                        //}
                        InitiateCreditPouchRechargeModelOutPut initiateCreditPouchRechargeModelOutPut = new InitiateCreditPouchRechargeModelOutPut();
                        ApiRequestResponse response = new ApiRequestResponse();
                        //CPPGLoginResponse CPPGLoginResponse = new CPPGLoginResponse();
                        //string apiurl = _configuration.GetSection("CPHDFCPG:ApiUrl").Value;

                        //HttpResponseMessage apiResponse = Variables.CallPostAPI(apiurl + req, JsonConvert.SerializeObject(objReq), "").Result;
                        //string json = string.Empty;
                        //if (apiResponse.IsSuccessStatusCode)
                        //{
                        //    json = apiResponse.Content.ReadAsStringAsync().Result;
                        //}
                        initiateCreditPouchRechargeModelOutPut.OrderId = result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].OrderId; 
                        response.apiurl = apiurl;
                        response.request = tranreq;
                        //JsonConvert.SerializeObject(objReq);
                        response.response = null;
                        response.UserId = ObjClass.Userid;
                        response.TransactionId = result.Cast<InitiateCreditPouchRechargeModelOutPut>().ToList()[0].OrderId;
                        response.request_Hash = req;
                        response.Amount = ObjClass.Amount;
                        response.CustomerId = ObjClass.CustomerId;
                        response.accessCode = _configuration.GetSection("HDFCPG:accessCode").Value;
                        response.ActionType = "Update";
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
      
        
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("hdfc_transaction_status")]
        public async Task<IActionResult> HdfcCPTransactionStatus([FromBody] HdfcTransactionStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.HdfcTransactionStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<HdfcTransactionStatusModelOutPut> item = result.Cast<HdfcTransactionStatusModelOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("hdfc_transaction_status_report")]
        public async Task<IActionResult> HdfcCPTransactionStatusReport([FromBody] HdfcTransactionStatusReportModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _creditPouchRepo.HdfcTransactionStatusReport(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<HdfcTransactionStatusModelOutPut> item = result.Cast<HdfcTransactionStatusModelOutPut>().ToList();
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
        public async Task<IActionResult> HDFCInsertCreditPouchReferralDetails([FromBody] InsertCreditPouchReferralDetailsModelInput ObjClass)
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
        public async Task<IActionResult> HDFCGetCreditPouchReferral([FromBody] GetCreditPouchDetalsReferralInput ObjClass)
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

       
    }

    
}
