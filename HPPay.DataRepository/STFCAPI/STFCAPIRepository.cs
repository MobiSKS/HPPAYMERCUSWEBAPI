using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.Card;
using HPPay.DataModel.STFCAPI;
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

namespace HPPay.DataRepository.STFCAPI
{

    public class STFCAPIRepository : ISTFCAPIRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public STFCAPIRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetCustResFinalOutput> >CreateCustomer([FromBody] STFCCreateCustomerModelInput ObjClass)
        {
            var procedureName = "UspSTFCCreateCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("RecordStatus", ObjClass.OSTFCCustomer.RecordStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPCustomerID", ObjClass.OSTFCCustomer.DTPCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("STFCCustomerID", ObjClass.OSTFCCustomer.STFCCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgNameTitle", ObjClass.OSTFCCustomer.CustomerTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgName", ObjClass.OSTFCCustomer.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.OSTFCCustomer.NameonCard, DbType.String, ParameterDirection.Input);
            parameters.Add("IncomeTaxPan", ObjClass.OSTFCCustomer.PAN, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress1", ObjClass.OSTFCCustomer.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress2", ObjClass.OSTFCCustomer.CommunicationAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress3", ObjClass.OSTFCCustomer.CommunicationAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationLocation", ObjClass.OSTFCCustomer.CommunicationAddressLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCityName", ObjClass.OSTFCCustomer.CommunicationAddressCity, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPincode", ObjClass.OSTFCCustomer.CommunicationAddressPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.OSTFCCustomer.CommunicationAddressState, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.OSTFCCustomer.CommunicationAddressDistrict, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationMobileNo", ObjClass.OSTFCCustomer.MobileNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationEmailid", ObjClass.OSTFCCustomer.CustomerEmail, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress1", ObjClass.OSTFCCustomer.PermanentAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress2", ObjClass.OSTFCCustomer.PermanentAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress3", ObjClass.OSTFCCustomer.PermanentAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentCityName", ObjClass.OSTFCCustomer.PermanentAddressCity, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentPincode", ObjClass.OSTFCCustomer.PermanentAddressPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentStateId", ObjClass.OSTFCCustomer.PermanentAddressState, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PermanentDistrictId", ObjClass.OSTFCCustomer.PermanentAddressDistrict, DbType.Int32, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.OSTFCCustomer.ApplicationNumber, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

                var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new STFCCreateCustomerModelOutput();
            storedProcedureResult.custRes = (List<GetCustResFinalOutput>)await result.ReadAsync<GetCustResFinalOutput>();

           //STFCCreateCustomerModelOutput sTFCCreateCustomerModelOutput = new STFCCreateCustomerModelOutput();

           List<GetCustResFinalOutput> objcustre = new List<GetCustResFinalOutput>();
            GetCustResFinalOutput objcustres = new GetCustResFinalOutput();

            //sTFCCreateCustomerModelOutput.custRes = storedProcedureResult.custRes;
            objcustres.responseMessage = storedProcedureResult.custRes.FirstOrDefault().responseMessage;
            objcustres.responseCode = storedProcedureResult.custRes.FirstOrDefault().responseCode;
            objcustres.dtpCustomerId = storedProcedureResult.custRes.FirstOrDefault().dtpCustomerId;
            objcustres.stfcCustomerID = storedProcedureResult.custRes.FirstOrDefault().stfcCustomerID;
            objcustre.Add(objcustres);
            return objcustre;
        }

