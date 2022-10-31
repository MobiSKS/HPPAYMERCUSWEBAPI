using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.HLFL
{
    public class HLFLGetProductRSPModelInPut
    {
        [Required]
        [JsonPropertyName("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }


        [Required]
        [JsonPropertyName("merchantId")]
        [DataMember]
        public string merchantId { get; set; }
    }

    public class HLFLGetProductRSPModelOutPut
    {
        [JsonProperty("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }

        [JsonProperty("ProductList")]
        public List<HLFLProductList> ProductList { get; set; }


        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }


        [JsonProperty("merchantID")]
        [DataMember]
        public string merchantID { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public int Status { get; set; } 
    }
    public class HLFLProductList
    {
        [JsonProperty("productName")]
        [DataMember]
        public string productName { get; set; }

        [JsonProperty("unitPrice")]
        [DataMember]
        public decimal unitPrice { get; set; }
    }
}
