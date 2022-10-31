using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AggregatorCustomer
{
    public class AggregatorNormalFleetCustomerGetCustomerReferenceNoModelInput : BaseClass
    {
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [JsonPropertyName("Type")]
        [DataMember]
        public int Type { get; set; }
    }



    public class AggregatorNormalFleetCustomerGetCustomerReferenceNoModelOutput : BaseClassOutput
    {
        //[JsonProperty("Title")]
        //[DataMember]
        //public string KeyOfficialTitle { get; set; }

        //[JsonProperty("KeyInitials")]
        //[DataMember]
        //public string KeyOfficialIndividualInitials { get; set; }


        //[JsonProperty("FirstName")]
        //[DataMember]
        //public string KeyOfficialFirstName { get; set; }

        //[JsonProperty("MiddleName")]
        //[DataMember]
        //public string KeyOfficialMiddleName { get; set; }

        //[JsonProperty("LastName")]
        //[DataMember]
        //public string KeyOfficialLastName { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

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


    }
}
