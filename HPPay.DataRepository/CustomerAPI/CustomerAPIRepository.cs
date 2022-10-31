using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.Card;
using HPPay.DataModel.CustomerAPI;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataRepository.CustomerAPI
{
    public class CustomerAPIRepository : ICustomerAPIRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public CustomerAPIRepository(DapperContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
      }
        public async Task<IEnumerable<CustomerAPICheckVechileNoModelOutput>> CustomerAPICheckVechileNo([FromBody] CustomerAPICheckVechileNoModelInput ObjClass)
        {
            var procedureName = "UspCheckVechileNo";
            var parameters = new DynamicParameters();
            parameters.Add("VehicleRegistrationNumber", ObjClass.VehicleRegistrationNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("MethodName", "CustomerAPICheckVechileNo", DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPICheckVechileNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPIGetCustomerBalanceModelOutput>> GetCustomerBalance([FromBody] CustomerAPIGetCustomerBalanceModelInput ObjClass)
        { 
            var procedureName = "UspCustomerAPIGetCustomerBalance";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);        
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPIGetCustomerBalanceModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPIGetCardBalanceModelOutput>> GetCardBalance([FromBody] CustomerAPIGetCardBalanceModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIGetCardBalance";
            var parameters = new DynamicParameters();
            parameters.Add("customerID", ObjClass.customerID, DbType.String, ParameterDirection.Input);
            parameters.Add("cardNumbers", ObjClass.cardNumbers, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPIGetCardBalanceModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<CustomerAPIGetCustomerDetailsByMobileNoModelOutput> GetCustomerDetailsByMobileNo([FromBody] CustomerAPIGetCustomerDetailsByMobileNoModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIGetCustomerDetailsByMobileNo";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("mobile", ObjClass.mobile, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new CustomerMainResponseList();
            storedProcedureResult.customerDtlsTemp = (List<CustomerDetails>)await result.ReadAsync<CustomerDetails>();
            storedProcedureResult.mainResponse = (List<MainResponse>)await result.ReadAsync<MainResponse>();

            CustomerAPIGetCustomerDetailsByMobileNoModelOutput customerAPIGetCustomerDetailsByMobileNoModelOutput = new CustomerAPIGetCustomerDetailsByMobileNoModelOutput();
            customerAPIGetCustomerDetailsByMobileNoModelOutput.customerDtls = storedProcedureResult.customerDtlsTemp;
            customerAPIGetCustomerDetailsByMobileNoModelOutput.responseCode = storedProcedureResult.mainResponse.FirstOrDefault().responseCode;
            customerAPIGetCustomerDetailsByMobileNoModelOutput.responseMessage = storedProcedureResult.mainResponse.FirstOrDefault().responseMessage;
            return customerAPIGetCustomerDetailsByMobileNoModelOutput;

        }

        public async Task<IEnumerable<CustomerAPIBlockCardsModelOutput>> BlockCards([FromBody] CustomerAPIBlockCardsModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIBlockCards";
            var parameters = new DynamicParameters();
            parameters.Add("customerID", ObjClass.customerID, DbType.String, ParameterDirection.Input);
            parameters.Add("cardNumber", ObjClass.cardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("UserName", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPIBlockCardsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPIUnblockCardsModelOutput>> UnblockCards([FromBody] CustomerAPIUnblockCardsModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIUnblockCards";
            var parameters = new DynamicParameters();
            parameters.Add("customerID", ObjClass.customerID, DbType.String, ParameterDirection.Input);
            parameters.Add("cardNumber", ObjClass.cardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPIUnblockCardsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPIGenerateMPinModelOutput>> GenerateMPin([FromBody] CustomerAPIGenerateMPinModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIGenerateMPin";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("password", ObjClass.Password, DbType.String, ParameterDirection.Input);
            parameters.Add("userName", ObjClass.Username, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPIGenerateMPinModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        //public async Task<IEnumerable<CustomerAPICustomerAPIGetHSDTransactionDetailsModelOutput>> CustomerAPIGetHSDTransactionDetails([FromBody] CustomerAPICustomerAPIGetHSDTransactionDetailsModelInput ObjClass)
        //{
        //    var procedureName = "UspCustomerAPIGenerateMPin";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("CustomerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
        //    parameters.Add("password", ObjClass.Password, DbType.String, ParameterDirection.Input);
        //    parameters.Add("userName", ObjClass.Username, DbType.String, ParameterDirection.Input);
        //    using var connection = _context.CreateConnection();
        //    return await connection.QueryAsync<CustomerAPICustomerAPIGetHSDTransactionDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        //}

        public async Task<IEnumerable<CustomerAPIMapCardlessModelOutput>> MapCardless([FromBody] CustomerAPIMapCardlessModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIMapCardless";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("customerID", ObjClass.customerID, DbType.String, ParameterDirection.Input);
            parameters.Add("cardNumber", ObjClass.cardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("mobile", ObjClass.mobile, DbType.String, ParameterDirection.Input);
            parameters.Add("manipulationType", ObjClass.manipulationType, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleNumber", ObjClass.VehicleNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("PONumber", ObjClass.PONumber, DbType.String, ParameterDirection.Input);
            parameters.Add("FastlaneTagNumber", ObjClass.FastlaneTagNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Validity", ObjClass.Validity, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPIMapCardlessModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<Tuple<List<CustomerAPIGetTransactionStatus>, List<CustomerAPIGetTransactionsModelOutput>>> GetTransactions([FromBody] CustomerAPIGetTransactionsModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIGetTransactions";
            var parameters = new DynamicParameters();
            parameters.Add("customerID", ObjClass.customerID, DbType.String, ParameterDirection.Input);
            parameters.Add("childID", ObjClass.childID, DbType.String, ParameterDirection.Input);
            parameters.Add("fromdate", ObjClass.fromdate, DbType.String, ParameterDirection.Input);
            parameters.Add("todate", ObjClass.todate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            List<CustomerAPIGetTransactionStatus> customerAPIGetTransactionStatuses = new List<CustomerAPIGetTransactionStatus>();
            List<CustomerAPIGetTransactionsModelOutput> customerAPIGetTransactionsModelOutput = new List<CustomerAPIGetTransactionsModelOutput>();
            var storedProcedureResult = new CustomerAPIGetTransactionsFinalOutputModel();
            customerAPIGetTransactionStatuses = (List<CustomerAPIGetTransactionStatus>)await result.ReadAsync<CustomerAPIGetTransactionStatus>();
            customerAPIGetTransactionsModelOutput = (List<CustomerAPIGetTransactionsModelOutput>)await result.ReadAsync<CustomerAPIGetTransactionsModelOutput>();

            storedProcedureResult.customerAPIGetTransactionStatus.AddRange(customerAPIGetTransactionStatuses);
            storedProcedureResult.customerAPIGetTransactionsModelOutput.AddRange(customerAPIGetTransactionsModelOutput);
            return Tuple.Create(storedProcedureResult.customerAPIGetTransactionStatus, storedProcedureResult.customerAPIGetTransactionsModelOutput);
        }

        public async Task<IEnumerable<CustomerAPIGetCardLimitModelOutput>> GetCardLimit([FromBody] CustomerAPIGetCardLimitModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIGetCardLimit";
            var parameters = new DynamicParameters();
            parameters.Add("customerID", ObjClass.customerID, DbType.String, ParameterDirection.Input);
            parameters.Add("cardNumber", ObjClass.cardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("limitType", ObjClass.limitType, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPIGetCardLimitModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPISetCardLimitModelOutput>> SetCardLimit([FromBody] CustomerAPISetCardLimitModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPISetCardLimit";
            var parameters = new DynamicParameters();
            parameters.Add("customerID", ObjClass.customerID, DbType.String, ParameterDirection.Input);
            parameters.Add("cardNumber", ObjClass.cardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("mobile", ObjClass.mobile, DbType.String, ParameterDirection.Input);
            parameters.Add("limitType", ObjClass.limitType, DbType.String, ParameterDirection.Input);
            parameters.Add("limitValue", ObjClass.limitValue, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("TransactionId", ObjClass.TransactionId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPISetCardLimitModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPIHotlistReactivateCardModelOutput>> HotlistReactivateCard([FromBody] CustomerAPIHotlistReactivateCardModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIHotlistReactivateCard";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("cardNumber", ObjClass.cardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNumber", ObjClass.ReferenceNumber, DbType.String, ParameterDirection.Input);           
            parameters.Add("StatusCode", ObjClass.StatusCode, DbType.Int32, ParameterDirection.Input);
            parameters.Add("StatusChangeReasonCode", ObjClass.StatusChangeReasonCode, DbType.Int32, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPIHotlistReactivateCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPIHotlistReactivateCustomerModelOutput>> HotlistReactivateCustomer([FromBody] CustomerAPIHotlistReactivateCustomerModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIHotlistReactivateCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNumber", ObjClass.ReferenceNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("StatusCode", ObjClass.StatusCode, DbType.Int32, ParameterDirection.Input);
            parameters.Add("StatusChangeReasonCode", ObjClass.StatusChangeReasonCode, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPIHotlistReactivateCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPISetCardAddOnLimitModelOutput>> SetCardAddOnLimit([FromBody] CustomerAPISetCardAddOnLimitModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPISetCardAddOnLimit";
            var parameters = new DynamicParameters();
            
            parameters.Add("customerID", ObjClass.customerID, DbType.String, ParameterDirection.Input);
            parameters.Add("mobile", ObjClass.mobile, DbType.String, ParameterDirection.Input);
            parameters.Add("limitType", ObjClass.limitType, DbType.String, ParameterDirection.Input);
            parameters.Add("limitValue", ObjClass.limitValue, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("TransactionId", ObjClass.TransactionId, DbType.String, ParameterDirection.Input);
            parameters.Add("cardNumber", ObjClass.cardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPISetCardAddOnLimitModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPIIsCustomerActiveModelOutput>> IsCustomerActive([FromBody] CustomerAPIIsCustomerActiveModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIIsCustomerActive";
            var parameters = new DynamicParameters();
            parameters.Add("customerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPIIsCustomerActiveModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPITransactionQueryStatusWithDetailsModelOutput>> TransactionQueryStatusWithDetails([FromBody] CustomerAPITransactionQueryStatusWithDetailsModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPITransactionQueryStatusWithDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("cardNumber", ObjClass.cardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("transactionId", ObjClass.TransactionId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPITransactionQueryStatusWithDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPIGetCustomerHotlistStatusModelOutput>>GetCustomerHotlistStatus([FromBody] CustomerAPIGetCustomerHotlistStatusModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIGetCustomerHotlistStatus";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPIGetCustomerHotlistStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPIDehotlistCustomerWithPANModelOutput>> DehotlistCustomerWithPAN([FromBody] CustomerAPIDehotlistCustomerWithPANModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIDehotlistCustomerWithPAN";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("PAN", ObjClass.PAN, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPIDehotlistCustomerWithPANModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPICheckCustomerActivityModelOutput>> CheckCustomerActivity([FromBody] CustomerAPICheckCustomerActivityModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPICheckCustomerActivity";
            var parameters = new DynamicParameters();
            parameters.Add("VehicleNumber", ObjClass.VehicleNumber, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPICheckCustomerActivityModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPIAggCustomerCreationModelOutput>>AggCustomerCreation([FromBody] CustomerAPIAggCustomerCreationModelInput ObjClass)
        {

            var procedureName = "UspCustomerAPIAggCustomerCreation";
             var parameters = new DynamicParameters();

            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("RecordStatus", ObjClass.OAggCustomer.RecordStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPCustomerID", ObjClass.OAggCustomer.DTPCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerTitle", ObjClass.OAggCustomer.CustomerTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.OAggCustomer.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress1", ObjClass.OAggCustomer.PermanentAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress2", ObjClass.OAggCustomer.PermanentAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress3", ObjClass.OAggCustomer.PermanentAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddressLocation", ObjClass.OAggCustomer.PermanentAddressLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddressCity", ObjClass.OAggCustomer.PermanentAddressCity, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddressDistrict", ObjClass.OAggCustomer.PermanentAddressDistrict, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PermanentAddressState", ObjClass.OAggCustomer.PermanentAddressState, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PermanentAddressPincode", ObjClass.OAggCustomer.PermanentAddressPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerEmail", ObjClass.OAggCustomer.CustomerEmail, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress1", ObjClass.OAggCustomer.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress2", ObjClass.OAggCustomer.CommunicationAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress3", ObjClass.OAggCustomer.CommunicationAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddressLocation", ObjClass.OAggCustomer.CommunicationAddressLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddressCity", ObjClass.OAggCustomer.CommunicationAddressCity, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddressDistrict", ObjClass.OAggCustomer.CommunicationAddressDistrict, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationAddressState", ObjClass.OAggCustomer.CommunicationAddressState, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationAddressPincode", ObjClass.OAggCustomer.CommunicationAddressPincode, DbType.Int32, ParameterDirection.Input);
            parameters.Add("MobileNumber", ObjClass.OAggCustomer.MobileNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.OAggCustomer.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyTitle", ObjClass.OAggCustomer.KeyTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyFirstName", ObjClass.OAggCustomer.KeyFirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyDesignation", ObjClass.OAggCustomer.KeyDesignation, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyMobile", ObjClass.OAggCustomer.KeyMobile, DbType.String, ParameterDirection.Input);
            parameters.Add("PAN", ObjClass.OAggCustomer.PAN, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new CustomerAPIAggCustomerCreationModelOutput();
            storedProcedureResult.custRes = (List<GetcustRes>)await result.ReadAsync<GetcustRes>();
            CustomerAPIAggCustomerCreationModelOutput objcustres = new CustomerAPIAggCustomerCreationModelOutput();
            List<CustomerAPIAggCustomerCreationModelOutput> objcustre = new List<CustomerAPIAggCustomerCreationModelOutput>();
            objcustres.custRes=storedProcedureResult.custRes;
            //objcustres.responseMessage = storedProcedureResult.custRes.FirstOrDefault().responseMessage;
            //objcustres.responseCode = storedProcedureResult.custRes.FirstOrDefault().responseCode;
            //objcustres.dtpCustomerId = storedProcedureResult.custRes.FirstOrDefault().dtpCustomerId;
            objcustre.Add(objcustres);
            return objcustre;
        }
        public async Task<IEnumerable<CustomerAPISetCardAllLimitModelOutput>> SetCardAllLimit([FromBody] CustomerAPISetCardAllLimitModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPISetCardAllLimit";
            var parameters = new DynamicParameters();

            parameters.Add("customerID", ObjClass.customerID, DbType.String, ParameterDirection.Input);
            parameters.Add("cardNumber", ObjClass.cardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("saleTransactionLimit", ObjClass.saleTransactionLimit, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("dailyLimit", ObjClass.dailyLimit, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("monthlyLimit", ObjClass.monthlyLimit, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("ccmslimittype", ObjClass.ccmslimittype, DbType.String, ParameterDirection.Input);
            parameters.Add("CCMSlimitValue", string.IsNullOrEmpty(ObjClass.CCMSlimitValue) ? "-1.00": ObjClass.CCMSlimitValue, DbType.Decimal, ParameterDirection.Input);
           // parameters.Add("transactionId", ObjClass.TransactionId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPISetCardAllLimitModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPITransactionQueryStatusModelOutput>> TransactionQueryStatus([FromBody] CustomerAPITransactionQueryStatusModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPITransactionQueryStatus";
            var parameters = new DynamicParameters();
            parameters.Add("customerID", ObjClass.customerID, DbType.String, ParameterDirection.Input);
            parameters.Add("cardNumber", ObjClass.cardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("transactionId", ObjClass.transactionId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPITransactionQueryStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPIUnblockUserCardPINModelOutput>>UnblockUserCardPIN([FromBody] CustomerAPIUnblockUserCardPINModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIUnblockUserCardPIN";
            var parameters = new DynamicParameters();
            parameters.Add("cardNumber", ObjClass.cardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPIUnblockUserCardPINModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<CustomerAPIGetProductRSPModelFInalOutput> GetProductRSP([FromBody] CustomerAPIGetProductRSPModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIGetProductRSP";
            var parameters = new DynamicParameters();
            parameters.Add("merchantID", ObjClass.merchantID, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new CustomerAPIGetProductRSPModelOutput();
            storedProcedureResult.merchantDetails = (List<MerchantRetailOutletDetails>)await result.ReadAsync<MerchantRetailOutletDetails>();
            storedProcedureResult.productList = (List<ProductList>)await result.ReadAsync<ProductList>();

            CustomerAPIGetProductRSPModelFInalOutput customerAPIGetProductRSPModelFInalOutput = new CustomerAPIGetProductRSPModelFInalOutput();
            customerAPIGetProductRSPModelFInalOutput.productList = storedProcedureResult.productList;
            customerAPIGetProductRSPModelFInalOutput.retailOutletName = storedProcedureResult.merchantDetails.FirstOrDefault().retailOutletName;
            customerAPIGetProductRSPModelFInalOutput.merchantID = storedProcedureResult.merchantDetails.FirstOrDefault().merchantID;
            customerAPIGetProductRSPModelFInalOutput.responseMessage = storedProcedureResult.merchantDetails.FirstOrDefault().responseMessage;
            customerAPIGetProductRSPModelFInalOutput.responseCode = storedProcedureResult.merchantDetails.FirstOrDefault().responseCode;
            return customerAPIGetProductRSPModelFInalOutput;
        }

        public async Task<CustomerAPIGetConsumptionDataModelOutput> GetConsumptionData([FromBody] CustomerAPIGetConsumptionDataModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIGetConsumptionData";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new CustomerAPIGetConsumptionDataModelOutput();
            storedProcedureResult.consumptionRes = (List<GetHeaderDetails>)await result.ReadAsync<GetHeaderDetails>();
            storedProcedureResult.transactionsDetails = (List<GetTransactionDetails>)await result.ReadAsync<GetTransactionDetails>();

            CustomerAPIGetConsumptionDataModelOutput CustomerAPIGetConsumptionDataModelOutput = new CustomerAPIGetConsumptionDataModelOutput();
            CustomerAPIGetConsumptionDataModelOutput.consumptionRes = storedProcedureResult.consumptionRes;
            CustomerAPIGetConsumptionDataModelOutput.transactionsDetails = storedProcedureResult.transactionsDetails;
            return CustomerAPIGetConsumptionDataModelOutput;

        }
        public async Task<IEnumerable<CustomerAPICustomerHotlistRequestModelOutput>> CustomerHotlistRequest([FromBody] CustomerAPICustomerHotlistRequestModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPICustomerHotlistRequest";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleNumber", ObjClass.VehicleNumber, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPICustomerHotlistRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<CustomerAPICreateCardModelOutput>> CreateCard([FromForm] CustomerAPICreateCardModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPICreateCard";
            var parameters = new DynamicParameters();

            string FileNamePathIdProofFront = string.Empty;
            var ImageFileNameIdProofFront = ObjClass.RCDoc;
            if (ImageFileNameIdProofFront.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".jpeg", ".bmp" };
                var ext = ImageFileNameIdProofFront.FileName.Substring(ImageFileNameIdProofFront.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath =  _hostingEnvironment.ContentRootPath;
                    FileNamePathIdProofFront = "/CustomerKYCImage/" + ObjClass.CustomerID + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.RCDoc + "_" + ImageFileNameIdProofFront.FileName;
                    string filePathIdProofFront = contentRootPath + FileNamePathIdProofFront;
                    var fileStream = new FileStream(filePathIdProofFront, FileMode.Create);
                    ImageFileNameIdProofFront.CopyTo(fileStream);
                }
            }

          
                parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
                parameters.Add("CustomerId", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
                parameters.Add("TypeOfVehicle", ObjClass.vehicleType, DbType.String, ParameterDirection.Input);
                parameters.Add("vehicleNumber", ObjClass.vehicleNumber, DbType.String, ParameterDirection.Input);
                parameters.Add("registrationYear", ObjClass.registrationYear, DbType.String, ParameterDirection.Input);
                parameters.Add("manufacturer", ObjClass.manufacturer, DbType.String, ParameterDirection.Input);
                parameters.Add("mobile", ObjClass.mobileNo, DbType.String, ParameterDirection.Input);
                parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);       
                parameters.Add("CardPreference", ObjClass.cardPreferenceType.ToLower()=="digital"?"Cardless":"Card", DbType.String, ParameterDirection.Input);
                parameters.Add("RCDoc", FileNamePathIdProofFront, DbType.String, ParameterDirection.Input);
                using var connection = _context.CreateConnection();
                return await connection.QueryAsync<CustomerAPICreateCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            }
        public async Task<IEnumerable<CustomerAPIParentChildBalanceTransferModelOutput>> ParentChildBalanceTransfer([FromBody] CustomerAPIParentChildBalanceTransferModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIParentChildBalanceTransfer";
            var parameters = new DynamicParameters();
            parameters.Add("userName", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("password", ObjClass.Password, DbType.String, ParameterDirection.Input);
            parameters.Add("ParentCustomerID", ObjClass.ParentCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ChildCustomerID", ObjClass.ChildCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("TransferAmount", ObjClass.TransferAmount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("BalanceTransType", ObjClass.BalanceTransType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionId", ObjClass.TransactionId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPIParentChildBalanceTransferModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPIChildtoParentBalanceTransferRequestModelOutput>> ChildtoParentBalanceTransferRequest([FromBody] CustomerAPIChildtoParentBalanceTransferRequestModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIChildtoParentBalanceTransferRequest";
            var parameters = new DynamicParameters();
            parameters.Add("userName", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("password", ObjClass.Password, DbType.String, ParameterDirection.Input);
            parameters.Add("ParentCustomerID", ObjClass.ParentCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ChildCustomerID", ObjClass.ChildCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("TransferAmount", ObjClass.TransferAmount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("BalanceTransType", ObjClass.BalanceTransType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionId", ObjClass.TransactionId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPIChildtoParentBalanceTransferRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CustomerAPICheckBalanceTransferStatusModelOutput>> CheckBalanceTransferStatus([FromBody] CustomerAPICheckBalanceTransferStatusModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPICheckBalanceTransferStatus";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("Password", ObjClass.Password, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionId", ObjClass.TransactionId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPICheckBalanceTransferStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPICheckLoyaltyRedeemStatusModelOutput>> CheckLoyaltyRedeemStatus([FromBody] CustomerAPICheckLoyaltyRedeemStatusModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPICheckLoyaltyRedeemStatus";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionId", ObjClass.TransactionId, DbType.String, ParameterDirection.Input);
            parameters.Add("Password", ObjClass.Password, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPICheckLoyaltyRedeemStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPILoyaltyRedeemRequestModelOutput>> LoyaltyRedeemRequest([FromBody] CustomerAPILoyaltyRedeemRequestModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPILoyaltyRedeemRequest";
            var parameters = new DynamicParameters();
            parameters.Add("username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("password", ObjClass.Password, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("DriveStars", ObjClass.DriveStars, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionId", ObjClass.TransactionId, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPILoyaltyRedeemRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPIChildtoParentBalanceTransferModelOutput>> ChildtoParentBalanceTransfer([FromBody] CustomerAPIChildtoParentBalanceTransferModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIChildtoParentBalanceTransfer";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("ParentCustomerID", ObjClass.ParentCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ChildCustomerID", ObjClass.ChildCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("TransferAmount", ObjClass.TransferAmount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("BalanceTransType", ObjClass.BalanceTransType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPIChildtoParentBalanceTransferModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAPIParentChildBalanceTransferV2ModelOutput>> ParentChildBalanceTransferV2([FromBody] CustomerAPIParentChildBalanceTransferV2ModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIParentChildBalanceTransferV2";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("ParentCustomerID", ObjClass.ParentCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ChildCustomerID", ObjClass.ChildCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("TransferAmount", ObjClass.TransferAmount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("BalanceTransType", ObjClass.BalanceTransType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("TransactionId", ObjClass.TransactionId, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPIParentChildBalanceTransferV2ModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<Tuple<List<CustomerAPIGetTransactionV2Status>, List<CustomerAPIGetTransactionsV2ModelOutput>>> GetTransactionsV2([FromBody] CustomerAPIGetTransactionsV2ModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIGetTransactionsV2";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("password", ObjClass.Password, DbType.String, ParameterDirection.Input);
            parameters.Add("customerID", ObjClass.customerID, DbType.String, ParameterDirection.Input);
            parameters.Add("childID", ObjClass.childID, DbType.String, ParameterDirection.Input);
            parameters.Add("fromdate", ObjClass.fromdate, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("todate", ObjClass.todate, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            List<CustomerAPIGetTransactionV2Status> customerAPIGetTransactionStatuses = new List<CustomerAPIGetTransactionV2Status>();
            List<CustomerAPIGetTransactionsV2ModelOutput> customerAPIGetTransactionsModelOutput = new List<CustomerAPIGetTransactionsV2ModelOutput>();
            var storedProcedureResult = new CustomerAPIGetTransactionsV2FinalOutputModel();
            customerAPIGetTransactionStatuses = (List<CustomerAPIGetTransactionV2Status>)await result.ReadAsync<CustomerAPIGetTransactionV2Status>();
            customerAPIGetTransactionsModelOutput = (List<CustomerAPIGetTransactionsV2ModelOutput>)await result.ReadAsync<CustomerAPIGetTransactionsV2ModelOutput>();

            storedProcedureResult.customerAPIGetTransactionV2Status.AddRange(customerAPIGetTransactionStatuses);
            storedProcedureResult.customerAPIGetTransactionsV2ModelOutput.AddRange(customerAPIGetTransactionsModelOutput);
            return Tuple.Create(storedProcedureResult.customerAPIGetTransactionV2Status, storedProcedureResult.customerAPIGetTransactionsV2ModelOutput);
        }

        public async Task<IEnumerable<CustomerAPIGenerateOTPModelOutput>> CustomerAPIGenerateTransactionOTP([FromBody] CustomerAPIGenerateOTPModelInput ObjClass)
        {
            var procedureName = "UspCustomerAPIGenerateOTP";
            var parameters = new DynamicParameters();
            parameters.Add("Mobileno", ObjClass.MobileNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAPIGenerateOTPModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

    }    
}
