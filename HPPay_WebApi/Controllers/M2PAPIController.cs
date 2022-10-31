using HPPay.DataModel.M2PAPI;
using HPPay.DataModel.SFLAPI;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataRepository.M2PAPI;
using HPPay.DataRepository.SMSGetSend;
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
    [ApiController]
    [Route("M2PAPI/M2P")]
    public class M2PAPIController : ControllerBase
    {
        private readonly ILogger<M2PAPIController> _logger;
        private readonly IM2PAPIRepository _M2PApiRepo;
        private readonly ISMSGetSendRepository _GetSendRepo;

        public M2PAPIController(ILogger<M2PAPIController> logger, IM2PAPIRepository M2PApiRepo, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _M2PApiRepo = M2PApiRepo;
            _GetSendRepo = GetSendRepo;
        }
        [HttpPost]
        [ServiceFilter(typeof(M2PAPIAuthenticationFilter))]
        [Route("UpdateStatus")]
        public async Task<IActionResult> M2PAPIUpdateStatus([FromBody] M2PAPIUpdateStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.M2PBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _M2PApiRepo.UpdateStatus(ObjClass);
                if (result == null)
                {
                    return this.M2PNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.responseCode == "0")
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
                                        getandInsertSendInputModel.CreatedBy = ObjClass.Username;
                                        getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                        string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                        TemplateMessage = TemplateMessage.Replace("", "");

                                        getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");//database
                                        getandInsertSendInputModel.MobileNo = "";//database
                                        getandInsertSendInputModel.OfficerMobileNo = "";//database
                                        getandInsertSendInputModel.HeaderTemplate = "";//database
                                        getandInsertSendInputModel.Userip = "100:100:100:100";
                                        getandInsertSendInputModel.Userid = ObjClass.Username;
                                        getandInsertSendInputModel.Useragent = "web";
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
                                        //if (result.Cast<M2PAPIUpdateStatusModelMainOutput>().ToList()[0].EmailId == "")
                                        //{
                                        //    result.Cast<M2PAPIUpdateStatusModelMainOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                        //}

                                        EmailTemplateMessage = EmailTemplateMessage.Replace("", ""); // database

                                        insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");
                                        insertEmailTextEntryInputModel.CreatedBy = ObjClass.Username;
                                        await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ControllerContext.ActionDescriptor.ActionName + " :: Email and SMS Error :" + ex.Message);
                        }


                    return this.M2POkCustom(ObjClass, result, _logger);
                }
                    else
                        return this.M2PFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(M2PAPIAuthenticationFilter))]
        [Route("GetConsumptionData")]
        public async Task<IActionResult> M2PAPIGetConsumptionData([FromBody] M2PAPIGetConsumptionDataModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.M2PBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _M2PApiRepo.GetConsumptionData(ObjClass);
                if (result == null)
                {
                    return this.M2PNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.consumptionRes.FirstOrDefault().responseCode == "0")
                        return this.M2POkCustom(ObjClass, result, _logger);
                    else
                        return this.M2PFail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(M2PAPIAuthenticationFilter))]
        [Route("GetCardHotlistStatus")]
        public async Task<IActionResult> M2PAPIGetCardHotlistStatus([FromBody] M2PAPIGetCardHotlistStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.M2PBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _M2PApiRepo.GetCardHotlistStatus(ObjClass);
                if (result == null)
                {
                    return this.M2PNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.cardHotListResponse.FirstOrDefault().responseCode == "0")
                        return this.M2POkCustom(ObjClass, result, _logger);
                    else
                        return this.M2PFail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(M2PAPIAuthenticationFilter))]
        [Route("GetAllTransactions")]
        public async Task<IActionResult> M2PAPIGetAllTransactions([FromBody] M2PAPIGetAllTransactionsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.M2PBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _M2PApiRepo.GetAllTransactions(ObjClass);
                if (result == null)
                {
                    return this.M2PNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<CustomerAPIGetProductRSPModelOutput> item = result.Cast<CustomerAPIGetProductRSPModelOutput>().ToList();
                    if (result.responseCode == "0")
                        return this.M2POkCustom(ObjClass, result, _logger);
                    else
                        return this.M2PFail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(M2PAPIAuthenticationFilter))]
        [Route("MAPM2PCardless")]
        public async Task<IActionResult> M2PAPIMAPM2PCardless([FromBody] MAPM2PCardlessModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.M2PBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _M2PApiRepo.MAPM2PCardless(ObjClass);
                if (result == null)
                {
                    return this.M2PNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MAPM2PCardlessModelOutput> item = result.Cast<MAPM2PCardlessModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.M2POkCustom(ObjClass, result, _logger);
                    else
                        return this.M2PFail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(M2PAPIAuthenticationFilter))]
        [Route("CreateCard")]
        public async Task<IActionResult> M2PAPICreateCard([FromBody] M2PAPICreateCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.M2PBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _M2PApiRepo.CreateCard(ObjClass);
                if (result == null)
                {
                    return this.M2PNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.cardRes.cardDetail.statusCode == "0")
                        return this.M2POkCustom(ObjClass, result, _logger);
                    else
                        return this.M2PFail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(M2PAPIAuthenticationFilter))]
        [Route("CreateCustomer")]
        public async Task<IActionResult> M2PAPICreateCustomer([FromBody] M2PAPICreateCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.M2PBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _M2PApiRepo.CreateCustomer(ObjClass);
                if (result == null)
                {
                    return this.M2PNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCustResFinalOutput> item = result.Cast<GetCustResFinalOutput>().ToList();
                    if (item.Count > 0)
                        return this.M2POkCustom(ObjClass, result, _logger);
                    else
                        return this.M2PFail(ObjClass, result, _logger);
                }
            }
        }

    }
}
