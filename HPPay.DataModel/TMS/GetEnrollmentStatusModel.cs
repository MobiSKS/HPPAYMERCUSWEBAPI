
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.TMS
{
    public class GetEnrollmentStatusModelInput : BaseClass
    {

    }
    public class GetEnrollmentStatusModelOutput 
    {
        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }

        [JsonProperty("StatusId")]
        [DataMember]
        public string StatusId { get; set; }
    }

   
}
