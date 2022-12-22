using HPPay.DataModel.Merchant;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataModel.Tatkal;
using HPPay.DataModel.ZonalOffice;
using HPPay.DataRepository.SMSGetSend;
using HPPay.DataRepository.Tatkal;
using HPPay.DataRepository.ZonalOffice;
using HPPay.Infrastructure.CommonClass;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [Route("api/hppay/tatkal")]
    [ApiController]
    public class TatkalController : ControllerBase
    {
        private readonly ILogger<TatkalController> _logger;

        private readonly ITatkalRepository _TatkalRepo;
        private readonly ISMSGetSendRepository _GetSendRepo;
        public TatkalController(ILogger<TatkalController> logger, ITatkalRepository TatkalRepo, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _TatkalRepo = TatkalRepo;
            _GetSendRepo = GetSendRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_availity_tatkal_card")]
        public async Task<IActionResult> CheckAvailityTatkalCard([FromBody] MerchantCheckAvailityCardInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _TatkalRepo.CheckAvailityTatkalCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantCheckAvailityCardOutput> item = result.Cast<MerchantCheckAvailityCardOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_availity_tatkal_card")]
        public async Task<IActionResult> GetAvailityTatkalCard([FromBody] MerchantGetAvailityCardInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _TatkalRepo.GetAvailityTatkalCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<MerchantGetAvailityCardOutput> item = result.Cast<MerchantGetAvailityCardOutput>().ToList();
                    //if (item.Count > 0)
                    //    return this.OkCustom(ObjClass, result, _logger);
                    //else
                    //    return this.Fail(ObjClass, result, _logger);

                    if (result.Cast<MerchantGetAvailityCardOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);

                    else if (result.Cast<MerchantGetAvailityCardOutput>().ToList()[0].Reason == "")
                        return this.Fail(ObjClass, result, _logger);

                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<MerchantGetAvailityCardOutput>().ToList()[0].Reason);
                    }
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_all_un_allocated_cards_for_tatkal_card")]
        public async Task<IActionResult> GetAllUnAllocatedCardsForTatkalCard([FromBody] MerchantGetAllUnAllocatedCardsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _TatkalRepo.GetAllUnAllocatedCardsForTatkalCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.ObjNoOfUnAllocatedCard.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("allocated_tatkal_card_to_merchant")]
        public async Task<IActionResult> AllocatedTatkalCardToMerchant([FromBody] MerchantAllocatedCardsToMerchantModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _TatkalRepo.AllocatedTatkalCardToMerchant(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<MerchantAllocatedCardsToMerchantModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<MerchantAllocatedCardsToMerchantModelOutput>().ToList()[0].Reason);
                    }


                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_requested_tatkal_card")]
        public async Task<IActionResult> ViewRequestedTatkalCard([FromBody] MerchantViewRequestedCardModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _TatkalRepo.ViewRequestedTatkalCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MerchantViewRequestedCardModelOutput> item = result.Cast<MerchantViewRequestedCardModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_dealer_wise_tatkal_card_request")]
        public async Task<IActionResult> InsertDealerWiseTatkalCardRequest([FromBody] MerchantInsertDealerWiseCardRequestModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _TatkalRepo.InsertDealerWiseTatkalCardRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<MerchantInsertDealerWiseCardRequestModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<MerchantInsertDealerWiseCardRequestModelOutput>().ToList()[0].Reason);
                    }


                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_tatkal_card_merchant_allocation")]
        public async Task<IActionResult> ViewTatkalCardMerchantAllocation([FromBody] MerchantViewCardMerchantAllocationModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _TatkalRepo.ViewTatkalCardMerchantAllocation(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //if (result.ObjMerchantViewCardDetail.Count > 0)
                    //    return this.OkCustom(ObjClass, result, _logger);
                    //else
                    //    return this.Fail(ObjClass, result, _logger);

                    if (result.ObjMerchantTotalCardDetail.Cast<MerchantTotalCardModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.ObjMerchantTotalCardDetail.Cast<MerchantTotalCardModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }


        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_tatkal_card_customer")]
        public async Task<IActionResult> InsertTatkalCustomer([FromForm] InsertTatkalCustomerModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _TatkalRepo.InsertTatkalCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].Status == 1)
                    {
                        if (result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].CustomerStatus == 4)
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

                                            TemplateMessage = TemplateMessage
                                                .Replace("@CustomerID", result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].CustomerID)
                                                .Replace("@Password", result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].Password)
                                                .Replace("[@CustomerCode]", result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].CustomerID)
                                                .Replace("@controlcardnumber", result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].ControlCardNo);
                                               
                                                
                                            // .Replace("@customerusername",result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].CustomerID)
                                            // .Replace("@customerpassword",result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].Password)
                                            //.Replace("@ControlCardNo",result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].ControlCardNo)
                                            // .Replace("@ControlPin",result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].ControlPassword)
                                            //.Replace("@customeruserpin", result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].ControlPassword)
                                            // .Replace("[@ControlCardNumber]",result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].ControlCardNo);
                                            // .Replace("@Email",result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].EmailId)

                                            getandInsertSendInputModel.SMSText = TemplateMessage;
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
                                                 .Replace("@customerusername", result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].CustomerID)
                                                 .Replace("@customerpassword", result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].Password)
                                                 .Replace("@controlcardnumber", result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].ControlCardNo)
                                                 .Replace("@customeruserpin", result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].ControlPassword);

                                                 // .Replace("@CustomerID", result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].CustomerID)
                                                 //.Replace("@customeruserpin", result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].ControlPassword)
                                                 //.Replace("@Password", result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].Password)
                                                 //.Replace("@ControlCardNo", result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].ControlCardNo)
                                                 //.Replace("@ControlPin", result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].ControlPassword);


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
                        }
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<InsertTatkalCustomerModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_tatkal_card_allocation_activation")]
        public async Task<IActionResult> GetTatkalCardAllocationActivation([FromBody] GetCardAllocationActivationModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _TatkalRepo.GetTatkalCardAllocationActivation(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCardAllocationActivationModelOutput> item = result.Cast<GetCardAllocationActivationModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_tatkal_card_request")]
        public async Task<IActionResult> InsertTatkalCardRequest([FromBody] CardRequestEntryModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _TatkalRepo.InsertTatkalCardRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CardRequestEntryModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<CardRequestEntryModelOutput>().ToList()[0].Reason);
                    }

                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("map_tatkal_cards_to_tatkal_customer")]
        public async Task<IActionResult> MapTatkalCardsToTatkalCustomer([FromBody] MapTatkalCardsToTatkalCustomerModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _TatkalRepo.MapTatkalCardsToTatkalCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.ObjGetCardDetailsTatkalCardsToTatkalCustomer.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_map_tatkal_cards_to_tatkal_customer")]
        public async Task<IActionResult> UpdateMapTatkalCardsToTatkalCustomer([FromBody] UpdateMapTatkalCardsToTatkalCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _TatkalRepo.UpdateMapTatkalCardsToTatkalCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateMapTatkalCardsToTatkalCustomerModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateMapTatkalCardsToTatkalCustomerModelOutput>().ToList()[0].Reason);
                    }

                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_tatkal_cards")]
        public async Task<IActionResult> ViewTatkalCards([FromBody] ViewTatkalCardsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _TatkalRepo.ViewTatkalCards(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ViewTatkalCardsModelOutput> item = result.Cast<ViewTatkalCardsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("validate_tatkal_customer_with_region")]
        public async Task<IActionResult> ValidateTatkalCustomerWithRegion([FromBody] ValidateTatkalCustomerWithRegionModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _TatkalRepo.ValidateTatkalCustomerWithRegion(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ValidateTatkalCustomerWithRegionModelOutput> item = result.Cast<ValidateTatkalCustomerWithRegionModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

    }

}
