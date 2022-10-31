using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.JCB
{
    public class ManageJCBSearchCardsModelInput : BaseClass
    {
        //[Required]
        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }


        //[Required]
        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }

        //[Required]
        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }

        //[Required]
        [JsonPropertyName("Vehiclenumber")]
        [DataMember]
        public string Vehiclenumber { get; set; }


        //[Required]
        [JsonPropertyName("Statusflag")]
        [DataMember]
        public int Statusflag { get; set; }

    }

    public class ManageJCBSearchCardsModelOutput
    {
        [JsonProperty("SrNumber")]
        [DataMember]
        public int SrNumber { get; set; }

        [JsonProperty("IndividualOrgName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }


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
        public Int32 OwnedorAttachedId { get; set; }


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
        public Int32 YearOfRegistration { get; set; }


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

        [JsonProperty("LimitTypeId")]
        [DataMember]
        public Int32 LimitTypeId { get; set; }

        [JsonProperty("LimitTypeName")]
        [DataMember]
        public string LimitTypeName { get; set; }

        [JsonProperty("CCMSReloadSaleLimitValue")]
        [DataMember]
        public decimal CCMSReloadSaleLimitValue { get; set; }
    }
}
