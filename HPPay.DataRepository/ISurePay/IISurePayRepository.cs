using HPPay.DataModel.ISurePay;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HPPay.DataRepository.ISurePay
{
    public interface IISurePayRepository
    {
        public Task<IEnumerable<ISuarePayValidationOutput>> ISUrePayRechargeDetailValidation([FromForm] ISuarePayValidationInput ObjClass);

        public Task<IEnumerable<ISuarePayRequestOutput>> ISUrePayRechargeDataInsert([FromForm] ISuarePayRequestInput ObjClass);

        public Task<IEnumerable<ISurePayPendingApprovalSearchOutput>> ISurePayRechargePendingForApprovalSearch([FromForm] ISurePayPendingApprovalSearchInput ObjClass);

        public Task<IEnumerable<ISurePayRechargeApprovalOutput>> ISurePayRechargeRequestApproval([FromBody] ISurePayRechargeApprovalInput ObjClass);

        public Task<IEnumerable<ISurePayRechargeRejectionOutput>> ISurePayRechargeDetailsRejection([FromBody] ISurePayRechargeRejectionInput ObjClass);

        public Task<IEnumerable<ISurePayRechargeReversalSearchOutput>> ISurePayRechargeReversalSearch([FromForm] ISurePayRechargeReversalSearchInput ObjClass);

        public Task<IEnumerable<ISurePayRechargeReversalRequestOutput>> ISurePayRechargeReversalRequest([FromBody] ISurePayRechargeReversalRequestInput ObjClass);

        public Task<IEnumerable<ISurePayReversalPendingApprovalSearchOutput>> ISurePayReversalPendingApprovalSearch([FromForm] ISurePayReversalPendingApprovalSearchInput ObjClass);

        public Task<IEnumerable<ISurePayRechargeReversalApprovalOutput>> ISurePayRechargeReversalApproval([FromBody] ISurePayRechargeReversalApprovalInput ObjClass);

        public Task<IEnumerable<ISurePayReversalRejectionOutput>> ISurePayReversalRejection([FromBody] ISurePayReversalRejectionInput ObjClass);

        public Task<IEnumerable<ISurePayViewRequestOutput>> ViewISurePayRequest([FromForm] ISurePayViewRequestInput ObjClass);
    }
}
