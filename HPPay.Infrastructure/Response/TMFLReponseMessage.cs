using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.Infrastructure.Response
{
    [Serializable]
    [DataContract]
    public class TMFLReponseMessage
    {
        #region Public properties.
        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonProperty("ResponseMessage")]
        [DataMember]
        public string ResponseMessage { get; set; }
        #endregion
    }
}
