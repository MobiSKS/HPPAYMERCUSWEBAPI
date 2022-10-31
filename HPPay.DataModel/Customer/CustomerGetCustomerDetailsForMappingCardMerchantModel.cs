using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    
    public class CustomerGetCustomerDetailsForMappingCardMerchantModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

       
        
    }

    public class CustomerGetCustomerDetailsForMappingCardMerchantModelOutput
    {
        [JsonProperty("GetCustomerDetails")]
        public List<CustomerGetCustomerBasicDetailsForMappingCardMerchantModelOutput> GetCustomerDetails { get; set; }

        [JsonProperty("GetCustomerCardDetails")]
        public List<CustomerGetCustomerCardDetailsForMappingCardMerchantModelOutput> GetCustomerCardDetails { get; set; }
    }

    public class CustomerGetCustomerBasicDetailsForMappingCardMerchantModelOutput
    {
         
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        
        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }


        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

    }

    public class CustomerGetCustomerCardDetailsForMappingCardMerchantModelOutput
    {
        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("CardIdentifier")]
        [DataMember]
        public string CardIdentifier { get; set; }


        [JsonProperty("LastTransactionDate")]
        [DataMember]
        public string LastTransactionDate { get; set; }
    }
}
