using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.VolvoEicher;
using HPPay.DataRepository.DBDapper;
using HPPay.Infrastructure.CommonClass;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.VolvoEicher
{
    public class VolcoEicherRepository: IVolcoEicherRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public VolcoEicherRepository(DapperContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<IEnumerable<VEDealerEnrollmentModelOutput>> InsertVEDealerEnrollment([FromBody] VEDealerEnrollmentModelInput ObjClass)
        {
            var procedureName = "UspInsertVEDealerEnrollment";
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
            parameters.Add("Createdby", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("OfficerType", 16, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<VEDealerEnrollmentModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateVEDealerEnrollmentModelOutput>> UpdateVEDealerEnrollment([FromBody] UpdateVEDealerEnrollmentModelInput ObjClass)
        {
            var procedureName = "UspUpdateVEDealerEnrollment";
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
            parameters.Add("ModifiedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateVEDealerEnrollmentModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetVEDealerNameModelOutput>> GetVEDealerDetail([FromBody] GetVEDealerNameModelInput ObjClass)
        {
            var procedureName = "UspGetVEDealerDetail";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPDealerCode", ObjClass.DTPDealerCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetVEDealerNameModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<InsertVECustomerModelOutput>> InsertVECustomer([FromBody] InsertVECustomerModelInput ObjClass)
        {
            var dtDBR = new DataTable("UserInsertVECard");
            dtDBR.Columns.Add("CardNo", typeof(string));
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("VehicleType", typeof(string));
            dtDBR.Columns.Add("VINNumber", typeof(string));
            dtDBR.Columns.Add("MobileNo", typeof(string));

            if (ObjClass.ObjVECardEntryDetail != null)
            {
                foreach (VECardEntryDetail ObjCardDetails in ObjClass.ObjVECardEntryDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CardNo"] = ObjCardDetails.CardNo;
                    dr["VechileNo"] = ObjCardDetails.VechileNo;
                    dr["VehicleType"] = ObjCardDetails.VehicleType;
                    dr["VINNumber"] = ObjCardDetails.VINNumber;
                    dr["MobileNo"] = ObjCardDetails.MobileNo;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspInsertVECustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerType", 947, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", 948, DbType.Int32, ParameterDirection.Input);
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
            parameters.Add("CopyofDriverLicense", ObjClass.CopyofDriverLicense, DbType.String, ParameterDirection.Input);
            parameters.Add("CopyofVehicleRegistrationCertificate", ObjClass.CopyofVehicleRegistrationCertificate, DbType.String, ParameterDirection.Input);
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("SalesExecutiveEmployeeID", ObjClass.SalesExecutiveEmployeeID, DbType.String, ParameterDirection.Input);
            parameters.Add("IncomeTaxPan", ObjClass.IncomeTaxPan, DbType.String, ParameterDirection.Input);
            parameters.Add("InsertALCard", dtDBR, DbType.Object, ParameterDirection.Input);
            
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertVECustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CheckVEDealerCodeModelOutput>> CheckVEDealerCode([FromBody] CheckVEDealerCodeModelInput ObjClass)
        {
            var procedureName = "UspCheckVEDealerCode";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckVEDealerCodeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<InsertDealerWiseVEOTCCardRequestModelOutput>> InsertDealerWiseVEOTCCardRequest([FromBody] InsertDealerWiseVEOTCCardRequestModelInput ObjClass)
        {
            var procedureName = "UspInsertDealerWiseVEOTCCard";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("NoofCards", ObjClass.NoofCards, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CardType", "VEOTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertDealerWiseVEOTCCardRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        


        public async Task<IEnumerable<GetAvailityVEOTCCardOutput>> GetAvailityVEOTCCard([FromBody] GetAvailityVEOTCCardInput ObjClass)
        {
            var procedureName = "UspGetAvailityVECard";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "VEOTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAvailityVEOTCCardOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<VEViewCardMerchantAllocationModelOutput> ViewVEOTCCardDealerAllocation([FromBody] VEViewCardDealerAllocationModelInput ObjClass)
        {
            var procedureName = "UspViewCardDealerVElocation";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "VEOTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new VEViewCardMerchantAllocationModelOutput();
            storedProcedureResult.ObjALTotalCardDetail = (List<VETotalCardModelOutput>)await result.ReadAsync<VETotalCardModelOutput>();
            storedProcedureResult.ObjALViewCardDetail = (List<VEViewCardMerchantDetailModelOutput>)await result.ReadAsync<VEViewCardMerchantDetailModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<ViewVEDealerOTCCardStatusModelOutput>> ViewVEDealerOTCCardStatus([FromBody] ViewVEDealerOTCCardStatusModelInput ObjClass)
        {
            var procedureName = "UspViewVEDealerOTCCardStatus";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "VEOTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ViewVEDealerOTCCardStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<ViewVEDealerOTCCardDetailModelOutput> ViewVEDealerOTCCardDetail([FromBody] ViewVEDealerOTCCardDetailModelInput ObjClass)
        {
            var procedureName = "UspViewVEDealerOTCCardDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "VEOTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new ViewVEDealerOTCCardDetailModelOutput();
            storedProcedureResult.ObjVETotalCardDetail = (List<TotalVECardDetail>)await result.ReadAsync<TotalVECardDetail>();
            storedProcedureResult.ObjVEViewCardDetail = (List<ViewVECardMerchantDetail>)await result.ReadAsync<ViewVECardMerchantDetail>();
            return storedProcedureResult;
        }

        public async Task<GetVEAddonOTCCardMappingCustomerDetailsModelOutput> GetVEAddonOTCCardMappingCustomerDetails([FromBody] GetVEAddonOTCCardMappingCustomerDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetVEAddonOTCCardMappingCustomerDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetVEAddonOTCCardMappingCustomerDetailsModelOutput();
            storedProcedureResult.GetCustomerNameAndNameOnCardOutput = (List<GetVECustomerNameAndNameOnCardModelOutput>)await result.ReadAsync<GetVECustomerNameAndNameOnCardModelOutput>();
            storedProcedureResult.GetCustomerStatusOutput = (List<GetVECustomerStatusOutput>)await result.ReadAsync<GetVECustomerStatusOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<GetVESalesExeEmpIdAddOnOTCCardMappingModelOutput>> GetVESalesExeEmpIdAddOnOTCCardMapping([FromBody] GetVESalesExeEmpIdAddOnOTCCardMappingModelInput ObjClass)
        {
            var procedureName = "UspGetVESalesExeEmpIdAddOnOTCCardMapping";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetVESalesExeEmpIdAddOnOTCCardMappingModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<VEAddOnOTCCardModelOutput>> VEAddOnOTCCard([FromBody] VEAddOnOTCCardModelInput ObjClass)
        {
            var dtDBR = new DataTable("UserDTNoofCards");
            dtDBR.Columns.Add("CardNo", typeof(string));
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("VehicleType", typeof(string));
            dtDBR.Columns.Add("VINNumber", typeof(string));
            dtDBR.Columns.Add("MobileNo", typeof(string));

            var procedureName = "UspInsertVEAddOnOTCCardMapping";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("NoOfCards", ObjClass.NoOfCards, DbType.Int32, ParameterDirection.Input);

            if (ObjClass.NoOfCards > 0 && ObjClass.ObjCardDetail != null)
            {
                foreach (VEAddOnOTCCardDetails ObjCardDetails in ObjClass.ObjCardDetail)
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
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<VEAddOnOTCCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetVEVerifyCustomerDocumentModelOutput>> GetVEVerifyCustomerDocument([FromBody] VEVerifyCustomerDocumentModelInput ObjClass)
        {
            var procedureName = "UspGetVEVerifyCustomerDocument";
            var parameters = new DynamicParameters();
            parameters.Add("StateId", ObjClass.StateId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatus", ObjClass.CustomerStatus, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetVEVerifyCustomerDocumentModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetVEUploadKycDocumentsModelOutput>> GetVEUploadKycDocument([FromBody] GetVEUploadKycDocumentsModelInput ObjClass)
        {
            var procedureName = "UspGetVEUploadKycDocument";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetVEUploadKycDocumentsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InsertVECustomerKYCModelOutput>> InsertVECustomerKYC([Microsoft.AspNetCore.Mvc.FromForm] InsertVECustomerKYCModelInput ObjClass)
        {
            string PanCardProof = UploadDocument(ObjClass.PanCardProof, "VE_54");
            string IDProof = UploadDocument(ObjClass.IdProofFront, "VE_55");

            var procedureName = "UspInsertVECustomerKYC";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("IdProofType", IDProof == "" ? 0 : 55, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IdProofFront", IDProof, DbType.String, ParameterDirection.Input);
            parameters.Add("PanCardType", PanCardProof == "" ? 0 : 54, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PanCard", PanCardProof, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertVECustomerKYCModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<IEnumerable<GetVECustomerDetailForVerificationModelOutput>> GetVECustomerDetailForVerification([FromBody] GetVECustomerDetailForVerificationModelInput ObjClass)
        {
            var procedureName = "UspGetVECustomerDetailForVerification";
            var parameters = new DynamicParameters();
            parameters.Add("StateID", ObjClass.StateID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("Status", ObjClass.Status, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetVECustomerDetailForVerificationModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<VolvoCustomerDetailsModelOutput> GetVolvoCustomerDetails([FromBody] VolvoCustomerDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetVECustomerDetail";
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
            //parameters.Add("CustomerReferenceNo", ObjClass.CustomerReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatusId", ObjClass.CustomerStatusId, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedonFromDate", ObjClass.ApprovedonFromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedonToDate", ObjClass.ApprovedonToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatusFeewaiverID", ObjClass.CustomerStatusFeewaiverID, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedBy", ObjClass.FeewaiverApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedOnFromDate", ObjClass.FeewaiverApprovedOnFromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedOnToDate", ObjClass.FeewaiverApprovedOnToDate, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();

            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new VolvoCustomerDetailsModelOutput();
            storedProcedureResult.GetCustomerDetails = (List<GetvolvoCustomerDetailsModelOutput>)await result.ReadAsync<GetvolvoCustomerDetailsModelOutput>();
            storedProcedureResult.CustomerKYCDetails = (List<VolvoCustomerKYCDetailsModelOutput>)await result.ReadAsync<VolvoCustomerKYCDetailsModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<ManageVESearchCardsModelOutput>> SearchManageCard([FromBody] ManageVESearchCardsModelInput ObjClass)
        {
            var procedureName = "UspGetVECardInfo";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("Vehiclenumber", ObjClass.Vehiclenumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Statusflag", ObjClass.Statusflag, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ManageVESearchCardsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateVECustomerDetailModelOutput>> UpdateVECustomerDetail([FromBody] UpdateVECustomerDetailModelinput ObjClass)
        {
            var procedureName = "UspUpdateVECustomerDetail";
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
            return await connection.QueryAsync<UpdateVECustomerDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<VECustomerDetailUpdateModelOutput>> RequestUpdateVECustomer([FromBody] VECustomerDetailUpdateModelInput ObjClass)
        {
            
            var procedureName = "UspRequestUpdateVECustomer";
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
            return await connection.QueryAsync<VECustomerDetailUpdateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ApprovalVECustomerUpdateRequestModelOutput>> ApprovalVECustomerUpdateRequest([FromBody] ApprovalVECustomerUpdateRequestModelInput ObjClass)
        {
            var dtDBR = new DataTable("CustomerApproval");
            dtDBR.Columns.Add("CustomerID", typeof(string));
            dtDBR.Columns.Add("Comments", typeof(string));
            var procedureName = "UspApprovalVECustomerUpdateRequest";
            var parameters = new DynamicParameters();

            foreach (VECustomerApproval objdtl in ObjClass.CustomerApprovalList)
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
            return await connection.QueryAsync<ApprovalVECustomerUpdateRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<UpdateVECommunicationEmailResetPasswordModelOutput>> UpdateVECommunicationEmailResetPassword(UpdateVECommunicationEmailResetPasswordModelInput objClass)
        {
            var procedureName = "UspUpdateVECommunicationEmailResetPassword";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", objClass.UserName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateVECommunicationEmailResetPasswordModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetVEDispatchDetailModelOutput>> GetVEDispatchDetail([FromBody] GetVEDispatchDetailModelInput ObjClass)
        {
            var procedureName = "UspGetVEDispatchDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetVEDispatchDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<GetVECustomerApplicationFormNameOnCardModelOutput> GetVECustomerApplicationFormNameOnCard([FromBody] GetVECustomerApplicationFormModelInput ObjClass)
        {
            var procedureName = "UspVECustomerApplicationForm";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetVECustomerApplicationFormNameOnCardModelOutput();
            storedProcedureResult.GetVECustomerApplicationFormOutput = (List<GetVECustomerApplicationFormModelOutput>)await result.ReadAsync<GetVECustomerApplicationFormModelOutput>();
            storedProcedureResult.GetVECustomerFormNameOnCard = (List<GetVECustomerFormNameOnCardModelOutput>)await result.ReadAsync<GetVECustomerFormNameOnCardModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<UpdateVECustomerStatusModelOutput>> UpdateVECustomerStatus([FromBody] UpdateVECustomerStatusModelInput ObjClass)
        {
            var procedureName = "UspUpdateVECustomerStatus";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatus", ObjClass.CustomerStatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Remarks", ObjClass.Remarks ?? string.Empty, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateVECustomerStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetVECustomerStatusDetailOutput>> GetVECustomerStatusDetail([FromBody] GetVECustomerStatusDetailInput ObjClass)
        {
            var procedureName = "UspGetVECustomerStatusDetail";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetVECustomerStatusDetailOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetVECustomerKYCModelOutput>> GetVECustomerKYC(GetVECustomerKYCModelInput objClass)
        {
            var procedureName = "UspGetVECustomerKYC";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", objClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetVECustomerKYCModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
