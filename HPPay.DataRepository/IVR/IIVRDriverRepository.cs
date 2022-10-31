using HPPay.DataModel.Customer;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPPay.DataModel.IVR;

namespace HPPay.DataRepository.IVR
{
    public interface IIVRDriverRepository
    {
        public Task<IEnumerable<ValidateDriverCardPinOutput>> ValidateDriverCardPin([FromBody] ValidateDriverCardPinInput ObjClass);

        public Task<IEnumerable<ValidateDriverMobileNumberOutput>> ValidateDriverMobileNumber([FromBody] ValidateDriverMobileNumberInput ObjClass);

        public Task<IEnumerable<DriverCheckCardBalanceOutput>> DriverCheckCardBalance([FromBody] DriverCheckCardBalanceInput ObjClass);

        public Task<IEnumerable<DriverCheckCardLimitOutput>> DriverCheckCardLimit([FromBody] DriverCheckCardLimitInput ObjClass);

        public Task<IEnumerable<DriverLastTransactionDetailsOutput>> DriverLastTransactionDetails([FromBody] DriverLastTransactionDetailsInput ObjClass);

    }
}
