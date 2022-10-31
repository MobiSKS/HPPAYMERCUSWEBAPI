﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{

    public class MerchantInsertDriverCardCustomerModelInput : BaseClass
    {

        [JsonPropertyName("CardNo")]
        public string CardNo { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }


        [Required]
        [JsonPropertyName("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [Required]
        [JsonPropertyName("IndividualOrgNameTitle")]
        [DataMember]
        public string IndividualOrgNameTitle { get; set; }

        //[Required]
        [JsonPropertyName("IncomeTaxPan")]
        [DataMember]
        //[RegularExpression("^[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}$", ErrorMessage = "Invalid Pancard Number")]
        public string IncomeTaxPan { get; set; }


        [Required]
        [JsonPropertyName("CommunicationAddress1")]
        [DataMember]
        public string CommunicationAddress1 { get; set; }


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

        [JsonPropertyName("CommunicationPhoneNo")]
        [DataMember]
        public string CommunicationPhoneNo { get; set; }


        [Required]
        [JsonPropertyName("CommunicationMobileNo")]
        [StringLength(10, MinimumLength = 10)]
        [DataMember]
        public string CommunicationMobileNo { get; set; }


        [JsonPropertyName("CommunicationEmailid")]
        [DataMember]
        [RegularExpression("\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", ErrorMessage = "Invalid Email Id")]
        public string CommunicationEmailid { get; set; }


        [JsonPropertyName("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }


        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonPropertyName("AddressProofType")]
        [DataMember]
        public string AddressProofType { get; set; }


        [JsonPropertyName("AddressProofDocumentNo")]
        [DataMember]
        public string AddressProofDocumentNo { get; set; }

        [Required]
        [JsonPropertyName("DrivingLicence")]
        [DataMember]
        public string DrivingLicence { get; set; }

        [Required]
        [JsonPropertyName("DTPCustomerStatus")]
        [DataMember]
        public Int32 DTPCustomerStatus { get; set; }
 
        [JsonPropertyName("ExistingCustomerId")]
        [DataMember]
        public string ExistingCustomerId { get; set; }

        [Required]
        [JsonPropertyName("BeneficiaryName")]
        [DataMember]
        public string BeneficiaryName { get; set; }

        [Required]
        [JsonPropertyName("RelationwithBeneficiary")]
        [DataMember]
        public string RelationwithBeneficiary { get; set; }


        [Required]
        [JsonPropertyName("BeneficiaryMobile")]
        [DataMember]
        public string BeneficiaryMobile { get; set; }

        
        [JsonPropertyName("AddressProof")]
        [DataMember]
        public IFormFile AddressProof { get; set; }


        [JsonPropertyName("AddressBackProof")]
        [DataMember]
        public IFormFile AddressBackProof { get; set; }

        [JsonPropertyName("IDProofType")]
        [DataMember]
        public string IDProofType { get; set; }


        [JsonPropertyName("IDProofDocumentNo")]
        [DataMember]
        public string IDProofDocumentNo { get; set; }

        [JsonPropertyName("IDProof")]
        [DataMember]
        public IFormFile IDProof { get; set; }


        [JsonPropertyName("IDBackProof")]
        [DataMember]
        public IFormFile IDBackProof { get; set; }


    }

    public class MerchantInsertDriverCardCustomerModelOutput : BaseClassOutput
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

        [JsonProperty("Password")]
        [DataMember]
        public string Password { get; set; }

        [JsonProperty("CustomerStatus")]
        [DataMember]
        public Int64 CustomerStatus { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }
    }
}
