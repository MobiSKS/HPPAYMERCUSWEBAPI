using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class UserManagerCheckUserModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }

    }

    public class UserManagerCheckUserModelOutput:BaseClassOutput
    {


    }
}
