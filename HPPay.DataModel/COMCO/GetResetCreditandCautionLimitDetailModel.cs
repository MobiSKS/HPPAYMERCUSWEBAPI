﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace HPPay.DataModel.COMCO
{
    public class GetResetCreditandCautionLimitDetailInput :BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }
    public class GetResetCreditandCautionLimitDetailOutput:BaseClassOutput
    {
        [JsonProperty("Amount")]
        [DataMember]
        public float Amount { get; set; }


        [JsonProperty("CautionAmount")]
        [DataMember]
        public float CautionAmount { get; set; }


        [JsonProperty("CreditBalance")]
        [DataMember]
        public decimal CreditBalance { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("COMCOPackageID")]
        [DataMember]
        public string COMCOPackageID { get; set; }
    }
}
