using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.AdvanceSearch
{
    public class GetAdvanceSearchCardSearchModelInput : BaseClass
    {

        [JsonPropertyName("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }


        [JsonPropertyName("IsCardNumberExist")]
        [DataMember]
        public bool IsCardNumberExist { get; set; }


        [JsonPropertyName("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }


        [JsonPropertyName("IsCustomerNameExist")]
        [DataMember]
        public bool IsCustomerNameExist { get; set; }


        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }


        [JsonPropertyName("IsControlCardNoExist")]
        [DataMember]
        public bool IsControlCardNoExist { get; set; }


        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


        [JsonPropertyName("IsCustomerIdExist")]
        [DataMember]
        public bool IsCustomerIdExist { get; set; }


        [JsonPropertyName("IssueType")]
        [DataMember]
        public string IssueType { get; set; }


        [JsonPropertyName("IsIssueTypeExist")]
        [DataMember]
        public bool IsIssueTypeExist { get; set; }


        [JsonPropertyName("Status")]
        [DataMember]
        public int? Status { get; set; }


        [JsonPropertyName("IsStatusExist")]
        [DataMember]
        public bool IsStatusExist { get; set; }


        [JsonPropertyName("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

        [JsonPropertyName("IsFormNumberExist")]
        [DataMember]
        public bool IsFormNumberExist { get; set; }


        [JsonPropertyName("VehicleNumber")]
        [DataMember]
        public string VehicleNumber { get; set; }

        [JsonPropertyName("IsVehicleNumberExist")]
        [DataMember]
        public bool IsVehicleNumberExist { get; set; }

        [JsonPropertyName("VehicleType")]
        [DataMember]
        public string VehicleType { get; set; }


        [JsonPropertyName("IsVehicleTypeExist")]
        [DataMember]
        public bool IsVehicleTypeExist { get; set; }


        [JsonPropertyName("VechileMake")]
        [DataMember]
        public string VechileMake { get; set; }


        [JsonPropertyName("IsVechileMakeExist")]
        [DataMember]
        public bool IsVechileMakeExist { get; set; }


        [JsonPropertyName("RegistrationYear")]
        [DataMember]
        public int? RegistrationYear { get; set; }

        [JsonPropertyName("IsRegistrationYearExist")]
        [DataMember]
        public bool IsRegistrationYearExist { get; set; }


        [JsonPropertyName("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonPropertyName("IsNameOnCardExist")]
        [DataMember]
        public bool IsNameOnCardExist { get; set; }
    }
    public class GetAdvanceSearchCardSearchModelOutput : BaseClassOutput
    {
        [JsonProperty("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }
        [JsonProperty("IssueType")]
        [DataMember]
        public string IssueType { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public string Status { get; set; }
        [JsonProperty("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }
        [JsonProperty("IssueDate")]
        [DataMember]
        public string IssueDate { get; set; }
        [JsonProperty("ExpiryDate")]
        [DataMember]
        public string ExpiryDate { get; set; }

        [JsonProperty("VehicleNumber")]
        [DataMember]
        public string VehicleNumber { get; set; }
        [JsonProperty("VehicleType")]
        [DataMember]
        public string VehicleType { get; set; }
        [JsonProperty("VehicleMake")]
        [DataMember]
        public string VehicleMake { get; set; }
        [JsonProperty("RegistrationYear")]
        [DataMember]
        public int RegistrationYear { get; set; }
        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }
        [JsonProperty("SalesArea")]
        [DataMember]
        public string SalesArea { get; set; }

    }
}
