using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.RBE
{
    public class RBEGetUserCreationApprovalForRBEModelInput:BaseClass

    {
     
        [JsonPropertyName("FirstName")]
        [DataMember]
        public string FirstName { get; set; }


        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }
    }

    public class RBEGetUserCreationApprovalForRBEModelOutput : BaseClassOutput
    {
        [JsonProperty("RBEId")]
        [DataMember]
        public string RBEId { get; set; }

        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonProperty("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        [DataMember]
        public string LastName { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }


        [JsonProperty("StateName")]
        [DataMember]
        public string StateName { get; set; }


    }


}
