using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.VolvoEicher
{
    public class VEVerifyCustomerDocumentModelInput:BaseClass
    {
        [JsonPropertyName("StateId")]
        [DataMember]
        public string StateId { get; set; }

        [JsonPropertyName("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

        [JsonPropertyName("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonPropertyName("CustomerStatus")]
        [DataMember]
        public string CustomerStatus { get; set; }

    }
    //FormNumber	CustomerID	CustomerName	CustomerAddress	PhoneNo	MobileNo
    public class GetVEVerifyCustomerDocumentModelOutput : BaseClassOutput
    {
        [JsonProperty("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("CustomerAddress")]
        [DataMember]
        public string CustomerAddress { get; set; }

        [JsonProperty("PhoneNo")]
        [DataMember]
        public string PhoneNo { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }
    }
}
