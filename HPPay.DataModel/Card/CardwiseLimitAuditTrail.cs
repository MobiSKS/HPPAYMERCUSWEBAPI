using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace HPPay.DataModel.Card
{
    public class CardwiseLimitAuditTrailModelInput: BaseClass
    {
        [JsonProperty("CustomerId")]
        [DataMember]
        [JsonRequired]
        public string CustomerId { get; set; }
        
        [JsonProperty("FromDate")]
        [DataMember]
        [JsonRequired]
        public DateTime FromDate { get; set; }

        [JsonProperty("ToDate")]
        [DataMember]
        [JsonRequired]
        public DateTime ToDate { get; set; }

        [JsonProperty("CardNumber")]
        [DataMember]
        
        public string CardNumber { get; set; }

        [JsonProperty("LimitType")]
        [DataMember]
        
        public string LimitType { get; set; }
    }
    public class CardwiseLimitAuditTrailModelOutput : BaseClassOutput
    {
        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonProperty("VehicleNo")]
        [DataMember]
        public string VehicleNo { get; set; }

        [JsonProperty("LimitType")]
        [DataMember]
        public string LimitType { get; set; }

        [JsonProperty("OldCCMSLimitValue")]
        [DataMember]
        public string OldCCMSLimitValue { get; set; }

        [JsonProperty("NewCCMSLimitValue")]
        [DataMember]
        public string NewCCMSLimitValue { get; set; }

        [JsonProperty("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonProperty("ModifiedDate")]
        [DataMember]
        public string ModifiedDate { get; set; }

    }
}
