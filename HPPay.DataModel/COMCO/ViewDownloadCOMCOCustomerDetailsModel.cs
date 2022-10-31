using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.COMCO
{
    public class ViewDownloadCOMCOCustomerDetailsModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }

        [Required]
        [JsonPropertyName("REQID")]
        [DataMember]
        public string REQID { get; set; }

    }
    public class ViewDownloadCOMCOCustomerDetailsModelOutput 
    {
        [JsonProperty("ChequeBDSCRNumber")]
        [DataMember]
        public string ChequeBDSCRNumber { get; set; }

        [JsonProperty("ChequeBDSCRDate")]
        [DataMember]
        public string ChequeBDSCRDate { get; set; }

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("ScannedReferenceDocument")]
        [DataMember]
        public string ScannedReferenceDocument { get; set; }
    }

}
