using HPPay.DataModel;
using HPPay.DataModel.M2PExternal;
using HPPay.DataModel.Transaction;
using HPPay.DataRepository.DBDapper;
using HPPay.DataRepository.M2PExternal;
using HPPay.DataRepository.Transaction;
using HPPay.Infrastructure.CommonClass;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [Route("api/hppay/M2P")]
    [ApiController]
    public class M2PExternalController : ControllerBase
    {

        private readonly ILogger<M2PExternalController> _logger;
        private readonly IM2PExternalRepository _M2PRepo;
        private readonly IConfiguration _configuration;
        string ApiPassword = string.Empty;
        string UserName = string.Empty;
        string serviceUrl = string.Empty;
        string M2PCustomerId = string.Empty;
        private readonly ITransactionRepository _transRepo;
        public M2PExternalController(ILogger<M2PExternalController> logger, IM2PExternalRepository M2PRepo, ITransactionRepository transRepo, IConfiguration configuration)
        {
            _M2PRepo = M2PRepo;
            _logger = logger;
            _configuration = configuration;
            ApiPassword = _configuration.GetSection("M2PExternalSettings:Password").Value.ToString();
            UserName = _configuration.GetSection("M2PExternalSettings:Username").Value.ToString();
            serviceUrl = _configuration.GetSection("M2PExternalSettings:APIUrl").Value.ToString();
            M2PCustomerId = "FDMC1O004";// _configuration.GetSection("M2PExternalSettings:APIUrl").Value.ToString();
            _transRepo = transRepo;
        }
        [HttpPost]
        [Route("m2p_authorization")]
        public M2PConfirmPaymentResponse M2PCreditLimitAuthorizationAPI([FromBody] TransactionSalebyTerminalModelInput objClass,string SaurceCustomerID)
        {
            M2PCustomerId = SaurceCustomerID;
            M2PCreditLimitAuthorizationModelOutput result = new M2PCreditLimitAuthorizationModelOutput();
            M2PConfirmPaymentResponse res = new M2PConfirmPaymentResponse();
          // var objgetCustomer = _M2PRepo.GetM2PCustomerIdByCard(objClass.CardNo).Result;
            if (objClass.Invoiceamount <= 0)
            {
                res = new M2PConfirmPaymentResponse() { ResCode = "0", ResMsg = "Amount must be greater then zero", Reason = "Amount must be greater then zero" };
                res.Invoiceid = objClass.Invoiceid;
                res.Batchid = objClass.Batchid;
                return res;
            }
            result = CreditLimitAuthorization(objClass);
            res.Status = result.Status;
            res.Reason = result.Reason;
            res.AvailableLimit = result.AvailableLimit;
            res.M2PCustomerID = SaurceCustomerID;
            res.DTPCustomerID = result.DTPCustomerID;
            res.CardNoOutput = result.CardNumber;
            res.TxnId = result.RefNo;
            res.RSP = result.RSP;
            res.Volume = result.Volume;
            res.Invoiceid = objClass.Invoiceid;
            res.Batchid = objClass.Batchid;
            res.RefNo = result.RefNo;
            if (result != null && result.Result)
            {
                res.ResCode = "700";
                res.ResMsg = result.MsgType;
                res.Reason = result.Reason;
                return res;
            }
            else
            {
                res.ResCode = "0";
                res.ResMsg = result.Reason;
                res.Reason = result.Reason;
                return res;
            }

        }

        private M2PEntityCheckAPIResponse EntityCheckAPI(TransactionSalebyTerminalModelInput objClass, string M2PCustomer, string PartnerCustomerId, int RequestId)
        {
            // EntityCheckAPIRequestModelOutput result = new EntityCheckAPIRequestModelOutput();
            M2PEntityCheckAPIResponse res = new M2PEntityCheckAPIResponse();


            M2PEntityCheckAPIRequest Req = new M2PEntityCheckAPIRequest() { CardNumber = objClass.Cardno, M2PCustomerId = M2PCustomer, PartnerCustomerId = PartnerCustomerId, Username = UserName, Password = ApiPassword };

            HttpResponseMessage apiResponse = null;
            string responseapi = string.Empty;

            try
            {
                apiResponse = Variables.CallAPI(serviceUrl + "entitycheck", JsonConvert.SerializeObject(Req), "").Result;

                responseapi = apiResponse.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrEmpty(responseapi))
                {
                    res = JsonConvert.DeserializeObject<M2PEntityCheckAPIResponse>(responseapi);



                }


            }
            catch (Exception ex)
            {
                responseapi = "Error in EntityCheckAPI ::" + ex.Message;
            }
            if (res != null && res.result!=true)
            {
                M2PApiRequestResponseModelInput reqres = new M2PApiRequestResponseModelInput()
                {
                    MerchantID = objClass.Merchantid,
                    TerminalID = objClass.Terminalid,
                    RqId = RequestId,
                    ApiRequest = JsonConvert.SerializeObject(Req),
                    ApiRequestUrL = serviceUrl + "entitycheck",
                    ApiResponse = responseapi,
                    CreatedBy = objClass.Userid,
                    DTPCustomerID = PartnerCustomerId,
                    ReqAmount = "",
                    ReqCardNo = objClass.Cardno,
                    ReqTxnId = "",
                    ResTxnId = "",
                    ResAvailableLimit = res.AvailableLimit,
                    ResMsgType = "",
                    ResMsg = "",
                    ResErrorReason = res.exception == null ? "" : res.exception.detailMessage,
                    M2PCustomerID = M2PCustomer,
                    ResCardNumber = "",
                    DetailMessage = res.exception == null ?"": res.exception.detailMessage,
                    ErrorCode = res.exception == null ? "" : res.exception.errorCode,
                    ShortMessage = res.exception == null ? "" : res.exception.shortMessage,
                    Result = res.result.ToString()

                };
                _M2PRepo.InsertM2PApiRequestResponseDetail(reqres);
            }
            else
            {
                UpdateM2PRequestInput ObjupdateRq = new UpdateM2PRequestInput();
                ObjupdateRq.Remarks = "";
                ObjupdateRq.ModifiedBy = objClass.Userid;
                ObjupdateRq.RequestId = RequestId;
                ObjupdateRq.EntityCheckAPIRequest = JsonConvert.SerializeObject(Req);
                ObjupdateRq.EntityCheckAPIRequest = responseapi;
                _M2PRepo.UpdateM2PApiRequest(ObjupdateRq);
            }
            return res;

        }


        private M2PCreditLimitAuthorizationModelOutput CreditLimitAuthorization(TransactionSalebyTerminalModelInput objClass)
        {
            int RequestID = 0;
            string TxnTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            M2PApiRequestResponseModelInput reqres = new M2PApiRequestResponseModelInput();
            M2PCreditLimitAuthorizationModelOutput result = new M2PCreditLimitAuthorizationModelOutput();
            try
            {


                M2PApiRequestModelInput LogReq = new M2PApiRequestModelInput()

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
                    Paymentmode = "5",
                    Gatewayname = "M2P",
                    Bankname = "M2P",
                    Paycode = ""
                };


                var Reqres = _M2PRepo.InsertM2PFastagApiRequest(LogReq).Result;

                if (Reqres != null && Reqres.Count() > 0)
                {
                    RequestID = Reqres.Cast<M2PApiRequestModelOutput>().ToList()[0].RequestId;

                    if (RequestID > 0 && Reqres.Cast<M2PApiRequestModelOutput>().ToList()[0].Status != 1)
                    {
                        M2PCreditLimitAuthorizationModelOutput res = new M2PCreditLimitAuthorizationModelOutput();
                        int status_Code = Reqres.Cast<M2PApiRequestModelOutput>().ToList()[0].Status;
                        if (status_Code == (int)ValidationStatus.Terminal_Not_Active)
                            res = new M2PCreditLimitAuthorizationModelOutput() { MsgType = Convert.ToString((int)IdfcApiStatus.Terminal_Not_Active), Reason = Reqres.Cast<M2PApiRequestModelOutput>().ToList()[0].Reason };

                        else if (status_Code == (int)ValidationStatus.Merchant_Not_Active)
                        {
                            res = new M2PCreditLimitAuthorizationModelOutput() { MsgType = Convert.ToString((int)IdfcApiStatus.Merchant_Not_Active), Reason = Reqres.Cast<M2PApiRequestModelOutput>().ToList()[0].Reason };

                        }
                        else if (status_Code == (int)ValidationStatus.Amount_lessthen_ccms)
                        {
                            res = new M2PCreditLimitAuthorizationModelOutput() { MsgType = Convert.ToString((int)IdfcApiStatus.Amount_lessthen_ccms), Reason = Reqres.Cast<M2PApiRequestModelOutput>().ToList()[0].Reason };
                        }
                        ///Update Request Table For failure
                        return res;
                    }
                }



                M2PCheckCardLimitValidationforAPIInput objreq = new M2PCheckCardLimitValidationforAPIInput()
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
                var checkbalance = _M2PRepo.M2PCheckCardLimitValidationforAPI(objreq).Result;
                if (checkbalance == null || checkbalance.Cast<M2PCheckCardLimitValidationforAPIOutput>().ToList()[0].Status == 0)
                {
                    UpdateM2PRequestInput ObjupdateRq = new UpdateM2PRequestInput();
                    ObjupdateRq.Remarks = checkbalance.Cast<CheckM2PInvoiceIdBatchIdExistOutput>().ToList()[0].Reason;
                    ObjupdateRq.ModifiedBy = objClass.Userid;
                    ObjupdateRq.RequestId = RequestID;
                    _M2PRepo.UpdateM2PApiRequest(ObjupdateRq);

                    return new M2PCreditLimitAuthorizationModelOutput() { MsgType = "Failure", Reason = ObjupdateRq.Remarks };

                }
                if (string.IsNullOrEmpty(objClass.Cardno))
                {
                    objClass.Cardno = checkbalance.Cast<M2PCheckCardLimitValidationforAPIOutput>().ToList()[0].CardNumber;
                }
                var objgetCustomer = _M2PRepo.GetM2PCustomerIdByCard(objClass.Cardno).Result;
                string CustomerId = string.Empty;
                if (objgetCustomer == null || (objgetCustomer.Count() > 0 && objgetCustomer.Cast<GetM2PCustomerIdByCardOutput>().ToList()[0].Status == 0))
                {
                    result.MsgType = "Failure";
                    result.Result = false;
                    result.Reason = objgetCustomer.Cast<GetM2PCustomerIdByCardOutput>().ToList()[0].Reason;

                    return result;
                }
                else
                {
                    CheckM2PInvoiceIdBatchIdExistInput obj = new CheckM2PInvoiceIdBatchIdExistInput() { Batchid = objClass.Batchid, Invoiceid = objClass.Invoiceid, RecordType = 1, MerchantID = objClass.Merchantid, TerminalID = objClass.Terminalid, UserId = objClass.Userid, TransTypeId = objClass.Transtype };
                    var checkInvoiceidExist = _M2PRepo.CheckM2PInvoiceIdBatchIdExist(obj).Result;
                    if (checkInvoiceidExist == null || checkInvoiceidExist.Cast<CheckM2PInvoiceIdBatchIdExistOutput>().ToList()[0].Status == 1)
                    {
                        UpdateM2PRequestInput ObjupdateRq = new UpdateM2PRequestInput();
                        ObjupdateRq.Remarks = checkInvoiceidExist.Cast<CheckM2PInvoiceIdBatchIdExistOutput>().ToList()[0].Reason;
                        ObjupdateRq.ModifiedBy = objClass.Userid;
                        ObjupdateRq.RequestId = RequestID;
                        _M2PRepo.UpdateM2PApiRequest(ObjupdateRq);
                        return new M2PCreditLimitAuthorizationModelOutput() { MsgType = Convert.ToString((int)IdfcApiStatus.InvoiceId_BatchId_Exist),Reason = checkInvoiceidExist.Cast<CheckM2PInvoiceIdBatchIdExistOutput>().ToList()[0].Reason };

                    }
                    CustomerId = objgetCustomer.Cast<GetM2PCustomerIdByCardOutput>().ToList()[0].CustomerId;
                    //M2PEntityCheckAPIRequest objReq = new M2PEntityCheckAPIRequest() { CardNo = objClass.CardNo, DTPCustomerId = CustomerId };
                    M2PEntityCheckAPIResponse objresult = EntityCheckAPI(objClass, M2PCustomerId,CustomerId,  RequestID);
                    string txnid = StaticClass.APIReferenceNo;
                    if (objresult != null && objresult.result )

                    {


                        M2PCreaditAuthAPIRequest creditAuthRequest = new M2PCreaditAuthAPIRequest()
                        {
                            Username = UserName,
                            Password = ApiPassword,
                            CardNumber = objClass.Cardno,
                            M2PCustomerId = M2PCustomerId,
                            PartnerCustomerId = CustomerId,                           
                            RefrenceNumber = txnid,
                            TransactionAmount =objClass.Invoiceamount.ToString(),
                            TransactionDate = TxnTime,
                            

                        };
                        HttpResponseMessage apiResponse = null;
                        string responseapi = string.Empty;



                        try
                        {
                            apiResponse = Variables.CallAPI(serviceUrl + "creditlimitauth", JsonConvert.SerializeObject(creditAuthRequest), "").Result;

                            responseapi = apiResponse.Content.ReadAsStringAsync().Result;
                            if (!string.IsNullOrEmpty(responseapi))
                            {
                                M2PCreaditAuthAPIResponse objM2P = new M2PCreaditAuthAPIResponse();
                                // var val = AESEncrytDecry.DecryptStringAES(responseapi, DeCryptKey, DeCryptIV);
                                 objM2P = JsonConvert.DeserializeObject<M2PCreaditAuthAPIResponse>(responseapi);
                                result.Result = objM2P.result;
                                result.DetailMessage = objM2P.exception==null?"": objM2P.exception.detailMessage;
                                result.ShortMessage = objM2P.exception == null ? "" : objM2P.exception.shortMessage;
                                result.ErrorCode = objM2P.exception == null ? "" : objM2P.exception.errorCode;
                                
                            }

                        }

                        catch (Exception ex)
                        {
                            responseapi = ex.Message;

                        }

                        reqres = new M2PApiRequestResponseModelInput()
                        {
                            RqId = RequestID,
                            ApiRequest = JsonConvert.SerializeObject(creditAuthRequest),
                            ApiRequestUrL = serviceUrl + "creditlimitauth",
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
                            ResErrorReason = result.DetailMessage,
                            M2PCustomerID = result.M2PCustomerID,
                            ResCardNumber = result.CardNumber,
                            DetailMessage= result.DetailMessage,
                            ErrorCode= result.ErrorCode,
                            ShortMessage=result.ShortMessage,
                            Result= result.Result.ToString()


                        };

                        if (result != null && result.Result==true)

                        {
                            objClass.Paymentmode = "5";
                            objClass.Bankname = "M2P";
                            result.RefNo = txnid;
                            result.CardNumber = objClass.Cardno;
                            result.DTPCustomerID = CustomerId;
                            result.M2PCustomerID =M2PCustomerId;
                            var UpdateCCMSBAlanceResult = _transRepo.SaleByTerminal(objClass).Result;//_M2PRepo.UpdateCCMSBAlanceForM2PCustomer(objClass, txnid, CustomerId).Result;
                            if (UpdateCCMSBAlanceResult != null && UpdateCCMSBAlanceResult.Count() > 0)
                            {
                                result.RSP = UpdateCCMSBAlanceResult.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].RSP;
                                result.Volume = UpdateCCMSBAlanceResult.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].Volume;
                                
                                if (UpdateCCMSBAlanceResult != null && UpdateCCMSBAlanceResult.Count() > 0 && UpdateCCMSBAlanceResult.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].Status == 1)
                                {
                                    reqres.Remarks = "Payment Process Successfully " + UpdateCCMSBAlanceResult.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].Reason;
                                    reqres.IsPaymentSuccess = 1;
                                    _M2PRepo.InsertM2PApiRequestResponseDetail(reqres);
                                    result.Reason = "Transaction Success";
                                }
                                else
                                {
                                    reqres.Remarks = "Payment Failed due to CCMCBalance Not Updated in DB. " + UpdateCCMSBAlanceResult.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].Reason;
                                    _M2PRepo.InsertM2PApiRequestResponseDetail(reqres);

                                    result.MsgType = "Failure";
                                    result.Reason = "CCMCBalance Not Updated in DB";
                                    result.Reason = UpdateCCMSBAlanceResult.Cast<TransactionSalebyTerminalModelOutput>().ToList()[0].Reason;
                                }
                            }

                        }
                        else
                        {
                            reqres.Remarks = "Payment failed from M2P API";
                            _M2PRepo.InsertM2PApiRequestResponseDetail(reqres);

                            return result;
                        }


                    }
                    else
                    {

                        result.MsgType = objresult.result?"Success":"Failure";
                        result.Reason = objresult.exception == null?"": objresult.exception.detailMessage;
                    }

                }


            }
            catch (Exception ex)
            {
                reqres.Remarks = "Error :: " + ex.Message;
                if (RequestID > 0)
                {

                    _M2PRepo.InsertM2PApiRequestResponseDetail(reqres);


                }
                result.MsgType = "Failure";
                result.Reason = "Error :: " + IdfcApiStatus.Unhandeled_Exception.GetDisplayName();

            }

            return result;
        }


        [HttpPost]
        [Route("m2p_transaction_reversal")]
        public M2PTransactionReversalModelOutput M2PTransactionReversalAPI(M2PTransactionReversalModelInput ObjClass)
        {
            int RequestID = 0;
            M2PTransactionReversalModelOutput result = new M2PTransactionReversalModelOutput();
            M2PApiRequestResponseModelInput objReqRes = new M2PApiRequestResponseModelInput();
            try
            {

                M2PApiRequestModelInput LogReq = new M2PApiRequestModelInput()

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
                    Sourceid = ObjClass.Sourceid,
                    Formfactor = ObjClass.Formfactor,
                    DCSTokenNo = ObjClass.DCSTokenNo,
                    Stan = ObjClass.Stan,
                    Paymentmode = "5",
                    Gatewayname = "M2P",
                    Bankname = "M2P",
                    Paycode = ""
                };


                var Reqres = _M2PRepo.InsertM2PFastagApiRequest(LogReq).Result;
                if (Reqres != null && Reqres.Count() > 0)
                {
                    RequestID = Reqres.Cast<M2PApiRequestModelOutput>().ToList()[0].RequestId;

                    if (RequestID > 0 && Reqres.Cast<M2PApiRequestModelOutput>().ToList()[0].Status != 1)
                    {
                        // result = new STFCTransactionReversalModelOutput();
                        int status_Code = Reqres.Cast<M2PApiRequestModelOutput>().ToList()[0].Status;
                        if (status_Code == (int)ValidationStatus.Terminal_Not_Active)
                            result = new M2PTransactionReversalModelOutput() { MsgType = Convert.ToString((int)IdfcApiStatus.Terminal_Not_Active), Reason = Reqres.Cast<M2PApiRequestModelOutput>().ToList()[0].Reason };

                        else if (status_Code == (int)ValidationStatus.Merchant_Not_Active)
                        {
                            result = new M2PTransactionReversalModelOutput() { MsgType = Convert.ToString((int)IdfcApiStatus.Merchant_Not_Active), Reason = Reqres.Cast<M2PApiRequestModelOutput>().ToList()[0].Reason };

                        }
                        else if (status_Code == (int)ValidationStatus.Amount_lessthen_ccms)
                        {
                            result = new M2PTransactionReversalModelOutput() { MsgType = Convert.ToString((int)IdfcApiStatus.Amount_lessthen_ccms),Reason = Reqres.Cast<M2PApiRequestModelOutput>().ToList()[0].Reason };
                        }
                        ///Update Request Table For failure
                        UpdateM2PRequestInput ObjupdateRq = new UpdateM2PRequestInput();
                        ObjupdateRq.Remarks = result.Reason;
                        ObjupdateRq.ModifiedBy = ObjClass.Userid;
                        ObjupdateRq.RequestId = RequestID;
                        _M2PRepo.UpdateM2PApiRequest(ObjupdateRq);

                    }

                    else
                    {
                       
                        string info = ObjClass.TxnRefId;
                        string txnid = StaticClass.APIReferenceNo;

                        M2PTransactionReversalRequest objRefundReq = new M2PTransactionReversalRequest()
                        {
                            Password = ApiPassword,
                            Username = UserName,
                            RefrenceNumber = ObjClass.TxnRefId
                        };
                        HttpResponseMessage apiResponse = null;
                        string responseapi = string.Empty;
                        try
                        {
                            var objrefund = _M2PRepo.CheckRefundProcessedForM2PCustomer(ObjClass).Result;
                            if (objrefund != null && objrefund.Count() > 0 && objrefund.Cast<M2PTransactionReversalModelOutput>().ToList()[0].Status == 1)
                            {
                                var res = objrefund.Cast<M2PTransactionReversalModelOutput>().ToList()[0];
                                result.MsgType = res.MsgType;
                                result.Reason = res.Reason;
                                return result;
                            }

                            apiResponse = Variables.CallAPI(serviceUrl + "reversetransaction", JsonConvert.SerializeObject(objRefundReq), "").Result;

                            responseapi = apiResponse.Content.ReadAsStringAsync().Result;
                            if (!string.IsNullOrEmpty(responseapi))
                            {
                                M2PTransactionReversalResponse objM2P = new M2PTransactionReversalResponse();
                                objM2P = JsonConvert.DeserializeObject<M2PTransactionReversalResponse>(responseapi);

                                result.Result = objM2P.result;
                                result.DetailMessage = objM2P.exception == null ? "" : objM2P.exception.detailMessage;
                                result.ShortMessage = objM2P.exception == null ? "" : objM2P.exception.shortMessage;
                                result.ErrorCode = objM2P.exception == null ? "" : objM2P.exception.errorCode;

                            }

                        }

                        catch (Exception ex)
                        {
                            responseapi = ex.Message;
                        }
                        
                        objReqRes = new M2PApiRequestResponseModelInput()
                        {
                            RqId = RequestID,
                            ApiRequest = JsonConvert.SerializeObject(objRefundReq),
                            ApiRequestUrL = serviceUrl + "reversetransaction",
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
                            ResErrorReason = result.Reason,
                            M2PCustomerID = "",
                            ResCardNumber = "",

                        };

                        if (!string.IsNullOrEmpty(result.MsgType) && result.MsgType.ToString().ToUpper() == "SUCCESS")
                        {
                            var objresult = _M2PRepo.RefundCCMSBAlanceForM2PCustomer(ObjClass).Result;
                            if (objresult != null && objresult.Count() > 0 && objresult.Cast<UpdateCCMSBAlanceForM2PCustomer>().ToList()[0].Status == 1)
                            {
                                objReqRes.Remarks = "Refund Process Successfully " + objresult.Cast<UpdateCCMSBAlanceForM2PCustomer>().ToList()[0].Reason;
                                objReqRes.IsRefundSuccess = 1;
                                _M2PRepo.M2PUpdateRequestResponseDetailRefundStatus(ObjClass);
                                result.Reason = "Transaction Success";                               //return result;
                            }

                            else
                            {
                                objReqRes.Remarks = "Refund Failed " + objresult.Cast<UpdateCCMSBAlanceForM2PCustomer>().ToList()[0].Reason;
                                objReqRes.IsRefundSuccess = 0;

                                result.Reason = "Transaction Failed";
                                result.MsgType = "Failure";

                            }
                        }

                        _M2PRepo.InsertM2PApiRequestResponseDetail(objReqRes);
                        return result;
                    }

                }

            }
            catch (Exception ex)
            {
                objReqRes.Remarks = "Error :: " + ex.Message;
                _M2PRepo.InsertM2PApiRequestResponseDetail(objReqRes);
                result.Reason = IdfcApiStatus.Unhandeled_Exception.GetDisplayName();
                result.MsgType = "Failure";

            }
            return result;
        }
    }

}
