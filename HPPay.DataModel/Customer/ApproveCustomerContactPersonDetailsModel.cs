using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class ApproveCustomerContactPersonDetailsModelInput : BaseClass
    {
        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }



        [JsonPropertyName("TypeApproveCustomerContactPersonDetails")]
        [DataMember]
        public List<TypeApproveCustomerContactPersonDetails> TypeApproveCustomerContactPersonDetails { get; set; }
    }

    public class TypeApproveCustomerContactPersonDetails
    {

        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("Comments")]
        [DataMember]
        public string Comments { get; set; }

    }
    public class ApproveCustomerContactPersonDetailsModelOutput : BaseClassOutput
    {

    }
}
