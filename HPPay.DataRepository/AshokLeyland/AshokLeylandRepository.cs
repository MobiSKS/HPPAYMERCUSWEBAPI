using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.AshokLeyland;
using HPPay.DataRepository.DBDapper;
using HPPay.Infrastructure.CommonClass;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;


namespace HPPay.DataRepository.AshokLeyland
{
    public class AshokLeylandRepository : IAshokLeylandRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public AshokLeylandRepository(DapperContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IEnumerable<ALDealerEnrollmentModelOutput>> InsertALDealerEnrollment([FromBody] ALDealerEnrollmentModelInput ObjClass)
        {
            var procedureName = "UspInsertALDealerEnrollment";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("DealerName", ObjClass.DealerName, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Address1", ObjClass.Address1, DbType.String, ParameterDirection.Input);
            parameters.Add("Address2", ObjClass.Address2, DbType.String, ParameterDirection.Input);
            parameters.Add("Address3", ObjClass.Address3, DbType.String, ParameterDirection.Input);
            parameters.Add("StateId", ObjClass.StateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CityName", ObjClass.CityName, DbType.String, ParameterDirection.Input);
            parameters.Add("DistrictId", ObjClass.DistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Pin", ObjClass.Pin, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("EmailId", ObjClass.EmailId, DbType.String, ParameterDirection.Input);
            parameters.Add("Createdby", ObjClass.Createdby, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("OfficerType", 8, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ALDealerEnrollmentModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateALDealerEnrollmentModelOutput>> UpdateALDealerEnrollment([FromBody] UpdateALDealerEnrollmentModelInput ObjClass)
        {
            var procedureName = "UspUpdateALDealerEnrollment";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Address1", ObjClass.Address1, DbType.String, ParameterDirection.Input);
            parameters.Add("Address2", ObjClass.Address2, DbType.String, ParameterDirection.Input);
            parameters.Add("Address3", ObjClass.Address3, DbType.String, ParameterDirection.Input);
            parameters.Add("StateId", ObjClass.StateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CityName", ObjClass.CityName, DbType.String, ParameterDirection.Input);
            parameters.Add("DistrictId", ObjClass.DistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Pin", ObjClass.Pin, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("EmailId", ObjClass.EmailId, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateALDealerEnrollmentModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetDealerNameModelOutput>> GetALDealerDetail([FromBody] GetDealerNameModelInput ObjClass)
        {
            var procedureName = "UspGetALDealerDetail";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPDealerCode", ObjClass.DTPDealerCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDealerNameModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ALGetGenericAttachedVehicleModelOutput>> ALGetGenericAttachedVehicle([FromBody] ALGetGenericAttachedVehicleModelInput ObjClass)
        {
            var procedureName = "UspGetGenericAttachedVehicle";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("Vehiclenumber", ObjClass.Vehiclenumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Statusflag", ObjClass.Statusflag, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ALGetGenericAttachedVehicleModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CheckDealerCodeModelOutput>> CheckDealerCode([FromBody] CheckDealerCodeModelInput ObjClass)
        {
            var procedureName = "UspCheckDealerCode";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckDealerCodeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<InsertALCustomerModelOutput>> InsertALCustomer([FromBody] InsertALCustomerModelInput ObjClass)
        {
            var dtDBR = new DataTable("UserInsertALCard");
            dtDBR.Columns.Add("CardNo", typeof(string));
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("VehicleType", typeof(string));
            dtDBR.Columns.Add("VINNumber", typeof(string));
            dtDBR.Columns.Add("MobileNo", typeof(string));

            if (ObjClass.ObjALCardEntryDetail != null)
            {
                foreach (ALCardEntryDetail ObjCardDetails in ObjClass.ObjALCardEntryDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CardNo"] = ObjCardDetails.CardNo;
                    dr["VechileNo"] = String.IsNullOrEmpty(ObjCardDetails.VechileNo) ? "En-Dhan Card": ObjCardDetails.VechileNo;
                    dr["VehicleType"] = ObjCardDetails.VehicleType;
                    dr["VINNumber"] = ObjCardDetails.VINNumber;
                    dr["MobileNo"] = ObjCardDetails.MobileNo;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspInsertALCCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerType", 942, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", 943, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgNameTitle", ObjClass.IndividualOrgNameTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgName", ObjClass.IndividualOrgName, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress1", ObjClass.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress2", ObjClass.CommunicationAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCityName", ObjClass.CommunicationCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPincode", ObjClass.CommunicationPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationPhoneNo", ObjClass.CommunicationPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationFax", ObjClass.CommunicationFax, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationMobileNo", ObjClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationEmailid", ObjClass.CommunicationEmailid, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("SalesExecutiveEmployeeID", ObjClass.SalesExecutiveEmployeeID, DbType.String, ParameterDirection.Input);
            parameters.Add("CopyofDriverLicense", ObjClass.CopyofDriverLicense, DbType.String, ParameterDirection.Input);
            parameters.Add("CopyofVehicleRegistrationCertificate", ObjClass.CopyofVehicleRegistrationCertificate, DbType.String, ParameterDirection.Input);

            parameters.Add("IncomeTaxPan", ObjClass.IncomeTaxPan, DbType.String, ParameterDirection.Input);
            parameters.Add("InsertALCard", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertALCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<InsertDealerWiseALOTCCardRequestModelOutput>> InsertDealerWiseALOTCCardRequest([FromBody] InsertDealerWiseALOTCCardRequestModelInput ObjClass)
        {
            var procedureName = "UspInsertDealerWiseALOTCCard";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("NoofCards", ObjClass.NoofCards, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CardType", "ALOTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertDealerWiseALOTCCardRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        //public async Task<IEnumerable<MerchantCheckAvailityCardOutput>> CheckAvailityALOTCCard([FromBody] MerchantCheckAvailityCardInput ObjClass)
        //{
        //    var procedureName = "UspCheckAvailityDummyCard";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CardType", "ALOTCCard", DbType.String, ParameterDirection.Input);
        //    using var connection = _context.CreateConnection();
        //    return await connection.QueryAsync<MerchantCheckAvailityCardOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        //}


        public async Task<IEnumerable<GetAvailityALOTCCardCardOutput>> GetAvailityALOTCCard([FromBody] GetAvailityALOTCCardCardInput ObjClass)
        {
            var procedureName = "UspGetAvailityALCard";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "ALOTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAvailityALOTCCardCardOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<ALViewCardMerchantAllocationModelOutput> ViewALOTCCardDealerAllocation([FromBody] ALViewCardDealerAllocationModelInput ObjClass)
        {
            var procedureName = "UspViewCardDealerAllocation";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "ALOTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new ALViewCardMerchantAllocationModelOutput();
            storedProcedureResult.ObjALTotalCardDetail = (List<ALTotalCardModelOutput>)await result.ReadAsync<ALTotalCardModelOutput>();
            storedProcedureResult.ObjALViewCardDetail = (List<ALViewCardMerchantDetailModelOutput>)await result.ReadAsync<ALViewCardMerchantDetailModelOutput>();
            return storedProcedureResult;
        }
        public async Task<GetAlAddonOTCCardMappingCustomerDetailsModelOutput> GetAlAddonOTCCardMappingCustomerDetails([FromBody] GetAlAddonOTCCardMappingCustomerDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetAlAddonOTCCardMappingCustomerDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetAlAddonOTCCardMappingCustomerDetailsModelOutput();
            storedProcedureResult.GetCustomerNameAndNameOnCardOutput = (List<GetCustomerNameAndNameOnCardModelOutput>)await result.ReadAsync<GetCustomerNameAndNameOnCardModelOutput>();
            storedProcedureResult.GetCustomerStatusOutput = (List<GetCustomerStatusOutput>)await result.ReadAsync<GetCustomerStatusOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<GetAlSalesExeEmpIdAddOnOTCCardMappingModelOutput>> GetAlSalesExeEmpIdAddOnOTCCardMapping([FromBody] GetAlSalesExeEmpIdAddOnOTCCardMappingModelInput ObjClass)
        {
            var procedureName = "UspGetAlSalesExeEmpIdAddOnOTCCardMapping";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAlSalesExeEmpIdAddOnOTCCardMappingModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AlAddOnOTCCardModelOutput>> AlAddOnOTCCard([FromBody] AlAddOnOTCCardModelInput ObjClass)
        {
            var dtDBR = new DataTable("UserDTNoofCards");
            dtDBR.Columns.Add("CardNo", typeof(string));
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("VehicleType", typeof(string));
            dtDBR.Columns.Add("VINNumber", typeof(string));
            dtDBR.Columns.Add("MobileNo", typeof(string));

            var procedureName = "UspInsertAlAddOnOTCCardMapping";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("NoOfCards", ObjClass.NoOfCards, DbType.Int32, ParameterDirection.Input);

            if (ObjClass.NoOfCards > 0 && ObjClass.ObjCardDetail != null)
            {
                foreach (AlAddOnOTCCardDetails ObjCardDetails in ObjClass.ObjCardDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CardNo"] = ObjCardDetails.CardNo;
                    dr["VechileNo"] = String.IsNullOrEmpty(ObjCardDetails.VechileNo) ? "En-Dhan Card" : ObjCardDetails.VechileNo; 
                    dr["VehicleType"] = ObjCardDetails.VehicleType;
                    dr["VINNumber"] = ObjCardDetails.VINNumber;
                    dr["MobileNo"] = ObjCardDetails.MobileNo;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }
            parameters.Add("CardDetails", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AlAddOnOTCCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetALVerifyCustomerDocumentModelOutput>> GetALVerifyCustomerDocument([FromBody] ALVerifyCustomerDocumentModelInput ObjClass)
        {
            var procedureName = "UspGetALVerifyCustomerDocument";
            var parameters = new DynamicParameters();
            parameters.Add("StateId", ObjClass.StateId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatus", ObjClass.CustomerStatus, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetALVerifyCustomerDocumentModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetALUploadKycDocumentsModelOutput>> GetALUploadKycDocument([FromBody] GetALUploadKycDocumentsModelInput ObjClass)
        {
            var procedureName = "UspGetALUploadKycDocument";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetALUploadKycDocumentsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InsertALCustomerKYCModelOutput>> InsertALCustomerKYC([FromForm] InsertALCustomerKYCModelInput ObjClass)
        {
            string AddressProof = UploadDocument(ObjClass.AddressProof, "AL_49");
            string IDProof = UploadDocument(ObjClass.IDProof, "AL_51");
            string PanCardProof = UploadDocument(ObjClass.PanCardProof, "AL_50");
            string VehicleDetail = UploadDocument(ObjClass.VehicleDetail, "AL_52");
            string SignedCustomerForm = UploadDocument(ObjClass.SignedCustomerForm, "AL_53");

            var procedureName = "UspInsertALCustomerKYC";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("AddressProofType", AddressProof == "" ? 0 : 49, DbType.Int32, ParameterDirection.Input);
            parameters.Add("AddressProofFront", AddressProof, DbType.String, ParameterDirection.Input);
            parameters.Add("IdProofType", IDProof == "" ? 0 : 51, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IdProofFront", IDProof, DbType.String, ParameterDirection.Input);
            parameters.Add("PanCardProofType", PanCardProof == "" ? 0 : 50, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PanCardProofFront", PanCardProof, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleDetailProofType", VehicleDetail == "" ? 0 : 52, DbType.Int32, ParameterDirection.Input);
            parameters.Add("VehicleDetailProofFront", VehicleDetail, DbType.String, ParameterDirection.Input);
            parameters.Add("SignedFormProofType", SignedCustomerForm == "" ? 0 : 53, DbType.Int32, ParameterDirection.Input);
            parameters.Add("SignedFormProofFront", SignedCustomerForm, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertALCustomerKYCModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public string UploadDocument(Microsoft.AspNetCore.Http.IFormFile ImageFileNameProof, string fileProofType)
        {
            string FileNamePathProof = String.Empty;
            if (ImageFileNameProof != null)
            {
                if (ImageFileNameProof.Length > 0)
                {
                    IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
                    var ext = ImageFileNameProof.FileName.Substring(ImageFileNameProof.FileName.LastIndexOf('.'));
                    var extension = ext.ToLower();
                    if (AllowedFileExtensions.Contains(extension))
                    {

                        string contentRootPath = _hostingEnvironment.ContentRootPath;
                        FileNamePathProof = "/CustomerKYCImage/" + DateTime.Now.ToString("yyyyMMddHHmmss")
                            + "_" + fileProofType + "_" + ImageFileNameProof.FileName;
                        string filePathPancardProofFront = contentRootPath + FileNamePathProof;
                        var fileStream = new FileStream(filePathPancardProofFront, FileMode.Create);
                        ImageFileNameProof.CopyTo(fileStream);
                    }
                }
            }

            return FileNamePathProof;
        }

        public async Task<IEnumerable<GetAlCustomerDetailForVerificationModelOutput>> GetAlCustomerDetailForVerification([FromBody] GetAlCustomerDetailForVerificationModelInput ObjClass)
        {
            var procedureName = "UspGetAlCustomerDetailForVerification";
            var parameters = new DynamicParameters();
            parameters.Add("StateID", ObjClass.StateID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("Status", ObjClass.Status, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAlCustomerDetailForVerificationModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetALCustomerStatusDetailOutput>> GetALCustomerStatusDetail([FromBody] GetALCustomerStatusDetailInput ObjClass)
        {
            var procedureName = "UspGetALCustomerStatusDetail";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetALCustomerStatusDetailOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateALCustomerStatusModelOutput>> UpdateALCustomerStatus([FromBody] UpdateALCustomerStatusModelInput ObjClass)
        {
            var procedureName = "UspUpdateALCustomerStatus";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatus", ObjClass.CustomerStatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Remarks", ObjClass.Remarks ?? string.Empty, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateALCustomerStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetALCustomerDetailModelOutput>> GetALCustomerDetail([FromBody] GetALCustomerDetailModelInput ObjClass)
        {
            var procedureName = "UspGetALCustomerDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetALCustomerDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateALCustomerDetailModelOutput>> UpdateALCustomerDetail([FromBody] UpdateALCustomerDetailModelinput ObjClass)
        {
            var procedureName = "UspUpdateALCustomerDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgNameTitle", ObjClass.IndividualOrgNameTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgName", ObjClass.IndividualOrgName, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCityName", ObjClass.CommunicationCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationPhoneNo", ObjClass.CommunicationPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationMobileNo", ObjClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress1", ObjClass.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress2", ObjClass.CommunicationAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPincode", ObjClass.CommunicationPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationFax", ObjClass.CommunicationFax, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationEmailid", ObjClass.CommunicationEmailid, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateALCustomerDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<ALCustomerDetailsModelOutput> GetALCustomerDetails([FromBody] ALCustomerDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetALCustomerDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerTypeId", ObjClass.CustomerTypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerSubtypeId", ObjClass.CustomerSubtypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeID", ObjClass.ZonalOfficeID, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeID", ObjClass.RegionalOfficeID, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfBusinessEntity", ObjClass.TypeOfBusinessEntity, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentStateId", ObjClass.PermanentStateId, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentDistrictId", ObjClass.PermanentDistrictId, DbType.String, ParameterDirection.Input);
            parameters.Add("Email", ObjClass.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfFleetId", ObjClass.TypeOfFleetId, DbType.String, ParameterDirection.Input);
            parameters.Add("FeePaymentsCollectFeeWaiver", ObjClass.FeePaymentsCollectFeeWaiver, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", ObjClass.ReferenceId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerReferenceNo", ObjClass.CustomerReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatusId", ObjClass.CustomerStatusId, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedonFromDate", ObjClass.ApprovedonFromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedonToDate", ObjClass.ApprovedonToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatusFeewaiverID", ObjClass.CustomerStatusFeewaiverID, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedBy", ObjClass.FeewaiverApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedOnFromDate", ObjClass.FeewaiverApprovedOnFromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedOnToDate", ObjClass.FeewaiverApprovedOnToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new ALCustomerDetailsModelOutput();
            storedProcedureResult.GetCustomerDetails = (List<GetALCustomerDetailsModelOutput>)await result.ReadAsync<GetALCustomerDetailsModelOutput>();
            storedProcedureResult.CustomerKYCDetails = (List<ALCustomerKYCDetailsModelOutput>)await result.ReadAsync<ALCustomerKYCDetailsModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<ManageALSearchCardsModelOutput>> SearchALManageCard([FromBody] ManageALSearchCardsModelInput ObjClass)
        {
            var procedureName = "UspGetALCardInfo";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("Vehiclenumber", ObjClass.Vehiclenumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Statusflag", ObjClass.Statusflag, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ManageALSearchCardsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ALCustomerDetailUpdateModelOutput>> RequestUpdateALCustomer([FromBody] ALCustomerDetailUpdateModelInput ObjClass)
        {

            var procedureName = "UspRequestUpdateALCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOffice", ObjClass.ZonalOffice, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RegionalOffice", ObjClass.RegionalOffice, DbType.Int32, ParameterDirection.Input);
            parameters.Add("DateOfApplication", ObjClass.DateOfApplication, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("SignedOnDate", ObjClass.SignedOnDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("SalesArea", ObjClass.SalesArea, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgNameTitle", ObjClass.IndividualOrgNameTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgName", ObjClass.IndividualOrgName, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfBusinessEntity", ObjClass.TypeOfBusinessEntity, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ResidenceStatus", ObjClass.ResidenceStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("IncomeTaxPan", ObjClass.IncomeTaxPan, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress1", ObjClass.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress2", ObjClass.CommunicationAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress3", ObjClass.CommunicationAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationLocation", ObjClass.CommunicationLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCityName", ObjClass.CommunicationCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPincode", ObjClass.CommunicationPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationPhoneNo", ObjClass.CommunicationPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationFax", ObjClass.CommunicationFax, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationMobileNo", ObjClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationEmailid", ObjClass.CommunicationEmailid, DbType.String, ParameterDirection.Input);

            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);

            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            //parameters.Add("PanCardRemarks", "", DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ALCustomerDetailUpdateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<ApprovalALCustomerUpdateRequestModelOutput>> ApprovalALCustomerUpdateRequest([FromBody] ApprovalALCustomerUpdateRequestModelInput ObjClass)
        {
            var dtDBR = new DataTable("CustomerApproval");
            dtDBR.Columns.Add("CustomerID", typeof(string));
            dtDBR.Columns.Add("Comments", typeof(string));
            var procedureName = "UspApprovalALCustomerUpdateRequest";
            var parameters = new DynamicParameters();

            foreach (CustomerApproval objdtl in ObjClass.CustomerApprovalList)
            {
                DataRow dr = dtDBR.NewRow();
                dr["CustomerID"] = objdtl.CustomerID;
                dr["Comment"] = objdtl.Comments;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }
            parameters.Add("ApprvalStatus", ObjClass.ActionType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerApproval", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ApprovalALCustomerUpdateRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetALCheckVinNumberModelOutput>> GetALCheckVinNumber([FromBody] GetALCheckVinNumberModelInput ObjClass)
        {
            var procedureName = "UspALCheckVINNumber";
            var parameters = new DynamicParameters();
            parameters.Add("VinRegistrationNumber", ObjClass.VinNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("MethodName", "CheckVinNo", DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetALCheckVinNumberModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetALPendingKycCustomerModelOutput>> GetALPendingKycCustomer([FromBody] GetALPendingKycCustomerModelInput ObjClass)
        {
            var procedureName = "UspGetPendingKycCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetALPendingKycCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateALCommunicationEmailResetPasswordModelOutput>> UpdateALCommunicationEmailResetPassword(UpdateALCommunicationEmailResetPasswordModelInput objClass)
        {
            var procedureName = "UspUpdateALCommunicationEmailResetPassword";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", objClass.UserName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateALCommunicationEmailResetPasswordModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetALVehicleSpecificCardRequestModelOutput>> GetALVehicleSpecificCardRequest([FromBody] GetALVehicleSpecificCardRequestModelInput ObjClass)
        {
            var procedureName = "UspGetALVehicleSpecificCardRequest";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetALVehicleSpecificCardRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InsertALVehicleSpecificCardRequestModelOutput>> InsertALVehicleSpecificCardRequest([FromBody] InsertALVehicleSpecificCardRequestModelInput ObjClass)
        {
            var dtDBR = new DataTable("VehicleSpecificCard");
            dtDBR.Columns.Add("CardNo", typeof(string));
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("VehicleType", typeof(string));
            dtDBR.Columns.Add("VinNumber", typeof(string));

            if (ObjClass.lstVehicleSpecificCard != null)
            {
                foreach (ALVehicleSpecificCard ObjCardDetails in ObjClass.lstVehicleSpecificCard)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CardNo"] = ObjCardDetails.CardNo;
                    dr["VechileNo"] = ObjCardDetails.VechileNo;
                    dr["VehicleType"] = ObjCardDetails.VehicleType;
                    dr["VinNumber"] = ObjCardDetails.VINNumber;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspInsertALVehicleSpecificCardRequest";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleSpecificCard", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertALVehicleSpecificCardRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetALDispatchDetailModelOutput>> GetALDispatchDetail([FromBody] GetALDispatchDetailModelInput ObjClass)
        {
            var procedureName = "UspGetDispatchDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetALDispatchDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetALVehicleSpecificCardApproveModelOutput>> GetALVehicleSpecificCardApprove([FromBody] GetALVehicleSpecificCardApproveModelInput ObjClass)
        {
            var procedureName = "UspGetALVehicleSpecificCardRequestApprove";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetALVehicleSpecificCardApproveModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ApproveALVehicleSpecificCardApproveModelOutput>> InsertALVehicleSpecificCardRequestApprove([FromBody] ApproveALVehicleSpecificCardApproveModelInput ObjClass)
        {
            var dtDBR = new DataTable("VehicleSpecificCardApprove");
            dtDBR.Columns.Add("Id", typeof(string));
            dtDBR.Columns.Add("PreviousCardNo", typeof(string));
            dtDBR.Columns.Add("FormNumber", typeof(string));
            dtDBR.Columns.Add("Comments", typeof(string));
            dtDBR.Columns.Add("CustomerID", typeof(string));

            if (ObjClass.lstVehicleSpecificCardApprove != null)
            {
                foreach (VehicleSpecificCardApprove ObjCardDetails in ObjClass.lstVehicleSpecificCardApprove)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["Id"] = ObjCardDetails.Id;
                    dr["PreviousCardNo"] = ObjCardDetails.PreviousCardNo;
                    dr["FormNumber"] = ObjCardDetails.FormNumber;
                    dr["Comments"] = ObjCardDetails.Comments;
                    dr["CustomerID"] = ObjCardDetails.CustomerID;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspVehicleSpecificCardApprove";
            var parameters = new DynamicParameters();
            parameters.Add("Approvalstatus", ObjClass.Approvalstatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleSpecificCardApprove", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ApproveALVehicleSpecificCardApproveModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<UpdateALHotlistReactivateModelOutput>> UpdateALHotlistReactivate(UpdateALHotlistReactivateModelInput ObjClass)
        {


            var procedureName = "UspUpdateALHotlistReactive";
            var parameters = new DynamicParameters();
            parameters.Add("EntitytypeId", ObjClass.EntitytypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("ReasonId", ObjClass.ReasonId, DbType.String, ParameterDirection.Input);
            parameters.Add("Remarks", ObjClass.Remarks, DbType.String, ParameterDirection.Input);
            parameters.Add("RemarksOthers", ObjClass.RemarksOthers, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionId", ObjClass.ActionId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateALHotlistReactivateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


        }
        public async Task<IEnumerable<GetALCustomerKYCModelOutput>> GetALCustomerKYC(GetALCustomerKYCModelInput objClass)
        {
            var procedureName = "UspGetALCustomerKYC";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", objClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetALCustomerKYCModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<ALUnMappedOTCCardModelOutput> ALUnMappedOTCCardDetail([FromBody] ALUnMappedOTCCardModelInput ObjClass)
        {
            var procedureName = "UspViewALDealerOTCCardDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "ALOTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new ALUnMappedOTCCardModelOutput();
            storedProcedureResult.ObjALTotalCardDetail = (List<TotalALCardDetail>)await result.ReadAsync<TotalALCardDetail>();
            storedProcedureResult.ObjALViewCardDetail = (List<ViewALCardWiseDetail>)await result.ReadAsync<ViewALCardWiseDetail>();
            return storedProcedureResult;
        }

        public async Task<GetALCustomerApplicationFormNameOnCardModelOutput> GetALCustomerApplicationFormNameOnCard([FromBody] GetALCustomerApplicationFormModelInput ObjClass)
        {
            var procedureName = "UspALCustomerApplicationForm";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetALCustomerApplicationFormNameOnCardModelOutput();
            storedProcedureResult.GetALCustomerApplicationFormOutput = (List<GetALCustomerApplicationFormModelOutput>)await result.ReadAsync<GetALCustomerApplicationFormModelOutput>();
            storedProcedureResult.GetALCustomerFormNameOnCard = (List<GetALCustomerFormNameOnCardModelOutput>)await result.ReadAsync<GetALCustomerFormNameOnCardModelOutput>();
            return storedProcedureResult;
        }
    }
}
