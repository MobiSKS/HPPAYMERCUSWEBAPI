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
    

    public class ViewCreditLimitModelInput : BaseClass
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

        
        [JsonPropertyName("Status")]
        [DataMember]
        public int Status { get; set; }


    }
    public class ViewCreditLimitModelOutput : BaseClassOutput
    {


        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }


        



        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }


        [JsonProperty("COMCOPackageID")]
        [DataMember]
        public string COMCOPackageID { get; set; }

        [JsonProperty("Amount")]
        [DataMember]
        public double Amount { get; set; }


        [JsonProperty("FinanceCharges")]
        [DataMember]
        public double FinanceCharges { get; set; }



        [JsonProperty("CautionAmount")]
        [DataMember]
        public double CautionAmount { get; set; }




        [JsonProperty("ChequeDetails")]
        [DataMember]
        public string ChequeDetails { get; set; }

        [JsonProperty("Mode")]
        [DataMember]
        public string Mode { get; set; }





        [JsonProperty("Status1")]
        [DataMember]
        public string Status1 { get; set; }
        



        [JsonProperty("InvoiceIntervalType")]
        [DataMember]
        public string InvoiceIntervalType { get; set; }

        [JsonProperty("CreatedDate")]
        [DataMember]
        public string CreatedDate { get; set; }


        [JsonProperty("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonProperty("Approved_RejectedBy")]
        [DataMember]
        public string Approved_RejectedBy { get; set; }


        [JsonProperty("Approved_RejectedDate")]
        [DataMember]
        public string Approved_RejectedDate { get; set; }

        [JsonProperty("ContractDetails")]
        [DataMember]
        public string ContractDetails { get; set; }

        [JsonProperty("Remarks")]
        [DataMember]
        public string Remarks { get; set; }

        [JsonProperty("REQID")]
        [DataMember]
        public string REQID { get; set; }

    }
}
