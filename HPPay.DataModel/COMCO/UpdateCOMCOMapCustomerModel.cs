using Newtonsoft.Json;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.COMCO
{
    public class UpdateCOMCOMapCustomerModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("MerchantID")]
        [DataMember]
        public string MerchantID { get; set; }


        [Required]
        [JsonPropertyName("CreatedBy")]
        [DataMember]
        public string CreatedBy { get; set; }

        [Required]
        [JsonPropertyName("TypeCOMCOMapCustomer")]
        [DataMember]
        public List<TypeCOMCOMapCustomer> TypeCOMCOMapCustomer { get; set; }
    }


    public class TypeCOMCOMapCustomer
    {
        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }



    }
    public class UpdateCOMCOMapCustomerModelOutput : BaseClassOutput
    {
        
        [JsonProperty("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

    }
}
