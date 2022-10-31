using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.IdfcAPI
{


    public class FastagGetOtpRequest : BaseClass
    {
        [JsonPropertyName("Merchantid")]
        [DataMember]
        [Required]
        public string Merchantid { get; set; }

        [JsonPropertyName("Terminalid")]
        [DataMember]
        [Required]
        public string Terminalid { get; set; }


        [JsonPropertyName("BankID")]
        [DataMember]
        [Required]
        public int BankID { get; set; }

        [JsonPropertyName("Mobileno")]
        [DataMember]
        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string Mobileno { get; set; }

        [JsonPropertyName("Vehicleno")]
        [DataMember]
        [Required]

        public string Vehicleno { get; set; }

        [JsonPropertyName("Invoiceamount")]
        [DataMember]
        [Required]
        public decimal Invoiceamount { get; set; }


    }



    public class FastagConfirmOtpReQuest : BaseClass
    {
        [JsonPropertyName("Merchantid")]
        [DataMember]
        [Required]
        public string Merchantid { get; set; }

        [JsonPropertyName("Terminalid")]
        [DataMember]
        [Required]
        public string Terminalid { get; set; }

        [JsonPropertyName("BankID")]
        [DataMember]
        [Required]
        public int BankID { get; set; }
        
        [JsonPropertyName("TxnRefId")]
        [DataMember]
        //[Required]
        public string TxnRefId { get; set; }

        [JsonPropertyName("Vehicleno")]
        [DataMember]
        [Required]
        public string Vehicleno { get; set; }

        [JsonPropertyName("Mobileno")]
        [DataMember]
        [Required]
        public string Mobileno { get; set; }

        [JsonPropertyName("Invoiceamount")]
        [DataMember]
        [Required]
        public decimal Invoiceamount { get; set; }


        [JsonPropertyName("TxnTime")]
        [DataMember]
        [Required]
        public string TxnTime { get; set; }

        [JsonPropertyName("OTP")]
        [DataMember]
        [Required]
        public string OTP { get; set; }

        [JsonPropertyName("TagId")]
        [DataMember]
        public string TagId { get; set; }

        [JsonPropertyName("TxnNo")]
        [DataMember]
        public string TxnNo { get; set; }
        [Required]
        [JsonPropertyName("Invoiceid")]
        [DataMember]
        public string Invoiceid { get; set; }

        [Required]
        [JsonPropertyName("Batchid")]
        [DataMember]
        public int Batchid { get; set; }

        [Required]
        [JsonPropertyName("Invoicedate")]
        [DataMember]
        public DateTime Invoicedate { get; set; }

        [Required]
        [JsonPropertyName("Productid")]
        [DataMember]
        public int Productid { get; set; }


        //[Required]
        [JsonPropertyName("Odometerreading")]
        [DataMember]
        public string Odometerreading { get; set; }

        [Required]
        [JsonPropertyName("TransType")]
        [DataMember]
        public string TransType { get; set; }

        [Required]
        [JsonPropertyName("Sourceid")]
        [DataMember]
        public int Sourceid { get; set; }

        [Required]
        [JsonPropertyName("Formfactor")]
        [DataMember]
        public int Formfactor { get; set; }

        //[Required]
        [JsonPropertyName("DCSTokenNo")]
        [DataMember]
        public string DCSTokenNo { get; set; }

        [Required]
        [JsonPropertyName("Stan")]
        [DataMember]
        public int Stan { get; set; }

        //[Required]
        //[JsonPropertyName("Paymentmode")]
        //[DataMember]
        //public string Paymentmode { get; set; }

        ////[Required]
        //[JsonPropertyName("Gatewayname")]
        //[DataMember]
        //public string Gatewayname { get; set; }

        //[Required]
        //[JsonPropertyName("Bankname")]
        //[DataMember]
        //public string Bankname { get; set; }

        ////[Required]
        //[JsonPropertyName("Paycode")]
        //[DataMember]
        //public string Paycode { get; set; }


    }

    public class FasTagConfirmOtpResponse : BaseClassOutput
    {
        [JsonProperty("ResCode")]
        [DataMember]
        public string ResCode { get; set; }

        [JsonProperty("ResCd")]
        [DataMember]
        public string ResCd { get; set; }

        [JsonProperty("ResMsg")]
        [DataMember]
        public string ResMsg { get; set; }

        [JsonProperty("TxnId")]
        [DataMember]
        public string TxnId { get; set; }

        [JsonProperty("txnTime")]
        [DataMember]
        public string txnTime { get; set; }

        [JsonProperty("TagId")]
        [DataMember]
        public string TagId { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonProperty("VRN")]
        [DataMember]
        public string Vrn { get; set; }

        [JsonProperty("TxnNo")]
        [DataMember]
        public string TxnNo { get; set; }

        [JsonProperty("Invoiceid")]
        [DataMember]
        public string Invoiceid { get; set; }

        [JsonProperty("Batchid")]
        [DataMember]
        public int Batchid { get; set; }

        [JsonProperty("RSP")]
        [DataMember]
        public string RSP { get; set; }

        [JsonProperty("Volume")]
        [DataMember]
        public string Volume { get; set; } = "-";

    }
    public class FasTagOtpResponse : BaseClassOutput
    {
        [JsonProperty("ResCode")]
        [DataMember]
        public string ResCode { get; set; }

        [JsonProperty("ResCd")]
        [DataMember]
        public string ResCd { get; set; }

        [JsonProperty("ResMsg")]
        [DataMember]
        public string ResMsg { get; set; }

        [JsonProperty("TxnId")]
        [DataMember]
        public string TxnId { get; set; }

        [JsonProperty("txnTime")]
        [DataMember]
        public string txnTime { get; set; }

        [JsonProperty("TagId")]
        [DataMember]
        public string TagId { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonProperty("VRN")]
        [DataMember]
        public string Vrn { get; set; }

        [JsonProperty("TxnNo")]
        [DataMember]
        public string TxnNo { get; set; }

    }



    public class IdfcGetOtpRequest : BaseClass
    {


        [JsonPropertyName("MobileNo")]
        [DataMember]
        [Required]
        public string MobileNo { get; set; }

        [JsonPropertyName("VRN")]
        [DataMember]
        [Required]
        public string Vrn { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        [Required]
        public decimal Amount { get; set; }


    }

    public class IdfcAPIGetOtpRequest
    {
        public string txnId { get; set; }
        public string mobileNo { get; set; }
        public string vrn { get; set; }
        public string amount { get; set; }
        public string entityId { get; set; }
        public string posId { get; set; }
        public string txnTime { get; set; }
        public string chkSm { get; set; }
        public string iin { get; set; }
        public string tagId { get; set; }
        public string netAmount { get; set; }
        public string discount { get; set; }
    }

    public class IdfcGetOtpResponse : BaseClassOutput
    {
        [JsonProperty("ResCode")]
        [DataMember]
        public string ResCode { get; set; }

        [JsonProperty("ResMsg")]
        [DataMember]
        public string ResMsg { get; set; }

        [JsonProperty("TxnId")]
        [DataMember]
        public string TxnId { get; set; }

        [JsonProperty("txnTime")]
        [DataMember]
        public string txnTime { get; set; }

        [JsonProperty("TagId")]
        [DataMember]
        public string TagId { get; set; }

        [JsonProperty("VRN")]
        [DataMember]
        public string Vrn { get; set; }

        [JsonProperty("TxnNo")]
        [DataMember]
        public string TxnNo { get; set; }

    }

    public class IdfcConfirmOtpReQuest : BaseClass
    {
        [JsonPropertyName("TxnId")]
        [DataMember]
        [Required]
        public string TxnId { get; set; }

        [JsonPropertyName("VRN")]
        [DataMember]
        [Required]
        public string Vrn { get; set; }

        [JsonPropertyName("MobileNo")]
        [DataMember]
        [Required]
        public string MobileNo { get; set; }

        [JsonPropertyName("GrossAmount")]
        [DataMember]
        [Required]
        public decimal GrossAmount { get; set; }


        //[JsonPropertyName("EntityId")]
        //[DataMember]
        //[Required]
        //public string EntityId { get; set; }

        //[JsonPropertyName("PosId")]
        //[DataMember]
        //[Required]
        //public string PosId { get; set; }

        [JsonPropertyName("TxnTime")]
        [DataMember]
        [Required]
        public string TxnTime { get; set; }

        [JsonPropertyName("Otp")]
        [DataMember]
        [Required]
        public string Otp { get; set; }





        [JsonPropertyName("TagId")]
        [DataMember]
        public string TagId { get; set; }
    }

    public class IdfcMakePaymentReQuest
    {
        public string txnId { get; set; }
        public string vrn { get; set; }
        public string mobileNo { get; set; }
        public string grossAmount { get; set; }
        public string netAmount { get; set; }
        public string discount { get; set; }
        public string entityId { get; set; }
        public string posId { get; set; }
        public string txnTime { get; set; }
        public string otp { get; set; }
        public string iin { get; set; }
        public string chkSm { get; set; }


    }

    public class UpdateCCMSBAlanceForIdfcCustomer : BaseClassOutput
    {
        public string RSP { get; set; }
        public string Volume { get; set; }

    }

    public class FastagRefundPaymentReQuest : BaseClass
    {
        [JsonPropertyName("Merchantid")]
        [DataMember]
        [Required]
        public string Merchantid { get; set; }

        [JsonPropertyName("Terminalid")]
        [DataMember]
        [Required]
        public string Terminalid { get; set; }

        [JsonPropertyName("BankID")]
        [DataMember]
        [Required]
        public int BankID { get; set; }

        [JsonPropertyName("OrgTxnId")]
        [DataMember]
        [Required]
        public string OrgTxnId { get; set; }


        [JsonPropertyName("OrgTxnTime")]
        [DataMember]
        [Required]
        public string OrgTxnTime { get; set; }

        [JsonPropertyName("TxnNo")]
        [DataMember]
        [Required]
        public string TxnNo { get; set; }

        [Required]
        [JsonPropertyName("Invoiceid")]
        [DataMember]
        public string Invoiceid { get; set; }

        [Required]
        [JsonPropertyName("Batchid")]
        [DataMember]
        public int Batchid { get; set; }

        [Required]
        [JsonPropertyName("Invoicedate")]
        [DataMember]
        public DateTime Invoicedate { get; set; }

        [Required]
        [JsonPropertyName("Productid")]
        [DataMember]
        public int Productid { get; set; }


        [Required]
        [JsonPropertyName("Odometerreading")]
        [DataMember]
        public string Odometerreading { get; set; }

        [Required]
        [JsonPropertyName("TransType")]
        [DataMember]
        public string TransType { get; set; }

        [Required]
        [JsonPropertyName("Sourceid")]
        [DataMember]
        public int Sourceid { get; set; }

        [Required]
        [JsonPropertyName("Formfactor")]
        [DataMember]
        public int Formfactor { get; set; }

        [Required]
        [JsonPropertyName("DCSTokenNo")]
        [DataMember]
        public string DCSTokenNo { get; set; }

        [Required]
        [JsonPropertyName("Stan")]
        [DataMember]
        public int Stan { get; set; }

        //[Required]
        //[JsonPropertyName("Paymentmode")]
        //[DataMember]
        //public string Paymentmode { get; set; }

        //[Required]
        //[JsonPropertyName("Gatewayname")]
        //[DataMember]
        //public string Gatewayname { get; set; }

        //[Required]
        //[JsonPropertyName("Bankname")]
        //[DataMember]
        //public string Bankname { get; set; }

        //[Required]
        //[JsonPropertyName("Paycode")]
        //[DataMember]
        //public string Paycode { get; set; }

    }

    public class FastagRefundResponse :BaseClassOutput
    {
        [JsonProperty("ResCode")]
        [DataMember]
        public string resCode { get; set; }

        [JsonProperty("ResMsg")]
        [DataMember]
        public string resMsg { get; set; }

        [JsonProperty("TxnId")]
        [DataMember]
        public string txnId { get; set; }



        [JsonProperty("TxnNo")]
        [DataMember]
        public string txnNo { get; set; }

        [JsonProperty("Invoiceid")]
        [DataMember]
        public string Invoiceid { get; set; }

        
        [JsonProperty("Batchid")]
        [DataMember]
        public int Batchid { get; set; }
    }
    public class IdfcRefundPaymentReQuest : BaseClass
    {

        [JsonPropertyName("OrgTxnId")]
        [DataMember]
        [Required]
        public string OrgTxnId { get; set; }


        [JsonPropertyName("OrgTxnTime")]
        [DataMember]
        [Required]
        public string OrgTxnTime { get; set; }



    }
    public class IdfcRefundReQuest
    {
        public string txnId { get; set; }
        public string orgTxnId { get; set; }
        public string entityId { get; set; }
        public string posId { get; set; }
        public string txnTime { get; set; }
        public string orgTxnTime { get; set; }
        public string iin { get; set; }
        public string chkSm { get; set; }
    }

    public class IdfcRefundReesponse
    {
        [JsonProperty("ResCode")]
        [DataMember]
        public string resCode { get; set; }

        [JsonProperty("ResMsg")]
        [DataMember]
        public string resMsg { get; set; }

        [JsonProperty("TxnId")]
        [DataMember]
        public string txnId { get; set; }



        [JsonProperty("TxnNo")]
        [DataMember]
        public string txnNo { get; set; }

    }
}
