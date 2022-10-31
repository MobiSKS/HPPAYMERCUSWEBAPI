using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace HPPay.DataModel.PayCode
{
    public class GetPayCodeStatusModelInput:BaseClass 
    {

    }

    public class GetPayCodeStatusModelOutput
    {
        [JsonProperty("StatusId")]
        [DataMember]
        public int StatusId { get; set; }

        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }
    }
}
