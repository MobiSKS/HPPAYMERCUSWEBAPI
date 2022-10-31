using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.PayCode
{
    public class CancelPaycodeModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }

        [JsonPropertyName("ObjPayCodeForCancel")]
        [DataMember]
        public List<PayCodeForCancel> ObjPayCodeForCancel { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }


    public class PayCodeForCancel
    {

        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }


        [JsonPropertyName("PayCode")]
        [DataMember]
        public string PayCode { get; set; }

    }


    public class CancelPaycodeModelOutput : BaseClassOutput
    {

        

    }

}
