using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.HDFCPG
{
    public class GenerateQRCodeModelInput : BaseClass
    {

        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [JsonPropertyName("ProductId")]
        [DataMember]
        public string ProductId { get; set; }       


    }

    public class GenerateQRCodeModelOutput : BaseClassOutput
    {
        [JsonProperty("QRString")]
        [DataMember]
        public string QRString { get; set; }

        [JsonProperty("RequestId")]
        [DataMember]
        public string RequestId { get; set; }

        [JsonProperty("OutletName")]
        [DataMember]
        public string OutletName { get; set; }         

        [JsonProperty("Amount")]
        [DataMember]
        public string Amount { get; set; }

    }

    public class ValidateQRCodeModelInput : BaseClass
    {
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; } 

        [JsonPropertyName("QRRequestId")]
        [DataMember]
        public string QRRequestId { get; set; }

    }
    public class ValidateQRCodeModelOutput : BaseClassOutput
    {        

        [JsonProperty("RequestId")]
        [DataMember]
        public string RequestId { get; set; }

        [JsonProperty("TransactionID")]
        [DataMember]
        public string TransactionID { get; set; }

        [JsonProperty("TransactionType")]
        [DataMember]
        public string TransactionType { get; set; }

    }

}
