using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.Merchant
{
    public class RejectedMerchantModelInput : BaseClass
    {
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }
    }

    public class RejectedMerchantModelOutput
    {

        [JsonProperty("ErpCode")]
        [DataMember]
        public string ErpCode { get; set; }


        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }


        [JsonProperty("MerchantTypeId")]
        [DataMember]
        public Int32 MerchantTypeId { get; set; }


        [JsonProperty("MerchantTypeName")]
        [DataMember]
        public string MerchantTypeName { get; set; }



        [JsonProperty("RetailOutletCity")]
        [DataMember]
        public string RetailOutletCity { get; set; }


        [JsonProperty("RegionalOfficeId")]
        [DataMember]
        public Int32 RegionalOfficeId { get; set; }


        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }


        [JsonProperty("Comments")]
        [DataMember]
        public string Comments { get; set; }

        [JsonProperty("RejectedDate")]
        [DataMember]
        public string RejectedDate { get; set; }

        [JsonProperty("CreatedDate")]
        [DataMember]
        public string CreatedDate { get; set; }

        [JsonProperty("RejectedBy")]
        [DataMember]
        public string RejectedBy { get; set; }
    }
}
