using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class UserManageGetUserManageRoleListModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("RoleId")]
        [DataMember]
        public string RoleId { get; set; }


    }

    public class UserManageGetUserManageRoleListModelOutput 
    {
        [JsonProperty("tblMainAndSubLevelRoleMap")]
        public List<GetMainAndSubLevelRoleMap>tblMainAndSubLevelRoleMap { get; set; }



        [JsonProperty("tblMenuDetails")]
        public List<GetSubLevelRoleMenuMap>tblMenuDetails { get; set; }

    }

    public class GetMainAndSubLevelRoleMap
    {
        [JsonProperty("SubLevelName")]
        [DataMember]
        public string SubLevelName { get; set; }


        [JsonProperty("Description")]
        [DataMember]
        public string Description { get; set; }

    }

    public class GetSubLevelRoleMenuMap
    {

        [JsonProperty("MenuId")]
        [DataMember]
        public int MenuId { get; set; }


        [JsonProperty("MenuName")]
        [DataMember]
        public string MenuName { get; set; }


        [JsonProperty("ParentMenuId")]
        [DataMember]
        public int ParentMenuId { get; set; }



        [JsonProperty("MenuLevel")]
        [DataMember]
        public int MenuLevel { get; set; }


        [JsonProperty("MenuOrder")]
        [DataMember]
        public int MenuOrder { get; set; }


        [JsonProperty("AllowedAction")]
        [DataMember]
        public int AllowedAction { get; set; }

        [JsonProperty("IsFinalPage")]
        [DataMember]
        public int IsFinalPage { get; set; }


    }
}
