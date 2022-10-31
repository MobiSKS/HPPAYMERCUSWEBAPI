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
    public class GetRequestForApprovalReactivateMerchantModelInput:BaseClass
    {
      
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [JsonPropertyName("MerchantZO")]
        [DataMember]
        public int MerchantZO { get; set; }

        [JsonPropertyName("MerchantRO")]
        [DataMember]
        public int MerchantRO { get; set; }

        [Required]
        [JsonPropertyName("MerchantStatus")]
        [DataMember]
        public int MerchantStatus { get; set; }

        [JsonPropertyName("HotlistDate")]
        [DataMember]
        public string HotlistDate { get; set; }

        [JsonPropertyName("SBUTypeId")]
        [DataMember]
        public int SBUTypeId { get; set; }
    }

    public class GetRequestForApprovalReactivateMerchantModelOutput:BaseClassOutput
    {
        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }


        [JsonProperty("HotListReasonId")]
        [DataMember]
        public int HotListReasonId { get; set; }


        [JsonProperty("HotlistedDate")]
        [DataMember]
        public string HotlistedDate { get; set; }



        [JsonProperty("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }


        [JsonProperty("RequestedDate")]
        [DataMember]
        public string RequestedDate { get; set; }


        [JsonProperty("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }


        [JsonProperty("Remarks")]
        [DataMember]
        public string Remarks { get; set; }

        [JsonProperty("SBUTypeId")]
        [DataMember]
        public int SBUTypeId { get; set; }


        [JsonProperty("SBUName")]
        [DataMember]
        public string SBUName { get; set; }
    }
}
