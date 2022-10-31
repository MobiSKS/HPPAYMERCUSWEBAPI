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
    public class PayCodeGeneratePayCodeDetailsForEGVAPIWithoutStartDateModelIntput
    {
        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [Required]
        [JsonPropertyName("PassWord")]
        [DataMember]
        public string PassWord { get; set; }


        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }



        [Required]
        [JsonPropertyName("NoOfPaycode")]
        [DataMember]
        public string NoOfPaycode { get; set; }

        ////        [Required]
        //[JsonPropertyName("StartDate")]
        //[DataMember]
        //public DateTime StartDate { get; set; }


        //[Required]
        //[JsonPropertyName("CreatedBy")]
        //[DataMember]
        //public string CreatedBy { get; set; }




    }
}
