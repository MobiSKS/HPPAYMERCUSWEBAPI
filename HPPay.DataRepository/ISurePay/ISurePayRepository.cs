using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.ISurePay;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HPPay.DataRepository.ISurePay
{

    public class ISurePayRepository : IISurePayRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ISurePayRepository(DapperContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<IEnumerable<ISuarePayValidationOutput>> ISUrePayRechargeDetailValidation([FromForm] ISuarePayValidationInput ObjClass)
        {

            string FileNamePathTransactionDetailFile = string.Empty;
            var TextFileNameTransactionDetailFile = ObjClass.TransactionDetailFile;
            List<ISuarePayValidationOutput> isurepaydatavalidationoutputlist = new List<ISuarePayValidationOutput>();
            var procName = "UspISurePayFileValidation";
            var validateParameters = new DynamicParameters();
            validateParameters.Add("FileName", TextFileNameTransactionDetailFile.FileName, DbType.String, ParameterDirection.Input);

            using var conValidate = _context.CreateConnection();
            var isurepayfilevalidationoutput = await conValidate.QueryAsync<ISuarePayValidationOutput>(procName, validateParameters, commandType: CommandType.StoredProcedure);

            var mdlValidate = isurepayfilevalidationoutput.FirstOrDefault();

            if (mdlValidate.Status == 1)
            {
                if (TextFileNameTransactionDetailFile.Length > 0)
                {
                    IList<string> AllowedFileExtensions = new List<string> { ".txt" };
                    var ext = TextFileNameTransactionDetailFile.FileName.Substring(TextFileNameTransactionDetailFile.FileName.LastIndexOf('.'));
                    var extension = ext.ToLower();
                    if (AllowedFileExtensions.Contains(extension))
                    {

                        string contentRootPath = _hostingEnvironment.ContentRootPath;
                        FileNamePathTransactionDetailFile = "/ISurePayRechargeFile/" + TextFileNameTransactionDetailFile.FileName;
                        string filePathTransactionDetailFile = contentRootPath + FileNamePathTransactionDetailFile;
                        if (!File.Exists(filePathTransactionDetailFile))
                        {
                            var fileStream = new FileStream(filePathTransactionDetailFile, FileMode.Create);
                            TextFileNameTransactionDetailFile.CopyTo(fileStream);
                            fileStream.Dispose();

                            var lines = File.ReadLines(filePathTransactionDetailFile);
                            foreach (var line in lines)
                            {
                                var values = line.Split('|');


                                var procedureName = "UspISurePayRechargeValidation";
                                var parameters = new DynamicParameters();
                                parameters.Add("ControlCardNo", values[0], DbType.String, ParameterDirection.Input);
                                parameters.Add("Amount", values[2], DbType.String, ParameterDirection.Input);
                                parameters.Add("ISureId", values[6], DbType.String, ParameterDirection.Input);

                                using var connection = _context.CreateConnection();
                                var isurepaydatavalidationoutput = await connection.QueryAsync<ISuarePayValidationOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                                ISuarePayValidationOutput mdl = new ISuarePayValidationOutput();
                                mdl = isurepaydatavalidationoutput.FirstOrDefault();
                                isurepaydatavalidationoutputlist.Add(mdl);


                            }
                        }
                        else
                        {
                            ISuarePayValidationOutput existfiledat = new ISuarePayValidationOutput();
                            existfiledat.Reason = "File already exist";
                            existfiledat.Status = 10;
                            isurepaydatavalidationoutputlist.Add(existfiledat);
                        }
                        var errorCount = isurepaydatavalidationoutputlist.Count(n => n.Status == 0);
                        if (errorCount > 0)
                        {
                            File.Delete(filePathTransactionDetailFile);
                        }
                    }
                }
            }        
            else
            {
                isurepaydatavalidationoutputlist.Add(mdlValidate);
            }
            return isurepaydatavalidationoutputlist.AsEnumerable();
        }
        
        public async Task<IEnumerable<ISuarePayRequestOutput>> ISUrePayRechargeDataInsert([FromForm] ISuarePayRequestInput ObjClass)
        {
            string FileNamePathTransactionDetailFile = string.Empty;
            var TextFileNameTransactionDetailFile = ObjClass.TransactionDetailFile;
            List<ISuarePayRequestOutput> isurepayrechargedataoutputlist = new List<ISuarePayRequestOutput>();
            var procName = "UspEFTFileValidation";
            var validateParameters = new DynamicParameters();
            validateParameters.Add("FileName", TextFileNameTransactionDetailFile.FileName, DbType.String, ParameterDirection.Input);

            using var conValidate = _context.CreateConnection();
            var isurefilevalidationoutput = await conValidate.QueryAsync<ISuarePayRequestOutput>(procName, validateParameters, commandType: CommandType.StoredProcedure);

            var mdlValidate = isurefilevalidationoutput.FirstOrDefault();
            if (mdlValidate.Status == 1)
            {
                if (TextFileNameTransactionDetailFile.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".txt" };
                var ext = TextFileNameTransactionDetailFile.FileName.Substring(TextFileNameTransactionDetailFile.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathTransactionDetailFile = "/ISurePayRechargeFile/" + TextFileNameTransactionDetailFile.FileName;
                    string filePathTransactionDetailFile = contentRootPath + FileNamePathTransactionDetailFile;

                    var lines = File.ReadLines(filePathTransactionDetailFile);
                    foreach (var line in lines)
                    {
                        var values = line.Split('|');                       


                        var procedureName = "UspISurePayRechargeDetailsEntry";
                        var parameters = new DynamicParameters();
                        parameters.Add("ControlCardNumber", values[0], DbType.String, ParameterDirection.Input);
                        parameters.Add("ValidateNo", values[1], DbType.String, ParameterDirection.Input);
                        parameters.Add("Amount", values[2], DbType.String, ParameterDirection.Input);
                        parameters.Add("TransactionDate", values[3], DbType.String, ParameterDirection.Input);
                        parameters.Add("TransactionId", values[4], DbType.String, ParameterDirection.Input);
                        parameters.Add("PayMode", values[5], DbType.String, ParameterDirection.Input);
                        parameters.Add("ISureId", values[6], DbType.String, ParameterDirection.Input);
                        parameters.Add("MICRCode", values[7], DbType.String, ParameterDirection.Input);
                        parameters.Add("BankName", values[8], DbType.String, ParameterDirection.Input);
                        parameters.Add("BranchName", values[9], DbType.String, ParameterDirection.Input);
                        parameters.Add("InstrumentNumber", values[10], DbType.String, ParameterDirection.Input);
                        parameters.Add("FileName", TextFileNameTransactionDetailFile.FileName, DbType.String, ParameterDirection.Input);
                        parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                        parameters.Add("Type", "Recharge", DbType.String, ParameterDirection.Input);
                        parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                        parameters.Add("BatchCode", TextFileNameTransactionDetailFile.FileName.Substring(0, TextFileNameTransactionDetailFile.FileName.Length - extension.Length), DbType.String, ParameterDirection.Input);

                        using var connection = _context.CreateConnection();
                        dynamic eftrechargedataoutput = await connection.QueryAsync<ISuarePayRequestOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


                        // EFTRechargeDataOutput mdlOutput = new EFTRechargeDataOutput();
                        //mdlOutput = eftrechargedataoutput;
                        isurepayrechargedataoutputlist.Add(eftrechargedataoutput[0]);



                    }
                }
            }
            }
            else
            {
                isurepayrechargedataoutputlist.Add(mdlValidate);
            }
            return isurepayrechargedataoutputlist.AsEnumerable();
        }
        
        public async Task<IEnumerable<ISurePayPendingApprovalSearchOutput>> ISurePayRechargePendingForApprovalSearch([FromForm] ISurePayPendingApprovalSearchInput ObjClass)
        {
            var procedureName = "UspISurePayRechargePendingForApproval";
            var parameters = new DynamicParameters();
            parameters.Add("ControlCardNo", ObjClass.ControlCardNo, DbType.Int64, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("BatchCode", ObjClass.BatchCode, DbType.String, ParameterDirection.Input);
            parameters.Add("ISureId", ObjClass.ISureId, DbType.String, ParameterDirection.Input);
            parameters.Add("Type", "Recharge", DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var isurepayrechargedataoutput = await connection.QueryAsync<ISurePayPendingApprovalSearchOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            
            return isurepayrechargedataoutput;
        }

        public async Task<IEnumerable<ISurePayRechargeApprovalOutput>> ISurePayRechargeRequestApproval([FromBody] ISurePayRechargeApprovalInput ObjClass)
        {
            List<ISurePayRechargeApprovalOutput> isurepayrechargeapprovaloutputlist = new List<ISurePayRechargeApprovalOutput>();
            for (int i = 0; i < ObjClass.iSurePayApprovallst.Count; i++)
            {
                var procedureName = "UspISurePayRechargeCCMSAccount";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", ObjClass.iSurePayApprovallst[i].CustomerId, DbType.String, ParameterDirection.Input);
                parameters.Add("ControlCardNo", ObjClass.iSurePayApprovallst[i].ControlCardNo, DbType.String, ParameterDirection.Input);
                parameters.Add("ISureId", ObjClass.iSurePayApprovallst[i].ISureId, DbType.String, ParameterDirection.Input);
                parameters.Add("ValidateNo", ObjClass.iSurePayApprovallst[i].ValidateNo, DbType.String, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Type", "Recharge", DbType.String, ParameterDirection.Input);
                parameters.Add("ReferenceNo", ObjClass.iSurePayApprovallst[i].ReferenceNo, DbType.String, ParameterDirection.Input);

                using var connection = _context.CreateConnection();
                var isurepayrechargedataoutput = await connection.QueryAsync<ISurePayRechargeApprovalOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                var mdl = isurepayrechargedataoutput.FirstOrDefault();
                isurepayrechargeapprovaloutputlist.Add(mdl);



            }
            return isurepayrechargeapprovaloutputlist.AsEnumerable();

        }

        public async Task<IEnumerable<ISurePayRechargeRejectionOutput>> ISurePayRechargeDetailsRejection([FromBody] ISurePayRechargeRejectionInput ObjClass)
        {
            List<ISurePayRechargeRejectionOutput> isurepayrechargerejectlist = new List<ISurePayRechargeRejectionOutput>();
            for (int i = 0; i < ObjClass.iSurePayRejectlst.Count; i++)
            {
                var procedureName = "UspISurePayRechargeDetailsRejection";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", ObjClass.iSurePayRejectlst[i].CustomerId, DbType.String, ParameterDirection.Input);
                parameters.Add("ControlCardNo", ObjClass.iSurePayRejectlst[i].ControlCardNo, DbType.String, ParameterDirection.Input);
                parameters.Add("ISureId", ObjClass.iSurePayRejectlst[i].ISureId, DbType.String, ParameterDirection.Input);
                parameters.Add("ValidateNo", ObjClass.iSurePayRejectlst[i].ValidateNo, DbType.String, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Type", "Recharge", DbType.String, ParameterDirection.Input);
                parameters.Add("ReferenceNo", ObjClass.iSurePayRejectlst[i].ReferenceNo, DbType.String, ParameterDirection.Input);


                using var connection = _context.CreateConnection();

                var  isurepayrechargerehectoutput = await connection.QueryAsync<ISurePayRechargeRejectionOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                
                var mdl = isurepayrechargerehectoutput.FirstOrDefault();
                isurepayrechargerejectlist.Add(mdl);

            }
            return isurepayrechargerejectlist.AsEnumerable();

        }

        public async Task<IEnumerable<ISurePayRechargeReversalSearchOutput>> ISurePayRechargeReversalSearch([FromForm] ISurePayRechargeReversalSearchInput ObjClass)
        {
            var procedureName = "UspISUrePayRechargeReversalSearch";
            var parameters = new DynamicParameters();
            //parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNo", ObjClass.ControlCardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.String, ParameterDirection.Input);
            parameters.Add("ISUreId", ObjClass.ISureId, DbType.String, ParameterDirection.Input);
            
            using var connection = _context.CreateConnection();

            var isurepayrreversalataoutput = await connection.QueryAsync<ISurePayRechargeReversalSearchOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            return isurepayrreversalataoutput;

        }

        public async Task<IEnumerable<ISurePayRechargeReversalRequestOutput>> ISurePayRechargeReversalRequest([FromForm] ISurePayRechargeReversalRequestInput ObjClass)
        {
            List<ISurePayRechargeReversalRequestOutput> isurepayreversalentrylist = new List<ISurePayRechargeReversalRequestOutput>();
            for (int i = 0; i < ObjClass.ISurePayReversalLst.Count; i++)
            {
                var procedureName = "UspISurePayRechargeReversalEntry";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", ObjClass.ISurePayReversalLst[i].CustomerId, DbType.String, ParameterDirection.Input);
                parameters.Add("ControlCardNo", ObjClass.ISurePayReversalLst[i].ControlCardNo, DbType.String, ParameterDirection.Input);
                parameters.Add("ValidateNo", ObjClass.ISurePayReversalLst[i].ValidateNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Amount", ObjClass.ISurePayReversalLst[i].Amount, DbType.String, ParameterDirection.Input);
                parameters.Add("TransactionDate", ObjClass.ISurePayReversalLst[i].TransactionDate, DbType.String, ParameterDirection.Input);
                parameters.Add("TransactionId", ObjClass.ISurePayReversalLst[i].TransactionId, DbType.String, ParameterDirection.Input);
                parameters.Add("PayMode", ObjClass.ISurePayReversalLst[i].PayMode, DbType.String, ParameterDirection.Input);
                parameters.Add("ISureId", ObjClass.ISurePayReversalLst[i].ISureId, DbType.String, ParameterDirection.Input);
                parameters.Add("InstrumentNumber", ObjClass.ISurePayReversalLst[i].InstrumentNumber, DbType.String, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("ReferenceNo", ObjClass.ISurePayReversalLst[i].ReferenceNo, DbType.String, ParameterDirection.Input);

                using var connection = _context.CreateConnection();

                var isurepayrechargedataoutput = await connection.QueryAsync<ISurePayRechargeReversalRequestOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                var mdl = isurepayrechargedataoutput.FirstOrDefault();
                isurepayreversalentrylist.Add(mdl);
            }
            return isurepayreversalentrylist.AsEnumerable() ;

        }

        public async Task<IEnumerable<ISurePayReversalPendingApprovalSearchOutput>> ISurePayReversalPendingApprovalSearch([FromForm] ISurePayReversalPendingApprovalSearchInput ObjClass)
        {
            var procedureName = "UspISurePayRechargePendingForApproval";
            var parameters = new DynamicParameters();
            parameters.Add("ControlCardNo", ObjClass.ControlCardNo, DbType.Int64, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("BatchCode", ObjClass.BatchCode, DbType.String, ParameterDirection.Input);
            parameters.Add("ISureId", ObjClass.ISureId, DbType.String, ParameterDirection.Input);
            parameters.Add("Type", "Reversal", DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var isurepayrechargedataoutput = await connection.QueryAsync<ISurePayReversalPendingApprovalSearchOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            return isurepayrechargedataoutput;
        }

        public async Task<IEnumerable<ISurePayRechargeReversalApprovalOutput>> ISurePayRechargeReversalApproval([FromBody] ISurePayRechargeReversalApprovalInput ObjClass)
        {
            List<ISurePayRechargeReversalApprovalOutput> isurepayreversalapprovaloutputlist = new List<ISurePayRechargeReversalApprovalOutput>();
            for (int i = 0; i < ObjClass.iSurePayReversalApprovallst.Count; i++)
            {
                var procedureName = "UspISurePayRechargeCCMSAccount";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", ObjClass.iSurePayReversalApprovallst[i].CustomerId, DbType.String, ParameterDirection.Input);
                parameters.Add("ControlCardNo", ObjClass.iSurePayReversalApprovallst[i].ControlCardNo, DbType.String, ParameterDirection.Input);
                parameters.Add("ISureId", ObjClass.iSurePayReversalApprovallst[i].ISureId, DbType.String, ParameterDirection.Input);
                parameters.Add("ValidateNo", ObjClass.iSurePayReversalApprovallst[i].ValidateNo, DbType.String, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Type", "Reversal", DbType.String, ParameterDirection.Input);
                parameters.Add("ReferenceNo", ObjClass.iSurePayReversalApprovallst[i].ReferenceNo, DbType.String, ParameterDirection.Input);

                using var connection = _context.CreateConnection();
                var isurepayrechargedataoutput = await connection.QueryAsync<ISurePayRechargeReversalApprovalOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                var mdl = isurepayrechargedataoutput.FirstOrDefault();
                isurepayreversalapprovaloutputlist.Add(mdl);



            }
            return isurepayreversalapprovaloutputlist.AsEnumerable();

        }

        public async Task<IEnumerable<ISurePayReversalRejectionOutput>> ISurePayReversalRejection([FromBody] ISurePayReversalRejectionInput ObjClass)
        {
            List<ISurePayReversalRejectionOutput> eftrechargedatavalidationoutputlist = new List<ISurePayReversalRejectionOutput>();
            for (int i = 0; i < ObjClass.iSurePayReversalRejectlst.Count; i++)
            {
                var procedureName = "UspISurePayRechargeDetailsRejection";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", ObjClass.iSurePayReversalRejectlst[i].CustomerId, DbType.String, ParameterDirection.Input);
                parameters.Add("ControlCardNo", ObjClass.iSurePayReversalRejectlst[i].ControlCardNo, DbType.String, ParameterDirection.Input);
                parameters.Add("ISureId", ObjClass.iSurePayReversalRejectlst[i].ISureId, DbType.String, ParameterDirection.Input);
                parameters.Add("ValidateNo", ObjClass.iSurePayReversalRejectlst[i].ValidateNo, DbType.String, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Type", "Reversal", DbType.String, ParameterDirection.Input);
                parameters.Add("ReferenceNo", ObjClass.iSurePayReversalRejectlst[i].ReferenceNo, DbType.String, ParameterDirection.Input);

                using var connection = _context.CreateConnection();
                var eftrechargedataoutput = await connection.QueryAsync<ISurePayReversalRejectionOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                var mdl = eftrechargedataoutput.FirstOrDefault();
                eftrechargedatavalidationoutputlist.Add(mdl);

            }
            return eftrechargedatavalidationoutputlist.AsEnumerable();

        }

        public async Task<IEnumerable<ISurePayViewRequestOutput>> ViewISurePayRequest([FromForm] ISurePayViewRequestInput ObjClass)
        {
            var procedureName = "UspViewISurePayRequest";
            var parameters = new DynamicParameters();
            parameters.Add("ControlCardNo", ObjClass.ControlCardNo, DbType.Int64, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.String, ParameterDirection.Input);
            parameters.Add("ISureId", ObjClass.ISureId, DbType.String, ParameterDirection.Input);
            parameters.Add("Type", ObjClass.Type, DbType.String, ParameterDirection.Input);


            using var connection = _context.CreateConnection();

            var eftrechargedataoutput = await connection.QueryAsync<ISurePayViewRequestOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            return eftrechargedataoutput;

        }
    }

}
