using HPPay.DataModel.DBConstants;
using HPPay.DataModel.Fastlane;
using HPPay.DataRepository.Fastlane;
using HPPay.Infrastructure.CommonClass;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/hppay/tapandpay")]
    public class FastlaneIntegrationController : Controller
    {
        private readonly ILogger<FastlaneIntegrationController> _logger;
        private readonly IFastlaneIntegrationRepository _hPPayFastlaneIntegrationRepository;
        private readonly IConfiguration _configuration;

        private static string publickeyforDataEncryption;
        private static string privateKeyforResponseDecryption;
        private static string fastLaneAGSApiKey;

        public FastlaneIntegrationController(
            ILogger<FastlaneIntegrationController> logger
            , IFastlaneIntegrationRepository hPPayFastlaneIntegrationRepository
            , IConfiguration configuration)
        {
            _logger = logger;
            _hPPayFastlaneIntegrationRepository = hPPayFastlaneIntegrationRepository;
            _configuration = configuration;

            publickeyforDataEncryption = _configuration.GetSection("TapAndPay:PublickeyforDataEncryption").Value;
            privateKeyforResponseDecryption = _configuration.GetSection("TapAndPay:PrivateKeyforResponseDecryption").Value;
            fastLaneAGSApiKey = _configuration.GetSection("TapAndPay:FastLaneAGSApiKey").Value;
        }


        [HttpPost]
        // [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("GetActiveCityList")]
        public async Task<IActionResult> GetActiveCityList(ActiveCityList_Request objClass)
        {
            try
            {

                if (objClass == null)
                {
                    return this.BadRequestCustom(objClass, null, _logger);
                }
                else
                {
                    ActiveCityList_Response activeCityLists = await _hPPayFastlaneIntegrationRepository.GetActiveCityList();
                    if (activeCityLists?.activeCityLists == null)
                    {
                        return this.NotFoundCustom(objClass, null, _logger);
                    }
                    else
                    {
                        if (activeCityLists?.activeCityLists?.Count == 0 && activeCityLists?.ResponseCode == 1)
                        {
                            activeCityLists = new ActiveCityList_Response()
                            {
                                ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                                ResponseMessage = $"Failure - {activeCityLists.ResponseMessage}",
                                ErrorCode = activeCityLists is null ? 1 : activeCityLists.ErrorCode,
                                activeCityLists = null,
                            };
                            return this.Fail(objClass, activeCityLists, _logger);
                        }
                        else if (activeCityLists?.activeCityLists?.Count > 0)
                        {
                            return this.OkCustom(objClass, activeCityLists, _logger);
                        }
                        else
                            return this.Fail(objClass, activeCityLists, _logger);
                    }
                }
            }
            catch (Exception ex)
            {
                var activeCityLists = new List<ActiveCityList_Response>()
                {
                    new ActiveCityList_Response()
                    {
                        ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                        ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                        ErrorCode = 500,
                    }
                };
                return this.Fail("", activeCityLists, _logger);
            }
        }

        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("CustomerRegistration")]
        public async Task<IActionResult> CustomerRegistration(CustomerRegistration_Request objClass)
        {
            List<CustomerRegistration_Response> customerRegistration_Respopnse = null;
            try
            {
                CustomerRegistration_CustomerInfo_Response customerInfo =
                    await _hPPayFastlaneIntegrationRepository.GetCustomerInfo_CustomerRegistration(objClass);

                if (customerInfo == null
                    || customerInfo?.ResponseCode == 1)
                {
                    customerRegistration_Respopnse = new List<CustomerRegistration_Response>()
                    {
                        new CustomerRegistration_Response()
                        {
                            CustomerID = 0,
                            FastlaneID = string.Empty,
                            Status = string.Empty,
                            Message = string.Empty,
                            ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                            ResponseMessage = $"Failure - No Record Found for the given details or {customerInfo?.ResponseMessage}",
                            ErrorCode = customerInfo is null ? 1 : customerInfo.ErrorCode,
                        }
                    };

                    return this.Fail("", customerRegistration_Respopnse, _logger);
                }

                string customerInfoData = Convert.ToString(JsonConvert.DeserializeObject(JsonConvert.SerializeObject(customerInfo)));

                string encryptedCustomerInfo = Crypto.Encrypt(customerInfoData, publickeyforDataEncryption);
                encryptedCustomerInfo = "{\"Data\" : \"" + encryptedCustomerInfo + "\"}";

                string ResponseString = string.Empty;
                string customerregistrationuri = _configuration.GetSection("TapAndPay:CustomerRegistrationURI").Value;
                Uri u = new Uri(customerregistrationuri);

                string customerRegistrationAction = _configuration.GetSection("TapAndPay:CustomerRegistrationAction").Value;

                HttpContent c = new StringContent(encryptedCustomerInfo, Encoding.UTF8, "application/json");
                var t = Task.Run(() => APIHelper.PostURI_Fastlane_CustomerRegistration(u, c, customerRegistrationAction, fastLaneAGSApiKey));
                t.Wait();

                HttpResponseMessage response = t.Result;
                ResponseString = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                };

                List<CryptoDecryptResponse> custregistrationEncryptedResult = System.Text.Json.JsonSerializer.Deserialize<List<CryptoDecryptResponse>>(ResponseString, options);

                string decryptedCustomerInfo = Crypto.Decrypt(custregistrationEncryptedResult[0].Data, privateKeyforResponseDecryption);

                customerRegistration_Respopnse = JsonConvert.DeserializeObject<List<CustomerRegistration_Response>>(decryptedCustomerInfo);

                if (customerRegistration_Respopnse is null)
                {
                    customerRegistration_Respopnse = new List<CustomerRegistration_Response>()
                    {
                        new CustomerRegistration_Response()
                        {
                            CustomerID = 0,
                            FastlaneID = string.Empty,
                            Status = string.Empty,
                            Message = string.Empty,
                            ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                            ResponseMessage = $"Failure - No Record Found or {customerInfo?.ResponseMessage}",
                            ErrorCode = customerInfo is null ? 1 : customerInfo.ErrorCode,
                        }
                    };

                    return this.Fail("", customerRegistration_Respopnse, _logger);
                }
                else
                {
                    customerRegistration_Respopnse[0].Status = custregistrationEncryptedResult[0].Status;
                    customerRegistration_Respopnse[0].Message = custregistrationEncryptedResult[0].Message;
                    customerRegistration_Respopnse[0].ResponseCode = Convert.ToInt16(ResponseCode.Success);
                    customerRegistration_Respopnse[0].ResponseMessage = "Success";
                    customerRegistration_Respopnse[0].ErrorCode = 0;

                    if (!customerRegistration_Respopnse[0].ResponseMessage.ToUpper().Contains("SUCCESSFUL"))
                    {
                        customerRegistration_Respopnse[0].ResponseCode = Convert.ToInt16(ResponseCode.Failure);
                        customerRegistration_Respopnse[0].ResponseMessage = $"Failure - {custregistrationEncryptedResult[0].Message}";
                        customerRegistration_Respopnse[0].ErrorCode = 1;

                        return this.Fail("", customerRegistration_Respopnse, _logger);
                    }

                    await _hPPayFastlaneIntegrationRepository.UpdateLoyalUserFastlaneId(customerRegistration_Respopnse[0]);

                    return this.OkCustom("", customerRegistration_Respopnse, _logger);
                }
            }
            catch (Exception ex)
            {

                customerRegistration_Respopnse = new List<CustomerRegistration_Response>()
                {
                    new CustomerRegistration_Response()
                    {
                        ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                        ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                        ErrorCode = 500,
                    }
                };

                return this.Fail("", customerRegistration_Respopnse, _logger);
            }
        }


        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("VehicleValidation")]
        public async Task<IActionResult> VehicleValidation(VehicleValidation objClass)
        {
            VahanVehicleDetail vahanVehicleDetails = null;
            try
            {
                vahanVehicleDetails = await _hPPayFastlaneIntegrationRepository.GetVahanVehicleDetail(objClass);

                if (vahanVehicleDetails is null)
                {
                    string responseString = string.Empty;
                    string vehicleAuthenticationURI = _configuration.GetSection("TapAndPay:VehicleAuthenticationURI").Value;
                    Uri u = new Uri(vehicleAuthenticationURI);

                    var payload = new Dictionary<string, object>
                    {
                        {"registrationNumber",  objClass.VehicleNumber},
                        {"consent",  objClass.Consent},
                        {"version",  objClass.Version}
                    };

                    HttpContent c = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                    string xkarzakey = _configuration.GetSection("TapAndPay:VehicleAuthenticationxkarzakey").Value;
                    var t = Task.Run(() => APIHelper.PostURI_Fastlane_VehicleAuthentication(u, c, xkarzakey));
                    t.Wait();

                    HttpResponseMessage response = t.Result;
                    responseString = await response.Content.ReadAsStringAsync();

                    VahanVehicleDetailobject vahanVehicleDetail_Response = JsonConvert.DeserializeObject<VahanVehicleDetailobject>(responseString);

                    if (vahanVehicleDetail_Response is null)
                    {
                        vahanVehicleDetails = new VahanVehicleDetail()
                        {
                            Vehicle_Number = string.Empty,
                            Registration_Date = string.Empty,
                            Owner_Name = string.Empty,
                            Fuel_Type = string.Empty,
                            Model_MakerClass = string.Empty,
                            Maker_Manufacturer = string.Empty,
                            Insurance_Upto = string.Empty,
                            Modified = null,
                            Message = string.Empty,
                            ResponseStatus = "1",
                            ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                            ResponseMessage = $"Failure - No Record Found for the given details",
                            ErrorCode = 1,
                        };

                        return this.Fail("", vahanVehicleDetails, _logger);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(vahanVehicleDetail_Response?.result?.registrationNumber)
                            || vahanVehicleDetail_Response?.result?.registrationNumber.ToUpper() != objClass.VehicleNumber.ToUpper())
                        {
                            vahanVehicleDetails = new VahanVehicleDetail()
                            {
                                Vehicle_Number = string.Empty,
                                Registration_Date = string.Empty,
                                Owner_Name = string.Empty,
                                Fuel_Type = string.Empty,
                                Model_MakerClass = string.Empty,
                                Maker_Manufacturer = string.Empty,
                                Insurance_Upto = string.Empty,
                                Modified = null,
                                Message = string.Empty,
                                ResponseStatus = "1",
                                ResponseMsg = $"Failure, The given vehicle number - {objClass.VehicleNumber} " +
                                $"not matching with the VahanVehicleDetail databse - {vahanVehicleDetail_Response?.result?.registrationNumber}.",
                                ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                                ResponseMessage = $"Failure - No Record Found for the given details",
                                ErrorCode = 1,
                            };
                            return this.Fail("", vahanVehicleDetails, _logger);
                        }

                        string registration_Date = customdate(vahanVehicleDetail_Response.result.registrationDate);
                        string insurance_Upto_Date = customdate(vahanVehicleDetail_Response.result.insuranceUpto);

                        vahanVehicleDetails = new VahanVehicleDetail()
                        {
                            Vehicle_Number = vahanVehicleDetail_Response.result.registrationNumber,
                            Registration_Date = registration_Date,
                            Owner_Name = vahanVehicleDetail_Response.result.ownerName,
                            Fuel_Type = vahanVehicleDetail_Response.result.fuelDescription,
                            Model_MakerClass = vahanVehicleDetail_Response.result.makerModel,
                            Maker_Manufacturer = vahanVehicleDetail_Response.result.makerDescription,
                            Insurance_Upto = insurance_Upto_Date,
                            Modified = null,
                            Message = response.ReasonPhrase,
                            ResponseStatus = $"StatusCode:{response.StatusCode}, IsSuccessStatusCode:{response.IsSuccessStatusCode}",
                            ResponseMsg = Convert.ToString(JsonConvert.SerializeObject(responseString)),
                            ResponseCode = Convert.ToInt16(ResponseCode.Success),
                            ResponseMessage = $"Success",
                            ErrorCode = 0,
                        };
                        vahanVehicleDetails = await _hPPayFastlaneIntegrationRepository.SaveVahanVehicleDetail(vahanVehicleDetails);

                        vahanVehicleDetails.ResponseStatus = string.Empty;
                        vahanVehicleDetails.ResponseMsg = string.Empty;
                        return this.OkCustom("", vahanVehicleDetails, _logger);
                    }
                }

                vahanVehicleDetails.ResponseStatus = "0";
                vahanVehicleDetails.ResponseMsg = "Success";
                return this.OkCustom("", vahanVehicleDetails, _logger);
            }
            catch (Exception ex)
            {
                vahanVehicleDetails = new VahanVehicleDetail()
                {
                    ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                    ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                    ErrorCode = 500,
                };
                return this.Fail("", vahanVehicleDetails, _logger);
            }
        }


        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("VehicleRegistration")]
        public async Task<IActionResult> VehicleRegistration(Input_VehicleRegistration objClass)
        {
            List<VehicleRegistration_Response> vehicleRegistration_Response = null;
            try
            {
                CustomerRegistration_Response customerRegistration_Response = await _hPPayFastlaneIntegrationRepository.GetLoyalUserDetails(objClass);

                if (customerRegistration_Response is null
                    || customerRegistration_Response?.ResponseCode == 1)
                {
                    vehicleRegistration_Response = new List<VehicleRegistration_Response>()
                    {
                        new VehicleRegistration_Response()
                        {
                            CustomerID = 0,
                            FastlaneID = string.Empty,
                            FastlaneVehicleID = string.Empty,
                            Message = string.Empty,
                            Status = string.Empty,
                            ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                            ResponseMessage = string.IsNullOrEmpty(customerRegistration_Response?.ResponseMessage)
                            ? "Failure or No Record Found" : customerRegistration_Response?.ResponseMessage,
                            ErrorCode = customerRegistration_Response is null ? 1 : customerRegistration_Response.ErrorCode,
                        }
                    };
                    return this.Fail("", vehicleRegistration_Response, _logger);
                }

                string vehicleRegistrationInfo =
                    "{\"CustomerID\": \"" + customerRegistration_Response.CustomerID +
                    "\", \"VehicleNo\": \"" + objClass.VehicleNumber +
                    "\", \"FuelType\": \"" + objClass.FuelType +
                    "\", \"TankCapacity\": \"\", " +
                    "\"TAGType\": \"\", " +
                    "\"TAGNO\": \"\", " +
                    "\"FastlaneID\" : \"" + customerRegistration_Response.FastlaneID +
                    "\"}";

                string encryptedVehicleInfo = Crypto.Encrypt(vehicleRegistrationInfo, publickeyforDataEncryption);
                encryptedVehicleInfo = "{\"Data\" : \"" + encryptedVehicleInfo + "\"}";

                string ResponseString = string.Empty;
                string vehicleRegistrationURI = _configuration.GetSection("TapAndPay:VehicleRegistrationURI").Value;
                Uri u = new Uri(vehicleRegistrationURI);

                string vehicleRegistrationAction = _configuration.GetSection("TapAndPay:VehicleRegistrationAction").Value;

                HttpContent c = new StringContent(encryptedVehicleInfo, Encoding.UTF8, "application/json");
                var t = Task.Run(() => APIHelper.PostURI_Fastlane_VehicleRegistration(u, c, vehicleRegistrationAction, fastLaneAGSApiKey));
                t.Wait();

                HttpResponseMessage response = t.Result;
                ResponseString = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                };

                List<CryptoDecryptResponse> vehicleRegistrationEncryptedResult = System.Text.Json.JsonSerializer.Deserialize<List<CryptoDecryptResponse>>(ResponseString, options);

                string privateKeyforResponseDecryption = _configuration.GetSection("TapAndPay:PrivateKeyforResponseDecryption").Value;
                string decryptedVehicleInfo = Crypto.Decrypt(vehicleRegistrationEncryptedResult[0].Data, privateKeyforResponseDecryption);

                vehicleRegistration_Response = JsonConvert.DeserializeObject<List<VehicleRegistration_Response>>(decryptedVehicleInfo);

                if (vehicleRegistration_Response is null)
                {
                    VehicleRegistration_Response vehicleRegistration_failure = new VehicleRegistration_Response()
                    {
                        CustomerID = 0,
                        FastlaneID = string.Empty,
                        FastlaneVehicleID = string.Empty,
                        Message = string.Empty,
                        Status = string.Empty,
                        ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                        ResponseMessage = "Failure or No Record Found",
                        ErrorCode = 1,
                    };
                    return this.Fail("", vehicleRegistration_failure, _logger);
                }
                else
                {
                    vehicleRegistration_Response[0].Status = vehicleRegistrationEncryptedResult[0].Status;
                    vehicleRegistration_Response[0].Message = vehicleRegistrationEncryptedResult[0].Message;

                    if (!vehicleRegistration_Response[0].Message.ToUpper().Contains("SUCCESSFUL")
                        && !vehicleRegistration_Response[0].Message.ToUpper().Contains("VEHICLE NO IS ALREADY EXISTS"))
                    {
                        vehicleRegistration_Response[0].ResponseCode = 1;
                        vehicleRegistration_Response[0].ResponseMessage = "Failure or No Record Found";

                        return this.Fail("", vehicleRegistration_Response, _logger);
                    }

                    vehicleRegistration_Response[0].ResponseCode = Convert.ToInt16(ResponseCode.Success);
                    vehicleRegistration_Response[0].ResponseMessage = "Success";
                    vehicleRegistration_Response[0].ErrorCode = 0;

                    VehicleTagMappingDetails vehicleTagMapping = new VehicleTagMappingDetails()
                    {
                        Customer_Id = vehicleRegistration_Response[0].CustomerID,
                        Vehicle_Number = objClass.VehicleNumber,
                        Tag_Type = null,
                        Tag_Number = null,
                        Fuel_type = objClass.FuelType,
                        Fastlane_Vehicle_ID = vehicleRegistration_Response[0].FastlaneVehicleID,
                        CreatedBy = null,
                        ModifedBy = null,
                        Modifieddate = null
                    };

                    await _hPPayFastlaneIntegrationRepository.SaveVehicleFastlaneMappingDetail(vehicleTagMapping);

                    return this.OkCustom("", vehicleRegistration_Response, _logger);
                }
            }
            catch (Exception ex)
            {
                VehicleRegistration_Response vehicleRegistration_Failure = new VehicleRegistration_Response()
                {
                    ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                    ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                    ErrorCode = 500,
                };
                return this.Fail("", vehicleRegistration_Failure, _logger);
            }
        }


        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("VehicleTagMapping")]
        public async Task<IActionResult> VehicleTagMapping(Input_VehicleTagMapping objClass)
        {
            List<VehicleTagMapping_Output> vehicleRegistration_Output = null;

            try
            {
                VehicleTagMappingDetails loyalUserDetails = await _hPPayFastlaneIntegrationRepository.GetVehicleFastlaneMappingDetails(objClass);
                if (loyalUserDetails is null)
                {
                    vehicleRegistration_Output = new List<VehicleTagMapping_Output>(){
                        new VehicleTagMapping_Output()
                        {
                            FastlaneVehicleID = string.Empty,
                            Message = string.Empty,
                            Status = string.Empty,
                            ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                            ResponseMessage = "Failure, No Record Found",
                            ErrorCode = 1,
                        }
                    };
                    return this.Fail("", vehicleRegistration_Output, _logger);
                }

                string vehicleTagMappingInfo =
                    "{\"TAGType\": \"" + objClass.TagType +
                    "\", \"TAGNO\": \"" + objClass.TagNumber +
                    "\", \"FastlaneVehicleID\": \"" + loyalUserDetails.Fastlane_Vehicle_ID +
                    "\"}";
                //Convert.ToString(JsonConvert.DeserializeObject(JsonConvert.SerializeObject(objClass)));

                string encryptedVehicleTagMappingInfo = Crypto.Encrypt(vehicleTagMappingInfo, publickeyforDataEncryption);
                encryptedVehicleTagMappingInfo = "{\"Data\" : \"" + encryptedVehicleTagMappingInfo + "\"}";

                string ResponseString = string.Empty;
                string vehicleTagMappingURI = _configuration.GetSection("FastLane:VehicleTagMappingURI").Value;
                Uri u = new Uri(vehicleTagMappingURI);

                string vehicleTagMappingAction = _configuration.GetSection("FastLane:VehicleTagMappingAction").Value;

                HttpContent c = new StringContent(encryptedVehicleTagMappingInfo, Encoding.UTF8, "application/json");
                var t = Task.Run(() => APIHelper.PostURI_Fastlane_VehicleRegistration(u, c, vehicleTagMappingAction, fastLaneAGSApiKey));
                t.Wait();

                HttpResponseMessage response = t.Result;
                ResponseString = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                };

                List<CryptoDecryptResponse> vehicleTagMappingEncryptedResult = System.Text.Json.JsonSerializer.Deserialize<List<CryptoDecryptResponse>>(ResponseString, options);

                string privateKeyforResponseDecryption = _configuration.GetSection("FastLane:PrivateKeyforResponseDecryption").Value;
                string decryptedVehicleInfo = Crypto.Decrypt(vehicleTagMappingEncryptedResult[0].Data, privateKeyforResponseDecryption);

                vehicleRegistration_Output = JsonConvert.DeserializeObject<List<VehicleTagMapping_Output>>(decryptedVehicleInfo);

                if (vehicleRegistration_Output is null)
                {
                    vehicleRegistration_Output = new List<VehicleTagMapping_Output>()
                    {
                        new VehicleTagMapping_Output()
                        {
                            FastlaneVehicleID = string.Empty,
                            Message = string.Empty,
                            Status = string.Empty,
                            ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                            ResponseMessage = "Failure, No Record Found",
                            ErrorCode = 1,
                        }
                    };
                    return this.Fail("", vehicleRegistration_Output, _logger);
                }
                else
                {
                    vehicleRegistration_Output[0].Status = vehicleTagMappingEncryptedResult[0]?.Status;
                    vehicleRegistration_Output[0].Message = vehicleTagMappingEncryptedResult[0]?.Message;

                    if (!vehicleTagMappingEncryptedResult[0].Message.ToUpper().Contains("SUCCESSFUL"))
                    {
                        vehicleRegistration_Output = new List<VehicleTagMapping_Output>()
                        {
                            new VehicleTagMapping_Output()
                            {
                                FastlaneVehicleID = string.Empty,
                                Message = string.Empty,
                                Status = string.Empty,
                                ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                                ResponseMessage = "Failure, No Record Found",
                                ErrorCode = 1,
                            }
                        };
                        return this.Fail("", vehicleRegistration_Output, _logger);
                    }

                    VehicleTagMappingDetails vehicleTagMapping = new VehicleTagMappingDetails()
                    {
                        Customer_Id = loyalUserDetails.Customer_Id,
                        Vehicle_Number = objClass.VehicleNumber,
                        Tag_Type = objClass.TagType,
                        Tag_Number = objClass.TagNumber,
                        Fastlane_Vehicle_ID = vehicleRegistration_Output[0].FastlaneVehicleID,
                    };

                    await _hPPayFastlaneIntegrationRepository.UpdateVehicleFastlaneMappingDetail(vehicleTagMapping);

                    vehicleRegistration_Output[0].ResponseCode = Convert.ToInt16(ResponseCode.Success);
                    vehicleRegistration_Output[0].ResponseMessage = "Success";
                    vehicleRegistration_Output[0].ErrorCode = 0;

                    return this.OkCustom("", vehicleRegistration_Output, _logger);
                }
            }
            catch (Exception ex)
            {
                vehicleRegistration_Output = new List<VehicleTagMapping_Output>()
                {
                    new VehicleTagMapping_Output()
                    {
                        ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                        ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                        ErrorCode = 500,
                    }
                };
                return this.Fail("", vehicleRegistration_Output, _logger);
            }
        }


        [HttpPost]
        // [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("VehiclePreset")]
        public async Task<IActionResult> VehiclePreset(Input_VehiclePresetDetails objClass)
        {
            List<VehiclePresetRegistration_Output> vehiclePresetRegistration_Output = null;
            try
            {
                VehiclePresetDetails_Output vehiclePresetDetails = await _hPPayFastlaneIntegrationRepository.GetVehiclePresetDetails(objClass);
                if (vehiclePresetDetails is null
                    || vehiclePresetDetails?.Status == 1)
                {
                    vehiclePresetRegistration_Output = new List<VehiclePresetRegistration_Output>()
                    {
                        new VehiclePresetRegistration_Output()
                        {
                            FastlaneReferenceID = string.Empty,
                            RequestID = 0,
                            Message = string.IsNullOrEmpty(vehiclePresetDetails?.Message) ? string.Empty : vehiclePresetDetails?.Message,
                            Status = string.IsNullOrEmpty(Convert.ToString(vehiclePresetDetails?.Status)) ? string.Empty : Convert.ToString(vehiclePresetDetails?.Status),
                            ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                            ResponseMessage = "Failure",
                            ErrorCode = 1,
                        }
                    };
                    return this.Fail("", vehiclePresetRegistration_Output, _logger);
                };

                string vehiclePresetRequestInfo =
                    "{\"RequestID\": \"" + vehiclePresetDetails.RequestID +
                    "\", \"PresetType\": \"" + objClass.PresetType +
                    "\", \"Value\": \"" + objClass.Amount +
                    "\", \"FastlaneVehicleID\": \"" + vehiclePresetDetails.FastlaneReferenceID +
                    "\"}";
                //Convert.ToString(JsonConvert.DeserializeObject(JsonConvert.SerializeObject(objClass)));

                string encryptedVehiclePresetRequestInfo = Crypto.Encrypt(vehiclePresetRequestInfo, publickeyforDataEncryption);
                encryptedVehiclePresetRequestInfo = "{\"Data\" : \"" + encryptedVehiclePresetRequestInfo + "\"}";

                string ResponseString = string.Empty;
                string vehiclePresetRequestURI = _configuration.GetSection("FastLane:VehiclePresetRequestURI").Value;
                Uri u = new Uri(vehiclePresetRequestURI);

                string vehiclePresetRequestAction = _configuration.GetSection("FastLane:VehiclePresetRequestAction").Value;

                HttpContent c = new StringContent(encryptedVehiclePresetRequestInfo, Encoding.UTF8, "application/json");
                var t = Task.Run(() => APIHelper.PostURI_Fastlane_VehicleRegistration(u, c, vehiclePresetRequestAction, fastLaneAGSApiKey));
                t.Wait();

                HttpResponseMessage response = t.Result;
                ResponseString = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                };

                List<CryptoDecryptResponse> vehiclePresetRequestEncryptedResult = System.Text.Json.JsonSerializer.Deserialize<List<CryptoDecryptResponse>>(ResponseString, options);

                string privateKeyforResponseDecryption = _configuration.GetSection("FastLane:PrivateKeyforResponseDecryption").Value;
                string decryptedVehicleInfo = Crypto.Decrypt(vehiclePresetRequestEncryptedResult[0].Data, privateKeyforResponseDecryption);

                vehiclePresetRegistration_Output = JsonConvert.DeserializeObject<List<VehiclePresetRegistration_Output>>(decryptedVehicleInfo);

                if (vehiclePresetRegistration_Output is null)
                {
                    VehiclePresetUpdateRequestDetails vehiclePresetUpdateRequestFail = new VehiclePresetUpdateRequestDetails()
                    {
                        RequestID = vehiclePresetDetails.RequestID,
                        CustomerID = vehiclePresetDetails.CustomerID,
                        FastlaneReferenceID = null,
                        VehicleNumber = objClass.VehicleNumber,
                        Status = 62505, // Mst_Parameters_Detail - 62505 - Failed
                        ConsumptionStatus = 62507 // Mst_Parameters_Detail - 62507 - Preset Cancel Initiated
                    };

                    await _hPPayFastlaneIntegrationRepository.UpdateVehiclePresetRequestDetails(vehiclePresetUpdateRequestFail);


                    vehiclePresetRegistration_Output = new List<VehiclePresetRegistration_Output>()
                    {
                        new VehiclePresetRegistration_Output()
                        {
                            FastlaneReferenceID = string.Empty,
                            RequestID = 0,
                            Message = ResponseString,
                            Status = string.Empty,
                            ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                            ResponseMessage = "Failure",
                            ErrorCode = 1,
                        }
                    };
                    return this.Fail("", vehiclePresetRegistration_Output, _logger);
                }
                else
                {
                    vehiclePresetRegistration_Output[0].Status = vehiclePresetRequestEncryptedResult[0]?.Status;
                    vehiclePresetRegistration_Output[0].Message = vehiclePresetRequestEncryptedResult[0]?.Message;

                    if (!vehiclePresetRequestEncryptedResult[0].Message.ToUpper().Contains("SUCCESSFUL"))
                    {
                        VehiclePresetUpdateRequestDetails vehiclePresetUpdateRequestFail = new VehiclePresetUpdateRequestDetails()
                        {
                            RequestID = vehiclePresetDetails.RequestID,
                            CustomerID = vehiclePresetDetails.CustomerID,
                            FastlaneReferenceID = vehiclePresetRegistration_Output[0].FastlaneReferenceID,
                            VehicleNumber = objClass.VehicleNumber,
                            Status = 62505, // Mst_Parameters_Detail - 62505 - Failed
                            ConsumptionStatus = 62507 // Mst_Parameters_Detail - 62507 - Preset Cancel Initiated
                        };

                        await _hPPayFastlaneIntegrationRepository.UpdateVehiclePresetRequestDetails(vehiclePresetUpdateRequestFail);


                        VehiclePresetRegistration_Output vehiclePresetRegistration_Failure = new VehiclePresetRegistration_Output()
                        {
                            FastlaneReferenceID = string.Empty,
                            RequestID = 0,
                            Message = vehiclePresetRequestEncryptedResult[0]?.Message,
                            Status = vehiclePresetRequestEncryptedResult[0]?.Status,
                            ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                            ResponseMessage = "Failure",
                            ErrorCode = 1,
                        };

                        return this.Fail("", vehiclePresetRegistration_Output, _logger);
                    }

                    VehiclePresetUpdateRequestDetails vehiclePresetUpdateRequestSuccess = new VehiclePresetUpdateRequestDetails()
                    {
                        RequestID = vehiclePresetDetails.RequestID,
                        CustomerID = vehiclePresetDetails.CustomerID,
                        FastlaneReferenceID = vehiclePresetRegistration_Output[0].FastlaneReferenceID,
                        VehicleNumber = objClass.VehicleNumber,
                        Status = 62502, // Mst_Parameters_Detail - 62502 - Active
                        ConsumptionStatus = 62510 // Mst_Parameters_Detail - 62510 - Preset Txn Initiated
                    };

                    await _hPPayFastlaneIntegrationRepository.UpdateVehiclePresetRequestDetails(vehiclePresetUpdateRequestSuccess);

                    vehiclePresetRegistration_Output[0].ResponseCode = Convert.ToInt16(ResponseCode.Success);
                    vehiclePresetRegistration_Output[0].ResponseMessage = "Success";
                    vehiclePresetRegistration_Output[0].ErrorCode = 0;

                    return this.OkCustom("", vehiclePresetRegistration_Output, _logger);
                }
            }
            catch (Exception ex)
            {
                vehiclePresetRegistration_Output = new List<VehiclePresetRegistration_Output>()
                {
                    new VehiclePresetRegistration_Output()
                    {
                        ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                        ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                        ErrorCode = 500,
                    }
                };
                return this.Fail("", vehiclePresetRegistration_Output, _logger);
            }
        }


        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("GetPresetVehicleList")]
        public async Task<IActionResult> GetPresetVehicleList(Input_PresetVehicleList objClass)
        {
            IList<PresetVehicleList_Output> result = null;
            try
            {
                result = await _hPPayFastlaneIntegrationRepository.GetPresetVehicleList(objClass);

                if (result == null
                    || result.Count == 0)
                {
                    result = new List<PresetVehicleList_Output>()
                    {
                        new PresetVehicleList_Output()
                        {
                            ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                            ResponseMessage = $"No Record Found",
                            ErrorCode = 0,
                        }
                    };

                    return this.Fail("", result, _logger);
                }
                else
                {
                    return this.OkCustom("", result, _logger);
                }
            }
            catch (Exception ex)
            {
                result = new List<PresetVehicleList_Output>()
                {
                    new PresetVehicleList_Output()
                    {
                        ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                        ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                        ErrorCode = 500,
                    }
                };

                return this.Fail("", result, _logger);
            }
        }


        [HttpPost]
        // [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("VehiclePresetCancel")]
        public async Task<IActionResult> VehiclePresetCancel(Input_VehiclePresetCancel objClass)
        {
            List<VehiclePresetCancelDetails_Output> vehiclePresetCancel_Output = null;
            try
            {
                VehiclePresetCancelDetails vehiclePresetCancelDetails = await _hPPayFastlaneIntegrationRepository.GetPresetCancelDetails(objClass);
                if (vehiclePresetCancelDetails is null
                    || vehiclePresetCancelDetails?.Status == "1")
                {
                    vehiclePresetCancel_Output = new List<VehiclePresetCancelDetails_Output>()
                    {
                        new VehiclePresetCancelDetails_Output()
                        {
                            FastlaneReferenceID = string.Empty,
                            RequestID = 0,
                            Status = string.IsNullOrEmpty(vehiclePresetCancelDetails?.Status) ? string.Empty : vehiclePresetCancelDetails?.Status,
                            Message = string.IsNullOrEmpty(vehiclePresetCancelDetails?.Message) ? string.Empty : vehiclePresetCancelDetails?.Message,
                            ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                            ResponseMessage = "Failure",
                            ErrorCode = 1,
                        }
                    };
                    return this.Fail("", vehiclePresetCancel_Output, _logger);
                };

                string vehiclePresetCancelRequestInfo =
                    "{\"FastlaneVehicleID\": \"" + vehiclePresetCancelDetails.FastlaneVehicleID +
                    "\", \"FastlaneCustomerID\": \"" + vehiclePresetCancelDetails.FastlaneCustomerID +
                    "\"}";
                //Convert.ToString(JsonConvert.DeserializeObject(JsonConvert.SerializeObject(objClass)));

                string encryptedVehiclePresetCancelRequestInfo = Crypto.Encrypt(vehiclePresetCancelRequestInfo, publickeyforDataEncryption);
                encryptedVehiclePresetCancelRequestInfo = "{\"Data\" : \"" + encryptedVehiclePresetCancelRequestInfo + "\"}";

                string ResponseString = string.Empty;
                string vehiclePresetCancelRequestURI = _configuration.GetSection("FastLane:VehiclePresetCancelRequestURI").Value;
                Uri u = new Uri(vehiclePresetCancelRequestURI);

                string vehiclePresetCancelRequestAction = _configuration.GetSection("FastLane:VehiclePresetCancelRequestAction").Value;

                HttpContent c = new StringContent(encryptedVehiclePresetCancelRequestInfo, Encoding.UTF8, "application/json");
                var t = Task.Run(() => APIHelper.PostURI_Fastlane_VehicleRegistration(u, c, vehiclePresetCancelRequestAction, fastLaneAGSApiKey));
                t.Wait();

                HttpResponseMessage response = t.Result;
                ResponseString = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                };

                List<CryptoDecryptResponse> vehiclePresetCancelRequestEncryptedResult = System.Text.Json.JsonSerializer.Deserialize<List<CryptoDecryptResponse>>(ResponseString, options);

                string privateKeyforResponseDecryption = _configuration.GetSection("FastLane:PrivateKeyforResponseDecryption").Value;
                string decryptedVehicleInfo = Crypto.Decrypt(vehiclePresetCancelRequestEncryptedResult[0].Data, privateKeyforResponseDecryption);

                vehiclePresetCancel_Output = JsonConvert.DeserializeObject<List<VehiclePresetCancelDetails_Output>>(decryptedVehicleInfo);

                if (vehiclePresetCancel_Output is null)
                {
                    VehiclePresetUpdateRequestDetails vehiclePresetUpdateRequestFail = new VehiclePresetUpdateRequestDetails()
                    {
                        CustomerID = 0,
                        FastlaneReferenceID = null,
                        VehicleNumber = objClass.VehicleNumber,
                        Status = 62503, // Mst_Parameters_Detail - 62503 - Cancelled
                        ConsumptionStatus = 62507 // Mst_Parameters_Detail - 62507 - Preset Cancel Initiated
                    };

                    await _hPPayFastlaneIntegrationRepository.UpdateVehiclePresetRequestDetails(vehiclePresetUpdateRequestFail);

                    vehiclePresetCancel_Output = new List<VehiclePresetCancelDetails_Output>()
                    {
                        new VehiclePresetCancelDetails_Output()
                        {
                            FastlaneReferenceID = string.Empty,
                            RequestID = 0,
                            Status = string.Empty,
                            Message = string.IsNullOrEmpty(ResponseString) ? string.Empty : ResponseString,
                            ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                            ResponseMessage = "Failure",
                            ErrorCode = 1,
                        }
                    };

                    return this.Fail("", vehiclePresetCancel_Output, _logger);
                }
                else
                {
                    vehiclePresetCancel_Output[0].Status = vehiclePresetCancelRequestEncryptedResult[0].Status;
                    vehiclePresetCancel_Output[0].Message = vehiclePresetCancelRequestEncryptedResult[0].Message;

                    if (!vehiclePresetCancel_Output[0].Message.ToUpper().Contains("SUCCESSFUL"))
                    {
                        VehiclePresetUpdateRequestDetails vehiclePresetUpdateRequestFail = new VehiclePresetUpdateRequestDetails()
                        {
                            CustomerID = vehiclePresetCancel_Output[0]?.RequestID,
                            FastlaneReferenceID = vehiclePresetCancel_Output[0]?.FastlaneReferenceID,
                            VehicleNumber = objClass.VehicleNumber,
                            Status = 62503, // Mst_Parameters_Detail - 62503 - Cancelled
                            ConsumptionStatus = 62507 // Mst_Parameters_Detail - 62507 - Preset Cancel Initiated
                        };

                        await _hPPayFastlaneIntegrationRepository.UpdateVehiclePresetRequestDetails(vehiclePresetUpdateRequestFail);

                        vehiclePresetCancel_Output = new List<VehiclePresetCancelDetails_Output>()
                        {
                            new VehiclePresetCancelDetails_Output()
                            {
                                FastlaneReferenceID = vehiclePresetCancel_Output[0]?.FastlaneReferenceID,
                                RequestID = vehiclePresetCancel_Output[0].RequestID,
                                Status = vehiclePresetCancel_Output[0]?.Status,
                                Message = vehiclePresetCancel_Output[0]?.Message,
                                ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                                ResponseMessage = "Failure",
                                ErrorCode = 1,
                            }
                        };

                        return this.Fail("", vehiclePresetCancel_Output, _logger);
                    }

                    VehiclePresetUpdateRequestDetails vehiclePresetUpdateRequestSuccess = new VehiclePresetUpdateRequestDetails()
                    {
                        CustomerID = vehiclePresetCancel_Output[0].RequestID,
                        FastlaneReferenceID = vehiclePresetCancel_Output[0].FastlaneReferenceID,
                        VehicleNumber = objClass.VehicleNumber,
                        Status = 62503, // Mst_Parameters_Detail - 62503 - Cancelled
                        ConsumptionStatus = 62507 // Mst_Parameters_Detail - 62507 - Preset Cancel Initiated
                    };

                    await _hPPayFastlaneIntegrationRepository.UpdateVehiclePresetRequestDetails(vehiclePresetUpdateRequestSuccess);

                    vehiclePresetCancel_Output[0].ResponseCode = Convert.ToInt16(ResponseCode.Success);
                    vehiclePresetCancel_Output[0].ResponseMessage = "Success";
                    vehiclePresetCancel_Output[0].ErrorCode = 0;

                    return this.OkCustom("", vehiclePresetCancel_Output, _logger);
                }
            }
            catch (Exception ex)
            {
                vehiclePresetCancel_Output = new List<VehiclePresetCancelDetails_Output>()
                {
                    new VehiclePresetCancelDetails_Output()
                    {
                        ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                        ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                        ErrorCode = 500,
                    }
                };
                return this.Fail("", vehiclePresetCancel_Output, _logger);
            }
        }


        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("GetVehicleList")]
        public async Task<IActionResult> GetVehicleList(Input_VehicleList objClass)
        {
            IList<VehicleList_Output> result = null;
            try
            {
                result = await _hPPayFastlaneIntegrationRepository.GetVehicleList(objClass);

                if (result == null
                    || result.Count == 0)
                {
                    result = new List<VehicleList_Output>()
                    {
                        new VehicleList_Output()
                        {
                            ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                            ResponseMessage = $"No Record Found",
                            ErrorCode = 0,
                        }
                    };

                    return this.Fail("", result, _logger);
                }
                else
                {
                    return this.OkCustom("", result, _logger);
                }
            }
            catch (Exception ex)
            {
                result = new List<VehicleList_Output>()
                {
                    new VehicleList_Output()
                    {
                        ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                        ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                        ErrorCode = 500,
                    }
                };

                return this.Fail("", result, _logger);
            }
        }


        [HttpPost]
        //[ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("GetFastlaneLastPresetAmount")]
        public async Task<IActionResult> GetFastlaneLastPresetAmount(Input_FastlaneLastPresetAmount objClass)
        {
            FastlaneLastPresetAmount_Output result = null;
            try
            {
                result = await _hPPayFastlaneIntegrationRepository.GetFastlaneLastPresetAmount(objClass);

                if (result == null
                    || result.ResponseCode == 1
                   || string.IsNullOrEmpty(result?.VehicleNumber))
                {
                    result = new FastlaneLastPresetAmount_Output()
                    {
                        VehicleNumber = objClass.VehicleNumber,
                        Amount = 0,
                        ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                        ResponseMessage = "Failure, No record found",
                        ErrorCode = 1,
                    };

                    return this.Fail("", result, _logger);
                }
                else
                {
                    result.ResponseCode = Convert.ToInt16(ResponseCode.Success);
                    result.ResponseMessage = "Success";
                    result.ErrorCode = 0;

                    return this.OkCustom("", result, _logger);
                }
            }
            catch (Exception ex)
            {
                result = new FastlaneLastPresetAmount_Output()
                {
                    ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                    ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                    ErrorCode = 500,
                };

                return this.Fail("", result, _logger);
            }
        }


        [HttpPost]
        // [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("ProcessSaleCompletion")]
        public async Task<IActionResult> ProcessSaleCompletion(Input_ProcessSaleCompletion objClass)
        {
            ProcessSaleCompletion_Output result = null;
            try
            {
                result = await _hPPayFastlaneIntegrationRepository.ProcessSaleCompletion(objClass);

                if (result == null
                    || result.ResponseCode == 1
                    || Convert.ToString(result?.ResponseMessage).ToUpper() != "SUCCESS")
                {
                    result = new ProcessSaleCompletion_Output()
                    {
                        ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                        ResponseMessage = result?.ResponseMessage == null ? "Failure - No Record Found" : result?.ResponseMessage,
                        ErrorCode = 1
                    };

                    return this.Fail("", result, _logger);
                }
                else
                {
                    result.ResponseCode = Convert.ToInt16(ResponseCode.Success);
                    result.ResponseMessage = "Success";
                    result.ErrorCode = 0;

                    return this.OkCustom("", result, _logger);
                }
            }
            catch (Exception ex)
            {
                result = new ProcessSaleCompletion_Output()
                {
                    ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                    ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                    ErrorCode = 500,
                };

                return this.Fail("", result, _logger);
            }
        }


        [HttpPost]
        // [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("InitiateRefund")]
        public async Task<IActionResult> InitiateRefund(Input_InitiateRefund objClass)
        {
            InitiateRefund_Output result = null;
            try
            {
                result = await _hPPayFastlaneIntegrationRepository.InitiateRefund(objClass);

                if (result == null
                    || result.ResponseCode == 1
                    || Convert.ToString(result?.ResponseMessage).ToUpper() != "SUCCESS")
                {
                    result = new InitiateRefund_Output()
                    {
                        HPPAYRefNumber = result?.HPPAYRefNumber,
                        TransactionNumber = result?.TransactionNumber,
                        ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                        ResponseMessage = result?.ResponseMessage == null ? "Failure - No Record Found" : result?.ResponseMessage,
                        ErrorCode = 1
                    };
                    return this.Fail("", result, _logger);
                }
                else
                {
                    result.ResponseCode = Convert.ToInt16(ResponseCode.Success);
                    result.ResponseMessage = "Success";
                    result.ErrorCode = 0;

                    return this.OkCustom("", result, _logger);
                }
            }
            catch (Exception ex)
            {
                result = new InitiateRefund_Output()
                {
                    ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                    ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                    ErrorCode = 500,
                };

                return this.Fail("", result, _logger);
            }
        }


        [HttpPost]
        // [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("CheckStatus")]
        public async Task<IActionResult> CheckStatus(Input_CheckStatus objClass)
        {
            CheckStatus_Output result = null;
            try
            {
                result = await _hPPayFastlaneIntegrationRepository.CheckStatus(objClass);

                if (result == null
                    || result.ResponseCode == 1
                    || Convert.ToString(result?.ResponseMessage).ToUpper() != "SUCCESS")
                {
                    CheckStatus_Output checkStatus_Failure = new CheckStatus_Output()
                    {
                        HPPAYRefNumber = result?.HPPAYRefNumber,
                        MobileNumber = result?.MobileNumber,
                        PartnerCustomerID = result?.PartnerCustomerID,
                        TransactionAmount = result?.TransactionAmount,
                        TransactionDate = result?.TransactionDate,
                        TransactionNumber = result?.TransactionNumber,
                        TransactionStatus = result?.TransactionStatus,
                        ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                        ResponseMessage = result?.ResponseMessage == null ? "Failure - No Record Found" : result?.ResponseMessage,
                        ErrorCode = 1
                    };

                    return this.Fail("", checkStatus_Failure, _logger);
                }
                else
                {
                    result.ResponseCode = Convert.ToInt16(ResponseCode.Success);
                    result.ResponseMessage = "Success";
                    result.ErrorCode = 0;

                    return this.OkCustom("", result, _logger);
                }
            }
            catch (Exception ex)
            {
                result = new CheckStatus_Output()
                {
                    ResponseCode = Convert.ToInt16(ResponseCode.Failure),
                    ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                    ErrorCode = 500,
                };

                return this.Fail("", result, _logger);
            }
        }

        static string customdate(string dateinput)
        {
            string trans_date = dateinput.ToString().Split(' ')[0];
            //string trans_time = (dateinput.ToString().Split(' ').Length > 0) ? dateinput.ToString().Split(' ')[1] : "";
            string splitChar = trans_date.Contains('/') ? "/" : trans_date.Contains(':') ? ":" : trans_date.Contains('-') ? "-" : trans_date.Contains(',') ? "," : ".";
            int Year = Convert.ToInt32(trans_date.Split(splitChar)[2]);
            int Month = Convert.ToInt32(trans_date.Split(splitChar)[1]);
            int Day = Convert.ToInt32(trans_date.Split(splitChar)[0]);

            //int hour = Convert.ToInt32(trans_time.Split(':')[0]);
            //int min = Convert.ToInt32(trans_time.Split(':')[1]);
            //int second = Convert.ToInt32(trans_time.Split(':')[2]);

            DateTime dt = new DateTime(Year, Month, Day, 0, 0, 0);

            return dt.ToString("MM/dd/yyyy hh:mm:ss");
        }
    }
}
