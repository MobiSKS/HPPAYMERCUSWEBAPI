using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.IMPS
{
    public class IMPSRechargeReversalRequestInput:BaseClass
    {
        [JsonPropertyName("BankTransactionID")]
        [DataMember]
        public string BankTransactionID { get; set; }

        [JsonPropertyName("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }
        
    }
    public class IMPSRechargeReversalRequestOutput:BaseClassOutput
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }
}
