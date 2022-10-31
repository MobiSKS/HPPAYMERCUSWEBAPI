using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.DICV
{
    public  class GetDICVCustomerApplicationFormModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }


    public class GetDICVCustomerApplicationFormModelOutput:BaseClassOutput
    {
         [JsonProperty("DealerId")]
        [DataMember]
        public string DealerId { get; set; }

        [JsonProperty("FormNo")]
        [DataMember]
        public string FormNo { get; set; }

        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("SalesArea")]
        [DataMember]
        public string SalesArea { get; set; }

        [JsonProperty("CustomerTypeName")]
        [DataMember]
        public string CustomerTypeName { get; set; }

        [JsonProperty("Date")]
        [DataMember]
        public string Date { get; set; }

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("Customer/OrganisationName")]
        [DataMember]
        public string IndividualOrgName { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("HouseNo")]
        [DataMember]
        public string HouseNo { get; set; }

        [JsonProperty("Location")]
        [DataMember]
        public string Location { get; set; }


        [JsonProperty("city")]
        [DataMember]
        public string city { get; set; }


        [JsonProperty("District")]
        [DataMember]
        public string District { get; set; }


        [JsonProperty("State")]
        [DataMember]
        public string State { get; set; }

        [JsonProperty("Phone")]
        [DataMember]
        public string Phone { get; set; }

        [JsonProperty("Mobile")]
        [DataMember]
        public string Mobile { get; set; }

        [JsonProperty("Pin")]
        [DataMember]
        public string Pin { get; set; }

        [JsonProperty("Fax")]
        [DataMember]
        public string Fax { get; set; }

        [JsonProperty("Email")]
        [DataMember]
        public string Email { get; set; }

        [JsonProperty("TotalCards")]
        [DataMember]
        public string TotalCards { get; set; }


    }


    public class GetDICVCustomerFormNameOnCardModelOutput: BaseClassOutput
    {
        [JsonProperty("CardNoIssued")]
        [DataMember]
        public string CardNoIssued { get; set; }

        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [JsonProperty("VINNumber")]
        [DataMember]
        public string VINNumber { get; set; }
        [JsonProperty("VehicleType")]
        [DataMember]
        public string VehicleType { get; set; }


    }

    public class GetDICVCustomerApplicationFormNameOnCardModelOutput
    {
        [JsonProperty("GetDICVCustomerApplicationFormOutput")]
        public List<GetDICVCustomerApplicationFormModelOutput> GetDICVCustomerApplicationFormOutput { get; set; }

        [JsonProperty("GetDICVCustomerFormNameOnCard")]
        public List<GetDICVCustomerFormNameOnCardModelOutput> GetDICVCustomerFormNameOnCard { get; set; }
    }


}
