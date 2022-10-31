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
    public class GetStatementofAccountModelInput:BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }


    }

    public class GetStatementofAccountModelOutput : BaseClassOutput
    {


        [JsonProperty("Customerid")]
        [DataMember]
        public string Customerid { get; set; }



        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }


        [JsonProperty("CreditLimit")]
        [DataMember]
        public string CreditLimit { get; set; }


        [JsonProperty("UtilizedLimit")]
        [DataMember]
        public string UtilizedLimit { get; set; }

        [JsonProperty("Balance")]
        [DataMember]
        public decimal Balance { get; set; }


    }

}
