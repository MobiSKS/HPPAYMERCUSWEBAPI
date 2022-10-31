using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.ParentCustomer
{
       public class GetParentCustomerBasicSearchCardModelInput : BaseClass
        {

            [JsonPropertyName("CustomerId")]
            [DataMember]
            public string CustomerId { get; set; }

            [JsonPropertyName("CardType")]
            [DataMember]
            public string CardType { get; set; }


            [JsonPropertyName("VehicleNo")]
            [DataMember]
            public string VehicleNo { get; set; }


            [JsonPropertyName("CardNumber")]
            [DataMember]
            public string CardNumber { get; set; }


            [JsonPropertyName("IssueDate")]
            [DataMember]
            public string IssueDate { get; set; }

            [JsonPropertyName("CustomerSubtype")]
            [DataMember]
            public int CustomerSubtype { get; set; }
        }

        public class GetParentCustomerBasicSearchCardModelOutput
        {
            [JsonProperty("Cardnumber")]
            [DataMember]
            public string Cardnumber { get; set; }

            [JsonProperty("CustomerId")]
            [DataMember]
            public string CustomerId { get; set; }

            [JsonProperty("Userid")]
            [DataMember]
            public string Userid { get; set; }

            [JsonProperty("VehicleNo/UserName")]
            [DataMember]
            public string VehicleNo { get; set; }

            [JsonProperty("[MobileNumber]")]
            [DataMember]
            public string Mobile { get; set; }

            [JsonProperty("IssueDate")]
            [DataMember]
            public string IssueDate { get; set; }

            [JsonProperty("VehicleType")]
            [DataMember]
            public string VehicleType { get; set; }

            [JsonProperty("VehicleMake")]
            [DataMember]
            public string VehicleMake { get; set; }
            [JsonProperty("StatusName")]
            [DataMember]
            public string StatusName { get; set; }
            [JsonProperty("YearOfRegistration")]
            [DataMember]
            public string YearOfRegistration { get; set; }

            [JsonProperty("Manufacturer")]
            [DataMember]
            public string Manufacturer { get; set; }

            [JsonProperty("Owned")]
            [DataMember]
            public string Owned { get; set; }


        }
    
}
