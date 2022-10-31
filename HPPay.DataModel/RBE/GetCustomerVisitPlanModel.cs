using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.RBE
{
    public class GetCustomerVisitPlanModelInput:BaseClass
    {
        [JsonPropertyName("SearchByDate")]
        [DataMember]
        public string SearchByDate { get; set; }

        [JsonPropertyName("VisitNumber")]
        [DataMember]
        public string VisitNumber { get; set; }

        [JsonPropertyName("SearchByZoneId")]
        [DataMember]
        public string SearchByZoneId { get; set; }

        [JsonPropertyName("SearchByRegionId")]
        [DataMember]
        public string SearchByRegionId { get; set; }

        [JsonPropertyName("SearchByRbeId")]
        [DataMember]
        public string SearchByRbeId { get; set; }

        [JsonPropertyName("SearchByVisitType")]
        [DataMember]
        public string SearchByVisitType { get; set; }

        [JsonPropertyName("SearchByStatus")]
        [DataMember]
        public string SearchByStatus { get; set; }
    }
    public class GetCustomerVisitPlanModelOutput 
    {
        [JsonProperty("RBEId")]
        [DataMember]
        public string RBEId { get; set; }

        [JsonProperty("VisitNumber")]
        [DataMember]
        public string VisitNumber { get; set; }

        [JsonProperty("VisitType")]
        [DataMember]
        public string VisitType { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }
      
        [JsonProperty("VisitDate")]
        [DataMember]
        public string VisitDate { get; set; }

        [JsonProperty("VisitStatus")]
        [DataMember]
        public string VisitStatus { get; set; }


    }
}
