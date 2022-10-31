using HPPay.DataModel.Merchant;
using HPPay.DataModel.Transaction;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.Merchant
{
    public interface IMerchantRepository
    {
        public Task<IEnumerable<GetMerchantTypeModelOutput>> GetMerchantType([FromBody] GetMerchantTypeModelInput ObjClass);

        public Task<IEnumerable<GetMerchantOutletCategoryModelOutput>> GetOutletCategory([FromBody] GetMerchantOutletCategoryModelInput ObjClass);

        public Task<IEnumerable<MerchantGetSBUModelOutput>> GetSBU([FromBody] MerchantGetSBUModelInput ObjClass);

        public Task<IEnumerable<MerchantInsertModelOutput>> InsertMerchant([FromBody] MerchantInsertModelInput ObjClass);

        public Task<IEnumerable<MerchantUpdateModelOutput>> UpdateMerchant([FromBody] MerchantUpdateModelInput ObjClass);

        public Task<IEnumerable<MerchantApprovalRejectModelOutput>> ApproveRejectMerchant([FromBody] MerchantApprovalRejectModelInput ObjClass);

        public Task<IEnumerable<GetNewlyCreatedTerminalIdsBasedOnErpCodesModelOutput>> GetNewlyCreatedTerminalIdsBasedOnErpCodes([FromBody] GetNewlyCreatedTerminalIdsBasedOnErpCodesModelInput ObjClass);
        public Task<IEnumerable<MerchantGetByMerchantIdModelOutput>> GetMerchantbyMerchantId([FromBody] MerchantGetByMerchantIdModelInput ObjClass);

        public Task<IEnumerable<GetMerchantDataUpdateRequestBeforeApprovalModelOutput>> GetMerchantDataUpdateRequestBeforeApproval([FromBody] GetMerchantDataUpdateRequestBeforeApprovalModelInput ObjClass);

        public Task<IEnumerable<MerchantGetByMerchantIdModelOutput>> GetMerchantbyERPCode([FromBody] MerchantGetByErpCodeModelInput ObjClass);

        public Task<IEnumerable<MerchantGetMerchantApprovalModelOutput>> GetMerchantApproval([FromBody] MerchantGetMerchantApprovalModelInput ObjClass);

        public Task<IEnumerable<RejectedMerchantModelOutput>> GetRejectedMerchant([FromBody] RejectedMerchantModelInput ObjClass);

        public Task<IEnumerable<MerchantSearchMerchantForCardCreationModelOutput>> SearchMerchantForCardCreation([FromBody] MerchantSearchMerchantForCardCreationModelInput ObjClass);
        public Task<IEnumerable<VerifyMerchantByMerchantIdModelOutput>> VerifyMerchantByMerchantId([FromBody] VerifyMerchantByMerchantIdModelInput ObjClass);

        public Task<IEnumerable<VerifyMerchantByMerchantIdandRegionalIdModelOutput>> VerifyMerchantByMerchantIdandRegionalId([FromBody] VerifyMerchantByMerchantIdandRegionalIdModelInput ObjClass);

        public Task<IEnumerable<MerchantSearchMerchantModelOutput>> SearchMerchant([FromBody] MerchantSearchMerchantModelInput ObjClass);

        public Task<IEnumerable<MerchantGetMerchantStatusModelOutput>> GetMerchantStatus([FromBody] MerchantGetMerchantStatusModelInput ObjClass);
       
        public Task<IEnumerable<MerchantViewMerchantCautionLimitModelOutput>> ViewMerchantCautionLimit([FromBody] MerchantViewMerchantCautionLimitModelInput ObjClass);

        public Task<IEnumerable<MerchantSettlementDetailsModelOutput>> MerchantSettlementDetail([FromBody] MerchantSettlementDetailsModelInput ObjClass);

        public Task<IEnumerable<MerchantBatchDetailModelOutput>> MerchantBatchDetail([FromBody] MerchantBatchDetailModelInput ObjClass);

        public Task<IEnumerable<MerchantTransactionDetailModelOutput>> MerchantTransactionDetail([FromBody] MerchantTransactionDetailModelInput ObjClass);

        public Task<IEnumerable<MerchantSaleReloadDeltaDetailModelOutput>> MerchantSaleReloadDeltaDetail([FromBody] MerchantSaleReloadDeltaDetailModelInput ObjClass);

        public Task<IEnumerable<MerchantERPReloadSaleEarningDetailModelOutput>> MerchantERPReloadSaleEarningDetail([FromBody] MerchantERPReloadSaleEarningDetailModelInput ObjClass);

        public Task<IEnumerable<MerchantReceivablePayableDetailModelOutput>> MerchantReceivablePayableDetail([FromBody] MerchantReceivablePayableDetailModelInput ObjClass);

        public Task<IEnumerable<ValidateMerchantErpCodeModelOutput>> ValidateMerchantErpCode([FromBody] ValidateMerchantErpCodeModelInput ObjClass);

        public Task<IEnumerable<CheckMappedMerchantIDModelOutput>> CheckMappedMerchantID([FromBody] CheckMappedMerchantIDModelInput ObjClass);

        public Task<IEnumerable<ApproveRejectMerchantUpdateModelOutput>> ApproveRejectMerchantUpdate([FromBody] ApproveRejectMerchantUpdateModelInput ObjClass);

        public Task<IEnumerable<MerchantReactivationStatusModelOutput>> MerchantReactivationStatus([FromBody] MerchantReactivationStatusModelInput ObjClass);

        public Task<IEnumerable<MerchantReactivationRequestModelOutput>> MerchantReactivationRequest([FromBody] MerchantReactivationRequestModelInput ObjClass);
        public Task<IEnumerable<MerchantGetHotlistedMonthYearModelOuput>> GetHotlistedMonthYear([FromBody] MerchantGetHotlistedMonthYearModelInput ObjClass);
        public  Task<IEnumerable<GetApprovedMerchantReactivationStatusModelOutput>> GetApprovedMerchantReactivationStatus([FromBody] GetApprovedMerchantReactivationStatusModelInput ObjClass);

        public  Task<IEnumerable<GetRequestForApprovalReactivateMerchantModelOutput>> GetRequestForApprovalReactivateMerchant([FromBody] GetRequestForApprovalReactivateMerchantModelInput ObjClass);
        public Task<IEnumerable<MerchantGetRequestReactivationMerchantModelOutput>> GetRequestReactivationMerchant([FromBody] MerchantGetRequestReactivationMerchantModelInput ObjClass);
        public  Task<IEnumerable<MerchantApproveMerchantReactivationRequestModelOuput>> ApproveMerchantReactivationRequest([FromBody] MerchantApproveMerchantReactivationRequestModelInput ObjClass);
        public Task<IEnumerable<InsertMobileDispenserRetailOutletMappingModelOutput>> InsertMobileDispenserRetailOutletMapping([FromBody] InsertMobileDispenserRetailOutletMappingModelInput ObjClass);
        public  Task<IEnumerable<MerchantApproveMobileDispenserRetailOutletMappingModelOutput>> ApproveMobileDispenserRetailOutletMapping([FromBody] MerchantApproveMobileDispenserRetailOutletMappingModelInput ObjClass);
        public Task<IEnumerable<MerchantGetMobileDispenserRetailOutletMappingModelOutput>> GetMobileDispenserRetailOutletMapping([FromBody] MerchantGetMobileDispenserRetailOutletMappingModelInput ObjClass);
        public Task<IEnumerable<MerchantGetMobileDispenserModelOutput>> GetMobileDispenser([FromBody] MerchantGetMobileDispenserModelInput ObjClass);
        public Task<IEnumerable<GetMappedParentMerchantIdModelOutput>> GetMappedParentMerchantId([FromBody] GetMappedParentMerchantIdModelInput ObjClass);
        public Task<IEnumerable<MerchantGetApproveTerminalMerchantMappingModelOutput>> GetApproveTerminalMerchantMapping([FromBody] MerchantGetApproveTerminalMerchantMappingModelInput ObjClass);
        public Task<IEnumerable<MerchantApproveTerminalMerchantMappingModelOutput>> ApproveTerminalMerchantMapping([FromBody] MerchantApproveTerminalMerchantMappingModelInput ObjClass);
        public Task<GetTerminalDetailsForManagTerminalModelOutput> GetTerminalDetailsForManagTerminal([FromBody] GetTerminalDetailsForManagTerminalModelInput ObjClass);
        public Task<IEnumerable<MerchantInsertMobileDispenserCustomerModelOutput>> InsertMobileDispenserCustomer([FromBody] MerchantInsertMobileDispenserCustomerModelInput ObjClass);
        public Task<IEnumerable<MerchantInsertTerminalDetailsModelOutput>> InsertTerminalDetails([FromBody] MerchantInsertTerminalDetailsModelInput ObjClass);
        public Task<IEnumerable<GetBalanceCCMSRechargebyMobiledispenserModelOutput>> GetBalanceCCMSRechargebyMobiledispenser([FromBody] GetBalanceCCMSRechargebyMobiledispenserModelInput ObjClass);//surya
        public Task<IEnumerable<GetCCMSRechargebyMobiledispenserModelOutput>> InitiateCCMSMobileDispercerRecharge([FromBody] GetCCMSRechargebyMobiledispenserModelInput ObjClass);
        public void InsertCCMSMobileDispencerGApiRequestResponse([FromBody] ApiRequestResponse ObjClass);

        public  Task<GetMobileDispencerFuelPurchaseModelOutPut> GetMobileDispencerFuelPurchase([FromBody] GetMobileDispencerFuelPurchaseModelInput ObjClass);

        public Task<IEnumerable<InsertMobileDispencerFuelPurchaseModelOutPut>> InsertMobileDispencerFuelPurchase([FromBody] InsertMobileDispencerFuelPurchaseModelInput ObjClass);

        public Task<IEnumerable<GetTerminalMerchantMappingStatusModelOutput>> GetTerminalMerchantMappingStatus([FromBody] GetTerminalMerchantMappingStatusModelInput ObjClass);

        public Task<IEnumerable<GetStatusMobileDispenserRetailOutletMappingModelOutPut>> GetStatusMobileDispenserRetailOutletMapping([FromBody] GetStatusMobileDispenserRetailOutletMappingModelInput ObjClass);

        public Task<IEnumerable<GetStatusMobileDispenserModelOutPut>> GetStatusMobileDispenser();

        public Task<IEnumerable<CheckMerchantIdStatusModelOutput>> CheckMerchantIdStatus([FromBody] CheckMerchantIdStatusModelInput ObjClass);

        public Task<IEnumerable<MerchantGetViewMerchantEarningbreakupModelOutput>> GetViewMerchantEarningbreakup([FromBody] MerchantGetViewMerchantEarningbreakupModelInput ObjClass);


        public Task<IEnumerable<MerchantGetMstEarningTxnTypeModelOutput>> GetMstEarningTxnType([FromBody] MerchantGetMstEarningTxnTypeModelInput ObjClass);


        public Task<IEnumerable<WebGenerateOTPModelOutput>> MobileDispenserGenerateOTP([FromBody] WebGenerateOTPModelInput ObjClass);
        
        public Task<IEnumerable<MobileDispenserConfirmOTPModelOutPut>> MobileDispenserConfirmOTP([FromBody] MobileDispenserConfirmOTPModelInput ObjClass);

        public Task<IEnumerable<GetTransactionsTypeModelOutput>> GetTransactionsType([FromBody] GetTransactionsTypeModelInput ObjClass);
       
        public Task<IEnumerable<GetMerchantBankNameModelOutput>> GetMerchantBankName([FromBody] GetMerchantBankNameModelInput ObjClass);

        public Task<MerchantTransactionGetRegistrationModelOutput> GetMerchantRegistrationParameters([FromBody] MerchantTransactionGetRegistrationProcessModelInput ObjClass);
        public Task<IEnumerable<MerchantRequestYearModeOutput>> MerchantRequestYear([FromBody] MerchantRequestYearModelInput ObjClass);
        public Task<IEnumerable<GetMerchantRequestMonthModelOutput>> GetMerchantRequestMonth([FromBody] GetMerchantRequestMonthModelInput ObjClass);
        public Task<IEnumerable<MerchantgetmonthModelOutput>> getmonth([FromBody] MerchantgetmonthModelInput ObjClass);
        public Task<IEnumerable<MerchantAccountStatementRequestModelOutput>> MerchantAccountStatementRequest([FromBody] MerchantAccountStatementRequestModelInput ObjClass);
        public Task<IEnumerable<MerchantReportTypeModelOutput>> MerchantReportType([FromBody] MerchantReportTypeModelInput ObjClass);
        public  Task<IEnumerable<MerchantGetMerchantMonthYearModelOutput>> GetMerchantMonthYear([FromBody] MerchantGetMerchantMonthYearModelInput ObjClass);
        public Task<IEnumerable<MerchantAccountStatementDetailsModelOutput>> MerchantAccountStatementDetails([FromBody] MerchantAccountStatementDetailsModelInput ObjClass);
        public Task<IEnumerable<GetMobileDispenserCustomerIDFromMerchantIDModelOutput>> GetMobileDispenserCustomerIDFromMerchantID([FromBody] GetMobileDispenserCustomerIDFromMerchantIDModelInput ObjClass);
        public Task<IEnumerable<MerchantGetTerminalStatusModelOutput>> GetTerminalStatus([FromBody] MerchantGetTerminalStatusModelInput ObjClass);
        public  Task<IEnumerable<MerchantViewTerminalMerchantMappingStatusModelOutput>> ViewTerminalMerchantMappingStatus([FromBody] MerchantViewTerminalMerchantMappingStatusModelInput ObjClass);
        public Task<IEnumerable<MerchantCloneInsertMerchantModelOutput>> CloneInsertMerchant([FromBody] MerchantCloneInsertMerchantModelInput ObjClass);
        public Task<IEnumerable<MerchantGeClonetMerchantApprovalModelOutput>> GeClonetMerchantApproval([FromBody] MerchantGeClonetMerchantApprovalModelInput ObjClass);
        public Task<IEnumerable<MerchantCloneApproveRejectMerchantModelOutput>> CloneApproveRejectMerchant([FromBody] MerchantCloneApproveRejectMerchantModelInput ObjClass);
        public Task<IEnumerable<MerchantGetMerchnatRegisterEmailModelOutput>> GetMerchnatRegisterEmail([FromBody] MerchantGetMerchnatRegisterEmailModelInput ObjClass);

        public Task<IEnumerable<MerchantGetUpdateRequestValueForCloneMerchantModelOutput>> GetUpdateRequestValueForCloneMerchant([FromBody] MerchantGetUpdateRequestValueForCloneMerchantModelInput ObjClass);

    }
}
