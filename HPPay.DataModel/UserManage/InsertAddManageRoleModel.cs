using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class InsertAddManageRoleModelInput:BaseClass
    {

        [Required]
        [JsonPropertyName("RoleName")]
        [DataMember]
        public string RoleName { get; set; }

        [JsonPropertyName("RoleDescription")]
        [DataMember]
        public string RoleDescription { get; set; }


        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }


        [JsonPropertyName("TypeInsertAddManageUsers")]
        [DataMember]
        public List<TypeInsertAddManageUsers> TypeInsertAddManageUsers { get; set; }



    }

    public class TypeInsertAddManageUsers
    {
        [Required]
        [JsonPropertyName("MenuId")]
        [DataMember]
        public int MenuId { get; set; }

        [Required]
        [JsonPropertyName("AllowedAction")]
        [DataMember]
        public int AllowedAction { get; set; }

    }

    public class InsertAddManageRoleModelOutput:BaseClassOutput
    {

    }
}