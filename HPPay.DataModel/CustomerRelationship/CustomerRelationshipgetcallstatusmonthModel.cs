using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerRelationship
{
    public class CustomerRelationshipgetcallstatusmonthModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("Month")]
        [DataMember]
        public string Month { get; set; }
    }
    public class CustomerRelationshipgetcallstatusmonthModelOutput : BaseClassOutput
    {

        [JsonProperty("SolicitationRelationshipDetails")]
        [DataMember]
        public List<GetRegionZoanlDetails> SolicitationRelationshipDetails { get; set; }

        [JsonProperty("BussinessSolicitationDetails")]
        [DataMember]
        public List<GetBussinessSolicitationDetails> BussinessSolicitationDetails { get; set; }

        [JsonProperty("CustomerRelationshipDetails")]
        [DataMember]
        public List<GetCustomerRelationshipDetails> CustomerRelationshipDetails { get; set; }

    }
    public class GetRegionZoanlDetails
    {
        
        [JsonProperty("ZonalOffice")]
        [DataMember]
        public string ZonalOffice { get; set; }

        [JsonProperty("RegionalOffice")]
        [DataMember]
        public string RegionalOffice { get; set; }

        [JsonProperty("SoilicitationCall")]
        [DataMember]
        public int SoilicitationCall { get; set; }

        [JsonProperty("RelationalCall")]
        [DataMember]
        public int RelationalCall { get; set; }

        [JsonProperty("totalcall")]
        [DataMember]
        public int totalcall { get; set; }
    }

    public class GetBussinessSolicitationDetails
    {

        [JsonProperty("RegionalOffice")]
        [DataMember]
        public string RegionalOffice { get; set; }

        [JsonProperty("MO")]
        [DataMember]
        public string MO { get; set; }

        [JsonProperty("TrackID")]
        [DataMember]
        public int TrackID { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("Location")]
        [DataMember]
        public string Location { get; set; }

        [JsonProperty("Potential")]
        [DataMember]
        public decimal Potential { get; set; }

        [JsonProperty("Lastvisitdate")]
        [DataMember]
        public string Lastvisitdate { get; set; }

        [JsonProperty("LastRemark")]
        [DataMember]
        public string LastRemark { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }

        [JsonProperty("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonProperty("MettingStatus")]
        [DataMember]
        public string MettingStatus { get; set; }

    }

    public class GetCustomerRelationshipDetails
    {

        [JsonProperty("RegionalOffice")]
        [DataMember]
        public string RegionalOffice { get; set; }

        [JsonProperty("MO")]
        [DataMember]
        public string MO { get; set; }

        [JsonProperty("RBEName")]
        [DataMember]
        public string RBEName { get; set; }

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("Potential")]
        [DataMember]
        public decimal Potential { get; set; }

        [JsonProperty("ActualVolume")]
        [DataMember]
        public decimal ActualVolume { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("Location")]
        [DataMember]
        public string Location { get; set; }


        [JsonProperty("LastVisitRemark")]
        [DataMember]
        public string LastVisitRemark { get; set; }


        [JsonProperty("LastVisitDate")]
        [DataMember]
        public string LastVisitDate { get; set; }


        [JsonProperty("MappingStatus")]
        [DataMember]
        public string MappingStatus { get; set; }

    }
}
