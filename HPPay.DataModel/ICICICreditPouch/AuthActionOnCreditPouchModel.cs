using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ICICICreditPouch
{
    public class AuthActionOnICICICreditPouchModelInput : BaseClass
    {
        [JsonPropertyName("ObjBankAuthEntryDetail")]
        [DataMember]
        public List<ICICIBankAuthEntryDetail> ObjBankAuthEntryDetail { get; set; }
    }

    public class ICICIBankAuthEntryDetail
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("RequestId")]
        [DataMember]
        public int RequestId { get; set; }

        [JsonPropertyName("AuthorizationRemark")]
        [DataMember]
        public string AuthorizationRemark { get; set; }

        [JsonPropertyName("ActionType")]
        [DataMember]
        public int ActionType { get; set; }

        [JsonPropertyName("CreditLimitAssigned")]
        [DataMember]
        public decimal CreditLimitAssigned { get; set; }
        
        [JsonPropertyName("PlanName")]
        [DataMember]
        public string PlanName { get; set; }

        [JsonPropertyName("AuthorizBy")]
        [DataMember]
        public string AuthorizBy { get; set; }
         
    }
    public class AuthActionOnICICICreditPouchModelOutput : BaseClassOutput
    {
        [JsonProperty("StatusCode")]
        [DataMember]
        public string StatusCode { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [JsonProperty("Mobile")]
        [DataMember]
        public string Mobile { get; set; }
    }
}
