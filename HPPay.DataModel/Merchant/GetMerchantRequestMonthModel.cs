using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public  class GetMerchantRequestMonthModelInput:BaseClass
    {

    }

    public class GetMerchantRequestMonthModelOutput 
    {
        [JsonProperty("StatmentTypeId")]
        [DataMember]
        public int StatmentTypeId { get; set; }

        [JsonProperty("StatementType")]
        [DataMember]
        public string StatementType { get; set; }
    }
}
