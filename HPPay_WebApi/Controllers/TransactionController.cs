using AtallaHSM;
using AtallaHSM.Model;
using HPPay.DataModel.PayCode;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataModel.Transaction;
using HPPay.DataRepository.SMSGetSend;
using HPPay.DataRepository.Transaction;
using HPPay.Infrastructure.CommonClass;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AtallaHSM.Common.LoggerUtility;

namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/hppay/transaction")]

    //int i = 0;
    //while (i == 0)
    //{
    //    i = 0;
    //}
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ITransactionRepository _transRepo;
        private static string MFKAKB;
        private static string DEKAKB;
        private static string KEKAKB;
        private static string PMKAKB;
        private static string HSMIP;
        private static string HSMPORT;
        private readonly ISMSGetSendRepository _GetSendRepo;

        public TransactionController(ILogger<TransactionController> logger, ITransactionRepository transRepo, IConfiguration configuration
            , ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _transRepo = transRepo;
            _configuration = configuration;
            MFKAKB = _configuration.GetSection("HSMAppSettings:MFKAKB").Value.ToString();
            DEKAKB = _configuration.GetSection("HSMAppSettings:DEKAKB").Value.ToString();
            KEKAKB = _configuration.GetSection("HSMAppSettings:KEKAKB").Value.ToString();
            PMKAKB = _configuration.GetSection("HSMAppSettings:PMKAKB").Value.ToString();
            HSMIP = _configuration.GetSection("HSMAppSettings:HSMIP").Value.ToString();
            HSMPORT = _configuration.GetSection("HSMAppSettings:HSMPORT").Value.ToString();
            _GetSendRepo = GetSendRepo;
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("sale_sfl")]
        public List<TransactionSalebyTerminalModelOutput> SaleSFL([FromBody] TransactionSalebyTerminalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return new List<TransactionSalebyTerminalModelOutput>();
            }
            else
            {
                var result = _transRepo.SaleByTerminal(ObjClass).Result;
                if (result == null)
                {
                    return new List<TransactionSalebyTerminalModelOutput>();
                }
                else
                {
                    return result.Cast<TransactionSalebyTerminalModelOutput>().ToList();
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("sale_by_terminal")]
        public async Task<IActionResult> SaleByTerminal([FromBody] TransactionSalebyTerminalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.SaleByTerminal(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].Status == 1)
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
                                        getandInsertSendInputModel.CreatedBy = ObjClass.CreatedBy;
                                        getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                        string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                        if (ObjClass.Transtype == "501")
                                        {

                                            TemplateMessage = TemplateMessage.Replace("[@ServiceName]",
                                                result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].ProductName.ToString()).Replace("[@TransactionAmount]",
                                                ObjClass.Invoiceamount.ToString()).Replace("[@VehicleNumber]",
                                                result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].VechileNo.ToString()).Replace("[@TransactionDate]",
                                                ObjClass.Invoicedate.ToString()).Replace("[@OutLetName]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].RetailOutletName).
                                                Replace("[@MerchantLocation]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].Address).Replace("[@LimitType]",
                                                result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].LimitType).
                                                Replace("[@CCMSLimit]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].CCMSLimit).
                                                Replace("[@CurrentCardBalance]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].CurrentCardBalance.ToString()).
                                                Replace("[@CurrentCCMSBalance]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].CurrentCCMSBalance.ToString()).
                                                Replace("[@RawTransactionId]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].APIReferenceNo.ToString());

                                            getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");
                                            getandInsertSendInputModel.MobileNo = result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].GetMultipleMobileNo; ;
                                            getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo;
                                            getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateName;
                                            getandInsertSendInputModel.Userip = ObjClass.Userip;
                                            getandInsertSendInputModel.Userid = ObjClass.Userid;
                                            getandInsertSendInputModel.Useragent = ObjClass.Useragent;
                                            getandInsertSendInputModel.SenderId = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SenderId;
                                            getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSAPIURL;
                                            await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);
                                        }


                                        if (ObjClass.Transtype == "502")
                                        {

                                            TemplateMessage = TemplateMessage.Replace("[@ServiceName]",
                                                result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].ProductName.ToString()).Replace("[@TransactionAmount]",
                                                ObjClass.Invoiceamount.ToString()).Replace("[@VehicleNumber]",
                                                result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].VechileNo.ToString()).Replace("[@TransactionDate]",
                                                ObjClass.Invoicedate.ToString()).Replace("[@OutLetName]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].RetailOutletName).
                                                Replace("[@MerchantLocation]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].Address).Replace("[@LimitType]",
                                                result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].LimitType).
                                                Replace("[@CCMSLimit]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].CCMSLimit).
                                                Replace("[@CurrentCardBalance]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].CurrentCardBalance.ToString()).
                                                Replace("[@CurrentCCMSBalance]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].CurrentCCMSBalance.ToString()).
                                                Replace("[@RawTransactionId]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].APIReferenceNo.ToString()).
                                                Replace("[@CardPAN]", ObjClass.Cardno).
                                                Replace("[@TxnDate]", ObjClass.Invoicedate.ToString("D").
                                                Replace("[@TxnTime]", ObjClass.Invoicedate.ToString("t")));

                                            getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");
                                            getandInsertSendInputModel.MobileNo = result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].GetMultipleMobileNo; ;
                                            getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo;
                                            getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateName;
                                            getandInsertSendInputModel.Userip = ObjClass.Userip;
                                            getandInsertSendInputModel.Userid = ObjClass.Userid;
                                            getandInsertSendInputModel.Useragent = ObjClass.Useragent;
                                            getandInsertSendInputModel.SenderId = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SenderId;
                                            getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSAPIURL;
                                            await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);
                                        }

                                        if (ObjClass.Transtype == "503")
                                        {

                                            TemplateMessage = TemplateMessage.Replace("[@ServiceName]",
                                                result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].ProductName.ToString()).Replace("[@TransactionAmount]",
                                                ObjClass.Invoiceamount.ToString()).Replace("[@VehicleNumber]",
                                                result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].VechileNo.ToString()).Replace("[@TransactionDate]",
                                                ObjClass.Invoicedate.ToString()).Replace("[@OutLetName]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].RetailOutletName).
                                                Replace("[@MerchantLocation]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].Address).Replace("[@LimitType]",
                                                result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].LimitType).
                                                Replace("[@CCMSLimit]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].CCMSLimit).
                                                Replace("[@CurrentCardBalance]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].CurrentCardBalance.ToString()).
                                                Replace("[@CurrentCCMSBalance]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].CurrentCCMSBalance.ToString()).
                                                Replace("[@RawTransactionId]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].APIReferenceNo.ToString()).
                                                Replace("[@TransactionBalance]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].CurrentCardBalance.ToString());

                                            getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");
                                            getandInsertSendInputModel.MobileNo = result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].GetMultipleMobileNo; ;
                                            getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo;
                                            getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateName;
                                            getandInsertSendInputModel.Userip = ObjClass.Userip;
                                            getandInsertSendInputModel.Userid = ObjClass.Userid;
                                            getandInsertSendInputModel.Useragent = ObjClass.Useragent;
                                            getandInsertSendInputModel.SenderId = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SenderId;
                                            getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSAPIURL;
                                            await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);
                                        }

                                        if (ObjClass.Transtype == "504")
                                        {

                                            TemplateMessage = TemplateMessage.Replace("[@ServiceName]",
                                                result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].ProductName.ToString()).Replace("[@TransactionAmount]",
                                                ObjClass.Invoiceamount.ToString()).Replace("[@VehicleNumber]",
                                                result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].VechileNo.ToString()).Replace("[@TransactionDate]",
                                                ObjClass.Invoicedate.ToString()).Replace("[@OutLetName]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].RetailOutletName).
                                                Replace("[@MerchantLocation]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].Address).Replace("[@LimitType]",
                                                result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].LimitType).
                                                Replace("[@CCMSLimit]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].CCMSLimit).
                                                Replace("[@CurrentCardBalance]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].CurrentCardBalance.ToString()).
                                                Replace("[@CurrentCCMSBalance]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].CurrentCCMSBalance.ToString()).
                                                Replace("[@RawTransactionId]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].APIReferenceNo.ToString()).
                                                Replace("[@CardPAN]", ObjClass.Cardno).
                                                Replace("[@TxnDate]", ObjClass.Invoicedate.ToString("D").
                                                Replace("[@TxnTime]", ObjClass.Invoicedate.ToString("t")).
                                                Replace("[@TransactionBalance]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].Balance.ToString()));

                                            getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");
                                            getandInsertSendInputModel.MobileNo = result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].GetMultipleMobileNo; ;
                                            getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo;
                                            getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateName;
                                            getandInsertSendInputModel.Userip = ObjClass.Userip;
                                            getandInsertSendInputModel.Userid = ObjClass.Userid;
                                            getandInsertSendInputModel.Useragent = ObjClass.Useragent;
                                            getandInsertSendInputModel.SenderId = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SenderId;
                                            getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSAPIURL;
                                            await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);
                                        }

                                        if (ObjClass.Transtype == "522")
                                        {

                                            TemplateMessage = TemplateMessage.Replace("[@ServiceName]",
                                                result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].ProductName.ToString()).Replace("[@TransactionAmount]",
                                                ObjClass.Invoiceamount.ToString()).Replace("[@VehicleNumber]",
                                                result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].VechileNo.ToString()).Replace("[@TransactionDate]",
                                                ObjClass.Invoicedate.ToString()).Replace("[@OutLetName]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].RetailOutletName).
                                                Replace("[@MerchantLocation]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].Address).Replace("[@LimitType]",
                                                result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].LimitType).
                                                Replace("[@CCMSLimit]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].CCMSLimit).
                                                Replace("[@CurrentCardBalance]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].CurrentCardBalance.ToString()).
                                                Replace("[@CurrentCCMSBalance]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].CurrentCCMSBalance.ToString()).
                                                Replace("[@RawTransactionId]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].APIReferenceNo.ToString()).
                                                Replace("[@CardPAN]", ObjClass.Cardno).
                                                Replace("[@TxnDate]", ObjClass.Invoicedate.ToString("D").
                                                Replace("[@TxnTime]", ObjClass.Invoicedate.ToString("t")).
                                                Replace("[@TransactionBalance]", result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].Balance.ToString()).
                                                Replace("[@MerchantCode]", ObjClass.Merchantid));

                                            getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");
                                            getandInsertSendInputModel.MobileNo = result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].GetMultipleMobileNo; ;
                                            getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo;
                                            getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateName;
                                            getandInsertSendInputModel.Userip = ObjClass.Userip;
                                            getandInsertSendInputModel.Userid = ObjClass.Userid;
                                            getandInsertSendInputModel.Useragent = ObjClass.Useragent;
                                            getandInsertSendInputModel.SenderId = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SenderId;
                                            getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSAPIURL;
                                            await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);
                                        }



                                    }

                                    if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailStatus == 1)
                                    {
                                        string ZOROEmaild = String.Empty;
                                        InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                        insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                                        insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                                        insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                                        insertEmailTextEntryInputModel.EmailIdTo = "";
                                        insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                        insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                        insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                        string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;
                                        EmailTemplateMessage = EmailTemplateMessage.Replace("@OutletName",
                                           result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].RetailOutletName.ToString()).Replace("@VehicleNumber",
                                           result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].VechileNo.ToString()).Replace("@Amount",
                                           ObjClass.Invoiceamount.ToString());
                                        insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");
                                        insertEmailTextEntryInputModel.CreatedBy = ObjClass.CreatedBy;
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
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("recharge_ccms_account")]
        public async Task<IActionResult> RechargeCCMSAccount([FromBody] RechargeCCMSAccountModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.RechargeCCMSAccount(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<RechargeCCMSAccountModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<RechargeCCMSAccountModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        #region Comment Code
        //[HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        //[Route("get_batch_no")]
        //public async Task<IActionResult> GetBatchno([FromBody] GetBatchnoModelInput ObjClass)
        //{
        //    if (ObjClass == null)
        //    {
        //        return this.BadRequestCustom(ObjClass, null, _logger);
        //    }
        //    else
        //    {
        //        var result = await _transRepo.GetBatchno(ObjClass);
        //        if (result == null)
        //        {
        //            return this.NotFoundCustom(ObjClass, null, _logger);
        //        }
        //        else
        //        {
        //            if (result.Cast<GetBatchnoModelOutput>().ToList()[0].Status == 1)
        //            {
        //                return this.OkCustom(ObjClass, result, _logger);
        //            }
        //            else
        //            {
        //                return this.FailCustom(ObjClass, result, _logger,
        //                    result.Cast<GetBatchnoModelOutput>().ToList()[0].Reason);
        //            }
        //        }
        //    }
        //}

        #endregion

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("batch_settlement")]
        public async Task<IActionResult> BatchSettlement([FromBody] TransactionBatchSettlementModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.BatchSettlement(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionBatchSettlementModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TransactionBatchSettlementModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("balance_transfer")]
        public async Task<IActionResult> BalanceTransfer([FromBody] TransactionBalanceTransferModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.BalanceTransfer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionBalanceTransferModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TransactionBalanceTransferModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("generate_otp")]
        public async Task<IActionResult> GenerateOTP([FromBody] TransactionGenerateOTPModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.GenerateOTP(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionGenerateOTPModelOutput>().ToList()[0].Status == 1)
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

                                    if (ObjClass.TransTypeId == 514 || ObjClass.TransTypeId == 516)
                                    {
                                        if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSEmailStatus == "0")
                                        {
                                            if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                                            {
                                                GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                                                getandInsertSendInputModel.CreatedBy = ObjClass.CreatedBy;
                                                getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                                string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                                TemplateMessage = TemplateMessage.Replace("@OTP",
                                                    result.Cast<TransactionGenerateOTPModelOutput>().ToList()[0].OTP.ToString()).Replace("@OutletName",
                                                    result.Cast<TransactionGenerateOTPModelOutput>().ToList()[0].RetailOutletName.ToString()).Replace("@VehicleNumber",
                                                    result.Cast<TransactionGenerateOTPModelOutput>().ToList()[0].VechileNo.ToString()).Replace("@Amount",
                                                    ObjClass.Invoiceamount.ToString());

                                                getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");
                                                getandInsertSendInputModel.MobileNo = result.Cast<TransactionGenerateOTPModelOutput>().ToList()[0].MobileNo.ToString();
                                                getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo;
                                                getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateName;
                                                getandInsertSendInputModel.Userip = ObjClass.Userip;
                                                getandInsertSendInputModel.Userid = ObjClass.Userid;
                                                getandInsertSendInputModel.Useragent = ObjClass.Useragent;
                                                getandInsertSendInputModel.SenderId = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SenderId;
                                                getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSAPIURL;
                                                await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);

                                            }
                                        }
                                    }
                                    else if (ObjClass.TransTypeId == 522)
                                    {
                                        if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSEmailStatus == "2")
                                        {
                                            if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                                            {
                                                GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                                                getandInsertSendInputModel.CreatedBy = ObjClass.CreatedBy;
                                                getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                                string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                                TemplateMessage = TemplateMessage.Replace("@OTP",
                                                    result.Cast<TransactionGenerateOTPModelOutput>().ToList()[0].OTP.ToString()).Replace("@OutletName",
                                                    result.Cast<TransactionGenerateOTPModelOutput>().ToList()[0].RetailOutletName.ToString()).Replace("@VehicleNumber",
                                                    result.Cast<TransactionGenerateOTPModelOutput>().ToList()[0].VechileNo.ToString()).Replace("@Amount",
                                                    ObjClass.Invoiceamount.ToString());

                                                getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");
                                                getandInsertSendInputModel.MobileNo = result.Cast<TransactionGenerateOTPModelOutput>().ToList()[0].MobileNo.ToString();
                                                getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo;
                                                getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateName;
                                                getandInsertSendInputModel.Userip = ObjClass.Userip;
                                                getandInsertSendInputModel.Userid = ObjClass.Userid;
                                                getandInsertSendInputModel.Useragent = ObjClass.Useragent;
                                                getandInsertSendInputModel.SenderId = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SenderId;
                                                getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSAPIURL;
                                                await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);

                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSEmailStatus == "1")
                                        {
                                            if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                                            {
                                                GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                                                getandInsertSendInputModel.CreatedBy = ObjClass.CreatedBy;
                                                getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                                string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                                TemplateMessage = TemplateMessage.Replace("@OTP",
                                                    result.Cast<TransactionGenerateOTPModelOutput>().ToList()[0].OTP.ToString()).Replace("@OutletName",
                                                    result.Cast<TransactionGenerateOTPModelOutput>().ToList()[0].RetailOutletName.ToString()).Replace("@VehicleNumber",
                                                    result.Cast<TransactionGenerateOTPModelOutput>().ToList()[0].VechileNo.ToString()).Replace("@Amount",
                                                    ObjClass.Invoiceamount.ToString());

                                                getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");
                                                getandInsertSendInputModel.MobileNo = result.Cast<TransactionGenerateOTPModelOutput>().ToList()[0].MobileNo.ToString();
                                                getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo;
                                                getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateName;
                                                getandInsertSendInputModel.Userip = ObjClass.Userip;
                                                getandInsertSendInputModel.Userid = ObjClass.Userid;
                                                getandInsertSendInputModel.Useragent = ObjClass.Useragent;
                                                getandInsertSendInputModel.SenderId = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SenderId;
                                                getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSAPIURL;
                                                await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);

                                            }
                                        }
                                    }


                                    if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailStatus == 1)
                                    {
                                        string ZOROEmaild = String.Empty;
                                        InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                        insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                                        insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                                        insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                                        insertEmailTextEntryInputModel.EmailIdTo = "";
                                        insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                        insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                        insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                        string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;
                                        EmailTemplateMessage = EmailTemplateMessage.Replace("@OTP",
                                           result.Cast<TransactionGenerateOTPModelOutput>().ToList()[0].OTP.ToString()).Replace("@OutletName",
                                           result.Cast<TransactionGenerateOTPModelOutput>().ToList()[0].RetailOutletName.ToString()).Replace("@VehicleNumber",
                                           result.Cast<TransactionGenerateOTPModelOutput>().ToList()[0].VechileNo.ToString()).Replace("@Amount",
                                           ObjClass.Invoiceamount.ToString());
                                        insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");
                                        insertEmailTextEntryInputModel.CreatedBy = ObjClass.CreatedBy;
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
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TransactionGenerateOTPModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("card_fee_payment")]
        public async Task<IActionResult> CardFeePayment([FromBody] TransactionCardFeePaymentModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.CardFeePayment(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionCardFeePaymentModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TransactionCardFeePaymentModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_transcations_for_batch_settlement")]
        public async Task<IActionResult> CheckTranscationsForBatchSettlement([FromBody] TranscationsCheckForBatchSettlementModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.CheckTranscationsForBatchSettlement(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TranscationsCheckForBatchSettlementModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TranscationsCheckForBatchSettlementModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }




        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_registration_parameters")]
        public async Task<IActionResult> GetRegistrationParameters([FromBody] TransactionGetRegistrationProcessModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.GetRegistrationParameters(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.ObjGetMerchantDetail.Count > 0)
                    {
                        if (result.ObjGetMerchantDetail[0].Status == 1)
                        {
                            return this.OkCustom(ObjClass, result, _logger);
                        }
                        else
                        {
                            return this.Fail(ObjClass, result, _logger);
                        }


                    }

                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }




        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_terminal_app_update")]
        public async Task<IActionResult> GetTerminalAppUpdate([FromBody] GetTerminalAppUpdateModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.GetTerminalAppUpdate(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetTerminalAppUpdateModelOutput>().ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("reload_account")]
        public async Task<IActionResult> ReloadAccount([FromBody] TransactionReloadAccountModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.ReloadAccount(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionReloadAccountModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TransactionReloadAccountModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("balance_enquiry")]
        public async Task<IActionResult> BalanceEnquiry([FromBody] TransactionBalanceEnquiryModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.BalanceEnquiry(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionBalanceEnquiryModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.Fail(ObjClass, result, _logger);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("ccms_balance_enquiry")]
        public async Task<IActionResult> CCMSBalanceEnquiry([FromBody] TransactionCCMSBalanceEnquiryModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.CCMSBalanceEnquiry(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionCCMSBalanceEnquiryModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.Fail(ObjClass, result, _logger);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("control_card_pin_change")]
        public async Task<IActionResult> ContrlCardPinChange([FromBody] TransactionContrlCardPinChangeInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.ContrlCardPinChange(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionContrlCardPinChangeOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TransactionContrlCardPinChangeOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("unblock_card_pin")]
        public async Task<IActionResult> UnblockCardPin([FromBody] TransactionUnblockCardPinModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.UnblockCardPin(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionUnblockCardPinModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TransactionUnblockCardPinModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("unblock_card_pin_through_ccn")]
        public async Task<IActionResult> UnblockCardPinThroughCCN([FromBody] TransactionUnblockCardPinThroughCCNModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.UnblockCardPinThroughCCN(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionUnblockCardPinThroughCCNModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TransactionUnblockCardPinThroughCCNModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("unblock_cardpin_checkstatus_through_ccn")]
        public async Task<IActionResult> UnblockCardPinCheckStatusThroughCCN([FromBody] TransactionUnblockCardPinCheckStatusThroughCCNModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.UnblockCardPinCheckStatusThroughCCN(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionUnblockCardPinCheckStatusThroughCCNModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TransactionUnblockCardPinCheckStatusThroughCCNModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("change_card_pin")]
        public async Task<IActionResult> ChangeCardPin([FromBody] TransactionChangeCardPinModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.ChangeCardPin(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionChangeCardPinModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TransactionChangeCardPinModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("pin_unblock_request")]
        public async Task<IActionResult> PinUnblockRequest([FromBody] TransactionPinUnblockRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.PinUnblockRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionPinUnblockRequestModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TransactionPinUnblockRequestModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("hms_key_exchange")]
        public async Task<IActionResult> HMSKeyExchange([FromBody] HMSKeyExchangeModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.HMSKeyExchange(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<HMSKeyExchangeModelOutput>().ToList()[0].Status == 1)
                    {
                        //var log = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
                        //log.Info("Start logging for Key Exchange");
                        RSADataUtiltiy rsaEncUtil = new RSADataUtiltiy();

                        //TripleDESUtil = new TripleDESEncryption();
                        HSMResponseInfo hsmresponse = new HSMResponseInfo();
                        // Connect HSM
                        AtallaHSMProvider athp = new AtallaHSMProvider(HSMIP, HSMPORT);

                        // Generate TMK for the Terminal
                        hsmresponse = athp.GenerateKey(AttalaHSMServiceProvider.KeyScheme.DoubleLengthKey, AttalaHSMServiceProvider.KeyType.TMK);
                        AT93ResponseInfo key = (AT93ResponseInfo)hsmresponse.ResponseData;

                        // Get Left and Right of the Generated KEY
                        string TMKLeft = key.keySet.KeySpecifier.Substring(0, 16);
                        //log.Info("TMK Left :" + TMKLeft);
                        Console.WriteLine("TMK Left :" + TMKLeft);
                        string TMKRight = key.keySet.KeySpecifier.ToString().Substring(16, 16);
                        //log.Info("TMK Right :" + TMKRight);
                        Console.WriteLine("TMK Right :" + TMKRight);
                        // TMK (Left+Right) is sent to POS along with KCV
                        // Encrypt TMK under Public key and send to POS

                        // Generated TMK under DEK in HSM

                        hsmresponse = athp.EncryptTMK(DEKAKB, TMKLeft);
                        //log.Info("Encrpt TMK Left:" + hsmresponse);
                        Console.WriteLine("Encrpt TMK Left :" + hsmresponse);
                        AT97ResponseInfo LeftEncKey = (AT97ResponseInfo)hsmresponse.ResponseData;
                        hsmresponse = athp.EncryptTMK(DEKAKB, TMKRight);
                        //log.Info("Encrpt TMK Right:" + hsmresponse);
                        Console.WriteLine("Encrpt TMK Right :" + hsmresponse);
                        AT97ResponseInfo RightEncKey = (AT97ResponseInfo)hsmresponse.ResponseData;
                        string CombinedEncKey = LeftEncKey.encKey + RightEncKey.encKey;
                        //log.Info("CombinedEncKey:" + hsmresponse);
                        Console.WriteLine("CombinedEncKey:" + hsmresponse);
                        // Import TMK under KEK in HSM
                        hsmresponse = athp.ImportTMKUnderKEK(KEKAKB, CombinedEncKey);
                        AT11BResponseInfo encTMKUnderKEK = (AT11BResponseInfo)hsmresponse.ResponseData;
                        string MKAKB = encTMKUnderKEK.encWorkingKey;
                        string MKKCV = encTMKUnderKEK.KCV;

                        var outKey = string.Empty;
                        var rsaParam = rsaEncUtil.GetRSAParameters(ObjClass.PublicKey, out outKey);
                        byte[] byteData = ConversionClass.HexToByteArray(TMKLeft + TMKRight);
                        string encTMK = rsaEncUtil.Hash(ObjClass.PublicKey, byteData);

                        InsertUpdateHSMMasterKeyModelInput ObjInsUpdateMasterKey = new InsertUpdateHSMMasterKeyModelInput();

                        ObjInsUpdateMasterKey.TerminalId = ObjClass.TerminalId;
                        ObjInsUpdateMasterKey.TerminalUniqueId = result.Cast<HMSKeyExchangeModelOutput>().ToList()[0].TidUnqId;
                        ObjInsUpdateMasterKey.MKAKB = MKAKB;
                        ObjInsUpdateMasterKey.MKKCV = MKKCV;
                        ObjInsUpdateMasterKey.TerminalPK = ObjClass.PublicKey;

                        var CheckSuccessresult = await _transRepo.InsertUpdateHSMMasterKey(ObjInsUpdateMasterKey);

                        if (CheckSuccessresult.Cast<InsertUpdateHSMMasterKeyModelOutput>().ToList()[0].Status == 1)
                        {
                            result.Cast<HMSKeyExchangeModelOutput>().ToList()[0].TerminalId = ObjClass.TerminalId;
                            result.Cast<HMSKeyExchangeModelOutput>().ToList()[0].EncTMK = encTMK;
                            result.Cast<HMSKeyExchangeModelOutput>().ToList()[0].TMKKCV = MKKCV;
                            result.Cast<HMSKeyExchangeModelOutput>().ToList()[0].Status = 1;
                            result.Cast<HMSKeyExchangeModelOutput>().ToList()[0].Reason = "Key Exchange Successfully";
                        }
                        else
                        {
                            result.Cast<HMSKeyExchangeModelOutput>().ToList()[0].TerminalId = ObjClass.TerminalId;
                            result.Cast<HMSKeyExchangeModelOutput>().ToList()[0].EncTMK = "";
                            result.Cast<HMSKeyExchangeModelOutput>().ToList()[0].TMKKCV = "";
                            result.Cast<HMSKeyExchangeModelOutput>().ToList()[0].Status = 0;
                            result.Cast<HMSKeyExchangeModelOutput>().ToList()[0].Reason = "Reinitiate Key Exchange"; //hsmresponse.ReturnMessage;
                        }

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<HMSKeyExchangeModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("log_on")]
        public async Task<IActionResult> LogOn([FromBody] HMSLogOnModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.LogOn(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<HMSLogOnModelOutput>().ToList()[0].Status == 1)
                    {
                        //TripleDESUtil = new TripleDESEncryption();
                        HSMResponseInfo hsmresponse = new HSMResponseInfo();
                        // Connect HSM
                        AtallaHSMProvider athp = new AtallaHSMProvider(HSMIP, HSMPORT);

                        // Generate Session Key - DEK and PEK
                        // DEK
                        string sessionDEKCommand = "1DDNE000";
                        hsmresponse = athp.GenerateSK(sessionDEKCommand);

                        AT10ResponseInfo DATASKAKB = (AT10ResponseInfo)hsmresponse.ResponseData;
                        // PEK
                        string sessionPEKCommand = "1PUNE000";
                        hsmresponse = athp.GenerateSK(sessionPEKCommand);

                        AT10ResponseInfo PINSKAKB = (AT10ResponseInfo)hsmresponse.ResponseData;

                        // store PINSKAKB and DATASKAKB in DB for each TID

                        // Translate Session keys under TMK

                        // Both DEK and PEK need to be translated under TMK

                        hsmresponse = athp.EncryptSKunderTMK(result.Cast<HMSLogOnModelOutput>().ToList()[0].MKAKB, DATASKAKB.encWorkingKey);
                        AT1AResponseInfo DEKUnderTMK = (AT1AResponseInfo)hsmresponse.ResponseData;

                        hsmresponse = athp.EncryptSKunderTMK(result.Cast<HMSLogOnModelOutput>().ToList()[0].MKAKB, PINSKAKB.encWorkingKey);
                        AT1AResponseInfo PEKUnderTMK = (AT1AResponseInfo)hsmresponse.ResponseData;

                        string DEKAKB = DATASKAKB.encWorkingKey;
                        string DEKKCV = DEKUnderTMK.KCV;
                        string PEKAKB = PINSKAKB.encWorkingKey;
                        string PEKKCV = PEKUnderTMK.KCV;


                        UpdateSessionKeyModelInput ObjUpdateSessionKey = new UpdateSessionKeyModelInput();
                        ObjUpdateSessionKey.TerminalId = ObjClass.TerminalId;
                        ObjUpdateSessionKey.TerminalUniqueId = result.Cast<HMSLogOnModelOutput>().ToList()[0].TidUnqId;
                        ObjUpdateSessionKey.DPKAKB = DEKAKB;
                        ObjUpdateSessionKey.DPKKCV = DEKKCV;
                        ObjUpdateSessionKey.PEKAKB = PEKAKB;
                        ObjUpdateSessionKey.PEKKCV = PEKKCV;

                        var CheckSuccessresult = await _transRepo.UpdateHSMSessionKey(ObjUpdateSessionKey);



                        if (CheckSuccessresult.Cast<UpdateSessionKeyModelOutput>().ToList()[0].Status == 1)
                        {
                            result.Cast<HMSLogOnModelOutput>().ToList()[0].TidUnqId = result.Cast<HMSLogOnModelOutput>().ToList()[0].TidUnqId;
                            result.Cast<HMSLogOnModelOutput>().ToList()[0].TerminalId = ObjClass.TerminalId;
                            result.Cast<HMSLogOnModelOutput>().ToList()[0].DEKWorkingKey = DEKUnderTMK.encSessionKey;
                            result.Cast<HMSLogOnModelOutput>().ToList()[0].DEKKCV = DEKKCV;
                            result.Cast<HMSLogOnModelOutput>().ToList()[0].PEKWorkingKey = PEKUnderTMK.encSessionKey;
                            result.Cast<HMSLogOnModelOutput>().ToList()[0].PEKKCV = PEKKCV;
                            //result.Cast<HMSLogOnModelOutput>().ToList()[0].MKAKB = result.Cast<HMSLogOnModelOutput>().ToList()[0].MKAKB;
                            result.Cast<HMSLogOnModelOutput>().ToList()[0].Status = 1;
                            result.Cast<HMSLogOnModelOutput>().ToList()[0].Reason = "LogOn Successfully";

                        }
                        else
                        {
                            result.Cast<HMSLogOnModelOutput>().ToList()[0].TidUnqId = result.Cast<HMSLogOnModelOutput>().ToList()[0].TidUnqId;
                            result.Cast<HMSLogOnModelOutput>().ToList()[0].TerminalId = ObjClass.TerminalId;
                            result.Cast<HMSLogOnModelOutput>().ToList()[0].DEKWorkingKey = "";
                            result.Cast<HMSLogOnModelOutput>().ToList()[0].DEKKCV = "";
                            result.Cast<HMSLogOnModelOutput>().ToList()[0].PEKWorkingKey = "";
                            result.Cast<HMSLogOnModelOutput>().ToList()[0].PEKKCV = "";
                            //result.Cast<HMSLogOnModelOutput>().ToList()[0].MKAKB = "";
                            result.Cast<HMSLogOnModelOutput>().ToList()[0].Status = 0;
                            result.Cast<HMSLogOnModelOutput>().ToList()[0].Reason = "Reinitiate LogOn";
                        }

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<HMSLogOnModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("reversal_financial_transactions")]
        public async Task<IActionResult> ReversalFinancialTransactions([FromBody] TransactionReversalFinancialModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.ReversalFinancialTransactions(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionReversalFinancialModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TransactionReversalFinancialModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("void_financial_transactions")]
        public async Task<IActionResult> VoidFinancialTransactions([FromBody] TransactionVoidFinancialModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.VoidFinancialTransactions(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionVoidFinancialModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TransactionVoidFinancialModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("loyalty_balance_check")]
        public async Task<IActionResult> LoyaltyBalanceCheck([FromBody] TransactionLoyaltyBalanceCheckModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.LoyaltyBalanceCheck(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionLoyaltyBalanceCheckModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TransactionLoyaltyBalanceCheckModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("batch_upload")]
        public async Task<IActionResult> BatchUpload([FromBody] TranscationsCheckForBatchUploadModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.BatchUpload(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TranscationsCheckForBatchUploadModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TranscationsCheckForBatchUploadModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("tracking_by_terminal")]
        public async Task<IActionResult> TrackingByTerminal([FromBody] TransactionTrackingByTerminalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.TrackingByTerminal(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionTrackingByTerminalModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TransactionTrackingByTerminalModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_driver_loyalty")]
        public async Task<IActionResult> InsertDriverLoyalty([FromBody] TransactionInsertDriverLoyaltyModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _transRepo.InsertDriverLoyalty(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TransactionInsertDriverLoyaltyModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TransactionInsertDriverLoyaltyModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }
    }
}
