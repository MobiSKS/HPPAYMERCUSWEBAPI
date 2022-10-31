using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.M2PExternal;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataRepository.M2PExternal
{
    public class M2PExternalRepository: IM2PExternalRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        public M2PExternalRepository(DapperContext context, IHostingEnvironment hostingEnvironment, IConfiguration configuration) // , IConfiguration configuration
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }


        public async Task<IEnumerable<M2PApiRequestModelOutput>> InsertM2PFastagApiRequest(M2PApiRequestModelInput ObjClass)
        {
            var procedureName = "UspInsertM2PApiRequest";
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
            parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
            parameters.Add("DCSTokenNo", ObjClass.DCSTokenNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Stan", ObjClass.Stan, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Paymentmode", null, DbType.String, ParameterDirection.Input);
            parameters.Add("Gatewayname", "M2P", DbType.String, ParameterDirection.Input);
            parameters.Add("Bankname", "M2P", DbType.String, ParameterDirection.Input);
            parameters.Add("Paycode", null, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<M2PApiRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async void InsertM2PApiRequestResponseDetail(M2PApiRequestResponseModelInput ObjClass)
        {
            var procedureName = "UspInsertM2PApiRequestResponseDetail";
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
            parameters.Add("M2PCustomerID", ObjClass.M2PCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPCustomerId", ObjClass.DTPCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ResCardNumber", ObjClass.ResCardNumber, DbType.String, ParameterDirection.Input);

            parameters.Add("Result", ObjClass.Result, DbType.String, ParameterDirection.Input);
            parameters.Add("DetailMessage", ObjClass.DetailMessage, DbType.String, ParameterDirection.Input);
            parameters.Add("ShortMessage", ObjClass.ShortMessage, DbType.String, ParameterDirection.Input);
            parameters.Add("ErrorCode", ObjClass.ErrorCode, DbType.String, ParameterDirection.Input);

            parameters.Add("Remarks", ObjClass.Remarks, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);


            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("IsPaymentSuccess", ObjClass.IsPaymentSuccess, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IsRefundSuccess", ObjClass.IsRefundSuccess, DbType.Int32, ParameterDirection.Input);

            parameters.Add("TransactionDate", ObjClass.TransactionDate, DbType.Int32, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var res = await connection.QueryAsync<M2PApiRequestResponseModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetM2PCustomerIdByCardOutput>> GetM2PCustomerIdByCard(string CardNo)
        {
            var procedureName = "UspGetM2PCustomerIdByCard";
            var parameters = new DynamicParameters();
            parameters.Add("CardNo", CardNo, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetM2PCustomerIdByCardOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CheckM2PInvoiceIdBatchIdExistOutput>> CheckM2PInvoiceIdBatchIdExist(CheckM2PInvoiceIdBatchIdExistInput obj)
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
            return await connection.QueryAsync<CheckM2PInvoiceIdBatchIdExistOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

       
        public async Task<IEnumerable<UpdateCCMSBAlanceForM2PCustomer>> RefundCCMSBAlanceForM2PCustomer(M2PTransactionReversalModelInput ObjClass)
        {
            var procedureName = "UspRefundCCMSBAlanceForM2PCustomer";
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
            parameters.Add("Paymentmode", "5", DbType.String, ParameterDirection.Input);
            parameters.Add("Gatewayname", "M2P", DbType.String, ParameterDirection.Input);
            parameters.Add("Bankname", "M2P", DbType.String, ParameterDirection.Input);
            parameters.Add("Paycode", null, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCCMSBAlanceForM2PCustomer>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<M2PRefundStatusUpdateModelOutput>> M2PUpdateRequestResponseDetailRefundStatus(M2PTransactionReversalModelInput ObjClass)
        {
            var procedureName = "UspUpdateM2PRequestResponseDetailRefundStatus";
            var parameters = new DynamicParameters();
            parameters.Add("TxnId", ObjClass.TxnRefId, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<M2PRefundStatusUpdateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<M2PCheckCardLimitValidationforAPIOutput>> M2PCheckCardLimitValidationforAPI(M2PCheckCardLimitValidationforAPIInput obj)
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
            return await connection.QueryAsync<M2PCheckCardLimitValidationforAPIOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async void UpdateM2PApiRequest(UpdateM2PRequestInput ObjClass)
        {
            var procedureName = "UspUpdateM2PApiRequest";
            var parameters = new DynamicParameters();
            parameters.Add("RequestId", ObjClass.RequestId, DbType.String, ParameterDirection.Input);
            parameters.Add("Remarks", ObjClass.Remarks, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("EntityCheckAPIRequest", ObjClass.EntityCheckAPIRequest, DbType.String, ParameterDirection.Input);
            parameters.Add("EntityCheckAPIResponse", ObjClass.EntityCheckAPIResponse, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            await connection.QueryAsync<UpdateM2PApiRequestOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<M2PTransactionReversalModelOutput>> CheckRefundProcessedForM2PCustomer(M2PTransactionReversalModelInput ObjClass)
        {
            var procedureName = "UspCheckRefundProcessedForM2PCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("TxnId", ObjClass.TxnRefId, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<M2PTransactionReversalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
