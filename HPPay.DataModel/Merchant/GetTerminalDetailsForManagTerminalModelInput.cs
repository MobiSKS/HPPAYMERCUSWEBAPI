using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace HPPay.DataModel.Merchant
{
    public class GetTerminalDetailsForManagTerminalModelInput : BaseClass
    {
        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }
    }
    public class GetTerminalDetailsForManagTerminalModelOutput
    {
        [JsonProperty("tblTerminalSubtblTransaction")]
        public List<GetTerminalDetailsForManagTerminal> tblTerminalSubtblTransaction { get; set; }

        [JsonProperty("tblTransaction")]
        public List<GettblTransactionDate> tblTransaction { get; set; }

        [JsonProperty("tblmstStatusSubTerminalLog")]
        public List<GetTerminalDetailsForManagTerminalSub> tblmstStatusSubTerminalLog { get; set; }


        [JsonProperty("tblMobileDispenserRetailOutletMapping")]
        public List<GetMobileDispenserRetailOutletMapping> tblMobileDispenserRetailOutletMapping { get; set; }

    }

    public class GetMobileDispenserRetailOutletMapping
    {
        [JsonProperty("ParentMerchantId")]
        [DataMember]
        public string ParentMerchantId { get; set; }

        [JsonProperty("ServiceCharge")]
        [DataMember]

        public double ServiceCharge { get; set; }

        [JsonProperty("RouteId")]
        [DataMember]
        public string RouteId { get; set; }

        [JsonProperty("RSP")]
        [DataMember]
        public string RSP { get; set; }


        [JsonProperty("Price")]
        [DataMember]
        public decimal Price{get; set;}

    }

    public class GettblTransactionDate
    {

        [JsonProperty("FirstTransactionDate")]
        [DataMember]
        public string FirstTransactionDate { get; set; }

        [JsonProperty("LastTransactionDate")]
        [DataMember]
        public string LastTransactionDate { get; set; }
    }

    public class GetTerminalDetailsForManagTerminalSub
    {

        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }

        [JsonProperty("Comment")]
        [DataMember]
        public string Comment { get; set; }

        [JsonProperty("Date")]
        [DataMember]

        public string Date { get; set; }
    }


    public class GetTerminalDetailsForManagTerminal
    {

        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("ApprovalDate")]
        [DataMember]
        public string ApprovalDate { get; set; }

        [JsonProperty("RetailOutletCity")]
        [DataMember]
        public string RetailOutletCity { get; set; }


    }
}
