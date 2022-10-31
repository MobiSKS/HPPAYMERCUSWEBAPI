using HPPay.DataRepository.DBDapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using HPPay.DataModel.COMCO;
using System.Linq;
using System.IO;
using HPPay.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace HPPay.DataRepository.COMCO
{
    public class COMCORepository : ICOMCORepository
    {

        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public COMCORepository(DapperContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;

        }


        public async Task<GetCOMCOMapCustomerDetailsModelOutput> GetCOMCOMapCustomerDetails([FromBody] GetCOMCOMapCustomerDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetCOMCOMapCustomerDetails";
            var parameters = new DynamicParameters();

            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();

            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetCOMCOMapCustomerDetailsModelOutput();

            storedProcedureResult.MerchantDetails = (List<GetMerchantDetails>)await result.ReadAsync<GetMerchantDetails>();
            storedProcedureResult.CustomerDetails = (List<GetCustomerDetails>)await result.ReadAsync<GetCustomerDetails>();

            return storedProcedureResult;
        }


        public async Task<IEnumerable<UpdateCOMCOMapCustomerModelOutput>> UpdateCOMCOMapCustomer([FromBody] UpdateCOMCOMapCustomerModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeCOMCOMapCustomer");
            dtDBR.Columns.Add("CustomerID", typeof(string));

            var procedureName = "UspUpdateCOMCOMapCustomer";
            var parameters = new DynamicParameters();


            foreach (TypeCOMCOMapCustomer ObjComco in ObjClass.TypeCOMCOMapCustomer)
            {
                DataRow dr = dtDBR.NewRow();
                dr["CustomerID"] = ObjComco.CustomerID;


                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }

            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);

            parameters.Add("TypeCOMCOMapCustomer", dtDBR, DbType.Object, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCOMCOMapCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<GetCOMCOViewMappedCustomerModelOutput> GetCOMCOViewMappedCustomer([FromBody] GetCOMCOViewMappedCustomerModelInput ObjClass)
        {
            var procedureName = "UspGetCOMCOViewMappedCustomer";
            var parameters = new DynamicParameters();

            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();

            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetCOMCOViewMappedCustomerModelOutput();

            storedProcedureResult.MerchantDetails = (List<MerchantDetails>)await result.ReadAsync<MerchantDetails>();
            storedProcedureResult.MappedDetails = (List<MappedDetails>)await result.ReadAsync<MappedDetails>();

            return storedProcedureResult;
        }


        public async Task<IEnumerable<GetViewMappedCustomerModelOutput>> GetViewMappedCustomer([FromBody] GetViewMappedCustomerModelInput ObjClass)
        {
            var procedureName = "UspGetViewMappedCustomer";
            var parameters = new DynamicParameters();

            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<GetViewMappedCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
           
        }


        public async Task<IEnumerable<GetCOMCOLimitSetModeModelOutput>> GetCOMCOLimitSetMode([FromBody] GetCOMCOLimitSetModeModelInput ObjClass)
        {
            var procedureName = "UspGetCOMCOLimitSetMode";

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCOMCOLimitSetModeModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);


        }


        public async Task<IEnumerable<GetCOMCOLimitSetInvoiceIntervalModelOutput>> GetCOMCOLimitSetInvoiceInterval([FromBody] GetCOMCOLimitSetInvoiceIntervalModelInput ObjClass)
        {
            var procedureName = "UspGetCOMCOLimitSetInvoiceInterval";

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCOMCOLimitSetInvoiceIntervalModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<COMCOLimitSetRequestModelOutput>> COMCOLimitSetRequest([FromForm] COMCOLimitSetRequestModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeInsertChequeDetails");
            dtDBR.Columns.Add("ChequeBDSCRNumber", typeof(string));
            dtDBR.Columns.Add("ChequeBDSCRDate", typeof(string));

            var procedureName = "UspCOMCOLimitSetRequest";
            var parameters = new DynamicParameters();

            parameters.Add("NoofCheques", ObjClass.NoofCheques, DbType.Int16, ParameterDirection.Input);

            //foreach (TypeInsertChequeDetails ObjComco in ObjClass.TypeInsertChequeDetails)
            //{
            if (ObjClass.NoofCheques > 0)
            {
                // var FileName = ObjClass.ChequeBDSCRDate.ToList().Count;
                DataTable dtR = new DataTable();
                if(ObjClass.ChequeBDSCRNumber != null && ObjClass.ChequeBDSCRDate != null)
                {
                    for (int i = 0; i < ObjClass.ChequeBDSCRNumber.Count && i < ObjClass.ChequeBDSCRDate.Count; i++)
                    {
                        DataRow dr = dtDBR.NewRow();
                        dr["ChequeBDSCRNumber"] = ObjClass.ChequeBDSCRNumber[i];
                        dr["ChequeBDSCRDate"] = ObjClass.ChequeBDSCRDate[i];
                        dtDBR.Rows.Add(dr);
                        dtDBR.AcceptChanges();
                    }
                }
                
            }
            //else
            //{
            //    DataTable dtR = new DataTable();
            //    DataRow dr = dtDBR.NewRow();
            //    dr["ChequeBDSCRNumber"] = ObjClass.ChequeBDSCRNumber.ToList() == null ?"" : ObjClass.ChequeBDSCRNumber ;
            //    dr["ChequeBDSCRDate"] = ObjClass.ChequeBDSCRDate.ToList() == null? "": ObjClass.ChequeBDSCRDate;

            //    dtDBR.Rows.Add(dr);
            //    dtDBR.AcceptChanges();
            //}

            //}
            string FileNamePathScannedReferenceDocument = string.Empty;
            var ImageFileNameScannedReferenceDocument = ObjClass.ScannedReferenceDocument;
            if (ImageFileNameScannedReferenceDocument.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".doc", ".pdf", ".docx" };
                var ext = ImageFileNameScannedReferenceDocument.FileName.Substring(ImageFileNameScannedReferenceDocument.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathScannedReferenceDocument = "/COMCOImage/" + ObjClass.CustomerID + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.ScannedReferenceDocument + "_" + ImageFileNameScannedReferenceDocument.FileName;
                    string filePathScannedReferenceDocument = contentRootPath + FileNamePathScannedReferenceDocument;
                    var fileStream = new FileStream(filePathScannedReferenceDocument, FileMode.Create);
                    ImageFileNameScannedReferenceDocument.CopyTo(fileStream);
                }
            }
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("LimitSetMode", ObjClass.LimitSetMode, DbType.Int32, ParameterDirection.Input);

            parameters.Add("Amount", ObjClass.Amount, DbType.Double, ParameterDirection.Input);
            parameters.Add("CautionAmount", ObjClass.CautionAmount, DbType.Double, ParameterDirection.Input);
            parameters.Add("FinanceCharges", ObjClass.FinanceCharges, DbType.Double, ParameterDirection.Input);
            parameters.Add("ServicesCharges", ObjClass.ServicesCharges, DbType.Double, ParameterDirection.Input);

            parameters.Add("ScannedReferenceDocument", FileNamePathScannedReferenceDocument, DbType.String, ParameterDirection.Input);
            parameters.Add("COMCOPackageID", ObjClass.COMCOPackageID, DbType.String, ParameterDirection.Input);
            parameters.Add("InvoiceIntervalId", ObjClass.InvoiceIntervalId, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);

            parameters.Add("TypeInsertChequeDetails", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<COMCOLimitSetRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCOMCOLimitSetRequestDetailsModelOutput>> GetCOMCOLimitSetRequestDetails([FromBody] GetCOMCOLimitSetRequestDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetCOMCOLimitSetRequestDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("LimitSetMode", ObjClass.LimitSetMode, DbType.Int32, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCOMCOLimitSetRequestDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetRMRechargeModeModelOutput>> GetRMRechargeMode([FromBody] GetRMRechargeModeModelInput ObjClass)
        {
            var procedureName = "UspGetRMRechargeMode";

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetRMRechargeModeModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);


        }
        public async Task<IEnumerable<GetApprovalCreditLimitDetailsModelOutput>> GetApprovalCreditLimitDetails([FromBody] GetApprovalCreditLimitDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetApprovalCreditLimitDetails";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("RechargeMode", ObjClass.RechargeMode, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetApprovalCreditLimitDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ViewDownloadCOMCOCustomerDetailsModelOutput>> ViewDownloadCOMCOCustomerDetails([FromBody] ViewDownloadCOMCOCustomerDetailsModelInput ObjClass)
        {
            var procedureName = "UspViewDownloadCOMCOCustomerDetails";
            var parameters = new DynamicParameters();
           
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
           
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);

            parameters.Add("REQID", ObjClass.REQID, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ViewDownloadCOMCOCustomerDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<UpdateApproveRejectCreditLimitModelOutput>> UpdateApproveRejectCreditLimit([FromBody] UpdateApproveRejectCreditLimitModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeApproveRejectCreditLimit");
            dtDBR.Columns.Add("MerchantID", typeof(string));
            dtDBR.Columns.Add("CustomerID", typeof(string));

            dtDBR.Columns.Add("Amount", typeof(decimal));
            dtDBR.Columns.Add("CautionAmount", typeof(decimal));
            dtDBR.Columns.Add("Comments", typeof(string));
            dtDBR.Columns.Add("REQID", typeof(string));
            var procedureName = "UspUpdateApproveRejectCreditLimit";  
            var parameters = new DynamicParameters();


            foreach (GetTypeApproveRejectCreditLimit ObjComco in ObjClass.TypeApproveRejectCreditLimit)
            {
                DataRow dr = dtDBR.NewRow();
              
                dr["MerchantID"] = ObjComco.MerchantID;
                dr["CustomerID"] = ObjComco.CustomerID;
                dr["Amount"] = ObjComco.Amount;
                dr["CautionAmount"] = ObjComco.CautionAmount;
                dr["Comments"] = ObjComco.Comments;
                dr["REQID"] = ObjComco.REQID;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }

            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);

            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            //parameters.Add("Comments", ObjClass.Comments, DbType.String, ParameterDirection.Input);

            parameters.Add("TypeApproveRejectCreditLimit", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateApproveRejectCreditLimitModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<ViewCreditLimitModelOutput>> ViewCreditLimit([FromBody] ViewCreditLimitModelInput ObjClass)
        {
            var procedureName = "UspViewCreditLimit";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("RechargeMode", ObjClass.RechargeMode, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Status", ObjClass.Status, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ViewCreditLimitModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<CustomerCreditandCautionLimitHistoryModelOutput>> CustomerCreditandCautionLimitHistory([FromBody] CustomerCreditandCautionLimitHistoryModelInput ObjClass)
        {
            var procedureName = "UspCustomerCreditandCautionLimitHistory";
            var parameters = new DynamicParameters();

            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerCreditandCautionLimitHistoryModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<COMCOCreditAccountSummaryModelOutput>> COMCOCreditAccountSummary([FromBody] COMCOCreditAccountSummaryModelInput ObjClass)
        {
            var procedureName = "UspCOMCOCreditAccountSummary";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<COMCOCreditAccountSummaryModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<IEnumerable<COMCOCreditCustomerAccountSummaryModelOutput>> COMCOCreditCustomerAccountSummary([FromBody] COMCOCreditCustomerAccountSummaryModelInput ObjClass)
        {
            var procedureName = "UspCOMCOCreditCustomerAccountSummary";
            var parameters = new DynamicParameters();

            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("DepositType", ObjClass.DepositType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<COMCOCreditCustomerAccountSummaryModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<COMCOCreditCustomerAccountDetailsModelOutput> COMCOCreditCustomerAccountDetails([FromBody] COMCOCreditCustomerAccountDetailsModelInput ObjClass)
        {
            var procedureName = "UspCOMCOCreditCustomerAccountDetails";
            var parameters = new DynamicParameters();


            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();

            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new COMCOCreditCustomerAccountDetailsModelOutput();

            storedProcedureResult.CustomerAccountDetails = (List<CustomerAccountDetails>)await result.ReadAsync<CustomerAccountDetails>();
            storedProcedureResult.TransactionDetails = (List<TransactionDetails>)await result.ReadAsync<TransactionDetails>();

            return storedProcedureResult;
        }


        public async Task<IEnumerable<ResetCreditandCautionLimitRequestModelOutput>> ResetCreditandCautionLimitRequest([FromForm] ResetCreditandCautionLimitRequestModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeInsertChequeDetails");
            dtDBR.Columns.Add("ChequeBDSCRNumber", typeof(string));
            dtDBR.Columns.Add("ChequeBDSCRDate", typeof(string));

            var procedureName = "UspResetCreditandCautionLimitRequest";
            var parameters = new DynamicParameters();

            parameters.Add("NoofCheques", ObjClass.NoofCheques, DbType.Int16, ParameterDirection.Input);

            //foreach (TypeInsertChequeDetails ObjComco in ObjClass.TypeInsertChequeDetails)
            //{
            if (ObjClass.NoofCheques > 0)
            {
                // var FileName = ObjClass.ChequeBDSCRDate.ToList().Count;
                DataTable dtR = new DataTable();

                for (int i = 0; i < ObjClass.ChequeBDSCRNumber.Count && i < ObjClass.ChequeBDSCRDate.Count; i++)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["ChequeBDSCRNumber"] = ObjClass.ChequeBDSCRNumber[i];
                    dr["ChequeBDSCRDate"] = ObjClass.ChequeBDSCRDate[i];
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }
           

            //}
            string FileNamePathScannedReferenceDocument = string.Empty;
            var ImageFileNameScannedReferenceDocument = ObjClass.ScannedReferenceDocument;
            if (ImageFileNameScannedReferenceDocument.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".doc", ".pdf", ".docx" };
                var ext = ImageFileNameScannedReferenceDocument.FileName.Substring(ImageFileNameScannedReferenceDocument.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathScannedReferenceDocument = "/COMCOImage/" + ObjClass.CustomerID + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.ScannedReferenceDocument + "_" + ImageFileNameScannedReferenceDocument.FileName;
                    string filePathScannedReferenceDocument = contentRootPath + FileNamePathScannedReferenceDocument;
                    var fileStream = new FileStream(filePathScannedReferenceDocument, FileMode.Create);
                    ImageFileNameScannedReferenceDocument.CopyTo(fileStream);
                }
            }
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("LimitSetMode", ObjClass.LimitSetMode, DbType.Int32, ParameterDirection.Input);

            parameters.Add("Amount", ObjClass.Amount, DbType.Double, ParameterDirection.Input);
            parameters.Add("CautionAmount", ObjClass.CautionAmount, DbType.Double, ParameterDirection.Input);
            parameters.Add("FinanceCharges", ObjClass.FinanceCharges, DbType.Double, ParameterDirection.Input);
            parameters.Add("ServicesCharges", ObjClass.ServicesCharges, DbType.Double, ParameterDirection.Input);

            parameters.Add("ScannedReferenceDocument", FileNamePathScannedReferenceDocument, DbType.String, ParameterDirection.Input);
            parameters.Add("COMCOPackageID", ObjClass.COMCOPackageID, DbType.String, ParameterDirection.Input);
            parameters.Add("InvoiceIntervalId", ObjClass.InvoiceIntervalId, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);

            parameters.Add("TypeInsertChequeDetails", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ResetCreditandCautionLimitRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<IEnumerable<GetPrematureClosureDetailOutput>> GetPrematureClosureDetail([FromBody] GetPrematureClosureDetailInput ObjClass)
        {
            var procedureName = "UspGetPrematureClosureDetail";
            var parameters = new DynamicParameters();

            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetPrematureClosureDetailOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetResetCreditandCautionLimitDetailOutput>> GetResetCreditandCautionLimitDetail([FromBody] GetResetCreditandCautionLimitDetailInput ObjClass)
        {
            var procedureName = "UspGetResetCreditandCautionLimitDetail";
            var parameters = new DynamicParameters();

            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetResetCreditandCautionLimitDetailOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetCreditCustomerCreditRechargeClubbingCategoryModelOutput>> GetCreditCustomerCreditRechargeClubbingCategory([FromBody] GetCreditCustomerCreditRechargeClubbingCategoryModelInput ObjClass)
        {
            var procedureName = "UspGetCreditCustomerCreditRechargeClubbingCategory";

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCreditCustomerCreditRechargeClubbingCategoryModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);


        }
        

        public async Task<IEnumerable<GetCreditCustomerCreditRechargePaymentModeModelOutput>> GetCreditCustomerCreditRechargePaymentMode([FromBody] GetCreditCustomerCreditRechargePaymentModeModelInput ObjClass)
        {
            var procedureName = "UspGetCreditCustomerCreditRechargePaymentMode";

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCreditCustomerCreditRechargePaymentModeModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);


        }

        public async Task<IEnumerable<GetCreditCustomerCreditRechargeDetailsModelOutput>> GetCreditCustomerCreditRechargeDetails([FromBody] GetCreditCustomerCreditRechargeDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetCreditCustomerCreditRechargeDetails";
            var parameters = new DynamicParameters();

            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCreditCustomerCreditRechargeDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<CreditCustomerCreditRechargeModelOutput>> CreditCustomerCreditRecharge([FromBody] CreditCustomerCreditRechargeModelInput ObjClass)
        {
            var procedureName = "UspCreditCustomerCreditRecharge";
            var parameters = new DynamicParameters();

            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("PaymentMode", ObjClass.PaymentMode, DbType.Int16, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.Double, ParameterDirection.Input);
            parameters.Add("ChequeDDBDSReferenceNumber", ObjClass.ChequeDDBDSReferenceNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("ChequeDDBDSReferenceDate", ObjClass.ChequeDDBDSReferenceDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ClubbingCategory", ObjClass.ClubbingCategory, DbType.Int16, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("BankName", ObjClass.BankName, DbType.String, ParameterDirection.Input);
            parameters.Add("BranchName", ObjClass.BranchName, DbType.String, ParameterDirection.Input);
            parameters.Add("RealizationDate", ObjClass.RealizationDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("DepositBank", ObjClass.DepositBank, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CreditCustomerCreditRechargeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<ViewCustomerCreditRechargeModelOutput> ViewCustomerCreditRecharge([FromBody] ViewCustomerCreditRechargeModelInput ObjClass)
        {
            var procedureName = "UspViewCustomerCreditRecharge";
            var parameters = new DynamicParameters();

            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();

            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new ViewCustomerCreditRechargeModelOutput();

            storedProcedureResult.CreditMerchantDetails = (List<CreditMerchantDetails>)await result.ReadAsync<CreditMerchantDetails>();
            storedProcedureResult.CustomerCreditRecharge = (List<CustomerCreditRecharge>)await result.ReadAsync<CustomerCreditRecharge>();

            return storedProcedureResult;
        }

        public async Task<IEnumerable<COMCOManagerCreditOperationRoleRequestModelOutput>> COMCOManagerCreditOperationRoleRequest([FromBody] COMCOManagerCreditOperationRoleRequestModelInput ObjClass)
        {
            var procedureName = "UspCOMCOManagerCreditOperationRoleRequest";
            var parameters = new DynamicParameters();

            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("Remarks", ObjClass.Remarks, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<COMCOManagerCreditOperationRoleRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetCOMCOManagerCreditOperationRoleRequestDetailsModelOutput>> GetCOMCOManagerCreditOperationRoleRequestDetails([FromBody] GetCOMCOManagerCreditOperationRoleRequestDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetCOMCOManagerCreditOperationRoleRequestDetails";
            var parameters = new DynamicParameters();
           
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCOMCOManagerCreditOperationRoleRequestDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<ApproveRejectCOMCOManagerCreditOperationRoleRequestModelOutput>> ApproveRejectCOMCOManagerCreditOperationRoleRequest([FromBody] ApproveRejectCOMCOManagerCreditOperationRoleRequestModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeCOMCOManagerCreditOperationRoleRequest");
            dtDBR.Columns.Add("MerchantID", typeof(string));
            dtDBR.Columns.Add("Remarks", typeof(string));

            var procedureName = "UspApproveRejectCOMCOManagerCreditOperationRoleRequest";
            var parameters = new DynamicParameters();


            foreach (TypeCOMCOManagerCreditOperationRoleRequest ObjComco in ObjClass.TypeCOMCOManagerCreditOperationRoleRequest)
            {

                   
                    DataRow dr = dtDBR.NewRow();
                    dr["MerchantID"] = ObjComco.MerchantID;
                    dr["Remarks"] = ObjComco.Remarks;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
               
            }
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);

            parameters.Add("TypeCOMCOManagerCreditOperationRoleRequest", dtDBR, DbType.Object, ParameterDirection.Input);
           
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ApproveRejectCOMCOManagerCreditOperationRoleRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<IEnumerable<UpdateCautionLimitModelOutput>> UpdateCautionLimit([FromBody] UpdateCautionLimitModelInput ObjClass)
        {
            var procedureName = "UspUpdateCautionLimit";
            var parameters = new DynamicParameters();

            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CautionLimit", ObjClass.CautionLimit, DbType.Double, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCautionLimitModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<PrematureClosureRequestModelOutput>> PrematureClosureRequest([FromBody] PrematureClosureRequestModelInput ObjClass)
        {
            var procedureName = "UspPrematureClosureRequest";
            var parameters = new DynamicParameters();

            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.Double, ParameterDirection.Input);
            parameters.Add("CautionAmount", ObjClass.CautionAmount, DbType.Double, ParameterDirection.Input);
            parameters.Add("Remarks", ObjClass.Remarks, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<PrematureClosureRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<ViewSetLimitCustomersModelOutput>> ViewSetLimitCustomers([FromBody] ViewSetLimitCustomersModelInput ObjClass)
        {
            var procedureName = "UspViewSetLimitCustomers";
            var parameters = new DynamicParameters();
           
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ViewSetLimitCustomersModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCreditCustomersWebReportModelOutput>> GetCreditCustomersWebReport([FromBody] GetCreditCustomersWebReportModelInput ObjClass)
        {
            var procedureName = "UspGetCreditCustomersWebReport";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCreditCustomersWebReportModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCOMCOCustomerCardNoVehicleDetailsModelOutput>> GetCOMCOCustomerCardNoVehicleDetails([FromBody] GetCOMCOCustomerCardNoVehicleDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetCOMCOCustomerCardNoVehicleDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCOMCOCustomerCardNoVehicleDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }

        public async Task<ViewCOMCOCustomerStatementModelOutput> ViewCOMCOCustomerStatement([FromBody] ViewCOMCOCustomerStatementModelInput ObjClass)
        {
            var procedureName = "UspViewCOMCOCustomerStatement";
            var parameters = new DynamicParameters();

            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleNo", ObjClass.VehicleNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new ViewCOMCOCustomerStatementModelOutput();

            storedProcedureResult.CreditMerchantCustomerDetails = (List<CreditMerchantCustomerDetails>)await result.ReadAsync<CreditMerchantCustomerDetails>();
            storedProcedureResult.TransactionStatement = (List<TransactionStatement>)await result.ReadAsync<TransactionStatement>();

            return storedProcedureResult;
        }

        public async Task<IEnumerable<GetAuthorizeCOMCOCreditOperationRoleRequestsDetailsModelOutput>> GetAuthorizeCOMCOCreditOperationRoleRequestsDetails([FromBody] GetAuthorizeCOMCOCreditOperationRoleRequestsDetailsModelInput ObjClass)
        {
            var procedureName = "USPGetAuthorizeCOMCOCreditOperationRoleRequestsDetails";
            var parameters = new DynamicParameters();

            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAuthorizeCOMCOCreditOperationRoleRequestsDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AuthorizeCOMCOCreditOperationRoleRequestsModelOutput>> AuthorizeCOMCOCreditOperationRoleRequests([FromBody] AuthorizeCOMCOCreditOperationRoleRequestsModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeAuthorizeCOMCO");
            dtDBR.Columns.Add("MerchantID", typeof(string));
            dtDBR.Columns.Add("Remarks", typeof(string));
            var procedureName = "UspAuthorizeCOMCOCreditOperationRoleRequests";
            var parameters = new DynamicParameters();


            foreach (TypeAuthorizeCOMCO ObjComco in ObjClass.TypeAuthorizeCOMCO)
            {

                DataRow dr = dtDBR.NewRow();
                dr["MerchantID"] = ObjComco.MerchantID;
                dr["Remarks"] = ObjComco.Remarks;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();

            }
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);

            parameters.Add("TypeAuthorizeCOMCO", dtDBR, DbType.Object, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AuthorizeCOMCOCreditOperationRoleRequestsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InsertCOMCOMerchantShiftMasterModelOutput>> InsertCOMCOMerchantShiftMaster([FromBody] InsertCOMCOMerchantShiftMasterModelInput ObjClass)
        {

            var dtDBR = new DataTable("ShiftDetailTypes");
            dtDBR.Columns.Add("ShiftName", typeof(string));
            dtDBR.Columns.Add("ShiftStartTime", typeof(string));
            dtDBR.Columns.Add("ShiftEndTime", typeof(string));
            dtDBR.Columns.Add("ShiftHours", typeof(Int32));
            var procedureName = "UspInsertCOMCOMerchantShiftMaster";
            var parameters = new DynamicParameters();


            foreach (COMCOShiftDetailTypes ObjComco in ObjClass.ShiftDetailTypes)
            {

                DataRow dr = dtDBR.NewRow();
                dr["ShiftName"] = ObjComco.ShiftName;
                dr["ShiftStartTime"] = ObjComco.ShiftStartTime;
                dr["ShiftEndTime"] = ObjComco.ShiftEndTime;
                dr["ShiftHours"] = ObjComco.ShiftHours;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();

            }
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("NoOfShifts", ObjClass.NoOfShifts, DbType.Int16, ParameterDirection.Input);
            parameters.Add("StartTime", ObjClass.StartTime, DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOutletName", ObjClass.RetailOutletName, DbType.String, ParameterDirection.Input);
            parameters.Add("EffectiveDate", ObjClass.EffectiveDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ClosingDate", ObjClass.ClosingDate, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);

            parameters.Add("ShiftDetailTypes", dtDBR, DbType.Object, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertCOMCOMerchantShiftMasterModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<IEnumerable<GetCOMCOMerchantDetailsModelOutput>> GetCOMCOMerchantDetails([FromBody] GetCOMCOMerchantDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetCOMCOMerchantDetails";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCOMCOMerchantDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCOMCOMerchantShiftMasterModelOutput>> GetCOMCOMerchantShiftMaster([FromBody] GetCOMCOMerchantShiftMasterModelInput ObjClass)
        {
            var procedureName = "UspGetCOMCOMerchantShiftMaster";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCOMCOMerchantShiftMasterModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

    }

}
