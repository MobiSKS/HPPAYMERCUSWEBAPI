using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.IMPS;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HPPay.DataRepository.IMPS
{
    public class IMPSRepository : IIMPSRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public IMPSRepository(DapperContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IEnumerable<IMPSSearchOutput>> IMPSTransactionSearch([FromForm] IMPSSearchInput ObjClass)
        {
            var procedureName = "UspEFTRechargePendingForApproval";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNo", ObjClass.ControlCardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("Status", ObjClass.Status, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactioId", ObjClass.TransactioId, DbType.String, ParameterDirection.Input);            
            parameters.Add("Type", "Recharge", DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var eftrechargedataoutput = await connection.QueryAsync<IMPSSearchOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            return eftrechargedataoutput;
        }
        public async Task<IEnumerable<IMPSRechargeReversalRequestOutput>> IMPSRechargeReversalRequest([FromForm] IMPSRechargeReversalRequestInput ObjClass)
        {
            //List<IMPSRechargeReversalRequestInput> isurepayreversalentrylist = new List<IMPSRechargeReversalRequestInput>();
            
                var procedureName = "UspIMPSRechargeReversalCCMSAccount";
                var parameters = new DynamicParameters();
                parameters.Add("BankTransactionID", ObjClass.BankTransactionID, DbType.String, ParameterDirection.Input);
                //parameters.Add("ControlCardNo", ObjClass.ISurePayReversalLst[i].ControlCardNo, DbType.String, ParameterDirection.Input);
                //parameters.Add("ValidateNo", ObjClass.ISurePayReversalLst[i].ValidateNo, DbType.String, ParameterDirection.Input);
                //parameters.Add("Amount", ObjClass.ISurePayReversalLst[i].Amount, DbType.String, ParameterDirection.Input);
                //parameters.Add("TransactionDate", ObjClass.ISurePayReversalLst[i].TransactionDate, DbType.String, ParameterDirection.Input);
                //parameters.Add("TransactionId", ObjClass.ISurePayReversalLst[i].TransactionId, DbType.String, ParameterDirection.Input);
                //parameters.Add("PayMode", ObjClass.ISurePayReversalLst[i].PayMode, DbType.String, ParameterDirection.Input);
                //parameters.Add("ISureId", ObjClass.ISurePayReversalLst[i].ISureId, DbType.String, ParameterDirection.Input);
                //parameters.Add("InstrumentNumber", ObjClass.ISurePayReversalLst[i].InstrumentNumber, DbType.String, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("ReferenceNo", ObjClass.ReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Type", "Reversal", DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();

                var isurepayrechargedataoutput = await connection.QueryAsync<IMPSRechargeReversalRequestOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                //var mdl = isurepayrechargedataoutput.FirstOrDefault();
                //isurepayreversalentrylist.Add(mdl);
            
            return isurepayrechargedataoutput.AsEnumerable();

        }
    }
}
