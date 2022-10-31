using CCA.Util;
using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.HDFCPG;
using HPPay.DataModel.PayU;
using HPPay.DataModel.RechargeCCMS;
using HPPay.DataRepository.DBDapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.PayU
{
    public  class PayURepository : IPayURepository
    {
        private readonly DapperContext _context;
        private readonly IConfiguration _configuration;
        public int OTPtype = 2;
        public string Status = "Initialized";
        public PayURepository(DapperContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<IEnumerable<PayUPaymentGatewayModelOutPut>> GetCustomerDetailsForRecharge([FromBody] InitiatePayUPaymentGatewayModelInput ObjClass)
        {
            var procedureName = "UspGetDetailsForPayUPayment";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<PayUPaymentGatewayModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async void InsertPayUApiRequestResponse([FromBody] PayUApiRequestResponse ObjClass)
        {
            //var procedureName = "UspInsertPayUApiRequestResponse";
            var procedureName = "UspInsertCPPGApiRequestResponse";
            var parameters = new DynamicParameters();
            parameters.Add("TransactionId", ObjClass.TransactionId, DbType.String, ParameterDirection.Input);
            parameters.Add("Request", ObjClass.request.Replace('"', '"'), DbType.String, ParameterDirection.Input);
            parameters.Add("Response", ObjClass.response, DbType.String, ParameterDirection.Input);
            parameters.Add("Apiurl", ObjClass.apiurl + ObjClass.request_Hash, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNo", ObjClass.ControlCardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Amt", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("BankStatus", Status, DbType.String, ParameterDirection.Input);
            parameters.Add("BankName", ObjClass.BankName, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("SourceId", ObjClass.SourceId, DbType.String, ParameterDirection.Input);
            parameters.Add("Formfactor", ObjClass.Formfactor, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var res = await connection.QueryAsync<object>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

           
        public async Task<IEnumerable<GetPayUPGResponseModelOutput>> PayUGetPGResponse([FromBody] PayUResponse ObjClass)
        {
            //var procedureName = "UspInsertPayUApiRequestResponse";
            var procedureName = "UspInsertCPPGApiRequestResponse";
            var parameters = new DynamicParameters(); 
            parameters.Add("BankStatus", Status, DbType.String, ParameterDirection.Input); 
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("orderId", ObjClass.txnid, DbType.String, ParameterDirection.Input);
            parameters.Add("Amt", ObjClass.amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("tracking_id", ObjClass.id, DbType.String, ParameterDirection.Input);
            parameters.Add("transactionId", ObjClass.txnid, DbType.String, ParameterDirection.Input);
            parameters.Add("status_message", ObjClass.status, DbType.String, ParameterDirection.Input);
            parameters.Add("bank_ref_no", ObjClass.bank_ref_no, DbType.String, ParameterDirection.Input);
            parameters.Add("order_status", ObjClass.status, DbType.String, ParameterDirection.Input);
            parameters.Add("failure_message", ObjClass.Error_Message, DbType.String, ParameterDirection.Input);
            parameters.Add("payment_mode", ObjClass.mode, DbType.String, ParameterDirection.Input);
            parameters.Add("mer_amount", ObjClass.transaction_fee, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("trans_date", ObjClass.addedon, DbType.String, ParameterDirection.Input);
            parameters.Add("Response", ObjClass.responseString, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            parameters.Add("TrnsSource", ObjClass.TrnsSource, DbType.String, ParameterDirection.Input);
            
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetPayUPGResponseModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
             
        } 
        

    }
}
