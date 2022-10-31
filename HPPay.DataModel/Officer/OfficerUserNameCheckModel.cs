using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Officer
{
    

    public class CheckOfficerModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }
    }

    public class CheckOfficerModelOutput : BaseClassOutput
    {

    }
}
