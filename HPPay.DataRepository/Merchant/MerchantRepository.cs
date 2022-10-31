using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.Merchant;
using HPPay.DataModel.Transaction;
using HPPay.DataRepository.DBDapper;
using HPPay.Infrastructure.CommonClass;
using HPPay.Infrastructure.TokenManager;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using static HPPay.Infrastructure.CommonClass.StatusMessage;

namespace HPPay.DataRepository.Merchant
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly DapperContext _context;
        public string Status = "Initited";
        public int OTPtype = 2;
        public MerchantRepository(DapperContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<GetMerchantTypeModelOutput>> GetMerchantType([FromBody] GetMerchantTypeModelInput ObjClass)
        {
            var procedureName = "UspGetMerchantType";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetMerchantTypeModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetMerchantOutletCategoryModelOutput>> GetOutletCategory([FromBody] GetMerchantOutletCategoryModelInput ObjClass)
        {
            var procedureName = "UspGetOutletCategory";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetMerchantOutletCategoryModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantGetSBUModelOutput>> GetSBU([FromBody] MerchantGetSBUModelInput ObjClass)
        {
            var procedureName = "UspGetSBU";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetSBUModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantInsertModelOutput>> InsertMerchant([FromBody] MerchantInsertModelInput ObjClass)
        {
            var procedureName = "UspInsertMerchant";
            var parameters = new DynamicParameters();
            parameters.Add("ErpCode", ObjClass.ErpCode, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletName", ObjClass.RetailOutletName, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantTypeId", ObjClass.MerchantTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("DealerName", ObjClass.DealerName, DbType.String, ParameterDirection.Input);
            parameters.Add("MappedMerchantId", ObjClass.MappedMerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("DealerMobileNo", ObjClass.DealerMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("OutletCategoryId", ObjClass.OutletCategoryId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("HighwayNo1", ObjClass.HighwayNo1, DbType.String, ParameterDirection.Input);
            parameters.Add("HighwayNo2", ObjClass.HighwayNo2, DbType.String, ParameterDirection.Input);
            parameters.Add("HighwayName", ObjClass.HighwayName, DbType.String, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("LPGCNGSale", ObjClass.LPGCNGSale, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("PancardNumber", ObjClass.PancardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("GSTNumber", ObjClass.GSTNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletAddress1", ObjClass.RetailOutletAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletAddress2", ObjClass.RetailOutletAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletAddress3", ObjClass.RetailOutletAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletLocation", ObjClass.RetailOutletLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletCity", ObjClass.RetailOutletCity, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletStateId", ObjClass.RetailOutletStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RetailOutletDistrictId", ObjClass.RetailOutletDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RetailOutletPinNumber", ObjClass.RetailOutletPinNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletPhoneNumber", ObjClass.RetailOutletPhoneNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletFax", ObjClass.RetailOutletFax, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("SalesAreaId", ObjClass.SalesAreaId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ContactPersonNameFirstName", ObjClass.ContactPersonNameFirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("ContactPersonNameMiddleName", ObjClass.ContactPersonNameMiddleName, DbType.String, ParameterDirection.Input);
            parameters.Add("ContactPersonNameLastName", ObjClass.ContactPersonNameLastName, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("EmailId", ObjClass.EmailId, DbType.String, ParameterDirection.Input);
            parameters.Add("Mics", ObjClass.Mics, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress1", ObjClass.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress2", ObjClass.CommunicationAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress3", ObjClass.CommunicationAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationLocation", ObjClass.CommunicationLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCity", ObjClass.CommunicationCity, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationPinNumber", ObjClass.CommunicationPinNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPhoneNumber", ObjClass.CommunicationPhoneNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationFax", ObjClass.CommunicationFax, DbType.String, ParameterDirection.Input);
            parameters.Add("NoofLiveTerminals", ObjClass.NoofLiveTerminals, DbType.Int32, ParameterDirection.Input);
            parameters.Add("TerminalTypeRequested", ObjClass.TerminalTypeRequested, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantInsertModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<MerchantUpdateModelOutput>> UpdateMerchant([FromBody] MerchantUpdateModelInput ObjClass)
        {
            var procedureName = "UspUpdateMerchant";
            var parameters = new DynamicParameters();
            parameters.Add("ErpCode", ObjClass.ErpCode, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletName", ObjClass.RetailOutletName, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantTypeId", ObjClass.MerchantTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("DealerName", ObjClass.DealerName, DbType.String, ParameterDirection.Input);
            parameters.Add("DealerMobileNo", ObjClass.DealerMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("OutletCategoryId", ObjClass.OutletCategoryId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("HighwayNo1", ObjClass.HighwayNo1, DbType.String, ParameterDirection.Input);
            parameters.Add("HighwayNo2", ObjClass.HighwayNo2, DbType.String, ParameterDirection.Input);
            parameters.Add("HighwayName", ObjClass.HighwayName, DbType.String, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("LPGCNGSale", ObjClass.LPGCNGSale, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("PancardNumber", ObjClass.PancardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("GSTNumber", ObjClass.GSTNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletAddress1", ObjClass.RetailOutletAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletAddress2", ObjClass.RetailOutletAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletAddress3", ObjClass.RetailOutletAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletLocation", ObjClass.RetailOutletLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletCity", ObjClass.RetailOutletCity, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletStateId", ObjClass.RetailOutletStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RetailOutletDistrictId", ObjClass.RetailOutletDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RetailOutletPinNumber", ObjClass.RetailOutletPinNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletPhoneNumber", ObjClass.RetailOutletPhoneNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletFax", ObjClass.RetailOutletFax, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("SalesAreaId", ObjClass.SalesAreaId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ContactPersonNameFirstName", ObjClass.ContactPersonNameFirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("ContactPersonNameMiddleName", ObjClass.ContactPersonNameMiddleName, DbType.String, ParameterDirection.Input);
            parameters.Add("ContactPersonNameLastName", ObjClass.ContactPersonNameLastName, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("EmailId", ObjClass.EmailId, DbType.String, ParameterDirection.Input);
            parameters.Add("Mics", ObjClass.Mics, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress1", ObjClass.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress2", ObjClass.CommunicationAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress3", ObjClass.CommunicationAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationLocation", ObjClass.CommunicationLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCity", ObjClass.CommunicationCity, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationPinNumber", ObjClass.CommunicationPinNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPhoneNumber", ObjClass.CommunicationPhoneNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationFax", ObjClass.CommunicationFax, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantUpdateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<MerchantApprovalRejectModelOutput>> ApproveRejectMerchant([FromBody] MerchantApprovalRejectModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeUpdateMerchant");
            dtDBR.Columns.Add("ErpCode", typeof(string));
            dtDBR.Columns.Add("Comments", typeof(string));

            var procedureName = "UspApproveRejectMerchant";
            var parameters = new DynamicParameters();
            //parameters.Add("ErpCode", ObjClass.ErpCode, DbType.String, ParameterDirection.Input);
            //parameters.Add("Comments", ObjClass.Comments, DbType.String, ParameterDirection.Input);

            if (ObjClass.ObjApprovalRejectDetail != null)
            {
                foreach (ApprovalRejectModelInput ObjCardDetails in ObjClass.ObjApprovalRejectDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["ErpCode"] = ObjCardDetails.ErpCode;
                    dr["Comments"] = ObjCardDetails.Comments;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            parameters.Add("UpdateMerchant", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("StatusId", ObjClass.StatusId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantApprovalRejectModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetNewlyCreatedTerminalIdsBasedOnErpCodesModelOutput>> GetNewlyCreatedTerminalIdsBasedOnErpCodes([FromBody] GetNewlyCreatedTerminalIdsBasedOnErpCodesModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeUpdateMerchant");
            dtDBR.Columns.Add("ErpCode", typeof(string));
            dtDBR.Columns.Add("Comments", typeof(string));

            var procedureName = "UspGetNewlyCreatedTerminalIdsBasedOnErpCodes";
            var parameters = new DynamicParameters();

            if (ObjClass.ObjApprovalRejectDetail != null)
            {
                foreach (ApprovalRejectModelInput ObjCardDetails in ObjClass.ObjApprovalRejectDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["ErpCode"] = ObjCardDetails.ErpCode;
                    dr["Comments"] = ObjCardDetails.Comments;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            parameters.Add("TypeErpCodes", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetNewlyCreatedTerminalIdsBasedOnErpCodesModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantGetByMerchantIdModelOutput>> GetMerchantbyMerchantId([FromBody] MerchantGetByMerchantIdModelInput ObjClass)
        {
            var procedureName = "UspGetMerchant";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetByMerchantIdModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetMerchantDataUpdateRequestBeforeApprovalModelOutput>> GetMerchantDataUpdateRequestBeforeApproval([FromBody] GetMerchantDataUpdateRequestBeforeApprovalModelInput ObjClass)
        {
            var procedureName = "UspGetUpdateRequestValueForMerchant";
            var parameters = new DynamicParameters();
            parameters.Add("ErpCode", ObjClass.ErpCode, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetMerchantDataUpdateRequestBeforeApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<MerchantGetByMerchantIdModelOutput>> GetMerchantbyERPCode([FromBody] MerchantGetByErpCodeModelInput ObjClass)
        {
            var procedureName = "UspGetMerchantbyErpCode";
            var parameters = new DynamicParameters();
            parameters.Add("ErpCode", ObjClass.ErpCode, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetByMerchantIdModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantGetMerchantApprovalModelOutput>> GetMerchantApproval([FromBody] MerchantGetMerchantApprovalModelInput ObjClass)
        {
            var procedureName = "UspGetMerchantApproval";
            var parameters = new DynamicParameters();
            parameters.Add("Category", ObjClass.Category, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetMerchantApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<RejectedMerchantModelOutput>> GetRejectedMerchant([FromBody] RejectedMerchantModelInput ObjClass)
        {
            var procedureName = "UspGetRejectedMerchant";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<RejectedMerchantModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<MerchantSearchMerchantForCardCreationModelOutput>> SearchMerchantForCardCreation([FromBody] MerchantSearchMerchantForCardCreationModelInput ObjClass)
        {
            var procedureName = "UspSearchMerchantForCardCreation";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantSearchMerchantForCardCreationModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<VerifyMerchantByMerchantIdModelOutput>> VerifyMerchantByMerchantId([FromBody] VerifyMerchantByMerchantIdModelInput ObjClass)
        {
            var procedureName = "UspVerifyMerchantID";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<VerifyMerchantByMerchantIdModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<VerifyMerchantByMerchantIdandRegionalIdModelOutput>> VerifyMerchantByMerchantIdandRegionalId([FromBody] VerifyMerchantByMerchantIdandRegionalIdModelInput ObjClass)
        {
            var procedureName = "UspVerifyMerchantIDWithRegionId";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<VerifyMerchantByMerchantIdandRegionalIdModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantSearchMerchantModelOutput>> SearchMerchant([FromBody] MerchantSearchMerchantModelInput ObjClass)
        {
            var procedureName = "UspSearchMerchant";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("ErpCode", ObjClass.ErpCode, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletName", ObjClass.RetailOutletName, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletCity", ObjClass.RetailOutletCity, DbType.String, ParameterDirection.Input);
            parameters.Add("HighwayNo", ObjClass.HighwayNo, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantStatus", ObjClass.MerchantStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantSearchMerchantModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantGetMerchantStatusModelOutput>> GetMerchantStatus([FromBody] MerchantGetMerchantStatusModelInput ObjClass)
        {
            var procedureName = "UspGetMerchantStatus";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetMerchantStatusModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantViewMerchantCautionLimitModelOutput>> ViewMerchantCautionLimit([FromBody] MerchantViewMerchantCautionLimitModelInput ObjClass)
        {
            var procedureName = "UspViewMerchantCautionLimit";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantStatus", ObjClass.MerchantStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOffice", ObjClass.RegionalOffice, DbType.String, ParameterDirection.Input);
            parameters.Add("SalesArea", ObjClass.SalesArea, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantViewMerchantCautionLimitModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantSettlementDetailsModelOutput>> MerchantSettlementDetail([FromBody] MerchantSettlementDetailsModelInput ObjClass)
        {
            var procedureName = "UspSettlementDetails";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantSettlementDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantBatchDetailModelOutput>> MerchantBatchDetail([FromBody] MerchantBatchDetailModelInput ObjClass)
        {
            var procedureName = "UspBatchDetails";
            var parameters = new DynamicParameters();
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("BatchId", ObjClass.BatchId, DbType.Int64, ParameterDirection.Input);
            //parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            //parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantBatchDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantTransactionDetailModelOutput>> MerchantTransactionDetail([FromBody] MerchantTransactionDetailModelInput ObjClass)
        {
            var procedureName = "UspMerchantTransactionDetails";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionType", ObjClass.TransactionType, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantTransactionDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<MerchantSaleReloadDeltaDetailModelOutput>> MerchantSaleReloadDeltaDetail([FromBody] MerchantSaleReloadDeltaDetailModelInput ObjClass)
        {
            var procedureName = "UspMerchantSaleReloadDeltaDetails";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantSaleReloadDeltaDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<MerchantERPReloadSaleEarningDetailModelOutput>> MerchantERPReloadSaleEarningDetail([FromBody] MerchantERPReloadSaleEarningDetailModelInput ObjClass)
        {
            var procedureName = "UspMerchantERPReloadSaleEarningDetails";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantERPReloadSaleEarningDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<MerchantReceivablePayableDetailModelOutput>> MerchantReceivablePayableDetail([FromBody] MerchantReceivablePayableDetailModelInput ObjClass)
        {
            var procedureName = "UspReceivablePayableDetails";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantReceivablePayableDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ValidateMerchantErpCodeModelOutput>> ValidateMerchantErpCode([FromBody] ValidateMerchantErpCodeModelInput ObjClass)
        {
            var procedureName = "UspValidateMerchantErpCode";
            var parameters = new DynamicParameters();
            parameters.Add("ErpCode", ObjClass.ErpCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ValidateMerchantErpCodeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CheckMappedMerchantIDModelOutput>> CheckMappedMerchantID([FromBody] CheckMappedMerchantIDModelInput ObjClass)
        {
            var procedureName = "UspCheckMappedMerchantID";
            var parameters = new DynamicParameters();
            parameters.Add("MappedMerchantID", ObjClass.MappedMerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckMappedMerchantIDModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ApproveRejectMerchantUpdateModelOutput>> ApproveRejectMerchantUpdate([FromBody] ApproveRejectMerchantUpdateModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeUpdateMerchant");
            dtDBR.Columns.Add("ErpCode", typeof(string));
            dtDBR.Columns.Add("Comments", typeof(string));

            var procedureName = "UspApproveMerchantUpdate";
            var parameters = new DynamicParameters();
            //parameters.Add("ErpCode", ObjClass.ErpCode, DbType.String, ParameterDirection.Input);
            //parameters.Add("Comments", ObjClass.Comments, DbType.String, ParameterDirection.Input);

            if (ObjClass.ObjApprovalRejectDetail != null)
            {
                foreach (ApprovalRejectModelInput ObjCardDetails in ObjClass.ObjApprovalRejectDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["ErpCode"] = ObjCardDetails.ErpCode;
                    dr["Comments"] = ObjCardDetails.Comments;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            parameters.Add("UpdateMerchant", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("StatusId", ObjClass.StatusId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ApproveRejectMerchantUpdateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantReactivationStatusModelOutput>> MerchantReactivationStatus([FromBody] MerchantReactivationStatusModelInput ObjClass)
        {
            var procedureName = "UspMerchantReactivationStatus";
            var parameters = new DynamicParameters();

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantReactivationStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantReactivationRequestModelOutput>> MerchantReactivationRequest([FromBody] MerchantReactivationRequestModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeRequestForMerchantReactivation");
            dtDBR.Columns.Add("MerchantId", typeof(string));
            dtDBR.Columns.Add("Remark", typeof(string));

            var procedureName = "UspMerchantReactivationRequest";
            var parameters = new DynamicParameters();

            if (ObjClass.TypeRequestForMerchantReactivation != null)
            {
                foreach (TypeRequestForMerchantReactivation ObjCardDetails in ObjClass.TypeRequestForMerchantReactivation)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["MerchantId"] = ObjCardDetails.MerchantId;
                    dr["Remark"] = ObjCardDetails.Remark;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            parameters.Add("TypeRequestForMerchantReactivation", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantReactivationRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<MerchantGetHotlistedMonthYearModelOuput>> GetHotlistedMonthYear([FromBody] MerchantGetHotlistedMonthYearModelInput ObjClass)
        {
            var procedureName = "UspGetHotlistedMonthYear";
            var parameters = new DynamicParameters();

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetHotlistedMonthYearModelOuput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetApprovedMerchantReactivationStatusModelOutput>> GetApprovedMerchantReactivationStatus([FromBody] GetApprovedMerchantReactivationStatusModelInput ObjClass)
        {
            var procedureName = "UspGetApprovedMerchantReactivationStatus";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetApprovedMerchantReactivationStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetRequestForApprovalReactivateMerchantModelOutput>> GetRequestForApprovalReactivateMerchant([FromBody] GetRequestForApprovalReactivateMerchantModelInput ObjClass)
        {
            var procedureName = "UspGetRequestForApprovalReactivateMerchant";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantZO", ObjClass.MerchantZO, DbType.Int32, ParameterDirection.Input);
            parameters.Add("MerchantRO", ObjClass.MerchantRO, DbType.Int32, ParameterDirection.Input);
            parameters.Add("MerchantStatus", ObjClass.MerchantStatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("HotlistDate", ObjClass.HotlistDate, DbType.String, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetRequestForApprovalReactivateMerchantModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantGetRequestReactivationMerchantModelOutput>> GetRequestReactivationMerchant([FromBody] MerchantGetRequestReactivationMerchantModelInput ObjClass)
        {
            var procedureName = "UspGetRequestReactivationMerchant";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantZO", ObjClass.MerchantZO, DbType.Int32, ParameterDirection.Input);
            parameters.Add("MerchantRO", ObjClass.MerchantRO, DbType.Int32, ParameterDirection.Input);
            parameters.Add("MerchantStatus", ObjClass.MerchantStatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("HotlistDate", ObjClass.HotlistDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetRequestReactivationMerchantModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantApproveMerchantReactivationRequestModelOuput>> ApproveMerchantReactivationRequest([FromBody] MerchantApproveMerchantReactivationRequestModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeApproveMerchantRequest");
            dtDBR.Columns.Add("MerchantId", typeof(string));
            dtDBR.Columns.Add("Remarks", typeof(string));

            var procedureName = "UspApproveMerchantReactivationRequest";
            var parameters = new DynamicParameters();

            if (ObjClass.TypeApproveMerchantRequest != null)
            {
                foreach (TypeApproveMerchantRequest ObjMerchantDetails in ObjClass.TypeApproveMerchantRequest)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["MerchantId"] = ObjMerchantDetails.MerchantId;
                    dr["Remarks"] = ObjMerchantDetails.Remarks;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            parameters.Add("TypeApproveMerchantRequest", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("MerchantStatus", ObjClass.MerchantStatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantApproveMerchantReactivationRequestModelOuput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<InsertMobileDispenserRetailOutletMappingModelOutput>> InsertMobileDispenserRetailOutletMapping([FromBody] InsertMobileDispenserRetailOutletMappingModelInput ObjClass)
        {
            var procedureName = "UspInsertMobileDispenserRetailOutletMapping";
            var parameters = new DynamicParameters();
            parameters.Add("MobileDispenserId", ObjClass.MobileDispenserId, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletsId", ObjClass.RetailOutletsId, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertMobileDispenserRetailOutletMappingModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantApproveMobileDispenserRetailOutletMappingModelOutput>> ApproveMobileDispenserRetailOutletMapping([FromBody] MerchantApproveMobileDispenserRetailOutletMappingModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeMobileDispenserRetailOutletMapping");
            dtDBR.Columns.Add("MobileDispenserId", typeof(string));
            dtDBR.Columns.Add("RetailOutletsId", typeof(string));
            dtDBR.Columns.Add("Remarks", typeof(string));

            var procedureName = "UspApproveMobileDispenserRetailOutletMapping";
            var parameters = new DynamicParameters();

            if (ObjClass.TypeMobileDispenserRetailOutletMapping != null)
            {
                foreach (TypeMobileDispenserRetailOutletMapping ObjMerchantDetails in ObjClass.TypeMobileDispenserRetailOutletMapping)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["MobileDispenserId"] = ObjMerchantDetails.MobileDispenserId;
                    dr["RetailOutletsId"] = ObjMerchantDetails.RetailOutletsId;
                    dr["Remarks"] = ObjMerchantDetails.Remarks;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            parameters.Add("TypeMobileDispenserRetailOutletMapping", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantApproveMobileDispenserRetailOutletMappingModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<MerchantGetMobileDispenserRetailOutletMappingModelOutput>> GetMobileDispenserRetailOutletMapping([FromBody] MerchantGetMobileDispenserRetailOutletMappingModelInput ObjClass)
        {
            var procedureName = "UspGetMobileDispenserRetailOutletMapping";
            var parameters = new DynamicParameters();
            parameters.Add("MobileDispenserId", ObjClass.MobileDispenserId, DbType.String, ParameterDirection.Input);
            parameters.Add("Status", ObjClass.Status, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetMobileDispenserRetailOutletMappingModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantGetMobileDispenserModelOutput>> GetMobileDispenser([FromBody] MerchantGetMobileDispenserModelInput ObjClass)
        {
            var procedureName = "UspGetMobileDispenser";
            var parameters = new DynamicParameters();
            parameters.Add("MobileDispenserId", ObjClass.MobileDispenserId, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetMobileDispenserModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetMappedParentMerchantIdModelOutput>> GetMappedParentMerchantId([FromBody] GetMappedParentMerchantIdModelInput ObjClass)
        {
            var procedureName = "UspGetMappedParentMerchantId";
            var parameters = new DynamicParameters();
            parameters.Add("MobileDispenserId", ObjClass.MobileDispenserId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetMappedParentMerchantIdModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantGetApproveTerminalMerchantMappingModelOutput>> GetApproveTerminalMerchantMapping([FromBody] MerchantGetApproveTerminalMerchantMappingModelInput ObjClass)
        {
            var procedureName = "UspGetApproveTerminalMerchantMapping";
            var parameters = new DynamicParameters();
            parameters.Add("MobileDispenserId", ObjClass.MobileDispenserId, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetApproveTerminalMerchantMappingModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<MerchantApproveTerminalMerchantMappingModelOutput>> ApproveTerminalMerchantMapping([FromBody] MerchantApproveTerminalMerchantMappingModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeApproveMerchantRequest");
            dtDBR.Columns.Add("MobileDispenserId", typeof(string));
            dtDBR.Columns.Add("RetailOutletsId", typeof(string));
            dtDBR.Columns.Add("TerminalId", typeof(string));
            dtDBR.Columns.Add("Remarks", typeof(string));

            var procedureName = "UspApproveTerminalMerchantMapping";
            var parameters = new DynamicParameters();

            if (ObjClass.TypeApproveTerminalMerchantMapping != null)
            {
                foreach (TypeApproveTerminalMerchantMapping ObjMerchantDetails in ObjClass.TypeApproveTerminalMerchantMapping)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["MobileDispenserId"] = ObjMerchantDetails.MobileDispenserId;
                    dr["RetailOutletsId"] = ObjMerchantDetails.RetailOutletsId;
                    dr["TerminalId"] = ObjMerchantDetails.TerminalId;
                    dr["Remarks"] = ObjMerchantDetails.Remarks;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeApproveTerminalMerchantMapping", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantApproveTerminalMerchantMappingModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetTerminalDetailsForManagTerminalModelOutput> GetTerminalDetailsForManagTerminal([FromBody] GetTerminalDetailsForManagTerminalModelInput ObjClass)
        {
            var procedureName = "UspGetTerminalDetailsForManagTerminal";
            var parameters = new DynamicParameters();
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetTerminalDetailsForManagTerminalModelOutput();
            storedProcedureResult.tblTerminalSubtblTransaction = (List<GetTerminalDetailsForManagTerminal>)await result.ReadAsync<GetTerminalDetailsForManagTerminal>();
            storedProcedureResult.tblTransaction = (List<GettblTransactionDate>)await result.ReadAsync<GettblTransactionDate>();
            storedProcedureResult.tblmstStatusSubTerminalLog = (List<GetTerminalDetailsForManagTerminalSub>)await result.ReadAsync<GetTerminalDetailsForManagTerminalSub>();
            storedProcedureResult.tblMobileDispenserRetailOutletMapping = (List<GetMobileDispenserRetailOutletMapping>)await result.ReadAsync<GetMobileDispenserRetailOutletMapping>();

            return storedProcedureResult;
            // return await connection.QueryAsync<GetTerminalDetailsForManagTerminalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<MerchantInsertMobileDispenserCustomerModelOutput>> InsertMobileDispenserCustomer([FromBody] MerchantInsertMobileDispenserCustomerModelInput ObjClass)
        {
            var procedureName = "UspInsertMobileDispenserCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", ObjClass.ReferenceId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantInsertMobileDispenserCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetBalanceCCMSRechargebyMobiledispenserModelOutput>> GetBalanceCCMSRechargebyMobiledispenser([FromBody] GetBalanceCCMSRechargebyMobiledispenserModelInput ObjClass)
        {
            var procedureName = "UspGetBalanceCCMSRechargebyMobiledispenser";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetBalanceCCMSRechargebyMobiledispenserModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCCMSRechargebyMobiledispenserModelOutput>> InitiateCCMSMobileDispercerRecharge([FromBody] GetCCMSRechargebyMobiledispenserModelInput ObjClass)
        {
            var procedureName = "UspInitiateCCMSMobileDispercerRecharge";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("BankNameId", ObjClass.BankNameId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCCMSRechargebyMobiledispenserModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async void InsertCCMSMobileDispencerGApiRequestResponse([FromBody] ApiRequestResponse ObjClass)
        {
            var procedureName = "UspInsertCCMSMobileDispencerGApiRequestResponse";
            var parameters = new DynamicParameters();
            parameters.Add("BankName", ObjClass.BankName, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionId", ObjClass.TransactionId, DbType.String, ParameterDirection.Input);
            parameters.Add("Request", ObjClass.request, DbType.String, ParameterDirection.Input);
            parameters.Add("Response", ObjClass.response, DbType.String, ParameterDirection.Input);
            parameters.Add("Apiurl", ObjClass.apiurl + ObjClass.request_Hash, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("Amt", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("BankStatus", Status, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNo", ObjClass.ControlCardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.UserId, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var res = await connection.QueryAsync<object>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantInsertTerminalDetailsModelOutput>> InsertTerminalDetails([FromBody] MerchantInsertTerminalDetailsModelInput ObjClass)
        {
            var procedureName = "UspInsertTerminalDetails";
            var parameters = new DynamicParameters();
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileDispenserId", ObjClass.MobileDispenserId, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            //parameters.Add("TermainalIssuanceType", ObjClass.TermainalIssuanceType, DbType.String, ParameterDirection.Input);
            parameters.Add("RouteId", ObjClass.RouteId, DbType.String, ParameterDirection.Input);
            parameters.Add("ServiceCharge", ObjClass.ServiceCharge, DbType.String, ParameterDirection.Input);
            //parameters.Add("Remarks", ObjClass.Remarks, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantInsertTerminalDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetMobileDispencerFuelPurchaseModelOutPut> GetMobileDispencerFuelPurchase([FromBody] GetMobileDispencerFuelPurchaseModelInput ObjClass)
        {
            var procedureName = "UspGetMobileDispencerFuelPurchase";
            var parameters = new DynamicParameters();
            parameters.Add("MobileDispenserId", ObjClass.MobileDispenserId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetMobileDispencerFuelPurchaseModelOutPut();

            storedProcedureResult.tblMobileDispencerFuelPurchaseModelMID = (List<MobileDispencerFuelPurchaseModelMID>)await result.ReadAsync<MobileDispencerFuelPurchaseModelMID>();
            storedProcedureResult.tblMobileDispencerFuelPurchaseModelMCID = (List<MobileDispencerFuelPurchaseModelMCID>)await result.ReadAsync<MobileDispencerFuelPurchaseModelMCID>();
            return storedProcedureResult;
        }


        public async Task<IEnumerable<InsertMobileDispencerFuelPurchaseModelOutPut>> InsertMobileDispencerFuelPurchase([FromBody] InsertMobileDispencerFuelPurchaseModelInput ObjClass)
        {
            var procedureName = "UspInsertMobileDispencerFuelPurchase";
            var parameters = new DynamicParameters();
            parameters.Add("MobileDispenserId", ObjClass.MobileDispenserId, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("OutletType", ObjClass.OutletType, DbType.String, ParameterDirection.Input);
            parameters.Add("MappedMerchantId", ObjClass.MappedMerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.Double, ParameterDirection.Input);
            parameters.Add("Modifiedby", ObjClass.Modifiedby, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("SourceofPayment", ObjClass.SourceofPayment, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertMobileDispencerFuelPurchaseModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetTerminalMerchantMappingStatusModelOutput>> GetTerminalMerchantMappingStatus([FromBody] GetTerminalMerchantMappingStatusModelInput ObjClass)
        {
            var procedureName = "UspGetTerminalMerchantMappingStatus";
            var parameters = new DynamicParameters();
            parameters.Add("MobileDispenserId", ObjClass.MobileDispenserId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("Todate", ObjClass.Todate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetTerminalMerchantMappingStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetStatusMobileDispenserRetailOutletMappingModelOutPut>> GetStatusMobileDispenserRetailOutletMapping([FromBody] GetStatusMobileDispenserRetailOutletMappingModelInput ObjClass)
        {
            var procedureName = "UspGetStatusMobileDispenserRetailOutletMapping";
            var parameters = new DynamicParameters();
            parameters.Add("Status", ObjClass.Status, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetStatusMobileDispenserRetailOutletMappingModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetStatusMobileDispenserModelOutPut>> GetStatusMobileDispenser()
        {
            var procedureName = "UspGetStatusMobileDispenser";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetStatusMobileDispenserModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CheckMerchantIdStatusModelOutput>> CheckMerchantIdStatus([FromBody] CheckMerchantIdStatusModelInput ObjClass)
        {
            var procedureName = "UspCheckMerchantStatus";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckMerchantIdStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<IEnumerable<MerchantGetViewMerchantEarningbreakupModelOutput>> GetViewMerchantEarningbreakup([FromBody] MerchantGetViewMerchantEarningbreakupModelInput ObjClass)
        {
            var procedureName = "uspgetViewMerchantEarningbreakup";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TxnType", ObjClass.TxnType, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetViewMerchantEarningbreakupModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<MerchantGetMstEarningTxnTypeModelOutput>> GetMstEarningTxnType([FromBody] MerchantGetMstEarningTxnTypeModelInput ObjClass)
        {
            var procedureName = "UspGetMstEarningTxnType";
            var parameters = new DynamicParameters();
            //  parameters.Add("TxnType", ObjClass.TxnType, DbType.Int64, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetMstEarningTxnTypeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<WebGenerateOTPModelOutput>> MobileDispenserGenerateOTP([FromBody] WebGenerateOTPModelInput ObjClass)
        {
            var procedureName = "UspGenerateOTP";
            var parameters = new DynamicParameters();
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("OTPtype", OTPtype, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CCN", ObjClass.CCN, DbType.String, ParameterDirection.Input);
            parameters.Add("TransTypeId", 530, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("Invoiceamount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<WebGenerateOTPModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<MobileDispenserConfirmOTPModelOutPut>> MobileDispenserConfirmOTP([FromBody] MobileDispenserConfirmOTPModelInput ObjClass)
        {
            var procedureName = "UspValidateOTPWeb";
            var parameters = new DynamicParameters();
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
            parameters.Add("OTPtype", OTPtype, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MobileDispenserConfirmOTPModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetTransactionsTypeModelOutput>> GetTransactionsType([FromBody] GetTransactionsTypeModelInput ObjClass)
        {
            var procedureName = "UspGetTransactionType";
            var parameters = new DynamicParameters();
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetTransactionsTypeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetMerchantBankNameModelOutput>> GetMerchantBankName([FromBody] GetMerchantBankNameModelInput ObjClass)
        {
            var procedureName = "UspGetBankNameList";
            var parameters = new DynamicParameters();
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetMerchantBankNameModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<MerchantTransactionGetRegistrationModelOutput> GetMerchantRegistrationParameters([FromBody] MerchantTransactionGetRegistrationProcessModelInput ObjClass)
        {
            var procedureName = "UspGetMerchantRegistrationProcess";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("HWSerialNo", ObjClass.HWSerialNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Password", ObjClass.Password, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            StatusInformation.API_Key_Is_Null.GetDisplayName();
            //bool IsResult = this.Return_Key(_accountRepo, out string UserMessage, 0, out int IntStatusCode, ObjClass.Useragent, ObjClass.Userip, ObjClass.Userid);
            string API_Key = string.Empty;
            string Secret_Key = string.Empty;
            byte[] bytes = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54, 56, 58, 60, 62, 64, 66, 68, 70 };
            TokenManager.Secret = Convert.ToBase64String(bytes);

            var storedProcedureResult = new MerchantTransactionGetRegistrationModelOutput();
            storedProcedureResult.ObjGetMerchantDetail = (List<MerchantTransactionGetRegistrationProcessMerchantModelOutput>)await result.ReadAsync<MerchantTransactionGetRegistrationProcessMerchantModelOutput>();
            List<MerchantTransactionGetRegistrationProcessMerchantModelOutput> ObjGetMerchantDetailToken = storedProcedureResult.ObjGetMerchantDetail.ToList();
            ObjGetMerchantDetailToken[0].Token = TokenManager.GenerateToken(ObjClass.Useragent, ObjClass.Userid, ObjClass.Userip);
            int StatusCode = storedProcedureResult.ObjGetMerchantDetail.Cast<MerchantTransactionGetRegistrationProcessMerchantModelOutput>().ToList()[0].StatusId;
            if (StatusCode == 4)
            {
                storedProcedureResult.ObjGetTransTypeDetail = (List<MerchantTransactionGetRegistrationProcessTransModelOutput>)await result.ReadAsync<MerchantTransactionGetRegistrationProcessTransModelOutput>();
                storedProcedureResult.ObjGetParentTransTypeDetail = (List<MerchantTransactionGetTransTypeDetailByParentidModelOutput>)await result.ReadAsync<MerchantTransactionGetTransTypeDetailByParentidModelOutput>();
                storedProcedureResult.ObjBanks = (List<MerchantTransactionBanksModelOutput>)await result.ReadAsync<MerchantTransactionBanksModelOutput>();
                storedProcedureResult.ObjFormFactors = (List<MerchantTransactionFormFactorsModelOutput>)await result.ReadAsync<MerchantTransactionFormFactorsModelOutput>();
                storedProcedureResult.ObjProduct = (List<MerchantProductModelOutput>)await result.ReadAsync<MerchantProductModelOutput>();
                storedProcedureResult.ObjOutletDetails = (List<MerchantOutletModelOutput>)await result.ReadAsync<MerchantOutletModelOutput>();
            }
            return storedProcedureResult;
        }

        public async Task<IEnumerable<MerchantRequestYearModeOutput>> MerchantRequestYear([FromBody] MerchantRequestYearModelInput ObjClass)
        {
            var procedureName = "UspMerchantRequestYear";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantRequestYearModeOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetMerchantRequestMonthModelOutput>> GetMerchantRequestMonth([FromBody] GetMerchantRequestMonthModelInput ObjClass)
        {
            var procedureName = "UspGetMerchantRequestMonth";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetMerchantRequestMonthModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<MerchantgetmonthModelOutput>> getmonth([FromBody] MerchantgetmonthModelInput ObjClass)
        {
            var procedureName = "Uspgetmonth";
            var parameters = new DynamicParameters();
            parameters.Add("StatmentId", ObjClass.StatmentId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantgetmonthModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
         
        public async Task<IEnumerable<MerchantAccountStatementRequestModelOutput>> MerchantAccountStatementRequest([FromBody] MerchantAccountStatementRequestModelInput ObjClass)
        {
            var procedureName = "UspMerchantAccountStatementRequest";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("StatementType", ObjClass.StatementType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("MonthId", ObjClass.MonthId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RequestYearId", ObjClass.RequestYearId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("AlternateEmail", ObjClass.AlternateEmail, DbType.String, ParameterDirection.Input);
            parameters.Add("RegisteredEmail", ObjClass.RegisteredEmail, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantAccountStatementRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantReportTypeModelOutput>> MerchantReportType([FromBody] MerchantReportTypeModelInput ObjClass)
        {
            var procedureName = "UspMerchantReportType";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantReportTypeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantGetMerchantMonthYearModelOutput>> GetMerchantMonthYear([FromBody] MerchantGetMerchantMonthYearModelInput ObjClass)
        {
            var procedureName = "UspGetMerchantMonthYear";
            var parameters = new DynamicParameters();
            parameters.Add("StatmentId", ObjClass.StatmentId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetMerchantMonthYearModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantAccountStatementDetailsModelOutput>> MerchantAccountStatementDetails([FromBody] MerchantAccountStatementDetailsModelInput ObjClass)
        {
            var procedureName = "UspMerchantAccountStatementDetails";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("ReportType", ObjClass.ReportType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("MonthId", ObjClass.MonthId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantAccountStatementDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetMobileDispenserCustomerIDFromMerchantIDModelOutput>> GetMobileDispenserCustomerIDFromMerchantID([FromBody] GetMobileDispenserCustomerIDFromMerchantIDModelInput ObjClass)
        {
            var procedureName = "UspGetMobileDispenserCustomerIDFromMerchantID";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetMobileDispenserCustomerIDFromMerchantIDModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<MerchantGetTerminalStatusModelOutput>> GetTerminalStatus([FromBody] MerchantGetTerminalStatusModelInput ObjClass)
        {
            var procedureName = "UspGetTerminalStatus";
            var parameters = new DynamicParameters();
            parameters.Add("MobileDispenserId", ObjClass.MobileDispenserId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetTerminalStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantViewTerminalMerchantMappingStatusModelOutput>> ViewTerminalMerchantMappingStatus([FromBody] MerchantViewTerminalMerchantMappingStatusModelInput ObjClass)
        {
            var procedureName = "UspViewTerminalMerchantMappingStatus";
            var parameters = new DynamicParameters();
            parameters.Add("MobileDispenserId", ObjClass.MobileDispenserId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantViewTerminalMerchantMappingStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantCloneInsertMerchantModelOutput>> CloneInsertMerchant([FromBody] MerchantCloneInsertMerchantModelInput ObjClass)
        {
            var procedureName = "UspCloneInsertMerchant";
            var parameters = new DynamicParameters();
            parameters.Add("OldMerchantId", ObjClass.OldMerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("ErpCode", ObjClass.ErpCode, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletName", ObjClass.RetailOutletName, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantTypeId", ObjClass.MerchantTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("DealerName", ObjClass.DealerName, DbType.String, ParameterDirection.Input);
            parameters.Add("MappedMerchantId", ObjClass.MappedMerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("DealerMobileNo", ObjClass.DealerMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("OutletCategoryId", ObjClass.OutletCategoryId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("HighwayNo1", ObjClass.HighwayNo1, DbType.String, ParameterDirection.Input);
            parameters.Add("HighwayNo2", ObjClass.HighwayNo2, DbType.String, ParameterDirection.Input);
            parameters.Add("HighwayName", ObjClass.HighwayName, DbType.String, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("LPGCNGSale", ObjClass.LPGCNGSale, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("PancardNumber", ObjClass.PancardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("GSTNumber", ObjClass.GSTNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletAddress1", ObjClass.RetailOutletAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletAddress2", ObjClass.RetailOutletAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletAddress3", ObjClass.RetailOutletAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletLocation", ObjClass.RetailOutletLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletCity", ObjClass.RetailOutletCity, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletStateId", ObjClass.RetailOutletStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RetailOutletDistrictId", ObjClass.RetailOutletDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RetailOutletPinNumber", ObjClass.RetailOutletPinNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletPhoneNumber", ObjClass.RetailOutletPhoneNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletFax", ObjClass.RetailOutletFax, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("SalesAreaId", ObjClass.SalesAreaId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ContactPersonNameFirstName", ObjClass.ContactPersonNameFirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("ContactPersonNameMiddleName", ObjClass.ContactPersonNameMiddleName, DbType.String, ParameterDirection.Input);
            parameters.Add("ContactPersonNameLastName", ObjClass.ContactPersonNameLastName, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("EmailId", ObjClass.EmailId, DbType.String, ParameterDirection.Input);
            parameters.Add("Mics", ObjClass.Mics, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress1", ObjClass.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress2", ObjClass.CommunicationAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress3", ObjClass.CommunicationAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationLocation", ObjClass.CommunicationLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCity", ObjClass.CommunicationCity, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationPinNumber", ObjClass.CommunicationPinNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPhoneNumber", ObjClass.CommunicationPhoneNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationFax", ObjClass.CommunicationFax, DbType.String, ParameterDirection.Input);
            parameters.Add("NoofLiveTerminals", ObjClass.NoofLiveTerminals, DbType.Int32, ParameterDirection.Input);
            parameters.Add("TerminalTypeRequested", ObjClass.TerminalTypeRequested, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantCloneInsertMerchantModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<MerchantGeClonetMerchantApprovalModelOutput>> GeClonetMerchantApproval([FromBody] MerchantGeClonetMerchantApprovalModelInput ObjClass)
        {
            var procedureName = "UspGeClonetMerchantApproval";
            var parameters = new DynamicParameters();
            parameters.Add("Category", ObjClass.Category, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGeClonetMerchantApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantCloneApproveRejectMerchantModelOutput>> CloneApproveRejectMerchant([FromBody] MerchantCloneApproveRejectMerchantModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeUpdateMerchant");
            dtDBR.Columns.Add("ErpCode", typeof(string));
            dtDBR.Columns.Add("Comments", typeof(string));

            var procedureName = "UspCloneApproveRejectMerchant";
            var parameters = new DynamicParameters();
            //parameters.Add("ErpCode", ObjClass.ErpCode, DbType.String, ParameterDirection.Input);
            //parameters.Add("Comments", ObjClass.Comments, DbType.String, ParameterDirection.Input);

            if (ObjClass.ObjApprovalRejectDetail != null)
            {
                foreach (ApprovalRejectModel ObjCardDetails in ObjClass.ObjApprovalRejectDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["ErpCode"] = ObjCardDetails.ErpCode;
                    dr["Comments"] = ObjCardDetails.Comments;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            parameters.Add("UpdateMerchant", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("StatusId", ObjClass.StatusId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantCloneApproveRejectMerchantModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantGetMerchnatRegisterEmailModelOutput>> GetMerchnatRegisterEmail([FromBody] MerchantGetMerchnatRegisterEmailModelInput ObjClass)
        {
            var procedureName = "UspGetMerchnatRegisterEmail";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetMerchnatRegisterEmailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantGetUpdateRequestValueForCloneMerchantModelOutput>> GetUpdateRequestValueForCloneMerchant([FromBody] MerchantGetUpdateRequestValueForCloneMerchantModelInput ObjClass)
        {
            var procedureName = "UspGetUpdateRequestValueForCloneMerchant";
            var parameters = new DynamicParameters();
            parameters.Add("ErpCode", ObjClass.ErpCode, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetUpdateRequestValueForCloneMerchantModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
