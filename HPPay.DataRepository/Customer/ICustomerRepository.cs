using HPPay.DataModel;
using HPPay.DataModel.Customer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HPPay.DataRepository.Customer
{
    public interface ICustomerRepository
    {
        public Task<IEnumerable<GetFormNumberModelOutput>> GetFormNumber([FromBody] GetFormNumberModelInput ObjClass);
        public Task<IEnumerable<CheckFormNumberModelOutput>> CheckFormNumber([FromBody] CheckFormNumberModelInput ObjClass);
        public Task<IEnumerable<CheckMobileNumberModelOutput>> CheckMobileNumber([FromBody] CheckMobileNumberModelInput ObjClass);
        public Task<IEnumerable<CheckEmailIdModelOutput>> CheckEmailId([FromBody] CheckEmailIdModelInput ObjClass);
        public Task<IEnumerable<GetCustomerTypeModelOutput>> GetCustomerType([FromBody] GetCustomerTypeModelInput ObjClass);
        public Task<IEnumerable<GetCustomerSubTypeModelOutput>> GetCustomerSubType([FromBody] GetCustomerSubTypeModelInput ObjClass);
        public Task<IEnumerable<GetCustomerTBEntityNameModelOutput>> GetTBEntityName([FromBody] GetCustomerTBEntityNameModelInput ObjClass);
        public Task<IEnumerable<GetCustomerSecretQuestionModelOutput>> GetSecretQuestion([FromBody] GetCustomerSecretQuestionModelInput ObjClass);
        public Task<IEnumerable<GetCustomerTypeOfFleetModelOutput>> GetTypeOfFleet([FromBody] GetCustomerTypeOfFleetModelInput ObjClass);
        public Task<IEnumerable<CustomerInsertModelOutput>> InsertCustomer([FromBody] CustomerInsertModelInput ObjClass);
        public Task<IEnumerable<CustomerUpdateModelOutput>> UpdateCustomer([FromBody] CustomerUpdateModelInput ObjClass);
        public Task<IEnumerable<CustomerViewOnlineFormStatusModelOutput>> ViewOnlineFormStatus([FromBody] CustomerViewOnlineFormStatusModelInput ObjClass);
        public Task<IEnumerable<CustomerKYCModelOutput>> UploadCustomerKYC([FromForm] CustomerKYCModelInput ObjClass);
        public Task<IEnumerable<CustomerApprovalModelOutput>> ApproveRejectCustomer([FromBody] CustomerApprovalModelInput ObjClass);

        public Task<IEnumerable<CustomerGetVehicleTypeModelOutput>> GetVehicleType([FromBody] CustomerGetVehicleTypeModelInput ObjClass);
        public Task<IEnumerable<CustomerFeewaiverApprovalModelOutput>> ApproveRejectFeewaiver([FromBody] CustomerFeewaiverApprovalModelInput ObjClass);

        public Task<GetApproveFeeWaiverDetailModelOutput> GetApproveFeeWaiverDetail([FromBody] GetApproveFeeWaiverDetailModelInput ObjClass);
        public Task<IEnumerable<CustomerGetCustomerReferenceNoModelOutput>> GetNameandFormNumberbyReferenceNo([FromBody] CustomerGetCustomerReferenceNoModelInput ObjClass);

        public Task<CustomerDetailsModelOutput> GetCustomerByCustomerId([FromBody] CustomerGetByCustomerIdModelInput ObjClass);
        public Task<CustomerDetailsModelOutput> GetCustomerDetails([FromBody] CustomerDetailsModelInput ObjClass);
        public Task<CustomerDetailsModelOutput> GetRawCustomerDetails([FromBody] CustomerDetailsModelInput ObjClass);

        public Task<IEnumerable<BindPendingCustomerModelOutput>> BindPendingCustomer([FromBody] BindPendingCustomerModelInput ObjClass);

        public Task<IEnumerable<BindPendingCustomerModelOutput>> BindUnverfiedCustomer([FromBody] BindPendingCustomerModelInput ObjClass);

        public Task<CustomerDetailsModelOutput> GetPendingCustomerDetailbyFormNumber([FromBody] CustomerDetailsbyFormNumberModelInput ObjClass);
        public Task<CustomerDetailsModelOutput> GetUnverfiedCustomerDetailbyFormNumber([FromBody] CustomerDetailsbyFormNumberModelInput ObjClass);

        public Task<IEnumerable<GetControlCardNumberModelOutput>> GetControlCardNumber([FromBody] GetControlCardNumberModelInput ObjClass);

        public Task<IEnumerable<CustomerCheckPancardModelOutput>> CheckPancard([FromBody] CustomerCheckPancardModelInput ObjClass);


        public Task<IEnumerable<CustomerGetMerchantForCardMappingModelOutput>> GetMerchantForCardMapping([FromBody] CustomerGetMerchantForCardMappingModelInput ObjClass);

        public Task<IEnumerable<CustomerGetCardListFromCustomerIdModelOutput>> GetCardListFromCustomerId([FromBody] CustomerGetCardListFromCustomerIdModelInput ObjClass);

        public Task<CustomerGetCustomerDetailsForMappingCardMerchantModelOutput> GetCustomerDetailsForMappingCardMerchant([FromBody] CustomerGetCustomerDetailsForMappingCardMerchantModelInput ObjClass);


        public Task<IEnumerable<CustomerAddCustomerCardMerchantMappingModelOutput>> AddCustomerCardMerchantMapping([FromBody] CustomerAddCustomerCardMerchantMappingModelInput ObjClass);


        public Task<IEnumerable<CustomerGetMappingUserCardstoMerchantsModelOutput>> GetMappingUserCardstoMerchants([FromBody] CustomerGetMappingUserCardstoMerchantsModelInput ObjClass);

        public Task<IEnumerable<CustomerGetCustomerNameModelOutput>> GetCustomerNameByCustomerId([FromBody] CustomerGetByCustomerIdModelInput ObjClass);

        public Task<IEnumerable<CustomerGetCustomerDetailsForSearchModelOutput>> GetCustomerDetailsForSearch([FromBody] CustomerGetByCustomerIdModelInput ObjClass);

        public Task<IEnumerable<CustomerGetCustomerBalanceInfoModelOutput>> GetCustomerBalanceInfo([FromBody] CustomerGetCustomerBalanceInfoModelInput ObjClass);

        public Task<IEnumerable<CustomerGetCustomerCardWiseBalancesModelOutput>> GetCustomerCardWiseBalances([FromBody] CustomerGetCustomerCardWiseBalancesModelInput ObjClass);

        public  Task<IEnumerable<CustomerGetCcmsBalanceInfoForCustomerIdModelOutput>> GetCcmsBalanceInfoForCustomerId([FromBody] CustomerGetCcmsBalanceInfoForCustomerIdModelInput ObjClass);

        public Task<CustomerGetTransactionsSummaryModelOutput> GetTransactionsSummary([FromBody] CustomerGetTransactionsSummaryModelInput ObjClass);

        public Task<IEnumerable<CustomerCheckPancardbyDistrictIdModelOutput>> CheckPancardbyDistrictId([FromBody] CustomerCheckPancardbyDistrictIdModelInput ObjClass);

        public Task<IEnumerable<CheckPancardbyDistrictIdAndCustomerReferenceNoModelOutput>> CheckPancardbyDistrictIdAndCustomerReferenceNo([FromBody] CheckPancardbyDistrictIdAndCustomerReferenceNoModelInput ObjClass);

        public Task<CustomerViewAccountStatementModelOutput> ViewAccountStatementSummary([FromBody] CustomerViewAccountStatementModelInput ObjClass);


        public Task<SearchCustomerandCardFormModelOutput> SearchCustomerandCardForm([FromBody] SearchCustomerandCardFormModelInput ObjClass);

        public Task<IEnumerable<GetNameandFormNumberbyCustomerIdModelOutput>> GetNameandFormNumberbyCustomerId([FromBody] GetNameandFormNumberbyCustomerIdModelInput ObjClass);

        public Task<IEnumerable<CustomerGetCustomerReferenceNoModelOutput>> GetNameandFormNumberbyReferenceNoforAddCard([FromBody] CustomerGetCustomerReferenceNoModelInput ObjClass);
        public Task<IEnumerable<CustomerAddOnUserModelOutput>> CustomerAddOnUser([FromBody] CustomerAddOnUserModelInput ObjClass);

        public Task<IEnumerable<ConfigureSMSAlertsModelOutput>> ConfigureSMSAlerts([FromBody] ConfigureSMSAlertsModelInput ObjClass);

        public Task<IEnumerable<GetUpdateContactPersonDetailsModelOutput>> GetUpdateContactPersonDetails(GetUpdateContactPersonDetailsModelInput objClass);


        public Task<IEnumerable<UpdateRequestContactPersonDetailsModelOutput>> UpdateRequestContactPersonDetails([FromBody] UpdateRequestContactPersonDetailsModelInput ObjClass);

        public Task<CCMSBalAlertConfigurationOutput> GetCCMSBalAlertConfiguration([FromBody] GetCCMSBalAlertConfigurationInput ObjClass);

        public Task<IEnumerable<UpdateCCMSBalAlertConfigurationModelOutput>> UpdateCCMSBalAlertConfiguration(UpdateCCMSBalAlertConfigurationModelInput ObjClass);

        public Task<IEnumerable<RequestApproveCustomerContactPersonDetailsModelOutput>> RequestApproveCustomerContactPersonDetails([FromBody] RequestApproveCustomerContactPersonDetailsModelInput ObjClass);

        public Task<RequestGetApproveCustomerContactPersonDetailsModelOutput> RequestGetApproveCustomerContactPersonDetails([FromBody] RequestGetApproveCustomerContactPersonDetailsModelInput ObjClass);


        public Task<IEnumerable<ApproveCustomerContactPersonDetailsModelOutput>> ApproveCustomerContactPersonDetails([FromBody] ApproveCustomerContactPersonDetailsModelInput ObjClass);

        public Task<IEnumerable<ApproveCustomerAddressRequestsModelOutput>> ApproveCustomerAddressRequests([FromBody] ApproveCustomerAddressRequestsModelInput ObjClass);

        public Task<GetApproveCustomerAddressRequestsModelOutput> GetApproveCustomerAddressRequests([FromBody] GetApproveCustomerAddressRequestsModelInput ObjClass);

        public Task<IEnumerable<UpdateRequestCustomerAddressModelOutput>> UpdateRequestCustomerAddress([FromBody] UpdateRequestCustomerAddressModelInput ObjClass);

        public Task<IEnumerable<ApprovalApproveCustomerAddressRequestsModelOutput>> ApprovalApproveCustomerAddressRequests([FromBody] ApprovalApproveCustomerAddressRequestsModelInput ObjClass);

        public Task<IEnumerable<BindPendingCustomerModelOutput>> BindUnverfiedCustomerForFeeWaiver([FromBody] BindPendingCustomerModelInput ObjClass);

        public Task<IEnumerable<GetCommunicationEmailResetPasswordModelOutput>> GetCommunicationEmailResetPassword(GetCommunicationEmailResetPasswordModelInput objClass);

        public Task<IEnumerable<UpdateCommunicationEmailResetPasswordModelOutput>> UpdateCommunicationEmailResetPassword(UpdateCommunicationEmailResetPasswordModelInput objClass);

        public Task<IEnumerable<CCNPinResetModelOutput>> CCNPinReset(CCNPinResetModelInput objClass);

        public  Task<IEnumerable<GetCustomerStatusModelOutput>> GetCustomerStatus([FromBody] GetCustomerStatusModelInput ObjClass);
        public Task<IEnumerable<CustomerPostAuthorizationForCreditPouchModelOutput>> PostAuthorizationForCreditPouch([FromBody] CustomerPostAuthorizationForCreditPouchModelInput ObjClass);

        public Task<IEnumerable<CustomerPostAuthForCreditPouchParentCustomerModelOutput>> PostAuthForCreditPouchParentCustomer([FromBody] CustomerPostAuthForCreditPouchParentCustomerModelInput ObjClass);
        public Task<IEnumerable<CustomerGetTransactionsDetailsModelOutput>> GetTransactionsDetails([FromBody] CustomerGetTransactionsDetailsModelInput ObjClass);
        public Task<IEnumerable<CheckNormalCustomerModelOutput>> CheckNormalCustomer([FromBody] CheckNormalCustomerModelInput ObjClass);
        public  Task<IEnumerable<CheckEGVCustomerModelOutput>> CheckEGVCustomer([FromBody] CheckEGVCustomerModelInput ObjClass);
        public  Task<IEnumerable<CustomerBalanceInfoDrivestarsModelOutput>> CustomerBalanceInfoDrivestars([FromBody] CustomerBalanceInfoDrivestarsModelInput ObjClass);
       
        public  Task<IEnumerable<CustomerFeedbackModelOutput>> CustomerFeedback([FromBody] CustomerFeedbackModelInput ObjClass);
       
        public  Task<IEnumerable<UpdateCustomerFeedbackModelOutput>> UpdateCustomerFeedback([FromBody] UpdateCustomerFeedbackModelInput ObjClass);
        public  Task<IEnumerable<VehicleTrackingModelOutput>> VehicleTracking([FromBody] VehicleTrackingModelInput ObjClass);
        public Task<IEnumerable<GetFeedbackQuestionsModelOutput>> GetFeedbackQuestions([FromBody] GetFeedbackQuestionsModelInput ObjClass);
        public  Task<IEnumerable<FeedbackSubmittedAnswersModelOutput>> FeedbackSubmittedAnswers([FromBody] FeedbackSubmittedAnswersModelInput ObjClass);
        public  Task<IEnumerable<GenerateMasterPinModelOutput>> GenerateMasterPin(GenerateMasterPinModelInput objClass);

        public Task<IEnumerable<SetCustomerCardDispatchOutputModel>> SetCustomerCardDispatchAddress([FromBody] SetCustomerCardDispatchInputModel ObjClass);

        public Task<IEnumerable<CustomerCardDispatchAddresDetailsSaveOutputModel>> CustomerCardDispatchAddressDetailsSave([FromBody] CustomerCardDispatchAddresDetailsSaveInputModel ObjClass);

        public Task<IEnumerable<TrackApplicationFormModelOutput>> TrackApplicationForm([FromBody] TrackApplicationFormModelInput ObjClass);


        public Task<IEnumerable<GetFinancialsTransactionDetailsOutPutModel>> GetFinancialsTransactionDetails([FromBody] GetFinancialsTransactionDetailsInputModel ObjClass);

        public Task<IEnumerable<GetCustomerNameAndROByCustomerIdModelOutput>> GetCustomerNameAndROByCustomerId([FromBody] GetCustomerNameAndROByCustomerIdModelInput ObjClass);
        public Task<IEnumerable<ForgetPasswordByControlCardNoModelOutput>> ForgetPasswordByControlCardNo([FromBody] ForgetPasswordByControlCardNoModelInput ObjClass);

        public Task<IEnumerable<NewEnrollCustomerOTPSentModelOutput>> NewEnrollCustomerOTPSent([FromBody] NewEnrollCustomerOTPSentModelInput ObjClass);

        public Task<IEnumerable<NewEnrollCustomerOTPVerifiedModelOutput>> NewEnrollCustomerOTPVerified([FromBody] NewEnrollCustomerOTPVerifiedModelInput ObjClass);


        public Task<IEnumerable<BindRejectedCustomerModelOutput>> UspBindRejectedCustomer([FromBody] BindRejectedCustomerModelInput ObjClass);

        public Task<IEnumerable<UpdateRawCustomerSendbackModelOutput>> UpdateRawCustomerSendback([FromBody] UpdateRawCustomerSendbackModelInput ObjClass);

        public Task<IEnumerable<NewEnrollCustomerOTPSentByCustomeridModelOutput>> NewEnrollCustomerOTPSentByCustomerid([FromBody] NewEnrollCustomerOTPSentByCustomeridModelInput ObjClass);
        public  Task<IEnumerable<NewEnrollCustomerOTPVerifiedByCustomeridModelOutput>> NewEnrollCustomerOTPVerifiedByCustomerid([FromBody] NewEnrollCustomerOTPVerifiedByCustomeridModelInput ObjClass);


    }

}
