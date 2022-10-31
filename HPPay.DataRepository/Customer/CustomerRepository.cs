using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.Customer;
using HPPay.DataRepository.DBDapper;
using HPPay.Infrastructure.CommonClass;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


//using Microsoft.Extensions.Configuration;

namespace HPPay.DataRepository.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        //private readonly Variables ObjVariable;
        public CustomerRepository(DapperContext context, IHostingEnvironment hostingEnvironment) // , IConfiguration configuration
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            //ObjVariable = new Variables(configuration);
        }

        public async Task<IEnumerable<GetFormNumberModelOutput>> GetFormNumber([FromBody] GetFormNumberModelInput ObjClass)
        {
            var procedureName = "UspGetFormNumber";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetFormNumberModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CheckFormNumberModelOutput>> CheckFormNumber([FromBody] CheckFormNumberModelInput ObjClass)
        {
            var procedureName = "UspCheckFormNumber";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckFormNumberModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CheckMobileNumberModelOutput>> CheckMobileNumber([FromBody] CheckMobileNumberModelInput ObjClass)
        {
            var procedureName = "UspCheckMobileNumber";
            var parameters = new DynamicParameters();
            parameters.Add("CommunicationMobileNo", ObjClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckMobileNumberModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CheckEmailIdModelOutput>> CheckEmailId([FromBody] CheckEmailIdModelInput ObjClass)
        {
            var procedureName = "UspCheckEmailId";
            var parameters = new DynamicParameters();
            parameters.Add("CommunicationEmailid", ObjClass.CommunicationEmailid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckEmailIdModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerCheckPancardModelOutput>> CheckPancard([FromBody] CustomerCheckPancardModelInput ObjClass)
        {
            var procedureName = "UspCheckPancard";
            var parameters = new DynamicParameters();
            parameters.Add("IncomeTaxPan", ObjClass.IncomeTaxPan, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerCheckPancardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetCustomerTypeModelOutput>> GetCustomerType([FromBody] GetCustomerTypeModelInput ObjClass)
        {
            var procedureName = "UspGetCustomerType";
            var parameters = new DynamicParameters();
            parameters.Add("CTFlag", ObjClass.CTFlag, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCustomerTypeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<IEnumerable<GetCustomerSubTypeModelOutput>> GetCustomerSubType([FromBody] GetCustomerSubTypeModelInput ObjClass)
        {
            var procedureName = "UspGetCustomerSubType";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerTypeId", ObjClass.CustomerTypeId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCustomerSubTypeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCustomerTBEntityNameModelOutput>> GetTBEntityName([FromBody] GetCustomerTBEntityNameModelInput ObjClass)
        {
            var procedureName = "UspGetTBEntityName";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCustomerTBEntityNameModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCustomerSecretQuestionModelOutput>> GetSecretQuestion([FromBody] GetCustomerSecretQuestionModelInput ObjClass)
        {
            var procedureName = "UspGetSecretQuestion";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCustomerSecretQuestionModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCustomerTypeOfFleetModelOutput>> GetTypeOfFleet([FromBody] GetCustomerTypeOfFleetModelInput ObjClass)
        {
            var procedureName = "UspGetTypeOfFleet";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCustomerTypeOfFleetModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<CustomerInsertModelOutput>> InsertCustomer([FromBody] CustomerInsertModelInput ObjClass)
        {
            //var dtDBR = new DataTable("UserDTNoofCards");
            //dtDBR.Columns.Add("CardIdentifier", typeof(string));
            //dtDBR.Columns.Add("VechileNo", typeof(string));
            //dtDBR.Columns.Add("VehicleMake", typeof(string));
            //dtDBR.Columns.Add("VehicleType", typeof(string));
            //dtDBR.Columns.Add("YearOfRegistration", typeof(int));

            //var procedureName = "UspInsertCustomer";
            var procedureName = "UspInsertRawCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerType", ObjClass.CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", ObjClass.CustomerSubtype, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ZonalOffice", ObjClass.ZonalOffice, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RegionalOffice", ObjClass.RegionalOffice, DbType.Int32, ParameterDirection.Input);
            parameters.Add("DateOfApplication", ObjClass.DateOfApplication, DbType.DateTime, ParameterDirection.Input);
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
            return await connection.QueryAsync<CustomerInsertModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerUpdateModelOutput>> UpdateCustomer([FromBody] CustomerUpdateModelInput ObjClass)
        {
            //var dtDBR = new DataTable("UserDTNoofCards");
            //dtDBR.Columns.Add("CardIdentifier", typeof(string));
            //dtDBR.Columns.Add("VechileNo", typeof(string));
            //dtDBR.Columns.Add("VehicleMake", typeof(string));
            //dtDBR.Columns.Add("VehicleType", typeof(int));
            //dtDBR.Columns.Add("YearOfRegistration", typeof(int));

            //var procedureName = "UspUpdateCustomer";
            var procedureName = "UspUpdateRawCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerReferenceNo", ObjClass.CustomerReferenceNo, DbType.Int64, ParameterDirection.Input);
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
            //parameters.Add("NoOfCards", ObjClass.NoOfCards, DbType.Int32, ParameterDirection.Input);
            //parameters.Add("FeePaymentsCollectFeeWaiver", ObjClass.FeePaymentsCollectFeeWaiver, DbType.Int16, ParameterDirection.Input);
            //parameters.Add("FeePaymentNo", ObjClass.FeePaymentNo, DbType.String, ParameterDirection.Input);
            //parameters.Add("FeePaymentDate", ObjClass.FeePaymentDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);

            parameters.Add("TierOfCustomer", ObjClass.TierOfCustomer, DbType.Int32, ParameterDirection.Input);
            parameters.Add("TypeOfCustomer", ObjClass.TypeOfCustomer, DbType.Int32, ParameterDirection.Input);

            //if (ObjClass.NoOfCards > 0 && ObjClass.ObjCardDetail != null)
            //{
            //    foreach (UpdateCardDetail ObjCardDetails in ObjClass.ObjCardDetail)
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
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("PanCardRemarks", ObjClass.PanCardRemarks, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerUpdateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerViewOnlineFormStatusModelOutput>> ViewOnlineFormStatus([FromBody] CustomerViewOnlineFormStatusModelInput ObjClass)
        {
            var procedureName = "UspBindCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("StatusId", ObjClass.StatusId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("CustomerReferenceNo", ObjClass.CustomerReferenceNo, DbType.Int64, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerViewOnlineFormStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerKYCModelOutput>> UploadCustomerKYC([FromForm] CustomerKYCModelInput ObjClass)
        {
            string FileNamePathIdProofFront = string.Empty;
            var ImageFileNameIdProofFront = ObjClass.IdProofFront;
            if (ImageFileNameIdProofFront.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
                var ext = ImageFileNameIdProofFront.FileName.Substring(ImageFileNameIdProofFront.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathIdProofFront = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.IdProofType + "_" + ImageFileNameIdProofFront.FileName;
                    string filePathIdProofFront = contentRootPath + FileNamePathIdProofFront;
                    //var fileStream = new FileStream(filePathIdProofFront, FileMode.Create);
                    //ImageFileNameIdProofFront.CopyTo(fileStream);
                    using (var fileStream = new FileStream(filePathIdProofFront, FileMode.Create))
                    {
                        ImageFileNameIdProofFront.CopyTo(fileStream);
                    }
                }
            }


            string FileNamePathIdProofBack = string.Empty;
            var ImageFileNameIdProofBack = ObjClass.IdProofBack;
            if (ImageFileNameIdProofBack.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
                var ext = ImageFileNameIdProofBack.FileName.Substring(ImageFileNameIdProofBack.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathIdProofBack = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.IdProofType + "_" + ImageFileNameIdProofBack.FileName;
                    string filePathIdProofBack = contentRootPath + FileNamePathIdProofBack;
                    //var fileStream = new FileStream(filePathIdProofBack, FileMode.Create);
                    //ImageFileNameIdProofBack.CopyTo(fileStream);


                    using (var fileStream = new FileStream(filePathIdProofBack, FileMode.Create))
                    {
                        ImageFileNameIdProofBack.CopyTo(fileStream);
                    }

                }
            }

            string FileNamePathAddressProofFront = string.Empty;
            var ImageFileNameAddressProofFront = ObjClass.AddressProofFront;
            if (ImageFileNameAddressProofFront.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
                var ext = ImageFileNameAddressProofFront.FileName.Substring(ImageFileNameAddressProofFront.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathAddressProofFront = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.IdProofType + "_" + ImageFileNameAddressProofFront.FileName;
                    string filePathAddressProofFront = contentRootPath + FileNamePathAddressProofFront;
                    //var fileStream = new FileStream(filePathAddressProofFront, FileMode.Create);
                    //ImageFileNameAddressProofFront.CopyTo(fileStream);

                    using (var fileStream = new FileStream(filePathAddressProofFront, FileMode.Create))
                    {
                        ImageFileNameAddressProofFront.CopyTo(fileStream);
                    }
                }
            }


            string FileNamePathAddressProofBack = string.Empty;
            var ImageFileNameAddressProofBack = ObjClass.AddressProofBack;
            if (ImageFileNameAddressProofBack.Length > 0)
            {
                IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
                var ext = ImageFileNameAddressProofBack.FileName.Substring(ImageFileNameAddressProofBack.FileName.LastIndexOf('.'));
                var extension = ext.ToLower();
                if (AllowedFileExtensions.Contains(extension))
                {

                    string contentRootPath = _hostingEnvironment.ContentRootPath;
                    FileNamePathAddressProofBack = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                        + "_" + ObjClass.IdProofType + "_" + ImageFileNameAddressProofBack.FileName;
                    string filePathAddressProofBack = contentRootPath + FileNamePathAddressProofBack;
                    //var fileStream = new FileStream(filePathAddressProofBack, FileMode.Create);
                    //ImageFileNameAddressProofBack.CopyTo(fileStream);

                    using (var fileStream = new FileStream(filePathAddressProofBack, FileMode.Create))
                    {
                        ImageFileNameAddressProofBack.CopyTo(fileStream);
                    }
                }
            }
            string FileNamePathLetterHead = string.Empty;
            if (ObjClass.LetterHead != null)
            {
                
                var ImageFileNamePathLetterHead = ObjClass.LetterHead;
                if (ImageFileNamePathLetterHead.Length > 0)
                {
                    IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".png", ".pdf", ".gif", ".jpeg", ".doc", ".docx" };
                    var ext = ImageFileNamePathLetterHead.FileName.Substring(ImageFileNamePathLetterHead.FileName.LastIndexOf('.'));
                    var extension = ext.ToLower();
                    if (AllowedFileExtensions.Contains(extension))
                    {

                        string contentRootPath = _hostingEnvironment.ContentRootPath;
                        FileNamePathLetterHead = "/CustomerKYCImage/" + ObjClass.FormNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss")
                            + "_" + ImageFileNamePathLetterHead.FileName;
                        string filePathLetterHead = contentRootPath + FileNamePathLetterHead;
                        //var fileStream = new FileStream(filePathAddressProofBack, FileMode.Create);
                        //ImageFileNameAddressProofBack.CopyTo(fileStream);

                        using (var fileStream = new FileStream(filePathLetterHead, FileMode.Create))
                        {
                            ImageFileNamePathLetterHead.CopyTo(fileStream);
                        }
                    }
                }
            }


            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("IdProofType", ObjClass.IdProofType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IdProofDocumentNo", ObjClass.IdProofDocumentNo, DbType.String, ParameterDirection.Input);
            parameters.Add("IdProofFront", FileNamePathIdProofFront, DbType.String, ParameterDirection.Input);
            parameters.Add("IdProofBack", FileNamePathIdProofBack, DbType.String, ParameterDirection.Input);
            parameters.Add("AddressProofType", ObjClass.AddressProofType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("AddressProofDocumentNo", ObjClass.AddressProofDocumentNo, DbType.String, ParameterDirection.Input);
            parameters.Add("AddressProofFront", FileNamePathAddressProofFront, DbType.String, ParameterDirection.Input);
            parameters.Add("AddressProofBack", FileNamePathAddressProofBack, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("LetterHead", FileNamePathLetterHead, DbType.String, ParameterDirection.Input);
            parameters.Add("OthersDocumentNoIDProof", ObjClass.OthersDocumentNoIDProof, DbType.String, ParameterDirection.Input);
            parameters.Add("OthersDocumentNoAddressProof", ObjClass.OthersDocumentNoAddressProof, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

            var procedureName = "UspInsertCustomerKYC";
            return await connection.QueryAsync<CustomerKYCModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerApprovalModelOutput>> ApproveRejectCustomer([FromBody] CustomerApprovalModelInput ObjClass)
        {
            var procedureName = "UspUserApproveCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("Comments", ObjClass.Comments, DbType.String, ParameterDirection.Input);
            parameters.Add("Approvalstatus", ObjClass.Approvalstatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerGetVehicleTypeModelOutput>> GetVehicleType([FromBody] CustomerGetVehicleTypeModelInput ObjClass)
        {
            var procedureName = "UspVehicleType";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerGetVehicleTypeModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<CustomerFeewaiverApprovalModelOutput>> ApproveRejectFeewaiver([FromBody] CustomerFeewaiverApprovalModelInput ObjClass)
        {
            var procedureName = "UspApproveRejectFeewaiver";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("Comments", ObjClass.Comments, DbType.String, ParameterDirection.Input);
            parameters.Add("Approvalstatus", ObjClass.Approvalstatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerFeewaiverApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetApproveFeeWaiverDetailModelOutput> GetApproveFeeWaiverDetail([FromBody] GetApproveFeeWaiverDetailModelInput ObjClass)
        {
            var procedureName = "UspGetApproveFeeWaiverDetail";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetApproveFeeWaiverDetailModelOutput();
            storedProcedureResult.GetApproveFeeWaiverBasicDetail = (List<GetApproveFeeWaiverBasicDetailModelOutput>)await result.ReadAsync<GetApproveFeeWaiverBasicDetailModelOutput>();
            storedProcedureResult.GetApproveFeeWaiverCardDetail = (List<GetApproveFeeWaiverCardDetailModelOutput>)await result.ReadAsync<GetApproveFeeWaiverCardDetailModelOutput>();
            return storedProcedureResult;

            //return await connection.QueryAsync<GetApproveFeeWaiverDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<CustomerGetCustomerReferenceNoModelOutput>> GetNameandFormNumberbyReferenceNo([FromBody] CustomerGetCustomerReferenceNoModelInput ObjClass)
        {
            var procedureName = "UspGetNameandFormNumberbyReferenceNo";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("Type", ObjClass.Type, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerGetCustomerReferenceNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<CustomerDetailsModelOutput> GetCustomerByCustomerId([FromBody] CustomerGetByCustomerIdModelInput ObjClass)
        {
            var procedureName = "UspGetCustomerDetailByCustomerId";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new CustomerDetailsModelOutput();
            storedProcedureResult.GetCustomerDetails = (List<GetCustomerDetailsModelOutput>)await result.ReadAsync<GetCustomerDetailsModelOutput>();
            storedProcedureResult.CustomerKYCDetails = (List<CustomerKYCDetailsModelOutput>)await result.ReadAsync<CustomerKYCDetailsModelOutput>();
            return storedProcedureResult;
            //return await connection.QueryAsync<CustomerDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerGetCustomerNameModelOutput>> GetCustomerNameByCustomerId([FromBody] CustomerGetByCustomerIdModelInput ObjClass)
        {
            var procedureName = "UspGetCustomerNameByCustomerId";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerGetCustomerNameModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<CustomerDetailsModelOutput> GetCustomerDetails([FromBody] CustomerDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetCustomerDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerTypeId", ObjClass.CustomerTypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerSubtypeId", ObjClass.CustomerSubtypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeID", ObjClass.ZonalOfficeID, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeID", ObjClass.RegionalOfficeID, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfBusinessEntity", ObjClass.TypeOfBusinessEntity, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentStateId", ObjClass.PermanentStateId, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentDistrictId", ObjClass.PermanentDistrictId, DbType.String, ParameterDirection.Input);
            parameters.Add("Email", ObjClass.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfFleetId", ObjClass.TypeOfFleetId, DbType.String, ParameterDirection.Input);
            parameters.Add("FeePaymentsCollectFeeWaiver", ObjClass.FeePaymentsCollectFeeWaiver, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", ObjClass.ReferenceId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerReferenceNo", ObjClass.CustomerReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatusId", ObjClass.CustomerStatusId, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedonFromDate", ObjClass.ApprovedonFromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedonToDate", ObjClass.ApprovedonToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatusFeewaiverID", ObjClass.CustomerStatusFeewaiverID, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedBy", ObjClass.FeewaiverApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedOnFromDate", ObjClass.FeewaiverApprovedOnFromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedOnToDate", ObjClass.FeewaiverApprovedOnToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new CustomerDetailsModelOutput();
            storedProcedureResult.GetCustomerDetails = (List<GetCustomerDetailsModelOutput>)await result.ReadAsync<GetCustomerDetailsModelOutput>();
            storedProcedureResult.CustomerKYCDetails = (List<CustomerKYCDetailsModelOutput>)await result.ReadAsync<CustomerKYCDetailsModelOutput>();
            return storedProcedureResult;
        }


        public async Task<CustomerDetailsModelOutput> GetRawCustomerDetails([FromBody] CustomerDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetRawCustomerDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerTypeId", ObjClass.CustomerTypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerSubtypeId", ObjClass.CustomerSubtypeId, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOfficeID", ObjClass.ZonalOfficeID, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeID", ObjClass.RegionalOfficeID, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfBusinessEntity", ObjClass.TypeOfBusinessEntity, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentStateId", ObjClass.PermanentStateId, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentDistrictId", ObjClass.PermanentDistrictId, DbType.String, ParameterDirection.Input);
            parameters.Add("Email", ObjClass.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfFleetId", ObjClass.TypeOfFleetId, DbType.String, ParameterDirection.Input);
            parameters.Add("FeePaymentsCollectFeeWaiver", ObjClass.FeePaymentsCollectFeeWaiver, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", ObjClass.ReferenceId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerReferenceNo", ObjClass.CustomerReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatusId", ObjClass.CustomerStatusId, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedonFromDate", ObjClass.ApprovedonFromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedonToDate", ObjClass.ApprovedonToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerStatusFeewaiverID", ObjClass.CustomerStatusFeewaiverID, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedBy", ObjClass.FeewaiverApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedOnFromDate", ObjClass.FeewaiverApprovedOnFromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("FeewaiverApprovedOnToDate", ObjClass.FeewaiverApprovedOnToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();

            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new CustomerDetailsModelOutput();
            storedProcedureResult.GetCustomerDetails = (List<GetCustomerDetailsModelOutput>)await result.ReadAsync<GetCustomerDetailsModelOutput>();
            storedProcedureResult.CustomerKYCDetails = (List<CustomerKYCDetailsModelOutput>)await result.ReadAsync<CustomerKYCDetailsModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<BindPendingCustomerModelOutput>> BindPendingCustomer([FromBody] BindPendingCustomerModelInput ObjClass)
        {
            var procedureName = "UspBindPendingCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("StateId", ObjClass.StateId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("Createdby", ObjClass.Createdby, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BindPendingCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<BindPendingCustomerModelOutput>> BindUnverfiedCustomer([FromBody] BindPendingCustomerModelInput ObjClass)
        {
            var procedureName = "UspBindUnverfiedCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("StateId", ObjClass.StateId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("Createdby", ObjClass.Createdby, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BindPendingCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<BindPendingCustomerModelOutput>> BindUnverfiedCustomerForFeeWaiver([FromBody] BindPendingCustomerModelInput ObjClass)
        {
            var procedureName = "UspBindUnverfiedCustomerForFeeWaiver";
            var parameters = new DynamicParameters();
            parameters.Add("StateId", ObjClass.StateId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("Createdby", ObjClass.Createdby, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BindPendingCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<CustomerDetailsModelOutput> GetPendingCustomerDetailbyFormNumber([FromBody] CustomerDetailsbyFormNumberModelInput ObjClass)
        {
            var procedureName = "UspGetPendingCustomerDetailbyFormNumber";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new CustomerDetailsModelOutput();
            storedProcedureResult.GetCustomerDetails = (List<GetCustomerDetailsModelOutput>)await result.ReadAsync<GetCustomerDetailsModelOutput>();
            storedProcedureResult.CustomerKYCDetails = (List<CustomerKYCDetailsModelOutput>)await result.ReadAsync<CustomerKYCDetailsModelOutput>();
            return storedProcedureResult;
        }

        public async Task<CustomerDetailsModelOutput> GetUnverfiedCustomerDetailbyFormNumber([FromBody] CustomerDetailsbyFormNumberModelInput ObjClass)
        {
            var procedureName = "UspGetUnverfiedCustomerDetailbyFormNumber";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new CustomerDetailsModelOutput();
            storedProcedureResult.GetCustomerDetails = (List<GetCustomerDetailsModelOutput>)await result.ReadAsync<GetCustomerDetailsModelOutput>();
            storedProcedureResult.CustomerKYCDetails = (List<CustomerKYCDetailsModelOutput>)await result.ReadAsync<CustomerKYCDetailsModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<GetControlCardNumberModelOutput>> GetControlCardNumber([FromBody] GetControlCardNumberModelInput ObjClass)
        {
            var procedureName = "UspGetControlCardNumber";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetControlCardNumberModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<CustomerGetMerchantForCardMappingModelOutput>> GetMerchantForCardMapping([FromBody] CustomerGetMerchantForCardMappingModelInput ObjClass)
        {
            var procedureName = "UspGetMerchantForCardMapping";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("StateID", ObjClass.StateID, DbType.String, ParameterDirection.Input);
            parameters.Add("DistrictID", ObjClass.DistrictID, DbType.String, ParameterDirection.Input);
            parameters.Add("City", ObjClass.City, DbType.String, ParameterDirection.Input);
            parameters.Add("HighwayName", ObjClass.HighwayName, DbType.String, ParameterDirection.Input);
            parameters.Add("HighwayNo1", ObjClass.HighwayNo1, DbType.String, ParameterDirection.Input);
            parameters.Add("HighwayNo2", ObjClass.HighwayNo2, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerGetMerchantForCardMappingModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerGetCardListFromCustomerIdModelOutput>> GetCardListFromCustomerId([FromBody] CustomerGetCardListFromCustomerIdModelInput ObjClass)
        {
            var procedureName = "UspGetCardListFromCustomerId";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerGetCardListFromCustomerIdModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<CustomerGetCustomerDetailsForMappingCardMerchantModelOutput> GetCustomerDetailsForMappingCardMerchant([FromBody] CustomerGetCustomerDetailsForMappingCardMerchantModelInput ObjClass)
        {
            var procedureName = "UspGetCustomerDetailsForMappingCardMerchant";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new CustomerGetCustomerDetailsForMappingCardMerchantModelOutput();
            storedProcedureResult.GetCustomerDetails = (List<CustomerGetCustomerBasicDetailsForMappingCardMerchantModelOutput>)await result.ReadAsync<CustomerGetCustomerBasicDetailsForMappingCardMerchantModelOutput>();
            storedProcedureResult.GetCustomerCardDetails = (List<CustomerGetCustomerCardDetailsForMappingCardMerchantModelOutput>)await result.ReadAsync<CustomerGetCustomerCardDetailsForMappingCardMerchantModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<CustomerAddCustomerCardMerchantMappingModelOutput>> AddCustomerCardMerchantMapping([FromBody] CustomerAddCustomerCardMerchantMappingModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeCardMerchantMap");
            dtDBR.Columns.Add("CardNo", typeof(string));
            dtDBR.Columns.Add("MerchantId", typeof(string));
            dtDBR.Columns.Add("CustomerID", typeof(string));

            foreach (CardMerchantMapModelInput ObjCardLimits in ObjClass.ObjCardMerchantMap)
            {
                DataRow dr = dtDBR.NewRow();
                dr["CardNo"] = ObjCardLimits.CardNo;
                dr["MerchantId"] = ObjCardLimits.MerchantId;
                dr["CustomerID"] = ObjCardLimits.CustomerID;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }

            var procedureName = "UspAddCustomerCardMerchantMapping";
            var parameters = new DynamicParameters();

            //parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Status", ObjClass.Status, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UpdateMapCardMerchant", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAddCustomerCardMerchantMappingModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<CustomerGetMappingUserCardstoMerchantsModelOutput>> GetMappingUserCardstoMerchants([FromBody] CustomerGetMappingUserCardstoMerchantsModelInput ObjClass)
        {
            var procedureName = "UspGetMappingUserCardstoMerchants";
            var parameters = new DynamicParameters();
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerGetMappingUserCardstoMerchantsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerGetCustomerDetailsForSearchModelOutput>> GetCustomerDetailsForSearch([FromBody] CustomerGetByCustomerIdModelInput ObjClass)
        {
            var procedureName = "UspGetCustomerDetailsForSearch";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerGetCustomerDetailsForSearchModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<CustomerGetCustomerBalanceInfoModelOutput>> GetCustomerBalanceInfo([FromBody] CustomerGetCustomerBalanceInfoModelInput ObjClass)
        {
            var procedureName = "UspGetCustomerBalanceInfo";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerGetCustomerBalanceInfoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerGetCustomerCardWiseBalancesModelOutput>> GetCustomerCardWiseBalances([FromBody] CustomerGetCustomerCardWiseBalancesModelInput ObjClass)
        {
            var procedureName = "UspGetCustomerCardWiseBalances";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerGetCustomerCardWiseBalancesModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerGetCcmsBalanceInfoForCustomerIdModelOutput>> GetCcmsBalanceInfoForCustomerId([FromBody] CustomerGetCcmsBalanceInfoForCustomerIdModelInput ObjClass)
        {
            var procedureName = "UspGetCcmsBalanceInfoForCustomerId";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerGetCcmsBalanceInfoForCustomerIdModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<CustomerGetTransactionsSummaryModelOutput> GetTransactionsSummary([FromBody] CustomerGetTransactionsSummaryModelInput ObjClass)
        {
            var procedureName = "UspGetTransactionsSummary";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new CustomerGetTransactionsSummaryModelOutput();
            storedProcedureResult.GetTransactionsSaleSummary = (List<CustomerGetTransactionsSaleSummaryModelOutput>)await result.ReadAsync<CustomerGetTransactionsSaleSummaryModelOutput>();
            storedProcedureResult.GetTransactionsDetailSummary = (List<CustomerGetTransactionsDetailSummaryModelOutput>)await result.ReadAsync<CustomerGetTransactionsDetailSummaryModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<CustomerCheckPancardbyDistrictIdModelOutput>> CheckPancardbyDistrictId([FromBody] CustomerCheckPancardbyDistrictIdModelInput ObjClass)
        {
            var procedureName = "UspCheckPancardDistrictId";
            var parameters = new DynamicParameters();
            parameters.Add("IncomeTaxPan", ObjClass.IncomeTaxPan, DbType.String, ParameterDirection.Input);
            parameters.Add("DistrictId", ObjClass.DistrictId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerCheckPancardbyDistrictIdModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CheckPancardbyDistrictIdAndCustomerReferenceNoModelOutput>> CheckPancardbyDistrictIdAndCustomerReferenceNo([FromBody] CheckPancardbyDistrictIdAndCustomerReferenceNoModelInput ObjClass)
        {
            var procedureName = "UspCheckPancardDistrictIdandCustomerReferenceNo";
            var parameters = new DynamicParameters();
            parameters.Add("IncomeTaxPan", ObjClass.IncomeTaxPan, DbType.String, ParameterDirection.Input);
            parameters.Add("DistrictId", ObjClass.DistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckPancardbyDistrictIdAndCustomerReferenceNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<CustomerViewAccountStatementModelOutput> ViewAccountStatementSummary([FromBody] CustomerViewAccountStatementModelInput ObjClass)
        {
            var procedureName = "UspViewAccountStatement";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new CustomerViewAccountStatementModelOutput();
            storedProcedureResult.GetCcmsAccountSummary = (List<CcmsAccountSummaryModelOutput>)await result.ReadAsync<CcmsAccountSummaryModelOutput>();
            storedProcedureResult.GetCardTransactionDetails = (List<CardTransactionDetailsModelOutput>)await result.ReadAsync<CardTransactionDetailsModelOutput>();
            return storedProcedureResult;
        }

        public async Task<SearchCustomerandCardFormModelOutput> SearchCustomerandCardForm([FromBody] SearchCustomerandCardFormModelInput ObjClass)
        {
            var procedureName = "UspSearchCustomerandCardForm";
            var parameters = new DynamicParameters();
            parameters.Add("EntityId", ObjClass.EntityId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("StateID", ObjClass.StateID, DbType.String, ParameterDirection.Input);
            parameters.Add("CityName", ObjClass.CityName, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new SearchCustomerandCardFormModelOutput();
            storedProcedureResult.GetCustomerSearchOutput = (List<CustomerSearchModelOutput>)await result.ReadAsync<CustomerSearchModelOutput>();
            storedProcedureResult.GetCardSearchOutput = (List<CardSearchModelOutput>)await result.ReadAsync<CardSearchModelOutput>();
            return storedProcedureResult;
        }
        //public async Task<GetNameandFormNumberbyCustomerIdModelOutput> GetNameandFormNumberbyCustomerId([FromBody] GetNameandFormNumberbyCustomerIdModelInput ObjClass)
        //{
        //    var procedureName = "UspGetNameandFormNumberbyCustomerId";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
        //    using var connection = _context.CreateConnection();
        //    var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
        //    var storedProcedureResult = new GetNameandFormNumberbyCustomerIdModelOutput();
        //    storedProcedureResult.GetStatusOutput = (List<GetStatusModelOutput>)await result.ReadAsync<GetStatusModelOutput>();
        //    storedProcedureResult.GetNameandFormNumberOutput = (List<GetNameandFormNumberModelOutput>)await result.ReadAsync<GetNameandFormNumberModelOutput>();
        //    return storedProcedureResult;
        //}


        public async Task<IEnumerable<GetNameandFormNumberbyCustomerIdModelOutput>> GetNameandFormNumberbyCustomerId([FromBody] GetNameandFormNumberbyCustomerIdModelInput ObjClass)
        {
            var procedureName = "UspGetNameandFormNumberbyCustomerId";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetNameandFormNumberbyCustomerIdModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<CustomerGetCustomerReferenceNoModelOutput>> GetNameandFormNumberbyReferenceNoforAddCard([FromBody] CustomerGetCustomerReferenceNoModelInput ObjClass)
        {
            var procedureName = "UspGetNameandFormNumberbyReferenceNoforAddCard";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("Type", ObjClass.Type, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerGetCustomerReferenceNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerAddOnUserModelOutput>> CustomerAddOnUser([FromBody] CustomerAddOnUserModelInput ObjClass)
        {
            var procedureName = "UspCustomerAddOnUser";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("EmailId", ObjClass.EmailId, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerAddOnUserModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<IEnumerable<ConfigureSMSAlertsModelOutput>> ConfigureSMSAlerts([FromBody] ConfigureSMSAlertsModelInput ObjClass)
        {
            var procedureName = "UspConfigureSMSAlerts";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionID", ObjClass.TransactionID, DbType.String, ParameterDirection.Input);
            parameters.Add("Action", ObjClass.Action, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ConfigureSMSAlertsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


         public async Task<IEnumerable<GetUpdateContactPersonDetailsModelOutput>> GetUpdateContactPersonDetails(GetUpdateContactPersonDetailsModelInput objClass)
         {
            var procedureName = "UspGetUpdateContactPersonDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", objClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetUpdateContactPersonDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
         }

        
        public async Task<IEnumerable<UpdateRequestContactPersonDetailsModelOutput>> UpdateRequestContactPersonDetails([FromBody] UpdateRequestContactPersonDetailsModelInput ObjClass)
        {
            
            var procedureName = "UspUpdateRequestContactPersonDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialTitle", ObjClass.KeyOfficialTitle, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialFirstName", ObjClass.KeyOfficialFirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialMiddleName", ObjClass.KeyOfficialMiddleName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialLastName", ObjClass.KeyOfficialLastName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDesignation", ObjClass.KeyOfficialDesignation, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialPhoneNo", ObjClass.KeyOfficialPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialFax", ObjClass.KeyOfficialFax, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDOA", ObjClass.KeyOfficialDOA, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialIndividualInitial", ObjClass.KeyOfficialIndividualInitial, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDOB", ObjClass.KeyOfficialDOB, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialMobile", ObjClass.KeyOfficialMobile, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialEmail", ObjClass.KeyOfficialEmail, DbType.String, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateRequestContactPersonDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<CCMSBalAlertConfigurationOutput> GetCCMSBalAlertConfiguration([FromBody] GetCCMSBalAlertConfigurationInput ObjClass)
        {
            var procedureName = "UspCCMSBalAlertConfiguration";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            //var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            //var storedProcedureResult = new CCMSBalAlertConfigurationOutput();
            //storedProcedureResult.CCMSCustomerDetail = (List<GetCCMSCustomerDetail>)await result.ReadAsync<GetCCMSCustomerDetail>();
            //storedProcedureResult.CCMSAmountDetail = (List<GetCCMSAmountDetail>)await result.ReadAsync<GetCCMSAmountDetail>();
            //storedProcedureResult.StatusOutput = (List<StatusOutput>)await result.ReadAsync<StatusOutput>();
            //return storedProcedureResult;

            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new CCMSBalAlertConfigurationOutput();
            storedProcedureResult.CCMSCustomerDetail = (List<GetCCMSCustomerDetail>)await result.ReadAsync<GetCCMSCustomerDetail>();
            storedProcedureResult.CCMSAmountDetail = (List<GetCCMSAmountDetail>)await result.ReadAsync<GetCCMSAmountDetail>();
            //storedProcedureResult.StatusOutput = (List<StatusOutput>)await result.ReadAsync<StatusOutput>();
            return storedProcedureResult;
        }



        

        public async Task<IEnumerable<UpdateCCMSBalAlertConfigurationModelOutput>> UpdateCCMSBalAlertConfiguration(UpdateCCMSBalAlertConfigurationModelInput ObjClass)
        {
            var procedureName = "UspCCMSBalAlertConfigurationUpdate";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCCMSBalAlertConfigurationModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<RequestApproveCustomerContactPersonDetailsModelOutput>> RequestApproveCustomerContactPersonDetails([FromBody] RequestApproveCustomerContactPersonDetailsModelInput ObjClass)
        {
            var procedureName = "UspRequestApproveCustomerContactPersonDetails";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<RequestApproveCustomerContactPersonDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<RequestGetApproveCustomerContactPersonDetailsModelOutput> RequestGetApproveCustomerContactPersonDetails([FromBody] RequestGetApproveCustomerContactPersonDetailsModelInput ObjClass)
        {
            var procedureName = "UspRequestGetApproveCustomerContactPersonDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId ", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new RequestGetApproveCustomerContactPersonDetailsModelOutput();
            storedProcedureResult.ObjOldCustomerContactValue = (List<GetContactPersonDetails>)await result.ReadAsync<GetContactPersonDetails>();
            storedProcedureResult.ObjNewCustomerContactValue = (List<GetDetailRequestGetApproveCustomerContactPersonDetails>)await result.ReadAsync<GetDetailRequestGetApproveCustomerContactPersonDetails>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<ApproveCustomerContactPersonDetailsModelOutput>>ApproveCustomerContactPersonDetails([FromBody] ApproveCustomerContactPersonDetailsModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeApproveCustomerContactPersonDetails");
            dtDBR.Columns.Add("CustomerID", typeof(string));
            dtDBR.Columns.Add("Comments", typeof(string));
            var procedureName = "UspApproveCustomerContactPersonDetails";
            var parameters = new DynamicParameters();
            foreach (TypeApproveCustomerContactPersonDetails objdtl in ObjClass.TypeApproveCustomerContactPersonDetails)
            {
                DataRow dr = dtDBR.NewRow();
                dr["CustomerID"] = objdtl.CustomerID;
                dr["Comments"] = objdtl.Comments;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeApproveCustomerContactPersonDetails", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ApproveCustomerContactPersonDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ApproveCustomerAddressRequestsModelOutput>> ApproveCustomerAddressRequests([FromBody] ApproveCustomerAddressRequestsModelInput ObjClass)
        {
            var procedureName = "UspApproveCustomerAddressRequests";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ApproveCustomerAddressRequestsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetApproveCustomerAddressRequestsModelOutput> GetApproveCustomerAddressRequests([FromBody] GetApproveCustomerAddressRequestsModelInput ObjClass)
        {
            var procedureName = "UspGetApproveCustomerAddressRequests";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId ", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            var storedProcedureResult = new GetApproveCustomerAddressRequestsModelOutput();
            storedProcedureResult.ObjOldCustomerAddressValue = (List<GetCustomerAddressDetail>)await result.ReadAsync<GetCustomerAddressDetail>();
            storedProcedureResult.ObjNewCustomerAddressValue = (List<GetDetailCustomerAddressDetail>)await result.ReadAsync<GetDetailCustomerAddressDetail>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<UpdateRequestCustomerAddressModelOutput>> UpdateRequestCustomerAddress([FromBody] UpdateRequestCustomerAddressModelInput ObjClass)
        {

            var procedureName = "UspUpdateRequestCustomerAddress";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress1", ObjClass.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress2", ObjClass.CommunicationAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress3", ObjClass.CommunicationAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationLocation", ObjClass.CommunicationLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCityName", ObjClass.CommunicationCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPincode", ObjClass.CommunicationPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPhoneNo", ObjClass.CommunicationPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationMobileNo", ObjClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationFax", ObjClass.CommunicationFax, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationEmailid", ObjClass.CommunicationEmailid, DbType.String, ParameterDirection.Input);
            parameters.Add("IncomeTaxPan", ObjClass.IncomeTaxPan, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress1", ObjClass.PermanentAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress2", ObjClass.PermanentAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentAddress3", ObjClass.PermanentAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentLocation", ObjClass.PermanentLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentCityName ", ObjClass.PermanentCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentPincode", ObjClass.PermanentPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentStateId", ObjClass.PermanentStateId, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentDistrictId ", ObjClass.PermanentDistrictId, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentPhoneNo", ObjClass.PermanentPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("PermanentFax", ObjClass.PermanentFax, DbType.String, ParameterDirection.Input);
            parameters.Add("PanCardRemarks", ObjClass.PanCardRemarks, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
       


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateRequestCustomerAddressModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<ApprovalApproveCustomerAddressRequestsModelOutput>> ApprovalApproveCustomerAddressRequests([FromBody] ApprovalApproveCustomerAddressRequestsModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeApprovalApproveCustomerAddressRequests");
            dtDBR.Columns.Add("CustomerID", typeof(string));    
            dtDBR.Columns.Add("Comments", typeof(string));
            var procedureName = "UspApprovalApproveCustomerAddressRequests";
            var parameters = new DynamicParameters();

            foreach (TypeApprovalApproveCustomerAddressRequests objdtl in ObjClass.TypeApprovalApproveCustomerAddressRequests)
            {
                DataRow dr = dtDBR.NewRow();
                dr["CustomerID"] = objdtl.CustomerID;
                dr["Comments"] = objdtl.Comments;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeApprovalApproveCustomerAddressRequests", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ApprovalApproveCustomerAddressRequestsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCommunicationEmailResetPasswordModelOutput>> GetCommunicationEmailResetPassword(GetCommunicationEmailResetPasswordModelInput objClass)
        {
            var procedureName = "UspGetCommunicationEmailResetPassword";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", objClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCommunicationEmailResetPasswordModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateCommunicationEmailResetPasswordModelOutput>> UpdateCommunicationEmailResetPassword(UpdateCommunicationEmailResetPasswordModelInput objClass)
        {
            var procedureName = "UspUpdateCommunicationEmailResetPassword";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", objClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("AlternateEmailId", objClass.AlternateEmailId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCommunicationEmailResetPasswordModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CCNPinResetModelOutput>>CCNPinReset(CCNPinResetModelInput objClass)
        {
            var procedureName = "UspCCNPinReset";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", objClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNo", objClass.ControlCardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", objClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("Type", objClass.Type, DbType.Int16, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CCNPinResetModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCustomerStatusModelOutput>> GetCustomerStatus([FromBody] GetCustomerStatusModelInput ObjClass)
        {
            var procedureName = "UspGetCustomerStatus";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCustomerStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CustomerPostAuthorizationForCreditPouchModelOutput>> PostAuthorizationForCreditPouch([FromBody] CustomerPostAuthorizationForCreditPouchModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeCustomerDetails");
            dtDBR.Columns.Add("CustomerID", typeof(string));

            if (ObjClass.ObjCustomerDetail.Count() > 0 && ObjClass.ObjCustomerDetail != null)
            {
                foreach (CustomerIdForPostAuthorization ObjCustomerIds in ObjClass.ObjCustomerDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CustomerID"] = ObjCustomerIds.CustomerID;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspPostAuthorizationForCreditPouch";
            var parameters = new DynamicParameters();
            parameters.Add("ObjCustomerDetail", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("CreditPouchType", ObjClass.CreditPouchType, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerPostAuthorizationForCreditPouchModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CustomerPostAuthForCreditPouchParentCustomerModelOutput>> PostAuthForCreditPouchParentCustomer([FromBody] CustomerPostAuthForCreditPouchParentCustomerModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeCustomerDetails");
            dtDBR.Columns.Add("CustomerID", typeof(string));

            if (ObjClass.ObjCustomerDetail.Count() > 0 && ObjClass.ObjCustomerDetail != null)
            {
                foreach (CustomerIdForPostAuthorization ObjCustomerIds in ObjClass.ObjCustomerDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CustomerID"] = ObjCustomerIds.CustomerID;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspPostAuthForCreditPouchParentCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("ObjCustomerDetail", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("CreditPouchType", ObjClass.CreditPouchType, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerPostAuthForCreditPouchParentCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerGetTransactionsDetailsModelOutput>> GetTransactionsDetails([FromBody] CustomerGetTransactionsDetailsModelInput ObjClass)
        {
            var dtDBR = new DataTable("TransTypes");
            dtDBR.Columns.Add("TypeId", typeof(string));
            dtDBR.Columns.Add("TypeName", typeof(string));


            foreach (TransTypes TransTypes  in ObjClass.TransTypes)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["TypeId"] = TransTypes.TypeId;
                    dr["TypeName"] = TransTypes.TypeName;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges(); 
                }
            
            var procedureName = "UspGetTransactionsDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("TransTypes", dtDBR, DbType.Object, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerGetTransactionsDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }


        public async Task<IEnumerable<CheckNormalCustomerModelOutput>> CheckNormalCustomer([FromBody] CheckNormalCustomerModelInput ObjClass)
        {
            var procedureName = "UspCheckNormalCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckNormalCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CheckEGVCustomerModelOutput>> CheckEGVCustomer([FromBody] CheckEGVCustomerModelInput ObjClass)
        {
            var procedureName = "UspCheckEGVCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
      
            return await connection.QueryAsync<CheckEGVCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CustomerBalanceInfoDrivestarsModelOutput>> CustomerBalanceInfoDrivestars([FromBody] CustomerBalanceInfoDrivestarsModelInput ObjClass)
        {
            var procedureName = "UspCustomerBalanceInfoDrivestars";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerBalanceInfoDrivestarsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CustomerFeedbackModelOutput>> CustomerFeedback([FromBody] CustomerFeedbackModelInput ObjClass)
        {
            var procedureName = "UspCustomerFeedback";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerFeedbackModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateCustomerFeedbackModelOutput>> UpdateCustomerFeedback([FromBody] UpdateCustomerFeedbackModelInput ObjClass)
        {
            var procedureName = "UspUpdateCustomerFeedback";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("Comment", ObjClass.Comment, DbType.String, ParameterDirection.Input);
            parameters.Add("FeedbackCategoryId ", ObjClass.FeedbackCategoryId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCustomerFeedbackModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<VehicleTrackingModelOutput>> VehicleTracking([FromBody] VehicleTrackingModelInput ObjClass)
        {
            var procedureName = "UspVehicleTracking";
            var parameters = new DynamicParameters();
            parameters.Add("ZonalOffice", ObjClass.ZonalOffice, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOffice", ObjClass.RegionalOffice, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantID", ObjClass.MerchantID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("VechileNo", ObjClass.VechileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("TransTypeId", ObjClass.TransTypeId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<VehicleTrackingModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetFeedbackQuestionsModelOutput>> GetFeedbackQuestions([FromBody] GetFeedbackQuestionsModelInput ObjClass)
        {
            var procedureName = "UspGetFeedbackQuestions";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetFeedbackQuestionsModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<FeedbackSubmittedAnswersModelOutput>> FeedbackSubmittedAnswers([FromBody] FeedbackSubmittedAnswersModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeFeedbackAnswers");
            dtDBR.Columns.Add("QuesId", typeof(string));
            dtDBR.Columns.Add("QuesType", typeof(string));
            dtDBR.Columns.Add("Answers", typeof(string));


            foreach (TypeFeedbackAnswers TypeFeedbackAnswers in ObjClass.TypeFeedbackAnswers)
            {
                DataRow dr = dtDBR.NewRow();
                dr["QuesId"] = TypeFeedbackAnswers.QuesId;
                dr["QuesType"] = TypeFeedbackAnswers.QuesType;
                dr["Answers"] = TypeFeedbackAnswers.Answers;
                
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }

            var procedureName = "UspFeedbackSubmittedAnswers";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeFeedbackAnswers", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("APIReferenceNo ", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<FeedbackSubmittedAnswersModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GenerateMasterPinModelOutput>> GenerateMasterPin(GenerateMasterPinModelInput objClass)
        {
            var procedureName = "UspGenerateMasterPin";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", objClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GenerateMasterPinModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<IEnumerable<SetCustomerCardDispatchOutputModel>> SetCustomerCardDispatchAddress([FromBody] SetCustomerCardDispatchInputModel ObjClass)
        {
            var procedureName = "UspSetCustomerCardDispatchAddress";
            var parameters = new DynamicParameters();
            parameters.Add("Zonalid", ObjClass.Zonalid, DbType.String, ParameterDirection.Input);
            parameters.Add("Regionalid", ObjClass.Regionalid, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<SetCustomerCardDispatchOutputModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<CustomerCardDispatchAddresDetailsSaveOutputModel>> CustomerCardDispatchAddressDetailsSave([FromBody] CustomerCardDispatchAddresDetailsSaveInputModel ObjClass)
        {
            var dtDBR = new DataTable("TypeDispatchDetailsTable");
            dtDBR.Columns.Add("CustomerID", typeof(string));
            dtDBR.Columns.Add("Zonalid", typeof(int));
            dtDBR.Columns.Add("Reginolid", typeof(int));
            dtDBR.Columns.Add("DispatchStatus", typeof(int));


            foreach (CardDispatchAddres DispatchAddres in ObjClass.CardDispatchAddres)
            {
                DataRow dr = dtDBR.NewRow();
                dr["CustomerID"] = DispatchAddres.CustomerID;
                dr["Zonalid"] = DispatchAddres.Zonalid;
                dr["Reginolid"] = DispatchAddres.Reginolid;
                dr["DispatchStatus"] = DispatchAddres.DispatchStatus;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }


            var procedureName = "UspUpdateCustomerCardDispatchAddress";
            var parameters = new DynamicParameters();
       
            //parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeDispatchDetailsAddress", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerCardDispatchAddresDetailsSaveOutputModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TrackApplicationFormModelOutput>> TrackApplicationForm([FromBody] TrackApplicationFormModelInput ObjClass)
        {
            var procedureName = "UspTrackApplicationForm";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<TrackApplicationFormModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetFinancialsTransactionDetailsOutPutModel>> GetFinancialsTransactionDetails([FromBody] GetFinancialsTransactionDetailsInputModel ObjClass)
        {
            var procedureName = "UspGetFinancialsTransactionDetails";
            var parameters = new DynamicParameters();
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetFinancialsTransactionDetailsOutPutModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetCustomerNameAndROByCustomerIdModelOutput>> GetCustomerNameAndROByCustomerId([FromBody] GetCustomerNameAndROByCustomerIdModelInput ObjClass)
        {
            var procedureName = "UspGetCustomerNameAndROByCustomerId";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCustomerNameAndROByCustomerIdModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<ForgetPasswordByControlCardNoModelOutput>> ForgetPasswordByControlCardNo([FromBody] ForgetPasswordByControlCardNoModelInput ObjClass)
        {
            var procedureName = "UspForgetPasswordByControlCardNo";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNumber", ObjClass.ControlCardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNoPin", ObjClass.ControlCardNoPin, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ForgetPasswordByControlCardNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<NewEnrollCustomerOTPSentModelOutput>> NewEnrollCustomerOTPSent([FromBody] NewEnrollCustomerOTPSentModelInput ObjClass)
        {
            var procedureName = "UspNewEnrollCustomerOTPSent";
            var parameters = new DynamicParameters();
            parameters.Add("MobileNo", ObjClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("OTPType", ObjClass.OTPType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("EmailId", ObjClass.CommunicationEmailId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<NewEnrollCustomerOTPSentModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<NewEnrollCustomerOTPSentByCustomeridModelOutput>> NewEnrollCustomerOTPSentByCustomerid([FromBody] NewEnrollCustomerOTPSentByCustomeridModelInput ObjClass)
        {
            var procedureName = "UspNewEnrollCustomerOTPSentByCustomerid";
            var parameters = new DynamicParameters();
            //parameters.Add("MobileNo", ObjClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("OTPType", ObjClass.OTPType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            //parameters.Add("EmailId", ObjClass.CommunicationEmailId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<NewEnrollCustomerOTPSentByCustomeridModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<IEnumerable<NewEnrollCustomerOTPVerifiedModelOutput>> NewEnrollCustomerOTPVerified([FromBody] NewEnrollCustomerOTPVerifiedModelInput ObjClass)
        {
            var procedureName = "UspNewEnrollCustomerOTPVerified";
            var parameters = new DynamicParameters();
            parameters.Add("MobileNo", ObjClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("OTPType", ObjClass.OTPType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
            parameters.Add("EmailId", ObjClass.CommunicationEmailId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<NewEnrollCustomerOTPVerifiedModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<NewEnrollCustomerOTPVerifiedByCustomeridModelOutput>> NewEnrollCustomerOTPVerifiedByCustomerid([FromBody] NewEnrollCustomerOTPVerifiedByCustomeridModelInput ObjClass)
        {
            var procedureName = "UspNewEnrollCustomerOTPVerifiedByCustomerid";
            var parameters = new DynamicParameters();
            //  parameters.Add("MobileNo", ObjClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);

            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("OTPType", ObjClass.OTPType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
            //parameters.Add("EmailId", ObjClass.CommunicationEmailId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<NewEnrollCustomerOTPVerifiedByCustomeridModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }




        public async Task<IEnumerable<BindRejectedCustomerModelOutput>> UspBindRejectedCustomer([FromBody] BindRejectedCustomerModelInput ObjClass)
        {
            var procedureName = "UspBindRejectedCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("StateId", ObjClass.StateId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("Createdby", ObjClass.Createdby, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BindRejectedCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<UpdateRawCustomerSendbackModelOutput>> UpdateRawCustomerSendback([FromBody] UpdateRawCustomerSendbackModelInput ObjClass)
        {

            var procedureName = "UspUpdateRawCustomerSendback";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
         

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateRawCustomerSendbackModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


    }
}
