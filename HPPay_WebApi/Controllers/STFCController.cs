using HPPay.DataModel;
using HPPay.DataModel.M2PExternal;
using HPPay.DataModel.STFC;
using HPPay.DataRepository.DBDapper;
using HPPay.DataRepository.M2PExternal;
using HPPay.DataRepository.STFC;
using HPPay.Infrastructure.CommonClass;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SecurityLayer;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Hosting;
using HPPay.DataModel.Settings;
using HPPay.DataRepository.Transaction;
using HPPay.DataModel.Transaction;

namespace HPPay_WebApi.Controllers
{
    [Route("api/dtplus/Stfc")]
    [ApiController]
    public class STFCController : ControllerBase
    {

        private readonly ILogger<STFCController> _logger;
        private readonly IStfcApiRepository _stfcRepo;
        private readonly IConfiguration _configuration;
        private readonly IM2PExternalRepository _M2PRepo;
        string EnCryptKey = string.Empty;
        string EnCryptIV = string.Empty;
        string DeCryptKey = string.Empty;
        string DeCryptIV = string.Empty;
        string serviceUrl = string.Empty;
        public ILogger<M2PExternalController> _M2plogger;
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ITransactionRepository _transRepo;
        public STFCController(ILogger<STFCController> logger, IStfcApiRepository stfcRepo, ITransactionRepository transRepo, IConfiguration configuration)
        {
            _stfcRepo = stfcRepo;
            _logger = logger;
            //_M2plogger = M2plogger;
            _configuration = configuration;
            //_context = context;
            //_hostingEnvironment = hostingEnvironment;
            EnCryptKey = _configuration.GetSection("STFCAPISettings:EnCryptKey").Value.ToString();
            EnCryptIV = _configuration.GetSection("STFCAPISettings:EnCryptIV").Value.ToString();
            DeCryptKey = _configuration.GetSection("STFCAPISettings:DeCryptKey").Value.ToString();
            DeCryptIV = _configuration.GetSection("STFCAPISettings:DeCryptIV").Value.ToString();
            serviceUrl = _configuration.GetSection("STFCAPISettings:APIUrl").Value.ToString();
            _M2PRepo = new M2PExternalRepository(_context, _hostingEnvironment, _configuration);
            _transRepo = transRepo;


        }



        [HttpPost]
        [Route("stfc_authorization")]
        public STFCConfirmPaymentResponse StfcCreditLimitAuthorizationAPI(TransactionSalebyTerminalModelInput objClass)
        {
            //if (objClass == null)
            //{
            //    return this.BadRequestCustom(objClass, null, _logger);
            //}
            //else
            //{
            CreditLimitAuthorizationModelOutput result = new CreditLimitAuthorizationModelOutput();
            STFCConfirmPaymentResponse res = new STFCConfirmPaymentResponse();
            if (objClass.Invoiceamount <= 0)
            {
                res = new STFCConfirmPaymentResponse() { ResCode = "0", ResMsg = "Amount must be greater then zero", Reason = "Amount must be greater then zero" };
                res.Invoiceid = objClass.Invoiceid;
                res.Batchid = objClass.Batchid;
                return res;
                //return this.FailCustom(objClass, res, _logger, "");
            }
            result = CreditLimitAuthorization(objClass);

            res.Status = result.Status;
            res.Reason = result.Reason;
            res.AvailableLimit = result.AvailableLimit;
            res.STFCCustomerID = result.STFCCustomerID;
            res.DTPCustomerID = result.DTPCustomerID;
            res.CardNoOutput = result.CardNumber;
            res.TxnId = result.TxnId;
            res.RSP = result.RSP;
            res.Volume = result.Volume;
            res.Invoiceid = objClass.Invoiceid;
            res.Batchid = objClass.Batchid;
            res.RefNo = result.RefNo;

            if (result != null && result.MsgType.Trim().ToUpper() == "SUCCESS")
            {
                res.ResCode = "700";
                res.ResMsg = result.MsgType;
                return res;
                //return this.OkCustom(objClass, res, _logger);
            }
            else
            {
                res.ResCode = "0";
                res.ResMsg = result.ErrorReason;
                res.Reason = result.Reason;
                return res;
                //return this.FailCustom(objClass, res, _logger, "");
            }
            //}
        }

