using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.DICV;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace HPPay.DataRepository.DICV
{
    public class DICVRepository : IDICVRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public DICVRepository(DapperContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment= hostingEnvironment;
        }


        public async Task<IEnumerable<CheckDICVDealerCodeModelOutput>> CheckDICVDealerCode([FromBody] CheckDICVDealerCodeModelInput ObjClass)
        {
            var procedureName = "UspCheckDICVDealerCode";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckDICVDealerCodeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetAvailityDICVOTCCardModelOutput>> GetAvailityDICVOTCCard([FromBody] GetAvailityDICVOTCCardModelInput ObjClass)
        {
            var procedureName = "UspGetAvailityDICVCard";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "DICVOTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAvailityDICVOTCCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<InsertDICVCustomerModelOutput>> InsertDICVCustomer([FromForm] InsertDICVCustomerModelInput ObjClass)
        {
            
            string FileNamePathAddressProof = string.Empty;
            var ImageFileNameAddressProofFront = ObjClass.AddressProof;
            if (ImageFileNameAddressProofFront != null)
            {
                if (ImageFileNameAddressProofFront.Length > 0)
                {
                    IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
                    var ext = ImageFileNameAddressProofFront.FileName.Substring(ImageFileNameAddressProofFront.FileName.LastIndexOf('.'));
                    var extension = ext.ToLower();
                    if (AllowedFileExtensions.Contains(extension))
                    {

                        string contentRootPath = _hostingEnvironment.ContentRootPath;
                        FileNamePathAddressProof = "/CustomerKYCImage/" + DateTime.Now.ToString("yyyyMMddHHmmss")
                            + "_DICV_56_" + ImageFileNameAddressProofFront.FileName;
                        string filePathAddressProofFront = contentRootPath + FileNamePathAddressProof;
                        var fileStream = new FileStream(filePathAddressProofFront, FileMode.Create);
                        ImageFileNameAddressProofFront.CopyTo(fileStream);
                    }
                }
            }

            string FileNamePathIDProof = string.Empty;
            var ImageFileNameIDProofFront = ObjClass.IDProof;
            if (ImageFileNameIDProofFront != null)
            {
                if (ImageFileNameIDProofFront.Length > 0)
                {
                    IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
                    var ext = ImageFileNameIDProofFront.FileName.Substring(ImageFileNameIDProofFront.FileName.LastIndexOf('.'));
                    var extension = ext.ToLower();
                    if (AllowedFileExtensions.Contains(extension))
                    {

                        string contentRootPath = _hostingEnvironment.ContentRootPath;
                        FileNamePathIDProof = "/CustomerKYCImage/"  + DateTime.Now.ToString("yyyyMMddHHmmss")
                            + "_DICV_58_" + ImageFileNameIDProofFront.FileName;
                        string filePathIDProofFront = contentRootPath + FileNamePathIDProof;
                        var fileStream = new FileStream(filePathIDProofFront, FileMode.Create);
                        ImageFileNameIDProofFront.CopyTo(fileStream);
                    }
                }
            }

            string FileNamePathPancardProof = string.Empty;
            var ImageFileNamePancardProofFront = ObjClass.PanCardProof;
            if (ImageFileNamePancardProofFront != null)
            {
                if (ImageFileNamePancardProofFront.Length > 0)
                {
                    IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
                    var ext = ImageFileNamePancardProofFront.FileName.Substring(ImageFileNamePancardProofFront.FileName.LastIndexOf('.'));
                    var extension = ext.ToLower();
                    if (AllowedFileExtensions.Contains(extension))
                    {

                        string contentRootPath = _hostingEnvironment.ContentRootPath;
                        FileNamePathPancardProof = "/CustomerKYCImage/" +  DateTime.Now.ToString("yyyyMMddHHmmss")
                            + "_DICV_57_" + ImageFileNamePancardProofFront.FileName;
                        string filePathPancardProofFront = contentRootPath + FileNamePathPancardProof;
                        var fileStream = new FileStream(filePathPancardProofFront, FileMode.Create);
                        ImageFileNamePancardProofFront.CopyTo(fileStream);
                    }
                }
            }


            var dtDBR = new DataTable("UserInsertDICVCard");
            dtDBR.Columns.Add("CardNo", typeof(string));
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("VehicleType", typeof(string));
            dtDBR.Columns.Add("VINNumber", typeof(string));
            dtDBR.Columns.Add("MobileNo", typeof(string));
            dtDBR.Columns.Add("RcCopyProof", typeof(string));

            int i=0;

            // foreach (DICVCardEntryDetail ObjCardDetails in ObjClass.ObjDICVCardEntryDetail)
            if (ObjClass.CardNo != null && ObjClass.CardNo?.Count > 0)
            {
                string FileNamePathRcCopyProof = string.Empty;
                var ImageFileNameRcCopyProofFront = ObjClass.RcCopyProof[i];
                if (ImageFileNameRcCopyProofFront != null)
                {
                    if (ImageFileNameRcCopyProofFront.Length > 0)
                    {
                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
                        var ext = ImageFileNameRcCopyProofFront.FileName.Substring(ImageFileNameRcCopyProofFront.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (AllowedFileExtensions.Contains(extension))
                        {

                            string contentRootPath = _hostingEnvironment.ContentRootPath;
                            FileNamePathRcCopyProof = "/CustomerKYCImage/" + DateTime.Now.ToString("yyyyMMddHHmmss")
                                + "_DICV_59_" + ImageFileNameRcCopyProofFront.FileName;
                            string filePathRcCopyProofFront = contentRootPath + FileNamePathRcCopyProof;
                            var fileStream = new FileStream(filePathRcCopyProofFront, FileMode.Create);
                            ImageFileNameRcCopyProofFront.CopyTo(fileStream);
                        }
                    }
                }

                for (i = 0; i < ObjClass.CardNo?.Count; i++)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CardNo"] = ObjClass.CardNo[i];
                    dr["VechileNo"] = ObjClass.VechileNo[i];
                    dr["VehicleType"] = ObjClass.VehicleType[i];
                    dr["VINNumber"] = ObjClass.VINNumber[i];
                    dr["MobileNo"] = ObjClass.MobileNo[i];
                    dr["RcCopyProof"] = FileNamePathRcCopyProof[i];

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }
            

            var procedureName = "UspInsertDICVCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerType", 953, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", 954, DbType.Int32, ParameterDirection.Input);
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
            parameters.Add("PanCardNumber", ObjClass.PanCardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("SalesExecutiveEmployeeID", ObjClass.SalesExecutiveEmployeeID, DbType.String, ParameterDirection.Input);
            parameters.Add("CopyofDriverLicense", ObjClass.CopyofDriverLicense, DbType.String, ParameterDirection.Input);
            parameters.Add("CopyofVehicleRegistrationCertificate", ObjClass.CopyofVehicleRegistrationCertificate, DbType.String, ParameterDirection.Input);
            
            parameters.Add("AddressProof", FileNamePathAddressProof, DbType.String, ParameterDirection.Input);
            parameters.Add("IdProof", FileNamePathIDProof, DbType.String, ParameterDirection.Input);
            parameters.Add("PancardProof", FileNamePathPancardProof, DbType.String, ParameterDirection.Input);
           

            parameters.Add("UserInsertDICVCard", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertDICVCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<InsertDICVCustomerKYCModelOutput>> InsertDICVCustomerKYC([FromForm] InsertDICVCustomerKYCModelInput ObjClass)
        {
            string AddressProof = UploadDocument(ObjClass.AddressProof, "DICV_56");
            string IDProof = UploadDocument(ObjClass.IdProof, "DICV_58");
            string PanCardProof = UploadDocument(ObjClass.PanCardProof, "DICV_57");

            var procedureName = "UspInsertDICVCustomerKYC";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("AddressProofType", AddressProof == "" ? 0 : 56, DbType.Int32, ParameterDirection.Input);
            parameters.Add("AddressProofFront", AddressProof, DbType.String, ParameterDirection.Input);
            parameters.Add("IdProofType", IDProof == "" ? 0 : 58, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IdProofFront", IDProof, DbType.String, ParameterDirection.Input);
            parameters.Add("PanCardProofType", PanCardProof == "" ? 0 : 57, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PanCardProofFront", PanCardProof, DbType.String, ParameterDirection.Input);

           
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertDICVCustomerKYCModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<IEnumerable<GetDICVUploadKycDocumentsModelOutput>> GetDICVUploadKycDocument([FromBody] GetDICVUploadKycDocumentsModelInput ObjClass)
        {
            var procedureName = "UspGetDICVUploadKycDocument";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDICVUploadKycDocumentsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetDICVAddonOTCCardMappingCustomerDetailsModelOutput> GetDICVAddonOTCCardMappingCustomerDetails([FromBody] GetDICVAddonOTCCardMappingCustomerDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetDICVAddonOTCCardMappingCustomerDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetDICVAddonOTCCardMappingCustomerDetailsModelOutput();
            storedProcedureResult.GetCustomerNameAndNameOnCardOutput = (List<GetDICVCustomerNameAndNameOnCardModelOutput>)await result.ReadAsync<GetDICVCustomerNameAndNameOnCardModelOutput>();
            storedProcedureResult.GetCustomerStatusOutput = (List<GetDICVCustomerStatusOutput>)await result.ReadAsync<GetDICVCustomerStatusOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<GetDICVSalesExeEmpIdAddOnOTCCardMappingModelOutput>> GetDICVSalesExeEmpIdAddOnOTCCardMapping([FromBody] GetDICVSalesExeEmpIdAddOnOTCCardMappingModelInput ObjClass)
        {
            var procedureName = "UspGetDICVSalesExeEmpIdAddOnOTCCardMapping";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDICVSalesExeEmpIdAddOnOTCCardMappingModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<DICVAddOnOTCCardModelOutput>> DICVAddOnOTCCard([FromBody] DICVAddOnOTCCardModelInput ObjClass)
        {
            var dtDBR = new DataTable("UserDTNoofCards");
            dtDBR.Columns.Add("CardNo", typeof(string));
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("VehicleType", typeof(string));
            dtDBR.Columns.Add("VINNumber", typeof(string));
            dtDBR.Columns.Add("MobileNo", typeof(string));

            var procedureName = "UspInsertDICVAddOnOTCCardMapping";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("NoOfCards", ObjClass.NoOfCards, DbType.Int32, ParameterDirection.Input);

            if (ObjClass.NoOfCards > 0 && ObjClass.ObjCardDetail != null)
            {
                foreach (DICVAddOnOTCCardDetails ObjCardDetails in ObjClass.ObjCardDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CardNo"] = ObjCardDetails.CardNo;
                    dr["VechileNo"] = String.IsNullOrEmpty(ObjCardDetails.VechileNo) ? "DICV Card" : ObjCardDetails.VechileNo;
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
            return await connection.QueryAsync<DICVAddOnOTCCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetDICVCustomerDetailForVerificationModelOutput>> GetDICVCustomerDetailForVerification([FromBody] GetDICVCustomerDetailForVerificationModelInput ObjClass)
        {
            var procedureName = "UspGetDICVCustomerDetailForVerification";
            var parameters = new DynamicParameters();
            parameters.Add("StateID", ObjClass.StateID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("Status", ObjClass.Status, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDICVCustomerDetailForVerificationModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetDICVCustomerStatusDetailOutput>> GetDICVCustomerStatusDetail([FromBody] GetDICVCustomerStatusDetailInput ObjClass)
        {
            var procedureName = "UspGetDICVCustomerStatusDetail";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDICVCustomerStatusDetailOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateDICVCustomerStatusModelOutput>> UpdateDICVCustomerStatus([FromBody] UpdateDICVCustomerStatusModelInput ObjClass)
        {
            var procedureName = "UspUpdateDICVCustomerStatus";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatus", ObjClass.CustomerStatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Remarks", ObjClass.Remarks ?? string.Empty, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateDICVCustomerStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetDICVCustomerDetailModelOutput>> GetDICVCustomerDetail([FromBody] GetDICVCustomerDetailModelInput ObjClass)
        {
            var procedureName = "UspGetDICVCustomerDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("UserID", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDICVCustomerDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateDICVCustomerDetailModelOutput>> UpdateDICVCustomerDetail([FromBody] UpdateDICVCustomerDetailModelinput ObjClass)
        {
            var procedureName = "UspUpdateDICVCustomerDetail";
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
            return await connection.QueryAsync<UpdateDICVCustomerDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        
        public async Task<IEnumerable<ViewDICVDealerOTCCardStatusModelOutput>> ViewDICVDealerOTCCardStatus([FromBody] ViewDICVDealerOTCCardStatusModelInput ObjClass)
        {
            var procedureName = "UspViewDICVDealerOTCCardStatus";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "DICVOTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ViewDICVDealerOTCCardStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetDealerDetailModelOutput>> GetDICVDealerDetail([FromBody] GetDealerDetailModelInput ObjClass)
        {
            var procedureName = "UspGetDICVDealerDetail";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPDealerCode", ObjClass.DTPDealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("OfficerType", ObjClass.OfficerType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDealerDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<EnableDisableDICVDealerModelOutput>> EnableDisableDICVDealer([FromBody] EnableDisableDICVDealerModelInput ObjClass)
        {
            var procedureName = "UspEnableDisableDICVDealer";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("OfficerType", ObjClass.OfficerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("OfficerStatus", ObjClass.IsDisable ?5 :4, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<EnableDisableDICVDealerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<DICVDealerEnrollmentModelOutput>> InsertDICVDealerEnrollment([FromBody] DICVDealerEnrollmentModelInput ObjClass)
        {
            var procedureName = "UspInsertDICVDealerEnrollment";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("DealerName", ObjClass.DealerName, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.Int32, ParameterDirection.Input);
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
            parameters.Add("OfficerType", ObjClass.OfficerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOffice", ObjClass.RegionalOffice, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DICVDealerEnrollmentModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateDICVDealerEnrollmentModelOutput>> UpdateDICVDealerEnrollment([FromBody] UpdateDICVDealerEnrollmentModelInput ObjClass)
        {
            var procedureName = "UspUpdateDICVDealerEnrollment";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.Int32, ParameterDirection.Input);
           // parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.Int32, ParameterDirection.Input);
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
            parameters.Add("RegionalOffice", ObjClass.RegionalOffice, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateDICVDealerEnrollmentModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<DICVCustomerDetailsModelOutput> GetDICVCustomerDetails([FromBody] DICVCustomerDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetDICVCustomerDetail";
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
           // parameters.Add("CustomerReferenceNo", ObjClass.CustomerReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatusId", ObjClass.CustomerStatusId, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedonFromDate", ObjClass.ApprovedonFromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedonToDate", ObjClass.ApprovedonToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatusFeewaiverID", ObjClass.CustomerStatusFeewaiverID, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedBy", ObjClass.FeewaiverApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedOnFromDate", ObjClass.FeewaiverApprovedOnFromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedOnToDate", ObjClass.FeewaiverApprovedOnToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("@CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new DICVCustomerDetailsModelOutput();
            storedProcedureResult.GetCustomerDetails = (List<GetDICVCustomerDetailsModelOutput>)await result.ReadAsync<GetDICVCustomerDetailsModelOutput>();
            storedProcedureResult.CustomerKYCDetails = (List<DICVCustomerKYCDetailsModelOutput>)await result.ReadAsync<DICVCustomerKYCDetailsModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<ManageDICVSearchCardsModelOutput>> SearchManageCard([FromBody] ManageDICVSearchCardsModelInput ObjClass)
        {
            var procedureName = "UspGetDICVCardInfo";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("Vehiclenumber", ObjClass.Vehiclenumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Statusflag", ObjClass.Statusflag, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ManageDICVSearchCardsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetDICVOfficerTypeModelOutput>> GetDICVOfficerType([FromBody] GetDICVOfficerTypeModelInput ObjClass)
        {
            var procedureName = "UspDICVOfficerType";
            var parameters = new DynamicParameters();

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDICVOfficerTypeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<DICVCustomerDetailUpdateModelOutput>> RequestUpdateDICVCustomer([FromBody] DICVCustomerDetailUpdateModelInput ObjClass)
        {

            var procedureName = "UspRequestUpdateDICVCustomer";
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
            return await connection.QueryAsync<DICVCustomerDetailUpdateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ApprovalDICVCustomerUpdateRequestModelOutput>> ApprovalDICVCustomerUpdateRequest([FromBody] ApprovalDICVCustomerUpdateRequestModelInput ObjClass)
        {
            var dtDBR = new DataTable("CustomerApproval");
            dtDBR.Columns.Add("CustomerID", typeof(string));
            dtDBR.Columns.Add("Comments", typeof(string));
            var procedureName = "UspApprovalDICVCustomerUpdateRequest";
            var parameters = new DynamicParameters();

            foreach (DICVCustomerApproval objdtl in ObjClass.CustomerApprovalList)
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
            return await connection.QueryAsync<ApprovalDICVCustomerUpdateRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetDICVCardLimtModelOutput> GetDICVCardLimitFeatures([FromBody] GetDICVCardLimtModelInput ObjClass)
        {
            var procedureName = "UspGetDICVCardFeatures";
            var parameters = new DynamicParameters();
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetDICVCardLimtModelOutput();
            storedProcedureResult.GetCardsDetails = (List<GetDICVCardsDetailsModelOutput>)await result.ReadAsync<GetDICVCardsDetailsModelOutput>();
            storedProcedureResult.GetCardLimt = (List<DICVCardLimtModelOutput>)await result.ReadAsync<DICVCardLimtModelOutput>();
            storedProcedureResult.CardServices = (List<DICVCardServicesModelOutput>)await result.ReadAsync<DICVCardServicesModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<DICVUpdateMobileInCardModelOutput>> DICVUpdateMobileInCard([FromBody] DICVUpdateMobileInCardModelInput ObjClass)
        {
            var procedureName = "UspDICVUpdateMobileInCard";
            var parameters = new DynamicParameters();
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DICVUpdateMobileInCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetDICVCustomerBalanceInfoModelOutput>> GetCustomerBalanceInfo([FromBody] GetDICVCustomerBalanceInfoModelInput ObjClass)
        {
            var procedureName = "UspGetDICVCustomerBalanceInfo";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDICVCustomerBalanceInfoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<GetDICVTransactionsSummaryModelOutput> GetDICVTransactionsSummary([FromBody] GetDICVTransactionsSummaryModelInput ObjClass)
        {
            var procedureName = "UspGetDICVTransactionsSummary";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetDICVTransactionsSummaryModelOutput();
            storedProcedureResult.GetTransactionsSaleSummary = (List<GetDICVTransactionsSaleSummaryModelOutput>)await result.ReadAsync<GetDICVTransactionsSaleSummaryModelOutput>();
            storedProcedureResult.GetTransactionsDetailSummary = (List<GetDICVTransactionsDetailSummaryModelOutput>)await result.ReadAsync<GetDICVTransactionsDetailSummaryModelOutput>();
            return storedProcedureResult;
        }
        public async Task<IEnumerable<DICVUpdateMobileandFastagNoModelOutput>> DICVUpdateMobileandFastagNo([FromBody] DICVUpdateMobileandFastagNoModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeUpdateMobileInCard");
            dtDBR.Columns.Add("Cardno", typeof(string));
            dtDBR.Columns.Add("Mobileno", typeof(string));
            dtDBR.Columns.Add("FastagNo", typeof(string));

            var procedureName = "UspDICVUpdateMobileandFastagNo";
            var parameters = new DynamicParameters();

            if (ObjClass.ObjUpdateMobileandFastagNoInCard != null)
            {
                foreach (DICVUpdateMobileandFastagNo ObjCardDetails in ObjClass.ObjUpdateMobileandFastagNoInCard)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["Cardno"] = ObjCardDetails.Cardno;
                    dr["Mobileno"] = ObjCardDetails.Mobileno;
                    dr["FastagNo"] = ObjCardDetails.FastagNo;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            parameters.Add("UpdateMobileInCard", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DICVUpdateMobileandFastagNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DICVGetMobileandFastagNoModelOutput>> GetDICVMobileandFastagNo([FromBody] DICVGetMobileandFastagNoModelInput ObjClass)
        {
            var procedureName = "UspGetDICVMobileandFastagNoInCard";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("Vehiclenumber", ObjClass.Vehiclenumber, DbType.String, ParameterDirection.Input);
            parameters.Add("IsNewMapping", Convert.ToInt32(ObjClass.IsNewMapping), DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DICVGetMobileandFastagNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetDICVCustomerApplicationFormNameOnCardModelOutput> GetDICVCustomerApplicationFormNameOnCard([FromBody] GetDICVCustomerApplicationFormModelInput ObjClass)
        {
            var procedureName = "UspDICVCustomerApplicationForm";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetDICVCustomerApplicationFormNameOnCardModelOutput();
            storedProcedureResult.GetDICVCustomerApplicationFormOutput = (List<GetDICVCustomerApplicationFormModelOutput>)await result.ReadAsync<GetDICVCustomerApplicationFormModelOutput>();
            storedProcedureResult.GetDICVCustomerFormNameOnCard = (List<GetDICVCustomerFormNameOnCardModelOutput>)await result.ReadAsync<GetDICVCustomerFormNameOnCardModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<GetDICVAdvancedSearchModelOutput>> GetDICVAdvancedSearch([FromBody] GetDICVAdvancedSearchModelInput ObjClass)
        {
            var procedureName = "UspGetDICVAdvancedSearch";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("IsCustomerNameExist", Convert.ToInt32(ObjClass.IsCustomerNameExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("IsFormNumberExist", Convert.ToInt32(ObjClass.IsFormNumberExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);

            parameters.Add("IsCustomeridExist", Convert.ToInt32(ObjClass.IsCustomeridExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerType", ObjClass.CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IsCustomerTypeExist", Convert.ToInt32(ObjClass.IsCustomerTypeExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("RegionalOfficeID", ObjClass.RegionalOfficeID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IsRegionalOfficeExist", Convert.ToInt32(ObjClass.IsRegionalOfficeExist), DbType.Int32, ParameterDirection.Input);

            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IsZonalOfficeExist", Convert.ToInt32(ObjClass.IsZonalOfficeExist), DbType.String, ParameterDirection.Input);
            parameters.Add("Pincode", ObjClass.Pincode, DbType.String, ParameterDirection.Input);
            parameters.Add("IsPincodeExist", Convert.ToInt32(ObjClass.IsPincodeExist), DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);

            parameters.Add("IsMobileExist", Convert.ToInt32(ObjClass.IsMobileExist), DbType.String, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDICVAdvancedSearchModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetDICVCommunicationEmailResetPasswordModelOutput>> GetDICVCommunicationEmailResetPassword(GetDICVCommunicationEmailResetPasswordModelInput objClass)
        {
            var procedureName = "UspGetDICVCommunicationEmailResetPassword";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", objClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDICVCommunicationEmailResetPasswordModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateDICVCommunicationEmailResetPasswordModelOutput>> UpdateDICVCommunicationEmailResetPassword(UpdateDICVCommunicationEmailResetPasswordModelInput objClass)
        {
            var procedureName = "UspUpdateDICVCommunicationEmailResetPassword";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", objClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("AlternateEmailId", objClass.AlternateEmailId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateDICVCommunicationEmailResetPasswordModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateDICVHotlistReactivateModelOutput>>UpdateDICVHotlistReactivate([FromBody] UpdateDICVHotlistReactivateModelInput ObjClass)
        {
            
                var procedureName = "UspUpdateDICVHotlistReactive";
                var parameters = new DynamicParameters();
                parameters.Add("EntitytypeId", ObjClass.EntitytypeId, DbType.String, ParameterDirection.Input);
                parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
                parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
                parameters.Add("ReasonId", ObjClass.ReasonId, DbType.String, ParameterDirection.Input);
                parameters.Add("Remarks", ObjClass.Remarks, DbType.String, ParameterDirection.Input);
                parameters.Add("RemarksOthers", ObjClass.RemarksOthers, DbType.String, ParameterDirection.Input);
                parameters.Add("ActionId", ObjClass.ActionId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);

                using var connection = _context.CreateConnection();
                return await connection.QueryAsync<UpdateDICVHotlistReactivateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            
        }

        public async Task<IEnumerable<GetDICVHotlistReactiveModelOutput>> GetDICVHotListReason([FromBody] GetDICVHotlistReactiveModelInput ObjClass)
        {

            var procedureName = "UspGetDICVHotListReason";
            var parameters = new DynamicParameters();
            parameters.Add("EntitytypeId", ObjClass.EntitytypeId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDICVHotlistReactiveModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


        }

        public async Task<IEnumerable<InsertDealerWiseDICVOTCCardRequestModelOutput>> InsertDealerWiseDICVOTCCardRequest([FromBody] InsertDealerWiseDICVOTCCardRequestModelInput ObjClass)
        {
            var procedureName = "UspInsertDealerWiseDICVOTCCard";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("NoofCards", ObjClass.NoofCards, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CardType", "DICVOTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertDealerWiseDICVOTCCardRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<DICVUnMappedOTCCardModelOutput> DICVUnMappedOTCCardDetail([FromBody] DICVUnMappedOTCCardModelInput ObjClass)
        {
            var procedureName = "UspViewDICVDealerOTCCardDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "DICVOTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new DICVUnMappedOTCCardModelOutput();
            storedProcedureResult.ObjDICVTotalCardDetail = (List<TotalDICVCardDetail>)await result.ReadAsync<TotalDICVCardDetail>();
            storedProcedureResult.ObjDICVViewCardDetail = (List<ViewDICVCardWiseDetail>)await result.ReadAsync<ViewDICVCardWiseDetail>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<GetDICVBalanceOTCCardModelOutput>> GetDICVBalanceOTCCard([FromBody] GetDICVBalanceOTCCardModelInput ObjClass)
        {
            var procedureName = "UspGetDICVDealerBalanceCard";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "DICVOTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDICVBalanceOTCCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateDICVCommunicationEmailResetPasswordModelOutput>> UpdateDICVDealerEmailResetPassword(UpdateDicvDealerEmailResetPasswordModelInput objClass)
        {
            var procedureName = "UspUpdateDICVDealerEmailResetPassword";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", objClass.UserName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateDICVCommunicationEmailResetPasswordModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetDICVCustomerKYCModelOutput>> GetDICVCustomerKYC(GetDICVCustomerKYCModelInput objClass)
        {
            var procedureName = "UspGetDICVCustomerKYC";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", objClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDICVCustomerKYCModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DICVContactUSDetailModelOutput>> GetDICVContactUSDetail(DICVContactUSDetailModelInput objClass)
        {
            var procedureName = "UspGetDICVContactUSDetail";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", objClass.UserName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DICVContactUSDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DICVLoyalityPointSummaryModelOutput>> GetDICVLoyalityPointSummary(DICVLoyalityPointSummaryModelInput objClass)
        {
            var procedureName = "UspGetDICVLoyalityPointSummary";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", objClass.FromDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("Todate", objClass.Todate, DbType.DateTime, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DICVLoyalityPointSummaryModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetDICVDispatchDetailModelOutput>> GetDICVDispatchDetail([FromBody] GetDICVDispatchDetailModelInput ObjClass)
        {
            var procedureName = "UspGetDICVDispatchDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDICVDispatchDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
