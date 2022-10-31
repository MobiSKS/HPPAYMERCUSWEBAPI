using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.COMCO
{
    public class GetCOMCOViewMappedCustomerModelInput : BaseClass
    {
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string @FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string @ToDate { get; set; }
    }
        public class GetCOMCOViewMappedCustomerModelOutput 
        {
            [JsonProperty("MerchantDetails")]
            public List<MerchantDetails> MerchantDetails { get; set; }

            [JsonProperty("MappedDetails")]
            public List<MappedDetails> MappedDetails { get; set; }
        }

    public class MerchantDetails :BaseClassOutput
    {
        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }


        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

    }

    public class MappedDetails
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


        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonProperty("MappingDate")]
        [DataMember]
        public string MappingDate { get; set; }
  
        [JsonProperty("MappingBy")]
        [DataMember]
        public string MappingBy { get; set; }

    }

    public class GetViewMappedCustomerModelInput : BaseClass
    {
        
    }
    public class GetViewMappedCustomerModelOutput
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


        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonProperty("CustomerAddress")]
        [DataMember]
        public string CustomerAddress { get; set; }

        [JsonProperty("PinCode")]
        [DataMember]
        public string PinCode { get; set; }

    }

}


