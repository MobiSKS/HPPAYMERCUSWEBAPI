using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DICV
{
    public class GetDICVCustomerKYCModelInput:BaseClass
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        [Required]
        public string CustomerId { get; set; }
    }

    public class GetDICVCustomerKYCModelOutput: BaseClassOutput
    {
        

        [JsonProperty("CustomerReferenceNo")]
        [DataMember]
        public string CustomerReferenceNo { get; set; }

        [JsonProperty("AddressProofType")]
        [DataMember]
        public string AddressProofType { get; set; }

        [JsonProperty("AddressProofDocumentNo")]
        [DataMember]
        public string AddressProofDocumentNo { get; set; }

        [JsonProperty("AddressProofFront")]
        [DataMember]
        public string AddressProofFront { get; set; }

        [JsonProperty("IdProofType")]
        [DataMember]
        public string IdProofType { get; set; }

        [JsonProperty("IdProofFront")]
        [DataMember]
        public string IdProofFront { get; set; }

        [JsonProperty("PanCardType")]
        [DataMember]
        public string PanCardType { get; set; }

        [JsonProperty("PanCard")]
        [DataMember]
        public string PanCard { get; set; }



    }
}
