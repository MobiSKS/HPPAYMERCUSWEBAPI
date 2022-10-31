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
    public class PayCodeGeneratePayCodeDetailsForEGVAPIModelInput
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

        [Required]
        [JsonPropertyName("StartDate")]
        [DataMember]
        public string StartDate { get; set; }
        
        
        //[Required]
        //[JsonPropertyName("CreatedBy")]
        //[DataMember]
        //public string CreatedBy { get; set; }



    }


    public class PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput: EGVAPIBaseClassOutput
    {
        //[JsonProperty("responseCode")]
        //[DataMember]
        //public int responseCode { get; set; }

        //[JsonProperty("responseMessage")]
        //[DataMember]
        //public string responseMessage { get; set; }


        [JsonProperty("voucherDetails")]
        public List<GetPayCodeGeneratePayCodeDetailsForEGVAPIModelOutput> voucherDetails { get; set; }


    }



    public class GetPayCodeGeneratePayCodeDetailsForEGVAPIModelOutput
    {
        [JsonProperty("amount")]
        [DataMember]
        public string amount { get; set; }

        [JsonProperty("productName")]
        [DataMember]
        public string productName { get; set; }


        [JsonProperty("paycode")]
        [DataMember]
        public string paycode { get; set; }



        [JsonProperty("paycodeExpiryDate")]
        [DataMember]
        public string paycodeExpiryDate { get; set; }

       
    }

    }
