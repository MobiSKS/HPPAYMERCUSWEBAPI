using HPPay.DataModel.VolvoEicher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.VolvoEicher
{
    public interface IVolcoEicherRepository
    {

        public Task<IEnumerable<VEDealerEnrollmentModelOutput>> InsertVEDealerEnrollment([FromBody] VEDealerEnrollmentModelInput ObjClass);
        public Task<IEnumerable<UpdateVEDealerEnrollmentModelOutput>> UpdateVEDealerEnrollment([FromBody] UpdateVEDealerEnrollmentModelInput ObjClass);
        public Task<IEnumerable<GetVEDealerNameModelOutput>> GetVEDealerDetail([FromBody] GetVEDealerNameModelInput ObjClass);
        public Task<IEnumerable<InsertVECustomerModelOutput>> InsertVECustomer([FromBody] InsertVECustomerModelInput ObjClass);

        public Task<IEnumerable<CheckVEDealerCodeModelOutput>> CheckVEDealerCode([FromBody] CheckVEDealerCodeModelInput ObjClass);
        public Task<IEnumerable<InsertDealerWiseVEOTCCardRequestModelOutput>> InsertDealerWiseVEOTCCardRequest([FromBody] InsertDealerWiseVEOTCCardRequestModelInput ObjClass);
        public Task<IEnumerable<GetAvailityVEOTCCardOutput>> GetAvailityVEOTCCard([FromBody] GetAvailityVEOTCCardInput ObjClass);
        public Task<VEViewCardMerchantAllocationModelOutput> ViewVEOTCCardDealerAllocation([FromBody] VEViewCardDealerAllocationModelInput ObjClass);
        public Task<GetVEAddonOTCCardMappingCustomerDetailsModelOutput> GetVEAddonOTCCardMappingCustomerDetails([FromBody] GetVEAddonOTCCardMappingCustomerDetailsModelInput ObjClass);
        public Task<IEnumerable<GetVESalesExeEmpIdAddOnOTCCardMappingModelOutput>> GetVESalesExeEmpIdAddOnOTCCardMapping([FromBody] GetVESalesExeEmpIdAddOnOTCCardMappingModelInput ObjClass);
        public Task<IEnumerable<VEAddOnOTCCardModelOutput>> VEAddOnOTCCard([FromBody] VEAddOnOTCCardModelInput ObjClass);
        public Task<IEnumerable<GetVEVerifyCustomerDocumentModelOutput>> GetVEVerifyCustomerDocument([FromBody] VEVerifyCustomerDocumentModelInput ObjClass);
        public Task<IEnumerable<GetVEUploadKycDocumentsModelOutput>> GetVEUploadKycDocument([FromBody] GetVEUploadKycDocumentsModelInput ObjClass);
        public Task<IEnumerable<InsertVECustomerKYCModelOutput>> InsertVECustomerKYC([Microsoft.AspNetCore.Mvc.FromForm] InsertVECustomerKYCModelInput ObjClass);
        public Task<IEnumerable<GetVECustomerDetailForVerificationModelOutput>> GetVECustomerDetailForVerification([FromBody] GetVECustomerDetailForVerificationModelInput ObjClass);

        public Task<IEnumerable<ViewVEDealerOTCCardStatusModelOutput>> ViewVEDealerOTCCardStatus([FromBody] ViewVEDealerOTCCardStatusModelInput ObjClass);
        public  Task<ViewVEDealerOTCCardDetailModelOutput> ViewVEDealerOTCCardDetail([FromBody] ViewVEDealerOTCCardDetailModelInput ObjClass);

        public Task<VolvoCustomerDetailsModelOutput> GetVolvoCustomerDetails([FromBody] VolvoCustomerDetailsModelInput ObjClass);
        public Task<IEnumerable<ManageVESearchCardsModelOutput>> SearchManageCard([FromBody] ManageVESearchCardsModelInput ObjClass);
        public Task<IEnumerable<UpdateVECustomerDetailModelOutput>> UpdateVECustomerDetail([FromBody] UpdateVECustomerDetailModelinput ObjClass);
        public Task<IEnumerable<VECustomerDetailUpdateModelOutput>> RequestUpdateVECustomer([FromBody] VECustomerDetailUpdateModelInput ObjClass);
        public Task<IEnumerable<ApprovalVECustomerUpdateRequestModelOutput>> ApprovalVECustomerUpdateRequest([FromBody] ApprovalVECustomerUpdateRequestModelInput ObjClass);
        public Task<IEnumerable<UpdateVECommunicationEmailResetPasswordModelOutput>> UpdateVECommunicationEmailResetPassword(UpdateVECommunicationEmailResetPasswordModelInput objClass);
        public  Task<IEnumerable<GetVEDispatchDetailModelOutput>> GetVEDispatchDetail([FromBody] GetVEDispatchDetailModelInput ObjClass);
        public Task<GetVECustomerApplicationFormNameOnCardModelOutput> GetVECustomerApplicationFormNameOnCard([FromBody] GetVECustomerApplicationFormModelInput ObjClass);
        public Task<IEnumerable<UpdateVECustomerStatusModelOutput>> UpdateVECustomerStatus([FromBody] UpdateVECustomerStatusModelInput ObjClass);
        public Task<IEnumerable<GetVECustomerStatusDetailOutput>> GetVECustomerStatusDetail([FromBody] GetVECustomerStatusDetailInput ObjClass);
        public Task<IEnumerable<GetVECustomerKYCModelOutput>> GetVECustomerKYC(GetVECustomerKYCModelInput objClass);
    }
}
