using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.TMS
{
    public class GetDetailsForCustomerUpdateModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }
    public class GetDetailsForCustomerUpdateModelOutput:BaseClassOutput
    {
        [JsonProperty("CustomerReferenceNo")]
        [DataMember]
        public long CustomerReferenceNo { get; set; }

        [JsonProperty("TBEntityId")]
        [DataMember]
        public int TBEntityId { get; set; }

        [JsonProperty("TBEntityName")]
        [DataMember]
        public string TBEntityName { get; set; }

        [JsonProperty("CommunicationAddress1")]
        [DataMember]
        public string CommunicationAddress1 { get; set; }

        [JsonProperty("CommunicationAddress2")]
        [DataMember]
        public string CommunicationAddress2 { get; set; }

        [JsonProperty("CommunicationAddress3")]
        [DataMember]
        public string CommunicationAddress3 { get; set; }

        [JsonProperty("CommunicationLocation")]
        [DataMember]
        public string CommunicationLocation { get; set; }

        [JsonProperty("CommunicationCityName")]
        [DataMember]
        public string CommunicationCityName { get; set; }


        [JsonProperty("CommunicationPincode")]
        [DataMember]
        public string CommunicationPincode { get; set; }

       [JsonProperty("CommunicationStateId")]
        [DataMember]
        public int CommunicationStateId { get; set; }

        [JsonProperty("CommunicationState")]
        [DataMember]
        public string CommunicationState { get; set; }

        [JsonProperty("CommunicationDistrictId")]
        [DataMember]
        public int CommunicationDistrictId { get; set; }

        [JsonProperty("CommunicationDistrict")]
        [DataMember]
        public string CommunicationDistrict { get; set; }

        [JsonProperty("CommunicationPhoneNo")]
        [DataMember]
        public string CommunicationPhoneNo { get; set; }

        [JsonProperty("CommunicationMobileNo")]
        [DataMember]
        public string CommunicationMobileNo { get; set; }

        [JsonProperty("CommunicationFax")]
        [DataMember]
        public string CommunicationFax { get; set; }

        [JsonProperty("CommunicationEmailid")]
        [DataMember]
        public string CommunicationEmailid { get; set; }

        [JsonProperty("IncomeTaxPan")]
        [DataMember]
        public string IncomeTaxPan { get; set; }

        [JsonProperty("PermanentAddress1")]
        [DataMember]
        public string PermanentAddress1 { get; set; }

        [JsonProperty("PermanentAddress2")]
        [DataMember]
        public string PermanentAddress2 { get; set; }

        [JsonProperty("PermanentAddress3")]
        [DataMember]
        public string PermanentAddress3 { get; set; }

        [JsonProperty("PermanentLocation")]
        [DataMember]
        public string PermanentLocation { get; set; }

        [JsonProperty("PermanentCityName")]
        [DataMember]
        public string PermanentCityName { get; set; }

        [JsonProperty("PermanentPincode")]
        [DataMember]
        public string PermanentPincode { get; set; }

        [JsonProperty("PermanentStateId")]
        [DataMember]
        public int PermanentStateId { get; set; }

        [JsonProperty("PermanentState")]
        [DataMember]
        public string PermanentState { get; set; }

        [JsonProperty("PermanentDistrictId")]
        [DataMember]
        public int PermanentDistrictId { get; set; }

        [JsonProperty("PermanentDistrict")]
        [DataMember]
        public string PermanentDistrict { get; set; }

        [JsonProperty("PermanentPhoneNo")]
        [DataMember]
        public string PermanentPhoneNo { get; set; }

        [JsonProperty("PermanentFax")]
        [DataMember]
        public string PermanentFax { get; set; }

        [JsonProperty("PanCardRemarks")]
        [DataMember]
        public string PanCardRemarks { get; set; }

        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }
    }
}
