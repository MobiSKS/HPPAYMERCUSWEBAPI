using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.IdfcAPI
{
    public class GetBankCreditLimitModelInput:BaseClass
    {

        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }

    }


    public class GetBankCreditLimitModelOutput : BaseClassOutput
    {

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("ExistingCreditLimit")]
        [DataMember]
        public string ExistingCreditLimit { get; set; }

        [JsonProperty("Outstanding")]
        [DataMember]
        public string Outstanding { get; set; }

        [JsonProperty("CreditLimitBalance")]
        [DataMember]
        public string CreditLimitBalance { get; set; }


        [JsonProperty("CCMSRechargeType")]
        [DataMember]
        public string CCMSRechargeType { get; set; }


        [JsonProperty("RequestedCreditLimit")]
        [DataMember]
        public string RequestedCreditLimit { get; set; }

        [JsonProperty("RequestStatus")]
        [DataMember]
        public string RequestStatus { get; set; }

    }
}
