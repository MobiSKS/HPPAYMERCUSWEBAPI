using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Transactions;
using HPPay.DataModel.Merchant;
using System.Collections.Generic;

namespace HPPay.DataModel.HLFL
{
    public class HLFLInsertRequestResponseModelInput
    {
         
        [JsonPropertyName("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }
         
        [JsonPropertyName("Request")]
        [DataMember]
        public string Request { get; set; }
         
        [JsonPropertyName("Response")]
        [DataMember]
        public string Response { get; set; }

        [JsonPropertyName("APIName")]
        [DataMember]
        public string APIName { get; set; }

        [JsonPropertyName("APIUrl")]
        [DataMember]
        public string APIUrl { get; set; }

        [JsonPropertyName("OrderId")]
        [DataMember]
        public string OrderId { get; set; }

        [JsonPropertyName("HLFLRequestID")]
        [DataMember]
        public string HLFLRequestID { get; set; }

        [JsonPropertyName("AggrCustomerID")]
        [DataMember]
        public string AggrCustomerID { get; set; }

        [JsonPropertyName("ResponseMessage")]
        [DataMember]
        public string ResponseMessage { get; set; }

        [Required]        
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; } 
    }

    public class HLFLInsertRequestResponseModel
    {
        
        [JsonProperty("Status")]
        [DataMember]
        public int Status { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }

        [JsonProperty("Response")]
        [DataMember]
        public string Response { get; set; }

        [JsonProperty("OrderId")]
        [DataMember]
        public string OrderId { get; set; }

        [JsonProperty("Id")]
        [DataMember]
        public string Id { get; set; }
    }
    public class HLFLCheckTransactionStatusInputModel:BaseClass
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [JsonPropertyName("OrderId")]
        [DataMember]
        public string OrderId { get; set; }


        [JsonPropertyName("HLFLReferenceId")]
        [DataMember]
        public string HLFLReferenceId { get; set; }

        [JsonPropertyName("TransactionSource")]
        [DataMember]
        public string TransactionSource { get; set; }

        [JsonPropertyName("TransactionStatus")]
        [DataMember]
        public string TransactionStatus { get; set; }

    }


    public class HLFLCheckTransactionStatusOutPutModel:HLFLAPIBaseClassOutput
    {

        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("ThirdPartyCustomerID")]
        [DataMember]
        public string ThirdPartyCustomerID { get; set; }

        [JsonProperty("HLFLReferenceId")]
        [DataMember]
        public string HLFLReferenceId { get; set; }

        [JsonProperty("TransactionSource")]
        [DataMember]
        public string TransactionSource { get; set; }

        [JsonProperty("OrderId")]
        [DataMember]
        public string OrderId { get; set; }

        [JsonProperty("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [JsonProperty("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }


        [JsonProperty("TransactionStatus")]
        [DataMember]
        public string TransactionStatus { get; set; }
    }

    public class HLFLGetStatusAndSourceInPutModel:BaseClass
    {
    }
    public class HLFLGetStatusAndSourceOutPutModel 
    {


        [JsonProperty("GetStatus")]
        public List<HLFLGetStatusOutput> GetStatus { get; set; }

        [JsonProperty("GetSourceOutPut")]
        public List<HLFLGetSourceOutPut> GetSourceOutPut { get; set; }

        [JsonProperty("GetEmail")]
        public List<HLFLEmailOutPut> GetEmail { get; set; }

    }

    public class HLFLGetStatusOutput
    {
        [JsonProperty("TransactionStatusId")]
        [DataMember]
        public string TransactionStatusId { get; set; }

        [JsonProperty("TransactionStatus")]
        [DataMember]
        public string TransactionStatus { get; set; }
    }

    public class HLFLGetSourceOutPut
    {
        [JsonProperty("TransactionSourceId")]
        [DataMember]
        public string TransactionSourceId { get; set; }

        [JsonProperty("TransactionSource")]
        [DataMember]
        public string TransactionSource { get; set; }
    }
    public class HLFLEmailOutPut
    {
        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }
    }

    public class HLFLInsertSendEmailLogInputModel : BaseClass
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("EmailTo")]
        [DataMember]
        public string EmailTo { get; set; }

        [JsonPropertyName("EmailCC")]
        [DataMember]
        public string EmailCC { get; set; }

        [JsonPropertyName("OrderId")]
        [DataMember]
        public string OrderId { get; set; }

        [JsonPropertyName("OrderId")]
        [DataMember]
        public string HLFLReferenceId { get; set; }

        [JsonPropertyName("EmailSubject")]
        [DataMember]
        public string EmailSubject { get; set; }

        [JsonPropertyName("EmailMessage")]
        [DataMember]
        public string EmailMessage { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

    }

    public class HLFLInsertSendEmailLogOutModel : BaseClassOutput
    {
         

    }


}
