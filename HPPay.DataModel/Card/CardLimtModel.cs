﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
namespace HPPay.DataModel.Card
{
    public class GetCardLimtModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }
    }

    public class GetCardLimtModelOutput
    {
        [JsonProperty("GetCardsDetailsModelOutput")]
        public List<GetCardsDetailsModelOutput> GetCardsDetails { get; set; }

        [JsonProperty("GetCardLimtModel")]
        public List<CardLimtModelOutput> GetCardLimt { get; set; }

        //[JsonProperty("CardReminingLimt")]
        //public List<CardReminingLimtModelOutput> CardReminingLimt { get; set; }

        //[JsonProperty("CardReminingCCMSLimt")]
        //public List<CardReminingCCMSLimtModelOutput> CardReminingCCMSLimt { get; set; }

        [JsonProperty("CardServices")]
        public List<CardServicesModelOutput> CardServices { get; set; }
    }

    public class CardLimtModelOutput
    {
         
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        //[Required]
        [JsonProperty("CardBalance")]
        [DataMember]
        public decimal CardBalance { get; set; }


        //[Required]
        [JsonProperty("CardStatus")]
        [DataMember]
        public string CardStatus { get; set; }


        //[Required]
        [JsonProperty("SaleTranscationLimit")]
        [DataMember]
        public decimal SaleTranscationLimit { get; set; }


        //[Required]
        [JsonProperty("DailySaleLimit")]
        [DataMember]
        public decimal DailySaleLimit { get; set; }


        //[Required]
        [JsonProperty("DailyCreditLimit")]
        [DataMember]
        public decimal DailyCreditLimit { get; set; }

        //[Required]
        [JsonProperty("CashPurseLimit")]
        [DataMember]
        public decimal CashPurseLimit { get; set; }

        //[Required]
        [JsonProperty("MonthlySaleLimit")]
        [DataMember]
        public decimal MonthlySaleLimit { get; set; }

        //[Required]
        [JsonProperty("MonthlySaleBalance")]
        [DataMember]
        public decimal MonthlySaleBalance { get; set; }

        //[Required]
        [JsonProperty("CCMSReloadSale")]
        [DataMember]
        public decimal CCMSReloadSale { get; set; }


        //[Required]
        [JsonProperty("CCMSReloadSaleLimit")]
        [DataMember]
        public string CCMSReloadSaleLimit { get; set; }


        [JsonProperty("CCMSReloadSaleLimitValue")]
        [DataMember]
        public decimal CCMSReloadSaleLimitValue { get; set; }

        [JsonProperty("ExpiryDate")]
        [DataMember]
        public string ExpiryDate { get; set; }

        [JsonProperty("AllowCreditTranscation")]
        [DataMember]
        public string AllowCreditTranscation { get; set; }


    }

    //public class CardReminingLimtModelOutput
    //{

    //    //[Required]
    //    [JsonProperty("RemCardDaily")]
    //    [DataMember]
    //    public decimal RemCardDaily { get; set; }

    //    //[Required]
    //    [JsonProperty("RemCardMonthly")]
    //    [DataMember]
    //    public decimal RemCardMonthly { get; set; }

    //    //[Required]
    //    [JsonProperty("RemCardYearly")]
    //    [DataMember]
    //    public decimal RemCardYearly { get; set; }

    //}

    //public class CardReminingCCMSLimtModelOutput
    //{

    //    //[Required]
    //    [JsonProperty("RemCCMSDaily")]
    //    [DataMember]
    //    public decimal RemCCMSDaily { get; set; }

    //    //[Required]
    //    [JsonProperty("RemCCMSMonthly")]
    //    [DataMember]
    //    public decimal RemCCMSMonthly { get; set; }

    //    //[Required]
    //    [JsonProperty("RemCCMSYearly")]
    //    [DataMember]
    //    public decimal RemCCMSYearly { get; set; }

    //}

    public class CardServicesModelOutput
    {

        //[Required]
        [JsonProperty("ServiceID")]
        [DataMember]
        public string ServiceID { get; set; }

        //[Required]
        [JsonProperty("ServiceName")]
        [DataMember]
        public string ServiceName { get; set; }

        //[Required]
        [JsonProperty("SelectedServices")]
        [DataMember]
        public int SelectedServices { get; set; }

    }


    public class GetCardsDetailsModelOutput
    {
        [JsonProperty("SrNumber")]
        [DataMember]
        public int SrNumber { get; set; }

        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }


        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("UserID")]
        [DataMember]
        public string UserID { get; set; }

        [JsonProperty("RequestDate")]
        [DataMember]
        public string RequestDate { get; set; }


        [JsonProperty("OwnedorAttachedId")]
        [DataMember]
        public int OwnedorAttachedId { get; set; }


        [JsonProperty("OwnedorAttached")]
        [DataMember]
        public string OwnedorAttached { get; set; }


        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }


        [JsonProperty("VehicleType")]
        [DataMember]
        public string VehicleType { get; set; }


        [JsonProperty("IssueDate")]
        [DataMember]
        public string IssueDate { get; set; }


        [JsonProperty("ExpiryDate")]
        [DataMember]
        public string ExpiryDate { get; set; }


        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }


        [JsonProperty("YearOfRegistration")]
        [DataMember]
        public int YearOfRegistration { get; set; }


        [JsonProperty("Manufacturer")]
        [DataMember]
        public string Manufacturer { get; set; }


        [JsonProperty("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }

        [JsonProperty("VINNumber")]
        [DataMember]
        public string VINNumber { get; set; }


        [JsonProperty("VehicleMake")]
        [DataMember]
        public string VehicleMake { get; set; }

        [JsonProperty("OwnershipType")]
        [DataMember]
        public string OwnershipType { get; set; }

        [JsonProperty("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

        [JsonProperty("CardCategory")]
        [DataMember]
        public string CardCategory { get; set; }

        [JsonProperty("CardIssueType")]
        [DataMember]
        public string CardIssueType { get; set; }

        [JsonProperty("CardIdentifier")]
        [DataMember]
        public string CardIdentifier { get; set; }


        [JsonProperty("FeePaymentsCollectFeeWaiverId")]
        [DataMember]
        public int FeePaymentsCollectFeeWaiverId { get; set; }

        [JsonProperty("FeePaymentsCollectFeeWaiver")]
        [DataMember]
        public string FeePaymentsCollectFeeWaiver { get; set; }


        [JsonProperty("FeePaymentNo")]
        [DataMember]
        public string FeePaymentNo { get; set; }


        [JsonProperty("FeePaymentDate")]
        [DataMember]
        public string FeePaymentDate { get; set; }

        [JsonProperty("RBEId")]
        [DataMember]
        public string RBEId { get; set; }

        [JsonProperty("RbeName")]
        [DataMember]
        public string RbeName { get; set; }

        [JsonProperty("CardPreference")]
        [DataMember]
        public string CardPreference { get; set; }
    }


    public class GetCcmsToCardBalanceTransferModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }


        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }
    }

    public class GetCcmsToCardBalanceTransferModelOutput:BaseClassOutput
    {
        [JsonProperty("AvailableCcmsBalanceModelOutput")]
        public List<AvailableCcmsBalanceModelOutput> ObjAvailableCcmsBalance { get; set; }

        [JsonProperty("GetCcmsToCardBalanceTransferDetailModelOutput")]
        public List<GetCcmsToCardBalanceTransferDetailModelOutput> ObjCcmsToCardBalanceTransferDetail { get; set; }
 
    }

    public class AvailableCcmsBalanceModelOutput
    {

        [JsonProperty("AvailableCcmsBalance")]
        [DataMember]
        public decimal AvailableCcmsBalance { get; set; }
    }

    public class GetCcmsToCardBalanceTransferDetailModelOutput : BaseClassOutput
    {
        [JsonProperty("SrNumber")]
        [DataMember]
        public int SrNumber { get; set; }


        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [JsonProperty("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }


        [JsonProperty("IssueDate")]
        [DataMember]
        public string IssueDate { get; set; }

        [JsonProperty("ExpiryDate")]
        [DataMember]
        public string ExpiryDate { get; set; }

        [JsonProperty("CardStatus")]
        [DataMember]
        public string CardStatus { get; set; }

        [JsonProperty("Balance")]
        [DataMember]
        public decimal Balance { get; set; }

        [JsonProperty("CashPurseLimit")]
        [DataMember]
        public decimal CashPurseLimit { get; set; }

        [JsonProperty("CCMSLimit")]
        [DataMember]
        public string CCMSLimit { get; set; }

        [JsonProperty("CCMSLimitValue")]
        [DataMember]
        public decimal CCMSLimitValue { get; set; }

    }
}



