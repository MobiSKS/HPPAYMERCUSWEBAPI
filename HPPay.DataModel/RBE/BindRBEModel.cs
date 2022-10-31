using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.RBE
{

    public class GetRBEDetailbyUserNameModelInput : BaseClass
    {
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }
    }

    public class GetRBEDetailbyUserNameModelOutput
    {
        [JsonProperty("Name")]
        [DataMember]
        public string Name { get; set; }

        [JsonProperty("RoleName")]
        [DataMember]
        public string RoleName { get; set; }

        [JsonProperty("Location")]
        [DataMember]
        public string Location { get; set; }

        [JsonProperty("IdProofTypeId")]
        [DataMember]
        public Int32 IdProofTypeId { get; set; }

        [JsonProperty("IdProofTypeName")]
        [DataMember]
        public string IdProofTypeName { get; set; }

        [JsonProperty("IdProofDocumentNo")]
        [DataMember]
        public string IdProofDocumentNo { get; set; }

        [JsonProperty("IdProofFront")]
        [DataMember]
        public string IdProofFront { get; set; }


        [JsonProperty("IdProofBack")]
        [DataMember]
        public string IdProofBack { get; set; }

        [JsonProperty("AddressProofTypeId")]
        [DataMember]
        public string AddressProofTypeId { get; set; }

        [JsonProperty("AddressProofTypeName")]
        [DataMember]
        public string AddressProofTypeName { get; set; }

        [JsonProperty("AddressProofDocumentNo")]
        [DataMember]
        public string AddressProofDocumentNo { get; set; }

        [JsonProperty("AddressProofFront")]
        [DataMember]
        public string AddressProofFront { get; set; }

        [JsonProperty("AddressProofBack")]
        [DataMember]
        public string AddressProofBack { get; set; }

        [JsonProperty("RBEPhoto")]
        [DataMember]
        public string RBEPhoto { get; set; }
    }

    public class BindRBEModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("RBEId")]
        [DataMember]
        public string RBEId { get; set; }

        [Required]
        [JsonPropertyName("DeviceId")]
        [DataMember]
        public string DeviceId { get; set; }
    }

    public class BindRBEModelOutput : BaseClassOutput
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

        [JsonProperty("RBEId")]
        [DataMember]
        public string RBEId { get; set; }

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

        [JsonProperty("RegionalOfficeId")]
        [DataMember]
        public int RegionalOfficeId { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("ZonalOfficeId")]
        [DataMember]
        public int ZonalOfficeId { get; set; }

        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }


    }
}
