using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ICICICreditPouch
{
    public class InitiateICICICreditPouchRechargeModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }
                
    }
    public class InitiateICICICreditPouchRechargeModelOutPut : BaseClassOutput
    {
        [JsonProperty("OrderId")]
        [DataMember]
        public string OrderId { get; set; }

        [JsonProperty("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonProperty("Mobile")]
        [DataMember]
        public string Mobile { get; set; }

    }
    public class InitPayment_Input
    {
        [JsonPropertyName("Response")]
        [DataMember]
        public Object Response { get; set; }

        [JsonPropertyName("API_Status")]
        [DataMember]
        public bool API_Status { get; set; }


        [JsonPropertyName("API_Message")]
        [DataMember]
        public object API_Message { get; set; }


        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [JsonPropertyName("Currency")]
        [DataMember]
        public string Currency { get; set; }

        [JsonPropertyName("Mobile_No")]
        [DataMember]
        public string Mobile_No { get; set; }

        [JsonPropertyName("Merchant_Id")]
        [DataMember]
        public string Merchant_Id { get; set; }

        [JsonPropertyName("Transaction_For")]
        [DataMember]
        public string Transaction_For { get; set; }

        [JsonPropertyName("Raw_Transaction_Id")]
        [DataMember]
        public string Raw_Transaction_Id { get; set; }

    }

    public class ICICICPUsreLogin
    {
        [Required]
        public string cp_userid { get; set; }
    }

    public class ICICIApiRequestResponse
    {
        public string BankName { get; set; }
        public string TransactionId { get; set; }
        public string request { get; set; }
        public string response { get; set; }
        public string apiurl { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
    }
    public class ICICICPPGLoginResponse
    {
        public string access_token { get; set; }
        public string message { get; set; }
        public string refresh_token { get; set; }
    }
    public class ICICIInitPayment_Output
    {

        [DataMember]
        public Object Response { get; set; }


        [DataMember]
        public bool API_Status { get; set; }


        [DataMember]
        public object API_Message { get; set; }
    }

    
}
