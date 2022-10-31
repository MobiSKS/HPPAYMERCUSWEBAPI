using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ISurePay
{
    public class ISurePayRechargeRejectionInput : BaseClass
    {
        public List<ISurePayRechargeRejectionInputData> iSurePayRejectlst { get; set; }
    }
    public class ISurePayRechargeRejectionInputData
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("ISureId")]
        [DataMember]
        public string ISureId { get; set; }

        [JsonPropertyName("ValidateNo")]
        [DataMember]
        public string ValidateNo { get; set; }

        [JsonPropertyName("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }

    }
    public class ISurePayRechargeRejectionOutput : BaseClassOutput
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }
}
