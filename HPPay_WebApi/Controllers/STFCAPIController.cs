using HPPay.DataModel.SMSGetSend;
using HPPay.DataModel.STFCAPI;
using HPPay.DataRepository.SMSGetSend;
using HPPay.DataRepository.STFCAPI;
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
    [Route("/api/STFCAPI/STFC")]
    public class STFCAPIController : ControllerBase
    {
        private readonly ILogger<STFCAPIController> _logger;
        private readonly ISTFCAPIRepository _STFCApiRepo;
        private readonly ISMSGetSendRepository _GetSendRepo;

        public STFCAPIController(ILogger<STFCAPIController> logger, ISTFCAPIRepository STFCApiRepo, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _STFCApiRepo = STFCApiRepo;
            _GetSendRepo = GetSendRepo;
        }

        //[HttpPost]
        //[Route("CreateCustomer")]


        //public async Task<IActionResult> CreateCustomer([FromBody] STFCCreateCustomerModelInput ObjClass)
        //{
        //    if (ObjClass == null)
        //    {
        //        return this.STFCBadRequestCustom(ObjClass, null, _logger);
        //    }
        //    else
        //    {
        //        var result = await _STFCApiRepo.CreateCustomer(ObjClass);
        //        if (result == null)
        //        {
        //            return this.STFCNotFoundCustom(ObjClass, null, _logger);
        //        }
        //        else
        //        {

        //            if (result== "0")
        //                return this.STFCOkCustom(ObjClass, result, _logger);
        //            else
        //                return this.STFCFail(ObjClass, result, _logger);
        //        }
        //    }
        //}

        [HttpPost]
        [ServiceFilter(typeof(STFCAPIAuthenticationFilter))]
        [Route("CreateCustomer")]
        public async Task<IActionResult> STFCAPICreateCustomer([FromBody] STFCCreateCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.STFCBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _STFCApiRepo.CreateCustomer(ObjClass);
                if (result == null)
                {
                    return this.STFCNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCustResFinalOutput> itemobj = result.Cast<GetCustResFinalOutput>().ToList();
                    if (itemobj.Count > 0)
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
                                        getandInsertSendInputModel.Useragent = "Web";
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
                                        //if (result.Cast<GetCustResFinalOutput>().ToList()[0].EmailId == "")
                                        //{
                                        //    result.Cast<GetCustResFinalOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
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

                        return this.STFCOkCustom(ObjClass, result, _logger);
                    }
                    else
                        return this.STFCFail(ObjClass, result, _logger);
                }
            }
        }


        //[HttpPost]
        //[ServiceFilter(typeof(STFCAPIAuthenticationFilter))]
        //[Route("CreateCard")]
        //public async Task<IActionResult> STFCAPICreateCard([FromBody] STFCCreateCardModelInput ObjClass)
        //{
        //    if (ObjClass == null)
        //    {
        //        return this.STFCBadRequestCustom(ObjClass, null, _logger);
        //    }
        //    else
        //    {
        //        var result = await _STFCApiRepo.CreateCard(ObjClass);
        //        if (result == null)
        //        {
        //            return this.STFCNotFoundCustom(ObjClass, null, _logger);
        //        }
        //        else
        //        {
        //            List<cardDetailsfinaloutput> item = result.Cast<cardDetailsfinaloutput>().ToList();
        //            if (item.Count > 0)
        //                return this.STFCOkCustom(ObjClass, result, _logger);
        //            else
        //                return this.STFCFail(ObjClass, result, _logger);
        //        }
        //    }
        //}

        [HttpPost]
        [ServiceFilter(typeof(STFCAPIAuthenticationFilter))]
        [Route("CreateCard")]
        public async Task<IActionResult> STFCAPICreateCard([FromBody] STFCCreateCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.STFCBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _STFCApiRepo.CreateCard(ObjClass);
                if (result == null)
                {
                    return this.STFCNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.cardRes.cardDetail.statusCode == "0")
                        return this.STFCOkCustom(ObjClass, result, _logger);
                    else
                        return this.STFCFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(STFCAPIAuthenticationFilter))]
        [Route("UpdateStatus")]
        public async Task<IActionResult> STFCAPIUpdateStatus([FromBody] STFCUpdateStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.STFCBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _STFCApiRepo.UpdateStatus(ObjClass);
                if (result == null)
                {
                    return this.STFCNotFoundCustom(ObjClass, null, _logger);
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
                                        //if (result.Cast<STFCUpdateStatusModelInput>().ToList()[0].EmailId == "")
                                        //{
                                        //    result.Cast<STFCUpdateStatusModelInput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
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

                        return this.STFCOkCustom(ObjClass, result, _logger);
                    }
                    else
                        return this.STFCFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(STFCAPIAuthenticationFilter))]
        [Route("GetConsumptionData")]
        public async Task<IActionResult> STFCAPIGetConsumptionData([FromBody] STFCGetConsumptionDataModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.STFCBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _STFCApiRepo.GetConsumptionData(ObjClass);
                if (result == null)
                {
                    return this.STFCNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.consumptionRes.FirstOrDefault().responseCode == "0")
                        return this.STFCOkCustom(ObjClass, result, _logger);
                    else
                        return this.STFCFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(STFCAPIAuthenticationFilter))]
        [Route("GetCardHotlistStatus")]
        public async Task<IActionResult> STFCAPIGetCardHotlistStatus([FromBody] STFCGetCardHotlistStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.STFCBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _STFCApiRepo.GetCardHotlistStatus(ObjClass);
                if (result == null)
                {
                    return this.STFCNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.cardHotListResponse.FirstOrDefault().responseCode == "0")
                        return this.STFCOkCustom(ObjClass, result, _logger);
                    else
                        return this.STFCFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(STFCAPIAuthenticationFilter))]
        [Route("MAPSTFCCardless")]
        public async Task<IActionResult> STFCAPIMAPSTFCCardless([FromBody] STFCMAPSTFCCardlessModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.STFCBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _STFCApiRepo.MAPSTFCCardless(ObjClass);
                if (result == null)
                {
                    return this.STFCNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<STFCMAPSTFCCardlessModelOutput> itemobj = result.Cast<STFCMAPSTFCCardlessModelOutput>().ToList();
                    if (itemobj.Count > 0)
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
                                        //if (result.Cast<STFCMAPSTFCCardlessModelOutput>().ToList()[0].EmailId == "")
                                        //{
                                        //    result.Cast<STFCMAPSTFCCardlessModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
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

                        return this.STFCOkCustom(ObjClass, result, _logger);
                    }
                    else
                        return this.STFCFail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(STFCAPIAuthenticationFilter))]
        [Route("GetAllTransactions")]
        public async Task<IActionResult> STFCAPIGetAllTransactions([FromBody] STFCGetAllTransactionsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.STFCBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _STFCApiRepo.GetAllTransactions(ObjClass);
                if (result == null)
                {
                    return this.STFCNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<CustomerAPIGetProductRSPModelOutput> item = result.Cast<CustomerAPIGetProductRSPModelOutput>().ToList();
                    if (result.responseCode == "0")
                        return this.STFCOkCustom(ObjClass, result, _logger);
                    else
                        return this.STFCFail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [Route("GetHotlistReactivateReason")]
        public async Task<IActionResult> STFCAPIGetHotlistReactivateReason([FromBody] STFCGetHotlistReactivateReasonModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.STFCBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _STFCApiRepo.GetHotlistReactivateReason(ObjClass);
                if (result == null)
                {
                    return this.STFCNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<CustomerAPIGetProductRSPModelOutput> item = result.Cast<CustomerAPIGetProductRSPModelOutput>().ToList();
                    if (result.lstResponse.FirstOrDefault().responseCode == "0")
                        return this.STFCOkCustom(ObjClass, result, _logger);
                    else
                        return this.STFCFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpGet]
        [ServiceFilter(typeof(STFCAPIAuthenticationFilter))]
        [Route("GetCustomerHotlistStatus")]
        public async Task<IActionResult> STFCAPIGetCustomerHotlistStatus([FromBody] STFCGetCustomerHotlistStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.STFCBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _STFCApiRepo.GetCustomerHotlistStatus(ObjClass);
                if (result == null)
                {
                    return this.STFCNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<CustomerAPIGetProductRSPModelOutput> item = result.Cast<CustomerAPIGetProductRSPModelOutput>().ToList();
                    if (result.customerHotlistDeatils.responseCode == "0")
                        return this.STFCOkCustom(ObjClass, result, _logger);
                    else
                        return this.STFCFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(STFCAPIAuthenticationFilter))]
        [Route("DehotlistCustomerWithPAN")]
        public async Task<IActionResult> STFCAPIDehotlistCustomerWithPAN([FromBody] STFCDehotlistCustomerWithPANModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.STFCBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _STFCApiRepo.DehotlistCustomerWithPAN(ObjClass);
                if (result == null)
                {
                    return this.STFCNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    // List<GetdehotlistCustfinaloutput> item = result.Cast<GetdehotlistCustfinaloutput>().ToList();
                    if (result.dehotlistCust.responseCode == "0")
                        return this.STFCOkCustom(ObjClass, result, _logger);
                    else
                        return this.STFCFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(STFCAPIAuthenticationFilter))]
        [Route("UpdateCardLimitinBulk")]
        public async Task<IActionResult> STFCAPIUpdateCardLimitinBulk([FromBody] STFCUpdateCardLimitinBulkModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.STFCBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _STFCApiRepo.UpdateCardLimitinBulk(ObjClass);
                if (result == null)
                {
                    return this.STFCNotFoundCustom(ObjClass, null, _logger);
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
                                        //if (result.Cast<STFCUpdateCardLimitinBulkModelOutput>().ToList()[0].EmailId == "")
                                        //{
                                        //    result.Cast<STFCUpdateCardLimitinBulkModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
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
                        return this.STFCOkCustom(ObjClass, result, _logger);
                    }
                    else
                        return this.STFCFail(ObjClass, result, _logger);
                }
            }
        }
    }
}
