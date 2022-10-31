using Dapper;
using HPPay.DataModel.Settings;
using HPPay.DataRepository.DBDapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.Settings
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly DapperContext _context;
        public SettingsRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SettingGetSalesareaModelOutput>> GetSalesarea([FromBody] SettingGetSalesareaModelInput ObjClass)
        {
            var procedureName = "UspGetSalesarea";
            var parameters = new DynamicParameters();
            parameters.Add("RegionID", ObjClass.RegionID, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<SettingGetSalesareaModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<SettingGetTransactionTypeModelOutput>> GetTransactionType([FromBody] SettingGetTransactionTypeModelInput ObjClass)
        {
            var procedureName = "UspGetTransactionType";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<SettingGetTransactionTypeModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<SettingGetRoleModelOutput>> GetRole([FromBody] SettingGetRoleModelInput ObjClass)
        {
            var procedureName = "UspGetRole";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<SettingGetRoleModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<SettingGetProductModelOutput>> GetProduct([FromBody] SettingGetProductModelInput ObjClass)
        {
            var procedureName = "UspGetProduct";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<SettingGetProductModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<SettingGetEntityModelOutput>> GetEntity([FromBody] SettingGetEntityModelInput ObjClass)
        {
            var procedureName = "UspGetEntity";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<SettingGetEntityModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<SettingGetEntityTypesModelOutput>> GetEntityStatusType([FromBody] SettingGetEntityTypesModelInput ObjClass)
        {
            var procedureName = "UspGetEntityTypes";
            var parameters = new DynamicParameters();
            parameters.Add("EntityTypeId", ObjClass.EntityTypeId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<SettingGetEntityTypesModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<SettingGetProofTypeModelOutput>> GetProofType([FromBody] SettingGetProofTypeModelInput ObjClass)
        {
            var procedureName = "UspGetProofTypes";
            var parameters = new DynamicParameters();
            parameters.Add("ProofIdType", ObjClass.ProofIdType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("EnrollmentType", ObjClass.EnrollmentType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<SettingGetProofTypeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<SettingGetProofTypesMasterModelOutput>> GetProofTypesMaster([FromBody] SettingGetProofTypesMasterModelInput ObjClass)
        {
            var procedureName = "UspGetProofTypesMaster";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<SettingGetProofTypesMasterModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<SettingGetEnrollmentTypeMasterModelOutput>> GetEnrollmentTypeMaster([FromBody] SettingGetEnrollmentTypeMasterModelInput ObjClass)
        {
            var procedureName = "UspGetEnrollmentTypeMaster";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<SettingGetEnrollmentTypeMasterModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<SettingGetTierModelOutput>> GetTier([FromBody] SettingGetTierModelInput ObjClass)
        {
            var procedureName = "UspGetTier";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<SettingGetTierModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<SettingGetRecordTypeModelOutput>> GetRecordType([FromBody] SettingGetRecordTypeModelInput ObjClass)
        {
            var procedureName = "UspGetRecordType";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<SettingGetRecordTypeModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<SettingGetSalesareaModelOutput>> GetSalesAreaByMultipleRegion([FromBody] SettingGetSalesAreaByMultipleRegionModelInput ObjClass)
        {
            var procedureName = "UspGetSalesAreaByMultipleRegion";
            var parameters = new DynamicParameters();
            parameters.Add("RegionID", ObjClass.RegionID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<SettingGetSalesareaModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetStatusTypesForTerminalModelOutput>> GetStatusTypesForTerminal([FromBody] GetStatusTypesForTerminalModelInput ObjClass)
        {
            var procedureName = "UspGetStatusTypesForTerminal";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetStatusTypesForTerminalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCPStatuModelOutPut>> GetCreditPouchStatus([FromBody] GetCPStatuModelInput ObjClass)
        {
            var procedureName = "USPGetCPStatus";
            var parameters = new DynamicParameters();
            parameters.Add("PageName", ObjClass.PageName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCPStatuModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<SettingChangePasswordModelOutput>> ChangePassword([FromBody] SettingChangePasswordModelInput ObjClass)
        {
            var procedureName = "UspChangePassword";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("OldPassword", ObjClass.OldPassword, DbType.String, ParameterDirection.Input);
            parameters.Add("NewPassword", ObjClass.NewPassword, DbType.String, ParameterDirection.Input);
            parameters.Add("ConfirmNewPassword", ObjClass.NewPassword, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<SettingChangePasswordModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<SettingForgetPasswordModelOutput>> ForgetPassword([FromBody] SettingForgetPasswordModelInput ObjClass)
        {
            var procedureName = "UspForgetPassword";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("EmailId", ObjClass.EmailId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<SettingForgetPasswordModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<SettingUpdateMobileNoAndEmailIdModelOutput>> UpdateMobileNoAndEmailId([FromBody] SettingUpdateMobileNoAndEmailIdModelInput ObjClass)
        {
            var procedureName = "UspUpdateMobileNoAndEmailId";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("EmailId", ObjClass.EmailId, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<SettingUpdateMobileNoAndEmailIdModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<IEnumerable<LoyaltyRewardingStatementModelOutput>> GetLoyaltyRewardingStatement([FromBody] LoyaltyRewardingStatementModelInput ObjClass)
        {
            var procedureName = "UspLoyaltyRewardingStatement";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("OfficerType", ObjClass.OfficerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.DateTime, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<LoyaltyRewardingStatementModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
