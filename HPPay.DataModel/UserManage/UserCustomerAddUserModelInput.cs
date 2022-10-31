using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    
    public class UserCustomerAddUserModelInput : BaseClass
    {


        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }


        [Required]
        [JsonPropertyName("Email")]
        [DataMember]
        public string Email { get; set; }


        [Required]
        [JsonPropertyName("Password")]
        [DataMember]
        public string Password { get; set; }


        [Required]
        [JsonPropertyName("ConfirmPassword")]
        [DataMember]
        public string ConfirmPassword { get; set; }


        [Required]
        [JsonPropertyName("SecretQuestion")]
        [DataMember]
        public int SecretQuestion { get; set; }



        [Required]
        [JsonPropertyName("SecretQuestionAnswer")]
        [DataMember]
        public string SecretQuestionAnswer { get; set; }


        

    }

    public class UserCustomerAddUserModelOutput : BaseClassOutput
    {



    }
}
