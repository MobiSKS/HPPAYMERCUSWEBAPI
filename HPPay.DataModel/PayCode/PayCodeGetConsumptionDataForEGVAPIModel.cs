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
    public  class PayCodeGetConsumptionDataForEGVAPIModelInput
    {
        [Required]
        [JsonPropertyName("username")]
        [DataMember]
        public string username { get; set; }

        [Required]
        [JsonPropertyName("password")]
        [DataMember]
        public string password { get; set; }


        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }


    }


    public class PayCodeGetConsumptionDataForEGVAPIModelOutput//:EGVAPIBaseClassOutput
    {



        //[JsonProperty("consumptionRes")]
        //public List<GetPayCodeGetConsumptionDataForEGVAPIModelOutput> consumptionRes { get; set; }

        [JsonProperty("consumptionRes")]
        public GetPayCodeGetConsumptionDataForEGVAPIModelOutput consumptionRes { get; set; }

        [JsonProperty("transactionsDetails")]
        public List<GettransactionsDetailsOutput> transactionsDetails { get; set; }


    }

    public class GetPayCodeGetConsumptionDataForEGVAPIModelOutput: EGVAPIBaseClassOutput
    {

        [JsonProperty("headerDetails")]
        public GetheaderDetailsOutput headerDetails { get; set; }


    }

    public class GetheaderDetailsOutput 

    {

        //headerDetails

        [JsonProperty("numberOfRecords")]
        [DataMember]
        public string numberOfRecords { get; set; }

        [JsonProperty("sumOfAmount")]
        [DataMember]
        public string sumOfAmount { get; set; }


        [JsonProperty("webServiceCalId")]
        [DataMember]
        public string webServiceCalId { get; set; }




    }



    public class GettransactionsDetailsOutput

    {

        //headerDetails

        [JsonProperty("paycode")]
        [DataMember]
        public string paycode { get; set; }

        [JsonProperty("merchantId")]
        [DataMember]
        public string merchantId { get; set; }


        [JsonProperty("cardNumber")]
        [DataMember]
        public string cardNumber { get; set; }



        [JsonProperty("terminalID")]
        [DataMember]
        public string terminalID { get; set; }


        [JsonProperty("batchID")]
        [DataMember]
        public string batchID { get; set; }


        [JsonProperty("batchTransactionNumber")]
        [DataMember]
        public string batchTransactionNumber { get; set; }

        [JsonProperty("merchantName")]
        [DataMember]
        public string merchantName { get; set; }

        [JsonProperty("merchantPlace")]
        [DataMember]
        public string merchantPlace { get; set; }


        [JsonProperty("amount")]
        [DataMember]
        public string amount { get; set; }

        
        [JsonProperty("odometer")]
        [DataMember]
        public string odometer { get; set; }

        [JsonProperty("certificateNumber")]
        [DataMember]
        public string certificateNumber { get; set; }

        [JsonProperty("settlementDate")]
        [DataMember]
        public string settlementDate { get; set; }


        [JsonProperty("transactionDate")]
        [DataMember]
        public string transactionDate { get; set; }


        


    }


}
