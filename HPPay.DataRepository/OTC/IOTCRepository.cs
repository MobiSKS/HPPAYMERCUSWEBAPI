using HPPay.DataModel.Merchant;
using HPPay.DataModel.OTC;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HPPay.DataRepository.OTC
{
    public interface IOTCRepository
    {
        public Task<IEnumerable<MerchantInsertOTCCustomerModelOutput>> InsertOTCCustomer([FromForm] MerchantInsertOTCCustomerModelInput ObjClass);

        public Task<IEnumerable<MerchantCheckAvailityCardOutput>> CheckAvailityOTCCard([FromBody] MerchantCheckAvailityCardInput ObjClass);

        public Task<IEnumerable<MerchantGetAvailityCardOutput>> GetAvailityOTCCard([FromBody] MerchantGetAvailityCardInput ObjClass);

        public Task<MerchantGetAllUnAllocatedCardsModelOutput> GetAllUnAllocatedCardsForOTCCard([FromBody] MerchantGetAllUnAllocatedCardsModelInput ObjClass);


        public Task<IEnumerable<MerchantAllocatedCardsToMerchantModelOutput>> AllocatedOTCCardToMerchant([FromBody] MerchantAllocatedCardsToMerchantModelInput ObjClass);

        public Task<IEnumerable<MerchantViewRequestedCardModelOutput>> ViewRequestedOTCCard([FromBody] MerchantViewRequestedCardModelInput ObjClass);

        public Task<IEnumerable<MerchantInsertDealerWiseCardRequestModelOutput>> InsertDealerWiseOTCCardRequest([FromBody] MerchantInsertDealerWiseCardRequestModelInput ObjClass);

        public Task<MerchantViewCardMerchantAllocationModelOutput> ViewOTCCardMerchantAllocation([FromBody] MerchantViewCardMerchantAllocationModelInput ObjClass);

        public Task<IEnumerable<CardRequestEntryModelOutput>> InsertOTCCardRequest([FromBody] CardRequestEntryModelInput ObjClass);

        public Task<IEnumerable<GetCardAllocationActivationModelOutput>> GetOTCCardAllocationActivation([FromBody] GetCardAllocationActivationModelInput ObjClass); Task<IEnumerable<VerifyOTCCardCustomerModelOutput>> VerifyOTCCardCustomer([FromBody] VerifyOTCCardCustomerModelInput ObjClass);

        public Task<IEnumerable<CustomerGetRegionalOfficerModelOutput>> GetAvailityOTCCardUserWise([FromBody] CustomerGetRegionalOfficerModelInput ObjClass);
        public Task<IEnumerable<OTCInsertOTCCustomerRegionWiseModelOutput>> InsertOTCCustomerRegionWise([FromForm] OTCInsertOTCCustomerRegionWiseModelInput ObjClass);

        public Task<IEnumerable<GetOTCVehicleSpecificCardRequestModelOutput>> GetOTCVehicleSpecificCardRequest([FromBody] GetOTCVehicleSpecificCardRequestModelInput ObjClass);
        public Task<IEnumerable<InsertOTCVehicleSpecificCardRequestModelOutput>> InsertOTCVehicleSpecificCardRequest([FromBody] InsertOTCVehicleSpecificCardRequestModelInput ObjClass);
        public Task<IEnumerable<GetOTCVehicleSpecificCardApproveModelOutput>> GetOTCVehicleSpecificCardApprove([FromBody] GetOTCVehicleSpecificCardApproveModelInput ObjClass);
        public Task<IEnumerable<ApproveOTCVehicleSpecificCardApproveModelOutput>> InsertOTCVehicleSpecificCardRequestApprove([FromBody] ApproveOTCVehicleSpecificCardApproveModelInput ObjClass);

    }
}
