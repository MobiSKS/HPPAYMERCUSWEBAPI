using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.LoyaltyRedemption
{
    public  class GetAuthorizeFuelLoyaltyRedemptionDetailModelInput:BaseClass
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("Customertype")]
        [DataMember]
        public string Customertype { get; set; }


        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }


        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }


        [JsonPropertyName("RequestNumber")]
        [DataMember]
        public string RequestNumber { get; set; }


        [JsonPropertyName("UserType")]
        [DataMember]
        public string UserType { get; set; }

        [JsonPropertyName("Type")]
        [DataMember]
        public string Type { get; set; }


    }

    public class GetAuthorizeFuelLoyaltyRedemptionDetailModelOutput    
    {


        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }


        [JsonProperty("RequestNumber")]
        [DataMember]
        public string RequestNumber { get; set; }

        [JsonProperty("RequestedDate")]
        [DataMember]
        public string RequestedDate { get; set; }

        [JsonProperty("ProductName")]
        [DataMember]
        public string ProductName { get; set; }



        [JsonProperty("Points")]
        [DataMember]
        public string Points { get; set; }


        [JsonProperty("BalancePoints")]
        [DataMember]
        public string BalancePoints { get; set; }


        [JsonProperty("Amount")]
        [DataMember]
        public string Amount { get; set; }


    }

}
