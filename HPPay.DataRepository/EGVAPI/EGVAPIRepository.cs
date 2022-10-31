//using AtallaHSM.Data.DBDapper;
using HPPay.DataRepository.DBDapper;
using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.PayCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.EGVAPI
{
    public class EGVAPIRepository:IEGVAPIRepository
    {
        private readonly DapperContext _context;
        public EGVAPIRepository(DapperContext context)
        {
            _context = context;
        }



        public async Task<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput> GeneratePayCodeForEGVAPI([FromBody] PayCodeGeneratePayCodeDetailsForEGVAPIWithoutStartDateModelIntput ObjClass)
        {
            var procedureName = "uspGenerateFuelVoucher";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("PassWord", ObjClass.PassWord, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("NoOfPaycode", ObjClass.NoOfPaycode, DbType.String, ParameterDirection.Input);
            //parameters.Add("StartDate", ObjClass.StartDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            // return await connection.QueryAsync<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);


            //var storedProcedureResult = new PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput();
            //storedProcedureResult.voucherDetails = (List<GetPayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>)await result.ReadAsync<GetPayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>();
            //return storedProcedureResult;


            var storedProcedureResult = new PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput();
            storedProcedureResult.voucherDetails = (List<GetPayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>)await result.ReadAsync<GetPayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>();
            var data = (List<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>)await result.ReadAsync<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>();

            storedProcedureResult.responseMessage = data.ToList()[0].responseMessage;
            storedProcedureResult.responseCode = data.ToList()[0].responseCode;

            return storedProcedureResult;




        }



        public async Task<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput> GenerateFuelVoucherWithStartDate([FromBody] PayCodeGeneratePayCodeDetailsForEGVAPIModelInput ObjClass)
        {
            var procedureName = "uspGenerateFuelVoucherWitDate";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("PassWord", ObjClass.PassWord, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("NoOfPaycode", ObjClass.NoOfPaycode, DbType.String, ParameterDirection.Input);
            parameters.Add("StartDate", ObjClass.StartDate, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            // return await connection.QueryAsync<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);


            var storedProcedureResult = new PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput();
            storedProcedureResult.voucherDetails = (List<GetPayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>)await result.ReadAsync<GetPayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>();
            var data = (List<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>)await result.ReadAsync<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>();

            storedProcedureResult.responseMessage = data.ToList()[0].responseMessage;
            storedProcedureResult.responseCode = data.ToList()[0].responseCode;

            return storedProcedureResult;

        }



        public async Task<PayCodeGetConsumptionDataForEGVAPIModelOutput> GetConsumptionData([FromBody] PayCodeGetConsumptionDataForEGVAPIModelInput ObjClass)
        {
            var procedureName = "UspGetConsumptionData";
            var parameters = new DynamicParameters();
            parameters.Add("userName", ObjClass.username, DbType.String, ParameterDirection.Input);
            parameters.Add("password", ObjClass.password, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            // parameters.Add("StartDate", ObjClass.StartDate, DbType.DateTime, ParameterDirection.Input);
            //  parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            // return await connection.QueryAsync<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);




            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);


            var storedProcedureResult = new PayCodeGetConsumptionDataForEGVAPIModelOutput();
            List<GetPayCodeGetConsumptionDataForEGVAPIModelOutput> getPayCodeGetConsumptionDataForEGVAPIModelOutputs = new List<GetPayCodeGetConsumptionDataForEGVAPIModelOutput>();
            List<GetheaderDetailsOutput> getheaderDetailsOutputs = new List<GetheaderDetailsOutput>();
            getPayCodeGetConsumptionDataForEGVAPIModelOutputs = (List<GetPayCodeGetConsumptionDataForEGVAPIModelOutput>)await result.ReadAsync<GetPayCodeGetConsumptionDataForEGVAPIModelOutput>();
            getheaderDetailsOutputs = (List<GetheaderDetailsOutput>)await result.ReadAsync<GetheaderDetailsOutput>();
            storedProcedureResult.consumptionRes = getPayCodeGetConsumptionDataForEGVAPIModelOutputs.FirstOrDefault();
            storedProcedureResult.consumptionRes.headerDetails = getheaderDetailsOutputs.FirstOrDefault();

            storedProcedureResult.transactionsDetails = (List<GettransactionsDetailsOutput>)await result.ReadAsync<GettransactionsDetailsOutput>();
            //storedProcedureResult.transactionsDetails = (List<PayCodeGetConsumptionDataForEGVAPIModelOutput>)await result.ReadAsync<PayCodeGetConsumptionDataForEGVAPIModelOutput>();

            return storedProcedureResult;
            

            //var storedProcedureResult = new PayCodeGetConsumptionDataForEGVAPIModelOutput();
            //GetPayCodeGetConsumptionDataForEGVAPIModelOutput resobj = new GetPayCodeGetConsumptionDataForEGVAPIModelOutput();
            
            //storedProcedureResult.consumptionRes = new List<GetPayCodeGetConsumptionDataForEGVAPIModelOutput>();
            //storedProcedureResult.consumptionRes.Add(resobj);
            //List<GetheaderDetailsOutput> obj=(List<GetheaderDetailsOutput>)await result.ReadAsync<GetheaderDetailsOutput>();
            //storedProcedureResult.consumptionRes[0].headerDetails = new List<GetheaderDetailsOutput>();
            //storedProcedureResult.consumptionRes[0].headerDetails.AddRange(obj); 
            ////(List<GetPayCodeGetConsumptionDataForEGVAPIModelOutput>)await result.ReadAsync<GetPayCodeGetConsumptionDataForEGVAPIModelOutput>();
            // storedProcedureResult. = (List<PayCodeGetConsumptionDataForEGVAPIModelOutput>)await result.ReadAsync<PayCodeGetConsumptionDataForEGVAPIModelOutput>();
            //storedProcedureResult. = (List<GetPayCodeGetConsumptionDataForEGVAPIModelOutput>)await result.ReadAsync<GetPayCodeGetConsumptionDataForEGVAPIModelOutput>();
            
            //storedProcedureResult.transactionsDetails = (List<GettransactionsDetailsOutput>)await result.ReadAsync<GettransactionsDetailsOutput>();
            //return storedProcedureResult;


            // var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);


            // var storedProcedureResult = new PayCodeGetConsumptionDataForEGVAPIModelOutput();
            //// storedProcedureResult.consumptionRes
            //    List < GetPayCodeGetConsumptionDataForEGVAPIModelOutput > res = (List<GetPayCodeGetConsumptionDataForEGVAPIModelOutput>)await result.ReadAsync<GetPayCodeGetConsumptionDataForEGVAPIModelOutput>();
            // var data = (List<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>)await result.ReadAsync<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>();

            // List<GettransactionsDetailsOutput> res2 = (List<GettransactionsDetailsOutput>)await result.ReadAsync<GettransactionsDetailsOutput>();
            //var data1 = (List<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>)await result.ReadAsync<PayCodeGeneratePayCodeDetailsForEGVAPIModelOutput>();


            // //storedProcedureResult.responseMessage = data.ToList()[0].responseMessage;
            // //storedProcedureResult.responseCode = data.ToList()[0].responseCode;
            // storedProcedureResult.transactionsDetails.AddRange(res2);
            // storedProcedureResult.consumptionRes.AddRange(res);
            // return storedProcedureResult;

        }



    }
}
