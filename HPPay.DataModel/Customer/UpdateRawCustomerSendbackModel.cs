using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Customer
{
    public class UpdateRawCustomerSendbackModelInput:BaseClass 
    {
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

    }

    public class UpdateRawCustomerSendbackModelOutput : BaseClassOutput
    {

    }

}
