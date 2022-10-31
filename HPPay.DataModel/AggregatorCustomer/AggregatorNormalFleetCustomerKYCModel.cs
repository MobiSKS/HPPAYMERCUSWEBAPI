using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AggregatorCustomer
{
    public class AggregatorNormalFleetCustomerKYCModelInput : BaseClass
    {


        [Required]
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [Required]
        [JsonPropertyName("AddressProofType")]
        [DataMember]
        public int AddressProofType { get; set; }

        [Required]
        [JsonPropertyName("AddressProofFront")]
        [DataMember]
        public IFormFile AddressProofFront { get; set; }

        [Required]
        [JsonPropertyName("PanCardType")]
        [DataMember]
        public int PanCardType { get; set; }

        [Required]
        [JsonPropertyName("PanCard")]
        [DataMember]
        public IFormFile PanCard { get; set; }


        [Required]
        [JsonPropertyName("IdProofType")]
        [DataMember]
        public int IdProofType { get; set; }


        [Required]
        [JsonPropertyName("IdProofFront")]
        [DataMember]
        public IFormFile IdProofFront { get; set; }


        [Required]
        [JsonPropertyName("VehicleDetailsType")]
        [DataMember]
        public string VehicleDetailsType { get; set; }


        [Required]
        [JsonPropertyName("VehicleDetails")]
        [DataMember]
        public IFormFile VehicleDetails { get; set; }

        [Required]
        [JsonPropertyName("CustomerFormType")]
        [DataMember]
        public string CustomerFormType { get; set; }


        [Required]
        [JsonPropertyName("CustomerForm")]
        [DataMember]
        public IFormFile CustomerForm { get; set; }


        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }

    public class AggregatorNormalFleetCustomerKYCModelOutput : BaseClassOutput
    {

    }   
}
