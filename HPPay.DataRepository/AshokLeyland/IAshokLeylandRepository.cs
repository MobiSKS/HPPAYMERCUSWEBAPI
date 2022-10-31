using HPPay.DataModel.AshokLeyland;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HPPay.DataRepository.AshokLeyland
{
    public interface IAshokLeylandRepository
    {
        public Task<IEnumerable<ALDealerEnrollmentModelOutput>> InsertALDealerEnrollment([FromBody] ALDealerEnrollmentModelInput ObjClass);

        public Task<IEnumerable<UpdateALDealerEnrollmentModelOutput>> UpdateALDealerEnrollment([FromBody] UpdateALDealerEnrollmentModelInput ObjClass);

        public Task<IEnumerable<GetDealerNameModelOutput>> GetALDealerDetail([FromBody] GetDealerNameModelInput ObjClass);

        public Task<IEnumerable<CheckDealerCodeModelOutput>> CheckDealerCode([FromBody] CheckDealerCodeModelInput ObjClass);

        public Task<IEnumerable<InsertALCustomerModelOutput>> InsertALCustomer([FromBody] InsertALCustomerModelInput ObjClass);

        public Task<IEnumerable<InsertDealerWiseALOTCCardRequestModelOutput>> InsertDealerWiseALOTCCardRequest([FromBody] InsertDealerWiseALOTCCardRequestModelInput ObjClass);

        public Task<IEnumerable<GetAvailityALOTCCardCardOutput>> GetAvailityALOTCCard([FromBody] GetAvailityALOTCCardCardInput ObjClass);

        public Task<ALViewCardMerchantAllocationModelOutput> ViewALOTCCardDealerAllocation([FromBody] ALViewCardDealerAllocationModelInput ObjClass);

        public Task<GetAlAddonOTCCardMappingCustomerDetailsModelOutput> GetAlAddonOTCCardMappingCustomerDetails([FromBody] GetAlAddonOTCCardMappingCustomerDetailsModelInput ObjClass);

        public Task<IEnumerable<GetAlSalesExeEmpIdAddOnOTCCardMappingModelOutput>> GetAlSalesExeEmpIdAddOnOTCCardMapping([FromBody] GetAlSalesExeEmpIdAddOnOTCCardMappingModelInput ObjClass);

        public Task<IEnumerable<AlAddOnOTCCardModelOutput>> AlAddOnOTCCard([FromBody] AlAddOnOTCCardModelInput ObjClass);
        public Task<IEnumerable<GetALVerifyCustomerDocumentModelOutput>> GetALVerifyCustomerDocument([FromBody] ALVerifyCustomerDocumentModelInput ObjClass);
        public Task<IEnumerable<GetALUploadKycDocumentsModelOutput>> GetALUploadKycDocument([FromBody] GetALUploadKycDocumentsModelInput ObjClass);

        public Task<IEnumerable<InsertALCustomerKYCModelOutput>> InsertALCustomerKYC([FromForm] InsertALCustomerKYCModelInput ObjClass);
        public Task<IEnumerable<GetAlCustomerDetailForVerificationModelOutput>> GetAlCustomerDetailForVerification([FromBody] GetAlCustomerDetailForVerificationModelInput ObjClass);
        public Task<IEnumerable<GetALCustomerStatusDetailOutput>> GetALCustomerStatusDetail([FromBody] GetALCustomerStatusDetailInput ObjClass);
        public Task<IEnumerable<UpdateALCustomerStatusModelOutput>> UpdateALCustomerStatus([FromBody] UpdateALCustomerStatusModelInput ObjClass);
        public  Task<IEnumerable<GetALCustomerDetailModelOutput>> GetALCustomerDetail([FromBody] GetALCustomerDetailModelInput ObjClass);
        public Task<IEnumerable<UpdateALCustomerDetailModelOutput>> UpdateALCustomerDetail([FromBody] UpdateALCustomerDetailModelinput ObjClass);
        public Task<ALCustomerDetailsModelOutput> GetALCustomerDetails([FromBody] ALCustomerDetailsModelInput ObjClass);
        public Task<IEnumerable<ManageALSearchCardsModelOutput>> SearchALManageCard([FromBody] ManageALSearchCardsModelInput ObjClass);
        public Task<IEnumerable<ApprovalALCustomerUpdateRequestModelOutput>> ApprovalALCustomerUpdateRequest([FromBody] ApprovalALCustomerUpdateRequestModelInput ObjClass);
        public Task<IEnumerable<ALCustomerDetailUpdateModelOutput>> RequestUpdateALCustomer([FromBody] ALCustomerDetailUpdateModelInput ObjClass);

        public Task<IEnumerable<ALGetGenericAttachedVehicleModelOutput>> ALGetGenericAttachedVehicle([FromBody] ALGetGenericAttachedVehicleModelInput ObjClass);
        public Task<IEnumerable<GetALCheckVinNumberModelOutput>> GetALCheckVinNumber([FromBody] GetALCheckVinNumberModelInput ObjClass);
        public Task<IEnumerable<GetALPendingKycCustomerModelOutput>> GetALPendingKycCustomer([FromBody] GetALPendingKycCustomerModelInput ObjClass);
        public Task<IEnumerable<UpdateALCommunicationEmailResetPasswordModelOutput>> UpdateALCommunicationEmailResetPassword(UpdateALCommunicationEmailResetPasswordModelInput objClass);
        public Task<IEnumerable<GetALVehicleSpecificCardRequestModelOutput>> GetALVehicleSpecificCardRequest([FromBody] GetALVehicleSpecificCardRequestModelInput ObjClass);
        public Task<IEnumerable<InsertALVehicleSpecificCardRequestModelOutput>> InsertALVehicleSpecificCardRequest([FromBody] InsertALVehicleSpecificCardRequestModelInput ObjClass);
        public Task<IEnumerable<GetALDispatchDetailModelOutput>> GetALDispatchDetail([FromBody] GetALDispatchDetailModelInput ObjClass);
        public Task<IEnumerable<GetALVehicleSpecificCardApproveModelOutput>> GetALVehicleSpecificCardApprove([FromBody] GetALVehicleSpecificCardApproveModelInput ObjClass);
        public Task<IEnumerable<ApproveALVehicleSpecificCardApproveModelOutput>> InsertALVehicleSpecificCardRequestApprove([FromBody] ApproveALVehicleSpecificCardApproveModelInput ObjClass);
        public Task<IEnumerable<UpdateALHotlistReactivateModelOutput>> UpdateALHotlistReactivate(UpdateALHotlistReactivateModelInput ObjClass);
        public Task<IEnumerable<GetALCustomerKYCModelOutput>> GetALCustomerKYC(GetALCustomerKYCModelInput objClass);
        public Task<ALUnMappedOTCCardModelOutput> ALUnMappedOTCCardDetail([FromBody] ALUnMappedOTCCardModelInput ObjClass);
        public Task<GetALCustomerApplicationFormNameOnCardModelOutput> GetALCustomerApplicationFormNameOnCard([FromBody] GetALCustomerApplicationFormModelInput ObjClass);
    }
}
