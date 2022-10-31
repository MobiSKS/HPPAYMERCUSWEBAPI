using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AshokLeyland
{
    public class GetALCustomerDetailModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class GetALCustomerDetailModelOutput 
    {

        [JsonProperty("CustomerID")]
        public string CustomerID { get; set; }

        [JsonProperty("IndividualOrgNameTitle")]
        public string IndividualOrgNameTitle { get; set; }

        [JsonProperty("IndividualOrgName")]
        public string IndividualOrgName { get; set; }

        [JsonProperty("NameOnCard")]
        public string NameOnCard { get; set; }

        [JsonProperty("CommunicationCityName")]
        public string CommunicationCityName { get; set; }

        [JsonProperty("CommunicationStateId")]
        public int CommunicationStateId { get; set; }

        [JsonProperty("CommunicationPhoneNo")]
        public string CommunicationPhoneNo { get; set; }

        [JsonProperty("CommunicationMobileNo")]
        public string CommunicationMobileNo { get; set; }

        [JsonProperty("CommunicationAddress1")]
        public string CommunicationAddress1 { get; set; }

        [JsonProperty("CommunicationAddress2")]
        public string CommunicationAddress2 { get; set; }

        [JsonProperty("CommunicationPincode")]
        public string CommunicationPincode { get; set; }

        [JsonProperty("CommunicationDistrictId")]
        public int CommunicationDistrictId { get; set; }

        [JsonProperty("CommunicationFax")]
        public string CommunicationFax { get; set; }

        [JsonProperty("CommunicationEmailid")]
        public string CommunicationEmailid { get; set; }

        [JsonProperty("ModifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonProperty("DealerCode")]
        public string DealerCode { get; set; }

        [JsonProperty("SalesExecutiveEmployeeID")]
        public string SalesExecutiveEmployeeID { get; set; }
    }
}
