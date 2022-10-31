
using HPPay.DataModel.HLFL;
using HPPay.DataModel.TMFL;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.TMFL
{
    public interface ITMFLRepository
    {
        public Task<IEnumerable<GetCardDetailsModelOutPut>> GetCardDetails([FromBody] GetCardDetailsModelInput ObjClass);

        public Task<MapFacilityModelOutPut> MapFacility([FromBody] MapFacilityModelInput ObjClass);

        public Task<IEnumerable<TMFLCreateCustomerModelOutPut>> CreateCustomer([FromBody] TMFLCreateCustomerModelInput ObjClass);

        public Task<IEnumerable<CreateCardModelOutPut>> CreateCard([FromBody] CreateCardModelInput ObjClass);

        public Task<consumptionRes> GetConsumptionData([FromBody] GetConsumptionDataModelInput ObjClass);

        public Task<IEnumerable<GetCustomerBalanceModelOutPut>> GetCustomerBalance([FromBody] GetCustomerBalanceModelInput ObjClass);

        public Task<IEnumerable<UpdateCardLimitModelOutPut>> CardLimit([FromBody] UpdateCardLimitModelInput ObjClass);

        public Task<IEnumerable<LoyaltyRedeemRequestModelOutPut>> LoyaltyRedeemRequest([FromBody] LoyaltyRedeemRequestModelInput ObjClass);

        public Task<IEnumerable<MapDriverMobileModelOutPut>> MapDriverMobile([FromBody] MapDriverMobileModelInput ObjClass);

        public Task<IEnumerable<CheckCustomerStatusModelOutPut>> CheckCustomerStatus([FromBody] CheckCustomerStatusModelInput ObjClass);

        public Task<IEnumerable<CheckCCMSRechargeStatusModelOutPut>> CheckCCMSRechargeStatus([FromBody] CheckCCMSRechargeStatusModelInput ObjClass);

        public Task<IEnumerable<ProcessCustomerRechargeModelOutPut>> ProcessCustomerRecharge([FromBody] ProcessCustomerRechargeModelInput ObjClass);

        public Task<IEnumerable<HLFLInsertRequestResponseModel>> InsertTMFLRequestResponse([FromBody] HLFLInsertRequestResponseModelInput ObjClass);

        public Task<IEnumerable<HLFLGetCustomerDetailsModelOutput>> USPGetTMFLCustomerDetails([FromBody] HLFLGetCustomerDetailsModelInput ObjClass);

        public Task<IEnumerable<HLFLValidateOTPOutput>> InsertTMFLRechargeRequestDetails([FromBody] HLFLValidateOTPModelInput ObjClass, decimal DDRequestAmount);


    }
}
