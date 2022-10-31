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
    public class GetVECustomerDetailForVerificationModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("StateID")]
        [DataMember]
        public int StateID { get; set; }

        [JsonPropertyName("FormNumber")]
        [DataMember]
        public string? FormNumber { get; set; }

        [JsonPropertyName("CustomerName")]
        [DataMember]
        public string? CustomerName { get; set; }

        [Required]
        [JsonPropertyName("Status")]
        [DataMember]
        public int Status { get; set; }
    }

    public class GetVECustomerDetailForVerificationModelOutput : BaseClassOutput
    {
        [JsonProperty("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }
        [JsonProperty("CustomerAddress")]
        [DataMember]
        public string CustomerAddress { get; set; }
        [JsonProperty("PhoneNo")]
        [DataMember]
        public string PhoneNo { get; set; }
        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonProperty("Remarks")]
        [DataMember]
        public string Remarks { get; set; }

    }

    public class GetVECustomerStatusDetailInput : BaseClass
    {
    }
    public class GetVECustomerStatusDetailOutput
    {
        [JsonProperty("StatusId")]
        [DataMember]
        public string StatusId { get; set; }

        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }

    }
}
