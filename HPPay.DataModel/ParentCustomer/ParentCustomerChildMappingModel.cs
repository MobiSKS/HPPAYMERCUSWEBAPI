using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.ParentCustomer
{
    public class ParentCustomerChildMappingModelInput:BaseClass
    {
        [JsonPropertyName("ObjParentCustomerDtl")]
        [DataMember]
        public List<ParentCustomerChildDetails> ObjParentCustomerDtl { get; set; }

        [Required]
        [JsonPropertyName("ParentCustomerId")]
        [DataMember]
        public string ParentCustomerId { get; set; }

        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

    }

    public class ParentCustomerChildDetails
    {
        [Required]
        [JsonPropertyName("Id")]
        [DataMember]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("ChildCustomerId")]
        [DataMember]
        public string ChildCustomerId { get; set; }

    }
    public class ParentCustomerChildMappingModelOutput : BaseClassOutput
    {
        

    }

    public class GetChildMappingDetailsModelInput 
    {
        [JsonPropertyName("ObjChildDtl")]
        [DataMember]
        public List<GetChildDetails> ObjChildDtl { get; set; }
    }

    public class GetChildDetails
    {
        [Required]
        [JsonPropertyName("Id")]
        [DataMember]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("ChildCustomerId")]
        [DataMember]
        public string ChildCustomerId { get; set; }

    }

    public class GetChildMappingDetailsModelOutput : BaseClassOutput
    {
        
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonProperty("CustomerName")]
        [DataMember]
        public string CustomerName { get; set; }

        [JsonProperty("RO")]
        [DataMember]
        public string RO { get; set; }

        [JsonProperty("ZO")]
        [DataMember]
        public string ZO { get; set; }

    }

    public class CheckParentCustomerChildMappingModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

    }
    public class CheckParentCustomerChildMappingModelOutPut : BaseClassOutput
    {
        

    }


    public class ViewChildMappedToParrentModelInput
    { 
        [JsonPropertyName("ParentCustomerId")]
        [DataMember]
        public string ParentCustomerId { get; set; }

        [JsonPropertyName("ChildCustomerId")]
        [DataMember]
        public string ChildCustomerId { get; set; }

    }
    public class ViewChildMappedToParrentModelOutPut 
    {
        [JsonProperty("ChildId")]
        [DataMember]
        public string ChildId { get; set; }

        [JsonProperty("NameOnCard")]
        [DataMember]
        public string NameOnCard { get; set; }

        [JsonProperty("ControlCardNo")]
        [DataMember]
        public string ControlCardNo { get; set; }

        [JsonProperty("CCMSBalance")]
        [DataMember]
        public string CCMSBalance { get; set; }

        [JsonProperty("DriveStar")]
        [DataMember]
        public string DriveStar { get; set; }

        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }

        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }
         

        [JsonProperty("Id")]
        [DataMember]
        public string Id { get; set; }

        [JsonProperty("ReqId")]
        [DataMember]
        public string ReqId { get; set; }
        
    }

    public class UnMapChildFromParrentModelInput
    { 
        [JsonPropertyName("Id")]
        [DataMember]
        public string Id { get; set; }

        [JsonPropertyName("ChildCustomerId")]
        [DataMember]
        public string ChildCustomerId { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

    }
    public class UnMapChildFromParrentModelOutPut:BaseClassOutput
    {

    }
}
