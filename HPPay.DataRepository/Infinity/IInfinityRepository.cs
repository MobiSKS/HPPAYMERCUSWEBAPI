using HPPay.DataModel.Infinity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HPPay.DataRepository.Infinity
{
    public interface IInfinityRepository
    {
        public Task<IEnumerable<InfinityRechargeValidationOutput>> InfinityRechargeDetailValidation([FromForm] InfinityRechargeValidationInput ObjClass);

        public Task<IEnumerable<InfinityRechargeDataInsertOutput>> InsertInfinityRechargeDetails([FromForm] InfinityRechargeDataInsertInput ObjClass);

        public Task<IEnumerable<InfinityRechargeApprovalPendingOutput>> InfinityRechargeDetailsPendingForApproval([FromForm] InfinityRechargeApprovalPendingInput ObjClass);

        public Task<IEnumerable<InfinityRechargeApprovalOutput>> InfinityRechargeDetailsApproval([FromBody] InfinityRechargeApprovalInput ObjClass);

        public Task<IEnumerable<InfinityRechargeRejectionOutput>> InfinityRechargeDetailsRejection([FromBody] InfinityRechargeRejectionInput ObjClass);

        public Task<IEnumerable<ViewInfinityRequestOutput>> ViewInfinityRequest([FromForm] ViewInfinityRequestInput ObjClass);
        
    }
}
