using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Merchant
{
    public class MerchantUpdateModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("ErpCode")]
        [DataMember]
        public string ErpCode { get; set; }

        [Required]
        [JsonPropertyName("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [Required]
        [JsonPropertyName("MerchantTypeId")]
        [DataMember]
        public Int32 MerchantTypeId { get; set; }


        //[Required]
        [JsonPropertyName("DealerName")]
        [DataMember]
        public string DealerName { get; set; }

       

        [Required]
        [JsonPropertyName("DealerMobileNo")]
        [DataMember]
        public string DealerMobileNo { get; set; }

        [Required]
        [JsonPropertyName("OutletCategoryId")]
        [DataMember]
        public Int32 OutletCategoryId { get; set; }

        //[Required]
        [JsonPropertyName("HighwayNo1")]
        [DataMember]
        public string HighwayNo1 { get; set; }

        //[Required]
        [JsonPropertyName("HighwayNo2")]
        [DataMember]
        public string HighwayNo2 { get; set; }


        //[Required]
        [JsonPropertyName("HighwayName")]
        [DataMember]
        public string HighwayName { get; set; }


        [Required]
        [JsonPropertyName("SBUTypeId")]
        [DataMember]
        public Int32 SBUTypeId { get; set; }


        //[Required]
        [JsonPropertyName("LPGCNGSale")]
        [DataMember]
        public decimal? LPGCNGSale { get; set; }


        [Required]
        [JsonPropertyName("PancardNumber")]
        [DataMember]
        public string PancardNumber { get; set; }



        //[Required]
        [JsonPropertyName("GSTNumber")]
        [DataMember]
        public string GSTNumber { get; set; }


        [Required]
        [JsonPropertyName("RetailOutletAddress1")]
        [DataMember]
        public string RetailOutletAddress1 { get; set; }


        [Required]
        [JsonPropertyName("RetailOutletAddress2")]
        [DataMember]
        public string RetailOutletAddress2 { get; set; }


        //[Required]
        [JsonPropertyName("RetailOutletAddress3")]
        [DataMember]
        public string RetailOutletAddress3 { get; set; }


        //[Required]
        [JsonPropertyName("RetailOutletLocation")]
        [DataMember]
        public string RetailOutletLocation { get; set; }


        [Required]
        [JsonPropertyName("RetailOutletCity")]
        [DataMember]
        public string RetailOutletCity { get; set; }


        [Required]
        [JsonPropertyName("RetailOutletStateId")]
        [DataMember]
        public Int32 RetailOutletStateId { get; set; }


        [Required]
        [JsonPropertyName("RetailOutletDistrictId")]
        [DataMember]
        public Int32 RetailOutletDistrictId { get; set; }


        [Required]
        [JsonPropertyName("RetailOutletPinNumber")]
        [DataMember]
        public string RetailOutletPinNumber { get; set; }


        //[Required]
        [JsonPropertyName("RetailOutletPhoneNumber")]
        [DataMember]
        public string RetailOutletPhoneNumber { get; set; }


        //[Required]
        [JsonPropertyName("RetailOutletFax")]
        [DataMember]
        public string RetailOutletFax { get; set; }


        [Required]
        [JsonPropertyName("ZonalOfficeId")]
        [DataMember]
        public Int32 ZonalOfficeId { get; set; }


        [Required]
        [JsonPropertyName("RegionalOfficeId")]
        [DataMember]
        public Int32 RegionalOfficeId { get; set; }


        [Required]
        [JsonPropertyName("SalesAreaId")]
        [DataMember]
        public Int32 SalesAreaId { get; set; }


        [Required]
        [JsonPropertyName("ContactPersonNameFirstName")]
        [DataMember]
        public string ContactPersonNameFirstName { get; set; }


        //[Required]
        [JsonPropertyName("ContactPersonNameMiddleName")]
        [DataMember]
        public string ContactPersonNameMiddleName { get; set; }

        //[Required]
        [JsonPropertyName("ContactPersonNameLastName")]
        [DataMember]
        public string ContactPersonNameLastName { get; set; }

        [Required]
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }


        [Required]
        [JsonPropertyName("EmailId")]
        [DataMember]
        //[RegularExpression("\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", ErrorMessage = "Invalid Email Id")]
        public string EmailId { get; set; }

        //[Required]
        [JsonPropertyName("Mics")]
        [DataMember]
        public string Mics { get; set; }

        //[Required]
        [JsonPropertyName("CommunicationAddress1")]
        [DataMember]
        public string CommunicationAddress1 { get; set; }

        //[Required]
        [JsonPropertyName("CommunicationAddress2")]
        [DataMember]
        public string CommunicationAddress2 { get; set; }

        //[Required]
        [JsonPropertyName("CommunicationAddress3")]
        [DataMember]
        public string CommunicationAddress3 { get; set; }

        //[Required]
        [JsonPropertyName("CommunicationLocation")]
        [DataMember]
        public string CommunicationLocation { get; set; }

        //[Required]
        [JsonPropertyName("CommunicationCity")]
        [DataMember]
        public string CommunicationCity { get; set; }

        //[Required]
        [JsonPropertyName("CommunicationStateId")]
        [DataMember]
        public Int32 CommunicationStateId { get; set; }

        //[Required]
        [JsonPropertyName("CommunicationDistrictId")]
        [DataMember]
        public Int32 CommunicationDistrictId { get; set; }


        //[Required]
        [JsonPropertyName("CommunicationPinNumber")]
        [DataMember]
        public string CommunicationPinNumber { get; set; }

        //[Required]
        [JsonPropertyName("CommunicationPhoneNumber")]
        [DataMember]
        public string CommunicationPhoneNumber { get; set; }

        //[Required]
        [JsonPropertyName("CommunicationFax")]
        [DataMember]
        public string CommunicationFax { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

    }
    public class MerchantUpdateModelOutput : BaseClassOutput
    {

        [JsonProperty("ReferenceId")]
        [DataMember]
        public string ReferenceId { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }


    }
}
