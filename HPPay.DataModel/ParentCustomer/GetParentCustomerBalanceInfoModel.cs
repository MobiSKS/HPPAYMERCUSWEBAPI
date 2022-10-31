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
    public class GetParentCustomerBalanceInfoModelInput : BaseClass
    {
        [JsonPropertyName("ParentCustomerID")]
        [DataMember]
        public string ParentCustomerID { get; set; }

        [JsonPropertyName("ChildCustomerId")]
        [DataMember]
        public string ChildCustomerId { get; set; }

    }

    public class GetParentCustomerBalanceInfoModelOutput
    {
        [JsonProperty("GetParentCustomerBalanceInfo")]
        public List<GetParentCustomerBalanceInfo> GetParentCustomerBalanceInfo { get; set; }

        [JsonProperty("GetChildCustomerBalanceInfo")]
        public List<GetChildCustomerBalanceInfo> GetChildCustomerBalanceInfo { get; set; }
    }

    public class GetParentCustomerBalanceInfo
    {
        [JsonProperty("ParentCustomerId")]
        [DataMember]
        public string ParentCustomerId { get; set; }

        [JsonProperty("CardBalance")]
        [DataMember]
        public decimal CardBalance { get; set; }

        [JsonProperty("CCMSBalance")]
        [DataMember]
        public decimal CCMSBalance { get; set; }

        [JsonProperty("Drivestars")]
        [DataMember]
        public string Drivestars { get; set; }

        [JsonProperty("ExpiredDrivestars")]
        [DataMember]
        public string ExpiredDrivestars { get; set; }

        [JsonProperty("ExpiringDrivestars")]
        [DataMember]
        public string ExpiringDrivestars { get; set; }

        [JsonProperty("DailyCashLimit")]
        [DataMember]
        public decimal DailyCashLimit { get; set; }

        [JsonProperty("DailyCashLimitBalance")]
        [DataMember]
        public decimal DailyCashLimitBalance { get; set; }

    }

    public class GetChildCustomerBalanceInfo
    {
        [JsonProperty("ChildCustomerId")]
        [DataMember]
        public string ChildCustomerId { get; set; }

        [JsonProperty("CardBalance")]
        [DataMember]
        public decimal CardBalance { get; set; }

        [JsonProperty("CCMSBalance")]
        [DataMember]
        public decimal CCMSBalance { get; set; }

        [JsonProperty("Drivestars")]
        [DataMember]
        public string Drivestars { get; set; }

        [JsonProperty("ExpiredDrivestars")]
        [DataMember]
        public string ExpiredDrivestars { get; set; }

        [JsonProperty("ExpiringDrivestars")]
        [DataMember]
        public string ExpiringDrivestars { get; set; }

        [JsonProperty("DailyCashLimit")]
        [DataMember]
        public decimal DailyCashLimit { get; set; }

        [JsonProperty("DailyCashLimitBalance")]
        [DataMember]
        public decimal DailyCashLimitBalance { get; set; }
    }
}
