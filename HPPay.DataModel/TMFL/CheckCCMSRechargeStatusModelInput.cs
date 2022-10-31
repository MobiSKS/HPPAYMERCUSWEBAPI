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
    public  class CheckCCMSRechargeStatusModelInput
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
        [JsonPropertyName("TransactionNumber")]
        [DataMember]
        public string TransactionNumber { get; set; }
    }

    public class CheckCCMSRechargeStatusModelOutPut : BaseClassOutput
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


        [JsonProperty("Amount")]
        [DataMember]
        public string Amount { get; set; }


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
