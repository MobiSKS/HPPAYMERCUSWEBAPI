using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
namespace HPPay.DataModel.DICV
{
    public class DICVUpdateMobileInCardModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }

        [Required]
        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }
    }

    public class DICVUpdateMobileInCardModelOutput : BaseClassOutput
    {

    }


    public class DICVGetMobileandFastagNoModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string Customerid { get; set; }
        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }

        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }

        [JsonPropertyName("Vehiclenumber")]
        [DataMember]
        public string Vehiclenumber { get; set; }

        [JsonPropertyName("IsNewMapping")]
        [DataMember]
        public bool IsNewMapping { get; set; }
    }
    public class DICVGetMobileandFastagNoModelOutput : BaseClassOutput
    {
        [JsonProperty("Cardno")]
        [DataMember]
        public string Cardno { get; set; }

        [JsonProperty("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }

        [JsonProperty("FastagNo")]
        [DataMember]
        public string FastagNo { get; set; }

        [JsonProperty("VehicleNo")]
        [DataMember]
        public string VehicleNo { get; set; }

        [JsonProperty("MappingDate")]
        [DataMember]
        public string MappingDate { get; set; }

    }
    public class DICVUpdateMobileandFastagNoModelInput : BaseClass
    {
        [JsonPropertyName("ObjUpdateMobileandFastagNoInCard")]
        [DataMember]
        public List<DICVUpdateMobileandFastagNo> ObjUpdateMobileandFastagNoInCard { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }
    }

    public class DICVUpdateMobileandFastagNo
    {
        [Required]
        [JsonPropertyName("Cardno")]
        [DataMember]
        public string Cardno { get; set; }


        [JsonPropertyName("Mobileno")]
        [DataMember]
        public string Mobileno { get; set; }


        [JsonPropertyName("FastagNo")]
        [DataMember]
        public string FastagNo { get; set; }


    }



    public class DICVUpdateMobileandFastagNoModelOutput : BaseClassOutput
    {

    }
}
