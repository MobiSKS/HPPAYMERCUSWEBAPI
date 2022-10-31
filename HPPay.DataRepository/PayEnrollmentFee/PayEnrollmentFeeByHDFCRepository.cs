using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.PayEnrollmentFee;
using HPPay.DataRepository.DBDapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.PayEnrollmentFee
{
    public  class PayEnrollmentFeeByHDFCRepository : IPayEnrollmentFeeByHDFCRepository
    {
        private readonly DapperContext _context;
        public int BankNameId = 1;
        public string Status = "Initiated";
        public PayEnrollmentFeeByHDFCRepository(DapperContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<InsertFeeDetailsModelOutput>> InsertFeeDetailst([FromBody] InsertFeeDetailsModelInput ObjClass)
        public async Task<IEnumerable<InitiateEnrollmentFeeByHDFCModelOutPut>> InsertFeeDetailst([FromBody] InitiateEnrollmentFeeByHDFCModelInput ObjClass)
        {
            var procedureName = "UspInsertFeeDetails";
            var parameters = new DynamicParameters(); 
            parameters.Add("CardAmount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("FeeStatus", "0", DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNo, DbType.String, ParameterDirection.Input);
            parameters.Add("NoOfCards", ObjClass.NoOfCard, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CardIssueType", "New", DbType.String, ParameterDirection.Input);
            parameters.Add("SourceType", "HDFC PG", DbType.String, ParameterDirection.Input);
            parameters.Add("OrderId", ObjClass.OrderId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InitiateEnrollmentFeeByHDFCModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            
        }

        public async void InsertEnrolFeeHDFGApiRequest([FromBody] ApiRequestResponse ObjClass)
        {
            var procedureName = "UspInsertCPPGApiRequestResponse";
            var parameters = new DynamicParameters();
            parameters.Add("BankName", ObjClass.BankName, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionId", ObjClass.TransactionId, DbType.String, ParameterDirection.Input);
            parameters.Add("Request", ObjClass.request, DbType.String, ParameterDirection.Input);
            parameters.Add("Response", ObjClass.response, DbType.String, ParameterDirection.Input);
            parameters.Add("Apiurl", ObjClass.apiurl+ ObjClass.request_Hash, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("Amt", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("BankStatus", Status, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNo", ObjClass.ControlCardNo, DbType.String, ParameterDirection.Input); 
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("email", ObjClass.email, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobile", ObjClass.Mobile, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var res = await connection.QueryAsync<object>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetDetailsByFormNoModelOutput>> GetDetailsByFormNo([FromBody] GetDetailsByFormNoModelInput ObjClass)
        {
            var procedureName = "UspGetdetailsByFormNo";
            var parameters = new DynamicParameters();
            parameters.Add("FormNo", ObjClass.FormNo, DbType.String, ParameterDirection.Input); 
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDetailsByFormNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetEnrollmentFeeAmountOutPut>> GetEnrollmentFeeAmount([FromBody] GetEnrollmentFeeAmountInput ObjClass)
        {
            var procedureName = "UspCalculateFeeByNoOfCard";
            var parameters = new DynamicParameters();
            parameters.Add("NoOfCard", ObjClass.NoOfCard, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetEnrollmentFeeAmountOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
