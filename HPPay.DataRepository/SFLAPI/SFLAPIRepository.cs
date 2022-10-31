using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.Card;
using HPPay.DataModel.SFLAPI;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.SFLAPI
{


    public class SFLAPIRepository : ISFLAPIRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public SFLAPIRepository(DapperContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<SFLAPIMapDTPlusCustomerModelOutput>> MapDTPlusCustomer([FromBody] SFLAPIMapDTPlusCustomerModelInput ObjClass)
        {
            var procedureName = "uspSFLMapDTPlusCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("SFCustomerID", ObjClass.SFCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPCustomerID", ObjClass.DTPCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("PanNumber", ObjClass.PanNumber, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<SFLAPIMapDTPlusCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<SFLAPICreateCardModelOutput> CreateCard([FromBody] SFLAPICreateCardModelInput ObjClass)
        {
            var procedureName = "UspSFLCreateCard";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleFormType", ObjClass.VehicleFormType, DbType.String, ParameterDirection.Input);
            parameters.Add("SFCustomerID", ObjClass.SFCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPCustomerID", ObjClass.DTPCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Recordstatus", ObjClass.Recordstatus, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleRegistrationNumber", ObjClass.CardDetail.VehicleRegistrationNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNumber", ObjClass.CardDetail.CardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CreditDailysaleLimit", ObjClass.CardDetail.CreditDailysaleLimit, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("TransactionDate", ObjClass.CardDetail.TransactionDate, DbType.String, ParameterDirection.Input);
            parameters.Add("AssetSerialNumber", ObjClass.CardDetail.AssetSerialNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleAssetType", ObjClass.CardDetail.VehicleAssetType, DbType.String, ParameterDirection.Input);
            parameters.Add("ItemsEnabledDiesel", ObjClass.CardDetail.ItemsEnabledDiesel, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            List<cardDetailsFinaloutput> objcardres = new List<cardDetailsFinaloutput>();
            GetcardRes objcardres2 = new GetcardRes();

            SFLAPICreateCardModelOutput objcardres3 = new SFLAPICreateCardModelOutput();

            objcardres = (List<cardDetailsFinaloutput>)await result.ReadAsync<cardDetailsFinaloutput>();

            objcardres2.cardDetail = objcardres.FirstOrDefault();
            objcardres3.cardRes = objcardres2;
            return objcardres3;

        }

        public async Task<SFLAPIUpdateStatusModelOutputMain> UpdateStatus([FromBody] SFLAPIUpdateStatusModelInput ObjClass)
        {
            var procedureName = "UspSFLUpdateStatus";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("ApplicabilityCustomerCard", ObjClass.ApplicabilityCustomerCard, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPCustomerID", ObjClass.DTPCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNumber", ObjClass.CardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNumber", ObjClass.ReferenceNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CardCustomerStatusCode", ObjClass.CardCustomerStatusCode, DbType.String, ParameterDirection.Input);
            parameters.Add("PreviousCardStatusCode", ObjClass.PreviousCardStatusCode, DbType.String, ParameterDirection.Input);
            parameters.Add("StatusChangeReasonCode", ObjClass.StatusChangeReasonCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new SFLAPIUpdateStatusModelOutput();
            SFLAPIUpdateStatusModelMainOutput sFLAPIUpdateStatusModelMainOutput = new SFLAPIUpdateStatusModelMainOutput();
            SFLAPIUpdateStatusModelOutputMain sFLAPIUpdateStatusModelOutputMain = new SFLAPIUpdateStatusModelOutputMain();
            List<GetcustomerCardStatusRes> getcustomerCardStatusResObj = new List<GetcustomerCardStatusRes>();
            List<entityDetail> entityDetailObj = new List<entityDetail>();
            getcustomerCardStatusResObj = (List<GetcustomerCardStatusRes>)await result.ReadAsync<GetcustomerCardStatusRes>();
            entityDetailObj = (List<entityDetail>)await result.ReadAsync<entityDetail>();
            storedProcedureResult.entityDetails = entityDetailObj.FirstOrDefault();
            storedProcedureResult.customerCardStatusRes = getcustomerCardStatusResObj.FirstOrDefault();

            sFLAPIUpdateStatusModelMainOutput.responseCode = storedProcedureResult.customerCardStatusRes.responseCode;
            sFLAPIUpdateStatusModelMainOutput.responseMessage = storedProcedureResult.customerCardStatusRes.responseMessage;
            sFLAPIUpdateStatusModelMainOutput.entityDetails = storedProcedureResult.entityDetails;
            sFLAPIUpdateStatusModelOutputMain.customerCardStatusRes = sFLAPIUpdateStatusModelMainOutput;
            
            return sFLAPIUpdateStatusModelOutputMain;

        }

        public async Task<SFLAPIGetConsumptionDataModelOutput> GetConsumptionData([FromBody] SFLAPIGetConsumptionDataModelInput ObjClass)
        {
            var procedureName = "UspSFLGetConsumptionData";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new SFLAPIGetConsumptionDataModelOutput();

            List<GetRespCodeMessageDetails> getRespCodeMessageDetails = new List<GetRespCodeMessageDetails>();
            List<GetheaderDetails> getheaderDetails = new List<GetheaderDetails>();
            List<GetTransactionDetails> getTransactionDetails = new List<GetTransactionDetails>();
            GetconsumptionRes getconsumptionRes = new GetconsumptionRes();

            //storedProcedureResult.GetRespCodeMessageDetails = (List<GetconsumptionRes>)await result.ReadAsync<GetconsumptionRes>();
            getRespCodeMessageDetails = (List<GetRespCodeMessageDetails>)await result.ReadAsync<GetRespCodeMessageDetails>();
            getheaderDetails = (List<GetheaderDetails>)await result.ReadAsync<GetheaderDetails>();
            getTransactionDetails = (List<GetTransactionDetails>)await result.ReadAsync<GetTransactionDetails>();

            getconsumptionRes.headerDetails = getheaderDetails.FirstOrDefault();
            getconsumptionRes.transactionsDetails = getTransactionDetails;
            getconsumptionRes.responseCode = getRespCodeMessageDetails.FirstOrDefault().responseCode;
            getconsumptionRes.responseMessage = getRespCodeMessageDetails.FirstOrDefault().responseMessage;

            SFLAPIGetConsumptionDataModelOutput objsfl = new SFLAPIGetConsumptionDataModelOutput();
            
            objsfl.consumptionRes = getconsumptionRes;
            return objsfl;

        }

        public async Task<SFLAPIGetCardHotlistStatusModelOutput> GetCardHotlistStatus([FromBody] SFLAPIGetCardHotlistStatusModelInput ObjClass)
        {
            var procedureName = "UspSFLGetCardHotlistStatus";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new SFLAPIGetCardHotlistStatusModelOutput();
            storedProcedureResult.cardHotListResponse = (List<GetcardHotListResponse>)await result.ReadAsync<GetcardHotListResponse>();
            storedProcedureResult.cards = (List<Getcards>)await result.ReadAsync<Getcards>();
            SFLAPIGetCardHotlistStatusModelOutput objsfl = new SFLAPIGetCardHotlistStatusModelOutput();
            objsfl.cardHotListResponse = storedProcedureResult.cardHotListResponse;
            objsfl.cards = storedProcedureResult.cards;
            return objsfl;

        }

        public async Task<SFLAPIGetCustomerHotlistStatusModelOutput> GetCustomerHotlistStatus([FromBody] SFLAPIGetCustomerHotlistStatusModelInput ObjClass)
        {
            var procedureName = "UspSFLGetCustomerHotlistStatus";
            var parameters = new DynamicParameters();
            parameters.Add("DtpCustomerId", ObjClass.DtpCustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("SFLCustomerId", ObjClass.SFLCustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new SFLAPIGetCustomerHotlistStatusModelOutput();
            storedProcedureResult.customerHotlistDetails = (List<GetcustomerHotlistDeatils>)await result.ReadAsync<GetcustomerHotlistDeatils>();

            SFLAPIGetCustomerHotlistStatusModelOutput objsfl = new SFLAPIGetCustomerHotlistStatusModelOutput();
            objsfl.customerHotlistDetails = storedProcedureResult.customerHotlistDetails;
            return objsfl;

        }

        public async Task<SFLAPIGetHotlistReactivateReasonModelOutput> GetHotlistReactivateReason([FromBody] SFLAPIGetHotlistReactivateReasonModelInput ObjClass)
        {
            var procedureName = "UspSFLGetHotlistReactivateReason";
            var parameters = new DynamicParameters();
            parameters.Add("flag", ObjClass.flag, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new SFLAPIGetHotlistReactivateReasonModelOutput();
            List<GetRespCodeMessage> getRespCodeMessages = new List<GetRespCodeMessage>();
            getRespCodeMessages = (List<GetRespCodeMessage>)await result.ReadAsync<GetRespCodeMessage>();
            storedProcedureResult.lstReasonInfo = (List<GetlstReasonInfo>)await result.ReadAsync<GetlstReasonInfo>();            

            SFLAPIGetHotlistReactivateReasonModelOutput objsfl = new SFLAPIGetHotlistReactivateReasonModelOutput();
            objsfl.responseMessage = getRespCodeMessages.FirstOrDefault().responseMessage;
            objsfl.responseCode = getRespCodeMessages.FirstOrDefault().responseCode;

            objsfl.lstReasonInfo = storedProcedureResult.lstReasonInfo;
            return objsfl;

        }

    }
}
