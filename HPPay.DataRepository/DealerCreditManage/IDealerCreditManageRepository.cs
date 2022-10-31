using HPPay.DataModel.DealerCreditManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.DealerCreditManage
{
    public interface IDealerCreditManageRepository
    {
        //  For Customer Dealer Credit Management
        public Task<GetDealerCreditMappingDetailsModelOutput> GetDealerCreditMappingDetails([FromBody] GetDealerCreditMappingDetailsModelInput ObjClass);
        public Task<IEnumerable<GetListCreditCloseLimitTypeModelOutput>> GetListCreditCloseLimitType([FromBody] GetListCreditCloseLimitTypeModelInput ObjClass);

        public Task<IEnumerable<GetListCreditPeriodModelOutput>> GetListCreditPeriod([FromBody] GetListCreditPeriodModelInput ObjClass);


        public Task<IEnumerable<CustomerMerchantMappingEnableDisableModelOutput>> CustomerMerchantMappingEnableDisable([FromBody] CustomerMerchantMappingEnableDisableModelInput ObjClass);

        public Task<IEnumerable<DCMInsertMapDealerForCreditSaleModelOutput>> DCMInsertMapDealerForCreditSale([FromBody] DCMInsertMapDealerForCreditSaleModelInput ObjClass);

        public Task<IEnumerable<UpdateDealerCreditMappingModelOutput>> UpdateDealerCreditMapping([FromBody] UpdateDealerCreditMappingModelInput ObjClass);
        public Task<IEnumerable<GetDealerCreditSaleStatementModelOutput>> GetDealerCreditSaleStatement([FromBody] GetDealerCreditSaleStatementModelInput ObjClass);

        public Task<IEnumerable<GetDealerCreditSaleViewModelOutput>> GetDealerCreditSaleView([FromBody] GetDealerCreditSaleViewModelInput ObjClass);
        public Task<IEnumerable<UpdateDealerCreditPaymentInBulkModelOutput>> UpdateDealerCreditPaymentInBulk([FromBody] UpdateDealerCreditPaymentInBulkModelInput ObjClass);


        //  For Merchant Dealer Credit Management

        public Task<GetMerchantDealerCreditSaleStatementModelOutput> GetMerchantDealerCreditSaleStatement([FromBody] GetMerchantDealerCreditSaleStatementModelInput ObjClass);
        public Task<GetDownloadMerchantDealerCreditSaleStatementModelOutput> GetDownloadMerchantDealerCreditSaleStatement([FromBody] GetDownloadMerchantDealerCreditSaleStatementModelInput ObjClass);

        public Task<IEnumerable<GetStatementDateListModelOutput>> GetStatementDateList([FromBody] GetStatementDateListModelInput ObjClass);


        public Task<IEnumerable<GetCreditSaleViewModelOutput>> GetCreditSaleView([FromBody] GetCreditSaleViewModelInput ObjClass);

        public Task<GetCreditSaleOutstandingDetailsModelOutput> GetCreditSaleOutstandingDetails([FromBody] GetCreditSaleOutstandingDetailsModelInput ObjClass);

        public Task<IEnumerable<GetDealerCreditSaleDetailsModelOutput>> GetDealerCreditSaleDetails([FromBody] GetDealerCreditSaleDetailsModelInput ObjClass);

        public Task<IEnumerable<GetDealerCreditPaymentInBulkModelOutput>> GetDealerCreditPaymentInBulk([FromBody] GetDealerCreditPaymentInBulkModelInput ObjClass);

        public Task<IEnumerable<GenerateOTPCreditClosePaymentModelOutput>> GenerateOTPCreditClosePayment([FromBody] GenerateOTPCreditClosePaymentModelInput ObjClass);

        public Task<IEnumerable<ValidateOTPUpdateCreditClosePaymentModelOutput>> ValidateOTPUpdateCreditClosePayment([FromBody] ValidateOTPUpdateCreditClosePaymentModelInput ObjClass);
        public Task<IEnumerable<GetCreditClosePaymentModelOutput>> GetCreditClosePayment([FromBody] GetCreditClosePaymentModelInput ObjClass);
        public Task<IEnumerable<GetDealerCreditPaymentStatusModelOutput>> GetDealerCreditPaymentStatus([FromBody] GetDealerCreditPaymentStatusModelInput ObjClass);

    }
}
