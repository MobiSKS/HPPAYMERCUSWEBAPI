using HPPay.DataModel.HLFL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.HDFCPG
{
    public class FSEGetLoginDetailsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; } 
    }

    public class FSEGetLoginDetailsModelOutPut : BaseClassOutput
    {
        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }

    }

    public class FSEGenerateOTPModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

    }

    public class FSEGenerateOTPModelOutPut : BaseClassOutput
    {
        [JsonProperty("OTP")]
        [DataMember]
        public string OTP { get; set; }
       

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

    }

    public class FSEVerifyTPModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [Required]
        [JsonPropertyName("OTP")]
        [DataMember]
        public string OTP { get; set; }

        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }

    public class FSEVerifyTPModelOutPut : BaseClassOutput
    {
        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonProperty("Token")]
        [DataMember]
        public string Token { get; set; }

    }
    public class FSEGetDetailsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }
    }

    public class FSEGetDetailsModelOutPut : BaseClassOutput
    {
        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("Name")]
        [DataMember]
        public string Name { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonProperty("Address")]
        [DataMember]
        public string Address { get; set; }

    }

    public class FSEGetDashboardDetailsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }
    }

    public class FSEGetDashboardDetailsModelOutPut : BaseClassOutput
    {
        
        [JsonProperty("FSEGetMerchantDetails")]
        public List<FSEGetDashboardMerchantDetails> FSEGetMerchantDetails { get; set; }

        [JsonProperty("FSEGetTicketDetails")]
        public List<FSEGetDashboardTicketDetails> FSEGetTicketDetails { get; set; }

        [JsonProperty("FSEGetRequestDetails")]
        public List<FSEGetRequestDetailsModelOutPut> FSEGetRequestDetails { get; set; }

    }

    public class FSEGetDashboardMerchantDetails
    {
        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("Name")]
        [DataMember]
        public string Name { get; set; }
    }
        public class FSEGetDashboardTicketDetails
    {
        [JsonProperty("OpenTickets")]
        [DataMember]
        public string OpenTickets { get; set; }

        [JsonProperty("CloseTickets")]
        [DataMember]
        public string CloseTickets { get; set; }

        [JsonProperty("TotalTickets")]
        [DataMember]
        public string TotalTickets { get; set; }

    }

    public class FSEGetRequestDetailsModelOutPut 
    {
        [JsonProperty("RequestType")]
        [DataMember]
        public string RequestType { get; set; }

        [JsonProperty("TicketNo")]
        [DataMember]

        public string TicketNo { get; set; }

        [JsonProperty("OutletName")]
        [DataMember]

        public string OutletName { get; set; }

        [JsonProperty("CreatedDate")]
        [DataMember]

        public string CreatedDate { get; set; }
    }

    public class FSEGetTicketsDetailsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("TicketNumber")]
        [DataMember]
        public string TicketNumber { get; set; }

        [Required]
        [JsonPropertyName("Type")]
        [DataMember]
        public string Type { get; set; }
    }

    public class FSEGetTicketsDetailsModelOutPut : BaseClassOutput
    {
        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("TicketNo")]
        [DataMember]
        public string TicketNo { get; set; }

        [JsonProperty("OutletName")]
        [DataMember]
        public string OutletName { get; set; }

        [JsonProperty("Address")]
        [DataMember]
        public string Address { get; set; }

        [JsonProperty("City")]
        [DataMember]
        public string City { get; set; }

        [JsonProperty("District")]
        [DataMember]
        public string District { get; set; }

        [JsonProperty("TerminalIssuanceType")]
        [DataMember]
        public string TerminalIssuanceType { get; set; }

        [JsonProperty("TerminalType")]
        [DataMember]
        public string TerminalType { get; set; }

        [JsonProperty("Remark")]
        [DataMember]
        public string Remark { get; set; }

    }



    }
