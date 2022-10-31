using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{

    public class MerchantViewCardMerchantAllocationModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

    
    }

    public class ViewCardDealerAllocationModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
    }


    public class MerchantTotalCardModelOutput : BaseClassOutput
    {
        [JsonProperty("TotalAllocatedCards")]
        [DataMember]
        public Int32 TotalAllocatedCards { get; set; }

        [JsonProperty("TotalMappedCards")]
        [DataMember]
        public Int32 TotalMappedCards { get; set; }


        [JsonProperty("TotalUnmappedCards")]
        [DataMember]
        public Int32 TotalUnmappedCards { get; set; }
    }

    public class MerchantViewCardMerchantDetailModelOutput 
    {
        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("AllocationDate")]
        [DataMember]
        public string AllocationDate { get; set; }

        [JsonProperty("MappingDate")]
        [DataMember]
        public string MappingDate { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }


        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }



    }

    public class MerchantViewCardMerchantAllocationModelOutput 
    {
        [JsonProperty("ObjMerchantTotalCardDetail")]
        public List<MerchantTotalCardModelOutput> ObjMerchantTotalCardDetail { get; set; }

        [JsonProperty("ObjMerchantViewCardDetail")]
        public List<MerchantViewCardMerchantDetailModelOutput> ObjMerchantViewCardDetail { get; set; }

    }


    public class CardRequestEntryModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("RegionalId")]
        [DataMember]
        public Int32 RegionalId { get; set; }

        [Required]
        [JsonPropertyName("NoofCards")]
        [DataMember]
        public Int32 NoofCards { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }
    public class CardRequestEntryModelOutput : BaseClassOutput
    {

    }


    public class GetCardAllocationActivationModelInput : BaseClass
    {

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


        [JsonPropertyName("ZonalOfficeId")]
        [DataMember]
        public string ZonalOfficeId { get; set; }

        [JsonPropertyName("RegionalOfficeId")]
        [DataMember]
        public string RegionalOfficeId { get; set; }

        [JsonPropertyName("SBUTypeId")]
        [DataMember]
        public int SBUTypeId { get; set; }
    }

    public class GetCardAllocationActivationModelOutput
    {
        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }

        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("MappingDate")]
        [DataMember]
        public string MappingDate { get; set; }

        [JsonProperty("AllocatedMID")]
        [DataMember]
        public string AllocatedMID { get; set; }

        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }

        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("AllocationDate")]
        [DataMember]
        public string AllocationDate { get; set; }


        [JsonProperty("FirstTransactionDate")]
        [DataMember]
        public string FirstTransactionDate { get; set; }

        [JsonProperty("IsDTPCustomer")]
        [DataMember]
        public string IsDTPCustomer { get; set; }


        [JsonProperty("SBUName")]
        [DataMember]
        public string SBUName { get; set; }

        [JsonProperty("SBUTypeId")]
        [DataMember]
        public int SBUTypeId { get; set; }
    }

    public class VerifyOTCCardCustomerModelInput : BaseClass
    {

        [JsonPropertyName("RegionalOfficeId")]
        [DataMember]
        public Int32 RegionalOfficeId { get; set; }

        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }
    }

    public class VerifyOTCCardCustomerModelOutput
    {
        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("CreatedDate")]
        [DataMember]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }

}
