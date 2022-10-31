using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Card
{
    public class GetCardBalanceModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }
    public class GetCardBalanceModelOutput : BaseClassOutput
    {
    
        [JsonProperty("Cardno")]
        [DataMember]
        public string Cardno { get; set; }

        [JsonProperty("CardBalance")]
        [DataMember]
        public string CardBalance { get; set; }


        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [JsonProperty("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }
        

    }
}
