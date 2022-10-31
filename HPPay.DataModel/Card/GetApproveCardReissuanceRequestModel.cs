using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Card
{
    public class GetApproveCardReissuanceRequestModelInput : BaseClass
    {

        [JsonPropertyName("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }

        [JsonPropertyName("Status")]
        [DataMember]
        public int Status { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

    }

    public class GetApproveCardReissuanceRequestModelOutput : BaseClassOutput
    {
        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }

        [JsonProperty("VehicleNo_UserName")]
        [DataMember]
        public string VehicleNo_UserName { get; set; }


        [JsonProperty("UserNo")]
        [DataMember]
        public string UserNo { get; set; }

        [JsonProperty("VehicleType")]
        [DataMember]
        public string VehicleType { get; set; }

        [JsonProperty("YearOfReg")]
        [DataMember]
        public string YearOfReg { get; set; }


        [JsonProperty("Manufacturer")]
        [DataMember]
        public string Manufacturer { get; set; }



        [JsonProperty("Owned_Attached")]
        [DataMember]
        public string Owned_Attached { get; set; }


        [JsonProperty("Live")]
        [DataMember]
        public string Live { get; set; }

        [JsonProperty("ReissueReason")]
        [DataMember]
        public string ReissueReason { get; set; }

        [JsonProperty("RequestStatus")]
        [DataMember]
        public string RequestStatus { get; set; }


        [JsonProperty("ApproverRemarks")]
        [DataMember]
        public string ApproverRemarks { get; set; }



    }
}
