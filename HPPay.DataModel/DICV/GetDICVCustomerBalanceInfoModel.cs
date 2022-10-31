using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DICV
{
    public class GetDICVCustomerBalanceInfoModelInput : BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class GetDICVCustomerBalanceInfoModelOutput
    {
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("CardBalance")]
        [DataMember]
        public decimal CardBalance { get; set; }

        [JsonProperty("CCMSLimitValue")]
        [DataMember]
        public decimal CCMSLimitValue { get; set; }

        [JsonProperty("Drivestars")]
        [DataMember]
        public decimal Drivestars { get; set; }

        [JsonProperty("ExpiredDrivestars")]
        [DataMember]
        public decimal ExpiredDrivestars { get; set; }

        [JsonProperty("ExpiringDrivestars")]
        [DataMember]
        public decimal ExpiringDrivestars { get; set; }

        [JsonProperty("CashPurseLimit")]
        [DataMember]
        public decimal CashPurseLimit { get; set; }

        [JsonProperty("DailyCashLimitBalance")]
        [DataMember]
        public decimal DailyCashLimitBalance { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }
    }
}
