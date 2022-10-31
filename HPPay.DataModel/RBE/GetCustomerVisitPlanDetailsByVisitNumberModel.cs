using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.RBE
{
    public class GetCustomerVisitPlanDetailsByVisitNumberModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("VisitNumber")]
        [DataMember]
        public string VisitNumber { get; set; }
    }
    public class GetCustomerVisitPlanDetailsByVisitNumberModelOutput 
    {
        [JsonProperty("RBEName")]
        [DataMember]
        public string RBEName { get; set; }

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

        [JsonProperty("PhoneNo")]
        [DataMember]
        public string PhoneNo { get; set; }

        [JsonProperty("VisitDate")]
        [DataMember]
        public string VisitDate { get; set; }

        [JsonProperty("VisitStatus")]
        [DataMember]
        public string VisitStatus { get; set; }


        [JsonProperty("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonProperty("CustomerAddress")]
        [DataMember]
        public string CustomerAddress { get; set; }


        [JsonProperty("CustomerCity")]
        [DataMember]
        public string CustomerCity { get; set; }

        [JsonProperty("CustomerState")]
        [DataMember]
        public string CustomerState { get; set; }

        [JsonProperty("CustomerDistrict")]
        [DataMember]
        public string CustomerDistrict { get; set; }

        [JsonProperty("Pincode")]
        [DataMember]
        public string Pincode { get; set; }

        [JsonProperty("VisitObjective")]
        [DataMember]
        public string VisitObjective { get; set; }

    }
}
