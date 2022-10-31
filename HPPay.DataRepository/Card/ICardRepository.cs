using HPPay.DataModel.Card;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;


namespace HPPay.DataRepository.Card
{
    public interface ICardRepository
    {
        public Task<IEnumerable<ManageSearchCardsModelOutput>> SearchManageCard([FromBody] ManageSearchCardsModelInput ObjClass);
        public Task<GetCardLimtModelOutput> GetCardLimitFeatures([FromBody] GetCardLimtModelInput ObjClass);
        public Task<IEnumerable<UpdateMobileInCardModelOutput>> UpdateMobileInCard([FromBody] UpdateMobileInCardModelInput ObjClass);
        public Task<IEnumerable<UpdateServiveOnCardModelOutput>> UpdateServiveOnCard([FromBody] UpdateServiveOnCardModelInput ObjClass);
        public Task<IEnumerable<UpdateCardLimitsModelOutput>> UpdateCardLimits([FromBody] UpdateCardLimitsModelInput ObjClass);
        public Task<IEnumerable<UpdateCCMSLimitsModelOutput>> UpdateCCMSLimits([FromBody] UpdateCCMSLimitsModelInput ObjClass);
        public Task<GetCCMSLimitsModelOutput> GetCCMSLimits([FromBody] GetCCMSLimitsModelInput ObjClass);
        public Task<IEnumerable<GetCardLimitsModelOutput>> GetCardLimits([FromBody] GetCardLimitsModelInput ObjClass);
        public Task<IEnumerable<UpdateCCMSLimitForAllCardsModelOutput>> UpdateCCMSLimitForAllCards([FromBody] UpdateCCMSLimitForAllCardsModelInput ObjClass);
        public Task<IEnumerable<UpdateCardLimitForAllCardsModelOutput>> UpdateCardLimitForAllCards([FromBody] UpdateCardLimitForAllCardsModelInput ObjClass);
        public Task<IEnumerable<GetLimitMasterModelOutput>> GetCCMSLimitMaster([FromBody] GetLimitMasterModelInput ObjClass);
        public Task<IEnumerable<GetAllCardWithStatusModelOutput>> GetAllCardWithStatus([FromBody] GetAllCardWithStatusModelInput ObjClass);
        public Task<IEnumerable<UpdateCardStatusModelOutput>> UpdateCardStatus([FromBody] UpdateCardStatusModelInput ObjClass);
        public Task<IEnumerable<ViewCardLimitsModelOutput>> ViewCardLimits([FromBody] ViewCardLimitsModelInput ObjClass);
        public Task<IEnumerable<GetCCMSLimitsForAllCardsModelOutput>> GetCCMSLimitsForAllCards([FromBody] GetCCMSLimitsForAllCardsModelInput ObjClass);
        public Task<IEnumerable<AddCardModelOutput>> AddCard([FromBody] AddCardModelInput ObjClass);
        public Task<IEnumerable<UpdateMobileandFastagNoInCardModelOutput>> UpdateMobileandFastagNoInCard([FromBody] UpdateMobileandFastagNoInCardModelInput ObjClass);

        public Task<IEnumerable<BindPendingCustomerforCardModelOutput>> BindPendingCustomerForCardApproval([FromBody] BindPendingCustomerforCardModelInput ObjClass);

        public Task<IEnumerable<BindPendingCustomerforCardModelOutput>> BindPendingCustomerForAddOnCardApproval([FromBody] BindPendingCustomerforCardModelInput ObjClass);

        public Task<IEnumerable<GetCardDetailForCardApprovalModelOutput>> GetCardDetailForCardApproval([FromBody] GetCardDetailForCardApprovalModelInput ObjClass);

        public Task<IEnumerable<GetCardDetailForCardApprovalModelOutput>> GetCardDetailForAddOnCardApproval([FromBody] GetCardDetailForCardApprovalModelInput ObjClass);

        public Task<IEnumerable<ApproveRejectCardModelOutput>> ApproveRejectCard([FromBody] ApproveRejectCardModelInput ObjClass);

