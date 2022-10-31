using Newtonsoft.Json;
using System.Runtime.Serialization;


namespace HPPay.DataModel.CustomerRelationship
{
    public class CustomerRelationshipPaymentTermsTypeModelInput:BaseClass
    {


    }

    public class CustomerRelationshipPaymentTermsTypeModelOutput : BaseClassOutput
    {
        [JsonProperty("PaymentId")]
        [DataMember]
        public int PaymentId { get; set; }

        [JsonProperty("PaymentType")]
        [DataMember]
        public string PaymentType { get; set; }

    }
}
