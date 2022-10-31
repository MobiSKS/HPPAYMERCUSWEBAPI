using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.DTP
{
    public class GetEnableDealerCreditSaleDetailsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class GetEnableDealerCreditSaleDetailsModelOutput
    {
        [JsonProperty("CustomerDetail")]

        public List<GetCustomerDetail> CustomerDetail { get; set; }

        [JsonProperty("MerchantDetail")]

        public List<GetMerchantDetail> MerchantDetail { get; set; }
    }

    public class GetCustomerDetail : BaseClassOutput
    {
        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }
    }
    public class GetMerchantDetail: BaseClassOutput
    {
        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }


        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("RetailOutletLocation")]
        [DataMember]
        public string RetailOutletLocation { get; set; }
    }


}