        private EntityCheckAPIResponse EntityCheckAPI(EntityCheckAPIRequest objClass)
        {
            // EntityCheckAPIRequestModelOutput result = new EntityCheckAPIRequestModelOutput();
            EntityCheckAPIResponse res = new EntityCheckAPIResponse();
            string info = objClass.CardNo + "|" + objClass.DTPCustomerId;



            CardInfo cardInfo = new CardInfo()
            {
                Info = AESEncrytDecry.EncryptStringAES(info, EnCryptKey, EnCryptIV)
            };

            HttpResponseMessage apiResponse = null;
            string responseapi = string.Empty;

            try
            {
                apiResponse = Variables.CallAPI(serviceUrl + "RestService/EntityCheckAPI", JsonConvert.SerializeObject(cardInfo), "").Result;

                responseapi = apiResponse.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrEmpty(responseapi))
                {
                    var val = AESEncrytDecry.DecryptStringAES(responseapi, DeCryptKey, DeCryptIV);
                    res = JsonConvert.DeserializeObject<EntityCheckAPIResponse>(val);



                }


            }
            catch (Exception ex)
            {
                responseapi = "Error in EntityCheckAPI ::"+ex.Message;

            }
            if (res != null && res.MsgType.Trim().ToUpper() != "SUCCESS")
            {
                STFCApiRequestResponseModelInput reqres = new STFCApiRequestResponseModelInput()
                {
                    MerchantID = objClass.MerchantID,
                    TerminalID = objClass.TerminalID,
                    RqId = objClass.RequestID,
                    ApiRequest = JsonConvert.SerializeObject(cardInfo),
                    ApiRequestUrL = serviceUrl + "EntityCheckAPI",
                    ApiResponse = responseapi,
                    CreatedBy = objClass.CreatedBy,
                    DTPCustomerID = objClass.DTPCustomerId,
                    ReqAmount = "",
                    ReqCardNo = objClass.CardNo,
                    ReqTxnId = "",
                    ResTxnId = "",
                    ResAvailableLimit = res.AvailableLimit,
                    ResMsgType = res.MsgType,
                    ResMsg = "",
                    ResErrorReason = res.ErrorReason,
                    STFCCustomerID = "",
                    ResCardNumber = "",
                    Remarks = responseapi

                };
                _stfcRepo.InsertStfcApiRequestResponseDetail(reqres);
            }
            else
            {
                UpdateSTFCRequestInput ObjupdateRq = new UpdateSTFCRequestInput();
                ObjupdateRq.Remarks = "";
                ObjupdateRq.ModifiedBy = objClass.CreatedBy;
                ObjupdateRq.RequestId = objClass.RequestID;
                ObjupdateRq.EntityCheckAPIRequest = JsonConvert.SerializeObject(cardInfo);
                ObjupdateRq.EntityCheckAPIRequest = responseapi;
                _stfcRepo.UpdateSTFCApiRequest(ObjupdateRq);
            }
            return res;

        }


