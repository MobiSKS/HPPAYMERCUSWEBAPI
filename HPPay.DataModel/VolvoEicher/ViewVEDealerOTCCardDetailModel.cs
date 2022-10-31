using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.VolvoEicher
{
    public class ViewVEDealerOTCCardDetailModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
    }
    public class TotalVECardDetail
    {
        [JsonProperty("TotalAllocatedCards")]
        [DataMember]
        public Int32 TotalAllocatedCards { get; set; }

        [JsonProperty("TotalMappedCards")]
        [DataMember]
        public Int32 TotalMappedCards { get; set; }


        [JsonProperty("TotalUnmappedCards")]
        [DataMember]
        public Int32 TotalUnmappedCards { get; set; }
    }

    public class ViewVECardMerchantDetail
    {
        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("AllocationDate")]
        [DataMember]
        public string AllocationDate { get; set; }

        [JsonProperty("MappingDate")]
        [DataMember]
        public string MappingDate { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }


        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

    }

    public class ViewVEDealerOTCCardDetailModelOutput
    {
        [JsonProperty("ObjVETotalCardDetail")]
        public List<TotalVECardDetail> ObjVETotalCardDetail { get; set; }

        [JsonProperty("ObjVEViewCardDetail")]
        public List<ViewVECardMerchantDetail> ObjVEViewCardDetail { get; set; }

    }
}
