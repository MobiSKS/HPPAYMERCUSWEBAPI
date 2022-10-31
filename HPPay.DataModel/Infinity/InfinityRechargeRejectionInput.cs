using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Infinity
{
    
    public class InfinityRechargeRejectionInput : BaseClass
    {
        public List<InfinityRechargeRejectionInputData> lstRejectioninput { get; set; }
    }
    public class InfinityRechargeRejectionInputData
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }

        [JsonPropertyName("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }
    }
    public class InfinityRechargeRejectionOutput : BaseClassOutput
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


    }
}
