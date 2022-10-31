using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.Card;
using HPPay.DataModel.CustomerRelationship;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataRepository.CustomerRelationship
{

    public class CustomerRelationshipRepository : ICustomerRelationshipRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public CustomerRelationshipRepository(DapperContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IEnumerable<CustomerRelationshipPaymentTermsTypeModelOutput>> PaymentTermsType([FromBody] CustomerRelationshipPaymentTermsTypeModelInput ObjClass)
        {
            var procedureName = "UspPaymentTermsType";
            var parameters = new DynamicParameters();

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerRelationshipPaymentTermsTypeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CustomerRelationshipPaymentTermsModeModelOutput>> PaymentTermsMode([FromBody] CustomerRelationshipPaymentTermsModeModelInput ObjClass)
        {
            var procedureName = "UspPaymentTermsMode";
            var parameters = new DynamicParameters();

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerRelationshipPaymentTermsModeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerRelationshipSegmentServedModelOutput>> SegmentServed([FromBody] CustomerRelationshipSegmentServedModelInput ObjClass)
        {
            var procedureName = "UspSegmentServed";
            var parameters = new DynamicParameters();

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerRelationshipSegmentServedModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<CustomerRelationshipUsageTypeModelOutput>> UsageType([FromBody] CustomerRelationshipUsageTypeModelInput ObjClass)
        {
            var procedureName = "UspUsageType";
            var parameters = new DynamicParameters();

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerRelationshipUsageTypeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<BusinessSolicitationCallReportModelOutput> BusinessSolicitationCallReport([FromBody] BusinessSolicitationCallReportModelInput ObjClass)
        {
            var procedureName = "UspBusinessSolicitationCallReport";
            var parameters = new DynamicParameters();

            parameters.Add("TrackId", ObjClass.TrackId, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            var storedProcedureResult = new BusinessSolicitationCallReportModelOutput();
            storedProcedureResult.BusinessSolicitationCallReport = (List<BusinessSolicitationCallReport>)await result.ReadAsync<BusinessSolicitationCallReport>();
            storedProcedureResult.BusinessSolicitationAreaofOperation = (List<BusinessSolicitationAreaofOperation>)await result.ReadAsync<BusinessSolicitationAreaofOperation>();
            storedProcedureResult.BusinessSolicitationMapping = (List<BusinessSolicitationMapping>)await result.ReadAsync<BusinessSolicitationMapping>();
            storedProcedureResult.BusinessSolicitationMeetingRemark = (List<BusinessSolicitationMeetingRemark>)await result.ReadAsync<BusinessSolicitationMeetingRemark>();

            //SettingBusinessSolicitationCallReportModelOutput Bussinessobj = new SettingBusinessSolicitationCallReportModelOutput();
            //Bussinessobj.BusinessSolicitationCallReport = storedProcedureResult.BusinessSolicitationCallReport;
            //Bussinessobj.BusinessSolicitationAreaofOperation = storedProcedureResult.BusinessSolicitationAreaofOperation;
            //Bussinessobj.BusinessSolicitationMapping = storedProcedureResult.BusinessSolicitationMapping;
            //Bussinessobj.BusinessSolicitationMeetingRemark = storedProcedureResult.BusinessSolicitationMeetingRemark;
            return storedProcedureResult;
        }

        public async Task<IEnumerable<CustomerRelationshipCustomerCategoryModelOutput>> CustomerCategory([FromBody] CustomerRelationshipCustomerCategoryModelInput ObjClass)
        {
            var procedureName = "UspCustomerCategory";
            var parameters = new DynamicParameters();

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerRelationshipCustomerCategoryModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerRelationshipFleetSizeValueModelOutput>> FleetSizeValue([FromBody] CustomerRelationshipFleetSizeValueModelInput ObjClass)
        {
            var procedureName = "UspFleetSizeValue";
            var parameters = new DynamicParameters();
            parameters.Add("TierId", ObjClass.TierId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerRelationshipFleetSizeValueModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerRelationshipGetDealerMappingInputModelOutput>> GetDealerMappingInput([FromBody] CustomerRelationshipGetDealerMappingInputModelInput ObjClass)
        {
            var procedureName = "UspGetDealerMappingInput";
            var parameters = new DynamicParameters();
            parameters.Add("RegionOfficeId", ObjClass.RegionOfficeId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerRelationshipGetDealerMappingInputModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CustomerRelationshipListAllTrackIdModelOutput>> ListAllTrackId([FromBody] CustomerRelationshipListAllTrackIdModelInput ObjClass)
        {
            var procedureName = "UspListAllTrackId";
            var parameters = new DynamicParameters();

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerRelationshipListAllTrackIdModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerRelationshipUpdateBusinessSolicitationCallReportModelOutput>> UpdateBusinessSolicitationCallReport([FromBody] CustomerRelationshipUpdateBusinessSolicitationCallReportModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeAreaOperation");
            dtDBR.Columns.Add("ID", typeof(int));
            dtDBR.Columns.Add("TrackId", typeof(int));
            dtDBR.Columns.Add("Routes", typeof(string));
            dtDBR.Columns.Add("RouteFrom", typeof(string));
            dtDBR.Columns.Add("RouteTo", typeof(string));
            dtDBR.Columns.Add("NHNO", typeof(int));

            var dtobjDBR = new DataTable("TypeMappingSolicitation");
            dtDBR.Columns.Add("ID", typeof(int));
            dtDBR.Columns.Add("TrackId", typeof(int));
            dtobjDBR.Columns.Add("MappingLocation", typeof(string));
            dtobjDBR.Columns.Add("CurrentSupplier", typeof(string));
            dtobjDBR.Columns.Add("LHSANDRHS", typeof(int));
            dtobjDBR.Columns.Add("Zone", typeof(int));
            dtobjDBR.Columns.Add("Region", typeof(string));
            dtobjDBR.Columns.Add("CreditExpected", typeof(decimal));
            dtobjDBR.Columns.Add("DiscountExpected", typeof(decimal));
            dtobjDBR.Columns.Add("NoOfDays", typeof(int));

            var objDBR = new DataTable("TypeRemarkBusinessSolicitation");
            dtDBR.Columns.Add("ID", typeof(int));
            dtDBR.Columns.Add("TrackId", typeof(int));
            objDBR.Columns.Add("MeetingDate", typeof(string));
            objDBR.Columns.Add("MeetingRemark", typeof(string));

            var procedureName = "UspUpdateBusinessSolicitationCallReport";
            var parameters = new DynamicParameters();

            if (ObjClass.TypeAreaOperation != null)
            {
                foreach (TypeAreaOperation ObjCardDetails in ObjClass.TypeAreaOperation)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["ID"] = ObjCardDetails.ID;
                    dr["TrackId"] = ObjCardDetails.TrackId;
                    dr["Routes"] = ObjCardDetails.Routes;
                    dr["RouteFrom"] = ObjCardDetails.RouteFrom;
                    dr["RouteTo"] = ObjCardDetails.RouteTo;
                    dr["NHNO"] = ObjCardDetails.NHNO;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }
            if (ObjClass.TypeMappingSolicitation != null)
            {
                foreach (TypeMappingSolicitation ObjCardDetail in ObjClass.TypeMappingSolicitation)
                {
                    DataRow dr = dtobjDBR.NewRow();
                    dr["ID"] = ObjCardDetail.ID;
                    dr["TrackId"] = ObjCardDetail.TrackId;
                    dr["MappingLocation"] = ObjCardDetail.MappingLocation;
                    dr["CurrentSupplier"] = ObjCardDetail.CurrentSupplier;
                    dr["LHSANDRHS"] = ObjCardDetail.LHSANDRHS;
                    dr["Zone"] = ObjCardDetail.Zone;
                    dr["Region"] = ObjCardDetail.Region;
                    dr["CreditExpected"] = ObjCardDetail.CreditExpected;
                    dr["DiscountExpected"] = ObjCardDetail.DiscountExpected;
                    dr["NoOfDays"] = ObjCardDetail.NoOfDays;
                    dtobjDBR.Rows.Add(dr);
                    dtobjDBR.AcceptChanges();
                }
            }

            if (ObjClass.TypeRemarkBusinessSolicitation != null)
            {
                foreach (TypeRemarkBusinessSolicitation CardDetail in ObjClass.TypeRemarkBusinessSolicitation)
                {
                    DataRow dr = objDBR.NewRow();
                    dr["ID"] = CardDetail.ID;
                    dr["TrackId"] = CardDetail.TrackId;
                    dr["MeetingDate"] = CardDetail.MeetingDate;
                    dr["MeetingRemark"] = CardDetail.MeetingRemark;

                    objDBR.Rows.Add(dr);
                    objDBR.AcceptChanges();
                }
            }
            parameters.Add("TrackId", ObjClass.TrackId, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOffice", ObjClass.ZonalOffice, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RegionalOffice", ObjClass.RegionalOffice, DbType.Int32, ParameterDirection.Input);
            parameters.Add("SalesSrea", ObjClass.SalesSrea, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Address1", ObjClass.Address1, DbType.String, ParameterDirection.Input);
            parameters.Add("Address2", ObjClass.Address2, DbType.String, ParameterDirection.Input);
            parameters.Add("Address3", ObjClass.Address3, DbType.String, ParameterDirection.Input);
            parameters.Add("Location", ObjClass.Location, DbType.String, ParameterDirection.Input);
            parameters.Add("City", ObjClass.City, DbType.String, ParameterDirection.Input);
            parameters.Add("Pincode", ObjClass.Pincode, DbType.String, ParameterDirection.Input);
            parameters.Add("State", ObjClass.State, DbType.Int32, ParameterDirection.Input);
            parameters.Add("District", ObjClass.District, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PhoneCode", ObjClass.PhoneCode, DbType.String, ParameterDirection.Input);
            parameters.Add("PhoneNo", ObjClass.PhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FaxCode", ObjClass.FaxCode, DbType.String, ParameterDirection.Input);
            parameters.Add("Fax", ObjClass.Fax, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Email", ObjClass.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerCategory", ObjClass.CustomerCategory, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Fleetsize", ObjClass.Fleetsize, DbType.Int32, ParameterDirection.Input);
            parameters.Add("HSD", ObjClass.HSD, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("MS", ObjClass.MS, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("Lube", ObjClass.Lube, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("CustomerType", ObjClass.CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubType", ObjClass.CustomerSubType, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialFirstName", ObjClass.KeyOfficialFirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialMiddleName", ObjClass.KeyOfficialMiddleName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialLastName", ObjClass.KeyOfficialLastName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDesignation", ObjClass.KeyOfficialDesignation, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialPhoneCode", ObjClass.KeyOfficialPhoneCode, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialPhoneNo", ObjClass.KeyOfficialPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialMobile", ObjClass.KeyOfficialMobile, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialEmail", ObjClass.KeyOfficialEmail, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialAlterMobile", ObjClass.KeyOfficialAlterMobile, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfBusinessEntity", ObjClass.TypeOfBusinessEntity, DbType.Int32, ParameterDirection.Input);
            parameters.Add("SegmentServed", ObjClass.SegmentServed, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UsageType", ObjClass.UsageType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("NoOfDays", ObjClass.NoOfDays, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ActionPlanforEnrollment", ObjClass.ActionPlanforEnrollment, DbType.String, ParameterDirection.Input);
            parameters.Add("EnrollmentExpectedby", ObjClass.EnrollmentExpectedby, DbType.String, ParameterDirection.Input);
            parameters.Add("PaymenttermsType", ObjClass.PaymenttermsType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Paymenttermsmode", ObjClass.Paymenttermsmode, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedTime", ObjClass.CreatedTime, DbType.String, ParameterDirection.Input);

            parameters.Add("TypeAreaOperation", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("TypeMappingSolicitation", dtobjDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("TypeRemarkBusinessSolicitation", objDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerRelationshipUpdateBusinessSolicitationCallReportModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerRelationshipBusinessSolicitationCallReportModelOutput>> CustomerRelationshipBusinessSolicitationCallReport([FromBody] CustomerRelationshipBusinessSolicitationCallReportModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeAreaofOperation");
            dtDBR.Columns.Add("Routes", typeof(string));
            dtDBR.Columns.Add("RouteFrom", typeof(string));
            dtDBR.Columns.Add("RouteTo", typeof(string));
            dtDBR.Columns.Add("NHNO", typeof(int));

            var dtobjDBR = new DataTable("TypeMappingBusinessSolicitation");
            dtobjDBR.Columns.Add("MappingLocation", typeof(string));
            dtobjDBR.Columns.Add("CurrentSupplier", typeof(string));
            dtobjDBR.Columns.Add("LHSANDRHS", typeof(int));
            dtobjDBR.Columns.Add("Zone", typeof(int));
            dtobjDBR.Columns.Add("Region", typeof(string));
            dtobjDBR.Columns.Add("CreditExpected", typeof(decimal));
            dtobjDBR.Columns.Add("DiscountExpected", typeof(decimal));
            dtobjDBR.Columns.Add("NoOfDays", typeof(int));

            var objDBR = new DataTable("TypeMeetingRemarkBusinessSolicitation");
            objDBR.Columns.Add("MeetingDate", typeof(string));
            objDBR.Columns.Add("MeetingRemark", typeof(string));


            var procedureName = "UspCustomerRelationshipBusinessSolicitationCallReport";
            var parameters = new DynamicParameters();

            if (ObjClass.TypeAreaofOperation != null)
            {
                foreach (TypeAreaofOperation ObjCardDetails in ObjClass.TypeAreaofOperation)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["Routes"] = ObjCardDetails.Routes;
                    dr["RouteFrom"] = ObjCardDetails.RouteFrom;
                    dr["RouteTo"] = ObjCardDetails.RouteTo;
                    dr["NHNO"] = ObjCardDetails.NHNO;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }


            if (ObjClass.TypeMappingBusinessSolicitation != null)
            {
                foreach (TypeMappingBusinessSolicitation ObjCardDetail in ObjClass.TypeMappingBusinessSolicitation)
                {
                    DataRow dr = dtobjDBR.NewRow();
                    dr["MappingLocation"] = ObjCardDetail.MappingLocation;
                    dr["CurrentSupplier"] = ObjCardDetail.CurrentSupplier;
                    dr["LHSANDRHS"] = ObjCardDetail.LHSANDRHS;
                    dr["Zone"] = ObjCardDetail.Zone;
                    dr["Region"] = ObjCardDetail.Region;
                    dr["CreditExpected"] = ObjCardDetail.CreditExpected;
                    dr["DiscountExpected"] = ObjCardDetail.DiscountExpected;
                    dr["NoOfDays"] = ObjCardDetail.NoOfDays;


                    dtobjDBR.Rows.Add(dr);
                    dtobjDBR.AcceptChanges();
                }
            }



            if (ObjClass.TypeMeetingRemarkBusinessSolicitation != null)
            {
                foreach (TypeMeetingRemarkBusinessSolicitation CardDetail in ObjClass.TypeMeetingRemarkBusinessSolicitation)
                {
                    DataRow dr = objDBR.NewRow();

                    dr["MeetingDate"] = CardDetail.MeetingDate;
                    dr["MeetingRemark"] = CardDetail.MeetingRemark;

                    objDBR.Rows.Add(dr);
                    objDBR.AcceptChanges();
                }
            }
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("ZonalOffice", ObjClass.ZonalOffice, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RegionalOffice", ObjClass.RegionalOffice, DbType.Int32, ParameterDirection.Input);
            parameters.Add("SalesSrea", ObjClass.SalesSrea, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Address1", ObjClass.Address1, DbType.String, ParameterDirection.Input);
            parameters.Add("Address2", ObjClass.Address2, DbType.String, ParameterDirection.Input);
            parameters.Add("Address3", ObjClass.Address3, DbType.String, ParameterDirection.Input);
            parameters.Add("Location", ObjClass.Location, DbType.String, ParameterDirection.Input);
            parameters.Add("City", ObjClass.City, DbType.String, ParameterDirection.Input);
            parameters.Add("Pincode", ObjClass.Pincode, DbType.String, ParameterDirection.Input);
            parameters.Add("State", ObjClass.State, DbType.Int32, ParameterDirection.Input);
            parameters.Add("District", ObjClass.District, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PhoneCode", ObjClass.PhoneCode, DbType.String, ParameterDirection.Input);
            parameters.Add("PhoneNo", ObjClass.PhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FaxCode", ObjClass.FaxCode, DbType.String, ParameterDirection.Input);
            parameters.Add("Fax", ObjClass.Fax, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Email", ObjClass.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerCategory", ObjClass.CustomerCategory, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Fleetsize", ObjClass.Fleetsize, DbType.Int32, ParameterDirection.Input);
            parameters.Add("HSD", ObjClass.HSD, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("MS", ObjClass.MS, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("Lube", ObjClass.Lube, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("CustomerType", ObjClass.CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerSubType", ObjClass.CustomerSubType, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialFirstName", ObjClass.KeyOfficialFirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialMiddleName", ObjClass.KeyOfficialMiddleName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialLastName", ObjClass.KeyOfficialLastName, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialDesignation", ObjClass.KeyOfficialDesignation, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialPhoneCode", ObjClass.KeyOfficialPhoneCode, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialPhoneNo", ObjClass.KeyOfficialPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialMobile", ObjClass.KeyOfficialMobile, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialEmail", ObjClass.KeyOfficialEmail, DbType.String, ParameterDirection.Input);
            parameters.Add("KeyOfficialAlterMobile", ObjClass.KeyOfficialAlterMobile, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeOfBusinessEntity", ObjClass.TypeOfBusinessEntity, DbType.Int32, ParameterDirection.Input);
            parameters.Add("SegmentServed", ObjClass.SegmentServed, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UsageType", ObjClass.UsageType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("NoOfDays", ObjClass.NoOfDays, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ActionPlanforEnrollment", ObjClass.ActionPlanforEnrollment, DbType.String, ParameterDirection.Input);
            parameters.Add("EnrollmentExpectedby", ObjClass.EnrollmentExpectedby, DbType.String, ParameterDirection.Input);
            parameters.Add("PaymenttermsType", ObjClass.PaymenttermsType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Paymenttermsmode", ObjClass.Paymenttermsmode, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedTime", ObjClass.CreatedTime, DbType.String, ParameterDirection.Input);

            parameters.Add("TypeAreaofOperation", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("TypeMappingBusinessSolicitation", dtobjDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("TypeMeetingRemarkBusinessSolicitation", objDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerRelationshipBusinessSolicitationCallReportModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerRelationshipMonthModelOutput>> CustomerRelationshipMonth([FromBody] CustomerRelationshipMonthModelInput ObjClass)
        {
            var procedureName = "UspCustomerRelationshipMonth";
            var parameters = new DynamicParameters();

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerRelationshipMonthModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<CustomerRelationshipgetcallstatusmonthModelOutput> getcallstatusmonth([FromBody] CustomerRelationshipgetcallstatusmonthModelInput ObjClass)
        {
            var procedureName = "Uspgetcallstatusmonth";
            var parameters = new DynamicParameters();

            parameters.Add("Month", ObjClass.Month, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            var storedProcedureResult = new CustomerRelationshipgetcallstatusmonthModelOutput();
            storedProcedureResult.SolicitationRelationshipDetails = (List<GetRegionZoanlDetails>)await result.ReadAsync<GetRegionZoanlDetails>();
            storedProcedureResult.BussinessSolicitationDetails = (List<GetBussinessSolicitationDetails>)await result.ReadAsync<GetBussinessSolicitationDetails>();
            storedProcedureResult.CustomerRelationshipDetails = (List<GetCustomerRelationshipDetails>)await result.ReadAsync<GetCustomerRelationshipDetails>();

            CustomerRelationshipgetcallstatusmonthModelOutput Customerobj = new CustomerRelationshipgetcallstatusmonthModelOutput();
            Customerobj.SolicitationRelationshipDetails = storedProcedureResult.SolicitationRelationshipDetails;
            Customerobj.BussinessSolicitationDetails = storedProcedureResult.BussinessSolicitationDetails;
            Customerobj.CustomerRelationshipDetails = storedProcedureResult.CustomerRelationshipDetails;
            return Customerobj;
        }

        public async Task<GetRelationshipManagementCallModelOutput> GetRelationshipManagementCall([FromBody] GetRelationshipManagementCallModelInput ObjClass)
        {
            var procedureName = "UspGetRelationshipManagementCall";
            var parameters = new DynamicParameters();

            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            var storedProcedureResult = new GetRelationshipManagementCallModelOutput();
            storedProcedureResult.CustomerDetails = (List<GetcustomerDetails>)await result.ReadAsync<GetcustomerDetails>();
            storedProcedureResult.CustomerRelationDetails = (List<GetCustomerRelationDetails>)await result.ReadAsync<GetCustomerRelationDetails>();
            storedProcedureResult.Hsddetails = (List<GetHsddetails>)await result.ReadAsync<GetHsddetails>();
            storedProcedureResult.DrivestarDetails = (List<GetDrivestarDetails>)await result.ReadAsync<GetDrivestarDetails>();
            storedProcedureResult.KeyCustomerDetails = (List<GetKeyCustomerDetails>)await result.ReadAsync<GetKeyCustomerDetails>();
            storedProcedureResult.CustomerRouteDetails = (List<GetCustomerRouteDetails>)await result.ReadAsync<GetCustomerRouteDetails>();
            storedProcedureResult.CustomerPaymentDetails = (List<GetCustomerPaymentDetails>)await result.ReadAsync<GetCustomerPaymentDetails>();
            storedProcedureResult.CustomerMappingLocation = (List<GetCustomerMappingLocation>)await result.ReadAsync<GetCustomerMappingLocation>();
            storedProcedureResult.CustomerFeedbackDetails = (List<GetCustomerFeedbackDetails>)await result.ReadAsync<GetCustomerFeedbackDetails>();

            GetRelationshipManagementCallModelOutput Customerobj = new GetRelationshipManagementCallModelOutput();
            Customerobj.CustomerDetails = storedProcedureResult.CustomerDetails;
            Customerobj.CustomerRelationDetails = storedProcedureResult.CustomerRelationDetails;
            Customerobj.Hsddetails = storedProcedureResult.Hsddetails;
            Customerobj.DrivestarDetails = storedProcedureResult.DrivestarDetails;
            Customerobj.KeyCustomerDetails = storedProcedureResult.KeyCustomerDetails;
            Customerobj.CustomerRouteDetails = storedProcedureResult.CustomerRouteDetails;
            Customerobj.CustomerPaymentDetails = storedProcedureResult.CustomerPaymentDetails;
            Customerobj.CustomerMappingLocation = storedProcedureResult.CustomerMappingLocation;
            Customerobj.CustomerFeedbackDetails = storedProcedureResult.CustomerFeedbackDetails;
            return Customerobj;
        }
    }
}
