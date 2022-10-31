using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Hotlist
{

    public class GetActionListInput : BaseClass
    {
        [JsonPropertyName("EntityTypeId")]
        [DataMember]
        public int EntityTypeId { get; set; }
    }
    public class GetActionListOutput
    {
        [JsonProperty("EntityTypeId")]
        [DataMember]
        public int EntityTypeId { get; set; }

        [JsonProperty("StatusId")]
        [DataMember]
        public int StatusId { get; set; }

        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }

      
    }

    public class GetEntityTypeListInput : BaseClass
    {
         
    }
    public class GetEntityTypeListOutput
    {
        [JsonProperty("EntityId")]
        [DataMember]
        public int EntityId { get; set; }


        [JsonProperty("EntityName")]
        [DataMember]
        public string EntityName { get; set; }


    }

    public class GetReasonListForEntitiesInput : BaseClass
    {
        [JsonPropertyName("EntityTypeId")]
        [DataMember]
        public int EntityTypeId { get; set; }

        [JsonPropertyName("Actionid")]
        [DataMember]
        public int Actionid { get; set; }
    }
    public class GetReasonListForEntitiesOutput
    {
        [JsonProperty("EntityTypeId")]
        [DataMember]
        public int EntityTypeId { get; set; }

        [JsonProperty("StatusId")]
        [DataMember]
        public int StatusId { get; set; }

        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }


    }

    public class GetHotlistedOrReactivatedDetailsInput : BaseClass
    {
        [Required]
        [JsonPropertyName("EntityTypeId")]
        [DataMember]
        public Int32 EntityTypeId { get; set; }

        [Required]
        [JsonPropertyName("EntityIdVal")]
        [DataMember]
        public string EntityIdVal { get; set; }
    }
    public class GetHotlistedOrReactivatedDetailsOutput
    {
        [JsonProperty("EntityType")]
        [DataMember]
        public string EntityType { get; set; }

        [JsonProperty("EntityIdValue")]
        [DataMember]
        public string EntityIdValue { get; set; }

        [JsonProperty("HotlistDate")]
        [DataMember]
        public string HotlistDate { get; set; }

        [JsonProperty("Action")]
        [DataMember]
        public string Action { get; set; }

        [JsonProperty("Reason")]
        [DataMember]
        public string Reason { get; set; }

        [JsonProperty("Remarks")]
        [DataMember]
        public string Remarks { get; set; }
    }

    public class GetHotlistApprovalModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("EntityTypeId")]
        [DataMember]
        public Int32 EntityTypeId { get; set; }

        [Required]
        [JsonPropertyName("ActionId")]
        [DataMember]
        public Int32 ActionId { get; set; }

        [Required]
        [JsonPropertyName("FromDate")]
        [DataMember]
        public string FromDate { get; set; }

        [Required]
        [JsonPropertyName("ToDate")]
        [DataMember]
        public string ToDate { get; set; }
    }
    public class GetHotlistApprovalModelOutput
    {
        [JsonProperty("EntityCode")]
        [DataMember]
        public string EntityCode { get; set; }

        [JsonProperty("CreationDate")]
        [DataMember]
        public string CreationDate { get; set; }
    }

    public class UpdateHotlistApprovalModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("EntityTypeId")]
        [DataMember]
        public Int32 EntityTypeId { get; set; }

        [Required]
        [JsonPropertyName("ActionId")]
        [DataMember]
        public Int32 ActionId { get; set; }

        [Required]
        [JsonPropertyName("ActionOnRequest")]
        [DataMember]
        public string ActionOnRequest { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("ObjUpdateHotlistApprovalEntityCode")]
        [DataMember]
        public List<UpdateHotlistApprovalEntityCodeModelInput> ObjUpdateHotlistApprovalEntityCode { get; set; }
    }
    public class UpdateHotlistApprovalEntityCodeModelInput
    {
        [JsonProperty("EntityCode")]
        [DataMember]
        public string EntityCode { get; set; }
    }
    public class UpdateHotlistApprovalModelOutput : BaseClassOutput
    {
        [JsonProperty("EntityCode")]
        [DataMember]
        public string EntityCode { get; set; }
    }
}
