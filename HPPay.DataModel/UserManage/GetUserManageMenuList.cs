using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.UserManage
{
    public class GetUserManageMenuListInput :BaseClass
    {
       
    }


    public class GetUserManageMenuListOutput : BaseClassOutput
    {

        [JsonProperty("MenuId")]
        [DataMember]
        public string MenuId { get; set; }

        [JsonProperty("MenuName")]
        [DataMember]
        public string MenuName { get; set; }

        [JsonProperty("MenuNameId")]
        [DataMember]
        public string MenuNameId { get; set; }

        [JsonProperty("ParentMenuId")]
        [DataMember]
        public string ParentMenuId { get; set; }

        [JsonProperty("MenuLevel")]
        [DataMember]
        public string MenuLevel { get; set; }


        [JsonProperty("MenuOrder")]
        [DataMember]
        public string MenuOrder { get; set; }


        [JsonProperty("IsFinalPage")]
        [DataMember]
        public string IsFinalPage { get; set; }

    }
}
