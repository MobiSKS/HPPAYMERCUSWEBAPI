using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.BasicSearchByCustomer
{
    public class ViewBasicSearchByCustomerModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
    }
    public class ViewBasicSearchByCustomerModelOutput
    {
        [JsonProperty("CardNumber")]
        [DataMember]
        public string CardNumber { get; set; }

        [JsonProperty("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [JsonProperty("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }

        [JsonProperty("IssueDate")]
        [DataMember]
        public string IssueDate { get; set; }

        [JsonProperty("ExpiryDate")]
        [DataMember]
        public string ExpiryDate { get; set; }

        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }
    }
}
