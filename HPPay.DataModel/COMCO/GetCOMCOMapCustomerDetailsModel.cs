using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.COMCO
{
    public class GetCOMCOMapCustomerDetailsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

     
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

    }

    public class GetCOMCOMapCustomerDetailsModelOutput 
    {
        [JsonProperty("MerchantDetails")]

        public List<GetMerchantDetails> MerchantDetails { get; set; }


        [JsonProperty("CustomerDetails")]

        public List<GetCustomerDetails> CustomerDetails { get; set; }
    }

    public class GetMerchantDetails : BaseClassOutput
    {
        
        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }


        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName  { get; set; }


        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string  RetailOutletName { get; set; }

}
    public class GetCustomerDetails 
    {
       
        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }


        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }


        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        
        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }


        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }


        [JsonProperty("CustomerAddress")]
        [DataMember]
        public string CustomerAddress { get; set; }

        [JsonProperty("CommunicationPincode")]
        [DataMember]
        public string CommunicationPincode { get; set; }


       
    }
}
