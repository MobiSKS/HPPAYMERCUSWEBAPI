using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.Card;
using HPPay.DataModel.M2PAPI;
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

namespace HPPay.DataRepository.M2PAPI
{

    public class M2PAPIRepository : IM2PAPIRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public M2PAPIRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<M2PAPIUpdateStatusModelMainOutput> UpdateStatus([FromBody] M2PAPIUpdateStatusModelInput ObjClass)
        {
            var procedureName = "UspM2PUpdateStatus";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("ApplicabilityCustomerCard", ObjClass.ApplicabilityCustomerCard, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPCustomerID", ObjClass.DTPCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNumber", ObjClass.CardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNumber", ObjClass.ReferenceNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CardCustomerStatusCode", ObjClass.CardCustomerStatusCode, DbType.String, ParameterDirection.Input);
            parameters.Add("PreviousCardStatusCode", ObjClass.PreviousCardStatusCode, DbType.String, ParameterDirection.Input);
            parameters.Add("StatusChangeReasonCode", ObjClass.StatusChangeReasonCode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new M2PAPIUpdateStatusModelOutput();

            M2PAPIUpdateStatusModelMainOutput M2PUpdateobj = new M2PAPIUpdateStatusModelMainOutput();
            List<GetcustomerCardStatusRes> getcustomerCardStatus = new List<GetcustomerCardStatusRes>();
            List<entityDetail> entityDetailobject = new List<entityDetail>();
            getcustomerCardStatus = (List<GetcustomerCardStatusRes>)await result.ReadAsync<GetcustomerCardStatusRes>();
            entityDetailobject = (List<entityDetail>)await result.ReadAsync<entityDetail>();
            storedProcedureResult.entityDetails = entityDetailobject.FirstOrDefault();
            storedProcedureResult.customerCardStatusRes = getcustomerCardStatus.FirstOrDefault();
            M2PUpdateobj.responseCode = storedProcedureResult.customerCardStatusRes.responseCode;
            M2PUpdateobj.responseMessage = storedProcedureResult.customerCardStatusRes.responseMessage;
            M2PUpdateobj.entityDetails = storedProcedureResult.entityDetails;
            return M2PUpdateobj;
        }

        public async Task<M2PAPIGetConsumptionDataModelOutput> GetConsumptionData([FromBody] M2PAPIGetConsumptionDataModelInput ObjClass)
        {
            var procedureName = "UspM2PGetConsumptionData";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            var storedProcedureResult = new M2PAPIGetConsumptionDataModelOutput();
            storedProcedureResult.headerDetails = (List<headerDetail>)await result.ReadAsync<headerDetail>();
            storedProcedureResult.consumptionRes = (List<GetconsumptionRes>)await result.ReadAsync<GetconsumptionRes>();
            storedProcedureResult.transactionsDetails = (List<transactionsDetail>)await result.ReadAsync<transactionsDetail>();

            M2PAPIGetConsumptionDataModelOutput STFCobj = new M2PAPIGetConsumptionDataModelOutput();
            STFCobj.headerDetails = storedProcedureResult.headerDetails;
            STFCobj.consumptionRes = storedProcedureResult.consumptionRes;
            STFCobj.transactionsDetails = storedProcedureResult.transactionsDetails;
            return STFCobj;
        }


