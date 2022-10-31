using Dapper;
using HPPay.DataModel.AdvanceSearch;
using HPPay.DataRepository.DBDapper;
using HPPay.DataRepository.AdvanceSearch;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository
{
    public class AdvanceSearchRepositary : IAdvanceSearchRepositary
    {
        private readonly DapperContext _context;
        //private readonly IHostingEnvironment _hostingEnvironment;

        public AdvanceSearchRepositary(DapperContext context)//, IHostingEnvironment hostingEnvironment) // , IConfiguration configuration
        {
            _context = context;
            // _hostingEnvironment = hostingEnvironment;

        }

        public async Task<IEnumerable<GetAdvanceSearchCustomerSearchModelOutput>> GetAdvanceSearchCustomerSearch([FromBody] GetAdvanceSearchCustomerSearchModelInput ObjClass)
        {
            var procedureName = "UspGetAdvanceSearchCustomerSearch";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("IsCustomerNameExist", Convert.ToInt32(ObjClass.IsCustomerNameExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("IsFormNumberExist", Convert.ToInt32(ObjClass.IsFormNumberExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("IsCustomeridExist", Convert.ToInt32(ObjClass.IsCustomeridExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerType", ObjClass.CustomerType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IsCustomerTypeExist", Convert.ToInt32(ObjClass.IsCustomerTypeExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("RegionalOfficeID", ObjClass.RegionalOfficeID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IsRegionalOfficeExist", Convert.ToInt32(ObjClass.IsRegionalOfficeExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("ZonalOfficeId", ObjClass.ZonalOfficeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IsZonalOfficeExist", Convert.ToInt32(ObjClass.IsZonalOfficeExist), DbType.String, ParameterDirection.Input);
            parameters.Add("Pincode", ObjClass.Pincode, DbType.String, ParameterDirection.Input);
            parameters.Add("IsPincodeExist", Convert.ToInt32(ObjClass.IsPincodeExist), DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("IsMobileExist", Convert.ToInt32(ObjClass.IsMobileExist), DbType.String, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAdvanceSearchCustomerSearchModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetAdvanceSearchMerchantSearchModelOutput>> GetAdvanceSearchMerchantSearch([FromBody] GetAdvanceSearchMerchantSearchModelInput ObjClass)
        {
            var procedureName = "UspGetAdvanceSearchMerchantSearch";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("IsMerchantIdExist", Convert.ToInt32(ObjClass.IsMerchantIdExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("MerchantType", ObjClass.MerchantType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IsMerchantTypeExist", Convert.ToInt32(ObjClass.IsMerchantTypeExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("MerchantName", ObjClass.MerchantName, DbType.String, ParameterDirection.Input);
            parameters.Add("IsMerchantNameExist", Convert.ToInt32(ObjClass.IsMerchantNameExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("RetailOutletName", ObjClass.RetailOutletName, DbType.String, ParameterDirection.Input);
            parameters.Add("IsRetailOutletNameExist", Convert.ToInt32(ObjClass.IsRetailOutletNameExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("ErpCode", ObjClass.ErpCode, DbType.String, ParameterDirection.Input);
            parameters.Add("IsErpCodeExist", Convert.ToInt32(ObjClass.IsRegionalOfficeExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("Status ", ObjClass.Status, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IsStatusExist", Convert.ToInt32(ObjClass.IsStatusExist), DbType.String, ParameterDirection.Input);
            //parameters.Add("Owner", ObjClass.Owner, DbType.String, ParameterDirection.Input);
            //parameters.Add("IsOwnerExist", Convert.ToInt32(ObjClass.IsOwnerExist), DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeID", ObjClass.RegionalOfficeID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IsRegionalOfficeExist", Convert.ToInt32(ObjClass.IsRegionalOfficeExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("RetailOffCity", ObjClass.RetailOffCity, DbType.String, ParameterDirection.Input);
            parameters.Add("IsRetailOffCityExist", Convert.ToInt32(ObjClass.IsRetailOffCityExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("RetailOffDistrict ", ObjClass.RetailOffDistrict, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IsRetailOffDistrictExist", Convert.ToInt32(ObjClass.IsRetailOffDistrictExist), DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOffState", ObjClass.RetailOffState, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IsRetailOffStateExist", Convert.ToInt32(ObjClass.IsRetailOffStateExist), DbType.String, ParameterDirection.Input);
            parameters.Add("RetailOffPinCode", ObjClass.RetailOffPinCode, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IsRetailOffPinCodeExist", Convert.ToInt32(ObjClass.IsRetailOffPinCodeExist), DbType.String, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAdvanceSearchMerchantSearchModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetAdvanceSearchCardSearchModelOutput>> GetAdvanceSearchCardSearch([FromBody] GetAdvanceSearchCardSearchModelInput ObjClass)
        {
            var procedureName = "UspGetAdvanceSearchCardSearch";
            var parameters = new DynamicParameters();
            parameters.Add("CardNumber", ObjClass.CardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("IsCardNumberExist", Convert.ToInt32(ObjClass.IsCardNumberExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("IsCustomerNameExist", Convert.ToInt32(ObjClass.IsCustomerNameExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("ControlCardNo", ObjClass.ControlCardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("IsControlCardNoExist ", Convert.ToInt32(ObjClass.IsControlCardNoExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("IsCustomerIdExist", Convert.ToInt32(ObjClass.IsCustomerIdExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("IssueType", ObjClass.IssueType, DbType.String, ParameterDirection.Input);
            parameters.Add("IsIssueTypeExist", Convert.ToInt32(ObjClass.IsIssueTypeExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("Status ", ObjClass.Status, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IsStatusExist", Convert.ToInt32(ObjClass.IsStatusExist), DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("IsFormNumberExist", Convert.ToInt32(ObjClass.IsFormNumberExist), DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleNumber", ObjClass.VehicleNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("IsVehicleNumberExist", Convert.ToInt32(ObjClass.IsVehicleNumberExist), DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleType ", ObjClass.VehicleType, DbType.String, ParameterDirection.Input);
            parameters.Add("IsVehicleTypeExist", Convert.ToInt32(ObjClass.IsVehicleTypeExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("VechileMake ", ObjClass.VechileMake, DbType.String, ParameterDirection.Input);
            parameters.Add("IsVechileMakeExist", Convert.ToInt32(ObjClass.IsVechileMakeExist), DbType.String, ParameterDirection.Input);
            parameters.Add("RegistrationYear", ObjClass.RegistrationYear, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IsRegistrationYearExist", Convert.ToInt32(ObjClass.IsRegistrationYearExist), DbType.String, ParameterDirection.Input);
            parameters.Add("NameOnCard", ObjClass.NameOnCard, DbType.String, ParameterDirection.Input);
            parameters.Add("IsNameOnCardExist", Convert.ToInt32(ObjClass.IsNameOnCardExist), DbType.String, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAdvanceSearchCardSearchModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetAdvanceSearchTerminalSearchModelOutput>> GetAdvanceSearchTerminalSearch([FromBody] GetAdvanceSearchTerminalSearchModelInput ObjClass)
        {
            var procedureName = "UspGetAdvanceSearchTerminalSearch";
            var parameters = new DynamicParameters();
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("IsTerminalIdExist", Convert.ToInt32(ObjClass.IsTerminalIdExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            parameters.Add("IsMerchantIdExist", Convert.ToInt32(ObjClass.IsMerchantIdExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("MerchantName", ObjClass.MerchantName, DbType.String, ParameterDirection.Input);
            parameters.Add("IsMerchantNameExist", Convert.ToInt32(ObjClass.IsMerchantNameExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("ErpCode", ObjClass.ErpCode, DbType.String, ParameterDirection.Input);
            parameters.Add("IsErpCodeExist", Convert.ToInt32(ObjClass.IsErpCodeExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("MerchantType", ObjClass.MerchantType, DbType.Int32, ParameterDirection.Input);
            parameters.Add("IsMerchantTypeExist", Convert.ToInt32(ObjClass.IsMerchantTypeExist), DbType.Int32, ParameterDirection.Input);
            parameters.Add("LocationName ", ObjClass.LocationName, DbType.String, ParameterDirection.Input);
            parameters.Add("IsLocationNameExist", Convert.ToInt32(ObjClass.IsLocationNameExist), DbType.String, ParameterDirection.Input);
            parameters.Add("ContactPersonName", ObjClass.ContactPersonName, DbType.String, ParameterDirection.Input);
            parameters.Add("IsContactPersonNameExist", Convert.ToInt32(ObjClass.IsContactPersonNameExist), DbType.String, ParameterDirection.Input);
            parameters.Add("StatusName", ObjClass.StatusName, DbType.String, ParameterDirection.Input);
            parameters.Add("IsStatusNameExist", Convert.ToInt32(ObjClass.IsStatusNameExist), DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalPan", ObjClass.TerminalPan, DbType.String, ParameterDirection.Input);
            parameters.Add("IsTerminalPanExist", Convert.ToInt32(ObjClass.IsTerminalPanExist), DbType.String, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAdvanceSearchTerminalSearchModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
