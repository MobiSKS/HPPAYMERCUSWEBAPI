using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System;

namespace HPPay.DataModel.DICV
{
  
    public class DICVUnMappedOTCCardModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
    }
    public class TotalDICVCardDetail
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

    public class ViewDICVCardWiseDetail
    {
        [JsonProperty("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

        [JsonProperty("DealerName")]
        [DataMember]
        public string DealerName { get; set; }

        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("AllocationDate")]
        [DataMember]
        public string AllocationDate { get; set; }

        [JsonProperty("MappingDate")]
        [DataMember]
        public string MappingDate { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }


        [JsonProperty("VehicleRegNo")]
        [DataMember]
        public string VehicleRegNo { get; set; }

        [JsonProperty("VINNumber")]
        [DataMember]
        public string VINNumber { get; set; }



    }

    public class DICVUnMappedOTCCardModelOutput:BaseClassOutput
    {
        [JsonProperty("ObjDICVTotalCardDetail")]
        public List<TotalDICVCardDetail> ObjDICVTotalCardDetail { get; set; }

        [JsonProperty("ObjDICVViewCardDetail")]
        public List<ViewDICVCardWiseDetail> ObjDICVViewCardDetail { get; set; }

    }
}
