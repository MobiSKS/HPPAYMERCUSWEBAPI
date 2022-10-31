using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantSearchTerminalModelInput : BaseClass
    {
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }


        [JsonPropertyName("TerminalType")]
        [DataMember]
        public string TerminalType { get; set; }

        [JsonPropertyName("IssueDate")]
        [DataMember]
        public string IssueDate { get; set; }

        
    }

    public class MerchantSearchTerminalModelOutput
    {

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }


        [JsonProperty("ApprovalDate")]
        [DataMember]
        public string ApprovalDate { get; set; }


        [JsonProperty("TerminalStatus")]
        [DataMember]
        public string TerminalStatus { get; set; }


        [JsonProperty("DeploymentStatus")]
        [DataMember]
        public string DeploymentStatus { get; set; }
         

    }

}
