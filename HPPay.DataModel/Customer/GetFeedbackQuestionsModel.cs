using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataModel.Customer
{
    public class GetFeedbackQuestionsModelInput:BaseClass
    {
    }
    public class GetFeedbackQuestionsModelOutput : BaseClassOutput
    {
        [JsonProperty("QuesId")]
        [DataMember]
        public string QuesId { get; set; }

        [JsonProperty("QuesTitle")]
        [DataMember]
        public string QuesTitle { get; set; }

        [JsonProperty("QuesType")]
        [DataMember]
        public string QuesType { get; set; }

        [JsonProperty("QuesStatus")]
        [DataMember]
        public string QuesStatus { get; set; }

        [JsonProperty("Option1")]
        [DataMember]
        public string Option1 { get; set; }

        [JsonProperty("Option2")]
        [DataMember]
        public string Option2 { get; set; }

        [JsonProperty("Option3")]
        [DataMember]
        public string Option3 { get; set; }

        [JsonProperty("Option4")]
        [DataMember]
        public string Option4 { get; set; }

        [JsonProperty("Option5")]
        [DataMember]
        public string Option5 { get; set; }

        [JsonProperty("Option6")]
        [DataMember]
        public string Option6 { get; set; }
    }

}