        public async Task<STFCCreateCardModelOutput> CreateCard([FromBody] STFCCreateCardModelInput ObjClass)
        {
            var procedureName = "UspSTFCCreateCard";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleFormType", ObjClass.VehicleFormType, DbType.String, ParameterDirection.Input);
            parameters.Add("STFCCustomerID", ObjClass.STFCCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPCustomerID", ObjClass.DTPCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Recordstatus", ObjClass.Recordstatus, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleRegistrationNumber", ObjClass.CardDetail.VehicleRegistrationNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CreditDailysaleLimit", ObjClass.CardDetail.CreditDailysaleLimit, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("TransactionDate", ObjClass.CardDetail.TransactionDate, DbType.String, ParameterDirection.Input);
            parameters.Add("AssetSerialNumber", ObjClass.CardDetail.AssetSerialNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleAssetType", ObjClass.CardDetail.VehicleAssetType, DbType.String, ParameterDirection.Input);
            parameters.Add("ItemsEnabledDiesel", ObjClass.CardDetail.ItemsEnabledDiesel, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            List<cardDetailsfinaloutput> objcardres = new List<cardDetailsfinaloutput>();
            GetcardRes objcardres2 = new GetcardRes();
            STFCCreateCardModelOutput objcardres3 = new STFCCreateCardModelOutput();
            objcardres = (List<cardDetailsfinaloutput>)await result.ReadAsync<cardDetailsfinaloutput>();
            objcardres3.cardRes = objcardres2;
            objcardres2.cardDetail = objcardres.FirstOrDefault();           
            return objcardres3;
        }


        public async Task<STFCAPIUpdateStatusModelMainOutput> UpdateStatus([FromBody] STFCUpdateStatusModelInput ObjClass)
        {
            var procedureName = "UspSTFCUpdateStatus";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("ApplicabilityCustomerCard", ObjClass.ApplicabilityCustomerCard, DbType.String, ParameterDirection.Input);
            parameters.Add("DTPCustomerID", ObjClass.DTPCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNumber", ObjClass.CardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNumber", ObjClass.ReferenceNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CardCustomerStatusCode", ObjClass.CardCustomerStatusCode, DbType.String, ParameterDirection.Input);
            parameters.Add("PreviousCardStatusCode", ObjClass.PreviousCardStatusCode, DbType.String, ParameterDirection.Input);
            parameters.Add("StatusChangeReasonCode", ObjClass.StatusChangeReasonCode, DbType.String, ParameterDirection.Input);
            //parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new STFCAPIUpdateStatusModelOutput();
           
            STFCAPIUpdateStatusModelMainOutput STFCUpdateobj = new STFCAPIUpdateStatusModelMainOutput();
            List<GetcustomerCardStatusRes> getcustomerCardStatus = new List<GetcustomerCardStatusRes>();
            List<entityDetail> entityDetailobject = new List<entityDetail>();
            getcustomerCardStatus = (List<GetcustomerCardStatusRes>)await result.ReadAsync<GetcustomerCardStatusRes>();
            entityDetailobject = (List<entityDetail>)await result.ReadAsync<entityDetail>();
            storedProcedureResult.entityDetails = entityDetailobject.FirstOrDefault();
              storedProcedureResult.customerCardStatusRes = getcustomerCardStatus.FirstOrDefault();
            STFCUpdateobj.responseCode = storedProcedureResult.customerCardStatusRes.responseCode;
            STFCUpdateobj.responseMessage = storedProcedureResult.customerCardStatusRes.responseMessage;
            STFCUpdateobj.entityDetails = storedProcedureResult.entityDetails;

            return STFCUpdateobj;
        }


        public async Task<STFCAPIGetConsumptionDataModelOutput> GetConsumptionData([FromBody] STFCGetConsumptionDataModelInput ObjClass)
        {
            var procedureName = "UspSTFCGetConsumptionData";
            var parameters = new DynamicParameters();
          
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            var storedProcedureResult = new STFCAPIGetConsumptionDataModelOutput();
            storedProcedureResult.headerDetails = (List<headerDetail>)await result.ReadAsync<headerDetail>();
            storedProcedureResult.consumptionRes = (List<GetconsumptionRes>)await result.ReadAsync<GetconsumptionRes>();
            storedProcedureResult.transactionsDetails = (List<transactionsDetail>)await result.ReadAsync<transactionsDetail>();

            STFCAPIGetConsumptionDataModelOutput STFCobj = new STFCAPIGetConsumptionDataModelOutput();
            STFCobj.headerDetails = storedProcedureResult.headerDetails;
            STFCobj.consumptionRes = storedProcedureResult.consumptionRes;
            STFCobj.transactionsDetails = storedProcedureResult.transactionsDetails;
            return STFCobj;
        }

        public async Task<STFCGetCardHotlistStatusModelOutput> GetCardHotlistStatus([FromBody] STFCGetCardHotlistStatusModelInput ObjClass)
        {
            var procedureName = "UspSTFCGetCardHotlistStatus";
            var parameters = new DynamicParameters();
            
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            var storedProcedureResult = new STFCGetCardHotlistStatusModelOutput();
            storedProcedureResult.cardHotListResponse = (List<cardHotListResponses>)await result.ReadAsync<cardHotListResponses>();
            storedProcedureResult.cards = (List<Getcards>)await result.ReadAsync<Getcards>();

            STFCGetCardHotlistStatusModelOutput STFCobj = new STFCGetCardHotlistStatusModelOutput();
            STFCobj.cardHotListResponse = storedProcedureResult.cardHotListResponse;
            STFCobj.cards = storedProcedureResult.cards;

            return STFCobj;
        }
        public async Task<IEnumerable<STFCMAPSTFCCardlessModelOutput>> MAPSTFCCardless([FromBody] STFCMAPSTFCCardlessModelInput ObjClass)
        {
            var procedureName = "UspSTFCMAPSTFCCardless";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNumber", ObjClass.CardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobile", ObjClass.Mobile, DbType.String, ParameterDirection.Input);
            parameters.Add("ManipulationType", ObjClass.ManipulationType, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<STFCMAPSTFCCardlessModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<STFCGetAllTransactionsModelFInalOutput> GetAllTransactions([FromBody] STFCGetAllTransactionsModelInput ObjClass)
        {
            var procedureName = "UspSTFCGetAllTransactions";
            var parameters = new DynamicParameters();
            parameters.Add("customerID", ObjClass.customerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new STFCGetAllTransactionsModelOutput();
            storedProcedureResult.TransactionDetail = (List<TransactionDetails>)await result.ReadAsync<TransactionDetails>();
            storedProcedureResult.lstTransactionDetailInfo = (List<TransactionDetailInfo>)await result.ReadAsync<TransactionDetailInfo>();
            STFCGetAllTransactionsModelFInalOutput STFCobj = new STFCGetAllTransactionsModelFInalOutput();
            STFCobj.customerId = storedProcedureResult.TransactionDetail.FirstOrDefault().customerId;
            STFCobj.startDate = storedProcedureResult.TransactionDetail.FirstOrDefault().startDate;
            STFCobj.endDate = storedProcedureResult.TransactionDetail.FirstOrDefault().endDate;
            STFCobj.txnCount = storedProcedureResult.TransactionDetail.FirstOrDefault().txnCount;
            STFCobj.responseMessage = storedProcedureResult.TransactionDetail.FirstOrDefault().responseMessage;
            STFCobj.responseCode = storedProcedureResult.TransactionDetail.FirstOrDefault().responseCode;
            STFCobj.lstTransactionDetailInfo = new List<TransactionDetailInfo>();
            STFCobj.lstTransactionDetailInfo.AddRange(storedProcedureResult.lstTransactionDetailInfo);
            //STFCobj.lstTransactionDetailInfo.FirstOrDefault().terminalCode = storedProcedureResult.lstTransactionDetailInfo.FirstOrDefault().terminalCode;

            return STFCobj;
        }
        public async Task<STFCGetHotlistReactivateReasonModelOutput> GetHotlistReactivateReason([FromBody] STFCGetHotlistReactivateReasonModelInput ObjClass)
        {
            var procedureName = "UspSTFCGetHotlistReactivateReason";
            var parameters = new DynamicParameters();
            parameters.Add("flag", ObjClass.flag, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new STFCGetHotlistReactivateReasonModelOutput();
            storedProcedureResult.lstResponse = (List<GetResponse>)await result.ReadAsync<GetResponse>();
            storedProcedureResult.lstReasonInfo = (List<ReasonInfo>)await result.ReadAsync<ReasonInfo>();
            
            STFCGetHotlistReactivateReasonModelOutput objsfl = new STFCGetHotlistReactivateReasonModelOutput();
            objsfl.lstResponse = storedProcedureResult.lstResponse;
            //objsfl.responseCode = storedProcedureResult.responseCode;
            //objsfl.responseMessage = storedProcedureResult.responseMessage;
            objsfl.lstReasonInfo = storedProcedureResult.lstReasonInfo;
            return objsfl;

        }

        public async Task<STFCGetCustomerHotlistStatusModelOutput> GetCustomerHotlistStatus([FromBody] STFCGetCustomerHotlistStatusModelInput ObjClass)
        {
            var procedureName = "UspSTFCGetCustomerHotlistStatus";
            var parameters = new DynamicParameters();
            parameters.Add("DtpCustomerId", ObjClass.DtpCustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("StfcCustomerId", ObjClass.StfcCustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new STFCGetCustomerHotlistStatusModelOutput();
            List<GetcustomerHotlistDeatils> objstfc= new List<GetcustomerHotlistDeatils>();
            objstfc= (List<GetcustomerHotlistDeatils>)await result.ReadAsync<GetcustomerHotlistDeatils>();
            storedProcedureResult.customerHotlistDeatils = objstfc.FirstOrDefault();
            STFCGetCustomerHotlistStatusModelOutput objsfl = new STFCGetCustomerHotlistStatusModelOutput();
            objsfl.customerHotlistDeatils = storedProcedureResult.customerHotlistDeatils;
            return objsfl;

        }


        public async Task<STFCDehotlistCustomerWithPANModelOutput> DehotlistCustomerWithPAN([FromBody] STFCDehotlistCustomerWithPANModelInput ObjClass)
        {
            var procedureName = "UspSTFCDehotlistCustomerWithPAN";
            var parameters = new DynamicParameters();
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("DtpCustomerId", ObjClass.DtpCustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("StfcCustomerId", ObjClass.StfcCustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("PAN", ObjClass.PAN, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            var storedProcedureResult = new STFCDehotlistCustomerWithPANModelOutput();
            List<GetdehotlistCust> objcust = new List<GetdehotlistCust>();
            objcust = (List<GetdehotlistCust>)await result.ReadAsync<GetdehotlistCust>();
            storedProcedureResult.dehotlistCust = objcust.FirstOrDefault();
            STFCDehotlistCustomerWithPANModelOutput objsfl = new STFCDehotlistCustomerWithPANModelOutput();
            objsfl.dehotlistCust = storedProcedureResult.dehotlistCust;
            return objsfl;

        }
        //public async Task<STFCUpdateCardLimitinBulkModelOutput> UpdateCardLimitinBulk([FromBody] STFCUpdateCardLimitinBulkModelInput ObjClass)
        //{
        //    var procedureName = "UspSTFCUpdateCardLimitinBulk";
        //    var parameters = new DynamicParameters();
        //    //parameters.Add("CardNumber", ObjClass.lstCardLimitDetails.FirstOrDefault().CardNumber, DbType.String, ParameterDirection.Input);
        //    //parameters.Add("CreditDailySaleLimit", ObjClass.lstCardLimitDetails.FirstOrDefault().CreditDailySaleLimit, DbType.String, ParameterDirection.Input);
        //    parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
        //    parameters.Add("UserName", ObjClass.Username, DbType.String, ParameterDirection.Input);
        //    using var connection = _context.CreateConnection();
        //    var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
        //    var storedProcedureResult = new STFCUpdateCardLimitinBulkModelOutput();
        //    storedProcedureResult.lstCardLimitDetails = (List<CardLimitDetails>)await result.ReadAsync<CardLimitDetails>();

        //    STFCUpdateCardLimitinBulkModelOutput objsfl = new STFCUpdateCardLimitinBulkModelOutput();
        //    objsfl.lstCardLimitDetails = storedProcedureResult.lstCardLimitDetails;
        //    return objsfl;

        //}



        public async Task<STFCUpdateCardLimitinBulkModelOutput> UpdateCardLimitinBulk([FromBody] STFCUpdateCardLimitinBulkModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeCardLimitDetails");
            dtDBR.Columns.Add("CardNumber", typeof(string));
            dtDBR.Columns.Add("CreditDailySaleLimit", typeof(decimal));

            var procedureName = "UspSTFCUpdateCardLimitinBulk";
            var parameters = new DynamicParameters();

            foreach (TypeCardLimitDetails ObjDCM in ObjClass.lstCardLimitDetails)
            {
                DataRow dr = dtDBR.NewRow();
                dr["CardNumber"] = ObjDCM.CardNumber;
                dr["CreditDailySaleLimit"] = ObjDCM.CreditDailySaleLimit;
               
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }
            parameters.Add("UserName", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("lstCardLimitDetails", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new STFCUpdateCardLimitinBulkModelOutput();
            var CardLimitDetailsobj = (List<CardLimitDetailsresponse>)await result.ReadAsync<CardLimitDetailsresponse>();
            storedProcedureResult.lstCardLimitDetails = new List<CardLimitDetails>();
            storedProcedureResult.lstCardLimitDetails = (List<CardLimitDetails>)await result.ReadAsync<CardLimitDetails>();
            //List<ABC> aBCs = new List<ABC>();
            
            STFCUpdateCardLimitinBulkModelOutput objsfl = new STFCUpdateCardLimitinBulkModelOutput();
            objsfl.lstCardLimitDetails = storedProcedureResult.lstCardLimitDetails;
            objsfl.responseCode = storedProcedureResult.responseCode;
            objsfl.responseMessage = storedProcedureResult.responseMessage;
            objsfl.responseMessage = CardLimitDetailsobj[0].responseMessage;
            objsfl.responseCode = CardLimitDetailsobj[0].responseCode;
            return objsfl;

        }

    }
}
