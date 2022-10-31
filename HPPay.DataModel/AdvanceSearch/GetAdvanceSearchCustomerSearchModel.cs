using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AdvanceSearch
{
    public class GetAdvanceSearchCustomerSearchModelInput : BaseClass
    {

        [JsonPropertyName("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }


        [JsonPropertyName("IsCustomerNameExist")]
        [DataMember]
        public bool IsCustomerNameExist { get; set; }


        [JsonPropertyName("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }


        [JsonPropertyName("IsFormNumberExist")]
        [DataMember]
        public bool IsFormNumberExist { get; set; }


        [JsonPropertyName("Customerid")]
        [DataMember]
        public string Customerid { get; set; }


        [JsonPropertyName("IsCustomeridExist")]
        [DataMember]
        public bool IsCustomeridExist { get; set; }


        [JsonPropertyName("CustomerType")]
        [DataMember]
        public int CustomerType { get; set; }


        [JsonPropertyName("IsCustomerTypeExist")]
        [DataMember]
        public bool IsCustomerTypeExist { get; set; }


        [JsonPropertyName("RegionalOfficeID")]
        [DataMember]
        public int RegionalOfficeID { get; set; }


        [JsonPropertyName("IsRegionalOfficeExist")]
        [DataMember]
        public bool IsRegionalOfficeExist { get; set; }


        [JsonPropertyName("ZonalOfficeId")]
        [DataMember]
        public int ZonalOfficeId { get; set; }


        [JsonPropertyName("IsZonalOfficeExist")]
        [DataMember]
        public bool IsZonalOfficeExist { get; set; }


        [JsonPropertyName("Pincode")]
        [DataMember]
        public string Pincode { get; set; }

        [JsonPropertyName("IsPincodeExist")]
        [DataMember]
        public bool IsPincodeExist { get; set; }


        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonPropertyName("IsMobileExist")]
        [DataMember]
        public bool IsMobileExist { get; set; }
    }
    public class GetAdvanceSearchCustomerSearchModelOutput : BaseClassOutput
    {
        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
        [JsonProperty("CustomerType")]
        [DataMember]
        public string CustomerType { get; set; }

        [JsonProperty("RegionalOffice")]
        [DataMember]
        public string RegionalOffice { get; set; }
        [JsonProperty("ZonalOffice")]
        [DataMember]
        public string ZonalOffice { get; set; }
        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }

        //[JsonProperty("Status")]
        //[DataMember]
        //public string Status { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }
        [JsonProperty("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }
        [JsonProperty("City")]
        [DataMember]
        public string City { get; set; }
        [JsonProperty("State")]
        [DataMember]
        public string State { get; set; }
        [JsonProperty("OfficePhone")]
        [DataMember]
        public string OfficePhone { get; set; }
        [JsonProperty("PinCode")]
        [DataMember]
        public string PinCode { get; set; }
        [JsonProperty("Mobile")]
        [DataMember]
        public string Mobile { get; set; }
        [JsonProperty("Email")]
        [DataMember]
        public string Email { get; set; }
        [JsonProperty("District")]
        [DataMember]
        public string District { get; set; }
        [JsonProperty("SalesArea")]
        [DataMember]
        public string SalesArea { get; set; }
    }
}
