using HPPay.DataModel.Customer;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPPay.DataModel.IVR;

namespace HPPay.DataRepository.IVR
{
    public interface IIVRCustomerRepository
    {
        public Task<IEnumerable<ValidateCustomerControlCardOutput>> ValidateCustomerControlCard([FromBody] ValidateCustomerConrolCardInput ObjClass);

        public Task<IEnumerable<ValidateCustomerMobileOutput>> ValidateCustomerMobile([FromBody] ValidateCustomerMobileInput ObjClass);

        public Task<IEnumerable<ValidateCustomerMobileOutput>> GenerateIVROTP([FromBody] ValidateCustomerMobileInput ObjClass);

        public Task<IEnumerable<ValidateCustomerMobileOutput>> ValidateIVROTP([FromBody] ValidateCustomerMobileInput ObjClass);
        
        public Task<IEnumerable<CustomerCCMSBalanceInquiryOutput>> CustomerCCMSBalanceInquiry([FromBody] CustomerCCMSBalanceInquiryInput ObjClass);

        public Task<IEnumerable<CustomerResetPasswordOutput>> CustomerResetPassword([FromBody] CustomerResetPasswordInput ObjClass);

        public Task<IEnumerable<CustomerBlockUnblockCardOutput>> CustomerBlockUnblockCard([FromBody] CustomerBlockUnblockCardInput ObjClass);

        
        public Task<IEnumerable<CustomerResetCardPinOutput>> CustomerResetCardPin([FromBody] CustomerResetCardPinInput ObjClass);

        public Task<IEnumerable<CustomerResetControlCardPinOutput>> CustomerResetControlCardPin([FromBody] CustomerResetControlCardPinInput ObjClass);

        public Task<IEnumerable<CustomerLoyaltyRedemptionOutput>> CustomerLoyaltyRedemption([FromBody] CustomerloyaltyRedemptionInput ObjClass);

        public Task<IEnumerable<CustomerStarRewardsOutput>> CustomerStarRewards([FromBody] CustomerStarRewardsInput ObjClass);

        public Task<IEnumerable<CustomerGenerateStatementOutput>> CustomerGenerateStatement([FromBody] CustomerGenerateStatementInput ObjClass);
        
        public Task<IEnumerable<ValidateCustomerControlCardOutput>> InsertUpdateIVRSecurityToken(string Token);
    }
}
