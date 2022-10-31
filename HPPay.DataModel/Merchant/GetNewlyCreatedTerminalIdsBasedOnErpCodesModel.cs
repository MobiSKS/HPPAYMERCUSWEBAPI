using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Merchant
{
    public class GetNewlyCreatedTerminalIdsBasedOnErpCodesModelInput : BaseClass
    {
        [JsonPropertyName("ObjApprovalRejectDetail")]
        [DataMember]
        public List<ApprovalRejectModelInput> ObjApprovalRejectDetail { get; set; }
    }

    public class GetNewlyCreatedTerminalIdsBasedOnErpCodesModelOutput : BaseClassOutput
    {
        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("IAC")]
        [DataMember]
        public string IAC { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }
    }
}
