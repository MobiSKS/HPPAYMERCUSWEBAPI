using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.VolvoEicher
{
    public class GetVESalesExeEmpIdAddOnOTCCardMappingModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }
    }

    public class GetVESalesExeEmpIdAddOnOTCCardMappingModelOutput
    {
        [JsonProperty("SalesExecutiveEmployeeID")]
        [DataMember]
        public string SalesExecutiveEmployeeID { get; set; }
    }
}
