using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{
    public class AddCardModelInput : BaseClass
    {
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [JsonPropertyName("NoOfCards")]
        [DataMember]
        public Int32 NoOfCards { get; set; }

        [JsonPropertyName("RBEId")]
        [DataMember]
        public string RBEId { get; set; }

        [JsonPropertyName("FeePaymentsCollectFeeWaiver")]
        [DataMember]
        public Int16 FeePaymentsCollectFeeWaiver { get; set; }


        [JsonPropertyName("FeePaymentNo")]
        [DataMember]
        public string FeePaymentNo { get; set; }


        [JsonPropertyName("FeePaymentDate")]
        [DataMember]
        public DateTime FeePaymentDate { get; set; }

        [JsonPropertyName("ObjCardDetail")]
        [DataMember]
        public List<CardDetail> ObjCardDetail { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("CardPreference")]
        [DataMember]
        public string CardPreference { get; set; }

        [JsonPropertyName("NoofVechileforAllCards")]
        [DataMember]
        public Int32 NoofVechileforAllCards { get; set; }

        [JsonPropertyName("VehicleNoVerifiedManually")]
        [DataMember]
        public Int32 VehicleNoVerifiedManually { get; set; }
    }

    public class CardDetail
    {
        [JsonPropertyName("CardIdentifier")]
        public string CardIdentifier { get; set; }

        [JsonPropertyName("VechileNo")]
        public string VechileNo { get; set; }

        [JsonPropertyName("VehicleType")]
        public string VehicleType { get; set; }

        [JsonPropertyName("VehicleMake")]
        public string VehicleMake { get; set; }

        [JsonPropertyName("YearOfRegistration")]
        public int YearOfRegistration { get; set; }

        [JsonPropertyName("MobileNo")]
        public string MobileNo { get; set; }

        [JsonPropertyName("CardId")]
        public int CardId { get; set; }

    }

    public class AddCardModelOutput : BaseClassOutput
    {

    }

    public class ApproveRejectAddOnCardModelInput : BaseClass
    {
        //[Required]
        //[JsonPropertyName("CustomerReferenceNo")]
        //[DataMember]
        //public Int64 CustomerReferenceNo { get; set; }

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


        [JsonPropertyName("ObjCardDetail")]
        [DataMember]
        public List<CardDetail> ObjCardDetail { get; set; }
    }
    public class ApproveRejectAddOnCardModelOutput : BaseClassOutput
    {

    }

    public class ApproveRejectCardModelInput : BaseClass
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

        [JsonPropertyName("ObjCardDetail")]
        [DataMember]
        public List<CardDetail> ObjCardDetail { get; set; }
    }
    public class ApproveRejectCardModelOutput : BaseClassOutput
    {
        [JsonProperty("TotalNoOfCards")]
        [DataMember]
        public Int32 TotalNoOfCards { get; set; }

        [JsonProperty("NoOfCardsVerified")]
        [DataMember]
        public Int32 NoOfCardsVerified { get; set; }
    }
}
