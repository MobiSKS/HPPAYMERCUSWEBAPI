using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RechargeCCMS
{


    public class CCMSTransactionSalebyTerminalModelInput : BaseClass
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
        public int Productid { get; set; }

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
        public int Formfactor { get; set; }

        //[JsonPropertyName("Vehicleno")]
        //[DataMember]
        //public string Vehicleno { get; set; }

        
    }
    public class CCMSTransactionSalebyTerminalModelOutput : BaseClassOutput
    {
        
    }


    public class CCMSRechargeCCMSAccountModelInput : BaseClass
    {
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

        [JsonPropertyName("Formfactor")]
        [DataMember]
        public Int32 Formfactor { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("CCN")]
        [DataMember]
        public string CCN { get; set; }
    }
    public class CCMSRechargeCCMSAccountModelOutput : BaseClassOutput
    {

    }


    public class CCMSGetBatchnoModelInput : BaseClass
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
    public class CCMSGetBatchnoModelOutput : BaseClassOutput
    {

    }


    public class CCMSTransactionBalanceTransferModelInput : BaseClass
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

    }
    public class CCMSTransactionBalanceTransferModelOutput : BaseClassOutput
    {

    }

    public class CCMSTransactionGenerateOTPModelInput : BaseClass
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

         

    }
    public class CCMSTransactionGenerateOTPModelOutput : BaseClassOutput
    {
        
        [JsonProperty("OTP")]
        [DataMember]
        public string OTP { get; set; }
    }
}
