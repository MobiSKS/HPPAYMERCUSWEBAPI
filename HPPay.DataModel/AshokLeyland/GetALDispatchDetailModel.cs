using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.AshokLeyland
{
    public class GetALDispatchDetailModelInput : BaseClass
    {
        [JsonPropertyName("CustomerID")]
        [DataMember]
        [Required]
        public string CustomerID { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]
      
        public string CardNo { get; set; }
    }
        public class GetALDispatchDetailModelOutput : BaseClassOutput
    {

        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonPropertyName("DispatchDate")]
        [DataMember]
        public string DispatchDate { get; set; }

        [JsonPropertyName("CourierName")]
        [DataMember]
        public string CourierName { get; set; }

        [JsonPropertyName("AirwaysBillNo")]
        [DataMember]
        public string AirwaysBillNo { get; set; }

        [JsonPropertyName("DispatchStatus")]
        [DataMember]
        public string DispatchStatus { get; set; }

        [JsonPropertyName("DeliveredTo")]
        [DataMember]
        public string DeliveredTo { get; set; }

        [JsonPropertyName("DeliveryDate")]
        [DataMember]
        public string DeliveryDate { get; set; }

        [JsonPropertyName("ReturnReason")]
        [DataMember]
        public string ReturnReason { get; set; }

        [JsonPropertyName("MOComments")]
        [DataMember]
        public string MOComments { get; set; }
    }
}
