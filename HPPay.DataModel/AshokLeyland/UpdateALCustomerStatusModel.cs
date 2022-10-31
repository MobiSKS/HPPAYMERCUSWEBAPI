using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace HPPay.DataModel.AshokLeyland
{
    public class UpdateALCustomerStatusModelInput:BaseClass
    {
        [Required]
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonProperty("CustomerStatus")]
        [DataMember]
        public int CustomerStatus { get; set; }

        [JsonProperty("Remarks")]
        [DataMember]
        public string Remarks { get; set; }



    }

    public class UpdateALCustomerStatusModelOutput : BaseClassOutput
    {
    }
}
