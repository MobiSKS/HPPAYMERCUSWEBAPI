using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{
    public class GetRBEMobilenoModelInput : BaseClass
    {
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }
    }
    public class GetRBEMobilenoModelOutput : BaseClassOutput
    {

    }
}
