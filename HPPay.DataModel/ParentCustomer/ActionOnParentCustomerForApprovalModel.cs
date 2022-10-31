using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ParentCustomer
{
    public class ActionOnParentCustomerForApprovalModelInput:BaseClass
    {
        [JsonPropertyName("ObjParentCustomerDtl")]
        [DataMember]
        public List<ParentCustomerDetails> ObjParentCustomerDtl { get; set; }

        [Required]
        [JsonPropertyName("Approvedby")]
        [DataMember]
        public string Approvedby { get; set; }

        [Required]
        [JsonPropertyName("ActionType")]
        [DataMember]
        public int ActionType { get; set; }
    }

    public class ParentCustomerDetails
    {
        [Required]
        [JsonPropertyName("Id")]
        [DataMember]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("FormNumber")]
        [DataMember]
        public string FormNumber { get; set; }

        [Required]
        [JsonPropertyName("Comment")]
        [DataMember]
        public string Comment { get; set; }       
         
    }

    public class ActionOnParentCustomerForApprovalModelOutput:BaseClassOutput
    {

        [JsonProperty("FirstName")]
        [DataMember]
        public string FirstName { get; set; }


        [JsonProperty("LastName")]
        [DataMember]
        public string LastName { get; set; }


        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }


        [JsonProperty("Password")]
        [DataMember]
        public string Password { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [JsonProperty("SendStatus")]
        [DataMember]
        public int SendStatus { get; set; }

        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonProperty("ControlPassword")]
        [DataMember]
        public string ControlPassword { get; set; }


        [JsonProperty("CommunicationMobileNo")]
        [DataMember]
        public string CommunicationMobileNo { get; set; }

    }
}
