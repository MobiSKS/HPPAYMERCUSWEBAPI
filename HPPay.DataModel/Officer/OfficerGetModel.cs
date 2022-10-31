using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Officer
{
    

    public class GetOfficerModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("OfficerType")]
        [DataMember]
        public int OfficerType { get; set; }

        [JsonPropertyName("Location")]
        [DataMember]
        public int Location { get; set; }
    }

    public class BindOfficerModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("OfficerID")]
        [DataMember]
        public int OfficerID { get; set; }
 
    }

    
    public class GetOfficerModelOutput
    {

        [JsonProperty("OfficerTypeID")]
        [DataMember]
        public int OfficerTypeID { get; set; }

        [JsonProperty("OfficerTypeName")]
        [DataMember]
        public string OfficerTypeName { get; set; }

        [JsonProperty("OfficerID")]
        [DataMember]
        public int OfficerID { get; set; }

        [JsonProperty("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        [DataMember]
        public string LastName { get; set; }

        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonProperty("Address1")]
        [DataMember]
        public string Address1 { get; set; }

        [JsonProperty("Address2")]
        [DataMember]
        public string Address2 { get; set; }

        [JsonProperty("Address3")]
        [DataMember]
        public string Address3 { get; set; }

        [JsonProperty("Pin")]
        [DataMember]
        public string Pin { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonProperty("PhoneNo")]
        [DataMember]
        public string PhoneNo { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }


        [JsonProperty("Fax")]
        [DataMember]
        public string Fax { get; set; }

        [JsonProperty("ReferenceId")]
        [DataMember]
        public string ReferenceId { get; set; }


        [JsonProperty("Createdby")]
        [DataMember]
        public string Createdby { get; set; }

        //[JsonProperty("LocationId")]
        //[DataMember]
        //public int LocationId { get; set; }
       

        [JsonProperty("StateId")]
        [DataMember]
        public int StateId { get; set; }

        [JsonProperty("CityId")]
        [DataMember]
        public int CityId { get; set; }

        [JsonProperty("DistrictId")]
        [DataMember]
        public int DistrictId { get; set; }


        [JsonProperty("DistrictName")]
        [DataMember]
        public string DistrictName { get; set; }

        [JsonProperty("StateName")]
        [DataMember]
        public string StateName { get; set; }


        [JsonProperty("CityName")]
        [DataMember]
        public string CityName { get; set; }


        [JsonProperty("Location")]
        [DataMember]
        public string Location { get; set; }

    }

    public class GetOfficerLocationMappingModelOutput
    {

        [JsonProperty("OfficerId")]
        [DataMember]
        public int OfficerId { get; set; }

        [JsonProperty("ZoneValue")]
        [DataMember]
        public string ZoneValue { get; set; }

        [JsonProperty("ZOId")]
        [DataMember]
        public int ZOId { get; set; }

        [JsonProperty("ZOName")]
        [DataMember]
        public string ZOName { get; set; }


        [JsonProperty("ROId")]
        [DataMember]
        public int ROId { get; set; }

        [JsonProperty("ROName")]
        [DataMember]
        public string ROName { get; set; }

        [JsonProperty("Username")]
        [DataMember]
        public string Username { get; set; }

    }


    

    public class GetOfficerDetailModelInput : BaseClass
    {
        [JsonPropertyName("ZO")]
        [DataMember]
        public string ZO { get; set; }

        [JsonPropertyName("RO")]
        [DataMember]
        public string RO { get; set; }

        [JsonPropertyName("StateId")]
        [DataMember]
        public string StateId { get; set; }

        [JsonPropertyName("DistrictId")]
        [DataMember]
        public string DistrictId { get; set; }

    }

    public class GetOfficerDetailModelOutput
    {
        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }


        [JsonProperty("StateName")]
        [DataMember]
        public string StateName { get; set; }


        [JsonProperty("DistrictName")]
        [DataMember]
        public string DistrictName { get; set; }


        [JsonProperty("MarketingOfficerName")]
        [DataMember]
        public string MarketingOfficerName { get; set; }


        [JsonProperty("MarketingOfficerEmail")]
        [DataMember]
        public string MarketingOfficerEmail { get; set; }


        [JsonProperty("ZonalOfficerName")]
        [DataMember]
        public string ZonalOfficerName { get; set; }


        [JsonProperty("ZonalOfficerEmail")]
        [DataMember]
        public string ZonalOfficerEmail { get; set; }


    }
}
