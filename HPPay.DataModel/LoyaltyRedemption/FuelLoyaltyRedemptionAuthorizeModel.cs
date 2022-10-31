using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.LoyaltyRedemption
{
    public class FuelLoyaltyRedemptionAuthorizeModelInput:BaseClass
    {

        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }

        [Required]
        [JsonPropertyName("Comments")]
        [DataMember]
        public string Comments { get; set; }


        [Required]
        [JsonPropertyName("TypeAuthorizeFuelLoyaltyRedemption")]
        [DataMember]
        public List<GetTypeAuthorizeFuelLoyaltyRedemption> TypeAuthorizeFuelLoyaltyRedemption { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }

    }






    public class GetTypeAuthorizeFuelLoyaltyRedemption
    {
        

        [Required]
        [JsonPropertyName("RequestNumber")]
        [DataMember]
        public string RequestNumber { get; set; }



        [Required]
        [JsonPropertyName("CustomerID")]
        [DataMember]
        public string CustomerID { get; set; }

        //[Required]
        //[JsonPropertyName("Comments")]
        //[DataMember]
        //public string Comments { get; set; }

        [Required]
        [JsonPropertyName("PointsToRedeem")]
        [DataMember]
        public string PointsToRedeem { get; set; }


        [Required]
        [JsonPropertyName("BalancedPoints")]
        [DataMember]
        public string BalancedPoints { get; set; }

        [Required]
        [JsonPropertyName("Amount")]
        [DataMember]
        public string Amount { get; set; }

    }


    public class FuelLoyaltyRedemptionAuthorizeModelOutput : BaseClassOutput
    {



    }






}
