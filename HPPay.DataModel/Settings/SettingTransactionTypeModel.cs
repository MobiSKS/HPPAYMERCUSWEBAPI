using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace HPPay.DataModel.Settings
{

    public class SettingGetTransactionTypeModelInput : BaseClass
    {

    }
    public class SettingGetTransactionTypeModelOutput
    {
        [JsonProperty("TransactionID")]
        [DataMember]
        public int TransactionID { get; set; }

        [JsonProperty("TransactionType")]
        [DataMember]
        public string TransactionType { get; set; }
    }

   
}
