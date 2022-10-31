using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace HPPay.DataModel.HLFL
{
    public  class HLFLProcessCustomerRechargeModelInPut
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
        [JsonPropertyName("HLFLCustomerID")]
        [DataMember]
        public string HLFLCustomerID { get; set; }

        [Required]
        [RegularExpression(@"^([FCfc]){2}([0-9]){7}$", ErrorMessage = "Invalid Facility Number.")]
        [JsonPropertyName("FacilityNumber")]
        [DataMember]
        public string FacilityNumber { get; set; }

        [Required] 
        [Range(1.00, 5000000.00, ErrorMessage = "Value must be between 1 to 50 Lac")]
        [RegularExpression("^[0-9]{1,8}([.][0-9]{1,2})?$", ErrorMessage = "Limit Value should be upto 2 decimal places only")]
        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }

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
    public class HLFLProcessCustomerRechargeModelOutPut
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


        [JsonProperty("HLFLCustomerID")]
        [DataMember]
        public string HLFLCustomerID { get; set; }


        [JsonProperty("FacilityNumber")]
        [DataMember]
        public string FacilityNumber { get; set; }


        [JsonProperty("TransactionNumber")]
        [DataMember]
        public string TransactionNumber { get; set; }


        [JsonProperty("DTPRefNumber")]
        [DataMember]
        public string DTPRefNumber { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public int Status { get; set; }

        [JsonProperty("ResponseMessage")]
        [DataMember]
        public string ResponseMessage { get; set; }

        [JsonProperty("Balance")]
        [DataMember]
        public string Balance { get; set; }


    }

     
}
