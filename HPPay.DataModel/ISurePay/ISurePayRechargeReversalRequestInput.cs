using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ISurePay
{
    public class ISurePayRechargeReversalRequestInput : BaseClass
    {
        public List<ISurePayRechargeReversalRequestInputData> ISurePayReversalLst { get; set; }
    }
    public class ISurePayRechargeReversalRequestInputData
    {
        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("ValidateNo")]
        [DataMember]
        public string ValidateNo { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }

        [JsonPropertyName("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }

        [JsonPropertyName("TransactionId")]
        [DataMember]
        public string TransactionId { get; set; }

        [JsonPropertyName("PayMode")]
        [DataMember]
        public string PayMode { get; set; }

        [JsonPropertyName("ISureId")]
        [DataMember]
        public string ISureId { get; set; }

        [JsonPropertyName("InstrumentNumber")]
        [DataMember]
        public string InstrumentNumber { get; set; }

        [JsonPropertyName("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }

    }
    public class ISurePayRechargeReversalRequestOutput : BaseClassOutput
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }
}
