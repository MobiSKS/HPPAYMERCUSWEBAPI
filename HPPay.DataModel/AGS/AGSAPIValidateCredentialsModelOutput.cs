using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataModel.AGS
{
    public class AGSAPIValidateCredentialsModelOutput:AGSBaseClassOutput
    {
        [JsonProperty("APIKey")]
        [DataMember]
        public string APIKey { get; set; }

    }


    public class AGSAPIValidateCredentialsModelInput : AGSAPIBaseClassInput
    {

    }

    

}
