using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace HPPay.DataModel.CustomerRelationship
{
        public class CustomerRelationshipFleetSizeValueModelInput:BaseClass
        {
            [Required]
            [JsonProperty("TierId")]
            [DataMember]
            public int TierId { get; set; }
        }
        public class CustomerRelationshipFleetSizeValueModelOutput:BaseClassOutput
        {
            [JsonProperty("TierId")]
            [DataMember]
            public int TierId { get; set; }

            [JsonProperty("TierName")]
            [DataMember]
            public string TierName { get; set; }

            [JsonProperty("FleetSize")]
            [DataMember]
            public string FleetSize { get; set; }
        }
    }

