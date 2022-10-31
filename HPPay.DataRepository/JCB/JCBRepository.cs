using Dapper;
using HPPay.DataModel.JCB;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using HPPay.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace HPPay.DataRepository.JCB
{
    public class JCBRepository: IJCBRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public JCBRepository(DapperContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IEnumerable<JCBDealerEnrollmentModelOutput>> InsertJCBDealerEnrollment([FromBody] JCBDealerEnrollmentModelInput ObjClass)
        {
            var procedureName = "UspInsertJCBDealerEnrollment";
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
            parameters.Add("Createdby", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("OfficerType", ObjClass.OfficerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOffice", ObjClass.RegionalOffice, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<JCBDealerEnrollmentModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateJCBDealerEnrollmentModelOutput>> UpdateJCBDealerEnrollment([FromBody] UpdateJCBDealerEnrollmentModelInput ObjClass)
        {
            var procedureName = "UspUpdateJCBDealerEnrollment";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.Int32, ParameterDirection.Input);
            //parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.Int32, ParameterDirection.Input);
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
            parameters.Add("RegionalOffice", ObjClass.RegionalOffice, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateJCBDealerEnrollmentModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetJCBDealerNameModelOutput>> GetJCBDealerDetail([FromBody] GetJCBDealerNameModelInput ObjClass)
        {
            var procedureName = "UspGetJCBDealerDetail";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPDealerCode", ObjClass.DTPDealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("OfficerType", ObjClass.OfficerType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetJCBDealerNameModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<EnableDisableJCBDealerModelOutput>> EnableDisableJCBDealer([FromBody] EnableDisableJCBDealerModelInput ObjClass)
        {
            var procedureName = "UspEnableDisableJCBDealer";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);            
            parameters.Add("OfficerType", ObjClass.OfficerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("OfficerStatus", ObjClass.IsDisable?5:4 , DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<EnableDisableJCBDealerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetJCBOfficerTypeModelOutput>> GetJCBOfficerType([FromBody] GetJCBOfficerTypeModelInput ObjClass)
        {
            var procedureName = "UspJCBOfficerType";
            var parameters = new DynamicParameters();
            
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetJCBOfficerTypeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<InsertJCBCustomerModelOutput>> InsertJCBCustomer([FromForm] InsertJCBCustomerModelInput ObjClass)
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
                            + "_JCB_60_" + ImageFileNameAddressProofFront.FileName;
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
                        FileNamePathIDProof = "/CustomerKYCImage/" + DateTime.Now.ToString("yyyyMMddHHmmss")
                            + "_JCB_62_" + ImageFileNameIDProofFront.FileName;
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
                        FileNamePathPancardProof = "/CustomerKYCImage/" + DateTime.Now.ToString("yyyyMMddHHmmss")
                            + "_JCB_61_" + ImageFileNamePancardProofFront.FileName;
                        string filePathPancardProofFront = contentRootPath + FileNamePathPancardProof;
                        var fileStream = new FileStream(filePathPancardProofFront, FileMode.Create);
                        ImageFileNamePancardProofFront.CopyTo(fileStream);
                    }
                }
            }

            var dtDBR = new DataTable("InsertJCBCard");
            dtDBR.Columns.Add("CardNo", typeof(string));
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("VehicleType", typeof(string));
            dtDBR.Columns.Add("VINNumber", typeof(string));
            dtDBR.Columns.Add("MobileNo", typeof(string));
            dtDBR.Columns.Add("RCCopyPath",typeof(string));


            int i = 0;
            if (ObjClass.CardNo != null && ObjClass.CardNo?.Count > 0)
            {
                //foreach (JCBCardEntryDetail ObjCardDetails in ObjClass.ObjJCBCardEntryDetail)
                for (i = 0; i < ObjClass.CardNo?.Count; i++)
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
                                    + "_JCB_63_" + ImageFileNameRcCopyProofFront.FileName;
                                string filePathRcCopyProofFront = contentRootPath + FileNamePathRcCopyProof;
                                var fileStream = new FileStream(filePathRcCopyProofFront, FileMode.Create);
                                ImageFileNameRcCopyProofFront.CopyTo(fileStream);
                            }
                        }
                    }



                    DataRow dr = dtDBR.NewRow();
                    dr["CardNo"] = ObjClass.CardNo[i];
                    dr["VechileNo"] = ObjClass.VechileNo[i];
                    dr["VehicleType"] = ObjClass.VehicleType[i];
                    dr["VINNumber"] = ObjClass.VINNumber[i];
                    dr["MobileNo"] = ObjClass.MobileNo[i];
                    dr["RCCopyPath"] = FileNamePathRcCopyProof;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspInsertJCBCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerType", 956, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", 957, DbType.Int32, ParameterDirection.Input);
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
            parameters.Add("PanCardNumber", ObjClass.PanCardNumber, DbType.String, ParameterDirection.Input);
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
           

            parameters.Add("InsertJCBCard", dtDBR, DbType.Object, ParameterDirection.Input);
          
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertJCBCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CheckJCBDealerCodeModelOutput>> CheckJCBDealerCode([FromBody] CheckJCBDealerCodeModelInput ObjClass)
        {
            var procedureName = "UspCheckJCBDealerCode";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckJCBDealerCodeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<InsertDealerWiseJCBOTCCardRequestModelOutput>> InsertDealerWiseJCBOTCCardRequest([FromBody] InsertDealerWiseJCBOTCCardRequestModelInput ObjClass)
        {
            var procedureName = "UspInsertDealerWiseJCBOTCCard";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("NoofCards", ObjClass.NoofCards, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CardType", "JCBOTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertDealerWiseJCBOTCCardRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetAvailityJCBOTCCardModelOutput>> GetAvailityJCBOTCCard([FromBody] GetAvailityJCBOTCCardModelInput ObjClass)
        {
            var procedureName = "UspGetAvailityJCBCard";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "JCBOTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAvailityJCBOTCCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetJCBBalanceOTCCardModelOutput>> GetJCBBalanceOTCCard([FromBody] GetJCBBalanceOTCCardModelInput ObjClass)
        {
            var procedureName = "UspGetJCBDealerBalanceCard";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "JCBOTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetJCBBalanceOTCCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ViewJCBDealerOTCCardStatusModelOutput>> ViewJCBDealerOTCCardStatus([FromBody] ViewJCBDealerOTCCardStatusModelInput ObjClass)
        {
            var procedureName = "UspViewJCBDealerOTCCardStatus";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "JCBOTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ViewJCBDealerOTCCardStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<ViewJCBDealerOTCCardDetailModelOutput> ViewJCBDealerOTCCardDetail([FromBody] ViewJCBDealerOTCCardDetailModelInput ObjClass)
        {
            var procedureName = "UspViewJCBDealerOTCCardDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "JCBOTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new ViewJCBDealerOTCCardDetailModelOutput();
            storedProcedureResult.ObjJCBTotalCardDetail = (List<TotalJCBCardDetail>)await result.ReadAsync<TotalJCBCardDetail>();
            storedProcedureResult.ObjJCBViewCardDetail = (List<ViewJCBCardMerchantDetail>)await result.ReadAsync<ViewJCBCardMerchantDetail>();
            return storedProcedureResult;
        }

        public async Task<GetJCBAddonOTCCardMappingCustomerDetailsModelOutput> GetJCBAddonOTCCardMappingCustomerDetails([FromBody] GetJCBAddonOTCCardMappingCustomerDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetJCBAddonOTCCardMappingCustomerDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetJCBAddonOTCCardMappingCustomerDetailsModelOutput();
            storedProcedureResult.GetCustomerNameAndNameOnCardOutput = (List<GetJCBCustomerNameAndNameOnCardModelOutput>)await result.ReadAsync<GetJCBCustomerNameAndNameOnCardModelOutput>();
            storedProcedureResult.GetCustomerStatusOutput = (List<GetJCBCustomerStatusOutput>)await result.ReadAsync<GetJCBCustomerStatusOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<GetJCBSalesExeEmpIdAddOnOTCCardMappingModelOutput>> GetJCBSalesExeEmpIdAddOnOTCCardMapping([FromBody] GetJCBSalesExeEmpIdAddOnOTCCardMappingModelInput ObjClass)
        {
            var procedureName = "UspGetJCBSalesExeEmpIdAddOnOTCCardMapping";
            var parameters = new DynamicParameters();
            parameters.Add("DealerCode", ObjClass.DealerCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetJCBSalesExeEmpIdAddOnOTCCardMappingModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<JCBAddOnOTCCardModelOutput>> JCBAddOnOTCCard([FromBody] JCBAddOnOTCCardModelInput ObjClass)
        {
            var dtDBR = new DataTable("UserDTNoofCards");
            dtDBR.Columns.Add("CardNo", typeof(string));
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("VehicleType", typeof(string));
            dtDBR.Columns.Add("VINNumber", typeof(string));
            dtDBR.Columns.Add("MobileNo", typeof(string));

            var procedureName = "UspInsertJCBAddOnOTCCardMapping";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("NoOfCards", ObjClass.NoOfCards, DbType.Int32, ParameterDirection.Input);

            if (ObjClass.NoOfCards > 0 && ObjClass.ObjCardDetail != null)
            {
                foreach (JCBAddOnOTCCardDetails ObjCardDetails in ObjClass.ObjCardDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CardNo"] = ObjCardDetails.CardNo;
                    dr["VechileNo"] = String.IsNullOrEmpty(ObjCardDetails.VechileNo) ? "JCB Card" : ObjCardDetails.VechileNo;
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
            return await connection.QueryAsync<JCBAddOnOTCCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<JCBCustomerDetailUpdateModelOutput>> RequestUpdateJCBCustomer([FromBody] JCBCustomerDetailUpdateModelInput ObjClass)
        {

            var procedureName = "UspRequestUpdateJCBCustomer";
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
            return await connection.QueryAsync<JCBCustomerDetailUpdateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<UpdateJCBCustomerDetailModelOutput>> UpdateJCBCustomer([FromBody] UpdateJCBCustomerDetailModelInput ObjClass)
        {

            var procedureName = "UspUpdateJCBCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
          //  parameters.Add("ZonalOffice", ObjClass.ZonalOffice, DbType.Int32, ParameterDirection.Input);
          //  parameters.Add("RegionalOffice", ObjClass.RegionalOffice, DbType.Int32, ParameterDirection.Input);
           // parameters.Add("DateOfApplication", ObjClass.DateOfApplication, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgNameTitle", ObjClass.IndividualOrgNameTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgName", ObjClass.IndividualOrgName, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress1", ObjClass.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress2", ObjClass.CommunicationAddress2, DbType.String, ParameterDirection.Input);
            //parameters.Add("CommunicationAddress3", ObjClass.CommunicationAddress3, DbType.String, ParameterDirection.Input);
            //parameters.Add("CommunicationLocation", ObjClass.CommunicationLocation, DbType.String, ParameterDirection.Input);
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

            //parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            //parameters.Add("PanCardRemarks", "", DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateJCBCustomerDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ApprovalJCBCustomerUpdateRequestModelOutput>> ApprovalJCBCustomerUpdateRequest([FromBody] ApprovalJCBCustomerUpdateRequestModelInput ObjClass)
        {
            var dtDBR = new DataTable("CustomerApproval");
            dtDBR.Columns.Add("CustomerID", typeof(string));
            dtDBR.Columns.Add("Comments", typeof(string));
            var procedureName = "UspApprovalJCBCustomerUpdateRequest";
            var parameters = new DynamicParameters();

            foreach (JCBCustomerApproval objdtl in ObjClass.CustomerApprovalList)
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
            return await connection.QueryAsync<ApprovalJCBCustomerUpdateRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<JCBCustomerDetailsModelOutput> GetJCBCustomerDetails([FromBody] JCBCustomerDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetJCBCustomerDetail";
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
            parameters.Add("@CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new JCBCustomerDetailsModelOutput();
            storedProcedureResult.GetCustomerDetails = (List<GetJCBCustomerDetailsModelOutput>)await result.ReadAsync<GetJCBCustomerDetailsModelOutput>();
            storedProcedureResult.CustomerKYCDetails = (List<JCBCustomerKYCDetailsModelOutput>)await result.ReadAsync<JCBCustomerKYCDetailsModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<ManageJCBSearchCardsModelOutput>> SearchManageCard([FromBody] ManageJCBSearchCardsModelInput ObjClass)
        {
            var procedureName = "UspGetJCBCardInfo";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("Vehiclenumber", ObjClass.Vehiclenumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Statusflag", ObjClass.Statusflag, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ManageJCBSearchCardsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<GetJCBCardLimtModelOutput> GetJCBCardLimitFeatures([FromBody] GetJCBCardLimtModelInput ObjClass)
        {
            var procedureName = "UspGetJCBCardFeatures";
            var parameters = new DynamicParameters();
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetJCBCardLimtModelOutput();
            storedProcedureResult.GetCardsDetails = (List<GetJCBCardsDetailsModelOutput>)await result.ReadAsync<GetJCBCardsDetailsModelOutput>();
            storedProcedureResult.GetCardLimt = (List<JCBCardLimtModelOutput>)await result.ReadAsync<JCBCardLimtModelOutput>();
            storedProcedureResult.CardServices = (List<JCBCardServicesModelOutput>)await result.ReadAsync<JCBCardServicesModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<GetJCBCustomerBalanceInfoModelOutput>> GetCustomerBalanceInfo([FromBody] GetJCBCustomerBalanceInfoModelInput ObjClass)
        {
            var procedureName = "UspGetJCBCustomerBalanceInfo";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetJCBCustomerBalanceInfoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<GetJCBTransactionsSummaryModelOutput> GetJCBTransactionsSummary([FromBody] GetJCBTransactionsSummaryModelInput ObjClass)
        {
            var procedureName = "UspGetJCBTransactionsSummary";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetJCBTransactionsSummaryModelOutput();
            storedProcedureResult.GetTransactionsSaleSummary = (List<GetJCBTransactionsSaleSummaryModelOutput>)await result.ReadAsync<GetJCBTransactionsSaleSummaryModelOutput>();
            storedProcedureResult.GetTransactionsDetailSummary = (List<GetJCBTransactionsDetailSummaryModelOutput>)await result.ReadAsync<GetJCBTransactionsDetailSummaryModelOutput>();
            return storedProcedureResult;
        }
        public async Task<IEnumerable<JCBUpdateMobileandFastagNoModelOutput>> JCBUpdateMobileandFastagNo([FromBody] JCBUpdateMobileandFastagNoModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeUpdateMobileInCard");
            dtDBR.Columns.Add("Cardno", typeof(string));
            dtDBR.Columns.Add("Mobileno", typeof(string));
            dtDBR.Columns.Add("FastagNo", typeof(string));

            var procedureName = "UspJCBUpdateMobileandFastagNo";
            var parameters = new DynamicParameters();

            if (ObjClass.ObjUpdateMobileandFastagNoInCard != null)
            {
                foreach (JCBUpdateMobileandFastagNo ObjCardDetails in ObjClass.ObjUpdateMobileandFastagNoInCard)
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
            return await connection.QueryAsync<JCBUpdateMobileandFastagNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<JCBGetMobileandFastagNoModelOutput>> GetJCBMobileandFastagNo([FromBody] JCBGetMobileandFastagNoModelInput ObjClass)
        {
            var procedureName = "UspGetJCBMobileandFastagNoInCard";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("Vehiclenumber", ObjClass.Vehiclenumber, DbType.String, ParameterDirection.Input);
            parameters.Add("IsNewMapping", Convert.ToInt32(ObjClass.IsNewMapping), DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<JCBGetMobileandFastagNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetJCBAdvancedSearchModelOutput>> GetJCBAdvancedSearch([FromBody] GetJCBAdvancedSearchModelInput ObjClass)
        {
            var procedureName = "UspGetJCBAdvancedSearch";
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
            return await connection.QueryAsync<GetJCBAdvancedSearchModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetJCBCommunicationEmailResetPasswordModelOutput>> GetJCBCommunicationEmailResetPassword(GetJCBCommunicationEmailResetPasswordModelInput objClass)
        {
            var procedureName = "UspGetJCBCommunicationEmailResetPassword";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", objClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetJCBCommunicationEmailResetPasswordModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateJCBCommunicationEmailResetPasswordModelOutput>> UpdateJCBCommunicationEmailResetPassword(UpdateJCBCommunicationEmailResetPasswordModelInput objClass)
        {
            var procedureName = "UspUpdateJCBCommunicationEmailResetPassword";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", objClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("AlternateEmailId", objClass.AlternateEmailId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateJCBCommunicationEmailResetPasswordModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateJCBHotlistReactivateModelOutput>> UpdateJCBHotlistReactivate(UpdateJCBHotlistReactivateModelInput ObjClass)
        {


            var procedureName = "UspUpdateJCBHotlistReactive";
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
            return await connection.QueryAsync<UpdateJCBHotlistReactivateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


        }

        public async Task<IEnumerable<GetJCBHotlistReactiveStatusModelOutput>> GetJCBVHotListReactiveStatus([FromBody] GetJCBHotlistReactiveStatusModelInput ObjClass)
        {

            var procedureName = "UspGetJCBHotListReason";
            var parameters = new DynamicParameters();
            parameters.Add("EntitytypeId", ObjClass.EntitytypeId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetJCBHotlistReactiveStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


        }

        public async Task<IEnumerable<UpdateJCBDealerCommunicationEmailResetPasswordModelOutput>> UpdateJCBDealerCommunicationEmailResetPassword(UpdateJCBDealerCommunicationEmailResetPasswordModelInput objClass)
        {
            var procedureName = "UspUpdateJCBDealerCommunicationEmailResetPassword";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", objClass.UserName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateJCBDealerCommunicationEmailResetPasswordModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetJCBCustomerApplicationFormNameOnCardModelOutput> GetJCBCustomerApplicationFormNameOnCard([FromBody] GetJCBCustomerApplicationFormModelInput ObjClass)
        {
            var procedureName = "UspJCBCustomerApplicationForm";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetJCBCustomerApplicationFormNameOnCardModelOutput();
            storedProcedureResult.GetJCBCustomerApplicationFormOutput = (List<GetJCBCustomerApplicationFormModelOutput>)await result.ReadAsync<GetJCBCustomerApplicationFormModelOutput>();
            storedProcedureResult.GetJCBCustomerFormNameOnCard = (List<GetJCBCustomerFormNameOnCardModelOutput>)await result.ReadAsync<GetJCBCustomerFormNameOnCardModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<GetJCBDispatchDetailModelOutput>> GetJCBDispatchDetail([FromBody] GetJCBDispatchDetailModelInput ObjClass)
        {
            var procedureName = "UspGetJCBDispatchDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetJCBDispatchDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InsertJCBCustomerKYCModelOutput>> UpdateJCBCustomerKYC([FromForm] InsertJCBCustomerKYCModelInput ObjClass)
        {
            string AddressProof = UploadDocument(ObjClass.AddressProof, "JCB_60");
            string IDProof = UploadDocument(ObjClass.IdProof, "JCB_62");
            string PanCardProof = UploadDocument(ObjClass.PanCardProof, "JCB_61");

            var procedureName = "UspUpdateJCBCustomerKYC";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("AddressProofType", AddressProof == "" ? 0 : 60, DbType.Int32, ParameterDirection.Input);
            parameters.Add("AddressProofFront", AddressProof, DbType.String, ParameterDirection.Input);
            parameters.Add("IdProofType", IDProof == "" ? 0 : 62, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IdProofFront", IDProof, DbType.String, ParameterDirection.Input);
            parameters.Add("PanCardProofType", PanCardProof == "" ? 0 : 61, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PanCardProofFront", PanCardProof, DbType.String, ParameterDirection.Input);


            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertJCBCustomerKYCModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<IEnumerable<GetJCBUploadKycDocumentsModelOutput>> GetJCBUploadKycDocument([FromBody] GetJCBUploadKycDocumentsModelInput ObjClass)
        {
            var procedureName = "UspGetJCBUploadKycDocument";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetJCBUploadKycDocumentsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetJCBCustomerDetailForVerificationModelOutput>> GetJCBCustomerDetailForVerification([FromBody] GetJCBCustomerDetailForVerificationModelInput ObjClass)
        {
            var procedureName = "UspGetJCBCustomerDetailForVerification";
            var parameters = new DynamicParameters();
            parameters.Add("StateID", ObjClass.StateID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("Status", ObjClass.Status, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetJCBCustomerDetailForVerificationModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetJCBCustomerStatusDetailOutput>> GetJCBCustomerStatusDetail([FromBody] GetJCBCustomerStatusDetailInput ObjClass)
        {
            var procedureName = "UspGetJCBCustomerStatusDetail";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetJCBCustomerStatusDetailOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateJCBCustomerStatusModelOutput>> UpdateJCBCustomerStatus([FromBody] UpdateJCBCustomerStatusModelInput ObjClass)
        {
            var procedureName = "UspUpdateJCBCustomerStatus";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatus", ObjClass.CustomerStatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Remarks", ObjClass.Remarks ?? string.Empty, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateJCBCustomerStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<JCBLoyalityPointSummaryModelOutput>> GetJCBLoyalityPointSummary(JCBLoyalityPointSummaryModelInput objClass)
        {
            var procedureName = "UspGetJCBLoyalityPointSummary";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", objClass.FromDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("Todate", objClass.Todate, DbType.DateTime, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<JCBLoyalityPointSummaryModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
