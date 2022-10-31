using HPPay.Common.Helper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataRepository.CommonRequests
{
    public class RequestServices : IRequestService
    {
        HelperAPI _api = new HelperAPI();
        private readonly IHttpContextAccessor HttpContextAccessor;
        public RequestServices(IHttpContextAccessor HttpContextAccessors)
        {
            HttpContextAccessor = HttpContextAccessors;
        }
        public async Task<string> PANValidationService(StringContent content, string requestUrl)
        {
            using (HttpClient client = new HelperAPI().GetApiPANUrlString())
            {
                using (var Response = await client.PostAsync(requestUrl, content))
                {
                    {
                        var ResponseContent = await Response.Content.ReadAsStringAsync();

                        return ResponseContent;
                    }
                }
            }
        }

        public async Task<string> VehicleRegistrationValidCheckService(StringContent content, string requestUrl)
        {
            using (HttpClient client = new HelperAPI().GetApiVehicleRegistrationUrlString())
            {
                using (var Response = await client.PostAsync(requestUrl, content))
                {
                    {
                        var ResponseContent = await Response.Content.ReadAsStringAsync();

                        return ResponseContent;
                    }
                }
            }
        }
    }


}
