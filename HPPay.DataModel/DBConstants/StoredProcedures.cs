namespace HPPay.DataModel.DBConstants
{
    public class StoredProcedures
    {
        /// <summary>
        /// Fastlane API Stored Procedure.
        /// </summary>

        public const string GET_ACTIVECITYLIST = "UspFastlaneGetActiveCityList";

        public const string GET_CUSTOMERINFO_CUSTOMERREGISTRATION = "UspFastlaneGetCustomerInfoCustomerRegistration";

        public const string UPDATE_FASTLANEID_MSTCUSTOMER = "UspFastlaneUpdatemstCustomer";

        public const string GET_SAVE_VAHANVEHICLEDETAIL = "UspFastlaneInitVahanVehicleDetail";

        public const string GET_LOYALUSER_DETAILS = "UspFastlaneGetLoyalUserDetail";

        public const string SAVE_VEHICLE_FASTLANE_MAPPING = "UspFastlaneInitVehicleFastlaneMapping";

        public const string GET_VEHICLE_FASTLANE_MAPPING_DETAIL = "UspFastlaneGetVehicleFastlaneMappingDetail";

        public const string UPDATE_VEHICLE_FASTLANE_MAPPING = "UspFastlaneUpdateVehicleFastlaneMapping";

        public const string GET_VEHICALPRESET_DETAIL = "Usp_Fastlane_GetCheckVehicalPreset_Details";

        public const string UPDATE_VEHICLE_PRESET_REQUEST = "Usp_Fastlane_Update_VehiclePresetRequest";

        public const string GET_PRESET_VEHICLE_LIST = "UspFastlaneGetPresetVehicleList";

        public const string GET_VEHICLE_PRESET_CANCEL_DETAIL = "Usp_Fastlane_GetPresetCancelDetails";

        public const string GET_VEHICLE_LIST = "UspFastlaneGetVehicleList";

        public const string GET_Fastlane_Last_Preset_Amount = "UspFastlaneGetFastlaneLastPresetAmount";

        public const string POST_FASTLANE_PROCESSSALECOMPLETION = "Usp_Fastlane_ProcessSaleCompletion";

        public const string POST_FASTLANE_CANCELSALECOMPLETION = "Usp_Fastlane_CancelSaleCompletion";

        public const string GET_FASTLANE_SALECOMPLETIONSTATUSCHECK = "Usp_Fastlane_SaleCompletionStatusCheck";
    }
}
