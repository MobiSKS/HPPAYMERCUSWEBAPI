using HPPay.DataModel.Settings;
using HPPay.DataRepository.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using HPPay_WebApi.ExtensionMethod;
using HPPay_WebApi.ActionFilters;
using System.Collections.Generic;
using System.Linq;
using HPPay.DataRepository.SMSGetSend;
using HPPay.DataModel.SMSGetSend;
using System;
using HPPay.DataModel.STFC;
using HPPay.DataModel.M2PExternal;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Hosting;
using HPPay.DataRepository.STFC;
using HPPay.DataRepository.M2PExternal;
using Microsoft.Extensions.Configuration;
using HPPay.DataModel.Transaction;
using HPPay.DataRepository.Transaction;

namespace HPPay_WebApi.Controllers
{

    [ApiController]
    [Route("/api/hppay/settings")]
    public class SettingsController : ControllerBase
    {
        private readonly ILogger<SettingsController> _logger;

        private readonly ISettingsRepository _settingRepo;
        private readonly ISMSGetSendRepository _GetSendRepo;
        private readonly IConfiguration _configuration;

        private readonly IStfcApiRepository _stfcRepo;
        public ILogger<STFCController> _stfclogger;

        private readonly ITransactionRepository _transRepo;
        public ILogger<TransactionController> _txnlogger;
        //ISMSGetSendRepository GetSendRepo

