using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.COMCO
{
    public class GetAuthorizeCOMCOCreditOperationRoleRequestsDetailsModelInput:BaseClass
    {
        
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }
    }
    public class GetAuthorizeCOMCOCreditOperationRoleRequestsDetailsModelOutput
    {

        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }


        [JsonProperty("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }

        [JsonProperty("RequestedDate")]
        [DataMember]
        public string RequestedDate { get; set; }

        [JsonProperty("ApprovedBy")]
        [DataMember]
        public string ApprovedBy { get; set; }


        [JsonProperty("ApprovalDate")]
        [DataMember]
        public string ApprovalDate { get; set; }

        [JsonProperty("ApprovalRemarks")]
        [DataMember]
        public string ApprovalRemarks { get; set; }

    }
}
