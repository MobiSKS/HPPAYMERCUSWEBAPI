using System.Collections.Generic;
using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
namespace HPPay.DataModel.ConfigureAlert
{
    public class GetSMSAlertstoIndividualCardUsersDetailsModelInput: BaseClass
    {

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

       // [Required]
        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
    }

    public class GetSMSAlertstoIndividualCardUsersDetailsModelOutput 
    {
        [JsonProperty("CustomerDetails")]

        public List<CustomerDetails> CustomerDetails { get; set; }


        [JsonProperty("CardDetails")]
        
        public List<CardDetails> CardDetails { get; set; }

       
    }

    public class CustomerDetails : BaseClassOutput
    {
        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

       

      
    }
    public class CardDetails
    {
        [JsonProperty("cardNo")]
        [DataMember]
        public string cardNo { get; set; }

        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [JsonProperty("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }



    }
}
