
using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.STFC;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataRepository.STFC
{
    public class StfcApiRepository:IStfcApiRepository
    {

        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        public StfcApiRepository(DapperContext context, IHostingEnvironment hostingEnvironment, IConfiguration configuration) // , IConfiguration configuration
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }

        public async Task<IEnumerable<GetStfcCustomerIdByCardOutput>> GetStfcCustomerIdByCard(string CardNo)
        {
            var procedureName = "UspGetStfcCustomerIdByCard";
            var parameters = new DynamicParameters();
            parameters.Add("CardNo", CardNo, DbType.String, ParameterDirection.Input);
            
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetStfcCustomerIdByCardOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCustomerIdByCardForExternalAPIOutput>> GetCustomerIdByCardForExternalAPI(string CardNo,string Mobileno)
        {
            var procedureName = "UspGetCustomerIdByCardForExternalAPI";
            var parameters = new DynamicParameters();
            parameters.Add("CardNo", CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", Mobileno, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCustomerIdByCardForExternalAPIOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<STFCApiRequestModelOutput>> InsertStfcFastagApiRequest(STFCApiRequestModelInput ObjClass)
        {
            var procedureName = "UspInsertSTFCApiRequest";
            var parameters = new DynamicParameters();
            parameters.Add("ApiRequestUrL", ObjClass.ApiRequestUrL, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalID", ObjClass.TerminalID, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.String, ParameterDirection.Input);
            parameters.Add("Remarks", ObjClass.Remarks, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("TxnId", ObjClass.TxnId, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPCustomerId", ObjClass.TxnId, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Transdate", ObjClass.Transdate, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);

            parameters.Add("Invoiceid", ObjClass.Invoiceid, DbType.String, ParameterDirection.Input);
            parameters.Add("Batchid", ObjClass.Batchid, DbType.String, ParameterDirection.Input);
            parameters.Add("Invoicedate", ObjClass.Invoicedate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("Productid", ObjClass.Productid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Odometerreading", ObjClass.Odometerreading, DbType.String, ParameterDirection.Input);
            parameters.Add("TransType", ObjClass.TransType, DbType.String, ParameterDirection.Input);
            parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input); ;
            parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
            parameters.Add("DCSTokenNo", ObjClass.DCSTokenNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Stan", ObjClass.Stan, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Paymentmode", null, DbType.String, ParameterDirection.Input);
            parameters.Add("Gatewayname", "STFC", DbType.String, ParameterDirection.Input);
            parameters.Add("Bankname", "STFC", DbType.String, ParameterDirection.Input);
            parameters.Add("Paycode", null, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<STFCApiRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async void InsertStfcApiRequestResponseDetail( STFCApiRequestResponseModelInput ObjClass)
        {
            var procedureName = "UspInsertStfcApiRequestResponseDetail";
            var parameters = new DynamicParameters();
            parameters.Add("RqId", ObjClass.RqId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ApiRequestUrL", ObjClass.ApiRequestUrL, DbType.String, ParameterDirection.Input);
            parameters.Add("ApiRequest", ObjClass.ApiRequest, DbType.String, ParameterDirection.Input);
            parameters.Add("ApiResponse", ObjClass.ApiResponse, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqTxnId", ObjClass.ReqTxnId, DbType.String, ParameterDirection.Input);
            parameters.Add("ResTxnId", ObjClass.ResTxnId, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqCardNo", ObjClass.ReqCardNo, DbType.String, ParameterDirection.Input);

            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalID", ObjClass.TerminalID, DbType.String, ParameterDirection.Input);


            parameters.Add("ReqAmount", ObjClass.ReqAmount, DbType.String, ParameterDirection.Input);
            parameters.Add("ResAvailableLimit", ObjClass.ResAvailableLimit, DbType.String, ParameterDirection.Input);
            parameters.Add("STFCCustomerID", ObjClass.STFCCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPCustomerId", ObjClass.DTPCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ResCardNumber", ObjClass.ResCardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("MsgType", ObjClass.ResMsgType, DbType.String, ParameterDirection.Input);

            parameters.Add("ErrorReason", ObjClass.ResErrorReason, DbType.String, ParameterDirection.Input);
            parameters.Add("Remarks", ObjClass.Remarks, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            

            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("IsPaymentSuccess", ObjClass.IsPaymentSuccess, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IsRefundSuccess", ObjClass.IsRefundSuccess, DbType.Int32, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var res = await connection.QueryAsync<STFCApiRequestResponseModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<STFCTransactionReversalModelOutput>> CheckFastagRefundProcessedForSTFCCustomer( STFCTransactionReversalModelInput ObjClass)
        {
            var procedureName = "UspCheckFastagRefundProcessedForSTFCCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("TxnId", ObjClass.TxnRefId, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<STFCTransactionReversalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CheckSTFCInvoiceIdBatchIdExistOutput>> CheckFastagInvoiceIdBatchIdExist(CheckSTFCInvoiceIdBatchIdExistInput obj)
        {
            var procedureName = "uspCheckFastagInvoiceIdBatchIdExist";
            var parameters = new DynamicParameters();
            parameters.Add("Invoiceid", obj.Invoiceid, DbType.String, ParameterDirection.Input);
            parameters.Add("Batchid", obj.Batchid, DbType.String, ParameterDirection.Input);
            parameters.Add("TransTypeId", obj.TransTypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("RecordType", obj.RecordType, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", obj.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", obj.TerminalID, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", obj.UserId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckSTFCInvoiceIdBatchIdExistOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CheckCardLimitValidationforAPIOutput>> CheckCardLimitValidationforAPI(CheckCardLimitValidationforAPIInput obj)
        {
            var procedureName = "UspCheckCardLimitValidationforAPI";
            var parameters = new DynamicParameters();
            parameters.Add("CardNo", obj.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", obj.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("Invoicedate", obj.Invoicedate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("Invoiceamount", obj.Invoiceamount, DbType.String, ParameterDirection.Input);

            parameters.Add("Sourceid", obj.Sourceid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Formfactor", obj.Formfactor, DbType.Int32, ParameterDirection.Input);
            parameters.Add("pin", obj.Pin, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", obj.Userid, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckCardLimitValidationforAPIOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateCCMSBAlanceForSTFCCustomer>> UpdateCCMSBAlanceForStfcCustomer(EntityCheckAPIRequestModelInput ObjClass,string TxnId, string CustomerId)
        {
            var procedureName = "UspUpdateCCMSBAlanceForSTFCCustomer";
            var parameters = new DynamicParameters();

            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerId", CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
            parameters.Add("PaidAmount", ObjClass.Amount, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("TxnId", TxnId, DbType.String, ParameterDirection.Input);
            parameters.Add("Invoiceid", ObjClass.Invoiceid, DbType.String, ParameterDirection.Input);
            parameters.Add("Batchid", ObjClass.Batchid, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);

            parameters.Add("Invoicedate", ObjClass.Invoicedate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("Productid", ObjClass.Productid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Odometerreading", ObjClass.Odometerreading, DbType.String, ParameterDirection.Input);
            parameters.Add("TransType", ObjClass.TransType, DbType.String, ParameterDirection.Input);
            parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
            parameters.Add("DCSTokenNo", ObjClass.DCSTokenNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Stan", ObjClass.Stan, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Paymentmode", "STFC", DbType.String, ParameterDirection.Input);
            parameters.Add("Gatewayname", "STFC", DbType.String, ParameterDirection.Input);
            parameters.Add("Bankname", "STFC", DbType.String, ParameterDirection.Input);
            parameters.Add("Paycode", null, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCCMSBAlanceForSTFCCustomer>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateCCMSBAlanceForSTFCCustomer>> RefundCCMSBAlanceForSTFCCustomer(STFCTransactionReversalModelInput ObjClass)
        {
            var procedureName = "UspRefundCCMSBAlanceForSTFCCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("TxnId", ObjClass.TxnRefId, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("Invoiceid", ObjClass.Invoiceid, DbType.String, ParameterDirection.Input);
            parameters.Add("Batchid", ObjClass.Batchid, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);

            parameters.Add("Invoicedate", ObjClass.Invoicedate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("Productid", ObjClass.Productid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Odometerreading", ObjClass.Odometerreading, DbType.String, ParameterDirection.Input);
            parameters.Add("TransType", ObjClass.TransType, DbType.String, ParameterDirection.Input);
            parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
            parameters.Add("DCSTokenNo", ObjClass.DCSTokenNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Stan", ObjClass.Stan, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Paymentmode", ObjClass.BankID, DbType.String, ParameterDirection.Input);
            parameters.Add("Gatewayname", "STFC", DbType.String, ParameterDirection.Input);
            parameters.Add("Bankname", "STFC", DbType.String, ParameterDirection.Input);
            parameters.Add("Paycode", null, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCCMSBAlanceForSTFCCustomer>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<STFCRefundStatusUpdateModelOutput>> UpdateRequestResponseDetailRefundStatus(STFCTransactionReversalModelInput ObjClass)
        {
            var procedureName = "UspUpdateSTFCRequestResponseDetailRefundStatus";
            var parameters = new DynamicParameters();
            parameters.Add("TxnId", ObjClass.TxnRefId, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<STFCRefundStatusUpdateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async void UpdateSTFCApiRequest(UpdateSTFCRequestInput ObjClass)
        {
            var procedureName = "UspUpdateSTFCApiRequest";
            var parameters = new DynamicParameters();
            parameters.Add("RequestId", ObjClass.RequestId, DbType.String, ParameterDirection.Input);
            parameters.Add("Remarks", ObjClass.Remarks, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("EntityCheckAPIRequest", ObjClass.EntityCheckAPIRequest, DbType.String, ParameterDirection.Input);
            parameters.Add("EntityCheckAPIResponse", ObjClass.EntityCheckAPIResponse, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            await connection.QueryAsync<UpdateSTFCApiRequestOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetSTFCTxnRefIDOutput>> GetSTFCTxnRefID()
        {
            var procedureName = "UspGetSTFCTxnRefID";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetSTFCTxnRefIDOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            
        }
    }
}
