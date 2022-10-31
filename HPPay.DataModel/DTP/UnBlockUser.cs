using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DTP
{
    public class GetDetailForUserUnblockByCustomerIdOrUserNameModelInput : BaseClass
    {    
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }
        
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }

    }

    public class GetDetailForUserUnblockByCustomerIdOrUserNameModelOutput : BaseClassOutput
    {
      
        [JsonProperty("UserName")]
        [DataMember]      
        public string UserName { get; set; }

        [JsonProperty("CreatedTime")]
        [DataMember]
        public string CreatedTime { get; set; }

        [JsonProperty("Name")]
        [DataMember]
        public string Name { get; set; }

    }
    
    public class UserUnBlockModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [Required]
        [JsonPropertyName("BlockUnblockStatus")]
        [DataMember]
        public int BlockUnblockStatus { get; set; }

        [Required]
        [JsonPropertyName("Remark")]
        [DataMember]
        public string Remark { get; set; }       

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

    }

    public class UserUnBlockModelOutput : BaseClassOutput
    {


    }
}
