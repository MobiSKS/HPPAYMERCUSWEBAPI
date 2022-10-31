using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AshokLeyland
{
    public class GetAlSalesExeEmpIdAddOnOTCCardMappingModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }
    }

    public class GetAlSalesExeEmpIdAddOnOTCCardMappingModelOutput
    {
        [JsonProperty("SalesExecutiveEmployeeID")]
        [DataMember]
        public string SalesExecutiveEmployeeID { get; set; }
    }
}
