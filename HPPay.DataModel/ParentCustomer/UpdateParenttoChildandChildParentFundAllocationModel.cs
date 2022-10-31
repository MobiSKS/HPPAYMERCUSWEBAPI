using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.ParentCustomer
{
    public class UpdateParenttoChildandChildParentFundAllocationModelInput : BaseClass
    {
        [JsonPropertyName("ParentCustomerId")]
        [DataMember]
        public string ParentCustomerId { get; set; }

        [JsonPropertyName("TypeUpdateParenttoChildandChildParentFund")]
        [DataMember]
        public List<TypeUpdateParenttoChildandChildParentFundModelInput> TypeUpdateParenttoChildandChildParentFund { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
        
    }

    public class TypeUpdateParenttoChildandChildParentFundModelInput
    {

        [JsonPropertyName("ChildCustomerId")]
        [DataMember]
        public string ChildCustomerId { get; set; }


        [JsonPropertyName("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }


        [JsonPropertyName("CCMSBalance")]
        [DataMember]
        public decimal CCMSBalance { get; set; }

        [JsonPropertyName("Drivestars")]
        [DataMember]
        public decimal Drivestars { get; set; }
         
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [JsonPropertyName("BalanceTransferType")]
        [DataMember]
        public string BalanceTransferType { get; set; }
    }

    public class UpdateParenttoChildandChildParentFundAllocationModeloutput : BaseClassOutput
    {
        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
         
        [JsonProperty("OldBalance")]
        [DataMember]
        public decimal OldBalance { get; set; }         

        [JsonProperty("TranseferredAmount")]
        [DataMember]
        public decimal TranseferredAmount { get; set; }

        [JsonProperty("NewBalance")]
        [DataMember]
        public decimal NewBalance { get; set; }

        [JsonProperty("TransactionType")]
        [DataMember]
        public string TransactionType { get; set; }

    }

    public class ParentToAggregatorCustomerUpdateModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerReferenceNo")]
        [DataMember]
        public Int64 CustomerReferenceNo { get; set; }

        [Required]
        [JsonPropertyName("ParentCustomerId")]
        [DataMember]
        public string ParentCustomerId { get; set; }

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
        public DateTime DateOfApplication { get; set; }

        [Required]
        [JsonPropertyName("SalesArea")]
        [DataMember]
        public Int32 SalesArea { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }
        
        
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

        [Required]
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
        [RegularExpression("\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", ErrorMessage = "Invalid Email Id")]
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
        [RegularExpression("\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", ErrorMessage = "Invalid Email Id")]
        public string KeyOfficialEmail { get; set; }


        [JsonPropertyName("KeyOfficialPhoneNo")]
        [DataMember]
        public string KeyOfficialPhoneNo { get; set; }


        [JsonPropertyName("KeyOfficialDOA")]
        [DataMember]
        public DateTime KeyOfficialDOA { get; set; }


        [Required]
        [JsonPropertyName("KeyOfficialMobile")]
        [StringLength(10, MinimumLength = 10)]
        [DataMember]
        public string KeyOfficialMobile { get; set; }

        [JsonPropertyName("KeyOfficialDOB")]
        [DataMember]
        public DateTime KeyOfficialDOB { get; set; }


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


        [JsonPropertyName("PanCardRemarks")]
        [DataMember]
        public string PanCardRemarks { get; set; }

        [JsonPropertyName("TierOfCustomer")]
        [DataMember]
        public int TierOfCustomer { get; set; }

        [JsonPropertyName("TypeOfCustomer")]
        [DataMember]
        public int TypeOfCustomer { get; set; }

    }

    public class ParentToAggregatorCustomerUpdateModelOutput : BaseClassOutput
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

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class GetTransactionTypeInput 
    {
        [JsonPropertyName("CustomerType")]
        [DataMember]
        public int CustomerType { get; set; }

        [JsonPropertyName("CustomerSubType")]
        [DataMember]
        public int CustomerSubType { get; set; }
    }
    public class GetTransactionTypeOutPut
    {
        [JsonProperty("TransactionID")]
        [DataMember]
        public int TransactionID { get; set; }

        [JsonProperty("TransactionType")]
        [DataMember]
        public string TransactionType { get; set; }
    }
}
