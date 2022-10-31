using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class GetCCMSBalAlertConfigurationInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class CCMSBalAlertConfigurationOutput
    {
        [JsonProperty("CCMSCustomerDetail")]
        public List<GetCCMSCustomerDetail> CCMSCustomerDetail { get; set; }

        [JsonProperty("CCMSAmountDetail")]
        public List<GetCCMSAmountDetail> CCMSAmountDetail { get; set; }

        //[JsonProperty("StatusOutput")]
        //public List<StatusOutput> StatusOutput { get; set; }

    }

    public class GetCCMSCustomerDetail
    {
        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

    }
    public class GetCCMSAmountDetail : BaseClassOutput
    {
        [JsonProperty("Amount")]
        [DataMember]
        public string Amount { get; set; }

    }

    //public class StatusOutput 
    //{

    //}
}
