using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.Merchant
{
    public class MerchantRequestYearModelInput:BaseClass
    {

    }

    public class MerchantRequestYearModeOutput 
    {
        [JsonProperty("year")]
        [DataMember]
        public string year { get; set; }

    }
}
