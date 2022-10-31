using HPPay.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.AGS
{
    public  class GetCustomerDetailsModelInput//: BaseClass
    {
        [Required(AllowEmptyStrings = false)]
        [JsonPropertyName("MobileNumber")]
        [DataMember]
        public string MobileNumber { get; set; }


        [Required]
        [JsonPropertyName("Apikey")]
        [DataMember]
        public string Apikey { get; set; }

    }

    public class GetCustomerDetailsModelOutput: AGSBaseClassOutput
    {
        [JsonProperty("CustomerInfo")]
        public List<GetCustomerDetailsByMobileNoModelOutput> CustomerInfo { get; set; }

    }



}
public class GetCustomerDetailsByMobileNoModelOutput
{
    [JsonProperty("CustomerID")]
    [DataMember]
    public string CustomerID { get; set; }


    

    [JsonProperty("CustomerName")]
     [DataMember]
     public string CustomerName { get; set; }

    [JsonProperty("MobileNumber")]
    [DataMember]
    public string MobileNumber { get; set; }


}


