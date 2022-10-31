using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.CustomerAPI
{
    public class CustomerAPIAggCustomerCreationModelInput : CustomerAPIBaseClassInput
    {


        [JsonProperty("OAggCustomer")]
        [DataMember]
        public OAggCustomers OAggCustomer { get; set; }
    }

    public class OAggCustomers
    { 

        [Required]
        [JsonPropertyName("RecordStatus")]
        [DataMember]
        public string RecordStatus { get; set; }

        [Required]
        [JsonPropertyName("DTPCustomerID")]
        [DataMember]
        public string DTPCustomerID { get; set; }

        [Required]
        [JsonPropertyName("CustomerTitle")]
        [DataMember]
        public string CustomerTitle { get; set; }

       
         [Required]
         [StringLength(50)]
        [JsonPropertyName("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }


        [Required]
        [JsonPropertyName("PermanentAddress1")]
        [DataMember]
        public string PermanentAddress1 { get; set; }

        [Required]
        [JsonPropertyName("PermanentAddress2")]
        [DataMember]
        public string PermanentAddress2 { get; set; }

        [Required]
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


        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Permanent Address District does not exist please enter correct District")]
        [JsonPropertyName("PermanentAddressDistrict")]
        [DataMember]
        public string PermanentAddressDistrict { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Permanent Address State does not exist please enter correct state")]
        [JsonPropertyName("PermanentAddressState")]
        [DataMember]
        public string PermanentAddressState { get; set; }

        [Required]
        [RegularExpression("^[1-9][0-9]{5}$", ErrorMessage = "Invalid Permanent Address Pincode.")]
        [JsonPropertyName("PermanentAddressPincode")]
        [DataMember]
        public string PermanentAddressPincode { get; set; }


        [Required]
        [RegularExpression(@"\A(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z](?:[A-Za-z]*[A-Za-z])?\.)+[A-Za-z](?:[A-Za-z]*[A-Za-z])?)\Z", ErrorMessage = "Invalid Customer Email")]
        [JsonPropertyName("CustomerEmail")]
        [DataMember]
        public string CustomerEmail { get; set; }

        [Required]
        [JsonPropertyName("CommunicationAddress1")]
        [DataMember]
        public string CommunicationAddress1 { get; set; }

        [Required]
        [JsonPropertyName("CommunicationAddress2")]
        [DataMember]
        public string CommunicationAddress2 { get; set; }

        [Required]
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

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Communication Address District does not exist please enter correct District")]
        [JsonPropertyName("CommunicationAddressDistrict")]
        [DataMember]
        public string CommunicationAddressDistrict { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Communication Address State does not exist please enter correct state")]
        [JsonPropertyName("CommunicationAddressState")]
        [DataMember]
        public string CommunicationAddressState { get; set; }

        [Required]
        [RegularExpression("^[1-9][0-9]{5}$", ErrorMessage = "Invalid Communication Address Pincode.")]
        [JsonPropertyName("CommunicationAddressPincode")]
        [DataMember]
        public string CommunicationAddressPincode { get; set; }

        [Required]
        [JsonPropertyName("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }

          [Required]     
          [RegularExpression("^[a-zA-Z]+.[a-zA-Z]{4,10}$", ErrorMessage = "Invalid NameOnCard.")]
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

        [Required]
        [JsonPropertyName("KeyMobile")]
        [DataMember]
        public string KeyMobile { get; set; }

        [Required]
        //[RegularExpression(@"^[a-zA-Z0-9''']+$", ErrorMessage = "Invalid PAN")]
        [RegularExpression(@"^[A-Z]{5}\d{4}[A-Z]{1}$", ErrorMessage = "Invalid PAN")]
        [StringLength(10, ErrorMessage = "Invalid PAN/PAN must be length of 10.")]
        [JsonPropertyName("PAN")]
        [DataMember]
        public string PAN { get; set; }

        //[Required]
        //[JsonPropertyName("ReferenceId")]
        //[DataMember]
        //public string ReferenceId { get; set; }

        //[Required]
        //[JsonPropertyName("Useragent")]
        //[DataMember]
        //public string Useragent { get; set; }

        //[Required]
        //[JsonPropertyName("Userip")]
        //[DataMember]
        //public string Userip { get; set; }

        //[Required]
        //[JsonPropertyName("Userid")]
        //[DataMember]
        //public string Userid { get; set; }
    }
    public class CustomerAPIAggCustomerCreationModelOutput
    {



        [JsonProperty("custRes")]
        [DataMember]
        public List<GetcustRes> custRes { get; set; }

    
    }
    public class GetcustRes: CustomerAPIBaseClassOutput
    {
        [JsonProperty("responseCode")]
        [DataMember]
        public string responseCode { get; set; }

        [JsonProperty("responseMessage")]
        [DataMember]
        public string responseMessage { get; set; }

        [JsonProperty("dtpCustomerId")]
        [DataMember]
        public string dtpCustomerId { get; set; }
    }
}
