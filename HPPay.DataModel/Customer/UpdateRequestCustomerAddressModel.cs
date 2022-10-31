using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class UpdateRequestCustomerAddressModelInput : BaseClass
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("CommunicationAddress1")]
        [DataMember]

        public string CommunicationAddress1 { get; set; }

        [JsonPropertyName("CommunicationAddress2")]
        [DataMember]

        public string CommunicationAddress2 { get; set; }

        [JsonPropertyName("CommunicationAddress3")]
        [DataMember]

        public string CommunicationAddress3 { get; set; }

        [JsonPropertyName("CommunicationLocation")]
        [DataMember]

        public string CommunicationLocation { get; set; }

        [JsonPropertyName("CommunicationCityName")]
        [DataMember]

        public string CommunicationCityName { get; set; }

        [JsonPropertyName("CommunicationPincode")]
        [DataMember]

        public string CommunicationPincode { get; set; }

        [JsonPropertyName("CommunicationStateId")]
        [DataMember]

        public string CommunicationStateId { get; set; }

        [JsonPropertyName("CommunicationDistrictId")]
        [DataMember]

        public string CommunicationDistrictId { get; set; }

        [JsonPropertyName("CommunicationPhoneNo")]
        [DataMember]

        public string CommunicationPhoneNo { get; set; }

        [JsonPropertyName("CommunicationMobileNo")]
        [DataMember]

        public string CommunicationMobileNo { get; set; }

        [JsonPropertyName("CommunicationFax")]
        [DataMember]

        public string CommunicationFax { get; set; }

        [JsonPropertyName("CommunicationEmailid")]
        [DataMember]

        public string CommunicationEmailid { get; set; }

        [JsonPropertyName("IncomeTaxPan")]
        [DataMember]

        public string IncomeTaxPan { get; set; }

        [JsonPropertyName("PermanentAddress1")]
        [DataMember]

        public string PermanentAddress1 { get; set; }

        [JsonPropertyName("PermanentAddress2")]
        [DataMember]

        public string PermanentAddress2 { get; set; }

        [JsonPropertyName("PermanentAddress3")]
        [DataMember]

        public string PermanentAddress3 { get; set; }

        [JsonPropertyName("PermanentLocation")]
        [DataMember]

        public string PermanentLocation { get; set; }

        [JsonPropertyName("PermanentCityName")]
        [DataMember]

        public string PermanentCityName { get; set; }

        [JsonPropertyName("PermanentPincode")]
        [DataMember]

        public string PermanentPincode { get; set; }

        [JsonPropertyName("PermanentStateId")]
        [DataMember]

        public string PermanentStateId { get; set; }

        [JsonPropertyName("PermanentDistrictId")]
        [DataMember]

        public string PermanentDistrictId { get; set; }

        [JsonPropertyName("PermanentPhoneNo")]
        [DataMember]

        public string PermanentPhoneNo { get; set; }

        [JsonPropertyName("PermanentFax")]
        [DataMember]

        public string PermanentFax { get; set; }


        [JsonPropertyName("PanCardRemarks")]
        [DataMember]

        public string PanCardRemarks { get; set; }


        [JsonPropertyName("CreatedBy")]
        [DataMember]

        public string CreatedBy { get; set; }


     
    }

    public class UpdateRequestCustomerAddressModelOutput : BaseClassOutput
    {

    }
}
