using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.DICV
{
    public class GetDICVDealerNameModelInput : BaseClass
    {
        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

        [JsonPropertyName("DTPDealerCode")]
        [DataMember]
        public string DTPDealerCode { get; set; }


    }
    public class GetDICVDealerNameModelOutput
    {

        [JsonProperty("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }

        [JsonProperty("DealerName")]
        [DataMember]
        public string DealerName { get; set; }

        [JsonProperty("ZonalOfficeID")]
        [DataMember]
        public int ZonalOfficeID { get; set; }

        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }

        [JsonProperty("RegionalOfficeID")]
        [DataMember]
        public int RegionalOfficeID { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("Address1")]
        [DataMember]
        public string Address1 { get; set; }

        [JsonProperty("Address2")]
        [DataMember]
        public string Address2 { get; set; }

        [JsonProperty("Address3")]
        [DataMember]
        public string Address3 { get; set; }

        [JsonProperty("CityName")]
        [DataMember]
        public string CityName { get; set; }

        [JsonProperty("StateId")]
        [DataMember]
        public int StateId { get; set; }

        [JsonProperty("StateName")]
        [DataMember]
        public string StateName { get; set; }

        [JsonProperty("DistrictId")]
        [DataMember]
        public int DistrictId { get; set; }

        [JsonProperty("DistrictName")]
        [DataMember]
        public string DistrictName { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonProperty("Pin")]
        [DataMember]
        public string Pin { get; set; }


        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }
    }

    public class CheckDICVDealerCodeModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("DealerCode")]
        [DataMember]
        public string DealerCode { get; set; }


    }

    public class CheckDICVDealerCodeModelOutput : BaseClassOutput
    {

    }
}
