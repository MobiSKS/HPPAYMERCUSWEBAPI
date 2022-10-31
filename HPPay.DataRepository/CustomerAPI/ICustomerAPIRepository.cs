using HPPay.DataModel.CustomerAPI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HPPay.DataRepository.CustomerAPI
{
    public interface ICustomerAPIRepository
    {
        Task<IEnumerable<CustomerAPICheckVechileNoModelOutput>> CustomerAPICheckVechileNo([FromBody] CustomerAPICheckVechileNoModelInput ObjClass);
        Task<IEnumerable<CustomerAPIGetCustomerBalanceModelOutput>> GetCustomerBalance([FromBody] CustomerAPIGetCustomerBalanceModelInput ObjClass);
        Task<IEnumerable<CustomerAPIGetCardBalanceModelOutput>> GetCardBalance([FromBody] CustomerAPIGetCardBalanceModelInput ObjClass);
        Task<CustomerAPIGetCustomerDetailsByMobileNoModelOutput> GetCustomerDetailsByMobileNo([FromBody] CustomerAPIGetCustomerDetailsByMobileNoModelInput ObjClass);
        Task<IEnumerable<CustomerAPIBlockCardsModelOutput>> BlockCards([FromBody] CustomerAPIBlockCardsModelInput ObjClass);
        Task<IEnumerable<CustomerAPIUnblockCardsModelOutput>> UnblockCards([FromBody] CustomerAPIUnblockCardsModelInput ObjClass);
        Task<IEnumerable<CustomerAPIMapCardlessModelOutput>> MapCardless([FromBody] CustomerAPIMapCardlessModelInput ObjClass);
        Task<Tuple<List<CustomerAPIGetTransactionStatus>, List<CustomerAPIGetTransactionsModelOutput>>> GetTransactions([FromBody] CustomerAPIGetTransactionsModelInput ObjClass);
        Task<IEnumerable<CustomerAPIGetCardLimitModelOutput>> GetCardLimit([FromBody] CustomerAPIGetCardLimitModelInput ObjClass);
        Task<IEnumerable<CustomerAPISetCardLimitModelOutput>> SetCardLimit([FromBody] CustomerAPISetCardLimitModelInput ObjClass);
        Task<IEnumerable<CustomerAPIHotlistReactivateCardModelOutput>> HotlistReactivateCard([FromBody] CustomerAPIHotlistReactivateCardModelInput ObjClass);
        Task<IEnumerable<CustomerAPIHotlistReactivateCustomerModelOutput>> HotlistReactivateCustomer([FromBody] CustomerAPIHotlistReactivateCustomerModelInput ObjClass);
        Task<IEnumerable<CustomerAPISetCardAddOnLimitModelOutput>> SetCardAddOnLimit([FromBody] CustomerAPISetCardAddOnLimitModelInput ObjClass);
        Task<IEnumerable<CustomerAPIIsCustomerActiveModelOutput>> IsCustomerActive([FromBody] CustomerAPIIsCustomerActiveModelInput ObjClass);
        Task<IEnumerable<CustomerAPITransactionQueryStatusWithDetailsModelOutput>> TransactionQueryStatusWithDetails([FromBody] CustomerAPITransactionQueryStatusWithDetailsModelInput ObjClass);
        Task<IEnumerable<CustomerAPIGetCustomerHotlistStatusModelOutput>> GetCustomerHotlistStatus([FromBody] CustomerAPIGetCustomerHotlistStatusModelInput ObjClass);
        Task<IEnumerable<CustomerAPIDehotlistCustomerWithPANModelOutput>> DehotlistCustomerWithPAN([FromBody] CustomerAPIDehotlistCustomerWithPANModelInput ObjClass);
        
        Task<IEnumerable<CustomerAPICheckCustomerActivityModelOutput>> CheckCustomerActivity([FromBody] CustomerAPICheckCustomerActivityModelInput ObjClass);
        Task<IEnumerable<CustomerAPIAggCustomerCreationModelOutput>> AggCustomerCreation([FromBody] CustomerAPIAggCustomerCreationModelInput ObjClass);
        Task<IEnumerable<CustomerAPISetCardAllLimitModelOutput>> SetCardAllLimit([FromBody] CustomerAPISetCardAllLimitModelInput ObjClass);
        Task<IEnumerable<CustomerAPITransactionQueryStatusModelOutput>> TransactionQueryStatus([FromBody] CustomerAPITransactionQueryStatusModelInput ObjClass);
        Task<IEnumerable<CustomerAPIUnblockUserCardPINModelOutput>> UnblockUserCardPIN([FromBody] CustomerAPIUnblockUserCardPINModelInput ObjClass);
        Task<CustomerAPIGetProductRSPModelFInalOutput> GetProductRSP([FromBody] CustomerAPIGetProductRSPModelInput ObjClass);
       Task<CustomerAPIGetConsumptionDataModelOutput> GetConsumptionData([FromBody] CustomerAPIGetConsumptionDataModelInput ObjClass);
        Task<IEnumerable<CustomerAPICustomerHotlistRequestModelOutput>> CustomerHotlistRequest([FromBody] CustomerAPICustomerHotlistRequestModelInput ObjClass);
        Task<IEnumerable<CustomerAPICreateCardModelOutput>> CreateCard([FromForm] CustomerAPICreateCardModelInput ObjClass);
        Task<IEnumerable<CustomerAPIParentChildBalanceTransferModelOutput>> ParentChildBalanceTransfer([FromBody] CustomerAPIParentChildBalanceTransferModelInput ObjClass);
        Task<IEnumerable<CustomerAPIChildtoParentBalanceTransferRequestModelOutput>> ChildtoParentBalanceTransferRequest([FromBody] CustomerAPIChildtoParentBalanceTransferRequestModelInput ObjClass);
        Task<IEnumerable<CustomerAPICheckBalanceTransferStatusModelOutput>> CheckBalanceTransferStatus([FromBody] CustomerAPICheckBalanceTransferStatusModelInput ObjClass);
        Task<IEnumerable<CustomerAPICheckLoyaltyRedeemStatusModelOutput>> CheckLoyaltyRedeemStatus([FromBody] CustomerAPICheckLoyaltyRedeemStatusModelInput ObjClass);
        Task<IEnumerable<CustomerAPILoyaltyRedeemRequestModelOutput>> LoyaltyRedeemRequest([FromBody] CustomerAPILoyaltyRedeemRequestModelInput ObjClass);
        Task<IEnumerable<CustomerAPIChildtoParentBalanceTransferModelOutput>> ChildtoParentBalanceTransfer([FromBody] CustomerAPIChildtoParentBalanceTransferModelInput ObjClass);
        Task<IEnumerable<CustomerAPIParentChildBalanceTransferV2ModelOutput>> ParentChildBalanceTransferV2([FromBody] CustomerAPIParentChildBalanceTransferV2ModelInput ObjClass);
        Task<Tuple<List<CustomerAPIGetTransactionV2Status>, List<CustomerAPIGetTransactionsV2ModelOutput>>> GetTransactionsV2([FromBody] CustomerAPIGetTransactionsV2ModelInput ObjClass);
        Task<IEnumerable<CustomerAPIGenerateMPinModelOutput>> GenerateMPin([FromBody] CustomerAPIGenerateMPinModelInput ObjClass);
        //Task<IEnumerable<CustomerAPICustomerAPIGetHSDTransactionDetailsModelOutput>> CustomerAPIGetHSDTransactionDetails([FromBody] CustomerAPICustomerAPIGetHSDTransactionDetailsModelInput ObjClass);
        Task<IEnumerable<CustomerAPIGenerateOTPModelOutput>> CustomerAPIGenerateTransactionOTP([FromBody] CustomerAPIGenerateOTPModelInput ObjClass);

    }

}
