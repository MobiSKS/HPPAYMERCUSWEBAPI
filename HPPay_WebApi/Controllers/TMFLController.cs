using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using HPPay.DataRepository.TMFL;
using HPPay_WebApi.ActionFilters;
using HPPay.DataModel.TMFL;
using HPPay_WebApi.ExtensionMethod;
using System.Threading.Tasks;
using System.Linq;
using Dapper;
using HPPay.DataModel.HLFL;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Data;
using HPPay.DataRepository.DBDapper;
using HPPay.DataRepository.SMSGetSend;
using HPPay.DataModel.SMSGetSend;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using HPPay.Infrastructure.CommonClass;

namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/TMFLAPI/Transaction")]
    public class TMFLController : ControllerBase
    {
        private readonly ILogger<TMFLController> _logger;
        private readonly ITMFLRepository _tmfl;
        private readonly IConfiguration _configuration;
        private readonly DapperContext _context;
        private readonly ISMSGetSendRepository _GetSendRepo;
        public TMFLController(ILogger<TMFLController> logger, ITMFLRepository tmfl, IConfiguration configuration, DapperContext context, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _tmfl = tmfl;
            _configuration = configuration;
            _context = context;
        }


        [HttpPost]
        [ServiceFilter(typeof(TMFLAPIAuthenticationFilter))]
        [Route("GetCardDetails")]
        public async Task<IActionResult> GetCardDetails([FromBody] GetCardDetailsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.TMFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmfl.GetCardDetails(ObjClass);
                if (result == null)
                {
                    return this.TMFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetCardDetailsModelOutPut>().ToList()[0].Status == 0)
                    {
                        return this.TMFLOkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.TMFLFail(ObjClass, result, _logger);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(TMFLAPIAuthenticationFilter))]
        [Route("MapFacility")]
        public async Task<IActionResult> MapFacility([FromBody] MapFacilityModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.TMFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmfl.MapFacility(ObjClass);

                if (result == null)
                {
                    return this.TMFLNotFoundCustom(ObjClass, null, _logger);
                }


                else
                {

                    if (result.tblThirdPartyCustomers2.Count > 0 && result.Status == 0)
                        return this.TMFLOkCustom(ObjClass, result, _logger);
                    else
                        return this.TMFLFail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(TMFLAPIAuthenticationFilter))]
        [Route("CreateCustomer")]
        public async Task<IActionResult> CreateCustomerTMFL([FromBody] TMFLCreateCustomerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.TMFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmfl.CreateCustomer(ObjClass);
                if (result == null)
                {
                    return this.TMFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TMFLCreateCustomerModelOutPut>().ToList()[0].Status == 0)
                    {

                        #region 23-08-2022


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
                        //            if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                        //            {
                        //                GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                        //                getandInsertSendInputModel.CreatedBy = ObjClass.CreatedBy;//Added
                        //                getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;
                        //                string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;
                        //                TemplateMessage = TemplateMessage.Replace("", "");
                        //                getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");//database
                        //                getandInsertSendInputModel.MobileNo = "";//database
                        //                getandInsertSendInputModel.OfficerMobileNo = "";//database
                        //                getandInsertSendInputModel.HeaderTemplate = "";//database
                        //                getandInsertSendInputModel.Userip = "";
                        //                getandInsertSendInputModel.Userid = "";
                        //                getandInsertSendInputModel.Useragent = "";
                        //                getandInsertSendInputModel.SenderId = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SenderId;
                        //                getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSAPIURL;
                        //                await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);
                        //            }

                        //            if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailStatus == 1)
                        //            {
                        //                string ZOROEmaild = String.Empty; //database

                        //                InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                        //                insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                        //                insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                        //                insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                        //                insertEmailTextEntryInputModel.EmailIdTo = "";//database
                        //                insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                        //                insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                        //                insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                        //                string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                        //                //database
                        //                //if (result.Cast<MerchantInsertTerminalDeInstallationRequestAuthorizationModelOutput>().ToList()[0].EmailId == "")
                        //                //{
                        //                //    result.Cast<MerchantInsertTerminalDeInstallationRequestAuthorizationModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                        //                //}

                        //                EmailTemplateMessage = EmailTemplateMessage.Replace("", ""); // database

                        //                insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");
                        //                insertEmailTextEntryInputModel.CreatedBy = ObjClass.CreatedBy;//Added
                        //                await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
                        //            }
                        //        }
                        //    }
                        //}
                        //catch (Exception ex)
                        //{
                        //    _logger.LogError(ControllerContext.ActionDescriptor.ActionName + " :: Email and SMS Error :" + ex.Message);
                        //}


                        #endregion


                        return this.TMFLOkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.TMFLFail(ObjClass, result, _logger);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(TMFLAPIAuthenticationFilter))]
        [Route("CreateCard")]
        public async Task<IActionResult> TMFLCreateCard([FromBody] CreateCardModelInput ObjClass)
        {


            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                IEnumerable<HLFLValidateCredentialsModelOutput> Validation = new List<HLFLValidateCredentialsModelOutput>();
                var procedureName = "UspTMFLAPIsValidateCredentials";
                var parameters = new DynamicParameters();
                parameters.Add("Username", HttpContext.Session.GetString("TMFLUsername"), DbType.String, ParameterDirection.Input);
                parameters.Add("Password", HttpContext.Session.GetString("TMFLPassword"), DbType.String, ParameterDirection.Input);
                parameters.Add("SecurityToken", HttpContext.Session.GetString("TMFLSecurityToken"), DbType.String, ParameterDirection.Input);
                parameters.Add("AuthKey", _configuration.GetSection("TMFLSettings:SecurityToken").Value, DbType.String, ParameterDirection.Input);
                using var connection = _context.CreateConnection();
                Validation = connection.Query<HLFLValidateCredentialsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                if (Validation.FirstOrDefault().Status == "0")
                {
                    var result = await _tmfl.CreateCard(ObjClass);
                    if (result == null)
                    {
                        return this.HLFLNotFoundCustom(ObjClass, null, _logger);
                    }
                    else
                    {
                        if (result.Cast<CreateCardModelOutPut>().ToList()[0].Status == 0)
                        {

                            //#region 23-08-2022

                            ////CreateCardModelOutPut ObjClass = new CreateCardModelOutPut();
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
                            //            if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                            //            {
                            //                GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                            //                getandInsertSendInputModel.CreatedBy = ObjClass.CreatedBy;//Added
                            //                getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                            //                string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                            //                TemplateMessage = TemplateMessage.Replace("", "");

                            //                getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");//database
                            //                getandInsertSendInputModel.MobileNo = "";//database
                            //                getandInsertSendInputModel.OfficerMobileNo = "";//database
                            //                getandInsertSendInputModel.HeaderTemplate = "";//database
                            //                getandInsertSendInputModel.Userip = null;
                            //                getandInsertSendInputModel.Userid = null;
                            //                getandInsertSendInputModel.Useragent = null;
                            //                getandInsertSendInputModel.SenderId = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SenderId;
                            //                getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSAPIURL;
                            //                await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);

                            //            }

                            //            if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailStatus == 1)
                            //            {
                            //                string ZOROEmaild = String.Empty; //database

                            //                InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                            //                insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                            //                insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                            //                insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                            //                insertEmailTextEntryInputModel.EmailIdTo = "";//database
                            //                insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                            //                insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                            //                insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                            //                string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                            //                //database
                            //                //if (result.Cast<MerchantInsertTerminalDeInstallationRequestAuthorizationModelOutput>().ToList()[0].EmailId == "")
                            //                //{
                            //                //    result.Cast<MerchantInsertTerminalDeInstallationRequestAuthorizationModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                            //                //}

                            //                EmailTemplateMessage = EmailTemplateMessage.Replace("", ""); // database

                            //                insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");
                            //                insertEmailTextEntryInputModel.CreatedBy = ObjClass.CreatedBy;//Added
                            //                await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
                            //            }
                            //        }
                            //    }
                            //}
                            //catch (Exception ex)
                            //{
                            //    _logger.LogError(ControllerContext.ActionDescriptor.ActionName + " :: Email and SMS Error :" + ex.Message);
                            //}


                            //#endregion



                            return this.TMFLOkCustom(ObjClass, result, _logger);
                        }
                        else
                        {
                            return this.TMFLFail(ObjClass, result, _logger);
                        }
                    }
                }
                else
                {
                    return this.TMFLFail(ObjClass, Validation, _logger);
                }

            }
        }

        [HttpPost]
        [ServiceFilter(typeof(TMFLAPIAuthenticationFilter))]
        [Route("GetConsumptionData")]
        public async Task<IActionResult> TMFLGetConsumptionData([FromBody] GetConsumptionDataModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.TMFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmfl.GetConsumptionData(ObjClass);
                if (result == null)
                {
                    return this.TMFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    //if (result.headerDetails.Count > 0 || result.transactionsDetails.Count > 0)
                    if (result.status == "0")
                    {
                        return this.TMFLOkCustom(ObjClass, result, _logger);
                    }
                    else
                        return this.TMFLFail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(TMFLAPIAuthenticationFilter))]
        [Route("GetCustomerBalance")]
        public async Task<IActionResult> TMFLGetCustomerBalance([FromBody] GetCustomerBalanceModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.TMFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmfl.GetCustomerBalance(ObjClass);
                if (result == null)
                {
                    return this.TMFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetCustomerBalanceModelOutPut>().ToList()[0].Status == 0)
                    {
                        return this.TMFLOkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.TMFLFail(ObjClass, result, _logger);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(TMFLAPIAuthenticationFilter))]
        [Route("UpdateCardLimit")]
        public async Task<IActionResult> TMFLCardLimit([FromBody] UpdateCardLimitModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.TMFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmfl.CardLimit(ObjClass);
                if (result == null)
                {
                    return this.TMFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateCardLimitModelOutPut>().ToList()[0].Status == 0)
                    {
                        return this.TMFLOkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.TMFLFail(ObjClass, result, _logger);
                    }
                }
            }
        }


        [HttpPost]
       // [ServiceFilter(typeof(TMFLAPIAuthenticationFilter))]
        [Route("LoyaltyRedeemRequest")]
        public async Task<IActionResult> TMFLLoyaltyRedeemRequest([FromBody] LoyaltyRedeemRequestModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.TMFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmfl.LoyaltyRedeemRequest(ObjClass);
                if (result == null)
                {
                    return this.TMFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<LoyaltyRedeemRequestModelOutPut>().ToList()[0].Status == 0)
                    {
                        return this.TMFLOkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.TMFLFail(ObjClass, result, _logger);
                    }
                }
            }
        }




        [HttpPost]
        [ServiceFilter(typeof(TMFLAPIAuthenticationFilter))]
        [Route("MapDriverMobile")]
        public async Task<IActionResult> TMFLMapDriverMobile([FromBody] MapDriverMobileModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.TMFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmfl.MapDriverMobile(ObjClass);
                if (result == null)
                {
                    return this.TMFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<MapDriverMobileModelOutPut>().ToList()[0].Status == 0)
                    {

                        //#region 23-08-2022


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
                        //            if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                        //            {
                        //                GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                        //                getandInsertSendInputModel.CreatedBy = ObjClass.CustomerID;//Added
                        //                getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                        //                string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                        //                TemplateMessage = TemplateMessage.Replace("", "");

                        //                getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");//database
                        //                getandInsertSendInputModel.MobileNo = "";//database
                        //                getandInsertSendInputModel.OfficerMobileNo = "";//database
                        //                getandInsertSendInputModel.HeaderTemplate = "";//database
                        //                getandInsertSendInputModel.Userip = null;
                        //                getandInsertSendInputModel.Userid = null;
                        //                getandInsertSendInputModel.Useragent = null;
                        //                getandInsertSendInputModel.SenderId = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SenderId;
                        //                getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSAPIURL;
                        //                await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);

                        //            }

                        //            if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailStatus == 1)
                        //            {
                        //                string ZOROEmaild = String.Empty; //database

                        //                InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                        //                insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                        //                insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                        //                insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                        //                insertEmailTextEntryInputModel.EmailIdTo = "";//database
                        //                insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                        //                insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                        //                insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                        //                string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                        //                //database
                        //                //if (result.Cast<MerchantInsertTerminalDeInstallationRequestAuthorizationModelOutput>().ToList()[0].EmailId == "")
                        //                //{
                        //                //    result.Cast<MerchantInsertTerminalDeInstallationRequestAuthorizationModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                        //                //}

                        //                EmailTemplateMessage = EmailTemplateMessage.Replace("", ""); // database

                        //                insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");
                        //                insertEmailTextEntryInputModel.CreatedBy = ObjClass.CustomerID;//Added
                        //                await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
                        //            }
                        //        }
                        //    }
                        //}
                        //catch (Exception ex)
                        //{
                        //    _logger.LogError(ControllerContext.ActionDescriptor.ActionName + " :: Email and SMS Error :" + ex.Message);
                        //}


                        //#endregion


                        return this.TMFLOkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.TMFLFail(ObjClass, result, _logger);
                    }
                }
            }
        }




        [HttpPost]
        [ServiceFilter(typeof(TMFLAPIAuthenticationFilter))]
        [Route("CheckCustomerStatus")]
        public async Task<IActionResult> TMFLCheckCustomerStatus([FromBody] CheckCustomerStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.TMFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmfl.CheckCustomerStatus(ObjClass);
                if (result == null)
                {
                    return this.TMFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CheckCustomerStatusModelOutPut>().ToList()[0].Status == 0)
                    {
                        return this.TMFLOkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.TMFLFail(ObjClass, result, _logger);
                    }
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(TMFLAPIAuthenticationFilter))]
        [Route("CheckCCMSRechargeStatus")]
        public async Task<IActionResult> TMFLCheckCCMSRechargeStatus([FromBody] CheckCCMSRechargeStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.TMFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmfl.CheckCCMSRechargeStatus(ObjClass);
                if (result == null)
                {
                    return this.TMFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CheckCCMSRechargeStatusModelOutPut>().ToList()[0].Status == 0)
                    {
                        return this.TMFLOkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.TMFLFail(ObjClass, result, _logger);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(TMFLAPIAuthenticationFilter))]
        [Route("ProcessCustomerRecharge")]
        public async Task<IActionResult> TMFLProcessCustomerRecharge([FromBody] ProcessCustomerRechargeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.TMFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmfl.ProcessCustomerRecharge(ObjClass);
                if (result == null)
                {
                    return this.TMFLNotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ProcessCustomerRechargeModelOutPut>().ToList()[0].Status == 0)
                    {
                        return this.TMFLOkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.TMFLFail(ObjClass, result, _logger);
                    }
                }
            }
        }


        [HttpPost]         
        //[Route("InsertTMFLRequestResponse")]
        public async Task<IActionResult> InsertTMFLRequestResponse([FromBody] HLFLInsertRequestResponseModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmfl.InsertTMFLRequestResponse(ObjClass);
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
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("CheckTMFLCustomerLimitStatus")]
        public async Task<IActionResult> CheckCustomerLimitStatus([FromBody] HLFLCheckLimitStatusModelInput ObjClass)
        {
            HLFLGetCustomerDetailsModelInput objDtls = new HLFLGetCustomerDetailsModelInput();
            objDtls.AggrCustomerID = ObjClass.AggrCustomerID;

            HLFLLimitStatusCheckModelInput userDetail = new HLFLLimitStatusCheckModelInput();

            var DtlResult = await _tmfl.USPGetTMFLCustomerDetails(objDtls);

           // userDetail.Authorization = _configuration.GetSection("TMFLSettings:TMFLAPIAuthorization").Value;
            userDetail.aggrID = "HPPay";
            userDetail.product = "Fuel";
            userDetail.aggrControlCardNumber = DtlResult.Cast<HLFLGetCustomerDetailsModelOutput>().ToList()[0].AggrControlCardNumber;
            userDetail.hlflcustomerID = DtlResult.Cast<HLFLGetCustomerDetailsModelOutput>().ToList()[0].HLFLCustomerId;
            userDetail.facilityNumber = DtlResult.Cast<HLFLGetCustomerDetailsModelOutput>().ToList()[0].FacilityNumber;
            userDetail.aggrCustomerID = DtlResult.Cast<HLFLGetCustomerDetailsModelOutput>().ToList()[0].AggrCustomerID;
            //userDetail.Source = "TMFL";

            var authIdPwd = _configuration.GetSection("TMFLSettings:TMFLAPIAuthorization").Value;
            HttpResponseMessage apiResponse = null;
            string responseapi = string.Empty;
            var urlStatuCheck = _configuration.GetSection("TMFLSettings:TMFLCheckLimitStatusAPIURL").Value;
            HLFLInsertRequestResponseModelInput ReqResponse = new HLFLInsertRequestResponseModelInput();
            ReqResponse.Request = JsonConvert.SerializeObject(userDetail);
            ReqResponse.APIUrl = urlStatuCheck;
            ReqResponse.APIName = "CheckCustomerLimitStatus";
            ReqResponse.AggrCustomerID = userDetail.aggrCustomerID;
            try
            {
                var InsertResult = _tmfl.InsertTMFLRequestResponse(ReqResponse).Result;
                if (InsertResult.Cast<HLFLInsertRequestResponseModel>().ToList()[0].Status == 0)
                {
                    apiResponse = Variables.CallAPI(urlStatuCheck, JsonConvert.SerializeObject(userDetail), authIdPwd).Result;
                    responseapi = apiResponse.Content.ReadAsStringAsync().Result;
                    HLFLCheckLimitStatusModelOutput results = new HLFLCheckLimitStatusModelOutput();
                    if (!string.IsNullOrEmpty(responseapi))
                    {
                        results = JsonConvert.DeserializeObject<HLFLCheckLimitStatusModelOutput>(responseapi);
                        ReqResponse.OrderId = InsertResult.Cast<HLFLInsertRequestResponseModel>().ToList()[0].OrderId;
                        ReqResponse.Response = results.Response;
                        ReqResponse.ResponseMessage = responseapi;
                        // Session["HLFLApiOrderId"]= ReqResponse.OrderId;
                        var res = _tmfl.InsertTMFLRequestResponse(ReqResponse).Result;
                        //----------------------------------------Calling Draw Down Request API Begin------------------------------------------------------------//
                         double EnterdAmount = 10.00;
                        // if (results.Status ==0 && results.responseMessage == "Succes" && Convert.ToDecimal(results.FacilityBalanceAmount) >= EnterdAmount)
                        if (1 == 1)
                        {
                            HLFLDDRequestModelInput DDRdtl = new HLFLDDRequestModelInput();
                            HLFLDDRequestModelOutput DDRresults = new HLFLDDRequestModelOutput();
                            DDRdtl.Authorization = _configuration.GetSection("TMFLSettings:TMFLAPIAuthorization").Value;
                            DDRdtl.AggrID = "HPPay";
                            DDRdtl.Source = "HPPay";
                            DDRdtl.Product = "Fuel";
                            DDRdtl.AggrRequestID = ReqResponse.OrderId;
                            DDRdtl.AggrControlCardNumber = userDetail.aggrControlCardNumber;
                            DDRdtl.HLFLCustomerID = userDetail.hlflcustomerID;
                            DDRdtl.HLFLFacilityNumber = userDetail.facilityNumber;
                            DDRdtl.AggrCustomerID = userDetail.aggrCustomerID;
                            DDRdtl.DDRequestDate = Convert.ToString(DateTime.Today);
                            DDRdtl.DDRequestAmount = EnterdAmount;
                            var urlDDReques = _configuration.GetSection("TMFLSettings:TMFLInitiateDrawDownRequestAPIURL").Value;

                            //-----------------------------------------save Request Begin-----------------------------------------------------//
                            ReqResponse.Request = JsonConvert.SerializeObject(DDRdtl);
                            ReqResponse.APIUrl = urlDDReques;
                            ReqResponse.APIName = "DrawDownRequest";
                            ReqResponse.AggrCustomerID = userDetail.aggrCustomerID;
                            ReqResponse.OrderId = InsertResult.Cast<HLFLInsertRequestResponseModel>().ToList()[0].OrderId;
                            ReqResponse.Response = null;
                            ReqResponse.ResponseMessage = null;
                            var resl = _tmfl.InsertTMFLRequestResponse(ReqResponse).Result;
                            //-----------------------------------------save Request End----------------------------------------------------//

                            apiResponse = Variables.CallAPI(urlDDReques, JsonConvert.SerializeObject(DDRdtl), authIdPwd).Result;
                            responseapi = apiResponse.Content.ReadAsStringAsync().Result;

                            DDRresults = JsonConvert.DeserializeObject<HLFLDDRequestModelOutput>(responseapi);
                            ReqResponse.Response = DDRresults.Response;
                            ReqResponse.OrderId = InsertResult.Cast<HLFLInsertRequestResponseModel>().ToList()[0].OrderId;
                            ReqResponse.ResponseMessage = responseapi;
                            //-----------------------------------------save Response Begin-----------------------------------------------------//
                            var reslt = _tmfl.InsertTMFLRequestResponse(ReqResponse).Result;
                        }
                        //--------------------------------------------Calling Draw Down Request API ENd--------------------------------------------------------//
                        if (results.hlflStatusCode == 0)
                        {
                            return this.HLFLOkCustom(ObjClass, results, _logger);
                        }
                        else
                        {
                            return this.HLFLFail(ObjClass, results, _logger);
                            // result.Cast<HLFLInsertRequestResponseModel>().ToList()[0].responseMessage);
                        }
                    }

                }
                else
                {
                    return this.HLFLFail(ObjClass, InsertResult, _logger);
                }
            }
            catch (Exception ex)
            {
                responseapi = ex.Message;

            }
            return null;
        }


        [HttpPost]
        [Route("InsertTMFLRechargeRequestDetails")]
        public async Task<IActionResult> InsertTMFLRechargeRequestDetails([FromBody] HLFLValidateOTPModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var authIdPwd = _configuration.GetSection("TMFLSettings:TMFLAPIAuthorization").Value;
                HttpResponseMessage apiResponse = null;
                string responseapi = string.Empty;
                var urlOTPValidateCheck = _configuration.GetSection("TMFLSettings:TMFLDrawDownOTPValidateAPIURL").Value;
                HLFLInsertRequestResponseModelInput ReqResponse = new HLFLInsertRequestResponseModelInput();
                ReqResponse.Request = JsonConvert.SerializeObject(ObjClass);
                ReqResponse.APIUrl = urlOTPValidateCheck;
                ReqResponse.APIName = "OTPValidationAndTransaction";
                ReqResponse.AggrCustomerID = ObjClass.AggrCustomerID;
                ReqResponse.OrderId = ObjClass.AggrRequestID;

                var res = _tmfl.InsertTMFLRequestResponse(ReqResponse).Result;
                //---------------------------------------------------------------------------------------------------------------//                
                apiResponse = Variables.CallAPI(urlOTPValidateCheck, JsonConvert.SerializeObject(ObjClass), authIdPwd).Result;
                responseapi = apiResponse.Content.ReadAsStringAsync().Result;
                HLFLValidateOTPOutput OTPResult = new HLFLValidateOTPOutput();
                OTPResult = JsonConvert.DeserializeObject<HLFLValidateOTPOutput>(responseapi);
                ReqResponse.Response = "";
                ReqResponse.OrderId = ObjClass.AggrRequestID;
                ReqResponse.ResponseMessage = responseapi;

                var reslt = _tmfl.InsertTMFLRequestResponse(ReqResponse).Result;
                //-----------------------------------------save Response Begin-----------------------------------------------------//

                if (OTPResult.hlflStatusCode == "0" && OTPResult.hlflStatusRemark == "Success")
                {
                    decimal DDRequestAmount = Convert.ToDecimal(1023.00);
                    var result = await _tmfl.InsertTMFLRechargeRequestDetails(ObjClass, DDRequestAmount);

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
                            // result.Cast<HLFLInsertRequestResponseModel>().ToList()[0].responseMessage);
                        }
                    }
                }
            }
            return null;
        }


        [HttpPost]
        [Route("ResendOTPTMFL")]
        public async Task<IActionResult> TMFLResendOTP([FromBody] HLFLResendOTPInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.HLFLBadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var authIdPwd = _configuration.GetSection("TMFLSettings:TMFLAPIAuthorization").Value;
                HttpResponseMessage apiResponse = null;
                string responseapi = string.Empty;
                var urlResendOTP = _configuration.GetSection("TMFLSettings:TMFLResendOTPAPIURL").Value;
                HLFLInsertRequestResponseModelInput ReqResponse = new HLFLInsertRequestResponseModelInput();
                ReqResponse.Request = JsonConvert.SerializeObject(ObjClass);
                ReqResponse.APIUrl = urlResendOTP;
                ReqResponse.APIName = "TMFLResendOTP";
                ReqResponse.AggrCustomerID = ObjClass.AggrCustomerID;
                ReqResponse.OrderId = ObjClass.AggrRequestID;

                var res = _tmfl.InsertTMFLRequestResponse(ReqResponse).Result;
                //---------------------------------------------------------------------------------------------------------------//                
                apiResponse = Variables.CallAPI(urlResendOTP, JsonConvert.SerializeObject(ObjClass), authIdPwd).Result;
                responseapi = apiResponse.Content.ReadAsStringAsync().Result;
                HLFLResendOTPOutput OTPResult = new HLFLResendOTPOutput();
                OTPResult = JsonConvert.DeserializeObject<HLFLResendOTPOutput>(responseapi);
                ReqResponse.Response = null;
                ReqResponse.OrderId = ObjClass.AggrRequestID;
                ReqResponse.ResponseMessage = responseapi;

                var reslt = _tmfl.InsertTMFLRequestResponse(ReqResponse).Result;

            }
            return null;
        }
    }
}
