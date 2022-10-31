using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class SearchCustomerandCardFormModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("EntityId")]
        [DataMember]
        public string EntityId { get; set; }

        [JsonPropertyName("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

        [JsonPropertyName("StateID")]
        [DataMember]
        public string StateID { get; set; }

        [JsonPropertyName("CityName")]
        [DataMember]
        public string CityName { get; set; }
    }

    public class SearchCustomerandCardFormModelOutput
    {
        [JsonProperty("GetCustomerSearchOutput")]
        public List<CustomerSearchModelOutput> GetCustomerSearchOutput { get; set; }

        [JsonProperty("GetCardSearchOutput")]
        public List<CardSearchModelOutput> GetCardSearchOutput { get; set; }
    }

    public class CustomerSearchModelOutput
    {
        [JsonProperty("CustomerReferenceNo")]
        [DataMember]
        public string CustomerReferenceNo { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("RegionalOffice")]
        [DataMember]
        public string RegionalOffice { get; set; }

        [JsonProperty("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

        [JsonProperty("CustomerStatus")]
        [DataMember]
        public string CustomerStatus { get; set; }

        [JsonProperty("CardStatus")]
        [DataMember]
        public string CardStatus { get; set; }

        [JsonProperty("City")]
        [DataMember]
        public string City { get; set; }

        [JsonProperty("State")]
        [DataMember]
        public string State { get; set; }
    }

    public class CardSearchModelOutput
    {
        [JsonProperty("CustomerReferenceNo")]
        [DataMember]
        public string CustomerReferenceNo { get; set; }

        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [JsonProperty("YearOfRegistration")]
        [DataMember]
        public Int32 YearOfRegistration { get; set; }

        [JsonProperty("Manufacturer")]
        [DataMember]
        public string Manufacturer { get; set; }

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("VehicleType")]
        [DataMember]
        public string VehicleType { get; set; }

        [JsonProperty("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }
    }

}
