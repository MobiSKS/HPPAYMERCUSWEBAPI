using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIGetProductRSPModelInput: CustomerAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("merchantID")]
        [DataMember]
        public string merchantID { get; set; }
    }

    public class CustomerAPIGetProductRSPModelOutput
    {

        [JsonProperty("merchantDetails")]
        [DataMember]
        public List<MerchantRetailOutletDetails> merchantDetails { get; set; }

        [JsonProperty("productList")]
        [DataMember]
        public List<ProductList> productList { get; set; }

    }

    public class CustomerAPIGetProductRSPModelFInalOutput
    {
        [JsonProperty("responseCode")]
        [DataMember]
        public string responseCode { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }

        [JsonProperty("merchantID")]
        [DataMember]
        public string merchantID { get; set; }

        [JsonProperty("retailOutletName")]
        [DataMember]
        public string retailOutletName { get; set; }

        [JsonProperty("productList")]
        [DataMember]
        public List<ProductList> productList { get; set; }

    }

    public class MerchantRetailOutletDetails : CustomerAPIBaseClassOutput
    {

        [JsonProperty("merchantID")]
        [DataMember]
        public string merchantID { get; set; }

        [JsonProperty("retailOutletName")]
        [DataMember]
        public string retailOutletName { get; set; }
    }

    public class ProductList 
    {
        [JsonProperty("productName")]
        [DataMember]
        public string productName { get; set; }

        [JsonProperty("unitPrice")]
        [DataMember]
        public decimal unitPrice { get; set; }
    }
}
