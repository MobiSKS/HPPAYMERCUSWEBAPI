using HPPay.DataModel.SMSGetSend;
using HPPay.DataModel.VolvoEicher;
using HPPay.DataRepository.SMSGetSend;
using HPPay.DataRepository.VolvoEicher;
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
    [Route("/api/hppay/VE")]
    [ApiController]
    public class VolvoEicherController : ControllerBase
    {
        private readonly IVolcoEicherRepository _VERepo;
        private readonly ILogger<VolvoEicherController> _logger;
        private readonly ISMSGetSendRepository _GetSendRepo;
        public VolvoEicherController(ILogger<VolvoEicherController> logger, IVolcoEicherRepository VERepo, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _VERepo = VERepo;
            _GetSendRepo= GetSendRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_volvo_eicher_dealer_enrollment")]
        public async Task<IActionResult> InsertVEDealerEnrollment([FromBody] VEDealerEnrollmentModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.InsertVEDealerEnrollment(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<VEDealerEnrollmentModelOutput>().ToList()[0].Status == 1)
                    {
                        if (result.Cast<VEDealerEnrollmentModelOutput>().ToList()[0].DealerStatus == 4)
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

                                            getandInsertSendInputModel.SMSText = TemplateMessage.Replace("@DealerID", result.Cast<VEDealerEnrollmentModelOutput>().ToList()[0].DealerId.ToString()).Replace("@password", result.Cast<VEDealerEnrollmentModelOutput>().ToList()[0].Password.ToString());//database
                                            getandInsertSendInputModel.MobileNo = ObjClass.MobileNo;//database
                                            getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo;//database
                                            getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;//database
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
                                            insertEmailTextEntryInputModel.EmailIdTo = ObjClass.EmailId; ;//database
                                            insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                            insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                            insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                            string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                            //database
                                            if (result.Cast<VEDealerEnrollmentModelOutput>().ToList()[0].EmailId == "")
                                            {
                                                result.Cast<VEDealerEnrollmentModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage.Replace("@DealerID", result.Cast<VEDealerEnrollmentModelOutput>().ToList()[0].DealerId.ToString()).Replace("@password", result.Cast<VEDealerEnrollmentModelOutput>().ToList()[0].Password.ToString()); // database


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
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<VEDealerEnrollmentModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_volvo_eicher_dealer_detail")]
        public async Task<IActionResult> GetVEDealerDetail([FromBody] GetVEDealerNameModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.GetVEDealerDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetVEDealerNameModelOutput> item = result.Cast<GetVEDealerNameModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_volvo_eicher_dealer_enrollment")]
        public async Task<IActionResult> UpdateALDealerEnrollment([FromBody] UpdateVEDealerEnrollmentModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.UpdateVEDealerEnrollment(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateVEDealerEnrollmentModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<UpdateVEDealerEnrollmentModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }






        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_volvo_eicher_customer")]
        public async Task<IActionResult> insertvecustomer([FromBody] InsertVECustomerModelInput objclass)
        {

            if (objclass == null)
            {
                return this.BadRequestCustom(objclass, null, _logger);
            }
            else
            {
                var result = await _VERepo.InsertVECustomer(objclass);
                if (result == null)
                {
                    return this.NotFoundCustom(objclass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertVECustomerModelOutput>().ToList()[0].Status == 1)
                    {
                        if (result.Cast<InsertVECustomerModelOutput>().ToList()[0].CustomerStatus == 4)
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
                                            getandInsertSendInputModel.CreatedBy = objclass.Userid;
                                            getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                            string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                            TemplateMessage = TemplateMessage.Replace("@UserName",
                                                 result.Cast<InsertVECustomerModelOutput>().ToList()[0].CustomerID.ToString()).Replace("@Email",
                                                 result.Cast<InsertVECustomerModelOutput>().ToList()[0].EmailId).Replace("@CustomerID",
                                                 result.Cast<InsertVECustomerModelOutput>().ToList()[0].CustomerID).Replace("@controlcardnumber",
                                                 result.Cast<InsertVECustomerModelOutput>().ToList()[0].ControlCardNo).Replace("@customeruserpin",
                                                 result.Cast<InsertVECustomerModelOutput>().ToList()[0].ControlPassword).Replace("@customerusername",
                                                 result.Cast<InsertVECustomerModelOutput>().ToList()[0].CustomerID).Replace("@customerpassword",
                                                 result.Cast<InsertVECustomerModelOutput>().ToList()[0].Password).Replace("@Password",
                                                 result.Cast<InsertVECustomerModelOutput>().ToList()[0].Password).Replace("@ControlCardNo",
                                                 result.Cast<InsertVECustomerModelOutput>().ToList()[0].ControlCardNo).Replace("@ControlPin",
                                                 result.Cast<InsertVECustomerModelOutput>().ToList()[0].ControlPassword).Replace("[@CustomerCode]",
                                                 result.Cast<InsertVECustomerModelOutput>().ToList()[0].CustomerID).Replace("[@ControlCardNumber]",
                                                 result.Cast<InsertVECustomerModelOutput>().ToList()[0].ControlCardNo);

                                            getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");//database
                                            getandInsertSendInputModel.MobileNo = "";//database
                                            getandInsertSendInputModel.OfficerMobileNo = "";//database
                                            getandInsertSendInputModel.HeaderTemplate = "";//database
                                            getandInsertSendInputModel.Userip = objclass.Userip;
                                            getandInsertSendInputModel.Userid = objclass.Userid;
                                            getandInsertSendInputModel.Useragent = objclass.Useragent;
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
                                            if (result.Cast<InsertVECustomerModelOutput>().ToList()[0].EmailId == "")
                                            {
                                                result.Cast<InsertVECustomerModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage.Replace("@UserName",
                                                  result.Cast<InsertVECustomerModelOutput>().ToList()[0].CustomerID.ToString()).Replace("@Email",
                                                  result.Cast<InsertVECustomerModelOutput>().ToList()[0].EmailId).Replace("@CustomerID",
                                                  result.Cast<InsertVECustomerModelOutput>().ToList()[0].CustomerID).Replace("@controlcardnumber",
                                                  result.Cast<InsertVECustomerModelOutput>().ToList()[0].ControlCardNo).Replace("@customeruserpin",
                                                  result.Cast<InsertVECustomerModelOutput>().ToList()[0].ControlPassword).Replace("@customerusername",
                                                  result.Cast<InsertVECustomerModelOutput>().ToList()[0].CustomerID).Replace("@customerpassword",
                                                  result.Cast<InsertVECustomerModelOutput>().ToList()[0].Password).Replace("@Password",
                                                  result.Cast<InsertVECustomerModelOutput>().ToList()[0].Password).Replace("@ControlCardNo",
                                                  result.Cast<InsertVECustomerModelOutput>().ToList()[0].ControlCardNo).Replace("@ControlPin",
                                                  result.Cast<InsertVECustomerModelOutput>().ToList()[0].ControlPassword);

                                            insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");
                                            insertEmailTextEntryInputModel.CreatedBy = objclass.Userid;
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
                        return this.OkCustom(objclass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(objclass, result, _logger,
                            result.Cast<InsertVECustomerModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_dealer_code")]
        public async Task<IActionResult> CheckDealerCode([FromBody] CheckVEDealerCodeModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.CheckVEDealerCode(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CheckVEDealerCodeModelOutput> item = result.Cast<CheckVEDealerCodeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_dealer_wise_volvo_eicher_otc_card_request")]
        public async Task<IActionResult> InsertDealerWiseVEOTCCardRequest([FromBody] InsertDealerWiseVEOTCCardRequestModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.InsertDealerWiseVEOTCCardRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertDealerWiseVEOTCCardRequestModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<InsertDealerWiseVEOTCCardRequestModelOutput>().ToList()[0].Reason);
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
        [Route("get_availity_volvo_eicher_otc_card")]
        public async Task<IActionResult> GetAvailityALOTCCard([FromBody] GetAvailityVEOTCCardInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.GetAvailityVEOTCCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAvailityVEOTCCardOutput> item = result.Cast<GetAvailityVEOTCCardOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_volvo_eicher_otc_card_dealer_allocation")]
        public async Task<IActionResult> ViewALOTCCardDealerAllocation([FromBody] VEViewCardDealerAllocationModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.ViewVEOTCCardDealerAllocation(ObjClass);
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
        [Route("view_volvo_eicher_dealer_otc_card_status")]
        public async Task<IActionResult> ViewVEDealerOTCCardStatus([FromBody] ViewVEDealerOTCCardStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.ViewVEDealerOTCCardStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ViewVEDealerOTCCardStatusModelOutput> item = result.Cast<ViewVEDealerOTCCardStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_volvo_eicher_dealer_otc_card_detail")]
        public async Task<IActionResult> ViewVEDealerOTCCardDetail([FromBody] ViewVEDealerOTCCardDetailModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.ViewVEDealerOTCCardDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.ObjVEViewCardDetail.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_volvo_eicher_addon_otc_card_mapping_customer_details")]
        public async Task<IActionResult> GetAlAddonOTCCardMappingCustomerDetails([FromBody] GetVEAddonOTCCardMappingCustomerDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.GetVEAddonOTCCardMappingCustomerDetails(ObjClass);
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
        [Route("get_volvo_eicher_sales_exe_empid_addon_otc_card_mapping")]
        public async Task<IActionResult> GetAlSalesExeEmpIdAddOnOTCCardMapping([FromBody] GetVESalesExeEmpIdAddOnOTCCardMappingModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.GetVESalesExeEmpIdAddOnOTCCardMapping(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetVESalesExeEmpIdAddOnOTCCardMappingModelOutput> item = result.Cast<GetVESalesExeEmpIdAddOnOTCCardMappingModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("volvo_eicher_addon_otc_card")]
        public async Task<IActionResult> AlAddOnOTCCard([FromBody] VEAddOnOTCCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.VEAddOnOTCCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<VEAddOnOTCCardModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<VEAddOnOTCCardModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_volvo_eicher_verify_customer_document")]
        public async Task<IActionResult> GetALVerifyCustomerDocument([FromBody] VEVerifyCustomerDocumentModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.GetVEVerifyCustomerDocument(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetVEVerifyCustomerDocumentModelOutput> item = result.Cast<GetVEVerifyCustomerDocumentModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_volvo_eicher_upload_kyc_document")]
        public async Task<IActionResult> GetALUploadKycDocument([FromBody] GetVEUploadKycDocumentsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.GetVEUploadKycDocument(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetVEUploadKycDocumentsModelOutput> item = result.Cast<GetVEUploadKycDocumentsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [Route("insert_volvo_eicher_customer_kyc")]
        public async Task<IActionResult> InsertVECustomerKYC([FromForm] InsertVECustomerKYCModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.InsertVECustomerKYC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertVECustomerKYCModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<InsertVECustomerKYCModelOutput>().ToList()[0].Reason);
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
        [Route("get_volvo_eicher_customer_detail")]
        public async Task<IActionResult> GetVolvoCustomerDetails([FromBody] VolvoCustomerDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.GetVolvoCustomerDetails(ObjClass);
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
        [Route("search_volvo_eicher_manage_card")]
        public async Task<IActionResult> SearchVolvoManageCard([FromBody] ManageVESearchCardsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.SearchManageCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ManageVESearchCardsModelOutput> item = result.Cast<ManageVESearchCardsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_ve_customer_detail")]
        public async Task<IActionResult> RequestUpdateVECustomer([FromBody] VECustomerDetailUpdateModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.RequestUpdateVECustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<VECustomerDetailUpdateModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<VECustomerDetailUpdateModelOutput>().ToList()[0].Reason);
                    }


                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <createdOn>07-07-2022</createdOn>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("approval_volvo_eicher_customer_update_request")]
        public async Task<IActionResult> ApprovalVECustomerUpdateRequest([FromBody] ApprovalVECustomerUpdateRequestModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.ApprovalVECustomerUpdateRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ApprovalVECustomerUpdateRequestModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<ApprovalVECustomerUpdateRequestModelOutput>().ToList()[0].Reason);
                    }


                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <createdOn>08-07-2022</createdOn>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_ve_communication_email_reset_password")]
        public async Task<IActionResult> UpdateVECommunicationEmailResetPassword([FromBody] UpdateVECommunicationEmailResetPasswordModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.UpdateVECommunicationEmailResetPassword(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateVECommunicationEmailResetPasswordModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_volovo_eicher_dispatch_detail")]
        public async Task<IActionResult> GetVEDispatchDetail([FromBody] GetVEDispatchDetailModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.GetVEDispatchDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetVEDispatchDetailModelOutput> item = result.Cast<GetVEDispatchDetailModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_ve_customer_application_form_details")]
        public async Task<IActionResult> GetVECustomerApplicationFormNameOnCard([FromBody] GetVECustomerApplicationFormModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.GetVECustomerApplicationFormNameOnCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetVECustomerApplicationFormOutput.Count > 0 && result.GetVECustomerFormNameOnCard.Count > 0 && result.GetVECustomerApplicationFormOutput[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_volovo_eicher_customer_detail_for_verification")]
        public async Task<IActionResult> GetAlCustomerDetailForVerification([FromBody] GetVECustomerDetailForVerificationModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.GetVECustomerDetailForVerification(ObjClass);
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
        [Route("get_volovo_eicher_customer_status")]
        public async Task<IActionResult> GetVECustomerStatusDetail([FromBody] GetVECustomerStatusDetailInput ObjClass)
        {
            var result = await _VERepo.GetVECustomerStatusDetail(ObjClass);
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
        [Route("update_volovo_eicher_customer_status")]
        public async Task<IActionResult> UpdateVECustomerStatus([FromBody] UpdateVECustomerStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.UpdateVECustomerStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateVECustomerStatusModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateVECustomerStatusModelOutput>().ToList()[0].Reason);
                    }


                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("volovo_eicher_update_customer")]
        public async Task<IActionResult> VEUpdateCustomer([FromBody] UpdateVECustomerDetailModelinput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.UpdateVECustomerDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateVECustomerDetailModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateVECustomerDetailModelOutput>().ToList()[0].Reason);
                    }


                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_volovo_eicher_customer_kyc")]
        public async Task<IActionResult> GetVECustomerKYC([FromBody] GetVECustomerKYCModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _VERepo.GetVECustomerKYC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetVECustomerKYCModelOutput> item = result.Cast<GetVECustomerKYCModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }
    }
}
