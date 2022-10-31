using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{


    public class CustomerViewOnlineFormStatusModelInput : BaseClass
    {
        [JsonPropertyName("StatusId")]
        [DataMember]
        public int StatusId { get; set; }

        [JsonPropertyName("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [JsonPropertyName("CustomerReferenceNo")]
        [DataMember]
        public Int64 CustomerReferenceNo { get; set; }

        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }
    }
    public class CustomerViewOnlineFormStatusModelOutput
    {
        [JsonProperty("ZonalOfficeId")]
        [DataMember]
        public int ZonalOfficeId { get; set; }

        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeId")]
        [DataMember]
        public int RegionalOfficeId { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [JsonProperty("CustomerReferenceNo")]
        [DataMember]
        public Int64 CustomerReferenceNo { get; set; }

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("CreatedDate")]
        [DataMember]
        public string CreatedDate { get; set; }

        [JsonProperty("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonProperty("ModifiedDate")]
        [DataMember]
        public string ModifiedDate { get; set; }

        [JsonProperty("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonProperty("StatusId")]
        [DataMember]
        public int StatusId { get; set; }

        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }

        [JsonProperty("KYCStatus")]
        [DataMember]
        public string KYCStatus { get; set; }

        [JsonProperty("CreatedRoleName")]
        [DataMember]
        public string CreatedRoleName { get; set; }
    }
}
