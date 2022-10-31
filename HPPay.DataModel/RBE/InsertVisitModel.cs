using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.RBE
{
    public class InsertVisitModelInput:BaseClass
    {
        [JsonPropertyName("RBEId")]
        [DataMember]
        public string RBEId { get; set; }


        [JsonPropertyName("ScheduledDateTime")]
        [DataMember]
        public string ScheduledDateTime { get; set; }

        [Required]
        [JsonPropertyName("VisitType")]
        [DataMember]
        public string VisitType { get; set; }

        [Required]
        [JsonPropertyName("VisitObjective")]
        [DataMember]
        public string VisitObjective { get; set; }


        [Required]
        [JsonPropertyName("TransportDetails")]
        [DataMember]
        public string TransportDetails { get; set; }

        [Required]
        [JsonPropertyName("Firstname")]
        [DataMember]
        public string Firstname { get; set; }

        [JsonPropertyName("Middlename")]
        [DataMember]
        public string Middlename { get; set; }

        [Required]
        [JsonPropertyName("Lastname")]
        [DataMember]
        public string Lastname { get; set; }

        [Required]
        [JsonPropertyName("StateId")]
        [DataMember]
        public int StateId { get; set; }

        [Required]
        [JsonPropertyName("Pincode")]
        [DataMember]
        public string Pincode { get; set; }

        [Required]
        [JsonPropertyName("CustomerCity")]
        [DataMember]
        public string CustomerCity { get; set; }

        [Required]
        [JsonPropertyName("DistrictId")]
        [DataMember]
        public int DistrictId { get; set; }

        [Required]
        [JsonPropertyName("CustomerAddress")]
        [DataMember]
        public string CustomerAddress { get; set; }

        [JsonPropertyName("PhoneNo")]
        [DataMember]
        public string PhoneNo { get; set; }

        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }


        [Required]
        [JsonPropertyName("Email")]
        [DataMember]
        public string Email { get; set; }

       
        [JsonPropertyName("LocationId")]
        [DataMember]
        public string LocationId { get; set; }

        
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }


        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }
    public class InsertVisitModelOutput : BaseClassOutput
    {
    }
}
