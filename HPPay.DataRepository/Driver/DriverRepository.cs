using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.Merchant;
using HPPay.DataRepository.DBDapper;
using HPPay.Infrastructure.CommonClass;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace HPPay.DataRepository.Driver
{
    public class DriverRepository: IDriverRepository
    {
        private readonly DapperContext _context;

        private readonly IHostingEnvironment _hostingEnvironment;
        public DriverRepository(DapperContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IEnumerable<MerchantCheckAvailityCardOutput>> CheckAvailityDriverCard([FromBody] MerchantCheckAvailityCardInput ObjClass)
        {
            var procedureName = "UspCheckAvailityDummyCard";
            var parameters = new DynamicParameters();
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CardType", "DriverCard", DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantCheckAvailityCardOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantGetAvailityCardOutput>> GetAvailityDriverCard([FromBody] MerchantGetAvailityCardInput ObjClass)
        {
            var procedureName = "UspGetAvailityDummyCard";
            var parameters = new DynamicParameters();
            parameters.Add("RegionalId", ObjClass.RegionalOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CardType", "DriverCard", DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetAvailityCardOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<MerchantGetAllUnAllocatedCardsModelOutput> GetAllUnAllocatedCardsForDriverCard([FromBody] MerchantGetAllUnAllocatedCardsModelInput ObjClass)
        {
            var procedureName = "UspGetAllUnAllocatedCards";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "DriverCard", DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            var storedProcedureResult = new MerchantGetAllUnAllocatedCardsModelOutput();
            storedProcedureResult.ObjNoOfUnAllocatedCard = (List<NoOfUnAllocatedCard>)await result.ReadAsync<NoOfUnAllocatedCard>();
            storedProcedureResult.ObjUnAllocatedCard = (List<UnAllocatedCard>)await result.ReadAsync<UnAllocatedCard>();
            return storedProcedureResult;

        }

        public async Task<IEnumerable<MerchantAllocatedCardsToMerchantModelOutput>> AllocatedDriverCardToMerchant([FromBody] MerchantAllocatedCardsToMerchantModelInput ObjClass)
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
            parameters.Add("CardType", "DriverCard", DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UpdateCardsAllocationReq", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantAllocatedCardsToMerchantModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantInsertDriverCardCustomerModelOutput>> InsertDriverCardCustomer([FromForm] MerchantInsertDriverCardCustomerModelInput ObjClass)
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



            var procedureName = "UspInsertDriverCardCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerType", 927, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", 929, DbType.Int32, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgNameTitle", ObjClass.IndividualOrgNameTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgName", ObjClass.IndividualOrgName, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCityName", ObjClass.CommunicationCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPincode", ObjClass.CommunicationPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationEmailid", ObjClass.CommunicationEmailid, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPhoneNo", ObjClass.CommunicationPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationMobileNo", ObjClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress1", ObjClass.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("IncomeTaxPan", ObjClass.IncomeTaxPan, DbType.String, ParameterDirection.Input);
            parameters.Add("AddressProofType", ObjClass.AddressProofType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("AddressProofDocumentNo", ObjClass.AddressProofDocumentNo, DbType.String, ParameterDirection.Input);
            parameters.Add("AddressProof", FileNamePathAddressProof, DbType.String, ParameterDirection.Input);
            parameters.Add("AddressBackProof", FileNamePathAddressBackProof, DbType.String, ParameterDirection.Input);
            parameters.Add("IDProofType", ObjClass.IDProofType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IDProofDocumentNo", ObjClass.IDProofDocumentNo, DbType.String, ParameterDirection.Input);
            parameters.Add("IDProof", FileNamePathIDProof, DbType.String, ParameterDirection.Input);
            parameters.Add("IDBackProof", FileNamePathIDProofBack, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("DrivingLicence", ObjClass.DrivingLicence, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPCustomerStatus", ObjClass.DTPCustomerStatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ExistingCustomerId", ObjClass.ExistingCustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("BeneficiaryName", ObjClass.BeneficiaryName, DbType.String, ParameterDirection.Input);
            parameters.Add("RelationwithBeneficiary", ObjClass.RelationwithBeneficiary, DbType.String, ParameterDirection.Input);
            parameters.Add("BeneficiaryMobile", ObjClass.BeneficiaryMobile, DbType.String, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantInsertDriverCardCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantViewRequestedCardModelOutput>> ViewRequestedDriverCard([FromBody] MerchantViewRequestedCardModelInput ObjClass)
        {
            var procedureName = "UspViewRequestedMyCard";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "DriverCard", DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalId", ObjClass.RegionalId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantViewRequestedCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantInsertDealerWiseCardRequestModelOutput>> InsertDealerWiseDriverCardRequest([FromBody] MerchantInsertDealerWiseCardRequestModelInput ObjClass)
        {
            var procedureName = "UspInsertMerchantWiseOTCTatkalDriverCard";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("NoofCards", ObjClass.NoofCards, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CardType", "DriverCard", DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantInsertDealerWiseCardRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<MerchantViewCardMerchantAllocationModelOutput> ViewDriverCardMerchantAllocation([FromBody] MerchantViewCardMerchantAllocationModelInput ObjClass)
        {
            var procedureName = "UspViewCardMerchantAllocation";
            var parameters = new DynamicParameters();
            parameters.Add("CardType", "DriverCard", DbType.String, ParameterDirection.Input);
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

        public async Task<IEnumerable<CardRequestEntryModelOutput>> InsertDriverCardRequest([FromBody] CardRequestEntryModelInput ObjClass)
        {
            var procedureName = "UspInsertOTCTatkalDriverCard";
            var parameters = new DynamicParameters();
            parameters.Add("RegionalId", ObjClass.RegionalId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("NoofCards", ObjClass.NoofCards, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CardType", "DriverCard", DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CardRequestEntryModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCardAllocationActivationModelOutput>> GetDriverCardAllocationActivation([FromBody] GetCardAllocationActivationModelInput ObjClass)
        {
            var procedureName = "UspGetCardAllocationActivation";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("CardType", "DriverCard", DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCardAllocationActivationModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


    }
}
