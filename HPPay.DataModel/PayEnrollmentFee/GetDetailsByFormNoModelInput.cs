using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace HPPay.DataModel.PayEnrollmentFee
{
    public class GetDetailsByFormNoModelInput
    {    
        [JsonPropertyName("FormNo")]
        [DataMember]
        public string FormNo { get; set; } 
    }

    public class GetDetailsByFormNoModelOutput:BaseClassOutput
    {
       

        [JsonProperty("OrderId")]
        [DataMember]
        public string OrderId { get; set; }

        [JsonProperty("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

        [JsonProperty("CommunicationEmailid")]
        [DataMember]
        public string CommunicationEmailid { get; set; }

        [JsonProperty("CommunicationMobileNo")]
        [DataMember]
        public string CommunicationMobileNo { get; set; }

    }    
        public class GetEnrollmentFeeAmountInput
        {
        [JsonPropertyName("NoOfCard")]
        [DataMember]
        public string NoOfCard { get; set; }
         }

    public class GetEnrollmentFeeAmountOutPut
    {
        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }
    }

    public class InsertFeeDetailsModelInput
    {
        
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("FormNo")]
        [DataMember]
        public string FormNo { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }

        [JsonPropertyName("NoOfCard")]
        [DataMember]
        public string NoOfCard { get; set; }

        [JsonPropertyName("SourceType")]
        [DataMember]
        public string SourceType { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("NoOfCards")]
        [DataMember]
        public string NoOfCards { get; set; }  



    }
    public class InsertFeeDetailsModelOutput:BaseClassOutput
    {
         
    }
}
