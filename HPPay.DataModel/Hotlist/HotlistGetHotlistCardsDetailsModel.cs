using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace HPPay.DataModel.Hotlist;

public class HotlistGetHotlistCardsDetailsModelInput:BaseClass
{
    [JsonPropertyName("CustomerID")]
    [DataMember]
    public string CustomerID { get; set; }

    [JsonPropertyName("CardNo")]
    [DataMember]
    public string CardNo { get; set; }
}

public class HotlistGetHotlistCardsDetailsModelOutput : BaseClassOutput
{


    [JsonProperty("CardNo")]
    [DataMember]
    public string CardNo { get; set; }


    [JsonProperty("UserName")]
    [DataMember]
    public string UserName { get; set; }


    [JsonProperty("VechileNo")]
    [DataMember]
    public string VechileNo { get; set; }


    [JsonProperty("VehicleType")]
    [DataMember]
    public string VehicleType { get; set; }


    [JsonProperty("YearOfRegistration")]
    [DataMember]
    public string YearOfRegistration { get; set; }


    [JsonProperty("Manufacturer")]
    [DataMember]
    public string Manufacturer { get; set; }


    [JsonProperty("CardCategory")]
    [DataMember]
    public string CardCategory { get; set; }

}
