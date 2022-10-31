using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.DICV
{
  

    public class InsertDICVCustomerModelInput : BaseClass
    {
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


        [Required]
        [JsonPropertyName("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }


        [Required]
        [JsonPropertyName("CommunicationAddress1")]
        [DataMember]
        public string CommunicationAddress1 { get; set; }

        [Required]
        [JsonPropertyName("CommunicationAddress2")]
        [DataMember]
        public string CommunicationAddress2 { get; set; }


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
        public string CommunicationEmailid { get; set; }


        [JsonPropertyName("CopyofDriverLicense")]
        [DataMember]
        public string CopyofDriverLicense { get; set; }

        [JsonPropertyName("CopyofVehicleRegistrationCertificate")]
        [DataMember]
        public string CopyofVehicleRegistrationCertificate { get; set; }

        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

        [JsonPropertyName("SalesExecutiveEmployeeID")]
        [DataMember]
        public string SalesExecutiveEmployeeID { get; set; }

        //[JsonPropertyName("ObjALCardEntryDetail")]
        //[DataMember]
        // public List<DICVCardEntryDetail> ObjDICVCardEntryDetail { get; set; }
       
        //[JsonPropertyName("NumberOfCard")]
        //[DataMember]
        //public int NumberOfCard { get; set; }

        
        [JsonPropertyName("PanCardNo")]
        [DataMember]
        public string PanCardNo { get; set; }
        
        [Required]
        [JsonPropertyName("AddressProof")]
        [DataMember]
        public IFormFile AddressProof { get; set; }

        [Required]
        [JsonPropertyName("IDProof")]
        [DataMember]
        public IFormFile IDProof { get; set; }

        [Required]
        [JsonPropertyName("PanCardProof")]
        [DataMember]
        public IFormFile PanCardProof { get; set; }

        [JsonPropertyName("VechileNo")]
        public List<string> VechileNo { get; set; }

        [JsonPropertyName("CardNo")]
        public List<string> CardNo { get; set; }

        [JsonPropertyName("MobileNo")]
        public List<string> MobileNo { get; set; }

        [JsonPropertyName("VehicleType")]
        public List<string> VehicleType { get; set; }

        [JsonPropertyName("VINNumber")]
        public List<string> VINNumber { get; set; }

        
        [JsonPropertyName("RcCopyProof")]
        
        public List<IFormFile> RcCopyProof { get; set; }
    }
    public class DICVCardEntryDetail
    {


        [JsonPropertyName("VechileNo")]
        public string VechileNo { get; set; }

        [JsonPropertyName("CardNo")]
        public string CardNo { get; set; }

        [JsonPropertyName("MobileNo")]
        public string MobileNo { get; set; }

        [JsonPropertyName("VehicleType")]
        public string VehicleType { get; set; }

        [JsonPropertyName("VINNumber")]
        public string VINNumber { get; set; }

    }

    public class InsertDICVCustomerModelOutput : BaseClassOutput
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

        [JsonProperty("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonProperty("ControlPassword")]
        [DataMember]
        public string ControlPassword { get; set; }

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
