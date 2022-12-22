using HPPay.DataModel.AshokLeyland;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataRepository.AshokLeyland;
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
    [Route("api/hppay/ashokleyland")]
    [ApiController]
    public class AshokLeylandController : ControllerBase
    {
        private readonly ILogger<AshokLeylandController> _logger;

        private readonly IAshokLeylandRepository _ALRepo;
        private readonly ISMSGetSendRepository _GetSendRepo;
        public AshokLeylandController(ILogger<AshokLeylandController> logger, IAshokLeylandRepository ALRepo, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _ALRepo = ALRepo;
            _GetSendRepo = GetSendRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_al_dealer_enrollment")]
        public async Task<IActionResult> InsertALDealerEnrollment([FromBody] ALDealerEnrollmentModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.InsertALDealerEnrollment(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ALDealerEnrollmentModelOutput>().ToList()[0].Status == 1)
                    {
                        if (result.Cast<ALDealerEnrollmentModelOutput>().ToList()[0].DealerStatus == 4)
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

                                            getandInsertSendInputModel.SMSText = TemplateMessage.Replace("@DealerID", result.Cast<ALDealerEnrollmentModelOutput>().ToList()[0].DealerId.ToString()).Replace("@password", result.Cast<ALDealerEnrollmentModelOutput>().ToList()[0].Password.ToString());//database
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
                                            if (result.Cast<ALDealerEnrollmentModelOutput>().ToList()[0].EmailId == "")
                                            {
                                                result.Cast<ALDealerEnrollmentModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage.Replace("@DealerID", result.Cast<ALDealerEnrollmentModelOutput>().ToList()[0].DealerId.ToString()).Replace("@password", result.Cast<ALDealerEnrollmentModelOutput>().ToList()[0].Password.ToString()); // database

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
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<ALDealerEnrollmentModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_al_dealer_enrollment")]
        public async Task<IActionResult> UpdateALDealerEnrollment([FromBody] UpdateALDealerEnrollmentModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.UpdateALDealerEnrollment(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateALDealerEnrollmentModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<UpdateALDealerEnrollmentModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_al_dealer_detail")]
        public async Task<IActionResult> GetALDealerDetail([FromBody] GetDealerNameModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.GetALDealerDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDealerNameModelOutput> item = result.Cast<GetDealerNameModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_dealer_code")]
        public async Task<IActionResult> CheckDealerCode([FromBody] CheckDealerCodeModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.CheckDealerCode(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CheckDealerCodeModelOutput> item = result.Cast<CheckDealerCodeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_al_customer")]
        public async Task<IActionResult> InsertALCustomer([FromBody] InsertALCustomerModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.InsertALCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertALCustomerModelOutput>().ToList()[0].Status == 1)
                    {
                        if (result.Cast<InsertALCustomerModelOutput>().ToList()[0].CustomerStatus == 4)
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
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].CustomerID.ToString()).Replace("@Email",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].EmailId).Replace("@CustomerID",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].CustomerID).Replace("@controlcardnumber",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].ControlCardNo).Replace("@customeruserpin",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].ControlPassword).Replace("@customerusername",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].CustomerID).Replace("@customerpassword",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].Password).Replace("@Password",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].Password).Replace("@ControlCardNo",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].ControlCardNo).Replace("@ControlPin",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].ControlPassword).Replace("[@CustomerCode]",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].CustomerID).Replace("[@ControlCardNumber]",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].ControlCardNo);

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
                                            if (result.Cast<InsertALCustomerModelOutput>().ToList()[0].EmailId == "")
                                            {
                                                result.Cast<InsertALCustomerModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage.Replace("@UserName",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].CustomerID.ToString()).Replace("@Email",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].EmailId).Replace("@CustomerID",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].CustomerID).Replace("@controlcardnumber",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].ControlCardNo).Replace("@customeruserpin",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].ControlPassword).Replace("@customerusername",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].CustomerID).Replace("@customerpassword",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].Password).Replace("@Password",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].Password).Replace("@ControlCardNo",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].ControlCardNo).Replace("@ControlPin",
                                                 result.Cast<InsertALCustomerModelOutput>().ToList()[0].ControlPassword);

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
                            result.Cast<InsertALCustomerModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_dealer_wise_al_otc_card_request")]
        public async Task<IActionResult> InsertDealerWiseALOTCCardRequest([FromBody] InsertDealerWiseALOTCCardRequestModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.InsertDealerWiseALOTCCardRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertDealerWiseALOTCCardRequestModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<InsertDealerWiseALOTCCardRequestModelOutput>().ToList()[0].Reason);
                    }


                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_availity_al_otc_card")]
        public async Task<IActionResult> GetAvailityALOTCCard([FromBody] GetAvailityALOTCCardCardInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.GetAvailityALOTCCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAvailityALOTCCardCardOutput> item = result.Cast<GetAvailityALOTCCardCardOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_al_otc_card_dealer_allocation")]
        public async Task<IActionResult> ViewALOTCCardDealerAllocation([FromBody] ALViewCardDealerAllocationModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.ViewALOTCCardDealerAllocation(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.ObjALViewCardDetail.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_al_addon_otc_card_mapping_customer_details")]
        public async Task<IActionResult> GetAlAddonOTCCardMappingCustomerDetails([FromBody] GetAlAddonOTCCardMappingCustomerDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.GetAlAddonOTCCardMappingCustomerDetails(ObjClass);
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
        [Route("get_al_sales_exe_empid_addon_otc_card_mapping")]
        public async Task<IActionResult> GetAlSalesExeEmpIdAddOnOTCCardMapping([FromBody] GetAlSalesExeEmpIdAddOnOTCCardMappingModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.GetAlSalesExeEmpIdAddOnOTCCardMapping(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAlSalesExeEmpIdAddOnOTCCardMappingModelOutput> item = result.Cast<GetAlSalesExeEmpIdAddOnOTCCardMappingModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("al_addon_otc_card")]
        public async Task<IActionResult> AlAddOnOTCCard([FromBody] AlAddOnOTCCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.AlAddOnOTCCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<AlAddOnOTCCardModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<AlAddOnOTCCardModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_al_verify_customer_document")]
        public async Task<IActionResult> GetALVerifyCustomerDocument([FromBody] ALVerifyCustomerDocumentModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.GetALVerifyCustomerDocument(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetALVerifyCustomerDocumentModelOutput> item = result.Cast<GetALVerifyCustomerDocumentModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_al_upload_kyc_document")]
        public async Task<IActionResult> GetALUploadKycDocument([FromBody] GetALUploadKycDocumentsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.GetALUploadKycDocument(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetALUploadKycDocumentsModelOutput> item = result.Cast<GetALUploadKycDocumentsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_al_customer_kyc")]
        public async Task<IActionResult> InsertALCustomerKYC([FromForm] InsertALCustomerKYCModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.InsertALCustomerKYC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertALCustomerKYCModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<InsertALCustomerKYCModelOutput>().ToList()[0].Reason);
                    }


                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_al_customer_detail_for_verification")]
        public async Task<IActionResult> GetAlCustomerDetailForVerification([FromBody] GetAlCustomerDetailForVerificationModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.GetAlCustomerDetailForVerification(ObjClass);
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

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_al_customer_status")]
        public async Task<IActionResult> GetALCustomerStatusDetail([FromBody] GetALCustomerStatusDetailInput ObjClass)
        {
            var result = await _ALRepo.GetALCustomerStatusDetail(ObjClass);
            if (result == null || result.Count() == 0)
            {
                return this.FailCustom(null, result, _logger, "");
            }
            else
            {
                return this.OkCustom(null, result, _logger);

            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_al_customer_status")]
        public async Task<IActionResult> UpdateALCustomerStatus([FromBody] UpdateALCustomerStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.UpdateALCustomerStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateALCustomerStatusModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateALCustomerStatusModelOutput>().ToList()[0].Reason);
                    }


                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_al_customer_detail")]
        public async Task<IActionResult> GetALCustomerDetail([FromBody] GetALCustomerDetailModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.GetALCustomerDetail(ObjClass);
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

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_al_customer_detail")]
        public async Task<IActionResult> RequestUpdateALCustomerDetail([FromBody] ALCustomerDetailUpdateModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.RequestUpdateALCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ALCustomerDetailUpdateModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<ALCustomerDetailUpdateModelOutput>().ToList()[0].Reason);
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
        [Route("get_al_customer_details")]
        public async Task<IActionResult> GetALCustomerDetails([FromBody] ALCustomerDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.GetALCustomerDetails(ObjClass);
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
        ///  <CreatedBy>Manmohan 13-06-2022</CreatedBy> 
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("search_al_manage_card")]
        public async Task<IActionResult> SearchALManageCard([FromBody] ManageALSearchCardsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.SearchALManageCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ManageALSearchCardsModelOutput> item = result.Cast<ManageALSearchCardsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("approval_al_customer_update_request")]
        public async Task<IActionResult> ApprovalALCustomerUpdateRequest([FromBody] ApprovalALCustomerUpdateRequestModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.ApprovalALCustomerUpdateRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ApprovalALCustomerUpdateRequestModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<ApprovalALCustomerUpdateRequestModelOutput>().ToList()[0].Reason);
                    }


                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        ///  <CreatedBy>Manmohan 23-06-2022</CreatedBy> 
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("al_get_generic_attached_vehicle")]
        public async Task<IActionResult> GetGenericAttachedVehicle([FromBody] ALGetGenericAttachedVehicleModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.ALGetGenericAttachedVehicle(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ALGetGenericAttachedVehicleModelOutput> item = result.Cast<ALGetGenericAttachedVehicleModelOutput>().ToList();
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
        /// <CreatedBy>Manmohan 28-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("al_update_customer")]
        public async Task<IActionResult> ALUpdateCustomer([FromBody] UpdateALCustomerDetailModelinput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.UpdateALCustomerDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateALCustomerDetailModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateALCustomerDetailModelOutput>().ToList()[0].Reason);
                    }


                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_vin_no")]
        public async Task<IActionResult> GetALCheckVinNumber([FromBody] GetALCheckVinNumberModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.GetALCheckVinNumber(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetALCheckVinNumberModelOutput> item = result.Cast<GetALCheckVinNumberModelOutput>().ToList();
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
        /// <CreatedBy>Manmohan 04-07-2022</CreatedBy> 
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_al_pending_kyc_customer")]
        public async Task<IActionResult> GetALPendingKycCustomer([FromBody] GetALPendingKycCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.GetALPendingKycCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetALPendingKycCustomerModelOutput> item = result.Cast<GetALPendingKycCustomerModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_al_communication_email_reset_password")]
        public async Task<IActionResult> UpdateALCommunicationEmailResetPassword([FromBody] UpdateALCommunicationEmailResetPasswordModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.UpdateALCommunicationEmailResetPassword(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateALCommunicationEmailResetPasswordModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 07-07-2022</CreatedBy> 
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_al_vehicle_specific_card_request")]
        public async Task<IActionResult> GetALVehicleSpecificCardRequest([FromBody] GetALVehicleSpecificCardRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.GetALVehicleSpecificCardRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetALVehicleSpecificCardRequestModelOutput> item = result.Cast<GetALVehicleSpecificCardRequestModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_al_vehicle_specific_card_request")]
        public async Task<IActionResult> InsertALVehicleSpecificCardRequest([FromBody] InsertALVehicleSpecificCardRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.InsertALVehicleSpecificCardRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertALVehicleSpecificCardRequestModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_al_dispatch_detail")]
        public async Task<IActionResult> GetALDispatchDetail([FromBody] GetALDispatchDetailModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.GetALDispatchDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetALDispatchDetailModelOutput> item = result.Cast<GetALDispatchDetailModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_al_vehicle_specific_card_request_approve")]
        public async Task<IActionResult> GetALVehicleSpecificCardRequest([FromBody] GetALVehicleSpecificCardApproveModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.GetALVehicleSpecificCardApprove(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetALVehicleSpecificCardApproveModelOutput> item = result.Cast<GetALVehicleSpecificCardApproveModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_al_vehicle_specific_card_request_approve")]
        public async Task<IActionResult> InsertALVehicleSpecificCardRequestApprove([FromBody] ApproveALVehicleSpecificCardApproveModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.InsertALVehicleSpecificCardRequestApprove(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ApproveALVehicleSpecificCardApproveModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("al_update_hotlist_reactivate")]
        public async Task<IActionResult> UpdateALHotlistReactivate([FromBody] UpdateALHotlistReactivateModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.UpdateALHotlistReactivate(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateALHotlistReactivateModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateALHotlistReactivateModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 29-08-2022</CreatedBy> 
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_al_customer_kyc")]
        public async Task<IActionResult> GetALCustomerKYC([FromBody] GetALCustomerKYCModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.GetALCustomerKYC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetALCustomerKYCModelOutput> item = result.Cast<GetALCustomerKYCModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("al_unmapped_otc_card_detail")]
        public async Task<IActionResult> ALUnMappedOTCCardDetail([FromBody] ALUnMappedOTCCardModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.ALUnMappedOTCCardDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.ObjALViewCardDetail.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_al_customer_application_form_details")]
        public async Task<IActionResult> GetALCustomerApplicationFormNameOnCard([FromBody] GetALCustomerApplicationFormModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _ALRepo.GetALCustomerApplicationFormNameOnCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetALCustomerApplicationFormOutput.Count > 0 && result.GetALCustomerFormNameOnCard.Count > 0 && result.GetALCustomerApplicationFormOutput[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
    }

}
