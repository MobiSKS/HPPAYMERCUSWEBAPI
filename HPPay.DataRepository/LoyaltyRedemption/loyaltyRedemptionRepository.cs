using Dapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using HPPay.DataModel;
using HPPay.DataModel.LoyaltyRedemption;
using HPPay.DataRepository.LoyaltyRedemption;
using HPPay.DataRepository.DBDapper;

namespace HPPay.DataRepository.LoyaltyRedemption
{
    public class LoyaltyRedemptionRepository : ILoyaltyRedemptionRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        //private readonly Variables ObjVariable;
        public LoyaltyRedemptionRepository(DapperContext context, IHostingEnvironment hostingEnvironment) // , IConfiguration configuration
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            //ObjVariable = new Variables(configuration);
        }

        public async Task<IEnumerable<GetLoyaltyRedemptionModelOutput>> GetLoyaltyRedemption([FromBody] GetLoyaltyRedemptionModelInput ObjClass)
        {
            var procedureName = "UspGetLoyaltyRedemption";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("Customertype", ObjClass.Customertype, DbType.String, ParameterDirection.Input);
            parameters.Add("UserType", ObjClass.Customertype, DbType.String, ParameterDirection.Input);
            parameters.Add("Type", ObjClass.Customertype, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetLoyaltyRedemptionModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetUpdateLoyaltyRedemptionModelOutput>> GetUpdateLoyaltyRedemption([FromBody] GetUpdateLoyaltyRedemptionModelInput ObjClass)
        {
            var procedureName = "UspGetUpdateLoyaltyRedemption";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("Points", ObjClass.Points, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetUpdateLoyaltyRedemptionModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<InsertLoyaltyRedemptionModelOutput>> InsertLoyaltyRedemption([FromBody] InsertLoyaltyRedemptionModelInput ObjClass)
        {
            var procedureName = "UspInsertLoyaltyRedemption";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("Points", ObjClass.Points, DbType.String, ParameterDirection.Input);
            //  parameters.Add("Amount", ObjClass.Amount, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertLoyaltyRedemptionModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetTransactionSourceIDModelOutput>> GetTransactionSourceID([FromBody] GetTransactionSourceIDModelInput ObjClass)
        {
            var procedureName = "UspGetTransactionSourceID";
            var parameters = new DynamicParameters();
            parameters.Add("EntityTypeId", ObjClass.EntityTypeId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetTransactionSourceIDModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetAuthorizationLevelIDModelOutput>> GetAuthorizationLevelID([FromBody] GetAuthorizationLevelIDModelInput ObjClass)
        {
            var procedureName = "UspGetAuthorizationLevelID";
            var parameters = new DynamicParameters();
            parameters.Add("EntityTypeId", ObjClass.EntityTypeId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAuthorizationLevelIDModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetRedemptionRequestRuleModelOutput>> GetRedemptionRequestRule([FromBody] GetRedemptionRequestRuleModelInput ObjClass)
        {
            var procedureName = "UspGetRedemptionRequestRule";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetRedemptionRequestRuleModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<InsertRedemptionRequestRuleModelOutput>> InsertRedemptionRequestRule([FromBody] InsertRedemptionRequestRuleModelInput ObjClass)
        {
            var procedureName = "UspInsertRedemptionRequestRule";
            var parameters = new DynamicParameters();
            parameters.Add("MinimumAmount", ObjClass.MinimumAmount, DbType.String, ParameterDirection.Input);
            parameters.Add("MaximumAmount", ObjClass.MaximumAmount, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionSourceId ", ObjClass.TransactionSourceId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("AuthorizationLevelId", ObjClass.AuthorizationLevelId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerType", ObjClass.CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertRedemptionRequestRuleModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<UpdateRedemptionRequestRuleModelOutput>> UpdateRedemptionRequestRule([FromBody] UpdateRedemptionRequestRuleModelInput ObjClass)
        {
            var procedureName = "UspUpdateRedemptionRequestRule";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerType", ObjClass.CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("MinimumAmount", ObjClass.MinimumAmount, DbType.String, ParameterDirection.Input);
            parameters.Add("MaximumAmount", ObjClass.MaximumAmount, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionSourceId ", ObjClass.TransactionSourceId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("AuthorizationLevelId", ObjClass.AuthorizationLevelId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("RuleId", ObjClass.RuleId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateRedemptionRequestRuleModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<DeleteRedemptionRequestRuleModelOutput>> DeleteRedemptionRequestRule([FromBody] DeleteRedemptionRequestRuleModelInput ObjClass)
        {
            var procedureName = "UspDeleteRedemptionRequestRule";
            var parameters = new DynamicParameters();
            parameters.Add("RuleId", ObjClass.RuleId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DeleteRedemptionRequestRuleModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<ApprovalAuthorizeFuelLoyaltyRedemptionModelOutput>> ApprovalAuthorizeFuelLoyaltyRedemption([FromBody] ApprovalAuthorizeFuelLoyaltyRedemptionModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeApprovalAuthorizeFuelLoyaltyRedemption");
            
            dtDBR.Columns.Add("RequestNumber", typeof(string));
            dtDBR.Columns.Add("CustomerID", typeof(string));
            //dtDBR.Columns.Add("Comments", typeof(string));
            dtDBR.Columns.Add("PointsToRedeem", typeof(string));
            dtDBR.Columns.Add("BalancedPoints", typeof(string));
            dtDBR.Columns.Add("Amount", typeof(string));


            var procedureName = "UspApprovalAuthorizeFuelLoyaltyRedemption";
            var parameters = new DynamicParameters();


            foreach (GetTypeApprovalAuthorizeFuelLoyaltyRedemption ObjComco in ObjClass.TypeApprovalAuthorizeFuelLoyaltyRedemption)
            {
                DataRow dr = dtDBR.NewRow();
                dr["RequestNumber"] = ObjComco.RequestNumber;
                dr["CustomerID"] = ObjComco.CustomerID;
               // dr["Comments"] = ObjComco.Comments;
                dr["PointsToRedeem"] = ObjComco.PointsToRedeem;
                dr["BalancedPoints"] = ObjComco.BalancedPoints;
                dr["Amount"] = ObjComco.Amount;
                    

                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }

          
            parameters.Add("Comments", ObjClass.Comments, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            //parame    ters.Add("Comments", ObjClass.Comments, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeApprovalAuthorizeFuelLoyaltyRedemption", dtDBR, DbType.Object, ParameterDirection.Input);

            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);

            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ApprovalAuthorizeFuelLoyaltyRedemptionModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<FuelLoyaltyRedemptionAuthorizeModelOutput>> FuelLoyaltyRedemptionAuthorize([FromBody] FuelLoyaltyRedemptionAuthorizeModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeAuthorizeFuelLoyaltyRedemption");
            dtDBR.Columns.Add("RequestNumber", typeof(string));
            dtDBR.Columns.Add("CustomerID", typeof(string));
            //dtDBR.Columns.Add("Comments", typeof(string));
            dtDBR.Columns.Add("PointsToRedeem", typeof(string));
            dtDBR.Columns.Add("BalancedPoints", typeof(string));
            dtDBR.Columns.Add("Amount", typeof(string));


            var procedureName = "UspFuelLoyaltyRedemptionAuthorize";
            var parameters = new DynamicParameters();


            foreach (GetTypeAuthorizeFuelLoyaltyRedemption ObjComco in ObjClass.TypeAuthorizeFuelLoyaltyRedemption)
            {
                DataRow dr = dtDBR.NewRow();

                dr["RequestNumber"] = ObjComco.RequestNumber;
                dr["CustomerID"] = ObjComco.CustomerID;
                //dr["Comments"] = ObjComco.Comments;
                dr["PointsToRedeem"] = ObjComco.PointsToRedeem;
                dr["BalancedPoints"] = ObjComco.BalancedPoints;
                dr["Amount"] = ObjComco.Amount;


                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }

            parameters.Add("Comments", ObjClass.Comments, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            //parame    ters.Add("Comments", ObjClass.Comments, DbType.String, ParameterDirection.Input);
            //  parameters.Add("TypeApprovalAuthorizeFuelLoyaltyRedemption", dtDBR, DbType.Object, ParameterDirection.Input);

            parameters.Add("TypeAuthorizeFuelLoyaltyRedemption", dtDBR, DbType.Object, ParameterDirection.Input);

            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);

            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<FuelLoyaltyRedemptionAuthorizeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetAuthorizeFuelLoyaltyRedemptionDetailModelOutput>> GetAuthorizeFuelLoyaltyRedemptionDetail([FromBody] GetAuthorizeFuelLoyaltyRedemptionDetailModelInput ObjClass)
        {
          //  var procedureName = "UspGetApproveFuelLoyaltyRedemptionDetail";
            var procedureName = "UspAuthorizeFuelLoyaltyRedemption";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("RequestNumber", ObjClass.RequestNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Customertype", ObjClass.Customertype, DbType.String, ParameterDirection.Input);
            parameters.Add("UserType", ObjClass.Customertype, DbType.String, ParameterDirection.Input);
            parameters.Add("Type", ObjClass.Customertype, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAuthorizeFuelLoyaltyRedemptionDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetApprovedFuelLoyaltyRedemptionDetailModelOutput>> GetApproveFuelLoyaltyRedemptionDetail([FromBody] GetApprovedFuelLoyaltyRedemptionDetailModelnput ObjClass)
        {
            var procedureName = "UspGetApproveFuelLoyaltyRedemptionDetail";
            //  var procedureName = "UspAuthorizeFuelLoyaltyRedemption";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("RequestNumber", ObjClass.RequestNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Customertype", ObjClass.Customertype, DbType.String, ParameterDirection.Input);
            parameters.Add("UserType", ObjClass.Customertype, DbType.String, ParameterDirection.Input);
            parameters.Add("Type", ObjClass.Customertype, DbType.String, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetApprovedFuelLoyaltyRedemptionDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }






    }
}
