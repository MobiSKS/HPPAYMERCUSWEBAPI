using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.TMS
{
    public class TMSUpdateEnrollmentStatusModelInput : BaseClass
    {
       
        public List<TMSInsertEnrollmentApprovalCustomerTrackingInput> TMSUpdateEnrollmentCustomerList { get; set; }
    }

    public class TMSInsertEnrollmentApprovalCustomerTrackingInput
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [Required]
        [JsonPropertyName("TMSUserId")]
        [DataMember]        
        public string TMSUserId { get; set; }
        [JsonPropertyName("TMSStatusID")]
        [DataMember]
        public int TMSStatusID { get; set; }
        [JsonPropertyName("Remarks")]
        [DataMember]
        public string Remarks { get; set; }
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }

    public class TMSUpdateEnrollmentStatusModelOutput:BaseClassOutput
    {
        

    }
}
