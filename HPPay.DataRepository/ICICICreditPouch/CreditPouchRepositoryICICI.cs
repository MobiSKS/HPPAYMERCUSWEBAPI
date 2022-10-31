using Dapper;
using HPPay.DataModel.HDFCCreditPouch;
using HPPay.DataModel.ICICICreditPouch;
using HPPay.DataRepository.DBDapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.ICICICreditPouch
{
    public  class CreditPouchRepositoryICICI: ICreditPouchRepositoryICICI
    {
        private readonly DapperContext _context;
        public int BankNameId = 2;
        public CreditPouchRepositoryICICI(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CheckICICICreditPouchEligibilityModelOutPut>>CheckCreditPouchEligibility([FromBody] CheckICICICreditPouchEligibilityModelInput ObjClass)
        {
            var procedureName = "UspCheckCreditPouchEligibility";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckICICICreditPouchEligibilityModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetICICICustomerDetailsForCreditPouchByMOModelOutPut> GetCustomerDetailsForCreditPouchByMO([FromBody] GetICICICustomerDetailsForCreditPouchByMOModelInput ObjClass)
        {
            var procedureName = "UspGetCustomerDetailsForCreditPouchByMO";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("RequestedBy", ObjClass.RequestedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetICICICustomerDetailsForCreditPouchByMOModelOutPut();
            storedProcedureResult.ICICICGetCustomerInfo = (List<ICICICGetCustomerInfo>)await result.ReadAsync<ICICICGetCustomerInfo>();
            storedProcedureResult.ICICICGetCustomerPrevInfo = (List<ICICICGetCustomerPrevInfo>)await result.ReadAsync<ICICICGetCustomerPrevInfo>();
            return storedProcedureResult;

        } 

        public async Task<IEnumerable<GetPlanNameModelICICIOutPut>> GetPlan([FromBody] GetPlanNameModelICICIInput ObjClass)
        {
            var procedureName = "UspGetPlan";
            var parameters = new DynamicParameters(); 
            //parameters.Add("Amount", ObjClass.Amount, DbType.String, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetPlanNameModelICICIOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InsertICICICreditPouchDetailsModelOutPut>> InsertCreditPouchDetails([FromBody] InsertICICICreditPouchDetailsModelInput ObjClass)
        {
            var procedureName = "USPInsertCreditPouchDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("FuleConsumptionCapacity", ObjClass.FuleConsumptionCapacity, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("PlanTypeId", ObjClass.PlanTypeId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);
            parameters.Add("ReferenceNo", ObjClass.ReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("MoComment", ObjClass.MoComment, DbType.String, ParameterDirection.Input); 
            parameters.Add("RequestedBy", ObjClass.RequestedBy, DbType.String, ParameterDirection.Input);  
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertICICICreditPouchDetailsModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetICICICreditPouchDetalsAtBankOutPut>> GetCreditPouchDetalsAtBank([FromBody] GetICICICreditPouchDetalsAtBankInput ObjClass)
        {
            var procedureName = "UspGetCreditPouchDetalsAtBank";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ZO", ObjClass.ZO, DbType.Int16, ParameterDirection.Input);
            parameters.Add("RO", ObjClass.RO, DbType.Int16, ParameterDirection.Input);
            parameters.Add("Status", ObjClass.Status, DbType.Int16, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetICICICreditPouchDetalsAtBankOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<ActionOnICICICreditPouchModelOutput>> ActionOnCreditPouch([FromBody] ActionOnICICICreditPouchModelInput ObjClass)
        {
            var dtDBR = new DataTable("UT_ActionOnCreditPouch");
            dtDBR.Columns.Add("CustomerId", typeof(string));
            dtDBR.Columns.Add("RequestId", typeof(string));
            dtDBR.Columns.Add("BankRemark", typeof(string));
            dtDBR.Columns.Add("ActionType", typeof(string));
            dtDBR.Columns.Add("ApprovedBy", typeof(string));
            dtDBR.Columns.Add("PlanName", typeof(string));
            dtDBR.Columns.Add("CPBankStatus", typeof(string));

            if (ObjClass.ObjBankEntryDetail != null)
            {
                foreach (ICICIBankEntryDetail ObjDetails in ObjClass.ObjBankEntryDetail)
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

            var procedureName = "UspActionOnCreditPouch";
            var parameters = new DynamicParameters();
            parameters.Add("UT_ActionOnCreditPouch", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ActionOnICICICreditPouchModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
         

        public async Task<IEnumerable<AuthActionOnICICICreditPouchModelOutput>> AuthActionOnCreditPouch([FromBody] AuthActionOnICICICreditPouchModelInput ObjClass)
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
                foreach (ICICIBankAuthEntryDetail ObjDetails in ObjClass.ObjBankAuthEntryDetail)
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


            var procedureName = "UspAuthActionOnCreditPouch";
            var parameters = new DynamicParameters();
            parameters.Add("UT_AuthActionOnCreditPouch", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AuthActionOnICICICreditPouchModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetICICICreditPouchDetalsForAuthOutPut>> GetCreditPouchDetalsForAuth([FromBody] GetICICICreditPouchDetalsForAuthInput ObjClass)
        {
            var procedureName = "UspGetCreditPouchDetalsForAuth";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetICICICreditPouchDetalsForAuthOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InsertICICICreditPouchDetailsByCustomerModelOutput>> InsertCreditPouchDetailsByCustomer([FromBody] InsertICICICreditPouchDetailsByCustomerModelInput ObjClass)
        {
            var procedureName = "USPInsertCreditPouchDetailsByCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("FuleConsumptionCapacity", ObjClass.FuleConsumptionCapacity, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("PlanTypeId", ObjClass.PlanTypeId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);

            parameters.Add("ReferenceNo", ObjClass.ReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerRemarks", ObjClass.CustomerRemarks, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RequestedBy", ObjClass.RequestedBy, DbType.String, ParameterDirection.Input); 
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertICICICreditPouchDetailsByCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetICICICreditPouchStatusOutPut>> GetCreditPouchStatus([FromBody] GetICICICreditPouchStatusInput ObjClass)
        {
            var procedureName = "UspGetCreditPouchStatus";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ZO", ObjClass.ZO, DbType.Int16, ParameterDirection.Input);
            parameters.Add("RO", ObjClass.RO, DbType.Int16, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetICICICreditPouchStatusOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);        }

        public async Task<IEnumerable<GetICICICreditPouchStatusReportOutPut>> GetCreditPouchStatusReport([FromBody] GetICICICreditPouchDetalsStatusReportInput ObjClass)
        {
            var procedureName = "UspGetCreditPouchStatusReport";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("RequestId", ObjClass.RequestId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetICICICreditPouchStatusReportOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InitiateICICICreditPouchRechargeModelOutPut>> InitiateCPRecharge([FromBody] InitiateICICICreditPouchRechargeModelInput ObjClass)
        {
            var procedureName = "UspInitiateCPRecharge";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InitiateICICICreditPouchRechargeModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async void InsertCPPGApiRequestResponse([FromBody] ICICIApiRequestResponse ObjClass)
        {
            var procedureName = "UspInsertCPPGApiRequestResponse";
            var parameters = new DynamicParameters();
            parameters.Add("BankName", ObjClass.BankName, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionId", ObjClass.TransactionId, DbType.String, ParameterDirection.Input);
            parameters.Add("Request", ObjClass.request, DbType.String, ParameterDirection.Input);
            parameters.Add("Response", ObjClass.response, DbType.String, ParameterDirection.Input);
            parameters.Add("Apiurl", ObjClass.apiurl, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.UserId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var res = await connection.QueryAsync<object>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InsertCreditPouchReferralDetailsModelOutPut>> InsertCreditPouchReferralDetails([FromBody] InsertCreditPouchReferralDetailsModelInput ObjClass)
        {
            var procedureName = "USPInsertCreditPouchReferralDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("ContactPerson", ObjClass.ContactPerson, DbType.String, ParameterDirection.Input);
            parameters.Add("City", ObjClass.City, DbType.String, ParameterDirection.Input);
            parameters.Add("StateId", ObjClass.StateId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("PinCode", ObjClass.PinCode, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Mobile", ObjClass.Mobile, DbType.String, ParameterDirection.Input);
            parameters.Add("PhoneNo", ObjClass.PhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Email", ObjClass.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("FuleReqPerMonth", ObjClass.FuleReqPerMonth, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("Address", ObjClass.Address, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);
            parameters.Add("DetailsSharedBy", ObjClass.DetailsSharedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("RequestStatus", ObjClass.RequestStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNo", ObjClass.ReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("RequestType", ObjClass.RequestType, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertCreditPouchReferralDetailsModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCreditPouchDetalsReferral>> GetCreditPouchReferral([FromBody] GetCreditPouchDetalsReferralInput ObjClass)
        {
            var procedureName = "USPGetCreditPouchReferralDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNo", ObjClass.ReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("StateId", ObjClass.StateId, DbType.Int16, ParameterDirection.Input);
            parameters.Add("StatusId", ObjClass.StatusId, DbType.Int16, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);
            parameters.Add("DetailsSharedBy", ObjClass.DetailsSharedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("RequestType", ObjClass.RequestType, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCreditPouchDetalsReferral>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
