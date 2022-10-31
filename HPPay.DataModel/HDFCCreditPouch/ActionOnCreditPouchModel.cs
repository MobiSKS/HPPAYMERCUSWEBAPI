using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.HDFCCreditPouch
{
    public class ActionOnCreditPouchModelInput :BaseClass
    { 
        [JsonPropertyName("ObjBankEntryDetail")]
        [DataMember]
        public List<HDFCBankEntryDetail> ObjBankEntryDetail { get; set; }       

    }

    public class HDFCBankEntryDetail
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
    public class ActionOnCreditPouchModelOutput : BaseClassOutput
    {
        [JsonProperty("StatusCode")]
        [DataMember]
        public string StatusCode { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

    }
}
