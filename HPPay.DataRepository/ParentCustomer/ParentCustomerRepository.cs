using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.Merchant;
using HPPay.DataModel.ParentCustomer;
using HPPay.DataRepository.DBDapper;
using HPPay.Infrastructure.CommonClass;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.ParentCustomer
{
    public class ParentCustomerRepository : IParentCustomerRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private int CustomerType = 981;
        private int CustomerSubType = 913;
        public ParentCustomerRepository(DapperContext context, IHostingEnvironment hostingEnvironment) // , IConfiguration configuration
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<IEnumerable<CreateCustomerModelOutput>> InsertParentCustomer([FromBody] CreateCustomerModelInput ObjClass)
        {
            var procedureName = "UspParentCustomerInsertRawCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", CustomerSubType, DbType.Int32, ParameterDirection.Input);
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
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("RBEId", ObjClass.RBEId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("PanCardRemarks", ObjClass.PanCardRemarks, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CreateCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetParentCustomerApprovalModelOutput>> GetParentCustomerForApproval([FromBody] GetParentCustomerApprovalModelInput ObjClass)
        {
            var procedureName = "UspGetParentCustomerForApproval";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubType", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetParentCustomerApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ActionOnParentCustomerForApprovalModelOutput>> ActionOnParentCustomerForApproval([FromBody] ActionOnParentCustomerForApprovalModelInput ObjClass)
        {
            var dtDBR = new DataTable("UT_ActionOnParentCustomerForApproval");
            dtDBR.Columns.Add("Id", typeof(string));
            dtDBR.Columns.Add("FormNumber", typeof(string));
            dtDBR.Columns.Add("Comment", typeof(string));

            if (ObjClass.ObjParentCustomerDtl != null)
            {
                foreach (ParentCustomerDetails ObjDetails in ObjClass.ObjParentCustomerDtl)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["Id"] = ObjDetails.Id;
                    dr["FormNumber"] = ObjDetails.FormNumber;
                    dr["Comment"] = ObjDetails.Comment;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }
            var procedureName = "UspActionParentCustomerForApproval";
            var parameters = new DynamicParameters();
            parameters.Add("UT_ActionOnParentCustomerForApproval", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.Int16, ParameterDirection.Input);
            parameters.Add("Approvedby", ObjClass.Approvedby, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ActionOnParentCustomerForApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetParentCustomerAuthModelOutput>> GetParentCustomerForAuth([FromBody] GetParentCustomerAuthModelInput ObjClass)
        {
            var procedureName = "UspGetParentCustomerForAuth";
            var parameters = new DynamicParameters();
            parameters.Add("FromDate", ObjClass.FromDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubType", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetParentCustomerAuthModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ActionOnParentCustomerForAuthModelOutput>> ActionOnParentCustomerForAuth([FromBody] ActionOnParentCustomerForAuthModelInput ObjClass)
        {
            var dtDBR = new DataTable("UT_ActionOnParentCustomerForAuth");
            dtDBR.Columns.Add("Id", typeof(string));
            dtDBR.Columns.Add("FormNumber", typeof(string));
            dtDBR.Columns.Add("Comment", typeof(string));
            dtDBR.Columns.Add("ReferenceId", typeof(string));

            if (ObjClass.ObjParentCustomerDtl != null)
            {
                foreach (ParentCustomerDetailsAuth ObjDetails in ObjClass.ObjParentCustomerDtl)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["Id"] = ObjDetails.Id;
                    dr["FormNumber"] = ObjDetails.FormNumber;
                    dr["Comment"] = ObjDetails.Comment;
                    dr["ReferenceId"] = ObjDetails.ReferenceId;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }
            var procedureName = "UspActionParentCustomerForAuth";
            var parameters = new DynamicParameters();
            parameters.Add("UT_ActionOnParentCustomerForAuth", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.Int16, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ActionOnParentCustomerForAuthModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetParentCustomerForUpdateModelOutput>> GetParentCustomerForUpdate([FromBody] GetParentCustomerForUpdateModelInput ObjClass)
        {
            var procedureName = "UspGetParentCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalId", ObjClass.RegionalId, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubType", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetParentCustomerForUpdateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetParentCustomerToUpdateModelOutput> GetParentCustomerToUpdate([FromBody] GetParentCustomerToUpdateModelInput ObjClass)
        {
            var procedureName = "UspGetParentCustomerToUpdate";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("RequestId", ObjClass.RequestId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubType", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetParentCustomerToUpdateModelOutput();
            storedProcedureResult.GetParentCustomerDetails = (List<GetParentCustomerDetailsModelOutput>)await result.ReadAsync<GetParentCustomerDetailsModelOutput>();
            return storedProcedureResult;

        }
        public async Task<IEnumerable<ParentCustomerUpdateModelOutput>> UpdateParentCustomer([FromBody] ParentCustomerUpdateModelInput ObjClass)
        {
            var procedureName = "UspUpdateParentCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("RequestId", ObjClass.RequestId, DbType.Int64, ParameterDirection.Input);
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
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("TierOfCustomer", ObjClass.TierOfCustomer, DbType.Int32, ParameterDirection.Input);
            parameters.Add("TypeOfCustomer", ObjClass.TypeOfCustomer, DbType.Int32, ParameterDirection.Input);
            //parameters.Add("ReferenceId", Variables.FunGenerateStringUId(), DbType.String, ParameterDirection.Input);
            parameters.Add("PanCardRemarks", ObjClass.PanCardRemarks, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ParentCustomerUpdateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetParentCustomerCardDetailsModelOutput>> GetParentCustomerCardDetails([FromBody] GetParentCustomerCardModelInput ObjClass)
        {
            var procedureName = "UspGetParentCustomerCardDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("RequestId", ObjClass.RequestId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetParentCustomerCardDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetParentCustomerDispatchDetailsModelOutput>> GetParentCustomerDispatchDetails([FromBody] GetParentCustomerDispatchModelInput ObjClass)
        {
            var procedureName = "UspGetParentCustomerDispatchDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("RequestId", ObjClass.RequestId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetParentCustomerDispatchDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetParentCustomerStatusModelOutput>> GetParentCustomerStatus([FromBody] GetParentCustomerStatusModelInput ObjClass)
        {
            var procedureName = "UspGetParentCustomerStatus";
            var parameters = new DynamicParameters();
            parameters.Add("SBUTypeId", ObjClass.SBUTypeId, DbType.Int16, ParameterDirection.Input);
            parameters.Add("ZO", ObjClass.ZO, DbType.Int16, ParameterDirection.Input);
            parameters.Add("RO", ObjClass.RO, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("FormId", ObjClass.FormId, DbType.Int64, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubType", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetParentCustomerStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<ParentCustomerReportStatusModelOutput>> GetParentCustomerReportStatus([FromBody] ParentCustomerReportStatusModelInput ObjClass)
        {
            var procedureName = "UspParentCustomerReportStatus";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("RequestId", ObjClass.RequestId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubType", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ParentCustomerReportStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<GetParentCustomerBalanceInfoModelOutput> GetParentCustomerBalanceInfo([FromBody] GetParentCustomerBalanceInfoModelInput ObjClass)
        {
            var procedureName = "UspGetParentCustomerBalanceInfo";
            var parameters = new DynamicParameters();
            parameters.Add("ParentCustomerID", ObjClass.ParentCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ChildCustomerId", ObjClass.ChildCustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubType", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetParentCustomerBalanceInfoModelOutput();
            storedProcedureResult.GetParentCustomerBalanceInfo = (List<GetParentCustomerBalanceInfo>)await result.ReadAsync<GetParentCustomerBalanceInfo>();
            storedProcedureResult.GetChildCustomerBalanceInfo = (List<GetChildCustomerBalanceInfo>)await result.ReadAsync<GetChildCustomerBalanceInfo>();
            return storedProcedureResult;
        }
        public async Task<IEnumerable<GetParentCustomerCardWiseBalancesModelOutput>> GetParentCustomerCardWiseBalances([FromBody] GetParentCustomerCardWiseBalancesModelInput ObjClass)
        {
            var procedureName = "UspGetParentCustomerCardWiseBalances";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetParentCustomerCardWiseBalancesModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetParentCcmsBalanceInfoForCustomerIdModelOutput>> GetParentCcmsBalanceInfoForCustomerId([FromBody] GetParentCcmsBalanceInfoForCustomerIdModelInput ObjClass)
        {
            var procedureName = "UspGetParentCcmsBalanceInfoForCustomerId";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubType", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetParentCcmsBalanceInfoForCustomerIdModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetParentCustomerDetailByCustomerIdModelOutput> GetParentCustomerDetailByCustomerId([FromBody] GetParentCustomerDetailByCustomerIdModelInput ObjClass)
        {
            var procedureName = "UspGetParentCustomerDetailByCustomerId";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetParentCustomerDetailByCustomerIdModelOutput();
            storedProcedureResult.GetParentCustomerDetails = (List<GetParentCustomerDetails>)await result.ReadAsync<GetParentCustomerDetails>();
            storedProcedureResult.ParentCustomerKYCDetails = (List<ParentCustomerKYCDetails>)await result.ReadAsync<ParentCustomerKYCDetails>();
            
            return storedProcedureResult;

        }       

        public async Task<IEnumerable<GetParentTransactionsSummaryModelOutput>> GetParentTransactionsSummary([FromBody] GetParentTransactionsSummaryModelInput ObjClass)
        {
            var procedureName = "UspGetParentTransactionsSummary";
            var parameters = new DynamicParameters();
            parameters.Add("ChildCustomerID", ObjClass.ChildCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ParentCustomerID", ObjClass.ParentCustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetParentTransactionsSummaryModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
         
        public async Task<GetParentTransactionsSummaryDetailsModelOutput> GetParentTransactionsSummaryDetails([FromBody] GetParentTransactionsSummaryDetailsModelInput ObjClass)
        {
            var dtDBR = new DataTable("UT_ParentTransactionsSummary");
            dtDBR.Columns.Add("Id", typeof(string));
            dtDBR.Columns.Add("ChildCustomerId", typeof(string)); 

            if (ObjClass.ObjChildCustomerIdDtl != null)
            {
                foreach (ChildCustomerTransactionsDetails ObjDetails in ObjClass.ObjChildCustomerIdDtl)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["Id"] = ObjDetails.Id;
                    dr["ChildCustomerId"] = ObjDetails.ChildCustomerID;                     
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }
            var procedureName = "UspGetParentTransactionsSummaryDetails";
            var parameters = new DynamicParameters();
            parameters.Add("UT_ParentTransactionsSummary", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("ParentCustomerID", ObjClass.ParentCustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetParentTransactionsSummaryDetailsModelOutput();
            storedProcedureResult.GetParentTransactionsSaleDetails = (List<GetParentTransactionsSaleSummary>)await result.ReadAsync<GetParentTransactionsSaleSummary>();
            storedProcedureResult.GetParentTransactionsDetailSummary = (List<GetParentCustomerTransactionsDetail>)await result.ReadAsync<GetParentCustomerTransactionsDetail>();
            storedProcedureResult.GetChildTransactionsDetailSummary = (List<GetParentCustomerTransactionsDetail>)await result.ReadAsync<GetParentCustomerTransactionsDetail>();
            return storedProcedureResult;

        }
        
        public async Task<IEnumerable<GetChildByParenModelOutput>> GetChildByParent([FromBody] GetChildByParenModelInput ObjClass)
        {
            var procedureName = "UspGetChildByParent";
            var parameters = new DynamicParameters(); 
            parameters.Add("ParentCustomerID", ObjClass.ParentCustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetChildByParenModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetParentCustomerBasicSearchModelOutput>> GetParentCustomerBasicSearch([FromBody] GetParentCustomerBasicSearchModelInput ObjClass)
        {
            var procedureName = "UspGetParentCustomerBasicSearch";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("NameonCard", ObjClass.NameonCard, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCityName", ObjClass.CommunicationCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerSubType", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetParentCustomerBasicSearchModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetParentCustomerBasicSearchCardModelOutput>> GetParentCustomerBasicSearchCard([FromBody] GetParentCustomerBasicSearchCardModelInput ObjClass)
        {

            var procedureName = "UspGetParentCustomerBasicSearchCard";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("CardType", ObjClass.CardType, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleNo", ObjClass.VehicleNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNumber", ObjClass.CardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("IssueDate", ObjClass.IssueDate, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetParentCustomerBasicSearchCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ParentCustomerControlCardPinResetModelOutput>> ParentCustomerControlCardPinReset(ParentCustomerControlCardPinResetModelInput objClass)
        {
            var procedureName = "UspParentCustomerControlCardPinReset";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", objClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardNo", objClass.ControlCardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", objClass.CustomerSubtype, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", objClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ParentCustomerControlCardPinResetModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetParentCustomerControlCardSearchModelOutput>> GetParentCustomerControlCardSearch([FromBody] GetParentCustomerControlCardSearchModelInput ObjClass)
        {
            var procedureName = "UspGetParentCustomerControlCardSearch";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetParentCustomerControlCardSearchModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<ConvertParentCustomertoAggregatorModelOutput>> ConvertParentCustomertoAggregator([FromBody] ConvertParentCustomertoAggregatorModelInput ObjClass)
        {
            var procedureName = "UspConvertParentCustomertoAggregator";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("NameonCard", ObjClass.NameonCard, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ConvertParentCustomertoAggregatorModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<PCHdfcTransactionStatusModelOutPut>> PCHdfcTransactionStatus([FromBody] PCHdfcTransactionStatusModelInput ObjClass)
        {
            var procedureName = "UspPCHdfcTransactionStatus";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<PCHdfcTransactionStatusModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetChildMappingDetailsModelOutput>> GetChildMappingDetails([FromBody] GetChildMappingDetailsModelInput ObjClass)
        {
            var dtDBR = new DataTable("@UT_ParentCustomerChild");
            dtDBR.Columns.Add("Id", typeof(string));
            dtDBR.Columns.Add("ChildCustomerId", typeof(string));

            if (ObjClass.ObjChildDtl != null)
            {
                foreach (GetChildDetails ObjDetails in ObjClass.ObjChildDtl)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["Id"] = ObjDetails.Id;
                    dr["ChildCustomerId"] = ObjDetails.ChildCustomerId;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }
            var procedureName = "UspGetChildDetails";
            var parameters = new DynamicParameters();
            parameters.Add("UT_ParentCustomerChild", dtDBR, DbType.Object, ParameterDirection.Input); 
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetChildMappingDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ParentCustomerChildMappingModelOutput>> ChildCustomerToParentCustomerMapping([FromBody] ParentCustomerChildMappingModelInput ObjClass)
        {
            var dtDBR = new DataTable("@UT_ParentCustomerChild");
            dtDBR.Columns.Add("Id", typeof(string));
            dtDBR.Columns.Add("ChildCustomerId", typeof(string)); 

            if (ObjClass.ObjParentCustomerDtl != null)
            {
                foreach (ParentCustomerChildDetails ObjDetails in ObjClass.ObjParentCustomerDtl)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["Id"] = ObjDetails.Id;
                    dr["ChildCustomerId"] = ObjDetails.ChildCustomerId;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }
            var procedureName = "UspInsertParentCustomerChild";
            var parameters = new DynamicParameters();
            parameters.Add("UT_ParentCustomerChild", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("ParentCustomerId", ObjClass.ParentCustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ParentCustomerChildMappingModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CheckParentCustomerChildMappingModelOutPut>> CheckParentCustomerMappingEligibility([FromBody] CheckParentCustomerChildMappingModelInput ObjClass)
        {
            var procedureName = "UspCheckParentCustomerMappingEligibility";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckParentCustomerChildMappingModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CheckParentCustomerChildMappingModelOutPut>> ChildCustomerToParentCustomerMappingEligibility([FromBody] CheckParentCustomerChildMappingModelInput ObjClass)
        {
            var procedureName = "UspCheckChildParentCustomerMappingEligibility";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input); 
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckParentCustomerChildMappingModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<PCConfigureSMSAlertsModelOutput>> PCConfigureSMSAlerts([FromBody] PCConfigureSMSAlertsModelInput ObjClass)
        {
            var procedureName = "UspPCConfigureSMSAlerts";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<PCConfigureSMSAlertsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<PCUpdateConfigureSMSAlertsModelOutput>> PCUpdateConfigureSMSAlerts([FromBody] PCUpdateConfigureSMSAlertsModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypePCConfigureSMSAlerts");
            dtDBR.Columns.Add("CustomerID", typeof(string));
            dtDBR.Columns.Add("TransactionID", typeof(string));
            dtDBR.Columns.Add("StatusId", typeof(string));


            if (ObjClass.TypePCConfigureSMSAlerts != null)
            {
                foreach (var ObjDetail in ObjClass.TypePCConfigureSMSAlerts)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CustomerID"] = ObjDetail.CustomerID;
                    dr["TransactionID"] = ObjDetail.TransactionID;
                    dr["StatusId"] = ObjDetail.StatusId;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();

                }
            }
            var procedureName = "UspPCUpdateConfigureSMSAlerts";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);

            parameters.Add("TypePCConfigureSMSAlerts", dtDBR, DbType.Object, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<PCUpdateConfigureSMSAlertsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
      
        public async Task<ParentToChildAndChildParentFundAllocationModelOutPut> ParentToChildAndChildParentFundAllocation([FromBody] ParentToChildAndChildParentFundAllocationModelInput ObjClass)
        {
            // To Get the details//
            var procedureName = "UspParentToChildAndChildParentFundAllocation";
            var parameters = new DynamicParameters();
            parameters.Add("ParentCustomerId", ObjClass.ParentCustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ChildCustomerId", ObjClass.ChildCustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new ParentToChildAndChildParentFundAllocationModelOutPut();
            storedProcedureResult.GetParentCustomer = (List<GetParentCustomer>)await result.ReadAsync<GetParentCustomer>();
            storedProcedureResult.GetChildCustomer = (List<GetChildCustomer>)await result.ReadAsync<GetChildCustomer>();              
            return storedProcedureResult;

        }
        public async Task<IEnumerable<PCChildCustomerBalanceInfoModelOutPut>> PCChildCustomerBalanceInfo([FromBody] PCChildCustomerBalanceInfoModelInput ObjClass)
        {
            var procedureName = "UspPCChildCustomerBalanceInfo";
            var parameters = new DynamicParameters();
            parameters.Add("ChildCustomerId", ObjClass.ChildCustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<PCChildCustomerBalanceInfoModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<PCCCMSBalanceInfoModelOutPut>> PCCCMSBalanceInfo([FromBody] PCCCMSBalanceInfoModelInput ObjClass)
        {
            var procedureName = "UspPCCCMSBalanceInfo";
            var parameters = new DynamicParameters();
            parameters.Add("ChildCustomerId", ObjClass.ChildCustomerId, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<PCCCMSBalanceInfoModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<PCDrivestarsBalanceInfoModelOutPut>> PCDrivestarsBalanceInfo([FromBody] PCDrivestarsBalanceInfoModelInput ObjClass)
        {
            var procedureName = "UspPCDrivestarsBalanceInfo";
            var parameters = new DynamicParameters();
            parameters.Add("ChildCustomerId", ObjClass.ChildCustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<PCDrivestarsBalanceInfoModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<PCDNDConfigureSMSAlertsModelOutput>> PCDNDConfigureSMSAlerts([FromBody] PCDNDConfigureSMSAlertsModelInput ObjClass)
        {
            var procedureName = "UspPCDNDConfigureSMSAlerts";
            var parameters = new DynamicParameters();
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<PCDNDConfigureSMSAlertsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<TransactionDetailsModelOutPut>> TransactionDetails([FromBody] TransactionDetailsModelInput ObjClass)
        {
            var procedureName = "UspTransactionDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("TransactionId", ObjClass.TransactionId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<TransactionDetailsModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<UpdateParenttoChildandChildParentFundAllocationModeloutput>> ParentChildFundAllocation([FromBody] UpdateParenttoChildandChildParentFundAllocationModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeUpdateParenttoChildandChildParentFund");
            dtDBR.Columns.Add("ChildCustomerId", typeof(string));
            dtDBR.Columns.Add("ControlCardNumber", typeof(string));
            dtDBR.Columns.Add("CCMSBalance", typeof(string));
            dtDBR.Columns.Add("Drivestars", typeof(string)); 
            dtDBR.Columns.Add("Amount", typeof(string));
            dtDBR.Columns.Add("BalanceTransferType", typeof(string));

            foreach (var item in ObjClass.TypeUpdateParenttoChildandChildParentFund)
            {
                DataRow dr = dtDBR.NewRow();
                dr["ChildCustomerId"] = item.ChildCustomerId;
                dr["ControlCardNumber"] = item.ControlCardNumber;
                dr["CCMSBalance"] = item.CCMSBalance;
                dr["Drivestars"] = item.Drivestars; 
                dr["Amount"] = item.Amount;
                dr["BalanceTransferType"] = item.BalanceTransferType;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();

            }
             
            var procedureName = "USPParentChildFundAllocation";
            var parameters = new DynamicParameters();
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("ParentCustomer", ObjClass.ParentCustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeUpdateParenttoChildandChildParentFund", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateParenttoChildandChildParentFundAllocationModeloutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// For Aggregator Customer Updation
        /// </summary>
        /// <param name="ObjClass"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ParentToAggregatorCustomerUpdateModelOutput>> ConvertParentToAggregator([FromBody] ParentToAggregatorCustomerUpdateModelInput ObjClass)
        {
            var procedureName = "UspConvertParentToAggregator";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerReferenceNo", ObjClass.CustomerReferenceNo, DbType.Int64, ParameterDirection.Input);
            parameters.Add("ParentCustomerId", ObjClass.ParentCustomerId, DbType.String, ParameterDirection.Input);
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
            parameters.Add("TierOfCustomer", ObjClass.TierOfCustomer, DbType.Int32, ParameterDirection.Input);
            parameters.Add("TypeOfCustomer", ObjClass.TypeOfCustomer, DbType.Int32, ParameterDirection.Input);             
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("PanCardRemarks", ObjClass.PanCardRemarks, DbType.String, ParameterDirection.Input); 
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ParentToAggregatorCustomerUpdateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetTransactionTypeOutPut>> GetTransactionType([FromBody] GetTransactionTypeInput ObjClass)
        {
            var procedureName = "UspGetPCTransactionType";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerSubtype", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetTransactionTypeOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ViewChildMappedToParrentModelOutPut>> ViewChildMappedToParrent([FromBody] ViewChildMappedToParrentModelInput ObjClass)
        {
            var procedureName = "UspViewChildMappedToParrent";
            var parameters = new DynamicParameters();
            parameters.Add("ParentCustomerId", ObjClass.ParentCustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ChildCustomerId", ObjClass.ChildCustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ViewChildMappedToParrentModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<UnMapChildFromParrentModelOutPut>> UnmapChildFromParrent([FromBody] UnMapChildFromParrentModelInput ObjClass)
        {
            var procedureName = "UspUnmapChildFromParent";
            var parameters = new DynamicParameters();
            parameters.Add("Id", ObjClass.Id, DbType.String, ParameterDirection.Input);
            parameters.Add("ChildCustomerId", ObjClass.ChildCustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerSubtype", CustomerSubType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerType", CustomerType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UnMapChildFromParrentModelOutPut>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
