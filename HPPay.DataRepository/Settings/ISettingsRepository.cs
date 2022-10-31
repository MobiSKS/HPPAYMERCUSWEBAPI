using HPPay.DataModel.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.Settings
{
    public interface ISettingsRepository
    {
        public Task<IEnumerable<SettingGetSalesareaModelOutput>> GetSalesarea([FromBody] SettingGetSalesareaModelInput ObjClass);
        public Task<IEnumerable<SettingGetTransactionTypeModelOutput>> GetTransactionType([FromBody] SettingGetTransactionTypeModelInput ObjClass);
        public Task<IEnumerable<SettingGetRoleModelOutput>> GetRole([FromBody] SettingGetRoleModelInput ObjClass);
        public Task<IEnumerable<SettingGetProductModelOutput>> GetProduct([FromBody] SettingGetProductModelInput ObjClass);
        public Task<IEnumerable<SettingGetEntityTypesModelOutput>> GetEntityStatusType([FromBody] SettingGetEntityTypesModelInput ObjClass);
        public Task<IEnumerable<SettingGetEntityModelOutput>> GetEntity([FromBody] SettingGetEntityModelInput ObjClass);
        public Task<IEnumerable<SettingGetProofTypeModelOutput>> GetProofType([FromBody] SettingGetProofTypeModelInput ObjClass);
        public Task<IEnumerable<SettingGetTierModelOutput>> GetTier([FromBody] SettingGetTierModelInput ObjClass);
        public Task<IEnumerable<SettingGetRecordTypeModelOutput>> GetRecordType([FromBody] SettingGetRecordTypeModelInput ObjClass);
        public Task<IEnumerable<SettingGetSalesareaModelOutput>> GetSalesAreaByMultipleRegion([FromBody] SettingGetSalesAreaByMultipleRegionModelInput ObjClass);
        public Task<IEnumerable<GetStatusTypesForTerminalModelOutput>> GetStatusTypesForTerminal([FromBody] GetStatusTypesForTerminalModelInput ObjClass);
        public Task<IEnumerable<GetCPStatuModelOutPut>> GetCreditPouchStatus([FromBody] GetCPStatuModelInput ObjClass);
        public Task<IEnumerable<SettingChangePasswordModelOutput>> ChangePassword([FromBody] SettingChangePasswordModelInput ObjClass);
        public  Task<IEnumerable<SettingForgetPasswordModelOutput>> ForgetPassword([FromBody] SettingForgetPasswordModelInput ObjClass);
        public  Task<IEnumerable<SettingUpdateMobileNoAndEmailIdModelOutput>> UpdateMobileNoAndEmailId([FromBody] SettingUpdateMobileNoAndEmailIdModelInput ObjClass);
        public Task<IEnumerable<LoyaltyRewardingStatementModelOutput>> GetLoyaltyRewardingStatement([FromBody] LoyaltyRewardingStatementModelInput ObjClass);
        public Task<IEnumerable<SettingGetProofTypesMasterModelOutput>> GetProofTypesMaster([FromBody] SettingGetProofTypesMasterModelInput ObjClass);
        public Task<IEnumerable<SettingGetEnrollmentTypeMasterModelOutput>> GetEnrollmentTypeMaster([FromBody] SettingGetEnrollmentTypeMasterModelInput ObjClass);
    }
}
