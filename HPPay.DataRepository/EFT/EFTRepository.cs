using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.EFT;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HPPay.DataRepository.EFT
{
    public class EFTRepository : IEFTRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public EFTRepository(DapperContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IEnumerable<EFTRechargeFileNameOutput>> EFTRechargeFileName([FromBody] EFTRechargeFileNameInput ObjClass)
        {
            var procedureName = "UspEFTRechargeFileName";
            var parameters = new DynamicParameters();


            using var connection = _context.CreateConnection();
            var eftrechargedataoutput = await connection.QueryAsync<EFTRechargeFileNameOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            return eftrechargedataoutput;
        }
        public async Task<IEnumerable<EFTRechargeDataOutput>> InsertEFTRechargeDetails([FromForm] EFTRechargeDataInsert ObjClass)
        {
            string FileNamePathTransactionDetailFile = string.Empty;
            var TextFileNameTransactionDetailFile = ObjClass.TransactionDetailFile;
            List<EFTRechargeDataOutput> eftrechargedataoutputlist = new List<EFTRechargeDataOutput>();
            var procName = "UspEFTFileValidation";
            var validateParameters = new DynamicParameters();
            validateParameters.Add("FileName", TextFileNameTransactionDetailFile.FileName, DbType.String, ParameterDirection.Input);

            using var conValidate = _context.CreateConnection();
            var eftfilevalidationoutput = await conValidate.QueryAsync<EFTRechargeDataOutput>(procName, validateParameters, commandType: CommandType.StoredProcedure);

            var mdlValidate = eftfilevalidationoutput.FirstOrDefault();
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
                        FileNamePathTransactionDetailFile = "/EFTRechargeFile/" + TextFileNameTransactionDetailFile.FileName;
                        string filePathTransactionDetailFile = contentRootPath + FileNamePathTransactionDetailFile;
                        var fileStream = new FileStream(filePathTransactionDetailFile, FileMode.Create);
                        TextFileNameTransactionDetailFile.CopyTo(fileStream);
                        fileStream.Dispose();
                        var lines = File.ReadLines(filePathTransactionDetailFile);
                        foreach (var line in lines)
                        {
                            var values = line.Split('|');
                            if (values.Length == 10)
                            {
                                EFTRechargeModel eftrechargemodel = new EFTRechargeModel();
                                eftrechargemodel.ControlCardNumber = Convert.ToInt64(values[0]);
                                var payDate = getdateInsert(values[1]);
                                eftrechargemodel.PaymentDate = payDate;//Convert.ToDateTime(values[1]).ToShortDateString();
                                eftrechargemodel.UTRNumber = values[2];
                                eftrechargemodel.Amount = values[3];
                                eftrechargemodel.IFSCCode = values[4];
                                eftrechargemodel.BankName = values[5];
                                eftrechargemodel.TransRefNumber = values[6];
                                eftrechargemodel.SenderName = values[7];
                                eftrechargemodel.ProductCode = values[8];
                                eftrechargemodel.SenderAccount = values[9];


                                var procedureName = "UspEFTRechargeDetailsEntry";
                                var parameters = new DynamicParameters();
                                parameters.Add("ControlCardNumber", eftrechargemodel.ControlCardNumber, DbType.String, ParameterDirection.Input);
                                parameters.Add("PaymentDate", eftrechargemodel.PaymentDate, DbType.String, ParameterDirection.Input);
                                parameters.Add("UTRNumber", eftrechargemodel.UTRNumber, DbType.String, ParameterDirection.Input);
                                parameters.Add("Amount", eftrechargemodel.Amount, DbType.String, ParameterDirection.Input);
                                parameters.Add("IFSCCode", eftrechargemodel.IFSCCode, DbType.String, ParameterDirection.Input);
                                parameters.Add("BankName", eftrechargemodel.BankName, DbType.String, ParameterDirection.Input);
                                parameters.Add("TransRefNumber", eftrechargemodel.TransRefNumber, DbType.String, ParameterDirection.Input);
                                parameters.Add("SenderName", eftrechargemodel.SenderName, DbType.String, ParameterDirection.Input);
                                parameters.Add("ProductCode", eftrechargemodel.ProductCode, DbType.String, ParameterDirection.Input);
                                parameters.Add("SenderAccount", eftrechargemodel.SenderAccount, DbType.String, ParameterDirection.Input);
                                parameters.Add("FileName", TextFileNameTransactionDetailFile.FileName, DbType.String, ParameterDirection.Input);
                                parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                                parameters.Add("Type", "Recharge", DbType.String, ParameterDirection.Input);
                                parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                                parameters.Add("BatchCode", TextFileNameTransactionDetailFile.FileName.Substring(0, TextFileNameTransactionDetailFile.FileName.Length - extension.Length), DbType.String, ParameterDirection.Input);
                                parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                                parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);

                                using var connection = _context.CreateConnection();
                                dynamic eftrechargedataoutput = await connection.QueryAsync<EFTRechargeDataOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


                                // EFTRechargeDataOutput mdlOutput = new EFTRechargeDataOutput();
                                //mdlOutput = eftrechargedataoutput;
                                eftrechargedataoutputlist.Add(eftrechargedataoutput[0]);

                            }
                            else
                            {
                                EFTRechargeDataOutput eFTRechargeDataOutput = new EFTRechargeDataOutput();
                                eFTRechargeDataOutput.Status = 0;
                                eFTRechargeDataOutput.Reason = "All data not present";
                                eFTRechargeDataOutput.ControlCardNumber = values[0];
                                eftrechargedataoutputlist.Add(eFTRechargeDataOutput);
                            }
                        }
                        var errorCount = eftrechargedataoutputlist.Count(n => n.Status == 1);
                        if (errorCount == 0)
                        {
                            File.Delete(filePathTransactionDetailFile);
                        }
                    }
                }
            }
            else
            {
                eftrechargedataoutputlist.Add(mdlValidate);
            }
            return eftrechargedataoutputlist.AsEnumerable();
        }
        public async Task<EFTRechargeDataValidationDetails> EFTRechargeDetailValidation([FromForm] EFTRechargeDataValidation ObjClass)
        {
            EFTRechargeDataValidationDetails eFTRechargeDataValidationDetails = new EFTRechargeDataValidationDetails();
            try
            {
                string FileNamePathTransactionDetailFile = string.Empty;
                var TextFileNameTransactionDetailFile = ObjClass.TransactionDetailFile;
                List<EFTRechargeDataValidationOutput> eftrechargedatavalidationoutputlist = new List<EFTRechargeDataValidationOutput>();
                var procName = "UspEFTFileValidation";
                var validateParameters = new DynamicParameters();
                validateParameters.Add("FileName", TextFileNameTransactionDetailFile.FileName, DbType.String, ParameterDirection.Input);

                using var conValidate = _context.CreateConnection();
                var eftfilevalidationoutput = await conValidate.QueryAsync<EFTRechargeDataValidationOutput>(procName, validateParameters, commandType: CommandType.StoredProcedure);

                var mdlValidate = eftfilevalidationoutput.FirstOrDefault();
                int totalRecords = 0;
                int validRecords = 0;
                int invalidRecords = 0;
                double validAmount = 0;
                double invalidAmount = 0;
                string invalidRecordRowNo = "";
                int invalidRow = 0;
                if (mdlValidate.Status == 1)
                {
                    if (TextFileNameTransactionDetailFile.Length > 0)
                    {
                        IList<string> AllowedFileExtensions = new List<string> { ".txt" };
                        var ext = TextFileNameTransactionDetailFile.FileName.Substring(TextFileNameTransactionDetailFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (AllowedFileExtensions.Contains(extension))
                        {
                            eFTRechargeDataValidationDetails.Status = 1;
                            eFTRechargeDataValidationDetails.Reason = "Success";
                            string contentRootPath = _hostingEnvironment.ContentRootPath;
                            FileNamePathTransactionDetailFile = "/EFTRechargeFile/" + TextFileNameTransactionDetailFile.FileName;
                            string filePathTransactionDetailFile = contentRootPath + FileNamePathTransactionDetailFile;

                            var fileStream = new FileStream(filePathTransactionDetailFile, FileMode.Create);
                            TextFileNameTransactionDetailFile.CopyTo(fileStream);
                            fileStream.Dispose();

                            var lines = File.ReadLines(filePathTransactionDetailFile);

                            foreach (var line in lines)
                            {
                                totalRecords = totalRecords + 1;
                                var values = line.Split('|');
                                invalidRow = invalidRow + 1;
                                if (values.Length == 10)
                                {
                                    var procedureName = "UspEFTRechargeValidation";
                                    var parameters = new DynamicParameters();
                                    parameters.Add("ControlCardNo", values[0], DbType.String, ParameterDirection.Input);
                                    parameters.Add("Amount", values[3], DbType.String, ParameterDirection.Input);
                                    parameters.Add("FileName", TextFileNameTransactionDetailFile.FileName, DbType.String, ParameterDirection.Input);
                                    parameters.Add("TransRefNumber", values[6], DbType.String, ParameterDirection.Input);
                                    parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                                    parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                                    parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                                    parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                                    parameters.Add("Amount", values[3], DbType.String, ParameterDirection.Input);
                                    parameters.Add("UTRNumber", values[2], DbType.String, ParameterDirection.Input);
                                    using var connection = _context.CreateConnection();
                                    var eftrechargedatavalidationoutput = await connection.QueryAsync<EFTRechargeDataValidationOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                                    //EFTRechargeDataValidationOutput mdl = new EFTRechargeDataValidationOutput();
                                    var mdl = eftrechargedatavalidationoutput.FirstOrDefault();
                                    var payDate = getdateShow(values[1]);
                                    mdl.PaymentDate = payDate;//Convert.ToDateTime(values[1]).ToShortDateString();
                                    mdl.UTRNumber = values[2];
                                    mdl.Amount = values[3];
                                    mdl.IFSCCode = values[4];
                                    mdl.BankName = values[5];
                                    mdl.TransRefNumber = values[6];
                                    mdl.SenderName = values[7];
                                    mdl.ProductCode = values[8];
                                    mdl.SenderAccount = values[9];
                                    eftrechargedatavalidationoutputlist.Add(mdl);
                                   
                                    if (mdl.Status == 1)
                                    {
                                        validRecords = validRecords + 1;
                                        validAmount = validAmount + Convert.ToDouble(values[3]);
                                    }
                                    if (mdl.Status == 0)
                                    {
                                        invalidRecords = invalidRecords + 1;
                                        invalidAmount = invalidAmount + Convert.ToDouble(values[3]);
                                        invalidRecordRowNo = invalidRecordRowNo + ',' + invalidRow.ToString();
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        invalidRecords = invalidRecords + 1;
                                        invalidAmount = invalidAmount + Convert.ToDouble(values[3]);
                                        invalidRecordRowNo = invalidRecordRowNo + ',' + invalidRow.ToString();
                                    }
                                    catch 
                                    {

                                    }

                                    EFTRechargeDataValidationOutput eFTRechargeDataValidationOutput = new EFTRechargeDataValidationOutput();
                                    eFTRechargeDataValidationOutput.Status = 0;
                                    eFTRechargeDataValidationOutput.Reason = "All data not present";
                                    eFTRechargeDataValidationOutput.ControlCardNumber = values[0];
                                    eftrechargedatavalidationoutputlist.Add(eFTRechargeDataValidationOutput);
                                    
                                }

                            }

                            var errorCount = eftrechargedatavalidationoutputlist.Count(n => n.Status == 0);
                            if (errorCount > 0)
                            {
                                eFTRechargeDataValidationDetails.Status = 0;
                                eFTRechargeDataValidationDetails.Reason = "Invalid Record";
                            }

                            File.Delete(filePathTransactionDetailFile);


                        }
                    }
                }
                else
                {
                    eFTRechargeDataValidationDetails.Status = 0;
                    eFTRechargeDataValidationDetails.Reason = "File already exist";
                    eftrechargedatavalidationoutputlist.Add(mdlValidate);
                }
                if (invalidRecordRowNo != "" && invalidRecordRowNo.Substring(0, 1) == ",")
                {
                    invalidRecordRowNo = invalidRecordRowNo.Substring(1);
                }
                eFTRechargeDataValidationDetails.TotalRecords = totalRecords;
                eFTRechargeDataValidationDetails.ValidRecords = validRecords;
                eFTRechargeDataValidationDetails.InvalidRecords = invalidRecords;
                eFTRechargeDataValidationDetails.ValidRecordsAmount = validAmount;
                eFTRechargeDataValidationDetails.InvalidRecordsAmount = invalidAmount;
                eFTRechargeDataValidationDetails.InvalidRecordsRowNo = invalidRecordRowNo;
                eFTRechargeDataValidationDetails.eFTRechargeDataValidationOutputsLst = eftrechargedatavalidationoutputlist;
            }
            catch (Exception ex)
            {
                eFTRechargeDataValidationDetails.Reason=ex.ToString();
            }
            return eFTRechargeDataValidationDetails;
        }

        public string getdateShow(string strDate)
        {
            string[] RawDate = strDate.Split('/');
            string[] Startdatearr = { RawDate[0], RawDate[1], RawDate[2] };
            string Newtdate = Startdatearr[0] + "-" + Startdatearr[1] + "-" + DateTime.Now.Year.ToString().Substring(0,2)+ Startdatearr[2];
            return Newtdate;
            
        }
        public string getdateInsert(string strDate)
        {
            string[] RawDate = strDate.Split('/');
            string[] Startdatearr = { RawDate[0], RawDate[1], RawDate[2] };
            string Newtdate = DateTime.Now.Year.ToString().Substring(0, 2) + Startdatearr[2] + "-" + Startdatearr[1]  + "-" + Startdatearr[0]   ;
            return Newtdate;

        }
        public async Task<IEnumerable<EFTRechargePendingForApprovalOutput>> EFTRechargeDetailsPendingForApproval([FromBody] EFTRechargePendingForApprovalInput ObjClass)
        {
            var procedureName = "UspEFTRechargePendingForApproval";
            var parameters = new DynamicParameters();
            //parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNo", ObjClass.ControlCardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("BatchCode", ObjClass.BatchCode, DbType.String, ParameterDirection.Input);
            parameters.Add("UTRNumber", ObjClass.UTRNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("TransRefNumber", ObjClass.TransRefNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Type", "Recharge", DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var eftrechargedataoutput = await connection.QueryAsync<EFTRechargePendingForApprovalOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            
            return eftrechargedataoutput;
        }
        public async Task<IEnumerable<EFTRechargeApprovalOutput>> EFTRechargeDetailsApproval([FromBody] EFTRechargeApprovalInput ObjClass)
        {
            //var listFTERechargeApprovalInput = ObjClass.lstinput.ToList();
            List<EFTRechargeApprovalOutput> eftrechargedatavalidationoutputlist = new List<EFTRechargeApprovalOutput>();
            for (int i = 0; i < ObjClass.lstinput.Count; i++)
            {
                var procedureName = "UspEFTRechargeCCMSAccount";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", ObjClass.lstinput[i].CustomerId, DbType.String, ParameterDirection.Input);
                parameters.Add("ControlCardNo", ObjClass.lstinput[i].ControlCardNo, DbType.String, ParameterDirection.Input);
                parameters.Add("TransRefNumber", ObjClass.lstinput[i].TransRefNumber, DbType.String, ParameterDirection.Input);
                parameters.Add("Amount", ObjClass.lstinput[i].Amount, DbType.String, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Type", "Recharge", DbType.String, ParameterDirection.Input);
                parameters.Add("ReferenceNo", ObjClass.lstinput[i].ReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                parameters.Add("Comment", ObjClass.lstinput[i].Comment, DbType.String, ParameterDirection.Input);
                parameters.Add("UTRNumber", ObjClass.lstinput[i].UTRNumber, DbType.String, ParameterDirection.Input);
                using var connection = _context.CreateConnection();
                var eftrechargedataoutput = await connection.QueryAsync<EFTRechargeApprovalOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


                EFTRechargeApprovalOutput mdl = eftrechargedataoutput.FirstOrDefault();
                eftrechargedatavalidationoutputlist.Add(mdl);



            }
            return eftrechargedatavalidationoutputlist.AsEnumerable();

        }
        public async Task<IEnumerable<EFTRechargeRejectionOutput>> EFTRechargeDetailsRejection([FromBody] EFTRechargeRejectionInput ObjClass)
        {
            List<EFTRechargeRejectionOutput> eftrechargedatavalidationoutputlist = new List<EFTRechargeRejectionOutput>();
            for (int i = 0; i < ObjClass.lstRejectioninput.Count; i++)
            {
                var procedureName = "UspEFTRechargeDetailsRejection";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", ObjClass.lstRejectioninput[i].CustomerId, DbType.String, ParameterDirection.Input);
                parameters.Add("ControlCardNo", ObjClass.lstRejectioninput[i].ControlCardNo, DbType.String, ParameterDirection.Input);
                parameters.Add("TransRefNumber", ObjClass.lstRejectioninput[i].TransRefNumber, DbType.String, ParameterDirection.Input);
                parameters.Add("Amount", ObjClass.lstRejectioninput[i].Amount, DbType.String, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Type", "Recharge", DbType.String, ParameterDirection.Input);
                parameters.Add("ReferenceNo", ObjClass.lstRejectioninput[i].ReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                parameters.Add("UTRNumber", ObjClass.lstRejectioninput[i].UTRNumber, DbType.String, ParameterDirection.Input);
                using var connection = _context.CreateConnection();
                var eftrechargedataoutput = await connection.QueryAsync<EFTRechargeRejectionOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                EFTRechargeRejectionOutput mdl = eftrechargedataoutput.FirstOrDefault();
                eftrechargedatavalidationoutputlist.Add(mdl);
            }
            return eftrechargedatavalidationoutputlist.AsEnumerable();

        }
        public async Task<IEnumerable<EFTRechargeReversalSearchOutput>> EFTRechargeReversalSearch([FromBody] EFTRechargeReversalSearchInput ObjClass)
        {
            var procedureName = "UspEFTRechargeReversalSearch";
            var parameters = new DynamicParameters();
            //parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNo", ObjClass.ControlCardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("BatchCode", ObjClass.BatchCode, DbType.String, ParameterDirection.Input);
            parameters.Add("UTRNumber", ObjClass.UTRNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("TransRefNumber", ObjClass.TransRefNumber, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var eftrechargedataoutput = await connection.QueryAsync<EFTRechargeReversalSearchOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            
             return eftrechargedataoutput;

        }
        public async Task<IEnumerable<EFTRechargeReversalRequestOutput>> EFTRechargeReversalRequest([FromBody] EFTRechargeReversalRequestInput ObjClass)
        {

            var dtDBR = new DataTable("TypeEFTRechargeReversalEntry");
            dtDBR.Columns.Add("CustomerId", typeof(string));
            dtDBR.Columns.Add("ControlCardNo", typeof(string));
            dtDBR.Columns.Add("BatchId", typeof(string));
            dtDBR.Columns.Add("UTRNumber", typeof(string));
            dtDBR.Columns.Add("TransRefNumber", typeof(string));
            dtDBR.Columns.Add("Amount", typeof(decimal));
            dtDBR.Columns.Add("ReferenceNo", typeof(string));
            dtDBR.Columns.Add("RechargeReversalComment", typeof(string));
            dtDBR.Columns.Add("TxnDate", typeof(string));

            var procedureName = "UspEFTRechargeReversalEntry";
            var parameters = new DynamicParameters();

            foreach (EFTRechargeReversalRequestDetailInput ObjEFTRechargeReversalRequestDetailInput in ObjClass.ObjEFTRechargeReversalRequestDetailInput)
            {

                DataRow dr = dtDBR.NewRow();
                dr["CustomerId"] = ObjEFTRechargeReversalRequestDetailInput.CustomerId;
                dr["ControlCardNo"] = ObjEFTRechargeReversalRequestDetailInput.ControlCardNo;
                dr["BatchId"] = ObjEFTRechargeReversalRequestDetailInput.BatchId;
                dr["UTRNumber"] = ObjEFTRechargeReversalRequestDetailInput.UTRNumber;
                dr["TransRefNumber"] = ObjEFTRechargeReversalRequestDetailInput.TransRefNumber;
                dr["Amount"] = ObjEFTRechargeReversalRequestDetailInput.Amount;
                dr["ReferenceNo"] = ObjEFTRechargeReversalRequestDetailInput.ReferenceNo;
                dr["RechargeReversalComment"] = ObjEFTRechargeReversalRequestDetailInput.RechargeReversalComment;
                dr["TxnDate"] = ObjEFTRechargeReversalRequestDetailInput.TxnDate;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
           
            }
            parameters.Add("TypeEFTRechargeReversalEntry", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            
            using var connection = _context.CreateConnection();
            var eftrechargedataoutput = await connection.QueryAsync<EFTRechargeReversalRequestOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            return eftrechargedataoutput;

        }

        public async Task<IEnumerable<EFTRechargeReversalPendingForApprovalOutput>> EFTRechargeReversalPendingForApproval([FromBody] EFTRechargeReversalPendingForApprovalInput ObjClass)
        {
            var procedureName = "UspEFTRechargePendingForApproval"; //UspEFTRehargeReversalPendingForApproval
            var parameters = new DynamicParameters();
            //parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNo", ObjClass.ControlCardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("BatchCode", ObjClass.BatchCode, DbType.String, ParameterDirection.Input);
            parameters.Add("UTRNumber", ObjClass.UTRNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("TransRefNumber", ObjClass.TransRefNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Type", "Reversal", DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();

            var eftrechargedataoutput = await connection.QueryAsync<EFTRechargeReversalPendingForApprovalOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            return eftrechargedataoutput;

        }
        public async Task<IEnumerable<EFTRechargeReversalApprovalOutput>> EFTRechargeReversalApproval([FromBody] EFTRechargeReversalApprovalInput ObjClass)
        {
            //var listFTERechargeApprovalInput = ObjClass.ToList();
            List<EFTRechargeReversalApprovalOutput> eftrechargedatavalidationoutputlist = new List<EFTRechargeReversalApprovalOutput>();
            for (int i = 0; i < ObjClass.eFTRechargeReversalApprovalLst.Count; i++)
            {
                var procedureName = "UspEFTRechargeCCMSAccount";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", ObjClass.eFTRechargeReversalApprovalLst[i].CustomerId, DbType.String, ParameterDirection.Input);
                parameters.Add("ControlCardNo", ObjClass.eFTRechargeReversalApprovalLst[i].ControlCardNo, DbType.String, ParameterDirection.Input);
                parameters.Add("TransRefNumber", ObjClass.eFTRechargeReversalApprovalLst[i].TransRefNumber, DbType.String, ParameterDirection.Input);
                parameters.Add("Amount", ObjClass.eFTRechargeReversalApprovalLst[i].Amount, DbType.String, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Type", "Reversal", DbType.String, ParameterDirection.Input);
                parameters.Add("ReferenceNo", ObjClass.eFTRechargeReversalApprovalLst[i].ReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                parameters.Add("Comment", ObjClass.eFTRechargeReversalApprovalLst[i].Comment, DbType.String, ParameterDirection.Input);
                parameters.Add("UTRNumber", ObjClass.eFTRechargeReversalApprovalLst[i].UTRNumber, DbType.String, ParameterDirection.Input);
                using var connection = _context.CreateConnection();

                var eftrechargedataoutput = await connection.QueryAsync<EFTRechargeReversalApprovalOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                var mdl = eftrechargedataoutput.FirstOrDefault();
                eftrechargedatavalidationoutputlist.Add(mdl);

            }
            return eftrechargedatavalidationoutputlist.AsEnumerable();

        }

        public async Task<IEnumerable<EFTReversalRejectionOutput>> EFTReversalRejection([FromBody] EFTReversalRejectionInput ObjClass)
        {
            List<EFTReversalRejectionOutput> eftrechargedatavalidationoutputlist = new List<EFTReversalRejectionOutput>();
            for (int i = 0; i < ObjClass.eFTReversalRejectionInputDatas.Count; i++)
            {
                var procedureName = "UspEFTRechargeDetailsRejection";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", ObjClass.eFTReversalRejectionInputDatas[i].CustomerId, DbType.String, ParameterDirection.Input);
                parameters.Add("ControlCardNo", ObjClass.eFTReversalRejectionInputDatas[i].ControlCardNo, DbType.String, ParameterDirection.Input);
                parameters.Add("TransRefNumber", ObjClass.eFTReversalRejectionInputDatas[i].TransRefNumber, DbType.String, ParameterDirection.Input);
                parameters.Add("Amount", ObjClass.eFTReversalRejectionInputDatas[i].Amount, DbType.String, ParameterDirection.Input);
                parameters.Add("ReferenceNo", ObjClass.eFTReversalRejectionInputDatas[i].ReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Type", "Reversal", DbType.String, ParameterDirection.Input);
                parameters.Add("ReferenceNo", ObjClass.eFTReversalRejectionInputDatas[i].ReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                parameters.Add("Comment", ObjClass.eFTReversalRejectionInputDatas[i].Comment, DbType.String, ParameterDirection.Input);
                parameters.Add("UTRNumber", ObjClass.eFTReversalRejectionInputDatas[i].UTRNumber, DbType.String, ParameterDirection.Input);
                using var connection = _context.CreateConnection();
                var eftrechargedataoutput = await connection.QueryAsync<EFTReversalRejectionOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                var mdl = eftrechargedataoutput.FirstOrDefault();
                eftrechargedatavalidationoutputlist.Add(mdl);

            }
            return eftrechargedatavalidationoutputlist.AsEnumerable();

        }
        public async Task<IEnumerable<ViewEFTRequestOutput>> ViewEFTRequest([FromBody] ViewEFTRequestInput ObjClass)
        {
            var procedureName = "UspViewEFTRequest";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNo", ObjClass.ControlCardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("BatchCode", ObjClass.BatchCode, DbType.String, ParameterDirection.Input);
            parameters.Add("UTRNumber", ObjClass.UTRNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("TransRefNumber", ObjClass.TransRefNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Status", ObjClass.Status, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var eftrechargedataoutput = await connection.QueryAsync<ViewEFTRequestOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            return eftrechargedataoutput;
        }

        public async Task<IEnumerable<ViewEFTReverseDetailOutput>> ViewEFTReverseDetail([FromBody] ViewEFTReverseDetailInput ObjClass)
        {
            var procedureName = "UspViewEFTReverseDetail";
            var parameters = new DynamicParameters();
            parameters.Add("ControlCardNo", ObjClass.ControlCardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("BatchCode", ObjClass.BatchCode, DbType.String, ParameterDirection.Input);
            parameters.Add("UTRNumber", ObjClass.UTRNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("TransRefNumber", ObjClass.TransRefNumber, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var eftrechargedataoutput = await connection.QueryAsync<ViewEFTReverseDetailOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            return eftrechargedataoutput;
        }
    }
}
