using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Customer
{
    public class VehicleTrackingModelInput : BaseClass
    {
        [JsonPropertyName("ZonalOffice")]
        [DataMember]
        public string ZonalOffice { get; set; }

        [JsonPropertyName("RegionalOffice")]
        [DataMember]
        public string RegionalOffice { get; set; }

        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

        [JsonPropertyName("TransTypeId")]
        [DataMember]
        public string TransTypeId { get; set; }

        
    }
    public class VehicleTrackingModelOutput
    {
        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }

        [JsonProperty("City")]
        [DataMember]
        public string City { get; set; }

        [JsonProperty("District")]
        [DataMember]
        public string District { get; set; }

        [JsonProperty("State")]
        [DataMember]
        public string State { get; set; }

        [JsonProperty("TransactionAmount")]
        [DataMember]
        public string TransactionAmount { get; set; }

        [JsonProperty("TransactionDate")]
        [DataMember]
        public string TransactionDate { get; set; }

        [JsonProperty("OdometerReading")]
        [DataMember]
        public string OdometerReading { get; set; }

       
    }
}
