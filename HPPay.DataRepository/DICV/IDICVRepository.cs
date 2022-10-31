using HPPay.DataModel.DICV;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HPPay.DataRepository.DICV
{
    public interface IDICVRepository
    {
        public Task<IEnumerable<CheckDICVDealerCodeModelOutput>> CheckDICVDealerCode([FromBody] CheckDICVDealerCodeModelInput ObjClass);
        public Task<IEnumerable<GetAvailityDICVOTCCardModelOutput>> GetAvailityDICVOTCCard([FromBody] GetAvailityDICVOTCCardModelInput ObjClass);
        public Task<IEnumerable<InsertDICVCustomerModelOutput>> InsertDICVCustomer([FromForm] InsertDICVCustomerModelInput ObjClass);
        public Task<IEnumerable<InsertDICVCustomerKYCModelOutput>> InsertDICVCustomerKYC([FromForm] InsertDICVCustomerKYCModelInput ObjClass);
        public Task<IEnumerable<GetDICVUploadKycDocumentsModelOutput>> GetDICVUploadKycDocument([FromBody] GetDICVUploadKycDocumentsModelInput ObjClass);
        public Task<GetDICVAddonOTCCardMappingCustomerDetailsModelOutput> GetDICVAddonOTCCardMappingCustomerDetails([FromBody] GetDICVAddonOTCCardMappingCustomerDetailsModelInput ObjClass);
        public Task<IEnumerable<GetDICVSalesExeEmpIdAddOnOTCCardMappingModelOutput>> GetDICVSalesExeEmpIdAddOnOTCCardMapping([FromBody] GetDICVSalesExeEmpIdAddOnOTCCardMappingModelInput ObjClass);
        public Task<IEnumerable<DICVAddOnOTCCardModelOutput>> DICVAddOnOTCCard([FromBody] DICVAddOnOTCCardModelInput ObjClass);

        public Task<IEnumerable<GetDICVCustomerDetailForVerificationModelOutput>> GetDICVCustomerDetailForVerification([FromBody] GetDICVCustomerDetailForVerificationModelInput ObjClass);
        public Task<IEnumerable<GetDICVCustomerStatusDetailOutput>> GetDICVCustomerStatusDetail([FromBody] GetDICVCustomerStatusDetailInput ObjClass);
        public Task<IEnumerable<UpdateDICVCustomerStatusModelOutput>> UpdateDICVCustomerStatus([FromBody] UpdateDICVCustomerStatusModelInput ObjClass);
        public Task<IEnumerable<GetDICVCustomerDetailModelOutput>> GetDICVCustomerDetail([FromBody] GetDICVCustomerDetailModelInput ObjClass);
        public Task<IEnumerable<UpdateDICVCustomerDetailModelOutput>> UpdateDICVCustomerDetail([FromBody] UpdateDICVCustomerDetailModelinput ObjClass);
        public Task<IEnumerable<ViewDICVDealerOTCCardStatusModelOutput>> ViewDICVDealerOTCCardStatus([FromBody] ViewDICVDealerOTCCardStatusModelInput ObjClass);
        public Task<IEnumerable<GetDealerDetailModelOutput>> GetDICVDealerDetail([FromBody] GetDealerDetailModelInput ObjClass);
        public Task<IEnumerable<DICVDealerEnrollmentModelOutput>> InsertDICVDealerEnrollment([FromBody] DICVDealerEnrollmentModelInput ObjClass);
        public Task<IEnumerable<UpdateDICVDealerEnrollmentModelOutput>> UpdateDICVDealerEnrollment([FromBody] UpdateDICVDealerEnrollmentModelInput ObjClass);
        public Task<DICVCustomerDetailsModelOutput> GetDICVCustomerDetails([FromBody] DICVCustomerDetailsModelInput ObjClass);
        public Task<IEnumerable<ManageDICVSearchCardsModelOutput>> SearchManageCard([FromBody] ManageDICVSearchCardsModelInput ObjClass);
        public Task<IEnumerable<DICVCustomerDetailUpdateModelOutput>> RequestUpdateDICVCustomer([FromBody] DICVCustomerDetailUpdateModelInput ObjClass);
        public Task<IEnumerable<ApprovalDICVCustomerUpdateRequestModelOutput>> ApprovalDICVCustomerUpdateRequest([FromBody] ApprovalDICVCustomerUpdateRequestModelInput ObjClass);
        public Task<GetDICVCardLimtModelOutput> GetDICVCardLimitFeatures([FromBody] GetDICVCardLimtModelInput ObjClass);
        public Task<IEnumerable<DICVUpdateMobileInCardModelOutput>> DICVUpdateMobileInCard([FromBody] DICVUpdateMobileInCardModelInput ObjClass);
        public Task<IEnumerable<GetDICVCustomerBalanceInfoModelOutput>> GetCustomerBalanceInfo([FromBody] GetDICVCustomerBalanceInfoModelInput ObjClass);
        public Task<GetDICVTransactionsSummaryModelOutput> GetDICVTransactionsSummary([FromBody] GetDICVTransactionsSummaryModelInput ObjClass);
        public Task<IEnumerable<DICVGetMobileandFastagNoModelOutput>> GetDICVMobileandFastagNo([FromBody] DICVGetMobileandFastagNoModelInput ObjClass);
        public Task<IEnumerable<DICVUpdateMobileandFastagNoModelOutput>> DICVUpdateMobileandFastagNo([FromBody] DICVUpdateMobileandFastagNoModelInput ObjClass);
        public Task<IEnumerable<GetDICVAdvancedSearchModelOutput>> GetDICVAdvancedSearch([FromBody] GetDICVAdvancedSearchModelInput ObjClass);
        public Task<IEnumerable<GetDICVCommunicationEmailResetPasswordModelOutput>> GetDICVCommunicationEmailResetPassword(GetDICVCommunicationEmailResetPasswordModelInput objClass);
        public Task<IEnumerable<UpdateDICVCommunicationEmailResetPasswordModelOutput>> UpdateDICVCommunicationEmailResetPassword(UpdateDICVCommunicationEmailResetPasswordModelInput objClass);

        public Task<GetDICVCustomerApplicationFormNameOnCardModelOutput> GetDICVCustomerApplicationFormNameOnCard([FromBody] GetDICVCustomerApplicationFormModelInput ObjClass);

        public Task<IEnumerable<UpdateDICVHotlistReactivateModelOutput>>UpdateDICVHotlistReactivate([FromBody]UpdateDICVHotlistReactivateModelInput ObjClass);

        public Task<IEnumerable<GetDICVHotlistReactiveModelOutput>> GetDICVHotListReason([FromBody] GetDICVHotlistReactiveModelInput ObjClass);
        public Task<IEnumerable<InsertDealerWiseDICVOTCCardRequestModelOutput>> InsertDealerWiseDICVOTCCardRequest([FromBody] InsertDealerWiseDICVOTCCardRequestModelInput ObjClass);
        public  Task<DICVUnMappedOTCCardModelOutput> DICVUnMappedOTCCardDetail([FromBody] DICVUnMappedOTCCardModelInput ObjClass);

        public Task<IEnumerable<GetDICVOfficerTypeModelOutput>> GetDICVOfficerType([FromBody] GetDICVOfficerTypeModelInput ObjClass);
        public Task<IEnumerable<GetDICVBalanceOTCCardModelOutput>> GetDICVBalanceOTCCard([FromBody] GetDICVBalanceOTCCardModelInput ObjClass);
        public Task<IEnumerable<UpdateDICVCommunicationEmailResetPasswordModelOutput>> UpdateDICVDealerEmailResetPassword(UpdateDicvDealerEmailResetPasswordModelInput objClass);
        public Task<IEnumerable<EnableDisableDICVDealerModelOutput>> EnableDisableDICVDealer([FromBody] EnableDisableDICVDealerModelInput ObjClass);
        public  Task<IEnumerable<GetDICVCustomerKYCModelOutput>> GetDICVCustomerKYC(GetDICVCustomerKYCModelInput objClass);
        public Task<IEnumerable<DICVContactUSDetailModelOutput>> GetDICVContactUSDetail(DICVContactUSDetailModelInput objClass);
        public Task<IEnumerable<DICVLoyalityPointSummaryModelOutput>> GetDICVLoyalityPointSummary(DICVLoyalityPointSummaryModelInput objClass);
        public Task<IEnumerable<GetDICVDispatchDetailModelOutput>> GetDICVDispatchDetail([FromBody] GetDICVDispatchDetailModelInput ObjClass);
    }
}
