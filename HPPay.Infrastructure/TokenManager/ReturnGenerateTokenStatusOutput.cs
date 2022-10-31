using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Runtime.Serialization;
//using System.Web.Http.ModelBinding;

namespace HPPay.Infrastructure.TokenManager
{

    public class ReturnGenerateTokenStatusOutput
    {

        [JsonProperty("Success")]
        [DataMember]
        public bool Success { get; set; }

        [JsonProperty("Message")]
        [DataMember]
        public string Message { get; set; }

        [JsonProperty("Status_Code")]
        [DataMember]
        public int Status_Code { get; set; }

        [JsonProperty("Internel_Status_Code")]
        [DataMember]
        public int Internel_Status_Code { get; set; }

        [JsonProperty("Method_Name")]
        [DataMember]
        public string Method_Name { get; set; }

        [JsonProperty("Token")]
        [DataMember]
        public string Token { get; set; }

        [JsonProperty("Model_State")]
        [DataMember]
        public ModelStateDictionary Model_State { get; set; }
    }
}
