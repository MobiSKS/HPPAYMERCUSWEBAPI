using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using HPPay.DataModel.PayCode;
namespace HPPay.DataRepository.PayCode
{
    public interface IPayCodeRepository
    {

        public  Task<IEnumerable<PayCodeGeneratePayCodeDetailsModelOutput>> GeneratePayCodeDetails([FromBody] PayCodeGeneratePayCodeDetailsModelInput ObjClass);

        public  Task<IEnumerable<PayCodeGeneratePayCodeDetailsForEGVModelOutput>> GeneratePayCodeDetailsForEGV([FromBody] PayCodeGeneratePayCodeDetailsForEGVModelInput ObjClass);
        public Task<IEnumerable<CheckCCMSBalanceforPaycodeGenerationModelOutput>> CheckCCMSBalanceforPaycodeGeneration([FromBody] CheckCCMSBalanceforPaycodeGenerationModelInput ObjClass);

        public Task<IEnumerable<PayCodeGetCardNoByVechileNoModelOutput>> GetCardNoByVechileNo([FromBody] PayCodeGetCardNoByVechileNoModelInput ObjClass);

        public Task<IEnumerable<GetCardNoByMobileNoModelOutput>> GetCardNoByMobileNo([FromBody] GetCardNoByMobileNoModelInput ObjClass);
        public Task<IEnumerable<GetPayCodeStatusModelOutput>> GetPayCodeStatus([FromBody] GetPayCodeStatusModelInput ObjClass);

        public Task<IEnumerable<GetPaycodeStatusDetailsModelOutput>> GetPaycodeStatusDetails([FromBody] GetPaycodeStatusDetailsModelInput ObjClass);

        public Task<IEnumerable<CancelPaycodeModelOutput>> CancelPaycode([FromBody] CancelPaycodeModelInput ObjClass);

        //public  Task<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput> GeneratePayCodeForEGVAPI([FromBody] PayCodeGeneratePayCodeDetailsForEGVAPIWithoutStartDateModelIntput ObjClass);

        //public Task<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput> GenerateFuelVoucherWithStartDate([FromBody] PayCodeGeneratePayCodeDetailsForEGVAPIModelInput ObjClass);

        //public Task<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput> GetConsumptionData([FromBody] PayCodeGeneratePayCodeDetailsForEGVAPIModelInput ObjClass);

        public Task<IEnumerable<UpdateExpiryDateModelOutput>> UpdateExpiryDate([FromBody] UpdateExpiryDateModelInput ObjClass);

    }
}