        public Task<IEnumerable<ApproveRejectAddOnCardModelOutput>> ApproveRejectAddOnCard([FromBody] ApproveRejectAddOnCardModelInput ObjClass);

        public Task<IEnumerable<CardSearchMappingDetailModelOutput>> SearchCardMappingDetail([FromBody] CardSearchMappingDetailModelInput ObjClass);
        public Task<IEnumerable<CardSearchMappingDetailsWithBlankMobileModelOutput>> SearchCardMappingDetailsWithBlankMobile([FromBody] CardSearchMappingDetailsWithBlankMobileModelInput ObjClass);

        public Task<IEnumerable<GetCardtoCCMSBalanceTransferModelOutput>> GetCardtoCCMSBalanceTransfer([FromBody] GetCardtoCCMSBalanceTransferModelInput ObjClass);

        public Task<GetCcmsToCardBalanceTransferModelOutput> GetCCMSToCardBalanceTransfer([FromBody] GetCcmsToCardBalanceTransferModelInput ObjClass);

        public Task<IEnumerable<GetCardtoCardBalanceTransferModelOutput>> GetCardtoCardBalanceTransfer([FromBody] GetCardtoCardBalanceTransferModelInput ObjClass);

        public Task<IEnumerable<CardCheckVechileNoModelOutput>> CheckVechileNo([FromBody] CardCheckVechileNoModelInput ObjClass);

        public Task<IEnumerable<CheckFastagNoDuplicacyInCardModelOutput>> CheckFastagNoDuplicacyInCard([FromBody] CheckFastagNoDuplicacyInCardModelInput ObjClass);

        public Task<IEnumerable<AddOnCardModelOutput>> AddOnCard([FromBody] AddOnCardModelInput ObjClass);

        public Task<IEnumerable<CheckAddOnFormNumberModelOutput>> CheckAddOnFormNumber([FromBody] CheckAddOnFormNumberModelInput ObjClass);

        public Task<IEnumerable<BindPendingCustomerForAddOnCardApprovalModelOutput>> BindPendingCustomerForAddOnCardApproval([FromBody] BindPendingCustomerForAddOnCardApprovalModelInput ObjClass);

        public Task<IEnumerable<CardCheckMobileNoModelOutput>> CheckMobileNo([FromBody] CardCheckMobileNoModelInput ObjClass);
        public Task<IEnumerable<TransferAmountCCMSToCardModelOutput>> TransferAmountCCMSToCard([FromBody] TransferAmountCCMSToCardModelInput ObjClass);
        public Task<IEnumerable<TransferAmountCardToCCMSModeloutput>> TransferAmountCardToCCMS([FromBody] TransferAmountCardToCCMSModelInput ObjClass);
        public Task<IEnumerable<TransferAmountCardToCardModelOutput>> TransferAmountCardToCard([FromBody] TransferAmountCardToCardModelInput ObjClass);

        public Task<IEnumerable<CheckCardIdentifierNoModelOutput>> CheckCardIdentifierNo([FromBody] CheckCardIdentifierNoModelInput ObjClass);
        public Task<IEnumerable<GetCardsForLimitUpdateForSingleRechargeModelOutput>> GetCardsForLimitUpdateForSingleRecharge([FromBody] GetCardsForLimitUpdateForSingleRechargeModelInput ObjClass);
        public Task<IEnumerable<LimitUpdateForSingleRechargeCardModelOutput>> LimitUpdateForSingleRecharge([FromBody] LimitUpdateForSingleRechargeCardModelInput ObjClass);
        public Task<IEnumerable<GetDetailForCorpMultiRechargeLimitConfigModelOutput>> GetDetailForCorpMultiRechargeLimitConfig([FromBody] GetDetailForCorpMultiRechargeLimitConfigModelInput ObjClass);
        public Task<IEnumerable<CorpMultiRechargeLimitConfigModelOutput>> CorpMultiRechargeLimitConfig([FromBody] CorpMultiRechargeLimitConfigModelInput ObjClass);

