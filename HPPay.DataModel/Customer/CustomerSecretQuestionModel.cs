using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.Customer
{
    public class GetCustomerSecretQuestionModelInput : BaseClass
    {
        
    }
    public class GetCustomerSecretQuestionModelOutput
    {
        [JsonProperty("SecretQuestionId")]
        [DataMember]
        public int SecretQuestionId { get; set; }

        [JsonProperty("SecretQuestionName")]
        [DataMember]
        public string SecretQuestionName { get; set; }
    }
}
