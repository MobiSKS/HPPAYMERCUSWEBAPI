using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.Merchant;
using HPPay.DataRepository.DBDapper;
using HPPay.Infrastructure.CommonClass;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.Terminal
{
    public class TerminalRepository: ITerminalRepository
    {
        private readonly DapperContext _context;
        public TerminalRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<MerchantSearchForTerminalInstallationRequestModelOutput> SearchForTerminalInstallationRequest([FromBody] MerchantSearchForTerminalInstallationRequestModelInput ObjClass)
        {
            var procedureName = "UspSearchForTerminalInstallationRequest";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            var storedProcedureResult = new MerchantSearchForTerminalInstallationRequestModelOutput();
            storedProcedureResult.ObjMerchantDetail = (List<MerchantDetailOutput>)await result.ReadAsync<MerchantDetailOutput>();
            storedProcedureResult.ObjTerminalDetail = (List<TerminalDetailOutput>)await result.ReadAsync<TerminalDetailOutput>();
            storedProcedureResult.ObjStatusDetail = (List<StatusOutput>)await result.ReadAsync<StatusOutput>();
            return storedProcedureResult;

        }

        public async Task<GetTerminalParametersModelOutput> GetTerminalParameters([FromBody] GetTerminalParametersModelInput ObjClass)
        {
            var procedureName = "UspGetTerminalParameters";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            var storedProcedureResult = new GetTerminalParametersModelOutput();

            storedProcedureResult.ObjMerchantTerminalDetails = (List<MerchantTerminalDetailsModelOutput>)await result.ReadAsync<MerchantTerminalDetailsModelOutput>();
            storedProcedureResult.ObjTerminalDefaultService = (List<TerminalDefaultServiceModelOutput>)await result.ReadAsync<TerminalDefaultServiceModelOutput>();
            storedProcedureResult.ObjTerminalFastTag = (List<TerminalFastTagModelOutput>)await result.ReadAsync<TerminalFastTagModelOutput>();
            storedProcedureResult.ObjTerminalFormFactor = (List<TerminalFormFactorModelOutput>)await result.ReadAsync<TerminalFormFactorModelOutput>();
            storedProcedureResult.ObjMerchantConfiguration = (List<MerchantConfigurationModelOutput>)await result.ReadAsync<MerchantConfigurationModelOutput>();
            return storedProcedureResult;

        }

        public async Task<IEnumerable<MerchantInsertAddonTerminalModelOutput>> InsertTerminalInstallationRequest([FromBody] MerchantInsertAddonTerminalModelInput ObjClass)
        {
            var procedureName = "UspInsertAddonTerminal";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalTypeRequested ", ObjClass.TerminalTypeRequested, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalIssuanceType", ObjClass.TerminalIssuanceType, DbType.String, ParameterDirection.Input);
            parameters.Add("Justification", ObjClass.Justification, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantInsertAddonTerminalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<MerchantSearchForTerminalInstallationRequestCloseModelOutput>> SearchForTerminalInstallationRequestClose([FromBody] MerchantSearchForTerminalInstallationRequestCloseModelInput ObjClass)
        {
            var procedureName = "UspSearchForTerminalInstallationRequestClose";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantSearchForTerminalInstallationRequestCloseModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantGetReasonListModelOutput>> GetReasonList([FromBody] MerchantGetReasonListModelInput ObjClass)
        {
            var procedureName = "UspGetReasonList";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetReasonListModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantUpdateTerminalInstallationRequestCloseModelOutput>> UpdateTerminalInstallationRequestClose([FromBody] MerchantUpdateTerminalInstallationRequestCloseModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeMerchantTerminalMap");
            dtDBR.Columns.Add("MerchantId", typeof(string));
            dtDBR.Columns.Add("TerminalId", typeof(string));


            if (ObjClass.ObjMerchantTerminalInstallationRequestCloseDetail != null)
            {
                foreach (MerchantTerminalInstallationRequestCloseModelInput ObjDetail in ObjClass.ObjMerchantTerminalInstallationRequestCloseDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["MerchantId"] = ObjDetail.MerchantId;
                    dr["TerminalId"] = ObjDetail.TerminalId;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspUpdateTerminalInstallationRequestClose";
            var parameters = new DynamicParameters();
            parameters.Add("ReasonId", ObjClass.ReasonId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UpdateTerminalInstReq", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantUpdateTerminalInstallationRequestCloseModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<MerchantViewTerminalInstallationRequestStatusCloseModelOutput>> ViewTerminalInstallationRequestStatus([FromBody] MerchantViewTerminalInstallationRequestStatusCloseInput ObjClass)
        {
            var procedureName = "UspViewTerminalInstallationRequestStatus";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantViewTerminalInstallationRequestStatusCloseModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }



        public async Task<MerchantGetTerminalDeinstallationRequestModelOutput> GetTerminalDeinstallationRequest([FromBody] MerchantGetTerminalDeinstallationRequestModelInput ObjClass)
        {
            var procedureName = "UspGetTerminalDeinstallationRequest";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            var storedProcedureResult = new MerchantGetTerminalDeinstallationRequestModelOutput();
            storedProcedureResult.ObjMerchantDeinstallationDetail = (List<MerchantDeinstallationDetailOutput>)await result.ReadAsync<MerchantDeinstallationDetailOutput>();
            storedProcedureResult.ObjTerminalDeinstallationDetail = (List<TerminalDeinstallationDetailOutput>)await result.ReadAsync<TerminalDeinstallationDetailOutput>();
            return storedProcedureResult;

        }


        public async Task<IEnumerable<MerchantUpdateTerminalDeInstalRequestModelOutput>> UpdateTerminalDeInstalRequest([FromBody] MerchantUpdateTerminalDeInstalRequestModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeTerminalIds");
            dtDBR.Columns.Add("TerminalId", typeof(string));


            if (ObjClass.ObjUpdateTerminalDeInstalRequest != null)
            {
                foreach (UpdateTerminalDeInstalRequestModelInput ObjDetail in ObjClass.ObjUpdateTerminalDeInstalRequest)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["TerminalId"] = ObjDetail.TerminalId;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspTerminalDeInstalUpdateRequest";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("DeinstallationType", ObjClass.DeinstallationType, DbType.String, ParameterDirection.Input);
            parameters.Add("Comments", ObjClass.Comments, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UpdateTerminalDeInstReq", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantUpdateTerminalDeInstalRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantGetTerminalDeInstallationRequestCloseModelOutput>> GetTerminalDeInstallationRequestClose([FromBody] MerchantGetTerminalDeInstallationRequestCloseModelInput ObjClass)
        {
            var procedureName = "UspGetTerminalDeInstallationRequestClose";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetTerminalDeInstallationRequestCloseModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantTerminalDeInstalUpdateRequestCloseModelOutput>> TerminalDeInstalUpdateRequestClose([FromBody] MerchantTerminalDeInstalUpdateRequestCloseModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeMerchantTerminalMap");
            dtDBR.Columns.Add("MerchantId", typeof(string));
            dtDBR.Columns.Add("TerminalID", typeof(string));


            if (ObjClass.ObjMerchantTerminalMapInput != null)
            {
                foreach (MerchantTerminalMapInput ObjDetail in ObjClass.ObjMerchantTerminalMapInput)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["MerchantId"] = ObjDetail.MerchantId;
                    dr["TerminalID"] = ObjDetail.TerminalID;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspTerminalDeInstalUpdateRequestClose";
            var parameters = new DynamicParameters();
            parameters.Add("Status", ObjClass.Status, DbType.String, ParameterDirection.Input);
            parameters.Add("Comments", ObjClass.Comments, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UpdateTerminalDeInstReqClose", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantTerminalDeInstalUpdateRequestCloseModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantGetTerminalInstallationRequestApprovalModelOutput>> GetTerminalInstallationRequestApproval([FromBody] MerchantGetTerminalInstallationRequestApprovalModelInput ObjClass)
        {
            var procedureName = "UspGetTerminalInstallationRequestApproval";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("Category", ObjClass.Category, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetTerminalInstallationRequestApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<MerchantUpdateTerminalInstallationRequestApprovalModelOutput>> InsertTerminalInstallationRequestApproval([FromBody] MerchantUpdateTerminalInstallationRequestApprovalModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeMerchantTerminalMap");
            dtDBR.Columns.Add("MerchantId", typeof(string));
            dtDBR.Columns.Add("TerminalID", typeof(string));


            if (ObjClass.ObjMerchantTerminalInsertInput != null)
            {
                foreach (MerchantTerminalInsertInput ObjDetail in ObjClass.ObjMerchantTerminalInsertInput)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["MerchantId"] = ObjDetail.MerchantId;
                    dr["TerminalID"] = ObjDetail.TerminalID;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspUpdateTerminalInstallationRequestApproval";
            var parameters = new DynamicParameters();
            parameters.Add("Remark", ObjClass.Remark, DbType.String, ParameterDirection.Input);
            parameters.Add("Action", ObjClass.Action, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UpdateTerminalInstReq", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantUpdateTerminalInstallationRequestApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<MerchantGetTerminalDeInstallationRequestApprovalModelOutput>> GetTerminalDeInstallationRequestApproval([FromBody] MerchantGetTerminalDeInstallationRequestApprovalModelInput ObjClass)
        {
            var procedureName = "UspGetTerminalDeInstallationRequestApproval";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetTerminalDeInstallationRequestApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<MerchantInsertTerminalDeInstallationRequestApprovalModelOutput>> InsertTerminalDeInstallationRequestApproval([FromBody] MerchantInsertTerminalDeInstallationRequestApprovalModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeMerchantTerminalMap");
            dtDBR.Columns.Add("MerchantId", typeof(string));
            dtDBR.Columns.Add("TerminalID", typeof(string));


            if (ObjClass.ObjTerminalDeInstallationInsertInput != null)
            {
                foreach (MerchantTerminalDeInstallationInsertInput ObjDetail in ObjClass.ObjTerminalDeInstallationInsertInput)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["MerchantId"] = ObjDetail.MerchantId;
                    dr["TerminalID"] = ObjDetail.TerminalID;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspUpdateTerminalDeInstallationRequestApproval";
            var parameters = new DynamicParameters();
            parameters.Add("Remark", ObjClass.Remark, DbType.String, ParameterDirection.Input);
            parameters.Add("Action", ObjClass.Action, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UpdateTerminalInstReq", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantInsertTerminalDeInstallationRequestApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<MerchantGetTerminalDeInstallationRequestAuthorizationModelOutput>> GetTerminalDeInstallationRequestAuthorization([FromBody] MerchantGetTerminalDeInstallationRequestAuthorizationModelInput ObjClass)
        {
            var procedureName = "UspGetTerminalDeInstallationRequestAuthorization";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetTerminalDeInstallationRequestAuthorizationModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<MerchantInsertTerminalDeInstallationRequestAuthorizationModelOutput>> InsertTerminalDeInstallationRequestAuthorization([FromBody] MerchantInsertTerminalDeInstallationRequestAuthorizationModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeMerchantTerminalMap");
            dtDBR.Columns.Add("MerchantId", typeof(string));
            dtDBR.Columns.Add("TerminalId", typeof(string));


            if (ObjClass.ObjTerminalDeInstallationAuthorizationInput != null)
            {
                foreach (MerchantTerminalDeInstallationAuthorizationInsertInput ObjDetail in ObjClass.ObjTerminalDeInstallationAuthorizationInput)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["MerchantId"] = ObjDetail.MerchantId;
                    dr["TerminalId"] = ObjDetail.TerminalId;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspUpdateTerminalDeInstallationRequestAuthorization";
            var parameters = new DynamicParameters();
            parameters.Add("Remark", ObjClass.Remark, DbType.String, ParameterDirection.Input);
            parameters.Add("Action", ObjClass.Action, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UpdateTerminalInstReq", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantInsertTerminalDeInstallationRequestAuthorizationModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<MerchantViewTerminalDeInstallationRequestStatusModelOutput>> ViewTerminalDeInstallationRequestStatus([FromBody] MerchantViewTerminalDeInstallationRequestStatusModelInput ObjClass)
        {
            var procedureName = "UspViewTerminalDeInstallationRequestStatus";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantViewTerminalDeInstallationRequestStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<MerchantGetProblematicDeinstalledToDeinstalledModelOutput>> GetProblematicDeinstalledToDeinstalled([FromBody] MerchantGetProblematicDeinstalledToDeinstalledModelInput ObjClass)
        {
            var procedureName = "UspGetProblematicDeinstalledToDeinstalled";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetProblematicDeinstalledToDeinstalledModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<MerchantInsertProblematicDeinstalledToDeinstalledModelOutput>> InsertProblematicDeinstalledToDeinstalled([FromBody] MerchantInsertProblematicDeinstalledToDeinstalledModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeMerchantTerminalMap");
            dtDBR.Columns.Add("MerchantId", typeof(string));
            dtDBR.Columns.Add("TerminalId", typeof(string));


            if (ObjClass.ObjTerminalProblematicDeinstalledToDeinstalled != null)
            {
                foreach (TerminalProblematicDeinstalledToDeinstalled ObjDetail in ObjClass.ObjTerminalProblematicDeinstalledToDeinstalled)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["MerchantId"] = ObjDetail.MerchantId;
                    dr["TerminalId"] = ObjDetail.TerminalId;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspUpdateProblematicDeinstalledToDeinstalled";
            var parameters = new DynamicParameters();
            parameters.Add("Remark", ObjClass.Remark, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UpdateTerminalInstReq", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantInsertProblematicDeinstalledToDeinstalledModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantGetManageTerminalDetailsModelOutput>> GetManageTerminalDetails([FromBody] MerchantGetManageTerminalDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetManageTerminalDetails";
            var parameters = new DynamicParameters();
            parameters.Add("DeploymentStatus", ObjClass.DeploymentStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetManageTerminalDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<MerchantGetTerminalTypeModelOutput>> GetTerminalType([FromBody] MerchantGetTerminalTypeModelInput ObjClass)
        {
            var procedureName = "UspGetTerminalType";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetTerminalTypeModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<MerchantTerminalDetailModelOutput> TerminalDetail([FromBody] MerchantTerminalDetailModelInput ObjClass)
        {
            var procedureName = "UspTerminalDetails";
            var parameters = new DynamicParameters();
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new MerchantTerminalDetailModelOutput();
            storedProcedureResult.ObjTerminalDetail = (List<TerminalDetail>)await result.ReadAsync<TerminalDetail>();
            storedProcedureResult.ObjTerminalDeploymentDetail = (List<TerminalDeploymentDetail>)await result.ReadAsync<TerminalDeploymentDetail>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<MerchantSearchTerminalModelOutput>> SearchTerminal([FromBody] MerchantSearchTerminalModelInput ObjClass)
        {
            var procedureName = "UspSearchTerminal";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalType", ObjClass.TerminalType, DbType.String, ParameterDirection.Input);
            parameters.Add("IssueDate", ObjClass.IssueDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantSearchTerminalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<MerchantSaveTerminalParametersModelOutput>> SaveTerminalParameters([FromBody] MerchantSaveTerminalParametersModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeTerminalDefaultServiceList");
            dtDBR.Columns.Add("TransactionType", typeof(string));
            dtDBR.Columns.Add("StatusFlag", typeof(int));

            var dtobjDBR = new DataTable("TypeTerminalFastTagList");
            dtobjDBR.Columns.Add("FastagId", typeof(int));
            dtobjDBR.Columns.Add("FastagName", typeof(string));
            dtobjDBR.Columns.Add("StatusFlag", typeof(int));

            var objDBR = new DataTable("TypeTerminalFormFactorList");
            objDBR.Columns.Add("FormFactorId", typeof(int));
            objDBR.Columns.Add("FormFactorName", typeof(string));
            objDBR.Columns.Add("StatusFlag", typeof(int));

            var procedureName = "UspSaveTerminalParameters";
            var parameters = new DynamicParameters();

            if (ObjClass.TypeTerminalDefaultServiceList != null)
            {
                foreach (TypeTerminalDefaultServiceList ObjCardDetails in ObjClass.TypeTerminalDefaultServiceList)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["TransactionType"] = ObjCardDetails.TransactionType;
                    dr["StatusFlag"] = ObjCardDetails.StatusFlag;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }


                if (ObjClass.TypeTerminalFastTagList != null)
                {
                    foreach (TypeTerminalFastTagList ObjCardDetail in ObjClass.TypeTerminalFastTagList)
                    {
                        DataRow dr = dtobjDBR.NewRow();
                        dr["FastagId"] = ObjCardDetail.FastagId;
                        dr["FastagName"] = ObjCardDetail.FastagName;
                        dr["StatusFlag"] = ObjCardDetail.StatusFlag;

                        dtobjDBR.Rows.Add(dr);
                        dtobjDBR.AcceptChanges();
                    }
                }



            if (ObjClass.TypeTerminalFormFactorList != null)
            {
                foreach (TypeTerminalFormFactorList CardDetail in ObjClass.TypeTerminalFormFactorList)
                {
                    DataRow dr = objDBR.NewRow();
                    dr["FormFactorId"] = CardDetail.FormFactorId;
                    dr["FormFactorName"] = CardDetail.FormFactorName;
                    dr["StatusFlag"] = CardDetail.StatusFlag;

                    objDBR.Rows.Add(dr);
                    objDBR.AcceptChanges();
                }
            }

            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("MechantName", ObjClass.MechantName, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeTerminalDefaultServiceList", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("TypeTerminalFastTagList", dtobjDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("TypeTerminalFormFactorList", objDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("Header1", ObjClass.Header1, DbType.String, ParameterDirection.Input);
            parameters.Add("Header2", ObjClass.Header2, DbType.String, ParameterDirection.Input);
            parameters.Add("Footer1", ObjClass.Footer1, DbType.String, ParameterDirection.Input);
            parameters.Add("Footer2", ObjClass.Footer2, DbType.String, ParameterDirection.Input);
            parameters.Add("BatchSaleLimit", ObjClass.BatchSaleLimit, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("BatchReloadLimit", ObjClass.BatchReloadLimit, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("BatchSize", ObjClass.BatchSize, DbType.Int32, ParameterDirection.Input);
            parameters.Add("SettlementTime", ObjClass.SettlementTime, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RemoteDownload", ObjClass.RemoteDownload, DbType.String, ParameterDirection.Input);
            parameters.Add("Url", ObjClass.Url, DbType.String, ParameterDirection.Input);
            parameters.Add("BatchNo", ObjClass.BatchNo, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantSaveTerminalParametersModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantGetHotlistedMonthYearModelOuput>> GetHotlistedMonthYear([FromBody] MerchantGetHotlistedMonthYearModelInput ObjClass)
        {
            var procedureName = "UspGetHotlistedMonthYear";
            var parameters = new DynamicParameters();

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantGetHotlistedMonthYearModelOuput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
