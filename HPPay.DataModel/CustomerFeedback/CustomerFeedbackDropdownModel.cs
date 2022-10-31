using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.CustomerFeedback
{
    public class CustomerFeedbackDropdownModelInput : BaseClass
    {
        [JsonPropertyName("EntityType")]
        [DataMember]
        public int EntityType { get; set; }
    }
    public class CustomerFeedbackDropdownModelOutput : BaseClassOutput
    {

        [JsonProperty("CategoryId")]
        [DataMember]
        public string CategoryId { get; set; }

        [JsonProperty("CategoryName")]
        [DataMember]
        public string CategoryName { get; set; }



    }
}
