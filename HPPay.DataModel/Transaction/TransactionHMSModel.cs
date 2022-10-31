using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Transaction
{

    public class HMSKeyExchangeModelInput : BaseClassTerminal
    {
        [JsonPropertyName("IACId")]
        [DataMember]
        public string IACId { get; set; }

        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonPropertyName("PublicKey")]
        [DataMember]
        public string PublicKey { get; set; }

    }



    public class HMSKeyExchangeModelOutput : BaseClassOutput
    {


        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonProperty("TidUnqId")]
        [DataMember]
        public int TidUnqId { get; set; }

        [JsonProperty("EncTMK")]
        [DataMember]
        public string EncTMK { get; set; }

        //TMK : Terminal Master Key
        [JsonProperty("TMKKCV")]
        [DataMember]
        public string TMKKCV { get; set; }

    }

    public class HMSLogOnModelInput : BaseClassTerminal
    {

        //[JsonPropertyName("IACId")]
        //[DataMember]
        //public string IACId { get; set; }

        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

    }

    public class HMSLogOnModelOutput : BaseClassOutput
    {

        [JsonProperty("TidUnqId")]
        [DataMember]
        public int TidUnqId { get; set; }

        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonProperty("DEKWorkingKey")]
        [DataMember]
        public string DEKWorkingKey { get; set; }

        // DEK : Data Encrypting Key
        [JsonProperty("DEKKCV")]
        [DataMember]
        public string DEKKCV { get; set; }


        [JsonProperty("PEKWorkingKey")]
        [DataMember]
        public string PEKWorkingKey { get; set; }

        //PEK : Pin Encrypting Key
        //KCV : Key Check Value
        [JsonProperty("PEKKCV")]
        [DataMember]
        public string PEKKCV { get; set; }

        [JsonProperty("MKAKB")]
        [DataMember]
        public string MKAKB { get; set; }

    }


    public class InsertUpdateHSMMasterKeyModelInput : BaseClass
    {
        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonPropertyName("TerminalUniqueId")]
        [DataMember]
        public int TerminalUniqueId { get; set; }

        [JsonPropertyName("MKAKB")]
        [DataMember]
        public string MKAKB { get; set; }

        [JsonPropertyName("MKKCV")]
        [DataMember]
        public string MKKCV { get; set; }


        [JsonPropertyName("TerminalPK")]
        [DataMember]
        public string TerminalPK { get; set; }

    }

    public class InsertUpdateHSMMasterKeyModelOutput : BaseClassOutput
    {

    }


    public class UpdateSessionKeyModelInput : BaseClass
    {
        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonPropertyName("TerminalUniqueId")]
        [DataMember]
        public int TerminalUniqueId { get; set; }

        [JsonPropertyName("DPKAKB")]
        [DataMember]
        public string DPKAKB { get; set; }

        [JsonPropertyName("DPKKCV")]
        [DataMember]
        public string DPKKCV { get; set; }


        [JsonPropertyName("PEKAKB")]
        [DataMember]
        public string PEKAKB { get; set; }

        [JsonPropertyName("PEKKCV")]
        [DataMember]
        public string PEKKCV { get; set; }

    }

    public class UpdateSessionKeyModelOutput : BaseClassOutput
    {

    }
}
