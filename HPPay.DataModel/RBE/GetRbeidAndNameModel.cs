using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataModel.RBE
{
    public class GetRbeidAndNameModelInput : BaseClass
    {
    }

    public class GetRbeidAndNameModelOutput 
    {
        [JsonProperty("RBEId")]
        [DataMember]
        public string RBEId { get; set; }

        [JsonProperty("OfficerID")]
        [DataMember]
        public int OfficerID { get; set; }


    }
}
