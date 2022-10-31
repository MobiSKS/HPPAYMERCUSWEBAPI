using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.MODashboard
{
    public class MODashboardRegionInformationModelInput : BaseClass
    {
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }
    }
    public class MODashboardRegionInformationModelOutput : BaseClassOutput
    {

        [JsonProperty("TotalCustomers")]
        [DataMember]
        public string TotalCustomers { get; set; }

        [JsonProperty("FleetCustomers")]
        [DataMember]
        public string FleetCustomers { get; set; }

        [JsonProperty("NonFleetCustomers")]
        [DataMember]
        public string NonFleetCustomers { get; set; }

        [JsonProperty("CorporateCustomers")]
        [DataMember]
        public string CorporateCustomers { get; set; }

        [JsonProperty("CustomerswithAttachedVechicles")]
        [DataMember]
        public string CustomerswithAttachedVechicles { get; set; }

        [JsonProperty("GenericCardCustomers")]
        [DataMember]
        public string GenericCardCustomers { get; set; }

        [JsonProperty("TatkalCardCustomers")]
        [DataMember]
        public string TatkalCardCustomers { get; set; }

        [JsonProperty("OTCCardCustomers")]
        [DataMember]
        public string OTCCardCustomers { get; set; }

        [JsonProperty("DriverCardCustomers")]
        [DataMember]
        public string DriverCardCustomers { get; set; }

        [JsonProperty("ActiveCustomersOfLastMonth")]
        [DataMember]
        public string ActiveCustomersOfLastMonth { get; set; }

        [JsonProperty("NoOfCards")]
        [DataMember]
        public string NoOfCards { get; set; }

        [JsonProperty("ActiveCardsOfLastMonth")]
        [DataMember]
        public string ActiveCardsOfLastMonth { get; set; }

        [JsonProperty("HPRe_FuelCardCustomers")]
        [DataMember]
        public string HPRe_FuelCardCustomers { get; set; }

        [JsonProperty("ActiveHPRe_FuelCardCustomersOfLastMonth")]
        [DataMember]
        public string ActiveHPRe_FuelCardCustomersOfLastMonth { get; set; }

        [JsonProperty("NoOfApprovedOrActiveDealersWithMinimum1InstalledTerminal")]
        [DataMember]
        public string NoOfApprovedOrActiveDealersWithMinimum1InstalledTerminal { get; set; }

        [JsonProperty("NoOfInstalledAndActiveTerminals")]
        [DataMember]
        public string NoOfInstalledAndActiveTerminals { get; set; }

        [JsonProperty("ActiveDealersOfLastMonth")]
        [DataMember]
        public string ActiveDealersOfLastMonth { get; set; }


        [JsonProperty("ActiveTerminalsOfLastMonth")]
        [DataMember]
        public string ActiveTerminalsOfLastMonth { get; set; }

        [JsonProperty("T_1Customer")]
        [DataMember]
        public string T_1Customer { get; set; }

        [JsonProperty("T_2Customer")]
        [DataMember]
        public string T_2Customer { get; set; }

    }
}
