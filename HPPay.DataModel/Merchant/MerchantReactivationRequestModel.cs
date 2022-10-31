using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantReactivationRequestModelInput : BaseClass
    {
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("TypeRequestForMerchantReactivation")]
        [DataMember]
        public List<TypeRequestForMerchantReactivation> TypeRequestForMerchantReactivation { get; set; }

    }

    public class TypeRequestForMerchantReactivation
    {

        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonPropertyName("Remark")]
        [DataMember]
        public string Remark { get; set; }

        //[JsonPropertyName("RcCopy")]
        //[DataMember]
        //public List<IFormFile> RcCopy { get; set; }

    }

    public class MerchantReactivationRequestModelOutput : BaseClassOutput
    {

    }

}
