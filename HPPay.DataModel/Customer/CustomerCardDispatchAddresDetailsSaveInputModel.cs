using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Customer
{
    public  class CustomerCardDispatchAddresDetailsSaveInputModel:BaseClass
    {

        //[JsonPropertyName("CustomerId")]
        //[DataMember]
        //public string CustomerId { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        public List<CardDispatchAddres> CardDispatchAddres { get; set; }
    }

    public class CardDispatchAddres
    {

        [JsonPropertyName("Zonalid")]
        [DataMember]
        public int Zonalid { get; set; }


        [JsonPropertyName("Reginolid")]
        [DataMember]
        public int Reginolid { get; set; }


        [JsonPropertyName("DispatchStatus")]
        [DataMember]
        public int DispatchStatus { get; set; }


        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        
    }

    public class CustomerCardDispatchAddresDetailsSaveOutputModel:BaseClassOutput
    {

    }
}
