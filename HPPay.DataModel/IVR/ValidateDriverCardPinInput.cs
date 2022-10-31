using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.IVR
{
    public class ValidateDriverCardPinInput 
    {
        [Required]
        [JsonPropertyName("DriverCardNumber")]
        [DataMember]
        public string DriverCardNumber { get; set; }

        //[Required]
        [JsonPropertyName("DriverCardPIN")]
        [DataMember]
        public string DriverCardPIN { get; set; }

        [Required]
        [JsonPropertyName("ValidationMode")]
        [DataMember]
        public string ValidationMode { get; set; }
    }

    public class ValidateDriverCardPinOutput : ValidateCustomerControlCardOutput
    {

    }

    public class ValidateDriverMobileNumberInput : ValidateCustomerMobileInput
    {

    }

    public class ValidateDriverMobileNumberOutput : ValidateDriverCardPinOutput
    {

    }

    public class DriverCheckCardBalanceInput : CustomerCCMSBalanceInquiryInput
    {

    }

    public class DriverCheckCardBalanceOutput : CustomerAPIBaseClassOutput
    {
        [Required]
        [JsonProperty("CardBalance")]
        [DataMember]
        public decimal CardBalance { get; set; }
    }

    public class DriverCheckCardLimitInput : CustomerCCMSBalanceInquiryInput
    {

    }

    public class DriverCheckCardLimitOutput : CustomerAPIBaseClassOutput
    {
        [Required]
        [JsonProperty("CCMSReloadLimitType")]
        [DataMember]
        public string CCMSReloadLimitType { get; set; }

        [Required]
        [JsonProperty("CCMSReloadLimit")]
        [DataMember]
        public decimal CCMSReloadLimit { get; set; }

        [Required]
        [JsonProperty("CCMSReloadLimitBalance")]
        [DataMember]
        public decimal CCMSReloadLimitBalance { get; set; }

        [Required]
        [JsonProperty("DailySaleBalance")]
        [DataMember]
        public decimal DailySaleBalance { get; set; }

        [Required]
        [JsonProperty("DailySaleLimit")]
        [DataMember]
        public decimal DailySaleLimit { get; set; }

        [Required]
        [JsonProperty("MonthlySaleLimit")]
        [DataMember]
        public decimal MonthlySaleLimit { get; set; }

        [Required]
        [JsonProperty("MonthlySaleBalance")]
        [DataMember]
        public decimal MonthlySaleBalance { get; set; }
    }

    public class DriverLastTransactionDetailsInput : CustomerCCMSBalanceInquiryInput
    {

    }

    public class DriverLastTransactionDetailsOutput : CustomerAPIBaseClassOutput
    {
        [Required]
        [JsonProperty("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }

        [Required]
        [JsonProperty("TransactionAmount")]
        [DataMember]
        public decimal TransactionAmount { get; set; }
    }
}
