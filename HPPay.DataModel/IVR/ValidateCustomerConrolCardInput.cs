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
    public class ValidateCustomerConrolCardInput 
    {
        [Required]
        [JsonPropertyName("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }

        //[Required]
        [JsonPropertyName("ControlCardPIN")]
        [DataMember]
        public string ControlCardPIN { get; set; }

        [Required]
        [JsonPropertyName("ValidationMode")]
        [DataMember]
        public string ValidationMode { get; set; } 
    }

    public class ValidateCustomerControlCardOutput : CustomerAPIBaseClassOutput
    {
        
        [Required]
        [JsonPropertyName("SecurityToken")]
        [DataMember]
        public string SecurityToken { get; set; }
    }

    public class ValidateCustomerMobileInput
    {
        [Required]
        [JsonPropertyName("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }

        [JsonPropertyName("OTP")]
        [DataMember]
        public string OTP { get; set; }

        [Required]
        [JsonPropertyName("ValidationMode")]
        [DataMember]
        public string ValidationMode { get; set; }
    }

    public class ValidateCustomerMobileOutput : ValidateCustomerControlCardOutput
    {
        [JsonPropertyName("OTP")]
        [DataMember]
        public string OTP { get; set; }

    }

    public class CustomerCCMSBalanceInquiryInput
    {
        [Required]
        [JsonPropertyName("InputType")]
        [DataMember]
        public string InputType { get; set; }

        [Required]
        [JsonPropertyName("CustomerIdentifier")]
        [DataMember]
        public string CustomerIdentifier { get; set; }        
    }

    public class CustomerCCMSBalanceInquiryOutput : CustomerAPIBaseClassOutput
    {
        [JsonProperty("CcmsBalance")]
        [DataMember]
        public decimal CcmsBalance { get; set; }

        [JsonProperty("RechargeAmount")]
        [DataMember]
        public decimal RechargeAmount { get; set; }

        [JsonProperty("RechargeDate")]
        [DataMember]
        public string RechargeDate { get; set; }
    }

    public class CustomerResetPasswordInput : CustomerCCMSBalanceInquiryInput
    {

    }

    public class CustomerResetPasswordOutput : CustomerAPIBaseClassOutput
    {

    }

    public class CustomerBlockUnblockCardInput : CustomerCCMSBalanceInquiryInput
    {
        [Required]
        [JsonPropertyName("RequestType")]
        [DataMember]
        public string RequestType { get; set; }

        [Required]
        [JsonPropertyName("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }
    }

    public class CustomerBlockUnblockCardOutput : CustomerAPIBaseClassOutput
    {

    }

    public class CustomerResetCardPinInput : CustomerCCMSBalanceInquiryInput
    {
        [Required]
        [JsonPropertyName("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }

        [JsonPropertyName("CardPIN")]
        [DataMember]
        public string CardPIN { get; set; }
    }

    public class CustomerResetCardPinOutput : CustomerAPIBaseClassOutput
    {

    }

    public class CustomerResetControlCardPinInput : CustomerCCMSBalanceInquiryInput
    {
        [JsonPropertyName("CardPIN")]
        [DataMember]
        public string CardPIN { get; set; }
    }

    public class CustomerResetControlCardPinOutput : CustomerAPIBaseClassOutput
    {
        
    }

    public class CustomerloyaltyRedemptionInput : CustomerCCMSBalanceInquiryInput
    {

    }

    public class CustomerLoyaltyRedemptionOutput : CustomerAPIBaseClassOutput
    {
        [Required]
        [JsonPropertyName("StatusName")]
        [DataMember]
        public string StatusName { get; set; }
    }

    public class CustomerStarRewardsInput : CustomerCCMSBalanceInquiryInput
    {

    }

    public class CustomerStarRewardsOutput : CustomerAPIBaseClassOutput
    {
        [Required]
        [JsonPropertyName("Balance")]
        [DataMember]
        public string Balance { get; set; }
    }

    public class CustomerGenerateStatementInput : CustomerCCMSBalanceInquiryInput
    {
        [Required]
        [JsonPropertyName("StatementPeriod")]
        [DataMember]
        public string StatementPeriod { get; set; }
    }

    public class CustomerGenerateStatementOutput : CustomerAPIBaseClassOutput
    {
        [Required]
        [JsonPropertyName("RequestNumber")]
        [DataMember]
        public string RequestNumber { get; set; }

        [JsonPropertyName("EmailTo")]
        [DataMember]
        public string Email { get; set; }
    }

}
