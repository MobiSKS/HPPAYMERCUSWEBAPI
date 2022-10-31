using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.COMCO
{
    public class ViewCustomerCreditRechargeModelInput:BaseClass
    {
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string @FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string @ToDate { get; set; }
    }

    public class ViewCustomerCreditRechargeModelOutput
    {
        [JsonProperty("CreditMerchantDetails")]
        public List<CreditMerchantDetails> CreditMerchantDetails { get; set; }

        [JsonProperty("CustomerCreditRecharge")]
        public List<CustomerCreditRecharge> CustomerCreditRecharge { get; set; }
    }

    public class CreditMerchantDetails : BaseClassOutput
    {
        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }


        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

    }

    public class CustomerCreditRecharge
    {
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }


        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("Amount")]
        [DataMember]
        public decimal Amount { get; set; }

        [JsonProperty("PaymentMode")]
        [DataMember]
        public string PaymentMode { get; set; }

        [JsonProperty("BankName")]
        [DataMember]
        public string BankName { get; set; }

        [JsonProperty("ChequeDDBDSReferenceNumber")]
        [DataMember]
        public string ChequeDDBDSReferenceNumber { get; set; }

        [JsonProperty("ChequeDDBDSReferenceDate")]
        [DataMember]
        public string ChequeDDBDSReferenceDate { get; set; }

        [JsonProperty("RealizationDate")]
        [DataMember]
        public string RealizationDate { get; set; }

        [JsonProperty("CreatedTime")]
        [DataMember]
        public string CreatedTime { get; set; }
        [JsonProperty("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
        
    }
}
