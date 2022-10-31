using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.DTP;
using HPPay.DataRepository.DBDapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.DTP
{
    public class DTPRepository : IDTPRepository
    {
        private readonly DapperContext _context;

        public DTPRepository(DapperContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<GetBlockUnBlockCustomerCCMSAccountByCustomerIdModelOutput>> GetBlockUnBlockCustomerCCMSAccountByCustomerId([FromBody] GetBlockUnBlockCustomerCCMSAccountByCustomerIdModelInput ObjClass)
        {
            var procedureName = "UspGetBlockUnBlockCustomerCCMSAccountByCustomerId";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetBlockUnBlockCustomerCCMSAccountByCustomerIdModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<BlockUnBlockCustomerCCMSAccountOutput>> BlockUnBlockCustomerCCMSAccount([FromBody] BlockUnBlockCustomerCCMSAccountInput ObjClass)
        {
            var procedureName = "UspBlockUnBlockCustomerCCMSAccount";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CCMSBalanceStatus", ObjClass.CCMSBalanceStatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CCMSBalanceRemarks", ObjClass.CCMSBalanceRemarks, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BlockUnBlockCustomerCCMSAccountOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        //

        public async Task<IEnumerable<CardBalanceTransferModelOutput>> CardBalanceTransfer([FromBody] CardBalanceTransferModelInput ObjClass)
        {
            var procedureName = "UspCardBalanceTransfer";
            var parameters = new DynamicParameters();
            parameters.Add("CardStatus", ObjClass.CardStatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CardBalanceTransferModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InsertTeamMappingModelOutput>> InsertTeamMapping([FromBody] InsertTeamMappingModelInput ObjClass)
        {
            var procedureName = "UspTeamMapping";
            var parameters = new DynamicParameters();
            parameters.Add("ZBMID", ObjClass.ZBMID, DbType.String, ParameterDirection.Input);
            parameters.Add("ZBMName", ObjClass.ZBMName, DbType.String, ParameterDirection.Input);
            parameters.Add("RSMID", ObjClass.RSMID, DbType.String, ParameterDirection.Input);
            parameters.Add("RSMName", ObjClass.RSMName, DbType.String, ParameterDirection.Input);
            parameters.Add("RBEID", ObjClass.RBEID, DbType.String, ParameterDirection.Input);
            parameters.Add("RBEName", ObjClass.RBEName, DbType.String, ParameterDirection.Input);
            parameters.Add("Location", ObjClass.Location, DbType.String, ParameterDirection.Input);          
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertTeamMappingModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetTeamMappingModelOutput>> GetTeamMapping([FromBody] GetTeamMappingModelInput ObjClass)
        {
            var procedureName = "UspGetTeamMapping";
            var parameters = new DynamicParameters();
            parameters.Add("ZBMID", ObjClass.ZBMID, DbType.String, ParameterDirection.Input);
            parameters.Add("ZBMName", ObjClass.ZBMName, DbType.String, ParameterDirection.Input);
            parameters.Add("RSMID", ObjClass.RSMID, DbType.String, ParameterDirection.Input);
            parameters.Add("RSMName", ObjClass.RSMName, DbType.String, ParameterDirection.Input);
            parameters.Add("RBEID", ObjClass.RBEID, DbType.String, ParameterDirection.Input);
            parameters.Add("RBEName", ObjClass.RBEName, DbType.String, ParameterDirection.Input);
            parameters.Add("Location", ObjClass.Location, DbType.String, ParameterDirection.Input);           
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetTeamMappingModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateTeamMappingModelOutput>> UpdateTeamMapping([FromBody] UpdateTeamMappingModelInput ObjClass)
        {
            var procedureName = "UspUpdateTeamMapping";

            var parameters = new DynamicParameters();
            parameters.Add("TeamMappingId", ObjClass.TeamMappingId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ZBMID", ObjClass.ZBMID, DbType.String, ParameterDirection.Input);
            parameters.Add("ZBMName", ObjClass.ZBMName, DbType.String, ParameterDirection.Input);
            parameters.Add("RSMID", ObjClass.RSMID, DbType.String, ParameterDirection.Input);
            parameters.Add("RSMName", ObjClass.RSMName, DbType.String, ParameterDirection.Input);
            parameters.Add("RBEID", ObjClass.RBEID, DbType.String, ParameterDirection.Input);
            parameters.Add("RBEName", ObjClass.RBEName, DbType.String, ParameterDirection.Input);
            parameters.Add("Location", ObjClass.Location, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateTeamMappingModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<DeleteTeamMappingModelOutput>> DeleteTeamMapping([FromBody] DeleteTeamMappingModelInput ObjClass)
        {
            var procedureName = "UspInactiveTeamMapping";
            var parameters = new DynamicParameters();
            parameters.Add("TeamMappingId", ObjClass.TeamMappingId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DeleteTeamMappingModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetEntityForGeneralUpdatesModelOutput>> GetEntityGeneralUpdates([FromBody] GetEntityForGeneralUpdatesModelInput ObjClass)
        {
            var procedureName = "UspGetEntityForGeneralUpdates";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetEntityForGeneralUpdatesModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetEntityFieldByEntityTypeIdModelOutput>> GetEntityFieldByEntityTypeId([FromBody] GetEntityFieldByEntityTypeIdModelInput ObjClass)
        {
            var procedureName = "GetEntityFieldByEntityTypeId";
            var parameters = new DynamicParameters();
            parameters.Add("EntityTypeId", ObjClass.EntityTypeId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetEntityFieldByEntityTypeIdModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateGeneralEntityFieldModelOutput>> UpdateGeneralEntityField([FromBody] UpdateGeneralEntityFieldModelInput ObjClass)
        {
            var procedureName = "UspUpdateGeneralEntityField";
            var parameters = new DynamicParameters();
            parameters.Add("EntityTypeId", ObjClass.EntityTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("EntityFieldId", ObjClass.EntityFieldId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerIdOrCardOrMerchantId", ObjClass.CustomerIdOrCardOrMerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("NewValue", ObjClass.NewValue, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateGeneralEntityFieldModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetEntityOldFieldValueModelOutput>> GetEntityOldFieldValue([FromBody] GetEntityOldFieldValueModelInput ObjClass)
        {
            var procedureName = "UspGetEntityOldFieldValue";
            var parameters = new DynamicParameters();
            parameters.Add("EntityTypeId", ObjClass.EntityTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("EntityFieldId", ObjClass.EntityFieldId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerIdOrCardOrMerchantId", ObjClass.CustomerIdOrCardOrMerchantId, DbType.String, ParameterDirection.Input);
            
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetEntityOldFieldValueModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetDetailForUserUnblockByCustomerIdOrUserNameModelOutput>> GetDetailForUserUnblockByCustomerIdOrUserName([FromBody] GetDetailForUserUnblockByCustomerIdOrUserNameModelInput ObjClass)
        {
            var procedureName = "UspGetDetailForUserUnblockByCustomerIdOrUserName";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDetailForUserUnblockByCustomerIdOrUserNameModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<UserUnBlockModelOutput>> UserUnBlock([FromBody] UserUnBlockModelInput ObjClass)
        {
            var procedureName = "UspUserUnBlock";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("BlockUnblockStatus", ObjClass.BlockUnblockStatus, DbType.Int32, ParameterDirection.Input);            
            parameters.Add("Remark", ObjClass.Remark, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UserUnBlockModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<RegenerateIACModelOutput>> RegenerateIAC([FromBody] RegenerateIACModelInput ObjClass)
        {
            var procedureName = "UspRegenerateIAC";
            var parameters = new DynamicParameters();
            parameters.Add("TerminalID", ObjClass.TerminalID, DbType.String, ParameterDirection.Input);
            
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<RegenerateIACModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetEnableDealerCreditSaleDetailsModelOutput> GetEnableDealerCreditSaleDetails([FromBody] GetEnableDealerCreditSaleDetailsModelInput ObjClass)
        {
            var procedureName = "USPGetEnableDealerCreditSaleDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetEnableDealerCreditSaleDetailsModelOutput();
            storedProcedureResult.CustomerDetail = (List<GetCustomerDetail>)await result.ReadAsync<GetCustomerDetail>();

            storedProcedureResult.MerchantDetail = (List<GetMerchantDetail>)await result.ReadAsync<GetMerchantDetail>();

            
            return storedProcedureResult;
        }

        public async Task<IEnumerable<AllocateEnableDealerCreditSaleModelOutput>> AllocateEnableDealerCreditSale([FromBody] AllocateEnableDealerCreditSaleModelInput ObjClass)
        {
            var procedureName = "USPUpdateEnableDealerCreditSale";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AllocateEnableDealerCreditSaleModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
