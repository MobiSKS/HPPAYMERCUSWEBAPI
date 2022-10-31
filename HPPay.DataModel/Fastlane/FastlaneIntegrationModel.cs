using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Fastlane
{
    public class FastlaneIntegrationRequestBase : BaseClass
    {
        [JsonPropertyName("APIKey")]
        [DataMember]
        //[Required(ErrorMessage = "Required, APIKey by which the customer will access the API.", AllowEmptyStrings = false)]
        //[StringLength(maximumLength:100, MinimumLength = 32, ErrorMessage = "APIKey length should be 100")]
        public string APIKey { get; set; }
    }

    public class FastlaneIntegrationResponseBase
    {
        [JsonPropertyName("ResponseCode")]
        [DataMember]
        public int ResponseCode { get; set; }

        [JsonPropertyName("ResponseMessage")]
        [DataMember]
        public string ResponseMessage { get; set; } = string.Empty;

        [JsonPropertyName("ErrorCode")]
        [DataMember]
        public int ErrorCode { get; set; }
    }

    public class CryptoDecryptResponse
    {
        [JsonPropertyName("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonPropertyName("Message")]
        [DataMember]
        public string Message { get; set; }

        [JsonPropertyName("Data")]
        [DataMember]
        public string Data { get; set; }
    }


    public class ActiveCityList_Request : BaseClass
    {
    }


    public class ActiveCityList_Response : FastlaneIntegrationResponseBase
    {
       public List<ActiveCityList> activeCityLists { get; set; }
    }

    public class ActiveCityList
    {
        [JsonPropertyName("CityId")]
        [DataMember]
        public string CityId { get; set; }

        [JsonPropertyName("CityName")]
        [DataMember]
        public string CityName { get; set; }

        [JsonPropertyName("DisplayOrder")]
        [DataMember]
        public string DisplayOrder { get; set; }
    }

    public class CustomerRegistration_Request : FastlaneIntegrationRequestBase
    {
        [Required(ErrorMessage = "EmailId is Required.")]
        [DataMember]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Mobile Number is Required.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Provide a valid phone number")]
        [DataMember]
        public long MobileNo { get; set; }
    }


    public class CustomerRegistration_Response : FastlaneIntegrationResponseBase
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public long CustomerID { get; set; }

        [JsonPropertyName("FastlaneID")]
        [DataMember]
        public string FastlaneID { get; set; }

        [JsonPropertyName("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonPropertyName("Message")]
        [DataMember]
        public string Message { get; set; }
    }


    public class CustomerRegistration_CustomerInfo_Response : FastlaneIntegrationResponseBase
    {
        [JsonPropertyName("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonPropertyName("LastName")]
        [DataMember]
        public string LastName { get; set; }

        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonPropertyName("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonPropertyName("Address")]
        [DataMember]
        public string Address { get; set; }

        [JsonPropertyName("CustomerDomain")]
        [DataMember]
        public string CustomerDomain { get; set; }

        [JsonPropertyName("CustomerID")]
        [DataMember]
        public long? CustomerID { get; set; }

        [JsonPropertyName("OrganizationName")]
        [DataMember]
        public string OrganizationName { get; set; }
    }


    public class VehicleValidation : FastlaneIntegrationRequestBase
    {
        [JsonPropertyName("VehicleNumber")]
        [Required(ErrorMessage = "VehicleNumber is Required.")]
        [DataMember]
        public string VehicleNumber { get; set; }

        [JsonPropertyName("Consent")]
        [DataMember]
        public string Consent { get; set; } = "Y";

        [JsonPropertyName("Version")]
        [DataMember]
        public string Version { get; set; } = "3.1";
    }


    public class VahanVehicleDetail : FastlaneIntegrationResponseBase
    {
        [JsonPropertyName("Vehicle_Number")]
        [DataMember]
        public string Vehicle_Number { get; set; }

        [JsonPropertyName("Registration_Date")]
        [DataMember]
        public string Registration_Date { get; set; }

        [JsonPropertyName("Owner_Name")]
        [DataMember]
        public string Owner_Name { get; set; }

        [JsonPropertyName("Fuel_Type")]
        [DataMember]
        public string Fuel_Type { get; set; }

        [JsonPropertyName("Model_MakerClass")]
        [DataMember]
        public string Model_MakerClass { get; set; }

        [JsonPropertyName("Maker_Manufacturer")]
        [DataMember]
        public string Maker_Manufacturer { get; set; }

        [JsonPropertyName("Insurance_Upto")]
        [DataMember]
        public string Insurance_Upto { get; set; }

        [JsonPropertyName("Created")]
        [DataMember]
        public DateTime? Created { get; set; }

        [JsonPropertyName("Modified")]
        [DataMember]
        public DateTime? Modified { get; set; }

        [JsonPropertyName("Status_Flag")]
        [DataMember]
        public int Status_Flag { get; set; }

        [JsonPropertyName("Message")]
        [DataMember]
        public string Message { get; set; }

        [JsonPropertyName("ResponseStatus")]
        [DataMember]
        public string ResponseStatus { get; set; }

        [JsonPropertyName("ResponseMsg")]
        [DataMember]
        public string ResponseMsg { get; set; }
    }


    public class VahanVehicleDetailobject
    {
        [JsonPropertyName("requestId")]
        [DataMember]
        public string requestId { get; set; }

        [JsonPropertyName("result")]
        [DataMember]
        public VahanVehicleDetailResult result { get; set; }

        [JsonPropertyName("statusCode")]
        [DataMember]
        public int statusCode { get; set; }

        [JsonPropertyName("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonPropertyName("Message")]
        [DataMember]
        public string Message { get; set; }
    }


    public class VahanVehicleDetailResult
    {
        [JsonPropertyName("seatingCapacity")]
        [DataMember]
        public string seatingCapacity { get; set; }

        [JsonPropertyName("taxPaidUpto")]
        [DataMember]
        public string taxPaidUpto { get; set; }

        [JsonPropertyName("vehicleClassDescription")]
        [DataMember]
        public string vehicleClassDescription { get; set; }

        [JsonPropertyName("grossVehicleWeight")]
        [DataMember]
        public string grossVehicleWeight { get; set; }

        [JsonPropertyName("unladenWeight")]
        [DataMember]
        public string unladenWeight { get; set; }

        [JsonPropertyName("permanentAddress")]
        [DataMember]
        public string permanentAddress { get; set; }

        [JsonPropertyName("ownerSerialNumber")]
        [DataMember]
        public string ownerSerialNumber { get; set; }

        [JsonPropertyName("statusAsOn")]
        [DataMember]
        public string statusAsOn { get; set; }

        [JsonPropertyName("wheelbase")]
        [DataMember]
        public string wheelbase { get; set; }

        [JsonPropertyName("registrationDate")]
        [DataMember]
        public string registrationDate { get; set; }

        [JsonPropertyName("fatherName")]
        [DataMember]
        public string fatherName { get; set; }

        [JsonPropertyName("financier")]
        [DataMember]
        public string financier { get; set; }

        [JsonPropertyName("registrationNumber")]
        [DataMember]
        public string registrationNumber { get; set; }

        [JsonPropertyName("chassisNumber")]
        [DataMember]
        public string chassisNumber { get; set; }

        [JsonPropertyName("numberOfCylinders")]
        [DataMember]
        public string numberOfCylinders { get; set; }

        [JsonPropertyName("bodyTypeDescription")]
        [DataMember]
        public string bodyTypeDescription { get; set; }

        [JsonPropertyName("makerDescription")]
        [DataMember]
        public string makerDescription { get; set; }

        [JsonPropertyName("sleeperCapacity")]
        [DataMember]
        public string sleeperCapacity { get; set; }

        [JsonPropertyName("fuelDescription")]
        [DataMember]
        public string fuelDescription { get; set; }

        [JsonPropertyName("makerModel")]
        [DataMember]
        public string makerModel { get; set; }

        [JsonPropertyName("cubicCapacity")]
        [DataMember]
        public string cubicCapacity { get; set; }

        [JsonPropertyName("color")]
        [DataMember]
        public string color { get; set; }

        [JsonPropertyName("ownerName")]
        [DataMember]
        public string ownerName { get; set; }

        [JsonPropertyName("normsDescription")]
        [DataMember]
        public string normsDescription { get; set; }

        [JsonPropertyName("standingCapacity")]
        [DataMember]
        public string standingCapacity { get; set; }

        [JsonPropertyName("insuranceUpto")]
        [DataMember]
        public string insuranceUpto { get; set; }

        [JsonPropertyName("engineNumber")]
        [DataMember]
        public string engineNumber { get; set; }

        [JsonPropertyName("presentAddress")]
        [DataMember]
        public string presentAddress { get; set; }

        [JsonPropertyName("insurancePolicyNumber")]
        [DataMember]
        public string insurancePolicyNumber { get; set; }

        [JsonPropertyName("registeredAt")]
        [DataMember]
        public string registeredAt { get; set; }

        [JsonPropertyName("fitnessUpto")]
        [DataMember]
        public string fitnessUpto { get; set; }

        [JsonPropertyName("manufacturedMonthYear")]
        [DataMember]
        public string manufacturedMonthYear { get; set; }

        [JsonPropertyName("insuranceCompany")]
        [DataMember]
        public string insuranceCompany { get; set; }

        [JsonPropertyName("pucNumber")]
        [DataMember]
        public string pucNumber { get; set; }

        [JsonPropertyName("pucExpiryDate")]
        [DataMember]
        public string pucExpiryDate { get; set; }

        [JsonPropertyName("blackListStatus")]
        [DataMember]
        public string blackListStatus { get; set; }

        [JsonPropertyName("nationalPermitIssuedBy")]
        [DataMember]
        public string nationalPermitIssuedBy { get; set; }

        [JsonPropertyName("nationalPermitNumber")]
        [DataMember]
        public string nationalPermitNumber { get; set; }

        [JsonPropertyName("nationalPermitExpiryDate")]
        [DataMember]
        public string nationalPermitExpiryDate { get; set; }

        [JsonPropertyName("statePermitNumber")]
        [DataMember]
        public string statePermitNumber { get; set; }

        [JsonPropertyName("statePermitType")]
        [DataMember]
        public string statePermitType { get; set; }

        [JsonPropertyName("statePermitIssuedDate")]
        [DataMember]
        public string statePermitIssuedDate { get; set; }

        [JsonPropertyName("statePermitExpiryDate")]
        [DataMember]
        public string statePermitExpiryDate { get; set; }

        [JsonPropertyName("nonUseFrom")]
        [DataMember]
        public string nonUseFrom { get; set; }

        [JsonPropertyName("nocDetails")]
        [DataMember]
        public string nocDetails { get; set; }

        [JsonPropertyName("nonUseTo")]
        [DataMember]
        public string nonUseTo { get; set; }

        [JsonPropertyName("stateCd")]
        [DataMember]
        public string stateCd { get; set; }

        [JsonPropertyName("vehicleCatgory")]
        [DataMember]
        public string vehicleCatgory { get; set; }

        [JsonPropertyName("rcStatus")]
        [DataMember]
        public string rcStatus { get; set; }

        [JsonPropertyName("stautsMessage")]
        [DataMember]
        public string stautsMessage { get; set; }

        [JsonPropertyName("rcMobileNo")]
        [DataMember]
        public string rcMobileNo { get; set; }

        [JsonPropertyName("rcNonUseStatus")]
        [DataMember]
        public string rcNonUseStatus { get; set; }

        [JsonPropertyName("blackListInfo")]
        [DataMember]
        public string[] blackListInfo { get; set; }
    }


    public class VehicleValidation_Output
    {
        [JsonPropertyName("VehicleNumber")]
        [DataMember]
        public string VehicleNumber { get; set; }

        [JsonPropertyName("RegistrationDate")]
        [DataMember]
        public DateOnly RegistrationDate { get; set; }

        [JsonPropertyName("OwnerName")]
        [DataMember]
        public string OwnerName { get; set; }

        [JsonPropertyName("FuelType")]
        [DataMember]
        public string FuelType { get; set; }

        [JsonPropertyName("ModelClass")]
        [DataMember]
        public string ModelClass { get; set; }

        [JsonPropertyName("Manufacturer")]
        [DataMember]
        public string Manufacturer { get; set; }

        [JsonPropertyName("InsuranceUpto")]
        [DataMember]
        public DateOnly InsuranceUpto { get; set; }

        [JsonPropertyName("status")]
        [DataMember]
        public string status { get; set; }

        [JsonPropertyName("Message")]
        [DataMember]
        public string Message { get; set; }
    }


    public class Input_LoyalUserDetails : BaseClass
    {
        [JsonPropertyName("MobileNumber")]
        [Required(ErrorMessage = "MobileNumber is Required.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Provide a valid phone number")]
        [DataMember]
        public long MobileNumber { get; set; }
    }


    public class Input_VehicleRegistration : BaseClass
    {
        [JsonPropertyName("FuelType")]
        [Required(ErrorMessage = "FuelType is Required.")]
        [DataMember]
        public string FuelType { get; set; }

        [JsonPropertyName("VehicleNumber")]
        [Required(ErrorMessage = "VehicleNumber is Required.")]
        [DataMember]
        public string VehicleNumber { get; set; }

        [JsonPropertyName("MobileNumber")]
        [Required(ErrorMessage = "MobileNumber is Required.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Provide a valid phone number")]
        [DataMember]
        public long MobileNumber { get; set; }
    }


    public class VehicleRegistrationRequestParams
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("VehicleNo")]
        [DataMember]
        public string VehicleNo { get; set; }

        [JsonPropertyName("FuelType")]
        [DataMember]
        public string FuelType { get; set; }

        [JsonPropertyName("TankCapacity")]
        [DataMember]
        public decimal? TankCapacity { get; set; }

        [JsonPropertyName("TAGType")]
        [DataMember]
        public string TAGType { get; set; }

        [JsonPropertyName("TAGNO")]
        [DataMember]
        public string TAGNO { get; set; }

        [JsonPropertyName("FastlaneID")]
        [DataMember]
        public string FastlaneID { get; set; }
    }


    public class VehicleRegistration_Response : FastlaneIntegrationResponseBase
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public long CustomerID { get; set; }

        [JsonPropertyName("FastlaneID")]
        [DataMember]
        public string FastlaneID { get; set; }

        [JsonPropertyName("FastlaneVehicleID")]
        [DataMember]
        public string FastlaneVehicleID { get; set; }

        [JsonPropertyName("Message")]
        [DataMember]
        public string Message { get; set; }

        [JsonPropertyName("Status")]
        [DataMember]
        public string Status { get; set; }
    }


    public class VehicleTagMappingDetails : FastlaneIntegrationResponseBase
    {
        [JsonPropertyName("Customer_Id")]
        [DataMember]
        public long Customer_Id { get; set; }

        [JsonPropertyName("Vehicle_Number")]
        [DataMember]
        public string Vehicle_Number { get; set; }

        [JsonPropertyName("Tag_Type")]
        [DataMember]
        public string Tag_Type { get; set; }

        [JsonPropertyName("Tag_Number")]
        [DataMember]
        public string Tag_Number { get; set; }

        [JsonPropertyName("Fuel_type")]
        [DataMember]
        public string Fuel_type { get; set; }

        [JsonPropertyName("Fastlane_Vehicle_ID")]
        [DataMember]
        public string Fastlane_Vehicle_ID { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public long? CreatedBy { get; set; }

        [JsonPropertyName("Createddate")]
        [DataMember]
        public DateTime Createddate { get; set; }

        [JsonPropertyName("ModifedBy")]
        [DataMember]
        public long? ModifedBy { get; set; }

        [JsonPropertyName("Modifieddate")]
        [DataMember]
        public DateTime? Modifieddate { get; set; }

        [JsonPropertyName("Status_Flag")]
        [DataMember]
        public int Status_Flag { get; set; } = 1;
    }


    public class Input_VehicleTagMapping : BaseClass
    {
        [Required(ErrorMessage = "TagType is Required.")]
        [JsonPropertyName("TagType")]
        [DataMember]
        public string TagType { get; set; }

        [Required(ErrorMessage = "TagNumber is Required.")]
        [JsonPropertyName("TagNumber")]
        [DataMember]
        public string TagNumber { get; set; }

        [Required(ErrorMessage = "VehicleNumber is Required.")]
        [JsonPropertyName("VehicleNumber")]
        [DataMember]
        public string VehicleNumber { get; set; }
    }


    public class VehicleTagMapping_Output : FastlaneIntegrationResponseBase
    {
        [JsonPropertyName("FastlaneVehicleID")]
        [DataMember]
        public string FastlaneVehicleID { get; set; }

        [JsonPropertyName("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonPropertyName("Message")]
        [DataMember]
        public string Message { get; set; }
    }

    public class Input_VehiclePresetDetails : BaseClass
    {
        [Required(ErrorMessage = "Amount is Required.")]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [JsonPropertyName("PresetType")]
        [DataMember]
        public string PresetType { get; set; } = "Amount";


        [Required(ErrorMessage = "VehicleNumber is Required.")]
        [JsonPropertyName("VehicleNumber")]
        [DataMember]
        public string VehicleNumber { get; set; }
    }


    public class VehiclePresetDetails_Output : FastlaneIntegrationResponseBase
    {
        [JsonPropertyName("RequestID")]
        [DataMember]
        public string RequestID { get; set; }

        [JsonPropertyName("CustomerID")]
        [DataMember]
        public long CustomerID { get; set; }

        [JsonPropertyName("FastlaneReferenceID")]
        [DataMember]
        public string FastlaneReferenceID { get; set; }

        [JsonPropertyName("Status")]
        [DataMember]
        public int Status { get; set; }

        [JsonPropertyName("Message")]
        [DataMember]
        public string Message { get; set; }
    }


    public class VehiclePresetUpdateRequestDetails
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public long? CustomerID { get; set; }

        [JsonPropertyName("RequestID")]
        [DataMember]
        public string RequestID { get; set; }

        [JsonPropertyName("FastlaneVehicleID")]
        [DataMember]
        public string FastlaneVehicleID { get; set; }

        [JsonPropertyName("FastlaneReferenceID")]
        [DataMember]
        public string FastlaneReferenceID { get; set; }

        [JsonPropertyName("VehicleNumber")]
        [DataMember]
        public string VehicleNumber { get; set; }

        [JsonPropertyName("Status")]
        [DataMember]
        public long Status { get; set; }

        [JsonPropertyName("ConsumptionStatus")]
        [DataMember]
        public long ConsumptionStatus { get; set; }
    }


    public class VehiclePresetRegistration_Output : FastlaneIntegrationResponseBase
    {
        [JsonPropertyName("RequestID")]
        [DataMember]
        public long RequestID { get; set; }

        [JsonPropertyName("FastlaneReferenceID")]
        [DataMember]
        public string FastlaneReferenceID { get; set; }

        [JsonPropertyName("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonPropertyName("Message")]
        [DataMember]
        public string Message { get; set; }
    }


    public class Input_PresetVehicleList : FastlaneIntegrationRequestBase
    {
        //[Required(ErrorMessage = "MobileNumber is Required.")]
        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Provide a valid phone number")]

        [JsonPropertyName("MobileNumber")]
        [DataMember]
        public long MobileNumber { get; set; }
    }


    public class PresetVehicleList_Output : FastlaneIntegrationResponseBase
    {
        [JsonPropertyName("MappingId")]
        [DataMember]
        public string MappingId { get; set; }

        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("CustomerCode")]
        [DataMember]
        public string CustomerCode { get; set; }

        [JsonPropertyName("FastlaneID")]
        [DataMember]
        public string FastlaneID { get; set; }

        [JsonPropertyName("VehicleNumber")]
        [DataMember]
        public string VehicleNumber { get; set; }

        [JsonPropertyName("TagType")]
        [DataMember]
        public string TagType { get; set; }

        [JsonPropertyName("TagNumber")]
        [DataMember]
        public string TagNumber { get; set; }

        [JsonPropertyName("Fueltype")]
        [DataMember]
        public string Fueltype { get; set; }

        [JsonPropertyName("FastlaneVehicleID")]
        [DataMember]
        public string FastlaneVehicleID { get; set; }

        [JsonPropertyName("PresetAmount")]
        [DataMember]
        public string PresetAmount { get; set; }

        [JsonPropertyName("RequestId")]
        [DataMember]
        public string RequestId { get; set; }

        [JsonPropertyName("Createddate")]
        [DataMember]
        public DateTime? Createddate { get; set; }
    }


    public class Input_VehiclePresetCancel : BaseClass
    {
        [Required(ErrorMessage = "VehicleNumber is Required.")]
        [JsonPropertyName("Message")]
        [DataMember]
        public string VehicleNumber { get; set; }
    }


    public class VehiclePresetCancelDetails : FastlaneIntegrationResponseBase
    {
        [JsonPropertyName("FastlaneVehicleID")]
        [DataMember]
        public string FastlaneVehicleID { get; set; }

        [JsonPropertyName("FastlaneCustomerID")]
        [DataMember]
        public string FastlaneCustomerID { get; set; }

        [JsonPropertyName("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonPropertyName("Message")]
        [DataMember]
        public string Message { get; set; }
    }


    public class VehiclePresetCancelDetails_Output : FastlaneIntegrationResponseBase
    {
        [JsonPropertyName("RequestID")]
        [DataMember]
        public long? RequestID { get; set; }

        [JsonPropertyName("FastlaneReferenceID")]
        [DataMember]
        public string FastlaneReferenceID { get; set; }

        [JsonPropertyName("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonPropertyName("Message")]
        [DataMember]
        public string Message { get; set; }
    }


    public class Input_VehicleList : BaseClass
    {
        [Required(ErrorMessage = "Flag is Required.")]
        [JsonPropertyName("Flag")]
        [DataMember]
        public string Flag { get; set; }


        [Required(ErrorMessage = "PresetFlag is Required.")]
        [JsonPropertyName("PresetFlag")]
        [DataMember]
        public string PresetFlag { get; set; }


        [Required(ErrorMessage = "MobileNumber is Required.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Provide a valid phone number")]
        [JsonPropertyName("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }
    }


    public class VehicleList_Output : FastlaneIntegrationResponseBase
    {
        [JsonPropertyName("MappingId")]
        [DataMember]
        public string MappingId { get; set; }

        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("CustomerCode")]
        [DataMember]
        public string CustomerCode { get; set; }

        [JsonPropertyName("FastlaneID")]
        [DataMember]
        public string FastlaneID { get; set; }

        [JsonPropertyName("VehicleNumber")]
        [DataMember]
        public string VehicleNumber { get; set; }

        [JsonPropertyName("TagType")]
        [DataMember]
        public string TagType { get; set; }

        [JsonPropertyName("TagNumber")]
        [DataMember]
        public string TagNumber { get; set; }

        [JsonPropertyName("Fueltype")]
        [DataMember]
        public string Fueltype { get; set; }

        [JsonPropertyName("FastlaneVehicleID")]
        [DataMember]
        public string FastlaneVehicleID { get; set; }

        [JsonPropertyName("PresetAmount")]
        [DataMember]
        public string PresetAmount { get; set; }
    }


    public class Input_FastlaneLastPresetAmount : BaseClass
    {
        [Required(ErrorMessage = "VehicleNumber is Required.")]
        [JsonPropertyName("VehicleNumber")]
        [DataMember]
        public string VehicleNumber { get; set; }
    }


    public class FastlaneLastPresetAmount_Output : FastlaneIntegrationResponseBase
    {
        [JsonPropertyName("VehicleNumber")]
        [DataMember]
        public string VehicleNumber { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }
    }

    public class Input_ProcessSaleCompletion
    {
        [JsonPropertyName("PartnerCode")]
        [DataMember]
        public string PartnerCode { get; set; }

        [JsonPropertyName("MobileNumber")]
        [DataMember]
        public long MobileNumber { get; set; }

        [JsonPropertyName("PartnerCustomerID")]
        [DataMember]
        public string PartnerCustomerID { get; set; }

        [JsonPropertyName("TransactionAmount")]
        [DataMember]
        public decimal TransactionAmount { get; set; }

        [JsonPropertyName("TransactionDate")]
        [DataMember]
        public DateTime TransactionDate { get; set; }

        [JsonPropertyName("TransactionNumber")]
        [DataMember]
        public long TransactionNumber { get; set; }

        [JsonPropertyName("MerchantId")]
        [DataMember]
        public long MerchantId { get; set; }

        [JsonPropertyName("FastlaneVehicleId")]
        [DataMember]
        public string FastlaneVehicleId { get; set; }

        [JsonPropertyName("FuelTypeName")]
        [DataMember]
        public string FuelTypeName { get; set; }
    }


    public class ProcessSaleCompletion_Output : FastlaneIntegrationResponseBase
    {
        [JsonPropertyName("MobileNumber")]
        [DataMember]
        public long? MobileNumber { get; set; }

        [JsonPropertyName("PartnerCustomerID")]
        [DataMember]
        public string PartnerCustomerID { get; set; }

        [JsonPropertyName("TransactionAmount")]
        [DataMember]
        public decimal? TransactionAmount { get; set; }

        [JsonPropertyName("TransactionDate")]
        [DataMember]
        public DateTime? TransactionDate { get; set; }

        [JsonPropertyName("TransactionNumber")]
        [DataMember]
        public string TransactionNumber { get; set; }

        [JsonPropertyName("MerchantId")]
        [DataMember]
        public long? MerchantId { get; set; }

        [JsonPropertyName("FastlaneVehicleId")]
        [DataMember]
        public string FastlaneVehicleId { get; set; }

        [JsonPropertyName("FuelTypeName")]
        [DataMember]
        public string FuelTypeName { get; set; }

        [JsonPropertyName("HPPAYRefNumber")]
        [DataMember]
        public string HPPAYRefNumber { get; set; }
    }


    public class Input_InitiateRefund
    {
        [JsonPropertyName("PartnerCode")]
        [DataMember]
        public string PartnerCode { get; set; }

        [JsonPropertyName("TransactionAmount")]
        [DataMember]
        public decimal TransactionAmount { get; set; }

        [JsonPropertyName("TransactionNumber")]
        [DataMember]
        public string TransactionNumber { get; set; }
    }


    public class InitiateRefund_Output : FastlaneIntegrationResponseBase
    {
        [JsonPropertyName("TransactionNumber")]
        [DataMember]
        public string TransactionNumber { get; set; }

        [JsonPropertyName("HPPAYRefNumber")]
        [DataMember]
        public string HPPAYRefNumber { get; set; }
    }


    public class Input_CheckStatus
    {
        [JsonPropertyName("PartnerCode")]
        [DataMember]
        public string PartnerCode { get; set; }

        [JsonPropertyName("TransactionNumber")]
        [DataMember]
        public string TransactionNumber { get; set; }
    }


    public class CheckStatus_Output : FastlaneIntegrationResponseBase
    {
        [JsonPropertyName("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }

        [JsonPropertyName("PartnerCustomerID")]
        [DataMember]
        public string PartnerCustomerID { get; set; }

        [JsonPropertyName("TransactionAmount")]
        [DataMember]
        public decimal? TransactionAmount { get; set; }

        [JsonPropertyName("TransactionNumber")]
        [DataMember]
        public string TransactionNumber { get; set; }

        [JsonPropertyName("TransactionDate")]
        [DataMember]
        public DateTime? TransactionDate { get; set; }

        [JsonPropertyName("TransactionStatus")]
        [DataMember]
        public string TransactionStatus { get; set; }

        [JsonPropertyName("HPPAYRefNumber")]
        [DataMember]
        public string HPPAYRefNumber { get; set; }
    }
}
