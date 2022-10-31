using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.DICV
{
    public class GetDICVUploadKycDocumentsModelInput : BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

    }
    public class GetDICVUploadKycDocumentsModelOutput : BaseClassOutput
    {
        [JsonProperty("IdProofType")]
        [DataMember]
        public string IdProofType { get; set; }

        [JsonProperty("IdProofName")]
        [DataMember]
        public string IdProofName { get; set; }

        [JsonProperty("IdProof")]
        [DataMember]
        public string IdProof { get; set; }

        [JsonProperty("AddressProofType")]
        [DataMember]
        public string AddressProofType { get; set; }

        [JsonProperty("AddressProof")]
        [DataMember]
        public string AddressProof { get; set; }

        [JsonProperty("PanCardType")]
        [DataMember]
        public string PanCardType { get; set; }

        [JsonProperty("PanCard")]
        [DataMember]
        public string PanCard { get; set; }

       
    }
}
