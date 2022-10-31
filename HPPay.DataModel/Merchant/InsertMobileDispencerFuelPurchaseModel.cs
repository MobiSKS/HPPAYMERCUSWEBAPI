using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Merchant
{
    public class InsertMobileDispencerFuelPurchaseModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MobileDispenserId")]
        [DataMember]
        public string MobileDispenserId { get; set; }



        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("OutletType")]
        [DataMember]
        public string OutletType { get; set; }

        [Required]
        [JsonPropertyName("MappedMerchantId")]
        [DataMember]
        public string MappedMerchantId { get; set; }

        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public Double Amount { get; set; }

        [Required]
        [JsonPropertyName("Modifiedby")]
        [DataMember]
        public string Modifiedby { get; set; }



        //[JsonPropertyName("ReferenceNo")]
        //[DataMember]
        //public string ReferenceNo { get; set; }

        [JsonPropertyName("SourceofPayment")]
        [DataMember]
        public string SourceofPayment { get; set; }


    }

    public class InsertMobileDispencerFuelPurchaseModelOutPut : BaseClassOutput
    {


    }

}
