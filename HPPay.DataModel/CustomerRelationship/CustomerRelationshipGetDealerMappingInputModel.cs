using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerRelationship
{
        public class CustomerRelationshipGetDealerMappingInputModelInput : BaseClass
        {
            [Required]
            [JsonPropertyName("RegionOfficeId")]
            [DataMember]
            public int RegionOfficeId { get; set; }
        }

        public class CustomerRelationshipGetDealerMappingInputModelOutput : BaseClassOutput
        {

            [JsonProperty("Location")]
            [DataMember]
            public string Location { get; set; }

            [JsonProperty("TrackIdorCustomerId")]
            [DataMember]
            public string TrackIdorCustomerId { get; set; }


            [JsonProperty("CustomerName")]
            [DataMember]
            public string CustomerName { get; set; }


            [JsonProperty("OriginatingReason")]
            [DataMember]
            public string OriginatingReason { get; set; }


            [JsonProperty("MO")]
            [DataMember]
            public string MO { get; set; }

            [JsonProperty("MOContact")]
            [DataMember]
            public string MOContact { get; set; }
        }
    }

