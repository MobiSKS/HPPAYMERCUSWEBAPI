using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.ParentCustomer
{
    public class GetParentCustomerBasicSearchModelInput : BaseClass
    {

        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }


        [JsonPropertyName("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }


        [JsonPropertyName("NameonCard")]
        [DataMember]
        public string NameonCard { get; set; }


        [JsonPropertyName("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }


        [JsonPropertyName("CommunicationStateId")]
        [DataMember]
        public string CommunicationStateId { get; set; }

        [JsonPropertyName("CommunicationCityName")]
        [DataMember]
        public string CommunicationCityName { get; set; }


        [JsonPropertyName("CustomerSubtype")]
        [DataMember]
        public int CustomerSubtype { get; set; }

    }

    public class GetParentCustomerBasicSearchModelOutput
    {

        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }
        [JsonProperty("CustomerName")]

        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [JsonProperty("[Mobile]")]
        [DataMember]
        public string Mobile { get; set; }

        [JsonProperty("CustomerType")]
        [DataMember]
        public string CustomerType { get; set; }

        [JsonProperty("FormReceiptDate")]
        [DataMember]
        public string FormReceiptDate { get; set; }

        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }

        [JsonProperty("requestId")]
        [DataMember]
        public int requestId { get; set; } 

        [JsonProperty("CustomerTypeName")]
        [DataMember]
        public string CustomerTypeName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }
        

    }

}
