using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerRelationship
{
    public class GetRelationshipManagementCallModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }

    public class GetRelationshipManagementCallModelOutput : BaseClassOutput
    {
        [JsonProperty("CustomerDetails")]
        [DataMember]
        public List<GetcustomerDetails> CustomerDetails { get; set; }

        [JsonProperty("CustomerRelationDetails")]
        [DataMember]
        public List<GetCustomerRelationDetails> CustomerRelationDetails { get; set; }

        [JsonProperty("Hsddetails")]
        [DataMember]
        public List<GetHsddetails> Hsddetails { get; set; }

        [JsonProperty("DrivestarDetails")]
        [DataMember]
        public List<GetDrivestarDetails> DrivestarDetails { get; set; }

        [JsonProperty("KeyCustomerDetails")]
        [DataMember]
        public List<GetKeyCustomerDetails> KeyCustomerDetails { get; set; }

        [JsonProperty("CustomerRouteDetails")]
        [DataMember]
        public List<GetCustomerRouteDetails> CustomerRouteDetails { get; set; }


        [JsonProperty("CustomerPaymentDetails")]
        [DataMember]
        public List<GetCustomerPaymentDetails> CustomerPaymentDetails { get; set; }

        [JsonProperty("CustomerMappingLocation")]
        [DataMember]
        public List<GetCustomerMappingLocation> CustomerMappingLocation { get; set; }


        [JsonProperty("CustomerFeedbackDetails")]
        [DataMember]
        public List<GetCustomerFeedbackDetails> CustomerFeedbackDetails { get; set; }
    }

    public class GetcustomerDetails
    {
 
        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("PreviousDate")]
        [DataMember]
        public string PreviousDate { get; set; }
    }

    public class GetCustomerRelationDetails
    {

        [JsonProperty("ZonalOffice")]
        [DataMember]
        public string ZonalOffice { get; set; }

        [JsonProperty("RegionalOffice")]
        [DataMember]
        public string RegionalOffice { get; set; }

        [JsonProperty("SalesArea")]
        [DataMember]
        public string SalesArea { get; set; }

        [JsonProperty("CommunicationAddress1")]
        [DataMember]
        public string CommunicationAddress1 { get; set; }

        [JsonProperty("CommunicationAddress2")]
        [DataMember]
        public string CommunicationAddress2 { get; set; }

        [JsonProperty("CommunicationAddress3")]
        [DataMember]
        public string CommunicationAddress3 { get; set; }

        [JsonProperty("CommunicationLocation")]
        [DataMember]
        public string CommunicationLocation { get; set; }

        [JsonProperty("CommunicationCityName")]
        [DataMember]
        public string CommunicationCityName { get; set; }

        [JsonProperty("CommunicationPincode")]
        [DataMember]
        public string CommunicationPincode { get; set; }

        [JsonProperty("CommunicationStateId")]
        [DataMember]
        public string CommunicationStateId { get; set; }


        [JsonProperty("CommunicationDistrictId")]
        [DataMember]
        public string CommunicationDistrictId { get; set; }

        [JsonProperty("CommunicationPhoneNo")]
        [DataMember]
        public string CommunicationPhoneNo { get; set; }

        [JsonProperty("CommunicationMobileNo")]
        [DataMember]
        public string CommunicationMobileNo { get; set; }

        [JsonProperty("CommunicationFax")]
        [DataMember]
        public string CommunicationFax { get; set; }

        [JsonProperty("CommunicationEmailid")]
        [DataMember]
        public string CommunicationEmailid { get; set; }

        [JsonProperty("TierOfCustomer")]
        [DataMember]
        public string TierOfCustomer { get; set; }

    }

    public class GetHsddetails
    {
        [JsonProperty("HSD")]
        [DataMember]
        public string HSD { get; set; }

        [JsonProperty("MS")]
        [DataMember]
        public string MS { get; set; }

        [JsonProperty("Lube")]
        [DataMember]
        public string Lube { get; set; }

    }

   public class GetDrivestarDetails
    {
        [JsonProperty("TotalDrivestar")]
        [DataMember]
        public string TotalDrivestar { get; set; }

        [JsonProperty("LastRedeemedDate")]
        [DataMember]
        public string LastRedeemedDate { get; set; }

        [JsonProperty("NumberOfOutlet")]
        [DataMember]
        public string NumberOfOutlet { get; set; }
    }

    public class GetKeyCustomerDetails
    {
        [JsonProperty("KeyOfficialFirstName")]
        [DataMember]
        public string KeyOfficialFirstName { get; set; }

        [JsonProperty("KeyOfficialMiddleName")]
        [DataMember]
        public string KeyOfficialMiddleName { get; set; }

        [JsonProperty("KeyOfficialLastName")]
        [DataMember]
        public string KeyOfficialLastName { get; set; }

        [JsonProperty("Designation")]
        [DataMember]
        public string Designation { get; set; }

        [JsonProperty("ContactNumber")]
        [DataMember]
        public string ContactNumber { get; set; }

        [JsonProperty("Mobile")]
        [DataMember]
        public string Mobile { get; set; }

        [JsonProperty("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonProperty("TypeOfBusinessEntity")]
        [DataMember]
        public string TypeOfBusinessEntity { get; set; }

        [JsonProperty("PAN")]
        [DataMember]
        public string PAN { get; set; }

        [JsonProperty("Fleetsize")]
        [DataMember]
        public string Fleetsize { get; set; }

    }

    public class GetCustomerRouteDetails
    {
        [JsonProperty("Routes")]
        [DataMember]
        public string Routes { get; set; }

        [JsonProperty("RouteFrom")]
        [DataMember]
        public string RouteFrom { get; set; }

        [JsonProperty("RouteTo")]
        [DataMember]
        public string RouteTo { get; set; }

        [JsonProperty("NHNO")]
        [DataMember]
        public string NHNO { get; set; }
    }

    public class GetCustomerPaymentDetails
    {
        [JsonProperty("PaymenttermsType")]
        [DataMember]
        public string PaymenttermsType { get; set; }

        [JsonProperty("Paymenttermsmode")]
        [DataMember]
        public string Paymenttermsmode { get; set; }

        [JsonProperty("NoOfDays")]
        [DataMember]
        public string NoOfDays { get; set; }

        [JsonProperty("CreditVolume")]
        [DataMember]
        public string CreditVolume { get; set; }
    }


    public class GetCustomerMappingLocation
    {
        [JsonProperty("Location")]
        [DataMember]
        public string Location { get; set; }

        [JsonProperty("CurrentSupplier")]
        [DataMember]
        public string CurrentSupplier { get; set; }

        [JsonProperty("LHSANDRHS")]
        [DataMember]
        public string LHSANDRHS { get; set; }

        [JsonProperty("Zone")]
        [DataMember]
        public string Zone { get; set; }

        [JsonProperty("Region")]
        [DataMember]
        public string Region { get; set; }

        [JsonProperty("CreditExpected")]
        [DataMember]
        public string CreditExpected { get; set; }

        [JsonProperty("DiscountExpected")]
        [DataMember]
        public string DiscountExpected { get; set; }

        [JsonProperty("NoOfDays")]
        [DataMember]
        public string NoOfDays { get; set; }
    }
    public class GetCustomerFeedbackDetails
    {
        [JsonProperty("Date")]
        [DataMember]
        public string Date { get; set; }

        [JsonProperty("SystemImprovement")]
        [DataMember]
        public string SystemImprovement { get; set; }

        [JsonProperty("DealerService")]
        [DataMember]
        public string DealerService { get; set; }

        [JsonProperty("ActivationPlan")]
        [DataMember]
        public string ActivationPlan { get; set; }
    }

}