        public async Task<M2PAPIGetCardHotlistStatusModelOutput> GetCardHotlistStatus([FromBody] M2PAPIGetCardHotlistStatusModelInput ObjClass)
        {
            var procedureName = "UspM2PGetCardHotlistStatus";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            var storedProcedureResult = new M2PAPIGetCardHotlistStatusModelOutput();
            storedProcedureResult.cardHotListResponse = (List<cardHotListResponses>)await result.ReadAsync<cardHotListResponses>();
            storedProcedureResult.cards = (List<Getcards>)await result.ReadAsync<Getcards>();

            M2PAPIGetCardHotlistStatusModelOutput STFCobj = new M2PAPIGetCardHotlistStatusModelOutput();
            STFCobj.cardHotListResponse = storedProcedureResult.cardHotListResponse;
            STFCobj.cards = storedProcedureResult.cards;

            return STFCobj;
        }
        public async Task<M2PAPIGetAllTransactionsModelFInalOutput> GetAllTransactions([FromBody] M2PAPIGetAllTransactionsModelInput ObjClass)
        {
            var procedureName = "UspM2PGetAllTransactions";
            var parameters = new DynamicParameters();
            parameters.Add("customerID", ObjClass.customerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new M2PAPIGetAllTransactionsModelOutput();
            storedProcedureResult.TransactionDetail = (List<TransactionDetails>)await result.ReadAsync<TransactionDetails>();
            storedProcedureResult.lstTransactionDetailInfo = (List<TransactionDetailInfo>)await result.ReadAsync<TransactionDetailInfo>();

            M2PAPIGetAllTransactionsModelFInalOutput M2PCobj = new M2PAPIGetAllTransactionsModelFInalOutput();
            M2PCobj.customerId = storedProcedureResult.TransactionDetail.FirstOrDefault().customerId;
            M2PCobj.startDate = storedProcedureResult.TransactionDetail.FirstOrDefault().startDate;
            M2PCobj.endDate = storedProcedureResult.TransactionDetail.FirstOrDefault().endDate;
            M2PCobj.txnCount = storedProcedureResult.TransactionDetail.FirstOrDefault().txnCount;
            M2PCobj.responseMessage = storedProcedureResult.TransactionDetail.FirstOrDefault().responseMessage;
            M2PCobj.responseCode = storedProcedureResult.TransactionDetail.FirstOrDefault().responseCode;
            M2PCobj.lstTransactionDetailInfo = new List<TransactionDetailInfo>();
            M2PCobj.lstTransactionDetailInfo.AddRange(storedProcedureResult.lstTransactionDetailInfo);
            return M2PCobj;
        }
        public async Task<IEnumerable<MAPM2PCardlessModelOutput>> MAPM2PCardless([FromBody] MAPM2PCardlessModelInput ObjClass)
        {
            var procedureName = "UspM2PMAPM2PCardless";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNumber", ObjClass.CardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobile", ObjClass.Mobile, DbType.String, ParameterDirection.Input);
            parameters.Add("ManipulationType", ObjClass.ManipulationType, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MAPM2PCardlessModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<M2PAPICreateCardModelOutput> CreateCard([FromBody] M2PAPICreateCardModelInput ObjClass)
        {
            var procedureName = "UspM2PCreateCard";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleFormType", ObjClass.VehicleFormType, DbType.String, ParameterDirection.Input);
            parameters.Add("M2PCustomerID", ObjClass.M2PCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPCustomerID", ObjClass.DTPCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Recordstatus", ObjClass.Recordstatus, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleRegistrationNumber", ObjClass.CardDetail.VehicleRegistrationNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CreditDailysaleLimit", ObjClass.CardDetail.CreditDailysaleLimit, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("ItemsEnabledDiesel", ObjClass.CardDetail.ItemsEnabledDiesel, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            List<cardDetailsfinaloutput> objcardres = new List<cardDetailsfinaloutput>();
            GetcardRes objcardres2 = new GetcardRes();
            M2PAPICreateCardModelOutput objcardres3 = new M2PAPICreateCardModelOutput();
            objcardres = (List<cardDetailsfinaloutput>)await result.ReadAsync<cardDetailsfinaloutput>();
            objcardres2.cardDetail = objcardres.FirstOrDefault();
            objcardres3.cardRes = objcardres2;
            return objcardres3;
        }

        public async Task<IEnumerable<GetCustResFinalOutput>> CreateCustomer([FromBody] M2PAPICreateCustomerModelInput ObjClass)
        {
            var procedureName = "UspM2PCreateCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("Recordstatus", ObjClass.OM2PCustomer.Recordstatus, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPCustomerID", ObjClass.OM2PCustomer.DTPCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("M2PCustomerID", ObjClass.OM2PCustomer.M2PCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgNameTitle", ObjClass.OM2PCustomer.CustomerTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgName", ObjClass.OM2PCustomer.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.OM2PCustomer.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("IncomeTaxPan", ObjClass.OM2PCustomer.PAN, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress1", ObjClass.OM2PCustomer.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress2", ObjClass.OM2PCustomer.CommunicationAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress3", ObjClass.OM2PCustomer.CommunicationAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationLocation", ObjClass.OM2PCustomer.CommunicationAddressLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCityName", ObjClass.OM2PCustomer.CommunicationAddressCity, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPincode", ObjClass.OM2PCustomer.CommunicationAddressPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.OM2PCustomer.CommunicationAddressState, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.OM2PCustomer.CommunicationAddressDistrict, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationMobileNo", ObjClass.OM2PCustomer.MobileNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationEmailid", ObjClass.OM2PCustomer.CustomerEmail, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress1", ObjClass.OM2PCustomer.PermanentAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress2", ObjClass.OM2PCustomer.PermanentAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress3", ObjClass.OM2PCustomer.PermanentAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentLocation", ObjClass.OM2PCustomer.PermanentAddressLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentCityName", ObjClass.OM2PCustomer.PermanentAddressCity, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentPincode", ObjClass.OM2PCustomer.PermanentAddressPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentStateId", ObjClass.OM2PCustomer.PermanentAddressState, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PermanentDistrictId", ObjClass.OM2PCustomer.PermanentAddressDistrict, DbType.Int32, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.OM2PCustomer.ApplicationNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new M2PAPICreateCustomerModelOutput();
            storedProcedureResult.custRes = (List<GetCustResFinalOutput>)await result.ReadAsync<GetCustResFinalOutput>();

            //STFCCreateCustomerModelOutput sTFCCreateCustomerModelOutput = new STFCCreateCustomerModelOutput();

            List<GetCustResFinalOutput> objcustre = new List<GetCustResFinalOutput>();
            GetCustResFinalOutput objcustres = new GetCustResFinalOutput();

            //sTFCCreateCustomerModelOutput.custRes = storedProcedureResult.custRes;
            objcustres.responseMessage = storedProcedureResult.custRes.FirstOrDefault().responseMessage;
            objcustres.responseCode = storedProcedureResult.custRes.FirstOrDefault().responseCode;
            objcustres.dtpCustomerId = storedProcedureResult.custRes.FirstOrDefault().dtpCustomerId;
            objcustres.M2PCustomerID = storedProcedureResult.custRes.FirstOrDefault().M2PCustomerID;
            objcustre.Add(objcustres);
            return objcustre;
        }
    }


}
