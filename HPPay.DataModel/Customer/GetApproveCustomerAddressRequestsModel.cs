using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class GetApproveCustomerAddressRequestsModelInput : BaseClass
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

    }
    public class GetApproveCustomerAddressRequestsModelOutput
    {
        [JsonProperty("ObjOldCustomerAddressValue")]
        public List<GetCustomerAddressDetail> ObjOldCustomerAddressValue { get; set; }



        [JsonProperty("ObjNewCustomerAddressValue")]
        public List<GetDetailCustomerAddressDetail> ObjNewCustomerAddressValue { get; set; }
    }
    public class GetCustomerAddressDetail
    { 
        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

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

        [JsonProperty("CommunicationStateName")]
        [DataMember]

        public string CommunicationStateName { get; set; }

        [JsonProperty("CommunicationDistrictName")]
        [DataMember]

        public string CommunicationDistrictName { get; set; }

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

        [JsonProperty("PermanentStateName")]
        [DataMember]

        public string PermanentStateName { get; set; }

        [JsonProperty("PermanentDistrictName")]
        [DataMember]

        public string PermanentDistrictName { get; set; }

        [JsonProperty("PermanentPhoneNo")]
        [DataMember]

        public string PermanentPhoneNo { get; set; }

        [JsonProperty("PermanentFax")]
        [DataMember]

        public string PermanentFax { get; set; }

        [JsonProperty("PanCardRemarks")]
        [DataMember]

        public string PanCardRemarks { get; set; }
    }
    public class GetDetailCustomerAddressDetail
    {
        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

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

        [JsonProperty("CommunicationStateName")]
        [DataMember]

        public string CommunicationStateName { get; set; }

        [JsonProperty("CommunicationDistrictName")]
        [DataMember]

        public string CommunicationDistrictName { get; set; }

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

        [JsonProperty("PermanentStateName")]
        [DataMember]

        public string PermanentStateName { get; set; }

        [JsonProperty("PermanentDistrictName")]
        [DataMember]

        public string PermanentDistrictName { get; set; }

        [JsonProperty("PermanentPhoneNo")]
        [DataMember]

        public string PermanentPhoneNo { get; set; }

        [JsonProperty("PermanentFax")]
        [DataMember]

        public string PermanentFax { get; set; }

        [JsonProperty("PanCardRemarks")]
        [DataMember]

        public string PanCardRemarks { get; set; }
    }
}
