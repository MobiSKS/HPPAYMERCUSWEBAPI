using Newtonsoft.Json;
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
    public class GetMobileDispencerFuelPurchaseModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MobileDispenserId")]
        [DataMember]
        public string MobileDispenserId { get; set; }
    }

    public class GetMobileDispencerFuelPurchaseModelOutPut : BaseClassOutput
    {


        [JsonProperty("tblTerminalSubtblTransaction")]
        public List<MobileDispencerFuelPurchaseModelMID> tblMobileDispencerFuelPurchaseModelMID { get; set; }

        [JsonProperty("tblTransaction")]
        public List<MobileDispencerFuelPurchaseModelMCID> tblMobileDispencerFuelPurchaseModelMCID { get; set; }
    }

    public class MobileDispencerFuelPurchaseModelMID
    {


        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("CCMSBalance")]
        [DataMember]
        public decimal CCMSBalance { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonProperty("SourceofPayment")]
        [DataMember]
        public string SourceofPayment { get; set; }

    }

    public class MobileDispencerFuelPurchaseModelMCID
    {
        [JsonProperty("OutletType")]
        [DataMember]
        public string OutletType { get; set; }

        [JsonProperty("MobileDispenserId")]
        [DataMember]
        public string MobileDispenserId { get; set; }


        [JsonProperty("MappedMerchantId")]
        [DataMember]
        public string MappedMerchantId { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

       


        
        


    }

}
