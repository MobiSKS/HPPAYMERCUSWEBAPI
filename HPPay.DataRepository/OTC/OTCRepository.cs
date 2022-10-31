using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.Merchant;
using HPPay.DataModel.OTC;
using HPPay.DataRepository.DBDapper;
using HPPay.Infrastructure.CommonClass;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;


namespace HPPay.DataRepository.OTC
{
    public class OTCRepository: IOTCRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public OTCRepository(DapperContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        //Backup InsertOTCCustomer
        //public async Task<IEnumerable<MerchantInsertOTCCustomerModelOutput>> InsertOTCCustomer([FromForm] MerchantInsertOTCCustomerModelInput ObjClass)
        //{
        //    var dtDBR = new DataTable("UserInsertOTCCard");
        //    dtDBR.Columns.Add("CardNo", typeof(string));
        //    dtDBR.Columns.Add("CardIdentifier", typeof(string));
        //    dtDBR.Columns.Add("MobileNo", typeof(string));

        //    if (ObjClass.ObjOTCCardEntryDetail != null)
        //    {
        //        foreach (OTCCardEntryDetail ObjCardDetails in ObjClass.ObjOTCCardEntryDetail)
        //        {
        //            DataRow dr = dtDBR.NewRow();
        //            dr["CardNo"] = ObjCardDetails.CardNo;
        //            dr["CardIdentifier"] = ObjCardDetails.VechileNo;
        //            dr["MobileNo"] = ObjCardDetails.MobileNo;

        //            dtDBR.Rows.Add(dr);
        //            dtDBR.AcceptChanges();
        //        }
        //    }

        //    string FileNamePathAddressProof = string.Empty;
        //    var ImageFileNameAddressProofFront = ObjClass.AddressProof;
        //    if (ImageFileNameAddressProofFront != null)
        //    {
        //        if (ImageFileNameAddressProofFront.Length > 0)
        //        {
        //            IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
        //            var ext = ImageFileNameAddressProofFront.FileName.Substring(ImageFileNameAddressProofFront.FileName.LastIndexOf('.'));
        //            var extension = ext.ToLower();
        //            if (AllowedFileExtensions.Contains(extension))
        //            {

        //                string contentRootPath = _hostingEnvironment.ContentRootPath;
        //                FileNamePathAddressProof = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
        //                    + "_" + ObjClass.AddressProofType + "_" + ImageFileNameAddressProofFront.FileName;
        //                string filePathAddressProofFront = contentRootPath + FileNamePathAddressProof;
        //                var fileStream = new FileStream(filePathAddressProofFront, FileMode.Create);
        //                ImageFileNameAddressProofFront.CopyTo(fileStream);
        //            }
        //        }
        //    }

        //    string FileNamePathAddressBackProof = string.Empty;
        //    var ImageFileNameAddressProofBack = ObjClass.AddressBackProof;
        //    if (ImageFileNameAddressProofBack != null)
        //    {
        //        if (ImageFileNameAddressProofBack.Length > 0)
        //        {
        //            IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
        //            var ext = ImageFileNameAddressProofBack.FileName.Substring(ImageFileNameAddressProofBack.FileName.LastIndexOf('.'));
        //            var extension = ext.ToLower();
        //            if (AllowedFileExtensions.Contains(extension))
        //            {

        //                string contentRootPath = _hostingEnvironment.ContentRootPath;
        //                FileNamePathAddressBackProof = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
        //                    + "_" + ObjClass.AddressProofType + "_" + ImageFileNameAddressProofBack.FileName;
        //                string filePathAddressProofBack = contentRootPath + FileNamePathAddressBackProof;
        //                var fileStream = new FileStream(filePathAddressProofBack, FileMode.Create);
        //                ImageFileNameAddressProofBack.CopyTo(fileStream);
        //            }
        //        }
        //    }

        //    string FileNamePathIDProof = string.Empty;
        //    var ImageFileNameIDProofFront = ObjClass.IDProof;
        //    if (ImageFileNameIDProofFront != null)
        //    {
        //        if (ImageFileNameIDProofFront.Length > 0)
        //        {
        //            IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
        //            var ext = ImageFileNameIDProofFront.FileName.Substring(ImageFileNameIDProofFront.FileName.LastIndexOf('.'));
        //            var extension = ext.ToLower();
        //            if (AllowedFileExtensions.Contains(extension))
        //            {

        //                string contentRootPath = _hostingEnvironment.ContentRootPath;
        //                FileNamePathIDProof = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
        //                    + "_" + ObjClass.IDProofType + "_" + ImageFileNameIDProofFront.FileName;
        //                string filePathIDFront = contentRootPath + FileNamePathIDProof;
        //                var fileStream = new FileStream(filePathIDFront, FileMode.Create);
        //                ImageFileNameIDProofFront.CopyTo(fileStream);
        //            }
        //        }
        //    }

        //    string FileNamePathIDProofBack = string.Empty;
        //    var ImageFileNameIDProofBack = ObjClass.IDBackProof;
        //    if (ImageFileNameIDProofBack != null)
        //    {
        //        if (ImageFileNameIDProofBack.Length > 0)
        //        {
        //            IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
        //            var ext = ImageFileNameIDProofBack.FileName.Substring(ImageFileNameIDProofBack.FileName.LastIndexOf('.'));
        //            var extension = ext.ToLower();
        //            if (AllowedFileExtensions.Contains(extension))
        //            {

        //                string contentRootPath = _hostingEnvironment.ContentRootPath;
        //                FileNamePathIDProofBack = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
        //                    + "_" + ObjClass.IDProofType + "_" + ImageFileNameIDProofBack.FileName;
        //                string filePathIDBack = contentRootPath + FileNamePathIDProofBack;
        //                var fileStream = new FileStream(filePathIDBack, FileMode.Create);
        //                ImageFileNameIDProofBack.CopyTo(fileStream);
        //            }
        //        }
        //    }



        //    var procedureName = "UspInsertOTCCustomer";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("CustomerType", 918, DbType.Int32, ParameterDirection.Input);
        //    parameters.Add("CustomerSubtype", 920, DbType.Int32, ParameterDirection.Input);
        //    parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
        //    parameters.Add("IndividualOrgNameTitle", ObjClass.IndividualOrgNameTitle, DbType.String, ParameterDirection.Input);
        //    parameters.Add("IndividualOrgName", ObjClass.IndividualOrgName, DbType.String, ParameterDirection.Input);
        //    parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
        //    parameters.Add("IncomeTaxPan", ObjClass.IncomeTaxPan, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CommunicationAddress1", ObjClass.CommunicationAddress1, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CommunicationAddress2", ObjClass.CommunicationAddress2, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CommunicationCityName", ObjClass.CommunicationCityName, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CommunicationPincode", ObjClass.CommunicationPincode, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.Int32, ParameterDirection.Input);
        //    parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.Int32, ParameterDirection.Input);
        //    parameters.Add("CommunicationPhoneNo", ObjClass.CommunicationPhoneNo, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CommunicationFax", ObjClass.CommunicationFax, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CommunicationMobileNo", ObjClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CommunicationEmailid", ObjClass.CommunicationEmailid, DbType.String, ParameterDirection.Input);
        //    parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
        //    parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
        //    parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
        //    parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
        //    parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
        //    parameters.Add("AddressProofType", ObjClass.AddressProofType, DbType.Int32, ParameterDirection.Input);
        //    parameters.Add("AddressProofDocumentNo", ObjClass.AddressProofDocumentNo, DbType.String, ParameterDirection.Input);
        //    parameters.Add("AddressProof", FileNamePathAddressProof, DbType.String, ParameterDirection.Input);
        //    parameters.Add("AddressBackProof", FileNamePathAddressBackProof, DbType.String, ParameterDirection.Input);
        //    parameters.Add("IDProofType", ObjClass.IDProofType, DbType.Int32, ParameterDirection.Input);
        //    parameters.Add("IDProofDocumentNo", ObjClass.IDProofDocumentNo, DbType.String, ParameterDirection.Input);
        //    parameters.Add("IDProof", FileNamePathIDProof, DbType.String, ParameterDirection.Input);
        //    parameters.Add("IDBackProof", FileNamePathIDProofBack, DbType.String, ParameterDirection.Input);
        //    parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CopyofDriverLicense", ObjClass.CopyofDriverLicense, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CopyofVehicleRegistrationCertificate", ObjClass.CopyofVehicleRegistrationCertificate, DbType.String, ParameterDirection.Input);
        //    parameters.Add("InsertOTCCard", dtDBR, DbType.Object, ParameterDirection.Input);
        //    using var connection = _context.CreateConnection();
        //    return await connection.QueryAsync<MerchantInsertOTCCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        //}


        public async Task<IEnumerable<MerchantInsertOTCCustomerModelOutput>> InsertOTCCustomer([FromForm] MerchantInsertOTCCustomerModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeOtcCardDetail");
            dtDBR.Columns.Add("CardNo", typeof(string));
            if (ObjClass.CardNo != null)
            {

                for (int i = 0; i < ObjClass.CardNo.Count; i++)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CardNo"] = ObjClass.CardNo[i];
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
                
            }

            var dtobjDBR = new DataTable("TypeOtcMobileDetail");
            dtobjDBR.Columns.Add("MobileNo", typeof(string));

            if (ObjClass.MobileNo != null)
            {
                for (int i = 0; i < ObjClass.MobileNo.Count; i++)
                {
                    DataRow dr = dtobjDBR.NewRow();
                    dr["MobileNo"] = ObjClass.MobileNo[i];

                    dtobjDBR.Rows.Add(dr);
                    dtobjDBR.AcceptChanges();
                }
            }

            var dtobjectDBR = new DataTable("TypeOtcVehicleDetail");
            dtobjectDBR.Columns.Add("VehicleNo", typeof(string));

            if (ObjClass.VechileNo != null)
            {
                for (int i = 0; i < ObjClass.VechileNo.Count; i++)
                {
                    DataRow dr = dtobjectDBR.NewRow();
                    dr["VehicleNo"] = ObjClass.VechileNo[i];

                    dtobjectDBR.Rows.Add(dr);
                    dtobjectDBR.AcceptChanges();
                }
            }



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
                        FileNamePathAddressProof = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                            + "_" + ObjClass.AddressProofType + "_" + ImageFileNameAddressProofFront.FileName;
                        string filePathAddressProofFront = contentRootPath + FileNamePathAddressProof;
                        var fileStream = new FileStream(filePathAddressProofFront, FileMode.Create);
                        ImageFileNameAddressProofFront.CopyTo(fileStream);
                    }
                }
            }

            string FileNamePathAddressBackProof = string.Empty;
            var ImageFileNameAddressProofBack = ObjClass.AddressBackProof;
            if (ImageFileNameAddressProofBack != null)
            {
                if (ImageFileNameAddressProofBack.Length > 0)
                {
                    IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
                    var ext = ImageFileNameAddressProofBack.FileName.Substring(ImageFileNameAddressProofBack.FileName.LastIndexOf('.'));
                    var extension = ext.ToLower();
                    if (AllowedFileExtensions.Contains(extension))
                    {

                        string contentRootPath = _hostingEnvironment.ContentRootPath;
                        FileNamePathAddressBackProof = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                            + "_" + ObjClass.AddressProofType + "_" + ImageFileNameAddressProofBack.FileName;
                        string filePathAddressProofBack = contentRootPath + FileNamePathAddressBackProof;
                        var fileStream = new FileStream(filePathAddressProofBack, FileMode.Create);
                        ImageFileNameAddressProofBack.CopyTo(fileStream);
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
                        FileNamePathIDProof = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                            + "_" + ObjClass.IDProofType + "_" + ImageFileNameIDProofFront.FileName;
                        string filePathIDFront = contentRootPath + FileNamePathIDProof;
                        var fileStream = new FileStream(filePathIDFront, FileMode.Create);
                        ImageFileNameIDProofFront.CopyTo(fileStream);
                    }
                }
            }

            string FileNamePathIDProofBack = string.Empty;
            var ImageFileNameIDProofBack = ObjClass.IDBackProof;
            if (ImageFileNameIDProofBack != null)
            {
                if (ImageFileNameIDProofBack.Length > 0)
                {
                    IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
                    var ext = ImageFileNameIDProofBack.FileName.Substring(ImageFileNameIDProofBack.FileName.LastIndexOf('.'));
                    var extension = ext.ToLower();
                    if (AllowedFileExtensions.Contains(extension))
                    {

                        string contentRootPath = _hostingEnvironment.ContentRootPath;
                        FileNamePathIDProofBack = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                            + "_" + ObjClass.IDProofType + "_" + ImageFileNameIDProofBack.FileName;
                        string filePathIDBack = contentRootPath + FileNamePathIDProofBack;
                        var fileStream = new FileStream(filePathIDBack, FileMode.Create);
                        ImageFileNameIDProofBack.CopyTo(fileStream);
                    }
                }
            }



            var procedureName = "UspInsertOTCCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerType", 918, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", 920, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgNameTitle", ObjClass.IndividualOrgNameTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgName", ObjClass.IndividualOrgName, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("IncomeTaxPan", ObjClass.IncomeTaxPan, DbType.String, ParameterDirection.Input);
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
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("AddressProofType", ObjClass.AddressProofType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("AddressProofDocumentNo", ObjClass.AddressProofDocumentNo, DbType.String, ParameterDirection.Input);
            parameters.Add("AddressProof", FileNamePathAddressProof, DbType.String, ParameterDirection.Input);
            parameters.Add("AddressBackProof", FileNamePathAddressBackProof, DbType.String, ParameterDirection.Input);
            parameters.Add("IDProofType", ObjClass.IDProofType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IDProofDocumentNo", ObjClass.IDProofDocumentNo, DbType.String, ParameterDirection.Input);
            parameters.Add("IDProof", FileNamePathIDProof, DbType.String, ParameterDirection.Input);
            parameters.Add("IDBackProof", FileNamePathIDProofBack, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("CopyofDriverLicense", ObjClass.CopyofDriverLicense, DbType.String, ParameterDirection.Input);
            parameters.Add("CopyofVehicleRegistrationCertificate", ObjClass.CopyofVehicleRegistrationCertificate, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOtcCardDetail", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("TypeOtcMobileDetail", dtobjDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("TypeOtcVehicleDetail", dtobjectDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantInsertOTCCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantCheckAvailityCardOutput>> CheckAvailityOTCCard([FromBody] MerchantCheckAvailityCardInput ObjClass)
        {
            var procedureName = "UspCheckAvailityDummyCard";
            var parameters = new DynamicParameters();
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CardType", "OTCCard", DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantCheckAvailityCardOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantGetAvailityCardOutput>> GetAvailityOTCCard([FromBody] MerchantGetAvailityCardInput ObjClass)
        {
            var procedureName = "UspGetAvailityDummyCard";
            var parameters = new DynamicParameters();
            parameters.Add("RegionalId", ObjClass.RegionalOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CardType", "OTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetAvailityCardOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<MerchantGetAllUnAllocatedCardsModelOutput> GetAllUnAllocatedCardsForOTCCard([FromBody] MerchantGetAllUnAllocatedCardsModelInput ObjClass)
        {
            var procedureName = "UspGetAllUnAllocatedCards";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "OTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            var storedProcedureResult = new MerchantGetAllUnAllocatedCardsModelOutput();
            storedProcedureResult.ObjNoOfUnAllocatedCard = (List<NoOfUnAllocatedCard>)await result.ReadAsync<NoOfUnAllocatedCard>();
            storedProcedureResult.ObjUnAllocatedCard = (List<UnAllocatedCard>)await result.ReadAsync<UnAllocatedCard>();
            return storedProcedureResult;

        }


        public async Task<IEnumerable<MerchantAllocatedCardsToMerchantModelOutput>> AllocatedOTCCardToMerchant([FromBody] MerchantAllocatedCardsToMerchantModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeCardNos");
            dtDBR.Columns.Add("CardNo", typeof(string));


            if (ObjClass.ObjAllocatedCardsToMerchant != null)
            {
                foreach (AllocatedCardsToMerchantModelInput ObjDetail in ObjClass.ObjAllocatedCardsToMerchant)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CardNo"] = ObjDetail.CardNo;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspAllocateUnAllocatedCardsToMerchant";
            var parameters = new DynamicParameters();
            parameters.Add("NoOfCardsAllocated", ObjClass.NoOfCardsAllocated, DbType.Int32, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("CardType", "OTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UpdateCardsAllocationReq", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantAllocatedCardsToMerchantModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantViewRequestedCardModelOutput>> ViewRequestedOTCCard([FromBody] MerchantViewRequestedCardModelInput ObjClass)
        {
            var procedureName = "UspViewRequestedMyCard";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "OTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalId", ObjClass.RegionalId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantViewRequestedCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<MerchantInsertDealerWiseCardRequestModelOutput>> InsertDealerWiseOTCCardRequest([FromBody] MerchantInsertDealerWiseCardRequestModelInput ObjClass)
        {
            var procedureName = "UspInsertMerchantWiseOTCTatkalDriverCard";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("NoofCards", ObjClass.NoofCards, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CardType", "OTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantInsertDealerWiseCardRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<MerchantViewCardMerchantAllocationModelOutput> ViewOTCCardMerchantAllocation([FromBody] MerchantViewCardMerchantAllocationModelInput ObjClass)
        {
            var procedureName = "UspViewCardMerchantAllocation";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "OTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new MerchantViewCardMerchantAllocationModelOutput();
            storedProcedureResult.ObjMerchantTotalCardDetail = (List<MerchantTotalCardModelOutput>)await result.ReadAsync<MerchantTotalCardModelOutput>();
            storedProcedureResult.ObjMerchantViewCardDetail = (List<MerchantViewCardMerchantDetailModelOutput>)await result.ReadAsync<MerchantViewCardMerchantDetailModelOutput>();
            return storedProcedureResult;
        }


        public async Task<IEnumerable<CardRequestEntryModelOutput>> InsertOTCCardRequest([FromBody] CardRequestEntryModelInput ObjClass)
        {
            var procedureName = "UspInsertOTCTatkalDriverCard";
            var parameters = new DynamicParameters();
            parameters.Add("RegionalId", ObjClass.RegionalId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("NoofCards", ObjClass.NoofCards, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CardType", "OTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CardRequestEntryModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCardAllocationActivationModelOutput>> GetOTCCardAllocationActivation([FromBody] GetCardAllocationActivationModelInput ObjClass)
        {
            var procedureName = "UspGetCardAllocationActivation";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CardType", "OTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCardAllocationActivationModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<VerifyOTCCardCustomerModelOutput>> VerifyOTCCardCustomer([FromBody] VerifyOTCCardCustomerModelInput ObjClass)
        {
            var procedureName = "UspVerifyOTCCardCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<VerifyOTCCardCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerGetRegionalOfficerModelOutput>> GetAvailityOTCCardUserWise([FromBody] CustomerGetRegionalOfficerModelInput ObjClass)
        {
            var procedureName = "UspGetAvailityDummyCardUserRegionWise";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "OTCCard", DbType.String, ParameterDirection.Input);
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerGetRegionalOfficerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        //public async Task<IEnumerable<OTCInsertOTCCustomerRegionWiseModelOutput>> InsertOTCCustomerRegionWise([FromForm] OTCInsertOTCCustomerRegionWiseModelInput ObjClass)
        //{
        //    var dtDBR = new DataTable("UserInsertOTCCard");
        //    dtDBR.Columns.Add("CardNo", typeof(string));
        //    dtDBR.Columns.Add("CardIdentifier", typeof(string));
        //    dtDBR.Columns.Add("MobileNo", typeof(string));

        //    if (ObjClass.ObjOTCCardEntryDetail != null)
        //    {
        //        foreach (UserInsertOTCCardDetails ObjCardDetails in ObjClass.ObjOTCCardEntryDetail)
        //        {
        //            DataRow dr = dtDBR.NewRow();
        //            dr["CardNo"] = ObjCardDetails.CardNo;
        //            dr["CardIdentifier"] = ObjCardDetails.VechileNo;
        //            dr["MobileNo"] = ObjCardDetails.MobileNo;

        //            dtDBR.Rows.Add(dr);
        //            dtDBR.AcceptChanges();
        //        }
        //    }

        //    string FileNamePathAddressProof = string.Empty;
        //    var ImageFileNameAddressProofFront = ObjClass.AddressProof;
        //    if (ImageFileNameAddressProofFront != null)
        //    {
        //        if (ImageFileNameAddressProofFront.Length > 0)
        //        {
        //            IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
        //            var ext = ImageFileNameAddressProofFront.FileName.Substring(ImageFileNameAddressProofFront.FileName.LastIndexOf('.'));
        //            var extension = ext.ToLower();
        //            if (AllowedFileExtensions.Contains(extension))
        //            {

        //                string contentRootPath = _hostingEnvironment.ContentRootPath;
        //                FileNamePathAddressProof = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
        //                    + "_" + ObjClass.AddressProofType + "_" + ImageFileNameAddressProofFront.FileName;
        //                string filePathAddressProofFront = contentRootPath + FileNamePathAddressProof;
        //                var fileStream = new FileStream(filePathAddressProofFront, FileMode.Create);
        //                ImageFileNameAddressProofFront.CopyTo(fileStream);
        //            }
        //        }
        //    }

        //    string FileNamePathAddressBackProof = string.Empty;
        //    var ImageFileNameAddressProofBack = ObjClass.AddressBackProof;
        //    if (ImageFileNameAddressProofBack != null)
        //    {
        //        if (ImageFileNameAddressProofBack.Length > 0)
        //        {
        //            IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
        //            var ext = ImageFileNameAddressProofBack.FileName.Substring(ImageFileNameAddressProofBack.FileName.LastIndexOf('.'));
        //            var extension = ext.ToLower();
        //            if (AllowedFileExtensions.Contains(extension))
        //            {

        //                string contentRootPath = _hostingEnvironment.ContentRootPath;
        //                FileNamePathAddressBackProof = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
        //                    + "_" + ObjClass.AddressProofType + "_" + ImageFileNameAddressProofBack.FileName;
        //                string filePathAddressProofBack = contentRootPath + FileNamePathAddressBackProof;
        //                var fileStream = new FileStream(filePathAddressProofBack, FileMode.Create);
        //                ImageFileNameAddressProofBack.CopyTo(fileStream);
        //            }
        //        }
        //    }

        //    string FileNamePathIDProof = string.Empty;
        //    var ImageFileNameIDProofFront = ObjClass.IDProof;
        //    if (ImageFileNameIDProofFront != null)
        //    {
        //        if (ImageFileNameIDProofFront.Length > 0)
        //        {
        //            IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
        //            var ext = ImageFileNameIDProofFront.FileName.Substring(ImageFileNameIDProofFront.FileName.LastIndexOf('.'));
        //            var extension = ext.ToLower();
        //            if (AllowedFileExtensions.Contains(extension))
        //            {

        //                string contentRootPath = _hostingEnvironment.ContentRootPath;
        //                FileNamePathIDProof = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
        //                    + "_" + ObjClass.IDProofType + "_" + ImageFileNameIDProofFront.FileName;
        //                string filePathIDFront = contentRootPath + FileNamePathIDProof;
        //                var fileStream = new FileStream(filePathIDFront, FileMode.Create);
        //                ImageFileNameIDProofFront.CopyTo(fileStream);
        //            }
        //        }
        //    }

        //    string FileNamePathIDProofBack = string.Empty;
        //    var ImageFileNameIDProofBack = ObjClass.IDBackProof;
        //    if (ImageFileNameIDProofBack != null)
        //    {
        //        if (ImageFileNameIDProofBack.Length > 0)
        //        {
        //            IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
        //            var ext = ImageFileNameIDProofBack.FileName.Substring(ImageFileNameIDProofBack.FileName.LastIndexOf('.'));
        //            var extension = ext.ToLower();
        //            if (AllowedFileExtensions.Contains(extension))
        //            {

        //                string contentRootPath = _hostingEnvironment.ContentRootPath;
        //                FileNamePathIDProofBack = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
        //                    + "_" + ObjClass.IDProofType + "_" + ImageFileNameIDProofBack.FileName;
        //                string filePathIDBack = contentRootPath + FileNamePathIDProofBack;
        //                var fileStream = new FileStream(filePathIDBack, FileMode.Create);
        //                ImageFileNameIDProofBack.CopyTo(fileStream);
        //            }
        //        }
        //    }


        //    var procedureName = "UspInsertOTCCustomerRegionWise";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("CustomerType", 918, DbType.Int32, ParameterDirection.Input);
        //    parameters.Add("CustomerSubtype", 920, DbType.Int32, ParameterDirection.Input);
        //    parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
        //    parameters.Add("IndividualOrgNameTitle", ObjClass.IndividualOrgNameTitle, DbType.String, ParameterDirection.Input);
        //    parameters.Add("IndividualOrgName", ObjClass.IndividualOrgName, DbType.String, ParameterDirection.Input);
        //    parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
        //    parameters.Add("IncomeTaxPan", ObjClass.IncomeTaxPan, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CommunicationAddress1", ObjClass.CommunicationAddress1, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CommunicationAddress2", ObjClass.CommunicationAddress2, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CommunicationCityName", ObjClass.CommunicationCityName, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CommunicationPincode", ObjClass.CommunicationPincode, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.Int32, ParameterDirection.Input);
        //    parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.Int32, ParameterDirection.Input);
        //    parameters.Add("CommunicationPhoneNo", ObjClass.CommunicationPhoneNo, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CommunicationFax", ObjClass.CommunicationFax, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CommunicationMobileNo", ObjClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CommunicationEmailid", ObjClass.CommunicationEmailid, DbType.String, ParameterDirection.Input);
        //    parameters.Add("AddressProofType", ObjClass.AddressProofType, DbType.Int32, ParameterDirection.Input);
        //    parameters.Add("AddressProofDocumentNo", ObjClass.AddressProofDocumentNo, DbType.String, ParameterDirection.Input);
        //    parameters.Add("AddressProof", FileNamePathAddressProof, DbType.String, ParameterDirection.Input);
        //    parameters.Add("AddressBackProof", FileNamePathAddressBackProof, DbType.String, ParameterDirection.Input);
        //    parameters.Add("IDProofType", ObjClass.IDProofType, DbType.Int32, ParameterDirection.Input);
        //    parameters.Add("IDProofDocumentNo", ObjClass.IDProofDocumentNo, DbType.String, ParameterDirection.Input);
        //    parameters.Add("IDProof", FileNamePathIDProof, DbType.String, ParameterDirection.Input);
        //    parameters.Add("IDBackProof", FileNamePathIDProofBack, DbType.String, ParameterDirection.Input);
        //    parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
        //    parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
        //    parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
        //    parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
        //    parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
        //    parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CopyofDriverLicense", ObjClass.CopyofDriverLicense, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CopyofVehicleRegistrationCertificate", ObjClass.CopyofVehicleRegistrationCertificate, DbType.String, ParameterDirection.Input);
        //    parameters.Add("InsertOTCCard", dtDBR, DbType.Object, ParameterDirection.Input);
        //    using var connection = _context.CreateConnection();
        //    return await connection.QueryAsync<OTCInsertOTCCustomerRegionWiseModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        //}


        public async Task<IEnumerable<OTCInsertOTCCustomerRegionWiseModelOutput>> InsertOTCCustomerRegionWise([FromForm] OTCInsertOTCCustomerRegionWiseModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeOtcCardDetail");
            dtDBR.Columns.Add("CardNo", typeof(string));
            if (ObjClass.CardNo != null)
            {

                for (int i = 0; i < ObjClass.CardNo.Count; i++)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CardNo"] = ObjClass.CardNo[i];
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }

            }

            var dtobjDBR = new DataTable("TypeOtcMobileDetail");
            dtobjDBR.Columns.Add("MobileNo", typeof(string));

            if (ObjClass.MobileNo != null)
            {
                for (int i = 0; i < ObjClass.MobileNo.Count; i++)
                {
                    DataRow dr = dtobjDBR.NewRow();
                    dr["MobileNo"] = ObjClass.MobileNo[i];

                    dtobjDBR.Rows.Add(dr);
                    dtobjDBR.AcceptChanges();
                }
            }

            var dtobjectDBR = new DataTable("TypeOtcVehicleDetail");
            dtobjectDBR.Columns.Add("VehicleNo", typeof(string));

            if (ObjClass.VechileNo != null)
            {
                for (int i = 0; i < ObjClass.VechileNo.Count; i++)
                {
                    DataRow dr = dtobjectDBR.NewRow();
                    dr["VehicleNo"] = ObjClass.VechileNo[i];

                    dtobjectDBR.Rows.Add(dr);
                    dtobjectDBR.AcceptChanges();
                }
            }


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
                        FileNamePathAddressProof = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                            + "_" + ObjClass.AddressProofType + "_" + ImageFileNameAddressProofFront.FileName;
                        string filePathAddressProofFront = contentRootPath + FileNamePathAddressProof;
                        var fileStream = new FileStream(filePathAddressProofFront, FileMode.Create);
                        ImageFileNameAddressProofFront.CopyTo(fileStream);
                    }
                }
            }

            string FileNamePathAddressBackProof = string.Empty;
            var ImageFileNameAddressProofBack = ObjClass.AddressBackProof;
            if (ImageFileNameAddressProofBack != null)
            {
                if (ImageFileNameAddressProofBack.Length > 0)
                {
                    IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
                    var ext = ImageFileNameAddressProofBack.FileName.Substring(ImageFileNameAddressProofBack.FileName.LastIndexOf('.'));
                    var extension = ext.ToLower();
                    if (AllowedFileExtensions.Contains(extension))
                    {

                        string contentRootPath = _hostingEnvironment.ContentRootPath;
                        FileNamePathAddressBackProof = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                            + "_" + ObjClass.AddressProofType + "_" + ImageFileNameAddressProofBack.FileName;
                        string filePathAddressProofBack = contentRootPath + FileNamePathAddressBackProof;
                        var fileStream = new FileStream(filePathAddressProofBack, FileMode.Create);
                        ImageFileNameAddressProofBack.CopyTo(fileStream);
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
                        FileNamePathIDProof = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                            + "_" + ObjClass.IDProofType + "_" + ImageFileNameIDProofFront.FileName;
                        string filePathIDFront = contentRootPath + FileNamePathIDProof;
                        var fileStream = new FileStream(filePathIDFront, FileMode.Create);
                        ImageFileNameIDProofFront.CopyTo(fileStream);
                    }
                }
            }

            string FileNamePathIDProofBack = string.Empty;
            var ImageFileNameIDProofBack = ObjClass.IDBackProof;
            if (ImageFileNameIDProofBack != null)
            {
                if (ImageFileNameIDProofBack.Length > 0)
                {
                    IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
                    var ext = ImageFileNameIDProofBack.FileName.Substring(ImageFileNameIDProofBack.FileName.LastIndexOf('.'));
                    var extension = ext.ToLower();
                    if (AllowedFileExtensions.Contains(extension))
                    {

                        string contentRootPath = _hostingEnvironment.ContentRootPath;
                        FileNamePathIDProofBack = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                            + "_" + ObjClass.IDProofType + "_" + ImageFileNameIDProofBack.FileName;
                        string filePathIDBack = contentRootPath + FileNamePathIDProofBack;
                        var fileStream = new FileStream(filePathIDBack, FileMode.Create);
                        ImageFileNameIDProofBack.CopyTo(fileStream);
                    }
                }
            }
            var procedureName = "UspInsertOTCCustomerRegionWise";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerType", 918, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", 920, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgNameTitle", ObjClass.IndividualOrgNameTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgName", ObjClass.IndividualOrgName, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("IncomeTaxPan", ObjClass.IncomeTaxPan, DbType.String, ParameterDirection.Input);
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
            parameters.Add("AddressProofType", ObjClass.AddressProofType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("AddressProofDocumentNo", ObjClass.AddressProofDocumentNo, DbType.String, ParameterDirection.Input);
            parameters.Add("AddressProof", FileNamePathAddressProof, DbType.String, ParameterDirection.Input);
            parameters.Add("AddressBackProof", FileNamePathAddressBackProof, DbType.String, ParameterDirection.Input);
            parameters.Add("IDProofType", ObjClass.IDProofType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IDProofDocumentNo", ObjClass.IDProofDocumentNo, DbType.String, ParameterDirection.Input);
            parameters.Add("IDProof", FileNamePathIDProof, DbType.String, ParameterDirection.Input);
            parameters.Add("IDBackProof", FileNamePathIDProofBack, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("CopyofDriverLicense", ObjClass.CopyofDriverLicense, DbType.String, ParameterDirection.Input);
            parameters.Add("CopyofVehicleRegistrationCertificate", ObjClass.CopyofVehicleRegistrationCertificate, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOtcCardDetail", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("TypeOtcMobileDetail", dtobjDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("TypeOtcVehicleDetail", dtobjectDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<OTCInsertOTCCustomerRegionWiseModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<IEnumerable<GetOTCVehicleSpecificCardRequestModelOutput>> GetOTCVehicleSpecificCardRequest([FromBody] GetOTCVehicleSpecificCardRequestModelInput ObjClass)
        {
            var procedureName = "UspGetOTCVehicleSpecificCardRequest";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetOTCVehicleSpecificCardRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InsertOTCVehicleSpecificCardRequestModelOutput>> InsertOTCVehicleSpecificCardRequest([FromBody] InsertOTCVehicleSpecificCardRequestModelInput ObjClass)
        {
            var dtDBR = new DataTable("VehicleSpecificCard");
            dtDBR.Columns.Add("CardNo", typeof(string));
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("VehicleType", typeof(string));
            dtDBR.Columns.Add("VinNumber", typeof(string));

            if (ObjClass.lstVehicleSpecificCard != null)
            {
                foreach (OTCVehicleSpecificCard ObjCardDetails in ObjClass.lstVehicleSpecificCard)
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

            var procedureName = "UspInsertOTCVehicleSpecificCardRequest";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleSpecificCard", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertOTCVehicleSpecificCardRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

       

        public async Task<IEnumerable<GetOTCVehicleSpecificCardApproveModelOutput>> GetOTCVehicleSpecificCardApprove([FromBody] GetOTCVehicleSpecificCardApproveModelInput ObjClass)
        {
            var procedureName = "UspGetOTCVehicleSpecificCardRequestApprove";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetOTCVehicleSpecificCardApproveModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ApproveOTCVehicleSpecificCardApproveModelOutput>> InsertOTCVehicleSpecificCardRequestApprove([FromBody] ApproveOTCVehicleSpecificCardApproveModelInput ObjClass)
        {
            var dtDBR = new DataTable("VehicleSpecificCardApprove");
            dtDBR.Columns.Add("Id", typeof(string));
            dtDBR.Columns.Add("PreviousCardNo", typeof(string));
            dtDBR.Columns.Add("FormNumber", typeof(string));
            dtDBR.Columns.Add("Comments", typeof(string));
            dtDBR.Columns.Add("CustomerID", typeof(string));

            if (ObjClass.lstVehicleSpecificCardApprove != null)
            {
                foreach (OTCVehicleSpecificCardApprove ObjCardDetails in ObjClass.lstVehicleSpecificCardApprove)
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
            return await connection.QueryAsync<ApproveOTCVehicleSpecificCardApproveModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


    }
}
