using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class CheckEmailIdModelInput : BaseClass
    {
        [JsonPropertyName("CommunicationEmailid")]
        [DataMember]
        public string CommunicationEmailid { get; set; }
    }
    public class CheckEmailIdModelOutput : BaseClassOutput
    {

    }
}
