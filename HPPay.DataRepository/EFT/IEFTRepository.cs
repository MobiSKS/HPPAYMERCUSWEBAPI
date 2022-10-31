using HPPay.DataModel.EFT;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HPPay.DataRepository.EFT
{

    public interface IEFTRepository
    {
        public Task<IEnumerable<EFTRechargeFileNameOutput>> EFTRechargeFileName([FromBody] EFTRechargeFileNameInput ObjClass);

        public Task<IEnumerable<EFTRechargeDataOutput>> InsertEFTRechargeDetails([FromForm] EFTRechargeDataInsert ObjClass);

        public Task<EFTRechargeDataValidationDetails> EFTRechargeDetailValidation([FromForm] EFTRechargeDataValidation ObjClass);

        public Task<IEnumerable<EFTRechargePendingForApprovalOutput>> EFTRechargeDetailsPendingForApproval([FromBody] EFTRechargePendingForApprovalInput ObjClass);

        public Task<IEnumerable<EFTRechargeApprovalOutput>> EFTRechargeDetailsApproval([FromBody] EFTRechargeApprovalInput ObjClass);

        public Task<IEnumerable<EFTRechargeRejectionOutput>> EFTRechargeDetailsRejection([FromBody] EFTRechargeRejectionInput ObjClass);

        public Task<IEnumerable<EFTRechargeReversalSearchOutput>> EFTRechargeReversalSearch([FromBody] EFTRechargeReversalSearchInput ObjClass);

        public Task<IEnumerable<EFTRechargeReversalRequestOutput>> EFTRechargeReversalRequest([FromForm] EFTRechargeReversalRequestInput ObjClass);

        public Task<IEnumerable<EFTRechargeReversalPendingForApprovalOutput>> EFTRechargeReversalPendingForApproval([FromForm] EFTRechargeReversalPendingForApprovalInput ObjClass);

        public Task<IEnumerable<EFTRechargeReversalApprovalOutput>> EFTRechargeReversalApproval([FromBody] EFTRechargeReversalApprovalInput ObjClass);

        public Task<IEnumerable<EFTReversalRejectionOutput>> EFTReversalRejection([FromBody] EFTReversalRejectionInput ObjClass);

        public Task<IEnumerable<ViewEFTRequestOutput>> ViewEFTRequest([FromForm] ViewEFTRequestInput ObjClass);

        public Task<IEnumerable<ViewEFTReverseDetailOutput>> ViewEFTReverseDetail([FromBody] ViewEFTReverseDetailInput ObjClass);
    }
}
