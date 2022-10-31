using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.CustomerRelationship
{
        public class CustomerRelationshipMonthModelInput:BaseClass
        {

        }

        public class CustomerRelationshipMonthModelOutput:BaseClassOutput
        {

            [JsonProperty("DateValue")]
            [DataMember]
            public string DateValue { get; set; }

            [JsonProperty("Date")]
            [DataMember]
            public string Date { get; set; }
        }
    
}
