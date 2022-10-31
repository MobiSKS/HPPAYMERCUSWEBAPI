using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class CustomerGetCardAllocationActivationModelInput : BaseClass
    {

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


        [JsonPropertyName("ZonalOfficeId")]
        [DataMember]
        public string ZonalOfficeId { get; set; }

        [JsonPropertyName("RegionalOfficeId")]
        [DataMember]
        public string RegionalOfficeId { get; set; }
    }

    public class CustomerGetCardAllocationActivationModelOutput
    {
        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("MappingDate")]
        [DataMember]
        public string MappingDate { get; set; }

        [JsonProperty("AllocatedMID")]
        [DataMember]
        public string AllocatedMID { get; set; }

        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }

        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("AllocationDate")]
        [DataMember]
        public string AllocationDate { get; set; }


        [JsonProperty("FirstTransactionDate")]
        [DataMember]
        public string FirstTransactionDate { get; set; }

        [JsonProperty("IsDTPCustomer")]
        [DataMember]
        public string IsDTPCustomer { get; set; }
    }

}
