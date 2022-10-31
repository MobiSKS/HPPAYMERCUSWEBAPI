using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.PayU
{
    public class ResponseArray
    {
        [JsonPropertyName("status")]
        [DataMember]
        public string status { get; set; }

        [JsonPropertyName("msg")]
        [DataMember]
        public string msg { get; set; }
         
    }

    public class Array 
    {

        [JsonPropertyName("mihpayid")]
        [DataMember]
        public string mihpayid { get; set; }

        [JsonPropertyName("request_id")]
        [DataMember]
        public string request_id { get; set; }

        [JsonPropertyName("bank_ref_num")]
        [DataMember]
        public string bank_ref_num { get; set; }

        [JsonPropertyName("amt")]
        [DataMember]
        public string amt { get; set; }

        [JsonPropertyName("txnid")]
        [DataMember]
        public string txnid { get; set; }

        [JsonPropertyName("additional_charges")]
        [DataMember]
        public string additional_charges { get; set; }

        [JsonPropertyName("productinfo")]
        [DataMember]
        public string productinfo { get; set; }

        [JsonPropertyName("firstname")]
        [DataMember]
        public string firstname { get; set; }

        [JsonPropertyName("bankcode")]
        [DataMember]
        public string bankcode { get; set; }

        [JsonPropertyName("udf1")]
        [DataMember]
        public string udf1 { get; set; }

        [JsonPropertyName("udf2")]
        [DataMember]
        public string udf2 { get; set; }

        [JsonPropertyName("udf3")]
        [DataMember]
        public string udf3 { get; set; }

        [JsonPropertyName("udf4")]
        [DataMember]
        public string udf4 { get; set; }

        [JsonPropertyName("udf5")]
        [DataMember]
        public string udf5 { get; set; }

        [JsonPropertyName("field9")]
        [DataMember]
        public string field9 { get; set; }

        [JsonPropertyName("error_code")]
        [DataMember]
        public string error_code { get; set; }

        [JsonPropertyName("error_Message")]
        [DataMember]
        public string error_Message { get; set; }

        [JsonPropertyName("net_amount_debit")]
        [DataMember]
        public string net_amount_debit { get; set; }

        [JsonPropertyName("disc")]
        [DataMember]
        public string disc { get; set; }

        [JsonPropertyName("mode")]
        [DataMember]
        public string mode { get; set; }

        [JsonPropertyName("PG_TYPE")]
        [DataMember]
        public string PG_TYPE { get; set; }

        [JsonPropertyName("card_no")]
        [DataMember]
        public string card_no { get; set; }

        [JsonPropertyName("name_on_card")]
        [DataMember]
        public string name_on_card { get; set; }

        [JsonPropertyName("status")]
        [DataMember]
        public string status { get; set; }         

        [JsonPropertyName("unmappedstatus")]
        [DataMember]
        public string unmappedstatus { get; set; }

    }
    public class PayUResponseModelOutPut : BaseClassOutput
    {

        [JsonProperty("salt")]
        [DataMember] 
        public string salt { get; set; }

        [JsonProperty("Key")]
        [DataMember]
        public string Key { get; set; }

        [JsonProperty("txnid")]
        [DataMember]
        public string txnid { get; set; }         

        [JsonProperty("Amount")]
        [DataMember]
        public string Amount { get; set; }

        [JsonProperty("productinfo")]
        [DataMember]
        public string productinfo { get; set; }

        [JsonProperty("firstname")]
        [DataMember]
        public string firstname { get; set; }

        [JsonProperty("lastname")]
        [DataMember]
        public string lastname { get; set; }

        [JsonProperty("email")]
        [DataMember]
        public string email { get; set; }

        [JsonProperty("phone")]
        [DataMember]
        public string phone { get; set; }
       

        [JsonProperty("surl")]
        [DataMember]
        public string surl { get; set; }

        [JsonProperty("furl")]
        [DataMember]
        public string furl { get; set; }

        [JsonProperty("hash")]
        [DataMember]
        public string hash { get; set; }

        [JsonProperty("redirectToUrl")]
        [DataMember]
        public string redirectToUrl { get; set; }

        [JsonProperty("payLoad")]
        [DataMember]
        public string payLoad { get; set; }

    }
     


}
