using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Customer
{
    public class CustomerGetCustomerBalanceInfoModelInput : BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class CustomerGetCustomerBalanceInfoModelOutput
    {
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("RegionalOfficeID")]
        [DataMember]
        public int RegionalOfficeID { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("CardBalance")]
        [DataMember]
        public decimal CardBalance { get; set; }

        [JsonProperty("CCMSLimitValue")]
        [DataMember]
        public decimal CCMSLimitValue { get; set; }

        [JsonProperty("Drivestars")]
        [DataMember]
        public int Drivestars { get; set; }

        [JsonProperty("ExpiredDrivestars")]
        [DataMember]
        public string ExpiredDrivestars { get; set; }

        [JsonProperty("ExpiringDrivestars")]
        [DataMember]
        public string ExpiringDrivestars { get; set; }

        [JsonProperty("CashPurseLimit")]
        [DataMember]
        public decimal CashPurseLimit { get; set; }

        [JsonProperty("DailyCashLimitBalance")]
        [DataMember]
        public decimal DailyCashLimitBalance { get; set; }

        [JsonProperty("TCSLiability")]
        [DataMember]
        public decimal TCSLiability { get; set; }
        
    }
}
