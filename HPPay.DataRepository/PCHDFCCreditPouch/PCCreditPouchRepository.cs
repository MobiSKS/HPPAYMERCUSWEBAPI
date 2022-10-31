using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.HDFCCreditPouch;
using HPPay.DataRepository.DBDapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.HDFCCreditPouch
{
    public  class PCCreditPouchRepository: IPCCreditPouchRepository
    {
        private readonly DapperContext _context;
        public int BankNameId = 1;
        public int CustomerSubType = 913;
        public int CustomerType = 981;
        public string Status = "Initiated";
        public PCCreditPouchRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CheckCreditPouchEligibilityModelOutPut>> CheckCreditPouchEligibilityForPC([FromBody] CheckCreditPouchEligibilityModelInput ObjClass)
        {
            var procedureName = "UspCheckCreditPouchEligibilityForPC";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("BankNameId",BankNameId, DbType.Int16, ParameterDirection.Input);
             parameters.Add("CustomerSubType", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckCreditPouchEligibilityModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<GetCustomerDetailsForCreditPouchByMOModelOutPut> GetCustomerDetailsForCreditPouchByMOForPC([FromBody] GetCustomerDetailsForCreditPouchByMOModelInput ObjClass)
        {
            var procedureName = "UspGetCustomerDetailsForCreditPouchByMOForPC";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("RequestedBy", ObjClass.RequestedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetCustomerDetailsForCreditPouchByMOModelOutPut();
            storedProcedureResult.GetCustomerInfo = (List<GetCustomerInfo>)await result.ReadAsync<GetCustomerInfo>();
            storedProcedureResult.GetCustomerPrevInfo = (List<GetCustomerPrevInfo>)await result.ReadAsync<GetCustomerPrevInfo>();
            return storedProcedureResult;

        }

        public async Task<GetCustomerDetailsForCreditPouchByMOModelOutPut> GetCustomerDetailsForCreditPouchByMO([FromBody] GetCustomerDetailsForCreditPouchByMOModelInput ObjClass)
        {
            var procedureName = "UspGetCustomerDetailsForCreditPouchByMO";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("RequestedBy", ObjClass.RequestedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetCustomerDetailsForCreditPouchByMOModelOutPut();
            storedProcedureResult.GetCustomerInfo = (List<GetCustomerInfo>)await result.ReadAsync<GetCustomerInfo>();
            storedProcedureResult.GetCustomerPrevInfo = (List<GetCustomerPrevInfo>)await result.ReadAsync<GetCustomerPrevInfo>();
            return storedProcedureResult;

        }

        public async Task<IEnumerable<GetPlanNameModelHDFCOutPut>> GetPlan([FromBody] GetPlanNameModelHDFCInput ObjClass)
        {
            var procedureName = "UspGetPlan";
            var parameters = new DynamicParameters();
           // parameters.Add("Amount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("BankNameId",BankNameId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetPlanNameModelHDFCOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<InsertCreditPouchDetailsModelOutPut>> InsertCreditPouchDetailsForPC([FromBody] InsertCreditPouchDetailsModelInput ObjClass)
        {
            var procedureName = "USPInsertCreditPouchDetailsForPC";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("FuleConsumptionCapacity", ObjClass.FuleConsumptionCapacity, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("PlanTypeId", ObjClass.PlanTypeId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("BankNameId",BankNameId, DbType.Int16, ParameterDirection.Input);
            parameters.Add("ReferenceNo", ObjClass.ReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("MoComment", ObjClass.MoComment, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType",1, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RequestedBy", ObjClass.RequestedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerSubType", CustomerSubType, DbType.Int32, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertCreditPouchDetailsModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCreditPouchDetalsAtBankOutPut>> GetCreditPouchDetalsAtBankForPC([FromBody] GetCreditPouchDetalsAtBankInput ObjClass)
        {
            var procedureName = "UspGetCreditPouchDetalsAtBankForPC";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ZO", ObjClass.ZO, DbType.Int16, ParameterDirection.Input);
            parameters.Add("RO", ObjClass.RO, DbType.Int16, ParameterDirection.Input);
            parameters.Add("Status", ObjClass.Status, DbType.Int16, ParameterDirection.Input);
            parameters.Add("BankNameId",BankNameId, DbType.Int16, ParameterDirection.Input);
            parameters.Add("CustomerSubType", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCreditPouchDetalsAtBankOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ActionOnCreditPouchModelOutput>> ActionOnCreditPouchForPC([FromBody] ActionOnCreditPouchModelInput ObjClass)
        {
            var dtDBR = new DataTable("UT_ActionOnCreditPouch");
            dtDBR.Columns.Add("CustomerId", typeof(string));
            dtDBR.Columns.Add("RequestId",  typeof(string));
            dtDBR.Columns.Add("BankRemark", typeof(string));
            dtDBR.Columns.Add("ActionType", typeof(string));
            dtDBR.Columns.Add("ApprovedBy", typeof(string));
            dtDBR.Columns.Add("PlanName", typeof(string));
            dtDBR.Columns.Add("CPBankStatus",typeof(string));

            if (ObjClass.ObjBankEntryDetail != null)
            {
                foreach (HDFCBankEntryDetail ObjDetails in ObjClass.ObjBankEntryDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CustomerId"] = ObjDetails.CustomerId;
                    dr["RequestId"] = ObjDetails.RequestId;
                    dr["BankRemark"] = ObjDetails.BankRemark;
                    dr["ActionType"] = ObjDetails.ActionType;
                    dr["ApprovedBy"] = ObjDetails.ApprovedBy;
                    dr["PlanName"] = ObjDetails.PlanName;
                    dr["CPBankStatus"] = BankNameId;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspActionOnCreditPouchForPC";
            var parameters = new DynamicParameters(); 
            parameters.Add("UT_ActionOnCreditPouch", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ActionOnCreditPouchModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AuthActionOnCreditPouchModelOutput>> AuthActionOnCreditPouchForPC([FromBody] AuthActionOnCreditPouchModelInput ObjClass)
        {
            var dtDBR = new DataTable("UT_AuthActionOnCreditPouch");
            dtDBR.Columns.Add("CustomerId", typeof(string));
            dtDBR.Columns.Add("RequestId", typeof(string));
            dtDBR.Columns.Add("AuthorizationRemark", typeof(string));
            dtDBR.Columns.Add("ActionType", typeof(string));
            dtDBR.Columns.Add("CreditLimitAssigned", typeof(string));
            dtDBR.Columns.Add("PlanName", typeof(string));
            dtDBR.Columns.Add("AuthorizBy", typeof(string)); 

            if (ObjClass.ObjBankAuthEntryDetail != null)
            {
                foreach (HDFDCBankAuthEntryDetail ObjDetails in ObjClass.ObjBankAuthEntryDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CustomerId"] = ObjDetails.CustomerId;
                    dr["RequestId"] = ObjDetails.RequestId;
                    dr["AuthorizationRemark"] = ObjDetails.AuthorizationRemark;
                    dr["ActionType"] = ObjDetails.ActionType;
                    dr["CreditLimitAssigned"] = ObjDetails.CreditLimitAssigned;
                    dr["PlanName"] = ObjDetails.PlanName;
                    dr["AuthorizBy"] = ObjDetails.AuthorizBy; 
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }
            var procedureName = "UspAuthActionOnCreditPouchForPC";
            var parameters = new DynamicParameters();
            parameters.Add("UT_AuthActionOnCreditPouch", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AuthActionOnCreditPouchModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCreditPouchDetalsForAuthOutPut>> GetCreditPouchDetalsForAuthForPC([FromBody] GetCreditPouchDetalsForAuthInput ObjClass)
        {
            var procedureName = "UspGetCreditPouchDetalsForAuthForPC";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("BankNameId",BankNameId, DbType.Int16, ParameterDirection.Input);
             parameters.Add("CustomerSubType", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCreditPouchDetalsForAuthOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InsertCreditPouchDetailsByCustomerModelOutput>> InsertCreditPouchDetailsByCustomerForPC([FromBody] InsertCreditPouchDetailsByCustomerModelInput ObjClass)
        {
            var procedureName = "USPInsertCreditPouchDetailsByCustomerForPC";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("FuleConsumptionCapacity", ObjClass.FuleConsumptionCapacity, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("PlanTypeId", ObjClass.PlanTypeId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("BankNameId",BankNameId, DbType.Int16, ParameterDirection.Input);
            parameters.Add("ReferenceNo", ObjClass.ReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerRemarks", ObjClass.CustomerRemarks, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RequestedBy", ObjClass.RequestedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerSubType", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertCreditPouchDetailsByCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCreditPouchStatusOutPut>> GetCreditPouchStatusForPC([FromBody] GetCreditPouchStatusInput ObjClass)
        {
            var procedureName = "UspGetCreditPouchStatusForPC";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ZO", ObjClass.ZO, DbType.Int16, ParameterDirection.Input);
            parameters.Add("RO", ObjClass.RO, DbType.Int16, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubType", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int16, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCreditPouchStatusOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);        }

        public async Task<IEnumerable<GetCreditPouchStatusReportOutPut>> GetCreditPouchStatusReportForPC([FromBody] GetCreditPouchDetalsStatusReportInput ObjClass)
        {
            var procedureName = "UspGetCreditPouchStatusReportForPC";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("RequestId", ObjClass.RequestId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("CustomerSubType", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCreditPouchStatusReportOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }         

        public async Task<IEnumerable<InitiateCreditPouchRechargeModelOutPut>> InitiateCPRechargeForPC([FromBody] InitiateCreditPouchRechargeModelInput ObjClass)
        {
            var procedureName = "UspInitiateCPRechargeForPC";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("BankNameId",BankNameId, DbType.Int16, ParameterDirection.Input);
            parameters.Add("CustomerSubType", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InitiateCreditPouchRechargeModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async void InsertCPPGApiRequestResponse([FromBody] ApiRequestResponse ObjClass)
        {
            var procedureName = "UspInsertCPPGApiRequestResponse";
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
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var res = await connection.QueryAsync<object>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }         

    }
}
