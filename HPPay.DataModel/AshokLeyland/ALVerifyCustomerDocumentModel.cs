using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AshokLeyland
{

    public class ALVerifyCustomerDocumentModelInput : BaseClass    {

        //StateId ,FormNumber ,CustomerName ,CustomerStatus
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
    public class GetALVerifyCustomerDocumentModelOutput : BaseClassOutput
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
