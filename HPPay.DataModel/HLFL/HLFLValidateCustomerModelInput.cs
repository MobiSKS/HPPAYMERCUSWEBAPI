using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace HPPay.DataModel.HLFL
{
    public  class HLFLValidateCustomerModelInput
    {
        [Required]
        [JsonPropertyName("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }
        [Required]
        [JsonPropertyName("PAN")]
        [DataMember]
        public string PAN { get; set; }
    }

    public class HLFLValidateCustomerModelOutPut
    { 
        [JsonProperty("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }

        [JsonProperty("CustomerList")]
        public List<HLFLCustomerList> CustomerList { get; set; }

        [JsonProperty("ResponseMessage")]
        [DataMember]
        public string ResponseMessage { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public int Status { get; set; }
    }
     public class HLFLValidateCustomerRespList
     {
        [JsonProperty("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }

        [JsonProperty("ResponseMessage")]
        [DataMember]
        public string ResponseMessage { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public int Status { get; set; } 
    }

    public class HLFLCustomerList
    {

        [JsonProperty("DTPCustomerId")]
        [DataMember]
        public string DTPCustomerID { get; set; }


        [JsonProperty("DTPCustomerName")]
        [DataMember]
        public string CustomerName { get; set; }


        [JsonProperty("ControlCardNo")]
        [DataMember]
        public string ControlCardNumber { get; set; }


        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }


        [JsonProperty("CustomerStatus")]
        [DataMember]
        public string CustomerStatus { get; set; }

    }


}
