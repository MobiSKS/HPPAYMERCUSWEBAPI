using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.COMCO
{
    public class GetCOMCOLimitSetRequestDetailsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


        [Required]
        [JsonPropertyName("LimitSetMode")]
        [DataMember]
        public int LimitSetMode { get; set; }

    }
    public class GetCOMCOLimitSetRequestDetailsModelOutput:BaseClassOutput
    {
        
        [JsonProperty("Amount")]
        [DataMember]
        public double Amount { get; set; }


    
        [JsonProperty("CautionAmount")]
        [DataMember]
        public double CautionAmount { get; set; }

   
        [JsonProperty("InvoiceIntervalId")]
        [DataMember]
        public int InvoiceIntervalId { get; set; }

        [JsonProperty("FileName")]
        [DataMember]
        public string FileName { get; set; }

      
        [JsonProperty("ServicesCharges")]
        [DataMember]
        public double ServicesCharges { get; set; }


        [JsonProperty("FinanceCharges")]
        [DataMember]
        public double FinanceCharges { get; set; }

  
        [JsonProperty("COMCOPackageID")]
        [DataMember]
        public string COMCOPackageID { get; set; }
    }
}
