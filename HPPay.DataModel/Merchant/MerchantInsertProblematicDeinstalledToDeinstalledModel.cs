using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    

    public class MerchantInsertProblematicDeinstalledToDeinstalledModelInput : BaseClass
    {


        [JsonPropertyName("Remark")]
        [DataMember]
        public string Remark { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("ObjTerminalProblematicDeinstalledToDeinstalled")]
        [DataMember]
        public List<TerminalProblematicDeinstalledToDeinstalled> ObjTerminalProblematicDeinstalledToDeinstalled { get; set; }
    }

    public class TerminalProblematicDeinstalledToDeinstalled
    {

        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }
    }

    public class MerchantInsertProblematicDeinstalledToDeinstalledModelOutput : BaseClassOutput
    {
        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonProperty("SendStatus")]
        [DataMember]
        public int ? SendStatus { get; set; }


        
    }
}
