using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.CustomerRelationship
{

        public class CustomerRelationshipCustomerCategoryModelInput : BaseClass
        {
        }

        public class CustomerRelationshipCustomerCategoryModelOutput : BaseClassOutput
        {
            [JsonProperty("TierId")]
            [DataMember]
            public int TierId { get; set; }

            [JsonProperty("TierName")]
            [DataMember]
            public string TierName { get; set; }
        }
    }

