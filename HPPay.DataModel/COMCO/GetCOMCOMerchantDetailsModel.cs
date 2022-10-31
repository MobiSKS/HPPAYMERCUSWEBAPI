using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.COMCO
{
    public class GetCOMCOMerchantDetailsModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }
    }
    public class GetCOMCOMerchantDetailsModelOutput : BaseClassOutput
    {
       
    }


    public class GetCOMCOMerchantShiftMasterModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }
    }
    public class GetCOMCOMerchantShiftMasterModelOutput : BaseClassOutput
    {
        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [JsonProperty("ClosingDate")]
        [DataMember]
        public string ClosingDate { get; set; }

        [JsonProperty("EffectiveDate")]
        [DataMember]
        public string EffectiveDate { get; set; }

        [JsonProperty("ShiftStartTime")]
        [DataMember]
        public string ShiftStartTime { get; set; }

        [JsonProperty("ShiftEndTime")]
        [DataMember]
        public string ShiftEndTime { get; set; }

        [JsonProperty("ShiftHours")]
        [DataMember]
        public string ShiftHours { get; set; }
    }


    public class InsertCOMCOMerchantShiftMasterModelInput : BaseClass
    {

        [Required]
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

        [Required]
        [JsonPropertyName("NoOfShifts")]
        [DataMember]
        public int NoOfShifts { get; set; }


        [Required]
        [JsonPropertyName("StartTime")]
        [DataMember]
        public string StartTime { get; set; }

        [Required]
        [JsonPropertyName("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }


        [Required]
        [JsonPropertyName("EffectiveDate")]
        [DataMember]
        public string EffectiveDate { get; set; }

        [Required]
        [JsonPropertyName("ClosingDate")]
        [DataMember]
        public string ClosingDate { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [JsonPropertyName("ShiftDetailTypes")]
        [DataMember]
        public List<COMCOShiftDetailTypes> ShiftDetailTypes { get; set; }

    }

    public class COMCOShiftDetailTypes
    {

        [Required]
        [JsonPropertyName("ShiftName")]
        [DataMember]
        public string ShiftName { get; set; }


        [JsonPropertyName("ShiftStartTime")]
        [DataMember]
        public string ShiftStartTime { get; set; }

        [JsonPropertyName("ShiftEndTime")]
        [DataMember]
        public string ShiftEndTime { get; set; }

        [JsonPropertyName("ShiftHours")]
        [DataMember]
        public int ShiftHours { get; set; }

    }
    public class InsertCOMCOMerchantShiftMasterModelOutput : BaseClassOutput
    {
        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }
    }


}



