using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class CheckMobileNumberModelInput : BaseClass
    {
        [JsonPropertyName("CommunicationMobileNo")]
        [DataMember]
        public string CommunicationMobileNo { get; set; }
    }
    public class CheckMobileNumberModelOutput : BaseClassOutput
    {

    }
}
