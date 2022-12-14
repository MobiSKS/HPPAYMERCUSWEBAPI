using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{

    public class CustomerGetCustomerReferenceNoModelInput : BaseClass
    {
        //[JsonPropertyName("CustomerReferenceNo")]
        //[DataMember]
        //public Int64 CustomerReferenceNo@FromNumber { get; set; }

        [JsonPropertyName("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [JsonPropertyName("Type")]
        [DataMember]
        public int Type { get; set; }
    }

  

    public class CustomerGetCustomerReferenceNoModelOutput :BaseClassOutput
    {
        //[JsonProperty("Title")]
        //[DataMember]
        //public string KeyOfficialTitle { get; set; }

        //[JsonProperty("KeyInitials")]
        //[DataMember]
        //public string KeyOfficialIndividualInitials { get; set; }


       

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

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonProperty("RBEId")]
        [DataMember]
        public string RBEId { get; set; }


        [JsonProperty("RBEName")]
        [DataMember]
        public string RBEName { get; set; }


    }


    public class SendOTPConsentModelInput : BaseClass
    {
        [JsonPropertyName("CustomerReferenceNo")]
        [DataMember]
        public Int64 CustomerReferenceNo { get; set; }
    }

    public class SendOTPConsentModelOutput : BaseClassOutput
    {

        [JsonProperty("CustomerReferenceNo")]
        [DataMember]
        public string OTP { get; set; }
    }


    public class ValidateOTPConsentModelInput : BaseClass
    {
        [JsonPropertyName("CustomerReferenceNo")]
        [DataMember]
        public Int64 CustomerReferenceNo { get; set; }

        [JsonPropertyName("OTP")]
        [DataMember]
        public string OTP { get; set; }
    }

    public class ValidateOTPConsentModelOutput : BaseClassOutput
    {

    }
}
