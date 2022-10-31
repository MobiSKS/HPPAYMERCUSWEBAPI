using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataModel.IdfcAPI
{
    public class GetFastagCreditLimitApprovalModelInput:BaseClass
    {


    }

    public class GetFastagCreditLimitApprovalModelOutput : BaseClassOutput
    {
        [JsonProperty("Customerid")]
        [DataMember]
        public string Customerid { get; set; }



        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }


        [JsonProperty("ExistingCreditLimit")]
        [DataMember]
        public string ExistingCreditLimit { get; set; }


        [JsonProperty("RequestedCreditLimit")]
        [DataMember]
        public string RequestedCreditLimit { get; set; }



        [JsonProperty("Requestedby")]
        [DataMember]
        public string Requestedby   { get; set; }


        [JsonProperty("RequestedDate")]
        [DataMember]
        public string   RequestedDate { get; set; }



        [JsonProperty("CCMSRechargeType")]
        [DataMember]
        public string CCMSRechargeType { get; set; }

        [JsonProperty("Remarks")]
        [DataMember]
        public string Remarks { get; set; }

    }

}
