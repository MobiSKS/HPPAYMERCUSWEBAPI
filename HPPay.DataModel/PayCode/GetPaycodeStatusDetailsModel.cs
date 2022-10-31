using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.PayCode
{
   public class GetPaycodeStatusDetailsModelInput:BaseClass
    {
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }

        [JsonPropertyName("PaycodeStatus")]
        [DataMember]
        public int PaycodeStatus { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [JsonPropertyName("Paycode")]
        [DataMember]
        public string Paycode { get; set; }

        [JsonPropertyName("PaycodeType")]
        [DataMember]
        public int PaycodeType { get; set; }

    }


    public class GetPaycodeStatusDetailsModelOutput 
    {
        [JsonProperty("PayCode")]
        [DataMember]
        public string PayCode { get; set; }

        [JsonProperty("Amount")]
        [DataMember]
        public string Amount { get; set; }



        [JsonProperty("PaycodeStatus")]
        [DataMember]
        public string PaycodeStatus { get; set; }



        [JsonProperty("GenerationDate")]
        [DataMember]
        public string GenerationDate { get; set; }


        [JsonProperty("ExpiryDate")]
        [DataMember]
        public string ExpiryDate { get; set; }

        [JsonProperty("EffectiveStartDate")]
        [DataMember]
        public string EffectiveStartDate { get; set; }

        [JsonProperty("Balance")]
        [DataMember]
        public decimal Balance { get; set; }



    }


}
