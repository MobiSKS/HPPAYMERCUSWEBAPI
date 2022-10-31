using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.RechargeCCMS;
using HPPay.DataModel.Transaction;
using HPPay.DataRepository.DBDapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.RechargeCCMS
{
    
    public class RechargeCCMSRepository: IRechargeCCMSRepository
    {
        public int OTPtype = 2;
        public string Status = "Initialized";
        private readonly DapperContext _context; 
        public RechargeCCMSRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetDetailsRechargeCCMSModelOutPut>> InitiateRechargeCCMS([FromBody] GetDetailsRechargeCCMSModelInput ObjClass)
        {
            var procedureName = "UspGetDetailsByMobileNo";
            var parameters = new DynamicParameters();
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDetailsRechargeCCMSModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InitiateRechargeCCMSModelOutPut>> GetDetailsForRechargeCCMS([FromBody] InitiateRechargeCCMSModelInput ObjClass)
        {
            var procedureName = "UspGetDetailsForCCMSRecharge";
            var parameters = new DynamicParameters(); 
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input); 
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();            
            return await connection.QueryAsync<InitiateRechargeCCMSModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure); 
        }
        public async void InsertRechargeCCMSApiRequestResponse([FromBody] CCMSApiRequestResponse ObjClass)
        {
            var procedureName = "UspInsertCPPGApiRequestResponse";
            var parameters = new DynamicParameters(); 
            parameters.Add("TransactionId", ObjClass.TransactionId, DbType.String, ParameterDirection.Input);
            parameters.Add("Request", ObjClass.request.Replace('"','"'), DbType.String, ParameterDirection.Input);
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
            parameters.Add("TrnsSource", ObjClass.TrnsSource, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var res = await connection.QueryAsync<object>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CCMSRechargeCCMSAccountModelOutput>> RechargeCCMSAccount([FromBody] CCMSRechargeCCMSAccountModelInput ObjClass)
        {
            var procedureName = "UspCCMSRechargeAccountResponse";
            var parameters = new DynamicParameters(); 
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Batchid", ObjClass.Batchid, DbType.Int64, ParameterDirection.Input);
            parameters.Add("Invoiceamount", ObjClass.Invoiceamount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("Transtype", ObjClass.Transtype, DbType.String, ParameterDirection.Input);
            parameters.Add("Invoiceid", ObjClass.Invoiceid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Invoicedate", ObjClass.Invoicedate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("Chequeno", ObjClass.Chequeno, DbType.String, ParameterDirection.Input);
            parameters.Add("MICR", ObjClass.MICR, DbType.String, ParameterDirection.Input);
            parameters.Add("MUtrno", ObjClass.MUtrno, DbType.String, ParameterDirection.Input);
            //parameters.Add("Paymentmode", ObjClass.Paymentmode, DbType.String, ParameterDirection.Input);
            //parameters.Add("Currency", ObjClass.Currency, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
            parameters.Add("Pin", ObjClass.Pin, DbType.String, ParameterDirection.Input);
            parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CCN", ObjClass.CCN, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();            
            return await connection.QueryAsync<CCMSRechargeCCMSAccountModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<WebGenerateOTPModelOutput>> CCMSGenerateOTP([FromBody] WebGenerateOTPModelInput ObjClass)
        {
            var procedureName = "UspGenerateOTP";
            var parameters = new DynamicParameters();
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("OTPtype", OTPtype, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CCN", ObjClass.CCN, DbType.String, ParameterDirection.Input);
            parameters.Add("TransTypeId", 530, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("Invoiceamount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<WebGenerateOTPModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CCMSConfirmOTPModelOutPut>> CCMSConfirmOTP([FromBody] CCMSConfirmOTPModelInput ObjClass)
        {
            var procedureName = "UspValidateOTPWeb";
            var parameters = new DynamicParameters();
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
            parameters.Add("OTPtype", OTPtype, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CCMSConfirmOTPModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        } 
    }
}
