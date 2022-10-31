using HPPay.DataRepository.DBDapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

using System.Threading.Tasks;

using System.Web.Http;
using HPPay.DataModel.DealerCreditManage;
using HPPay.DataModel;

namespace HPPay.DataRepository.DealerCreditManage
{
    public class DealerCreditManageRepository : IDealerCreditManageRepository
    {

        private readonly DapperContext _context;
        public DealerCreditManageRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<GetDealerCreditMappingDetailsModelOutput> GetDealerCreditMappingDetails([FromBody] GetDealerCreditMappingDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetDealerCreditMappingDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetDealerCreditMappingDetailsModelOutput();
            storedProcedureResult.CustomerCCMSBalanceDetails = (List<GetCustomerCCMSBalanceDetails>)await result.ReadAsync<GetCustomerCCMSBalanceDetails>();
            storedProcedureResult.CustomerDetails = (List<GetCustomerDetails>)await result.ReadAsync<GetCustomerDetails>();
            storedProcedureResult.CustomerMerchantMappedDetails = (List<GetCustomerMerchantMappedDetails>)await result.ReadAsync<GetCustomerMerchantMappedDetails>();

            return storedProcedureResult;
        }

        public async Task<IEnumerable<GetListCreditCloseLimitTypeModelOutput>> GetListCreditCloseLimitType([FromBody] GetListCreditCloseLimitTypeModelInput ObjClass)
        {
            var procedureName = "UspGetListCreditCloseLimitType";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetListCreditCloseLimitTypeModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetListCreditPeriodModelOutput>> GetListCreditPeriod([FromBody] GetListCreditPeriodModelInput ObjClass)
        {
            var procedureName = "UspGetListCreditPeriod";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetListCreditPeriodModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DCMInsertMapDealerForCreditSaleModelOutput>> DCMInsertMapDealerForCreditSale([FromBody] DCMInsertMapDealerForCreditSaleModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeMapDealerForCreditSale");
            dtDBR.Columns.Add("MerchantID", typeof(string));
            dtDBR.Columns.Add("CreditPeriod", typeof(string));
            dtDBR.Columns.Add("EffectiveDate", typeof(string));
            
            var procedureName = "UspInsertMapDealerForCreditSale";
            var parameters = new DynamicParameters();


            foreach (TypeMapDealerForCreditSale ObjDCM in ObjClass.TypeMapDealerForCreditSale)
            {
                DataRow dr = dtDBR.NewRow();
                dr["MerchantID"] = ObjDCM.MerchantID;
                dr["CreditPeriod"] = ObjDCM.CreditPeriod;
                dr["EffectiveDate"] = ObjDCM.EffectiveDate;

                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }



            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);

            parameters.Add("TypeMapDealerForCreditSale", dtDBR, DbType.Object, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DCMInsertMapDealerForCreditSaleModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

      
        public async Task<IEnumerable<CustomerMerchantMappingEnableDisableModelOutput>> CustomerMerchantMappingEnableDisable([FromBody] CustomerMerchantMappingEnableDisableModelInput ObjClass)
        {
            var procedureName = "UspCustomerMerchantMappingEnableDisable";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("Action", ObjClass.Action, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerMerchantMappingEnableDisableModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<IEnumerable<UpdateDealerCreditMappingModelOutput>> UpdateDealerCreditMapping([FromBody] UpdateDealerCreditMappingModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeUpdateDealerCreditMapping");
            dtDBR.Columns.Add("MerchantID", typeof(string));
            dtDBR.Columns.Add("CreditCloseLimitType", typeof(string));
            dtDBR.Columns.Add("LimitAmount", typeof(decimal));

            var procedureName = "UspUpdateDealerCreditMapping";
            var parameters = new DynamicParameters();

            foreach (TypeUpdateDealerCreditMapping ObjDCM in ObjClass.TypeUpdateDealerCreditMapping)
            {
                DataRow dr = dtDBR.NewRow();
                dr["MerchantID"] = ObjDCM.MerchantID;
                dr["CreditCloseLimitType"] = ObjDCM.CreditCloseLimitType;
                dr["LimitAmount"] = ObjDCM.LimitAmount;

                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
           
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);

            parameters.Add("TypeUpdateDealerCreditMapping", dtDBR, DbType.Object, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateDealerCreditMappingModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public  async Task<IEnumerable<GetDealerCreditSaleStatementModelOutput>> GetDealerCreditSaleStatement([FromBody] GetDealerCreditSaleStatementModelInput ObjClass)
        {
            var procedureName = "UspDealerCreditSaleStatement";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);

            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
           
             using var connection = _context.CreateConnection();

            return await connection.QueryAsync<GetDealerCreditSaleStatementModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<GetDealerCreditPaymentStatusModelOutput>> GetDealerCreditPaymentStatus([FromBody] GetDealerCreditPaymentStatusModelInput ObjClass)
        {
            var procedureName = "UspDealerCreditPaymentStatus";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);

            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<GetDealerCreditPaymentStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }


        public async Task<IEnumerable<GetDealerCreditSaleViewModelOutput>> GetDealerCreditSaleView([FromBody] GetDealerCreditSaleViewModelInput ObjClass)
        {
            var procedureName = "UspGetDealerCreditSaleView";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);

            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<GetDealerCreditSaleViewModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }
        

        public async Task<IEnumerable<GetCreditSaleViewModelOutput>> GetCreditSaleView([FromBody] GetCreditSaleViewModelInput ObjClass)
        {
            var procedureName = "UspGetCreditSaleView";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);

            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<GetCreditSaleViewModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }
        public async Task<GetMerchantDealerCreditSaleStatementModelOutput> GetMerchantDealerCreditSaleStatement([FromBody] GetMerchantDealerCreditSaleStatementModelInput ObjClass)
        {
            var procedureName = "UspGetMerchantDealerCreditSaleStatement";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("StatementDate", ObjClass.StatementDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetMerchantDealerCreditSaleStatementModelOutput();

            storedProcedureResult.ViewStatementDetails = (List<ViewStatementDetails>)await result.ReadAsync<ViewStatementDetails>();
            storedProcedureResult.TransactionDetails = (List<TransactionDetails>)await result.ReadAsync<TransactionDetails>();


            return storedProcedureResult;
        }
        public async Task<GetDownloadMerchantDealerCreditSaleStatementModelOutput> GetDownloadMerchantDealerCreditSaleStatement([FromBody] GetDownloadMerchantDealerCreditSaleStatementModelInput ObjClass)
        {
            var procedureName = "UspGetDownloadMerchantDealerCreditSaleStatement";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("StatementDate", ObjClass.StatementDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetDownloadMerchantDealerCreditSaleStatementModelOutput();


            storedProcedureResult.ViewCustomerMerchantDetails = (List<ViewCustomerMerchantDetails>)await result.ReadAsync<ViewCustomerMerchantDetails>();
            storedProcedureResult.GetStatementDetails = (List<GetStatementDetails>)await result.ReadAsync<GetStatementDetails>();
            storedProcedureResult.GetTransactionDetails = (List<GetTransactionDetails>)await result.ReadAsync<GetTransactionDetails>();


            return storedProcedureResult;
        }



        public async Task<GetCreditSaleOutstandingDetailsModelOutput> GetCreditSaleOutstandingDetails([FromBody] GetCreditSaleOutstandingDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetCreditSaleOutstandingDetails";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetCreditSaleOutstandingDetailsModelOutput();

            storedProcedureResult.MerchantDetails = (List<GetMerchantDetails>)await result.ReadAsync<GetMerchantDetails>();

            storedProcedureResult.MerchantCustomerMappedDetails = (List<GetMerchantCustomerMappedDetails>)await result.ReadAsync<GetMerchantCustomerMappedDetails>();

            return storedProcedureResult;
        }

        public async Task<IEnumerable<GetStatementDateListModelOutput>> GetStatementDateList([FromBody] GetStatementDateListModelInput ObjClass)
        {
            var procedureName = "UspGetStatementDateList";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetStatementDateListModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetDealerCreditSaleDetailsModelOutput>> GetDealerCreditSaleDetails([FromBody] GetDealerCreditSaleDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetDealerCreditSaleDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);

            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<GetDealerCreditSaleDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }



        public async Task<IEnumerable<GetDealerCreditPaymentInBulkModelOutput>> GetDealerCreditPaymentInBulk([FromBody] GetDealerCreditPaymentInBulkModelInput ObjClass)
        {
            var procedureName = "UspGetDealerCreditPaymentInBulk";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDealerCreditPaymentInBulkModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GenerateOTPCreditClosePaymentModelOutput>> GenerateOTPCreditClosePayment([FromBody] GenerateOTPCreditClosePaymentModelInput ObjClass)
        {
            var procedureName = "UspGenerateOtpCreditClosePayment";
            var parameters = new DynamicParameters();
            parameters.Add("Merchantid", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("SourceofPayment", ObjClass.SourceofPayment, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GenerateOTPCreditClosePaymentModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<ValidateOTPUpdateCreditClosePaymentModelOutput>> ValidateOTPUpdateCreditClosePayment([FromBody] ValidateOTPUpdateCreditClosePaymentModelInput ObjClass)
        {
            var procedureName = "UspValidateOtpUpdateCreditClosePayment";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("SourceofPayment", ObjClass.SourceofPayment, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ValidateOTPUpdateCreditClosePaymentModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetCreditClosePaymentModelOutput>> GetCreditClosePayment([FromBody] GetCreditClosePaymentModelInput ObjClass)
        {
            var procedureName = "UspGetCreditClosePayment";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<GetCreditClosePaymentModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<UpdateDealerCreditPaymentInBulkModelOutput>> UpdateDealerCreditPaymentInBulk([FromBody] UpdateDealerCreditPaymentInBulkModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeUpdateDealerCreditPaymentInBulk");
            dtDBR.Columns.Add("CustomerID", typeof(string));
            dtDBR.Columns.Add("MerchantID", typeof(string));
            dtDBR.Columns.Add("Outstanding", typeof(decimal));
            dtDBR.Columns.Add("Amount", typeof(decimal));

            var procedureName = "UspUpdateDealerCreditPaymentInBulk";
            var parameters = new DynamicParameters();

            foreach (TypeUpdateDealerCreditPaymentInBulk ObjDCM in ObjClass.TypeUpdateDealerCreditPaymentInBulk)
            {
                DataRow dr = dtDBR.NewRow();
                dr["MerchantID"] = ObjDCM.MerchantID;
                dr["CustomerID"] = ObjDCM.CustomerID;
                dr["Outstanding"] = ObjDCM.Outstanding;
                dr["Amount"] = ObjDCM.Amount;


                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }
           
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ApiReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeUpdateDealerCreditPaymentInBulk", dtDBR, DbType.Object, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateDealerCreditPaymentInBulkModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


       


    }


}
