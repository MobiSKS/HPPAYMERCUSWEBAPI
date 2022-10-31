using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class GetNameandFormNumberbyCustomerIdModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }
    public class GetNameandFormNumberbyCustomerIdModelOutput : BaseClassOutput
    {
        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonProperty("CustomerTypeId")]
        [DataMember]
        public int CustomerTypeId { get; set; }

        [JsonProperty("CustomerTypeName")]
        [DataMember]
        public string CustomerTypeName { get; set; }

        [JsonProperty("NoOfCards")]
        [DataMember]
        public int NoOfCards { get; set; }

        [JsonProperty("PaymentType")]
        [DataMember]
        public string PaymentType { get; set; }

        [JsonProperty("PaymentReceivedDate")]
        [DataMember]
        public string PaymentReceivedDate { get; set; }


        [JsonProperty("ReceivedAmount")]
        [DataMember]
        public decimal ReceivedAmount { get; set; }


        [JsonProperty("RBEId")]
        [DataMember]
        public string RBEId { get; set; }


        [JsonProperty("RBEName")]
        [DataMember]
        public string RBEName { get; set; }

        //[JsonProperty("GetStatus")]
        //public List<GetStatusModelOutput> GetStatusOutput { get; set; }

        //[JsonProperty("GetNameandFormNumberbyCustomerId")]
        //public List<GetNameandFormNumberModelOutput> GetNameandFormNumberOutput { get; set; }
    }

    public class GetNameandFormNumberModelOutput
    {
        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("CustomerReferenceNo")]
        [DataMember]
        public string CustomerReferenceNo { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }
    }

    public class GetStatusModelOutput : BaseClassOutput
    {
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

}
