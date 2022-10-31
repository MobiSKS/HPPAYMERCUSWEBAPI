using Newtonsoft.Json;
using System.Runtime.Serialization;
namespace HPPay.DataModel.DealerCreditManage
{
    public class GetListCreditCloseLimitTypeModelInput :BaseClass
    {
    }

    public class GetListCreditCloseLimitTypeModelOutput
    {
        [JsonProperty("LimitId")]
        [DataMember]
        public int LimitId { get; set; }


        [JsonProperty("Description")]
        [DataMember]
        public string Description { get; set; }

    }
}
