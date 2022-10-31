using HPPay.DataModel.RBE;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HPPay.DataRepository.RBE
{
    public interface IRBERepository
    {
        public Task<IEnumerable<ChangeRBEMappingModelOutput>> ChangeRBEMapping([FromBody] ChangeRBEMappingModelInput ObjClass);

        public Task<IEnumerable<ManageRBEUserModelOutput>> ManageRBEUser([FromBody] ManageRBEUserModelInput ObjClass);

        public Task<IEnumerable<GetPendingRbeConsentModelOutput>> GetPendingRbeConsent([FromBody] GetPendingRbeConsentModelInput ObjClass);

        public Task<IEnumerable<RbeSentOtpForgotPasswordModelOutput>> RbeSentOtpForgotPassword([FromBody] RbeSentOtpForgotPasswordModelInput ObjClass);

        public Task<IEnumerable<RbeValidateForgotPasswordModelOutput>> RbeValidateForgotPassword([FromBody] RbeValidateForgotPasswordModelInput ObjClass);

        public Task<IEnumerable<GetRbeDashboardModelOutput>> GetRbeDashboard([FromBody] GetRbeDashboardModelInput ObjClass);

        public Task<IEnumerable<GetNewRbeAddCardsModelOutput>> GetNewRbeAddCards([FromBody] GetNewRbeAddCardsModelInput ObjClass);

        public Task<IEnumerable<GetNewRbeEnrollCustomersModelOutput>> GetNewRbeEnrollCustomers([FromBody] GetNewRbeEnrollCustomersModelInput ObjClass);

        public Task<IEnumerable<RBEGetModelOutput>> GetRBEId([FromBody] RBEGetModelInput ObjClass);

        public Task<IEnumerable<RbeSentOtpNewEnrollCustomerModelOutput>> RbeSentOtpNewEnrollCustomer([FromBody] RbeSentOtpNewEnrollCustomerModelInput ObjClass);

        public Task<IEnumerable<RbeValidateOtpNewEnrollCustomerModelOutput>> RbeValidateOtpNewEnrollCustomer([FromBody] RbeValidateOtpNewEnrollCustomerModelInput ObjClass);

        public Task<IEnumerable<BindRBEModelOutput>> BindRBEbyRBEId([FromBody] BindRBEModelInput ObjClass);

        public Task<IEnumerable<InsertRBEModelOutput>> InsertRBE([FromBody] InsertRBEModelInput ObjClass);

        public Task<IEnumerable<RBEUpdateModelOutput>> UpdateRBE([FromBody] RBEUpdateModelInput ObjClass);

        public Task<IEnumerable<RBEKYCModelOutput>> UploadRBEKYC([FromForm] RBEKYCModelInput ObjClass);

        public Task<IEnumerable<GetRBEMobilenoModelOutput>> CheckRBEMobileNo([FromBody] GetRBEMobilenoModelInput ObjClass);

        public Task<IEnumerable<GetRBECreationApprovalModelOutput>> BindRBEDetail([FromBody] GetRBECreationApprovalModelInput ObjClass);

        public Task<IEnumerable<GetRBEDetailbyUserNameModelOutput>> GetRBEDetailbyUserName([FromBody] GetRBEDetailbyUserNameModelInput ObjClass);

        public Task<IEnumerable<RBEApprovalRejectApprovalModelOutput>> ApproveRejectRBE([FromBody] RBEApprovalRejectModelInput ObjClass);

        public Task<IEnumerable<GetRBEDeviceIdResetRequestModelOutput>> GetRBEDeviceIdResetRequest([FromBody] GetRBEDeviceIdResetRequestModelInput ObjClass);
       
        public Task<IEnumerable<GetRBEMobileChangeRequestModelOutput>> GetRBEMobileChangeRequest([FromBody] GetRBEMobileChangeRequestModelInput ObjClass);
       
        public Task<IEnumerable<RequestToChangeRBEMappingModelOutput>> RequestToChangeRBEMapping([FromBody] RequestToChangeRBEMappingModelInput ObjClass);
       
        public Task<IEnumerable<ValidateOtpRBEMappingModelOutput>> ValidateOtpRBEMapping([FromBody] ValidateOtpRBEMappingModelInput ObjClass);

        public Task<IEnumerable<GetApproveChangeRBEMappingModelOutput>> GetApproveChangeRBEMapping([FromBody] GetApproveChangeRBEMappingModelInput ObjClass);

        public Task<IEnumerable<GetRbeMappingStatusModelOutput>> GetRbeMappingStatus([FromBody] GetRbeMappingStatusModelInput ObjClass);

        public Task<IEnumerable<ApproveRejectChangedRbeMappingModelOutput>> ApproveRejectChangedRbeMapping([FromBody] ApproveRejectChangedRbeMappingModelInput ObjClass);


        public Task<IEnumerable<SendOtpChangeRBEMobileModelOutput>> SendOtpChangeRBEMobile([FromBody] SendOtpChangeRBEMobileModelInput ObjClass);

        public Task<IEnumerable<ValidateOtpChangeRbeMobileModelOutput>> ValidateOtpChangeRbeMobile([FromBody] ValidateOtpChangeRbeMobileModelInput ObjClass);

        public Task<IEnumerable<GetApproveChangedRBEMobileModelOutput>> GetApproveChangedRBEMobile([FromBody] GetApproveChangedRBEMobileModelInput ObjClass);

        public Task<IEnumerable<ApproveRejectChangedRbeMobileModelOutput>> ApproveRejectChangedRbeMobile([FromBody] ApproveRejectChangedRbeMobileModelInput ObjClass);

        public Task<IEnumerable<SendOtpResetRBEDeviceModelOutput>> SendOtpResetRBEDevice([FromBody] SendOtpResetRBEDeviceModelInput ObjClass);

        public Task<IEnumerable<ValidateOtpResetRBEDeviceModelOutput>> ValidateOtpResetRBEDevice([FromBody] ValidateOtpResetRBEDeviceModelInput ObjClass);

        public Task<IEnumerable<GetApproveChangedRBEDeviceResetModelOutput>> GetApproveChangedRBEDeviceReset([FromBody] GetApproveChangedRBEDeviceResetModelInput ObjClass);

        public Task<IEnumerable<ApproveRejectChangedRBEDeviceResetModelOutput>> ApproveRejectChangedRBEDeviceReset([FromBody] ApproveRejectChangedRBEDeviceResetModelInput ObjClass);


        public Task<IEnumerable<InsertVisitModelOutput>> InsertVisit([FromBody] InsertVisitModelInput ObjClass);
        public Task<IEnumerable<GenerateRBEEmpIDModelOutput>> GenerateRBEEmpID([FromBody] GenerateRBEEmpIDModelInput ObjClass);
        public Task<IEnumerable<RbeDistrictMappingModelOutput>> RbeDistrictMapping([FromBody] RbeDistrictMappingModelInput ObjClass);
        public  Task<IEnumerable<GetRbeidAndNameModelOutput>> GetRbeidAndName([FromBody] GetRbeidAndNameModelInput ObjClass);
        public Task<IEnumerable<GetCustomerVisitPlanModelOutput>> GetCustomerVisitPlan([FromBody] GetCustomerVisitPlanModelInput ObjClass);
        public Task<IEnumerable<GetCustomerVisitPlanDetailsByVisitNumberModelOutput>> GetCustomerVisitPlanDetailsByVisitNumber([FromBody] GetCustomerVisitPlanDetailsByVisitNumberModelInput ObjClass);
        public Task<IEnumerable<RBEGetRBEStateDetailsModelOutput>> BindRBEStateDetail([FromBody] RBEGetRBEStateDetailsModelInput ObjClass);
        public Task<IEnumerable<RBEUpdateLocationMappingModelOutput>> UpdateRBEStateMapping([FromBody] RBEUpdateLocationMappingModelInput ObjClass);
        public  Task<IEnumerable<RBEGetUserCreationApprovalForRBEModelOutput>> GetRBEStateDetail([FromBody] RBEGetUserCreationApprovalForRBEModelInput ObjClass);
    }
}
