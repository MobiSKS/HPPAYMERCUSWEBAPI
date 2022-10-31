using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.IdfcAPI
{
    public class UpdateFastagBankApprovalModelInput:BaseClass
    {

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [Required]
        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }

        [Required]
        [JsonPropertyName("TypeFastagBankApproval")]
        [DataMember]
        public List<GetTypeFastagBankApproval> TypeFastagBankApproval { get; set; }

    }


    public class GetTypeFastagBankApproval
    {


        [Required]
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }


        [Required]
        [JsonPropertyName("Comments")]
        [DataMember]
        public string Comments { get; set; }
    }



    public class UpdateFastagBankApprovalModelOutput :BaseClassOutput
    {
    }

}
