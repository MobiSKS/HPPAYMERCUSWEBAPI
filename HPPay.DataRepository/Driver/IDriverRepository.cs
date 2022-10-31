using HPPay.DataModel.Merchant;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HPPay.DataRepository.Driver
{
    public interface IDriverRepository
    {
        public Task<IEnumerable<MerchantCheckAvailityCardOutput>> CheckAvailityDriverCard([FromBody] MerchantCheckAvailityCardInput ObjClass);

        public Task<IEnumerable<MerchantGetAvailityCardOutput>> GetAvailityDriverCard([FromBody] MerchantGetAvailityCardInput ObjClass);

        public Task<MerchantGetAllUnAllocatedCardsModelOutput> GetAllUnAllocatedCardsForDriverCard([FromBody] MerchantGetAllUnAllocatedCardsModelInput ObjClass);

        public Task<IEnumerable<MerchantAllocatedCardsToMerchantModelOutput>> AllocatedDriverCardToMerchant([FromBody] MerchantAllocatedCardsToMerchantModelInput ObjClass);

        public Task<IEnumerable<MerchantInsertDriverCardCustomerModelOutput>> InsertDriverCardCustomer([FromForm] MerchantInsertDriverCardCustomerModelInput ObjClass);

        public Task<IEnumerable<MerchantViewRequestedCardModelOutput>> ViewRequestedDriverCard([FromBody] MerchantViewRequestedCardModelInput ObjClass);

        public Task<IEnumerable<MerchantInsertDealerWiseCardRequestModelOutput>> InsertDealerWiseDriverCardRequest([FromBody] MerchantInsertDealerWiseCardRequestModelInput ObjClass);

        public Task<MerchantViewCardMerchantAllocationModelOutput> ViewDriverCardMerchantAllocation([FromBody] MerchantViewCardMerchantAllocationModelInput ObjClass);

        public Task<IEnumerable<CardRequestEntryModelOutput>> InsertDriverCardRequest([FromBody] CardRequestEntryModelInput ObjClass);

        public Task<IEnumerable<GetCardAllocationActivationModelOutput>> GetDriverCardAllocationActivation([FromBody] GetCardAllocationActivationModelInput ObjClass);

    }
}
