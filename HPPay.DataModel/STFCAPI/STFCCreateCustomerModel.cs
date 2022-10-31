using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
namespace HPPay.DataModel.STFCAPI
{
    public class STFCCreateCustomerModelInput:STFCAPIBaseClassInput
    {
        [Required]
        [JsonPropertyName("OSTFCCustomer")]
        [DataMember]
        public OSTFCCustomers OSTFCCustomer { get; set; }
    }
    public class OSTFCCustomers
    {
        [Required]
        [JsonPropertyName("RecordStatus")]
        [DataMember]
        public string RecordStatus { get; set; }

        [Required]
        //[RegularExpression(@"\d{10}", ErrorMessage = "Invalid DTPCustomerId")]
        [JsonPropertyName("DTPCustomerID")]
        [DataMember]
        public string DTPCustomerID { get; set; }

        [Required]
        [RegularExpression(@"^[0-9a-zA-Z]{1,15}$", ErrorMessage = "Invalid STFCCustomerID")]
        [JsonPropertyName("STFCCustomerID")]
        [DataMember]
        public string STFCCustomerID { get; set; }

        [Required]
        [JsonPropertyName("CustomerTitle")]
        [DataMember] 
        public string CustomerTitle { get; set; }

        [Required]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,22}$", ErrorMessage = "No Special Characters allowed for CustomerName/CustomerName Must be a maximum of 22 characters")]
        [JsonPropertyName("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [Required]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,22}$", ErrorMessage = "No Special Characters allowed for NameOnCard/NameOnCard Must be a maximum of 22 characters")]
        [JsonPropertyName("NameonCard")]
        [DataMember]
        public string NameonCard { get; set; }

        //[Required]
        //[JsonPropertyName("ResidenceStatus")]
        //[DataMember]
        //public string ResidenceStatus { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{5}\d{4}[A-Z]{1}$", ErrorMessage = "Invalid PAN")]
        [JsonPropertyName("PAN")]
        [DataMember]
        public string PAN { get; set; }

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

        [JsonPropertyName("CommunicationAddressLocation")]
        [DataMember]
        public string CommunicationAddressLocation { get; set; }

        
        [JsonPropertyName("CommunicationAddressCity")]
        [DataMember]
        public string CommunicationAddressCity { get; set; }

        [Required]
        [RegularExpression("^[1-9][0-9]{5}$", ErrorMessage = "Invalid Communication Address Pincode.")]
        [JsonPropertyName("CommunicationAddressPincode")]
        [DataMember]
        public string CommunicationAddressPincode { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Communication Address State does not exist please enter correct District")]
        [JsonPropertyName("CommunicationAddressState")]
        [DataMember]
        public string CommunicationAddressState { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Communication Address District does not exist please enter correct District")]
        [JsonPropertyName("CommunicationAddressDistrict")]
        [DataMember]
        public string CommunicationAddressDistrict { get; set; }


        //[Required]
        //[JsonPropertyName("CommunicationPhoneNo")]
        //[DataMember]
        //public string CommunicationPhoneNo { get; set; }


        //[Required],"CustomerEmail"
        //[JsonPropertyName("CommunicationFax")]
        //[DataMember]
        //public string CommunicationFax { get; set; }


        [Required]
        [RegularExpression("^[6-9][0-9]{9}$", ErrorMessage = "Invalid Mobile Number.")]
        [JsonPropertyName("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }


        [Required]
        [RegularExpression(@"\A(?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[A-Za-z](?:[A-Za-z]*[A-Za-z])?\.)+[A-Za-z](?:[A-Za-z]*[A-Za-z])?)\Z", ErrorMessage = "Invalid Customer Email")]
        [JsonPropertyName("CustomerEmail")]
        [DataMember]
        public string CustomerEmail { get; set; }


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


 
        //[JsonPropertyName("PermanentLocation")]
        //[DataMember]
        //public string PermanentLocation { get; set; }

        [JsonPropertyName("PermanentAddressCity")]
        [DataMember]
        public string PermanentAddressCity { get; set; }


        [Required]
        [RegularExpression("^[1-9][0-9]{5}$", ErrorMessage = "Invalid Permanent Address Pincode.")]
        [JsonPropertyName("PermanentAddressPincode")]
        [DataMember]
        public string PermanentAddressPincode { get; set; }


        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Permanent Address State does not exist please enter correct District")]
        [JsonPropertyName("PermanentAddressState")]
        [DataMember]
        public string PermanentAddressState { get; set; }


        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Permanent Address District does not exist please enter correct District")]
        [JsonPropertyName("PermanentAddressDistrict")]
        [DataMember]
        public string PermanentAddressDistrict { get; set; }


        //[Required]
        //[JsonPropertyName("PermanentPhoneNo")]
        //[DataMember]
        //public string PermanentPhoneNo { get; set; }


        //[Required]
        //[JsonPropertyName("PermanentFax")]
        //[DataMember]
        //public string PermanentFax { get; set; }


        [Required]
        [JsonPropertyName("ApplicationNumber")]
        [DataMember]
        public string ApplicationNumber { get; set; }
    }

    public class STFCCreateCustomerModelOutput
    {

        [JsonProperty("custRes")]
        [DataMember]
        public List<GetCustResFinalOutput> custRes { get; set; }
    }
    public class GetCustResFinalOutput : STFCAPIBaseClassOutput

    {

        [JsonProperty("dtpCustomerId")]
        [DataMember]
        public string dtpCustomerId { get; set; }

        [JsonProperty("stfcCustomerID")]
        [DataMember]
        public string stfcCustomerID { get; set; }

    }
}
