using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using HPPay_WebApi.ExtensionMethod;
using HPPay_WebApi.ActionFilters;
using System.Linq;
using HPPay.DataRepository.ParentCustomer;
using Microsoft.Extensions.Configuration;
using HPPay.DataModel.ParentCustomer;
using System.Collections.Generic;
using HPPay.DataRepository.SMSGetSend;
using HPPay.DataModel.SMSGetSend;
using System;

namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/hppay/ParentCustomer")]
    public class ParentCustomerController : ControllerBase
    {
        private readonly ILogger<ParentCustomerController> _logger;
        private readonly IParentCustomerRepository _parentCustomer;
        private readonly ISMSGetSendRepository _GetSendRepo;
        private readonly IConfiguration _configuration;

        public ParentCustomerController(ILogger<ParentCustomerController> logger, IParentCustomerRepository parentCustomer, IConfiguration configuration, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _parentCustomer = parentCustomer;
            _configuration = configuration;
            _GetSendRepo = GetSendRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_parent_customer")]
        public async Task<IActionResult> InsertParentCustomer([FromBody] CreateCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.InsertParentCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CreateCustomerModelOutput>().ToList()[0].Status == 1)
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
                                        getandInsertSendInputModel.CreatedBy = ObjClass.CreatedBy;
                                        getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                        string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                        TemplateMessage = TemplateMessage                                            
                                            .Replace("[RefNo]", result.Cast<CreateCustomerModelOutput>().ToList()[0].FormNumber.ToString())
                                            .Replace("@UserName", result.Cast<CreateCustomerModelOutput>().ToList()[0].FormNumber.ToString())
                                            .Replace("@Email", ObjClass.CommunicationEmailid);

                                        getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");
                                        getandInsertSendInputModel.MobileNo = ObjClass.CommunicationMobileNo;
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
                                        string ZOROEmaild = String.Empty;
                                        InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                        insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                                        insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                                        insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                                        insertEmailTextEntryInputModel.EmailIdTo = ObjClass.CommunicationEmailid;
                                        insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                        insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                        insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                        string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                        if (ObjClass.CommunicationEmailid == "")
                                        {
                                            ObjClass.CommunicationEmailid = insertEmailTextEntryInputModel.EmailIdCC;
                                        }

                                            EmailTemplateMessage = EmailTemplateMessage
                                            .Replace("[RefNo]",result.Cast<CreateCustomerModelOutput>().ToList()[0].FormNumber.ToString())
                                            .Replace("@UserName",result.Cast<CreateCustomerModelOutput>().ToList()[0].FormNumber.ToString())
                                            .Replace("@Email",ObjClass.CommunicationEmailid);

                                        insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");
                                        insertEmailTextEntryInputModel.CreatedBy = ObjClass.CreatedBy;
                                        await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
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
                            result.Cast<CreateCustomerModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_parent_customer_approval")]
        public async Task<IActionResult> GetParentCustomerForApproval([FromBody] GetParentCustomerApprovalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetParentCustomerForApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetParentCustomerApprovalModelOutput> item = result.Cast<GetParentCustomerApprovalModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("action_parent_customer_approval")]
        public async Task<IActionResult> ActionOnParentCustomerForApproval([FromBody] ActionOnParentCustomerForApprovalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.ActionOnParentCustomerForApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ActionOnParentCustomerForApprovalModelOutput>().ToList()[0].Status == 1)
                    {
                       
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<ActionOnParentCustomerForApprovalModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_parent_customer_auth")]
        public async Task<IActionResult> GetParentCustomerForAuth([FromBody] GetParentCustomerAuthModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetParentCustomerForAuth(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetParentCustomerAuthModelOutput> item = result.Cast<GetParentCustomerAuthModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }




        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("action_parent_customer_auth")]
        public async Task<IActionResult> ActionOnParentCustomerForAuth([FromBody] ActionOnParentCustomerForAuthModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.ActionOnParentCustomerForAuth(ObjClass);
                if (result == null)
                {
                    if (result.Cast<ActionOnParentCustomerForApprovalModelOutput>().ToList()[0].SendStatus == 4)
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
                                        getandInsertSendInputModel.CreatedBy = ObjClass.ApprovedBy;
                                        getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                        string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                        TemplateMessage = TemplateMessage.Replace("@UserName",
                                             result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].CustomerID.ToString()).Replace("@Email",
                                             result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].EmailId).Replace("@CustomerID",
                                             result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].CustomerID).Replace("@controlcardnumber",
                                             result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].ControlCardNo).Replace("@customeruserpin",
                                             result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].ControlPassword).Replace("@customerusername",
                                             result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].CustomerID).Replace("@customerpassword",
                                             result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].Password).Replace("@Password",
                                             result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].Password).Replace("@ControlCardNo",
                                             result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].ControlCardNo).Replace("@ControlPin",
                                             result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].ControlPassword).Replace("[@CustomerCode]",
                                             result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].CustomerID).Replace("[@ControlCardNumber]",
                                             result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].ControlCardNo);


                                        getandInsertSendInputModel.SMSText = TemplateMessage;
                                        getandInsertSendInputModel.MobileNo = result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].CommunicationMobileNo;
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
                                        string ZOROEmaild = String.Empty;
                                        InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                        insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                                        insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                                        insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                                        insertEmailTextEntryInputModel.EmailIdTo = result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].EmailId;
                                        insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                        insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                        insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                        string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                        if (result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].EmailId == "")
                                        {
                                            result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                        }

                                        EmailTemplateMessage = EmailTemplateMessage
                                            .Replace("@UserName", result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].CustomerID.ToString())
                                            .Replace("@Email", result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].EmailId)
                                            .Replace("@CustomerID", result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].CustomerID)
                                            .Replace("@controlcardnumber", result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].ControlCardNo)
                                            .Replace("@customeruserpin", result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].ControlPassword)
                                            .Replace("@customerusername", result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].CustomerID)
                                            .Replace("@customerpassword", result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].Password)
                                            .Replace("@Password", result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].Password)
                                            .Replace("@ControlCardNo", result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].ControlCardNo)
                                            .Replace("@ControlPin", result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].ControlPassword);

                                        insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
                                        insertEmailTextEntryInputModel.CreatedBy = ObjClass.ApprovedBy;
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
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<ActionOnParentCustomerForAuthModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_parent_customer_for_update")]
        public async Task<IActionResult> GetParentCustomerForUpdate([FromBody] GetParentCustomerForUpdateModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetParentCustomerForUpdate(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetParentCustomerForUpdateModelOutput> item = result.Cast<GetParentCustomerForUpdateModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_parent_customer_to_update")]
        public async Task<IActionResult> GetParentCustomerToUpdate([FromBody] GetParentCustomerToUpdateModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetParentCustomerToUpdate(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetParentCustomerDetails.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_parent_customer")]
        public async Task<IActionResult> UpdateParentCustomer([FromBody] ParentCustomerUpdateModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.UpdateParentCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ParentCustomerUpdateModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<ParentCustomerUpdateModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_parent_customer_dispatch_details")]
        public async Task<IActionResult> GetParentCustomerDispatchDetails([FromBody] GetParentCustomerDispatchModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetParentCustomerDispatchDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetParentCustomerDispatchDetailsModelOutput> item = result.Cast<GetParentCustomerDispatchDetailsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_parent_customer_card_details")]
        public async Task<IActionResult> GetParentCustomerCardDetails([FromBody] GetParentCustomerCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetParentCustomerCardDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetParentCustomerCardDetailsModelOutput> item = result.Cast<GetParentCustomerCardDetailsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_parent_customer_status_report")]
        public async Task<IActionResult> GetParentCustomerReportStatus([FromBody] ParentCustomerReportStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetParentCustomerReportStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ParentCustomerReportStatusModelOutput> item = result.Cast<ParentCustomerReportStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_parent_customer_status")]
        public async Task<IActionResult> GetParentCustomerStatus([FromBody] GetParentCustomerStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetParentCustomerStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetParentCustomerStatusModelOutput> item = result.Cast<GetParentCustomerStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
       // [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_parent_customer_balance_info")]
        public async Task<IActionResult> GetParentCustomerBalanceInfo([FromBody] GetParentCustomerBalanceInfoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetParentCustomerBalanceInfo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetParentCustomerBalanceInfo.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_parent_customer_card_wise_balances")]
        public async Task<IActionResult> GetParentCustomerCardWiseBalances([FromBody] GetParentCustomerCardWiseBalancesModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetParentCustomerCardWiseBalances(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetParentCustomerCardWiseBalancesModelOutput> item = result.Cast<GetParentCustomerCardWiseBalancesModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_parent_ccms_balance_info_for_customerId")]
        public async Task<IActionResult> GetParentCcmsBalanceInfoForCustomerId([FromBody] GetParentCcmsBalanceInfoForCustomerIdModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetParentCcmsBalanceInfoForCustomerId(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetParentCcmsBalanceInfoForCustomerIdModelOutput> item = result.Cast<GetParentCcmsBalanceInfoForCustomerIdModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_parent_customer_detail_by_customerId")]
        public async Task<IActionResult> GetParentCustomerDetailByCustomerId([FromBody] GetParentCustomerDetailByCustomerIdModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetParentCustomerDetailByCustomerId(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetParentCustomerDetails.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_parent_transactions_summary")]
        public async Task<IActionResult> GetParentTransactionsSummary([FromBody] GetParentTransactionsSummaryModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetParentTransactionsSummary(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetParentTransactionsSummaryModelOutput> item = result.Cast<GetParentTransactionsSummaryModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_child_by_parent")]
        public async Task<IActionResult> GetChildByParent([FromBody] GetChildByParenModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetChildByParent(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetChildByParenModelOutput> item = result.Cast<GetChildByParenModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_parent_transactions_summary_details")]
        public async Task<IActionResult> GetParentTransactionsSummaryDetails([FromBody] GetParentTransactionsSummaryDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetParentTransactionsSummaryDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetParentTransactionsSaleDetails.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_parent_customer_basic_search")]
        public async Task<IActionResult> GetParentCustomerBasicSearch([FromBody] GetParentCustomerBasicSearchModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetParentCustomerBasicSearch(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetParentCustomerBasicSearchModelOutput> item = result.Cast<GetParentCustomerBasicSearchModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_parent_customer_basic_search_card")]
        public async Task<IActionResult> GetParentCustomerBasicSearchCard([FromBody] GetParentCustomerBasicSearchCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetParentCustomerBasicSearchCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetParentCustomerBasicSearchCardModelOutput> item = result.Cast<GetParentCustomerBasicSearchCardModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("parent_customer_control_card_pin_reset")]
        public async Task<IActionResult> ParentCustomerControlCardPinReset([FromBody] ParentCustomerControlCardPinResetModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.ParentCustomerControlCardPinReset(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);

                }
                else
                {
                    if (result.Cast<ParentCustomerControlCardPinResetModelOutput>().ToList()[0].Status == 1)
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
        [Route("get_parent_customer_control_card_search")]
        public async Task<IActionResult> GetParentCustomerControlCardSearch([FromBody] GetParentCustomerControlCardSearchModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetParentCustomerControlCardSearch(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetParentCustomerControlCardSearchModelOutput> item = result.Cast<GetParentCustomerControlCardSearchModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("convert_parent_customer_to_aggregator")]
        public async Task<IActionResult> ConvertParentCustomertoAggregator([FromBody] ConvertParentCustomertoAggregatorModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.ConvertParentCustomertoAggregator(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ConvertParentCustomertoAggregatorModelOutput> item = result.Cast<ConvertParentCustomertoAggregatorModelOutput>().ToList();
                    if (item.Count > 0)
                    {
                        //Change the Parameters acordingly
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
                                    if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                                    {
                                        GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                                        getandInsertSendInputModel.CreatedBy = ObjClass.Userid;
                                        getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                        string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                        TemplateMessage = TemplateMessage
                                            .Replace("[RefNo]", result.Cast<CreateCustomerModelOutput>().ToList()[0].FormNumber.ToString())
                                            .Replace("@UserName", result.Cast<CreateCustomerModelOutput>().ToList()[0].FormNumber.ToString())
                                            .Replace("@Email", "");

                                        getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");
                                        getandInsertSendInputModel.MobileNo = "";
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
                                        string ZOROEmaild = String.Empty;
                                        InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                        insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                                        insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                                        insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                                        insertEmailTextEntryInputModel.EmailIdTo ="";
                                        insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                        insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                        insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                        string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                        //if (ObjClass.CommunicationEmailid == "")
                                        //{
                                        //    ObjClass.CommunicationEmailid = insertEmailTextEntryInputModel.EmailIdCC;
                                        //}

                                        EmailTemplateMessage = EmailTemplateMessage
                                        .Replace("[RefNo]", result.Cast<ConvertParentCustomertoAggregatorModelOutput>().ToList()[0].FormNumber.ToString())
                                        .Replace("@UserName", result.Cast<ConvertParentCustomertoAggregatorModelOutput>().ToList()[0].FormNumber.ToString())
                                        .Replace("@Email", "" );

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

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("pc_hdfc_transaction_status")]
        public async Task<IActionResult> PCHdfcTransactionStatus([FromBody] PCHdfcTransactionStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.PCHdfcTransactionStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<PCHdfcTransactionStatusModelOutPut> item = result.Cast<PCHdfcTransactionStatusModelOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("pc_configure_sms_alerts")]
        public async Task<IActionResult> PCConfigureSMSAlerts([FromBody] PCConfigureSMSAlertsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.PCConfigureSMSAlerts(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<PCConfigureSMSAlertsModelOutput> item = result.Cast<PCConfigureSMSAlertsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
       // [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_child_mapping_details")]
        public async Task<IActionResult> GetChildMappingDetails([FromBody] GetChildMappingDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetChildMappingDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Count() > 0 && result.Cast<GetChildMappingDetailsModelOutput>().ToList()[0].Status == 1)
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

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("parent_customer_child_mapping")]
        public async Task<IActionResult> ChildCustomerToParentCustomerMapping([FromBody] ParentCustomerChildMappingModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.ChildCustomerToParentCustomerMapping(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Count() > 0 && result.Cast<ParentCustomerChildMappingModelOutput>().ToList()[0].Status == 1)
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

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_parent_mapping_eligibility")]
        public async Task<IActionResult> CheckParentCustomerMappingEligibility([FromBody] CheckParentCustomerChildMappingModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.CheckParentCustomerMappingEligibility(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CheckParentCustomerChildMappingModelOutPut>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<CheckParentCustomerChildMappingModelOutPut>().ToList()[0].Reason);
                    }
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("parent_customer_child_mapping_eligibility")]
        public async Task<IActionResult> ChildCustomerToParentCustomerMappingEligibility([FromBody] CheckParentCustomerChildMappingModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.ChildCustomerToParentCustomerMappingEligibility(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CheckParentCustomerChildMappingModelOutPut>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<CheckParentCustomerChildMappingModelOutPut>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("pc_update_configure_sms_alerts")]
        public async Task<IActionResult> PCUpdateConfigureSMSAlerts([FromBody] PCUpdateConfigureSMSAlertsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.PCUpdateConfigureSMSAlerts(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<PCUpdateConfigureSMSAlertsModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<PCUpdateConfigureSMSAlertsModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("parent_to_child_and_child_parent_fund_allocation")]
        public async Task<IActionResult> GetDetailsForParentChildFundAllocation([FromBody] ParentToChildAndChildParentFundAllocationModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.ParentToChildAndChildParentFundAllocation(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetParentCustomer[0].Status == 1)
                    { 

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, result.GetParentCustomer[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("pc_child_customer_balance_info")]
        public async Task<IActionResult> PCChildCustomerBalanceInfo([FromBody] PCChildCustomerBalanceInfoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.PCChildCustomerBalanceInfo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<PCChildCustomerBalanceInfoModelOutPut> item = result.Cast<PCChildCustomerBalanceInfoModelOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("pc_ccms_balance_info")]
        public async Task<IActionResult> PCCCMSBalanceInfo([FromBody] PCCCMSBalanceInfoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.PCCCMSBalanceInfo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<PCCCMSBalanceInfoModelOutPut> item = result.Cast<PCCCMSBalanceInfoModelOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("pc_drivestars_balance_info")]
        public async Task<IActionResult> PCDrivestarsBalanceInfo([FromBody] PCDrivestarsBalanceInfoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.PCDrivestarsBalanceInfo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<PCDrivestarsBalanceInfoModelOutPut> item = result.Cast<PCDrivestarsBalanceInfoModelOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("pc_dnd_configure_sms_alerts")]
        public async Task<IActionResult> PCDNDConfigureSMSAlerts([FromBody] PCDNDConfigureSMSAlertsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.PCDNDConfigureSMSAlerts(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<PCDNDConfigureSMSAlertsModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<PCDNDConfigureSMSAlertsModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("transaction_details")]
        public async Task<IActionResult> TransactionDetails([FromBody] TransactionDetailsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.TransactionDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionDetailsModelOutPut>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TransactionDetailsModelOutPut>().ToList()[0].Reason);
                    }
                }
            }
        }
        [HttpPost]
       // [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_parent_to_child_and_child_parent_fund_allocation")]
        public async Task<IActionResult> ParentChildFundAllocation([FromBody] UpdateParenttoChildandChildParentFundAllocationModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.ParentChildFundAllocation(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<UpdateParenttoChildandChildParentFundAllocationModeloutput> item = result.Cast<UpdateParenttoChildandChildParentFundAllocationModeloutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("convert_parent_to_aggregator")]
        public async Task<IActionResult> ConvertParentToAggregator([FromBody] ParentToAggregatorCustomerUpdateModelInput ObjClass)
        {
            if (ObjClass == null)
            {

                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.ConvertParentToAggregator(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ParentToAggregatorCustomerUpdateModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<ParentToAggregatorCustomerUpdateModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_transaction_type_for_pc")]
        public async Task<IActionResult> GetTransactionType([FromBody] GetTransactionTypeInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.GetTransactionType(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetTransactionTypeOutPut> item = result.Cast<GetTransactionTypeOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_child_mapped_to_parrent")]
        public async Task<IActionResult> ViewChildMappedToParrent([FromBody] ViewChildMappedToParrentModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.ViewChildMappedToParrent(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                { 
                    List<ViewChildMappedToParrentModelOutPut> item = result.Cast<ViewChildMappedToParrentModelOutPut>().ToList();
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
        [Route("unmap_child_from_parrent")]
        public async Task<IActionResult> UnmapChildFromParrent([FromBody] UnMapChildFromParrentModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _parentCustomer.UnmapChildFromParrent(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<UnMapChildFromParrentModelOutPut> item = result.Cast<UnMapChildFromParrentModelOutPut>().ToList();
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


    }

}
