using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Settings
{
    internal class CreditLimitAuthorizationAPIModel
    {

    }
    public class CreditLimitAuthorizationAPIInput : BaseClass
    {
        [JsonPropertyName("Merchantid")]
        [DataMember]
        [Required]
        public string Merchantid { get; set; }

        [JsonPropertyName("Terminalid")]
        [DataMember]
        [Required]
        public string Terminalid { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]
        [Required]
        public string CardNo { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        [Required]
        public decimal Amount { get; set; }

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

        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }

        [JsonPropertyName("OTP")]
        [DataMember]
        public string OTP { get; set; }


        [JsonPropertyName("Pin")]
        [DataMember]
        public string Pin { get; set; }

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

        [JsonPropertyName("Latitude")]
        [DataMember]
        public string Latitude { get; set; }


        [JsonPropertyName("Longitude")]
        [DataMember]
        public string Longitude { get; set; }




    }
}
