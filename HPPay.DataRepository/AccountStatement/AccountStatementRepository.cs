using Dapper;
using HPPay.DataModel.AccountStatment;
using HPPay.DataRepository.DBDapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.AccountStatment
{
    public  class AccountStatmentRepository : IAccountStatmentRepository
    {
        private readonly DapperContext _context; 
        public AccountStatmentRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<GetAccountStatmentRequestDetailsOutPut> GetAccountStatmentRequestDetails([FromBody] GetAccountStatmentRequestDetailsInput ObjClass)
        {
            var procedureName = "UspGetAccountStatmentRequestDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetAccountStatmentRequestDetailsOutPut();
            storedProcedureResult.GetAccountStatmentRequest = (List<GetAccountStatmentRequest>)await result.ReadAsync<GetAccountStatmentRequest>();
            storedProcedureResult.GetAccountStatmentRequestDetails = (List<GetAccountStatmentRequestDetails>)await result.ReadAsync<GetAccountStatmentRequestDetails>();
            return storedProcedureResult;
        }
        public async Task<IEnumerable<GetAccountStatmentTypeOutPut>> GetAccountStatmentType([FromBody] GetAccountStatmentTypeInput ObjClass)
        {
            var procedureName = "UspGetAccountStatmentType";
            var parameters = new DynamicParameters(); 
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAccountStatmentTypeOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<InsertAccountStatmentRequestModelOutPut>> InsertAccountStatmentRequest([FromBody] InsertAccountStatmentRequestModelInput ObjClass)
        {
            var procedureName = "UspInsertAccountStatmentRequest";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input); 
            parameters.Add("StatementType", ObjClass.StatementType, DbType.Int32, ParameterDirection.Input); 
            parameters.Add("CustomerSubType", ObjClass.CustomerSubType, DbType.Int32, ParameterDirection.Input); 
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertAccountStatmentRequestModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }             
        public async Task<IEnumerable<UpdateAccountStatmentRequestModelOutput>> UpdateAccountStatmentRequest([FromBody] UpdateAccountStatmentRequestModelInput ObjClass)
        {
            var procedureName = "UspUpdateAccountStatmentRequest";
            var parameters = new DynamicParameters();            
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input); 
            parameters.Add("IsActivate", ObjClass.IsActivate, DbType.Int32, ParameterDirection.Input);  
            parameters.Add("StatementType", ObjClass.StatementType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RequestId", ObjClass.RequestId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateAccountStatmentRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<DownloadAccountStatmentOutput>> DownloadAccountStatment([FromBody] DownloadAccountStatmentInput ObjClass)
        {
            //Need to create Procedure//
            var procedureName = "UspDownloadAccountStatment";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("StatementType", ObjClass.StatementType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubTypeId", ObjClass.CustomerSubTypeId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DownloadAccountStatmentOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
