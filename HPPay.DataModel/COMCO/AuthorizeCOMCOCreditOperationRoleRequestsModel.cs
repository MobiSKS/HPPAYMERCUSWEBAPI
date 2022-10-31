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
   
    public class AuthorizeCOMCOCreditOperationRoleRequestsModelInput : BaseClass
    {

        [Required]
        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }



        [Required]
        [JsonPropertyName("ApprovedBy")]
        [DataMember]
        public string ApprovedBy { get; set; }

        [JsonPropertyName("TypeAuthorizeCOMCO")]
        [DataMember]
        public List<TypeAuthorizeCOMCO> TypeAuthorizeCOMCO { get; set; }

    }

    public class TypeAuthorizeCOMCO
    {

        [Required]
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }


        [JsonPropertyName("Remarks")]
        [DataMember]
        public string Remarks { get; set; }

    }
    public class AuthorizeCOMCOCreditOperationRoleRequestsModelOutput : BaseClassOutput
    {
        [JsonProperty("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }
    }
}
