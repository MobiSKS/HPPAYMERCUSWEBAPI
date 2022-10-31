using HPPay.DataModel.IdfcAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using HPPay.DataRepository.DBDapper;
using Dapper;
using HPPay.DataModel;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace HPPay.DataRepository.IdfcAPI
{
    public class IdfcApiRepository: IIdfcApiRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        public IdfcApiRepository(DapperContext context, IHostingEnvironment hostingEnvironment, IConfiguration configuration) // , IConfiguration configuration
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        public async Task<IEnumerable<UpdateCCMSBAlanceForIdfcCustomer>> UpdateCCMSBAlanceForIdfcCustomer([FromBody] FastagConfirmOtpReQuest ObjClass,string NetAmount,string DiscountAmount)
        {
            var procedureName = "UspUpdateCCMSBAlanceForIdfcCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
            parameters.Add("PaidAmount", NetAmount, DbType.String, ParameterDirection.Input);
            parameters.Add("InvoiceAmount", ObjClass.Invoiceamount, DbType.String, ParameterDirection.Input);
            parameters.Add("DiscountAmount", DiscountAmount, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNumber", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("VechileNo", "", DbType.String, ParameterDirection.Input);
            parameters.Add("FastagNo", ObjClass.TagId, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("TxnId", ObjClass.TxnRefId, DbType.String, ParameterDirection.Input);
            parameters.Add("Invoiceid", ObjClass.Invoiceid, DbType.String, ParameterDirection.Input);
            parameters.Add("Batchid", ObjClass.Batchid, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);

            parameters.Add("Invoicedate", ObjClass.Invoicedate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("Productid", ObjClass.Productid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Odometerreading", ObjClass.Odometerreading, DbType.String, ParameterDirection.Input);
            parameters.Add("TransType", ObjClass.TransType, DbType.String, ParameterDirection.Input);
            parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
            parameters.Add("DCSTokenNo", ObjClass.DCSTokenNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Stan", ObjClass.Stan, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Paymentmode", ObjClass.BankID.ToString(), DbType.String, ParameterDirection.Input);
            parameters.Add("Gatewayname", "IDFC", DbType.String, ParameterDirection.Input);
            parameters.Add("Bankname", "IDFC", DbType.String, ParameterDirection.Input);
            parameters.Add("Paycode", "", DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCCMSBAlanceForIdfcCustomer>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateCCMSBAlanceForIdfcCustomer>> RefundCCMSBAlanceForIdfcCustomer([FromBody] FastagRefundPaymentReQuest ObjClass)
        {
            var procedureName = "UspRefundCCMSBAlanceForIdfcCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("TxnId", ObjClass.OrgTxnId, DbType.String, ParameterDirection.Input);           
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
            parameters.Add("Invoiceid", ObjClass.Invoiceid, DbType.String, ParameterDirection.Input);
            parameters.Add("Batchid", ObjClass.Batchid, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);

            parameters.Add("Invoicedate", ObjClass.Invoicedate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("Productid", ObjClass.Productid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Odometerreading", ObjClass.Odometerreading, DbType.String, ParameterDirection.Input);
            parameters.Add("TransType", ObjClass.TransType, DbType.String, ParameterDirection.Input);
            parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
            parameters.Add("DCSTokenNo", ObjClass.DCSTokenNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Stan", ObjClass.Stan, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Paymentmode", ObjClass.BankID.ToString(), DbType.String, ParameterDirection.Input);
            parameters.Add("Gatewayname", "IDFC", DbType.String, ParameterDirection.Input);
            parameters.Add("Bankname", "IDFC", DbType.String, ParameterDirection.Input);
            parameters.Add("Paycode", "", DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCCMSBAlanceForIdfcCustomer>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<IdfcApiRequestResponseOutput>> InsertIdfcApiRequestResponse([FromBody] IdfcApiRequestResponseInput ObjClass)
        {
            var procedureName = "UspInsertIdfcApiRequestResponse";
            var parameters = new DynamicParameters();
            parameters.Add("ApiRequestUrL", ObjClass.ApiRequestUrL, DbType.String, ParameterDirection.Input);
            parameters.Add("ApiRequest", ObjClass.ApiRequest, DbType.String, ParameterDirection.Input);
            parameters.Add("ApiResponse", ObjClass.ApiResponse, DbType.String, ParameterDirection.Input);
            parameters.Add("Remarks", ObjClass.Remarks, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<IdfcApiRequestResponseOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InsertFastagIdfcApiRequestOutput>> InsertIdfcFastagApiRequest( InsertFastagIdfcApiRequestInput ObjClass)
        {
            var procedureName = "UspInsertIdfcFastagApiRequest";
            var parameters = new DynamicParameters();
            parameters.Add("ApiRequestUrL", ObjClass.ApiRequestUrL, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalID", ObjClass.TerminalID, DbType.String, ParameterDirection.Input);
            parameters.Add("BankID", ObjClass.BankID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Vrn", ObjClass.Vrn, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.String, ParameterDirection.Input);
            parameters.Add("NetAmount", ObjClass.NetAmount, DbType.String, ParameterDirection.Input);
            parameters.Add("DiscountAmount", ObjClass.DiscountAmount, DbType.String, ParameterDirection.Input);
            parameters.Add("Remarks", ObjClass.Remarks, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);

            parameters.Add("TxnId", ObjClass.TxnId, DbType.String, ParameterDirection.Input);
            parameters.Add("TagId", ObjClass.TagId, DbType.String, ParameterDirection.Input);
            parameters.Add("OrgTxnId", ObjClass.OrgTxnId, DbType.String, ParameterDirection.Input);
            parameters.Add("OrgTxnTime", ObjClass.OrgTxnTime, DbType.String, ParameterDirection.Input);
            parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
            parameters.Add("TxnTime", ObjClass.TxnTime, DbType.String, ParameterDirection.Input);

            parameters.Add("TxnNo", ObjClass.TxnNo, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Invoiceid", ObjClass.Invoiceid, DbType.String, ParameterDirection.Input);
            parameters.Add("Batchid", ObjClass.Batchid, DbType.Int32, ParameterDirection.Input);

            parameters.Add("Invoicedate", ObjClass.Invoicedate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("Productid", ObjClass.Productid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Odometerreading", ObjClass.Odometerreading, DbType.String, ParameterDirection.Input);
            parameters.Add("TransType", ObjClass.TransType, DbType.String, ParameterDirection.Input);
            parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
            parameters.Add("DCSTokenNo", ObjClass.DCSTokenNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Stan", ObjClass.Stan, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Paymentmode", ObjClass.Paymentmode, DbType.String, ParameterDirection.Input);
            parameters.Add("Gatewayname", ObjClass.Gatewayname, DbType.String, ParameterDirection.Input);
            parameters.Add("Bankname", ObjClass.Bankname, DbType.String, ParameterDirection.Input);
            parameters.Add("Paycode", ObjClass.Paycode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertFastagIdfcApiRequestOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async void UpdateIdfcFastagApiRequest( UpdateFastagIdfcApiRequestInput ObjClass)
        {
            var procedureName = "UspUpdateIdfcFastagApiRequest";
            var parameters = new DynamicParameters();
            parameters.Add("RequestId", ObjClass.RequestId, DbType.String, ParameterDirection.Input);         
            parameters.Add("Remarks", ObjClass.Remarks, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
             await connection.QueryAsync<UpdateFastagIdfcApiRequestOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async void InsertIdfcApiRequestResponseDetail([FromBody] IdfcApiRequestResponseDetailInput ObjClass)
        {
            var procedureName = "UspInsertIdfcApiRequestResponseDetail";
            var parameters = new DynamicParameters();
            parameters.Add("Id", ObjClass.RqId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ApiRequestUrL", ObjClass.ApiRequestUrL, DbType.String, ParameterDirection.Input);
            parameters.Add("ApiRequest", ObjClass.ApiRequest, DbType.String, ParameterDirection.Input);
            parameters.Add("ApiResponse", ObjClass.ApiResponse, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqMobileNo", ObjClass.ReqMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqVrn", ObjClass.ReqVrn, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqAmount", ObjClass.ReqAmount, DbType.String, ParameterDirection.Input);

            parameters.Add("ReqNetAmount", ObjClass.ReqNetAmount, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqDiscount", ObjClass.ReqDiscount, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqEntityId", ObjClass.ReqEntityId, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqPosId", ObjClass.ReqPosId, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqTxnTime", ObjClass.ReqTxnTime, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqIIN", ObjClass.ReqIIN, DbType.String, ParameterDirection.Input);

            parameters.Add("ReqChkSm", ObjClass.ReqChkSm, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqOtp", ObjClass.ReqOtp, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqOrgTxnId", ObjClass.ReqOrgTxnId, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqOrgTxnTime", ObjClass.ReqOrgTxnTime, DbType.String, ParameterDirection.Input);
            parameters.Add("ReqTxnId", ObjClass.ReqTxnId, DbType.String, ParameterDirection.Input);
            parameters.Add("ResTxnId", ObjClass.ResTxnId, DbType.String, ParameterDirection.Input);

            parameters.Add("ResTxnNo", ObjClass.ResTxnNo, DbType.String, ParameterDirection.Input);
            parameters.Add("ResCode", ObjClass.ResCode, DbType.String, ParameterDirection.Input);
            parameters.Add("ResMsg", ObjClass.ResMsg, DbType.String, ParameterDirection.Input);
            parameters.Add("RestagId", ObjClass.RestagId, DbType.String, ParameterDirection.Input);
            parameters.Add("vrn", ObjClass.vrn, DbType.String, ParameterDirection.Input);
            parameters.Add("Remarks", ObjClass.Remarks, DbType.String, ParameterDirection.Input);

            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("IsPaymentSuccess", ObjClass.IsPaymentSuccess, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IsRefundSuccess", ObjClass.IsRefundSuccess, DbType.Int32, ParameterDirection.Input);
           
            using var connection = _context.CreateConnection();
            var res = await connection.QueryAsync<IdfcApiRequestResponseDetailOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<IdfcCheckFastagInvoiceIdBatchIdExistOutput>> CheckFastagInvoiceIdBatchIdExist(IdfcCheckFastagInvoiceIdBatchIdExistInput obj)
        {
            var procedureName = "uspCheckFastagInvoiceIdBatchIdExist";
            var parameters = new DynamicParameters();
            parameters.Add("Invoiceid", obj.Invoiceid, DbType.String, ParameterDirection.Input);
            parameters.Add("Batchid", obj.Batchid, DbType.String, ParameterDirection.Input);
            parameters.Add("TransTypeId", 538, DbType.String, ParameterDirection.Input);
            parameters.Add("RecordType", obj.RecordType, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", obj.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalId", obj.TerminalID, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", obj.UserId, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", obj.UserAgent, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<IdfcCheckFastagInvoiceIdBatchIdExistOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerInsertFastTagModelOutput>> InsertCustomerFastTag([FromBody] CustomerInsertFastTagModelInput ObjClass)
        {
            //var dtDBR = new DataTable("UserDTNoofCards");
            //dtDBR.Columns.Add("CardIdentifier", typeof(string));
            //dtDBR.Columns.Add("VechileNo", typeof(string));
            //dtDBR.Columns.Add("VehicleMake", typeof(string));
            //dtDBR.Columns.Add("VehicleType", typeof(string));
            //dtDBR.Columns.Add("YearOfRegistration", typeof(int));

            //var procedureName = "UspInsertCustomer";
            var procedureName = "UspInsertCustomerFastTag";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerType", ObjClass.CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", ObjClass.CustomerSubtype, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ZonalOffice", ObjClass.ZonalOffice, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RegionalOffice", ObjClass.RegionalOffice, DbType.Int32, ParameterDirection.Input);
            //parameters.Add("DateOfApplication", ObjClass.DateOfApplication, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("IsHPPAYSettlement", ObjClass.IsHPPAYSettlement, DbType.Int32, ParameterDirection.Input);
            parameters.Add("SalesArea", ObjClass.SalesArea, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgNameTitle", ObjClass.IndividualOrgNameTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgName", ObjClass.IndividualOrgName, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfBusinessEntity", ObjClass.TypeOfBusinessEntity, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ResidenceStatus", ObjClass.ResidenceStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("IncomeTaxPan", ObjClass.IncomeTaxPan, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress1", ObjClass.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress2", ObjClass.CommunicationAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress3", ObjClass.CommunicationAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationLocation", ObjClass.CommunicationLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCityName", ObjClass.CommunicationCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPincode", ObjClass.CommunicationPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationPhoneNo", ObjClass.CommunicationPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationFax", ObjClass.CommunicationFax, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationMobileNo", ObjClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationEmailid", ObjClass.CommunicationEmailid, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress1", ObjClass.PermanentAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress2", ObjClass.PermanentAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress3", ObjClass.PermanentAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentLocation", ObjClass.PermanentLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentCityName", ObjClass.PermanentCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentPincode", ObjClass.PermanentPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentStateId", ObjClass.PermanentStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PermanentDistrictId", ObjClass.PermanentDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PermanentPhoneNo", ObjClass.PermanentPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentFax", ObjClass.PermanentFax, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialTitle", ObjClass.KeyOfficialTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialIndividualInitials", ObjClass.KeyOfficialIndividualInitials, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialFirstName", ObjClass.KeyOfficialFirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialMiddleName", ObjClass.KeyOfficialMiddleName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialLastName", ObjClass.KeyOfficialLastName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialFax", ObjClass.KeyOfficialFax, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDesignation", ObjClass.KeyOfficialDesignation, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialEmail", ObjClass.KeyOfficialEmail, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialPhoneNo", ObjClass.KeyOfficialPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDOA", ObjClass.KeyOfficialDOA, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("KeyOfficialMobile", ObjClass.KeyOfficialMobile, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDOB", ObjClass.KeyOfficialDOB, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("KeyOfficialSecretQuestion", ObjClass.KeyOfficialSecretQuestion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("KeyOfficialSecretAnswer", ObjClass.KeyOfficialSecretAnswer, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialTypeOfFleet", ObjClass.KeyOfficialTypeOfFleet, DbType.Int32, ParameterDirection.Input);
            parameters.Add("KeyOfficialCardAppliedFor", ObjClass.KeyOfficialCardAppliedFor, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialApproxMonthlySpendsonVechile1", ObjClass.KeyOfficialApproxMonthlySpendsonVechile1, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("KeyOfficialApproxMonthlySpendsonVechile2", ObjClass.KeyOfficialApproxMonthlySpendsonVechile2, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("AreaOfOperation", ObjClass.AreaOfOperation, DbType.String, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedHCV", ObjClass.FleetSizeNoOfVechileOwnedHCV, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedLCV", ObjClass.FleetSizeNoOfVechileOwnedLCV, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedMUVSUV", ObjClass.FleetSizeNoOfVechileOwnedMUVSUV, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedCarJeep", ObjClass.FleetSizeNoOfVechileOwnedCarJeep, DbType.Int16, ParameterDirection.Input);
            //parameters.Add("NoOfCards", ObjClass.NoOfCards, DbType.Int32, ParameterDirection.Input);
            //parameters.Add("FeePaymentsCollectFeeWaiver", ObjClass.FeePaymentsCollectFeeWaiver, DbType.Int16, ParameterDirection.Input);
            //parameters.Add("FeePaymentsChequeNo", ObjClass.FeePaymentsChequeNo, DbType.String, ParameterDirection.Input);
            //parameters.Add("FeePaymentsChequeDate", ObjClass.FeePaymentsChequeDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("TierOfCustomer", ObjClass.TierOfCustomer, DbType.Int32, ParameterDirection.Input);
            parameters.Add("TypeOfCustomer", ObjClass.TypeOfCustomer, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RBEId", ObjClass.RBEId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("PanCardRemarks", ObjClass.PanCardRemarks, DbType.String, ParameterDirection.Input);
            //if (ObjClass.NoOfCards > 0 && ObjClass.ObjCardDetail != null)
            //{
            //    foreach (CardDetail ObjCardDetails in ObjClass.ObjCardDetail)
            //    {
            //        DataRow dr = dtDBR.NewRow();
            //        dr["CardIdentifier"] = ObjCardDetails.CardIdentifier;
            //        dr["VechileNo"] = ObjCardDetails.VechileNo;
            //        dr["VehicleMake"] = ObjCardDetails.VehicleMake;
            //        dr["VehicleType"] = ObjCardDetails.VehicleType;
            //        dr["YearOfRegistration"] = ObjCardDetails.YearOfRegistration;

            //        dtDBR.Rows.Add(dr);
            //        dtDBR.AcceptChanges();
            //    }
            //}
            //parameters.Add("CardDetails", dtDBR, DbType.Object, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerInsertFastTagModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FastTagCustomerKYCModelOutput>> UploadCustomerKYCFastTag([FromForm] FastTagCustomerKYCModelInput ObjClass)
        {
            string FileNamePathAgreementWithBank = string.Empty;
            var ImageFileNamePathAgreementWithBank = ObjClass.AgreementWithBank;
            if (ImageFileNamePathAgreementWithBank.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg" };
                var ext = ImageFileNamePathAgreementWithBank.FileName.Substring(ImageFileNamePathAgreementWithBank.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathAgreementWithBank = "/CustomerKYCFastTagImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.IdProofType + "_" + ImageFileNamePathAgreementWithBank.FileName;
                    string filePathAgreementWithBank = contentRootPath + FileNamePathAgreementWithBank;
                    //var fileStream = new FileStream(filePathIdProofFront, FileMode.Create);
                    //ImageFileNameIdProofFront.CopyTo(fileStream);
                    using (var fileStream = new FileStream(filePathAgreementWithBank, FileMode.Create))
                    {
                        ImageFileNamePathAgreementWithBank.CopyTo(fileStream);
                    }
                }
            }


            string FileNamePathAddressProof = string.Empty;
            var ImageFileNamePathAddressProof = ObjClass.AddressProof;
            if (ImageFileNamePathAddressProof.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg" };
                var ext = ImageFileNamePathAddressProof.FileName.Substring(ImageFileNamePathAddressProof.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathAddressProof = "/CustomerKYCFastTagImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.IdProofType + "_" + ImageFileNamePathAddressProof.FileName;
                    string filePathAddressProof = contentRootPath + FileNamePathAddressProof;
                    //var fileStream = new FileStream(filePathIdProofBack, FileMode.Create);
                    //ImageFileNameIdProofBack.CopyTo(fileStream);


                    using (var fileStream = new FileStream(filePathAddressProof, FileMode.Create))
                    {
                        ImageFileNamePathAddressProof.CopyTo(fileStream);
                    }

                }
            }

            string FileNamePathPANCardOfFirm = string.Empty;
            var ImageFileNamePathPANCardOfFirm = ObjClass.PANCardOfFirm;
            if (ImageFileNamePathPANCardOfFirm.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg" };
                var ext = ImageFileNamePathPANCardOfFirm.FileName.Substring(ImageFileNamePathPANCardOfFirm.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathPANCardOfFirm = "/CustomerKYCFastTagImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.IdProofType + "_" + ImageFileNamePathPANCardOfFirm.FileName;
                    string filePathPANCardOfFirm = contentRootPath + FileNamePathPANCardOfFirm;
                    //var fileStream = new FileStream(filePathAddressProofFront, FileMode.Create);
                    //ImageFileNameAddressProofFront.CopyTo(fileStream);

                    using (var fileStream = new FileStream(filePathPANCardOfFirm, FileMode.Create))
                    {
                        ImageFileNamePathPANCardOfFirm.CopyTo(fileStream);
                    }
                }
            }


            string FileNamePathIncorporationProof = string.Empty;
            var ImageFileNamePathIncorporationProof = ObjClass.IncorporationProof;
            if (ImageFileNamePathIncorporationProof.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg" };
                var ext = ImageFileNamePathIncorporationProof.FileName.Substring(ImageFileNamePathIncorporationProof.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathIncorporationProof = "/CustomerKYCFastTagImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.IdProofType + "_" + ImageFileNamePathIncorporationProof.FileName;
                    string filePathIncorporationProof = contentRootPath + FileNamePathIncorporationProof;
                    //var fileStream = new FileStream(filePathAddressProofBack, FileMode.Create);
                    //ImageFileNameAddressProofBack.CopyTo(fileStream);

                    using (var fileStream = new FileStream(filePathIncorporationProof, FileMode.Create))
                    {
                        ImageFileNamePathIncorporationProof.CopyTo(fileStream);
                    }
                }
            }


            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("IdProofType", ObjClass.IdProofType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IdProofDocumentNo", ObjClass.IdProofDocumentNo, DbType.String, ParameterDirection.Input);
            parameters.Add("AgreementWithBank", FileNamePathAgreementWithBank, DbType.String, ParameterDirection.Input);
            parameters.Add("AddressProof", FileNamePathAddressProof, DbType.String, ParameterDirection.Input);
            parameters.Add("AddressProofType", ObjClass.AddressProofType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("AddressProofDocumentNo", ObjClass.AddressProofDocumentNo, DbType.String, ParameterDirection.Input);
            parameters.Add("PANCardOfFirm", FileNamePathPANCardOfFirm, DbType.String, ParameterDirection.Input);
            parameters.Add("IncorporationProof", FileNamePathIncorporationProof, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

            var procedureName = "UspInsertCustomerKYCFastTag";
            return await connection.QueryAsync<FastTagCustomerKYCModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetBankCreditLimitModelOutput>> GetBankCreditLimit([FromBody] GetBankCreditLimitModelInput ObjClass)
        {
            var procedureName = "UspGetBankCreditLimit";

            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<GetBankCreditLimitModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<BankCreditLimitRequestModelOutput>> BankCreditLimitRequest([FromBody] BankCreditLimitRequestModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeBankCreditLimit");
            dtDBR.Columns.Add("CustomerID", typeof(string));
            dtDBR.Columns.Add("CCMSRechargeType", typeof(string));
            dtDBR.Columns.Add("RequestedCreditLimit", typeof(string));

            if (ObjClass.ObjTypeBankCreditLimit != null)
            {
            foreach (TypeBankCreditLimit ObjDetail in ObjClass.ObjTypeBankCreditLimit)
            {
                DataRow dr = dtDBR.NewRow();
                dr["CustomerID"] = ObjDetail.CustomerID;
                dr["CCMSRechargeType"] = ObjDetail.CCMSRechargeType;
                dr["RequestedCreditLimit"] = ObjDetail.RequestedCreditLimit;
                
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }
            }

            var procedureName = "UspBankCreditLimitRequest";
            var parameters = new DynamicParameters();   
            parameters.Add("TypeBankCreditLimit", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
           // parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BankCreditLimitRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }


        public async Task<IEnumerable<GetBankCreditLimitStatusDetailsModelOutput>> GetBankCreditLimitStatusDetail([FromBody] GetBankCreditLimitStatusDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetBankCreditLimitStatusDetail";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("Status", ObjClass.Status, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetBankCreditLimitStatusDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetFastagCreditLimitApprovalModelOutput>> GetFastagCreditLimitApproval([FromBody] GetFastagCreditLimitApprovalModelInput ObjClass)
        {
            var procedureName = "UspGetFastagCreditLimitApproval";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<GetFastagCreditLimitApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetBankEnrollmentStatusDetailModelOutput>> GetBankEnrollmentStatusDetail([FromBody] GetBankEnrollmentStatusDetailModelInput ObjClass)
        {
            var procedureName = "UspGetBankEnrollmentStatusDetail";
            var parameters = new DynamicParameters();
            parameters.Add("Status", ObjClass.Status, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetBankEnrollmentStatusDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        

        public async Task<IEnumerable<UpdateFastagCreditLimitApprovalModelOutput>> UpdateFastagCreditLimitApproval([FromBody] UpdateFastagCreditLimitApprovalModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeFastagCreditLimitApproval");
            dtDBR.Columns.Add("CustomerID", typeof(string));
            dtDBR.Columns.Add("RequestedCreditLimit", typeof(string));
            dtDBR.Columns.Add("CCMSRechargeType", typeof(string));
            dtDBR.Columns.Add("Remarks", typeof(string));
           

            var procedureName = "UspUpdateFastagCreditLimitApproval";
            var parameters = new DynamicParameters();


            foreach (GetTypeFastagCreditLimitApproval ObjComco in ObjClass.TypeFastagCreditLimitApproval)
            {
                DataRow dr = dtDBR.NewRow();
                dr["CustomerID"] = ObjComco.CustomerID;
                dr["RequestedCreditLimit"] = ObjComco.RequestedCreditLimit;
                dr["CCMSRechargeType"] = ObjComco.CCMSRechargeType;
                dr["Remarks"] = ObjComco.Remarks;


                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }

            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);

            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            //parameters.Add("Comments", ObjClass.Comments, DbType.String, ParameterDirection.Input);

            parameters.Add("TypeFastagCreditLimitApproval", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateFastagCreditLimitApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetFastagBankApprovalDetailModelOutput>> GetFastagBankApprovalDetail([FromBody] GetFastagBankApprovalDetailModelInput ObjClass)
        {   
            var procedureName = "UspGetFastagBankApprovalDetail";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<GetFastagBankApprovalDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<UpdateFastagBankApprovalModelOutput>> UpdateFastagBankApproval([FromBody] UpdateFastagBankApprovalModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeFastagBankApproval");
            dtDBR.Columns.Add("FormNumber", typeof(string));
            dtDBR.Columns.Add("Comments", typeof(string));


            var procedureName = "UspUpdateFastagBankApproval";
            var parameters = new DynamicParameters();


            foreach (GetTypeFastagBankApproval ObjComco in ObjClass.TypeFastagBankApproval)
            {
                DataRow dr = dtDBR.NewRow();
                dr["FormNumber"] = ObjComco.FormNumber;
                dr["Comments"] = ObjComco.Comments;


                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }

            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);

            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            //parameters.Add("Comments", ObjClass.Comments, DbType.String, ParameterDirection.Input);

            parameters.Add("TypeFastagBankApproval", dtDBR, DbType.Object, ParameterDirection.Input);
            //  parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateFastagBankApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<IEnumerable<GetStatementofAccountModelOutput>> GetStatementofAccount([FromBody] GetStatementofAccountModelInput ObjClass)
        {
            var procedureName = "UspGetStatementofAccount";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetStatementofAccountModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<GetUnverfiedCustomerDetailbyFormNumberModelOutput> GetUnverfiedCustomerDetailbyFormNumber([FromBody] GetUnverfiedCustomerDetailbyFormNumberModelInput ObjClass)
        {
            var procedureName = "UspGetFastagUnverfiedCustomerDetailbyFormNumber";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetUnverfiedCustomerDetailbyFormNumberModelOutput();
            storedProcedureResult.GetCustomerDetails = (List<GetCustomerDetailsModelOutput>)await result.ReadAsync<GetCustomerDetailsModelOutput>();
            storedProcedureResult.CustomerKYCDetails = (List<CustomerKYCDetailsModelOutput>)await result.ReadAsync<CustomerKYCDetailsModelOutput>();
            return storedProcedureResult;
        }



        public async Task<IEnumerable<FastagCustomerUpdateModelOutput>> UpdateCustomer([FromBody] FastagCustomerUpdateModelInput ObjClass)
        {
            
            var procedureName = "UspUpdateRawCustomerFastag";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("ZonalOffice", ObjClass.ZonalOffice, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RegionalOffice", ObjClass.RegionalOffice, DbType.Int32, ParameterDirection.Input);
            parameters.Add("DateOfApplication", ObjClass.DateOfApplication, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("SalesArea", ObjClass.SalesArea, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgNameTitle", ObjClass.IndividualOrgNameTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("IndividualOrgName", ObjClass.IndividualOrgName, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfBusinessEntity", ObjClass.TypeOfBusinessEntity, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ResidenceStatus", ObjClass.ResidenceStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("IncomeTaxPan", ObjClass.IncomeTaxPan, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress1", ObjClass.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress2", ObjClass.CommunicationAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress3", ObjClass.CommunicationAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationLocation", ObjClass.CommunicationLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCityName", ObjClass.CommunicationCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPincode", ObjClass.CommunicationPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationPhoneNo", ObjClass.CommunicationPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationFax", ObjClass.CommunicationFax, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationMobileNo", ObjClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationEmailid", ObjClass.CommunicationEmailid, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress1", ObjClass.PermanentAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress2", ObjClass.PermanentAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress3", ObjClass.PermanentAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentLocation", ObjClass.PermanentLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentCityName", ObjClass.PermanentCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentPincode", ObjClass.PermanentPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentStateId", ObjClass.PermanentStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PermanentDistrictId", ObjClass.PermanentDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PermanentPhoneNo", ObjClass.PermanentPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentFax", ObjClass.PermanentFax, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialTitle", ObjClass.KeyOfficialTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialIndividualInitials", ObjClass.KeyOfficialIndividualInitials, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialFirstName", ObjClass.KeyOfficialFirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialMiddleName", ObjClass.KeyOfficialMiddleName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialLastName", ObjClass.KeyOfficialLastName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialFax", ObjClass.KeyOfficialFax, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDesignation", ObjClass.KeyOfficialDesignation, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialEmail", ObjClass.KeyOfficialEmail, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialPhoneNo", ObjClass.KeyOfficialPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDOA", ObjClass.KeyOfficialDOA, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("KeyOfficialMobile", ObjClass.KeyOfficialMobile, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDOB", ObjClass.KeyOfficialDOB, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("KeyOfficialSecretQuestion", ObjClass.KeyOfficialSecretQuestion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("KeyOfficialSecretAnswer", ObjClass.KeyOfficialSecretAnswer, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialTypeOfFleet", ObjClass.KeyOfficialTypeOfFleet, DbType.Int32, ParameterDirection.Input);
            parameters.Add("KeyOfficialCardAppliedFor", ObjClass.KeyOfficialCardAppliedFor, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialApproxMonthlySpendsonVechile1", ObjClass.KeyOfficialApproxMonthlySpendsonVechile1, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("KeyOfficialApproxMonthlySpendsonVechile2", ObjClass.KeyOfficialApproxMonthlySpendsonVechile2, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("AreaOfOperation", ObjClass.AreaOfOperation, DbType.String, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedHCV", ObjClass.FleetSizeNoOfVechileOwnedHCV, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedLCV", ObjClass.FleetSizeNoOfVechileOwnedLCV, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedMUVSUV", ObjClass.FleetSizeNoOfVechileOwnedMUVSUV, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FleetSizeNoOfVechileOwnedCarJeep", ObjClass.FleetSizeNoOfVechileOwnedCarJeep, DbType.Int16, ParameterDirection.Input);
            
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);

            //parameters.Add("TierOfCustomer", ObjClass.TierOfCustomer, DbType.Int32, ParameterDirection.Input);
            //parameters.Add("TypeOfCustomer", ObjClass.TypeOfCustomer, DbType.Int32, ParameterDirection.Input);

            parameters.Add("CustomerSubtype", ObjClass.CustomerSubtype, DbType.Int32, ParameterDirection.Input);


            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("PanCardRemarks", ObjClass.PanCardRemarks, DbType.String, ParameterDirection.Input);
            
            
            
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<FastagCustomerUpdateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }






    }
}
