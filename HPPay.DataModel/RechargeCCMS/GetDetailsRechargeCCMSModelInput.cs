using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RechargeCCMS
{
    public class GetDetailsRechargeCCMSModelInput : BaseClass
    { 
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }
         
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

    }
    public class GetDetailsRechargeCCMSModelOutPut:BaseClassOutput
    {
        
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("CustomerType")]
        [DataMember]
        public string CustomerType { get; set; }

        [JsonProperty("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonProperty("OrderId")]
        [DataMember]
        public string OrderId { get; set; }

    }

    public class GetBatchIdCCMSModelInput
    {
        [JsonPropertyName("Merchantid")]
        [DataMember]
        public string Merchantid { get; set; }

        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

    }

    public class GetBatchIdCCMSModelOutput
    {
        [JsonProperty("Bid")]
        [DataMember]
        public string Bid { get; set; }

        [JsonProperty("InvoiceId")]
        [DataMember]
        public string InvoiceId { get; set; }

        [JsonProperty("ReqStatus")]
        [DataMember]
        public string ReqStatus { get; set; }

    }



}
