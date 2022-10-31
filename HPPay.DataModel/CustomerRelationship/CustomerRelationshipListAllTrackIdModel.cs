using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.CustomerRelationship
{

        public class CustomerRelationshipListAllTrackIdModelInput : BaseClass
        {

        }

        public class CustomerRelationshipListAllTrackIdModelOutput: BaseClassOutput
        {
            [JsonProperty("TrackID")]
            [DataMember]
            public int TrackID { get; set; }

            [JsonProperty("CustomerName")]
            [DataMember]
            public string CustomerName { get; set; }

            [JsonProperty("CustomerAddress1")]
            [DataMember]
            public int CustomerAddress1 { get; set; }

            [JsonProperty("CustomerAddress2")]
            [DataMember]
            public string CustomerAddress2 { get; set; }

            [JsonProperty("CustomerCity")]
            [DataMember]
            public int CustomerCity { get; set; }

            [JsonProperty("CustomerCategory")]
            [DataMember]
            public string CustomerCategory { get; set; }

            [JsonProperty("CustomerMobileNo")]
            [DataMember]
            public string CustomerMobileNo { get; set; }


        }
    }

