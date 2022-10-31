using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataModel.DICV
{
    public class UpdateDICVCustomerStatusModelInput : BaseClass
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

    public class UpdateDICVCustomerStatusModelOutput : BaseClassOutput
    {
    }
}
