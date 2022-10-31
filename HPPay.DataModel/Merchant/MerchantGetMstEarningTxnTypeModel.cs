using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Merchant
{
    public class MerchantGetMstEarningTxnTypeModelInput:BaseClass
    {
        //[Required]
        //[JsonPropertyName("TxnType")]
        //[DataMember]
        //public int TxnType { get; set; }
    }



    public class MerchantGetMstEarningTxnTypeModelOutput 
    {
        [Required]
        [JsonProperty("TxnTypeID")]
        [DataMember]
        public int TxnTypeID { get; set; }

        [JsonProperty("Name")]
        [DataMember]
        public string Name { get; set; }


    }

    public class GetTransactionsTypeModelInput : BaseClass
    { 


    }

    public class GetTransactionsTypeModelOutput
    {
        [Required]
        [JsonProperty("TxnTypeID")]
        [DataMember]
        public int TxnTypeID { get; set; }

        [JsonProperty("TxnTypeName")]
        [DataMember]
        public string TxnTypeName { get; set; }


    }
    public class GetMerchantBankNameModelInput : BaseClass
    {


    }

    public class GetMerchantBankNameModelOutput
    {
        [Required]
        [JsonProperty("Id")]
        [DataMember]
        public int Id { get; set; }

        [JsonProperty("BankName")]
        [DataMember]
        public string BankName { get; set; }


    }

    public class MerchantTransactionGetRegistrationProcessModelInput : BaseClassTerminal
    {
        [Required]
        [JsonPropertyName("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [Required]
        [JsonPropertyName("HWSerialNo")]
        [DataMember]
        public string HWSerialNo { get; set; }

        [Required]
        [JsonPropertyName("Password")]
        [DataMember]
        public string Password { get; set; }
        
    }

    public class MerchantTransactionGetRegistrationModelOutput
    {
        [JsonProperty("ObjGetMerchantDetail")]
        public List<MerchantTransactionGetRegistrationProcessMerchantModelOutput> ObjGetMerchantDetail { get; set; }

        [JsonProperty("ObjGetTransTypeDetail")]
        public List<MerchantTransactionGetRegistrationProcessTransModelOutput> ObjGetTransTypeDetail { get; set; }

        [JsonProperty("ObjGetParentTransTypeDetail")]
        public List<MerchantTransactionGetTransTypeDetailByParentidModelOutput> ObjGetParentTransTypeDetail { get; set; }

        [JsonProperty("ObjBanks")]
        public List<MerchantTransactionBanksModelOutput> ObjBanks { get; set; }

        [JsonProperty("ObjFormFactors")]
        public List<MerchantTransactionFormFactorsModelOutput> ObjFormFactors { get; set; }

        [JsonProperty("ObjProduct")]
        public List<MerchantProductModelOutput> ObjProduct { get; set; }

        [JsonProperty("ObjOutletDetails")]
        public List<MerchantOutletModelOutput> ObjOutletDetails { get; set; }

        
    }
    
    public class MerchantTransactionGetRegistrationProcessMerchantModelOutput : BaseClassOutput
    {
        [JsonProperty("Token")]
        [DataMember]
        public string Token { get; set; }

        [JsonProperty("MerchantId")]
        [DataMember]
        public string MerchantId { get; set; }

        [JsonProperty("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [JsonProperty("MerchantName")]
        [DataMember]
        public string MerchantName { get; set; }

        [JsonProperty("MerchantLocation")]
        [DataMember]
        public string MerchantLocation { get; set; }

        [JsonProperty("Header1")]
        [DataMember]
        public string Header1 { get; set; }


        [JsonProperty("Header2")]
        [DataMember]
        public string Header2 { get; set; }


        [JsonProperty("Footer1")]
        [DataMember]
        public string Footer1 { get; set; }


        [JsonProperty("Footer2")]
        [DataMember]
        public string Footer2 { get; set; }

        [JsonProperty("BatchSaleLimit")]
        [DataMember]
        public decimal BatchSaleLimit { get; set; }

        [JsonProperty("BatchReloadLimit")]
        [DataMember]
        public decimal BatchReloadLimit { get; set; }

        [JsonProperty("BatchSize")]
        [DataMember]
        public Int32 BatchSize { get; set; }


        [JsonProperty("SettlementTime")]
        [DataMember]
        public Int32 SettlementTime { get; set; }


        [JsonProperty("RemoteDownload")]
        [DataMember]
        public string RemoteDownload { get; set; }


        [JsonProperty("URL")]
        [DataMember]
        public string URL { get; set; }


        [JsonProperty("BatchNo")]
        [DataMember]
        public string BatchNo { get; set; }

        [JsonProperty("CardFeeAmount")]
        [DataMember]
        public string CardFeeAmount { get; set; }

        [JsonProperty("StatusId")]
        [DataMember]
        public int StatusId { get; set; }

        [JsonProperty("StatusName")]
        [DataMember]
        public string StatusName { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }

        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

    }

    public class MerchantTransactionGetRegistrationProcessTransModelOutput
    {
        [JsonProperty("SerialNo")]
        [DataMember]
        public int SerialNo { get; set; }

        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }

        [JsonProperty("ParentId")]
        [DataMember]
        public Int32 ParentId { get; set; }

        

    }
    public class MerchantTransactionGetTransTypeDetailByParentidModelOutput
    {
        [JsonProperty("SerialNo")]
        [DataMember]
        public int SerialNo { get; set; }

        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }

        [JsonProperty("ParentId")]
        [DataMember]
        public Int32 ParentId { get; set; }


    }

    public class MerchantTransactionGetRegistrationProcessTransBalanceEnquiryModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }

    public class MerchantTransactionGetRegistrationProcessTransBalanceTransferModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }

    public class MerchantTransactionGetRegistrationProcessTransCardFeeModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }

    public class MerchantTransactionGetRegistrationProcessTransCardUnblockingModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }

    public class MerchantTransactionGetRegistrationProcessTransCCMSBalanceModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }

    public class MerchantTransactionGetRegistrationProcessTransCCMSRechargeModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }

    public class MerchantTransactionGetRegistrationProcessTransChangePinModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }

    public class MerchantTransactionGetRegistrationProcessTransControlPinChangeModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }

    public class MerchantTransactionGetRegistrationProcessTransDriverLoyaltyModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }

    public class MerchantTransactionGetRegistrationProcessTransLoyaltyBalanceModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }
    public class MerchantTransactionGetRegistrationProcessTransLoyaltyRedeemModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }
    public class MerchantTransactionGetRegistrationProcessTransOTCDriverRedeemModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }
    public class MerchantTransactionGetRegistrationProcessTransPaybackModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }
    public class MerchantTransactionGetRegistrationProcessTransPaycodeModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }
    public class MerchantTransactionGetRegistrationProcessTransReloadModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }
    public class MerchantTransactionGetRegistrationProcessTransSaleModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }
    public class MerchantTransactionGetRegistrationProcessTransSaleCompleteModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }
    public class MerchantTransactionGetRegistrationProcessTransTrackingModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }
    public class MerchantTransactionGetRegistrationProcessTransUnblockPinModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }
    public class MerchantTransactionGetRegistrationProcessTransVoidModelOutput
    {
        [JsonProperty("Type")]
        [DataMember]
        public string Type { get; set; }

        [JsonProperty("TransType")]
        [DataMember]
        public Int32 TransType { get; set; }

        [JsonProperty("TransName")]
        [DataMember]
        public string TransName { get; set; }

        [JsonProperty("MaxVal")]
        [DataMember]
        public decimal MaxVal { get; set; }


        [JsonProperty("MinVal")]
        [DataMember]
        public decimal MinVal { get; set; }

        [JsonProperty("ServiceStatus")]
        [DataMember]
        public Int32 ServiceStatus { get; set; }

        [JsonProperty("Carded")]
        [DataMember]
        public Int32 Carded { get; set; }

        [JsonProperty("Cardless")]
        [DataMember]
        public Int32 Cardless { get; set; }

        [JsonProperty("NonCarded")]
        [DataMember]
        public Int32 NonCarded { get; set; }
    }


    public class MerchantTransactionBanksModelOutput
    {
        [JsonProperty("FastagId")]
        [DataMember]
        public Int32 FastagId { get; set; }

        [JsonProperty("FastagName")]
        [DataMember]
        public string FastagName { get; set; }

    }


    public class MerchantTransactionFormFactorsModelOutput
    {
        [JsonProperty("FormFactorId")]
        [DataMember]
        public Int32 FormFactorId { get; set; }

        [JsonProperty("FormFactorName")]
        [DataMember]
        public string FormFactorName { get; set; }

    }

    public class MerchantProductModelOutput
    {
        [JsonProperty("ProductId")]
        [DataMember]
        public Int32 ProductId { get; set; }

        [JsonProperty("ProductName")]
        [DataMember]
        public string ProductName { get; set; }

        [JsonProperty("ProductStatus")]
        [DataMember]
        public Int32 ProductStatus { get; set; }

    }

    public class MerchantOutletModelOutput
    {
        [JsonProperty("OutletCategoryName")]
        [DataMember]
        public string OutletCategoryName { get; set; }

        [JsonProperty("MerchantTypeName")]
        [DataMember]
        public string MerchantTypeName { get; set; }

        [JsonProperty("EmailId")]
        [DataMember]
        public string EmailId { get; set; }


        [JsonProperty("MobileNo")]
        [DataMember]
        public string MobileNo { get; set; }

        [JsonProperty("RetailOutletAddress1")]
        [DataMember]
        public string RetailOutletAddress1 { get; set; }

        [JsonProperty("RetailOutletAddress2")]
        [DataMember]
        public string RetailOutletAddress2 { get; set; }

        [JsonProperty("RetailOutletAddress3")]
        [DataMember]
        public string RetailOutletAddress3 { get; set; }


        [JsonProperty("RetailOutletPhoneNumber")]
        [DataMember]
        public string RetailOutletPhoneNumber { get; set; }

        [JsonProperty("GSTNumber")]
        [DataMember]
        public string GSTNumber { get; set; }

        [JsonProperty("RetailOutletCity")]
        [DataMember]
        public string RetailOutletCity { get; set; }

        [JsonProperty("RetailOutletDistrictId")]
        [DataMember]
        public string RetailOutletDistrictId { get; set; }

        [JsonProperty("RetailOutletPinNumber")]
        [DataMember]
        public string RetailOutletPinNumber { get; set; }

        [JsonProperty("RetailOutletName")]
        [DataMember]
        public string RetailOutletName { get; set; }


        [JsonProperty("ZonalOfficeName")]
        [DataMember]
        public string ZonalOfficeName { get; set; }


        [JsonProperty("RegionalOfficeName")]
        [DataMember]
        public string RegionalOfficeName { get; set; }
         

        [JsonProperty("ErpCode")]
        [DataMember]
        public string ErpCode { get; set; }

        [JsonProperty("SalesArea")]
        [DataMember]
        public string SalesArea { get; set; }
    }



}
