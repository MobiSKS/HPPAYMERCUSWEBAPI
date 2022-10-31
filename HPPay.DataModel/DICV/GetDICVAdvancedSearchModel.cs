using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DICV
{
    public class GetDICVAdvancedSearchModelInput:BaseClass
    {
        
        [JsonPropertyName("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        
        [JsonPropertyName("IsCustomerNameExist")]
        [DataMember]
        public bool IsCustomerNameExist { get; set; }

        
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

        
        [JsonPropertyName("IsFormNumberExist")]
        [DataMember]
        public bool IsFormNumberExist { get; set; }

        
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }

        
        [JsonPropertyName("IsCustomeridExist")]
        [DataMember]
        public bool IsCustomeridExist { get; set; }

        
        [JsonPropertyName("CustomerType")]
        [DataMember]
        public int CustomerType { get; set; }

        
        [JsonPropertyName("IsCustomerTypeExist")]
        [DataMember]
        public bool IsCustomerTypeExist { get; set; }

        
        [JsonPropertyName("RegionalOfficeID")]
        [DataMember]
        public int RegionalOfficeID { get; set; }

        
        [JsonPropertyName("IsRegionalOfficeExist")]
        [DataMember]
        public bool IsRegionalOfficeExist { get; set; }

        
        [JsonPropertyName("ZonalOfficeId")]
        [DataMember]
        public int ZonalOfficeId { get; set; }

        
        [JsonPropertyName("IsZonalOfficeExist")]
        [DataMember]
        public bool IsZonalOfficeExist { get; set; }

        
        [JsonPropertyName("Pincode")]
        [DataMember]
        public string Pincode { get; set; }

        [JsonPropertyName("IsPincodeExist")]
        [DataMember]
        public bool IsPincodeExist { get; set; }


        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonPropertyName("IsMobileExist")]
        [DataMember]
        public bool IsMobileExist { get; set; }
    }
    public class GetDICVAdvancedSearchModelOutput:BaseClassOutput
    {
        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
        [JsonProperty("CustomerTypeName")]
        [DataMember]
        public string CustomerTypeName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }
        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }
        [JsonProperty("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }
        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }
        [JsonProperty("ResidenceType")]
        [DataMember]
        public string ResidenceType { get; set; }
        [JsonProperty("Constitution")]
        [DataMember]
        public string Constitution { get; set; }
        [JsonProperty("ITPermanentAccount")]
        [DataMember]
        public string ITPermanentAccount { get; set; }
        [JsonProperty("BankName")]
        [DataMember]
        public string BankName { get; set; }
        [JsonProperty("BankBranchName")]
        [DataMember]
        public string BankBranchName { get; set; }
        [JsonProperty("BankAccountNumber")]
        [DataMember]
        public string BankAccountNumber { get; set; }
        [JsonProperty("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }
        [JsonProperty("CommunicationCityName")]
        [DataMember]
        public string CommunicationCityName { get; set; }
        [JsonProperty("StateName")]
        [DataMember]
        public string StateName { get; set; }
        [JsonProperty("CommunicationPhoneNo")]
        [DataMember]
        public string CommunicationPhoneNo { get; set; }
        [JsonProperty("CommunicationPincode")]
        [DataMember]
        public string CommunicationPincode { get; set; }

        [JsonProperty("CommunicationMobileNo")]
        [DataMember]
        public string CommunicationMobileNo { get; set; }

        [JsonProperty("CommunicationEmailid")]
        [DataMember]
        public string CommunicationEmailid { get; set; }

        [JsonProperty("District")]
        [DataMember]
        public string District { get; set; }

        [JsonProperty("SalesArea")]
        [DataMember]
        public string SalesArea { get; set; }

    }
}
