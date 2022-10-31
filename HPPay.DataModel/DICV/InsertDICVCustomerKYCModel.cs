using Microsoft.AspNetCore.Http;
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
    public class InsertDICVCustomerKYCModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        //[Required]
        //[JsonPropertyName("IdProofType")]
        //[DataMember]
        //public int IdProofType { get; set; }

        [JsonPropertyName("IdProof")]
        [DataMember]
        public IFormFile IdProof { get; set; }

        [JsonPropertyName("AddressProof")]
        [DataMember]
        public IFormFile AddressProof { get; set; }

        [JsonPropertyName("PanCardProof")]
        [DataMember]
        public IFormFile PanCardProof { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }   


    }
    public class InsertDICVCustomerKYCModelOutput : BaseClassOutput
    {
    }
}
