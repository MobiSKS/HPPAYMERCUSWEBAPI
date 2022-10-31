using HPPay.Common.Helper;
using HPPay.DataModel.CommonValidations;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataRepository.CommonRequests
{
    public class CommonValidations : ICommonValidations
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRequestService _requestService;

        public CommonValidations(IHttpContextAccessor httpContextAccessor, IRequestService requestServices)
        {
            _httpContextAccessor = httpContextAccessor;
            _requestService = requestServices;
        }
        public async Task<string> PANValidation(string PANNumber)
        {
            string apiUrl = "v2/pan";

            var input = new
            {
                consent = "Y",
                pan = PANNumber
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");

            var response = await _requestService.PANValidationService(content, apiUrl);

            return response;
        }

        public async Task<string> CheckVehicleRegistrationValid(string RegistrationNumber)
        {
            string apiUrl = "v3/rc-advanced";

            var input = new VehicleRegistrationValidateRequestModel()
            {
                registrationNumber = RegistrationNumber,
                consent = "Y",
                version = "3.1"
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");

            var response = await _requestService.VehicleRegistrationValidCheckService(content, apiUrl);

            return response;
        }
    }


}
