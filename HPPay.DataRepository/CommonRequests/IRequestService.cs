using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataRepository.CommonRequests
{
    public interface IRequestService
    {
        Task<string> PANValidationService(StringContent content, string requestUrl);
        Task<string> VehicleRegistrationValidCheckService(StringContent content, string requestUrl);
    }
}
