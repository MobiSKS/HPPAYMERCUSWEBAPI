using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class ApprovalApproveCustomerAddressRequestsModelInput : BaseClass
    {
        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }

        [JsonPropertyName("ApprovedBy")]
        [DataMember]
        public string ApprovedBy { get; set; }

        [JsonPropertyName("TypeApprovalApproveCustomerAddressRequests")]
        [DataMember]
        public List<TypeApprovalApproveCustomerAddressRequests> TypeApprovalApproveCustomerAddressRequests { get; set; }
    }

    public class TypeApprovalApproveCustomerAddressRequests
    {

        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("Comments")]
        [DataMember]
        public string Comments { get; set; }

    }
    public class ApprovalApproveCustomerAddressRequestsModelOutput : BaseClassOutput
    {

    }
}
