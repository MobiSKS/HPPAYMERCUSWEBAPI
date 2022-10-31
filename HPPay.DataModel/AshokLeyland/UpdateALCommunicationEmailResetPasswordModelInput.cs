using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AshokLeyland
{
  

    public class UpdateALCommunicationEmailResetPasswordModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("UserName")]
        [DataMember]
        public string UserName { get; set; }

       
    }

    public class UpdateALCommunicationEmailResetPasswordModelOutput : BaseClassOutput
    {
        [JsonProperty("Password")]
        [DataMember]
        public string Password { get; set; }

    }
}
