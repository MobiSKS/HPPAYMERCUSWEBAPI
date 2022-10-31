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
    public class COMCOCreditCustomerAccountDetailsModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
    }

    public class COMCOCreditCustomerAccountDetailsModelOutput  
    {
        [JsonProperty("CustomerAccountDetails")]
        public List<CustomerAccountDetails> CustomerAccountDetails { get; set; }

        [JsonProperty("TransactionDetails")]
        public List<TransactionDetails> TransactionDetails { get; set; }


    }

    

    public class CustomerAccountDetails
    {

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


        [JsonProperty("COMCOPackageID")]
        [DataMember]
        public string COMCOPackageID { get; set; }


        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("CreditLimit")]
        [DataMember]
        public decimal CreditLimit { get; set; }

        [JsonProperty("CustomerAddress")]
        [DataMember]
        public string CustomerAdd { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("DepositType")]
        [DataMember]
        public string DepositType { get; set; }



        [JsonProperty("CautionLimit")]
        [DataMember]
        public double CautionLimit { get; set; }


        [JsonProperty("AccountBalance")]
        [DataMember]
        public decimal AccountBalance { get; set; }

        [JsonProperty("ReservedBalance")]
        [DataMember]
        public decimal ReservedBalance { get; set; }

    }

    public class TransactionDetails
    {
        [JsonProperty("TransactionType")]
        [DataMember]
        public string TransactionType { get; set; }

        [JsonProperty("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }

        [JsonProperty("TransactionAmount")]
        [DataMember]
        public double TransactionAmount { get; set; }
        
        [JsonProperty("Balance")]
        [DataMember]
        public decimal Balance { get; set; }

        [JsonProperty("RSP")]
        [DataMember]
        public decimal RSP { get; set; }
        [JsonProperty("FinanceCharges")]
        [DataMember]
        public decimal FinanceCharges { get; set; }

    }
}

