using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using HPPay_WebApi.ExtensionMethod;
using HPPay_WebApi.ActionFilters;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using HPPay.DataRepository.HLFL;
using HPPay.DataModel.HLFL;
using Dapper;
using System.Data;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http;
using HPPay.Infrastructure.CommonClass;
using System;
using HPPay.DataRepository.SMSGetSend;
using HPPay.DataModel.SMSGetSend;
using System.Text;
using System.Globalization;
using HPPay.DataModel.Card;
using HPPay.DataModel.HDFCCreditPouch;

namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/HLFLAPI/Transaction")]
    public class HLFLController : ControllerBase
    {
        private readonly ILogger<HLFLController> _logger;
        private readonly IHLFLRepository _hlfl;
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;

        private readonly ISMSGetSendRepository _GetSendRepo;

        public HLFLController(ILogger<HLFLController> logger, IHLFLRepository hlfl, IConfiguration configuration, DapperContext context, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _hlfl = hlfl;
            _configuration = configuration;
            _context = context;

        }


        [HttpPost]
        [ServiceFilter(typeof(HLFLAPIAuthenticationFilter))]
        [Route("CreateCustomer")]
        public async Task<IActionResult> HLFLCreateCustomer([FromBody] HLFLCreateCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _hlfl.HLFLCreateCustomer(ObjClass);
                if (result == null)
                {
                    return this.HLFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<HLFLCreateCustomerModelOutput>().ToList()[0].Status == 0)
                    {


                        #region 23-08-2022


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
                                        getandInsertSendInputModel.CreatedBy = ObjClass.CreatedBy;//Added
                                        getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                        string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                        TemplateMessage = TemplateMessage.Replace("", "");

                                        getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");//database
                                        getandInsertSendInputModel.MobileNo = "";//database
                                        getandInsertSendInputModel.OfficerMobileNo = "";//database
                                        getandInsertSendInputModel.HeaderTemplate = "";//database
                                        getandInsertSendInputModel.Userip = null;
                                        getandInsertSendInputModel.Userid = null;
                                        getandInsertSendInputModel.Useragent = null;
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
                                        //if (result.Cast<MerchantInsertTerminalDeInstallationRequestAuthorizationModelOutput>().ToList()[0].EmailId == "")
                                        //{
                                        //    result.Cast<MerchantInsertTerminalDeInstallationRequestAuthorizationModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                        //}

                                        EmailTemplateMessage = EmailTemplateMessage.Replace("", ""); // database

                                        insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");
                                        insertEmailTextEntryInputModel.CreatedBy = ObjClass.CreatedBy;//Added
                                        await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ControllerContext.ActionDescriptor.ActionName + " :: Email and SMS Error :" + ex.Message);
                        }


                        #endregion



                        return this.HLFLOkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.HLFLFail(ObjClass, result, _logger);
                    }
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(HLFLAPIAuthenticationFilter))]
        [Route("MapFacility")]
        public async Task<IActionResult> HLFLMapFacility([FromBody] HLFLMapFacilityModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _hlfl.HLFLMapFacility(ObjClass);

                if (result == null)
                {
                    return this.HLFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    if (result.CardListModel.Count > 0)
                        return this.HLFLOkCustom(ObjClass, result, _logger);
                    else
                        return this.HLFLFail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(HLFLAPIAuthenticationFilter))]
        [Route("CreateCard")]
        public async Task<IActionResult> HLFLCreateCard([FromForm] HLFLCreateCardModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                IEnumerable<HLFLValidateCredentialsModelOutput> Validation = new List<HLFLValidateCredentialsModelOutput>();
                var procedureName = "UspHLFLAPIsValidateCredentials";
                var parameters = new DynamicParameters();

                parameters.Add("Username", HttpContext.Session.GetString("HLFLUsername"), DbType.String, ParameterDirection.Input);
                parameters.Add("Password", HttpContext.Session.GetString("HLFLPassword"), DbType.String, ParameterDirection.Input);
                parameters.Add("SecurityToken", HttpContext.Session.GetString("HLFLSecurityToken"), DbType.String, ParameterDirection.Input);
                parameters.Add("AuthKey", _configuration.GetSection("HLFLSettings:SecurityToken").Value, DbType.String, ParameterDirection.Input);
                using var connection = _context.CreateConnection();
                Validation = connection.Query<HLFLValidateCredentialsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                if (Validation.FirstOrDefault().Status == "0")
                {
                    var result = await _hlfl.HLFLCreateCard(ObjClass);
                    if (result == null)
                    {
                        return this.HLFLNotFoundCustom(ObjClass, null, _logger);
                    }
                    else
                    {
                        if (result.Cast<HLFLCreateCardModelOutPut>().ToList()[0].Status == 0)
                        {

                            #region 23-08-2022


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
                                            getandInsertSendInputModel.CreatedBy = ObjClass.CreatedBy;//Added
                                            getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                            string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                            TemplateMessage = TemplateMessage.Replace("", "");

                                            getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");//database
                                            getandInsertSendInputModel.MobileNo = "";//database
                                            getandInsertSendInputModel.OfficerMobileNo = "";//database
                                            getandInsertSendInputModel.HeaderTemplate = "";//database
                                            getandInsertSendInputModel.Userip = "";
                                            getandInsertSendInputModel.Userid = ObjClass.CreatedBy;
                                            getandInsertSendInputModel.Useragent = "";
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
                                            //if (result.Cast<MerchantInsertTerminalDeInstallationRequestAuthorizationModelOutput>().ToList()[0].EmailId == "")
                                            //{
                                            //    result.Cast<MerchantInsertTerminalDeInstallationRequestAuthorizationModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                            //}

                                            EmailTemplateMessage = EmailTemplateMessage.Replace("", ""); // database

                                            insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");
                                            insertEmailTextEntryInputModel.CreatedBy = ObjClass.CreatedBy;//Added
                                            await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ControllerContext.ActionDescriptor.ActionName + " :: Email and SMS Error :" + ex.Message);
                            }


                            #endregion


                            return this.HLFLOkCustom(ObjClass, result, _logger);
                        }
                        else
                        {
                            return this.HLFLFail(ObjClass, result, _logger);
                        }
                    }
                }
                else
                {
                    return this.HLFLFail(ObjClass, Validation, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(HLFLAPIAuthenticationFilter))]
        [Route("UpdateCardLimit")]
        public async Task<IActionResult> HLFLCardLimit([FromBody] HLFLCardLimitModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _hlfl.HLFLCardLimit(ObjClass);
                if (result == null)
                {
                    return this.HLFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<HLFLCardLimitModelOutPut>().ToList()[0].Status == 0)
                    {
                        return this.HLFLOkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.HLFLFail(ObjClass, result, _logger);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(HLFLAPIAuthenticationFilter))]
        [Route("CheckCustomerStatus")]
        public async Task<IActionResult> HLFLCheckCustomerStatus([FromBody] HLFLCheckCustomerStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _hlfl.HLFLCheckCustomerStatus(ObjClass);
                if (result == null)
                {
                    return this.HLFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<HLFLCheckCustomerStatusModelOutPut>().ToList()[0].Status == 0)
                    {
                        return this.HLFLOkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.HLFLFail(ObjClass, result, _logger);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(HLFLAPIAuthenticationFilter))]
        [Route("CheckCCMSRechargeStatus")]
        public async Task<IActionResult> HLFLCheckCCMSRechargeStatus([FromBody] HLFLCheckCCMSRechargeStatusModelInPut ObjClass)
        {

            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _hlfl.HLFLCheckCCMSRechargeStatus(ObjClass);
                if (result == null)
                {
                    return this.HLFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<HLFLCheckCCMSRechargeStatusModelOutPut>().ToList()[0].Status == 0)
                    {
                        return this.HLFLOkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.HLFLFail(ObjClass, result, _logger);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(HLFLAPIAuthenticationFilter))]
        [Route("ProcessCustomerRecharge")]
        public async Task<IActionResult> HLFLProcessCustomerRecharge([FromBody] HLFLProcessCustomerRechargeModelInPut ObjClass)
        {

            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _hlfl.HLFLProcessCustomerRecharge(ObjClass);
                if (result == null)
                {
                    return this.HLFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<HLFLProcessCustomerRechargeModelOutPut>().ToList()[0].Status == 0)
                    {
                        return this.HLFLOkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.HLFLFail(ObjClass, result, _logger);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(HLFLAPIAuthenticationFilter))]
        [Route("ValidateCustomer")]
        public async Task<IActionResult> HLFLValidateCustomer([FromBody] HLFLValidateCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _hlfl.HLFLValidateCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.CustomerList.Count > 0)
                        return this.HLFLOkCustom(ObjClass, result, _logger);
                    else
                        return this.HLFLFail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(HLFLAPIAuthenticationFilter))]
        [Route("GetProductRSP")]
        public async Task<IActionResult> HLFLGetProductRSP([FromBody] HLFLGetProductRSPModelInPut ObjClass)
        {

            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _hlfl.HLFLGetProductRSP(ObjClass);

                if (result == null)
                {
                    return this.HLFLNotFoundCustom(ObjClass, null, _logger);
                }


                else
                {

                    if (result.ProductList.Count > 0)
                        return this.HLFLOkCustom(ObjClass, result, _logger);
                    else
                        return this.HLFLFail(ObjClass, result, _logger);

                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(HLFLAPIAuthenticationFilter))]
        [Route("MapDriverMobile")]
        public async Task<IActionResult> HLFLMapDriverMobile([FromBody] HLFLMapDriverMobileModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _hlfl.HLFLMapDriverMobile(ObjClass);
                if (result == null)
                {
                    return this.HLFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<HLFLMapDriverMobileModelOutPut>().ToList()[0].Status == 0)
                    {

                        #region 23-08-2022


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
                                        getandInsertSendInputModel.CreatedBy = ObjClass.CustomerID;//Added
                                        getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                        string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                        TemplateMessage = TemplateMessage.Replace("", "");

                                        getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");//database
                                        getandInsertSendInputModel.MobileNo = "";//database
                                        getandInsertSendInputModel.OfficerMobileNo = "";//database
                                        getandInsertSendInputModel.HeaderTemplate = "";//database
                                        getandInsertSendInputModel.Userip = null;
                                        getandInsertSendInputModel.Userid = null;
                                        getandInsertSendInputModel.Useragent = null;
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
                                        //if (result.Cast<MerchantInsertTerminalDeInstallationRequestAuthorizationModelOutput>().ToList()[0].EmailId == "")
                                        //{
                                        //    result.Cast<MerchantInsertTerminalDeInstallationRequestAuthorizationModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                        //}

                                        EmailTemplateMessage = EmailTemplateMessage.Replace("", ""); // database

                                        insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");
                                        insertEmailTextEntryInputModel.CreatedBy = ObjClass.CustomerID;//Added
                                        await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ControllerContext.ActionDescriptor.ActionName + " :: Email and SMS Error :" + ex.Message);
                        }


                        #endregion

                        return this.HLFLOkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.HLFLFail(ObjClass, result, _logger);
                    }
                }
            }
        }

        [HttpPost] 
        [Route("HLFLInsertRequestResponse")]
        public async Task<IActionResult> InsertHLFLRequestResponse([FromBody] HLFLInsertRequestResponseModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _hlfl.InsertHLFLRequestResponse(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<HLFLInsertRequestResponseModel>().ToList()[0].Status == 0)
                    {
                        return this.HLFLOkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.HLFLFail(ObjClass, result, _logger);
                       // result.Cast<HLFLInsertRequestResponseModel>().ToList()[0].responseMessage);
                    }
                }
            }
        }
        [HttpPost]
       // [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("CheckCustomerLimitStatus")] 
        public async Task<IActionResult> CheckCustomerLimitStatus([FromBody] HLFLCheckLimitStatusModelInput ObjClass)
        {
            HLFLGetCustomerDetailsModelInput objDtls = new HLFLGetCustomerDetailsModelInput();
            objDtls.AggrCustomerID = ObjClass.AggrCustomerID;

            HLFLLimitStatusCheckModelInput userDetail = new HLFLLimitStatusCheckModelInput();

            var DtlResult = await _hlfl.USPGetHLFLCustomerDetails(objDtls);

            userDetail.aggrID = "HPPay";
            userDetail.product = "Fuel";
            userDetail.aggrControlCardNumber = DtlResult.Cast<HLFLGetCustomerDetailsModelOutput>().ToList()[0].AggrControlCardNumber;
            userDetail.hlflcustomerID = DtlResult.Cast<HLFLGetCustomerDetailsModelOutput>().ToList()[0].HLFLCustomerId;
            userDetail.facilityNumber = DtlResult.Cast<HLFLGetCustomerDetailsModelOutput>().ToList()[0].FacilityNumber;
            userDetail.aggrCustomerID = DtlResult.Cast<HLFLGetCustomerDetailsModelOutput>().ToList()[0].AggrCustomerID;

            var authIdPwd = _configuration.GetSection("HLFLSettings:HLFLAPIAuthorization").Value;
            string responseapi = string.Empty;
            var urlStatuCheck = _configuration.GetSection("HLFLSettings:HLFLCheckLimitStatusAPIURL").Value;
            HLFLInsertRequestResponseModelInput ReqResponse = new HLFLInsertRequestResponseModelInput();
            ReqResponse.Request = JsonConvert.SerializeObject(userDetail);
            ReqResponse.APIUrl = urlStatuCheck;
            ReqResponse.APIName = "CheckCustomerLimitStatus";
            ReqResponse.AggrCustomerID = userDetail.aggrCustomerID;
            try
            {
                if (DtlResult != null)
                {
                    //-------------------------------------------------------------------------------------------
                    Uri u = new Uri(_configuration.GetSection("HLFLSettings:HLFLCheckLimitStatusAPIURL").Value);

                    var payload = new Dictionary<string, object>
                {
                    {"aggrID",  userDetail.aggrID},
                    {"product", userDetail.product},
                    {"aggrControlCardNumber", userDetail.aggrControlCardNumber},
                    {"hlflcustomerID",userDetail.hlflcustomerID },
                    {"facilityNumber",userDetail.facilityNumber },
                    {"aggrCustomerID",userDetail.aggrCustomerID }
                };

                    HttpContent c = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                    var t = Task.Run(() => APIHelper.PostURI(u, c, authIdPwd));
                    t.Wait();
                    HttpResponseMessage response = t.Result;
                    string responseString = await response.Content.ReadAsStringAsync();
                    //-------------------------------------------------------------------------------------------
                    HLFLCheckLimitStatusModelOutput results = new HLFLCheckLimitStatusModelOutput();
                    HLFLDDRequestModelOutput DDRresults = new HLFLDDRequestModelOutput();
                    if (!string.IsNullOrEmpty(responseString))
                    {
                        results = JsonConvert.DeserializeObject<HLFLCheckLimitStatusModelOutput>(responseString);
                        ReqResponse.OrderId = DtlResult.Cast<HLFLGetCustomerDetailsModelOutput>().ToList()[0].orderId;
                        //ReqResponse.Request = JsonConvert.SerializeObject(payload);
                        ReqResponse.Response = responseString;
                        ReqResponse.ResponseMessage = results.hlflStatusRemark;

                        var res = _hlfl.InsertHLFLRequestResponse(ReqResponse).Result;
                         
                        if (DDRresults.hlflStatusCode == "0")
                        {
                            return this.HLFLOkCustom(ObjClass, DDRresults, _logger);
                        }
                        else
                        {
                            return this.HLFLFail(ObjClass, DDRresults, _logger);
                        }
                    }

                }
                else
                {
                    return this.HLFLFail(ObjClass, DtlResult, _logger);
                }
            }
            catch (Exception ex)
            {
                responseapi = ex.Message;

            }
            return null;
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("InitiateDrawDownRequest")]
        //InitiateDrawDownRequest and CheckCustomerLimitStatus//
        public async Task<IActionResult> InitiateAndCheckCustomerLimitStatus([FromBody] HLFLCheckLimitStatusModelInput ObjClass)
        {
            bool possitive = ObjClass.Amount > 0;
            HLFLDetailsModelOutput RechargeModelOutPut = new HLFLDetailsModelOutput();
            double MinAmt = Convert.ToDouble(_configuration.GetSection("RechargeSettings:MinimumAmount").Value);
            if (MinAmt > ObjClass.Amount)
            {
                RechargeModelOutPut.Status = 0;
                RechargeModelOutPut.Reason = "Minimum amount should be " + _configuration.GetSection("RechargeSettings:MinimumAmount").Value;
                return this.OkCustom(ObjClass, RechargeModelOutPut, _logger);
            }
            else
            {
                HLFLGetCustomerDetailsModelInput objDtls = new HLFLGetCustomerDetailsModelInput();
                objDtls.AggrCustomerID = ObjClass.AggrCustomerID;

                HLFLLimitStatusCheckModelInput userDetail = new HLFLLimitStatusCheckModelInput();

                var DtlResult = await _hlfl.USPGetHLFLCustomerDetails(objDtls);

                userDetail.aggrID = "HPPay";
                userDetail.product = "Fuel";
                userDetail.aggrControlCardNumber = DtlResult.Cast<HLFLGetCustomerDetailsModelOutput>().ToList()[0].AggrControlCardNumber;
                userDetail.hlflcustomerID = DtlResult.Cast<HLFLGetCustomerDetailsModelOutput>().ToList()[0].HLFLCustomerId;
                userDetail.facilityNumber = DtlResult.Cast<HLFLGetCustomerDetailsModelOutput>().ToList()[0].FacilityNumber;
                userDetail.aggrCustomerID = DtlResult.Cast<HLFLGetCustomerDetailsModelOutput>().ToList()[0].AggrCustomerID;

                var authIdPwd = _configuration.GetSection("HLFLSettings:HLFLAPIAuthorization").Value;
                string responseapi = string.Empty;
                var urlStatuCheck = _configuration.GetSection("HLFLSettings:HLFLCheckLimitStatusAPIURL").Value;
                HLFLInsertRequestResponseModelInput ReqResponse = new HLFLInsertRequestResponseModelInput();
                ReqResponse.Request = JsonConvert.SerializeObject(userDetail);
                ReqResponse.APIUrl = urlStatuCheck;
                ReqResponse.APIName = "CheckCustomerLimitAndStatus";
                ReqResponse.AggrCustomerID = userDetail.aggrCustomerID;
                try
                {
                    if (DtlResult != null)
                    {
                        //-------------------------------------------------------------------------------------------
                        Uri u = new Uri(_configuration.GetSection("HLFLSettings:HLFLCheckLimitStatusAPIURL").Value);

                        var payload = new Dictionary<string, object>
                {
                    {"aggrID",  userDetail.aggrID},
                    {"product", userDetail.product},
                    {"aggrControlCardNumber", userDetail.aggrControlCardNumber},
                    {"hlflcustomerID",userDetail.hlflcustomerID },
                    {"facilityNumber",userDetail.facilityNumber },
                    {"aggrCustomerID",userDetail.aggrCustomerID }
                };

                        HttpContent c = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                        var t = Task.Run(() => APIHelper.PostURI(u, c, authIdPwd));
                        t.Wait();
                        HttpResponseMessage response = t.Result;
                        string responseString = await response.Content.ReadAsStringAsync();
                        //-------------------------------------------------------------------------------------------
                        HLFLCheckLimitStatusModelOutput results = new HLFLCheckLimitStatusModelOutput();
                        HLFLDDRequestModelOutput DDRresults = new HLFLDDRequestModelOutput();
                        if (!string.IsNullOrEmpty(responseString))
                        {
                            results = JsonConvert.DeserializeObject<HLFLCheckLimitStatusModelOutput>(responseString);
                            ReqResponse.OrderId = DtlResult.Cast<HLFLGetCustomerDetailsModelOutput>().ToList()[0].orderId;
                            //ReqResponse.Request = JsonConvert.SerializeObject(payload);
                            ReqResponse.Response = responseString;
                            ReqResponse.ResponseMessage = results.hlflStatusRemark;

                            var res = _hlfl.InsertHLFLRequestResponse(ReqResponse).Result;
                            //----------------------------------------Calling Draw Down Request API Begin------------------------------------------------------------// 
                            if (results.hlflStatusCode == 0 && Convert.ToDecimal(results.facilityBalanceAmount) >= Convert.ToDecimal(ObjClass.Amount))
                            {
                                HLFLDDRequestModelInput DDRdtl = new HLFLDDRequestModelInput();

                                DDRdtl.Authorization = _configuration.GetSection("HLFLSettings:HLFLAPIAuthorization").Value;
                                DDRdtl.AggrID = "HPPay";
                                DDRdtl.Source = "HPPay";
                                DDRdtl.Product = "Fuel";
                                DDRdtl.AggrRequestID = ReqResponse.OrderId;
                                DDRdtl.AggrControlCardNumber = userDetail.aggrControlCardNumber;
                                DDRdtl.HLFLCustomerID = userDetail.hlflcustomerID;
                                DDRdtl.HLFLFacilityNumber = userDetail.facilityNumber;
                                DDRdtl.AggrCustomerID = userDetail.aggrCustomerID;
                                DDRdtl.DDRequestDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                DDRdtl.DDRequestAmount = ObjClass.Amount;
                                var urlDDReques = _configuration.GetSection("HLFLSettings:HLFLInitiateDrawDownRequestAPIURL").Value;

                                //-----------------------------------------save Request Begin-----------------------------------------------------//
                                ReqResponse.Request = JsonConvert.SerializeObject(DDRdtl);
                                ReqResponse.APIUrl = urlDDReques;
                                ReqResponse.APIName = "DrawDownRequest";
                                ReqResponse.AggrCustomerID = userDetail.aggrCustomerID;
                                ReqResponse.OrderId = DtlResult.Cast<HLFLGetCustomerDetailsModelOutput>().ToList()[0].orderId;
                                ReqResponse.Response = null;
                                ReqResponse.ResponseMessage = null;

                                //-----------------------------------------save Request End----------------------------------------------------//
                                Uri u1 = new Uri(_configuration.GetSection("HLFLSettings:HLFLInitiateDrawDownRequestAPIURL").Value);

                                var payload1 = new Dictionary<string, object>
                            {
                                {"aggrId",  DDRdtl.AggrID},
                                {"product", DDRdtl.Product},
                                {"source", DDRdtl.Source },
                                {"aggrRequestId",DDRdtl.AggrRequestID },
                                {"aggrControlCardNumber", DDRdtl.AggrControlCardNumber},
                                {"hlflCustomerId",DDRdtl.HLFLCustomerID },
                                {"hlflFacilityNumber",DDRdtl.HLFLFacilityNumber },
                                //{"hlflFacilityNumber","FC0000528" },
                                {"aggrCustomerId",DDRdtl.AggrCustomerID },
                                {"ddRequestDate",DDRdtl.DDRequestDate },
                                {"ddRequestAmount",DDRdtl.DDRequestAmount }
                        };

                                HttpContent c1 = new StringContent(JsonConvert.SerializeObject(payload1), Encoding.UTF8, "application/json");
                                var t1 = Task.Run(() => APIHelper.PostURI(u1, c1, authIdPwd));
                                t1.Wait();
                                HttpResponseMessage response1 = t1.Result;
                                string responseString1 = await response1.Content.ReadAsStringAsync();
                                //------------------------------------------------------------------------------------------- 

                                DDRresults = JsonConvert.DeserializeObject<HLFLDDRequestModelOutput>(responseString1);
                                ReqResponse.Request = JsonConvert.SerializeObject(payload1);
                                ReqResponse.Response = responseString1;
                                ReqResponse.OrderId = DtlResult.Cast<HLFLGetCustomerDetailsModelOutput>().ToList()[0].orderId;
                                ReqResponse.ResponseMessage = DDRresults.hlflStatusRemark;
                                ReqResponse.HLFLRequestID = DDRresults.hlflRequestId;
                                results.hlflStatusRemark = DDRresults.hlflStatusRemark;
                                results.hlflRequestId = DDRresults.hlflRequestId;
                                results.aggrRequestId = DDRresults.aggrRequestId;
                                //-----------------------------------------save Response Begin-----------------------------------------------------//
                                var reslt = _hlfl.InsertHLFLRequestResponse(ReqResponse).Result;
                            }
                            //--------------------------------------------Calling Draw Down Request API ENd--------------------------------------------------------//
                            if (DDRresults.hlflStatusCode == "0")
                            {
                                return this.HLFLOkCustom(ObjClass, results, _logger);
                            }
                            else
                            {
                                return this.HLFLFail(ObjClass, DDRresults, _logger);
                            }
                        }

                    }
                    else
                    {
                        return this.HLFLFail(ObjClass, DtlResult, _logger);
                    }
                }
                catch (Exception ex)
                {
                    responseapi = ex.Message;

                }
            }
            return null;
        }


        [HttpPost] 
        [Route("HLFLdrawDownOTPValidate")]
        public async Task<IActionResult> InsertHLFLRechargeRequestDetails([FromBody] HLFLValidateOTPModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var authIdPwd = _configuration.GetSection("HLFLSettings:HLFLAPIAuthorization").Value; 
                string responseapi = string.Empty;
                var urlOTPValidateCheck = _configuration.GetSection("HLFLSettings:HLFLDrawDownOTPValidateAPIURL").Value;
                HLFLInsertRequestResponseModelInput ReqResponse = new HLFLInsertRequestResponseModelInput(); 
                ReqResponse.Request = JsonConvert.SerializeObject(ObjClass);
                ReqResponse.APIUrl = urlOTPValidateCheck;
                ReqResponse.APIName = "OTPValidationAndTransaction";
                ReqResponse.AggrCustomerID = ObjClass.AggrCustomerID;
                ReqResponse.OrderId = ObjClass.AggrRequestID; 
                //---------------------------------------------------------------------------------------------------------------// 
                Uri u1 = new Uri(_configuration.GetSection("HLFLSettings:HLFLDrawDownOTPValidateAPIURL").Value);

                var payload1 = new Dictionary<string, object>
                            {
                                {"aggrId",  ObjClass.AggrID},
                                {"product", ObjClass.Product},
                                {"source", "HPPay" },
                                {"aggrRequestId",ObjClass.AggrRequestID },
                                {"customerOtp",ObjClass.CustomerOTP },
                                {"hlflRequestId", ObjClass.HLFLRequestID},
                                {"aggrControlCardNumber", ObjClass.AggrControlCardNumber},
                                {"hlflCustomerId",ObjClass.HLFLCustomerID },
                                {"hlflFacilityNumber",ObjClass.HLFLFacilityNumber }, 
                                {"aggrCustomerId",ObjClass.AggrCustomerID }

                        };

                HttpContent c1 = new StringContent(JsonConvert.SerializeObject(payload1), Encoding.UTF8, "application/json");
                var t1 = Task.Run(() => APIHelper.PostURI(u1, c1, authIdPwd));
                t1.Wait();
                HttpResponseMessage response1 = t1.Result;
                string responseString1 = await response1.Content.ReadAsStringAsync();
                //-------------------------------------------------------------------------------------------//
                 

                HLFLValidateOTPOutput OTPResult = new HLFLValidateOTPOutput();
                OTPResult = JsonConvert.DeserializeObject<HLFLValidateOTPOutput>(responseString1);
                ReqResponse.Request = JsonConvert.SerializeObject(payload1);
                ReqResponse.Response = responseString1;
                ReqResponse.OrderId = ObjClass.AggrRequestID;
                ReqResponse.HLFLRequestID = ObjClass.HLFLRequestID;
                ReqResponse.ResponseMessage = OTPResult.hlflStatusRemark;
                ReqResponse.HLFLRequestID = ObjClass.HLFLRequestID;
                var reslt = _hlfl.InsertHLFLRequestResponse(ReqResponse).Result;
                //-----------------------------------------save Response Begin-----------------------------------------------------//

                if (OTPResult.hlflStatusCode == "0" && OTPResult.hlflStatusRemark == "Successfully Approved")
                { 
                    var result = await _hlfl.InsertHLFLRechargeRequestDetails(ObjClass,0);

                    if (result == null)
                    {
                        return this.NotFoundCustom(ObjClass, null, _logger);
                    }
                    else
                    {
                        if (result.Cast<HLFLValidateOTPOutput>().ToList()[0].hlflStatusCode == "0")
                        {
                            return this.HLFLOkCustom(ObjClass, result, _logger);
                        }
                        else
                        {
                            return this.HLFLFail(ObjClass, result, _logger); 
                        }
                    }
                    
                }
                return this.HLFLFail(ObjClass, OTPResult, _logger);
            }
            
        }


        [HttpPost]
        [Route("ResendOTPHLFL")]
        public async Task<IActionResult> HLFLResendOTP([FromBody] HLFLResendOTPInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var authIdPwd =   _configuration.GetSection("HLFLSettings:HLFLAPIAuthorization").Value; 
                string responseapi = string.Empty;
                var urlResendOTP = _configuration.GetSection("HLFLSettings:HLFLResendOTPAPIURL").Value;
                HLFLInsertRequestResponseModelInput ReqResponse = new HLFLInsertRequestResponseModelInput();
                ReqResponse.Request = JsonConvert.SerializeObject(ObjClass);
                ReqResponse.APIUrl = urlResendOTP;
                ReqResponse.APIName = "HLFLResendOTP";
                ReqResponse.AggrCustomerID = ObjClass.AggrCustomerID;
                ReqResponse.OrderId = ObjClass.AggrRequestID;
                ObjClass.DDRequestDate = Convert.ToDateTime(ObjClass.DDRequestDate).ToString("yyyy-MM-dd HH:mm:ss");
                //---------------------------------------------------------------------------------------------------------------// 
                Uri u1 = new Uri(_configuration.GetSection("HLFLSettings:HLFLResendOTPAPIURL").Value);

                var payload1 = new Dictionary<string, object>
                            {
                                {"aggrId", "HPPay"},
                                {"product", "Fuel"},
                                {"source", "HPPay" },
                                {"aggrRequestId",ObjClass.AggrRequestID },
                                {"hlflRequestId", ObjClass.HLFLRequestID},
                                {"aggrControlCardNumber", ObjClass.AggrControlCardNumber},
                                {"hlflCustomerId",ObjClass.HLFLCustomerID },
                                {"hlflFacilityNumber",ObjClass.HLFLFacilityNumber }, 
                                {"aggrCustomerId",ObjClass.AggrCustomerID },
                                {"ddRequestDate",ObjClass.DDRequestDate },
                                {"ddRequestAmount",ObjClass.DDRequestAmount }

                        };

                HttpContent c1 = new StringContent(JsonConvert.SerializeObject(payload1), Encoding.UTF8, "application/json");
                var t1 = Task.Run(() => APIHelper.PostURI(u1, c1, authIdPwd));
                t1.Wait();
                HttpResponseMessage response1 = t1.Result;
                string responseString1 = await response1.Content.ReadAsStringAsync();
                //-------------------------------------------------------------------------------------------//
                 
                HLFLResendOTPOutput OTPResult = new HLFLResendOTPOutput();
                OTPResult = JsonConvert.DeserializeObject<HLFLResendOTPOutput>(responseString1);
                ReqResponse.Request = JsonConvert.SerializeObject(payload1);
                ReqResponse.Response = responseString1;
                ReqResponse.OrderId = ObjClass.AggrRequestID;
                ReqResponse.ResponseMessage = OTPResult.hlflStatusRemark;
                ReqResponse.HLFLRequestID = ObjClass.HLFLRequestID;
                var reslt = _hlfl.InsertHLFLRequestResponse(ReqResponse).Result;

                return this.HLFLOkCustom(ObjClass, OTPResult, _logger);

            }
             
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("CheckIfHLFLUser")]
        public async Task<IActionResult> CheckIfHLFLUser([FromBody] CheckIfHLFLUserModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _hlfl.CheckIfHLFLUser(ObjClass);

                if (result == null)
                {
                    return this.HLFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    if (result.Cast<CheckIfHLFLUserModelOutput>().ToList()[0].Status == "1")
                        return this.HLFLOkCustom(ObjClass, result, _logger);
                    else
                        return this.HLFLFail(ObjClass, result, _logger);

                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("HLFLCheckTransactionStatus")]
        public async Task<IActionResult> HLFLCheckTransactionStatus([FromBody] HLFLCheckTransactionStatusInputModel ObjClass)
        {
            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _hlfl.HLFLCheckTransactionStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                { 
                    List<HLFLCheckTransactionStatusOutPutModel> item = result.Cast<HLFLCheckTransactionStatusOutPutModel>().ToList();
                    if (item.Count > 0)                        
                    {
                        return this.HLFLOkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.HLFLFail(ObjClass, result, _logger); 
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("HLFLGetStatusAndSources")]
        public async Task<IActionResult> HLFLGetStatusAndSource([FromBody] HLFLGetStatusAndSourceInPutModel ObjClass)
        {
            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _hlfl.HLFLGetStatusAndSource(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                { 
                        if (result.GetStatus.Count > 0 && result.GetSourceOutPut.Count > 0)
                        {
                        return this.HLFLOkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.HLFLFail(ObjClass, result, _logger);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("HLFLInsertSendEmailLog")]
        public async Task<IActionResult> uspHLFLInsertSendEmailLog([FromBody] HLFLInsertSendEmailLogInputModel ObjClass)
        {

            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _hlfl.uspHLFLInsertSendEmailLog(ObjClass);

                if (result == null)
                {
                    return this.HLFLNotFoundCustom(ObjClass, null, _logger);
                }


                else
                {

                    if (result.Cast<HLFLInsertSendEmailLogOutModel>().ToList()[0].Status == 1)
                        return this.HLFLOkCustom(ObjClass, result, _logger);
                    else
                        return this.HLFLFail(ObjClass, result, _logger);

                }
            }
        }

    }
}