        private CreditLimitAuthorizationModelOutput CreditLimitAuthorization(TransactionSalebyTerminalModelInput objClass)
        {
            int RequestID = 0;
            string TxnTime = DateTime.Now.ToString("yyyyy-MM-dd");
            STFCApiRequestResponseModelInput reqres = new STFCApiRequestResponseModelInput();
            CreditLimitAuthorizationModelOutput result = new CreditLimitAuthorizationModelOutput();
            try
            {

                STFCApiRequestModelInput LogReq = new STFCApiRequestModelInput()

                {
                    Amount = objClass.Invoiceamount.ToString(),
                    ApiRequestUrL = serviceUrl + "RestService/EntityCheckAPI",
                    CardNo = objClass.Cardno,
                    CreatedBy = objClass.Userid,
                    MerchantID = objClass.Merchantid,
                    TerminalID = objClass.Terminalid,

                    Invoiceid = objClass.Invoiceid,
                    Batchid = objClass.Batchid,
                    Invoicedate = objClass.Invoicedate,
                    Productid = objClass.Productid,
                    Odometerreading = objClass.Odometerreading,
                    TransType = objClass.Transtype,
                    Sourceid = objClass.Sourceid,
                    Formfactor = objClass.Formfactor,
                    DCSTokenNo = objClass.DCSTokenNo,
                    Stan = objClass.Stan,
                    Paymentmode = "STFC",
                    Gatewayname = "STFC",
                    Bankname = "STFC",
                    Paycode = ""
                };



                var Reqres = _stfcRepo.InsertStfcFastagApiRequest(LogReq).Result;

                if (Reqres != null && Reqres.Count() > 0)
                {
                    RequestID = Reqres.Cast<STFCApiRequestModelOutput>().ToList()[0].RequestId;

                    if (RequestID > 0 && Reqres.Cast<STFCApiRequestModelOutput>().ToList()[0].Status != 1)
                    {
                        CreditLimitAuthorizationModelOutput res = new CreditLimitAuthorizationModelOutput();
                        int status_Code = Reqres.Cast<STFCApiRequestModelOutput>().ToList()[0].Status;
                        if (status_Code == (int)ValidationStatus.Terminal_Not_Active)
                            res = new CreditLimitAuthorizationModelOutput() { MsgType = Convert.ToString((int)IdfcApiStatus.Terminal_Not_Active), ErrorReason = Reqres.Cast<STFCApiRequestModelOutput>().ToList()[0].Reason };

                        else if (status_Code == (int)ValidationStatus.Merchant_Not_Active)
                        {
                            res = new CreditLimitAuthorizationModelOutput() { MsgType = Convert.ToString((int)IdfcApiStatus.Merchant_Not_Active), ErrorReason = Reqres.Cast<STFCApiRequestModelOutput>().ToList()[0].Reason };

                        }
                        else if (status_Code == (int)ValidationStatus.Amount_lessthen_ccms)
                        {
                            res = new CreditLimitAuthorizationModelOutput() { MsgType = Convert.ToString((int)IdfcApiStatus.Amount_lessthen_ccms), ErrorReason = Reqres.Cast<STFCApiRequestModelOutput>().ToList()[0].Reason };
                        }
                        ///Update Request Table For failure
                        return res;
                    }
                }
                CheckCardLimitValidationforAPIInput objreq = new CheckCardLimitValidationforAPIInput()
                {
                    CardNo = objClass.Cardno,
                    Invoiceamount = objClass.Invoiceamount,
                    Mobileno = objClass.Mobileno,
                    Invoicedate = objClass.Invoicedate,
                    Sourceid = objClass.Sourceid,
                    Formfactor = objClass.Formfactor,
                    Pin = objClass.Pin,
                    Userid = objClass.Userid
                };
                var checkbalance = _stfcRepo.CheckCardLimitValidationforAPI(objreq).Result;
                if (checkbalance == null || checkbalance.Cast<CheckCardLimitValidationforAPIOutput>().ToList()[0].Status == 0)
                {
                    UpdateSTFCRequestInput ObjupdateRq = new UpdateSTFCRequestInput();
                    ObjupdateRq.Remarks = checkbalance.Cast<CheckSTFCInvoiceIdBatchIdExistOutput>().ToList()[0].Reason;
                    ObjupdateRq.ModifiedBy = objClass.Userid;
                    ObjupdateRq.RequestId = RequestID;
                    _stfcRepo.UpdateSTFCApiRequest(ObjupdateRq);

                    return new CreditLimitAuthorizationModelOutput() { MsgType = "Failure", ErrorReason = ObjupdateRq.Remarks, Reason = ObjupdateRq.Remarks };

                }
                if (string.IsNullOrEmpty(objClass.Cardno))
                {
                    objClass.Cardno = checkbalance.Cast<CheckCardLimitValidationforAPIOutput>().ToList()[0].CardNumber;
                }

                var objgetCustomer = _stfcRepo.GetStfcCustomerIdByCard(objClass.Cardno).Result;
                string CustomerId = string.Empty;
                if (objgetCustomer == null || (objgetCustomer.Count() > 0 && objgetCustomer.Cast<GetStfcCustomerIdByCardOutput>().ToList()[0].Status == 0))
                {
                    result.MsgType = "Failure";
                    result.ErrorReason = objgetCustomer.Cast<GetStfcCustomerIdByCardOutput>().ToList()[0].Reason;

                    return result;
                }
                else
                {
                    CheckSTFCInvoiceIdBatchIdExistInput obj = new CheckSTFCInvoiceIdBatchIdExistInput() { Batchid = objClass.Batchid, Invoiceid = objClass.Invoiceid, RecordType = 1, MerchantID = objClass.Merchantid, TerminalID = objClass.Terminalid, UserId = objClass.Userid, TransTypeId = objClass.Transtype };
                    var checkInvoiceidExist = _stfcRepo.CheckFastagInvoiceIdBatchIdExist(obj).Result;
                    if (checkInvoiceidExist == null || checkInvoiceidExist.Cast<CheckSTFCInvoiceIdBatchIdExistOutput>().ToList()[0].Status == 1)
                    {
                        UpdateSTFCRequestInput ObjupdateRq = new UpdateSTFCRequestInput();
                        ObjupdateRq.Remarks = checkInvoiceidExist.Cast<CheckSTFCInvoiceIdBatchIdExistOutput>().ToList()[0].Reason;
                        ObjupdateRq.ModifiedBy = objClass.Userid;
                        ObjupdateRq.RequestId = RequestID;
                        _stfcRepo.UpdateSTFCApiRequest(ObjupdateRq);
                        return new CreditLimitAuthorizationModelOutput() { MsgType = Convert.ToString((int)IdfcApiStatus.InvoiceId_BatchId_Exist), ErrorReason = IdfcApiStatus.InvoiceId_BatchId_Exist.GetDisplayName() };

                    }
                    CustomerId = objgetCustomer.Cast<GetStfcCustomerIdByCardOutput>().ToList()[0].CustomerId;
                    EntityCheckAPIRequest objReq = new EntityCheckAPIRequest() { CardNo = objClass.Cardno, DTPCustomerId = CustomerId ,CreatedBy=objClass.Userid,RequestID= RequestID };
                    EntityCheckAPIResponse objresult = EntityCheckAPI(objReq);
                    string txnid = "";   //"stfc" + StaticClass.APIReferenceNo;
                    if (objresult != null && objresult.MsgType.Trim().ToUpper() == "SUCCESS")

                    {
                        // var lststfcid = _stfcRepo.GetSTFCTxnRefID().Result;
                        //if (lststfcid != null && lststfcid.Count() > 0)
                        //{
                        //txnid = lststfcid.Cast<GetSTFCTxnRefIDOutput>().ToList()[0].STFCTxnRefID;
                        txnid = StaticClass.APIReferenceNo;
                        string info = objClass.Cardno + "|" + CustomerId + "|" + objClass.Invoiceamount + "|" + DateTime.Now.ToString("yyyy-MM-dd") + "|" + txnid;
                        CardInfo cardInfo = new CardInfo() { Info = AESEncrytDecry.EncryptStringAES(info, EnCryptKey, EnCryptIV) };

                        HttpResponseMessage apiResponse = null;
                        string responseapi = string.Empty;



                        try
                        {
                            apiResponse = Variables.CallAPI(serviceUrl + "RestService/CreditLimitAuthorizationAPI", JsonConvert.SerializeObject(cardInfo), "").Result;

                            responseapi = apiResponse.Content.ReadAsStringAsync().Result;
                            if (!string.IsNullOrEmpty(responseapi))
                            {
                                var val = AESEncrytDecry.DecryptStringAES(responseapi, DeCryptKey, DeCryptIV);
                                result = JsonConvert.DeserializeObject<CreditLimitAuthorizationModelOutput>(val);
                            }

                        }

                        catch (Exception ex)
                        {
                            responseapi = ex.Message;

                        }

                        reqres = new STFCApiRequestResponseModelInput()
                        {
                            RqId = RequestID,
                            ApiRequest = JsonConvert.SerializeObject(cardInfo),
                            ApiRequestUrL = serviceUrl + "RestService/CreditLimitAuthorizationAPI",
                            ApiResponse = responseapi,
                            CreatedBy = objClass.Userid,
                            DTPCustomerID = CustomerId,
                            ResDTPCustomerID = result.DTPCustomerID,
                            ReqAmount = objClass.Invoiceamount.ToString(),
                            ReqCardNo = objClass.Cardno,
                            ReqTxnId = txnid,
                            ResTxnId = "",
                            ResAvailableLimit = objresult.AvailableLimit,
                            ResMsgType = result.MsgType,
                            ResMsg = "",
                            ResErrorReason = result.ErrorReason,
                            STFCCustomerID = result.STFCCustomerID,
                            ResCardNumber = result.CardNumber,

                        };

                        if (result != null && result.MsgType.Trim().ToUpper() == "SUCCESS")

                        {
                            objClass.Paymentmode = "3";
                            objClass.Bankname = "STFC";
                            var UpdateCCMSBAlanceResult = _transRepo.SaleByTerminal(objClass).Result;//_stfcRepo.UpdateCCMSBAlanceForStfcCustomer(objClass, txnid, CustomerId).Result;
                            result.RefNo = txnid;
                            result.TxnId = txnid;
                            if (UpdateCCMSBAlanceResult != null && UpdateCCMSBAlanceResult.Count() > 0)
                            {
                                result.RSP = UpdateCCMSBAlanceResult.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].RSP;
                                result.Volume = UpdateCCMSBAlanceResult.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].Volume;

                                if (UpdateCCMSBAlanceResult != null && UpdateCCMSBAlanceResult.Count() > 0 && UpdateCCMSBAlanceResult.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].Status == 1)
                                {
                                    reqres.Remarks = "Payment Process Successfully " + UpdateCCMSBAlanceResult.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].Reason;
                                    reqres.IsPaymentSuccess = 1;
                                    _stfcRepo.InsertStfcApiRequestResponseDetail(reqres);
                                    result.Reason = "Transaction Success";
                                }
                                else
                                {
                                    reqres.Remarks = "Payment Failed due to CCMCBalance Not Updated in DB. " + UpdateCCMSBAlanceResult.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].Reason;
                                    _stfcRepo.InsertStfcApiRequestResponseDetail(reqres);

                                    result.MsgType = "Failure";
                                    result.ErrorReason = "CCMCBalance Not Updated in DB";
                                    result.Reason = UpdateCCMSBAlanceResult.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].Reason;
                                }
                            }

                        }
                        else
                        {
                            reqres.Remarks = "Payment failed from STFC API";
                            _stfcRepo.InsertStfcApiRequestResponseDetail(reqres);
                            result.Reason = result.ErrorReason;
                            return result;
                        }

                        //}
                        //else
                        //{
                        //    result.ErrorReason = IdfcApiStatus.TxnID_Not_Genrated.GetDisplayName();
                        //    result.MsgType = "Failure";
                        //    result.Reason = IdfcApiStatus.TxnID_Not_Genrated.GetDisplayName();
                        //}
                    }
                    else
                    {

                        result.MsgType = objresult.MsgType;
                        result.ErrorReason = objresult.ErrorReason;
                        result.Reason = objresult.MsgType;
                    }

                }
            }
            catch (Exception ex)
            {
                reqres.Remarks = "Error :: " + ex.Message;
                if (RequestID > 0)
                {

                    _stfcRepo.InsertStfcApiRequestResponseDetail(reqres);


                }
                result.ErrorReason = IdfcApiStatus.Unhandeled_Exception.GetDisplayName();
                result.MsgType = "Failure";
                result.Reason = "Error :: " + IdfcApiStatus.Unhandeled_Exception.GetDisplayName();

            }

            return result;
        }


        [HttpPost]
        [Route("stfc_transaction_reversal")]
        public STFCTransactionReversalModelOutput STFCTransactionReversalAPI(STFCTransactionReversalModelInput ObjClass)
        {
            int RequestID = 0;
            STFCTransactionReversalModelOutput result = new STFCTransactionReversalModelOutput();
            STFCApiRequestResponseModelInput objReqRes = new STFCApiRequestResponseModelInput();
            try
            {

                STFCApiRequestModelInput LogReq = new STFCApiRequestModelInput()

                {
                    ApiRequestUrL = serviceUrl + "RestService/TransactionReversalAPI",
                    CardNo = ObjClass.CardNo,
                    CreatedBy = ObjClass.Userid,
                    MerchantID = ObjClass.Merchantid,
                    TerminalID = ObjClass.Terminalid,
                    TxnId = ObjClass.TxnRefId,
                    Invoiceid = ObjClass.Invoiceid,
                    Batchid = ObjClass.Batchid,
                    Invoicedate = ObjClass.Invoicedate,
                    Productid = ObjClass.Productid,
                    Odometerreading = ObjClass.Odometerreading,
                    TransType = ObjClass.TransType,
                    Sourceid =ObjClass.Sourceid,
                    Formfactor = ObjClass.Formfactor,
                    DCSTokenNo = ObjClass.DCSTokenNo,
                    Stan = ObjClass.Stan,
                    Paymentmode = "STFC",
                    Gatewayname = "STFC",
                    Bankname = "STFC",
                    Paycode = ""
                };


                var Reqres = _stfcRepo.InsertStfcFastagApiRequest(LogReq).Result;
                if (Reqres != null && Reqres.Count() > 0)
                {
                    RequestID = Reqres.Cast<STFCApiRequestModelOutput>().ToList()[0].RequestId;

                    if (RequestID > 0 && Reqres.Cast<STFCApiRequestModelOutput>().ToList()[0].Status != 1)
                    {
                        // result = new STFCTransactionReversalModelOutput();
                        int status_Code = Reqres.Cast<STFCApiRequestModelOutput>().ToList()[0].Status;
                        if (status_Code == (int)ValidationStatus.Terminal_Not_Active)
                            result = new STFCTransactionReversalModelOutput() { MsgType = Convert.ToString((int)IdfcApiStatus.Terminal_Not_Active), ErrorReason = Reqres.Cast<STFCApiRequestModelOutput>().ToList()[0].Reason };

                        else if (status_Code == (int)ValidationStatus.Merchant_Not_Active)
                        {
                            result = new STFCTransactionReversalModelOutput() { MsgType = Convert.ToString((int)IdfcApiStatus.Merchant_Not_Active), ErrorReason = Reqres.Cast<STFCApiRequestModelOutput>().ToList()[0].Reason };

                        }
                        else if (status_Code == (int)ValidationStatus.Amount_lessthen_ccms)
                        {
                            result = new STFCTransactionReversalModelOutput() { MsgType = Convert.ToString((int)IdfcApiStatus.Amount_lessthen_ccms), ErrorReason = Reqres.Cast<STFCApiRequestModelOutput>().ToList()[0].Reason };
                        }
                        ///Update Request Table For failure
                        UpdateSTFCRequestInput ObjupdateRq = new UpdateSTFCRequestInput();
                        ObjupdateRq.Remarks = result.ErrorReason;
                        ObjupdateRq.ModifiedBy = ObjClass.Userid;
                        ObjupdateRq.RequestId = RequestID;
                        _stfcRepo.UpdateSTFCApiRequest(ObjupdateRq);

                    }

                    else
                    {
                        //result = new STFCTransactionReversalModelOutput();
                        CheckSTFCInvoiceIdBatchIdExistInput obj = new CheckSTFCInvoiceIdBatchIdExistInput() { Batchid = ObjClass.Batchid, Invoiceid = ObjClass.Invoiceid, RecordType = 1, MerchantID = ObjClass.Merchantid, TerminalID = ObjClass.Terminalid, UserId = ObjClass.Userid, TransTypeId = ObjClass.TransType };
                        //var checkInvoiceidExist = _stfcRepo.CheckFastagInvoiceIdBatchIdExist(obj).Result;
                        //if (checkInvoiceidExist == null || checkInvoiceidExist.Cast<CheckSTFCInvoiceIdBatchIdExistOutput>().ToList()[0].Status == 1)
                        //{
                        //    return new STFCTransactionReversalModelOutput() { MsgType = Convert.ToString((int)IdfcApiStatus.InvoiceId_BatchId_Exist), ErrorReason = IdfcApiStatus.InvoiceId_BatchId_Exist.GetDisplayName() };

                        //}

                        string info = ObjClass.TxnRefId;
                        string txnid =  StaticClass.APIReferenceNo;

                        var lststfcid = _stfcRepo.GetSTFCTxnRefID().Result;
                        if (lststfcid != null && lststfcid.Count() > 0)
                        {
                            txnid = lststfcid.Cast<GetSTFCTxnRefIDOutput>().ToList()[0].STFCTxnRefID;
                        }
                        else
                        {
                            result.ErrorReason = IdfcApiStatus.TxnID_Not_Genrated.GetDisplayName();
                            result.MsgType = "Failure";
                            return result;
                        }
                        CardInfo cardInfo = new CardInfo() { Info = AESEncrytDecry.EncryptStringAES(info, EnCryptKey, EnCryptIV) };

                        HttpResponseMessage apiResponse = null;
                        string responseapi = string.Empty;



                        try
                        {
                            var objrefund = _stfcRepo.CheckFastagRefundProcessedForSTFCCustomer(ObjClass).Result;
                            if (objrefund != null && objrefund.Count() > 0 && objrefund.Cast<STFCTransactionReversalModelOutput>().ToList()[0].Status == 1)
                            {
                                var res = objrefund.Cast<STFCTransactionReversalModelOutput>().ToList()[0];
                                result.MsgType = res.MsgType;
                                result.ErrorReason = res.Reason;
                                return result;

                            }

                            apiResponse = Variables.CallAPI(serviceUrl + "RestService/TransactionReversalAPI", JsonConvert.SerializeObject(cardInfo), "").Result;

                            responseapi = apiResponse.Content.ReadAsStringAsync().Result;
                            if (!string.IsNullOrEmpty(responseapi))
                            {
                                var val = AESEncrytDecry.DecryptStringAES(responseapi, DeCryptKey, DeCryptIV);
                                result = JsonConvert.DeserializeObject<STFCTransactionReversalModelOutput>(val);
                            }

                        }

                        catch (Exception ex)
                        {
                            responseapi = ex.Message;

                        }

                        objReqRes = new STFCApiRequestResponseModelInput()
                        {
                            RqId = RequestID,
                            ApiRequest = JsonConvert.SerializeObject(cardInfo),
                            ApiRequestUrL = serviceUrl + "RestService/TransactionReversalAPI",
                            ApiResponse = responseapi,
                            CreatedBy = ObjClass.Userid,
                            DTPCustomerID = "",
                            ResDTPCustomerID = "",
                            ReqAmount = "",  //ObjClass.Amount.ToString()
                            ReqCardNo = "",
                            ReqTxnId = txnid,
                            ReqOrgTxnId = ObjClass.TxnRefId,
                            ResTxnId = "",
                            ResAvailableLimit = "",
                            ResMsgType = result.MsgType,
                            ResMsg = "",
                            ResErrorReason = result.ErrorReason,
                            STFCCustomerID = "",
                            ResCardNumber = "",

                        };

                        if (!string.IsNullOrEmpty(result.MsgType) && result.MsgType.ToString().ToUpper() == "SUCCESS")
                        {
                            var objresult = _stfcRepo.RefundCCMSBAlanceForSTFCCustomer(ObjClass).Result;
                            if (objresult != null && objresult.Count() > 0 && objresult.Cast<UpdateCCMSBAlanceForSTFCCustomer>().ToList()[0].Status == 1)
                            {
                                objReqRes.Remarks = "Refund Process Successfully " + objresult.Cast<UpdateCCMSBAlanceForSTFCCustomer>().ToList()[0].Reason;
                                objReqRes.IsRefundSuccess = 1;
                                // _iciciRepo.InsertIciciApiRequestResponseDetail(objReqRes);
                                _stfcRepo.UpdateRequestResponseDetailRefundStatus(ObjClass);
                            }

                            else
                            {
                                objReqRes.Remarks = "Refund Failed " + objresult.Cast<UpdateCCMSBAlanceForSTFCCustomer>().ToList()[0].Reason;
                                objReqRes.IsRefundSuccess = 0;

                                result.ErrorReason = Convert.ToString((int)IdfcApiStatus.Unhandeled_Exception);
                                result.MsgType = "Failure";

                            }
                        }

                        _stfcRepo.InsertStfcApiRequestResponseDetail(objReqRes);
                        return result;
                    }

                }

            }
            catch (Exception ex)
            {
                objReqRes.Remarks = "Error :: " + ex.Message;
                _stfcRepo.InsertStfcApiRequestResponseDetail(objReqRes);
                result.ErrorReason = IdfcApiStatus.Unhandeled_Exception.GetDisplayName();
                result.MsgType = "Failure";

            }
            return result;
        }

    }





}
