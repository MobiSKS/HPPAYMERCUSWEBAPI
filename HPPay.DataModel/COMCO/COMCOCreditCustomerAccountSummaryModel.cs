using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.COMCO
{
    public class COMCOCreditCustomerAccountSummaryModelInput:BaseClass
    {

        [Required]
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("DepositType")]
        [DataMember]
        public int DepositType { get; set; }
    }
    public class COMCOCreditCustomerAccountSummaryModelOutput
    {
        

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


        [JsonProperty("COMCOPackageID")]
        [DataMember]
        public string COMCOPackageID { get; set; }


        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }


        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }


        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }


        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }



        [JsonProperty("DepositType")]
        [DataMember]
        public string DepositType { get; set; }


        [JsonProperty("CreditLimit")]
        [DataMember]
        public decimal CreditLimit { get; set; }

        [JsonProperty("AccountBalance")]
        [DataMember]
        public decimal AccountBalance { get; set; }


        [JsonProperty("CautionLimit")]
        [DataMember]
        public double CautionLimit { get; set; }
    }
}
