using CCA.Util;
using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.HDFCPG;
using HPPay.DataModel.HLFL;
using HPPay.DataModel.RBE;
using HPPay.DataModel.Transaction;
using HPPay.DataRepository.DBDapper;
using HPPay.DataRepository.RBE;
using HPPay.Infrastructure.TokenManager;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Http;
using static HPPay.Infrastructure.CommonClass.StatusMessage;

namespace HPPay.DataRepository.FSE
{
    public  class FSERepository : IFSERepository
    {
        private readonly DapperContext _context;
        private readonly IConfiguration _configuration;
        public int OTPtype = 2;
        public FSERepository(DapperContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<IEnumerable<FSEVerifyTPModelOutPut>> FSEValidateOTP([FromBody] FSEVerifyTPModelInput ObjClass)
        {
            var procedureName = "UspFSEValidateOTP";
            var parameters = new DynamicParameters(); 
            parameters.Add("NewMobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("ExistingMobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);            
            parameters.Add("CreatedBy", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
            //parameters.Add("Token", ObjClass.Token, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<FSEVerifyTPModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FSEGenerateOTPModelOutPut>> FSEGenerateOTP([FromBody] FSEGenerateOTPModelInput ObjClass)
        {
            var procedureName = "UspSendOtpChangeRBEMobile";
            var parameters = new DynamicParameters();
            parameters.Add("NewMobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input); 
            parameters.Add("CreatedBy", "FSE", DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);            
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<FSEGenerateOTPModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            
        }

        public async Task<IEnumerable<FSEGetDetailsModelOutPut>> FSEViewMerchantDetails([FromBody] FSEGetDetailsModelInput ObjClass)
        {
            var procedureName = "UspFSEGetMerchantDetails";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<FSEGetDetailsModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
             
        }

        public async Task<FSEGetDashboardDetailsModelOutPut> FSEViewDashboardDetails([FromBody] FSEGetDashboardDetailsModelInput ObjClass)
        {
            var procedureName = "UspFSEGetDashboardDetails";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new FSEGetDashboardDetailsModelOutPut();           
            storedProcedureResult.FSEGetMerchantDetails = (List<FSEGetDashboardMerchantDetails>)await result.ReadAsync<FSEGetDashboardMerchantDetails>();
            storedProcedureResult.FSEGetTicketDetails = (List<FSEGetDashboardTicketDetails>)await result.ReadAsync<FSEGetDashboardTicketDetails>();
            storedProcedureResult.FSEGetRequestDetails = (List<FSEGetRequestDetailsModelOutPut>)await result.ReadAsync<FSEGetRequestDetailsModelOutPut>();
            return storedProcedureResult;
        }
         
        public async Task<IEnumerable<FSEGetTicketsDetailsModelOutPut>> FSEGetTicketDetails([FromBody] FSEGetTicketsDetailsModelInput ObjClass)
        {
            var procedureName = "UspFSEGetTicketDetails";
            var parameters = new DynamicParameters();
            parameters.Add("TicketNumber", ObjClass.TicketNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Type", ObjClass.Type, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<FSEGetTicketsDetailsModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
