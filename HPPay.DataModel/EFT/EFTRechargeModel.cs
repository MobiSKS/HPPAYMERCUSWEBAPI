using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.EFT
{
    public class EFTRechargeModel : BaseClass
    {
        [JsonPropertyName("ControlCardNumber")]
        [DataMember]
        public Int64 ControlCardNumber { get; set; }

        [JsonPropertyName("PaymentDate")]
        [DataMember]
        public string PaymentDate { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }


        [JsonPropertyName("IFSCCode")]
        [DataMember]
        public string IFSCCode { get; set; }

        [JsonPropertyName("BankName")]
        [DataMember]
        public string BankName { get; set; }

        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }

        [JsonPropertyName("SenderName ")]
        [DataMember]
        public string SenderName { get; set; }

        [JsonPropertyName("ProductCode ")]
        [DataMember]
        public string ProductCode { get; set; }

        [JsonPropertyName("SenderAccount")]
        [DataMember]
        public string SenderAccount { get; set; }
    }
    public class EFTRechargeDataValidationInput
    {
        [JsonPropertyName("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }
    }
    public class EFTRechargeDataValidationDetails : BaseClassOutput
    {
        [JsonPropertyName("TotalRecords")]
        [DataMember]
        public int TotalRecords { get; set; }

        [JsonPropertyName("ValidRecords")]
        [DataMember]
        public int ValidRecords { get; set; }

        [JsonPropertyName("ValidRecordsAmount")]
        [DataMember]
        public double ValidRecordsAmount { get; set; }

        [JsonPropertyName("InvalidRecords")]
        [DataMember]
        public int InvalidRecords { get; set; }

        [JsonPropertyName("InvalidRecordsAmount")]
        [DataMember]
        public double InvalidRecordsAmount { get; set; }

        [JsonPropertyName("InvalidRecordsRowNo")]
        [DataMember]
        public string InvalidRecordsRowNo { get; set; }

        public List<EFTRechargeDataValidationOutput> eFTRechargeDataValidationOutputsLst { get; set; }
    }
    public class EFTRechargeDataValidationOutput : BaseClassOutput
    {
        [JsonPropertyName("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }

        [JsonPropertyName("PaymentDate")]
        [DataMember]
        public string PaymentDate { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }


        [JsonPropertyName("IFSCCode")]
        [DataMember]
        public string IFSCCode { get; set; }

        [JsonPropertyName("BankName")]
        [DataMember]
        public string BankName { get; set; }

        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }

        [JsonPropertyName("SenderName ")]
        [DataMember]
        public string SenderName { get; set; }

        [JsonPropertyName("ProductCode ")]
        [DataMember]
        public string ProductCode { get; set; }

        [JsonPropertyName("SenderAccount")]
        [DataMember]
        public string SenderAccount { get; set; }


    }
    public class EFTRechargeDataOutput : BaseClassOutput
    {
        [JsonPropertyName("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }


    }

    public class EFTRechargeDataValidation : BaseClass
    {
        [Required]
        [JsonPropertyName("TransactionDetailFile")]
        [DataMember]
        public IFormFile TransactionDetailFile { get; set; }
    }
    public class EFTRechargeDataInsert : BaseClass
    {
        [Required]
        [JsonPropertyName("TransactionDetailFile")]
        [DataMember]
        public IFormFile TransactionDetailFile { get; set; }
    }
    public class EFTRechargePendingForApprovalInput : BaseClass
    {
        //[JsonPropertyName("CustomerId")]
        //[DataMember]
        //public string CustomerId { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [JsonPropertyName("BatchCode")]
        [DataMember]
        public string BatchCode { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }

        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }
    }

    public class EFTRechargePendingForApprovalOutput
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("PaymentDate")]
        [DataMember]
        public string PaymentDate { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }

        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }

        [JsonPropertyName("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }

        [JsonPropertyName("BatchCode")]
        [DataMember]
        public string BatchCode { get; set; }

        [JsonPropertyName("RequestedBy")]
        [DataMember]
        public string RequestedBy { get; set; }

        [JsonPropertyName("RequestedOn")]
        [DataMember]
        public string RequestedOn { get; set; }
    }

    public class EFTRechargeApprovalInput : BaseClass
    {
        public List<EFTRechargeApprovalInputData> lstinput { get; set; }

    }
    public class EFTRechargeApprovalInputData
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }

        [JsonPropertyName("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }

        [JsonPropertyName("Comment")]
        [DataMember]
        public string Comment { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }

        
    }
    public class EFTRechargeApprovalOutput : BaseClassOutput
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


    }

    public class EFTRechargeRejectionInput : BaseClass
    {
        public List<EFTRechargeRejectionInputData> lstRejectioninput { get; set; }
    }
    public class EFTRechargeRejectionInputData
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }
        
        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }

        [JsonPropertyName("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }

        
    }
    public class EFTRechargeRejectionOutput : BaseClassOutput
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


    }

    public class EFTRechargeReversalSearchInput : BaseClass
    {
        //[JsonPropertyName("CustomerId")]
        //[DataMember]
        //public string CustomerId { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [JsonPropertyName("BatchCode")]
        [DataMember]
        public string BatchCode { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }

        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }
    }

    public class EFTRechargeReversalSearchOutput
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }

        [JsonPropertyName("TxnDate")]
        [DataMember]
        public string TxnDate { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }


        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }

        [JsonPropertyName("BatchCode ")]
        [DataMember]
        public string BatchCode { get; set; }

        [JsonPropertyName("RequestedBy ")]
        [DataMember]
        public string RequestedBy { get; set; }

        [JsonPropertyName("RequestedOn")]
        [DataMember]
        public string RequestedOn { get; set; }

        [JsonPropertyName("ApprovedOn")]
        [DataMember]
        public string ApprovedOn { get; set; }

        [JsonPropertyName("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }

    }

    public class EFTRechargeReversalRequestDetailInput
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }

        [JsonPropertyName("TxnDate")]
        [DataMember]
        public string TxnDate { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }


        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }

        [JsonPropertyName("BatchId ")]
        [DataMember]
        public string BatchId { get; set; }

        [JsonPropertyName("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }

        [JsonPropertyName("RechargeReversalComment")]
        [DataMember]
        public string RechargeReversalComment { get; set; }
    }
    public class EFTRechargeReversalRequestInput : BaseClass
    {

        [JsonPropertyName("ObjEFTRechargeReversalRequestDetailInput")]
        [DataMember]
        public List<EFTRechargeReversalRequestDetailInput> ObjEFTRechargeReversalRequestDetailInput { get; set; }

        //[JsonPropertyName("RequestedBy ")]
        //[DataMember]
        //public string RequestedBy { get; set; }

        //[JsonPropertyName("RequestedOn")]
        //[DataMember]
        //public string RequestedOn { get; set; }

        //[JsonPropertyName("ApprovedOn")]
        //[DataMember]
        //public string ApprovedOn { get; set; }

        [JsonPropertyName("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }

    }
    public class EFTRechargeReversalRequestOutput : BaseClassOutput
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


    }


    public class EFTRechargeReversalPendingForApprovalInput : BaseClass
    {
        //[JsonPropertyName("CustomerId")]
        //[DataMember]
        //public string CustomerId { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [JsonPropertyName("BatchCode")]
        [DataMember]
        public string BatchCode { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }

        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }
    }

    public class EFTRechargeReversalPendingForApprovalOutput
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }

        [JsonPropertyName("TxnDate")]
        [DataMember]
        public string TxnDate { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }


        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }

        [JsonPropertyName("RequestedBy ")]
        [DataMember]
        public string RequestedBy { get; set; }

        [JsonPropertyName("RequestedOn")]
        [DataMember]
        public string RequestedOn { get; set; }

        [JsonPropertyName("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }

        [JsonPropertyName("BatchCode")]
        [DataMember]
        public string BatchCode { get; set; }

        [JsonPropertyName("Comment")]
        [DataMember]
        public string Comment { get; set; }
        
    }
    public class EFTRechargeReversalApprovalInput : BaseClass
    {
        public List<EFTRechargeReversalApprovalInputData> eFTRechargeReversalApprovalLst { get; set; }
    }
    public class EFTRechargeReversalApprovalInputData
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }

        [JsonPropertyName("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }

        [JsonPropertyName("Comment")]
        [DataMember]
        public string Comment { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }

        
    }
    public class EFTRechargeReversalApprovalOutput : BaseClassOutput
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


    }
    public class EFTReversalRejectionInput : BaseClass
    {
        public List<EFTReversalRejectionInputData> eFTReversalRejectionInputDatas { get; set; }
    }
    public class EFTReversalRejectionInputData
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }

        [JsonPropertyName("ReferenceNo")]
        [DataMember]
        public string ReferenceNo { get; set; }

        [JsonPropertyName("Comment")]
        [DataMember]
        public string Comment { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }
    }
    public class EFTReversalRejectionOutput : BaseClassOutput
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


    }

    public class ViewEFTRequestInput : BaseClass
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [JsonPropertyName("BatchCode")]
        [DataMember]
        public string BatchCode { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }

        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }
    }

    public class ViewEFTRequestOutput
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }

        [JsonPropertyName("TxnDate")]
        [DataMember]
        public string TxnDate { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }


        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }

        [JsonPropertyName("BatchCode ")]
        [DataMember]
        public string BatchCode { get; set; }

        [JsonPropertyName("RequestedBy ")]
        [DataMember]
        public string RequestedBy { get; set; }

        [JsonPropertyName("RequestedOn")]
        [DataMember]
        public string RequestedOn { get; set; }

        

        [JsonPropertyName("RequestStatus")]
        [DataMember]
        public string RequestStatus { get; set; }

        [JsonPropertyName("EFTType")]
        [DataMember]
        public string EFTType { get; set; }

        [JsonPropertyName("ApprovedRejectedBy")]
        [DataMember]
        public string ApprovedRejectedBy { get; set; }


        [JsonPropertyName("ApprovedRejectedOn")]
        [DataMember]
        public string ApprovedRejectedOn { get; set; }

        [JsonPropertyName("Remarks")]
        [DataMember]
        public string Remarks { get; set; }


        [JsonPropertyName("ReversalDetails")]
        [DataMember]
        public string ReversalDetails { get; set; }
    }




    public class ViewEFTReverseDetailInput : BaseClass
    {

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

       
        [JsonPropertyName("BatchCode")]
        [DataMember]
        public string BatchCode { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }

        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }

         
    }

    public class ViewEFTReverseDetailOutput
    {
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("UTRNumber")]
        [DataMember]
        public string UTRNumber { get; set; }

        [JsonPropertyName("TxnDate")]
        [DataMember]
        public string TxnDate { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }


        [JsonPropertyName("TransRefNumber")]
        [DataMember]
        public string TransRefNumber { get; set; }

        [JsonPropertyName("BatchCode ")]
        [DataMember]
        public string BatchCode { get; set; }

        [JsonPropertyName("RequestedBy ")]
        [DataMember]
        public string RequestedBy { get; set; }

        [JsonPropertyName("RequestedOn")]
        [DataMember]
        public string RequestedOn { get; set; }



        [JsonPropertyName("RequestStatus")]
        [DataMember]
        public string RequestStatus { get; set; }

        [JsonPropertyName("EFTType")]
        [DataMember]
        public string EFTType { get; set; }

        [JsonPropertyName("ApprovedRejectedBy")]
        [DataMember]
        public string ApprovedRejectedBy { get; set; }


        [JsonPropertyName("ApprovedRejectedOn")]
        [DataMember]
        public string ApprovedRejectedOn { get; set; }

        [JsonPropertyName("MakerRemarks")]
        [DataMember]
        public string MakerRemarks { get; set; }


        [JsonPropertyName("CheckerRemarks")]
        [DataMember]
        public string CheckerRemarks { get; set; }
    }

}
