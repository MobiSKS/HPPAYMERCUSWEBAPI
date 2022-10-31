using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.ParentCustomer
{
    public  class TransactionDetailsModelInput
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("TransactionId")]
        [DataMember]
        public string TransactionId { get; set; }
    }

    public class TransactionDetailsModelOutPut:BaseClassOutput
    {

        [JsonProperty("TransactionId")]
        [DataMember]
        public string TransactionId { get; set; }

        [JsonProperty("Name")]
        [DataMember]
        public string Name { get; set; }




        [JsonProperty("Location")]
        [DataMember]
        public string Location { get; set; }



        [JsonProperty("City")]
        [DataMember]
        public string City { get; set; }


        [JsonProperty("District")]
        [DataMember]
        public string District { get; set; }



        [JsonProperty("NH")]
        [DataMember]
        public string NH { get; set; }


        [JsonProperty("State")]
        [DataMember]
        public string State { get; set; }


    }
}
