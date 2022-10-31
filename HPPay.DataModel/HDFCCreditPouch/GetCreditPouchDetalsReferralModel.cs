using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.HDFCCreditPouch
{
    public class GetCreditPouchDetalsReferralInput : BaseClass
    {
        [JsonPropertyName("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonPropertyName("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }


        [JsonProperty("StateId")]
        [DataMember]
        public int StateId { get; set; }

        [JsonProperty("StatusId")]
        [DataMember]
        public int StatusId { get; set; }

        [JsonPropertyName("DetailsSharedBy")]
        [DataMember]
        public string DetailsSharedBy { get; set; }

        [JsonPropertyName("RequestType")]
        [DataMember]
        public string RequestType { get; set; }

    }

    public class GetCreditPouchDetalsReferral:BaseClassOutput
    {
        
        [JsonProperty("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }
         
        [JsonProperty("ContactPerson")]
        [DataMember]
        public string ContactPerson { get; set; }

        [JsonProperty("City")]
        [DataMember]
        public string City { get; set; }
         

        [JsonProperty("StateName")]
        [DataMember]
        public string StateName { get; set; }

        [JsonProperty("StateId")]
        [DataMember]
        public string StateId { get; set; }

        [JsonProperty("PinCode")]
        [DataMember]
        public string PinCode { get; set; }

        [JsonProperty("Mobile")]
        [DataMember]
        public string Mobile { get; set; }
         

        [JsonProperty("PhoneNo")]
        [DataMember]
        public string PhoneNo { get; set; }

        [JsonProperty("Address")]
        [DataMember]
        public string Address { get; set; }

        [JsonProperty("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonProperty("RequestStatus")]
        [DataMember]
        public string RequestStatus { get; set; }

        [JsonProperty("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }


        [JsonProperty("RequestedDate")]
        [DataMember]
        public string RequestedDate { get; set; }

    }
}
