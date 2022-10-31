using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HPPay.DataModel.TMFL
{
    public  class TMFLCreateCustomerModelInput 
    {
        [JsonPropertyName("TMFLCustomerID")]
        [DataMember]
        public string TMFLCustomerID { get; set; }

        [Required]
        [JsonPropertyName("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }
         

        [Required]
        [JsonPropertyName("RecordStatus")]
        [DataMember]
        public string RecordStatus { get; set; }

        [JsonPropertyName("DTPCustomerID")]
        [DataMember]
        public string DTPCustomerID { get; set; }

        [Required]
        [JsonPropertyName("CustomerTitle")]
        [DataMember]
        public string CustomerTitle { get; set; }

        [Required]
        [JsonPropertyName("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [Required]
        [JsonPropertyName("PermanentAddress1")]
        [DataMember]
        public string PermanentAddress1 { get; set; }
         
        [JsonPropertyName("PermanentAddress2")]
        [DataMember]
        public string PermanentAddress2 { get; set; }
         
        [JsonPropertyName("PermanentAddress3")]
        [DataMember]
        public string PermanentAddress3 { get; set; }

        [Required]
        [JsonPropertyName("PermanentAddressLocation")]
        [DataMember]
        public string PermanentAddressLocation { get; set; }


        [Required]
        [JsonPropertyName("PermanentAddressCity")]
        [DataMember]
        public string PermanentAddressCity { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonPropertyName("PermanentAddressPincode")]
        [DataMember]
        public string PermanentAddressPincode { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonPropertyName("PermanentAddressState")]
        [DataMember]
        public string PermanentAddressState { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonPropertyName("PermanentAddressDistrict")]
        [DataMember]
        public string PermanentAddressDistrict { get; set; }


        [JsonPropertyName("CustomerEmail")]
        [DataMember]
        public string CustomerEmail { get; set; }

        [Required]
        [JsonPropertyName("CommunicationAddress1")]
        [DataMember]
        public string CommunicationAddress1 { get; set; }
         
        [JsonPropertyName("CommunicationAddress2")]
        [DataMember]
        public string CommunicationAddress2 { get; set; }
         
        [JsonPropertyName("CommunicationAddress3")]
        [DataMember]
        public string CommunicationAddress3 { get; set; }

        [Required]
        [JsonPropertyName("CommunicationAddressLocation")]
        [DataMember]
        public string CommunicationAddressLocation { get; set; }

        [Required]
        [JsonPropertyName("CommunicationAddressCity")]
        [DataMember]
        public string CommunicationAddressCity { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonPropertyName("CommunicationAddressDistrict")]
        [DataMember]
        public string CommunicationAddressDistrict { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonPropertyName("CommunicationAddressState")]
        [DataMember]
        public string CommunicationAddressState { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonPropertyName("CommunicationAddressPincode")]
        [DataMember]
        public string CommunicationAddressPincode { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonPropertyName("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }

        [Required]
        [JsonPropertyName("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [Required]
        [JsonPropertyName("KeyTitle")]
        [DataMember]
        public string KeyTitle { get; set; }

        [Required]
        [JsonPropertyName("KeyFirstName")]
        [DataMember]
        public string KeyFirstName { get; set; }

        [Required]
        [JsonPropertyName("KeyDesignation")]
        [DataMember]
        public string KeyDesignation { get; set; }

        [Required(AllowEmptyStrings = false)]
        [JsonPropertyName("KeyMobile")]
        [DataMember]
        public string KeyMobile { get; set; }

        [Required]
        [JsonPropertyName("Pan_Card")]
        [DataMember]
        public string Pan_Card { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }


    }


    public class TMFLCreateCustomerModelOutPut  
    {
        [JsonProperty("ClientCode")]
        [DataMember]
        public string ClientCode { get; set; }


        [JsonProperty("DTPCustomerID")]
        [DataMember]
        public string DTPCustomerID { get; set; }


        [JsonProperty("ControlCardNumber")]
        [DataMember]
        public string ControlCardNumber { get; set; }


        [JsonProperty("TMFLCustomerID")]
        [DataMember]
        public string TMFLCustomerID { get; set; }


        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonProperty("ResponseMessage")]
        [DataMember]
        public string ResponseMessage { get; set; }

        [JsonProperty("Status")]
        [DataMember]
        public int Status { get; set; }

        //[JsonProperty("SendStatus")]
        //[DataMember]
        //public int? SendStatus { get; set; }

        



    }
}