        private readonly IM2PExternalRepository _M2PRepo;
        public ILogger<M2PExternalController> _M2plogger;
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public SettingsController(ILogger<SettingsController> logger, ILogger<STFCController> stfclogger, ILogger<M2PExternalController> M2plogger, ILogger<TransactionController> txnlogger, DapperContext context, IHostingEnvironment hostingEnvironment, ISettingsRepository settingRepo, ISMSGetSendRepository GetSendRepo, IConfiguration configuration)
        {
            _logger = logger;
            _settingRepo = settingRepo;
            _GetSendRepo = GetSendRepo;
            _M2plogger = M2plogger;
            _stfclogger = stfclogger;
            _context = context;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _txnlogger = txnlogger;
            _M2PRepo = new M2PExternalRepository(_context, _hostingEnvironment, _configuration);
            _stfcRepo = new StfcApiRepository(_context, _hostingEnvironment, _configuration);
            _transRepo = new TransactionRepository(_context, _configuration);
            _GetSendRepo = new SMSGetSendRepository(_context, _configuration);
        }





        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("credit_sale")]
        public async Task<IActionResult> CreditLimitSale([FromBody] TransactionSalebyTerminalModelInput objClass)
        {
            if (objClass == null)
            {
                return this.BadRequestCustom(objClass, null, _logger);
            }
            else
            {
                List<CreditLimitAuthorizationAPIOutput> lst = new List<CreditLimitAuthorizationAPIOutput>();
                CreditLimitAuthorizationAPIOutput result = new CreditLimitAuthorizationAPIOutput();
                int StatusValue = 0;
                string CardNo = string.Empty;
                if (!string.IsNullOrEmpty(objClass.Cardno))
                {
                    CardNo = _transRepo.PlainCardNoAsync(objClass.Cardno, objClass.Terminalid, out StatusValue);
                }

                var objgetCustomer = _stfcRepo.GetCustomerIdByCardForExternalAPI(CardNo, objClass.Mobileno).Result;

                string CustomerId = string.Empty;
                if (objgetCustomer == null || objgetCustomer.Count() == 0)
                {


                    result.ResMsg = "Customer Not Exist for card";
                    result.ResCode = "0";
                    // result.ErrorReason = objgetCustomer.Cast<GetStfcCustomerIdByCardOutput>().ToList()[0].Reason;
                    result.Reason = "Customer Not Exist for card";


                    lst.Add(result);
                    return this.FailCustom(objClass, lst, _logger, "");
                }
                else
                {
                    string SourceName = objgetCustomer.Cast<GetCustomerIdByCardForExternalAPIOutput>().ToList()[0].SourceName ?? string.Empty;
                    string SourceCustomerId = objgetCustomer.Cast<GetCustomerIdByCardForExternalAPIOutput>().ToList()[0].SourceCustomerId ?? string.Empty;
                    if (SourceName.ToString().ToUpper() == "STFC")
                    {
                        if (StatusValue == 1)
                            objClass.Cardno = CardNo;
                        List<STFCConfirmPaymentResponse> stfclst = new List<STFCConfirmPaymentResponse>();
                        objClass.Paymentmode = "3";
                        objClass.Bankname = "STFC";

                        var res = new STFCController(_stfclogger, _stfcRepo, _transRepo, _configuration).StfcCreditLimitAuthorizationAPI(objClass);

                        stfclst.Add(res);
                        if (res.ResCode == "700")
                        {
                            return this.OkCustom(objClass, stfclst, _logger);
                        }
                        else
                        {
                            return this.FailCustom(objClass, stfclst, _logger, "");
                        }
                    }
                    else if (SourceName.ToString().ToUpper() == "M2P")
                    {
                        objClass.Paymentmode = "5";
                        objClass.Bankname = "M2P";
                        if (StatusValue == 1)
                            objClass.Cardno = CardNo;
                        List<M2PConfirmPaymentResponse> m2plst = new List<M2PConfirmPaymentResponse>();
                        // M2PEntityCheckAPIRequestModelInput objCls = new M2PEntityCheckAPIRequestModelInput();

                        var res = new M2PExternalController(_M2plogger, _M2PRepo, _transRepo, _configuration).M2PCreditLimitAuthorizationAPI(objClass, SourceCustomerId);

                        m2plst.Add(res);
                        if (res.ResCode == "700")
                        {
                            return this.OkCustom(objClass, m2plst, _logger);
                        }
                        else
                        {
                            return this.FailCustom(objClass, m2plst, _logger, "");
                        }
                    }
                    else if (SourceName.ToString().ToUpper() == "SFL")
                    {
                        objClass.Paymentmode = "4";
                        objClass.Bankname = "SFL";

                        var res = new TransactionController(_txnlogger, _transRepo, _configuration, _GetSendRepo).SaleSFL(objClass);

                        if (res == null)
                        {
                            return this.FailCustom(objClass, res, _logger, "");
                        }
                        else
                        {
                            if (res[0].Status == 1)
                            {

                                return this.OkCustom(objClass, res, _logger);
                            }
                            else
                            {
                                return this.FailCustom(objClass, res, _logger,
                                    res[0].Reason);
                            }


                        }
                    }
                    else
                    {
                        result.ResMsg = objgetCustomer.Cast<GetCustomerIdByCardForExternalAPIOutput>().ToList()[0].Reason ?? String.Empty;
                        result.ResCode = "0";
                        result.Reason = objgetCustomer.Cast<GetCustomerIdByCardForExternalAPIOutput>().ToList()[0].Reason ?? String.Empty;
                        lst.Add(result);
                        return this.FailCustom(objClass, lst, _logger, "");
                    }
                }

            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_sales_area")]
        public async Task<IActionResult> GetSalesarea([FromBody] SettingGetSalesareaModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _settingRepo.GetSalesarea(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<SettingGetSalesareaModelOutput> item = result.Cast<SettingGetSalesareaModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_sales_area_by_multiple_region")]
        public async Task<IActionResult> GetSalesAreaByMultipleRegion([FromBody] SettingGetSalesAreaByMultipleRegionModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _settingRepo.GetSalesAreaByMultipleRegion(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<SettingGetSalesareaModelOutput> item = result.Cast<SettingGetSalesareaModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_transaction_type")]
        public async Task<IActionResult> GetTransactionType([FromBody] SettingGetTransactionTypeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _settingRepo.GetTransactionType(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<SettingGetTransactionTypeModelOutput> item = result.Cast<SettingGetTransactionTypeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_role")]
        public async Task<IActionResult> GetRole([FromBody] SettingGetRoleModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _settingRepo.GetRole(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<SettingGetRoleModelOutput> item = result.Cast<SettingGetRoleModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_product")]
        public async Task<IActionResult> GetProduct([FromBody] SettingGetProductModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _settingRepo.GetProduct(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<SettingGetProductModelOutput> item = result.Cast<SettingGetProductModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_entity")]
        public async Task<IActionResult> GetEntity([FromBody] SettingGetEntityModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _settingRepo.GetEntity(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<SettingGetEntityModelOutput> item = result.Cast<SettingGetEntityModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_entity_status_type")]
        public async Task<IActionResult> GetEntityStatusType([FromBody] SettingGetEntityTypesModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _settingRepo.GetEntityStatusType(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<SettingGetEntityTypesModelOutput> item = result.Cast<SettingGetEntityTypesModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))] -- As per prelogin method, ServiceFilter is comment
        [Route("get_proof_type")]
        public async Task<IActionResult> GetProofType([FromBody] SettingGetProofTypeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _settingRepo.GetProofType(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<SettingGetProofTypeModelOutput> item = result.Cast<SettingGetProofTypeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_tier")]
        public async Task<IActionResult> GetTier([FromBody] SettingGetTierModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _settingRepo.GetTier(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<SettingGetTierModelOutput> item = result.Cast<SettingGetTierModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_record_type")]
        public async Task<IActionResult> GetRecordType([FromBody] SettingGetRecordTypeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _settingRepo.GetRecordType(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<SettingGetRecordTypeModelOutput> item = result.Cast<SettingGetRecordTypeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_status_types_for_terminal")]
        public async Task<IActionResult> GetStatusTypesForTerminal([FromBody] GetStatusTypesForTerminalModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _settingRepo.GetStatusTypesForTerminal(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetStatusTypesForTerminalModelOutput> item = result.Cast<GetStatusTypesForTerminalModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_cp_statusName")]
        public async Task<IActionResult> GetCreditPouchStatus([FromBody] GetCPStatuModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _settingRepo.GetCreditPouchStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCPStatuModelOutPut> item = result.Cast<GetCPStatuModelOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("change_password")]
        public async Task<IActionResult> ChangePassword([FromBody] SettingChangePasswordModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _settingRepo.ChangePassword(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    if (result.Cast<SettingChangePasswordModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("forgot_password")]
        public async Task<IActionResult> ForgotPassword([FromBody] SettingForgetPasswordModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _settingRepo.ForgetPassword(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<SettingForgetPasswordModelOutput>().ToList()[0].Status == 1)
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

                                        TemplateMessage = TemplateMessage.Replace("@UserName", ObjClass.UserName).Replace("@NewPassword",
                                            result.Cast<SettingForgetPasswordModelOutput>().ToList()[0].Password);


                                        getandInsertSendInputModel.SMSText = TemplateMessage;
                                        getandInsertSendInputModel.MobileNo = result.Cast<SettingForgetPasswordModelOutput>().ToList()[0].MobileNo;
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
                                        string ZOROEmaild = String.Empty;
                                        InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                        insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                                        insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                                        insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                                        insertEmailTextEntryInputModel.EmailIdTo = result.Cast<SettingForgetPasswordModelOutput>().ToList()[0].Email;
                                        insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                        insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                        insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                        string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                        if (ObjClass.EmailId == "")
                                        {
                                            ObjClass.EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                        }

                                        EmailTemplateMessage = EmailTemplateMessage.Replace("@UserName", ObjClass.UserName).Replace("@NewPassword",
                                            result.Cast<SettingForgetPasswordModelOutput>().ToList()[0].Password).Replace("@Name", result.Cast<SettingForgetPasswordModelOutput>().ToList()[0].Name);

                                        insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
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
                        return this.OkCustom(ObjClass, result, _logger);
                    }

                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<SettingForgetPasswordModelOutput>().ToList()[0].Reason);
                    }

                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_mobile_no_and_emailid")]
        public async Task<IActionResult> UpdateMobileNoAndEmailId([FromBody] SettingUpdateMobileNoAndEmailIdModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _settingRepo.UpdateMobileNoAndEmailId(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {

                    if (result.Cast<SettingUpdateMobileNoAndEmailIdModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

    

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_loyalty_rewarding_statement")]
        public async Task<IActionResult> GetLoyaltyRewardingStatement([FromBody] LoyaltyRewardingStatementModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _settingRepo.GetLoyaltyRewardingStatement(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<LoyaltyRewardingStatementModelOutput> item = result.Cast<LoyaltyRewardingStatementModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_proof_types_master")]
        public async Task<IActionResult> GetProofTypesMaster([FromBody] SettingGetProofTypesMasterModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _settingRepo.GetProofTypesMaster(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<SettingGetProofTypesMasterModelOutput> item = result.Cast<SettingGetProofTypesMasterModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_enrollment_type_master")]
        public async Task<IActionResult> GetEnrollmentTypeMaster([FromBody] SettingGetEnrollmentTypeMasterModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _settingRepo.GetEnrollmentTypeMaster(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<SettingGetEnrollmentTypeMasterModelOutput> item = result.Cast<SettingGetEnrollmentTypeMasterModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

    }
}



