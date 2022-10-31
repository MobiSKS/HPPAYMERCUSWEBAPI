using Dapper;
using HPPay.DataModel.ConfigureAlert;
using HPPay.DataRepository.DBDapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.ConfigureAlert
{
    public class ConfigureAlertRepository:IConfigureAlertRepository
    {
        private readonly DapperContext _context;
        public ConfigureAlertRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<GetSmsAlertForMultipleMobileDetailModelOutput> GetSmsAlertForMultipleMobile([FromBody] GetSmsAlertForMultipleMobileDetailModelInput ObjClass)
        {
            var procedureName = "UspGetSmsAlertForMultipleMobileDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetSmsAlertForMultipleMobileDetailModelOutput();
            storedProcedureResult.CustomerDetail = (List<CustomerDetail>)await result.ReadAsync<CustomerDetail>();
            storedProcedureResult.CustomerMultipleMobileDetail = (List<SmsAlertForMultipleMobileDetail>)await result.ReadAsync<SmsAlertForMultipleMobileDetail>();
            
            return storedProcedureResult;
        }

        public async Task<IEnumerable<UpdateSmsAlertForMultipleMobileDetailModelOutput>> UpdateSmsAlertForMultipleMobileDetail([FromBody] UpdateSmsAlertForMultipleMobileDetailModelinput ObjClass)
        {

            var dtDBR = new DataTable("CustomerMultiMobile");
            dtDBR.Columns.Add("CustomerID", typeof(string));
            dtDBR.Columns.Add("MobileNo", typeof(string));
            dtDBR.Columns.Add("Name", typeof(string));
            dtDBR.Columns.Add("Designation", typeof(string));

            if(ObjClass.CustomerDetailForSmsAlert != null )
            {
                foreach (var ObjDetail in ObjClass.CustomerDetailForSmsAlert)
                {
                    

                    DataRow dr = dtDBR.NewRow();
                    dr["CustomerID"] = ObjDetail.CustomerID;
                    dr["MobileNo"] = ObjDetail.MobileNo;
                    dr["Name"] = ObjDetail.Name;
                    dr["Designation"] = ObjDetail.Designation;

                    //dr["CreatedBy"] = ObjDetail.CreatedBy;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();

                }
            }
            var procedureName = "UspUpdateSmsAlertForMultipleMobileDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerMultiMobile",dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("userId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateSmsAlertForMultipleMobileDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DeleteSmsAlertForMultipleMobileDetailModelOutput>> DeleteSmsAlertForMultipleMobileDetail([FromBody] DeleteSmsAlertForMultipleMobileDetailModelInput ObjClass)
        {
            var procedureName = "UspDeleteSmsAlertForMultipleMobileDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID",ObjClass.CustomerID , DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DeleteSmsAlertForMultipleMobileDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


        }


        public async Task<IEnumerable<ConfigureAlertGetConfigureSMSAlertsDetailsByCustomerIDModelOutput>> GetConfigureSMSAlertsDetailsByCustomerID([FromBody] ConfigureAlertGetConfigureSMSAlertsDetailsByCustomerIDModelInput ObjClass)
        {
            var procedureName = "UspGetConfigureSMSAlertsDetailsByCustomerID";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ConfigureAlertGetConfigureSMSAlertsDetailsByCustomerIDModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<UpdateConfigureSMSAlertsModelOutput>> UpdateConfigureSMSAlerts([FromBody] UpdateConfigureSMSAlertsModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeConfigureSMSAlerts");
            dtDBR.Columns.Add("CustomerID", typeof(string));
            dtDBR.Columns.Add("TransactionID", typeof(string));
            dtDBR.Columns.Add("StatusId", typeof(string));


            if (ObjClass.TypeConfigureSMSAlerts != null)
            {
                foreach (var ObjDetail in ObjClass.TypeConfigureSMSAlerts)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CustomerID"] = ObjDetail.CustomerID;
                    dr["TransactionID"] = ObjDetail.TransactionID;
                    dr["StatusId"] = ObjDetail.StatusId;
                    // dr["Designation"] = ObjDetail.Designation;

                    //dr["CreatedBy"] = ObjDetail.CreatedBy;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();

                }
            }
            var procedureName = "UspUpdateConfigureSMSAlerts";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);

            parameters.Add("TypeConfigureSMSAlerts", dtDBR, DbType.Object, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateConfigureSMSAlertsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetConfigureEmailAlertsOutput>> GetConfigureEmailAlerts([FromBody] GetConfigureEmailAlertsModelInput ObjClass)
        {
            var procedureName = "UspGetConfigureEmailAlerts";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetConfigureEmailAlertsOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateConfigureEmailAlertModelOutput>> UpdateConfigureEmailAlert([FromBody] UpdateConfigureEmailAlertModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeServiceName");
            dtDBR.Columns.Add("ServiceId", typeof(string));
            dtDBR.Columns.Add("AllowedStatus", typeof(decimal));

            var procedureName = "UspUpdateConfigureEmailAlert";
            var parameters = new DynamicParameters();

            foreach (ConfigureEmailAlertModelInput objConfigureEmailAlert in ObjClass.objConfigureEmailAlert)
            {
                DataRow dr = dtDBR.NewRow();
                dr["ServiceId"] = objConfigureEmailAlert.ServiceId;
                dr["AllowedStatus"] = objConfigureEmailAlert.AllowedStatus;

                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeServiceName", dtDBR, DbType.Object, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateConfigureEmailAlertModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<GetSMSAlertstoIndividualCardUsersDetailsModelOutput> GetSMSAlertstoIndividualCardUsersDetails([FromBody] GetSMSAlertstoIndividualCardUsersDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetSMSAlertstoIndividualCardUsersDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetSMSAlertstoIndividualCardUsersDetailsModelOutput();
            storedProcedureResult.CustomerDetails = (List<CustomerDetails>)await result.ReadAsync<CustomerDetails>();
            storedProcedureResult.CardDetails = (List<CardDetails>)await result.ReadAsync<CardDetails>();

            return storedProcedureResult;
        }

        public async Task<IEnumerable<UpdateSMSAlertstoIndividualCardUsersModelOutput>> UpdateSMSAlertstoIndividualCardUsers([FromBody] UpdateSMSAlertstoIndividualCardUsersModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeSMSAlertsToIndividualCardUsers");
            dtDBR.Columns.Add("Cardno", typeof(string));
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("MobileNo", typeof(string));

            var procedureName = "UspUpdateSMSAlertsToIndividualCardUsers";
            var parameters = new DynamicParameters();


            foreach (TypeSMSAlertsToIndividualCardUsers ObjCardLimits in ObjClass.TypeSMSAlertsToIndividualCardUsers)
            {
                DataRow dr = dtDBR.NewRow();
                dr["Cardno"] = ObjCardLimits.CardNo;
                dr["VechileNo"] = ObjCardLimits.VechileNo;
                dr["MobileNo"] = ObjCardLimits.MobileNo;

                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }


            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);

            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);


            parameters.Add("TypeSMSAlertsToIndividualCardUsers", dtDBR, DbType.Object, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateSMSAlertstoIndividualCardUsersModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<DeleteSMSAlertstoIndividualCardUsersModelOutput>> DeleteSMSAlertsToIndividualCardUsers([FromBody] DeleteSMSAlertstoIndividualCardUsersModelInput ObjClass)
        {
            var procedureName = "UspDeleteSMSAlertsToIndividualCardUsers";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);

            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DeleteSMSAlertstoIndividualCardUsersModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


        }


        public async Task<IEnumerable<UpdateDNDConfigureSMSAlertsModelOutput>> UpdateDNDConfigureSMSAlerts([FromBody] UpdateDNDConfigureSMSAlertsModelInput ObjClass)
        {
            var procedureName = "UspUpdateDNDConfigureSMSAlerts";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);

            
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateDNDConfigureSMSAlertsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


        }

    }
}
