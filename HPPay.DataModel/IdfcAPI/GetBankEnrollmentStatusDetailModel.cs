using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.IdfcAPI
{
    public class GetBankEnrollmentStatusDetailModelInput:BaseClass
    {

        
        [JsonPropertyName("Status")]
        [DataMember]
        public string Status { get; set; }

      


        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }

    }


    public class GetBankEnrollmentStatusDetailModelOutput : BaseClassOutput
    {

        [JsonProperty("Customerid")]
        [DataMember]
        public string Customerid { get; set; }



        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }


        [JsonProperty("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }


        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }



        [JsonProperty("City")]
        [DataMember]
        public string City { get; set; }


        [JsonProperty("Createddate")]
        [DataMember]
        public string Createddate { get; set; }



        [JsonProperty("createdby")]
        [DataMember]
        public string createdby { get; set; }

             

        [JsonProperty("Remarks")]
        [DataMember]
        public string Remarks { get; set; }

        [JsonProperty("ApprovedDate")]
        [DataMember]
        public string ApprovedDate { get; set; }


    }

}
