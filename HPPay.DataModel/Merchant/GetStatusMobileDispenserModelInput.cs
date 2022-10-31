using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Merchant
{
    public  class GetStatusMobileDispenserModelInput:BaseClass
    {
        
    }

    public class GetStatusMobileDispenserModelOutPut:BaseClassOutput
    {
        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }


        [JsonProperty("StatusId")]
        [DataMember]
        public int StatusId { get; set; }
    }

    public class MobileDispenserConfirmOTPModelInput : BaseClass
    { 
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

         
        [JsonPropertyName("OTP")]
        [DataMember]
        public string OTP { get; set; }

        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


    }
    public class MobileDispenserConfirmOTPModelOutPut : BaseClassOutput
    {


    }
}
