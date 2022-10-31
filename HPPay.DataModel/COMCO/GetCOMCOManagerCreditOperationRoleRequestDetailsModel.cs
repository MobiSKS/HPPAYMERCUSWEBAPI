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
    public class GetCOMCOManagerCreditOperationRoleRequestDetailsModelInput:BaseClass
    {
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }


        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

    }
    public class GetCOMCOManagerCreditOperationRoleRequestDetailsModelOutput : BaseClassOutput
    {
        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [JsonProperty("RequestDate")]
        [DataMember]
        public string RequestDate    { get; set; }

        [JsonProperty("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }

        [JsonProperty("RequesterRemarks")]
        [DataMember]
        public string RequesterRemarks { get; set; }

    }

}
