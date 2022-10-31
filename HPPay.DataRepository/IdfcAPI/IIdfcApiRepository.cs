using HPPay.DataModel.IdfcAPI;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HPPay.DataRepository.IdfcAPI
{
    public  interface IIdfcApiRepository
    {
        public Task<IEnumerable<UpdateCCMSBAlanceForIdfcCustomer>> UpdateCCMSBAlanceForIdfcCustomer([FromBody] FastagConfirmOtpReQuest ObjClass,string NetAmount,string DiscountAmount);
        public Task<IEnumerable<UpdateCCMSBAlanceForIdfcCustomer>> RefundCCMSBAlanceForIdfcCustomer([FromBody] FastagRefundPaymentReQuest ObjClass);
        public Task<IEnumerable<IdfcApiRequestResponseOutput>> InsertIdfcApiRequestResponse([FromBody] IdfcApiRequestResponseInput ObjClass);
        public void InsertIdfcApiRequestResponseDetail([FromBody] IdfcApiRequestResponseDetailInput ObjClass);

        public Task<IEnumerable<InsertFastagIdfcApiRequestOutput>> InsertIdfcFastagApiRequest( InsertFastagIdfcApiRequestInput ObjClass);
        public void UpdateIdfcFastagApiRequest( UpdateFastagIdfcApiRequestInput ObjClass);
        public Task<IEnumerable<IdfcCheckFastagInvoiceIdBatchIdExistOutput>> CheckFastagInvoiceIdBatchIdExist(IdfcCheckFastagInvoiceIdBatchIdExistInput obj);

        public Task<IEnumerable<CustomerInsertFastTagModelOutput>> InsertCustomerFastTag([FromBody] CustomerInsertFastTagModelInput ObjClass);

        public Task<IEnumerable<FastTagCustomerKYCModelOutput>> UploadCustomerKYCFastTag([FromForm] FastTagCustomerKYCModelInput ObjClass);

        public Task<IEnumerable<GetBankCreditLimitModelOutput>> GetBankCreditLimit([FromBody] GetBankCreditLimitModelInput ObjClass);

        public Task<IEnumerable<BankCreditLimitRequestModelOutput>> BankCreditLimitRequest([FromBody] BankCreditLimitRequestModelInput ObjClass);
        public Task<IEnumerable<GetBankCreditLimitStatusDetailsModelOutput>> GetBankCreditLimitStatusDetail([FromBody] GetBankCreditLimitStatusDetailsModelInput ObjClass);

        public Task<IEnumerable<GetFastagCreditLimitApprovalModelOutput>> GetFastagCreditLimitApproval([FromBody] GetFastagCreditLimitApprovalModelInput ObjClass);

        public Task<IEnumerable<GetBankEnrollmentStatusDetailModelOutput>> GetBankEnrollmentStatusDetail([FromBody] GetBankEnrollmentStatusDetailModelInput ObjClass);

        public Task<IEnumerable<UpdateFastagCreditLimitApprovalModelOutput>> UpdateFastagCreditLimitApproval([FromBody] UpdateFastagCreditLimitApprovalModelInput ObjClass);

        public Task<IEnumerable<GetFastagBankApprovalDetailModelOutput>> GetFastagBankApprovalDetail([FromBody] GetFastagBankApprovalDetailModelInput ObjClass);


        public Task<IEnumerable<UpdateFastagBankApprovalModelOutput>> UpdateFastagBankApproval([FromBody] UpdateFastagBankApprovalModelInput ObjClass);

        public Task<IEnumerable<GetStatementofAccountModelOutput>> GetStatementofAccount([FromBody] GetStatementofAccountModelInput ObjClass);

        public Task<GetUnverfiedCustomerDetailbyFormNumberModelOutput> GetUnverfiedCustomerDetailbyFormNumber([FromBody] GetUnverfiedCustomerDetailbyFormNumberModelInput ObjClass);

        public Task<IEnumerable<FastagCustomerUpdateModelOutput>> UpdateCustomer([FromBody] FastagCustomerUpdateModelInput ObjClass);





    }
}
