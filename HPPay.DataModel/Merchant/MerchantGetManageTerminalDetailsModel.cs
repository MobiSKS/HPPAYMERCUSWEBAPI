using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantGetManageTerminalDetailsModelInput :BaseClass
    {
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }


        [JsonPropertyName("DeploymentStatus")]
        [DataMember]
        public string DeploymentStatus { get; set; }
    }

    public class MerchantGetManageTerminalDetailsModelOutput
    {
        [JsonProperty("Merchantid")]
        [DataMember]
        public string Merchantid { get; set; }

        [JsonProperty("Terminalid")]
        [DataMember]
        public string Terminalid { get; set; }

        [JsonProperty("ApprovalDate")]
        [DataMember]
        public string ApprovalDate { get; set; }

        [JsonProperty("DeploymentStatus")]
        [DataMember]
        public string DeploymentStatus { get; set; }

        [JsonProperty("TerminalIssuanceType")]
        [DataMember]
        public string TerminalIssuanceType { get; set; }


        [JsonProperty("MappedMerchantId")]
        [DataMember]
        public string MappedMerchantId { get; set; }

        [JsonProperty("ServiceChargeInRsPerLtr")]
        [DataMember]
        public string ServiceChargeInRsPerLtr { get; set; }

        [JsonProperty("RouteId")]
        [DataMember]
        public string RouteId { get; set; }


        [JsonProperty("EffectiveDate")]
        [DataMember]
        public string EffectiveDate { get; set; }

        [JsonProperty("TerminalStatus")]
        [DataMember]
        public string TerminalStatus { get; set; }

        [JsonProperty("MerchantTypeId")]
        [DataMember]
        public string MerchantTypeId { get; set; }

    }
}
