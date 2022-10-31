using HPPay.DataModel.Fastlane;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HPPay.DataRepository.Fastlane
{
    public interface IFastlaneIntegrationRepository
    {
        public Task<ActiveCityList_Response> GetActiveCityList();

        public Task<CustomerRegistration_CustomerInfo_Response> GetCustomerInfo_CustomerRegistration(CustomerRegistration_Request objClass);

        public Task<object> UpdateLoyalUserFastlaneId(CustomerRegistration_Response objClass);

        public Task<VahanVehicleDetail> GetVahanVehicleDetail(VehicleValidation objClass);

        public Task<VahanVehicleDetail> SaveVahanVehicleDetail(VahanVehicleDetail objClass);

        public Task<CustomerRegistration_Response> GetLoyalUserDetails(Input_VehicleRegistration objClass);

        public Task<object> SaveVehicleFastlaneMappingDetail(VehicleTagMappingDetails objClass);

        public Task<object> UpdateVehicleFastlaneMappingDetail(VehicleTagMappingDetails objClass);

        public Task<VehicleTagMappingDetails> GetVehicleFastlaneMappingDetails(Input_VehicleTagMapping objClass);

        public Task<VehiclePresetDetails_Output> GetVehiclePresetDetails(Input_VehiclePresetDetails objClass);

        public Task<object> UpdateVehiclePresetRequestDetails(VehiclePresetUpdateRequestDetails objClass);

        public Task<IList<PresetVehicleList_Output>> GetPresetVehicleList(Input_PresetVehicleList objClass);

        public Task<VehiclePresetCancelDetails> GetPresetCancelDetails(Input_VehiclePresetCancel objClass);

        public Task<IList<VehicleList_Output>> GetVehicleList(Input_VehicleList objClass);

        public Task<FastlaneLastPresetAmount_Output> GetFastlaneLastPresetAmount(Input_FastlaneLastPresetAmount objClass);

        public Task<ProcessSaleCompletion_Output> ProcessSaleCompletion(Input_ProcessSaleCompletion objClass);

        public Task<InitiateRefund_Output> InitiateRefund(Input_InitiateRefund objClass);

        public Task<CheckStatus_Output> CheckStatus(Input_CheckStatus objClass);
    }
}
