using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Merchant
{
    public class GetCCMSRechargebyMobiledispenserModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [JsonPropertyName("BankNameId")]
        [DataMember]
        public int BankNameId { get; set; }


    }

    public class GetCCMSRechargebyMobiledispenserModelOutput : BaseClassOutput
    {
        [JsonProperty("OrderId")]
        [DataMember]
        public string OrderId { get; set; }

        [JsonProperty("Response")]
        [DataMember]
        public ApiRequestResponse Response { get; set; }
    }


    public class ApiRequestResponse
    {
        public string BankName { get; set; }
        public string TransactionId { get; set; }
        public string request { get; set; }
        public object response { get; set; }
        public string apiurl { get; set; }
        public string UserId { get; set; }
        public string request_Hash { get; set; }
        public string accessCode { get; set; }
        public string CustomerId { get; set; }
        public string ControlCardNo { get; set; }
        public decimal Amount { get; set; }


    }
    public class CPPGLoginResponse
    {

        public string access_token { get; set; }
        public string message { get; set; }
        public string refresh_token { get; set; }
    }
}
