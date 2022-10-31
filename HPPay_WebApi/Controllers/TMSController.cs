using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using HPPay_WebApi.ExtensionMethod;
using HPPay_WebApi.ActionFilters;
using HPPay.DataModel.TMS;
using System.Linq;
using HPPay.DataRepository.TMS;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using static HPPay_WebApi.ActionFilters.CustomAuthenticationFilter;
using Microsoft.AspNetCore.Routing;
using System;
using System.IO;
using System.Text;
using System.Net.Http.Headers;
using HPPay.Infrastructure.CommonClass;

namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/dtplus/TMS")]
    public class TMSController : Controller
    {
        private readonly ILogger<TMSController> _logger;

        private readonly ITMSRepository _tmsRepo;
        private readonly IConfiguration _configuration;
        public TMSController(ILogger<TMSController> logger, ITMSRepository tmsRepo, IConfiguration configuration)
        {
            _logger = logger;
            _tmsRepo = tmsRepo;
            _configuration = configuration;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_enroll_transport_management_system")]
        public async Task<IActionResult> GetEnrollTransportManagementSystem([FromBody] GetEnrollTransportManagementSystemModelInput ObjClass)
        {
            

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmsRepo.GetEnrollTransportManagementSystem(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<GetEnrollTransportManagementSystemModelOutput>().ToList()[0].Status == 1)
                    {
                        ApiRequestResponse response = new ApiRequestResponse();
                        CargoFlLoginResponse cargoFlLoginResponse = new CargoFlLoginResponse();
                        CargoFlLogin obj = new CargoFlLogin() { cargofl_userid = _configuration.GetSection("TMSSettings:CargoFLUser").Value };
                        // string cargofl_userid = "admin";
                        string apiurl = _configuration.GetSection("TMSSettings:APIUrl").Value;

                         HttpResponseMessage apiResponse = Variables.CallPostAPI(apiurl + "v1/common/loginSuperUser", JsonConvert.SerializeObject(obj), "").Result;
                        string json=string.Empty;
                        if (apiResponse.IsSuccessStatusCode)
                        {
                            json = apiResponse.Content.ReadAsStringAsync().Result;
                        }
                        if (!string.IsNullOrEmpty(json))
                        {
                            cargoFlLoginResponse = JsonConvert.DeserializeObject<CargoFlLoginResponse>(json);
                        }
                        //var dat = JObject.Parse(json);

                        response.apiurl = apiurl + "v1/common/loginSuperUser";
                        response.request = JsonConvert.SerializeObject(obj);
                        response.response = apiResponse.Content.ReadAsStringAsync().Result;
                        response.UserId = ObjClass.Userid;
                        _tmsRepo.InsertAPIRequestResponse(response);


                        CargoFlRegisterTrucker objcargoFL = new CargoFlRegisterTrucker();
                        var cargoflUser = _tmsRepo.GetCargoFlRegisterTruckerDetail(ObjClass.CustomerId).Result.ToList<CargoFlRegisterTrucker>();
                        if (cargoflUser != null && cargoflUser.Count > 0)
                        {
                            objcargoFL = cargoflUser.ToList().FirstOrDefault();
                        }
                        HttpResponseMessage apiResult = Variables.CallPostAPI(apiurl + "v1/user/registerTrucker", JsonConvert.SerializeObject(objcargoFL), cargoFlLoginResponse.access_token).Result;
                        string res = string.Empty;
                        if (apiResult.IsSuccessStatusCode)
                        {
                            res = apiResult.Content.ReadAsStringAsync().Result;
                        }
                        response.apiurl = apiurl + "v1/user/registerTrucker";
                        response.request = JsonConvert.SerializeObject(objcargoFL);


                        response.response = apiResult.Content.ReadAsStringAsync().Result;
                        List<CargoFlResponse>  objlst = new List<CargoFlResponse>();
                        if (!string.IsNullOrEmpty(res))
                        {
                            CargoFlResponse objval = new CargoFlResponse();
                            objval = JsonConvert.DeserializeObject<CargoFlResponse>(res);

                            response.TMSUserId = objval.cargofl_userid;
                            response.CustomerId = ObjClass.CustomerId;
                            response.TMSStatus = 1;
                            objval.Reason = objval.message;
                            if(!String.IsNullOrEmpty(objval.message) && objval.message.ToUpper().Contains( "USER ADDED SUCCESSFULLY"))
                            {
                                objval.Status = 1;
                            }
                            else
                            {
                                objval.Status = 0;
                            }

                            objval.message = "";
                            
                            objlst.Add(objval);

                        }
                        else
                        {
                            CargoFlResponse objval = new CargoFlResponse();
                            objval.Reason = "No Response Coming From TMS API";
                            objval.message = "";
                            objval.Status = 0;
                            objlst.Add(objval);

                        }
                        _tmsRepo.InsertAPIRequestResponse(response);
                        if (objlst !=null && objlst.Count()>0 && objlst[0].Status==1)                       
                            return this.OkCustom(ObjClass, objlst, _logger);
                        else
                            return this.FailCustom(ObjClass, objlst, _logger,"");
                    }
                    else
                    {

                        return this.FailCustom(ObjClass, result, _logger,
                        result.Cast<GetEnrollTransportManagementSystemModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_enrollment_status")]
        public async Task<IActionResult> GetEnrollmentStatus([FromBody] GetEnrollmentStatusModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmsRepo.GetEnrollmentStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetEnrollmentStatusModelOutput> item = result.Cast<GetEnrollmentStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_enroll_vehicle")]
        public async Task<IActionResult> GetEnrollVehicle([FromBody] GetEnrollVehicleModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmsRepo.GetEnrollVehicle(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.ObjGetEnrollVehicle.Count > 0 && result.ObjGetEnrollVehicleCustomerName.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_manage_enrollments")]
        public async Task<IActionResult> GetManageEnrollments([FromBody] GetManageEnrollmentsModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmsRepo.GetManageEnrollments(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetManageEnrollmentsModelOutput> item = result.Cast<GetManageEnrollmentsModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_customer_detail_for_enrollment_approval")]
        public async Task<IActionResult> GetCustomerDetailForEnrollmentApproval([FromBody] GetCustomerDetailForEnrollmentApprovalInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmsRepo.GetCustomerDetailForEnrollmentApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetCustomerDetailForEnrollmentApprovalOutput> item = result.Cast<GetCustomerDetailForEnrollmentApprovalOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger,"");
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_tms_enrollment_status")]
        public async Task<IActionResult> GetEnrollmentStatusDetail(GetEnrollmentStatusModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {

                var result = await _tmsRepo.GetEnrollmentStatus();
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetEnrollmentStatusModelOutput> item = result.Cast<GetEnrollmentStatusModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
            
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_tms_enrollment_tms_status")]
        public async Task<IActionResult> UpdateTMSEnrollmentTMSStatus([FromBody] TMSUpdateEnrollmentStatusModelInput ObjClass)
        {
            
            string apiurl = _configuration.GetSection("TMSSettings:APIUrl").Value;

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmsRepo.TMSInsertCustomerTracking(ObjClass, apiurl);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<TMSUpdateEnrollmentStatusModelOutput>().ToList()[0].Status==1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<TMSUpdateEnrollmentStatusModelOutput>().ToList()[0].Reason);

                }
            }

        }



        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_vehicle_enrollment_detail")]
        public async Task<IActionResult> GetEnrollVehicleManagementDetail([FromBody] GetEnrollVehicleManagementModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmsRepo.GetEnrollVehicleManagementDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetEnrollVehicleManagementModeloutput> item = result.Cast<GetEnrollVehicleManagementModeloutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_vehicle_enrollment_status")]
        public async Task<IActionResult> GetEnrollVehicleManagementStatus([FromBody] GetEnrollVehicleManagementStatusInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmsRepo.GetEnrollVehicleManagementStatus();
                if (result == null)
                {
                    return this.NotFoundCustom(null, null, _logger);
                }
                else
                {
                    List<GetEnrollVehicleManagementStatusOutput> item = result.Cast<GetEnrollVehicleManagementStatusOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(null, result, _logger);
                    else
                        return this.Fail(null, result, _logger);
                }
            }
            
        }

        [HttpPost]
       [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_vehicle_enrollment_status")]
        public async Task<IActionResult> InsertVehicleEnrollmentStatus([FromBody] InsertVehicleEnrollmentStatusInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmsRepo.InsertVehicleEnrollmentStatus(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(null, null, _logger);
                }
                else
                {
                    List<InsertVehicleEnrollmentStatusOutput> item = result.Cast<InsertVehicleEnrollmentStatusOutput>().ToList();
                    if (item.Count > 0 && item[0].Status==1)
                        return this.OkCustom(null, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger, item[0].Reason);
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_transport_management_system_url")]
        public async Task<IActionResult> GetTransportManagementSystemUrl([FromBody] GetTransportManagementSystemModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmsRepo.GetActiveApprovedCustomer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetTransportManagementSystemModelOutput> item = result.Cast<GetTransportManagementSystemModelOutput>().ToList();
                    if (item.Count > 0)
                    {
                        if(item[0].Status == 1)
                        {
                            ApiRequestResponse response = new ApiRequestResponse();
                            CargoFlLoginResponse cargoFlLoginResponse = new CargoFlLoginResponse();
                            CargoFlLogin obj= new CargoFlLogin() {cargofl_userid= item[0].TMSUserId};
                            string apiurl = _configuration.GetSection("TMSSettings:APIUrl").Value;
                            HttpResponseMessage apiResponse = Variables.CallPostAPI(apiurl + "v1/common/loginSuperUser", JsonConvert.SerializeObject(obj), "").Result;
                            string json="";
                            if(apiResponse.IsSuccessStatusCode)
                            {
                                json = apiResponse.Content.ReadAsStringAsync().Result;  
                            }                           
                            
                            if (!string.IsNullOrEmpty(json))
                            {
                                cargoFlLoginResponse = JsonConvert.DeserializeObject<CargoFlLoginResponse>(json);
                            }
                            //var dat = JObject.Parse(json);

                            response.apiurl = apiurl + "v1/common/loginSuperUser";
                            response.request = JsonConvert.SerializeObject(obj);
                            response.response = apiResponse.Content.ReadAsStringAsync().Result;
                            response.UserId = ObjClass.Userid;
                            _tmsRepo.InsertAPIRequestResponse(response);

                            if (cargoFlLoginResponse != null && !string.IsNullOrEmpty(cargoFlLoginResponse.message) && cargoFlLoginResponse.message.ToUpper().Contains("USER LOGGED IN SUCCESSFULLY"))
                            {
                                item[0].Url = _configuration.GetSection("TMSSettings:TransportSystemUrl").Value;
                            }
                            else
                            {
                                item[0].Reason =" User Logged in fail in API";
                                item[0].Status = 0;
                            }
                            item[0].access_token = cargoFlLoginResponse.access_token;
                            item[0].message = cargoFlLoginResponse.message;
                            item[0].refresh_token = cargoFlLoginResponse.refresh_token;
                            if(item[0].Status==0)
                            {
                                return this.FailCustom(ObjClass, item, _logger, item[0].message);
                            }
                            return this.OkCustom(ObjClass, item, _logger);
                        }
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("bind_enroll_transport_management_system")]
        public async Task<IActionResult> BindEnrollTransportManagementSystem([FromBody] BindEnrollTransportManagementSystemModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmsRepo.BindEnrollTransportManagementSystem(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<BindEnrollTransportManagementSystemModelOutput> item = result.Cast<BindEnrollTransportManagementSystemModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_details_for_customer_update")]
        public async Task<IActionResult> GetDetailsForCustomerUpdate([FromBody] GetDetailsForCustomerUpdateModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmsRepo.GetDetailsForCustomerUpdate(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDetailsForCustomerUpdateModelOutput> item = result.Cast<GetDetailsForCustomerUpdateModelOutput>().ToList();
                    if (item.Count > 0 && item[0].Status ==1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.FailCustom(ObjClass, result, _logger,"");
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_customer_address")]
        public async Task<IActionResult> UpdateCustomerAddress([FromBody] UpdateCustomerAddressModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmsRepo.UpdateCustomerAddress(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateCustomerAddressModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<UpdateCustomerAddressModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_customer_detail_for_enrollment_approval")]
        public async Task<IActionResult> GeUpdateCustomerDetailForEnrollmentApproval([FromBody] UpdateCustomerDetailForEnrollmentApprovalModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _tmsRepo.UpdateCustomerDetailForEnrollmentApproval(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<UpdateCustomerDetailForEnrollmentApprovalModelOutput> item = result.Cast<UpdateCustomerDetailForEnrollmentApprovalModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

    }

}
