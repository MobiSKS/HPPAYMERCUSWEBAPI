using HPPay.DataModel.PayCode;
using HPPay.DataModel.Transaction;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.Transaction
{
    public interface ITransactionRepository
    {
        public Task<IEnumerable<TransactionSalebyTerminalModelOutput>> SaleByTerminal([FromBody] TransactionSalebyTerminalModelInput ObjClass);
        public Task<IEnumerable<RechargeCCMSAccountModelOutput>> RechargeCCMSAccount([FromBody] RechargeCCMSAccountModelInput ObjClass);
        public Task<IEnumerable<GetBatchnoModelOutput>> GetBatchno([FromBody] GetBatchnoModelInput ObjClass);

        public Task<IEnumerable<TransactionBalanceTransferModelOutput>> BalanceTransfer([FromBody] TransactionBalanceTransferModelInput ObjClass);

        public Task<IEnumerable<TransactionGenerateOTPModelOutput>> GenerateOTP([FromBody] TransactionGenerateOTPModelInput ObjClass);

        public Task<IEnumerable<TransactionCardFeePaymentModelOutput>> CardFeePayment([FromBody] TransactionCardFeePaymentModelInput ObjClass);

        public Task<IEnumerable<TranscationsCheckForBatchSettlementModelOutput>> CheckTranscationsForBatchSettlement([FromBody] TranscationsCheckForBatchSettlementModelInput ObjClass);

        public Task<IEnumerable<TransactionBatchSettlementModelOutput>> BatchSettlement([FromBody] TransactionBatchSettlementModelInput ObjClass);

        //public Task<TransactionGetRegistrationProcessModelOutput> GetRegistrationParametersArrayWise([FromBody] TransactionGetRegistrationProcessModelInput ObjClass);

        public Task<TransactionGetRegistrationModelOutput> GetRegistrationParameters([FromBody] TransactionGetRegistrationProcessModelInput ObjClass);
        public Task<IEnumerable<GetTerminalAppUpdateModelOutput>> GetTerminalAppUpdate([FromBody] GetTerminalAppUpdateModelInput ObjClass);
        public Task<IEnumerable<TransactionReloadAccountModelOutput>> ReloadAccount([FromBody] TransactionReloadAccountModelInput ObjClass);

        public Task<IEnumerable<TransactionBalanceEnquiryModelOutput>> BalanceEnquiry([FromBody] TransactionBalanceEnquiryModelInput ObjClass);

        public Task<IEnumerable<TransactionCCMSBalanceEnquiryModelOutput>> CCMSBalanceEnquiry([FromBody] TransactionCCMSBalanceEnquiryModelInput ObjClass);

        public Task<IEnumerable<TransactionContrlCardPinChangeOutput>> ContrlCardPinChange([FromBody] TransactionContrlCardPinChangeInput ObjClass);

        public Task<IEnumerable<TransactionUnblockCardPinModelOutput>> UnblockCardPin([FromBody] TransactionUnblockCardPinModelInput ObjClass);

        public Task<IEnumerable<TransactionChangeCardPinModelOutput>> ChangeCardPin([FromBody] TransactionChangeCardPinModelInput ObjClass);

        public Task<IEnumerable<TransactionUnblockCardPinCheckStatusThroughCCNModelOutput>> UnblockCardPinCheckStatusThroughCCN([FromBody] TransactionUnblockCardPinCheckStatusThroughCCNModelInput ObjClass);



        public Task<IEnumerable<TransactionPinUnblockRequestModelOutput>> PinUnblockRequest([FromBody] TransactionPinUnblockRequestModelInput ObjClass);
        public Task<IEnumerable<TransactionUnblockCardPinThroughCCNModelOutput>> UnblockCardPinThroughCCN([FromBody] TransactionUnblockCardPinThroughCCNModelInput ObjClass);
        public Task<IEnumerable<HMSKeyExchangeModelOutput>> HMSKeyExchange([FromBody] HMSKeyExchangeModelInput ObjClass);

        public Task<IEnumerable<InsertUpdateHSMMasterKeyModelOutput>> InsertUpdateHSMMasterKey([FromBody] InsertUpdateHSMMasterKeyModelInput ObjClass);

        public Task<IEnumerable<HMSLogOnModelOutput>> LogOn([FromBody] HMSLogOnModelInput ObjClass);

        public Task<IEnumerable<UpdateSessionKeyModelOutput>> UpdateHSMSessionKey([FromBody] UpdateSessionKeyModelInput ObjClass);

        public Task<IEnumerable<TransactionReversalFinancialModelOutput>> ReversalFinancialTransactions([FromBody] TransactionReversalFinancialModelInput ObjClass);

        public Task<IEnumerable<TransactionVoidFinancialModelOutput>> VoidFinancialTransactions([FromBody] TransactionVoidFinancialModelInput ObjClass);

        public Task<IEnumerable<TransactionLoyaltyBalanceCheckModelOutput>> LoyaltyBalanceCheck([FromBody] TransactionLoyaltyBalanceCheckModelInput ObjClass);

        public Task<IEnumerable<TranscationsCheckForBatchUploadModelOutput>> BatchUpload([FromBody] TranscationsCheckForBatchUploadModelInput ObjClass);

        public Task<IEnumerable<TransactionTrackingByTerminalModelOutput>> TrackingByTerminal([FromBody] TransactionTrackingByTerminalModelInput ObjClass);

        public Task<IEnumerable<TransactionInsertDriverLoyaltyModelOutput>> InsertDriverLoyalty([FromBody] TransactionInsertDriverLoyaltyModelInput ObjClass);
        public string PlainCardNoAsync(string CardNo, string TerminalId, out int StatusValue);


    }
}
