using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.ParentCustomer
{
    public class ParentCustomerControlCardPinResetModelInput : BaseClass
    {

        [JsonPropertyName("CustomerID")]
        [DataMember]

        public string CustomerID { get; set; }

        [JsonPropertyName("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonPropertyName("CustomerSubtype")]
        [DataMember]
        public int CustomerSubtype { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

    }

    public class ParentCustomerControlCardPinResetModelOutput : BaseClassOutput
    {
        [JsonProperty("MobileNo")]
        [DataMember]
        public Int64 MobileNo { get; set; }

        [JsonProperty("CIN")]
        [DataMember]
        public Int64 CIN { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        

    }
}
