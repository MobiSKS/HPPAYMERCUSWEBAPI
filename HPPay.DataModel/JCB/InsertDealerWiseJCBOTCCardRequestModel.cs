using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.JCB
{
    public class InsertDealerWiseJCBOTCCardRequestModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

        [Required]
        [JsonPropertyName("NoofCards")]
        [DataMember]
        public Int32 NoofCards { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }
    public class InsertDealerWiseJCBOTCCardRequestModelOutput : BaseClassOutput
    {

    }



    public class GetJCBBalanceOTCCardModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

       
    }
    public class GetJCBBalanceOTCCardModelOutput : BaseClassOutput
    {
        
        [JsonProperty("TotalCard")]
        [DataMember]
        public string TotalCard { get; set; }

        [JsonProperty("BalanceCard")]
        [DataMember]
        public string BalanceCard { get; set; }
    }
}
