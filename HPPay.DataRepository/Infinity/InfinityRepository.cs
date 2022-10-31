using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.Infinity;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HPPay.DataRepository.Infinity
{
    public class InfinityRepository : IInfinityRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public InfinityRepository(DapperContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<IEnumerable<InfinityRechargeValidationOutput>> InfinityRechargeDetailValidation([FromForm] InfinityRechargeValidationInput ObjClass)
        {

            string FileNamePathTransactionDetailFile = string.Empty;
            var TextFileNameTransactionDetailFile = ObjClass.TransactionDetailFile;
            List<InfinityRechargeValidationOutput> infinityrechargedatavalidationoutputlist = new List<InfinityRechargeValidationOutput>();
            var procName = "UspInfinityFileValidation";
            var validateParameters = new DynamicParameters();
            validateParameters.Add("FileName", TextFileNameTransactionDetailFile.FileName, DbType.String, ParameterDirection.Input);            

            using var conValidate = _context.CreateConnection();
            var infinityfilevalidationoutput = await conValidate.QueryAsync<InfinityRechargeValidationOutput>(procName, validateParameters, commandType: CommandType.StoredProcedure);

            var mdlValidate = infinityfilevalidationoutput.FirstOrDefault();
            
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
                    FileNamePathTransactionDetailFile = "/InfinityRechargeFile/" + TextFileNameTransactionDetailFile.FileName;
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


                            var procedureName = "UspInfinityRechargeValidation";
                            var parameters = new DynamicParameters();
                            parameters.Add("ControlCardNo", values[0], DbType.String, ParameterDirection.Input);
                            parameters.Add("Amount", values[3], DbType.String, ParameterDirection.Input);
                            parameters.Add("TransRefNumber", values[6], DbType.String, ParameterDirection.Input);

                            using var connection = _context.CreateConnection();
                            var infinityrechargedatavalidationoutput = await connection.QueryAsync<InfinityRechargeValidationOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                            InfinityRechargeValidationOutput mdl = new InfinityRechargeValidationOutput();
                            mdl = infinityrechargedatavalidationoutput.FirstOrDefault();
                            infinityrechargedatavalidationoutputlist.Add(mdl);


                        }
                    }
                    else
                    {
                        InfinityRechargeValidationOutput existfiledat = new InfinityRechargeValidationOutput();
                        existfiledat.Reason = "File already exist";
                        existfiledat.Status = 10;
                        infinityrechargedatavalidationoutputlist.Add(existfiledat);
                    }
                    var errorCount = infinityrechargedatavalidationoutputlist.Count(n => n.Status == 0);
                    if (errorCount > 0)
                    {
                        File.Delete(filePathTransactionDetailFile);
                    }
                }
            }
            }
            else
            {
                infinityrechargedatavalidationoutputlist.Add(mdlValidate);
            }

            return infinityrechargedatavalidationoutputlist.AsEnumerable();
        }

        public async Task<IEnumerable<InfinityRechargeDataInsertOutput>> InsertInfinityRechargeDetails([FromForm] InfinityRechargeDataInsertInput ObjClass)
        {
            string FileNamePathTransactionDetailFile = string.Empty;
            var TextFileNameTransactionDetailFile = ObjClass.TransactionDetailFile;
            List<InfinityRechargeDataInsertOutput> infinityrechargedataoutputlist = new List<InfinityRechargeDataInsertOutput>();
            if (TextFileNameTransactionDetailFile.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".txt" };
                var ext = TextFileNameTransactionDetailFile.FileName.Substring(TextFileNameTransactionDetailFile.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathTransactionDetailFile = "/InfinityRechargeFile/" + TextFileNameTransactionDetailFile.FileName;
                    string filePathTransactionDetailFile = contentRootPath + FileNamePathTransactionDetailFile;

                    var lines = File.ReadLines(filePathTransactionDetailFile);
                    foreach (var line in lines)
                    {
                        var values = line.Split('|');
                        InfinityRechargeModel eftrechargemodel = new InfinityRechargeModel();
                        eftrechargemodel.ControlCardNumber = Convert.ToInt64(values[0]);
                        eftrechargemodel.PaymentDate = values[1];
                        eftrechargemodel.UTRNumber = values[2];
                        eftrechargemodel.Amount = values[3];
                        eftrechargemodel.IFSCCode = values[4];
                        eftrechargemodel.BankName = values[5];
                        eftrechargemodel.TransRefNumber = values[6];
                        eftrechargemodel.SenderName = values[7];
                        eftrechargemodel.TransactionType = values[8];
                        eftrechargemodel.TransactionReferenceNo = values[9];


                        var procedureName = "UspInfinityRechargeDetailsEntry";
                        var parameters = new DynamicParameters();
                        parameters.Add("ControlCardNumber", eftrechargemodel.ControlCardNumber, DbType.String, ParameterDirection.Input);
                        parameters.Add("PaymentDate", eftrechargemodel.PaymentDate, DbType.String, ParameterDirection.Input);
                        parameters.Add("UTRNumber", eftrechargemodel.UTRNumber, DbType.String, ParameterDirection.Input);
                        parameters.Add("Amount", eftrechargemodel.Amount, DbType.String, ParameterDirection.Input);
                        parameters.Add("IFSCCode", eftrechargemodel.IFSCCode, DbType.String, ParameterDirection.Input);
                        parameters.Add("BankName", eftrechargemodel.BankName, DbType.String, ParameterDirection.Input);
                        parameters.Add("TransRefNumber", eftrechargemodel.TransRefNumber, DbType.String, ParameterDirection.Input);
                        parameters.Add("SenderName", eftrechargemodel.SenderName, DbType.String, ParameterDirection.Input);
                        parameters.Add("TransactionType", eftrechargemodel.TransactionType, DbType.String, ParameterDirection.Input);
                        parameters.Add("TransactionReferenceNo", eftrechargemodel.TransactionReferenceNo, DbType.String, ParameterDirection.Input);
                        parameters.Add("FileName", TextFileNameTransactionDetailFile.FileName, DbType.String, ParameterDirection.Input);
                        parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                        parameters.Add("Type", "Recharge", DbType.String, ParameterDirection.Input);
                        parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                        parameters.Add("BatchCode", TextFileNameTransactionDetailFile.FileName.Substring(0, TextFileNameTransactionDetailFile.FileName.Length - extension.Length), DbType.String, ParameterDirection.Input);

                        using var connection = _context.CreateConnection();
                        dynamic eftrechargedataoutput = await connection.QueryAsync<InfinityRechargeDataInsertOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


                        // EFTRechargeDataOutput mdlOutput = new EFTRechargeDataOutput();
                        //mdlOutput = eftrechargedataoutput;
                        infinityrechargedataoutputlist.Add(eftrechargedataoutput[0]);



                    }
                }
            }
            return infinityrechargedataoutputlist.AsEnumerable();
        }

        public async Task<IEnumerable<InfinityRechargeApprovalPendingOutput>> InfinityRechargeDetailsPendingForApproval([FromForm] InfinityRechargeApprovalPendingInput ObjClass)
        {
            var procedureName = "UspInfinityRechargePendingForApproval";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNo", ObjClass.ControlCardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("BatchCode", ObjClass.BatchCode, DbType.String, ParameterDirection.Input);
            parameters.Add("UTRNumber", ObjClass.UTRNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("TransRefNumber", ObjClass.TransRefNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Type", "Recharge", DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var infinityrechargedataoutput = await connection.QueryAsync<InfinityRechargeApprovalPendingOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            return infinityrechargedataoutput;
        }

        public async Task<IEnumerable<InfinityRechargeApprovalOutput>> InfinityRechargeDetailsApproval([FromBody] InfinityRechargeApprovalInput ObjClass)
        {
            List<InfinityRechargeApprovalOutput> infinityrechargedataoutputlist = new List<InfinityRechargeApprovalOutput>();
            for (int i = 0; i < ObjClass.lstinput.Count; i++)
            {
                var procedureName = "UspInfinityRechargeCCMSAccount";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", ObjClass.lstinput[i].CustomerId, DbType.String, ParameterDirection.Input);
                parameters.Add("ControlCardNo", ObjClass.lstinput[i].ControlCardNo, DbType.String, ParameterDirection.Input);
                parameters.Add("TransRefNumber", ObjClass.lstinput[i].TransRefNumber, DbType.String, ParameterDirection.Input);
                parameters.Add("Amount", ObjClass.lstinput[i].Amount, DbType.String, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Type", "Recharge", DbType.String, ParameterDirection.Input);
                parameters.Add("ReferenceNo", ObjClass.lstinput[i].ReferenceNo, DbType.String, ParameterDirection.Input);

                using var connection = _context.CreateConnection();
                var eftrechargedataoutput = await connection.QueryAsync<InfinityRechargeApprovalOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                var mdl = eftrechargedataoutput.FirstOrDefault();
                infinityrechargedataoutputlist.Add(mdl);



            }
            return infinityrechargedataoutputlist.AsEnumerable();

        }

        public async Task<IEnumerable<InfinityRechargeRejectionOutput>> InfinityRechargeDetailsRejection([FromBody] InfinityRechargeRejectionInput ObjClass)
        {
            List<InfinityRechargeRejectionOutput> infinityrechargerejectlist = new List<InfinityRechargeRejectionOutput>();
            for (int i = 0; i < ObjClass.lstRejectioninput.Count; i++)
            {
                var procedureName = "UspInfinityRechargeDetailsRejection";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerId", ObjClass.lstRejectioninput[i].CustomerId, DbType.String, ParameterDirection.Input);
                parameters.Add("ControlCardNo", ObjClass.lstRejectioninput[i].ControlCardNo, DbType.String, ParameterDirection.Input);
                parameters.Add("TransRefNumber", ObjClass.lstRejectioninput[i].TransRefNumber, DbType.String, ParameterDirection.Input);
                parameters.Add("Amount", ObjClass.lstRejectioninput[i].Amount, DbType.String, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Type", "Recharge", DbType.String, ParameterDirection.Input);
                parameters.Add("ReferenceNo", ObjClass.lstRejectioninput[i].ReferenceNo, DbType.String, ParameterDirection.Input);


                using var connection = _context.CreateConnection();

                var eftrechargedataoutput = await connection.QueryAsync<InfinityRechargeRejectionOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                var mdl = eftrechargedataoutput.FirstOrDefault();
                infinityrechargerejectlist.Add(mdl);

            }
            return infinityrechargerejectlist.AsEnumerable();

        }

        public async Task<IEnumerable<ViewInfinityRequestOutput>> ViewInfinityRequest([FromForm] ViewInfinityRequestInput ObjClass)
        {
            var procedureName = "UspViewInfinityRequest";
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

            var infinityrechargedataoutput = await connection.QueryAsync<ViewInfinityRequestOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            return infinityrechargedataoutput;

        }
    }
}
