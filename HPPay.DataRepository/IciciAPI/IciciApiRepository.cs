using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.IciciAPI;
using HPPay.DataModel.IdfcAPI;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.IciciAPI
{
    public class IciciApiRepository :IIciciApiRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        public IciciApiRepository(DapperContext context, IHostingEnvironment hostingEnvironment, IConfiguration configuration) // , IConfiguration configuration
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }

        //public async Task<IEnumerable<IciciApiRequestResponseOutput>> InsertIciciApiRequestResponse([FromBody] IciciApiRequestResponseInput ObjClass)
        //{
        //    var procedureName = "UspInsertIciciApiRequestResponse";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("ApiRequestUrL", ObjClass.ApiRequestUrL, DbType.String, ParameterDirection.Input);
        //    parameters.Add("ApiRequest", ObjClass.ApiRequest, DbType.String, ParameterDirection.Input);
        //    parameters.Add("ApiResponse", ObjClass.ApiResponse, DbType.String, ParameterDirection.Input);
        //    parameters.Add("Remarks", ObjClass.Remarks, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
        //    using var connection = _context.CreateConnection();
        //    return await connection.QueryAsync<IciciApiRequestResponseOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        //}

        public async Task<IEnumerable<InsertFastagIciciApiRequestOutput>> InsertIciciFastagApiRequest(InsertFastagIciciApiRequestInput ObjClass)
        {
            var procedureName = "UspInsertIciciFastagApiRequest";
            var parameters = new DynamicParameters();
            parameters.Add("ApiRequestUrL", ObjClass.ApiRequestUrL, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalID", ObjClass.TerminalID, DbType.String, ParameterDirection.Input);
            parameters.Add("BankID", ObjClass.BankID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Vrn", ObjClass.Vrn, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.String, ParameterDirection.Input);
            parameters.Add("NetAmount", ObjClass.NetAmount, DbType.String, ParameterDirection.Input);
            parameters.Add("DiscountAmount", ObjClass.DiscountAmount, DbType.String, ParameterDirection.Input);
            parameters.Add("Remarks", ObjClass.Remarks, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("TxnId", ObjClass.TxnId, DbType.String, ParameterDirection.Input);
            parameters.Add("TagId", ObjClass.TagId, DbType.String, ParameterDirection.Input);
            parameters.Add("OrgTxnId", ObjClass.OrgTxnId, DbType.String, ParameterDirection.Input);
            parameters.Add("OrgTxnTime", ObjClass.OrgTxnTime, DbType.String, ParameterDirection.Input);
            parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
            parameters.Add("TxnTime", ObjClass.TxnTime, DbType.String, ParameterDirection.Input);

            parameters.Add("TxnNo", ObjClass.TxnNo, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Invoiceid", ObjClass.Invoiceid, DbType.String, ParameterDirection.Input);
            parameters.Add("Batchid", ObjClass.Batchid, DbType.Int32, ParameterDirection.Input);

            parameters.Add("Invoicedate", ObjClass.Invoicedate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("Productid", ObjClass.Productid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Odometerreading", ObjClass.Odometerreading, DbType.String, ParameterDirection.Input);
            parameters.Add("TransType", ObjClass.TransType, DbType.String, ParameterDirection.Input);
            parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
            parameters.Add("DCSTokenNo", ObjClass.DCSTokenNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Stan", ObjClass.Stan, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Paymentmode", ObjClass.Paymentmode, DbType.String, ParameterDirection.Input);
            parameters.Add("Gatewayname", ObjClass.Gatewayname, DbType.String, ParameterDirection.Input);
            parameters.Add("Bankname", ObjClass.Bankname, DbType.String, ParameterDirection.Input);
            parameters.Add("Paycode", ObjClass.Paycode, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertFastagIciciApiRequestOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async void UpdateIciciFastagApiRequest(UpdateFastagIciciApiRequestInput ObjClass)
        {
            var procedureName = "UspUpdateIciciFastagApiRequest";
            var parameters = new DynamicParameters();
            parameters.Add("RequestId", ObjClass.RequestId, DbType.String, ParameterDirection.Input);
            parameters.Add("Remarks", ObjClass.Remarks, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            await connection.QueryAsync<UpdateFastagIciciApiRequestOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateCCMSBAlanceForICICICustomer>> UpdateCCMSBAlanceForIciciCustomer([FromBody] FastagConfirmOtpReQuest ObjClass, string NetAmount, string DiscountAmount)
        {
            var procedureName = "UspUpdateCCMSBAlanceForIciciCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
            parameters.Add("PaidAmount", NetAmount, DbType.String, ParameterDirection.Input);
            parameters.Add("InvoiceAmount", ObjClass.Invoiceamount, DbType.String, ParameterDirection.Input);
            parameters.Add("DiscountAmount", DiscountAmount, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNumber", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("VechileNo", ObjClass.Vehicleno, DbType.String, ParameterDirection.Input);
            parameters.Add("FastagNo", ObjClass.TagId, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("TxnId", ObjClass.TxnRefId, DbType.String, ParameterDirection.Input);
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
            parameters.Add("Gatewayname", "ICICI", DbType.String, ParameterDirection.Input);
            parameters.Add("Bankname", "ICICI", DbType.String, ParameterDirection.Input);
            parameters.Add("Paycode", "0", DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCCMSBAlanceForICICICustomer>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateCCMSBAlanceForICICICustomer>> RefundCCMSBAlanceForIciciCustomer([FromBody] FastagRefundPaymentReQuest ObjClass)
        {
            var procedureName = "UspRefundCCMSBAlanceForIciciCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("TxnId", ObjClass.OrgTxnId, DbType.String, ParameterDirection.Input);
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
            parameters.Add("Gatewayname", "ICICI", DbType.String, ParameterDirection.Input);
            parameters.Add("Bankname", "ICICI", DbType.String, ParameterDirection.Input);
            parameters.Add("Paycode", "0", DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCCMSBAlanceForICICICustomer>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<IciciRefundResponse>> CheckFastagRefundProcessedForIciciCustomer([FromBody] FastagRefundPaymentReQuest ObjClass)
        {
            var procedureName = "UspCheckFastagRefundProcessedForIciciCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("TxnId", ObjClass.OrgTxnId, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);            
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<IciciRefundResponse>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<IciciRefundStatusUpdateModelOutput>> UpdateRequestResponseDetailRefundStatus([FromBody] FastagRefundPaymentReQuest ObjClass)
        {
            var procedureName = "UspUpdateRequestResponseDetailRefundStatus";
            var parameters = new DynamicParameters();
            parameters.Add("TxnId", ObjClass.OrgTxnId, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<IciciRefundStatusUpdateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async void InsertIciciApiRequestResponseDetail([FromBody] IciciApiRequestResponseDetailInput ObjClass)
        {
            var procedureName = "UspInsertIciciApiRequestResponseDetail";
            var parameters = new DynamicParameters();
            parameters.Add("RefId", ObjClass.RqId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ApiRequestUrL", ObjClass.ApiRequestUrL, DbType.String, ParameterDirection.Input);
            parameters.Add("ApiRequest", ObjClass.ApiRequest, DbType.String, ParameterDirection.Input);
            parameters.Add("ApiResponse", ObjClass.ApiResponse, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqMobileNo", ObjClass.ReqMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqVrn", ObjClass.ReqVrn, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqAmount", ObjClass.ReqAmount, DbType.String, ParameterDirection.Input);

            parameters.Add("ReqNetAmount", ObjClass.ReqNetAmount, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqDiscount", ObjClass.ReqDiscount, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqEntityId", ObjClass.ReqEntityId, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqPosId", ObjClass.ReqPosId, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqTxnTime", ObjClass.ReqTxnTime, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqIIN", ObjClass.ReqIIN, DbType.String, ParameterDirection.Input);

            parameters.Add("ReqChkSm", ObjClass.ReqChkSm, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqOtp", ObjClass.ReqOtp, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqOrgTxnId", ObjClass.ReqOrgTxnId, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqOrgTxnTime", ObjClass.ReqOrgTxnTime, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqTxnId", ObjClass.ReqTxnId, DbType.String, ParameterDirection.Input);
            parameters.Add("ResTxnId", ObjClass.ResTxnId, DbType.String, ParameterDirection.Input);

            parameters.Add("ResTxnNo", ObjClass.ResTxnNo, DbType.String, ParameterDirection.Input);
            parameters.Add("ResCode", ObjClass.ResCode, DbType.String, ParameterDirection.Input);
            parameters.Add("ResMsg", ObjClass.ResMsg, DbType.String, ParameterDirection.Input);
            parameters.Add("RestagId", ObjClass.RestagId, DbType.String, ParameterDirection.Input);
            parameters.Add("ResMobileNo", ObjClass.ResMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("vrn", ObjClass.ResVrn, DbType.String, ParameterDirection.Input);
           
            parameters.Add("Remarks", ObjClass.Remarks, DbType.String, ParameterDirection.Input);

            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("IsPaymentSuccess", ObjClass.IsPaymentSuccess, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IsRefundSuccess", ObjClass.IsRefundSuccess, DbType.Int32, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var res = await connection.QueryAsync<IciciApiRequestResponseDetailOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<IciciCheckFastagInvoiceIdBatchIdExistOutput>> CheckFastagInvoiceIdBatchIdExist(IciciCheckFastagInvoiceIdBatchIdExistInput obj)
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
            parameters.Add("Useragent", obj.Useragent, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
           return await connection.QueryAsync<IciciCheckFastagInvoiceIdBatchIdExistOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
