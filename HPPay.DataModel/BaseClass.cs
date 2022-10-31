using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel
{


    public abstract class BaseClass
    {
        [Required]
        [JsonPropertyName("UserId")]
        [DataMember]
        public string Userid { get; set; }

        [Required]
        [JsonPropertyName("Useragent")]
        [DataMember]
        public string Useragent { get; set; }

        [Required]
        [JsonPropertyName("Userip")]
        [DataMember]
        public string Userip { get; set; }


        //[JsonPropertyName("ZonalId")]
        //[DataMember]
        //public string ZonalId { get; set; }


        //[JsonPropertyName("RegionalId")]
        //[DataMember]
        //public string RegionalId { get; set; }

    }

    public abstract class BaseClassTerminal
    {
        [Required]
        [JsonPropertyName("UserId")]
        [DataMember]
        public string Userid { get; set; }

        [Required]
        [JsonPropertyName("Useragent")]
        [DataMember]
        public string Useragent { get; set; }

        [Required]
        [JsonPropertyName("Userip")]
        [DataMember]
        public string Userip { get; set; }


        [JsonPropertyName("Latitude")]
        [DataMember]
        public string Latitude { get; set; }


        [JsonPropertyName("Longitude")]
        [DataMember]
        public string Longitude { get; set; }

    }
    public abstract class BaseClassOutput
    {
        [JsonProperty("Status")]
        [DataMember]
        public int Status { get; set; }

        [JsonProperty("Reason")]
        [DataMember]
        public string Reason { get; set; }      

    }

    public abstract class CustomerAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("Username")]
        [DataMember]
        public string Username { get; set; }

        [Required]
        [JsonPropertyName("Password")]
        [DataMember]
        public string Password { get; set; }

        [JsonPropertyName("TransactionId")]
        [DataMember]
        public string TransactionId { get; set; }
    }

    public abstract class CustomerAPIBaseClassOutput
    {
        [JsonProperty("responseCode")]
        [DataMember]
        public string responseCode { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }
    }

    public abstract class SFLAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("Username")]
        [DataMember]
        public string Username { get; set; }

        [Required]
        [JsonPropertyName("Password")]
        [DataMember]
        public string Password { get; set; }

        [JsonPropertyName("TransactionId")]
        [DataMember]
        public string TransactionId { get; set; }
    }

    public abstract class SFLAPIBaseClassOutput
    {
        [JsonProperty("responseCode")]
        [DataMember]
        public string responseCode { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }
    }


    public abstract class STFCAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("Username")]
        [DataMember]
        public string Username { get; set; }

        [Required]
        [JsonPropertyName("Password")]
        [DataMember]
        public string Password { get; set; }

        [JsonPropertyName("TransactionId")]
        [DataMember]
        public string TransactionId { get; set; }
    }

    public abstract class STFCAPIBaseClassOutput
    {
        [JsonProperty("responseCode")]
        [DataMember]
        public string  responseCode { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }
    }

    public abstract class M2PAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("Username")]
        [DataMember]
        public string Username { get; set; }

        [Required]
        [JsonPropertyName("Password")]
        [DataMember]
        public string Password { get; set; }

        [JsonPropertyName("TransactionId")]
        [DataMember]
        public string TransactionId { get; set; }
    }

    public abstract class M2PAPIBaseClassOutput
    {
        [JsonProperty("responseCode")]
        [DataMember]
        public string responseCode { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }
    }

    public abstract class TMFLAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("Username")]
        [DataMember]
        public string Username { get; set; }

        [Required]
        [JsonPropertyName("Password")]
        [DataMember]
        public string Password { get; set; }

        [Required]
        [JsonPropertyName("Authorization")]
        [DataMember]
        public string Authorization { get; set; }

        //[Required]
        //[JsonPropertyName("Content-Type")]
        //[DataMember]
        //public string ContentType { get; set; }
    }

    public abstract class TMFLAPIBaseClassOutput
    {
        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonProperty("ResponseMessage")]
        [DataMember]
        public string ResponseMessage { get; set; }
    }

    public abstract class HLFLAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("Username")]
        [DataMember]
        public string Username { get; set; }

        [Required]
        [JsonPropertyName("Password")]
        [DataMember]
        public string Password { get; set; }

        [Required]
        [JsonPropertyName("Authorization")]
        [DataMember]
        public string Authorization { get; set; }         
    }

    public abstract class HLFLValidationBaseClassInput
    {
        [Required]
        [JsonPropertyName("Username")]
        [DataMember]
        public string Username { get; set; }

        [Required]
        [JsonPropertyName("Password")]
        [DataMember]
        public string Password { get; set; }

        [JsonPropertyName("TransactionNumber")]
        [DataMember]
        public string TransactionNumber { get; set; }

        [JsonPropertyName("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber;

        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId;

        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount;

        [JsonPropertyName("TransactionDate")]
        [DataMember]
        public string TransactionDate;

        [JsonPropertyName("ClientCheckSum")]
        [DataMember]
        public string ClientCheckSum; 
    }

    public abstract class HLFLValidationBaseClassOutput
    {
        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonProperty("ResponseMessage")]
        [DataMember]
        public string ResponseMessage { get; set; }
    }
    public abstract class HLFLAPIBaseClassOutput
    {
        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonProperty("ResponseMessage")]
        [DataMember]
        public string ResponseMessage { get; set; }
    }

    public abstract class AGSBaseClassOutput
    {
        [JsonProperty("responseCode")]
        [DataMember]
        public int responseCode { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }
    }


    public abstract class EGVAPIBaseClassOutput
    {
        [JsonProperty("responseCode")]
        [DataMember]
        public int responseCode { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }
    }



    public abstract class AGSAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("Username")]
        [DataMember]
        public string Username { get; set; }

        [Required]
        [JsonPropertyName("Password")]
        [DataMember]
        public string Password { get; set; }

       
    }




}
