using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantUpdateTerminalInstallationRequestCloseModelInput : BaseClass
    {

        //[JsonPropertyName("StatusId")]
        //[DataMember]
        //public Int32 StatusId { get; set; }

        [JsonPropertyName("ReasonId")]
        [DataMember]
        public string ReasonId { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("ObjMerchantTerminalInstallationRequestCloseDetail")]
        [DataMember]
        public List<MerchantTerminalInstallationRequestCloseModelInput> ObjMerchantTerminalInstallationRequestCloseDetail { get; set; }
    }

    public class MerchantTerminalInstallationRequestCloseModelInput
    {

        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }
    }

    public class MerchantUpdateTerminalInstallationRequestCloseModelOutput : BaseClassOutput
    {

    }
}
