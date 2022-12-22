using CCA.Util;
using HPPay.DataModel.Merchant;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataModel.Transaction;
using HPPay.DataRepository.Merchant;
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
    [Route("api/hppay/merchant")]
    [ApiController]

    public class MerchantController : ControllerBase
    {
        private readonly ILogger<MerchantController> _logger;

        private readonly IMerchantRepository _merchant;
        private readonly ISMSGetSendRepository _GetSendRepo;

        private readonly IConfiguration _configuration;
        public MerchantController(ILogger<MerchantController> logger, IMerchantRepository merchant, IConfiguration configuration, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _merchant = merchant;
            _configuration = configuration;
            _GetSendRepo = GetSendRepo;
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_merchant_type")]
        public async Task<IActionResult> GetMerchantType([FromBody] GetMerchantTypeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetMerchantType(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetMerchantTypeModelOutput> item = result.Cast<GetMerchantTypeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_outlet_category")]
        public async Task<IActionResult> GetOutletCategory([FromBody] GetMerchantOutletCategoryModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetOutletCategory(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetMerchantOutletCategoryModelOutput> item = result.Cast<GetMerchantOutletCategoryModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_sbu")]
        public async Task<IActionResult> GetSBU([FromBody] MerchantGetSBUModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetSBU(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantGetSBUModelOutput> item = result.Cast<MerchantGetSBUModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_merchant")]
        public async Task<IActionResult> InsertMerchant([FromBody] MerchantInsertModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.InsertMerchant(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<MerchantInsertModelOutput>().ToList()[0].Status == 1)
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

                                        TemplateMessage = TemplateMessage.Replace("[Process]", "Registration")
                                        .Replace("[Action]", "Placed").Replace("[UserId]", ObjClass.CreatedBy);

                                        getandInsertSendInputModel.SMSText = TemplateMessage;//database
                                        getandInsertSendInputModel.MobileNo = result.Cast<MerchantInsertModelOutput>().ToList()[0].MobileNo;//database
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
                                        string ZOROEmaild = String.Empty; //database

                                        InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                        insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                                        insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                                        insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                                        insertEmailTextEntryInputModel.EmailIdTo = result.Cast<MerchantInsertModelOutput>().ToList()[0].EmailId;//database
                                        insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                        insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                        insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                        string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                        //database
                                        if (result.Cast<MerchantInsertModelOutput>().ToList()[0].EmailId == "")
                                        {
                                            result.Cast<MerchantInsertModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                        }

                                        EmailTemplateMessage = EmailTemplateMessage.Replace("[Action]", "Placed").Replace("[Userid]", ObjClass.CreatedBy); // database

                                        insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
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
                            result.Cast<MerchantInsertModelOutput>().ToList()[0].Reason);
                    }


                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_merchant")]
        public async Task<IActionResult> UpdateMerchant([FromBody] MerchantUpdateModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.UpdateMerchant(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<MerchantUpdateModelOutput>().ToList()[0].Status == 1)
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
                                        getandInsertSendInputModel.CreatedBy = ObjClass.ModifiedBy;
                                        getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                        string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                        TemplateMessage = TemplateMessage.Replace("[Process]", "Updation")
                                            .Replace("[Action]", "Placed").Replace("[UserId]", ObjClass.ModifiedBy);

                                        getandInsertSendInputModel.SMSText = TemplateMessage;//database
                                        getandInsertSendInputModel.MobileNo = result.Cast<MerchantUpdateModelOutput>().ToList()[0].MobileNo;//database
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
                                        string ZOROEmaild = String.Empty; //database

                                        InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                        insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                                        insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                                        insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                                        insertEmailTextEntryInputModel.EmailIdTo = result.Cast<MerchantUpdateModelOutput>().ToList()[0].MobileNo;//database
                                        insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                        insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                        insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                        string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                        //database
                                        if (result.Cast<MerchantUpdateModelOutput>().ToList()[0].EmailId == "")
                                        {
                                            result.Cast<MerchantUpdateModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                        }

                                        EmailTemplateMessage = EmailTemplateMessage.Replace("[Action]", "Placed").Replace("[Userid]", ObjClass.ModifiedBy); // database

                                        insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
                                        insertEmailTextEntryInputModel.CreatedBy = ObjClass.ModifiedBy;
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
                            result.Cast<MerchantUpdateModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("approve_reject_merchant")]
        public async Task<IActionResult> ApproveRejectMerchant([FromBody] MerchantApprovalRejectModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.ApproveRejectMerchant(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<MerchantApprovalRejectModelOutput>().ToList()[0].Status == 1)
                    {
                        GetNewlyCreatedTerminalIdsBasedOnErpCodesModelInput getNewlyCreatedTerminalIdsBasedOnErpCodesModelInput = new GetNewlyCreatedTerminalIdsBasedOnErpCodesModelInput();
                        getNewlyCreatedTerminalIdsBasedOnErpCodesModelInput.ObjApprovalRejectDetail = ObjClass.ObjApprovalRejectDetail;
                        var terminalResult = await _merchant.GetNewlyCreatedTerminalIdsBasedOnErpCodes(getNewlyCreatedTerminalIdsBasedOnErpCodesModelInput);

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
                                    if (result.Cast<MerchantApprovalRejectModelOutput>().ToList()[0].SendStatus != 4)
                                    {
                                        List<MerchantApprovalRejectModelOutput> item1 = result.Cast<MerchantApprovalRejectModelOutput>().ToList();
                                        for (int j = 0; j < item1.Count; j++)
                                        {
                                            if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSEmailStatus == "2")
                                            {
                                                if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                                                {
                                                    GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                                                    getandInsertSendInputModel.CreatedBy = ObjClass.ApprovedBy;
                                                    getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                                    string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                                    TemplateMessage = TemplateMessage.Replace("[Process]", "Registration")
                                                    .Replace("[Action]", "Rejected").Replace("[UserId]", ObjClass.ApprovedBy);

                                                    getandInsertSendInputModel.SMSText = TemplateMessage;//database
                                                    getandInsertSendInputModel.MobileNo = item1[i].MobileNo;//database
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
                                                    string ZOROEmaild = String.Empty; //database

                                                    InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                                    insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                                                    insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                                                    insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                                                    insertEmailTextEntryInputModel.EmailIdTo = item1[i].EmailId;//database
                                                    insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                                    insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                                    insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                                    string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                                    //database
                                                    if (item1[i].EmailId == "")
                                                    {
                                                        item1[i].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                                    }

                                                    EmailTemplateMessage = EmailTemplateMessage.Replace("[Action]", "Rejected").Replace("[Userid]", ObjClass.ApprovedBy); // database

                                                    insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
                                                    insertEmailTextEntryInputModel.CreatedBy = ObjClass.ApprovedBy;
                                                    await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSEmailStatus == "1")
                                        {
                                            List<GetNewlyCreatedTerminalIdsBasedOnErpCodesModelOutput> item2 = terminalResult.Cast<GetNewlyCreatedTerminalIdsBasedOnErpCodesModelOutput>().ToList();
                                            for (int k = 0; k < item2.Count; k++)
                                            {
                                                if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                                                {
                                                    GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                                                    getandInsertSendInputModel.CreatedBy = ObjClass.ApprovedBy;
                                                    getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                                    string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                                    TemplateMessage = TemplateMessage.Replace("[TerminalId]", item2[k].TerminalId)
                                                    .Replace("[IAC]", item2[k].IAC);

                                                    getandInsertSendInputModel.SMSText = TemplateMessage;//database
                                                    getandInsertSendInputModel.MobileNo = item2[k].MobileNo;//database
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
                                                    string ZOROEmaild = String.Empty; //database

                                                    InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                                    insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                                                    insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                                                    insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                                                    insertEmailTextEntryInputModel.EmailIdTo = item2[k].EmailId;//database
                                                    insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                                    insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                                    insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                                    string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                                    //database
                                                    if (item2[k].EmailId == "")
                                                    {
                                                        item2[k].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                                    }

                                                    EmailTemplateMessage = EmailTemplateMessage.Replace("[IAC]", item2[k].IAC)
                                                        .Replace("[TerminalId]", item2[k].TerminalId)
                                                        .Replace("[MerchantId]", item2[k].MerchantId)
                                                        .Replace("[RetailOutletName]", item2[k].RetailOutletName)
                                                        .Replace("[RegionalOffice]", item2[k].RegionalOfficeName); // database

                                                    insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
                                                    insertEmailTextEntryInputModel.CreatedBy = ObjClass.ApprovedBy;
                                                    await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
                                                }
                                            }

                                        }
                                        if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSEmailStatus != "1")
                                        {
                                            List<MerchantApprovalRejectModelOutput> item1 = result.Cast<MerchantApprovalRejectModelOutput>().ToList();
                                            for (int j = 1; j < item1.Count; j++)
                                            {
                                                if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSEmailStatus == "2")
                                                {
                                                    if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                                                    {
                                                        GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                                                        getandInsertSendInputModel.CreatedBy = ObjClass.ApprovedBy;
                                                        getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                                        string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                                        TemplateMessage = TemplateMessage.Replace("[Process]", "Registration")
                                                        .Replace("[Action]", "Approved").Replace("[UserId]", ObjClass.ApprovedBy);

                                                        getandInsertSendInputModel.SMSText = TemplateMessage;//database
                                                        getandInsertSendInputModel.MobileNo = item1[j].MobileNo;//database
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
                                                        string ZOROEmaild = String.Empty; //database

                                                        InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                                        insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                                                        insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                                                        insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                                                        insertEmailTextEntryInputModel.EmailIdTo = item1[j].EmailId;//database
                                                        insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                                        insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                                        insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                                        string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                                        //database
                                                        if (item1[j].EmailId == "")
                                                        {
                                                            item1[j].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                                        }

                                                        EmailTemplateMessage = EmailTemplateMessage.Replace("[Action]", "Approved").Replace("[Userid]", ObjClass.ApprovedBy); // database

                                                        insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
                                                        insertEmailTextEntryInputModel.CreatedBy = ObjClass.ApprovedBy;
                                                        await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
                                                    }
                                                }

                                                if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSEmailStatus == "3")
                                                {
                                                    if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                                                    {
                                                        GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                                                        getandInsertSendInputModel.CreatedBy = ObjClass.ApprovedBy;
                                                        getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                                        string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                                        TemplateMessage = TemplateMessage.Replace("[Pwd]", item1[j].Password)
                                                        .Replace("[Userid]", item1[j].MerchantId);

                                                        getandInsertSendInputModel.SMSText = TemplateMessage;//database
                                                        getandInsertSendInputModel.MobileNo = item1[j].MobileNo;//database
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
                                                        string ZOROEmaild = String.Empty; //database

                                                        InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                                        insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                                                        insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                                                        insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                                                        insertEmailTextEntryInputModel.EmailIdTo = item1[j].EmailId;//database
                                                        insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                                        insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                                        insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                                        string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                                        //database
                                                        if (item1[j].EmailId == "")
                                                        {
                                                            item1[j].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                                        }

                                                        EmailTemplateMessage = EmailTemplateMessage.Replace("[Pwd]", item1[j].Password).Replace("[UserId]", item1[j].MerchantId); // database

                                                        insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
                                                        insertEmailTextEntryInputModel.CreatedBy = ObjClass.ApprovedBy;
                                                        await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
                                                    }
                                                }
                                            }
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
                            result.Cast<MerchantApprovalRejectModelOutput>().ToList()[0].Reason);
                    }
                }
            }


        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_merchant_by_merchant_Id")]
        public async Task<IActionResult> GetMerchantbyMerchantId([FromBody] MerchantGetByMerchantIdModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetMerchantbyMerchantId(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantGetByMerchantIdModelOutput> item = result.Cast<MerchantGetByMerchantIdModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }

        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_merchant_data_update_request_before_approval")]
        public async Task<IActionResult> GetMerchantDataUpdateRequestBeforeApproval([FromBody] GetMerchantDataUpdateRequestBeforeApprovalModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetMerchantDataUpdateRequestBeforeApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetMerchantDataUpdateRequestBeforeApprovalModelOutput> item = result.Cast<GetMerchantDataUpdateRequestBeforeApprovalModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_merchant_by_erp_code")]
        public async Task<IActionResult> GetMerchantbyERPCode([FromBody] MerchantGetByErpCodeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetMerchantbyERPCode(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantGetByMerchantIdModelOutput> item = result.Cast<MerchantGetByMerchantIdModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_merchant_approval_list")]
        public async Task<IActionResult> GetMerchantApproval([FromBody] MerchantGetMerchantApprovalModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetMerchantApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantGetMerchantApprovalModelOutput> item = result.Cast<MerchantGetMerchantApprovalModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_rejected_merchant")]
        public async Task<IActionResult> GetRejectedMerchant([FromBody] RejectedMerchantModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetRejectedMerchant(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<RejectedMerchantModelOutput> item = result.Cast<RejectedMerchantModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("search_merchant_for_card_creation")]
        public async Task<IActionResult> SearchMerchantForCardCreation([FromBody] MerchantSearchMerchantForCardCreationModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.SearchMerchantForCardCreation(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantSearchMerchantForCardCreationModelOutput> item = result.Cast<MerchantSearchMerchantForCardCreationModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("verify_merchant_by_merchant_id")]
        public async Task<IActionResult> VerifyMerchantByMerchantId([FromBody] VerifyMerchantByMerchantIdModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.VerifyMerchantByMerchantId(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<VerifyMerchantByMerchantIdModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<VerifyMerchantByMerchantIdModelOutput>().ToList()[0].Reason);
                    }


                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("verify_merchant_by_merchant_id_and_regional_id")]
        public async Task<IActionResult> VerifyMerchantByMerchantIdandRegionalId([FromBody] VerifyMerchantByMerchantIdandRegionalIdModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.VerifyMerchantByMerchantIdandRegionalId(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<VerifyMerchantByMerchantIdandRegionalIdModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<VerifyMerchantByMerchantIdandRegionalIdModelOutput>().ToList()[0].Reason);
                    }


                }
            }

        }




        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("search_merchant")]
        public async Task<IActionResult> SearchMerchant([FromBody] MerchantSearchMerchantModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.SearchMerchant(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantSearchMerchantModelOutput> item = result.Cast<MerchantSearchMerchantModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_merchant_status")]
        public async Task<IActionResult> GetMerchantStatus([FromBody] MerchantGetMerchantStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetMerchantStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantGetMerchantStatusModelOutput> item = result.Cast<MerchantGetMerchantStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_merchant_caution_limit")]
        public async Task<IActionResult> ViewMerchantCautionLimit([FromBody] MerchantViewMerchantCautionLimitModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.ViewMerchantCautionLimit(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantViewMerchantCautionLimitModelOutput> item = result.Cast<MerchantViewMerchantCautionLimitModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("merchant_settlement_detail")]
        public async Task<IActionResult> MerchantSettlementDetail([FromBody] MerchantSettlementDetailsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.MerchantSettlementDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantSettlementDetailsModelOutput> item = result.Cast<MerchantSettlementDetailsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("merchant_batch_detail")]
        public async Task<IActionResult> MerchantBatchDetail([FromBody] MerchantBatchDetailModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.MerchantBatchDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantBatchDetailModelOutput> item = result.Cast<MerchantBatchDetailModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("merchant_transaction_detail")]
        public async Task<IActionResult> MerchantTransactionDetail([FromBody] MerchantTransactionDetailModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.MerchantTransactionDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantTransactionDetailModelOutput> item = result.Cast<MerchantTransactionDetailModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("merchant_sale_reload_delta_detail")]
        public async Task<IActionResult> MerchantSaleReloadDeltaDetail([FromBody] MerchantSaleReloadDeltaDetailModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.MerchantSaleReloadDeltaDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantSaleReloadDeltaDetailModelOutput> item = result.Cast<MerchantSaleReloadDeltaDetailModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("merchant_erp_reload_sale_earning_detail")]
        public async Task<IActionResult> MerchantERPReloadSaleEarningDetail([FromBody] MerchantERPReloadSaleEarningDetailModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.MerchantERPReloadSaleEarningDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantERPReloadSaleEarningDetailModelOutput> item = result.Cast<MerchantERPReloadSaleEarningDetailModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("merchant_receivable_payable_detail")]
        public async Task<IActionResult> MerchantReceivablePayableDetail([FromBody] MerchantReceivablePayableDetailModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.MerchantReceivablePayableDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantReceivablePayableDetailModelOutput> item = result.Cast<MerchantReceivablePayableDetailModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("validate_merchant_erp_code")]
        public async Task<IActionResult> ValidateMerchantErpCode([FromBody] ValidateMerchantErpCodeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.ValidateMerchantErpCode(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ValidateMerchantErpCodeModelOutput> item = result.Cast<ValidateMerchantErpCodeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_mapped_merchant_id")]
        public async Task<IActionResult> CheckMappedMerchantID([FromBody] CheckMappedMerchantIDModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.CheckMappedMerchantID(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CheckMappedMerchantIDModelOutput> item = result.Cast<CheckMappedMerchantIDModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("approve_reject_merchant_update")]
        public async Task<IActionResult> ApproveRejectMerchantUpdate([FromBody] ApproveRejectMerchantUpdateModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.ApproveRejectMerchantUpdate(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ApproveRejectMerchantUpdateModelOutput>().ToList()[0].Status == 1)
                    {

                        if (result.Cast<ApproveRejectMerchantUpdateModelOutput>().ToList()[0].SendStatus != 4)
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

                                            TemplateMessage = TemplateMessage.Replace("", "");

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
                                            string ZOROEmaild = String.Empty; //database

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
                                            //if (result.Cast<ApproveRejectMerchantUpdateModelOutput>().ToList()[0].EmailId == "")
                                            //{
                                            //    result.Cast<ApproveRejectMerchantUpdateModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                            //}

                                            EmailTemplateMessage = EmailTemplateMessage.Replace("", ""); // database

                                            insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");
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

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<ApproveRejectMerchantUpdateModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("merchant_reactivation_status")]
        public async Task<IActionResult> MerchantReactivationStatus([FromBody] MerchantReactivationStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.MerchantReactivationStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantReactivationStatusModelOutput> item = result.Cast<MerchantReactivationStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("merchant_reactivation_request")]
        public async Task<IActionResult> MerchantReactivationRequest([FromBody] MerchantReactivationRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.MerchantReactivationRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<MerchantReactivationRequestModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<MerchantReactivationRequestModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_hotlisted_month_year")]
        public async Task<IActionResult> GetHotlistedMonthYear([FromBody] MerchantGetHotlistedMonthYearModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetHotlistedMonthYear(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantGetHotlistedMonthYearModelOuput> item = result.Cast<MerchantGetHotlistedMonthYearModelOuput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }

        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_approved_merchant_reactivation_status")]
        public async Task<IActionResult> GetApprovedMerchantReactivationStatus([FromBody] GetApprovedMerchantReactivationStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetApprovedMerchantReactivationStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetApprovedMerchantReactivationStatusModelOutput> item = result.Cast<GetApprovedMerchantReactivationStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("Get_Request_For_Approval_Reactivate_Merchant")]
        public async Task<IActionResult> GetRequestForApprovalReactivateMerchant([FromBody] GetRequestForApprovalReactivateMerchantModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetRequestForApprovalReactivateMerchant(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetRequestForApprovalReactivateMerchantModelOutput> item = result.Cast<GetRequestForApprovalReactivateMerchantModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }

        }

        [HttpPost]
       // [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_request_reactivation_merchant")]
        public async Task<IActionResult> GetRequestReactivationMerchant([FromBody] MerchantGetRequestReactivationMerchantModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetRequestReactivationMerchant(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantGetRequestReactivationMerchantModelOutput> item = result.Cast<MerchantGetRequestReactivationMerchantModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("approve_merchant_reactivation_request")]
        public async Task<IActionResult> ApproveMerchantReactivationRequest([FromBody] MerchantApproveMerchantReactivationRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.ApproveMerchantReactivationRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<MerchantApproveMerchantReactivationRequestModelOuput>().ToList()[0].Status == 1)
                    {
                        if (result.Cast<MerchantApproveMerchantReactivationRequestModelOuput>().ToList()[0].SendStatus != 4)
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

                                            TemplateMessage = TemplateMessage.Replace("", "");

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
                                            string ZOROEmaild = String.Empty; //database

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
                                            //if (result.Cast<MerchantApproveMerchantReactivationRequestModelOuput>().ToList()[0].EmailId == "")
                                            //{
                                            //    result.Cast<MerchantApproveMerchantReactivationRequestModelOuput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                            //}

                                            EmailTemplateMessage = EmailTemplateMessage.Replace("", ""); // database

                                            insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");
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

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<MerchantApproveMerchantReactivationRequestModelOuput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_mobile_dispenser_retail_outlet_mapping")]
        public async Task<IActionResult> InsertMobileDispenserRetailOutletMapping([FromBody] InsertMobileDispenserRetailOutletMappingModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.InsertMobileDispenserRetailOutletMapping(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertMobileDispenserRetailOutletMappingModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<InsertMobileDispenserRetailOutletMappingModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("approve_mobile_dispenser_retail_outlet_mapping")]
        public async Task<IActionResult> ApproveMobileDispenserRetailOutletMapping([FromBody] MerchantApproveMobileDispenserRetailOutletMappingModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.ApproveMobileDispenserRetailOutletMapping(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<MerchantApproveMobileDispenserRetailOutletMappingModelOutput>().ToList()[0].Status == 1)
                    {
                        if (result.Cast<MerchantApproveMobileDispenserRetailOutletMappingModelOutput>().ToList()[0].SendStatus != 4)
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
                                            getandInsertSendInputModel.CreatedBy = ObjClass.ModifiedBy;
                                            getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                            string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                            TemplateMessage = TemplateMessage.Replace("", "");

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
                                            string ZOROEmaild = String.Empty; //database

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
                                            //if (result.Cast<MerchantApproveMobileDispenserRetailOutletMappingModelOutput>().ToList()[0].EmailId == "")
                                            //{
                                            //    result.Cast<MerchantApproveMobileDispenserRetailOutletMappingModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                            //}

                                            EmailTemplateMessage = EmailTemplateMessage.Replace("", ""); // database

                                            insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");
                                            insertEmailTextEntryInputModel.CreatedBy = ObjClass.ModifiedBy;
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
                            result.Cast<MerchantApproveMobileDispenserRetailOutletMappingModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_mobile_dispenser_retail_outlet_mapping")]
        public async Task<IActionResult> GetMobileDispenserRetailOutletMapping([FromBody] MerchantGetMobileDispenserRetailOutletMappingModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetMobileDispenserRetailOutletMapping(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantGetMobileDispenserRetailOutletMappingModelOutput> item = result.Cast<MerchantGetMobileDispenserRetailOutletMappingModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }

        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_mobile_dispenser")]
        public async Task<IActionResult> GetMobileDispenser([FromBody] MerchantGetMobileDispenserModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetMobileDispenser(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantGetMobileDispenserModelOutput> item = result.Cast<MerchantGetMobileDispenserModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_mapped_parent_merchantid")]
        public async Task<IActionResult> GetMappedParentMerchantId([FromBody] GetMappedParentMerchantIdModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetMappedParentMerchantId(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetMappedParentMerchantIdModelOutput> item = result.Cast<GetMappedParentMerchantIdModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_approve_terminal_merchant_mapping")]
        public async Task<IActionResult> GetApproveTerminalMerchantMapping([FromBody] MerchantGetApproveTerminalMerchantMappingModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetApproveTerminalMerchantMapping(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantGetApproveTerminalMerchantMappingModelOutput> item = result.Cast<MerchantGetApproveTerminalMerchantMappingModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("approve_terminal_merchant_mapping")]
        public async Task<IActionResult> ApproveTerminalMerchantMapping([FromBody] MerchantApproveTerminalMerchantMappingModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.ApproveTerminalMerchantMapping(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<MerchantApproveTerminalMerchantMappingModelOutput>().ToList()[0].Status == 1)
                    {
                        if (result.Cast<MerchantApproveTerminalMerchantMappingModelOutput>().ToList()[0].SendStatus != 4)
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
                                            getandInsertSendInputModel.CreatedBy = ObjClass.ModifiedBy;
                                            getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                            string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                            TemplateMessage = TemplateMessage.Replace("", "");

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
                                            string ZOROEmaild = String.Empty; //database

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
                                            //if (result.Cast<MerchantApproveTerminalMerchantMappingModelOutput>().ToList()[0].EmailId == "")
                                            //{
                                            //    result.Cast<MerchantApproveTerminalMerchantMappingModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                            //}

                                            EmailTemplateMessage = EmailTemplateMessage.Replace("", ""); // database

                                            insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");
                                            insertEmailTextEntryInputModel.CreatedBy = ObjClass.ModifiedBy;
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
                            result.Cast<MerchantApproveTerminalMerchantMappingModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_terminal_details_for_managterminal")]
        public async Task<IActionResult> GetTerminalDetailsForManagTerminal([FromBody] GetTerminalDetailsForManagTerminalModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetTerminalDetailsForManagTerminal(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    // List<GetTerminalDetailsForManagTerminalModelOutput> item = result.Cast<GetTerminalDetailsForManagTerminalModelOutput>().ToList();
                    if (result.tblTerminalSubtblTransaction.Count > 0 && result.tblmstStatusSubTerminalLog.Count > 0 && result.tblMobileDispenserRetailOutletMapping.Count > 0 && result.tblTransaction.Count > 0)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_balance_ccms_recharge_by_mobiledispenser")]
        public async Task<IActionResult> UspGetBalanceCCMSRechargebyMobiledispenser([FromBody] GetBalanceCCMSRechargebyMobiledispenserModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetBalanceCCMSRechargebyMobiledispenser(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetBalanceCCMSRechargebyMobiledispenserModelOutput> item = result.Cast<GetBalanceCCMSRechargebyMobiledispenserModelOutput>().ToList();
                    if (item.Count > 0)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("initiate_ccms_mobiledispercer_recharge")]
        public async Task<IActionResult> InitiateCCMSMobileDispercerRecharge([FromBody] GetCCMSRechargebyMobiledispenserModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.InitiateCCMSMobileDispercerRecharge(ObjClass);

                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCCMSRechargebyMobiledispenserModelOutput> item = result.Cast<GetCCMSRechargebyMobiledispenserModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_ccms_mobiledispencer_gapirequestresponse")]
        public async Task<IActionResult> InsertCCMSMobileDispencerGApiRequestResponse([FromBody] GetCCMSRechargebyMobiledispenserModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.InitiateCCMSMobileDispercerRecharge(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetCCMSRechargebyMobiledispenserModelOutput>().ToList()[0].Status == 1)
                    {

                        //------------------------------------------------------


                        Random rn = new Random();
                        var tid = rn.Next();
                        string req = null;
                        string reqerror = _configuration.GetSection("HDFCPG:ErrorUrl").Value;
                        string reqresponse = _configuration.GetSection("HDFCPG:ResponseUrl").Value;
                        string ReqTranportalId = _configuration.GetSection("HDFCPG:MerchentId").Value;
                        string order_id = result.Cast<GetCCMSRechargebyMobiledispenserModelOutput>().ToList()[0].OrderId;
                        string currency = "INR"; decimal amount = ObjClass.Amount; string language = "EN";

                        Dictionary<string, string> objReq = new Dictionary<string, string> { };
                        objReq.Add("tid", tid.ToString());
                        objReq.Add("merchant_id", ReqTranportalId);
                        objReq.Add("currency", currency);
                        objReq.Add("amount", amount.ToString());
                        objReq.Add("order_id", result.Cast<GetCCMSRechargebyMobiledispenserModelOutput>().ToList()[0].OrderId);
                        objReq.Add("language", language);
                        objReq.Add("redirect_url", reqresponse);
                        objReq.Add("cancel_url", reqerror);

                        //  string tranreq = objgm.XMLFormation(objReq, "hosted_http");
                        req = "tid=" + tid + "&cancel_url=" + reqerror + "&currency=" + currency + "&amount=" + amount + "&language=" + language + "&redirect_url=" + reqresponse + "&merchant_id=" + ReqTranportalId + "&order_id=" + order_id + "&";


                        CCACrypto ccaCrypto = new CCACrypto();
                        if (!string.IsNullOrEmpty(req))
                        {
                            req = ccaCrypto.Encrypt(req, _configuration.GetSection("HDFCPG:Key").Value);

                        }
                        //------------------------------------------------------
                        GetCCMSRechargebyMobiledispenserModelOutput initiateCreditPouchRechargeModelOutPut = new GetCCMSRechargebyMobiledispenserModelOutput();
                        ApiRequestResponse response = new ApiRequestResponse();
                        CPPGLoginResponse CPPGLoginResponse = new CPPGLoginResponse();
                        string apiurl = _configuration.GetSection("HDFCPG:ApiUrl").Value;

                        HttpResponseMessage apiResponse = Variables.CallPostAPI(apiurl + req, JsonConvert.SerializeObject(objReq), "").Result;
                        string json = string.Empty;

                        if (apiResponse.IsSuccessStatusCode)
                        {
                            json = apiResponse.Content.ReadAsStringAsync().Result;
                        }
                        initiateCreditPouchRechargeModelOutPut.OrderId = result.Cast<GetCCMSRechargebyMobiledispenserModelOutput>().ToList()[0].OrderId;
                        response.BankName = "HDFC Mobile Dispenser";
                        response.apiurl = apiurl;
                        response.request = JsonConvert.SerializeObject(objReq);
                        response.response = json;
                        response.UserId = ObjClass.Userid;
                        response.TransactionId = result.Cast<GetCCMSRechargebyMobiledispenserModelOutput>().ToList()[0].OrderId;
                        response.request_Hash = req;
                        response.CustomerId = ObjClass.CustomerID;
                        response.Amount = ObjClass.Amount;
                        response.accessCode = _configuration.GetSection("HDFCPG:accessCode").Value;
                        initiateCreditPouchRechargeModelOutPut.Response = response;
                        //log entry of rqst & rspnce
                        _merchant.InsertCCMSMobileDispencerGApiRequestResponse(response);
                        return this.OkCustom(ObjClass, initiateCreditPouchRechargeModelOutPut, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                        result.Cast<GetCCMSRechargebyMobiledispenserModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_mobile_dispenser_customer")]
        public async Task<IActionResult> InsertMobileDispenserCustomer([FromBody] MerchantInsertMobileDispenserCustomerModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.InsertMobileDispenserCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<MerchantInsertMobileDispenserCustomerModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<MerchantInsertMobileDispenserCustomerModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_terminal_details")]
        public async Task<IActionResult> InsertTerminalDetails([FromBody] MerchantInsertTerminalDetailsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.InsertTerminalDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<MerchantInsertTerminalDetailsModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<MerchantInsertTerminalDetailsModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_mobiledispencer_fuel_purchase")]
        public async Task<IActionResult> GetMobileDispencerFuelPurchase([FromBody] GetMobileDispencerFuelPurchaseModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetMobileDispencerFuelPurchase(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    // List<GetMobileDispencerFuelPurchaseModelOutPut> item = result.Cast<GetMobileDispencerFuelPurchaseModelOutPut>().ToList();
                    if (result.tblMobileDispencerFuelPurchaseModelMID.Count > 0 && result.tblMobileDispencerFuelPurchaseModelMID.Count > 0)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }


        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_mobile_dispencer_fuel_purchase")]
        public async Task<IActionResult> InsertMobileDispencerFuelPurchase([FromBody] InsertMobileDispencerFuelPurchaseModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.InsertMobileDispencerFuelPurchase(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    List<InsertMobileDispencerFuelPurchaseModelOutPut> item = result.Cast<InsertMobileDispencerFuelPurchaseModelOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);


                    //if (result.Cast<InsertMobileDispencerFuelPurchaseModelOutPut>().ToList()[0].Status == 1)
                    //{
                    //    return this.OkCustom(ObjClass, result, _logger);
                    //}
                    //else
                    //{
                    //    return this.FailCustom(ObjClass, result, _logger,
                    //        result.Cast<InsertMobileDispencerFuelPurchaseModelOutPut>().ToList()[0].Reason);
                    //}
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_terminal_merchant_mapping_status")]
        public async Task<IActionResult> GetTerminalMerchantMappingStatus([FromBody] GetTerminalMerchantMappingStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetTerminalMerchantMappingStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetTerminalMerchantMappingStatusModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<GetTerminalMerchantMappingStatusModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }




        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_status_mobiledispenser_retailoutletmapping")]
        public async Task<IActionResult> GetStatusMobileDispenserRetailOutletMapping([FromBody] GetStatusMobileDispenserRetailOutletMappingModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetStatusMobileDispenserRetailOutletMapping(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetStatusMobileDispenserRetailOutletMappingModelOutPut> item = result.Cast<GetStatusMobileDispenserRetailOutletMappingModelOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_status_mobile_dispenser")]
        public async Task<IActionResult> GetStatusMobileDispenser([FromBody] GetStatusMobileDispenserModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetStatusMobileDispenser();
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetStatusMobileDispenserModelOutPut> item = result.Cast<GetStatusMobileDispenserModelOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_merchant_id_status")]
        public async Task<IActionResult> CheckMerchantIdStatus([FromBody] CheckMerchantIdStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.CheckMerchantIdStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CheckMerchantIdStatusModelOutput> item = result.Cast<CheckMerchantIdStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }


        [HttpPost]
        //   [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_view_merchant_earning_breakup")]
        public async Task<IActionResult> GetViewMerchantEarningbreakup([FromBody] MerchantGetViewMerchantEarningbreakupModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetViewMerchantEarningbreakup(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantGetViewMerchantEarningbreakupModelOutput> item = result.Cast<MerchantGetViewMerchantEarningbreakupModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_earning_txn_type")]
        public async Task<IActionResult> GetMstEarningTxnType([FromBody] MerchantGetMstEarningTxnTypeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetMstEarningTxnType(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantGetMstEarningTxnTypeModelOutput> item = result.Cast<MerchantGetMstEarningTxnTypeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("mobile_dispenser_generate_ccms_otp")]
        public async Task<IActionResult> MobileDispenserGenerateOTP([FromBody] WebGenerateOTPModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.MobileDispenserGenerateOTP(ObjClass);
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
                                                .Replace("[OutletName]", ObjClass.CCN)
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

                                          

                                            EmailTemplateMessage = EmailTemplateMessage
                                                .Replace("@OTP", result.Cast<WebGenerateOTPModelOutput>().ToList()[0].OTP)
                                                .Replace("@OutletName", ObjClass.CCN)
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
        [Route("mobile_dispenser_confirm_otp")]
        public async Task<IActionResult> MobileDispenserConfirmOTP([FromBody] MobileDispenserConfirmOTPModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.MobileDispenserConfirmOTP(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MobileDispenserConfirmOTPModelOutPut> item = result.Cast<MobileDispenserConfirmOTPModelOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_merchant_txns_type")]
        public async Task<IActionResult> GetTransactionsType([FromBody] GetTransactionsTypeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetTransactionsType(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetTransactionsTypeModelOutput> item = result.Cast<GetTransactionsTypeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_merchant_bank_name")]
        public async Task<IActionResult> GetMerchantBankName([FromBody] GetMerchantBankNameModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetMerchantBankName(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetMerchantBankNameModelOutput> item = result.Cast<GetMerchantBankNameModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }


        [HttpPost]
        //not required in Android while using API key
        ////[ServiceFilter(typeof(CustomAuthenticationFilter))] 
        [Route("get_merchant_registration_parameters")]
        public async Task<IActionResult> GetMerchantRegistrationParameters([FromBody] MerchantTransactionGetRegistrationProcessModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetMerchantRegistrationParameters(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.ObjGetMerchantDetail.Count > 0)
                    {
                        if (result.ObjGetMerchantDetail[0].Status == 1)
                        {
                            return this.OkCustom(ObjClass, result, _logger);
                        }
                        else
                        {
                            return this.Fail(ObjClass, result, _logger);
                        }


                    }

                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("merchant_request_year")]
        public async Task<IActionResult> MerchantRequestYear([FromBody] MerchantRequestYearModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.MerchantRequestYear(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantRequestYearModeOutput> item = result.Cast<MerchantRequestYearModeOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_merchant_request_month")]
        public async Task<IActionResult> GetMerchantRequestMonth([FromBody] GetMerchantRequestMonthModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetMerchantRequestMonth(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetMerchantRequestMonthModelOutput> item = result.Cast<GetMerchantRequestMonthModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
       [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_month")]
        public async Task<IActionResult> getmonth([FromBody] MerchantgetmonthModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.getmonth(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantgetmonthModelOutput> item = result.Cast<MerchantgetmonthModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("merchant_account_statement_request")]
        public async Task<IActionResult> MerchantAccountStatementRequest([FromBody] MerchantAccountStatementRequestModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.MerchantAccountStatementRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantAccountStatementRequestModelOutput> item = result.Cast<MerchantAccountStatementRequestModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("merchant_report_type")]
        public async Task<IActionResult> MerchantReportType([FromBody] MerchantReportTypeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.MerchantReportType(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantReportTypeModelOutput> item = result.Cast<MerchantReportTypeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_merchant_month_year")]
        public async Task<IActionResult> GetMerchantMonthYear([FromBody] MerchantGetMerchantMonthYearModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetMerchantMonthYear(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantGetMerchantMonthYearModelOutput> item = result.Cast<MerchantGetMerchantMonthYearModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("merchant_account_statement_details")]
        public async Task<IActionResult> MerchantAccountStatementDetails([FromBody] MerchantAccountStatementDetailsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.MerchantAccountStatementDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantAccountStatementDetailsModelOutput> item = result.Cast<MerchantAccountStatementDetailsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_mobile_dispenser_customerid_from_merchant_id")]
        public async Task<IActionResult> GetMobileDispenserCustomerIDFromMerchantID([FromBody] GetMobileDispenserCustomerIDFromMerchantIDModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetMobileDispenserCustomerIDFromMerchantID(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetMobileDispenserCustomerIDFromMerchantIDModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<GetMobileDispenserCustomerIDFromMerchantIDModelOutput>().ToList()[0].Reason);
                    }

                }
            }

        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_terminal_status")]
        public async Task<IActionResult> GetTerminalStatus([FromBody] MerchantGetTerminalStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetTerminalStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantGetTerminalStatusModelOutput> item = result.Cast<MerchantGetTerminalStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_terminal_merchant_mapping_status")]
        public async Task<IActionResult> ViewTerminalMerchantMappingStatus([FromBody] MerchantViewTerminalMerchantMappingStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.ViewTerminalMerchantMappingStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantViewTerminalMerchantMappingStatusModelOutput> item = result.Cast<MerchantViewTerminalMerchantMappingStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("clone_insert_merchant")]
        public async Task<IActionResult> CloneInsertMerchant([FromBody] MerchantCloneInsertMerchantModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.CloneInsertMerchant(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<MerchantCloneInsertMerchantModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<MerchantCloneInsertMerchantModelOutput>().ToList()[0].Reason);
                    }

                }
            }
        }


            [HttpPost]
            [ServiceFilter(typeof(CustomAuthenticationFilter))]
            [Route("get_clone_merchant_approval")]
            public async Task<IActionResult> GeClonetMerchantApproval([FromBody] MerchantGeClonetMerchantApprovalModelInput ObjClass)
            {

                if (ObjClass == null)
                {
                    return this.BadRequestCustom(ObjClass, null, _logger);
                }
                else
                {
                    var result = await _merchant.GeClonetMerchantApproval(ObjClass);
                    if (result == null)
                    {
                        return this.NotFoundCustom(ObjClass, null, _logger);
                    }
                    else
                    {
                        List<MerchantGeClonetMerchantApprovalModelOutput> item = result.Cast<MerchantGeClonetMerchantApprovalModelOutput>().ToList();
                        if (item.Count > 0)
                            return this.OkCustom(ObjClass, result, _logger);
                        else
                            return this.Fail(ObjClass, result, _logger);
                    }
                }

            }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("clone_approve_reject_merchant")]
        public async Task<IActionResult> CloneApproveRejectMerchant([FromBody] MerchantCloneApproveRejectMerchantModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.CloneApproveRejectMerchant(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<MerchantCloneApproveRejectMerchantModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<MerchantCloneApproveRejectMerchantModelOutput>().ToList()[0].Reason);
                    }

                }
            }
        }
            [HttpPost]
            [ServiceFilter(typeof(CustomAuthenticationFilter))]
            [Route("get_merchnat_register_email")]
            public async Task<IActionResult> GetMerchnatRegisterEmail([FromBody] MerchantGetMerchnatRegisterEmailModelInput ObjClass)
            {

                if (ObjClass == null)
                {
                    return this.BadRequestCustom(ObjClass, null, _logger);
                }
                else
                {
                    var result = await _merchant.GetMerchnatRegisterEmail(ObjClass);
                    if (result == null)
                    {
                        return this.NotFoundCustom(ObjClass, null, _logger);
                    }
                    else
                    {
                        List<MerchantGetMerchnatRegisterEmailModelOutput> item = result.Cast<MerchantGetMerchnatRegisterEmailModelOutput>().ToList();
                        if (item.Count > 0)
                            return this.OkCustom(ObjClass, result, _logger);
                        else
                            return this.Fail(ObjClass, result, _logger);
                    }
                }

            }

          [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_update_request_value_for_clone_merchant")]
        public async Task<IActionResult> GetUpdateRequestValueForCloneMerchant([FromBody] MerchantGetUpdateRequestValueForCloneMerchantModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _merchant.GetUpdateRequestValueForCloneMerchant(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantGetUpdateRequestValueForCloneMerchantModelOutput> item = result.Cast<MerchantGetUpdateRequestValueForCloneMerchantModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }

        }
        }
    }

        

        

    

    
    



