using Dapper;
using HPPay.DataModel.CommonValidations;
using HPPay.DataModel.CustomerAPI;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataRepository.CommonRequests;
using HPPay.DataRepository.CustomerAPI;
using HPPay.DataRepository.DBDapper;
using HPPay.DataRepository.SMSGetSend;
using HPPay.Infrastructure.CommonClass;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/CustomerInterface/CustomerAPI")]
    public class CustomerAPIController : ControllerBase
    {
        private readonly ILogger<CustomerAPIController> _logger;
        private readonly ICustomerAPIRepository _custApiRepo;
        private readonly ICommonValidations _commonValidations;
        private readonly DapperContext _context;
        private readonly ISMSGetSendRepository _GetSendRepo;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        //public CustomerAPIRepository(DapperContext context, IHostingEnvironment hostingEnvironment)
        //{
        //    _context = context;
        //    _hostingEnvironment = hostingEnvironment;
        //}
        public CustomerAPIController(ILogger<CustomerAPIController> logger, ICustomerAPIRepository customerApiRepo, ICommonValidations commonValidations, DapperContext context, IHostingEnvironment hostingEnvironment, ISMSGetSendRepository GetSendRepo, IConfiguration configuration)
        {
            _logger = logger;
            _custApiRepo = customerApiRepo;
            _commonValidations = commonValidations;
            _context = context;
            _GetSendRepo = GetSendRepo;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }

        [HttpPost]
        // [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("IsVehicleNumberExists")]
        public async Task<IActionResult> CustomerAPIIsVehicleNumberExists([FromBody] CustomerAPICheckVechileNoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.CustomerAPICheckVechileNo(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPICheckVechileNoModelOutput> item = result.Cast<CustomerAPICheckVechileNoModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("GetCustomerBalance")]
        public async Task<IActionResult> CustomerAPIGetCustomerBalance([FromBody] CustomerAPIGetCustomerBalanceModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.GetCustomerBalance(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPIGetCustomerBalanceModelOutput> item = result.Cast<CustomerAPIGetCustomerBalanceModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("GetCardBalance")]
        public async Task<IActionResult> CustomerAPIGetCardBalance([FromBody] CustomerAPIGetCardBalanceModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.GetCardBalance(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPIGetCardBalanceModelOutput> item = result.Cast<CustomerAPIGetCardBalanceModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("GetCustomerDetailsByMobileNo")]
        public async Task<IActionResult> CustomerAPIGetCustomerDetailsByMobileNo([FromBody] CustomerAPIGetCustomerDetailsByMobileNoModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.GetCustomerDetailsByMobileNo(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    CustomerAPIGetCustomerDetailsByMobileNoModelOutput item = result;
                    if (item.responseCode == "1")
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("BlockCards")]
        public async Task<IActionResult> CustomerAPIBlockCards([FromBody] CustomerAPIBlockCardsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.BlockCards(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPIBlockCardsModelOutput> item = result.Cast<CustomerAPIBlockCardsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("UnblockCards")]
        public async Task<IActionResult> CustomerAPIUnblockCards([FromBody] CustomerAPIUnblockCardsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.UnblockCards(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPIUnblockCardsModelOutput> item = result.Cast<CustomerAPIUnblockCardsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("GenerateMPin")]
        public async Task<IActionResult> CustomerAPIGenerateMPin([FromBody] CustomerAPIGenerateMPinModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.GenerateMPin(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPIGenerateMPinModelOutput> item = result.Cast<CustomerAPIGenerateMPinModelOutput>().ToList();
                    if (item.Count > 0)
                    {
                        RSADataUtiltiy rsaEncUtil = new RSADataUtiltiy();

                        result.FirstOrDefault().MPIN = rsaEncUtil.EncryptData(result.FirstOrDefault().MPIN, _configuration.GetSection("SaltKey:EncryptionKey").Value.ToString());
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    }
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("GetHSDTransactionDetails")]
        public async Task<IActionResult> CustomerAPIGetHSDTransactionDetails([FromBody] CustomerAPICustomerAPIGetHSDTransactionDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                HttpResponseMessage apiResponse;
                string responseapi = string.Empty;
                apiResponse = Variables.CallLnTAPI("https://ltceip4uat1.azure-api.net/HPPay/GetHSDTransactionDetails", JsonConvert.SerializeObject(ObjClass)).Result;

                var content = await apiResponse.Content.ReadAsStringAsync();

                JObject obj1 = JObject.Parse(JsonConvert.DeserializeObject(content).ToString());
                string respMessage = obj1.ToString();
                JObject obj2 = JObject.Parse(JsonConvert.DeserializeObject(respMessage).ToString());
                CustomerAPICustomerAPIGetHSDTransactionDetailsModelOutput resp = obj2.ToObject<CustomerAPICustomerAPIGetHSDTransactionDetailsModelOutput>();

                if (resp == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (resp.responseMessageCode == "90020")
                    {
                        return this.CustomerAPIOkCustom(ObjClass, resp, _logger);
                    }
                    else
                        return this.CustomerAPIFail(ObjClass, resp, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("MapCardless")]
        public async Task<IActionResult> CustomerAPIMapCardless([FromBody] CustomerAPIMapCardlessModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.MapCardless(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPIMapCardlessModelOutput> itemobj = result.Cast<CustomerAPIMapCardlessModelOutput>().ToList();
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
                                        //if (result.Cast<CustomerAPIMapCardlessModelOutput>().ToList()[0].EmailId == "")
                                        //{
                                        //    result.Cast<CustomerAPIMapCardlessModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
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


                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    }
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("GetTransactions")]
        public async Task<IActionResult> CustomerAPIGetTransactions([FromBody] CustomerAPIGetTransactionsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.GetTransactions(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<object> objectList = result.Item1.Cast<object>().Concat(result.Item2).ToList();
                    if (result.Item1.FirstOrDefault().responseMessage == "Success")
                    {
                        return this.CustomerAPIOkCustom(ObjClass, objectList, _logger);

                    }
                    else
                    {
                        return this.CustomerAPIFail(ObjClass, objectList, _logger);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("GetCardLimit")]
        public async Task<IActionResult> CustomerAPIGetCardLimit([FromBody] CustomerAPIGetCardLimitModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.GetCardLimit(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPIGetCardLimitModelOutput> item = result.Cast<CustomerAPIGetCardLimitModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [Route("SetCardLimit")]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        public async Task<IActionResult> CustomerAPISetCardLimit([FromBody] CustomerAPISetCardLimitModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.SetCardLimit(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPISetCardLimitModelOutput> item = result.Cast<CustomerAPISetCardLimitModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("HotlistReactivateCard")]
        public async Task<IActionResult> CustomerAPIHotlistReactivateCard([FromBody] CustomerAPIHotlistReactivateCardModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.HotlistReactivateCard(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPIHotlistReactivateCardModelOutput> item = result.Cast<CustomerAPIHotlistReactivateCardModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("HotlistReactivateCustomer")]
        public async Task<IActionResult> CustomerAPIHotlistReactivateCustomer([FromBody] CustomerAPIHotlistReactivateCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.HotlistReactivateCustomer(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPIHotlistReactivateCustomerModelOutput> item = result.Cast<CustomerAPIHotlistReactivateCustomerModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("SetCardAddOnLimit")]
        public async Task<IActionResult> CustomerAPISetCardAddOnLimit([FromBody] CustomerAPISetCardAddOnLimitModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.SetCardAddOnLimit(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPISetCardAddOnLimitModelOutput> item = result.Cast<CustomerAPISetCardAddOnLimitModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("IsCustomerActive")]
        public async Task<IActionResult> CustomerAPIIsCustomerActive([FromBody] CustomerAPIIsCustomerActiveModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.IsCustomerActive(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPIIsCustomerActiveModelOutput> item = result.Cast<CustomerAPIIsCustomerActiveModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("TransactionQueryStatusWithDetails")]
        public async Task<IActionResult> CustomerAPITransactionQueryStatusWithDetails([FromBody] CustomerAPITransactionQueryStatusWithDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.TransactionQueryStatusWithDetails(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPITransactionQueryStatusWithDetailsModelOutput> item = result.Cast<CustomerAPITransactionQueryStatusWithDetailsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("GetCustomerHotlistStatus")]
        public async Task<IActionResult> CustomerAPIGetCustomerHotlistStatus([FromBody] CustomerAPIGetCustomerHotlistStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.GetCustomerHotlistStatus(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPIGetCustomerHotlistStatusModelOutput> item = result.Cast<CustomerAPIGetCustomerHotlistStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("DehotlistCustomerWithPAN")]
        public async Task<IActionResult> CustomerAPIDehotlistCustomerWithPAN([FromBody] CustomerAPIDehotlistCustomerWithPANModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var data = await _commonValidations.PANValidation(ObjClass.PAN);

                JObject obj = JObject.Parse(JsonConvert.DeserializeObject(data).ToString());
                PanValidationResponse searchList = obj.ToObject<PanValidationResponse>();

                searchList.status_code = "101";
                if (searchList.status_code == "101")
                {
                    var result = await _custApiRepo.DehotlistCustomerWithPAN(ObjClass);
                    if (result == null)
                    {
                        return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                    }
                    else
                    {
                        List<CustomerAPIDehotlistCustomerWithPANModelOutput> item = result.Cast<CustomerAPIDehotlistCustomerWithPANModelOutput>().ToList();
                        if (item.Count > 0)
                            return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                        else

                            return this.CustomerAPIFail(ObjClass, result, _logger);
                    }
                }
                else
                {
                    CustomerAPIDehotlistCustomerWithPANModelOutput customerAPICheckPanModelOutputs = new CustomerAPIDehotlistCustomerWithPANModelOutput();
                    //List<GetcustRes> getcustRes = new List<GetcustRes>();
                    customerAPICheckPanModelOutputs.responseCode = "0";
                    customerAPICheckPanModelOutputs.responseMessage = "Invalid PAN.";


                    //customerAPICheckPanModelOutputs.custRes = getcustRes;
                    return this.CustomerAPIFail(ObjClass, customerAPICheckPanModelOutputs, _logger);
                }
            }
        }

        //[HttpPost]
        //[ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        //[Route("DehotlistCustomerWithPAN")]
        //public async Task<IActionResult> CustomerAPIDehotlistCustomerWithPAN([FromBody] CustomerAPIDehotlistCustomerWithPANModelInput ObjClass)
        //{
        //    if (ObjClass == null)
        //    {
        //        return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
        //    }
        //    else
        //    {
        //        var result = await _custApiRepo.DehotlistCustomerWithPAN(ObjClass);
        //        if (result == null)
        //        {
        //            return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
        //        }
        //        else
        //        {
        //            List<CustomerAPIDehotlistCustomerWithPANModelOutput> item = result.Cast<CustomerAPIDehotlistCustomerWithPANModelOutput>().ToList();
        //            if (item.Count > 0)
        //                return this.CustomerAPIOkCustom(ObjClass, result, _logger);
        //            else
        //                return this.CustomerAPIFail(ObjClass, result, _logger);
        //        }
        //    }
        //}

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("CheckCustomerActivity")]
        public async Task<IActionResult> CustomerAPICheckCustomerActivity([FromBody] CustomerAPICheckCustomerActivityModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.CheckCustomerActivity(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPICheckCustomerActivityModelOutput> item = result.Cast<CustomerAPICheckCustomerActivityModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("AggCustomerCreation")]
        public async Task<IActionResult> CustomerAPIAggCustomerCreation([FromBody] CustomerAPIAggCustomerCreationModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var data = await _commonValidations.PANValidation(ObjClass.OAggCustomer.PAN);

                JObject obj = JObject.Parse(JsonConvert.DeserializeObject(data).ToString());
                PanValidationResponse searchList = obj.ToObject<PanValidationResponse>();

                searchList.status_code = "101";
                if (searchList.status_code == "101")
                {
                    var result = await _custApiRepo.AggCustomerCreation(ObjClass);
                    if (result == null)
                    {
                        return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                    }
                    else
                    {
                        List<CustomerAPIAggCustomerCreationModelOutput> itemobj = result.Cast<CustomerAPIAggCustomerCreationModelOutput>().ToList();
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
                                            //if (result.Cast<CustomerAPIAggCustomerCreationModelOutput>().ToList()[0].EmailId == "")
                                            //{
                                            //    result.Cast<CustomerAPIAggCustomerCreationModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
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


                            return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                        }
                        else

                            return this.CustomerAPIFail(ObjClass, result, _logger);
                    }
                }
                else
                {
                    CustomerAPIAggCustomerCreationModelOutput customerAPICheckPanModelOutputs = new CustomerAPIAggCustomerCreationModelOutput();
                    List<GetcustRes> getcustRes = new List<GetcustRes>();
                    getcustRes.Add(new GetcustRes
                    {
                        responseCode = "0",
                        responseMessage = "Invalid PAN."
                    });
                    customerAPICheckPanModelOutputs.custRes = getcustRes;
                    return this.CustomerAPIFail(ObjClass, customerAPICheckPanModelOutputs, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("SetCardAllLimit")]
        public async Task<IActionResult> CustomerAPISetCardAllLimit([FromBody] CustomerAPISetCardAllLimitModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.SetCardAllLimit(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPISetCardAllLimitModelOutput> item = result.Cast<CustomerAPISetCardAllLimitModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("TransactionQueryStatus")]
        public async Task<IActionResult> CustomerAPITransactionQueryStatus([FromBody] CustomerAPITransactionQueryStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.TransactionQueryStatus(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPITransactionQueryStatusModelOutput> item = result.Cast<CustomerAPITransactionQueryStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("UnblockUserCardPIN")]
        public async Task<IActionResult> CustomerAPIUnblockUserCardPIN([FromBody] CustomerAPIUnblockUserCardPINModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.UnblockUserCardPIN(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPIUnblockUserCardPINModelOutput> item = result.Cast<CustomerAPIUnblockUserCardPINModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("GetProductRSP")]
        public async Task<IActionResult> CustomerAPIGetProductRSP([FromBody] CustomerAPIGetProductRSPModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.GetProductRSP(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<CustomerAPIGetProductRSPModelOutput> item = result.Cast<CustomerAPIGetProductRSPModelOutput>().ToList();
                    if (result.responseCode == "1")
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("GetConsumptionData")]
        public async Task<IActionResult> CustomerAPIGetConsumptionData([FromBody] CustomerAPIGetConsumptionDataModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.GetConsumptionData(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<CustomerAPIGetProductRSPModelOutput> item = result.Cast<CustomerAPIGetProductRSPModelOutput>().ToList();
                    if (result.responseCode == "1")
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("CustomerHotlistRequest")]
        public async Task<IActionResult> CustomerAPICustomerHotlistRequest([FromBody] CustomerAPICustomerHotlistRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.CustomerHotlistRequest(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<CustomerAPICustomerHotlistRequestModelOutput> item = result.Cast<CustomerAPICustomerHotlistRequestModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [Route("CreateCard")]
        public async Task<IActionResult> CustomerAPICreateCard([FromForm] CustomerAPICreateCardModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                IEnumerable<CustomerAPIValidateCredentialsModelOutput> Validation = new List<CustomerAPIValidateCredentialsModelOutput>();
                var procedureName = "UspCustomerAPIValidateCredentials";
                var parameters = new DynamicParameters();

                string FileNamePathIdProofFront = string.Empty;
                var ImageFileNameIdProofFront = ObjClass.RCDoc;

                if (ObjClass.RCDoc.Length / 1048576.0 <= 2)
                {
                    IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".jpeg", ".bmp" };
                    var ext = ImageFileNameIdProofFront.FileName.Substring(ImageFileNameIdProofFront.FileName.LastIndexOf('.'));
                    var extension = ext.ToLower();
                    if (!AllowedFileExtensions.Contains(extension))
                    {
                        List<CustomerAPICheckVechileNoModelOutput> customerAPICheckVechileNoModelOutputs = new List<CustomerAPICheckVechileNoModelOutput>();
                        customerAPICheckVechileNoModelOutputs.Add(new CustomerAPICheckVechileNoModelOutput
                        {
                            responseCode = "0",
                            responseMessage = "Invalid RC Doc Type."
                        });
                        return this.CustomerAPIFail(ObjClass, customerAPICheckVechileNoModelOutputs, _logger);
                    }
                }
                else
                {
                    List<CustomerAPICheckVechileNoModelOutput> customerAPICheckVechileNoModelOutputs = new List<CustomerAPICheckVechileNoModelOutput>();
                    customerAPICheckVechileNoModelOutputs.Add(new CustomerAPICheckVechileNoModelOutput
                    {
                        responseCode = "0",
                        responseMessage = "Only a file upto 2MB can be uploaded in RC Doc."
                    });
                    return this.CustomerAPIFail(ObjClass, customerAPICheckVechileNoModelOutputs, _logger);
                }




                parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
                parameters.Add("Password", ObjClass.Password, DbType.String, ParameterDirection.Input);
                parameters.Add("TransactionId", ObjClass.TransactionId, DbType.String, ParameterDirection.Input);
                parameters.Add("CustomerId", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
                parameters.Add("ControllerName", "CustomerAPI", DbType.String, ParameterDirection.Input);
                parameters.Add("ActionName", "CreateCard", DbType.String, ParameterDirection.Input);
                using var connection = _context.CreateConnection();
                Validation = connection.Query<CustomerAPIValidateCredentialsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                if (Validation.FirstOrDefault().responseCode == "0")
                {
                    List<CustomerAPICheckVechileNoModelOutput> customerAPICheckVechileNoModelOutputs = new List<CustomerAPICheckVechileNoModelOutput>();
                    customerAPICheckVechileNoModelOutputs.Add(new CustomerAPICheckVechileNoModelOutput
                    {
                        responseCode = "0",
                        responseMessage = Validation.FirstOrDefault().responseMessage
                    });
                    return this.CustomerAPIFail(ObjClass, customerAPICheckVechileNoModelOutputs, _logger);
                }
                else if (ObjClass.cardPreferenceType.ToLower() != "digital" && ObjClass.cardPreferenceType.ToLower() != "magstripe")
                {
                    List<CustomerAPICheckVechileNoModelOutput> customerAPICheckVechileNoModelOutputs = new List<CustomerAPICheckVechileNoModelOutput>();
                    customerAPICheckVechileNoModelOutputs.Add(new CustomerAPICheckVechileNoModelOutput
                    {
                        responseCode = "0",
                        responseMessage = "Invalid Card Preference Type, Only Digital and MagStripe is allowed."
                    });
                    return this.CustomerAPIFail(ObjClass, customerAPICheckVechileNoModelOutputs, _logger);
                }
                else
                {
                    var data = await _commonValidations.CheckVehicleRegistrationValid(ObjClass.vehicleNumber);

                    JObject obj = JObject.Parse(JsonConvert.DeserializeObject(data).ToString());
                    VehicleRegistrationNumberValidationResponse searchList = obj.ToObject<VehicleRegistrationNumberValidationResponse>();
                    searchList.statusCode = "101";
                    if (searchList.statusCode == "101")
                    {
                        var result = await _custApiRepo.CreateCard(ObjClass);
                        if (result == null)
                        {
                            return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                        }
                        else
                        {
                            List<CustomerAPICreateCardModelOutput> item = result.Cast<CustomerAPICreateCardModelOutput>().ToList();
                            if (item.Count > 0)
                                return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                            else
                                return this.CustomerAPIFail(ObjClass, result, _logger);
                        }
                    }
                    else
                    {
                        List<CustomerAPICheckVechileNoModelOutput> customerAPICheckVechileNoModelOutputs = new List<CustomerAPICheckVechileNoModelOutput>();
                        customerAPICheckVechileNoModelOutputs.Add(new CustomerAPICheckVechileNoModelOutput
                        {
                            responseCode = "0",
                            responseMessage = "Invalid Vehicle Number."
                        });
                        return this.CustomerAPIFail(ObjClass, customerAPICheckVechileNoModelOutputs, _logger);
                    }
                }
            }

        }
        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("ParentChildBalanceTransfer")]
        public async Task<IActionResult> CustomerAPIParentChildBalanceTransfer([FromBody] CustomerAPIParentChildBalanceTransferModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.ParentChildBalanceTransfer(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<CustomerAPIGetProductRSPModelOutput> item = result.Cast<CustomerAPIGetProductRSPModelOutput>().ToList();
                    if (result.FirstOrDefault().responseCode == "1")
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("ChildtoParentBalanceTransferRequest")]
        public async Task<IActionResult> CustomerAPIChildtoParentBalanceTransferRequest([FromBody] CustomerAPIChildtoParentBalanceTransferRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.ChildtoParentBalanceTransferRequest(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<CustomerAPIGetProductRSPModelOutput> item = result.Cast<CustomerAPIGetProductRSPModelOutput>().ToList();
                    if (result.FirstOrDefault().responseCode == "1")
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("CheckBalanceTransferStatus")]
        public async Task<IActionResult> CustomerAPICheckBalanceTransferStatus([FromBody] CustomerAPICheckBalanceTransferStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.CheckBalanceTransferStatus(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<CustomerAPIGetProductRSPModelOutput> item = result.Cast<CustomerAPIGetProductRSPModelOutput>().ToList();
                    if (result.FirstOrDefault().responseCode == "1")
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("CheckLoyaltyRedeemStatus")]
        public async Task<IActionResult> CustomerAPICheckLoyaltyRedeemStatus([FromBody] CustomerAPICheckLoyaltyRedeemStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.CheckLoyaltyRedeemStatus(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<CustomerAPIGetProductRSPModelOutput> item = result.Cast<CustomerAPIGetProductRSPModelOutput>().ToList();
                    if (result.FirstOrDefault().responseCode == "1")
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("LoyaltyRedeemRequest")]
        public async Task<IActionResult> CustomerAPILoyaltyRedeemRequest([FromBody] CustomerAPILoyaltyRedeemRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.LoyaltyRedeemRequest(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<CustomerAPIGetProductRSPModelOutput> item = result.Cast<CustomerAPIGetProductRSPModelOutput>().ToList();
                    if (result.FirstOrDefault().responseCode == "1")
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("ChildtoParentBalanceTransfer")]
        public async Task<IActionResult> CustomerAPIChildtoParentBalanceTransfer([FromBody] CustomerAPIChildtoParentBalanceTransferModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.ChildtoParentBalanceTransfer(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<CustomerAPIGetProductRSPModelOutput> item = result.Cast<CustomerAPIGetProductRSPModelOutput>().ToList();
                    if (result.FirstOrDefault().responseCode == "1")
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("ParentChildBalanceTransferV2")]
        public async Task<IActionResult> CustomerAPIParentChildBalanceTransferV2([FromBody] CustomerAPIParentChildBalanceTransferV2ModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.ParentChildBalanceTransferV2(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //List<CustomerAPIGetProductRSPModelOutput> item = result.Cast<CustomerAPIGetProductRSPModelOutput>().ToList();
                    if (result.FirstOrDefault().responseCode == "1")
                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("GetTransactionsV2")]
        public async Task<IActionResult> CustomerAPIGetTransactionsV2([FromBody] CustomerAPIGetTransactionsV2ModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.GetTransactionsV2(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<object> objectList = result.Item1.Cast<object>().Concat(result.Item2).ToList();
                    if (result.Item1.FirstOrDefault().responseMessage == "Success")
                        return this.CustomerAPIOkCustom(ObjClass, objectList, _logger);
                    else
                        return this.CustomerAPIFail(ObjClass, objectList, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomerAPIAuthenticationFilter))]
        [Route("GenerateTransactionOTP")]
        public async Task<IActionResult> CustomerAPIGenerateTransactionOTP([FromBody] CustomerAPIGenerateOTPModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.CustomerAPIBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _custApiRepo.CustomerAPIGenerateTransactionOTP(ObjClass);
                if (result == null)
                {
                    return this.CustomerAPINotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CustomerAPIGenerateOTPModelOutput>().ToList()[0].responseCode == "1")
                    {
                        //try
                        //{
                        //    GetSMSValueInputModel ObjSMSValue = new GetSMSValueInputModel();
                        //    ObjSMSValue.MethodName = ControllerContext.ActionDescriptor.ActionName;
                        //    var SMSResult = await _GetSendRepo.GetSMSValue(ObjSMSValue);
                        //    if (SMSResult != null)
                        //    {
                        //        List<GetSMSValueOutputModel> item = SMSResult.Cast<GetSMSValueOutputModel>().ToList();
                        //        for (int i = 0; i < item.Count; i++)
                        //        {
                        //            if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSEmailStatus == "1")
                        //            {

                        //                if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                        //                {
                        //                    GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                        //                    getandInsertSendInputModel.CreatedBy = ObjClass.Username;
                        //                    getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                        //                    string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                        //                    TemplateMessage = TemplateMessage
                        //                        .Replace("[OTP]", result.Cast<CustomerAPIGenerateOTPModelOutput>().ToList()[0].OTP);

                        //                    getandInsertSendInputModel.SMSText = TemplateMessage;
                        //                    getandInsertSendInputModel.MobileNo = ObjClass.MobileNumber;
                        //                    getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo;
                        //                    getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateName;
                        //                    getandInsertSendInputModel.Userip = "100:100:100:100";
                        //                    getandInsertSendInputModel.Userid = ObjClass.Username;
                        //                    getandInsertSendInputModel.Useragent = "CustomerAPI";
                        //                    getandInsertSendInputModel.SenderId = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SenderId;
                        //                    getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSAPIURL;
                        //                    await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);

                        //                }
                        //            }
                        //        }
                        //    }
                        //}
                        //catch (Exception ex)
                        //{
                        //    _logger.LogError(ControllerContext.ActionDescriptor.ActionName + " :: Email and SMS Error :" + ex.Message);
                        //}

                        RSADataUtiltiy rsaEncUtil = new RSADataUtiltiy();

                        result.FirstOrDefault().OTP = rsaEncUtil.EncryptData(result.FirstOrDefault().OTP, _configuration.GetSection("SaltKey:EncryptionKey").Value.ToString());

                        return this.CustomerAPIOkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.CustomerAPIFail(ObjClass, result, _logger);
                    }
                }
            }
        }
    }
}

