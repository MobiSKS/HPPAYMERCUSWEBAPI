using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AccountStatment
{
    public class GetAccountStatmentRequestDetailsInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
 
    }
    public class GetAccountStatmentRequestDetailsOutPut
    {
        [JsonProperty("GetAccountStatmentRequest")]
        public List<GetAccountStatmentRequest> GetAccountStatmentRequest { get; set; }

        [JsonProperty("GetAccountStatmentRequestDetails")]
        public List<GetAccountStatmentRequestDetails> GetAccountStatmentRequestDetails { get; set; }
    }

    public class GetAccountStatmentRequest:BaseClassOutput
    {
        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }

        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; } 
    }

   


    public class GetAccountStatmentTypeInput : BaseClass
    {
    }
    public class GetAccountStatmentTypeOutPut:BaseClassOutput
    {
        [JsonProperty("TypeName")]
        [DataMember]
        public string TypeName { get; set; }

        [JsonProperty("TypeId")]
        [DataMember]
        public int TypeId { get; set; }

    }


    public class InsertAccountStatmentRequestModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }         

        [Required]
        [JsonPropertyName("StatementType")]
        [DataMember]
        public int StatementType { get; set; }


        [JsonPropertyName("CustomerSubType")]
        [DataMember]
        public int CustomerSubType { get; set; }          

    }
    public class InsertAccountStatmentRequestModelOutPut : BaseClassOutput
    {


    }
    public class GetAccountStatmentRequestDetails: BaseClassOutput
    { 
        [JsonPropertyName("ReqestId")]
        [DataMember]
        public string ReqestId { get; set; } 
         
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("OptedDate")]
        [DataMember]
        public string OptedDate { get; set; }         
         
        [JsonPropertyName("ActionName")]
        [DataMember]
        public string ActionName { get; set; }

        [Required]
        [JsonPropertyName("StatementType")]
        [DataMember]
        public string StatementType { get; set; }
    }

    public class UpdateAccountStatmentRequestModelInput:BaseClass
    { 

        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("StatementType")]
        [DataMember]
        public string StatementType { get; set; }

        [Required]
        [JsonPropertyName("RequestId")]
        [DataMember]
        public int RequestId { get; set; }

        [Required]
        [JsonPropertyName("IsActivate")]
        [DataMember]
        public int IsActivate { get; set; }
         
    }
    public class UpdateAccountStatmentRequestModelOutput:BaseClassOutput
    {

    }
    public class DownloadAccountStatmentInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("StatementType")]
        [DataMember]
        public string StatementType { get; set; }

        [Required]
        [JsonPropertyName("CustomerSubTypeId")]
        [DataMember]
        public int CustomerSubTypeId { get; set; }

        [JsonPropertyName("FinancialQtr")]
        [DataMember]
        public DateTime FinancialQtr { get; set; }

        [JsonPropertyName("Month")]
        [DataMember]
        public string Month { get; set; }
    }

    public class DownloadAccountStatmentOutput : BaseClassOutput
    {
        

    }


}
