using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.LoyaltyRedemption
{
    public class GetLoyaltyRedemptionModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


        [JsonPropertyName("Customertype")]
        [DataMember]
        public string Customertype { get; set; }

        [JsonPropertyName("UserType")]
        [DataMember]
        public string UserType { get; set; }

        [JsonPropertyName("Type")]
        [DataMember]
        public string Type { get; set; }



    }
    public class GetLoyaltyRedemptionModelOutput : BaseClassOutput
    {
        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("CustomerAddress")]
        [DataMember]
        public string CustomerAddress { get; set; }

        [JsonProperty("RegionalOffice")]
        [DataMember]
        public string RegionalOffice { get; set; }

        [JsonProperty("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }

        [JsonProperty("AvailableLoyaltyPoints")]
        [DataMember]
        public string AvailableLoyaltyPoints { get; set; }

        [JsonProperty("CCMSBalance")]
        [DataMember]
        public string CCMSBalance { get; set; }


        [JsonProperty("CustomerStatus")]
        [DataMember]
        public string CustomerStatus { get; set; }

    }
}
