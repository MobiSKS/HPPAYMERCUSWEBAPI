using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.AggregatorCustomer
{
    public class AggregatorCustomerApprovalModelInput : BaseClass
    {
        //[Required]
        //[JsonPropertyName("CustomerReferenceNo")]
        //[DataMember]
        //public string CustomerReferenceNo { get; set; }

       


        [Required]
        [JsonPropertyName("Approvalstatus")]
        [DataMember]
        public Int32 Approvalstatus { get; set; }

        [Required]
        [JsonPropertyName("ApprovedBy")]
        [DataMember]
        public string ApprovedBy { get; set; }

        [Required]
        [JsonPropertyName("CustomerDetail")]
        [DataMember]
        public List<CustomerDetailList> CustomerDetail { get; set; }
    }

    public class CustomerDetailList 
    {
        [Required]
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [Required]
        [JsonPropertyName("Comments")]
        [DataMember]
        public string Comments { get; set; }

    }
    public class AggregatorCustomerApprovalModelOutput : BaseClassOutput
    {

        [JsonProperty("FirstName")]
        [DataMember]
        public string FirstName { get; set; }


        [JsonProperty("LastName")]
        [DataMember]
        public string LastName { get; set; }


        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }


        [JsonProperty("Password")]
        [DataMember]
        public string Password { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [JsonProperty("SendStatus")]
        [DataMember]
        public int SendStatus { get; set; }

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonProperty("CommunicationMobileNo")]
        [DataMember]
        public string CommunicationMobileNo { get; set; }
    }


    public class AggregatorCustomerFeewaiverApprovalModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerReferenceNo")]
        [DataMember]
        public Int64 CustomerReferenceNo { get; set; }

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

    public class AggregatorCustomerFeewaiverApprovalModelOutput : BaseClassOutput
    {

    }

    public class GetApproveAggregatorFeeWaiverDetailModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerReferenceNo")]
        [DataMember]
        public Int64 CustomerReferenceNo { get; set; }
    }


    public class GetApproveAggregatorFeeWaiverDetailModelOutput
    {
        [JsonProperty("GetApproveAggregatorFeeWaiverBasicDetail")]
        public List<GetApproveAggregatorFeeWaiverBasicDetailModelOutput> GetApproveAggregatorFeeWaiverBasicDetail { get; set; }

        [JsonProperty("GetApproveAggregatorFeeWaiverCardDetail")]
        public List<GetApproveAggregatorFeeWaiverCardDetailModelOutput> GetApproveAggregatorFeeWaiverCardDetail { get; set; }
    }

    public class GetApproveAggregatorFeeWaiverBasicDetailModelOutput
    {
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
        public DateTime FeePaymentDate { get; set; }


        [JsonProperty("CustomerTypeId")]
        [DataMember]
        public Int32 CustomerTypeId { get; set; }

        [JsonProperty("CustomerTypeName")]
        [DataMember]
        public string CustomerTypeName { get; set; }

    }

    public class GetApproveAggregatorFeeWaiverCardDetailModelOutput
    {

        [JsonProperty("SrNumber")]
        [DataMember]
        public string SrNumber { get; set; }


        [JsonProperty("CardIdentifier")]
        [DataMember]
        public string CardIdentifier { get; set; }


        [JsonProperty("VehicleType")]
        [DataMember]
        public string VehicleType { get; set; }


        [JsonProperty("VehicleMake")]
        [DataMember]
        public string VehicleMake { get; set; }


        [JsonProperty("YearOfRegistration")]
        [DataMember]
        public Int32 YearOfRegistration { get; set; }

        [JsonProperty("VechileOwnerName")]
        [DataMember]
        public string VechileOwnerName { get; set; }

        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }


        [JsonProperty("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }



    }

    
}
