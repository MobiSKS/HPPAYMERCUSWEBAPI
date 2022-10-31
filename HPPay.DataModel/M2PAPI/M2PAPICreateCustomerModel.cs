using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.M2PAPI
{
    public class M2PAPICreateCustomerModelInput:M2PAPIBaseClassInput
    {
      
        [JsonPropertyName("OM2PCustomer")]
        [DataMember]
        public OM2PCustomers OM2PCustomer { get; set; }
    }

    public class OM2PCustomers
    {
        [Required]
        [JsonPropertyName("Recordstatus")]
        [DataMember]
        public string Recordstatus { get; set; }

        [Required]
        //[RegularExpression(@"\d{10}", ErrorMessage = "Invalid DTPCustomerId")]
        [JsonPropertyName("DTPCustomerID")]
        [DataMember]
        public string DTPCustomerID { get; set; }

        [Required]
        //[MinLength(1, ErrorMessage = "M2PCustomerID Must be a minimum of 1 characters")]
        //[MaxLength(15, ErrorMessage = "M2PCustomerID Must be a maximum of 15 characters")]
        //[RegularExpression(@"\d{1,15}", ErrorMessage = "Invalid M2PCustomerID")]
        [RegularExpression(@"^[0-9a-zA-Z]{1,15}$", ErrorMessage = "Invalid M2PCustomerID")]

        [JsonPropertyName("M2PCustomerID")]
        [DataMember]
        public string M2PCustomerID { get; set; }

        [Required]
        [JsonPropertyName("CustomerTitle")]
        [DataMember]
        public string CustomerTitle { get; set; }


        [Required]
        //[MinLength(1, ErrorMessage = "M2PCustomerID Must be a minimum of 1 characters")]
        //[MaxLength(22, ErrorMessage = "M2PCustomerID Must be a maximum of 22 characters")]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,22}$", ErrorMessage = "No Special Characters allowed for M2PCustomerID/M2PCustomerID Must be a maximum of 22 characters")]
        [JsonPropertyName("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }
        

        [Required]
        //[RegularExpression(@"^[ A-Za-z0-9]$", ErrorMessage = "No Special Characters allowed for NameOnCard")]
        [RegularExpression(@"^[0-9a-zA-Z''-'\s]{1,22}$", ErrorMessage = "No Special Characters allowed for NameOnCard/NameOnCard Must be a maximum of 22 characters")]
        [JsonPropertyName("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

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
        public int CommunicationAddressState { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Communication Address District does not exist please enter correct District")]
        [JsonPropertyName("CommunicationAddressDistrict")]
        [DataMember]
        public int CommunicationAddressDistrict { get; set; }


        //[Required]
        //[JsonPropertyName("CommunicationPhoneNo")]
        //[DataMember]
        //public string CommunicationPhoneNo { get; set; }


        //[Required]
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



        [JsonPropertyName("PermanentAddressLocation")]
        [DataMember]
        public string PermanentAddressLocation { get; set; }

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
        public int PermanentAddressState { get; set; }


        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Permanent Address District does not exist please enter correct District")]
        [JsonPropertyName("PermanentAddressDistrict")]
        [DataMember]
        public int PermanentAddressDistrict { get; set; }


        //[Required]
        //[JsonPropertyName("PermanentPhoneNo")]
        //[DataMember]
        //public string PermanentPhoneNo { get; set; }


        //[Required]
        //[JsonPropertyName("PermanentFax")]
        //[DataMember]
        //public string PermanentFax { get; set; }


        [Required]
        [RegularExpression("^[0-9]{7,10}$", ErrorMessage = "Invalid Application Number, Application Number should be of Minimum 7 Length and Maximum 10")]
        [JsonPropertyName("ApplicationNumber")]
        [DataMember]
        public string ApplicationNumber { get; set; }
    }


    public class M2PAPICreateCustomerModelOutput
    {

        [JsonProperty("custRes")]
        [DataMember]
        public List<GetCustResFinalOutput> custRes { get; set; }
    }
    public class GetCustResFinalOutput 

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

        [JsonProperty("M2PCustomerID")]
        [DataMember]
        public string M2PCustomerID { get; set; }

    }
}
