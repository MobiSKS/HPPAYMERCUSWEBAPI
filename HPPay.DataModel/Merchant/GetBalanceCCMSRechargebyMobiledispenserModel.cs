using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Merchant
{
    public class GetBalanceCCMSRechargebyMobiledispenserModelInput : BaseClass
    {

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class GetBalanceCCMSRechargebyMobiledispenserModelOutput : BaseClassOutput
    {
        [JsonProperty("Current CCMS Blance")]
        [DataMember]
        public decimal CurrentCCMSBlance { get; set; }
    }
}
