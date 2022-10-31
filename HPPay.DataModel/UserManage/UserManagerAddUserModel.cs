using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class UserManagerAddUserModelInput : BaseClass
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


        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        //[Required]
        //[JsonPropertyName("UserRole")]
        //[DataMember]
        //public int UserRole { get; set; }


        //[Required]
        //[JsonPropertyName("ModifiedBy")]
        //[DataMember]
        //public string ModifiedBy { get; set; }

        //[Required]
        [JsonPropertyName("FirstName")]
        [DataMember]
        public string FirstName { get; set; }

        //[Required]
        [JsonPropertyName("LastName")]
        [DataMember]
        public string LastName { get; set; }

        [Required]
        [JsonPropertyName("StateId")]
        [DataMember]
        public int StateId { get; set; }

        [Required]
        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }



        //[JsonPropertyName("TypeManageUsersAddUserRole")]
        //[DataMember]
        //public List<TypeManageUsersAddUserRole> TypeManageUsersAddUserRole { get; set; }

    }

    public class UserManagerAddUserModelOutput : BaseClassOutput
    {



    }
}


   
