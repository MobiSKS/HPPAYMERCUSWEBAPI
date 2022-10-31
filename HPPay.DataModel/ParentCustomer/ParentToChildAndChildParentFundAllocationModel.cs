using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.ParentCustomer
{
    public class ParentToChildAndChildParentFundAllocationModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("ParentCustomerId")]
        [DataMember]
        public string ParentCustomerId { get; set; }

        [JsonPropertyName("ChildCustomerId")]
        [DataMember]
        public string ChildCustomerId { get; set; }

    }

    public class ParentToChildAndChildParentFundAllocationModelOutPut
    {
        [JsonProperty("GetParentCustomer")]
        public List<GetParentCustomer> GetParentCustomer { get; set; }

        [JsonProperty("GetChildCustomer")]
        public List<GetChildCustomer> GetChildCustomer { get; set; }
    }

    public class GetParentCustomer:BaseClassOutput
    {
        [JsonProperty("AvailableCCMSBalance")]
        [DataMember]
        public string AvailableCCMSBalance { get; set; }

        [JsonProperty("AvailableDriveStars")]
        [DataMember]
        public string AvailableDriveStars { get; set; }
    }
    public class GetChildCustomer: BaseClassOutput
    {

        [JsonProperty("ChildId")]
        [DataMember]
        public string ChildId { get; set; }

        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonProperty("CCMSBalance")]
        [DataMember]
        public string CCMSBalance { get; set; }

        [JsonProperty("Drivestars")]
        [DataMember]
        public string Drivestars { get; set; }

        [JsonProperty("RegionalOffice")]
        [DataMember]
        public string RegionalOffice { get; set; }

        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }
    }
}
