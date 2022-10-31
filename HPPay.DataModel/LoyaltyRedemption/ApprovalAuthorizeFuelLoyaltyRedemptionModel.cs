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
    public class ApprovalAuthorizeFuelLoyaltyRedemptionModelInput:BaseClass
    {

        //[JsonPropertyName("CustomerId")]
        //[DataMember]
        //public string CustomerId { get; set; }

        [JsonPropertyName("ActionType")]
        [DataMember]
        public string ActionType { get; set; }

        [Required]
        [JsonPropertyName("Comments")]
        [DataMember]
        public string Comments { get; set; }


        [Required]
        [JsonPropertyName("TypeApprovalAuthorizeFuelLoyaltyRedemption")]
        [DataMember]
        public List<GetTypeApprovalAuthorizeFuelLoyaltyRedemption> TypeApprovalAuthorizeFuelLoyaltyRedemption { get; set; }

        [JsonPropertyName("ModifiedBy")]
        [DataMember]
        public string ModifiedBy { get; set; }


    }


    public class GetTypeApprovalAuthorizeFuelLoyaltyRedemption
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


    public class ApprovalAuthorizeFuelLoyaltyRedemptionModelOutput : BaseClassOutput
    {

     

    }



}
