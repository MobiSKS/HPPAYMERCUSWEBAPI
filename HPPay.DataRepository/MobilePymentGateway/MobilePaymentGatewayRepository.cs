using CCA.Util;
using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.HDFCPG;
using HPPay.DataModel.MobilePaymentGatewayModel;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.MobilePaymentGateway
{
    public  class MobilePaymentGatewayRepository : IMobilePaymentGatewayRepository
    {
        private readonly DapperContext _context;
        private readonly IConfiguration _configuration;
        public MobilePaymentGatewayRepository(DapperContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        } 

        public async Task<IEnumerable<MobilePaymentGatewayModelOutPut>> InitiateMobilePaymentRequest([FromForm] MobilePaymentGatewayModelInPut ObjClass)
        { 
            var procedureName = "UspInsertCPPGApiRequestResponse";
            var parameters = new DynamicParameters();
            parameters.Add("BankName", "CCMS Recharge By Mobile", DbType.String, ParameterDirection.Input);
            parameters.Add("BankStatus", "Initiated", DbType.String, ParameterDirection.Input);
            parameters.Add("Amt", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);            
            parameters.Add("SourceId", ObjClass.SourceId, DbType.String, ParameterDirection.Input);
            parameters.Add("Formfactor", ObjClass.Formfactor, DbType.String, ParameterDirection.Input);
            parameters.Add("Request", ObjClass.Request, DbType.String, ParameterDirection.Input);
            parameters.Add("trans_date", ObjClass.TransactionDate, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionId", ObjClass.OrderId, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MobilePaymentGatewayModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GenerateQRCodeModelOutput>> GenerateQRCode([FromForm] GenerateQRCodeModelInput ObjClass)
        {
            var procedureName = "UspGenerateQRCodeString";
            var parameters = new DynamicParameters(); 
            parameters.Add("Amount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input); 
            parameters.Add("ProductId", ObjClass.ProductId, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input); 
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input); 
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GenerateQRCodeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ValidateQRCodeModelOutput>> ValidateQRCode([FromForm] ValidateQRCodeModelInput ObjClass)
        {
            var procedureName = "UspValidateQRCodeString";
            var parameters = new DynamicParameters(); 
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("QRRequestId", ObjClass.QRRequestId, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input); 
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ValidateQRCodeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
