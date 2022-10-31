using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Card
{
    public class ApproveRejectAddOnCardWithPaymentModelInput:BaseClass
    {
     

        [Required]
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [Required]
        [JsonPropertyName("Comments")]
        [DataMember]
        public string Comments { get; set; }

        [Required]
        [JsonPropertyName("Approvalstatus")]
        [DataMember]
        public Int32 Approvalstatus { get; set; }

        [Required]
        [JsonPropertyName("ApprovedBy")]
        [DataMember]
        public string ApprovedBy { get; set; }

        

    }

    public class ApproveRejectAddOnCardWithPaymentModelOutput : BaseClassOutput
    {
    }

    public class BindPendingCustomerForAddOnCardWithPaymentApprovalModelInput : BaseClass 
    {
       

        [JsonPropertyName("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }


        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }


        [JsonPropertyName("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonPropertyName("RegionalOfficeId")]
        [DataMember]
        public string RegionalOfficeId { get; set; }
    }

    public class BindPendingCustomerForAddOnCardWithPaymentApprovalModelOutput  
    {
        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }


        [JsonProperty("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }


        [JsonProperty("CustomerReferenceNo")]
        [DataMember]
        public Int64 CustomerReferenceNo { get; set; }


        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }

        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }


        [JsonProperty("PaymentType")]
        [DataMember]
        public string PaymentType { get; set; }


        [JsonProperty("TotalCards")]
        [DataMember]
        public string TotalCards { get; set; }

        [JsonProperty("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }


        [JsonProperty("CreatedDate")]
        [DataMember]
        public string CreatedDate { get; set; }


        [JsonProperty("Action")]
        [DataMember]
        public string Action { get; set; }
    }



    public class GetCardDetailForAddOnCardWithPaymentApprovalModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }
    }

    public class GetCardDetailForAddOnCardWithPaymentApprovalModelOutput
    {

        [JsonProperty("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }


        [JsonProperty("VehicleMake")]
        [DataMember]
        public string VehicleMake { get; set; }

        [JsonProperty("VehicleType")]
        [DataMember]
        public string VehicleType { get; set; }

        [JsonProperty("YearOfRegistration")]
        [DataMember]
        public Int32 YearOfRegistration { get; set; }



        [JsonProperty("CardStatus")]
        [DataMember]
        public string CardStatus { get; set; }

        [JsonProperty("Remarks")]
        [DataMember]
        public string Remarks { get; set; }



        [JsonProperty("CustomerReferenceNo")]
        [DataMember]
        public Int64 CustomerReferenceNo { get; set; }

        [JsonProperty("CardPreference")]
        [DataMember]
        public string CardPreference { get; set; }


        [JsonProperty("FeePaymentsCollectFeeWaiverId")]
        [DataMember]
        public Int16 FeePaymentsCollectFeeWaiverId { get; set; }


        [JsonProperty("FeePaymentsCollectorFeeWaiver")]
        [DataMember]
        public string FeePaymentsCollectorFeeWaiver { get; set; }


        [JsonProperty("FeePaymentNo")]
        [DataMember]
        public string FeePaymentNo { get; set; }


        [JsonProperty("FeePaymentDate")]
        [DataMember]
        public string FeePaymentDate { get; set; }


        [JsonProperty("CardIdentifier")]
        [DataMember]
        public string CardIdentifier { get; set; }


        //[JsonProperty("VehicleType")]
        //[DataMember]
        //public string VehicleType { get; set; }


        //[JsonProperty("VehicleMake")]
        //[DataMember]
        //public string VehicleMake { get; set; }


        //[JsonProperty("YearOfRegistration")]
        //[DataMember]
        //public Int32 YearOfRegistration { get; set; }

        [JsonProperty("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }

        //[JsonProperty("RBEId")]
        //[DataMember]
        //public string RBEId { get; set; }

        //[JsonProperty("RbeName")]
        //[DataMember]
        //public string RbeName { get; set; }

        //[JsonProperty("VechileNo")]
        //[DataMember]
        //public string VechileNo { get; set; }

    }

}
