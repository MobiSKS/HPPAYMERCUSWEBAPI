using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AMEXCreditPouch
{
    public class AuthActionOnAMEXCreditPouchModelInput: BaseClass
    {
        [JsonPropertyName("ObjBankAuthEntryDetail")]
        [DataMember]
        public List<AMEXBankAuthEntryDetail> ObjBankAuthEntryDetail { get; set; }
    }

    public class AMEXBankAuthEntryDetail
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

        [JsonPropertyName("AuthorizBy")]
        [DataMember]
        public string AuthorizBy { get; set; }

        [JsonPropertyName("PlanName")]
        [DataMember]
        public string PlanName { get; set; }

        

    }
    public class AuthActionOnAMEXCreditPouchModelOutput : BaseClassOutput
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
