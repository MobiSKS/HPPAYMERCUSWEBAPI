using Dapper;
using HPPay.DataRepository.DBDapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using HPPay.DataModel.HLFL;
using HPPay.DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using HPPay.DataModel.Merchant;
using Org.BouncyCastle.Utilities.Collections;

namespace HPPay.DataRepository.HLFL
{
    public class HLFLRepository : IHLFLRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        IConfiguration _configuration;
        int ErrorCode;
        public HLFLRepository(DapperContext context, IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IEnumerable<HLFLCreateCustomerModelOutput>> HLFLCreateCustomer([FromBody] HLFLCreateCustomerModelInput ObjClass)
        { 
            var procedureName = "UspHLFLCreateCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("HLFLCustomerID", ObjClass.HLFLCustomerID, DbType.String, ParameterDirection.Input);
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
            parameters.Add("CommunicationEmailid",  ObjClass.CustomerEmail, DbType.String, ParameterDirection.Input);

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
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Username", _configuration.GetSection("HLFLSettings:UserName").Value, DbType.String, ParameterDirection.Input);
            
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HLFLCreateCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<HLFLMapFacilityModelOutPut> HLFLMapFacility([FromBody] HLFLMapFacilityModelInput ObjClass)
        {
            var procedureName = "UspHLFLMapFacility";
            var parameters = new DynamicParameters();
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("HLFLCustomerID", ObjClass.HLFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPCustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FacilityNumber", ObjClass.FacilityNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNumber", ObjClass.ControlCardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("UserName", _configuration.GetSection("HLFLSettings:UserName").Value, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
           var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            HLFLMapFacilityModelOutPut storedProcedureResult = new HLFLMapFacilityModelOutPut();

            List<HLFLMapFacilityModelOutPut> storedProcedureResult1 = new List<HLFLMapFacilityModelOutPut>();
            storedProcedureResult1 = (List<HLFLMapFacilityModelOutPut>)await result.ReadAsync<HLFLMapFacilityModelOutPut>();
            storedProcedureResult.CardListModel = (List<HLFLCardListModel>)await result.ReadAsync<HLFLCardListModel>();

            if (storedProcedureResult1 != null && storedProcedureResult1.Count > 0)
            {
                storedProcedureResult.ClientCode = storedProcedureResult1[0].ClientCode;
                storedProcedureResult.CustomerID = storedProcedureResult1[0].CustomerID;
                storedProcedureResult.ControlCardNumber = storedProcedureResult1[0].ControlCardNumber;
                storedProcedureResult.HLFLCustomerID = storedProcedureResult1[0].HLFLCustomerID;
                storedProcedureResult.FacilityNumber = storedProcedureResult1[0].FacilityNumber;
                storedProcedureResult.responseMessage = storedProcedureResult1[0].responseMessage;
                storedProcedureResult.Status = storedProcedureResult1[0].Status;
            }
            return storedProcedureResult;

        }
        public async Task<IEnumerable<HLFLCreateCardModelOutPut>> HLFLCreateCard([FromForm] HLFLCreateCardModelInput ObjClass)
        {
            var procedureName = "USPHLFLCreateCard";
            var parameters = new DynamicParameters();
            string FileNamePathIdProofFront = string.Empty;
            var ImageFileNameIdProofFront = ObjClass.RCDoc;
            if (ObjClass.RCDoc != null )
            {
                if (ObjClass.RCDoc != null && ObjClass.RCDoc.Length / 1048576.0 <= 2)
                {
                    IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".jpeg", ".bmp" };
                    var extn = Path.GetExtension(ImageFileNameIdProofFront.FileName);
                    //var ext = ImageFileNameIdProofFront.FileName.Substring(ImageFileNameIdProofFront.FileName.LastIndexOf('.'));
                    var extension = extn.ToLower();
                        if (AllowedFileExtensions.Contains(extension))
                        {
                        string contentRootPath = _hostingEnvironment.ContentRootPath;
                        FileNamePathIdProofFront = "/HLFLRcDoc/" + ObjClass.CustomerId + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                            + "_" + ObjClass.RCDoc + "_" + ImageFileNameIdProofFront.FileName;
                        string filePathIdProofFront = contentRootPath + FileNamePathIdProofFront;
                        var fileStream = new FileStream(filePathIdProofFront, FileMode.Create);
                        ImageFileNameIdProofFront.CopyTo(fileStream);
                        }
                        else
                        {
                            ErrorCode = 83;
                            List<HLFLValidateCredentialsModelOutput> hlflAPICheckDocModelOutputs = new List<HLFLValidateCredentialsModelOutput>();
                            hlflAPICheckDocModelOutputs.Add(new HLFLValidateCredentialsModelOutput
                            {

                                Status = "83",
                                ResponseMessage = "RC file type is not valid. Allowed file types are jpeg, jpg, png, BMP, and pdf"
                            }); ;

                        }
                }
                else
                {
                    ErrorCode = 82;
                    List<HLFLValidateCredentialsModelOutput> hlflAPICheckDocModelOutputs = new List<HLFLValidateCredentialsModelOutput>();
                    hlflAPICheckDocModelOutputs.Add(new HLFLValidateCredentialsModelOutput
                    {
                        Status = "82",
                        ResponseMessage = "Maximum file size allowed is 2 MB"
                    });
                }
            }
            else
            {
                ErrorCode = 85;
                List<HLFLValidateCredentialsModelOutput> hlflAPICheckDocModelOutputs = new List<HLFLValidateCredentialsModelOutput>();
                hlflAPICheckDocModelOutputs.Add(new HLFLValidateCredentialsModelOutput
                {
                    Status = "85",
                    ResponseMessage = "RC File missing"
                });              
            }
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPCustomerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNumber", ObjClass.ControlCardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("HLFLCustomerID", ObjClass.HLFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfVehicle", ObjClass.VehicleType, DbType.String, ParameterDirection.Input);
            parameters.Add("vehicleNumber", ObjClass.vehicleNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("registrationYear", ObjClass.registrationYear, DbType.String, ParameterDirection.Input);
            parameters.Add("CardPreference", ObjClass.cardPreferenceType, DbType.String, ParameterDirection.Input);
            parameters.Add("manufacturer", ObjClass.manufacturer, DbType.String, ParameterDirection.Input);
            parameters.Add("mobile", ObjClass.mobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("RCDoc", FileNamePathIdProofFront, DbType.String, ParameterDirection.Input); 
            parameters.Add("UserName", _configuration.GetSection("HLFLSettings:UserName").Value, DbType.String, ParameterDirection.Input);
            parameters.Add("ErrorCode", ErrorCode, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HLFLCreateCardModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        
        }
        public async Task<IEnumerable<HLFLCardLimitModelOutPut>> HLFLCardLimit([FromBody] HLFLCardLimitModelInput ObjClass)
        {
            var procedureName = "UspHLFLSetCardLimit";
            var parameters = new DynamicParameters();
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("customerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("HLFLCustomerId", ObjClass.HLFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("cardNumber", ObjClass.CardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("ccmslimittype", ObjClass.LimitType, DbType.String, ParameterDirection.Input);
            parameters.Add("CCMSlimitValue", ObjClass.LimitValue, DbType.String, ParameterDirection.Input);
            parameters.Add("UserName", _configuration.GetSection("HLFLSettings:UserName").Value, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HLFLCardLimitModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<HLFLMapDriverMobileModelOutPut>> HLFLMapDriverMobile([FromBody] HLFLMapDriverMobileModelInput ObjClass)
        {
            var procedureName = "USPHLFLMapDriverMobile";
            var parameters = new DynamicParameters();
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("HLFLCustomerID", ObjClass.HLFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNumber", ObjClass.CardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobile, DbType.String, ParameterDirection.Input);
            parameters.Add("ManipulationType", ObjClass.ManipulationType, DbType.String, ParameterDirection.Input);
            parameters.Add("UserName", _configuration.GetSection("HLFLSettings:UserName").Value, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HLFLMapDriverMobileModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<HLFLCheckCustomerStatusModelOutPut>> HLFLCheckCustomerStatus([FromBody] HLFLCheckCustomerStatusModelInput ObjClass)
        {
            var procedureName = "UspHLFLCustomerActive";
            var parameters = new DynamicParameters();
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("customerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNumber", ObjClass.ControlCardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("HLFLCustomerID", ObjClass.HLFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FacilityNumber", ObjClass.FacilityNumber, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HLFLCheckCustomerStatusModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<HLFLCheckCCMSRechargeStatusModelOutPut>> HLFLCheckCCMSRechargeStatus([FromBody] HLFLCheckCCMSRechargeStatusModelInPut ObjClass)
        {
            var procedureName = "uspHLFLCheckCCMSRechargeStatus";
            var parameters = new DynamicParameters();
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNumber", ObjClass.ControlCardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("HLFLCustomerID", ObjClass.HLFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FacilityNumber", ObjClass.FacilityNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionNumber", ObjClass.TransactionNumber, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HLFLCheckCCMSRechargeStatusModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<HLFLProcessCustomerRechargeModelOutPut>> HLFLProcessCustomerRecharge([FromBody] HLFLProcessCustomerRechargeModelInPut ObjClass)
        {
            var procedureName = "uspHLFLRechargeCCMS";
            var parameters = new DynamicParameters();
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNumber", ObjClass.ControlCardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("HLFLCustomerID", ObjClass.HLFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FacilityNumber", ObjClass.FacilityNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionDate", ObjClass.TransactionDate, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionNumber", ObjClass.TransactionNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Pan_Card", ObjClass.Pan_Card, DbType.String, ParameterDirection.Input);
            parameters.Add("HashKey", ObjClass.HashKey, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("UserName", _configuration.GetSection("HLFLSettings:UserName").Value, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HLFLProcessCustomerRechargeModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        } 
        public async Task<HLFLValidateCustomerModelOutPut> HLFLValidateCustomer([FromBody] HLFLValidateCustomerModelInput ObjClass)
        {
            var procedureName = "UspValidateCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("Pan_Card", ObjClass.PAN, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure); 

            HLFLValidateCustomerModelOutPut storedProcedureResult = new HLFLValidateCustomerModelOutPut();
            List<HLFLValidateCustomerModelOutPut> storedProcedureResult1 = new List<HLFLValidateCustomerModelOutPut>();
            storedProcedureResult1 = (List<HLFLValidateCustomerModelOutPut>)await result.ReadAsync<HLFLValidateCustomerModelOutPut>();
            storedProcedureResult.CustomerList = (List<HLFLCustomerList>)await result.ReadAsync<HLFLCustomerList>();

            if (storedProcedureResult1 != null && storedProcedureResult1.Count > 0)
            {
                storedProcedureResult.ClientCode = storedProcedureResult1[0].ClientCode; 
                storedProcedureResult.Status = storedProcedureResult1[0].Status;
                storedProcedureResult.ResponseMessage = storedProcedureResult1[0].ResponseMessage;

            }

            return storedProcedureResult;
        }
        public async Task<HLFLGetProductRSPModelOutPut> HLFLGetProductRSP([FromBody] HLFLGetProductRSPModelInPut ObjClass)
        {
            var procedureName = "UspHLFLGetProductRSP";
            var parameters = new DynamicParameters();
            parameters.Add("ClientCode", ObjClass.ClientCode, DbType.String, ParameterDirection.Input);
            parameters.Add("merchantID", ObjClass.merchantId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure); 
            HLFLGetProductRSPModelOutPut storedProcedureResult = new HLFLGetProductRSPModelOutPut();
            List<HLFLGetProductRSPModelOutPut> storedProcedureResult1 = new List<HLFLGetProductRSPModelOutPut>();
            storedProcedureResult1 = (List<HLFLGetProductRSPModelOutPut>)await result.ReadAsync<HLFLGetProductRSPModelOutPut>();
            storedProcedureResult.ProductList = (List<HLFLProductList>)await result.ReadAsync<HLFLProductList>();

            if (storedProcedureResult1 != null && storedProcedureResult1.Count > 0)
            {
                storedProcedureResult.ClientCode = storedProcedureResult1[0].ClientCode;
                storedProcedureResult.RetailOutletName = storedProcedureResult1[0].RetailOutletName;
                storedProcedureResult.merchantID = storedProcedureResult1[0].merchantID;
                storedProcedureResult.responseMessage = storedProcedureResult1[0].responseMessage;
                storedProcedureResult.Status = storedProcedureResult1[0].Status;

            }
            return storedProcedureResult;
        }
        public async Task<IEnumerable<HLFLGetCustomerDetailsModelOutput>> USPGetHLFLCustomerDetails([FromBody] HLFLGetCustomerDetailsModelInput ObjClass)
        {
            var procedureName = "USPGetHLFLDetails";
            var parameters = new DynamicParameters();
            parameters.Add("SourceName", "HLFL", DbType.String, ParameterDirection.Input);
            parameters.Add("AggrCustomerID", ObjClass.AggrCustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HLFLGetCustomerDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<HLFLInsertRequestResponseModel>> InsertHLFLRequestResponse([FromBody] HLFLInsertRequestResponseModelInput ObjClass)
        {
            var procedureName = "USPInsertHLFLRequestResponse";
            var parameters = new DynamicParameters();
            parameters.Add("SourceName", "HLFL", DbType.String, ParameterDirection.Input);
            parameters.Add("AggrCustomerID", ObjClass.AggrCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Request", ObjClass.Request, DbType.String, ParameterDirection.Input);
            parameters.Add("Response", ObjClass.Response, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIName", ObjClass.APIName, DbType.String, ParameterDirection.Input);
            parameters.Add("OrderId", ObjClass.OrderId, DbType.String, ParameterDirection.Input);
            parameters.Add("APIUrl", ObjClass.APIUrl, DbType.String, ParameterDirection.Input);
            parameters.Add("HLFLRequestID", ObjClass.HLFLRequestID, DbType.String, ParameterDirection.Input); 
            parameters.Add("ResponseMessage", ObjClass.ResponseMessage, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HLFLInsertRequestResponseModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<HLFLValidateOTPOutput>> InsertHLFLRechargeRequestDetails([FromBody] HLFLValidateOTPModelInput ObjClass,decimal Amount)
        {
            var procedureName = "uspHLFLRechargeCCMS";
            var parameters = new DynamicParameters();
            parameters.Add("ClientCode", "HLFL-API", DbType.String, ParameterDirection.Input);
            parameters.Add("customerID", ObjClass.AggrCustomerID, DbType.String, ParameterDirection.Input);
           // parameters.Add("Product", "Fuel", DbType.String, ParameterDirection.Input); 
           //parameters.Add("AggrID", "HPPay", DbType.String, ParameterDirection.Input);
            parameters.Add("FacilityNumber", ObjClass.HLFLFacilityNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("HLFLCustomerID", ObjClass.HLFLCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNumber", ObjClass.AggrControlCardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("OrderId", ObjClass.AggrRequestID, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionNumber", ObjClass.HLFLRequestID, DbType.String, ParameterDirection.Input);
          //  parameters.Add("CustomerOTP", ObjClass.CustomerOTP, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.DDRequestAmount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("TransactionDate", DateTime.Today, DbType.DateTime, ParameterDirection.Input); 
            parameters.Add("HashKey", "", DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HLFLValidateOTPOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CheckIfHLFLUserModelOutput>> CheckIfHLFLUser([FromBody] CheckIfHLFLUserModelInput ObjClass)
        {
            var procedureName = "uspCheckIfHLFLCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("SourceName", "HLFL", DbType.String, ParameterDirection.Input);
            parameters.Add("customerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("UserIp", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckIfHLFLUserModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<HLFLCheckTransactionStatusOutPutModel>> HLFLCheckTransactionStatus([FromBody] HLFLCheckTransactionStatusInputModel ObjClass)
        {
            var procedureName = "uspHLFLCheckTransactionStatus";
            var parameters = new DynamicParameters();
            parameters.Add("SourceName", "HLFL", DbType.String, ParameterDirection.Input);
            parameters.Add("customerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("OrderId", ObjClass.OrderId, DbType.String, ParameterDirection.Input);
            parameters.Add("HLFLReferenceId", ObjClass.HLFLReferenceId, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionStatus", ObjClass.TransactionStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionSource", ObjClass.TransactionSource, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("UserIp", ObjClass.Userip, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HLFLCheckTransactionStatusOutPutModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<HLFLGetStatusAndSourceOutPutModel> HLFLGetStatusAndSource([FromBody] HLFLGetStatusAndSourceInPutModel ObjClass)
        {
            var procedureName = "uspHLFLGetStatusAndSource";
            var parameters = new DynamicParameters(); 
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("UserIp", ObjClass.Userip, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new HLFLGetStatusAndSourceOutPutModel();
            storedProcedureResult.GetStatus = (List<HLFLGetStatusOutput>)await result.ReadAsync<HLFLGetStatusOutput>();
            storedProcedureResult.GetSourceOutPut = (List<HLFLGetSourceOutPut>)await result.ReadAsync<HLFLGetSourceOutPut>();
            storedProcedureResult.GetEmail = (List<HLFLEmailOutPut>)await result.ReadAsync<HLFLEmailOutPut>();
            return storedProcedureResult;             
        }

        public async Task<IEnumerable<HLFLInsertSendEmailLogOutModel>> uspHLFLInsertSendEmailLog([FromBody] HLFLInsertSendEmailLogInputModel ObjClass)
        {
            var procedureName = "uspCheckIfHLFLCustomer";
            var parameters = new DynamicParameters(); 
            parameters.Add("customerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("OrderId", ObjClass.OrderId, DbType.String, ParameterDirection.Input);
            parameters.Add("HLFLReferenceId", ObjClass.HLFLReferenceId, DbType.String, ParameterDirection.Input);
            parameters.Add("EmailTo", ObjClass.EmailTo, DbType.String, ParameterDirection.Input);
            parameters.Add("EmailCC", ObjClass.EmailCC, DbType.String, ParameterDirection.Input);
            parameters.Add("EmailSubject", ObjClass.EmailSubject, DbType.String, ParameterDirection.Input);
            parameters.Add("EmailMessage", ObjClass.EmailMessage, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("UserIp", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HLFLInsertSendEmailLogOutModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