        public Task<IEnumerable<EmergencyReplacementCardModelOutput>> GetDetailForEmergencyReplacementCards([FromBody] EmergencyReplacementCardModelInput ObjClass);

        public Task<IEnumerable<EmergencyReplacementCardsModelOutput>> EmergencyReplacementCards([FromBody] UpdateEmergencyReplacementCardsModelInput ObjClass);

        public Task<IEnumerable<CardGetCardRenewalRequestDetailModelOutput>> GetCardRenewalRequestDetail([FromBody] CardGetCardRenewalRequestDetailModelInput ObjClass);


        public  Task<IEnumerable<CardUpdateCardRenewalRequestModelOutput>> UpdateCardRenewalRequest([FromBody] CardUpdateCardRenewalRequestModelInput ObjClass);

        public Task<IEnumerable<CardApproveCardRenewalRequestsModelOutput>> ApproveCardRenewalRequests([FromBody] CardApproveCardRenewalRequestsModelInput ObjClass);

        public Task<GetDetailForEnableDisableProductsAndTransactionsModelOutput> GetDetailForEnableDisableProductsAndTransactions([FromBody] GetDetailForEnableDisableProductsAndTransactionsModelInput ObjClass);

        public Task<IEnumerable<EnableDisableProductsAndTransactionsModelOutput>> EnableDisableProductsAndTransactions([FromBody] EnableDisableProductsAndTransactionsModelInput ObjClass);

        public Task<IEnumerable<CardUpdateApproveCardRenewalRequestsModelOutput>> UpdateApproveCardRenewalRequests([FromBody] CardUpdateApproveCardRenewalRequestsModelInput ObjClass);

        public Task<IEnumerable<UpdateHotlistReissueCardRequestModelOutput>> UpdateHotlistReissueCardRequest([FromBody] UpdateHotlistReissueCardRequestModelInput ObjClass);

        public Task<IEnumerable<GetGenericAttachedVehicleModelOutput>> GetGenericAttachedVehicle([FromBody] GetGenericAttachedVehicleModelInput ObjClass);

        public  Task<IEnumerable<GetApproveCardReissuanceRequestModelOutput>> GetApproveCardReissuanceRequest([FromBody] GetApproveCardReissuanceRequestModelInput ObjClass);
        public Task<IEnumerable<GetLimitTypeModelOutput>> GetLimitType([FromBody] GetLimitTypeModelInput ObjClass);
        public Task<IEnumerable<CardwiseLimitAuditTrailModelOutput>> CardwiseLimitAuditTrail([FromBody] CardwiseLimitAuditTrailModelInput ObjClass);
        public  Task<IEnumerable<UpdateApproveCardReissuanceRequestModelOutput>> UpdateApproveCardReissuanceRequest([FromBody] UpdateApproveCardReissuanceRequestModelInput ObjClass);
       
         public Task<IEnumerable<GetAddOnCardRequestDetailsModelOutput>> GetAddOnCardRequestDetails([FromBody] GetAddOnCardRequestDetailsModelInput ObjClass);

        public Task<IEnumerable<AddOnCardRequestWithPaymentModelOutput>> AddOnCardRequestWithPayment([FromBody] AddOnCardRequestWithPaymentModelInput ObjClass);
        public Task<IEnumerable<ApproveRejectAddOnCardWithPaymentModelOutput>> ApproveRejectAddOnCardWithPayment([FromBody] ApproveRejectAddOnCardWithPaymentModelInput ObjClass);
        public Task<IEnumerable<CardPinUnblockMobileRequestModelOutput>> CardPinUnblockMobileRequest([FromBody] CardPinUnblockMobileRequestModelInput ObjClass);

