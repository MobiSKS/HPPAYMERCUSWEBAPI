using HPPay.DataModel.HDFCCreditPouch;
using HPPay.DataModel.ParentCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.ParentCustomer
{
    public interface IParentCustomerRepository
    {
        public Task<IEnumerable<CreateCustomerModelOutput>> InsertParentCustomer([FromBody] CreateCustomerModelInput ObjClass);
        public Task<IEnumerable<GetParentCustomerApprovalModelOutput>> GetParentCustomerForApproval([FromBody] GetParentCustomerApprovalModelInput ObjClass);
        public Task<IEnumerable<ActionOnParentCustomerForApprovalModelOutput>> ActionOnParentCustomerForApproval([FromBody] ActionOnParentCustomerForApprovalModelInput ObjClass);
        public Task<IEnumerable<GetParentCustomerAuthModelOutput>> GetParentCustomerForAuth([FromBody] GetParentCustomerAuthModelInput ObjClass);
        public Task<IEnumerable<ActionOnParentCustomerForAuthModelOutput>> ActionOnParentCustomerForAuth([FromBody] ActionOnParentCustomerForAuthModelInput ObjClass);
        public Task<IEnumerable<GetParentCustomerForUpdateModelOutput>> GetParentCustomerForUpdate([FromBody] GetParentCustomerForUpdateModelInput ObjClass);
        public Task<GetParentCustomerToUpdateModelOutput> GetParentCustomerToUpdate([FromBody] GetParentCustomerToUpdateModelInput ObjClass);
        public Task<IEnumerable<ParentCustomerUpdateModelOutput>> UpdateParentCustomer([FromBody] ParentCustomerUpdateModelInput ObjClass);
        public Task<IEnumerable<GetParentCustomerDispatchDetailsModelOutput>> GetParentCustomerDispatchDetails([FromBody] GetParentCustomerDispatchModelInput ObjClass);
        public Task<IEnumerable<GetParentCustomerCardDetailsModelOutput>> GetParentCustomerCardDetails([FromBody] GetParentCustomerCardModelInput ObjClass);
        public Task<IEnumerable<GetParentCustomerStatusModelOutput>> GetParentCustomerStatus([FromBody] GetParentCustomerStatusModelInput ObjClass);
        public Task<IEnumerable<ParentCustomerReportStatusModelOutput>> GetParentCustomerReportStatus([FromBody] ParentCustomerReportStatusModelInput ObjClass);
        public Task<IEnumerable<GetParentCustomerCardWiseBalancesModelOutput>> GetParentCustomerCardWiseBalances([FromBody] GetParentCustomerCardWiseBalancesModelInput ObjClass);
        public Task<IEnumerable<GetParentCcmsBalanceInfoForCustomerIdModelOutput>> GetParentCcmsBalanceInfoForCustomerId([FromBody] GetParentCcmsBalanceInfoForCustomerIdModelInput ObjClass);
        public Task<GetParentCustomerDetailByCustomerIdModelOutput> GetParentCustomerDetailByCustomerId([FromBody] GetParentCustomerDetailByCustomerIdModelInput ObjClass); 
        public Task<IEnumerable<GetParentTransactionsSummaryModelOutput>> GetParentTransactionsSummary([FromBody] GetParentTransactionsSummaryModelInput ObjClass);
        public Task<IEnumerable<GetChildByParenModelOutput>> GetChildByParent([FromBody] GetChildByParenModelInput ObjClass);
        public Task<GetParentTransactionsSummaryDetailsModelOutput> GetParentTransactionsSummaryDetails([FromBody] GetParentTransactionsSummaryDetailsModelInput ObjClass);
        public Task<IEnumerable<GetParentCustomerBasicSearchModelOutput>> GetParentCustomerBasicSearch([FromBody] GetParentCustomerBasicSearchModelInput ObjClass);
        public Task<IEnumerable<GetParentCustomerBasicSearchCardModelOutput>> GetParentCustomerBasicSearchCard([FromBody] GetParentCustomerBasicSearchCardModelInput ObjClass);
        public Task<IEnumerable<ParentCustomerControlCardPinResetModelOutput>> ParentCustomerControlCardPinReset(ParentCustomerControlCardPinResetModelInput objClass);
        public Task<IEnumerable<GetParentCustomerControlCardSearchModelOutput>> GetParentCustomerControlCardSearch([FromBody] GetParentCustomerControlCardSearchModelInput ObjClass);
        public Task<IEnumerable<ConvertParentCustomertoAggregatorModelOutput>> ConvertParentCustomertoAggregator([FromBody] ConvertParentCustomertoAggregatorModelInput ObjClass);
        public Task<IEnumerable<PCHdfcTransactionStatusModelOutPut>> PCHdfcTransactionStatus([FromBody] PCHdfcTransactionStatusModelInput ObjClass);
        public Task<IEnumerable<ParentCustomerChildMappingModelOutput>> ChildCustomerToParentCustomerMapping([FromBody] ParentCustomerChildMappingModelInput ObjClass);
        public Task<IEnumerable<GetChildMappingDetailsModelOutput>> GetChildMappingDetails([FromBody] GetChildMappingDetailsModelInput ObjClass);
        public Task<IEnumerable<CheckParentCustomerChildMappingModelOutPut>> ChildCustomerToParentCustomerMappingEligibility([FromBody] CheckParentCustomerChildMappingModelInput ObjClass);
        public Task<IEnumerable<CheckParentCustomerChildMappingModelOutPut>> CheckParentCustomerMappingEligibility([FromBody] CheckParentCustomerChildMappingModelInput ObjClass);
        public  Task<IEnumerable<PCConfigureSMSAlertsModelOutput>> PCConfigureSMSAlerts([FromBody] PCConfigureSMSAlertsModelInput ObjClass);
        public  Task<IEnumerable<PCUpdateConfigureSMSAlertsModelOutput>> PCUpdateConfigureSMSAlerts([FromBody] PCUpdateConfigureSMSAlertsModelInput ObjClass);
        public  Task<GetParentCustomerBalanceInfoModelOutput> GetParentCustomerBalanceInfo([FromBody] GetParentCustomerBalanceInfoModelInput ObjClass);
        public  Task<IEnumerable<PCChildCustomerBalanceInfoModelOutPut>> PCChildCustomerBalanceInfo([FromBody] PCChildCustomerBalanceInfoModelInput ObjClass);
        public  Task<IEnumerable<PCCCMSBalanceInfoModelOutPut>> PCCCMSBalanceInfo([FromBody] PCCCMSBalanceInfoModelInput ObjClass);
        public  Task<IEnumerable<PCDrivestarsBalanceInfoModelOutPut>> PCDrivestarsBalanceInfo([FromBody] PCDrivestarsBalanceInfoModelInput ObjClass);
        public  Task<IEnumerable<PCDNDConfigureSMSAlertsModelOutput>> PCDNDConfigureSMSAlerts([FromBody] PCDNDConfigureSMSAlertsModelInput ObjClass);
        public Task<IEnumerable<TransactionDetailsModelOutPut>> TransactionDetails([FromBody] TransactionDetailsModelInput ObjClass);
        public  Task<IEnumerable<UpdateParenttoChildandChildParentFundAllocationModeloutput>> ParentChildFundAllocation([FromBody] UpdateParenttoChildandChildParentFundAllocationModelInput ObjClass);
        public  Task<ParentToChildAndChildParentFundAllocationModelOutPut> ParentToChildAndChildParentFundAllocation([FromBody] ParentToChildAndChildParentFundAllocationModelInput ObjClass);
        public Task<IEnumerable<ParentToAggregatorCustomerUpdateModelOutput>> ConvertParentToAggregator([FromBody] ParentToAggregatorCustomerUpdateModelInput ObjClass);
        public Task<IEnumerable<GetTransactionTypeOutPut>> GetTransactionType([FromBody] GetTransactionTypeInput ObjClass);
        public Task<IEnumerable<ViewChildMappedToParrentModelOutPut>> ViewChildMappedToParrent([FromBody] ViewChildMappedToParrentModelInput ObjClass);
        public Task<IEnumerable<UnMapChildFromParrentModelOutPut>> UnmapChildFromParrent([FromBody] UnMapChildFromParrentModelInput ObjClass);

    }
}
