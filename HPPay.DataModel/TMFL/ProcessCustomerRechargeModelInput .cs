using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HPPay.DataModel.TMFL
{
    public  class ProcessCustomerRechargeModelInput
    {
        [Required]
        [JsonPropertyName("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }

        [Required]
        [JsonPropertyName("TMFLCustomerID")]
        [DataMember]
        public string TMFLCustomerID { get; set; }

        [Required]
        [JsonPropertyName("FacilityNumber")]
        [DataMember]
        public string FacilityNumber { get; set; }

        [Required]
        [Range(1, 99999999999999.99, ErrorMessage = "Value must be between 1 to 50 Lac")]
        [RegularExpression("^[0-9]{1,8}([.][0-9]{1,2})?$", ErrorMessage = "Limit Value should be upto 2 decimal places only")]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [Required]
        [JsonPropertyName("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }

        [Required]
        [JsonPropertyName("TransactionNumber")]
        [DataMember]
        public string TransactionNumber { get; set; }



        [JsonPropertyName("Pan_Card")]
        [DataMember]
        public string Pan_Card { get; set; }

        [Required]
        [JsonPropertyName("HashKey")]
        [DataMember]
        public string HashKey { get; set; }
         



    }

    public class ProcessCustomerRechargeModelOutPut:BaseClassOutput
    {

        [JsonProperty("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }


        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


        [JsonProperty("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }


        [JsonProperty("TMFLCustomerID")]
        [DataMember]
        public string TMFLCustomerID { get; set; }


        [JsonProperty("FacilityNumber")]
        [DataMember]
        public string FacilityNumber { get; set; }


        [JsonProperty("TransactionNumber")]
        [DataMember]
        public string TransactionNumber { get; set; }


        [JsonProperty("DTPRefNumber")]
        [DataMember]
        public string DTPRefNumber { get; set; }

        [JsonProperty("ResponseMessage")]
        [DataMember]
        public string ResponseMessage { get; set; }

        

    }
}
