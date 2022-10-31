using HPPay.DataModel.JCB;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataRepository.JCB;
using HPPay.DataRepository.SMSGetSend;
using HPPay.Infrastructure.CommonClass;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [Route("/api/dtplus/JCB")]
    [ApiController]
    public class JCBController : ControllerBase
    {
        private readonly IJCBRepository _JCBRepo;
        private readonly ILogger<JCBController> _logger;
        private readonly ISMSGetSendRepository _GetSendRepo;
        public JCBController(ILogger<JCBController> logger, IJCBRepository JCBRepo, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _JCBRepo = JCBRepo;
            _GetSendRepo = GetSendRepo;
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_jcb_dealer_enrollment")]
        public async Task<IActionResult> InsertJCBDealerEnrollment([FromBody] JCBDealerEnrollmentModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.InsertJCBDealerEnrollment(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<JCBDealerEnrollmentModelOutput>().ToList()[0].Status == 1)
                    {
                        if (result.Cast<JCBDealerEnrollmentModelOutput>().ToList()[0].DealerStatus == 4)
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
                                        if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                                        {
                                            GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                                            getandInsertSendInputModel.CreatedBy = ObjClass.Userid;
                                            getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                            string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                            //TemplateMessage = TemplateMessage.Replace("", "");

                                            getandInsertSendInputModel.SMSText = TemplateMessage.Replace("@DealerID", result.Cast<JCBDealerEnrollmentModelOutput>().ToList()[0].DealerId.ToString()).
                                                                                                Replace("@password", result.Cast<JCBDealerEnrollmentModelOutput>().ToList()[0].Password.ToString()).
                                                                                                Replace("@Role", result.Cast<JCBDealerEnrollmentModelOutput>().ToList()[0].UserRole.ToString());//database
                                            getandInsertSendInputModel.MobileNo = ObjClass.MobileNo;//database
                                            getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo;//database
                                            getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Header;//database
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
                                            insertEmailTextEntryInputModel.EmailIdTo = ObjClass.EmailId;//database
                                            insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                            insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                            insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                            string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                            //database
                                            if (result.Cast<JCBDealerEnrollmentModelOutput>().ToList()[0].EmailId == "")
                                            {
                                                result.Cast<JCBDealerEnrollmentModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage.Replace("@DealerID", result.Cast<JCBDealerEnrollmentModelOutput>().ToList()[0].DealerId.ToString())
                                                                                       .Replace("@password", result.Cast<JCBDealerEnrollmentModelOutput>().ToList()[0].Password.ToString())
                                                                                       .Replace("@Role", result.Cast<JCBDealerEnrollmentModelOutput>().ToList()[0].UserRole.ToString());  // database

                                            insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");
                                            insertEmailTextEntryInputModel.CreatedBy = ObjClass.Userid;
                                            await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
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
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<JCBDealerEnrollmentModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_jcb_dealer_detail")]
        public async Task<IActionResult> GetJCBDealerDetail([FromBody] GetJCBDealerNameModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.GetJCBDealerDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetJCBDealerNameModelOutput> item = result.Cast<GetJCBDealerNameModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("enable_disable_jcb_dealer")]
        public async Task<IActionResult> EnableDisableJCBDealer([FromBody] EnableDisableJCBDealerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.EnableDisableJCBDealer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<EnableDisableJCBDealerModelOutput> item = result.Cast<EnableDisableJCBDealerModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_jcb_dealer_enrollment")]
        public async Task<IActionResult> UpdateALDealerEnrollment([FromBody] UpdateJCBDealerEnrollmentModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.UpdateJCBDealerEnrollment(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateJCBDealerEnrollmentModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<UpdateJCBDealerEnrollmentModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_jcb_officer_type")]
        public async Task<IActionResult> GetJCBOfficerType([FromBody] GetJCBOfficerTypeModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.GetJCBOfficerType(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetJCBOfficerTypeModelOutput> item = result.Cast<GetJCBOfficerTypeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_jcb_customer")]
        public async Task<IActionResult> insertJCBcustomer([FromForm] InsertJCBCustomerModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.InsertJCBCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].Status == 1)
                    {
                        if (result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].CustomerStatus == 4)
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
                                        if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                                        {
                                            GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                                            getandInsertSendInputModel.CreatedBy = ObjClass.Userid;
                                            getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                            string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                            TemplateMessage = TemplateMessage.Replace("@UserName",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].CustomerID.ToString()).Replace("@Email",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].EmailId).Replace("@CustomerID",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].CustomerID).Replace("@controlcardnumber",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].ControlCardNo).Replace("@customeruserpin",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].ControlPassword).Replace("@customerusername",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].CustomerID).Replace("@customerpassword",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].Password).Replace("@Password",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].Password).Replace("@ControlCardNo",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].ControlCardNo).Replace("@ControlPin",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].ControlPassword).Replace("[@CustomerCode]",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].CustomerID).Replace("[@ControlCardNumber]",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].ControlCardNo);

                                            getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");//database
                                            getandInsertSendInputModel.MobileNo = "";//database
                                            getandInsertSendInputModel.OfficerMobileNo = "";//database
                                            getandInsertSendInputModel.HeaderTemplate = "";//database
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
                                            insertEmailTextEntryInputModel.EmailIdTo = "";//database
                                            insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                            insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                            insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                            string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                            //database
                                            if (result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].EmailId == "")
                                            {
                                                result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage.Replace("@UserName",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].CustomerID.ToString()).Replace("@Email",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].EmailId).Replace("@CustomerID",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].CustomerID).Replace("@controlcardnumber",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].ControlCardNo).Replace("@customeruserpin",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].ControlPassword).Replace("@customerusername",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].CustomerID).Replace("@customerpassword",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].Password).Replace("@Password",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].Password).Replace("@ControlCardNo",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].ControlCardNo).Replace("@ControlPin",
                                                 result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].ControlPassword);

                                            insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");
                                            insertEmailTextEntryInputModel.CreatedBy = ObjClass.Userid;
                                            await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
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
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<InsertJCBCustomerModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_jcb_dealer_code")]
        public async Task<IActionResult> CheckjcbDealerCode([FromBody] CheckJCBDealerCodeModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.CheckJCBDealerCode(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CheckJCBDealerCodeModelOutput> item = result.Cast<CheckJCBDealerCodeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_availity_jcb_otc_card")]
        public async Task<IActionResult> GetAvailityJCBOTCCard([FromBody] GetAvailityJCBOTCCardModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.GetAvailityJCBOTCCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAvailityJCBOTCCardModelOutput> item = result.Cast<GetAvailityJCBOTCCardModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_dealer_wise_jcb_otc_card_request")]
        public async Task<IActionResult> InsertDealerWiseJCBOTCCardRequest([FromBody] InsertDealerWiseJCBOTCCardRequestModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.InsertDealerWiseJCBOTCCardRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertDealerWiseJCBOTCCardRequestModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<InsertDealerWiseJCBOTCCardRequestModelOutput>().ToList()[0].Reason);
                    }


                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_jcb_balance_otc_card")]
        public async Task<IActionResult> GetJCBBalanceOTCCard([FromBody] GetJCBBalanceOTCCardModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.GetJCBBalanceOTCCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetJCBBalanceOTCCardModelOutput> item = result.Cast<GetJCBBalanceOTCCardModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_jcb_dealer_otc_card_status")]
        public async Task<IActionResult> ViewJCBDealerOTCCardStatus([FromBody] ViewJCBDealerOTCCardStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.ViewJCBDealerOTCCardStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ViewJCBDealerOTCCardStatusModelOutput> item = result.Cast<ViewJCBDealerOTCCardStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_jcb_dealer_otc_card_detail")]
        public async Task<IActionResult> ViewJCBDealerOTCCardDetail([FromBody] ViewJCBDealerOTCCardDetailModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.ViewJCBDealerOTCCardDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.ObjJCBViewCardDetail.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_jcb_addon_otc_card_mapping_customer_details")]
        public async Task<IActionResult> GetAlAddonOTCCardMappingCustomerDetails([FromBody] GetJCBAddonOTCCardMappingCustomerDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.GetJCBAddonOTCCardMappingCustomerDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetCustomerNameAndNameOnCardOutput.Count > 0 && result.GetCustomerStatusOutput.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_jcb_sales_exe_empid_addon_otc_card_mapping")]
        public async Task<IActionResult> GetAlSalesExeEmpIdAddOnOTCCardMapping([FromBody] GetJCBSalesExeEmpIdAddOnOTCCardMappingModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.GetJCBSalesExeEmpIdAddOnOTCCardMapping(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetJCBSalesExeEmpIdAddOnOTCCardMappingModelOutput> item = result.Cast<GetJCBSalesExeEmpIdAddOnOTCCardMappingModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("jcb_addon_otc_card")]
        public async Task<IActionResult> AlAddOnOTCCard([FromBody] JCBAddOnOTCCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.JCBAddOnOTCCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<JCBAddOnOTCCardModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<JCBAddOnOTCCardModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 23-June-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("request_update_JCB_customer")]
        public async Task<IActionResult> RequestUpdateJCBCustomer([FromBody] JCBCustomerDetailUpdateModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.RequestUpdateJCBCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<JCBCustomerDetailUpdateModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<JCBCustomerDetailUpdateModelOutput>().ToList()[0].Reason);
                    }


                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_jcb_customer_Detail")]
        public async Task<IActionResult> UpdateJCBCustomer([FromBody] UpdateJCBCustomerDetailModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.UpdateJCBCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateJCBCustomerDetailModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, "");
                    }


                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 23-June-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("approval_jcb_customer_update_request")]
        public async Task<IActionResult> ApprovalJCBCustomerUpdateRequest([FromBody] ApprovalJCBCustomerUpdateRequestModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.ApprovalJCBCustomerUpdateRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ApprovalJCBCustomerUpdateRequestModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<ApprovalJCBCustomerUpdateRequestModelOutput>().ToList()[0].Reason);
                    }


                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <CreatedBy>Manmohan 13-06-2022</CreatedBy> 
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_jcb_customer_detail")]
        public async Task<IActionResult> GetJCBCustomerDetails([FromBody] JCBCustomerDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.GetJCBCustomerDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetCustomerDetails.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 13-06-2022</CreatedBy> 
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("search_jcb_manage_card")]
        public async Task<IActionResult> SearchJCBManageCard([FromBody] ManageJCBSearchCardsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.SearchManageCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ManageJCBSearchCardsModelOutput> item = result.Cast<ManageJCBSearchCardsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("jcb_get_card_limit_features")]
        public async Task<IActionResult> GetCardLimitFeatures([FromBody] GetJCBCardLimtModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.GetJCBCardLimitFeatures(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    if (result.GetCardsDetails.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_jcb_customer_balance_info")]
        public async Task<IActionResult> GetCustomerBalanceInfo([FromBody] GetJCBCustomerBalanceInfoModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.GetCustomerBalanceInfo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetJCBCustomerBalanceInfoModelOutput> item = result.Cast<GetJCBCustomerBalanceInfoModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_jcb_transactions_summary")]
        public async Task<IActionResult> GetJCBTransactionsSummary([FromBody] GetJCBTransactionsSummaryModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.GetJCBTransactionsSummary(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetTransactionsDetailSummary.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("JCB_update_mobile_and_fastag_no_in_card")]
        public async Task<IActionResult> JCBUpdateMobileandFastagNo([FromBody] JCBUpdateMobileandFastagNoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.JCBUpdateMobileandFastagNo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<JCBUpdateMobileandFastagNoModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<JCBUpdateMobileandFastagNoModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_jcb_mobile_and_fastagno")]
        public async Task<IActionResult> GetJCBMobileandFastagNo([FromBody] JCBGetMobileandFastagNoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.GetJCBMobileandFastagNo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Count() > 0)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, "");
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 25-06-2022</CreatedBy> 
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_jcb_advanced_search")]
        public async Task<IActionResult> GetJCBAdvancedSearch([FromBody] GetJCBAdvancedSearchModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.GetJCBAdvancedSearch(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetJCBAdvancedSearchModelOutput> item = result.Cast<GetJCBAdvancedSearchModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_JCB_communication_email_reset_password")]
        public async Task<IActionResult> GetJCBCommunicationEmailResetPassword([FromBody] GetJCBCommunicationEmailResetPasswordModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.GetJCBCommunicationEmailResetPassword(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetJCBCommunicationEmailResetPasswordModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_jcb_communication_email_reset_password")]
        public async Task<IActionResult> UpdateJCBCommunicationEmailResetPassword([FromBody] UpdateJCBCommunicationEmailResetPasswordModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.UpdateJCBCommunicationEmailResetPassword(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateJCBCommunicationEmailResetPasswordModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("jcb_update_hotlist_reactivate")]
        public async Task<IActionResult> UpdateJCBHotlistReactivate([FromBody] UpdateJCBHotlistReactivateModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.UpdateJCBHotlistReactivate(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateJCBHotlistReactivateModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateJCBHotlistReactivateModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("jcb_hotlist_reactive")]
        public async Task<IActionResult> GetJCBVHotListReactiveStatus([FromBody] GetJCBHotlistReactiveStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.GetJCBVHotListReactiveStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetJCBHotlistReactiveStatusModelOutput> item = result.Cast<GetJCBHotlistReactiveStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_jcb_dealer_communication_email_reset_password")]
        public async Task<IActionResult> UpdateJCBCommunicationEmailResetPassword([FromBody] UpdateJCBDealerCommunicationEmailResetPasswordModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.UpdateJCBDealerCommunicationEmailResetPassword(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateJCBDealerCommunicationEmailResetPasswordModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_jcb_dispatch_detail")]
        public async Task<IActionResult> GetJCBDispatchDetail([FromBody] GetJCBDispatchDetailModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.GetJCBDispatchDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetJCBDispatchDetailModelOutput> item = result.Cast<GetJCBDispatchDetailModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_jcb_customer_application_form_details")]
        public async Task<IActionResult> GetJCBCustomerApplicationFormNameOnCard([FromBody] GetJCBCustomerApplicationFormModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.GetJCBCustomerApplicationFormNameOnCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetJCBCustomerApplicationFormOutput.Count > 0 && result.GetJCBCustomerFormNameOnCard.Count > 0 && result.GetJCBCustomerApplicationFormOutput[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 26-08-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_jcb_upload_kyc_document")]
        public async Task<IActionResult> GetJCBUploadKycDocument([FromBody] GetJCBUploadKycDocumentsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.GetJCBUploadKycDocument(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetJCBUploadKycDocumentsModelOutput> item = result.Cast<GetJCBUploadKycDocumentsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 26-08-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_jcb_customer_kyc")]
        public async Task<IActionResult> UpdateJCBVCustomerKYC([FromForm] InsertJCBCustomerKYCModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.UpdateJCBCustomerKYC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertJCBCustomerKYCModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<InsertJCBCustomerKYCModelOutput>().ToList()[0].Reason);
                    }


                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 31-08-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_JCB_customer_detail_for_verification")]
        public async Task<IActionResult> GetAlCustomerDetailForVerification([FromBody] GetJCBCustomerDetailForVerificationModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.GetJCBCustomerDetailForVerification(ObjClass);
                if (result == null || result.Count() == 0)
                {
                    return this.Fail(ObjClass, result, _logger);
                }
                else
                {
                    return this.OkCustom(ObjClass, result, _logger);

                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 31-08-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_jcb_customer_status")]
        public async Task<IActionResult> GetALCustomerStatusDetail([FromBody] GetJCBCustomerStatusDetailInput ObjClass)
        {
            var result = await _JCBRepo.GetJCBCustomerStatusDetail(ObjClass);
            if (result == null || result.Count() == 0)
            {
                return this.FailCustom(null, result, _logger, "");
            }
            else
            {
                return this.OkCustom(null, result, _logger);

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 31-08-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_jcb_customer_status")]
        public async Task<IActionResult> UpdateALCustomerStatus([FromBody] UpdateJCBCustomerStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.UpdateJCBCustomerStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateJCBCustomerStatusModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateJCBCustomerStatusModelOutput>().ToList()[0].Reason);
                    }


                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 01-09-2022</CreatedBy> 
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_jcb_loyality_point_summary")]
        public async Task<IActionResult> GetJCBLoyalityPointSummary([FromBody] JCBLoyalityPointSummaryModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _JCBRepo.GetJCBLoyalityPointSummary(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<JCBLoyalityPointSummaryModelOutput> item = result.Cast<JCBLoyalityPointSummaryModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }
    }
}
