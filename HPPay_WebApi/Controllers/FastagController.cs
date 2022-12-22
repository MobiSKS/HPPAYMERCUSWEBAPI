using HPPay.DataModel.IdfcAPI;
using HPPay.DataRepository.IdfcAPI;
using HPPay.Infrastructure.CommonClass;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using HPPay.DataModel.IciciAPI;
using HPPay.DataRepository.IciciAPI;
using System.Net;
using HPPay.DataRepository.DBDapper;
using System.Collections.Generic;
using HPPay.DataModel;

namespace HPPay_WebApi.Controllers
{
    [Route("api/hppay/Fastag")]
    [ApiController]
    public class FastagController : ControllerBase
    {

        private readonly ILogger<FastagController> _logger;

        private readonly IIdfcApiRepository _idfcRepo;
        private readonly IConfiguration _configuration;
        private readonly IIciciApiRepository _iciciRepo;
        string idfc_apiurl;
        string idfc_EntityId;
        string idfc_POSID;
        string idfc_IIN;

        string icici_apiurl;
        string icici_EntityId;
        string icici_POSID;
        string icici_IIN;
        string icici_APIClient_ID;
        string icici_API_KEY;

        public FastagController(ILogger<FastagController> logger, IIdfcApiRepository idfcRepo, IIciciApiRepository iciciRepo, IConfiguration configuration)
        {
            _logger = logger;
            _idfcRepo = idfcRepo;
            _configuration = configuration;
            _iciciRepo = iciciRepo;
            idfc_apiurl = _configuration.GetSection("IDFCAPISettings:APIUrl").Value.ToString();
            idfc_EntityId = _configuration.GetSection("IDFCAPISettings:EntityId").Value.ToString();
            idfc_POSID = _configuration.GetSection("IDFCAPISettings:POSID").Value.ToString();
            idfc_IIN = _configuration.GetSection("IDFCAPISettings:IIN").Value.ToString();

            icici_apiurl = _configuration.GetSection("ICICIAPISettings:APIUrl").Value.ToString();
            icici_EntityId = _configuration.GetSection("ICICIAPISettings:EntityId").Value.ToString();
            icici_POSID = _configuration.GetSection("ICICIAPISettings:POSID").Value.ToString();
            icici_IIN = _configuration.GetSection("ICICIAPISettings:IIN").Value.ToString();
            icici_API_KEY = _configuration.GetSection("ICICIAPISettings:API_KEY").Value.ToString();
            icici_APIClient_ID = _configuration.GetSection("ICICIAPISettings:APIClient_ID").Value.ToString();
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("fastag_get_otp")]
        public async Task<IActionResult> FasTagGetOTP([FromBody] FastagGetOtpRequest ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                FasTagOtpResponse result = new FasTagOtpResponse();
                if (ObjClass.Invoiceamount <= 0)
                {
                    result = new FasTagOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.Amount_Zero), ResMsg = "Amount must be greater then zero",Reason= "Amount must be greater then zero" };
                    return this.FailCustom(ObjClass, result, _logger, "");
                }
                if (ObjClass.BankID == (int)BankName.ICICI)
                {
                    result = IciciGetOTP(ObjClass);
                }
                else if (ObjClass.BankID == (int)BankName.IDFC)
                {
                    result = IdfcGetOTP(ObjClass);
                    //call
                }
                if (result != null && String.IsNullOrEmpty(result.Reason))
                {
                    result.Reason = result.ResMsg ?? string.Empty;
                }
                if (result != null && result.ResCode == Convert.ToString((int)IdfcApiStatus.Success))
                {
                    
                    return this.OkCustom(ObjClass, result, _logger);
                }
                else
                {
                    
                    return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("fastag_confirm_otp")]
        public async Task<IActionResult> FasTagConfirmOTP([FromBody] FastagConfirmOtpReQuest ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                FasTagConfirmOtpResponse result = new FasTagConfirmOtpResponse();
                if (ObjClass.Invoiceamount <= 0)
                {
                    result = new FasTagConfirmOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.Amount_Zero), ResMsg = "Amount must be greater then zero" ,Reason= "Amount must be greater then zero" };
                    result.Invoiceid = ObjClass.Invoiceid;
                    result.Batchid = ObjClass.Batchid;
                    return this.FailCustom(ObjClass, result, _logger, "");
                }

                if (ObjClass.BankID == (int)BankName.ICICI)
                {
                    result = IciciConfirmOTPandPayment(ObjClass);
                }
                else if (ObjClass.BankID == (int)BankName.IDFC)
                {
                    result = IdfcConfirmOTP(ObjClass);
                    //call
                }
                if (result != null && (result.ResCode == Convert.ToString((int)IdfcApiStatus.Success) || result.ResCd == Convert.ToString((int)IdfcApiStatus.Success)))
                {
                    if (String.IsNullOrEmpty(result.ResCode))
                    {
                        result.ResCode = result.ResCd;
                    }

                    if (String.IsNullOrEmpty(result.Reason))
                    {
                        result.Reason = result.ResMsg;
                    }
                    result.Invoiceid = ObjClass.Invoiceid;
                    result.Batchid = ObjClass.Batchid;
                    if (result.ResCode == Convert.ToString((int)IdfcApiStatus.Success))
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, "");
                    }
                }
                else
                {
                    if (result != null && String.IsNullOrEmpty(result.Reason))
                    {
                        result.Reason = result.ResMsg ?? string.Empty;
                    }
                    result.Invoiceid = ObjClass.Invoiceid;
                    result.Batchid = ObjClass.Batchid;
                    return this.FailCustom(ObjClass, result, _logger, "");
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("fastag_refund_payment")]
        public async Task<IActionResult> FastagRefundPayment([FromBody] FastagRefundPaymentReQuest ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                FastagRefundResponse result = new FastagRefundResponse();


                if (ObjClass.BankID == (int)BankName.ICICI)
                {
                    // return new HttpResponseMessage(HttpStatusCode.GatewayTimeout);
                    result = IciciRefundAPiCall(ObjClass);
                }
                else if (ObjClass.BankID == (int)BankName.IDFC)
                {
                    result = IDfcRefundAPiCall(ObjClass);
                }
                if (result != null && result.resCode == Convert.ToString((int)IdfcApiStatus.Success))
                {
                    result.Invoiceid = ObjClass.Invoiceid;
                    result.Batchid = ObjClass.Batchid;
                    return this.OkCustom(ObjClass, result, _logger);
                }
                else
                {
                    result.Invoiceid = ObjClass.Invoiceid;
                    result.Batchid = ObjClass.Batchid;
                    return this.FailCustom(ObjClass, result, _logger, "");
                }

            }
        }
        private FasTagOtpResponse IdfcGetOTP([FromBody] FastagGetOtpRequest ObjClass)
        {
            int RequestID = 0;
            ///Add Amount > 0 Validation 
            decimal Discount = Convert.ToDecimal(_configuration.GetSection("IDFCAPISettings:Discount").Value.ToString());
            decimal DiscountAmount = Convert.ToDecimal(string.Format("{0:00.00}", ObjClass.Invoiceamount * Discount / 100));
            decimal NetAmount = Convert.ToDecimal(string.Format("{0:00.00}", (ObjClass.Invoiceamount - DiscountAmount)));

            InsertFastagIdfcApiRequestInput ObjRq = new InsertFastagIdfcApiRequestInput()
            { BankID = ObjClass.BankID, MobileNo = ObjClass.Mobileno, Amount = Convert.ToString(ObjClass.Invoiceamount), Vrn = ObjClass.Vehicleno, CreatedBy = ObjClass.Userid, Remarks = "", ApiRequestUrL = "GetOTP", DiscountAmount = string.Format("{0:00.00}", DiscountAmount), NetAmount = string.Format("{0:00.00}", NetAmount), MerchantID = ObjClass.Merchantid, TerminalID = ObjClass.Terminalid };


            var Reqres = _idfcRepo.InsertIdfcFastagApiRequest(ObjRq).Result;



            if (Reqres != null && Reqres.Count() > 0)
            {
                RequestID = Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].RequestId;

                if (RequestID > 0 && Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].Status != 1)
                {
                    FasTagOtpResponse res = new FasTagOtpResponse();
                    int status_Code = Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].Status;
                    if (status_Code == (int)ValidationStatus.Terminal_Not_Active)
                    {
                        res = new FasTagOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.Terminal_Not_Active), ResMsg = Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].Reason };
                        res.Reason = "Transaction Not Allowed";
                    }
                    else if (status_Code == (int)ValidationStatus.Merchant_Not_Active)
                    {
                        res = new FasTagOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.Merchant_Not_Active), ResMsg = Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].Reason };
                        res.Reason = "Transaction Not Allowed";
                    }
                    else if (status_Code == (int)ValidationStatus.Amount_lessthen_ccms)
                    {
                        res = new FasTagOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.Amount_lessthen_ccms), ResMsg = Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].Reason };
                        res.Reason = "Insufficient Credit Limit";
                    }
                    else if (status_Code == (int)ValidationStatus.Amount_lessthen_ccms)
                    {
                        res = new FasTagOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.Amount_lessthen_ccms), ResMsg = Reqres.Cast<InsertFastagIciciApiRequestOutput>().ToList()[0].Reason };
                        res.Reason = "Transaction Not Allowed";
                    }
                    return res;
                }
                else
                {

                    string TxnTime = DateTime.Now.ToString("ddMMyyyyHHmmss");
                    string txnId = StaticClass.APIReferenceNo; //"idfc" + Variables.GetUniqueNumber();
                    string ConcatenatedStringOFParams = CreateRawString(_configuration.GetSection("IDFCAPISettings:SecureToken").Value.ToString(), string.Format("{0:00.00}", ObjClass.Invoiceamount), idfc_EntityId, idfc_POSID, txnId, TxnTime, ObjClass.Vehicleno, "", ObjClass.Mobileno, String.Format("{0:00.00}", NetAmount), String.Format("{0:00.00}", DiscountAmount), idfc_IIN);
                    string CreateHashKeyByHPPay = ComputeSha256Hash(ConcatenatedStringOFParams);
                    IdfcAPIGetOtpRequest req = new IdfcAPIGetOtpRequest()
                    { amount = string.Format("{0:00.00}", ObjClass.Invoiceamount), chkSm = CreateHashKeyByHPPay, discount = string.Format("{0:00.00}", DiscountAmount), entityId = idfc_EntityId, iin = idfc_IIN, mobileNo = ObjClass.Mobileno, netAmount = String.Format("{0:00.00}", NetAmount), posId = idfc_POSID, tagId = "", txnId = txnId, txnTime = TxnTime, vrn = ObjClass.Vehicleno };

                    string authIdPwd = _configuration.GetSection("IDFCAPISettings:UserName").Value.ToString() + ":" + _configuration.GetSection("IDFCAPISettings:Password").Value.ToString();

                    HttpResponseMessage apiResponse;
                    string responseapi = string.Empty;
                    try
                    {
                        apiResponse = Variables.CallAPI(idfc_apiurl + "HPPay/getotp", JsonConvert.SerializeObject(req), authIdPwd).Result;
                        responseapi = apiResponse.Content.ReadAsStringAsync().Result;


                        IdfcApiRequestResponseInput ObjReq = new IdfcApiRequestResponseInput() { ApiRequestUrL = idfc_apiurl + "HPPay/getotp", ApiRequest = JsonConvert.SerializeObject(req), ApiResponse = responseapi, CreatedBy = ObjClass.Userid, Remarks = "Get Otp Call" };
                        // var rqres = _idfcRepo.InsertIdfcApiRequestResponse(ObjReq).Result;
                        string json = string.Empty;
                        //int rqID = 0;
                        //if (rqres != null && rqres.Count() > 0)
                        //{
                        //    rqID = rqres.Cast<IdfcApiRequestResponseOutput>().ToList()[0].Id;
                        //}

                        json = apiResponse.Content.ReadAsStringAsync().Result;

                        if (apiResponse != null && apiResponse.IsSuccessStatusCode)
                        {
                            json = apiResponse.Content.ReadAsStringAsync().Result;
                        }
                        FasTagOtpResponse result = new FasTagOtpResponse();
                        if (!string.IsNullOrEmpty(json))
                        {
                            result = JsonConvert.DeserializeObject<FasTagOtpResponse>(json);
                            result.txnTime = TxnTime;
                        }
                        IdfcApiRequestResponseDetailInput objReqRes = new IdfcApiRequestResponseDetailInput()
                        {
                            RqId = RequestID,
                            ApiRequestUrL = idfc_apiurl + "HPPay/getotp",
                            ApiRequest = JsonConvert.SerializeObject(req),
                            ApiResponse = apiResponse.Content.ReadAsStringAsync().Result,
                            CreatedBy = ObjClass.Userid,
                            Remarks = "",
                            ReqAmount = req.amount,
                            ReqChkSm = req.chkSm,
                            ReqDiscount = req.discount,
                            ReqEntityId = req.entityId,
                            ReqIIN = req.iin,
                            ReqMobileNo = req.mobileNo,
                            ReqNetAmount = req.netAmount,
                            ReqOrgTxnId = "",
                            ReqOrgTxnTime = "",
                            ReqOtp = "",
                            ReqPosId = req.posId,
                            ReqTxnId = req.txnId,
                            ReqTxnTime = req.txnTime,
                            ReqVrn = req.vrn,
                            ResCode = result.ResCode,
                            ResMsg = result.ResMsg,
                            RestagId = result.TagId,
                            ResTxnId = result.TxnId,
                            vrn = result.Vrn,
                            ResTxnNo = result.TxnNo,
                        };
                        _idfcRepo.InsertIdfcApiRequestResponseDetail(objReqRes);
                        return result;
                    }
                    catch (Exception ex)
                    {

                        responseapi = ex.Message;
                        //IdfcApiRequestResponseInput ObjReq = new IdfcApiRequestResponseInput() { ApiRequestUrL = idfc_apiurl + "HPPay/getotp", ApiRequest = JsonConvert.SerializeObject(req), ApiResponse = responseapi, CreatedBy = ObjClass.Userid, Remarks = "Get Otp Call" };
                        // var rqres = _idfcRepo.InsertIdfcApiRequestResponse(ObjReq).Result;


                        if (RequestID > 0)
                        {
                            UpdateFastagIdfcApiRequestInput ObjupdateRq = new UpdateFastagIdfcApiRequestInput();
                            ObjupdateRq.Remarks = responseapi;
                            ObjupdateRq.ModifiedBy = ObjClass.Userid;
                            ObjupdateRq.RequestId = RequestID;
                            _idfcRepo.UpdateIdfcFastagApiRequest(ObjupdateRq);
                        }
                        else
                        {
                            ObjRq.Remarks = responseapi;
                            var Rqrs = _idfcRepo.InsertIdfcFastagApiRequest(ObjRq).Result;
                        }
                        FasTagOtpResponse res = new FasTagOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.None), ResMsg = responseapi };
                        return res;

                    }

                }

            }
            FasTagOtpResponse res1 = new FasTagOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.Unhandeled_Exception), ResMsg = "Unhandeled Exception Occur", Reason = "Unhandeled Exception Occur" };
            return res1;
        }







        private FasTagConfirmOtpResponse IdfcConfirmOTP([FromBody] FastagConfirmOtpReQuest ObjClass)
        {
            FasTagConfirmOtpResponse res = new FasTagConfirmOtpResponse();

            decimal Discount = Convert.ToDecimal(_configuration.GetSection("IDFCAPISettings:Discount").Value.ToString());
            decimal DiscountAmount = Convert.ToDecimal(String.Format("{0:00.00}", ObjClass.Invoiceamount * Discount / 100));
            decimal NetAmount = Convert.ToDecimal(String.Format("{0:00.00}", (ObjClass.Invoiceamount - DiscountAmount)));
            string CreateHashKeyByHPPay = String.Empty;

            int RequestID = 0;
            InsertFastagIdfcApiRequestInput ObjRq = new InsertFastagIdfcApiRequestInput()
            {
                BankID = ObjClass.BankID,
                MobileNo = ObjClass.Mobileno,
                Amount = Convert.ToString(ObjClass.Invoiceamount),
                Vrn = ObjClass.Vehicleno,
                CreatedBy = ObjClass.Userid,
                Remarks = "",
                ApiRequestUrL = "ConfirmOTP",
                DiscountAmount = string.Format("{0:00.00}", DiscountAmount),
                NetAmount = string.Format("{0:00.00}", NetAmount)
            ,
                MerchantID = ObjClass.Merchantid,
                TerminalID = ObjClass.Terminalid,
                TxnId = ObjClass.TxnRefId,
                TxnTime = ObjClass.TxnTime,
                OTP = ObjClass.OTP,
                TagId = ObjClass.TagId,
                TxnNo = ObjClass.TxnNo,
                Invoicedate = ObjClass.Invoicedate,
                Productid = ObjClass.Productid,
                Odometerreading = ObjClass.Odometerreading,
                TransType = ObjClass.TransType,
                Sourceid = ObjClass.Sourceid,
                Formfactor = ObjClass.Formfactor,
                DCSTokenNo = ObjClass.DCSTokenNo,
                Stan = ObjClass.Stan,
                Paymentmode = ObjClass.BankID.ToString(),
                Gatewayname = "IDFC",
                Bankname = "IDFC",
                Paycode = ""
            };

            var Reqres = _idfcRepo.InsertIdfcFastagApiRequest(ObjRq).Result;



            if (Reqres != null && Reqres.Count() > 0)
            {
                RequestID = Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].RequestId;
                if (RequestID > 0 && Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].Status == 0)
                {
                    res = new FasTagConfirmOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.Amount_Zero), ResMsg = Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].Reason };
                    return res;
                }
                else
                {
                    IdfcCheckFastagInvoiceIdBatchIdExistInput obj = new IdfcCheckFastagInvoiceIdBatchIdExistInput() { Batchid = ObjClass.Batchid, Invoiceid = ObjClass.Invoiceid, RecordType = 1, MerchantID = ObjClass.Merchantid, TerminalID = ObjClass.Terminalid, UserId = ObjClass.Userid,UserAgent= ObjClass .Useragent};
                    var checkInvoiceidExist = _idfcRepo.CheckFastagInvoiceIdBatchIdExist(obj).Result;
                    if (checkInvoiceidExist == null || checkInvoiceidExist.Cast<IdfcCheckFastagInvoiceIdBatchIdExistOutput>().ToList()[0].Status == 1)
                    {
                        UpdateFastagIdfcApiRequestInput ObjupdateRq = new UpdateFastagIdfcApiRequestInput();
                        ObjupdateRq.Remarks = checkInvoiceidExist.Cast<IdfcCheckFastagInvoiceIdBatchIdExistOutput>().ToList()[0].Reason;
                        ObjupdateRq.ModifiedBy = ObjClass.Userid;
                        ObjupdateRq.RequestId = RequestID;
                        _idfcRepo.UpdateIdfcFastagApiRequest(ObjupdateRq);
                        return new FasTagConfirmOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.InvoiceId_BatchId_Exist), ResMsg = IdfcApiStatus.InvoiceId_BatchId_Exist.GetDisplayName(), Reason = ObjupdateRq.Remarks };

                    }

                    string ConcatenatedStringOFParams = CreateRawString(_configuration.GetSection("IDFCAPISettings:SecureToken").Value.ToString(), ObjClass.OTP, String.Format("{0:00.00}", ObjClass.Invoiceamount), idfc_EntityId, idfc_POSID, ObjClass.TxnRefId, ObjClass.TxnTime, ObjClass.Vehicleno, ObjClass.TagId, ObjClass.Mobileno, String.Format("{0:00.00}", NetAmount), String.Format("{0:00.00}", DiscountAmount), idfc_IIN);
                    CreateHashKeyByHPPay = ComputeSha256Hash(ConcatenatedStringOFParams);

                    IdfcMakePaymentReQuest req = new IdfcMakePaymentReQuest()
                    { grossAmount = String.Format("{0:00.00}", ObjClass.Invoiceamount), chkSm = CreateHashKeyByHPPay, discount = String.Format("{0:00.00}", DiscountAmount), entityId = idfc_EntityId, iin = idfc_IIN, mobileNo = ObjClass.Mobileno, netAmount = String.Format("{0:00.00}", NetAmount), posId = idfc_POSID, txnId = ObjClass.TxnRefId, txnTime = ObjClass.TxnTime, vrn = ObjClass.Vehicleno, otp = ObjClass.OTP };

                    string authIdPwd = _configuration.GetSection("IDFCAPISettings:UserName").Value.ToString() + ":" + _configuration.GetSection("IDFCAPISettings:Password").Value.ToString();
                    HttpResponseMessage apiResponse = null;
                    string responseapi = string.Empty;
                    try
                    {
                        apiResponse = Variables.CallAPI(idfc_apiurl + "HPPay/makepayment", JsonConvert.SerializeObject(req), authIdPwd).Result;
                        responseapi = apiResponse.Content.ReadAsStringAsync().Result;
                    }
                    catch (Exception ex)
                    {
                        responseapi = ex.Message;

                    }


                    string json = string.Empty;

                    if (apiResponse != null && apiResponse.IsSuccessStatusCode)
                    {

                        json = apiResponse.Content.ReadAsStringAsync().Result;

                    }
                    //FasTagConfirmOtpResponse res = new FasTagConfirmOtpResponse();
                    IdfcApiRequestResponseDetailInput objReqRes = new IdfcApiRequestResponseDetailInput();
                    try
                    {


                        if (!string.IsNullOrEmpty(json))
                        {

                            res = JsonConvert.DeserializeObject<FasTagConfirmOtpResponse>(json);
                            objReqRes = new IdfcApiRequestResponseDetailInput()
                            {
                                RqId = RequestID,
                                ApiRequestUrL = idfc_apiurl + "HPPay/makepayment",
                                ApiRequest = JsonConvert.SerializeObject(req),
                                ApiResponse = apiResponse.Content.ReadAsStringAsync().Result,
                                CreatedBy = ObjClass.Userid,
                                Remarks = "",
                                ReqAmount = req.grossAmount,
                                ReqChkSm = req.chkSm,
                                ReqDiscount = req.discount,
                                ReqEntityId = req.entityId,
                                ReqIIN = req.iin,
                                ReqMobileNo = req.mobileNo,
                                ReqNetAmount = req.netAmount,
                                ReqOrgTxnId = "",
                                ReqOrgTxnTime = "",
                                ReqOtp = req.otp,
                                ReqPosId = req.posId,
                                ReqTxnId = req.txnId,
                                ReqTxnTime = req.txnTime,
                                ReqVrn = req.vrn,
                                ResCode = res.ResCode,
                                ResMsg = res.ResMsg,
                                RestagId = res.TagId,
                                ResTxnId = res.TxnId,
                                vrn = res.Vrn,
                                ResTxnNo = res.TxnNo,
                            };
                            if (res.ResCode == Convert.ToString((int)IdfcApiStatus.Success))
                            {

                                var result = _idfcRepo.UpdateCCMSBAlanceForIdfcCustomer(ObjClass, req.netAmount, req.discount).Result;
                                if (result != null && result.Count() > 0)
                                {
                                    res.RSP = result.Cast<UpdateCCMSBAlanceForIdfcCustomer>().ToList()[0].RSP;
                                    res.Volume = result.Cast<UpdateCCMSBAlanceForIdfcCustomer>().ToList()[0].Volume;

                                    if (result.Cast<UpdateCCMSBAlanceForIdfcCustomer>().ToList()[0].Status == 1)
                                    {
                                        objReqRes.Remarks = "Payment Process Successfully " + result.Cast<UpdateCCMSBAlanceForIdfcCustomer>().ToList()[0].Reason;
                                        objReqRes.IsPaymentSuccess = 1;
                                        _idfcRepo.InsertIdfcApiRequestResponseDetail(objReqRes);
                                    }
                                    else
                                    {
                                        objReqRes.Remarks = "Payment Failed due to CCMCBalance Not Updated in DB. " + result.Cast<UpdateCCMSBAlanceForIdfcCustomer>().ToList()[0].Reason;
                                        _idfcRepo.InsertIdfcApiRequestResponseDetail(objReqRes);
                                        res.ResCode = "0";
                                        res.ResMsg = "Transaction failed";
                                        res.Reason = "CCMCBalance Not Updated in DB";
                                        return res;
                                    }
                                }
                            }
                            else
                            {
                                objReqRes.Remarks = "Payment failed from IdfcAPI";
                                _idfcRepo.InsertIdfcApiRequestResponseDetail(objReqRes);
                                res.Reason = res.ResMsg;
                                return res;
                            }


                        }
                        else
                        {
                            objReqRes = new IdfcApiRequestResponseDetailInput()
                            {
                                ApiRequestUrL = idfc_apiurl + "HPPay/makepayment",
                                ApiRequest = JsonConvert.SerializeObject(req),
                                ApiResponse = apiResponse.Content.ReadAsStringAsync().Result,
                                CreatedBy = ObjClass.Userid,
                                Remarks = "",
                                ReqAmount = req.grossAmount,
                                ReqChkSm = req.chkSm,
                                ReqDiscount = req.discount,
                                ReqEntityId = req.entityId,
                                ReqIIN = req.iin,
                                ReqMobileNo = req.mobileNo,
                                ReqNetAmount = req.netAmount,
                                ReqOrgTxnId = "",
                                ReqOrgTxnTime = "",
                                ReqOtp = req.otp,
                                ReqPosId = req.posId,
                                ReqTxnId = req.txnId,
                                ReqTxnTime = req.txnTime,
                                ReqVrn = req.vrn,
                                ResCode = res.ResCode,
                                ResMsg = res.ResMsg,
                                RestagId = res.TagId,
                                ResTxnId = res.TxnId,
                                vrn = res.Vrn,
                                ResTxnNo = res.TxnNo,
                            };

                            _idfcRepo.InsertIdfcApiRequestResponseDetail(objReqRes);

                            res.ResCode = "0";
                            res.ResMsg = "Transaction failed";
                            res.Reason = "Response Not coming from API";
                            return res;
                        }
                    }
                    catch (Exception ex)
                    {
                        objReqRes.RqId = RequestID;
                        objReqRes.Remarks = ex.Message;
                        _idfcRepo.InsertIdfcApiRequestResponseDetail(objReqRes);
                        res.ResCd = Convert.ToString((int)IdfcApiStatus.Unhandeled_Exception);
                        res.ResCode = "0";
                        res.ResMsg = IdfcApiStatus.Unhandeled_Exception.ToString();

                    }
                }
            }

            return res;

        }




        private FastagRefundResponse IDfcRefundAPiCall(FastagRefundPaymentReQuest ObjClass)
        {
            int RequestID = 0;
            ///Add Amount > 0 Validation 


            InsertFastagIdfcApiRequestInput ObjRq = new InsertFastagIdfcApiRequestInput()
            {
                BankID = ObjClass.BankID,
                // MobileNo = ObjClass.MobileNo,
                // Amount = Convert.ToString(ObjClass.GrossAmount),
                //Vrn = ObjClass.Vrn,
                CreatedBy = ObjClass.Userid,
                Remarks = "",
                ApiRequestUrL = "Refund",
                // DiscountAmount = string.Format("{0:00.00}", DiscountAmount),
                //NetAmount = string.Format("{0:00.00}", NetAmount)

                MerchantID = ObjClass.Merchantid,
                TerminalID = ObjClass.Terminalid,
                //TxnId = ObjClass.TxnId,
                TxnTime = ObjClass.OrgTxnTime,

                Invoicedate = ObjClass.Invoicedate,
                Productid = ObjClass.Productid,
                Odometerreading = ObjClass.Odometerreading,
                TransType = ObjClass.TransType,
                Sourceid = ObjClass.Sourceid,
                Formfactor = ObjClass.Formfactor,
                DCSTokenNo = ObjClass.DCSTokenNo,
                Stan = ObjClass.Stan,
                Paymentmode = ObjClass.BankID.ToString(),
                Gatewayname = "IDFC",
                Bankname = "IDFC",
                Paycode = ""
                //OTP = ObjClass.Otp,
                //TagId = ObjClass.TagId,
                //TxnNo = ObjClass.TxnNo


            };


            var Reqres = _idfcRepo.InsertIdfcFastagApiRequest(ObjRq).Result;



            if (Reqres != null && Reqres.Count() > 0)
            {
                RequestID = Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].RequestId;

                if (RequestID > 0 && Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].Status != 1)
                {
                    FastagRefundResponse res = new FastagRefundResponse();
                    int status_Code = Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].Status;
                    if (status_Code == (int)ValidationStatus.Terminal_Not_Active)
                        res = new FastagRefundResponse() { resCode = Convert.ToString((int)IdfcApiStatus.Terminal_Not_Active), resMsg = Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].Reason };

                    else if (status_Code == (int)ValidationStatus.Merchant_Not_Active)
                    {
                        res = new FastagRefundResponse() { resCode = Convert.ToString((int)IdfcApiStatus.Merchant_Not_Active), resMsg = Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].Reason };

                    }
                    else if (status_Code == (int)ValidationStatus.Amount_lessthen_ccms)
                    {
                        res = new FastagRefundResponse() { resCode = Convert.ToString((int)IdfcApiStatus.Amount_lessthen_ccms), resMsg = Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].Reason };
                    }
                    res.Reason = Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].Reason;
                    return res;
                }
            }
            IdfcCheckFastagInvoiceIdBatchIdExistInput obj = new IdfcCheckFastagInvoiceIdBatchIdExistInput() { Batchid = ObjClass.Batchid, Invoiceid = ObjClass.Invoiceid, RecordType = 1, MerchantID = ObjClass.Merchantid, TerminalID = ObjClass.Terminalid, UserId = ObjClass.Userid };
            //var checkInvoiceidExist = _idfcRepo.CheckFastagInvoiceIdBatchIdExist(obj).Result;
            //if (checkInvoiceidExist == null || checkInvoiceidExist.Cast<IdfcCheckFastagInvoiceIdBatchIdExistOutput>().ToList()[0].Status == 1)
            //{
            //    UpdateFastagIdfcApiRequestInput ObjupdateRq = new UpdateFastagIdfcApiRequestInput();
            //    ObjupdateRq.Remarks = checkInvoiceidExist.Cast<IdfcCheckFastagInvoiceIdBatchIdExistOutput>().ToList()[0].Reason;
            //    ObjupdateRq.ModifiedBy = ObjClass.Userid;
            //    ObjupdateRq.RequestId = RequestID;
            //    _idfcRepo.UpdateIdfcFastagApiRequest(ObjupdateRq);
            //    return new FastagRefundResponse() { resCode = Convert.ToString((int)IdfcApiStatus.InvoiceId_BatchId_Exist), resMsg = IdfcApiStatus.InvoiceId_BatchId_Exist.GetDisplayName(), Reason = ObjupdateRq.Remarks };

            //}
            string CreateHashKeyByHPPay = String.Empty;
            string TxnTime = DateTime.Now.ToString("ddMMyyyyHHmmss");
            string txnId = StaticClass.APIReferenceNo; // "idfc" + Variables.GetUniqueNumber();
            //ObjClass.TxnTime = DateTime.Now.ToString("ddMMyyyyHHmmss");
            string ConcatenatedStringOFParams = CreateRawString(_configuration.GetSection("IDFCAPISettings:SecureToken").Value.ToString(), idfc_EntityId, ObjClass.OrgTxnId, ObjClass.OrgTxnTime, idfc_POSID, txnId, TxnTime, idfc_IIN);
            CreateHashKeyByHPPay = ComputeSha256Hash(ConcatenatedStringOFParams);
            IdfcRefundReQuest req = new IdfcRefundReQuest()
            { chkSm = CreateHashKeyByHPPay, entityId = idfc_EntityId, iin = idfc_IIN, posId = idfc_POSID, txnId = txnId, txnTime = TxnTime, orgTxnId = ObjClass.OrgTxnId, orgTxnTime = ObjClass.OrgTxnTime };

            string authIdPwd = _configuration.GetSection("IDFCAPISettings:UserName").Value.ToString() + ":" + _configuration.GetSection("IDFCAPISettings:Password").Value.ToString();
            HttpResponseMessage apiResponse = null;
            string responseapi = string.Empty;
            try
            {
                apiResponse = Variables.CallAPI(idfc_apiurl + "HPPay/refund", JsonConvert.SerializeObject(req), authIdPwd).Result;
                responseapi = apiResponse.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {

                responseapi = ex.Message;
            }


            //IdfcApiRequestResponseInput ObjReq = new IdfcApiRequestResponseInput() { ApiRequestUrL = idfc_apiurl + "HPPay/refund", ApiRequest = JsonConvert.SerializeObject(req), ApiResponse = responseapi, CreatedBy = ObjClass.Userid, Remarks = "Refund Payment Process" };
            //var rqres = _idfcRepo.InsertIdfcApiRequestResponse(ObjReq).Result;
            //string json = string.Empty;
            //int rqID = 0;
            //if (rqres != null && rqres.Count() > 0)
            //{
            //    rqID = rqres.Cast<IdfcApiRequestResponseOutput>().ToList()[0].Id;
            //}
            string json = string.Empty;
            json = apiResponse.Content.ReadAsStringAsync().Result;

            if (apiResponse.IsSuccessStatusCode)
            {

                json = apiResponse.Content.ReadAsStringAsync().Result;
            }
            FastagRefundResponse result = new FastagRefundResponse();
            if (!string.IsNullOrEmpty(json))
            {

                result = JsonConvert.DeserializeObject<FastagRefundResponse>(json);

            }
            IdfcApiRequestResponseDetailInput objReqRes = new IdfcApiRequestResponseDetailInput()
            {
                RqId = RequestID,
                ApiRequestUrL = idfc_apiurl + "HPPay/refund",
                ApiRequest = JsonConvert.SerializeObject(req),
                ApiResponse = apiResponse.Content.ReadAsStringAsync().Result,
                CreatedBy = ObjClass.Userid,
                Remarks = "",
                ReqAmount = "",
                ReqChkSm = req.chkSm,
                ReqDiscount = "",
                ReqEntityId = req.entityId,
                ReqIIN = req.iin,
                ReqMobileNo = "",
                ReqNetAmount = "",
                ReqOrgTxnId = req.orgTxnId,
                ReqOrgTxnTime = req.orgTxnTime,
                ReqOtp = "",
                ReqPosId = req.posId,
                ReqTxnId = req.txnId,
                ReqTxnTime = req.txnTime,
                ReqVrn = "",
                ResCode = result.resCode,
                ResMsg = result.resMsg,
                RestagId = "",
                ResTxnId = result.txnId,
                vrn = "",
                ResTxnNo = result.txnNo,
            };

            var objresult = _idfcRepo.RefundCCMSBAlanceForIdfcCustomer(ObjClass).Result;
            if (objresult != null && objresult.Count() > 0 && objresult.Cast<UpdateCCMSBAlanceForIdfcCustomer>().ToList()[0].Status == 1)
            {
                objReqRes.Remarks = "Refund Process Successfully " + objresult.Cast<UpdateCCMSBAlanceForIdfcCustomer>().ToList()[0].Reason;
                objReqRes.IsRefundSuccess = 1;
                _idfcRepo.InsertIdfcApiRequestResponseDetail(objReqRes);
            }
            else
            {
                objReqRes.Remarks = "Refund Failed " + objresult.Cast<UpdateCCMSBAlanceForIdfcCustomer>().ToList()[0].Reason;
                objReqRes.IsRefundSuccess = 0;
                _idfcRepo.InsertIdfcApiRequestResponseDetail(objReqRes);
                result.resCode = Convert.ToString((int)IdfcApiStatus.Unhandeled_Exception);
                result.resMsg = objresult.Cast<UpdateCCMSBAlanceForIdfcCustomer>().ToList()[0].Reason;
                result.Reason = objresult.Cast<UpdateCCMSBAlanceForIdfcCustomer>().ToList()[0].Reason;


            }
            return result;
        }





        private FasTagOtpResponse IciciGetOTP([FromBody] FastagGetOtpRequest ObjClass)
        {

            int RequestID = 0;
            ///Add Amount > 0 Validation 
            decimal Discount = Convert.ToDecimal(_configuration.GetSection("ICICIAPISettings:Discount").Value.ToString());
            decimal DiscountAmount = Convert.ToDecimal(string.Format("{0:00.00}", ObjClass.Invoiceamount * Discount / 100));
            decimal NetAmount = Convert.ToDecimal(string.Format("{0:00.00}", (ObjClass.Invoiceamount - DiscountAmount)));

            InsertFastagIciciApiRequestInput ObjRq = new InsertFastagIciciApiRequestInput()
            { BankID = ObjClass.BankID, MobileNo = ObjClass.Mobileno, Amount = Convert.ToString(ObjClass.Invoiceamount), Vrn = ObjClass.Vehicleno, CreatedBy = ObjClass.Userid, Remarks = "", ApiRequestUrL = "GetOTP", DiscountAmount = string.Format("{0:00.00}", DiscountAmount), NetAmount = string.Format("{0:00.00}", NetAmount), MerchantID = ObjClass.Merchantid, TerminalID = ObjClass.Terminalid };


            var Reqres = _iciciRepo.InsertIciciFastagApiRequest(ObjRq).Result;



            if (Reqres != null && Reqres.Count() > 0)
            {
                RequestID = Reqres.Cast<InsertFastagIciciApiRequestOutput>().ToList()[0].RequestId;

                if (RequestID > 0 && Reqres.Cast<InsertFastagIciciApiRequestOutput>().ToList()[0].Status != 1)
                {
                    FasTagOtpResponse res = new FasTagOtpResponse();
                    int status_Code = Reqres.Cast<InsertFastagIciciApiRequestOutput>().ToList()[0].Status;
                    if (status_Code == (int)ValidationStatus.Terminal_Not_Active)
                    {
                        res = new FasTagOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.Terminal_Not_Active), ResMsg = Reqres.Cast<InsertFastagIciciApiRequestOutput>().ToList()[0].Reason };
                        res.Reason = "Transaction Not Allowed";
                    }
                    else if (status_Code == (int)ValidationStatus.Merchant_Not_Active)
                    {
                        res = new FasTagOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.Merchant_Not_Active), ResMsg = Reqres.Cast<InsertFastagIciciApiRequestOutput>().ToList()[0].Reason };
                        res.Reason = "Transaction Not Allowed";
                    }
                    else if (status_Code == (int)ValidationStatus.Amount_lessthen_ccms)
                    {
                        res = new FasTagOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.Amount_lessthen_ccms), ResMsg = Reqres.Cast<InsertFastagIciciApiRequestOutput>().ToList()[0].Reason };
                        res.Reason = "Insufficient Credit Limit";
                    }
                    else if (status_Code == (int)ValidationStatus.Customer_Not_Active)
                    {
                        res = new FasTagOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.Customer_Not_Active), ResMsg = Reqres.Cast<InsertFastagIciciApiRequestOutput>().ToList()[0].Reason };
                        res.Reason = "Transaction Not Allowed";
                    }
                    return res;
                }
                else
                {


                    string TxnTime = DateTime.Now.ToString("ddMMyyyyHHmmss");
                    string txnId = StaticClass.APIReferenceNo;  // "icici" + Variables.GetUniqueNumber();
                    string ConcatenatedStringOFParams = CreateRawString(_configuration.GetSection("ICICIAPISettings:SecureToken").Value.ToString(), string.Format("{0:00.00}", ObjClass.Invoiceamount), icici_EntityId, icici_POSID, txnId, TxnTime, ObjClass.Vehicleno, "", ObjClass.Mobileno, String.Format("{0:00.00}", NetAmount), String.Format("{0:00.00}", DiscountAmount), icici_IIN);
                    string CreateHashKeyByHPPay = ComputeSha256Hash(ConcatenatedStringOFParams);
                    IciciAPIGetOtpRequest req = new IciciAPIGetOtpRequest()
                    { amount = string.Format("{0:00.00}", ObjClass.Invoiceamount), chkSm = CreateHashKeyByHPPay, discount = string.Format("{0:00.00}", DiscountAmount), entityId = icici_EntityId, iin = icici_IIN, mobileNo = ObjClass.Mobileno, netAmount = String.Format("{0:00.00}", NetAmount), posId = icici_POSID, tagId = "", txnId = txnId, txnTime = TxnTime, vrn = ObjClass.Vehicleno };

                    HttpResponseMessage apiResponse;
                    string responseapi = string.Empty;
                    try
                    {
                        apiResponse = Variables.CallIciciAPI(icici_apiurl + "Fuel/getOtp", JsonConvert.SerializeObject(req), icici_APIClient_ID, icici_API_KEY).Result;
                        responseapi = apiResponse.Content.ReadAsStringAsync().Result;


                        //IciciApiRequestResponseInput ObjReq = new IciciApiRequestResponseInput() { ApiRequestUrL = icici_apiurl + "Fuel/getOtp", ApiRequest = JsonConvert.SerializeObject(req), ApiResponse = responseapi, CreatedBy = ObjClass.Userid, Remarks = "Get Otp Call" };
                        //var rqres = _iciciRepo.InsertIciciApiRequestResponse(ObjReq).Result;
                        string json = string.Empty;
                        //int rqID = 0;
                        //if (rqres != null && rqres.Count() > 0)
                        //{
                        //    rqID = rqres.Cast<IciciApiRequestResponseOutput>().ToList()[0].Id;
                        //}

                        json = apiResponse.Content.ReadAsStringAsync().Result;

                        if (apiResponse != null && apiResponse.IsSuccessStatusCode)
                        {
                            json = apiResponse.Content.ReadAsStringAsync().Result;
                        }
                        FasTagOtpResponse result = new FasTagOtpResponse();
                        if (!string.IsNullOrEmpty(json))
                        {
                            result = JsonConvert.DeserializeObject<FasTagOtpResponse>(json);
                            result.txnTime = TxnTime;
                            result.Reason=result.ResMsg.ToString();
                        }
                        IciciApiRequestResponseDetailInput objReqRes = new IciciApiRequestResponseDetailInput()
                        {
                            RqId = RequestID,
                            ApiRequestUrL = icici_apiurl + "Fuel/getOtp",
                            ApiRequest = JsonConvert.SerializeObject(req),
                            ApiResponse = apiResponse.Content.ReadAsStringAsync().Result,
                            CreatedBy = ObjClass.Userid,
                            Remarks = "",
                            ReqAmount = req.amount,
                            ReqChkSm = req.chkSm,
                            ReqDiscount = req.discount,
                            ReqEntityId = req.entityId,
                            ReqIIN = req.iin,
                            ReqMobileNo = req.mobileNo,
                            ReqNetAmount = req.netAmount,
                            ReqOrgTxnId = "",
                            ReqOrgTxnTime = "",
                            ReqOtp = "",
                            ReqPosId = req.posId,
                            ReqTxnId = req.txnId,
                            ReqTxnTime = req.txnTime,
                            ReqVrn = req.vrn,
                            ResCode = result.ResCode,
                            ResMsg = result.ResMsg,
                            RestagId = result.TagId,
                            ResTxnId = result.TxnId,
                            ResVrn = result.Vrn,
                            ResTxnNo = result.TxnNo,
                        };
                        _iciciRepo.InsertIciciApiRequestResponseDetail(objReqRes);

                        return result;
                    }
                    catch (Exception ex)
                    {

                        responseapi = ex.Message;
                        //IciciApiRequestResponseInput ObjReq = new IciciApiRequestResponseInput() { ApiRequestUrL = icici_apiurl + "Fuel/getOtp", ApiRequest = JsonConvert.SerializeObject(req), ApiResponse = responseapi, CreatedBy = ObjClass.Userid, Remarks = "Get Otp Call" };
                        if (RequestID > 0)
                        {
                            UpdateFastagIciciApiRequestInput ObjupdateRq = new UpdateFastagIciciApiRequestInput();
                            ObjupdateRq.Remarks = responseapi;
                            ObjupdateRq.ModifiedBy = ObjClass.Userid;
                            ObjupdateRq.RequestId = RequestID;
                            _iciciRepo.UpdateIciciFastagApiRequest(ObjupdateRq);
                        }
                        else
                        {
                            var Rqrs = _iciciRepo.InsertIciciFastagApiRequest(ObjRq).Result;
                        }
                        FasTagOtpResponse res = new FasTagOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.None), ResMsg = responseapi, Reason = responseapi };
                        return res;

                    }
                }
            }
            FasTagOtpResponse res1 = new FasTagOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.Unhandeled_Exception), ResMsg = "Unhandeled Exception Occur" };
            return res1;
        }


        private FasTagConfirmOtpResponse IciciConfirmOTPandPayment([FromBody] FastagConfirmOtpReQuest ObjClass)
        {
            FasTagConfirmOtpResponse res = new FasTagConfirmOtpResponse();
            decimal Discount = Convert.ToDecimal(_configuration.GetSection("ICICIAPISettings:Discount").Value.ToString());
            decimal DiscountAmount = Convert.ToDecimal(String.Format("{0:00.00}", ObjClass.Invoiceamount * Discount / 100));
            decimal NetAmount = Convert.ToDecimal(String.Format("{0:00.00}", (ObjClass.Invoiceamount - DiscountAmount)));
            string CreateHashKeyByHPPay = String.Empty;
            int RequestID = 0;
            ///Add Amount > 0 Validation 


            InsertFastagIciciApiRequestInput ObjRq = new InsertFastagIciciApiRequestInput()
            {
                BankID = ObjClass.BankID,
                MobileNo = ObjClass.Mobileno,
                Amount = Convert.ToString(ObjClass.Invoiceamount),
                Vrn = ObjClass.Vehicleno,
                CreatedBy = ObjClass.Userid,
                Remarks = "",
                ApiRequestUrL = "ConfirmOTPandPayment",
                DiscountAmount = string.Format("{0:00.00}", DiscountAmount),
                NetAmount = string.Format("{0:00.00}", NetAmount),
                MerchantID = ObjClass.Merchantid,
                TerminalID = ObjClass.Terminalid,
                TxnId = ObjClass.TxnRefId,
                TxnTime = ObjClass.TxnTime,
                OTP = ObjClass.OTP,
                TagId = ObjClass.TagId,
                TxnNo = ObjClass.TxnNo,
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
                Paymentmode = ObjClass.BankID.ToString(),
                Gatewayname = "ICICI",
                Bankname = "ICICI",
                Paycode = ""

            };


            var Reqres = _iciciRepo.InsertIciciFastagApiRequest(ObjRq).Result;



            if (Reqres != null && Reqres.Count() > 0)
            {
                RequestID = Reqres.Cast<InsertFastagIciciApiRequestOutput>().ToList()[0].RequestId;

                if (RequestID > 0 && Reqres.Cast<InsertFastagIciciApiRequestOutput>().ToList()[0].Status != 1)
                {

                    int status_Code = Reqres.Cast<InsertFastagIciciApiRequestOutput>().ToList()[0].Status;
                    if (status_Code == (int)ValidationStatus.Terminal_Not_Active)
                        res = new FasTagConfirmOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.Terminal_Not_Active), ResMsg = Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].Reason };

                    else if (status_Code == (int)ValidationStatus.Merchant_Not_Active)
                    {
                        res = new FasTagConfirmOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.Merchant_Not_Active), ResMsg = Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].Reason };

                    }
                    else if (status_Code == (int)ValidationStatus.Amount_lessthen_ccms)
                    {
                        res = new FasTagConfirmOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.Amount_lessthen_ccms), ResMsg = Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].Reason };
                    }
                    res.Reason = Reqres.Cast<InsertFastagIdfcApiRequestOutput>().ToList()[0].Reason;
                    return res;
                }
                else
                {

                    IciciCheckFastagInvoiceIdBatchIdExistInput obj = new IciciCheckFastagInvoiceIdBatchIdExistInput() { Batchid = ObjClass.Batchid, Invoiceid = ObjClass.Invoiceid, RecordType = 1, MerchantID = ObjClass.Merchantid, TerminalID = ObjClass.Terminalid, UserId = ObjClass.Userid, TransTypeId = ObjClass.TransType,Useragent=ObjClass.Useragent };
                    var checkInvoiceidExist = _iciciRepo.CheckFastagInvoiceIdBatchIdExist(obj).Result;
                    if (checkInvoiceidExist == null || checkInvoiceidExist.Cast<IciciCheckFastagInvoiceIdBatchIdExistOutput>().ToList()[0].Status == 1)
                    {
                        UpdateFastagIciciApiRequestInput ObjupdateRq = new UpdateFastagIciciApiRequestInput();
                        ObjupdateRq.Remarks = checkInvoiceidExist.Cast<IciciCheckFastagInvoiceIdBatchIdExistOutput>().ToList()[0].Reason;
                        ObjupdateRq.ModifiedBy = ObjClass.Userid;
                        ObjupdateRq.RequestId = RequestID;
                        _iciciRepo.UpdateIciciFastagApiRequest(ObjupdateRq);
                        return new FasTagConfirmOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.InvoiceId_BatchId_Exist), ResMsg = IdfcApiStatus.InvoiceId_BatchId_Exist.GetDisplayName(), Reason = ObjupdateRq.Remarks };

                    }

                    string ConcatenatedStringOFParams = CreateRawString(_configuration.GetSection("ICICIAPISettings:SecureToken").Value.ToString(), ObjClass.OTP, String.Format("{0:00.00}", ObjClass.Invoiceamount), icici_EntityId, icici_POSID, ObjClass.TxnRefId, ObjClass.TxnTime, ObjClass.Vehicleno, ObjClass.TagId, ObjClass.Mobileno, String.Format("{0:00.00}", NetAmount), String.Format("{0:00.00}", DiscountAmount), icici_IIN);
                    CreateHashKeyByHPPay = ComputeSha256Hash(ConcatenatedStringOFParams);

                    IciciMakePaymentReQuest req = new IciciMakePaymentReQuest()
                    { grossAmount = String.Format("{0:00.00}", ObjClass.Invoiceamount), chkSm = CreateHashKeyByHPPay, discount = String.Format("{0:00.00}", DiscountAmount), entityId = icici_EntityId, iin = icici_IIN, mobileNo = ObjClass.Mobileno, netAmount = String.Format("{0:00.00}", NetAmount), posId = icici_POSID, txnId = ObjClass.TxnRefId, vrn = ObjClass.Vehicleno, otp = ObjClass.OTP };

                    //string authIdPwd = _configuration.GetSection("IDFCAPISettings:UserName").Value.ToString() + ":" + _configuration.GetSection("IDFCAPISettings:Password").Value.ToString();
                    HttpResponseMessage apiResponse = null;
                    string responseapi = string.Empty;

                    try
                    {
                        apiResponse = Variables.CallIciciAPI(icici_apiurl + "Fuel/makePayment", JsonConvert.SerializeObject(req), icici_APIClient_ID, icici_API_KEY).Result;
                        responseapi = apiResponse.Content.ReadAsStringAsync().Result;
                        if (!string.IsNullOrEmpty(responseapi))
                        {
                            res = JsonConvert.DeserializeObject<FasTagConfirmOtpResponse>(responseapi);
                            if (String.IsNullOrEmpty(res.ResCode) && !String.IsNullOrEmpty(res.ResCd))
                            {
                                res.ResCode = res.ResCd;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        responseapi = ex.Message;

                    }

                    string json = string.Empty;
                    try
                    {
                        //IciciApiRequestResponseInput ObjReq = new IciciApiRequestResponseInput() { ApiRequestUrL = icici_apiurl + "Fuel/makePayment", ApiRequest = JsonConvert.SerializeObject(req), ApiResponse = responseapi, CreatedBy = ObjClass.Userid, Remarks = "Payment Process" };
                        //var rqres = _iciciRepo.InsertIciciApiRequestResponse(ObjReq).Result;
                        //int rqID = 0;
                        //if (rqres != null && rqres.Count() > 0)
                        //{
                        //    rqID = rqres.Cast<IciciApiRequestResponseOutput>().ToList()[0].Id;
                        //}
                        if (apiResponse != null && apiResponse.IsSuccessStatusCode)
                        {

                            json = apiResponse.Content.ReadAsStringAsync().Result;

                        }

                        if (!string.IsNullOrEmpty(json))
                        {

                            res = JsonConvert.DeserializeObject<FasTagConfirmOtpResponse>(json);
                            IciciApiRequestResponseDetailInput objReqRes = new IciciApiRequestResponseDetailInput()
                            {
                                RqId = RequestID,
                                ApiRequestUrL = icici_apiurl + "Fuel/makePayment",
                                ApiRequest = JsonConvert.SerializeObject(req),
                                ApiResponse = apiResponse.Content.ReadAsStringAsync().Result,
                                CreatedBy = ObjClass.Userid,
                                Remarks = "",
                                ReqAmount = req.grossAmount,
                                ReqChkSm = req.chkSm,
                                ReqDiscount = req.discount,
                                ReqEntityId = req.entityId,
                                ReqIIN = req.iin,
                                ReqMobileNo = req.mobileNo,
                                ReqNetAmount = req.netAmount,
                                ReqOrgTxnId = "",
                                ReqOrgTxnTime = "",
                                ReqOtp = req.otp,
                                ReqPosId = req.posId,
                                ReqTxnId = req.txnId,
                                ReqTxnTime = req.txnTime,
                                ReqVrn = req.vrn,
                                ResCode = res.ResCode,
                                ResMsg = res.ResMsg,
                                RestagId = res.TagId,
                                ResTxnId = res.TxnId,
                                ResVrn = res.Vrn,
                                ResTxnNo = res.TxnNo,
                                ResMobileNo = res.MobileNo
                            };
                            if (res.ResCode == Convert.ToString((int)IdfcApiStatus.Success) || res.ResCd == Convert.ToString((int)IdfcApiStatus.Success))
                            {

                                var result = _iciciRepo.UpdateCCMSBAlanceForIciciCustomer(ObjClass, req.netAmount, req.discount).Result;
                                if (result != null && result.Count() > 0)
                                {
                                    res.RSP = result.Cast<UpdateCCMSBAlanceForICICICustomer>().ToList()[0].RSP;
                                    res.Volume = result.Cast<UpdateCCMSBAlanceForICICICustomer>().ToList()[0].Volume;
                                    if (result.Cast<UpdateCCMSBAlanceForICICICustomer>().ToList()[0].Status == 1)
                                    {
                                        objReqRes.Remarks = "Payment Process Successfully " + result.Cast<UpdateCCMSBAlanceForICICICustomer>().ToList()[0].Reason;
                                        objReqRes.IsPaymentSuccess = 1;
                                        _iciciRepo.InsertIciciApiRequestResponseDetail(objReqRes);
                                        res.Reason = res.ResMsg;
                                    }
                                    else
                                    {
                                        objReqRes.Remarks = "Payment Failed due to CCMCBalance Not Updated in DB. " + result.Cast<UpdateCCMSBAlanceForICICICustomer>().ToList()[0].Reason;
                                        _iciciRepo.InsertIciciApiRequestResponseDetail(objReqRes);
                                        res.ResCode = Convert.ToString((int)IdfcApiStatus.Unhandeled_Exception);
                                        res.ResMsg = "Transaction failed";
                                        res.Reason = objReqRes.Remarks;
                                        return res;
                                        //refund 
                                        //IciciRefundPaymentReQuest refundRq = new IciciRefundPaymentReQuest()
                                        //{
                                        //    OrgTxnId = ObjClass.TxnId,


                                        //};
                                        //IciciRefundResponse resultres = IciciRefundAPiCall(refundRq);

                                        //if (resultres != null && resultres.resCode != Convert.ToString((int)IdfcApiStatus.Success))
                                        //{
                                        //    res.ResCode = "0";
                                        //    res.ResMsg = "Transaction failed";
                                        //    return res;
                                        //}
                                        //else
                                        //{
                                        //    var result12 = _iciciRepo.RefundCCMSBAlanceForIciciCustomer(refundRq).Result;
                                        //    return res;
                                        //}

                                    }
                                }
                            }
                            else
                            {
                                objReqRes.Remarks = "Payment failed from IciciAPI";
                                _iciciRepo.InsertIciciApiRequestResponseDetail(objReqRes);
                                res.Reason = res.ResMsg;
                                return res;
                            }


                        }
                        else
                        {
                            IciciApiRequestResponseDetailInput objReqRes = new IciciApiRequestResponseDetailInput()
                            {
                                ApiRequestUrL = icici_apiurl + "HPPay/makepayment",
                                ApiRequest = JsonConvert.SerializeObject(req),
                                ApiResponse = apiResponse.Content.ReadAsStringAsync().Result,
                                CreatedBy = ObjClass.Userid,
                                Remarks = "",
                                ReqAmount = req.grossAmount,
                                ReqChkSm = req.chkSm,
                                ReqDiscount = req.discount,
                                ReqEntityId = req.entityId,
                                ReqIIN = req.iin,
                                ReqMobileNo = req.mobileNo,
                                ReqNetAmount = req.netAmount,
                                ReqOrgTxnId = "",
                                ReqOrgTxnTime = "",
                                ReqOtp = req.otp,
                                ReqPosId = req.posId,
                                ReqTxnId = req.txnId,
                                ReqTxnTime = req.txnTime,
                                ReqVrn = req.vrn,
                                ResCode = res.ResCode,
                                ResMsg = res.ResMsg,
                                RestagId = res.TagId,
                                ResTxnId = res.TxnId,
                                ResMobileNo = res.MobileNo,
                                ResVrn = res.Vrn,
                                ResTxnNo = res.TxnNo,
                            };

                            //IciciRefundPaymentReQuest refundRq = new IciciRefundPaymentReQuest()
                            //{
                            //    OrgTxnId = ObjClass.TxnId,


                            //};
                            //IciciRefundResponse resultres = IciciRefundAPiCall(refundRq);

                            //res.ResCode = "0";
                            //res.ResMsg = "Transaction failed";
                            //return res;
                            _iciciRepo.InsertIciciApiRequestResponseDetail(objReqRes);
                        }
                    }
                    catch (Exception ex)
                    {
                        IciciApiRequestResponseDetailInput objReqRes = new IciciApiRequestResponseDetailInput()
                        {
                            ApiRequestUrL = icici_apiurl + "HPPay/makepayment",
                            ApiRequest = JsonConvert.SerializeObject(req),
                            ApiResponse = apiResponse.Content.ReadAsStringAsync().Result,
                            CreatedBy = ObjClass.Userid,
                            Remarks = ex.Message,
                            ReqAmount = req.grossAmount,
                            ReqChkSm = req.chkSm,
                            ReqDiscount = req.discount,
                            ReqEntityId = req.entityId,
                            ReqIIN = req.iin,
                            ReqMobileNo = req.mobileNo,
                            ReqNetAmount = req.netAmount,
                            ReqOrgTxnId = "",
                            ReqOrgTxnTime = "",
                            ReqOtp = req.otp,
                            ReqPosId = req.posId,
                            ReqTxnId = req.txnId,
                            ReqTxnTime = req.txnTime,
                            ReqVrn = req.vrn,
                            ResCode = res.ResCode,
                            ResMsg = res.ResMsg,
                            RestagId = res.TagId,
                            ResTxnId = res.TxnId,
                            ResMobileNo = res.MobileNo,
                            ResVrn = res.Vrn,
                            ResTxnNo = res.TxnNo,
                        };

                        _iciciRepo.InsertIciciApiRequestResponseDetail(objReqRes);
                        res.Reason = ex.Message;

                    }

                    return res;
                }

            }


            return new FasTagConfirmOtpResponse() { Reason = "Error when insert Request" };
        }


        private FastagRefundResponse IciciRefundAPiCall(FastagRefundPaymentReQuest ObjClass)
        {

            int RequestID = 0;
            ///Add Amount > 0 Validation 


            InsertFastagIciciApiRequestInput ObjRq = new InsertFastagIciciApiRequestInput()
            {
                BankID = ObjClass.BankID,
                // MobileNo = ObjClass.MobileNo,
                // Amount = Convert.ToString(ObjClass.GrossAmount),
                //Vrn = ObjClass.Vrn,
                CreatedBy = ObjClass.Userid,
                Remarks = "",
                ApiRequestUrL = "Refund",
                // DiscountAmount = string.Format("{0:00.00}", DiscountAmount),
                //NetAmount = string.Format("{0:00.00}", NetAmount)

                MerchantID = ObjClass.Merchantid,
                TerminalID = ObjClass.Terminalid,
                //TxnId = ObjClass.TxnId,
                TxnTime = ObjClass.OrgTxnTime,
                //OTP = ObjClass.Otp,
                //TagId = ObjClass.TagId,

                Invoicedate = ObjClass.Invoicedate,
                Productid = ObjClass.Productid,
                Odometerreading = ObjClass.Odometerreading,
                TransType = ObjClass.TransType,
                Sourceid = ObjClass.Sourceid,
                Formfactor = ObjClass.Formfactor,
                DCSTokenNo = ObjClass.DCSTokenNo,
                Stan = ObjClass.Stan,

                TxnNo = ObjClass.TxnNo,
                Paymentmode = ObjClass.BankID.ToString(),
                Gatewayname = "ICICI",
                Bankname = "ICICI",
                Paycode = ""



            };


            var Reqres = _iciciRepo.InsertIciciFastagApiRequest(ObjRq).Result;



            if (Reqres != null && Reqres.Count() > 0)
            {
                RequestID = Reqres.Cast<InsertFastagIciciApiRequestOutput>().ToList()[0].RequestId;

                if (RequestID > 0 && Reqres.Cast<InsertFastagIciciApiRequestOutput>().ToList()[0].Status != 1)
                {
                    FastagRefundResponse res = new FastagRefundResponse();
                    int status_Code = Reqres.Cast<InsertFastagIciciApiRequestOutput>().ToList()[0].Status;
                    if (status_Code == (int)ValidationStatus.Terminal_Not_Active)
                        res = new FastagRefundResponse() { resCode = Convert.ToString((int)IdfcApiStatus.Terminal_Not_Active), resMsg = Reqres.Cast<InsertFastagIciciApiRequestOutput>().ToList()[0].Reason };

                    else if (status_Code == (int)ValidationStatus.Merchant_Not_Active)
                    {
                        res = new FastagRefundResponse() { resCode = Convert.ToString((int)IdfcApiStatus.Merchant_Not_Active), resMsg = Reqres.Cast<InsertFastagIciciApiRequestOutput>().ToList()[0].Reason };

                    }
                    else if (status_Code == (int)ValidationStatus.Amount_lessthen_ccms)
                    {
                        res = new FastagRefundResponse() { resCode = Convert.ToString((int)IdfcApiStatus.Amount_lessthen_ccms), resMsg = Reqres.Cast<InsertFastagIciciApiRequestOutput>().ToList()[0].Reason };
                    }
                    res.Reason = Reqres.Cast<InsertFastagIciciApiRequestOutput>().ToList()[0].Reason;
                    return res;
                }
            }

            IciciCheckFastagInvoiceIdBatchIdExistInput obj = new IciciCheckFastagInvoiceIdBatchIdExistInput() { Batchid = ObjClass.Batchid, Invoiceid = ObjClass.Invoiceid, RecordType = 2, MerchantID = ObjClass.Merchantid, TerminalID = ObjClass.Terminalid, UserId = ObjClass.Userid, TransTypeId = ObjClass.TransType };
            //var checkInvoiceidExist = _iciciRepo.CheckFastagInvoiceIdBatchIdExist(obj).Result;
            //if (checkInvoiceidExist != null || checkInvoiceidExist.Cast<IciciCheckFastagInvoiceIdBatchIdExistOutput>().ToList()[0].Status == 1)
            //{
            //    UpdateFastagIdfcApiRequestInput ObjupdateRq = new UpdateFastagIdfcApiRequestInput();
            //    ObjupdateRq.Remarks = checkInvoiceidExist.Cast<IdfcCheckFastagInvoiceIdBatchIdExistOutput>().ToList()[0].Reason;
            //    ObjupdateRq.ModifiedBy = ObjClass.Userid;
            //    ObjupdateRq.RequestId = RequestID;
            //    _idfcRepo.UpdateIdfcFastagApiRequest(ObjupdateRq);
            //    return new FastagRefundResponse() { resCode = Convert.ToString((int)IdfcApiStatus.InvoiceId_BatchId_Exist), resMsg = IdfcApiStatus.InvoiceId_BatchId_Exist.GetDisplayName(), Reason = ObjupdateRq.Remarks };

            //}
            string CreateHashKeyByHPPay = String.Empty;
            string TxnTime = DateTime.Now.ToString("ddMMyyyyHHmmss");
            string txnId = StaticClass.APIReferenceNo; //"icici" + Variables.GetUniqueNumber();
            //ObjClass.TxnTime = DateTime.Now.ToString("ddMMyyyyHHmmss");
            string ConcatenatedStringOFParams = CreateRawString(_configuration.GetSection("ICICIAPISettings:SecureToken").Value.ToString(), icici_EntityId, ObjClass.OrgTxnId, icici_POSID, ObjClass.TxnNo);
            CreateHashKeyByHPPay = ComputeSha256Hash(ConcatenatedStringOFParams);
            IciciRefundReQuest req = new IciciRefundReQuest()
            { chkSm = CreateHashKeyByHPPay, entityId = icici_EntityId, orgTxnId = ObjClass.OrgTxnId, txnId = ObjClass.TxnNo, posId = icici_POSID };

            HttpResponseMessage apiResponse = null;
            string responseapi = string.Empty;
            try
            {
                var objrefund = _iciciRepo.CheckFastagRefundProcessedForIciciCustomer(ObjClass).Result;
                if (objrefund != null && objrefund.Count() > 0 && objrefund.Cast<IciciRefundResponse>().ToList()[0].Status == 1)
                {
                    var res = objrefund.Cast<IciciRefundResponse>().ToList()[0];
                    FastagRefundResponse objres = new FastagRefundResponse();
                    objres.resMsg = res.Reason;
                    objres.resCode = res.resCode;
                    objres.txnId = res.txnId;
                    objres.txnNo = res.txnNo;
                    objres.Reason = res.Reason;

                    return objres;

                }

                apiResponse = Variables.CallIciciAPI(icici_apiurl + "Fuel/Refund", JsonConvert.SerializeObject(req), icici_APIClient_ID, icici_API_KEY).Result;
                responseapi = apiResponse.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {

                responseapi = ex.Message;
            }


            //IciciApiRequestResponseInput ObjReq = new IciciApiRequestResponseInput() { ApiRequestUrL = icici_apiurl + "HPPay/refund", ApiRequest = JsonConvert.SerializeObject(req), ApiResponse = responseapi, CreatedBy = ObjClass.Userid, Remarks = "Refund Payment Process" };
            //var rqres = _iciciRepo.InsertIciciApiRequestResponse(ObjReq).Result;
            //
            //int rqID = 0;
            //if (rqres != null && rqres.Count() > 0)
            //{
            //    rqID = rqres.Cast<IciciApiRequestResponseOutput>().ToList()[0].Id;
            //}
            string json = string.Empty;
            json = apiResponse.Content.ReadAsStringAsync().Result;

            if (apiResponse.IsSuccessStatusCode)
            {

                json = apiResponse.Content.ReadAsStringAsync().Result;
            }
            FastagRefundResponse result = new FastagRefundResponse();
            if (!string.IsNullOrEmpty(json))
            {

                result = JsonConvert.DeserializeObject<FastagRefundResponse>(json);

            }
            IciciApiRequestResponseDetailInput objReqRes = new IciciApiRequestResponseDetailInput()
            {
                RqId = RequestID,
                ApiRequestUrL = icici_apiurl + "HPPay/refund",
                ApiRequest = JsonConvert.SerializeObject(req),
                ApiResponse = apiResponse.Content.ReadAsStringAsync().Result,
                CreatedBy = ObjClass.Userid,
                Remarks = "",
                ReqAmount = "",
                ReqChkSm = req.chkSm,
                ReqDiscount = "",
                ReqEntityId = req.entityId,
                ReqIIN = "",
                ReqMobileNo = "",
                ReqNetAmount = "",
                ReqOrgTxnId = req.orgTxnId,
                ReqOrgTxnTime = "",
                ReqOtp = "",
                ReqPosId = req.posId,
                ReqTxnId = txnId,
                ReqTxnTime = "",
                ReqVrn = "",
                ResCode = result.resCode,
                ResMsg = result.resMsg,
                RestagId = "",
                ResTxnId = result.txnId,
                ResVrn = "",
                ResTxnNo = result.txnNo,
            };

            if (!string.IsNullOrEmpty(result.resCode) && Convert.ToInt32(result.resCode) == (int)IdfcApiStatus.Success)
            {
                var objresult = _iciciRepo.RefundCCMSBAlanceForIciciCustomer(ObjClass).Result;
                if (objresult != null && objresult.Count() > 0 && objresult.Cast<UpdateCCMSBAlanceForICICICustomer>().ToList()[0].Status == 1)
                {
                    objReqRes.Remarks = "Refund Process Successfully " + objresult.Cast<UpdateCCMSBAlanceForICICICustomer>().ToList()[0].Reason;
                    objReqRes.IsRefundSuccess = 1;
                    // _iciciRepo.InsertIciciApiRequestResponseDetail(objReqRes);
                    _iciciRepo.UpdateRequestResponseDetailRefundStatus(ObjClass);
                }

                else
                {
                    objReqRes.Remarks = "Refund Failed " + objresult.Cast<UpdateCCMSBAlanceForICICICustomer>().ToList()[0].Reason;
                    objReqRes.IsRefundSuccess = 0;

                    result.resCode = Convert.ToString((int)IdfcApiStatus.Unhandeled_Exception);
                    result.resMsg = "Refund Failed";
                    result.Reason = objresult.Cast<UpdateCCMSBAlanceForICICICustomer>().ToList()[0].Reason;

                }
            }
            else if (!string.IsNullOrEmpty(result.resCode) && Convert.ToInt32(result.resCode) != (int)IdfcApiStatus.Success)
            {
                objReqRes.Remarks = "Refund Failed : " + result.resMsg;
                objReqRes.IsRefundSuccess = 0;
                result.resCode = result.resCode;
                result.resCode = result.resMsg;
                result.Reason = result.resMsg;
            }
            else
            {
                objReqRes.Remarks = "Refund Failed : " + responseapi;
                objReqRes.IsRefundSuccess = 0;
                result.resCode = Convert.ToString((int)IdfcApiStatus.Unhandeled_Exception);
                result.resCode = result.resMsg = IdfcApiStatus.Unhandeled_Exception.ToString();
                result.Reason = responseapi;
            }
            _iciciRepo.InsertIciciApiRequestResponseDetail(objReqRes);
            return result;
        }

        private string CreateRawString(params object[] args)
        {
            StringBuilder sbRawData = new StringBuilder();
            for (int i = 0; i < args.Length; i++)
            {
                sbRawData.Append(Convert.ToString(args[i]).Trim());
            }
            //sbRawData.Append(SecretKey);
            return sbRawData.ToString();
        }

        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString().ToUpper();
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("fastag_insert_customer")]
        public async Task<IActionResult> InsertCustomer([FromBody] CustomerInsertFastTagModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _idfcRepo.InsertCustomerFastTag(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CustomerInsertFastTagModelOutput>().ToList()[0].Status == 1)
                    {

                        #region OldCode
                        //GetSMSValueInputModel ObjSMSValue = new GetSMSValueInputModel();
                        //ObjSMSValue.MethodName = ControllerContext.ActionDescriptor.ActionName;
                        //var SMSResult = await _GetSendRepo.GetSMSValue(ObjSMSValue);
                        //if (SMSResult != null)
                        //{
                        //    List<GetSMSValueOutputModel> item = result.Cast<GetSMSValueOutputModel>().ToList();

                        //    if (item.Count > 0)
                        //    {

                        //        if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].SMSStatus == 1)
                        //        {
                        //            string TemplateName = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].TemplateName;
                        //            string CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].CTID;
                        //            string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].TemplateMessage;
                        //            string Header = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].Header;
                        //        }

                        //        if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].EmailStatus == 1)
                        //        {
                        //            string FromEmail = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].FromEmail;
                        //            string Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].Host;
                        //            string HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].HostPWd;
                        //            string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].EmailTemplateMessage;
                        //        }
                        //    }
                        //}
                        #endregion
                        return this.OkCustom(ObjClass, result, _logger);

                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<CustomerInsertFastTagModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        // [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("fastag_upload_customer_kyc")]
        public async Task<IActionResult> UploadCustomerKYC([FromForm] FastTagCustomerKYCModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _idfcRepo.UploadCustomerKYCFastTag(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<FastTagCustomerKYCModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<FastTagCustomerKYCModelOutput>().ToList()[0].Reason);
                    }

                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_bank_credit_limit")]
        public async Task<IActionResult> GetBankCreditLimit([FromBody] GetBankCreditLimitModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _idfcRepo.GetBankCreditLimit(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetBankCreditLimitModelOutput> item = result.Cast<GetBankCreditLimitModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("bank_credit_limit_request")]
        public async Task<IActionResult> BankCreditLimitRequest([FromBody] BankCreditLimitRequestModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _idfcRepo.BankCreditLimitRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<BankCreditLimitRequestModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<BankCreditLimitRequestModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_bank_credit_limit_status_detail")]
        public async Task<IActionResult> GetBankCreditLimitStatusDetail([FromBody] GetBankCreditLimitStatusDetailsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _idfcRepo.GetBankCreditLimitStatusDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetBankCreditLimitStatusDetailsModelOutput> item = result.Cast<GetBankCreditLimitStatusDetailsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
       [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_fastag_credit_limit_approval")]
        public async Task<IActionResult> GetFastagCreditLimitApproval([FromBody] GetFastagCreditLimitApprovalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _idfcRepo.GetFastagCreditLimitApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetFastagCreditLimitApprovalModelOutput> item = result.Cast<GetFastagCreditLimitApprovalModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_bank_enrollment_status_detail")]
        public async Task<IActionResult> GetBankEnrollmentStatusDetail([FromBody] GetBankEnrollmentStatusDetailModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _idfcRepo.GetBankEnrollmentStatusDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetBankEnrollmentStatusDetailModelOutput> item = result.Cast<GetBankEnrollmentStatusDetailModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_fastag_credit_limit_approval")]
        public async Task<IActionResult> UpdateFastagCreditLimitApproval([FromBody] UpdateFastagCreditLimitApprovalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _idfcRepo.UpdateFastagCreditLimitApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateFastagCreditLimitApprovalModelOutput>().ToList()[0].Status == 1)
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
        [Route("get_fastag_bank_approval_detail")]
        public async Task<IActionResult> GetFastagBankApprovalDetail([FromBody] GetFastagBankApprovalDetailModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _idfcRepo.GetFastagBankApprovalDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetFastagBankApprovalDetailModelOutput> item = result.Cast<GetFastagBankApprovalDetailModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }




        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_fastag_bank_approval")]
        public async Task<IActionResult> UpdateFastagBankApproval([FromBody] UpdateFastagBankApprovalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _idfcRepo.UpdateFastagBankApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateFastagBankApprovalModelOutput>().ToList()[0].Status == 1)
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
        [Route("get_statement_of_account")]
        public async Task<IActionResult> GetStatementofAccount([FromBody] GetStatementofAccountModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _idfcRepo.GetStatementofAccount(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetStatementofAccountModelOutput> item = result.Cast<GetStatementofAccountModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_unverfied_customer_detail_by_form_number")]
        public async Task<IActionResult> GetUnverfiedCustomerDetailbyFormNumber([FromBody] GetUnverfiedCustomerDetailbyFormNumberModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _idfcRepo.GetUnverfiedCustomerDetailbyFormNumber(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.GetCustomerDetails.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_customer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] FastagCustomerUpdateModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _idfcRepo.UpdateCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<FastagCustomerUpdateModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<FastagCustomerUpdateModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }



    }
}
