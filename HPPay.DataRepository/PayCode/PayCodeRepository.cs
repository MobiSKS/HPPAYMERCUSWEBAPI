using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.PayCode;
using HPPay.DataRepository.DBDapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.PayCode
{
    public class PayCodeRepository:IPayCodeRepository
    {
        private readonly DapperContext _context;
        public PayCodeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PayCodeGeneratePayCodeDetailsModelOutput>> GeneratePayCodeDetails([FromBody] PayCodeGeneratePayCodeDetailsModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeDespetachDetails");
            dtDBR.Columns.Add("MobileNo", typeof(string));
            dtDBR.Columns.Add("Email", typeof(string));

            //if (ObjClass.ObjTranscationsForTypeDespetachDetails != null)
            //{
            foreach (PayCodeForTypeDespetachDetails ObjDetail in ObjClass.ObjPayCodeForTypeDespetachDetails)
            {
                DataRow dr = dtDBR.NewRow();
                dr["MobileNo"] = ObjDetail.MobileNo;
                dr["Email"] = ObjDetail.Email;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }
            //}

            var procedureName = "UspGeneratePayCode";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("ProductId", ObjClass.ProductId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("NoOfPaycode", 1, DbType.Int64, ParameterDirection.Input);
            // parameters.Add("Validitiy", ObjClass.Validitiy, DbType.String, ParameterDirection.Input);
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("VechileNo", ObjClass.VechileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            //parameters.Add("EffectiveDate", ObjClass.EffectiveDate, DbType.DateTime, ParameterDirection.Input);


            parameters.Add("Amount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeDespetachDetails", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<PayCodeGeneratePayCodeDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<PayCodeGeneratePayCodeDetailsForEGVModelOutput>> GeneratePayCodeDetailsForEGV([FromBody] PayCodeGeneratePayCodeDetailsForEGVModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeDespetachDetails");
            dtDBR.Columns.Add("MobileNo", typeof(string));
            dtDBR.Columns.Add("Email", typeof(string));

            //if (ObjClass.ObjTranscationsForTypeDespetachDetails != null)
            //{
            foreach (PayCodeForTypeDespetachDetailsForEGV ObjDetail in ObjClass.ObjPayCodeForEGVTypeDespetachDetails)
            {
                DataRow dr = dtDBR.NewRow();
                dr["MobileNo"] = ObjDetail.MobileNo;
                dr["Email"] = ObjDetail.Email;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }
            //}

            var procedureName = "UspGeneratePayCodeforEGV";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
             parameters.Add("NoOfPaycode", ObjClass.NoOfPaycode, DbType.Int64, ParameterDirection.Input);
            //parameters.Add("NoOfPaycode", 1, DbType.Int64, ParameterDirection.Input);
            parameters.Add("Validitiy", ObjClass.Validitiy, DbType.Int64, ParameterDirection.Input);
            parameters.Add("EffectiveDate", ObjClass.EffectiveDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeDespetachDetails", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<PayCodeGeneratePayCodeDetailsForEGVModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<CheckCCMSBalanceforPaycodeGenerationModelOutput>> CheckCCMSBalanceforPaycodeGeneration([FromBody] CheckCCMSBalanceforPaycodeGenerationModelInput ObjClass)
        {
           
            var procedureName = "UspCheckCCMSBalanceforPaycodeGeneration";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("NoOfPaycode", ObjClass.NoOfPaycode, DbType.Int64, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckCCMSBalanceforPaycodeGenerationModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }


        public async Task<IEnumerable<PayCodeGetCardNoByVechileNoModelOutput>> GetCardNoByVechileNo([FromBody] PayCodeGetCardNoByVechileNoModelInput ObjClass)
        {
            var procedureName = "UspGetCardNoByVechileNo";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("VechileNo", ObjClass.VechileNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
        
            return await connection.QueryAsync<PayCodeGetCardNoByVechileNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetCardNoByMobileNoModelOutput>> GetCardNoByMobileNo([FromBody] GetCardNoByMobileNoModelInput ObjClass)
        {
            var procedureName = "UspGetCardNoByMobileNo";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<GetCardNoByMobileNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetPayCodeStatusModelOutput>> GetPayCodeStatus([FromBody] GetPayCodeStatusModelInput ObjClass)
        {
            var procedureName = "UspGetPayCodeStatus";

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetPayCodeStatusModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);


        }

        public async Task<IEnumerable<GetPaycodeStatusDetailsModelOutput>> GetPaycodeStatusDetails([FromBody] GetPaycodeStatusDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetPaycodeStatusDetails";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("PaycodeStatus", ObjClass.PaycodeStatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("Paycode", ObjClass.Paycode, DbType.String, ParameterDirection.Input);
            parameters.Add("PaycodeType", ObjClass.PaycodeType, DbType.Int64, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetPaycodeStatusDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<IEnumerable<CancelPaycodeModelOutput>> CancelPaycode([FromBody] CancelPaycodeModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeCancelPaycode");
            dtDBR.Columns.Add("Amount", typeof(decimal));
            dtDBR.Columns.Add("PayCode", typeof(string));

            var procedureName = "UspCancelPaycode";
            var parameters = new DynamicParameters();
            
            if (ObjClass.ObjPayCodeForCancel != null)
            {
                foreach (PayCodeForCancel ObjPayCodeDetails in ObjClass.ObjPayCodeForCancel)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["Amount"] = ObjPayCodeDetails.Amount;
                    dr["PayCode"] = ObjPayCodeDetails.PayCode;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            parameters.Add("TypeCancelPaycode", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);

            // parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            //parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            //parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            //parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CancelPaycodeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<UpdateExpiryDateModelOutput>> UpdateExpiryDate([FromBody] UpdateExpiryDateModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeUpdatePaycodeExpiryDate");
            dtDBR.Columns.Add("PayCode", typeof(string));   
            dtDBR.Columns.Add("ExpiryDate", typeof(string));

            var procedureName = "UspUpdateExpiryDate";
            var parameters = new DynamicParameters();

            if (ObjClass.ObjUpdatePaycodeExpiryDate != null)
            {
                foreach (UpdatePaycodeExpiryDate ObjPayCodeDetails in ObjClass.ObjUpdatePaycodeExpiryDate)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["PayCode"] = ObjPayCodeDetails.PayCode;
                    dr["ExpiryDate"] = ObjPayCodeDetails.ExpiryDate;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeUpdatePaycodeExpiryDate", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateExpiryDateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }






        //public async Task<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput> GeneratePayCodeForEGVAPI([FromBody] PayCodeGeneratePayCodeDetailsForEGVAPIWithoutStartDateModelIntput ObjClass)
        //{
        //    var procedureName = "uspGenerateFuelVoucher";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
        //    parameters.Add("PassWord", ObjClass.PassWord, DbType.String, ParameterDirection.Input);
        //    parameters.Add("Amount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
        //    parameters.Add("NoOfPaycode", ObjClass.NoOfPaycode, DbType.String, ParameterDirection.Input);
        //    //parameters.Add("StartDate", ObjClass.StartDate, DbType.DateTime, ParameterDirection.Input);
        //    parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
        //    using var connection = _context.CreateConnection();
        //   // return await connection.QueryAsync<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


        //    var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);


        //    //var storedProcedureResult = new PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput();
        //    //storedProcedureResult.voucherDetails = (List<GetPayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>)await result.ReadAsync<GetPayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>();
        //    //return storedProcedureResult;


        //    var storedProcedureResult = new PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput();
        //    storedProcedureResult.voucherDetails = (List<GetPayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>)await result.ReadAsync<GetPayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>();
        //    var data = (List<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>)await result.ReadAsync<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>();

        //    storedProcedureResult.responseMessage = data.ToList()[0].responseMessage;
        //    storedProcedureResult.responseCode = data.ToList()[0].responseCode;

        //    return storedProcedureResult;




        //}



        //public async Task<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput> GenerateFuelVoucherWithStartDate([FromBody] PayCodeGeneratePayCodeDetailsForEGVAPIModelInput ObjClass)
        //{
        //    var procedureName = "uspGenerateFuelVoucher";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
        //    parameters.Add("PassWord", ObjClass.PassWord, DbType.String, ParameterDirection.Input);
        //    parameters.Add("Amount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
        //    parameters.Add("NoOfPaycode", ObjClass.NoOfPaycode, DbType.String, ParameterDirection.Input);
        //    parameters.Add("StartDate", ObjClass.StartDate, DbType.DateTime, ParameterDirection.Input);
        //    parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
        //    using var connection = _context.CreateConnection();
        //    // return await connection.QueryAsync<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


        //    var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);


        //    var storedProcedureResult = new PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput();
        //    storedProcedureResult.voucherDetails = (List<GetPayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>)await result.ReadAsync<GetPayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>();
        //    var data  = (List<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>)await result.ReadAsync<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>();

        //    storedProcedureResult.responseMessage = data.ToList()[0].responseMessage;
        //    storedProcedureResult.responseCode = data.ToList()[0].responseCode;

        //    return storedProcedureResult;

        //}



        //public async Task<PayCodeGetConsumptionDataForEGVAPIModelOutput> GetConsumptionData([FromBody] PayCodeGetConsumptionDataForEGVAPIModelInput ObjClass)
        //{
        //    var procedureName = "uspGetConsumptionData";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("userName", ObjClass.username, DbType.String, ParameterDirection.Input);
        //    parameters.Add("password", ObjClass.password, DbType.String, ParameterDirection.Input);
        //    parameters.Add("FromDate", ObjClass.FromDate, DbType.Decimal, ParameterDirection.Input);
        //    parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
        //   // parameters.Add("StartDate", ObjClass.StartDate, DbType.DateTime, ParameterDirection.Input);
        //  //  parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
        //    using var connection = _context.CreateConnection();
        //    // return await connection.QueryAsync<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


        //    var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);


        //    var storedProcedureResult = new PayCodeGetConsumptionDataForEGVAPIModelOutput();
        //    storedProcedureResult.consumptionRes = (List<GetPayCodeGetConsumptionDataForEGVAPIModelOutput>)await result.ReadAsync<GetPayCodeGetConsumptionDataForEGVAPIModelOutput>();
        //    var data = (List<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>)await result.ReadAsync<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>();

        //    //storedProcedureResult.responseMessage = data.ToList()[0].responseMessage;
        //    //storedProcedureResult.responseCode = data.ToList()[0].responseCode;

        //    return storedProcedureResult;

        //}





    }
}
