using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Transaction
{


    public class TransactionSalebyTerminalModelInput : BaseClassTerminal
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


        [JsonPropertyName("Productid")]
        [DataMember]
        public Int32 Productid { get; set; }

        [JsonPropertyName("Odometerreading")]
        [DataMember]
        public string Odometerreading { get; set; }


        [JsonPropertyName("OTP")]
        [DataMember]
        public string OTP { get; set; }


        [JsonPropertyName("Pin")]
        [DataMember]
        public string Pin { get; set; }


        [JsonPropertyName("Sourceid")]
        [DataMember]
        public Int32 Sourceid { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("Formfactor")]
        [DataMember]
        public Int32 Formfactor { get; set; }

        [JsonPropertyName("DCSTokenNo")]
        [DataMember]
        public string DCSTokenNo { get; set; }

        [JsonPropertyName("Stan")]
        [DataMember]
        public Int32 Stan { get; set; }

        [JsonPropertyName("OtherCardNo")]
        [DataMember]
        public string OtherCardNo { get; set; }

        [JsonPropertyName("TxnRefId")]
        [DataMember]
        public string TxnRefId { get; set; }

        [JsonPropertyName("Paymentmode")]
        [DataMember]
        public string Paymentmode { get; set; }

        [JsonPropertyName("Gatewayname")]
        [DataMember]
        public string Gatewayname { get; set; }

        [JsonPropertyName("Bankname")]
        [DataMember]
        public string Bankname { get; set; }

        [JsonPropertyName("Paycode")]
        [DataMember]
        public string Paycode { get; set; }

    }
    public class TransactionSalebyTerminalModelOutput :BaseClassOutput
    {
        [JsonProperty("Balance")]
        [DataMember]
        public string Balance { get; set; }

        [JsonProperty("RSP")]
        [DataMember]
        public string RSP { get; set; }

        [JsonProperty("InvAmt")]
        [DataMember]
        public string InvAmt { get; set; }

        [JsonProperty("Volume")]
        [DataMember]
        public string Volume { get; set; }

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


    public class RechargeCCMSAccountModelInput : BaseClassTerminal
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
        public Int32 Invoiceid { get; set; }

        [JsonPropertyName("Invoicedate")]
        [DataMember]
        public DateTime Invoicedate { get; set; }


        [JsonPropertyName("Chequeno")]
        [DataMember]
        public string Chequeno { get; set; }


        [JsonPropertyName("MICR")]
        [DataMember]
        public string MICR { get; set; }


        [JsonPropertyName("MUtrno")]
        [DataMember]
        public string MUtrno { get; set; }


        [JsonPropertyName("Paymentmode")]
        [DataMember]
        public string Paymentmode { get; set; }


        //[JsonPropertyName("Currency")]
        //[DataMember]
        //public string Currency { get; set; }


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
        public Int32 Sourceid { get; set; }

        [JsonPropertyName("Stan")]
        [DataMember]
        public Int32 Stan { get; set; }

        [JsonPropertyName("Formfactor")]
        [DataMember]
        public Int32 Formfactor { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("CCN")]
        [DataMember]
        public string CCN { get; set; }

        [JsonPropertyName("Points")]
        [DataMember]
        public decimal Points { get; set; }
    }
    public class RechargeCCMSAccountModelOutput : BaseClassOutput
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


    public class GetBatchnoModelInput : BaseClass
    {
        [JsonPropertyName("Merchantid")]
        [DataMember]
        public string Merchantid { get; set; }

        [JsonPropertyName("Terminalid")]
        [DataMember]
        public string Terminalid { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }
    public class GetBatchnoModelOutput : BaseClassOutput
    {

    }


    public class TransactionBalanceTransferModelInput : BaseClassTerminal
    {
        [JsonPropertyName("Merchantid")]
        [DataMember]
        public string Merchantid { get; set; }

        [JsonPropertyName("Terminalid")]
        [DataMember]
        public string Terminalid { get; set; }

        [JsonPropertyName("CCN")]
        [DataMember]
        public string CCN { get; set; }

        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }

        [JsonPropertyName("Batchid")]
        [DataMember]
        public Int64 Batchid { get; set; }

        [JsonPropertyName("Invoiceid")]
        [DataMember]
        public string Invoiceid { get; set; }

        [JsonPropertyName("Invoicedate")]
        [DataMember]
        public DateTime Invoicedate { get; set; }


        [JsonPropertyName("Invoiceamount")]
        [DataMember]
        public decimal Invoiceamount { get; set; }



        [JsonPropertyName("Transtype")]
        [DataMember]
        public string Transtype { get; set; }


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
        public Int32 Sourceid { get; set; }

        [JsonPropertyName("Formfactor")]
        [DataMember]
        public Int32 Formfactor { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }


        [JsonPropertyName("Stan")]
        [DataMember]
        public Int32 Stan { get; set; }


    }
    public class TransactionBalanceTransferModelOutput : BaseClassOutput
    {
        [JsonProperty("RefNo")]
        [DataMember]
        public string RefNo { get; set; }

        [JsonProperty("CardNoOutput")]
        [DataMember]
        public string CardNoOutput { get; set; }


        [JsonProperty("CardBal")]
        [DataMember]
        public string CardBal { get; set; }
    }

    public class TransactionGenerateOTPModelInput : BaseClassTerminal
    {
        [JsonPropertyName("Merchantid")]
        [DataMember]
        public string Merchantid { get; set; }

        [JsonPropertyName("Terminalid")]
        [DataMember]
        public string Terminalid { get; set; }


        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }


        [JsonPropertyName("OTPtype")]
        [DataMember]
        public int OTPtype { get; set; }


        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }


        [JsonPropertyName("CCN")]
        [DataMember]
        public string CCN { get; set; }

        [JsonPropertyName("TransTypeId")]
        [DataMember]
        public int TransTypeId { get; set; }

        [JsonPropertyName("Invoiceamount")]
        [DataMember]
        public decimal Invoiceamount { get; set; }

    }
    public class TransactionGenerateOTPModelOutput : BaseClassOutput
    {
        
        [JsonProperty("OTP")]
        [DataMember]
        public string OTP { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [JsonProperty("Address")]
        [DataMember]
        public string Address { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }
    }

    public class TransactionGetPEKAKBModelOutput 
    {
        [JsonProperty("DPKAKB")]
        [DataMember]
        public string DPKAKB { get; set; }

        
    }
}
