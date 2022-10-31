using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class CustomerInsertModelInput : BaseClass
    {
        //[JsonPropertyName("CustomerID")]
        //[DataMember]
        //public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("CustomerType")]
        [DataMember]
        public Int32 CustomerType { get; set; }


        [Required]
        [JsonPropertyName("CustomerSubtype")]
        [DataMember]
        public Int32 CustomerSubtype { get; set; }

        [Required]

        [JsonPropertyName("ZonalOffice")]
        [DataMember]
        public Int32 ZonalOffice { get; set; }


        [Required]
        [JsonPropertyName("RegionalOffice")]
        [DataMember]
        public Int32 RegionalOffice { get; set; }


        [Required]
        [JsonPropertyName("DateOfApplication")]
        [DataMember]
        public DateTime? DateOfApplication { get; set; }

        [Required]
        [JsonPropertyName("SalesArea")]
        [DataMember]
        public Int32 SalesArea { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }


        [Required]
        [JsonPropertyName("IndividualOrgNameTitle")]
        [DataMember]
        public string IndividualOrgNameTitle { get; set; }


        [Required]
        [JsonPropertyName("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }


        [Required]
        [JsonPropertyName("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }


        [Required]
        [JsonPropertyName("TypeOfBusinessEntity")]
        [DataMember]
        public Int32 TypeOfBusinessEntity { get; set; }


        [Required]
        [JsonPropertyName("ResidenceStatus")]
        [DataMember]
        public string ResidenceStatus { get; set; }


        [Required]
        [JsonPropertyName("IncomeTaxPan")]
        [DataMember]
        //[RegularExpression("^[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}$", ErrorMessage = "Invalid Pancard Number")]
        public string IncomeTaxPan { get; set; }


        [Required]
        [JsonPropertyName("CommunicationAddress1")]
        [DataMember]
        public string CommunicationAddress1 { get; set; }

        [Required]
        [JsonPropertyName("CommunicationAddress2")]
        [DataMember]
        public string CommunicationAddress2 { get; set; }


        [JsonPropertyName("CommunicationAddress3")]
        [DataMember]
        public string CommunicationAddress3 { get; set; }

        [JsonPropertyName("CommunicationLocation")]
        [DataMember]
        public string CommunicationLocation { get; set; }

        [Required]
        [JsonPropertyName("CommunicationCityName")]
        [DataMember]
        public string CommunicationCityName { get; set; }

        [Required]
        [JsonPropertyName("CommunicationPincode")]
        [DataMember]
        public string CommunicationPincode { get; set; }

        [Required]
        [JsonPropertyName("CommunicationStateId")]
        [DataMember]
        public Int32 CommunicationStateId { get; set; }


        [Required]
        [JsonPropertyName("CommunicationDistrictId")]
        [DataMember]
        public Int32 CommunicationDistrictId { get; set; }

        //[Required]
        [JsonPropertyName("CommunicationPhoneNo")]
        [DataMember]
        public string CommunicationPhoneNo { get; set; }


        [JsonPropertyName("CommunicationFax")]
        [DataMember]
        public string CommunicationFax { get; set; }


        [Required]
        [JsonPropertyName("CommunicationMobileNo")]
        [StringLength(10, MinimumLength = 10)]
        [DataMember]
        public string CommunicationMobileNo { get; set; }


        [JsonPropertyName("CommunicationEmailid")]
        [DataMember]
        //[RegularExpression("\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", ErrorMessage = "Invalid Email Id")]
        public string CommunicationEmailid { get; set; }


        [Required]
        [JsonPropertyName("PermanentAddress1")]
        [DataMember]
        public string PermanentAddress1 { get; set; }

        [Required]
        [JsonPropertyName("PermanentAddress2")]
        [DataMember]
        public string PermanentAddress2 { get; set; }


        [JsonPropertyName("PermanentAddress3")]
        [DataMember]
        public string PermanentAddress3 { get; set; }


        [JsonPropertyName("PermanentLocation")]
        [DataMember]
        public string PermanentLocation { get; set; }


        [Required]
        [JsonPropertyName("PermanentCityName")]
        [DataMember]
        public string PermanentCityName { get; set; }


        [Required]
        [JsonPropertyName("PermanentPincode")]
        [DataMember]
        public string PermanentPincode { get; set; }

        [Required]
        [JsonPropertyName("PermanentStateId")]
        [DataMember]
        public Int32 PermanentStateId { get; set; }


        [Required]
        [JsonPropertyName("PermanentDistrictId")]
        [DataMember]
        public Int32 PermanentDistrictId { get; set; }


        [JsonPropertyName("PermanentPhoneNo")]
        [DataMember]
        public string PermanentPhoneNo { get; set; }


        [JsonPropertyName("PermanentFax")]
        [DataMember]
        public string PermanentFax { get; set; }


        [Required]
        [JsonPropertyName("KeyOfficialTitle")]
        [DataMember]
        public string KeyOfficialTitle { get; set; }


        [JsonPropertyName("KeyOfficialIndividualInitials")]
        [DataMember]
        public string KeyOfficialIndividualInitials { get; set; }


        [Required]
        [JsonPropertyName("KeyOfficialFirstName")]
        [DataMember]
        public string KeyOfficialFirstName { get; set; }

        [JsonPropertyName("KeyOfficialMiddleName")]
        [DataMember]
        public string KeyOfficialMiddleName { get; set; }


        [JsonPropertyName("KeyOfficialLastName")]
        [DataMember]
        public string KeyOfficialLastName { get; set; }


        [JsonPropertyName("KeyOfficialFax")]
        [DataMember]
        public string KeyOfficialFax { get; set; }


        [Required]
        [JsonPropertyName("KeyOfficialDesignation")]
        [DataMember]
        public string KeyOfficialDesignation { get; set; }


        [JsonPropertyName("KeyOfficialEmail")]
        [DataMember]
        //[RegularExpression("\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", ErrorMessage = "Invalid Email Id")]
        public string KeyOfficialEmail { get; set; }


        [JsonPropertyName("KeyOfficialPhoneNo")]
        [DataMember]
        public string KeyOfficialPhoneNo { get; set; }


        [JsonPropertyName("KeyOfficialDOA")]
        [DataMember]
        public DateTime? KeyOfficialDOA { get; set; }


        [Required]
        [JsonPropertyName("KeyOfficialMobile")]
        [StringLength(10, MinimumLength = 10)]
        [DataMember]
        public string KeyOfficialMobile { get; set; }

        [JsonPropertyName("KeyOfficialDOB")]
        [DataMember]
        public DateTime? KeyOfficialDOB { get; set; }


        [JsonPropertyName("KeyOfficialSecretQuestion")]
        [DataMember]
        public int KeyOfficialSecretQuestion { get; set; }


        [JsonPropertyName("KeyOfficialSecretAnswer")]
        [DataMember]
        public string KeyOfficialSecretAnswer { get; set; }


        [JsonPropertyName("KeyOfficialTypeOfFleet")]
        [DataMember]
        public int KeyOfficialTypeOfFleet { get; set; }

        [JsonPropertyName("KeyOfficialCardAppliedFor")]
        [DataMember]
        public string KeyOfficialCardAppliedFor { get; set; }



        [JsonPropertyName("KeyOfficialApproxMonthlySpendsonVechile1")]
        [DataMember]
        public decimal KeyOfficialApproxMonthlySpendsonVechile1 { get; set; }



        [JsonPropertyName("KeyOfficialApproxMonthlySpendsonVechile2")]
        [DataMember]
        public decimal KeyOfficialApproxMonthlySpendsonVechile2 { get; set; }


        [JsonPropertyName("AreaOfOperation")]
        [DataMember]
        public string AreaOfOperation { get; set; }


        [JsonPropertyName("FleetSizeNoOfVechileOwnedHCV")]
        [DataMember]
        public Int16 FleetSizeNoOfVechileOwnedHCV { get; set; }



        [JsonPropertyName("FleetSizeNoOfVechileOwnedLCV")]
        [DataMember]
        public Int16 FleetSizeNoOfVechileOwnedLCV { get; set; }


        [JsonPropertyName("FleetSizeNoOfVechileOwnedMUVSUV")]
        [DataMember]
        public Int16 FleetSizeNoOfVechileOwnedMUVSUV { get; set; }


        [JsonPropertyName("FleetSizeNoOfVechileOwnedCarJeep")]
        [DataMember]
        public Int16 FleetSizeNoOfVechileOwnedCarJeep { get; set; }


        //[JsonPropertyName("NoOfCards")]
        //[DataMember]
        //public Int32 NoOfCards { get; set; }


        //[JsonPropertyName("FeePaymentsCollectFeeWaiver")]
        //[DataMember]
        //public Int16 FeePaymentsCollectFeeWaiver { get; set; }


        //[JsonPropertyName("FeePaymentsChequeNo")]
        //[DataMember]
        //public string FeePaymentsChequeNo { get; set; }


        //[JsonPropertyName("FeePaymentsChequeDate")]
        //[DataMember]
        //public DateTime FeePaymentsChequeDate { get; set; }

        //[JsonPropertyName("ObjCardDetail")]
        //[DataMember]
        //public List<CardDetail> ObjCardDetail { get; set; }


        [JsonPropertyName("TierOfCustomer")]
        [DataMember]
        public Int32 TierOfCustomer { get; set; }


        [JsonPropertyName("TypeOfCustomer")]
        [DataMember]
        public Int32 TypeOfCustomer { get; set; }

        [JsonPropertyName("RBEId")]
        [DataMember]
        public string RBEId { get; set; }

        [JsonPropertyName("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [JsonPropertyName("PanCardRemarks")]
        [DataMember]
        public string PanCardRemarks { get; set; }
    }

    //public class CardDetail
    //{
    //    [JsonPropertyName("CardIdentifier")]
    //    public string CardIdentifier { get; set; }

    //    [JsonPropertyName("VechileNo")]
    //    public string VechileNo { get; set; }

    //    [JsonPropertyName("VehicleType")]
    //    public int VehicleType { get; set; }

    //    [JsonPropertyName("VehicleMake")]
    //    public string VehicleMake { get; set; }

    //    [JsonPropertyName("YearOfRegistration")]
    //    public int YearOfRegistration { get; set; }

    //}

    public class CustomerInsertModelOutput : BaseClassOutput
    {

        [JsonProperty("ReferenceId")]
        [DataMember]
        public string ReferenceId { get; set; }

        [JsonProperty("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [JsonProperty("CustomerReferenceNo")]
        [DataMember]
        public Int64 CustomerReferenceNo { get; set; }

        //[JsonProperty("CustomerID")]
        //[DataMember]
        //public string CustomerID { get; set; }
    }

}
