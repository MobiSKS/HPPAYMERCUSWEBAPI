using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace HPPay.DataModel.Transaction
{
    public class TransactionGetRegistrationProcessModelInput : BaseClassTerminal
    {
        [Required]
        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }

        [Required]
        [JsonPropertyName("HWSerialNo")]
        [DataMember]
        public string HWSerialNo { get; set; }

       
    }

    public class TransactionGetRegistrationModelOutput
    {
        [JsonProperty("ObjGetMerchantDetail")]
        public List<TransactionGetRegistrationProcessMerchantModelOutput> ObjGetMerchantDetail { get; set; }

        [JsonProperty("ObjGetTransTypeDetail")]
        public List<TransactionGetRegistrationProcessTransModelOutput> ObjGetTransTypeDetail { get; set; }


        [JsonProperty("ObjBanks")]
        public List<TransactionBanksModelOutput> ObjBanks { get; set; }

        [JsonProperty("ObjFormFactors")]
        public List<TransactionFormFactorsModelOutput> ObjFormFactors { get; set; }

        [JsonProperty("ObjProduct")]
        public List<ProductModelOutput> ObjProduct { get; set; }
    }
    public class TransactionGetRegistrationProcessModelOutput
    {
        [JsonProperty("ObjGetRegistrationProcessMerchant")]
        public List<TransactionGetRegistrationProcessMerchantModelOutput> ObjGetRegistrationProcessMerchant { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransBalanceEnquiry")]
        public List<TransactionGetRegistrationProcessTransBalanceEnquiryModelOutput> ObjGetRegistrationProcessTransBalanceEnquiry { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransBalanceTransfer")]
        public List<TransactionGetRegistrationProcessTransBalanceTransferModelOutput> ObjGetRegistrationProcessTransBalanceTransfer { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransCardFee")]
        public List<TransactionGetRegistrationProcessTransCardFeeModelOutput> ObjGetRegistrationProcessTransCardFee { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransCardUnblocking")]
        public List<TransactionGetRegistrationProcessTransCardUnblockingModelOutput> ObjGetRegistrationProcessTransCardUnblocking { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransCCMSBalance")]
        public List<TransactionGetRegistrationProcessTransCCMSBalanceModelOutput> ObjGetRegistrationProcessTransCCMSBalance { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransCCMSRecharge")]
        public List<TransactionGetRegistrationProcessTransCCMSRechargeModelOutput> ObjGetRegistrationProcessTransCCMSRecharge { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransChangePin")]
        public List<TransactionGetRegistrationProcessTransChangePinModelOutput> ObjGetRegistrationProcessTransChangePin { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransControlPinChange")]
        public List<TransactionGetRegistrationProcessTransControlPinChangeModelOutput> ObjGetRegistrationProcessTransControlPinChange { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransDriverLoyalty")]
        public List<TransactionGetRegistrationProcessTransDriverLoyaltyModelOutput> ObjGetRegistrationProcessTransDriverLoyalty { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransLoyaltyBalance")]
        public List<TransactionGetRegistrationProcessTransLoyaltyBalanceModelOutput> ObjGetRegistrationProcessTransLoyaltyBalance { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransLoyaltyRedeem")]
        public List<TransactionGetRegistrationProcessTransLoyaltyRedeemModelOutput> ObjGetRegistrationProcessTransLoyaltyRedeem { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransOTCDriverRedeem")]
        public List<TransactionGetRegistrationProcessTransOTCDriverRedeemModelOutput> ObjGetRegistrationProcessTransOTCDriverRedeem { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransPayback")]
        public List<TransactionGetRegistrationProcessTransPaybackModelOutput> ObjGetRegistrationProcessTransPayback { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransPaycode")]
        public List<TransactionGetRegistrationProcessTransPaycodeModelOutput> ObjGetRegistrationProcessTransPaycode { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransReload")]
        public List<TransactionGetRegistrationProcessTransReloadModelOutput> ObjGetRegistrationProcessTransReload { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransSale")]
        public List<TransactionGetRegistrationProcessTransSaleModelOutput> ObjGetRegistrationProcessTransSale { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransSaleComplete")]
        public List<TransactionGetRegistrationProcessTransSaleCompleteModelOutput> ObjGetRegistrationProcessTransSaleComplete { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransTracking")]
        public List<TransactionGetRegistrationProcessTransTrackingModelOutput> ObjGetRegistrationProcessTransTracking { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransUnblockPin")]
        public List<TransactionGetRegistrationProcessTransUnblockPinModelOutput> ObjGetRegistrationProcessTransUnblockPin { get; set; }

        [JsonProperty("ObjGetRegistrationProcessTransVoid")]
        public List<TransactionGetRegistrationProcessTransVoidModelOutput> ObjGetRegistrationProcessTransVoid { get; set; }


        [JsonProperty("ObjBanks")]
        public List<TransactionBanksModelOutput> ObjBanks { get; set; }

        [JsonProperty("ObjFormFactors")]
        public List<TransactionFormFactorsModelOutput> ObjFormFactors { get; set; }

        [JsonProperty("ObjProduct")]
        public List<ProductModelOutput> ObjProduct { get; set; }
    }

    public class TransactionGetRegistrationProcessMerchantModelOutput : BaseClassOutput
    {
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


        [JsonProperty("CommunicationCity")]
        [DataMember]
        public string CommunicationCity { get; set; }

        [JsonProperty("CommunicationDistrictId")]
        [DataMember]
        public Int32 CommunicationDistrictId { get; set; }

        [JsonProperty("CommunicationStateId")]
        [DataMember]
        public Int32 CommunicationStateId { get; set; }

        [JsonProperty("CommunicationPhoneNumber")]
        [DataMember]
        public string CommunicationPhoneNumber { get; set; }


        [JsonProperty("CommunicationAddress")]
        [DataMember]
        public string CommunicationAddress { get; set; }

        [JsonProperty("CommunicationPinNumber")]
        [DataMember]
        public string CommunicationPinNumber { get; set; }

        [JsonProperty("CommunicationStateName")]
        [DataMember]
        public string CommunicationStateName { get; set; }

        [JsonProperty("CommunicationDistrictName")]
        [DataMember]
        public string CommunicationDistrictName { get; set; }

    }

    public class TransactionGetRegistrationProcessTransModelOutput
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

        [JsonProperty("ObjGetParentTransTypeDetail")]
        public List<TransactionGetTransTypeDetailByParentidModelOutput> ObjGetParentTransTypeDetail { get; set; }

    }
    public class TransactionGetTransTypeDetailByParentidModelOutput
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

    public class TransactionGetRegistrationProcessTransBalanceEnquiryModelOutput
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

    public class TransactionGetRegistrationProcessTransBalanceTransferModelOutput
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

    public class TransactionGetRegistrationProcessTransCardFeeModelOutput
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

    public class TransactionGetRegistrationProcessTransCardUnblockingModelOutput
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

    public class TransactionGetRegistrationProcessTransCCMSBalanceModelOutput
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

    public class TransactionGetRegistrationProcessTransCCMSRechargeModelOutput
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

    public class TransactionGetRegistrationProcessTransChangePinModelOutput
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

    public class TransactionGetRegistrationProcessTransControlPinChangeModelOutput
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

    public class TransactionGetRegistrationProcessTransDriverLoyaltyModelOutput
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

    public class TransactionGetRegistrationProcessTransLoyaltyBalanceModelOutput
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
    public class TransactionGetRegistrationProcessTransLoyaltyRedeemModelOutput
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
    public class TransactionGetRegistrationProcessTransOTCDriverRedeemModelOutput
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
    public class TransactionGetRegistrationProcessTransPaybackModelOutput
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
    public class TransactionGetRegistrationProcessTransPaycodeModelOutput
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
    public class TransactionGetRegistrationProcessTransReloadModelOutput
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
    public class TransactionGetRegistrationProcessTransSaleModelOutput
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
    public class TransactionGetRegistrationProcessTransSaleCompleteModelOutput
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
    public class TransactionGetRegistrationProcessTransTrackingModelOutput
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
    public class TransactionGetRegistrationProcessTransUnblockPinModelOutput
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
    public class TransactionGetRegistrationProcessTransVoidModelOutput
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
   

    public class TransactionBanksModelOutput
    {
        [JsonProperty("FastagId")]
        [DataMember]
        public Int32 FastagId { get; set; }

        [JsonProperty("FastagName")]
        [DataMember]
        public string FastagName { get; set; }

    }

     
 


    public class TransactionFormFactorsModelOutput
    {
        [JsonProperty("FormFactorId")]
        [DataMember]
        public Int32 FormFactorId { get; set; }

        [JsonProperty("FormFactorName")]
        [DataMember]
        public string FormFactorName { get; set; }

    }

    public class ProductModelOutput
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
}
