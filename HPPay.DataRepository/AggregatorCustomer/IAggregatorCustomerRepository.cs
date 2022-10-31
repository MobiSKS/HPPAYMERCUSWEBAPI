using HPPay.DataModel.AggregatorCustomer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataRepository.AggregatorCustomer
{
    public interface IAggregatorCustomerRepository
    {
        public Task<IEnumerable<AggregatorCustomerInsertModelOutput>> InsertAggregatorCustomer([FromBody] AggregatorCustomerInsertModelInput ObjClass);

        public Task<IEnumerable<AggregatorNormalFleetCustomerModelOutput>> InsertAggregatorNormalFleetCustomer([FromBody] AggregatorNormalFleetCustomerModelInput ObjClass);

        public Task<IEnumerable<AggregatorCustomerUpdateModelOutput>> UpdateAggregatorCustomer([FromBody] AggregatorCustomerUpdateModelInput ObjClass);

        public Task<IEnumerable<GetAggregatorCustomerModelOutput>> GetAggregatorCustomer([FromBody] GetAggregatorCustomerModelInput ObjClass);

        public Task<IEnumerable<AggregatorNormalFleetCustomerUpdateModelOutput>> UpdateAggregatorNormalFleetCustomer([FromBody] AggregatorNormalFleetCustomerUpdateModelInput ObjClass);

        public Task<IEnumerable<AggregatorCustomerKYCModelOutput>> UploadAggregatorCustomerKYC([FromBody] AggregatorCustomerKYCModelInput ObjClass);

        public Task<IEnumerable<AggregatorNormalFleetCustomerKYCModelOutput>> UploadAggregatorNormalFleetCustomerKYC([FromBody] AggregatorNormalFleetCustomerKYCModelInput ObjClass);

        //public Task<IEnumerable<AggregatorNormalFleetCustomerRCCopyModelOutput>> UploadAggregatorNormalFleetCustomerRCCopy([FromBody] AggregatorNormalFleetCustomerRCCopyModelInput ObjClass);


        public Task<IEnumerable<AggregatorCustomerApprovalModelOutput>> ApproveRejectAggregatorCustomer([FromBody] AggregatorCustomerApprovalModelInput ObjClass);

        public Task<IEnumerable<AggregatorCustomerFeewaiverApprovalModelOutput>> ApproveRejectAggregatorFeewaiver([FromBody] AggregatorCustomerFeewaiverApprovalModelInput ObjClass);

        public Task<GetApproveAggregatorFeeWaiverDetailModelOutput> GetApproveAggregatorFeeWaiverDetail([FromBody] GetApproveAggregatorFeeWaiverDetailModelInput ObjClass);

        public Task<IEnumerable<AggregatorCustomerGetCustomerReferenceNoModelOutput>> GetAggregatorNameandFormNumberbyReferenceNo([FromBody] AggregatorCustomerGetCustomerReferenceNoModelInput ObjClass);

        public Task<IEnumerable<AggregatorNormalFleetCustomerGetCustomerReferenceNoModelOutput>> GetAggregatorNormalFleetCustomerNameandFormNumberbyReferenceNo([FromBody] AggregatorNormalFleetCustomerGetCustomerReferenceNoModelInput ObjClass);

        public Task<IEnumerable<AggregatorNormalFleetCustomerGetCustomerReferenceNoforCustomerModelOutput>> GetAggregatorNormalFleetCustomerNameandFormNumberbyReferenceNoforCustomer([FromBody] AggregatorNormalFleetCustomerGetCustomerReferenceNoforCustomerModelInput ObjClass);

        public Task<IEnumerable<AggregatorCustomerGetCustomerReferenceNoModelOutput>> GetAggregatorNameandFormNumberbyReferenceNoforAddCard([FromBody] AggregatorCustomerGetCustomerReferenceNoModelInput ObjClass);

        public Task<IEnumerable<GetAggregatorNormalFleetNamebyReferenceNoModelOutput>> GetAggregatorNormalFleetNamebyReferenceNo([FromBody] GetAggregatorNormalFleetNamebyReferenceNoModelInput ObjClass);

        public Task<AggregatorCustomerDetailsModelOutput> GetAggregatorCustomerDetails([FromBody] AggregatorCustomerDetailsModelInput ObjClass);

        public Task<AggregatorCustomerDetailsModelOutput> GetAggregatorCustomerByCustomerId([FromBody] AggregatorCustomerGetByCustomerIdModelInput ObjClass);

        public Task<AggregatorCustomerDetailsModelOutput> GetRawAggregatorCustomerDetails([FromBody] AggregatorCustomerDetailsModelInput ObjClass);

        public Task<IEnumerable<BindPendingAggregatorCustomerModelOutput>> BindPendingAggregatorCustomer([FromBody] BindPendingAggregatorCustomerModelInput ObjClass);

        public Task<IEnumerable<BindPendingAggregatorCustomerModelOutput>> BindUnverfiedAggregatorCustomer([FromBody] BindPendingAggregatorCustomerModelInput ObjClass);

        public Task<AggregatorCustomerDetailsModelOutput> GetUnverfiedAggregatorCustomerDetailbyFormNumber([FromBody] AggregatorCustomerDetailsbyFormNumberModelInput ObjClass);

        public Task<AggregatorNormalFleetCustomerDetailsModelOutput> GetUnverfiedAggregatorNormalFleetCustomerDetailbyFormNumber([FromBody] AggregatorNormalFleetCustomerDetailsbyFormNumberModelInput ObjClass);

        public Task<IEnumerable<AggregatorCustomerGetCustomerNameModelOutput>> GetAggregatorCustomerNameByCustomerId([FromBody] AggregatorCustomerGetByCustomerIdModelInput ObjClass);

        public Task<IEnumerable<AggregatorCustomerGetCustomerDetailsForSearchModelOutput>> GetAggregatorCustomerDetailsForSearch([FromBody] AggregatorCustomerGetByCustomerIdModelInput ObjClass);

        public Task<SearchAggregatorCustomerandCardFormModelOutput> SearchAggregatorCustomerandCardForm([FromBody] SearchAggregatorCustomerandCardFormModelInput ObjClass);

        public Task<IEnumerable<GetAggregatorNameandFormNumberbyCustomerIdModelOutput>> GetAggregatorNameandFormNumberbyCustomerId([FromBody] GetAggregatorNameandFormNumberbyCustomerIdModelInput ObjClass);

        public Task<IEnumerable<AggregatorCustomerAddOnUserModelOutput>> AggregatorCustomerAddOnUser([FromBody] AggregatorCustomerAddOnUserModelInput ObjClass);

        public Task<IEnumerable<AggregatorNormalFleetCustomerAddCardModelOutput>> AggregatorNormalFleetCustomerAddCard([FromForm] AggregatorNormalFleetCustomerAddCardModelInput ObjClass);

        public Task<IEnumerable<GetAggregatorNormalFleetCustomerStatusModelOutput>> GetAggregatorNormalFleetCustomerStatus([FromBody] GetAggregatorNormalFleetCustomerStatusModelInput ObjClass);

        public Task<IEnumerable<GetAggregatorNormalFleetCustomerStatusModelOutput>> GetAggregatorNormalFleetCustomerStatusApprove([FromBody] GetAggregatorNormalFleetCustomerStatusModelInput ObjClass);

        public Task<IEnumerable<GetAggregatorNormalFleetCustomerModelOutput>> GetAggregatorNormalFleetCustomer([FromBody] GetAggregatorNormalFleetCustomerModelInput ObjClass);

        public Task<IEnumerable<VerifyRejectAggregatorNormalFleetCustomerModelOutput>> VerifyRejectAggregatorNormalFleetCustomer([FromBody] VerifyRejectAggregatorNormalFleetCustomerModelInput ObjClass);

        public Task<IEnumerable<VerifyRejectAggregatorNormalFleetCustomerCardModelOutput>> VerifyRejectAggregatorNormalFleetCustomerCard([FromBody] VerifyRejectAggregatorNormalFleetCustomerCardModelInput ObjClass);

        public Task<IEnumerable<ApproveRejectAggregatorNormalFleetCustomerModelOutput>> ApproveRejectAggregatorNormalFleetCustomer([FromBody] ApproveRejectAggregatorNormalFleetCustomerModelInput ObjClass);

        public Task<IEnumerable<ApproveRejectAggregatorNormalFleetCustomerCardModelOutput>> ApproveRejectAggregatorNormalFleetCustomerCard([FromBody] ApproveRejectAggregatorNormalFleetCustomerCardModelInput ObjClass);

        public Task<IEnumerable<GetAggregatorFleetCustomerNameByCustomerIdModelOutput>> GetAggregatorFleetCustomerNameByCustomerId([FromBody] GetAggregatorFleetCustomerNameByCustomerIdModelInput ObjClass);

        public Task<IEnumerable<AggregatorNormalFleetCustomerAddOnCardModelOutput>> AggregatorNormalFleetCustomerAddOnCard([FromForm] AggregatorNormalFleetCustomerAddOnCardModelInput ObjClass);

        public Task<IEnumerable<GetAggregatorNormalFleetCustomerDownloadKycModelOutput>> GetAggregatorNormalFleetCustomerDownloadKyc([FromBody] GetAggregatorNormalFleetCustomerDownloadKycModelInput ObjClass);

        public Task<IEnumerable<GetAggregatorNormalFleetCustomerVerifyCardModelOutput>> GetAggregatorNormalFleetCustomerVerifyCard([FromBody] GetAggregatorNormalFleetCustomerVerifyCardModelInput ObjClass);

        public Task<IEnumerable<GetAggregatorNormalFleetCustomerApproveCardModelOutput>> GetAggregatorNormalFleetCustomerApproveCard([FromBody] GetAggregatorNormalFleetCustomerApproveCardModelInput ObjClass);
        public Task<IEnumerable<GetAggregatorStatusModelOutput>> GetAggregatorStatusList([FromBody] GetAggregatorStatusModelInput ObjClass);
        public Task<IEnumerable<GetAggregatorCustomerForZOHOApprovalModelOutput>> GetAggregatorCustomerForZOHOApproval([FromBody] GetAggregatorCustomerForZOHOApprovalModelInput ObjClass);
        public Task<IEnumerable<GetAggregateUserDetailForApprovalModelOutput>> GetAggregateUserDetailForApproval([FromBody] GetAggregateUserDetailForApprovalModelInput ObjClass);
        public Task<IEnumerable<ApproveRejectAggregateUserApprovalModelOutput>> ApproveRejectAggregateUserApproval([FromBody] ApproveRejectAggregateUserApprovalModelInput ObjClass);
    }
}
