using HPPay.DataModel.HDFCPG;
using HPPay.DataModel.MobilePaymentGatewayModel;
using HPPay.DataRepository.MobilePaymentGateway;
using HPPay.DataRepository.SMSGetSend;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [Route("api/hppay/Mobile")]
    [ApiController]
    public class MobilePaymentGatewayController : ControllerBase
    {
        private readonly ILogger<MobilePaymentGatewayController> _logger;
        private readonly IMobilePaymentGatewayRepository _pghdfcRepo;
        private readonly IConfiguration _configuration;
        private readonly ISMSGetSendRepository _GetSendRepo;
        public MobilePaymentGatewayController(ILogger<MobilePaymentGatewayController> logger, IMobilePaymentGatewayRepository pghdfcRepo, IConfiguration configuration, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _pghdfcRepo = pghdfcRepo;
            _configuration = configuration;
            _GetSendRepo = GetSendRepo;
        }
         
        
        [HttpPost]
       // [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("initiate_hdfc_mobile_payment")]
        public async Task<IActionResult> InitiateMobilePaymentRequest([FromBody] MobilePaymentGatewayModelInPut ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {           
                ObjClass.OrderId = RandomDigits(10);
                ObjClass.MerchantId = _configuration.GetSection("HDFCPGMobile:MerchantId").Value;
                ObjClass.workingKey = _configuration.GetSection("HDFCPGMobile:Workingkey").Value;
                ObjClass.accessCode = _configuration.GetSection("HDFCPGMobile:accessCode").Value;
                string inputStringForHash = ObjClass.OrderId+ ObjClass.workingKey + ObjClass.MerchantId;
                string hashKeyForToken = SHA512(inputStringForHash);
                HttpClient client = new HttpClient();                    
                var data = new[]
                {
                    new KeyValuePair<string, string>("requestId", ObjClass.OrderId),
                    new KeyValuePair<string, string>("accessCode", ObjClass.accessCode),
                    new KeyValuePair<string, string>("requestHash", hashKeyForToken.ToLower())
                };
                HttpResponseMessage response =  await client.PostAsync(_configuration.GetSection("HDFCPGMobile:getSecureTokenApiUrl").Value, 
                    new FormUrlEncodedContent(data));

                var success= response.IsSuccessStatusCode.ToString();

                var PayAuthContent = await response.Content.ReadAsStringAsync();
                JObject PayAuthObj = JObject.Parse(JsonConvert.DeserializeObject(PayAuthContent).ToString());
                string PayAuthMessage = PayAuthObj.ToString();
                 PayAuthObj = JObject.Parse(JsonConvert.DeserializeObject(PayAuthMessage).ToString());

                GetSecureToken gst = PayAuthObj.ToObject<GetSecureToken>();
                string SecureToken=gst.secureToken;
                inputStringForHash = ObjClass.OrderId + ObjClass.Currency + ObjClass.Amount + SecureToken;
                string hashKeyForAPI = SHA512(inputStringForHash);
                ObjClass.ActionType = "Add";
                var result = await _pghdfcRepo.InitiateMobilePaymentRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    MobilePaymentGatewayModelOutPut op = new MobilePaymentGatewayModelOutPut();
                    op.RequestHash = hashKeyForAPI.ToLower();
                    op.Amount = ObjClass.Amount;
                    op.orderId = ObjClass.OrderId;
                    op.Status = 1;
                    op.Reason = "Success";
                    op.ResponseUrl = _configuration.GetSection("HDFCPGMobile:ResponseUrl").Value;

                    List<MobilePaymentGatewayModelOutPut> item = result.Cast<MobilePaymentGatewayModelOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, op, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        public static string SHA512(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }

        [HttpPost]
        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("updateStatus_ccms_recharge")]
        public async Task<IActionResult> HDFCPGUpdateStatus([FromBody] MobilePaymentGatewayModelInPut ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                ObjClass.ActionType = "Update";
                var result = await _pghdfcRepo.InitiateMobilePaymentRequest(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<MobilePaymentGatewayModelOutPut> item = result.Cast<MobilePaymentGatewayModelOutPut>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("generate_QR_code")]
        public async Task<IActionResult> GenerateQRCode([FromBody] GenerateQRCodeModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            { 
                var result = await _pghdfcRepo.GenerateQRCode(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GenerateQRCodeModelOutput> item = result.Cast<GenerateQRCodeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("validate_QR_code")]
        public async Task<IActionResult> ValidateQRCode([FromBody] ValidateQRCodeModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _pghdfcRepo.ValidateQRCode(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<ValidateQRCodeModelOutput> item = result.Cast<ValidateQRCodeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


    }

}

