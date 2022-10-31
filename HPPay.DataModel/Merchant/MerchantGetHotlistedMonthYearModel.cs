using Newtonsoft.Json;
using System.Runtime.Serialization;


namespace HPPay.DataModel.Merchant
{
    public class MerchantGetHotlistedMonthYearModelInput:BaseClass
    {

    }

    public class MerchantGetHotlistedMonthYearModelOuput:BaseClassOutput
    {

        [JsonProperty("DateValue")]
        [DataMember]
        public string DateValue { get; set; }

        [JsonProperty("Date")]
        [DataMember]
        public string Date { get; set; }
    }
}
