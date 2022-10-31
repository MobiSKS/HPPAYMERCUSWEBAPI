using HPPay.DataModel.PayCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.EGVAPI
{
    public interface IEGVAPIRepository
    {
        public  Task<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput> GeneratePayCodeForEGVAPI([FromBody] PayCodeGeneratePayCodeDetailsForEGVAPIWithoutStartDateModelIntput ObjClass);

        public  Task<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput> GenerateFuelVoucherWithStartDate([FromBody] PayCodeGeneratePayCodeDetailsForEGVAPIModelInput ObjClass);

        public Task<PayCodeGetConsumptionDataForEGVAPIModelOutput> GetConsumptionData([FromBody] PayCodeGetConsumptionDataForEGVAPIModelInput ObjClass);

       
    }
}
