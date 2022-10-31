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
    public class GetApprovalCreditLimitDetailsModelInput:BaseClass
    {
        
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [JsonPropertyName("RechargeMode")]
        [DataMember]
        public int RechargeMode { get; set; }


    }
    public class GetApprovalCreditLimitDetailsModelOutput 
    {
        
        
        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

       
        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }


       
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

      
        [JsonProperty("COMCOPackageID")]
        [DataMember]
        public string COMCOPackageID { get; set; }


       
        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }


        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }


        
        
        [JsonProperty("Amount")]
        [DataMember]
        public double Amount { get; set; }


        
        [JsonProperty("ServicesCharges")]
        [DataMember]
        public double ServicesCharges { get; set; }


       
        [JsonProperty("BankName")]
        [DataMember]
        public string BankName { get; set; }


        
        [JsonProperty("ExpiryDate")]
        [DataMember]
        public string ExpiryDate { get; set; }



       
        [JsonProperty("CautionAmount")]
        [DataMember]
        public double CautionAmount { get; set; }


       
        [JsonProperty("ChequeDetails")]
        [DataMember]
        public string ChequeDetails { get; set; }


       
        [JsonProperty("Mode")]
        [DataMember]
        public string Mode { get; set; }


        [JsonProperty("InvoiceIntervalType")]
        [DataMember]
        public string InvoiceIntervalType { get; set; }

        [JsonProperty("CreatedDate")]
        [DataMember]
        public string CreatedDate { get; set; }

        [JsonProperty("ContractDetails")]
        [DataMember]
        public string ContractDetails { get; set; }

        [JsonProperty("REQID")]
        [DataMember]
        public string REQID { get; set; }


    }
}
