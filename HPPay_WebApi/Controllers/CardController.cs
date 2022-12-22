using HPPay.DataModel.Card;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataRepository.Card;
using HPPay.DataRepository.SMSGetSend;
using HPPay.Infrastructure.CommonClass;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Http;
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
    [Route("/api/hppay/card")]
    public class CardController : ControllerBase
    {
        private readonly ILogger<CardController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ICardRepository _cardRepo;
        private readonly ISMSGetSendRepository _GetSendRepo;

        public CardController(ILogger<CardController> logger, ICardRepository cardRepo, ISMSGetSendRepository GetSendRepo, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
            _cardRepo = cardRepo;
            _GetSendRepo = GetSendRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("search_manage_card")]
        public async Task<IActionResult> SearchManageCard([FromBody] ManageSearchCardsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.SearchManageCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ManageSearchCardsModelOutput> item = result.Cast<ManageSearchCardsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("search_manage_card_with_vahan_info")]
        public async Task<IActionResult> GetCardInfowithVahanInfo([FromBody] CardManageSearchWithVahanInfoModelnput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetCardInfowithVahanInfo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CardManageSearchWithVahanInfoModelOutput> item = result.Cast<CardManageSearchWithVahanInfoModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_card_limit_features")]
        public async Task<IActionResult> GetCardLimitFeatures([FromBody] GetCardLimtModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetCardLimitFeatures(ObjClass);
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
        [Route("update_mobile_in_card")]
        public async Task<IActionResult> UpdateMobileInCard([FromBody] UpdateMobileInCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.UpdateMobileInCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateMobileInCardModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateMobileInCardModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_mobile_and_fastag_no_in_card")]
        public async Task<IActionResult> UpdateMobileandFastagNoInCard([FromBody] UpdateMobileandFastagNoInCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.UpdateMobileandFastagNoInCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateMobileandFastagNoInCardModelOutput>().ToList()[0].Status == 1)
                    {
                        try
                        {
                            GetDetailsSMSValueInputModel ObjSMSValue = new GetDetailsSMSValueInputModel();
                            ObjSMSValue.MethodName = ControllerContext.ActionDescriptor.ActionName;
                            ObjSMSValue.APIRefNo = result.Cast<UpdateMobileandFastagNoInCardModelOutput>().ToList()[0].APIRefNo;
                            var SMSResult = await _GetSendRepo.GetDetailsSMSValue(ObjSMSValue);
                            if (SMSResult != null)
                            {
                                List<GetDetailsSMSValueOutputModel> items = SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList();
                                for (int i = 0; i < items.Count; i++)
                                {
                                    if (SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].SMSEmailStatus == "1")
                                    {

                                        if (SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                                        {
                                            GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                                            getandInsertSendInputModel.CreatedBy = ObjClass.Userid;
                                            getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                            string TemplateMessage = SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                            TemplateMessage = TemplateMessage
                                                .Replace("@CardNumber", SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].CardNo)
                                                .Replace("@Mobile", SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].MobileNo);
                                            getandInsertSendInputModel.SMSText = TemplateMessage;
                                            getandInsertSendInputModel.MobileNo = SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].MobileNo;
                                            getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].OfficerMobileNo;
                                            getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].TemplateName;
                                            getandInsertSendInputModel.Userip = ObjClass.Userip;
                                            getandInsertSendInputModel.Userid = ObjClass.Userid;
                                            getandInsertSendInputModel.Useragent = ObjClass.Useragent;
                                            getandInsertSendInputModel.SenderId = SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].SenderId;
                                            getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].SMSAPIURL;
                                            await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);

                                        }

                                        if (SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].EmailStatus == 1)
                                        {
                                            string ZOROEmaild = string.Empty;
                                            string EmailId = null;
                                            InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                            insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].Host;
                                            insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].HostPWd;
                                            insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].FromEmail;
                                            insertEmailTextEntryInputModel.EmailIdTo = EmailId;
                                            insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                            insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                            insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                            string EmailTemplateMessage = SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                           

                                            EmailTemplateMessage = EmailTemplateMessage
                                               .Replace("@CardNumber", SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].CardNo)
                                                .Replace("@Mobile", SMSResult.Cast<GetDetailsSMSValueOutputModel>().ToList()[i].MobileNo);

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
                            result.Cast<UpdateMobileandFastagNoInCardModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_service_on_card")]
        public async Task<IActionResult> UpdateServiveOnCard([FromBody] UpdateServiveOnCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.UpdateServiveOnCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateServiveOnCardModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateServiveOnCardModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_card_limits")]
        public async Task<IActionResult> UpdateCardLimits([FromBody] UpdateCardLimitsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.UpdateCardLimits(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateCardLimitsModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateCardLimitsModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_ccms_limits")]
        public async Task<IActionResult> UpdateCCMSLimits([FromBody] UpdateCCMSLimitsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.UpdateCCMSLimits(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateCCMSLimitsModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateCCMSLimitsModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_ccms_limit")]
        public async Task<IActionResult> GetCCMSLimits([FromBody] GetCCMSLimitsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetCCMSLimits(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.CCMSBasicDetail.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_card_limit")]
        public async Task<IActionResult> GetCardLimits([FromBody] GetCardLimitsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetCardLimits(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCardLimitsModelOutput> item = result.Cast<GetCardLimitsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_ccms_limit_for_all_cards")]
        public async Task<IActionResult> GetCCMSLimitsForAllCards([FromBody] GetCCMSLimitsForAllCardsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetCCMSLimitsForAllCards(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<GetCCMSLimitsForAllCardsModelOutput> item = result.Cast<GetCCMSLimitsForAllCardsModelOutput>().ToList();
                    //if (item.Count > 0)
                    if (result.Cast<GetCCMSLimitsForAllCardsModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_ccms_limit_for_all_cards")]
        public async Task<IActionResult> UpdateCCMSLimitForAllCards([FromBody] UpdateCCMSLimitForAllCardsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.UpdateCCMSLimitForAllCards(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<UpdateCCMSLimitForAllCardsModelOutput> item = result.Cast<UpdateCCMSLimitForAllCardsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_limit_for_all_cards")]
        public async Task<IActionResult> UpdateCardLimitForAllCards([FromBody] UpdateCardLimitForAllCardsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.UpdateCardLimitForAllCards(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<UpdateCardLimitForAllCardsModelOutput> item = result.Cast<UpdateCardLimitForAllCardsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_ccms_limit_master")]
        public async Task<IActionResult> GetCCMSLimitMaster([FromBody] GetLimitMasterModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetCCMSLimitMaster(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetLimitMasterModelOutput> item = result.Cast<GetLimitMasterModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_all_card_with_status")]
        public async Task<IActionResult> GetAllCardWithStatus([FromBody] GetAllCardWithStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetAllCardWithStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAllCardWithStatusModelOutput> item = result.Cast<GetAllCardWithStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);//, "Customer is Hotlisted");
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_card_status")]
        public async Task<IActionResult> UpdateCardStatus([FromBody] UpdateCardStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.UpdateCardStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<UpdateCardStatusModelOutput> item = result.Cast<UpdateCardStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_card_limits")]
        public async Task<IActionResult> ViewCardLimits([FromBody] ViewCardLimitsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.ViewCardLimits(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ViewCardLimitsModelOutput> item = result.Cast<ViewCardLimitsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("add_card")]
        public async Task<IActionResult> AddCard([FromBody] AddCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.AddCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<AddCardModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<AddCardModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("bind_pending_customer_for_card_approval")]
        public async Task<IActionResult> BindPendingCustomerForCardApproval([FromBody] BindPendingCustomerforCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.BindPendingCustomerForCardApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<BindPendingCustomerforCardModelOutput> item = result.Cast<BindPendingCustomerforCardModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_card_detail_for_card_approval")]
        public async Task<IActionResult> GetCardDetailForCardApproval([FromBody] GetCardDetailForCardApprovalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetCardDetailForCardApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCardDetailForCardApprovalModelOutput> item = result.Cast<GetCardDetailForCardApprovalModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("approve_reject_card")]
        public async Task<IActionResult> ApproveRejectCard([FromBody] ApproveRejectCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.ApproveRejectCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ApproveRejectCardModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<ApproveRejectCardModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("bind_pending_customer_for_add_on_card_approval")]
        public async Task<IActionResult> BindPendingCustomerForAddOnCardApproval([FromBody] BindPendingCustomerforCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.BindPendingCustomerForAddOnCardApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<BindPendingCustomerforCardModelOutput> item = result.Cast<BindPendingCustomerforCardModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("bind_rejected_customer_for_add_on_card_approval")]
        public async Task<IActionResult> BindRejectedCustomerForAddOnCardApproval([FromBody] BindPendingCustomerforCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.BindRejectedCustomerForAddOnCardApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<BindRejectedCustomerforAddOnCardModelOutput> item = result.Cast<BindRejectedCustomerforAddOnCardModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }




        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_card_detail_for_add_on_card_approval")]
        public async Task<IActionResult> GetCardDetailForAddOnCardApproval([FromBody] GetCardDetailForCardApprovalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetCardDetailForAddOnCardApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCardDetailForCardApprovalModelOutput> item = result.Cast<GetCardDetailForCardApprovalModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("approve_reject_add_on_card")]
        public async Task<IActionResult> ApproveRejectAddOnCard([FromBody] ApproveRejectAddOnCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.ApproveRejectAddOnCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ApproveRejectAddOnCardModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<ApproveRejectAddOnCardModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("search_card_mapping_detail")]
        public async Task<IActionResult> SearchCardMappingDetail([FromBody] CardSearchMappingDetailModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.SearchCardMappingDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CardSearchMappingDetailModelOutput> item = result.Cast<CardSearchMappingDetailModelOutput>().ToList();
                    if (item.Count > 0 && item[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                    return this.FailCustom(ObjClass, result, _logger, "");
                        //return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("search_card_mapping_details_with_blank_mobile")]
        public async Task<IActionResult> SearchCardMappingDetailsWithBlankMobile([FromBody] CardSearchMappingDetailsWithBlankMobileModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.SearchCardMappingDetailsWithBlankMobile(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CardSearchMappingDetailsWithBlankMobileModelOutput> item = result.Cast<CardSearchMappingDetailsWithBlankMobileModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_card_to_ccms_balance_transfer")]
        public async Task<IActionResult> GetCardtoCCMSBalanceTransfer([FromBody] GetCardtoCCMSBalanceTransferModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetCardtoCCMSBalanceTransfer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCardtoCCMSBalanceTransferModelOutput> item = result.Cast<GetCardtoCCMSBalanceTransferModelOutput>().ToList();
                    if (item.Count > 0 && item[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_ccms_to_card_balance_transfer")]
        public async Task<IActionResult> GetCCMSToCardBalanceTransfer([FromBody] GetCcmsToCardBalanceTransferModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetCCMSToCardBalanceTransfer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.ObjCcmsToCardBalanceTransferDetail.Count > 0 && result.ObjCcmsToCardBalanceTransferDetail[0].Status==1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_card_to_card_balance_transfer")]
        public async Task<IActionResult> GetCardtoCardBalanceTransfer([FromBody] GetCardtoCardBalanceTransferModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetCardtoCardBalanceTransfer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCardtoCardBalanceTransferModelOutput> item = result.Cast<GetCardtoCardBalanceTransferModelOutput>().ToList();
                    if (item.Count > 0 && item[0].Status==1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_vechile_no")]
        public async Task<IActionResult> CheckVechileNo([FromBody] CardCheckVechileNoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.CheckVechileNo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CardCheckVechileNoModelOutput> item = result.Cast<CardCheckVechileNoModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_fastag_no_duplicacy_in_card")]
        public async Task<IActionResult> CheckFastagNoDuplicacyInCard([FromBody] CheckFastagNoDuplicacyInCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.CheckFastagNoDuplicacyInCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CheckFastagNoDuplicacyInCardModelOutput> item = result.Cast<CheckFastagNoDuplicacyInCardModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("add_addon_card")]
        public async Task<IActionResult> AddOnCard([FromBody] AddOnCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.AddOnCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Count() > 0 && result.Cast<AddOnCardModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<AddOnCardModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_addon_formnumber")]
        public async Task<IActionResult> CheckAddOnFormNumber([FromBody] CheckAddOnFormNumberModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.CheckAddOnFormNumber(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CheckAddOnFormNumberModelOutput> item = result.Cast<CheckAddOnFormNumberModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("bind_pending_customer_for_addon_card_approval")]
        public async Task<IActionResult> BindPendingCustomerForAddOnCardApproval([FromBody] BindPendingCustomerForAddOnCardApprovalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.BindPendingCustomerForAddOnCardApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<BindPendingCustomerForAddOnCardApprovalModelOutput> item = result.Cast<BindPendingCustomerForAddOnCardApprovalModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_mobile_no")]
        public async Task<IActionResult> CheckMobileNo([FromBody] CardCheckMobileNoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.CheckMobileNo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CardCheckMobileNoModelOutput> item = result.Cast<CardCheckMobileNoModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("transfer_amount_ccms_to_card")]
        public async Task<IActionResult> TransferAmountCCMSToCard([FromBody] TransferAmountCCMSToCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.TransferAmountCCMSToCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<TransferAmountCCMSToCardModelOutput> item = result.Cast<TransferAmountCCMSToCardModelOutput>().ToList();
                    if (item.Count > 0 && item[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("transfer_amount_card_to_ccms")]
        public async Task<IActionResult> TransferAmountCardToCCMS([FromBody] TransferAmountCardToCCMSModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.TransferAmountCardToCCMS(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<TransferAmountCardToCCMSModeloutput> item = result.Cast<TransferAmountCardToCCMSModeloutput>().ToList();
                    if (item.Count > 0 && item[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("transfer_amount_card_to_card")]
        public async Task<IActionResult> TransferAmountCardToCard([FromBody] TransferAmountCardToCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.TransferAmountCardToCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<TransferAmountCardToCardModelOutput> item = result.Cast<TransferAmountCardToCardModelOutput>().ToList();
                    if (item.Count > 0 && item[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_card_identifier_no")]
        public async Task<IActionResult> CheckCardIdentifierNo([FromBody] CheckCardIdentifierNoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.CheckCardIdentifierNo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CheckCardIdentifierNoModelOutput> item = result.Cast<CheckCardIdentifierNoModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_cards_for_limit_update_for_single_recharge")]
        public async Task<IActionResult> GetCardsForLimitUpdateForSingleRecharge([FromBody] GetCardsForLimitUpdateForSingleRechargeModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetCardsForLimitUpdateForSingleRecharge(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    
                    if (result.Cast<GetCardsForLimitUpdateForSingleRechargeModelOutput>().ToList()[0].Status == 1)
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
        [Route("limit_update_for_single_recharge")]
        public async Task<IActionResult> LimitUpdateForSingleRecharge([FromBody] LimitUpdateForSingleRechargeCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.LimitUpdateForSingleRecharge(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<LimitUpdateForSingleRechargeCardModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<LimitUpdateForSingleRechargeCardModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_detail_for_corp_multi_recharge_limit_config")]
        public async Task<IActionResult> GetDetailForCorpMultiRechargeLimitConfig([FromBody] GetDetailForCorpMultiRechargeLimitConfigModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetDetailForCorpMultiRechargeLimitConfig(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDetailForCorpMultiRechargeLimitConfigModelOutput> item = result.Cast<GetDetailForCorpMultiRechargeLimitConfigModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("corp_multi_recharge_limit_config")]
        public async Task<IActionResult> CorpMultiRechargeLimitConfig([FromBody] CorpMultiRechargeLimitConfigModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.CorpMultiRechargeLimitConfig(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CorpMultiRechargeLimitConfigModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<CorpMultiRechargeLimitConfigModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_detail_for_emergency_replacement_cards")]
        public async Task<IActionResult> GetDetailForEmergencyReplacementCards([FromBody] EmergencyReplacementCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetDetailForEmergencyReplacementCards(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<EmergencyReplacementCardModelOutput> item = result.Cast<EmergencyReplacementCardModelOutput>().ToList();
                    //if (item.Count > 0)
                    //    return this.OkCustom(ObjClass, result, _logger);
                    //else
                    //    return this.Fail(ObjClass, result, _logger);

                    if (result.Cast<EmergencyReplacementCardModelOutput>().ToList()[0].Status == 1 && result.Count() > 0)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<EmergencyReplacementCardModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("emergency_replacement_cards")]
        public async Task<IActionResult> EmergencyReplacementCards([FromBody] UpdateEmergencyReplacementCardsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.EmergencyReplacementCards(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<EmergencyReplacementCardsModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<EmergencyReplacementCardsModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_card_renewal_request_detail")]

        public async Task<IActionResult> GetCardRenewalRequestDetail([FromBody] CardGetCardRenewalRequestDetailModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetCardRenewalRequestDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CardGetCardRenewalRequestDetailModelOutput> item = result.Cast<CardGetCardRenewalRequestDetailModelOutput>().ToList();
                    if (item.Count > 0 && result.Cast<CardGetCardRenewalRequestDetailModelOutput>().ToList()[0].Status == 1)
                    //if (result.Cast<CardGetCardRenewalRequestDetailModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_card_renewal_request")]
        public async Task<IActionResult> UpdateCardRenewalRequest([FromBody] CardUpdateCardRenewalRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.UpdateCardRenewalRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CardUpdateCardRenewalRequestModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<CardUpdateCardRenewalRequestModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
       [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("approve_card_renewal_requests")]
        public async Task<IActionResult> ApproveCardRenewalRequests([FromBody] CardApproveCardRenewalRequestsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.ApproveCardRenewalRequests(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CardApproveCardRenewalRequestsModelOutput> item = result.Cast<CardApproveCardRenewalRequestsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_detail_for_enable_disable_products_and_transactions")]
        public async Task<IActionResult> GetDetailForEnableDisableProductsAndTransactions([FromBody] GetDetailForEnableDisableProductsAndTransactionsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetDetailForEnableDisableProductsAndTransactions(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetProductsTransactionsStatus.ToList()[0].Status == 1 && result.GetProductsType.Count > 0
                        && result.GetTransactionsType.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("enable_disable_products_and_transactions")]
        public async Task<IActionResult> EnableDisableProductsAndTransactions([FromBody] EnableDisableProductsAndTransactionsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.EnableDisableProductsAndTransactions(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<EnableDisableProductsAndTransactionsModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<EnableDisableProductsAndTransactionsModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_approve_card_renewal_requests")]
        public async Task<IActionResult> UpdateApproveCardRenewalRequests([FromBody] CardUpdateApproveCardRenewalRequestsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.UpdateApproveCardRenewalRequests(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CardUpdateApproveCardRenewalRequestsModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<CardUpdateApproveCardRenewalRequestsModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_hotlist_reissue_card_request")]
        public async Task<IActionResult> UpdateHotlistReissueCardRequest([FromBody] UpdateHotlistReissueCardRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.UpdateHotlistReissueCardRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateHotlistReissueCardRequestModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateHotlistReissueCardRequestModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_generic_attached_vehicle")]
        public async Task<IActionResult> GetGenericAttachedVehicle([FromBody] GetGenericAttachedVehicleModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetGenericAttachedVehicle(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetGenericAttachedVehicleModelOutput> item = result.Cast<GetGenericAttachedVehicleModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_approve_card_reissuance_request")]
        public async Task<IActionResult> GetApproveCardReissuanceRequest([FromBody] GetApproveCardReissuanceRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetApproveCardReissuanceRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetApproveCardReissuanceRequestModelOutput> item = result.Cast<GetApproveCardReissuanceRequestModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_limit_type")]
        public async Task<IActionResult> GetLimitType([FromBody] GetLimitTypeModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetLimitType(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetLimitTypeModelOutput> item = result.Cast<GetLimitTypeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_card_wise_limit_audit_trail")]
        public async Task<IActionResult> CardwiseLimitAuditTrail([FromBody] CardwiseLimitAuditTrailModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.CardwiseLimitAuditTrail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CardwiseLimitAuditTrailModelOutput> item = result.Cast<CardwiseLimitAuditTrailModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_approve_card_reissuance_request")]
        public async Task<IActionResult> UpdateApproveCardReissuanceRequest([FromBody] UpdateApproveCardReissuanceRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.UpdateApproveCardReissuanceRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateApproveCardReissuanceRequestModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateApproveCardReissuanceRequestModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_add_on_card_request_details")]
        public async Task<IActionResult> GetAddOnCardRequestDetails([FromBody] GetAddOnCardRequestDetailsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetAddOnCardRequestDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetAddOnCardRequestDetailsModelOutput>().ToList()[0].Status == 1)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_customer_driverstars_ccms_balance")]
        public async Task<IActionResult> CheckCustomerDriverStarsCCMSBalance([FromBody] CheckCustomerDriverStarsCCMSBalanceModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.CheckCustomerDriverStarsCCMSBalance(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CheckCustomerDriverStarsCCMSBalanceModelOutput>().ToList()[0].Status == 1)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
       [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("add_on_card_request_with_payment")]
        public async Task<IActionResult> AddOnCardRequestWithPayment([FromBody] AddOnCardRequestWithPaymentModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.AddOnCardRequestWithPayment(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Count() > 0 && result.Cast<AddOnCardRequestWithPaymentModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            "");
                    }
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("approve_reject_add_on_card_with_payment")]
        public async Task<IActionResult> ApproveRejectAddOnCardWithPayment([FromBody] ApproveRejectAddOnCardWithPaymentModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.ApproveRejectAddOnCardWithPayment(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Count() > 0 && result.Cast<ApproveRejectAddOnCardWithPaymentModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<ApproveRejectAddOnCardWithPaymentModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("card_pin_unblock_mobile_request")]
        public async Task<IActionResult> CardPinUnblockMobileRequest([FromBody] CardPinUnblockMobileRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.CardPinUnblockMobileRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CardPinUnblockMobileRequestModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_card_limits_by_vehicleno")]
        public async Task<IActionResult> GetCardLimitsByVehicleNo([FromBody] GetCardLimitsByVehicleNoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetCardLimitsByVehicleNo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCardLimitsByVehicleNoModelOutput> item = result.Cast<GetCardLimitsByVehicleNoModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_card_limits_limittype_wise")]
        public async Task<IActionResult> UpdateCardLimitsLimitTypeWise([FromBody] UpdateCardLimitsLimitTypeWiseModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.UpdateCardLimitsLimitTypeWise(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateCardLimitsLimitTypeWiseModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateCardLimitsLimitTypeWiseModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_ccms_limits_by_vehicleno")]
        public async Task<IActionResult> GetCCMSLimitsByVehicleNo([FromBody] GetCCMSLimitsByVehicleNoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetCCMSLimitsByVehicleNo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCCMSLimitsByVehicleNoModelOutput> item = result.Cast<GetCCMSLimitsByVehicleNoModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_ccms_limits_card_wise")]
        public async Task<IActionResult> UpdateCCMSLimitsCardWise([FromBody] UpdateCCMSLimitsCardWiseModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.UpdateCCMSLimitsCardWise(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateCCMSLimitsCardWiseModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateCCMSLimitsCardWiseModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_card_balance")]
        public async Task<IActionResult> GetCardBalance([FromBody] GetCardBalanceModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetCardBalance(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCardBalanceModelOutput> item = result.Cast<GetCardBalanceModelOutput>().ToList();
                    if (item.Count > 0 && result.ToList()[0].Status==1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_card_issue_type")]
        public async Task<IActionResult> GetCardIssueType([FromBody] GetCardIssueTypeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetCardIssueType(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCardIssueTypeModelOutput> item = result.Cast<GetCardIssueTypeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("show_otp")]
        public async Task<IActionResult> ShowOTP([FromBody] ShowOTPModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.ShowOTP(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ShowOTPModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<ShowOTPModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("bind_pending_customer_for_addon_card_with_payment_approval")]
        public async Task<IActionResult> BindPendingCustomerForAddOnCardWithPaymentApproval([FromBody] BindPendingCustomerForAddOnCardWithPaymentApprovalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.BindPendingCustomerForAddOnCardWithPaymentApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<BindPendingCustomerForAddOnCardWithPaymentApprovalModelOutput> item = result.Cast<BindPendingCustomerForAddOnCardWithPaymentApprovalModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
       [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_card_detail_for_addon_card_with_payment_approval")]
        public async Task<IActionResult> GetCardDetailForAddOnCardWithPaymentApproval([FromBody] GetCardDetailForAddOnCardWithPaymentApprovalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetCardDetailForAddOnCardWithPaymentApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCardDetailForAddOnCardWithPaymentApprovalModelOutput> item = result.Cast<GetCardDetailForAddOnCardWithPaymentApprovalModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_vehicle_No")]
        public async Task<IActionResult> GetVehicleNo([FromBody] GetVehicleNoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetVehicleNo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    List<GetVehicleNoModelOutput> item = result.Cast<GetVehicleNoModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_ccmsbalance_driverstars_for_addon_card_request")]
        public async Task<IActionResult> CheckCCMSBalanceDriverstarsforAddOnCardRequest([FromBody] CheckCCMSBalanceDriverstarsforAddOnCardRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.CheckCCMSBalanceDriverstarsforAddOnCardRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CheckCCMSBalanceDriverstarsforAddOnCardRequestModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<CheckCCMSBalanceDriverstarsforAddOnCardRequestModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_vechile_no_through_vahan")]
        public async Task<IActionResult> CheckVechileNoThroughVahan([FromBody] CheckVechileNoThroughVahanModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.CheckVechileNoThroughVahan(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CheckVechileNoThroughVahanModelOutput> item = result.Cast<CheckVechileNoThroughVahanModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_vehicle_details")]
        public async Task<IActionResult> GetVehicleDetails([FromBody] GetVehicleDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.GetVehicleDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else if (result.Cast<GetVehicleDetailsModelOutput>().ToList()[0].Status == 0)
                {
                    Uri u1 = new Uri(_configuration.GetSection("KarjaAPI:ApiUrl").Value);
                    string consent = _configuration.GetSection("KarjaAPI:consent").Value;
                    string version = _configuration.GetSection("KarjaAPI:version").Value;
                    string Karzakey = _configuration.GetSection("KarjaAPI:key").Value;
                    var payload1 = new Dictionary<string, object>
                            {
                                {"consent",  consent},
                                {"version", version},
                                {"registrationNumber", ObjClass.VehicleNo }
                        };
                    HttpContent c1 = new StringContent(JsonConvert.SerializeObject(payload1), Encoding.UTF8, "application/json");
                    var t1 = Task.Run(() => APIHelper.KarzaPostURI(u1, c1, Karzakey));
                    t1.Wait();
                    HttpResponseMessage response1 = t1.Result;
                    string responseString1 = await response1.Content.ReadAsStringAsync();

                    Root root = new Root();
                    root = JsonConvert.DeserializeObject<Root>(responseString1);
                    if (root.result.registrationNumber != null)
                    {
                        InsertVehicleDetailsModelInput ObjInputData = new InsertVehicleDetailsModelInput();
                        ObjInputData.seatingCapacity = root.result.seatingCapacity;
                        ObjInputData.taxPaidUpto = root.result.taxPaidUpto;
                        ObjInputData.vehicleClassDescription = root.result.vehicleClassDescription;
                        ObjInputData.grossVehicleWeight = root.result.grossVehicleWeight;
                        ObjInputData.unladenWeight = root.result.unladenWeight;
                        ObjInputData.permanentAddress = root.result.permanentAddress;
                        ObjInputData.ownerSerialNumber = root.result.ownerSerialNumber;
                        ObjInputData.statusAsOn = root.result.statusAsOn;
                        ObjInputData.wheelbase = root.result.wheelbase;
                        ObjInputData.registrationDate = root.result.registrationDate;
                        ObjInputData.fatherName = root.result.fatherName;
                        ObjInputData.financier = root.result.financier;
                        ObjInputData.registrationNumber = root.result.registrationNumber;
                        ObjInputData.chassisNumber = root.result.chassisNumber;
                        ObjInputData.numberOfCylinders = root.result.numberOfCylinders;
                        ObjInputData.bodyTypeDescription = root.result.bodyTypeDescription;
                        ObjInputData.makerDescription = root.result.makerDescription;
                        ObjInputData.sleeperCapacity = root.result.sleeperCapacity;
                        ObjInputData.fuelDescription = root.result.fuelDescription;
                        ObjInputData.makerModel = root.result.makerModel;
                        ObjInputData.cubicCapacity = root.result.cubicCapacity;
                        ObjInputData.color = root.result.color;
                        ObjInputData.ownerName = root.result.ownerName;
                        ObjInputData.normsDescription =
                        ObjInputData.standingCapacity = root.result.standingCapacity;
                        ObjInputData.insuranceUpto = root.result.insuranceUpto;
                        ObjInputData.engineNumber = root.result.engineNumber;
                        ObjInputData.presentAddress = root.result.presentAddress;
                        ObjInputData.insurancePolicyNumber = root.result.insurancePolicyNumber;
                        ObjInputData.registeredAt = root.result.registeredAt;
                        ObjInputData.fitnessUpto = root.result.fitnessUpto;
                        ObjInputData.manufacturedMonthYear = root.result.manufacturedMonthYear;
                        ObjInputData.insuranceCompany = root.result.insuranceCompany;
                        ObjInputData.pucNumber = root.result.pucNumber;
                        ObjInputData.pucExpiryDate = root.result.pucExpiryDate;
                        ObjInputData.blackListStatus = root.result.blackListStatus;
                        ObjInputData.nationalPermitIssuedBy = root.result.nationalPermitIssuedBy;
                        ObjInputData.nationalPermitNumber = root.result.nationalPermitNumber;
                        ObjInputData.nationalPermitExpiryDate = root.result.nationalPermitExpiryDate;
                        ObjInputData.statePermitNumber = root.result.statePermitNumber;
                        ObjInputData.statePermitType = root.result.statePermitType;
                        ObjInputData.statePermitIssuedDate = root.result.statePermitIssuedDate;
                        ObjInputData.statePermitExpiryDate = root.result.statePermitExpiryDate;
                        ObjInputData.nonUseFrom = root.result.nonUseFrom;
                        ObjInputData.nocDetails = root.result.nocDetails;
                        ObjInputData.nonUseTo = root.result.nonUseTo;
                        ObjInputData.stateCd = root.result.stateCd;
                        ObjInputData.vehicleCatgory = root.result.vehicleCatgory;
                        ObjInputData.rcStatus = root.result.rcStatus;
                        ObjInputData.stautsMessage = root.result.stautsMessage;
                        ObjInputData.rcMobileNo = root.result.rcMobileNo;
                        ObjInputData.rcNonUseStatus = root.result.rcNonUseStatus;
                        result = await _cardRepo.InsertVehicleDetails(ObjInputData);
                    }
                    else
                        return this.OkCustom(ObjClass, result, _logger);
                } 

                    List<GetVehicleDetailsModelOutput> item = result.Cast<GetVehicleDetailsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("customer_tcs_balance_info")]
        public async Task<IActionResult> GetCustomerBalanceInfo([FromBody] GetCustomerTCSBalanceInfoModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.CustomerTCSBalanceInfo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCustomerTCSBalanceInfoModelOutput> item = result.Cast<GetCustomerTCSBalanceInfoModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }




        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("bind_rejected_customer_for_card_approval")]
        public async Task<IActionResult> BindRejectedCustomerForCardApproval([FromBody] BindRejectedCustomerforCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.BindRejectedCustomerForCardApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<BindRejectedCustomerforCardModelOutput> item = result.Cast<BindRejectedCustomerforCardModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_rawcard_sendback")]
        public async Task<IActionResult> UpdateRawCardSendback([FromBody] UpdateRawCardSendbackModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.UpdateRawCardSendback(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateRawCardSendbackModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateRawCardSendbackModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_invalid_customerid_for_login_user")]
        public async Task<IActionResult> CheckInvalidCustomerIDForLoginUser([FromBody] CheckInvalidCustomerIDForLoginUserModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _cardRepo.CheckInvalidCustomerIDForLoginUser(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CheckInvalidCustomerIDForLoginUserModelOutput> item = result.Cast<CheckInvalidCustomerIDForLoginUserModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

    }
}
