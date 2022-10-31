using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.CustomerRelationship
{
    public class CustomerRelationshipPaymentTermsModeModelInput:BaseClass
    {
    }

    public class CustomerRelationshipPaymentTermsModeModelOutput : BaseClassOutput
    {
        [JsonProperty("PaymentModeId")]
        [DataMember]
        public int PaymentModeId { get; set; }

        [JsonProperty("PaymentMode")]
        [DataMember]
        public string PaymentMode { get; set; }
    }
}
