using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Customer
{
    public class CustomerGetTransactionsDetailsModelInput : BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }


        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }


        [JsonPropertyName("TransTypes")]
        [DataMember]

        public List<TransTypes> TransTypes { get; set; }



    }

    public class TransTypes
    {

        [JsonPropertyName("TypeId")]
        [DataMember]
        public string TypeId { get; set; }


        [JsonPropertyName("TypeName")]
        [DataMember]
        public string TypeName { get; set; }
    }

    public class CustomerGetTransactionsDetailsModelOutput 
    {
        [JsonProperty("TransactionType")]
        [DataMember]
        public string TransactionType { get; set; }

        [JsonProperty("Amount")]
        [DataMember]
        public decimal Amount { get; set; }


    }
}
