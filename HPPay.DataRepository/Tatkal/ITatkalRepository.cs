using HPPay.DataModel.Merchant;
using HPPay.DataModel.Tatkal;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HPPay.DataRepository.Tatkal
{
    public interface ITatkalRepository
    {
        public Task<IEnumerable<MerchantCheckAvailityCardOutput>> CheckAvailityTatkalCard([FromBody] MerchantCheckAvailityCardInput ObjClass);

        public Task<IEnumerable<MerchantGetAvailityCardOutput>> GetAvailityTatkalCard([FromBody] MerchantGetAvailityCardInput ObjClass);

        public Task<MerchantGetAllUnAllocatedCardsModelOutput> GetAllUnAllocatedCardsForTatkalCard([FromBody] MerchantGetAllUnAllocatedCardsModelInput ObjClass);

        public Task<IEnumerable<MerchantAllocatedCardsToMerchantModelOutput>> AllocatedTatkalCardToMerchant([FromBody] MerchantAllocatedCardsToMerchantModelInput ObjClass);

        public Task<IEnumerable<MerchantViewRequestedCardModelOutput>> ViewRequestedTatkalCard([FromBody] MerchantViewRequestedCardModelInput ObjClass);

        public Task<IEnumerable<MerchantInsertDealerWiseCardRequestModelOutput>> InsertDealerWiseTatkalCardRequest([FromBody] MerchantInsertDealerWiseCardRequestModelInput ObjClass);

        public Task<MerchantViewCardMerchantAllocationModelOutput> ViewTatkalCardMerchantAllocation([FromBody] MerchantViewCardMerchantAllocationModelInput ObjClass);

        public Task<IEnumerable<CardRequestEntryModelOutput>> InsertTatkalCardRequest([FromBody] CardRequestEntryModelInput ObjClass);

        public  Task<IEnumerable<InsertTatkalCustomerModelOutput>> InsertTatkalCustomer([FromForm] InsertTatkalCustomerModelInput ObjClass);
        public Task<IEnumerable<GetCardAllocationActivationModelOutput>> GetTatkalCardAllocationActivation([FromBody] GetCardAllocationActivationModelInput ObjClass);

        public Task<MapTatkalCardsToTatkalCustomerModelOutput> MapTatkalCardsToTatkalCustomer([FromBody] MapTatkalCardsToTatkalCustomerModelInput ObjClass);

        public Task<IEnumerable<UpdateMapTatkalCardsToTatkalCustomerModelOutput>> UpdateMapTatkalCardsToTatkalCustomer([FromBody] UpdateMapTatkalCardsToTatkalCustomerModelInput ObjClass);

        public Task<IEnumerable<ViewTatkalCardsModelOutput>> ViewTatkalCards([FromBody] ViewTatkalCardsModelInput ObjClass);

        public Task<IEnumerable<ValidateTatkalCustomerWithRegionModelOutput>> ValidateTatkalCustomerWithRegion([FromBody] ValidateTatkalCustomerWithRegionModelInput ObjClass);


    }
}
