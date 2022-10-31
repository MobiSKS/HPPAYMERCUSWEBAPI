using HPPay.DataModel.COMCO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HPPay.DataRepository.COMCO
{
    public interface ICOMCORepository
    {
        public Task<GetCOMCOMapCustomerDetailsModelOutput> GetCOMCOMapCustomerDetails([FromBody] GetCOMCOMapCustomerDetailsModelInput ObjClass);
        public Task<IEnumerable<UpdateCOMCOMapCustomerModelOutput>> UpdateCOMCOMapCustomer([FromBody] UpdateCOMCOMapCustomerModelInput ObjClass);
        public Task<GetCOMCOViewMappedCustomerModelOutput> GetCOMCOViewMappedCustomer([FromBody] GetCOMCOViewMappedCustomerModelInput ObjClass);

        public Task<IEnumerable<GetCOMCOLimitSetModeModelOutput>> GetCOMCOLimitSetMode([FromBody] GetCOMCOLimitSetModeModelInput ObjClass);

        public Task<IEnumerable<GetCOMCOLimitSetInvoiceIntervalModelOutput>> GetCOMCOLimitSetInvoiceInterval([FromBody] GetCOMCOLimitSetInvoiceIntervalModelInput ObjClass);

        public Task<IEnumerable<COMCOLimitSetRequestModelOutput>> COMCOLimitSetRequest([FromBody] COMCOLimitSetRequestModelInput ObjClass);

        public Task<IEnumerable<GetCOMCOLimitSetRequestDetailsModelOutput>> GetCOMCOLimitSetRequestDetails([FromBody] GetCOMCOLimitSetRequestDetailsModelInput ObjClass);
        public Task<IEnumerable<GetApprovalCreditLimitDetailsModelOutput>> GetApprovalCreditLimitDetails([FromBody] GetApprovalCreditLimitDetailsModelInput ObjClass);

        public Task<IEnumerable<GetRMRechargeModeModelOutput>> GetRMRechargeMode([FromBody] GetRMRechargeModeModelInput ObjClass);

        public Task<IEnumerable<UpdateApproveRejectCreditLimitModelOutput>> UpdateApproveRejectCreditLimit([FromBody] UpdateApproveRejectCreditLimitModelInput ObjClass);

        public Task<IEnumerable<ViewCreditLimitModelOutput>> ViewCreditLimit([FromBody] ViewCreditLimitModelInput ObjClass);

        public  Task<IEnumerable<CustomerCreditandCautionLimitHistoryModelOutput>> CustomerCreditandCautionLimitHistory([FromBody] CustomerCreditandCautionLimitHistoryModelInput ObjClass);


        public Task<IEnumerable<COMCOCreditAccountSummaryModelOutput>> COMCOCreditAccountSummary([FromBody] COMCOCreditAccountSummaryModelInput ObjClass);


        public Task<IEnumerable<COMCOCreditCustomerAccountSummaryModelOutput>> COMCOCreditCustomerAccountSummary([FromBody] COMCOCreditCustomerAccountSummaryModelInput ObjClass);

        public Task<COMCOCreditCustomerAccountDetailsModelOutput> COMCOCreditCustomerAccountDetails([FromBody] COMCOCreditCustomerAccountDetailsModelInput ObjClass);

        public Task<IEnumerable<ResetCreditandCautionLimitRequestModelOutput>> ResetCreditandCautionLimitRequest([FromForm] ResetCreditandCautionLimitRequestModelInput ObjClass);
        public Task<IEnumerable<GetPrematureClosureDetailOutput>> GetPrematureClosureDetail([FromBody] GetPrematureClosureDetailInput ObjClass);

        public Task<IEnumerable<GetCreditCustomerCreditRechargeClubbingCategoryModelOutput>> GetCreditCustomerCreditRechargeClubbingCategory([FromBody] GetCreditCustomerCreditRechargeClubbingCategoryModelInput ObjClass);

        public Task<IEnumerable<GetCreditCustomerCreditRechargePaymentModeModelOutput>> GetCreditCustomerCreditRechargePaymentMode([FromBody] GetCreditCustomerCreditRechargePaymentModeModelInput ObjClass);

        public Task<IEnumerable<GetCreditCustomerCreditRechargeDetailsModelOutput>> GetCreditCustomerCreditRechargeDetails([FromBody] GetCreditCustomerCreditRechargeDetailsModelInput ObjClass);
        public Task<IEnumerable<CreditCustomerCreditRechargeModelOutput>> CreditCustomerCreditRecharge([FromBody] CreditCustomerCreditRechargeModelInput ObjClass);
        public Task<ViewCustomerCreditRechargeModelOutput> ViewCustomerCreditRecharge([FromBody] ViewCustomerCreditRechargeModelInput ObjClass);
        public Task<IEnumerable<GetResetCreditandCautionLimitDetailOutput>> GetResetCreditandCautionLimitDetail([FromBody] GetResetCreditandCautionLimitDetailInput ObjClass);

        public Task<IEnumerable<COMCOManagerCreditOperationRoleRequestModelOutput>> COMCOManagerCreditOperationRoleRequest([FromBody] COMCOManagerCreditOperationRoleRequestModelInput ObjClass);

        public Task<IEnumerable<GetCOMCOManagerCreditOperationRoleRequestDetailsModelOutput>> GetCOMCOManagerCreditOperationRoleRequestDetails([FromBody] GetCOMCOManagerCreditOperationRoleRequestDetailsModelInput ObjClass);
        public Task<IEnumerable<ApproveRejectCOMCOManagerCreditOperationRoleRequestModelOutput>> ApproveRejectCOMCOManagerCreditOperationRoleRequest([FromBody] ApproveRejectCOMCOManagerCreditOperationRoleRequestModelInput ObjClass);


        public Task<IEnumerable<ViewDownloadCOMCOCustomerDetailsModelOutput>> ViewDownloadCOMCOCustomerDetails([FromBody] ViewDownloadCOMCOCustomerDetailsModelInput ObjClass);

        public Task<IEnumerable<UpdateCautionLimitModelOutput>> UpdateCautionLimit([FromBody] UpdateCautionLimitModelInput ObjClass);
        public Task<IEnumerable<PrematureClosureRequestModelOutput>> PrematureClosureRequest([FromBody] PrematureClosureRequestModelInput ObjClass);
        public Task<IEnumerable<GetViewMappedCustomerModelOutput>> GetViewMappedCustomer([FromBody] GetViewMappedCustomerModelInput ObjClass);
        public Task<IEnumerable<ViewSetLimitCustomersModelOutput>> ViewSetLimitCustomers([FromBody] ViewSetLimitCustomersModelInput ObjClass);
        public Task<IEnumerable<GetCreditCustomersWebReportModelOutput>> GetCreditCustomersWebReport([FromBody] GetCreditCustomersWebReportModelInput ObjClass);
        public Task<IEnumerable<GetCOMCOCustomerCardNoVehicleDetailsModelOutput>> GetCOMCOCustomerCardNoVehicleDetails([FromBody] GetCOMCOCustomerCardNoVehicleDetailsModelInput ObjClass);
        public Task<ViewCOMCOCustomerStatementModelOutput> ViewCOMCOCustomerStatement([FromBody] ViewCOMCOCustomerStatementModelInput ObjClass);
        public Task<IEnumerable<GetAuthorizeCOMCOCreditOperationRoleRequestsDetailsModelOutput>> GetAuthorizeCOMCOCreditOperationRoleRequestsDetails([FromBody] GetAuthorizeCOMCOCreditOperationRoleRequestsDetailsModelInput ObjClass);

        public Task<IEnumerable<AuthorizeCOMCOCreditOperationRoleRequestsModelOutput>> AuthorizeCOMCOCreditOperationRoleRequests([FromBody] AuthorizeCOMCOCreditOperationRoleRequestsModelInput ObjClass);
        public Task<IEnumerable<GetCOMCOMerchantDetailsModelOutput>> GetCOMCOMerchantDetails([FromBody] GetCOMCOMerchantDetailsModelInput ObjClass);
        public Task<IEnumerable<GetCOMCOMerchantShiftMasterModelOutput>> GetCOMCOMerchantShiftMaster([FromBody] GetCOMCOMerchantShiftMasterModelInput ObjClass);
        public Task<IEnumerable<InsertCOMCOMerchantShiftMasterModelOutput>> InsertCOMCOMerchantShiftMaster([FromBody] InsertCOMCOMerchantShiftMasterModelInput ObjClass);


    }
}