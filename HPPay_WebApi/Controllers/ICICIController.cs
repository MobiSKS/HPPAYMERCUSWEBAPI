using HPPay.DataModel.IciciAPI;
using HPPay.DataModel.IdfcAPI;
using HPPay.DataRepository.IciciAPI;
using HPPay.Infrastructure.CommonClass;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [Route("api/dtplus/ICICI")]
    [ApiController]
    public class ICICIController : ControllerBase
    {
        private readonly ILogger<ICICIController> _logger;
        private readonly IIciciApiRepository _iciciRepo;
        private readonly IConfiguration _configuration;
        string icici_apiurl;
        string icici_APIClient_ID;
        string icici_API_KEY;
        string icici_PlazaCode;
        string icici_DeviceId;
        string icici_Hex_TagId;
        public ICICIController(ILogger<ICICIController> logger, IIciciApiRepository iciciRepo, IConfiguration configuration)
        {
            _logger = logger;

            _iciciRepo = iciciRepo;
            _configuration = configuration;
            icici_APIClient_ID = _configuration.GetSection("ICICIAPISettings:APIClient_ID").Value.ToString();
            icici_API_KEY = _configuration.GetSection("ICICIAPISettings:API_KEY").Value.ToString();
            icici_apiurl = _configuration.GetSection("ICICIAPISettings:APIUrl").Value.ToString();
            //icici_PlazaCode = _configuration.GetSection("ICICIAPISettings:PlazaCode").Value.ToString();
            //icici_DeviceId = _configuration.GetSection("ICICIAPISettings:DeviceId").Value.ToString();
            //icici_Hex_TagId = _configuration.GetSection("ICICIAPISettings:HexTagId").Value.ToString();
        }



        //[HttpPost]
        //// [ServiceFilter(typeof(CustomAuthenticationFilter))]
        //[Route("fastag_get_otp1")]
        //public async Task<HttpResponseMessage> FasTagGetOTP([FromBody] FastagGetOtpRequest ObjClass)
        //{
        //    FasTagOtpResponse result = new FasTagOtpResponse();
        //    //System.Web.Http.ApiController 
        //    result = new FasTagOtpResponse() { ResCode = Convert.ToString((int)IdfcApiStatus.Amount_Zero), ResMsg = "Amount must be greater then zero" };
        //    HttpResponseMessage res = new HttpResponseMessage();
            
        //    res.Content= new StringContent(JsonConvert.SerializeObject(ObjClass, Formatting.Indented));

        //    //return res;

        //    return new HttpResponseMessage(HttpStatusCode.GatewayTimeout);

        //    //return new HttpResponseMessage(HttpStatusCode.OKresult));
        //    //return apiController.Request.CreateResponse(HttpStatusCode.RequestTimeout);
        //   // return apiController.Request.CreateResponse(HttpStatusCode.GatewayTimeout, result);
        //}

        //[HttpPost]
        //// [ServiceFilter(typeof(CustomAuthenticationFilter))]
        //[Route("icici_init_fuel_payment_request")]
        //public async Task<IActionResult> IciciInitFuelPaymentRequest([FromBody] IciciInitFuelPaymentRequestModelInput ObjClass)
        //{
        //    string txnid = string.Empty;
        //    if (ObjClass == null)
        //    {
        //        return this.BadRequestCustom(ObjClass, null, _logger);
        //    }
        //    else
        //    {

        //        decimal Discount = Convert.ToDecimal(_configuration.GetSection("IDFCAPISettings:Discount").Value.ToString());
        //        decimal DiscountAmount = Convert.ToDecimal(string.Format("{0:00.00}", ObjClass.Amount * Discount / 100));
        //        decimal NetAmount = Convert.ToDecimal(string.Format("{0:00.00}", (ObjClass.Amount - DiscountAmount)));
        //        txnid = "icici" + Variables.GetUniqueNumber();
        //        IciciInitFuelPayHexTagRequest payReq = new IciciInitFuelPayHexTagRequest()
        //        {
        //            Amount = string.Format("{0:00.00}", NetAmount),
        //            DeviceId = ObjClass.DeviceId,
        //            DispenserId = ObjClass.DispenserId,
        //            FUELTxnID = txnid,
        //            HexTagId = icici_Hex_TagId,   //ObjClass.HexTagId,
        //            PlazaCode = icici_PlazaCode, //ObjClass.PlazaCode,
        //            VehicleNumber = ObjClass.VehicleNumber,

        //        };
        //        HttpResponseMessage apiResponse;
        //        string responseapi = string.Empty;

        //        try
        //        {
        //            apiResponse = Variables.CallIciciAPI("https://issuat.icicibank.com/FuelTxnAPI/customer/InitFuelPayHexTag", JsonConvert.SerializeObject(payReq), icici_APIClient_ID, icici_API_KEY).Result;
        //            responseapi = apiResponse.Content.ReadAsStringAsync().Result;

        //            IciciApiRequestResponseInput ObjReq = new IciciApiRequestResponseInput() { ApiRequestUrL = icici_apiurl + "InitFuelPayHexTag", ApiRequest = JsonConvert.SerializeObject(payReq), ApiResponse = responseapi, CreatedBy = ObjClass.Userid, Remarks = "InitFuelPayment Call" };
        //            var rqres = _iciciRepo.InsertIciciApiRequestResponse(ObjReq).Result;

        //            string json = string.Empty;
        //            int rqID = 0;
        //            if (rqres != null && rqres.Count() > 0)
        //            {
        //                rqID = rqres.Cast<IciciApiRequestResponseOutput>().ToList()[0].Id;
        //            }

        //            json = apiResponse.Content.ReadAsStringAsync().Result;

        //            if (apiResponse != null && apiResponse.IsSuccessStatusCode)
        //            {
        //                json = apiResponse.Content.ReadAsStringAsync().Result;
        //            }

        //            IciciInitFuelPayHexTagResponse result = new IciciInitFuelPayHexTagResponse();
        //            if (!string.IsNullOrEmpty(json))
        //            {
        //                result = JsonConvert.DeserializeObject<IciciInitFuelPayHexTagResponse>(json);

        //            }
        //            //TODO insert RQ RS Detail

        //            return this.OkCustom(ObjClass, result, _logger);
        //        }
        //        catch (System.Exception ex)
        //        {
        //            string req;
        //            responseapi = ex.Message;
        //            //IciciApiRequestResponseInput ObjReq = new IciciApiRequestResponseInput() { ApiRequestUrL = apiurl + "InitFuelPayHexTag", ApiRequest = JsonConvert.SerializeObject(""), ApiResponse = responseapi, CreatedBy = ObjClass.Userid, Remarks = "InitFuelPayment Call" };
        //            //var rqres = _iciciRepo.InsertIciciApiRequestResponse(ObjReq).Result;
        //            IciciInitFuelPayHexTagResponse res = new IciciInitFuelPayHexTagResponse() { IsSuccess = false };
        //            return this.FailCustom(ObjClass, res, _logger, "");
        //        }

        //    }
        //}

        //[HttpPost]
        //// [ServiceFilter(typeof(CustomAuthenticationFilter))]
        //[Route("icici_complete_fuel_payment")]
        //public async Task<IActionResult> IciciCompleteFuelPayment([FromBody] IciciCompleteFuelPaymentInput ObjClass)
        //{
        //    string txnid = string.Empty;
        //    if (ObjClass == null)
        //    {
        //        return this.BadRequestCustom(ObjClass, null, _logger);
        //    }
        //    else
        //    {
        //        try
        //        {
        //            IciciCompleteFuelPayRequest payReq = new IciciCompleteFuelPayRequest()
        //            {
        //                FUELTxnID = ObjClass.FUELTxnID,
        //                OTP = ObjClass.OTP,

        //            };
        //            HttpResponseMessage apiResponse;
        //            string responseapi = string.Empty;

        //            apiResponse = Variables.CallIciciAPI(icici_apiurl + "CompleteFuelPayRequest", JsonConvert.SerializeObject(payReq), icici_APIClient_ID, icici_API_KEY).Result;
        //            responseapi = apiResponse.Content.ReadAsStringAsync().Result;

        //            IciciApiRequestResponseInput ObjReq = new IciciApiRequestResponseInput() { ApiRequestUrL = icici_apiurl + "CompleteFuelPayRequest", ApiRequest = JsonConvert.SerializeObject(payReq), ApiResponse = responseapi, CreatedBy = ObjClass.Userid, Remarks = "InitFuelPayment Call" };
        //            var rqres = _iciciRepo.InsertIciciApiRequestResponse(ObjReq).Result;

        //            string json = string.Empty;
        //            int rqID = 0;
        //            if (rqres != null && rqres.Count() > 0)
        //            {
        //                rqID = rqres.Cast<IciciApiRequestResponseOutput>().ToList()[0].Id;
        //            }

        //            json = apiResponse.Content.ReadAsStringAsync().Result;

        //            if (apiResponse != null && apiResponse.IsSuccessStatusCode)
        //            {
        //                json = apiResponse.Content.ReadAsStringAsync().Result;
        //            }

        //            IciciInitFuelPayHexTagResponse result = new IciciInitFuelPayHexTagResponse();
        //            if (!string.IsNullOrEmpty(json))
        //            {
        //                result = JsonConvert.DeserializeObject<IciciInitFuelPayHexTagResponse>(json);

        //            }

        //            //TODO insert RQ RS Detail

        //            return this.OkCustom(ObjClass, result, _logger);


        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }

        //    }

        //}
    }
}
