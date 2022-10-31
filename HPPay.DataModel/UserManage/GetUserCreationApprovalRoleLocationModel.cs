﻿using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class GetUserCreationApprovalRoleLocationModelInput : BaseClass
    {

        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }


    }

    public class GetUserCreationApprovalRoleLocationModelOutput : BaseClassOutput
    {
        [JsonProperty("UserRole")]
        [DataMember]
        public string UserRole { get; set; }


        [JsonProperty("Location")]
        [DataMember]
        public string Location { get; set; }


    }
}
