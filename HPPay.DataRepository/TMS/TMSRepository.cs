using Dapper;
using HPPay.DataModel.TMS;
using HPPay.DataRepository.DBDapper;
using HPPay.Infrastructure.CommonClass;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.TMS
{
    public class TMSRepository : ITMSRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        public TMSRepository(DapperContext context, IHostingEnvironment hostingEnvironment, IConfiguration configuration) // , IConfiguration configuration
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        public async Task<IEnumerable<GetEnrollTransportManagementSystemModelOutput>> GetEnrollTransportManagementSystem([FromBody] GetEnrollTransportManagementSystemModelInput ObjClass)
        {
            var procedureName = "UspGetEnrollTransportManagementSystem";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetEnrollTransportManagementSystemModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetEnrollmentStatusModelOutput>> GetEnrollmentStatus([FromBody] GetEnrollmentStatusModelInput ObjClass)
        {
            var procedureName = "UspGetEnrollmentStatus";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetEnrollmentStatusModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);

        }
        public async Task<GetEnrollVehicleModelOutput> GetEnrollVehicle([FromBody] GetEnrollVehicleModelInput ObjClass)
        {
            var procedureName = "UspGetEnrollVehicle";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("EnrollmentStatus", ObjClass.EnrollmentStatus, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetEnrollVehicleModelOutput();
            storedProcedureResult.ObjGetEnrollVehicleCustomerName = (List<GetEnrollVehicleCustomerNameModelOutput>)await result.ReadAsync<GetEnrollVehicleCustomerNameModelOutput>();
            storedProcedureResult.ObjGetEnrollVehicle = (List<GetStatusEnrollVehicleModelOutput>)await result.ReadAsync<GetStatusEnrollVehicleModelOutput>();
            return storedProcedureResult;
        }
        public async Task<IEnumerable<GetManageEnrollmentsModelOutput>> GetManageEnrollments([FromBody] GetManageEnrollmentsModelInput ObjClass)
        {
            var procedureName = "UspGetManageEnrollmentDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetManageEnrollmentsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async void InsertAPIRequestResponse([FromBody] ApiRequestResponse ObjClass)
        {
            var procedureName = "UspInsertApiRequestResponse";
            var parameters = new DynamicParameters();
            parameters.Add("Request", ObjClass.request, DbType.String, ParameterDirection.Input);
            parameters.Add("Response", ObjClass.response, DbType.String, ParameterDirection.Input);
            parameters.Add("Apiurl", ObjClass.apiurl, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.UserId, DbType.String, ParameterDirection.Input);
            parameters.Add("TMSUserId", ObjClass.TMSUserId, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("TMSStatus", ObjClass.TMSStatus, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var res = await connection.QueryAsync<object>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CargoFlRegisterTrucker>> GetCargoFlRegisterTruckerDetail([FromBody] string CustomerId)
        {
            var procedureName = "UspGetCargoFlRegisterTruckerDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CargoFlRegisterTrucker>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCustomerDetailForEnrollmentApprovalOutput>> GetCustomerDetailForEnrollmentApproval([FromBody] GetCustomerDetailForEnrollmentApprovalInput ObjClass)
        {
            var procedureName = "UspGetCustomerDetailForEnrollmentApproval";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("TMSUserId", ObjClass.TMSUserId, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("TMSStatus", Convert.ToString(ObjClass.TMSStatus), DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCustomerDetailForEnrollmentApprovalOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetEnrollmentStatusModelOutput>> GetEnrollmentStatus()
        {
            var procedureName = "UspGetTMSEnrollmentStatus";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetEnrollmentStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<TMSUpdateEnrollmentStatusModelOutput>> TMSInsertCustomerTracking([FromBody] TMSUpdateEnrollmentStatusModelInput ObjClass, string Apiurl)
        {
            var dtDBR = new DataTable("CustomerTracking");
            dtDBR.Columns.Add("CustomerID", typeof(string));
            dtDBR.Columns.Add("TMSUserId", typeof(string));
            dtDBR.Columns.Add("TMSStatus", typeof(int));
            dtDBR.Columns.Add("Remarks", typeof(string));
            dtDBR.Columns.Add("CreatedBy", typeof(string));

            List<TMSUpdateEnrollmentStatusModelOutput> resultobj = new List<TMSUpdateEnrollmentStatusModelOutput>();

            if (ObjClass.TMSUpdateEnrollmentCustomerList != null)
            {
                foreach (TMSInsertEnrollmentApprovalCustomerTrackingInput ObjDetail in ObjClass.TMSUpdateEnrollmentCustomerList)
                {
                    string apiurl = string.Empty;

                    ApiRequestResponse response = new ApiRequestResponse();
                    CargoFlLoginResponse cargoFlLoginResponse = new CargoFlLoginResponse();
                    CargoFlLogin obj = new CargoFlLogin() { cargofl_userid = ObjDetail.TMSUserId };//_configuration.GetSection("TMSSettings:CargoFLUser").Value };

                    HttpResponseMessage apiResponse = Variables.CallPostAPI(Apiurl + "v1/common/loginSuperUser", JsonConvert.SerializeObject(obj), "").Result;
                    string json = "";
                    if (apiResponse.IsSuccessStatusCode)
                    {
                        json = apiResponse.Content.ReadAsStringAsync().Result;
                    }
                    if (!string.IsNullOrEmpty(json))
                    {
                        cargoFlLoginResponse = JsonConvert.DeserializeObject<CargoFlLoginResponse>(json);
                    }
                    //var dat = JObject.Parse(json);
                    response.apiurl = Apiurl + "v1/common/loginSuperUser";
                    response.request = JsonConvert.SerializeObject(obj);
                    response.response = apiResponse.Content.ReadAsStringAsync().Result;
                    response.UserId = ObjDetail.CreatedBy;
                    InsertAPIRequestResponse(response);
                    if ((string.IsNullOrEmpty(json) && response.response.Contains("message"))|| !response.response.ToUpper().Contains("USER LOGGED IN SUCCESSFULLY"))
                    {
                        cargoFlLoginResponse = JsonConvert.DeserializeObject<CargoFlLoginResponse>(response.response);

                        TMSUpdateEnrollmentStatusModelOutput tmsobj = new TMSUpdateEnrollmentStatusModelOutput() { Status = 0, Reason = cargoFlLoginResponse.message };
                        resultobj.Add(tmsobj);
                        return resultobj;
                    }

                    if (cargoFlLoginResponse != null && !string.IsNullOrEmpty(cargoFlLoginResponse.access_token))
                    {
                        if (ObjDetail.TMSStatusID == 2)
                        {
                            apiurl = Apiurl + "v1/user/enableTrucker";
                        }
                        else if (ObjDetail.TMSStatusID == 3 || ObjDetail.TMSStatusID == 4)
                        {
                            apiurl = Apiurl + "v1/user/disableTrucker";
                        }


                        HttpResponseMessage apiResult = Variables.CallPostAPI(apiurl, JsonConvert.SerializeObject(obj), cargoFlLoginResponse.access_token).Result;
                        string res = string.Empty;
                        if (apiResult.IsSuccessStatusCode)
                        {
                            res = apiResult.Content.ReadAsStringAsync().Result;
                        }
                        response.apiurl = apiurl;
                        response.request = JsonConvert.SerializeObject(obj);


                        response.response = apiResult.Content.ReadAsStringAsync().Result; ;
                        CargoFlLoginResponse objResponce = new CargoFlLoginResponse();
                        if (!string.IsNullOrEmpty(res))
                        {

                            objResponce = JsonConvert.DeserializeObject<CargoFlLoginResponse>(res);

                            response.TMSUserId = obj.cargofl_userid;
                            response.CustomerId = ObjDetail.CustomerID;
                            response.TMSStatus = ObjDetail.TMSStatusID;

                        }

                        InsertAPIRequestResponse(response);
                        if ((string.IsNullOrEmpty(res) && response.response.Contains("message"))|| (!objResponce.message.Trim().ToUpper().Contains("USER ENABLED SUCCESSFULLY") && !objResponce.message.Trim().ToUpper().Contains("USER DISABLED SUCCESSFULLY")))
                        {
                            objResponce = JsonConvert.DeserializeObject<CargoFlLoginResponse>(response.response);

                            TMSUpdateEnrollmentStatusModelOutput tmsobj = new TMSUpdateEnrollmentStatusModelOutput() { Status = 0, Reason = objResponce.message };
                            resultobj.Add(tmsobj);
                            return resultobj;
                        }
                        if (!string.IsNullOrEmpty(objResponce.message) && (objResponce.message.Trim().ToUpper().Contains("USER ENABLED SUCCESSFULLY") || objResponce.message.Trim().ToUpper().Contains("USER DISABLED SUCCESSFULLY")))
                        {

                            DataRow dr = dtDBR.NewRow();
                            dr["Remarks"] = ObjDetail.Remarks;
                            dr["CustomerID"] = ObjDetail.CustomerID;
                            dr["TMSUserId"] = ObjDetail.TMSUserId;
                            dr["TMSStatus"] = Convert.ToInt32(ObjDetail.TMSStatusID);

                            dr["CreatedBy"] = ObjClass.Userid;

                            dtDBR.Rows.Add(dr);
                            dtDBR.AcceptChanges();
                        }
                    }
                }
            }
            var procedureName = "UspTMSInsertEnrollmentCustomerTracking";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerTracking", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<TMSUpdateEnrollmentStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetEnrollVehicleManagementModeloutput>> GetEnrollVehicleManagementDetail([FromBody] GetEnrollVehicleManagementModelInput ObjClass)
        {
            var procedureName = "UspGetEnrollVehicleManagementDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("EnrollmentStatus", ObjClass.EnrollmentStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleNo", ObjClass.VehicleNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetEnrollVehicleManagementModeloutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetEnrollVehicleManagementStatusOutput>> GetEnrollVehicleManagementStatus()
        {
            var procedureName = "UspGetVehicleEnrollmentStatus";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetEnrollVehicleManagementStatusOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InsertVehicleEnrollmentStatusOutput>> InsertVehicleEnrollmentStatus(InsertVehicleEnrollmentStatusInput ObjClass)
        {
            var dtDBR = new DataTable("CardVehicleDetail");
            dtDBR.Columns.Add("CustomerID", typeof(string));
            //dtDBR.Columns.Add("TMSUserId", typeof(string));
            dtDBR.Columns.Add("EnrollmentStatus", typeof(int));
            dtDBR.Columns.Add("CardNo", typeof(string));
            dtDBR.Columns.Add("VehicleNo", typeof(string));
            dtDBR.Columns.Add("CreatedBy", typeof(string));

            if (ObjClass.VehicleEnrollmentStatusList != null)
            {

                foreach (var item in ObjClass.VehicleEnrollmentStatusList)
                {

                    DataRow dr = dtDBR.NewRow();
                    dr["CustomerID"] = item.CustomerID;
                    dr["EnrollmentStatus"] = 1;
                    dr["CardNo"] = item.CardNo;
                    dr["VehicleNo"] = item.VehicleNo;
                    dr["CreatedBy"] = item.CreatedBy;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();


                }

            }
            var procedureName = "UspInsertVehicleEnrollmentStatus";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            parameters.Add("CardVehicle", dtDBR, DbType.Object, ParameterDirection.Input);
            return await connection.QueryAsync<InsertVehicleEnrollmentStatusOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetTransportManagementSystemModelOutput>> GetActiveApprovedCustomer(GetTransportManagementSystemModelInput ObjClass)
        {
            var procedureName = "UspGetActiveApprovedCustomer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetTransportManagementSystemModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<BindEnrollTransportManagementSystemModelOutput>> BindEnrollTransportManagementSystem([FromBody] BindEnrollTransportManagementSystemModelInput ObjClass)
        {
            var procedureName = "UspBindEnrollTransportManagementSystem";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BindEnrollTransportManagementSystemModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetDetailsForCustomerUpdateModelOutput>> GetDetailsForCustomerUpdate([FromBody] GetDetailsForCustomerUpdateModelInput ObjClass)
        {
            var procedureName = "UspGetDetailsForCustomerUpdate";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDetailsForCustomerUpdateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateCustomerAddressModelOutput>> UpdateCustomerAddress([FromBody] UpdateCustomerAddressModelInput ObjClass)
        {
            var procedureName = "UspUpdateCustomerAddress";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress1", ObjClass.CommunicationAddress1, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress2", ObjClass.CommunicationAddress2, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationAddress3", ObjClass.CommunicationAddress3, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationLocation", ObjClass.CommunicationLocation, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCityName", ObjClass.CommunicationCityName, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationPincode", ObjClass.CommunicationPincode, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationDistrictId", ObjClass.CommunicationDistrictId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CommunicationPhoneNo", ObjClass.CommunicationPhoneNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationMobileNo", ObjClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationFax", ObjClass.CommunicationFax, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationEmailid", ObjClass.CommunicationEmailid, DbType.String, ParameterDirection.Input);
            parameters.Add("IncomeTaxPan", ObjClass.IncomeTaxPan, DbType.String, ParameterDirection.Input);
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
            parameters.Add("PanCardRemarks", ObjClass.PanCardRemarks, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCustomerAddressModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateCustomerDetailForEnrollmentApprovalModelOutput>> UpdateCustomerDetailForEnrollmentApproval([FromBody] UpdateCustomerDetailForEnrollmentApprovalModelInput ObjClass)
        {
            var dtDBR = new DataTable("CustomerTracking");
            dtDBR.Columns.Add("CustomerID", typeof(string));
            dtDBR.Columns.Add("TMSUserId", typeof(string));
            dtDBR.Columns.Add("TMSStatus", typeof(int));
            dtDBR.Columns.Add("Remarks", typeof(string));
            dtDBR.Columns.Add("CreatedBy", typeof(string));

            foreach (var ObjDetail in ObjClass.CustomerDetailForEnrollmentApproval)
            {
                DataRow dr = dtDBR.NewRow();
                dr["Remarks"] = ObjDetail.Remarks;
                dr["CustomerID"] = ObjDetail.CustomerID;
                dr["TMSUserId"] = 0;
                dr["TMSStatus"] = Convert.ToInt32(ObjDetail.TMSStatus);

                dr["CreatedBy"] = ObjClass.Userid;

                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }
            if (dtDBR.Rows.Count > 0)
            {
                var procedureName = "UspUpdateCustomerDetailForEnrollmentApproval";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerTracking", dtDBR, DbType.Object, ParameterDirection.Input);
                using var connection = _context.CreateConnection();
                return await connection.QueryAsync<UpdateCustomerDetailForEnrollmentApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
            else
            {
                return null;
            }
        }

    }

}
