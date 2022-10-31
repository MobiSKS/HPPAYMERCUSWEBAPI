using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.HLFL;
using HPPay.DataModel.TMFL;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.TMFL
{
    public class TMFLRepository : ITMFLRepository
    {
        private readonly DapperContext _context;
        private string ClientCode = "TMFL"; 
        IConfiguration _configuration;
        private readonly IHostingEnvironment _hostingEnvironment;
        int ErrorCode;
        public TMFLRepository(DapperContext context, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IEnumerable<GetCardDetailsModelOutPut>> GetCardDetails([FromBody] GetCardDetailsModelInput ObjClass)
        {
            var procedureName = "UspTMFLGetCardDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("TMFLCustomerID", ObjClass.TMFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNumber", ObjClass.CardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("LimitType", ObjClass.LimitType, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCardDetailsModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<MapFacilityModelOutPut> MapFacility([FromBody] MapFacilityModelInput ObjClass)
        {
            var procedureName = "UspTMFLMapFacility";
            var parameters = new DynamicParameters();
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("TMFLCustomerID", ObjClass.TMFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPCustomerID", ObjClass.customerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FacilityNumber", ObjClass.FacilityNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNumber", ObjClass.ControlCardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("UserName", _configuration.GetSection("TMFLSettings:UserName").Value, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            MapFacilityModelOutPut storedProcedureResult = new MapFacilityModelOutPut();

            List<MapFacilityModelOutPut> storedProcedureResult1 = new List<MapFacilityModelOutPut>();
            storedProcedureResult1 = (List<MapFacilityModelOutPut>)await result.ReadAsync<MapFacilityModelOutPut>();
            storedProcedureResult.tblThirdPartyCustomers2 = (List<CardListModel>)await result.ReadAsync<CardListModel>();

            //storedProcedureResult.tblThirdPartyCustomers2 = new List<CardListModel>();
            if (storedProcedureResult1 != null && storedProcedureResult1.Count > 0)
            {
                storedProcedureResult.ClientCode = storedProcedureResult1[0].ClientCode;
                storedProcedureResult.CustomerID = storedProcedureResult1[0].CustomerID;
                storedProcedureResult.ControlCardNumber = storedProcedureResult1[0].ControlCardNumber;
                storedProcedureResult.TMFLCustomerID = storedProcedureResult1[0].TMFLCustomerID;
                storedProcedureResult.FacilityNumber = storedProcedureResult1[0].FacilityNumber;
                storedProcedureResult.ResponseMessage = storedProcedureResult1[0].ResponseMessage;
                //storedProcedureResult. = storedProcedureResult1[0].ClientCode;
            }

            return storedProcedureResult;
        }

        public async Task<IEnumerable<TMFLCreateCustomerModelOutPut>> CreateCustomer([FromBody] TMFLCreateCustomerModelInput ObjClass)
        {
            var procedureName = "usptmflCreateCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("TMFLCustomerID", ObjClass.TMFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("RecordStatus", ObjClass.RecordStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPCustomerID", ObjClass.DTPCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgNameTitle", ObjClass.CustomerTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);

            parameters.Add("PermanentAddress1", ObjClass.PermanentAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress2", ObjClass.PermanentAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress3", ObjClass.PermanentAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentLocation", ObjClass.PermanentAddressLocation, DbType.String, ParameterDirection.Input);

            parameters.Add("PermanentCityName", ObjClass.PermanentAddressCity, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentPincode", ObjClass.PermanentAddressPincode, DbType.String, ParameterDirection.Input);

            parameters.Add("PermanentStateId", ObjClass.PermanentAddressState, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentDistrictId", ObjClass.PermanentAddressDistrict, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationEmailid", ObjClass.CustomerEmail, DbType.String, ParameterDirection.Input);

            parameters.Add("CommunicationAddress1", ObjClass.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress2", ObjClass.CommunicationAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress3", ObjClass.CommunicationAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationLocation", ObjClass.CommunicationAddressLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCityName", ObjClass.CommunicationAddressCity, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationAddressDistrict, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationAddressState, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPincode", ObjClass.CommunicationAddressPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationMobileNo", ObjClass.MobileNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialTitle", ObjClass.KeyTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialFirstName", ObjClass.KeyFirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDesignation", ObjClass.KeyDesignation, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialMobile", ObjClass.KeyMobile, DbType.String, ParameterDirection.Input);
            parameters.Add("IncomeTaxPan", ObjClass.Pan_Card, DbType.String, ParameterDirection.Input);
            parameters.Add("Username", _configuration.GetSection("TMFLSettings:UserName").Value, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<TMFLCreateCustomerModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<CreateCardModelOutPut>> CreateCard([FromBody] CreateCardModelInput ObjClass)
        {
            var procedureName = "USPTMFLCreateCard";
            var parameters = new DynamicParameters();             
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPCustomerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNumber", ObjClass.ControlCardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("TMFLCustomerID", ObjClass.TMFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfVehicle", ObjClass.VehicleType, DbType.String, ParameterDirection.Input);
            parameters.Add("vehicleNumber", ObjClass.vehicleNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("registrationYear", ObjClass.registrationYear, DbType.String, ParameterDirection.Input);
            parameters.Add("CardPreference", ObjClass.cardPreferenceType, DbType.String, ParameterDirection.Input);
            parameters.Add("manufacturer", ObjClass.manufacturer, DbType.String, ParameterDirection.Input);
            parameters.Add("mobile", ObjClass.mobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("RCDoc", null, DbType.String, ParameterDirection.Input);
            //parameters.Add("RCDoc", ObjClass.RCDoc, DbType.String, ParameterDirection.Input);
            parameters.Add("UserName", _configuration.GetSection("TMFLSettings:UserName").Value, DbType.String, ParameterDirection.Input);
            parameters.Add("ErrorCode", ErrorCode, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection(); 
            return await connection.QueryAsync<CreateCardModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<consumptionRes> GetConsumptionData([FromBody] GetConsumptionDataModelInput ObjClass)
        {
            var procedureName = "UspTMFLGetConsumptionData";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("TMFLCustomerID", ObjClass.TMFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            consumptionRes storedProcedureResult = new consumptionRes();
            //List<consumptionRes> storedProcedureResult1 = new List<consumptionRes>();
            //var storedProcedureResult = new GetConsumptionDataModelOutPut();
            storedProcedureResult.headerDetails = (List<headerDetailsGetConsumptionDataModelOutput>)await result.ReadAsync<headerDetailsGetConsumptionDataModelOutput>();
            storedProcedureResult.transactionsDetails = (List<transactionsDetailsGetConsumptionDataModelOutPut>)await result.ReadAsync<transactionsDetailsGetConsumptionDataModelOutPut>();
            return storedProcedureResult;
        }



        public async Task<IEnumerable<GetCustomerBalanceModelOutPut>> GetCustomerBalance([FromBody] GetCustomerBalanceModelInput ObjClass)
        {
            var procedureName = "UspTFMLGetCustomerBalance";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("TMFLCustomerID", ObjClass.TMFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCustomerBalanceModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<IEnumerable<UpdateCardLimitModelOutPut>> CardLimit([FromBody] UpdateCardLimitModelInput ObjClass)
        {
            var procedureName = "UspTMFLSetCardLimit";
            var parameters = new DynamicParameters();
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("customerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("tmflCustomerId", ObjClass.TMFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("cardNumber", ObjClass.CardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("ccmslimittype", ObjClass.LimitType, DbType.String, ParameterDirection.Input);
            parameters.Add("CCMSlimitValue", ObjClass.LimitValue, DbType.String, ParameterDirection.Input);
            parameters.Add("UserName", _configuration.GetSection("TMFLSettings:UserName").Value, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCardLimitModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<LoyaltyRedeemRequestModelOutPut>> LoyaltyRedeemRequest([FromBody] LoyaltyRedeemRequestModelInput ObjClass)
        {
            var procedureName = "UspInsertLoyaltyRedemptionTMFL";
            var parameters = new DynamicParameters();
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input); 
            parameters.Add("DriveStars", ObjClass.DriveStars, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionId", ObjClass.TransactionId, DbType.String, ParameterDirection.Input); 
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input); 
            parameters.Add("CreatedBy", _configuration.GetSection("TMFLSettings:UserName").Value, DbType.String, ParameterDirection.Input);
            parameters.Add("TMFLCustomerID", ObjClass.TMFLCustomerID, DbType.String, ParameterDirection.Input);            
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<LoyaltyRedeemRequestModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<MapDriverMobileModelOutPut>> MapDriverMobile([FromBody] MapDriverMobileModelInput ObjClass)
        {
            var procedureName = "USPTMFLMapDriverMobile";
            var parameters = new DynamicParameters();
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("TMFLCustomerID", ObjClass.TMFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNumber", ObjClass.CardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobile, DbType.String, ParameterDirection.Input);
            parameters.Add("ManipulationType", ObjClass.ManipulationType, DbType.String, ParameterDirection.Input);
            parameters.Add("UserName", _configuration.GetSection("TMFLSettings:UserName").Value, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MapDriverMobileModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<IEnumerable<CheckCustomerStatusModelOutPut>> CheckCustomerStatus([FromBody] CheckCustomerStatusModelInput ObjClass)
        {
            var procedureName = "UspTMFLCustomerActive";
            var parameters = new DynamicParameters();
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNumber", ObjClass.ControlCardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("TMFLCustomerID", ObjClass.TMFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FacilityNumber", ObjClass.FacilityNumber, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckCustomerStatusModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<CheckCCMSRechargeStatusModelOutPut>> CheckCCMSRechargeStatus([FromBody] CheckCCMSRechargeStatusModelInput ObjClass)
        {
            var procedureName = "CheckCCMSRechargeStatus";
            var parameters = new DynamicParameters();
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNumber", ObjClass.ControlCardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("TMFLCustomerID", ObjClass.TMFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FacilityNumber", ObjClass.FacilityNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionNumber", ObjClass.TransactionNumber, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckCCMSRechargeStatusModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<IEnumerable<ProcessCustomerRechargeModelOutPut>> ProcessCustomerRecharge([FromBody] ProcessCustomerRechargeModelInput ObjClass)
        {
            var procedureName = "uspTMFLRechargeCCMS";
            var parameters = new DynamicParameters();
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNumber", ObjClass.ControlCardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("TMFLCustomerID", ObjClass.TMFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FacilityNumber", ObjClass.FacilityNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("TransactionDate", ObjClass.TransactionDate, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionNumber", ObjClass.TransactionNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Pan_Card", ObjClass.Pan_Card, DbType.String, ParameterDirection.Input);
            parameters.Add("HashKey", ObjClass.HashKey, DbType.String, ParameterDirection.Input); 
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("UserName", _configuration.GetSection("TMFLSettings:UserName").Value, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ProcessCustomerRechargeModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<HLFLGetCustomerDetailsModelOutput>> USPGetTMFLCustomerDetails([FromBody] HLFLGetCustomerDetailsModelInput ObjClass)
        {
            var procedureName = "USPGetHLFLDetails";
            var parameters = new DynamicParameters();
            parameters.Add("SourceName", "TMFL", DbType.String, ParameterDirection.Input);
            parameters.Add("AggrCustomerID", ObjClass.AggrCustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HLFLGetCustomerDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<HLFLInsertRequestResponseModel>> InsertTMFLRequestResponse([FromBody] HLFLInsertRequestResponseModelInput ObjClass)
        {
            var procedureName = "USPInsertHLFLRequestResponse";
            var parameters = new DynamicParameters();
            parameters.Add("SourceName", "TMFL", DbType.String, ParameterDirection.Input);
            parameters.Add("AggrCustomerID", ObjClass.AggrCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Request", ObjClass.Request, DbType.String, ParameterDirection.Input);
            parameters.Add("Response", ObjClass.Response, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIName", ObjClass.APIName, DbType.String, ParameterDirection.Input);
            parameters.Add("OrderId", ObjClass.OrderId, DbType.String, ParameterDirection.Input);
            parameters.Add("APIUrl", ObjClass.APIUrl, DbType.String, ParameterDirection.Input);
            parameters.Add("ResponseMessage", ObjClass.ResponseMessage, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HLFLInsertRequestResponseModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<HLFLValidateOTPOutput>> InsertTMFLRechargeRequestDetails([FromBody] HLFLValidateOTPModelInput ObjClass, decimal Amount)
        {
            var procedureName = "uspHLFLRechargeCCMS";
            var parameters = new DynamicParameters();
            parameters.Add("ClientCode", "TMFL-API", DbType.String, ParameterDirection.Input);
            parameters.Add("customerID", ObjClass.AggrCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Product", "Fuel", DbType.String, ParameterDirection.Input);
            parameters.Add("AggrID", "HPPay", DbType.String, ParameterDirection.Input);
            parameters.Add("FacilityNumber", ObjClass.HLFLFacilityNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("HLFLCustomerID", ObjClass.HLFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNumber", ObjClass.AggrControlCardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("OrderId", ObjClass.AggrRequestID, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionNumber", ObjClass.HLFLRequestID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerOTP", ObjClass.CustomerOTP, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("TransactionDate", DateTime.Today, DbType.DateTime, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HLFLValidateOTPOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


    }
}
