using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.AGS;
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

namespace HPPay.DataRepository.AGS
{
    public class AGSRepository : IAGSRepository
    {
        private readonly DapperContext _context;
        IConfiguration _configuration;

        private readonly IHostingEnvironment _hostingEnvironment;
        public AGSRepository(DapperContext context, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {

            _context = context;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }




        public async Task<IEnumerable<AGSAPIValidateCredentialsModelOutput>> AGSAPIsValidateCredentials([FromBody] AGSAPIValidateCredentialsModelInput ObjClass)
        {
            var procedureName = "UspAGSAPIsValidateCredentials";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("Password", ObjClass.Password, DbType.String, ParameterDirection.Input);
           //   parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            // parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            //check if the supplied api and the existing api is same 
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AGSAPIValidateCredentialsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InitializationModelOutput>> Initialization([FromBody] InitializationModelInput ObjClass)
        {
            var procedureName = "UspInitialization";
            var parameters = new DynamicParameters();
            parameters.Add("MobileNumber", ObjClass.MobileNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            //parameters.Add("Useragent", , DbType.String, ParameterDirection.Input);
           
            parameters.Add("APIKey", ObjClass.APIKey, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            // parameters.Add("APIReferenceNo", _configuration.GetSection("AGS:ApiKey").Value, DbType.String, ParameterDirection.Input);
            // parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            //check if the supplied api and the existing api is same 
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InitializationModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<GetCustomerDetailsModelOutput> GetCustomerByMobileNo([FromBody] GetCustomerDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetCustomerByMobileNo";
            var parameters = new DynamicParameters();
            parameters.Add("Apikey", ObjClass.Apikey, DbType.String, ParameterDirection.Input);
        
            parameters.Add("MobileNumber", ObjClass.MobileNumber, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            // var result = await connection.QueryAsync<GetCustomerDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);


            var storedProcedureResult = new GetCustomerDetailsModelOutput();
            storedProcedureResult.CustomerInfo = (List<GetCustomerDetailsByMobileNoModelOutput>)await result.ReadAsync<GetCustomerDetailsByMobileNoModelOutput>();
            return storedProcedureResult;
            // return await connection.QueryAsync<InitializationModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetPEKModelOutput>> GetPEK([FromBody] GetPEKModelInput ObjClass)

        {
            var procedureName = "UspGetPEK";
            var parameters = new DynamicParameters();
            parameters.Add("PublicKey", ObjClass.PublicKey, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceuser", ObjClass.APIKey, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", _configuration.GetSection("AGS:ApiKey").Value, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            // var result = await connection.QueryAsync<GetCustomerDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            // var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            return await connection.QueryAsync<GetPEKModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


        }

        public async Task<IEnumerable<ValidateVehicleNumberModelOutput>> ValidateVehicleNumber([FromBody] ValidateVehicleNumberModelInput ObjClass)

        {
            var procedureName = "UspValidateVehicleNumber";
            var parameters = new DynamicParameters();
            parameters.Add("APIKey", ObjClass.APIKey, DbType.String, ParameterDirection.Input);
          //  parameters.Add("APIReferenceNo", _configuration.GetSection("AGS:ApiKey").Value, DbType.String, ParameterDirection.Input);

            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("DeviceID", ObjClass.DeviceID, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleNumber", ObjClass.VehicleNumber, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ValidateVehicleNumberModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


        }


        public async Task<IEnumerable<AuthorizationModelOutput>> Authorization([FromBody] AuthorizationModelInput ObjClass)

        {
            var procedureName = "UspAGSAuthorizationRequest";
            var parameters = new DynamicParameters();
            //parameters.Add("APIReferenceuser", ObjClass.APIKey, DbType.String, ParameterDirection.Input);
            //parameters.Add("APIReferenceNo", _configuration.GetSection("AGS:ApiKey").Value, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNumber", ObjClass.MobileNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNumber", ObjClass.ReferenceNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionType", ObjClass.TransactionType, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleNumber", ObjClass.VehicleNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("AutomationPIN", ObjClass.AutomationPIN, DbType.String, ParameterDirection.Input);
            parameters.Add("DeviceID", ObjClass.DeviceID, DbType.String, ParameterDirection.Input);
            parameters.Add("HashKey", ObjClass.HashKey, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AuthorizationModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


        }


        public async Task<IEnumerable<AcknowledgeModelOutput>> Acknowledge([FromBody] AcknowledgeModelInput ObjClass)

        {
            var procedureName = "UspAcknowledge";
            var parameters = new DynamicParameters();
            parameters.Add("APIKey", ObjClass.APIKey, DbType.String, ParameterDirection.Input);
          //  parameters.Add("APIReferenceNo", _configuration.GetSection("AGS:ApiKey").Value, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNumber", ObjClass.ReferenceNumber, DbType.String, ParameterDirection.Input);
           
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AcknowledgeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


        }



        public async Task<IEnumerable<BatchSettlementModelOutput>> BatchSettlement([FromBody] BatchSettlementModelInput ObjClass)

        {
            var procedureName = "UspBatchSettlementForAGS";
            var parameters = new DynamicParameters();
            parameters.Add("APIKey", ObjClass.APIKey, DbType.String, ParameterDirection.Input);
           // parameters.Add("APIReferenceNo", _configuration.GetSection("AGS:ApiKey").Value, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TotalAmount", ObjClass.TotalAmount, DbType.String, ParameterDirection.Input);
            parameters.Add("TotalCount ", ObjClass.TotalCount, DbType.String, ParameterDirection.Input);
            parameters.Add("BatchId", ObjClass.BatchId, DbType.String, ParameterDirection.Input);
            parameters.Add("DeviceID", ObjClass.DeviceID, DbType.String, ParameterDirection.Input);
         
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BatchSettlementModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


        }


        public async Task<IEnumerable<TransactionReversalModelOutput>> TransactionReversal([FromBody] TransactionReversalModelInput ObjClass)

        {
            var procedureName = "UspTransactionReversal";
            var parameters = new DynamicParameters();
            parameters.Add("APIKey", ObjClass.APIKey, DbType.String, ParameterDirection.Input);
         //   parameters.Add("APIReferenceNo", _configuration.GetSection("AGS:ApiKey").Value, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionAmount", ObjClass.TransactionAmount, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNumber", ObjClass.ReferenceNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("BatchId", ObjClass.BatchId, DbType.String, ParameterDirection.Input);
            parameters.Add("DeviceID", ObjClass.DeviceID, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNumber", ObjClass.MobileNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleNumber", ObjClass.VehicleNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionType", ObjClass.TransactionType, DbType.String, ParameterDirection.Input);
            parameters.Add("HashKey", ObjClass.HashKey, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<TransactionReversalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


        }


        public async Task<IEnumerable<PayCodeTransactionReversalModelOutput>> PayCodeTransactionReversal([FromBody] PayCodeTransactionReversalModelInput ObjClass)

        {
            var procedureName = "UspPayCodeTransactionReversal";
            var parameters = new DynamicParameters();
            parameters.Add("APIKey", ObjClass.APIKey, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);

            //   parameters.Add("APIReferenceNo", _configuration.GetSection("AGS:ApiKey").Value, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("Paycode", ObjClass.Paycode, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNumber", ObjClass.ReferenceNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("BatchId", ObjClass.BatchId, DbType.String, ParameterDirection.Input);
            parameters.Add("DeviceID", ObjClass.DeviceID, DbType.String, ParameterDirection.Input);
         
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<PayCodeTransactionReversalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


        }



        public async Task<IEnumerable<AuthorizePayCodeTxnModelOutput>> AuthorizePayCodeTxn([FromBody] AuthorizePayCodeTxnModelInput ObjClass)

        {
            var procedureName = "UspAuthorizePayCodeTxn";
            var parameters = new DynamicParameters();
            parameters.Add("APIKey", ObjClass.APIKey, DbType.String, ParameterDirection.Input);
           // parameters.Add("APIReferenceNo", _configuration.GetSection("AGS:ApiKey").Value, DbType.String, ParameterDirection.Input);
            parameters.Add("Paycode", ObjClass.Paycode, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNumber", ObjClass.ReferenceNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("DeviceID", ObjClass.DeviceID, DbType.String, ParameterDirection.Input);
           
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AuthorizePayCodeTxnModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


        }




        public async Task<IEnumerable<BatchUploadModelOutput>> BatchUpload([FromBody] BatchUploadModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeBatchUpload");
            dtDBR.Columns.Add("MobileNumber", typeof(string));
            dtDBR.Columns.Add("MerchantId", typeof(string));
            dtDBR.Columns.Add("Amount", typeof(string));
            dtDBR.Columns.Add("ProductName", typeof(string));
            dtDBR.Columns.Add("ReferenceNumber", typeof(string));
            dtDBR.Columns.Add("TransactionType", typeof(string));
            dtDBR.Columns.Add("VehicleNumber", typeof(string));
            dtDBR.Columns.Add("HashKey", typeof(string));
           


            if (ObjClass.ObjTransactionDetails != null)
            {
                foreach (TransactionDetails ObjDetail in ObjClass.ObjTransactionDetails)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["MobileNumber"] = ObjDetail.MobileNumber;
                    dr["MerchantId"] = ObjDetail.MerchantId;
                    dr["Amount"] = ObjDetail.Amount;
                    dr["ProductName"] = ObjDetail.ProductName;
                    dr["ReferenceNumber"] = ObjDetail.ReferenceNumber;
                    dr["TransactionType"] = ObjDetail.TransactionType;
                    dr["VehicleNumber"] = ObjDetail.VehicleNumber;
                    dr["HashKey"] = ObjDetail.HashKey;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspBatchUploadAGS";
            var parameters = new DynamicParameters();

            parameters.Add("APIKey", ObjClass.APIKey, DbType.String, ParameterDirection.Input);
          //  parameters.Add("APIReferenceNo", _configuration.GetSection("AGS:ApiKey").Value, DbType.String, ParameterDirection.Input);

            parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
            parameters.Add("Batchid", ObjClass.Batchid, DbType.Int64, ParameterDirection.Input);
            parameters.Add("TypeBatchUpload", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("DeviceId", ObjClass.DeviceId, DbType.Int64, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BatchUploadModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }





    }
}
