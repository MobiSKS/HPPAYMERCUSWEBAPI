using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Transaction
{

    public class TransactionBalanceEnquiryModelInput : BaseClassTerminal
    {
        [JsonPropertyName("Merchantid")]
        [DataMember]
        public string Merchantid { get; set; }

        [JsonPropertyName("Terminalid")]
        [DataMember]
        public string Terminalid { get; set; }

        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }


        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }


        [JsonPropertyName("OTP")]
        [DataMember]
        public string OTP { get; set; }


        [JsonPropertyName("Pin")]
        [DataMember]
        public string Pin { get; set; }


        [JsonPropertyName("Sourceid")]
        [DataMember]
        public int Sourceid { get; set; }

        [JsonPropertyName("Formfactor")]
        [DataMember]
        public int Formfactor { get; set; }


        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }
    public class TransactionBalanceEnquiryModelOutput : BaseClassOutput
    {
        [JsonProperty("MonthlyLimit")]
        [DataMember]
        public decimal MonthlyLimit { get; set; }

        [JsonProperty("MonthlySpent")]
        [DataMember]
        public decimal MonthlySpent { get; set; }

        [JsonProperty("MonthlyLimitBal")]
        [DataMember]
        public decimal MonthlyLimitBal { get; set; }

        [JsonProperty("DailyLimit")]
        [DataMember]
        public decimal DailyLimit { get; set; }

        [JsonProperty("DailySpent")]
        [DataMember]
        public decimal DailySpent { get; set; }

        [JsonProperty("DailyLimitBal")]
        [DataMember]
        public decimal DailyLimitBal { get; set; }

        [JsonProperty("CCMSLimit")]
        [DataMember]
        public string CCMSLimit { get; set; }

        [JsonProperty("CCMSLimitBal")]
        [DataMember]
        public string CCMSLimitBal { get; set; }

        [JsonProperty("CardBalance")]
        [DataMember]
        public decimal CardBalance { get; set; }

        [JsonProperty("CardNoOutput")]
        [DataMember]
        public string CardNoOutput { get; set; }


    }


    public class TransactionTrackingByTerminalModelInput : BaseClassTerminal
    {
        [JsonPropertyName("Merchantid")]
        [DataMember]
        public string Merchantid { get; set; }

        [JsonPropertyName("Terminalid")]
        [DataMember]
        public string Terminalid { get; set; }

        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }


        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }


        [JsonPropertyName("OTP")]
        [DataMember]
        public string OTP { get; set; }


        [JsonPropertyName("Pin")]
        [DataMember]
        public string Pin { get; set; }


        [JsonPropertyName("Sourceid")]
        [DataMember]
        public int Sourceid { get; set; }

        [JsonPropertyName("Formfactor")]
        [DataMember]
        public int Formfactor { get; set; }


        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("Transtype")]
        [DataMember]
        public string Transtype { get; set; }

        [JsonPropertyName("Trackingdate")]
        [DataMember]
        public DateTime Trackingdate { get; set; }

        [JsonPropertyName("Odometerreading")]
        [DataMember]
        public string Odometerreading { get; set; }
    }
    public class TransactionTrackingByTerminalModelOutput : BaseClassOutput
    {
        [JsonProperty("Balance")]
        [DataMember]
        public string Balance { get; set; }
    }

    public class TransactionInsertDriverLoyaltyModelInput : BaseClassTerminal
    {
        [JsonPropertyName("Merchantid")]
        [DataMember]
        public string Merchantid { get; set; }

        [JsonPropertyName("Terminalid")]
        [DataMember]
        public string Terminalid { get; set; }

        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }


        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }


        [JsonPropertyName("OTP")]
        [DataMember]
        public string OTP { get; set; }


        [JsonPropertyName("Pin")]
        [DataMember]
        public string Pin { get; set; }


        [JsonPropertyName("Sourceid")]
        [DataMember]
        public int Sourceid { get; set; }

        [JsonPropertyName("Formfactor")]
        [DataMember]
        public int Formfactor { get; set; }


        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("Transtype")]
        [DataMember]
        public string Transtype { get; set; }

        //[JsonPropertyName("Trackingdate")]
        //[DataMember]
        //public DateTime Trackingdate { get; set; }

        [JsonPropertyName("Odometerreading")]
        [DataMember]
        public string Odometerreading { get; set; }

        [JsonPropertyName("Batchid")]
        [DataMember]
        public Int64 Batchid { get; set; }

        [JsonPropertyName("Invoiceamount")]
        [DataMember]
        public decimal Invoiceamount { get; set; }

        [JsonPropertyName("Invoiceid")]
        [DataMember]
        public string Invoiceid { get; set; }

        [JsonPropertyName("Invoicedate")]
        [DataMember]
        public DateTime Invoicedate { get; set; }

        [JsonPropertyName("Stan")]
        [DataMember]
        public int Stan { get; set; }


    }
    public class TransactionInsertDriverLoyaltyModelOutput : BaseClassOutput
    {
        [JsonProperty("CardNoOutput")]
        [DataMember]
        public string CardNoOutput { get; set; }

        [JsonProperty("Points")]
        [DataMember]
        public string Points { get; set; }

        [JsonProperty("BalancePoints")]
        [DataMember]
        public string BalancePoints { get; set; }

        [JsonProperty("RefNo")]
        [DataMember]
        public string RefNo { get; set; }

    }
}
