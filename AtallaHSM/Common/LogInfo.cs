using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AtallaHSM.Common
{
    public struct LogInfo
    {
        [JsonProperty("timestamp")]
        public string TimeStamp { get; set; }
        [JsonProperty("level")]
        public string Level { get; set; }
        [JsonProperty("severity")]
        public string Severity { get; set; }
        [JsonProperty("priority")]
        public string Priority { get; set; }
        [JsonProperty("correlation_id")]
        public string CorrelationId { get; set; }
        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("my_custom_field")]
        public string CustomField { get; set; }
    }
}