        public Task<IEnumerable<GetCardLimitsByVehicleNoModelOutput>> GetCardLimitsByVehicleNo([FromBody] GetCardLimitsByVehicleNoModelInput ObjClass);
        public Task<IEnumerable<UpdateCardLimitsLimitTypeWiseModelOutput>> UpdateCardLimitsLimitTypeWise([FromBody] UpdateCardLimitsLimitTypeWiseModelInput ObjClass);
        public Task<IEnumerable<GetCCMSLimitsByVehicleNoModelOutput>> GetCCMSLimitsByVehicleNo([FromBody] GetCCMSLimitsByVehicleNoModelInput ObjClass);
        public Task<IEnumerable<UpdateCCMSLimitsCardWiseModelOutput>>UpdateCCMSLimitsCardWise([FromBody] UpdateCCMSLimitsCardWiseModelInput ObjClass);
        public Task<IEnumerable<GetCardBalanceModelOutput>> GetCardBalance([FromBody] GetCardBalanceModelInput ObjClass);
        public  Task<IEnumerable<GetCardIssueTypeModelOutput>> GetCardIssueType([FromBody] GetCardIssueTypeModelInput ObjClass);

        public  Task<IEnumerable<ShowOTPModelOutput>> ShowOTP([FromBody] ShowOTPModelInput ObjClass);
        public Task<IEnumerable<CheckCustomerDriverStarsCCMSBalanceModelOutput>> CheckCustomerDriverStarsCCMSBalance([FromBody] CheckCustomerDriverStarsCCMSBalanceModelInput ObjClass);

        public Task<IEnumerable<BindPendingCustomerForAddOnCardWithPaymentApprovalModelOutput>> BindPendingCustomerForAddOnCardWithPaymentApproval([FromBody] BindPendingCustomerForAddOnCardWithPaymentApprovalModelInput ObjClass);
        public Task<IEnumerable<GetCardDetailForAddOnCardWithPaymentApprovalModelOutput>> GetCardDetailForAddOnCardWithPaymentApproval([FromBody] GetCardDetailForAddOnCardWithPaymentApprovalModelInput ObjClass);
        public  Task<IEnumerable<GetVehicleNoModelOutput>> GetVehicleNo([FromBody] GetVehicleNoModelInput ObjClass);
        public  Task<IEnumerable<CheckCCMSBalanceDriverstarsforAddOnCardRequestModelOutput>> CheckCCMSBalanceDriverstarsforAddOnCardRequest([FromBody] CheckCCMSBalanceDriverstarsforAddOnCardRequestModelInput ObjClass);

        public Task<IEnumerable<CheckVechileNoThroughVahanModelOutput>> CheckVechileNoThroughVahan([FromBody] CheckVechileNoThroughVahanModelInput ObjClass);

        public Task<IEnumerable<GetVehicleDetailsModelOutput>> GetVehicleDetails([FromBody] GetVehicleDetailsModelInput ObjClass);

        public Task<IEnumerable<GetVehicleDetailsModelOutput>> InsertVehicleDetails([FromBody] InsertVehicleDetailsModelInput ObjClass);

        public Task<IEnumerable<GetCustomerTCSBalanceInfoModelOutput>> CustomerTCSBalanceInfo([FromBody] GetCustomerTCSBalanceInfoModelInput ObjClass);
        //  public Task<IEnumerable<ManageSearchCardsModelOutput>> GetCardInfowithVahanInfo([FromBody] ManageSearchCardsModelInput ObjClass);
        public Task<IEnumerable<CardManageSearchWithVahanInfoModelOutput>> GetCardInfowithVahanInfo([FromBody] CardManageSearchWithVahanInfoModelnput ObjClass);

        public Task<IEnumerable<BindRejectedCustomerforCardModelOutput>> BindRejectedCustomerForCardApproval([FromBody] BindRejectedCustomerforCardModelInput ObjClass);

        public  Task<IEnumerable<UpdateRawCardSendbackModelOutput>> UpdateRawCardSendback([FromBody] UpdateRawCardSendbackModelInput ObjClass);

        public Task<IEnumerable<CheckInvalidCustomerIDForLoginUserModelOutput>> CheckInvalidCustomerIDForLoginUser([FromBody] CheckInvalidCustomerIDForLoginUserModelInput ObjClass);

        public  Task<IEnumerable<BindRejectedCustomerforAddOnCardModelOutput>> BindRejectedCustomerForAddOnCardApproval([FromBody] BindPendingCustomerforCardModelInput ObjClass);
    }
}
