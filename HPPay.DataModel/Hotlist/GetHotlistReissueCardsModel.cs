using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Hotlist
{
    public class HotlistGetHotlistReissueCardsModelInput : BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
    }

    public class HotlistGetHotlistReissueCardsModelOutput : BaseClassOutput
    {


        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }


        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }


        [JsonProperty("OwnedORAttachedId")]
        [DataMember]
        public int OwnedORAttachedId { get; set; }

        [JsonProperty("OwnedORAttachedName")]
        [DataMember]
        public string OwnedORAttachedName { get; set; }


        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }


        [JsonProperty("VechileType")]
        [DataMember]
        public string VechileType { get; set; }


        [JsonProperty("YearOfRegistration")]
        [DataMember]
        public string YearOfRegistration { get; set; }


        [JsonProperty("Manufacturer")]
        [DataMember]
        public string Manufacturer { get; set; }


        [JsonProperty("CardCategory")]
        [DataMember]
        public string CardCategory { get; set; }
    }

}
