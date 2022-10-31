using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DICV
{
    public class DICVCustomerDetailUpdateModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("ZonalOffice")]
        [DataMember]
        public Int32 ZonalOffice { get; set; }

        [Required]
        [JsonPropertyName("RegionalOffice")]
        [DataMember]
        public Int32 RegionalOffice { get; set; }

        [JsonProperty("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [Required]
        [JsonPropertyName("DateOfApplication")]
        [DataMember]
        public DateTime DateOfApplication { get; set; }

        [Required]
        [JsonPropertyName("SignedOnDate")]
        [DataMember]
        public DateTime SignedOnDate { get; set; }

        [JsonProperty("SalesArea")]
        [DataMember]
        public Int64 SalesArea { get; set; }

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

        //AdressDetail

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
    }

    public class DICVCustomerDetailUpdateModelOutput : BaseClassOutput
    {

    }

    public class ApprovalDICVCustomerUpdateRequestModelInput : BaseClass
    {
        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }

        [JsonPropertyName("CustomerApproval")]
        [DataMember]
        public List<DICVCustomerApproval> CustomerApprovalList { get; set; }
    }

    public class DICVCustomerApproval
    {

        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("Comments")]
        [DataMember]
        public string Comments { get; set; }

    }
    public class ApprovalDICVCustomerUpdateRequestModelOutput : BaseClassOutput
    {

    }
}
