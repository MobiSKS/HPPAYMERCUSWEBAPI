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
    public class ApproveRejectCOMCOManagerCreditOperationRoleRequestModelInput:BaseClass
    {

        [Required]
        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }



        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("TypeCOMCOManagerCreditOperationRoleRequest")]
        [DataMember]
        public List<TypeCOMCOManagerCreditOperationRoleRequest> TypeCOMCOManagerCreditOperationRoleRequest { get; set; }

    }

    public class TypeCOMCOManagerCreditOperationRoleRequest
    {

        [Required]
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }

      
        [JsonPropertyName("Remarks")]
        [DataMember]
        public string Remarks { get; set; }

    }
    public class ApproveRejectCOMCOManagerCreditOperationRoleRequestModelOutput : BaseClassOutput
    {
        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }
    }
}
