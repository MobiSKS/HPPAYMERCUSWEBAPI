using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class AddUsersManageAggregatorUsersModelInput : BaseClass
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

        [JsonPropertyName("ReferenceId")]
        [DataMember]
        public string ReferenceId { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("TypeAddManageAggregatorUsers")]
        [DataMember]
        public List<TypeAddManageAggregatorUsers> TypeAddManageAggregatorUsers { get; set; }

  


    }

    public class TypeAddManageAggregatorUsers
    {
        
        [JsonPropertyName("RoleName")]
        [DataMember]
        public string RoleName { get; set; }

    
        [JsonPropertyName("RoleDescription")]
        [DataMember]
        public string RoleDescription { get; set; }

        [JsonPropertyName("ControlType")]
        [DataMember]
        public string ControlType { get; set; }

    }

    public class AddUsersManageAggregatorUsersModelOutput : BaseClassOutput
    {

    }
}
