using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using HPPay.DataModel;
using HPPay.DataModel.LoyaltyRedemption;

namespace HPPay.DataRepository.LoyaltyRedemption
{
    public interface ILoyaltyRedemptionRepository
    {
        public Task<IEnumerable<GetLoyaltyRedemptionModelOutput>> GetLoyaltyRedemption([FromBody] GetLoyaltyRedemptionModelInput ObjClass);
        public Task<IEnumerable<GetUpdateLoyaltyRedemptionModelOutput>> GetUpdateLoyaltyRedemption([FromBody] GetUpdateLoyaltyRedemptionModelInput ObjClass);
        public  Task<IEnumerable<InsertLoyaltyRedemptionModelOutput>> InsertLoyaltyRedemption([FromBody] InsertLoyaltyRedemptionModelInput ObjClass);
        public  Task<IEnumerable<GetTransactionSourceIDModelOutput>> GetTransactionSourceID([FromBody] GetTransactionSourceIDModelInput ObjClass);
        public  Task<IEnumerable<GetAuthorizationLevelIDModelOutput>> GetAuthorizationLevelID([FromBody] GetAuthorizationLevelIDModelInput ObjClass);
        public  Task<IEnumerable<GetRedemptionRequestRuleModelOutput>> GetRedemptionRequestRule([FromBody] GetRedemptionRequestRuleModelInput ObjClass);
        public  Task<IEnumerable<InsertRedemptionRequestRuleModelOutput>> InsertRedemptionRequestRule([FromBody] InsertRedemptionRequestRuleModelInput ObjClass);
        public  Task<IEnumerable<UpdateRedemptionRequestRuleModelOutput>> UpdateRedemptionRequestRule([FromBody] UpdateRedemptionRequestRuleModelInput ObjClass);
        public  Task<IEnumerable<DeleteRedemptionRequestRuleModelOutput>> DeleteRedemptionRequestRule([FromBody] DeleteRedemptionRequestRuleModelInput ObjClass);

        public Task<IEnumerable<ApprovalAuthorizeFuelLoyaltyRedemptionModelOutput>> ApprovalAuthorizeFuelLoyaltyRedemption([FromBody] ApprovalAuthorizeFuelLoyaltyRedemptionModelInput ObjClass);
        public Task<IEnumerable<GetAuthorizeFuelLoyaltyRedemptionDetailModelOutput>> GetAuthorizeFuelLoyaltyRedemptionDetail([FromBody] GetAuthorizeFuelLoyaltyRedemptionDetailModelInput ObjClass);

        public Task<IEnumerable<FuelLoyaltyRedemptionAuthorizeModelOutput>> FuelLoyaltyRedemptionAuthorize([FromBody] FuelLoyaltyRedemptionAuthorizeModelInput ObjClass);

        public Task<IEnumerable<GetApprovedFuelLoyaltyRedemptionDetailModelOutput>> GetApproveFuelLoyaltyRedemptionDetail([FromBody] GetApprovedFuelLoyaltyRedemptionDetailModelnput ObjClass);




    }
}
