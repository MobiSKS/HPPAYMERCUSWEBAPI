using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIParentChildBalanceTransferV2ModelInput:CustomerAPIBaseClassInput
    {
        [Required]
        [RegularExpression(@"\d{10}", ErrorMessage = "Invalid Parent CustomerID")]
        [JsonPropertyName("ParentCustomerID")]
        [DataMember]
        public string ParentCustomerID { get; set; }


        [Required]
        [RegularExpression(@"\d{10}", ErrorMessage = "Invalid Child CustomerID")]
        [JsonPropertyName("ChildCustomerID")]
        [DataMember]
        public string ChildCustomerID { get; set; }

        [Required]
        [RegularExpression("^[0-9]{1,8}([.][0-9]{1,2})?$", ErrorMessage = "Invalid Transfer Amount")]
        [JsonPropertyName("TransferAmount")]
        [DataMember]
        public decimal TransferAmount { get; set; }

        [Required]
        [RegularExpression(@"\d{4}", ErrorMessage = "Invalid Balance Transaction Type")]
        [JsonPropertyName("BalanceTransType")]
        [DataMember]
        public int BalanceTransType { get; set; }
    }

    public class CustomerAPIParentChildBalanceTransferV2ModelOutput : CustomerAPIBaseClassOutput
    {
        [JsonProperty("finalBalance")]
        [DataMember]
        public decimal finalBalance { get; set; }

        [JsonProperty("debitTransactionID")]
        [DataMember]
        public string debitTransactionID { get; set; }


        [JsonProperty("creditTransactionID")]
        [DataMember]
        public string creditTransactionID { get; set; }



    }
}
