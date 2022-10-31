using HPPay.DataModel.Merchant;
using HPPay.DataModel.OTC;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataRepository.OTC;
using HPPay.DataRepository.SMSGetSend;
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
    [Route("api/dtplus/otc")]
    [ApiController]
    public class OTCController : ControllerBase
    {
        private readonly ILogger<OTCController> _logger;

        private readonly IOTCRepository _OTCRepo;
        private readonly ISMSGetSendRepository _GetSendRepo;
        public OTCController(ILogger<OTCController> logger, IOTCRepository OTCRepo, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _OTCRepo = OTCRepo;
            _GetSendRepo = GetSendRepo;
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_otc_customer")]
        public async Task<IActionResult> InsertOTCCustomer([FromForm] MerchantInsertOTCCustomerModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _OTCRepo.InsertOTCCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<MerchantInsertOTCCustomerModelOutput>().ToList()[0].Status == 1)
                    {
                        if (result.Cast<MerchantInsertOTCCustomerModelOutput>().ToList()[0].CustomerStatus == 4)
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
                                                .Replace("[@CustomerID]", result.Cast<MerchantInsertOTCCustomerModelOutput>().ToList()[0].CustomerID)
                                                 .Replace("[@controlcardnumber]", result.Cast<MerchantInsertOTCCustomerModelOutput>().ToList()[0].ControlCardNo)
                                                 .Replace("[@customeruserpin]", result.Cast<MerchantInsertOTCCustomerModelOutput>().ToList()[0].ControlPin)
                                                  .Replace("[@customerusername]", result.Cast<MerchantInsertOTCCustomerModelOutput>().ToList()[0].CustomerID)
                                                   .Replace("[@customerpassword]", result.Cast<MerchantInsertOTCCustomerModelOutput>().ToList()[0].Password);

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
                                            string ZOROEmaild = string.Empty; //database

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
                                                .Replace("@CustomerID", result.Cast<MerchantInsertOTCCustomerModelOutput>().ToList()[0].CustomerID.ToString())
                                                .Replace("@controlcardnumber", result.Cast<MerchantInsertOTCCustomerModelOutput>().ToList()[0].ControlCardNo)
                                                .Replace("@customeruserpin", result.Cast<MerchantInsertOTCCustomerModelOutput>().ToList()[0].ControlPin)
                                                .Replace("@customerusername", result.Cast<MerchantInsertOTCCustomerModelOutput>().ToList()[0].CustomerID)
                                                .Replace("@customerpassword", result.Cast<MerchantInsertOTCCustomerModelOutput>().ToList()[0].Password);

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
                            result.Cast<MerchantInsertOTCCustomerModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_availity_otc_card")]
        public async Task<IActionResult> CheckAvailityOTCCard([FromBody] MerchantCheckAvailityCardInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _OTCRepo.CheckAvailityOTCCard(ObjClass);
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
        [Route("get_availity_otc_card")]
        public async Task<IActionResult> GetAvailityOTCCard([FromBody] MerchantGetAvailityCardInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _OTCRepo.GetAvailityOTCCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<MerchantGetAvailityCardOutput> item = result.Cast<MerchantGetAvailityCardOutput>().ToList();
                    //if (item.Count > 0)

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
        [Route("get_all_un_allocated_cards_for_otc_card")]
        public async Task<IActionResult> GetAllUnAllocatedCardsForOTCCard([FromBody] MerchantGetAllUnAllocatedCardsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _OTCRepo.GetAllUnAllocatedCardsForOTCCard(ObjClass);
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
        [Route("allocated_otc_card_to_merchant")]
        public async Task<IActionResult> AllocatedOTCCardToMerchant([FromBody] MerchantAllocatedCardsToMerchantModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _OTCRepo.AllocatedOTCCardToMerchant(ObjClass);
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
        [Route("view_requested_otc_card")]
        public async Task<IActionResult> ViewRequestedOTCCard([FromBody] MerchantViewRequestedCardModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _OTCRepo.ViewRequestedOTCCard(ObjClass);
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
        [Route("insert_dealer_wise_otc_card_request")]
        public async Task<IActionResult> InsertDealerWiseOTCCardRequest([FromBody] MerchantInsertDealerWiseCardRequestModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _OTCRepo.InsertDealerWiseOTCCardRequest(ObjClass);
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
        [Route("view_otc_card_merchant_allocation")]
        public async Task<IActionResult> ViewOTCCardMerchantAllocation([FromBody] MerchantViewCardMerchantAllocationModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _OTCRepo.ViewOTCCardMerchantAllocation(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

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
        [Route("insert_otc_card_request")]
        public async Task<IActionResult> InsertOTCCardRequest([FromBody] CardRequestEntryModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _OTCRepo.InsertOTCCardRequest(ObjClass);
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
        [Route("get_otc_card_allocation_activation")]
        public async Task<IActionResult> GetOTCCardAllocationActivation([FromBody] GetCardAllocationActivationModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _OTCRepo.GetOTCCardAllocationActivation(ObjClass);
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
        [Route("verify_otc_card_customer")]
        public async Task<IActionResult> VerifyOTCCardCustomer([FromBody] VerifyOTCCardCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _OTCRepo.VerifyOTCCardCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<VerifyOTCCardCustomerModelOutput> item = result.Cast<VerifyOTCCardCustomerModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_availity_otc_card_user_wise")]
        public async Task<IActionResult> GetAvailityOTCCardUserWise([FromBody] CustomerGetRegionalOfficerModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _OTCRepo.GetAvailityOTCCardUserWise(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    if (result.Cast<CustomerGetRegionalOfficerModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);

                    else if (result.Cast<CustomerGetRegionalOfficerModelOutput>().ToList()[0].Reason == "")
                        return this.Fail(ObjClass, result, _logger);

                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<CustomerGetRegionalOfficerModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_otc_customer_region_wise")]
        public async Task<IActionResult> InsertOTCCustomerRegionWise([FromForm] OTCInsertOTCCustomerRegionWiseModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _OTCRepo.InsertOTCCustomerRegionWise(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<OTCInsertOTCCustomerRegionWiseModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<OTCInsertOTCCustomerRegionWiseModelOutput>().ToList()[0].Reason);
                    }
                }
            }


        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_otc_vehicle_specific_card_request")]
        public async Task<IActionResult> GetOTCVehicleSpecificCardRequest([FromBody] GetOTCVehicleSpecificCardRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _OTCRepo.GetOTCVehicleSpecificCardRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetOTCVehicleSpecificCardRequestModelOutput> item = result.Cast<GetOTCVehicleSpecificCardRequestModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }

        [HttpPost]
        // [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_otc_vehicle_specific_card_request")]
        public async Task<IActionResult> InsertOTCVehicleSpecificCardRequest([FromBody] InsertOTCVehicleSpecificCardRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _OTCRepo.InsertOTCVehicleSpecificCardRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertOTCVehicleSpecificCardRequestModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_otc_vehicle_specific_card_request_approve")]
        public async Task<IActionResult> GetALVehicleSpecificCardRequest([FromBody] GetOTCVehicleSpecificCardApproveModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _OTCRepo.GetOTCVehicleSpecificCardApprove(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetOTCVehicleSpecificCardRequestModelOutput> item = result.Cast<GetOTCVehicleSpecificCardRequestModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_otc_vehicle_specific_card_request_approve")]
        public async Task<IActionResult> InsertOTCVehicleSpecificCardRequestApprove([FromBody] ApproveOTCVehicleSpecificCardApproveModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _OTCRepo.InsertOTCVehicleSpecificCardRequestApprove(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertOTCVehicleSpecificCardRequestModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

    }

}
