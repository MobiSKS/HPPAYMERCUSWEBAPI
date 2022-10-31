using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Customer
{
    public class UpdateCustomerFeedbackModelInput : BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("Comment")]
        [DataMember]
        public string Comment { get; set; }

        [JsonPropertyName("FeedbackCategoryId")]
        [DataMember]
        public string FeedbackCategoryId { get; set; }
    }
    public class UpdateCustomerFeedbackModelOutput : BaseClassOutput
    {

    }
}
