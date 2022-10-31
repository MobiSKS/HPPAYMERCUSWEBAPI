using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace HPPay.Infrastructure.Response
{
    [Serializable]
    [DataContract]
    public class CustomerAPIReponseMessage
    {
        #region Public properties.
        [JsonProperty("responseCode")]
        [DataMember]
        public string responseCode { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }
        #endregion
    }
}
