using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
namespace HPPay.DataModel.Merchant
{
    
    public class MerchantUpdateTerminalInstallationRequestApprovalModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("Remark")]
        [DataMember]
        public string Remark { get; set; }

        [Required]
        [JsonPropertyName("Action")]
        [DataMember]
        public string Action { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("ObjMerchantTerminalInsertInput")]
        [DataMember]
        public List<MerchantTerminalInsertInput> ObjMerchantTerminalInsertInput { get; set; }
    }

    public class MerchantTerminalInsertInput
    {
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonPropertyName("TerminalID")]
        [DataMember]
        public string TerminalID { get; set; }

    }

    public class MerchantUpdateTerminalInstallationRequestApprovalModelOutput : BaseClassOutput
    {
        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonProperty("TerminalID")]
        [DataMember]
        public string TerminalID { get; set; }


        [JsonProperty("SendStatus")]
        [DataMember]
        public int? SendStatus { get; set; }
        
    }
}
