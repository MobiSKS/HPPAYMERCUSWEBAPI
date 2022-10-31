using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.DTP
{

    public class GetTeamMappingModelInput : BaseClass
    {
       
        [JsonPropertyName("ZBMID")]
        [DataMember]
        public string ZBMID { get; set; }

       
        [JsonPropertyName("ZBMName")]
        [DataMember]
        public string ZBMName { get; set; }
        
        [JsonPropertyName("RSMID")]
        [DataMember]
        public string RSMID { get; set; }

     
        [JsonPropertyName("RSMName")]
        [DataMember]
        public string RSMName { get; set; }

  
        [JsonPropertyName("RBEID")]
        [DataMember]
        public string RBEID { get; set; }

     
        [JsonPropertyName("RBEName")]
        [DataMember]
        public string RBEName { get; set; }

        [JsonPropertyName("Location")]
        [DataMember]
        public string Location { get; set; }

    }
    public class GetTeamMappingModelOutput
    {
        
        [JsonProperty("TeamMappingId")]
        [DataMember]
        public int TeamMappingId { get; set; }

       
        [JsonProperty("ZBMID")]
        [DataMember]
        public string ZBMID { get; set; }

        
        [JsonProperty("ZBMName")]
        [DataMember]
        public string ZBMName { get; set; }
       
        [JsonProperty("RSMID")]
        [DataMember]
        public string RSMID { get; set; }

        
        [JsonProperty("RSMName")]
        [DataMember]
        public string RSMName { get; set; }

        
        [JsonProperty("RBEID")]
        [DataMember]
        public string RBEID { get; set; }

       
        [JsonProperty("RBEName")]
        [DataMember]
        public string RBEName { get; set; }

   
        [JsonProperty("Location")]
        [DataMember]
        public string Location { get; set; }


    }
    public class InsertTeamMappingModelInput
    { 
       
        [Required]
        [JsonPropertyName("ZBMID")]
        [DataMember]
        public string ZBMID { get; set; }

        [Required]
        [JsonPropertyName("ZBMName")]
        [DataMember]
        public string ZBMName { get; set; }
        [Required]
        [JsonPropertyName("RSMID")]
        [DataMember]
        public string RSMID { get; set; }
        [Required]
        [JsonPropertyName("RSMName")]
        [DataMember]
        public string RSMName { get; set; }

        [Required]
        [JsonPropertyName("RBEID")]
        [DataMember]
        public string RBEID { get; set; }

        [Required]
        [JsonPropertyName("RBEName")]
        [DataMember]
        public string RBEName { get; set; }

        [Required]
        [JsonPropertyName("Location")]
        [DataMember]
        public string Location { get; set; }

        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }
    }

    public class InsertTeamMappingModelOutput : BaseClassOutput
    {

    }

    public class UpdateTeamMappingModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("TeamMappingId")]
        [DataMember]
        public int TeamMappingId { get; set; }

        [Required]
        [JsonPropertyName("ZBMID")]
        [DataMember]
        public string ZBMID { get; set; }

        [Required]
        [JsonPropertyName("ZBMName")]
        [DataMember]
        public string ZBMName { get; set; }
        [Required]
        [JsonPropertyName("RSMID")]
        [DataMember]
        public string RSMID { get; set; }

        [Required]
        [JsonPropertyName("RSMName")]
        [DataMember]
        public string RSMName { get; set; }

        [Required]
        [JsonPropertyName("RBEID")]
        [DataMember]
        public string RBEID { get; set; }

        [Required]
        [JsonPropertyName("RBEName")]
        [DataMember]
        public string RBEName { get; set; }

        [Required]
        [JsonPropertyName("Location")]
        [DataMember]
        public string Location { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }
       
    }

    public class UpdateTeamMappingModelOutput : BaseClassOutput
    {

    }

    public class DeleteTeamMappingModelInput : BaseClass
    {
        [JsonPropertyName("TeamMappingId")]
        [DataMember]
        public int TeamMappingId { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

    }

    public class DeleteTeamMappingModelOutput : BaseClassOutput
    {

    }
}
