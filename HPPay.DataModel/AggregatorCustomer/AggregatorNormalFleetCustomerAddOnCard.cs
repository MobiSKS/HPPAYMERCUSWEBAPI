using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.AggregatorCustomer
{
    internal class AggregatorNormalFleetCustomerAddOnCard
    {
    }
    public class AggregatorNormalFleetCustomerAddOnCardModelInput
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("Userid")]
        [DataMember]
        public string Userid { get; set; }

        [JsonPropertyName("Useragent")]
        [DataMember]
        public string Useragent { get; set; }

        [JsonPropertyName("Userip")]
        [DataMember]
        public string Userip { get; set; }

        [JsonPropertyName("FormNumber")]
        [DataMember]
        public Int64 FormNumber { get; set; }


        [JsonPropertyName("NoOfCards")]
        [DataMember]
        public Int32 NoOfCards { get; set; }


        //[JsonPropertyName("ObjCardDetail")]
        //[DataMember]
        //public List<CardDetailAgg> ObjCardDetail { get; set; }
        [Required]
        [JsonPropertyName("VechileNo")]
        public List<string> VechileNo { get; set; }
        [Required]
        [JsonPropertyName("VehicleType")]
        public List<string> VehicleType { get; set; }
        [Required]
        [JsonPropertyName("VehicleMake")]
        public List<string> VehicleMake { get; set; }
        [Required]
        [JsonPropertyName("YearOfRegistration")]
        public List<string> YearOfRegistration { get; set; }
       

        [JsonPropertyName("MobileNo")]
        public List<string> MobileNo { get; set; }
        [Required]
        [JsonPropertyName("RcCopy")]
        [DataMember]
        public List<IFormFile> RcCopy { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("CardPreference")]
        [DataMember]
        public string CardPreference { get; set; }



    }

    public class AggregatorNormalFleetCustomerAddOnCardModelOutput : BaseClassOutput
    {

    }
}
