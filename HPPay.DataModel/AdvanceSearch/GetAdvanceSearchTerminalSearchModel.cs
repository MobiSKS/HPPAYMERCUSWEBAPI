using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.AdvanceSearch
{
    public class GetAdvanceSearchTerminalSearchModelInput : BaseClass
    {

        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }


        [JsonPropertyName("IsTerminalIdExist")]
        [DataMember]
        public bool IsTerminalIdExist { get; set; }


        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }


        [JsonPropertyName("IsMerchantIdExist")]
        [DataMember]
        public bool IsMerchantIdExist { get; set; }


        [JsonPropertyName("MerchantName")]
        [DataMember]
        public string MerchantName { get; set; }


        [JsonPropertyName("IsMerchantNameExist")]
        [DataMember]
        public bool IsMerchantNameExist { get; set; }


        [JsonPropertyName("ErpCode")]
        [DataMember]
        public string ErpCode { get; set; }


        [JsonPropertyName("IsErpCodeExist")]
        [DataMember]
        public bool IsErpCodeExist { get; set; }


        [JsonPropertyName("MerchantType")]
        [DataMember]
        public int MerchantType { get; set; }


        [JsonPropertyName("IsMerchantTypeExist")]
        [DataMember]
        public bool IsMerchantTypeExist { get; set; }


        [JsonPropertyName("LocationName")]
        [DataMember]
        public string LocationName { get; set; }


        [JsonPropertyName("IsLocationNameExist")]
        [DataMember]
        public bool IsLocationNameExist { get; set; }


        [JsonPropertyName("ContactPersonName")]
        [DataMember]
        public string ContactPersonName { get; set; }

        [JsonPropertyName("IsContactPersonNameExist")]
        [DataMember]
        public bool IsContactPersonNameExist { get; set; }


        [JsonPropertyName("StatusName")]
        [DataMember]
        public string StatusName { get; set; }

        [JsonPropertyName("IsStatusNameExist")]
        [DataMember]
        public bool IsStatusNameExist { get; set; }

        [JsonPropertyName("TerminalPan")]
        [DataMember]
        public string TerminalPan { get; set; }

        [JsonPropertyName("IsTerminalPanExist")]
        [DataMember]
        public bool IsTerminalPanExist { get; set; }
    }
    public class GetAdvanceSearchTerminalSearchModelOutput : BaseClassOutput
    {
        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }
        [JsonProperty("DeploymentStatus")]
        [DataMember]
        public string DeploymentStatus { get; set; }

        [JsonProperty("ApprovalDate")]
        [DataMember]
        public string ApprovalDate { get; set; }

        //[JsonProperty("Status")]
        //[DataMember]
        //public string Status { get; set; }

        [JsonProperty("DeinstallDate")]
        [DataMember]
        public string DeinstallDate { get; set; }
    }
}
