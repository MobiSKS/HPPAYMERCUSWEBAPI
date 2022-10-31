using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.Transaction
{


    public class TransactionReloadAccountModelInput : BaseClassTerminal
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

        [JsonPropertyName("Batchid")]
        [DataMember]
        public Int64 Batchid { get; set; }

        [JsonPropertyName("Invoiceamount")]
        [DataMember]
        public decimal Invoiceamount { get; set; }

        [JsonPropertyName("Transtype")]
        [DataMember]
        public string Transtype { get; set; }


        [JsonPropertyName("Invoiceid")]
        [DataMember]
        public string Invoiceid { get; set; }

        [JsonPropertyName("Invoicedate")]
        [DataMember]
        public DateTime Invoicedate { get; set; }


        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }


        [JsonPropertyName("Chequeno")]
        [DataMember]
        public string Chequeno { get; set; }

        [JsonPropertyName("MICR")]
        [DataMember]
        public string MICR { get; set; }


        [JsonPropertyName("OTP")]
        [DataMember]
        public string OTP { get; set; }


        [JsonPropertyName("Pin")]
        [DataMember]
        public string Pin { get; set; }


        [JsonPropertyName("Sourceid")]
        [DataMember]
        public int Sourceid { get; set; }

        [JsonPropertyName("Stan")]
        [DataMember]
        public Int32 Stan { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("Formfactor")]
        [DataMember]
        public int Formfactor { get; set; }
    }
    public class TransactionReloadAccountModelOutput : BaseClassOutput
    {
        [JsonProperty("Balance")]
        [DataMember]
        public string Balance { get; set; }

        [JsonProperty("RefNo")]
        [DataMember]
        public string RefNo { get; set; }

        [JsonProperty("CardNoOutput")]
        [DataMember]
        public string CardNoOutput { get; set; }

        [JsonProperty("ProductName")]
        [DataMember]
        public string ProductName { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [JsonProperty("Address")]
        [DataMember]
        public string Address { get; set; }

        [JsonProperty("LimitType")]
        [DataMember]
        public string LimitType { get; set; }

        [JsonProperty("CCMSLimit")]
        [DataMember]
        public string CCMSLimit { get; set; }

        [JsonProperty("CurrentCardBalance")]
        [DataMember]
        public string CurrentCardBalance { get; set; }

        [JsonProperty("CurrentCCMSBalance")]
        [DataMember]
        public string CurrentCCMSBalance { get; set; }

        [JsonProperty("APIReferenceNo")]
        [DataMember]
        public string APIReferenceNo { get; set; }


        [JsonProperty("GetMultipleMobileNo")]
        [DataMember]
        public string GetMultipleMobileNo { get; set; }

    }
}
