using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataRepository.CommonRequests
{
    public interface ICommonValidations
    {
        public Task<string> PANValidation(string PANNumber);
        public Task<string> CheckVehicleRegistrationValid(string RegistrationNumber);
    }
}
