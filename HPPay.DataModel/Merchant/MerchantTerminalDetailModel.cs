using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.Merchant
{
    public class MerchantTerminalDetailModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }
    }


    public class TerminalDetail
    {
        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonProperty("MerchantCity")]
        [DataMember]
        public string MerchantCity { get; set; }

        [JsonProperty("ApprovalDate")]
        [DataMember]
        public string ApprovalDate { get; set; }

        [JsonProperty("FirstTransactionDate")]
        [DataMember]
        public string FirstTransactionDate { get; set; }

        [JsonProperty("LastTransactionDate")]
        [DataMember]
        public string LastTransactionDate { get; set; }

        [JsonProperty("DeploymentStatus")]
        [DataMember]
        public string DeploymentStatus { get; set; }
    }

    public class TerminalDeploymentDetail
    {
        [JsonProperty("Events")]
        [DataMember]
        public string Events { get; set; }

        [JsonProperty("Date")]
        [DataMember]
        public string Date { get; set; }

        [JsonProperty("Comment")]
        [DataMember]
        public string Comment { get; set; }


        [JsonProperty("DeliveredTo")]
        [DataMember]
        public string DeliveredTo { get; set; }

       

    }

    public class MerchantTerminalDetailModelOutput
    {
        [JsonProperty("ObjTerminalDetail")]
        public List<TerminalDetail> ObjTerminalDetail { get; set; }

        [JsonProperty("ObjTerminalDeploymentDetail")]
        public List<TerminalDeploymentDetail> ObjTerminalDeploymentDetail { get; set; }

    }
}
