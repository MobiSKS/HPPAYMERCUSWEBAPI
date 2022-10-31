using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AggregatorCustomer
{
    public class AggregatorNormalFleetCustomerRCCopyModelInput : BaseClass
    {

        [Required]
        [JsonPropertyName("RcCopy")]
        [DataMember]
       // public IFormFile RcCopy { get; set; }
        public IList<IFormFile> RcCopy { get; set; }

        [Required]
        [JsonPropertyName("CustomerReferenceNo")]
        [DataMember]
        public Int64 CustomerReferenceNo { get; set; }

        [Required]
        [JsonPropertyName("VechileNo")]
        [DataMember]
        public List <string> VechileNo { get; set; }





        //public IList<IFormFile> Attachments { get; set; }


        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }

    //public class CardDetailAgg1
    //{

       
    //}

    public class AggregatorNormalFleetCustomerRCCopyModelOutput : BaseClassOutput
    {
        
    }
}
