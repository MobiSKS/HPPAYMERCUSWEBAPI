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
    public class GetMobileMenuDetailsForUserModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("UserType")]
        [DataMember]
        public string UserType { get; set; }
    }

    public class GetMobileMenuDetailsForUserModelOutput : BaseClassOutput
    {
        [JsonProperty("UserID")]
        [DataMember]
        public string UserID { get; set; }

        [JsonProperty("MenuId")]
        [DataMember]
        public int MenuId { get; set; }

        [JsonProperty("MenuName")]
        [DataMember]
        public string MenuName { get; set; }


        [JsonProperty("MenuNameId")]
        [DataMember]
        public string MenuNameId { get; set; }


        [JsonProperty("ParentMenuId")]
        [DataMember]
        public int ParentMenuId { get; set; }


        [JsonProperty("MenuLevel")]
        [DataMember]
        public int MenuLevel { get; set; }


        [JsonProperty("MenuOrder")]
        [DataMember]
        public int MenuOrder { get; set; }


        [JsonProperty("Controller")]
        [DataMember]
        public string Controller { get; set; }


        [JsonProperty("Action")]
        [DataMember]
        public string Action { get; set; }


        [JsonProperty("ImageUrl")]
        [DataMember]
        public string ImageUrl { get; set; }


        [JsonProperty("Heading")]
        [DataMember]
        public string Heading { get; set; }


        [JsonProperty("Details")]
        [DataMember]
        public string Details { get; set; }

        [JsonProperty("AllowedAction")]
        [DataMember]
        public string AllowedAction { get; set; }

        [JsonProperty("IsFinalPage")]
        [DataMember]
        public string IsFinalPage { get; set; }
    }
}
