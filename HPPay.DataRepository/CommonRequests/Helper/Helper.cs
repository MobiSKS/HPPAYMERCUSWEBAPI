using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.Common.Helper
{
    public class HelperAPI
    {
        private HttpClient _client;
        public HttpClient GetApiPANUrlString()
        {
            var ApiUrl = "https://testapi.karza.in/";
            _client = new HttpClient();
            _client.BaseAddress = new Uri(ApiUrl);
            _client.DefaultRequestHeaders.Add("x-karza-key", "3OSJINpsUYitlG9d");
            return _client;
        }
        public HttpClient GetApiVehicleRegistrationUrlString()
        {
            var ApiUrl = "https://testapi.karza.in/";
            _client = new HttpClient();
            _client.BaseAddress = new Uri(ApiUrl);
            _client.DefaultRequestHeaders.Add("x-karza-key", "3OSJINpsUYitlG9d");
            return _client;
        }
    }
}
