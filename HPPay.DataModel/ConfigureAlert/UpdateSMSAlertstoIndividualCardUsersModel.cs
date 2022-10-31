using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ConfigureAlert
{



    public class UpdateSMSAlertstoIndividualCardUsersModelInput : BaseClass
    {
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("TypeSMSAlertsToIndividualCardUsers")]
        [DataMember]
        public List<TypeSMSAlertsToIndividualCardUsers> TypeSMSAlertsToIndividualCardUsers { get; set; }
        
       
    }

    public class TypeSMSAlertsToIndividualCardUsers
    {
        [Required]
        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

       

        [JsonPropertyName("VechileNo")]
        [DataMember]
        public string VechileNo { get; set; }

        [Required]
        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

    }

    public class UpdateSMSAlertstoIndividualCardUsersModelOutput : BaseClassOutput
    {

    }
}
