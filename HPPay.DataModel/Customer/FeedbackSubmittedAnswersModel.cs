using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Customer
{
    public class FeedbackSubmittedAnswersModelInput : BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("TypeFeedbackAnswers")]
        [DataMember]

        public List<TypeFeedbackAnswers> TypeFeedbackAnswers { get; set; }

    }

    public class TypeFeedbackAnswers
    {
        [JsonPropertyName("QuesId")]
        [DataMember]
        public string QuesId { get; set; }


        [JsonPropertyName("QuesType")]
        [DataMember]
        public string QuesType { get; set; }
       


        [JsonPropertyName("Answers")]
        [DataMember]
        public string Answers { get; set; }
    }

    public class FeedbackSubmittedAnswersModelOutput : BaseClassOutput
    {
    }
}
