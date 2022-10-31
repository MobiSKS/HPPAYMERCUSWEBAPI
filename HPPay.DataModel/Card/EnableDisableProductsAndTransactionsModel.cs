using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Card
{

    public class GetDetailForEnableDisableProductsAndTransactionsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }
    }

    public class GetProductsTransactionsStatusModelOutput : BaseClassOutput
    {
       

    }

    public class GetDetailForEnableDisableProductsAndTransactionsModelOutput
    {
        [JsonProperty("GetProductsTransactionsStatus")]
        public List<GetProductsTransactionsStatusModelOutput> GetProductsTransactionsStatus { get; set; }

        [JsonProperty("GetProductsType")]
        public List<GetProductsTypeModelOutput> GetProductsType { get; set; }

        [JsonProperty("GetTransactionsType")]
        public List<GetTransactionsTypeModelOutput> GetTransactionsType { get; set; }
    }
      

    public class GetProductsTypeModelOutput
    {
        [JsonProperty("ProductID")]
        [DataMember]
        public int ProductID { get; set; }

        [JsonProperty("ProductName")]
        [DataMember]
        public string ProductName { get; set; }

        [JsonProperty("StatusFlag")]
        [DataMember]
        public int StatusFlag { get; set; }

    }
    // 

    public class GetTransactionsTypeModelOutput
    {
        [JsonProperty("TransactionID")]
        [DataMember]
        public int TransactionID { get; set; }

        [JsonProperty("TransactionType")]
        [DataMember]
        public string TransactionType { get; set; }

        [JsonProperty("StatusFlag")]
        [DataMember]
        public int StatusFlag { get; set; }

    }
    /// for Enable Desable
    /// 
    public class EnableDisableProductsAndTransactionsModelInput : BaseClass
    {
        [Required]
        [JsonPropertyName("CustomerId")]
        [DataMember]
        public string CustomerId { get; set; }

        [JsonPropertyName("CardNo")]
        [DataMember]
        public string CardNo { get; set; }

        [JsonPropertyName("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [Required]
        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("ObjProducts")]
        [DataMember]
        public List<ProductStatusModelInput> ObjProducts { get; set; }

        [JsonPropertyName("ObjTransactions")]
        [DataMember]
        public List<TransactionModelInput> ObjTransactions { get; set; }
    }

    public class ProductStatusModelInput
    {
        [JsonProperty("ProductID")]
        [DataMember]
        public int ProductID { get; set; }        

        [JsonProperty("StatusFlag")]
        [DataMember]
        public int StatusFlag { get; set; }
    }

    public class TransactionModelInput
    {
        [JsonPropertyName("TransactionID")]
        [DataMember]
        public int TransactionID { get; set; }
        
        [JsonPropertyName("StatusFlag")]
        [DataMember]
        public int StatusFlag { get; set; }

    }

    public class EnableDisableProductsAndTransactionsModelOutput : BaseClassOutput
    {

    }





}
