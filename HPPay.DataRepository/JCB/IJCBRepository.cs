using HPPay.DataModel.JCB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.JCB
{
    public interface IJCBRepository
    {
        public Task<IEnumerable<JCBDealerEnrollmentModelOutput>> InsertJCBDealerEnrollment([FromBody] JCBDealerEnrollmentModelInput ObjClass);
        public Task<IEnumerable<UpdateJCBDealerEnrollmentModelOutput>> UpdateJCBDealerEnrollment([FromBody] UpdateJCBDealerEnrollmentModelInput ObjClass);
        public Task<IEnumerable<GetJCBDealerNameModelOutput>> GetJCBDealerDetail([FromBody] GetJCBDealerNameModelInput ObjClass);
        public Task<IEnumerable<GetJCBOfficerTypeModelOutput>> GetJCBOfficerType([FromBody] GetJCBOfficerTypeModelInput ObjClass);
        public Task<IEnumerable<InsertJCBCustomerModelOutput>> InsertJCBCustomer([FromBody] InsertJCBCustomerModelInput ObjClass);

        public Task<IEnumerable<CheckJCBDealerCodeModelOutput>> CheckJCBDealerCode([FromBody] CheckJCBDealerCodeModelInput ObjClass);
        public Task<IEnumerable<InsertDealerWiseJCBOTCCardRequestModelOutput>> InsertDealerWiseJCBOTCCardRequest([FromBody] InsertDealerWiseJCBOTCCardRequestModelInput ObjClass);
        public Task<IEnumerable<GetAvailityJCBOTCCardModelOutput>> GetAvailityJCBOTCCard([FromBody] GetAvailityJCBOTCCardModelInput ObjClass);
        public Task<IEnumerable<ViewJCBDealerOTCCardStatusModelOutput>> ViewJCBDealerOTCCardStatus([FromBody] ViewJCBDealerOTCCardStatusModelInput ObjClass);
        public Task<ViewJCBDealerOTCCardDetailModelOutput> ViewJCBDealerOTCCardDetail([FromBody] ViewJCBDealerOTCCardDetailModelInput ObjClass);
        public Task<GetJCBAddonOTCCardMappingCustomerDetailsModelOutput> GetJCBAddonOTCCardMappingCustomerDetails([FromBody] GetJCBAddonOTCCardMappingCustomerDetailsModelInput ObjClass);
        public Task<IEnumerable<GetJCBSalesExeEmpIdAddOnOTCCardMappingModelOutput>> GetJCBSalesExeEmpIdAddOnOTCCardMapping([FromBody] GetJCBSalesExeEmpIdAddOnOTCCardMappingModelInput ObjClass);
        public Task<IEnumerable<JCBAddOnOTCCardModelOutput>> JCBAddOnOTCCard([FromBody] JCBAddOnOTCCardModelInput ObjClass);
        public Task<IEnumerable<JCBCustomerDetailUpdateModelOutput>> RequestUpdateJCBCustomer([FromBody] JCBCustomerDetailUpdateModelInput ObjClass);
        public Task<IEnumerable<ApprovalJCBCustomerUpdateRequestModelOutput>> ApprovalJCBCustomerUpdateRequest([FromBody] ApprovalJCBCustomerUpdateRequestModelInput ObjClass);
        public Task<IEnumerable<ManageJCBSearchCardsModelOutput>> SearchManageCard([FromBody] ManageJCBSearchCardsModelInput ObjClass);
        public Task<JCBCustomerDetailsModelOutput> GetJCBCustomerDetails([FromBody] JCBCustomerDetailsModelInput ObjClass);
        public Task<GetJCBCardLimtModelOutput> GetJCBCardLimitFeatures([FromBody] GetJCBCardLimtModelInput ObjClass);
        public Task<IEnumerable<GetJCBCustomerBalanceInfoModelOutput>> GetCustomerBalanceInfo([FromBody] GetJCBCustomerBalanceInfoModelInput ObjClass);
        public Task<GetJCBTransactionsSummaryModelOutput> GetJCBTransactionsSummary([FromBody] GetJCBTransactionsSummaryModelInput ObjClass);
        public Task<IEnumerable<JCBGetMobileandFastagNoModelOutput>> GetJCBMobileandFastagNo([FromBody] JCBGetMobileandFastagNoModelInput ObjClass);
        public Task<IEnumerable<JCBUpdateMobileandFastagNoModelOutput>> JCBUpdateMobileandFastagNo([FromBody] JCBUpdateMobileandFastagNoModelInput ObjClass);

        public Task<IEnumerable<GetJCBAdvancedSearchModelOutput>> GetJCBAdvancedSearch([FromBody] GetJCBAdvancedSearchModelInput ObjClass);
        public Task<IEnumerable<GetJCBCommunicationEmailResetPasswordModelOutput>> GetJCBCommunicationEmailResetPassword(GetJCBCommunicationEmailResetPasswordModelInput objClass);
        public Task<IEnumerable<UpdateJCBCommunicationEmailResetPasswordModelOutput>> UpdateJCBCommunicationEmailResetPassword(UpdateJCBCommunicationEmailResetPasswordModelInput objClass);

        public Task<IEnumerable<UpdateJCBHotlistReactivateModelOutput>> UpdateJCBHotlistReactivate(UpdateJCBHotlistReactivateModelInput ObjClass);
        public Task<IEnumerable<GetJCBHotlistReactiveStatusModelOutput>> GetJCBVHotListReactiveStatus([FromBody] GetJCBHotlistReactiveStatusModelInput ObjClass);
        public Task<IEnumerable<GetJCBBalanceOTCCardModelOutput>> GetJCBBalanceOTCCard([FromBody] GetJCBBalanceOTCCardModelInput ObjClass);
        public Task<IEnumerable<UpdateJCBDealerCommunicationEmailResetPasswordModelOutput>> UpdateJCBDealerCommunicationEmailResetPassword(UpdateJCBDealerCommunicationEmailResetPasswordModelInput objClass);
        public Task<IEnumerable<GetJCBDispatchDetailModelOutput>> GetJCBDispatchDetail([FromBody] GetJCBDispatchDetailModelInput ObjClass);

        public Task<IEnumerable<EnableDisableJCBDealerModelOutput>> EnableDisableJCBDealer([FromBody] EnableDisableJCBDealerModelInput ObjClass);
        public Task<IEnumerable<UpdateJCBCustomerDetailModelOutput>> UpdateJCBCustomer([FromBody] UpdateJCBCustomerDetailModelInput ObjClass);

        public Task<GetJCBCustomerApplicationFormNameOnCardModelOutput> GetJCBCustomerApplicationFormNameOnCard([FromBody] GetJCBCustomerApplicationFormModelInput ObjClass);
        public Task<IEnumerable<GetJCBUploadKycDocumentsModelOutput>> GetJCBUploadKycDocument([FromBody] GetJCBUploadKycDocumentsModelInput ObjClass);
        public Task<IEnumerable<InsertJCBCustomerKYCModelOutput>> UpdateJCBCustomerKYC([Microsoft.AspNetCore.Mvc.FromForm] InsertJCBCustomerKYCModelInput ObjClass);
        public Task<IEnumerable<GetJCBCustomerDetailForVerificationModelOutput>> GetJCBCustomerDetailForVerification([FromBody] GetJCBCustomerDetailForVerificationModelInput ObjClass);
        public Task<IEnumerable<GetJCBCustomerStatusDetailOutput>> GetJCBCustomerStatusDetail([FromBody] GetJCBCustomerStatusDetailInput ObjClass);
        public Task<IEnumerable<UpdateJCBCustomerStatusModelOutput>> UpdateJCBCustomerStatus([FromBody] UpdateJCBCustomerStatusModelInput ObjClass);

        public Task<IEnumerable<JCBLoyalityPointSummaryModelOutput>> GetJCBLoyalityPointSummary(JCBLoyalityPointSummaryModelInput objClass);
    }
}
