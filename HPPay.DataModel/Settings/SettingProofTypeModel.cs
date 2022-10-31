using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace HPPay.DataModel.Settings
{
    public class SettingGetProofTypeModelInput : BaseClass
    {
        [JsonPropertyName("ProofIdType")]
        [DataMember]
        public int ProofIdType { get; set; }

        [JsonPropertyName("EnrollmentType")]
        [DataMember]
        public int EnrollmentType { get; set; }
    }
    public class SettingGetProofTypeModelOutput
    {
        [JsonProperty("ProofTypeId")]
        [DataMember]
        public int ProofTypeId { get; set; }


        [JsonProperty("ProofTypeName")]
        [DataMember]
        public string ProofTypeName { get; set; }
    }

    public class SettingGetProofTypesMasterModelInput : BaseClass
    {

    }
    public class SettingGetProofTypesMasterModelOutput
    {
        [JsonProperty("ID")]
        [DataMember]
        public int ID { get; set; }


        [JsonProperty("ProofType")]
        [DataMember]
        public string ProofType { get; set; }
    }

    public class SettingGetEnrollmentTypeMasterModelInput : BaseClass
    {

    }
    public class SettingGetEnrollmentTypeMasterModelOutput
    {
        [JsonProperty("ID")]
        [DataMember]
        public int ID { get; set; }


        [JsonProperty("EnrollmentType")]
        [DataMember]
        public string EnrollmentType { get; set; }
    }
}
