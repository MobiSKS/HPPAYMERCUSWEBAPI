using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Login
{
    public class CheckManageUsersTokenModelInput : BaseClass
    {
    }

    public class CheckManageUsersTokenModelOutput
    {
        [JsonProperty("ManageUsersTokenModelBaseOutput")]
        public CHeckManageUsersTokenModelBaseOutput CheckManageUsersTokenModelBaseOutput { get; set; }

        [JsonProperty("MenuDetails")]
        public List<MenuDetails> MenuDetails { get; set; }
    }

    public class CHeckManageUsersTokenModelBaseOutput : BaseClassOutput
    {
        [JsonProperty("Token")]
        [DataMember]
        public string Token { get; set; }
    }

}
