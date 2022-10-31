using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.IciciAPI
{
    internal class IciciPaymentApiModel
    {
    }

   

    public class IciciAPIGetOtpRequest
    {
        public string txnId { get; set; }
        public string mobileNo { get; set; }
        public string vrn { get; set; }
        public string amount { get; set; }
        public string entityId { get; set; }
        public string posId { get; set; }
        public string txnTime { get; set; }
        public string chkSm { get; set; }
        public string iin { get; set; }
        public string tagId { get; set; }
        public string netAmount { get; set; }
        public string discount { get; set; }
    }

    public class IciciGetOtpResponse1 : BaseClassOutput
    {
        [JsonProperty("ResCode")]
        [DataMember]
        public string ResCode { get; set; }

        [JsonProperty("ResMsg")]
        [DataMember]
        public string ResMsg { get; set; }

        [JsonProperty("TxnId")]
        [DataMember]
        public string TxnId { get; set; }

        [JsonProperty("txnTime")]
        [DataMember]
        public string txnTime { get; set; }

        [JsonProperty("TagId")]
        [DataMember]
        public string TagId { get; set; }

        [JsonProperty("VRN")]
        [DataMember]
        public string Vrn { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }
        

        [JsonProperty("TxnNo")]
        [DataMember]
        public string TxnNo { get; set; }


    }


    public class IciciConfirmOtpReQuest : BaseClass
    {
        [JsonPropertyName("TxnId")]
        [DataMember]
        [Required]
        public string TxnId { get; set; }

        [JsonPropertyName("VRN")]
        [DataMember]
        [Required]
        public string Vrn { get; set; }

        [JsonPropertyName("MobileNo")]
        [DataMember]
        [Required]
        public string MobileNo { get; set; }

        [JsonPropertyName("GrossAmount")]
        [DataMember]
        [Required]
        public decimal GrossAmount { get; set; }

        [JsonPropertyName("TxnTime")]
        [DataMember]
        [Required]
        public string TxnTime { get; set; }

        [JsonPropertyName("Otp")]
        [DataMember]
        [Required]
        public string Otp { get; set; }

        [JsonPropertyName("TagId")]
        [DataMember]
        public string TagId { get; set; }
    }

    public class IciciMakePaymentReQuest
    {
        public string txnId { get; set; }
        public string vrn { get; set; }
        public string mobileNo { get; set; }
        public string grossAmount { get; set; }
        public string netAmount { get; set; }
        public string discount { get; set; }
        public string entityId { get; set; }
        public string posId { get; set; }
        public string txnTime { get; set; }
        public string otp { get; set; }
        public string iin { get; set; }
        public string chkSm { get; set; }


    }

    public class UpdateCCMSBAlanceForIcciCustomer : BaseClassOutput
    {

    }



    public class IciciRefundPaymentReQuest : BaseClass
    {

        [JsonPropertyName("OrgTxnId")]
        [DataMember]
        [Required]
        public string OrgTxnId { get; set; }


        [JsonPropertyName("OrgTxnTime")]
        [DataMember]
        [Required]
        public string OrgTxnTime { get; set; }


    }
    public class IciciRefundReQuest
    {
        public string txnId { get; set; }
        public string entityId { get; set; }
        public string posId { get; set; }
        public string chkSm { get; set; }
        public string orgTxnId { get; set; }
    }

    public class IciciRefundResponse:BaseClassOutput
    {
        [JsonProperty("ResCode")]
        [DataMember]
        public string resCode { get; set; }

        [JsonProperty("ResMsg")]
        [DataMember]
        public string resMsg { get; set; }

        [JsonProperty("TxnId")]
        [DataMember]
        public string txnId { get; set; }



        [JsonProperty("TxnNo")]
        [DataMember]
        public string txnNo { get; set; }

    }

    public class IciciRefundStatusUpdateModelOutput: BaseClassOutput
    {

    }
    public class UpdateCCMSBAlanceForICICICustomer : BaseClassOutput
    {
        public string RSP { get; set; }
        public string Volume { get; set; }
    }







































    /// <summary>
    /// remove
    /// </summary>
    public class IciciInitFuelPaymentRequestModelInput:BaseClass
    {
        [Required]
        [JsonPropertyName("DeviceId")]
        [DataMember]
        public string DeviceId { get; set; }

        [JsonPropertyName("DispenserId")]
        [DataMember]
        public string DispenserId { get; set; }

        [JsonPropertyName("VehicleNumber")]
        [DataMember]
        public string VehicleNumber { get; set; }

        [JsonPropertyName("HexTagId")]
        [DataMember]
        public string HexTagId { get; set; }

        [JsonPropertyName("Amount")]
        [DataMember]
        public decimal Amount { get; set; }



    }

    public class IciciInitFuelPaymentRequestModelOutput : BaseClassOutput
    {
        public string FUELTxnID { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsBlacklist { get; set; }
        public bool IsBalanceAvailable { get; set; }
        public string Messages { get; set; }
    }
        public class IciciInitFuelPayHexTagRequest
    {
        public string DeviceId { get; set; }
        public string DispenserId { get; set; }
        public string VehicleNumber { get; set; }
        public string HexTagId { get; set; }
        public string Amount { get; set; }
        public string FUELTxnID { get; set; }
        public string PlazaCode { get; set; }

    }

    public class IciciInitFuelPayHexTagResponse
    {
        public bool IsSuccess { get; set; }
        public bool IsBlacklist { get; set; }
        public bool IsBalanceAvailable { get; set; }
        public List<string> Messages { get; set; }
    }



    public class IciciCompleteFuelPaymentInput : BaseClass
    {
        public string FUELTxnID { get; set; }
        public string HexTagId { get; set; }
        public string OTP { get; set; }
    }

    public class IciciCompleteFuelPaymentOutput : BaseClassOutput
    {
        public string TxnProcessedDateTime { get; set; }
        public bool IsAcceptedForDebit { get; set; }
        public bool IsSuccess { get; set; }
        public string Messages { get; set; }
    }
        public class IciciCompleteFuelPayRequest
    {
        public string FUELTxnID { get; set; }
        public string OTP { get; set; }
    }

    public class IciciCompleteFuelPayResponse
    {
        public string TxnProcessedDateTime { get; set; }
        public bool IsAcceptedForDebit { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Messages { get; set; }
    }
}
