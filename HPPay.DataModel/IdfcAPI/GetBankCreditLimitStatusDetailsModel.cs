using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.IdfcAPI
{
    public class GetBankCreditLimitStatusDetailsModelInput:BaseClass
    {
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }

        [JsonPropertyName("Status")]
        [DataMember]
        public string Status { get; set; }

    }



    public class GetBankCreditLimitStatusDetailsModelOutput: BaseClassOutput
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


        [JsonProperty("RequestedLimit")]
        [DataMember]
        public string RequestedLimit { get; set; }



        [JsonProperty("RequestedDate")]
        [DataMember]
        public string RequestedDate { get; set; }

        [JsonProperty("ApprovedDate")]
        [DataMember]
        public string ApprovedDate { get; set; }


        [JsonProperty("CCMSRechargeType")]
        [DataMember]
        public string CCMSRechargeType { get; set; }

        [JsonProperty("Remarks")]
        [DataMember]
        public string Remarks { get; set; }
    }

}
