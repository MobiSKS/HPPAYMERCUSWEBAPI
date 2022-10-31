using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AMEXCreditPouch
{
    public class ActionOnAMEXCreditPouchModelInput: BaseClass
    {
        [JsonPropertyName("ObjBankEntryDetail")]
        [DataMember]
        public List<AMEXBankEntryDetail> ObjBankEntryDetail { get; set; }

    }
    public class AMEXBankEntryDetail
    {

        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("RequestId")]
        [DataMember]
        public int RequestId { get; set; }

        [JsonPropertyName("BankRemark")]
        [DataMember]
        public string BankRemark { get; set; }

        [JsonPropertyName("ActionType")]
        [DataMember]
        public int ActionType { get; set; }

        [JsonPropertyName("ApprovedBy")]
        [DataMember]
        public string ApprovedBy { get; set; }
        
        [JsonPropertyName("PlanName")]
        [DataMember]
        public string PlanName { get; set; }

    }
    public class ActionOnAMEXCreditPouchModelOutput : BaseClassOutput
    {
        [JsonProperty("StatusCode")]
        [DataMember]
        public string StatusCode { get; set; }

        //[JsonPropertyName("EmailId")]
        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

    }
}
