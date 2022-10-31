using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Customer
{
    public class ForgetPasswordByControlCardNoModelInput : BaseClass
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonPropertyName("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }

        [JsonPropertyName("ControlCardNoPin")]
        [DataMember]
        public string ControlCardNoPin { get; set; }

    }
    public class ForgetPasswordByControlCardNoModelOutput : BaseClassOutput
    {
        [JsonProperty("Password")]
        [DataMember]
        public string Password { get; set; }

        [JsonProperty("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonProperty("Name")]
        [DataMember]
        public string Name { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }
    }

    public class NewEnrollCustomerOTPSentModelInput : BaseClass
    {
        //[Required]
        [JsonPropertyName("CommunicationMobileNo")]
        [DataMember]
        public string CommunicationMobileNo { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [Required]
        [JsonPropertyName("OTPType")]
        [DataMember]
        public Int32 OTPType { get; set; }

        [JsonPropertyName("CommunicationEmailId")]
        [DataMember]
        public string CommunicationEmailId { get; set; }


    }

    public class NewEnrollCustomerOTPSentByCustomeridModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [Required]
        [JsonPropertyName("OTPType")]
        [DataMember]
        public Int32 OTPType { get; set; }

        //[JsonPropertyName("CommunicationEmailId")]
        //[DataMember]
        //public string CommunicationEmailId { get; set; }


    }

    public class NewEnrollCustomerOTPSentByCustomeridModelOutput : BaseClassOutput
    {

        [JsonProperty("OTP")]
        [DataMember]
        public string OTP { get; set; }

        [JsonProperty("EmailID")]
        [DataMember]
        public string EmailID { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

    }



    public class NewEnrollCustomerOTPSentModelOutput : BaseClassOutput
    {

        [JsonProperty("OTP")]
        [DataMember]
        public string OTP { get; set; }
    }

    public class NewEnrollCustomerOTPVerifiedModelInput : BaseClass
    {
        //[Required]
        [JsonPropertyName("CommunicationMobileNo")]
        [DataMember]
        public string CommunicationMobileNo { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [Required]
        [JsonPropertyName("OTPType")]
        [DataMember]
        public Int32 OTPType { get; set; }

        [JsonPropertyName("CommunicationEmailId")]
        [DataMember]
        public string CommunicationEmailId { get; set; }

        [JsonPropertyName("OTP")]
        [DataMember]
        public string OTP { get; set; }


    }
    public class NewEnrollCustomerOTPVerifiedModelOutput : BaseClassOutput
    {
         
    }


    public class NewEnrollCustomerOTPVerifiedByCustomeridModelInput : BaseClass
    {
        //[Required]
        //[JsonPropertyName("CommunicationMobileNo")]
        //[DataMember]
        //public string CommunicationMobileNo { get; set; }

        [Required]
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }


        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [Required]
        [JsonPropertyName("OTPType")]
        [DataMember]
        public Int32 OTPType { get; set; }

        //[JsonPropertyName("CommunicationEmailId")]
        //[DataMember]
        //public string CommunicationEmailId { get; set; }

        [JsonPropertyName("OTP")]
        [DataMember]
        public string OTP { get; set; }


    }
    public class NewEnrollCustomerOTPVerifiedByCustomeridModelOutput : BaseClassOutput
    {

    }




}
