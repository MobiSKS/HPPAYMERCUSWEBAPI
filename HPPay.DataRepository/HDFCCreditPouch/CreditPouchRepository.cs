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
    public  class CreditPouchRepository: ICreditPouchRepository
    {
        private readonly DapperContext _context;
        public int BankNameId = 1;
        public string Status = "Initiated";
        public CreditPouchRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CheckCreditPouchEligibilityModelOutPut>>CheckCreditPouchEligibility([FromBody] CheckCreditPouchEligibilityModelInput ObjClass)
        {
            var procedureName = "UspCheckCreditPouchEligibility";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("BankNameId",BankNameId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckCreditPouchEligibilityModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
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
          //  parameters.Add("Amount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("BankNameId",BankNameId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetPlanNameModelHDFCOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<InsertCreditPouchDetailsModelOutPut>> InsertCreditPouchDetails([FromBody] InsertCreditPouchDetailsModelInput ObjClass)
        {
            var procedureName = "USPInsertCreditPouchDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("FuleConsumptionCapacity", ObjClass.FuleConsumptionCapacity, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("PlanTypeId", ObjClass.PlanTypeId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("BankNameId",BankNameId, DbType.Int16, ParameterDirection.Input);
            parameters.Add("ReferenceNo", ObjClass.ReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("MoComment", ObjClass.MoComment, DbType.String, ParameterDirection.Input); 
            parameters.Add("RequestedBy", ObjClass.RequestedBy, DbType.String, ParameterDirection.Input); 

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertCreditPouchDetailsModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCreditPouchDetalsAtBankOutPut>> GetCreditPouchDetalsAtBank([FromBody] GetCreditPouchDetalsAtBankInput ObjClass)
        {
            var procedureName = "UspGetCreditPouchDetalsAtBank";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ZO", ObjClass.ZO, DbType.Int16, ParameterDirection.Input);
            parameters.Add("RO", ObjClass.RO, DbType.Int16, ParameterDirection.Input);
            parameters.Add("Status", ObjClass.Status, DbType.Int16, ParameterDirection.Input);
            parameters.Add("BankNameId",BankNameId, DbType.Int16, ParameterDirection.Input);
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCreditPouchDetalsAtBankOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ActionOnCreditPouchModelOutput>> ActionOnCreditPouch([FromBody] ActionOnCreditPouchModelInput ObjClass)
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

            var procedureName = "UspActionOnCreditPouch";
            var parameters = new DynamicParameters(); 
            parameters.Add("UT_ActionOnCreditPouch", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ActionOnCreditPouchModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AuthActionOnCreditPouchModelOutput>> AuthActionOnCreditPouch([FromBody] AuthActionOnCreditPouchModelInput ObjClass)
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

            var procedureName = "UspAuthActionOnCreditPouch";
            var parameters = new DynamicParameters();
            parameters.Add("UT_AuthActionOnCreditPouch", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AuthActionOnCreditPouchModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCreditPouchDetalsForAuthOutPut>> GetCreditPouchDetalsForAuth([FromBody] GetCreditPouchDetalsForAuthInput ObjClass)
        {
            var procedureName = "UspGetCreditPouchDetalsForAuth";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("BankNameId",BankNameId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCreditPouchDetalsForAuthOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InsertCreditPouchDetailsByCustomerModelOutput>> InsertCreditPouchDetailsByCustomer([FromBody] InsertCreditPouchDetailsByCustomerModelInput ObjClass)
        {
            var procedureName = "USPInsertCreditPouchDetailsByCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("FuleConsumptionCapacity", ObjClass.FuleConsumptionCapacity, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("PlanTypeId", ObjClass.PlanTypeId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("BankNameId",BankNameId, DbType.Int16, ParameterDirection.Input);
            parameters.Add("ReferenceNo", ObjClass.ReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerRemarks", ObjClass.CustomerRemarks, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RequestedBy", ObjClass.RequestedBy, DbType.String, ParameterDirection.Input); 
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertCreditPouchDetailsByCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCreditPouchStatusOutPut>> GetCreditPouchStatus([FromBody] GetCreditPouchStatusInput ObjClass)
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
            return await connection.QueryAsync<GetCreditPouchStatusOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);        }

        public async Task<IEnumerable<GetCreditPouchStatusReportOutPut>> GetCreditPouchStatusReport([FromBody] GetCreditPouchDetalsStatusReportInput ObjClass)
        {
            var procedureName = "UspGetCreditPouchStatusReport";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("RequestId", ObjClass.RequestId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.Int16, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCreditPouchStatusReportOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }         

        public async Task<IEnumerable<InitiateCreditPouchRechargeModelOutPut>> InitiateCPRecharge([FromBody] InitiateCreditPouchRechargeModelInput ObjClass)
        {
            var procedureName = "UspInitiateCPRecharge";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("BankNameId",BankNameId, DbType.Int16, ParameterDirection.Input);
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
            parameters.Add("Apiurl", ObjClass.apiurl+ ObjClass.request_Hash, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("Amt", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("BankStatus", Status, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNo", ObjClass.ControlCardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.UserId, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("SourceId", ObjClass.SourceId, DbType.String, ParameterDirection.Input);
            parameters.Add("Formfactor", ObjClass.Formfactor, DbType.String, ParameterDirection.Input);
            parameters.Add("TrnsSource", ObjClass.TrnsSource, DbType.String, ParameterDirection.Input); 
            using var connection = _context.CreateConnection();
            var res = await connection.QueryAsync<object>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<HdfcTransactionStatusModelOutPut>> HdfcTransactionStatus([FromBody] HdfcTransactionStatusModelInput ObjClass)
        {
            var procedureName = "UspHdfcTransactionStatus";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("Type", "All", DbType.String, ParameterDirection.Input);
            parameters.Add("BankNameId", BankNameId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HdfcTransactionStatusModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<HdfcTransactionStatusModelOutPut>> HdfcTransactionStatusReport([FromBody] HdfcTransactionStatusReportModelInput ObjClass)
        {
            var procedureName = "UspHdfcTransactionReport";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("OrderId", ObjClass.OrderId, DbType.String, ParameterDirection.Input); 
            parameters.Add("BankNameId", BankNameId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HdfcTransactionStatusModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
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
