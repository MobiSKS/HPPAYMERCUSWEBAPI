using HPPay.DataModel.Merchant;
using HPPay.DataRepository.Driver;
using HPPay.Infrastructure.CommonClass;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HPPay.DataRepository.SMSGetSend;
using HPPay.DataModel.SMSGetSend;
using System;

namespace HPPay_WebApi.Controllers
{
    [Route("api/dtplus/driver")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly ILogger<DriverController> _logger;

        private readonly IDriverRepository _DriverRepo;
        private readonly ISMSGetSendRepository _GetSendRepo;
        public DriverController(ILogger<DriverController> logger, IDriverRepository DriverRepo, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _DriverRepo = DriverRepo;
            _GetSendRepo = GetSendRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_availity_driver_card")]
        public async Task<IActionResult> GetAvailityDriverCard([FromBody] MerchantGetAvailityCardInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DriverRepo.GetAvailityDriverCard(ObjClass);
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
        [Route("check_availity_driver_card")]
        public async Task<IActionResult> CheckAvailityDriverCard([FromBody] MerchantCheckAvailityCardInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DriverRepo.CheckAvailityDriverCard(ObjClass);
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
        [Route("get_all_un_allocated_cards_for_driver_card")]
        public async Task<IActionResult> GetAllUnAllocatedCardsForDriverCard([FromBody] MerchantGetAllUnAllocatedCardsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DriverRepo.GetAllUnAllocatedCardsForDriverCard(ObjClass);
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
        [Route("allocated_driver_card_to_merchant")]
        public async Task<IActionResult> AllocatedDriverCardToMerchant([FromBody] MerchantAllocatedCardsToMerchantModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DriverRepo.AllocatedDriverCardToMerchant(ObjClass);
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
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_driver_card_customer")]
        public async Task<IActionResult> InsertDriverCardCustomer([FromForm] MerchantInsertDriverCardCustomerModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DriverRepo.InsertDriverCardCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                   
                    if (result.Cast<MerchantInsertDriverCardCustomerModelOutput>().ToList()[0].Status == 1)
                    {
                        if (result.Cast<MerchantInsertDriverCardCustomerModelOutput>().ToList()[0].CustomerStatus == 4)
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
                                               .Replace("@CustomerID", result.Cast<MerchantInsertDriverCardCustomerModelOutput>().ToList()[0].CustomerID.ToString())
                                               .Replace("@Password", result.Cast<MerchantInsertDriverCardCustomerModelOutput>().ToList()[0].Password);

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
                                            string ZOROEmaild = string.Empty; 

                                            InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                            insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                                            insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                                            insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                                            insertEmailTextEntryInputModel.EmailIdTo = ObjClass.CommunicationEmailid;
                                            insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                            insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                            insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                            string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                           
                                            if (result.Cast<MerchantInsertDriverCardCustomerModelOutput>().ToList()[0].EmailId == "")
                                            {
                                                result.Cast<MerchantInsertDriverCardCustomerModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage
                                                 .Replace("@customerusername", result.Cast<MerchantInsertDriverCardCustomerModelOutput>().ToList()[0].CustomerID.ToString())
                                               .Replace("@customerpassword", result.Cast<MerchantInsertDriverCardCustomerModelOutput>().ToList()[0].Password);

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
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<MerchantInsertDriverCardCustomerModelOutput>().ToList()[0].Reason);
                    }
                  
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_requested_driver_card")]
        public async Task<IActionResult> ViewRequestedDriverCard([FromBody] MerchantViewRequestedCardModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DriverRepo.ViewRequestedDriverCard(ObjClass);
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
        [Route("insert_dealer_wise_driver_card_request")]
        public async Task<IActionResult> InsertDealerWiseDriverCardRequest([FromBody] MerchantInsertDealerWiseCardRequestModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DriverRepo.InsertDealerWiseDriverCardRequest(ObjClass);
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
        [Route("view_driver_card_merchant_allocation")]
        public async Task<IActionResult> ViewDriverCardMerchantAllocation([FromBody] MerchantViewCardMerchantAllocationModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DriverRepo.ViewDriverCardMerchantAllocation(ObjClass);
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
                        //if (result.ObjMerchantViewCardDetail.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                    {
                        // return this.Fail(ObjClass, result, _logger);
                        return this.FailCustom(ObjClass, result, _logger,
                            result.ObjMerchantTotalCardDetail.Cast<MerchantTotalCardModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }



        [HttpPost]
       [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_driver_card_allocation_activation")]
        public async Task<IActionResult> GetDriverCardAllocationActivation([FromBody] GetCardAllocationActivationModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DriverRepo.GetDriverCardAllocationActivation(ObjClass);
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
        [Route("insert_driver_card_request")]
        public async Task<IActionResult> InsertDriverCardRequest([FromBody] CardRequestEntryModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DriverRepo.InsertDriverCardRequest(ObjClass);
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

    }

}
