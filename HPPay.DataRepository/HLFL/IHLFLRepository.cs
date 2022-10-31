
using System.Collections.Generic;
using System.Threading.Tasks;
using HPPay.DataModel.HLFL;
using Microsoft.AspNetCore.Mvc;

namespace HPPay.DataRepository.HLFL
{
    public interface IHLFLRepository
    {
        public Task<IEnumerable<HLFLCreateCustomerModelOutput>> HLFLCreateCustomer([FromBody] HLFLCreateCustomerModelInput ObjClass);

        public Task<HLFLMapFacilityModelOutPut> HLFLMapFacility([FromBody] HLFLMapFacilityModelInput ObjClass);

        public Task<IEnumerable<HLFLCreateCardModelOutPut>> HLFLCreateCard([FromForm] HLFLCreateCardModelInput ObjClass);

        public Task<IEnumerable<HLFLCardLimitModelOutPut>> HLFLCardLimit([FromBody] HLFLCardLimitModelInput ObjClass);

        public Task<IEnumerable<HLFLMapDriverMobileModelOutPut>> HLFLMapDriverMobile([FromBody] HLFLMapDriverMobileModelInput ObjClass);

        public Task<IEnumerable<HLFLCheckCustomerStatusModelOutPut>> HLFLCheckCustomerStatus([FromBody] HLFLCheckCustomerStatusModelInput ObjClass);

        public Task<IEnumerable<HLFLCheckCCMSRechargeStatusModelOutPut>> HLFLCheckCCMSRechargeStatus([FromBody] HLFLCheckCCMSRechargeStatusModelInPut ObjClass);

        public Task<IEnumerable<HLFLProcessCustomerRechargeModelOutPut>> HLFLProcessCustomerRecharge([FromBody] HLFLProcessCustomerRechargeModelInPut ObjClass);
         
        public Task<HLFLValidateCustomerModelOutPut> HLFLValidateCustomer([FromBody] HLFLValidateCustomerModelInput ObjClass);

        public Task<HLFLGetProductRSPModelOutPut> HLFLGetProductRSP([FromBody] HLFLGetProductRSPModelInPut ObjClass);

        public Task<IEnumerable<HLFLInsertRequestResponseModel>> InsertHLFLRequestResponse([FromBody] HLFLInsertRequestResponseModelInput ObjClass);

        public Task<IEnumerable<HLFLGetCustomerDetailsModelOutput>> USPGetHLFLCustomerDetails([FromBody] HLFLGetCustomerDetailsModelInput ObjClass);
         
        public Task<IEnumerable<HLFLValidateOTPOutput>> InsertHLFLRechargeRequestDetails([FromBody] HLFLValidateOTPModelInput ObjClass, decimal DDRequestAmount);

        public Task<IEnumerable<CheckIfHLFLUserModelOutput>> CheckIfHLFLUser([FromBody] CheckIfHLFLUserModelInput ObjClass);

        public Task<IEnumerable<HLFLCheckTransactionStatusOutPutModel>> HLFLCheckTransactionStatus([FromBody] HLFLCheckTransactionStatusInputModel ObjClass);

        public Task<HLFLGetStatusAndSourceOutPutModel> HLFLGetStatusAndSource([FromBody] HLFLGetStatusAndSourceInPutModel ObjClass);

        public Task<IEnumerable<HLFLInsertSendEmailLogOutModel>> uspHLFLInsertSendEmailLog([FromBody] HLFLInsertSendEmailLogInputModel ObjClass);

    }

}
