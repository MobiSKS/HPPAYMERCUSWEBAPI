﻿using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Settings
{

    public class SettingGetEntityTypesModelInput : BaseClass
    {
        [JsonPropertyName("EntityTypeId")]
        [DataMember]
        public int EntityTypeId { get; set; }
    }
    public class SettingGetEntityTypesModelOutput
    {

        [JsonProperty("EntityTypeId")]
        [DataMember]
        public int EntityTypeId { get; set; }


        [JsonProperty("StatusId")]
        [DataMember]
        public int StatusId { get; set; }


        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }


        [JsonProperty("StatusCode")]
        [DataMember]
        public string StatusCode { get; set; }


        [JsonProperty("StatusDescription")]
        [DataMember]
        public string StatusDescription { get; set; }
    }
}
