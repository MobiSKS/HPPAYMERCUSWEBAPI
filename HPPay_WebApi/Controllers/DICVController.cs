using HPPay.DataModel.DICV;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataRepository.DICV;
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
    [Route("/api/dtplus/DICV")]
    [ApiController]
    public class DICVController : ControllerBase
    {
        private readonly IDICVRepository _DICVRepo;
        private readonly ILogger<DICVController> _logger;
        private readonly ISMSGetSendRepository _GetSendRepo;
        public DICVController(ILogger<DICVController> logger, IDICVRepository DICVRepo, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _DICVRepo = DICVRepo;
            _GetSendRepo = GetSendRepo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 14-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_dicv_customer")]
        public async Task<IActionResult> InsertDICVCustomer([FromForm] InsertDICVCustomerModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.InsertDICVCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].Status == 1)
                    {
                        if (result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].CustomerStatus == 4)
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
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].CustomerID.ToString()).Replace("@Email",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].EmailId).Replace("@CustomerID",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].CustomerID).Replace("@controlcardnumber",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].ControlCardNo).Replace("@customeruserpin",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].ControlPassword).Replace("@customerusername",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].CustomerID).Replace("@customerpassword",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].Password).Replace("@Password",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].Password).Replace("@ControlCardNo",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].ControlCardNo).Replace("@ControlPin",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].ControlPassword).Replace("[@CustomerCode]",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].CustomerID).Replace("[@ControlCardNumber]",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].ControlCardNo);

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
                                            if (result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].EmailId == "")
                                            {
                                                result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage.Replace("@UserName",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].CustomerID.ToString()).Replace("@Email",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].EmailId).Replace("@CustomerID",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].CustomerID).Replace("@controlcardnumber",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].ControlCardNo).Replace("@customeruserpin",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].ControlPassword).Replace("@customerusername",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].CustomerID).Replace("@customerpassword",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].Password).Replace("@Password",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].Password).Replace("@ControlCardNo",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].ControlCardNo).Replace("@ControlPin",
                                                 result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].ControlPassword);

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
                            result.Cast<InsertDICVCustomerModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 14-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_dealer_code")]
        public async Task<IActionResult> CheckDealerCode([FromBody] CheckDICVDealerCodeModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.CheckDICVDealerCode(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CheckDICVDealerCodeModelOutput> item = result.Cast<CheckDICVDealerCodeModelOutput>().ToList();
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
        /// <CreatedBy>Manmohan 14-06-2022</CreatedBy> 
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_availity_dicv_otc_card")]
        public async Task<IActionResult> GetAvailityALOTCCard([FromBody] GetAvailityDICVOTCCardModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetAvailityDICVOTCCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetAvailityDICVOTCCardModelOutput> item = result.Cast<GetAvailityDICVOTCCardModelOutput>().ToList();
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
        /// <CreatedBy>Manmohan 14-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dicv_upload_kyc_document")]
        public async Task<IActionResult> GetDICVUploadKycDocument([FromBody] GetDICVUploadKycDocumentsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVUploadKycDocument(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDICVUploadKycDocumentsModelOutput> item = result.Cast<GetDICVUploadKycDocumentsModelOutput>().ToList();
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
        /// <CreatedBy>Manmohan 14-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_dicv_customer_kyc")]
        public async Task<IActionResult> InsertDICVCustomerKYC([FromForm] InsertDICVCustomerKYCModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.InsertDICVCustomerKYC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertDICVCustomerKYCModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<InsertDICVCustomerKYCModelOutput>().ToList()[0].Reason);
                    }


                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 15-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dicv_addon_otc_card_mapping_customer_details")]
        public async Task<IActionResult> GetDICVAddonOTCCardMappingCustomerDetails([FromBody] GetDICVAddonOTCCardMappingCustomerDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVAddonOTCCardMappingCustomerDetails(ObjClass);
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
        [Route("get_dicv_customer_application_form_details")]
        public async Task<IActionResult> GetDICVCustomerApplicationFormNameOnCard([FromBody] GetDICVCustomerApplicationFormModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVCustomerApplicationFormNameOnCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetDICVCustomerApplicationFormOutput.Count > 0 && result.GetDICVCustomerFormNameOnCard.Count > 0 && result.GetDICVCustomerApplicationFormOutput[0].Status==1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 15-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dicv_sales_exe_empid_addon_otc_card_mapping")]
        public async Task<IActionResult> GetDICVSalesExeEmpIdAddOnOTCCardMapping([FromBody] GetDICVSalesExeEmpIdAddOnOTCCardMappingModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVSalesExeEmpIdAddOnOTCCardMapping(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDICVSalesExeEmpIdAddOnOTCCardMappingModelOutput> item = result.Cast<GetDICVSalesExeEmpIdAddOnOTCCardMappingModelOutput>().ToList();
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
        /// <CreatedBy>Manmohan 15-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("dicv_addon_otc_card")]
        public async Task<IActionResult> DICVAddOnOTCCard([FromBody] DICVAddOnOTCCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.DICVAddOnOTCCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<DICVAddOnOTCCardModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<DICVAddOnOTCCardModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 15-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dicv_customer_detail_for_verification")]
        public async Task<IActionResult> GetAlCustomerDetailForVerification([FromBody] GetDICVCustomerDetailForVerificationModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVCustomerDetailForVerification(ObjClass);
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
        /// <CreatedBy>Manmohan 15-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dicv_customer_status")]
        public async Task<IActionResult> GetALCustomerStatusDetail([FromBody] GetDICVCustomerStatusDetailInput ObjClass)
        {
            var result = await _DICVRepo.GetDICVCustomerStatusDetail(ObjClass);
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
        /// <CreatedBy>Manmohan 15-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_dicv_customer_status")]
        public async Task<IActionResult> UpdateALCustomerStatus([FromBody] UpdateDICVCustomerStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.UpdateDICVCustomerStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateDICVCustomerStatusModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateDICVCustomerStatusModelOutput>().ToList()[0].Reason);
                    }


                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 15-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dicv_customer_detail")]
        public async Task<IActionResult> GetDICVCustomerDetail([FromBody] GetDICVCustomerDetailModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVCustomerDetail(ObjClass);
                if (result == null || result.Count() == 0)
                {
                    return this.Fail(ObjClass, result, _logger);
                }
                else
                {
                    if (result.Cast<GetDICVCustomerDetailModelOutput>().ToList()[0].Status == 1)
                    return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger,"");


                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 15-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("request_update_dicv_customer")]
        public async Task<IActionResult> RequestUpdateDICVCustomer([FromBody] DICVCustomerDetailUpdateModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.RequestUpdateDICVCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<DICVCustomerDetailUpdateModelOutput>().ToList()[0].Status == 1)
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
        /// <CreatedBy>Manmohan 15-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("view_dicv_dealer_otc_card_status")]
        public async Task<IActionResult> ViewVEDealerOTCCardStatus([FromBody] ViewDICVDealerOTCCardStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.ViewDICVDealerOTCCardStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ViewDICVDealerOTCCardStatusModelOutput> item = result.Cast<ViewDICVDealerOTCCardStatusModelOutput>().ToList();
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
        /// <CreatedBy>Manmohan 15-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dicv_dealer_detail")]
        public async Task<IActionResult> GetDICVDealerDetail([FromBody] GetDealerDetailModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVDealerDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDealerDetailModelOutput> item = result.Cast<GetDealerDetailModelOutput>().ToList();
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
        /// <CreatedBy>Manmohan 16-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_dicv_dealer_enrollment")]
        public async Task<IActionResult> InsertDICVDealerEnrollment([FromBody] DICVDealerEnrollmentModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.InsertDICVDealerEnrollment(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<DICVDealerEnrollmentModelOutput>().ToList()[0].Status == 1)
                    {
                        if (result.Cast<DICVDealerEnrollmentModelOutput>().ToList()[0].DealerStatus == 4)
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

                                            TemplateMessage = TemplateMessage.Replace("@DealerID", result.Cast<DICVDealerEnrollmentModelOutput>().ToList()[0].DealerId.ToString())
                                                                             .Replace("@password", result.Cast<DICVDealerEnrollmentModelOutput>().ToList()[0].Password.ToString())
                                                                             .Replace("@Role", result.Cast<DICVDealerEnrollmentModelOutput>().ToList()[0].UserRole.ToString());  // database


                                            getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");//database
                                            getandInsertSendInputModel.MobileNo = ObjClass.MobileNo;//database
                                            getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo; //database
                                            getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Header; //database
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
                                            if (result.Cast<DICVDealerEnrollmentModelOutput>().ToList()[0].EmailId == "")
                                            {
                                                result.Cast<DICVDealerEnrollmentModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage.Replace("@DealerID", result.Cast<DICVDealerEnrollmentModelOutput>().ToList()[0].DealerId.ToString())
                                                                                       .Replace("@password", result.Cast<DICVDealerEnrollmentModelOutput>().ToList()[0].Password.ToString())
                                                                                       .Replace("@Role", result.Cast<DICVDealerEnrollmentModelOutput>().ToList()[0].UserRole.ToString());  // database


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
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<DICVDealerEnrollmentModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 16-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("enable_disable_dicv_dealer")]
        public async Task<IActionResult> EnableDisableDICVDealer([FromBody] EnableDisableDICVDealerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.EnableDisableDICVDealer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<EnableDisableDICVDealerModelOutput> item = result.Cast<EnableDisableDICVDealerModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_dicv_dealer_enrollment")]
        public async Task<IActionResult> UpdateDICVDealerEnrollment([FromBody] UpdateDICVDealerEnrollmentModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.UpdateDICVDealerEnrollment(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateDICVDealerEnrollmentModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<UpdateDICVDealerEnrollmentModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dicv_officer_type")]
        public async Task<IActionResult> GetDICVOfficerType([FromBody] GetDICVOfficerTypeModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVOfficerType(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDICVOfficerTypeModelOutput> item = result.Cast<GetDICVOfficerTypeModelOutput>().ToList();
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
        /// <CreatedBy>Manmohan 16-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dicv_customer_details")]
        public async Task<IActionResult> GetDICVCustomerDetails([FromBody] DICVCustomerDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVCustomerDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDICVCustomerDetailsModelOutput> item = result.GetCustomerDetails.Cast<GetDICVCustomerDetailsModelOutput>().ToList();
                    if (result.GetCustomerDetails.Count > 0 && item[0].Status == 1)
                    {
                        result.Status = item[0].Status;                        
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                        
                    else
                    {
                        if (item.Count > 0 && !string.IsNullOrEmpty(item[0].Reason))
                        {
                            result.Reason = item[0].Reason;
                        }
                        result.GetCustomerDetails = null;
                        result.CustomerKYCDetails = null;
                        return this.Fail(ObjClass, result, _logger);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 16-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("search_dicv_manage_card")]
        public async Task<IActionResult> SearchDICVManageCard([FromBody] ManageDICVSearchCardsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.SearchManageCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ManageDICVSearchCardsModelOutput> item = result.Cast<ManageDICVSearchCardsModelOutput>().ToList();
                    if (item.Count > 0 && item[0].Status ==1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger,"");
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("approval_dicv_customer_update_request")]
        public async Task<IActionResult> ApprovalDICVCustomerUpdateRequest([FromBody] ApprovalDICVCustomerUpdateRequestModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.ApprovalDICVCustomerUpdateRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ApprovalDICVCustomerUpdateRequestModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<ApprovalDICVCustomerUpdateRequestModelOutput>().ToList()[0].Reason);
                    }


                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("dicv_get_card_limit_features")]
        public async Task<IActionResult> GetCardLimitFeatures([FromBody] GetDICVCardLimtModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVCardLimitFeatures(ObjClass);
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
        [Route("dicv_update_mobile_in_card")]
        public async Task<IActionResult> UpdateMobileInCard([FromBody] DICVUpdateMobileInCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.DICVUpdateMobileInCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<DICVUpdateMobileInCardModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<DICVUpdateMobileInCardModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("dicv_update_hotlist_reactivate")]
        public async Task<IActionResult> UpdateDICVHotlistReactivate([FromBody] UpdateDICVHotlistReactivateModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.UpdateDICVHotlistReactivate(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateDICVHotlistReactivateModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateDICVHotlistReactivateModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("dicv_hotlist_reason")]
        public async Task<IActionResult>GetDICVHotListReason ([FromBody] GetDICVHotlistReactiveModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVHotListReason(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDICVHotlistReactiveModelOutput> item = result.Cast<GetDICVHotlistReactiveModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }







        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dicv_customer_balance_info")]
        public async Task<IActionResult> GetCustomerBalanceInfo([FromBody] GetDICVCustomerBalanceInfoModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetCustomerBalanceInfo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDICVCustomerBalanceInfoModelOutput> item = result.Cast<GetDICVCustomerBalanceInfoModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dicv_transactions_summary")]
        public async Task<IActionResult> GetDICVTransactionsSummary([FromBody] GetDICVTransactionsSummaryModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVTransactionsSummary(ObjClass);
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
        [Route("dicv_update_mobile_and_fastag_no_in_card")]
        public async Task<IActionResult> DICVUpdateMobileandFastagNo([FromBody] DICVUpdateMobileandFastagNoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.DICVUpdateMobileandFastagNo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<DICVUpdateMobileandFastagNoModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<DICVUpdateMobileandFastagNoModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dicv_mobile_and_fastagno")]
        public async Task<IActionResult> GetDICVMobileandFastagNo([FromBody] DICVGetMobileandFastagNoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVMobileandFastagNo(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Count() > 0 && result.Cast<DICVGetMobileandFastagNoModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,"");
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
        [Route("get_dicv_advanced_search")]
        public async Task<IActionResult> GetDICVAdvancedSearch([FromBody] GetDICVAdvancedSearchModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVAdvancedSearch(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDICVAdvancedSearchModelOutput> item = result.Cast<GetDICVAdvancedSearchModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger,"");
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dicv_communication_email_reset_password")]
        public async Task<IActionResult> GetDICVCommunicationEmailResetPassword([FromBody] GetDICVCommunicationEmailResetPasswordModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVCommunicationEmailResetPassword(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetDICVCommunicationEmailResetPasswordModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_dicv_communication_email_reset_password")]
        public async Task<IActionResult> UpdateDICVCommunicationEmailResetPassword([FromBody] UpdateDICVCommunicationEmailResetPasswordModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.UpdateDICVCommunicationEmailResetPassword(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateDICVCommunicationEmailResetPasswordModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <CreatedBy>Manmohan 27-06-2022</CreatedBy>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("dicv_update_customer")]
        public async Task<IActionResult> UpdateDICVCustomerDetail([FromBody] UpdateDICVCustomerDetailModelinput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.UpdateDICVCustomerDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateDICVCustomerDetailModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateDICVCustomerDetailModelOutput>().ToList()[0].Reason);
                    }


                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_dealer_wise_dicv_otc_card_request")]
        public async Task<IActionResult> InsertDealerWiseVEOTCCardRequest([FromBody] InsertDealerWiseDICVOTCCardRequestModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.InsertDealerWiseDICVOTCCardRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertDealerWiseDICVOTCCardRequestModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<InsertDealerWiseDICVOTCCardRequestModelOutput>().ToList()[0].Reason);
                    }


                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("dicv_unmapped_otc_card_detail")]
        public async Task<IActionResult> DICVUnMappedOTCCardDetail([FromBody] DICVUnMappedOTCCardModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.DICVUnMappedOTCCardDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.ObjDICVViewCardDetail.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dicv_balance_otc_card")]
        public async Task<IActionResult> GetDICVBalanceOTCCard([FromBody] GetDICVBalanceOTCCardModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVBalanceOTCCard(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDICVBalanceOTCCardModelOutput> item = result.Cast<GetDICVBalanceOTCCardModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_dicv_dealer_email_reset_password")]
        public async Task<IActionResult> UpdateDICVDealerEmailResetPassword([FromBody] UpdateDicvDealerEmailResetPasswordModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.UpdateDICVDealerEmailResetPassword(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateDICVCommunicationEmailResetPasswordModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
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
        [Route("get_dicv_customer_kyc")]
        public async Task<IActionResult> GetDICVCustomerKYC([FromBody] GetDICVCustomerKYCModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVCustomerKYC(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDICVCustomerKYCModelOutput> item = result.Cast<GetDICVCustomerKYCModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
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
        [Route("get_dicv_contact_us_detail")]
        public async Task<IActionResult> GetDICVContactUSDetail([FromBody] DICVContactUSDetailModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVContactUSDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<DICVContactUSDetailModelOutput> item = result.Cast<DICVContactUSDetailModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
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
        [Route("get_dicv_loyality_point_summary")]
        public async Task<IActionResult> GetDICVLoyalityPointSummary([FromBody] DICVLoyalityPointSummaryModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVLoyalityPointSummary(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<DICVLoyalityPointSummaryModelOutput> item = result.Cast<DICVLoyalityPointSummaryModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_dicv_dispatch_detail")]
        public async Task<IActionResult> GetDICVDispatchDetail([FromBody] GetDICVDispatchDetailModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _DICVRepo.GetDICVDispatchDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDICVDispatchDetailModelOutput> item = result.Cast<GetDICVDispatchDetailModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }
    }
}
