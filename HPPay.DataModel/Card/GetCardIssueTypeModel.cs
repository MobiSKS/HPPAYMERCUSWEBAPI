using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataModel.Card
{
    public class GetCardIssueTypeModelInput : BaseClass
    {

    }
    public class GetCardIssueTypeModelOutput
    {
        [JsonProperty("CardIssueId")]
        [DataMember]
        public int CardIssueId { get; set; }

        [JsonProperty("CardIssueType")]
        [DataMember]
        public string CardIssueType { get; set; }
    }
}
