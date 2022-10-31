﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.STFCAPI
{
    public class STFCDehotlistCustomerWithPANModelInput:STFCAPIBaseClassInput
    {

        [Required]
        [RegularExpression(@"\d{10}", ErrorMessage = "Invalid DtpCustomerId/DtpCustomerId should be length of 10 digits.")]
        [JsonPropertyName("DtpCustomerId")]
        [DataMember]
        public new string DtpCustomerId { get; set; }

        [Required]
        [RegularExpression(@"^[0-9a-zA-Z]{1,15}$", ErrorMessage = "Invalid STFCCustomerID")]
        [JsonPropertyName("StfcCustomerId")]
        [DataMember]
        public string StfcCustomerId { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{5}\d{4}[A-Z]{1}$", ErrorMessage = "Invalid PAN")]
        [StringLength(10, ErrorMessage = "Invalid PAN/PAN must be length of 10.")]
        [JsonPropertyName("PAN")]
        [DataMember]
        public string PAN { get; set; }
    }

    public class STFCDehotlistCustomerWithPANModelOutput 
    {
        [JsonProperty("dehotlistCust")]
        [DataMember]
        public GetdehotlistCust dehotlistCust { get; set; }
    }

    public class GetdehotlistCust
    {
        [JsonProperty("responseCode")]
        [DataMember]
        public string responseCode { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }


        [JsonProperty("pan")]
        [DataMember]
        public string pan { get; set; }

        [JsonProperty("dtpCustomerID")]
        [DataMember]
        public string dtpCustomerID { get; set; }

        [JsonProperty("stfcCustomerId")]
        [DataMember]
        public string stfcCustomerId { get; set; }
    }
    }
