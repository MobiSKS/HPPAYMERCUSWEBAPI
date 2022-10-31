using Dapper;
using HPPay.DataModel.DBConstants;
using HPPay.DataModel.Fastlane;
using HPPay.DataRepository.DBDapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HPPay.DataRepository.Fastlane
{
    public class FastlaneIntegrationRepository : IFastlaneIntegrationRepository
    {
        private readonly DapperContext _context;
        private readonly IConfiguration _configuration;

        public FastlaneIntegrationRepository(DapperContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ActiveCityList_Response> GetActiveCityList()
        {
            ActiveCityList_Response results = null;
            try
            {
                string procedureName = StoredProcedures.GET_ACTIVECITYLIST;

                using IDbConnection connection = _context.CreateConnection();
                IEnumerable<ActiveCityList> result = await connection.QueryAsync<ActiveCityList>(procedureName, null, commandType: CommandType.StoredProcedure);

                if (result is null || result.ToList().Count == 0)
                {
                    return null;
                }

                List<ActiveCityList> activityLists = new List<ActiveCityList>();
                activityLists.AddRange(result);
                results = new ActiveCityList_Response()
                {
                    ResponseCode = 0,
                    ResponseMessage = $"Success",
                    ErrorCode = 0,
                    activeCityLists = activityLists,
                };

                return results;
            }
            catch (Exception ex)
            {
                results = new ActiveCityList_Response()
                {
                    ResponseCode = 1,
                    ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                    ErrorCode = 500,
                    activeCityLists = null,
                };

                return results;
            }
        }

        public async Task<CustomerRegistration_CustomerInfo_Response> GetCustomerInfo_CustomerRegistration(CustomerRegistration_Request objClass)
        {
            List<CustomerRegistration_CustomerInfo_Response> results = null;
            string procedureName = StoredProcedures.GET_CUSTOMERINFO_CUSTOMERREGISTRATION;
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "EmailId", objClass.EmailId },
                    { "MobileNo", objClass.MobileNo },
                };

                DynamicParameters Parameters = new DynamicParameters(parameters);

                using IDbConnection connection = _context.CreateConnection();
                IEnumerable<dynamic> result = await connection.QueryAsync<CustomerRegistration_CustomerInfo_Response>(procedureName, Parameters, commandType: CommandType.StoredProcedure);
                results = result.Cast<CustomerRegistration_CustomerInfo_Response>().ToList();
                if (results is null || results.Count == 0 || results?[0] is null || results[0]?.ResponseCode is null)
                {
                    return null;
                }

                return results[0];
            }
            catch (Exception ex)
            {
                CustomerRegistration_CustomerInfo_Response registration_CustomerInfo_Failure = new CustomerRegistration_CustomerInfo_Response()
                {
                    ResponseCode = 1,
                    ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                    ErrorCode = 500,
                };

                return registration_CustomerInfo_Failure;
            }
        }

        public async Task<object> UpdateLoyalUserFastlaneId(CustomerRegistration_Response objClass)
        {
            try
            {
                string procedureName = StoredProcedures.UPDATE_FASTLANEID_MSTCUSTOMER;

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "CustomerID", objClass.CustomerID },
                    { "FastlaneID", objClass.FastlaneID },
                };

                DynamicParameters Parameters = new DynamicParameters(parameters);

                using IDbConnection connection = _context.CreateConnection();
                IEnumerable<dynamic> result = await connection.QueryAsync(procedureName, Parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                CustomerRegistration_Response customerRegistration_Failure = new CustomerRegistration_Response()
                {
                    ResponseCode = 1,
                    ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                    ErrorCode = 500,
                };

                return customerRegistration_Failure;
            }
        }

        public async Task<VahanVehicleDetail> GetVahanVehicleDetail(VehicleValidation objClass)
        {
            List<VahanVehicleDetail> results = null;
            try
            {
                string procedureName = StoredProcedures.GET_SAVE_VAHANVEHICLEDETAIL;

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Vehicle_Number", objClass.VehicleNumber },
                    { "CheckIsExists", 1 }
                };

                DynamicParameters Parameters = new DynamicParameters(parameters);

                using IDbConnection connection = _context.CreateConnection();
                IEnumerable<VahanVehicleDetail> result = await connection.QueryAsync<VahanVehicleDetail>(procedureName, Parameters, commandType: CommandType.StoredProcedure);
                results = result.Cast<VahanVehicleDetail>().ToList();
                if (results is null || results.Count == 0 || results?[0] is null || results[0]?.Vehicle_Number is null)
                {
                    return null;
                }

                return results[0];
            }
            catch (Exception ex)
            {
                VahanVehicleDetail vahanVehicleDetail_Failure = new VahanVehicleDetail()
                {
                    ResponseCode = 1,
                    ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                    ErrorCode = 500,
                };

                return vahanVehicleDetail_Failure;
            }
        }

        public async Task<VahanVehicleDetail> SaveVahanVehicleDetail(VahanVehicleDetail objClass)
        {
            List<VahanVehicleDetail> results = new List<VahanVehicleDetail>();
            try
            {
                string procedureName = StoredProcedures.GET_SAVE_VAHANVEHICLEDETAIL;

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Vehicle_Number", objClass.Vehicle_Number },
                    { "Registration_Date", objClass.Registration_Date },
                    { "Owner_Name", objClass.Owner_Name },
                    { "Fuel_Type", objClass.Fuel_Type },
                    { "Model_MakerClass", objClass.Model_MakerClass },
                    { "Maker_Manufacturer", objClass.Maker_Manufacturer },
                    { "Insurance_Upto", objClass.Insurance_Upto },
                    { "Modified", objClass.Modified },
                    { "Message", objClass.Message },
                    { "ResponseStatus", objClass.ResponseStatus },
                    { "ResponseMsg", objClass.ResponseMsg },
                    { "CheckIsExists", 0 }
                };

                DynamicParameters Parameters = new DynamicParameters(parameters);

                using IDbConnection connection = _context.CreateConnection();
                IEnumerable<dynamic> result = await connection.QueryAsync<VahanVehicleDetail>(procedureName, Parameters, commandType: CommandType.StoredProcedure);
                List<VahanVehicleDetail> Results = result.Cast<VahanVehicleDetail>().ToList();
                if (Results is null || Results.Count == 0 || Results?[0] is null || Results[0]?.Vehicle_Number is null)
                {
                    return null;
                }

                return Results[0];
            }
            catch (Exception ex)
            {
                VahanVehicleDetail vahanVehicleDetail_Failure = new VahanVehicleDetail()
                {
                    ResponseCode = 1,
                    ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                    ErrorCode = 500,
                };

                return vahanVehicleDetail_Failure;
            }
        }

        public async Task<CustomerRegistration_Response> GetLoyalUserDetails(Input_VehicleRegistration objClass)
        {
            List<CustomerRegistration_Response> results = new List<CustomerRegistration_Response>();
            try
            {
                string procedureName = StoredProcedures.GET_LOYALUSER_DETAILS;

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "MobileNumber", objClass.MobileNumber },
                    { "VehicleNumber", objClass.VehicleNumber }
                };

                DynamicParameters Parameters = new DynamicParameters(parameters);

                using IDbConnection connection = _context.CreateConnection();
                IEnumerable<dynamic> result = await connection.QueryAsync<CustomerRegistration_Response>(procedureName, Parameters, commandType: CommandType.StoredProcedure);
                results = result.Cast<CustomerRegistration_Response>().ToList();
                if (results is null || results.Count == 0 || results?[0] is null || results[0]?.CustomerID is null)
                {
                    return null;
                }

                return results[0];
            }
            catch (Exception ex)
            {
                CustomerRegistration_Response customerRegistration_Failure = new CustomerRegistration_Response()
                {
                    ResponseCode = 1,
                    ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                    ErrorCode = 500,
                };

                return customerRegistration_Failure;
            }
        }

        public async Task<object> SaveVehicleFastlaneMappingDetail(VehicleTagMappingDetails objClass)
        {
            try
            {
                string procedureName = StoredProcedures.SAVE_VEHICLE_FASTLANE_MAPPING;

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Customer_Id", objClass.Customer_Id },
                    { "Vehicle_Number", objClass.Vehicle_Number },
                    { "Tag_Type", objClass.Tag_Type },
                    { "Tag_Number", objClass.Tag_Number },
                    { "Fuel_type", objClass.Fuel_type },
                    { "Fastlane_Vehicle_ID", objClass.Fastlane_Vehicle_ID },
                    { "CreatedBy", objClass.CreatedBy },
                    { "ModifedBy", objClass.ModifedBy },
                    { "Modifieddate", objClass.Modifieddate },
                    { "Status_Flag", 1 }
                };

                DynamicParameters Parameters = new DynamicParameters(parameters);

                using IDbConnection connection = _context.CreateConnection();
                IEnumerable<dynamic> result = await connection.QueryAsync<VahanVehicleDetail>(procedureName, Parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<VehicleTagMappingDetails> GetVehicleFastlaneMappingDetails(Input_VehicleTagMapping objClass)
        {
            List<VehicleTagMappingDetails> results = new List<VehicleTagMappingDetails>();
            try
            {
                string procedureName = StoredProcedures.GET_VEHICLE_FASTLANE_MAPPING_DETAIL;

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "VehicleNumber", objClass.VehicleNumber }
                };

                DynamicParameters Parameters = new DynamicParameters(parameters);

                using IDbConnection connection = _context.CreateConnection();
                IEnumerable<dynamic> result = await connection.QueryAsync<VehicleTagMappingDetails>(procedureName, Parameters, commandType: CommandType.StoredProcedure);
                results = result.Cast<VehicleTagMappingDetails>().ToList();
                if (results is null || results.Count == 0 || results?[0] is null || results[0]?.Customer_Id is null)
                {
                    return null;
                }
                return results[0];
            }
            catch (Exception ex)
            {
                VehicleTagMappingDetails vehicleTagMappingDetails_Failure = new VehicleTagMappingDetails()
                {
                    ResponseCode = 1,
                    ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                    ErrorCode = 500,
                };

                return vehicleTagMappingDetails_Failure;
            }
        }

        public async Task<object> UpdateVehicleFastlaneMappingDetail(VehicleTagMappingDetails objClass)
        {
            try
            {
                string procedureName = StoredProcedures.UPDATE_VEHICLE_FASTLANE_MAPPING;

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "CustomerId", objClass.Customer_Id },
                    { "VehicleNumber", objClass.Vehicle_Number },
                    { "TagType", objClass.Tag_Type },
                    { "TagNumber", objClass.Tag_Number },
                    { "FastlaneVehicleID", objClass.Fastlane_Vehicle_ID },
                };

                DynamicParameters Parameters = new DynamicParameters(parameters);

                using IDbConnection connection = _context.CreateConnection();
                IEnumerable<dynamic> result = await connection.QueryAsync<VahanVehicleDetail>(procedureName, Parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<VehiclePresetDetails_Output> GetVehiclePresetDetails(Input_VehiclePresetDetails objClass)
        {
            List<VehiclePresetDetails_Output> results = new List<VehiclePresetDetails_Output>();
            try
            {
                string procedureName = StoredProcedures.GET_VEHICALPRESET_DETAIL;

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "PresetAmount", objClass.Amount },
                    { "PresetType", objClass.PresetType },
                    { "VehicleNumber", objClass.VehicleNumber }
                };

                DynamicParameters Parameters = new DynamicParameters(parameters);

                using IDbConnection connection = _context.CreateConnection();
                IEnumerable<dynamic> result = await connection.QueryAsync<VehiclePresetDetails_Output>(procedureName, Parameters, commandType: CommandType.StoredProcedure);
                results = result.Cast<VehiclePresetDetails_Output>().ToList();
                if (results is null || results.Count == 0 || results?[0] is null || results[0]?.RequestID is null)
                {
                    return null;
                }

                return results[0];
            }
            catch (Exception ex)
            {
                VehiclePresetDetails_Output vehicleTagMappingDetails_Failure = new VehiclePresetDetails_Output()
                {
                    ResponseCode = 1,
                    ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                    ErrorCode = 500,
                };

                return vehicleTagMappingDetails_Failure;
            }
        }

        public async Task<object> UpdateVehiclePresetRequestDetails(VehiclePresetUpdateRequestDetails objClass)
        {
            try
            {
                string procedureName = StoredProcedures.UPDATE_VEHICLE_PRESET_REQUEST;

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "RequestID", objClass.RequestID },
                    { "CustomerID", objClass.CustomerID },
                    { "FastlaneReferenceID", objClass.FastlaneReferenceID},
                    { "VehicleNumber", objClass.VehicleNumber },
                    { "Status", objClass.Status },
                    { "ConsumptionStatus", objClass.ConsumptionStatus }
                };

                DynamicParameters Parameters = new DynamicParameters(parameters);

                using IDbConnection connection = _context.CreateConnection();
                IEnumerable<dynamic> result = await connection.QueryAsync<VahanVehicleDetail>(procedureName, Parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IList<PresetVehicleList_Output>> GetPresetVehicleList(Input_PresetVehicleList objClass)
        {
            List<PresetVehicleList_Output> results = new List<PresetVehicleList_Output>();
            try
            {
                string procedureName = StoredProcedures.GET_PRESET_VEHICLE_LIST;

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "MobileNumber", objClass.MobileNumber }
                };

                DynamicParameters Parameters = new DynamicParameters(parameters);

                using IDbConnection connection = _context.CreateConnection();
                IEnumerable<dynamic> result = await connection.QueryAsync<PresetVehicleList_Output>(procedureName, Parameters, commandType: CommandType.StoredProcedure);
                results = result.Cast<PresetVehicleList_Output>().ToList();
                if (results is null || results.Count == 0 || results?[0] is null || results[0]?.RequestId is null)
                {
                    return null;
                }

                return results;
            }
            catch (Exception ex)
            {
                List<PresetVehicleList_Output> presetVehicleList_Failure = new List<PresetVehicleList_Output>() {
                     new PresetVehicleList_Output()
                        {
                            ResponseCode = 1,
                            ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                            ErrorCode = 500,
                        }
                };

                return presetVehicleList_Failure;
            }
        }

        public async Task<VehiclePresetCancelDetails> GetPresetCancelDetails(Input_VehiclePresetCancel objClass)
        {
            List<VehiclePresetCancelDetails> results = new List<VehiclePresetCancelDetails>();
            try
            {
                string procedureName = StoredProcedures.GET_VEHICLE_PRESET_CANCEL_DETAIL;

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "VehicleNumber", objClass.VehicleNumber }
                };

                DynamicParameters Parameters = new DynamicParameters(parameters);

                using IDbConnection connection = _context.CreateConnection();
                IEnumerable<dynamic> result = await connection.QueryAsync<VehiclePresetCancelDetails>(procedureName, Parameters, commandType: CommandType.StoredProcedure);
                results = result.Cast<VehiclePresetCancelDetails>().ToList();
                if (results is null || results.Count == 0 || results?[0] is null || results[0]?.FastlaneCustomerID is null)
                {
                    return null;
                }

                return results[0];
            }
            catch (Exception ex)
            {
                VehiclePresetCancelDetails presetVehicleList_Failure = new VehiclePresetCancelDetails()
                {
                    ResponseCode = 1,
                    ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                    ErrorCode = 500,
                };

                return presetVehicleList_Failure;
            }
        }

        public async Task<IList<VehicleList_Output>> GetVehicleList(Input_VehicleList objClass)
        {
            List<VehicleList_Output> results = new List<VehicleList_Output>();
            try
            {
                string procedureName = StoredProcedures.GET_VEHICLE_LIST;

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "Flag", objClass.Flag },
                    { "PresetFlag", objClass.PresetFlag },
                    { "MobileNumber", objClass.MobileNumber }
                };

                DynamicParameters Parameters = new DynamicParameters(parameters);

                using IDbConnection connection = _context.CreateConnection();
                IEnumerable<dynamic> result = await connection.QueryAsync<VehicleList_Output>(procedureName, Parameters, commandType: CommandType.StoredProcedure);
                results = result.Cast<VehicleList_Output>().ToList();
                if (results is null || results.Count == 0) // || Results?[0] is null || Results[0]?.CustomerId is null
                {
                    return null;
                }

                return results;
            }
            catch (Exception ex)
            {
                List<VehicleList_Output> vehicleList_Failure = new List<VehicleList_Output>(){
                    new VehicleList_Output()
                    {
                        ResponseCode = 1,
                        ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                        ErrorCode = 500,
                    }
                };

                return vehicleList_Failure;
            }
        }

        public async Task<FastlaneLastPresetAmount_Output> GetFastlaneLastPresetAmount(Input_FastlaneLastPresetAmount objClass)
        {
            List<FastlaneLastPresetAmount_Output> results = new List<FastlaneLastPresetAmount_Output>();
            try
            {
                string procedureName = StoredProcedures.GET_Fastlane_Last_Preset_Amount;

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "VehicleNumber", objClass.VehicleNumber }
                };

                DynamicParameters Parameters = new DynamicParameters(parameters);

                using IDbConnection connection = _context.CreateConnection();
                IEnumerable<dynamic> result = await connection.QueryAsync<FastlaneLastPresetAmount_Output>(procedureName, Parameters, commandType: CommandType.StoredProcedure);
                results = result.Cast<FastlaneLastPresetAmount_Output>().ToList();
                if (results is null || results.Count == 0) // || Results?[0] is null || Results[0]?.CustomerId is null
                {
                    return null;
                }

                return results[0];
            }
            catch (Exception ex)
            {
                FastlaneLastPresetAmount_Output vehicleList_Failure = new FastlaneLastPresetAmount_Output()
                {
                    ResponseCode = 1,
                    ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                    ErrorCode = 500,
                };

                return vehicleList_Failure;
            }
        }

        public async Task<ProcessSaleCompletion_Output> ProcessSaleCompletion(Input_ProcessSaleCompletion objClass)
        {
            List<ProcessSaleCompletion_Output> results = new List<ProcessSaleCompletion_Output>();
            try
            {
                string procedureName = StoredProcedures.POST_FASTLANE_PROCESSSALECOMPLETION;

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "PartnerCode", objClass.PartnerCode },
                    { "MobileNumber", objClass.MobileNumber },
                    { "PartnerCustomerID", objClass.PartnerCustomerID },
                    { "TransactionAmount", objClass.TransactionAmount },
                    { "TransactionDate", objClass.TransactionDate },
                    { "TransactionNumber", objClass.TransactionNumber },
                    { "MerchantId", objClass.MerchantId },
                    { "FastlaneVehicleId", objClass.FastlaneVehicleId },
                    { "FuelTypeName", objClass.FuelTypeName },
                    { "RequestJson", Convert.ToString(JsonConvert.SerializeObject(objClass)) }
                };

                DynamicParameters Parameters = new DynamicParameters(parameters);

                using IDbConnection connection = _context.CreateConnection();
                IEnumerable<dynamic> result = await connection.QueryAsync<ProcessSaleCompletion_Output>(procedureName, Parameters, commandType: CommandType.StoredProcedure);
                results = result.Cast<ProcessSaleCompletion_Output>().ToList();
                if (results is null || results.Count == 0) // || Results?[0] is null || Results[0]?.CustomerId is null
                {
                    return null;
                }

                return results[0];
            }
            catch (Exception ex)
            {
                ProcessSaleCompletion_Output processSaleCompletion_Failure = new ProcessSaleCompletion_Output()
                {
                    ResponseCode = 1,
                    ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                    ErrorCode = 500,
                };

                return processSaleCompletion_Failure;
            }
        }

        public async Task<InitiateRefund_Output> InitiateRefund(Input_InitiateRefund objClass)
        {
            List<InitiateRefund_Output> results = new List<InitiateRefund_Output>();
            try
            {
                string procedureName = StoredProcedures.POST_FASTLANE_CANCELSALECOMPLETION;

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "PartnerCode", objClass.PartnerCode },
                    { "TransactionAmount", objClass.TransactionAmount },
                    { "TransactionNumber", objClass.TransactionNumber },
                    { "RequestJson", Convert.ToString(JsonConvert.SerializeObject(objClass)) }
                };

                DynamicParameters Parameters = new DynamicParameters(parameters);

                using IDbConnection connection = _context.CreateConnection();
                IEnumerable<dynamic> result = await connection.QueryAsync<InitiateRefund_Output>(procedureName, Parameters, commandType: CommandType.StoredProcedure);
                results = result.Cast<InitiateRefund_Output>().ToList();
                if (results is null || results.Count == 0) // || Results?[0] is null || Results[0]?.CustomerId is null
                {
                    return null;
                }

                return results[0];
            }
            catch (Exception ex)
            {
                InitiateRefund_Output initiateRefund_Failure = new InitiateRefund_Output()
                {
                    ResponseCode = 1,
                    ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                    ErrorCode = 500,
                };

                return initiateRefund_Failure;
            }
        }

        public async Task<CheckStatus_Output> CheckStatus(Input_CheckStatus objClass)
        {
            List<CheckStatus_Output> results = new List<CheckStatus_Output>();
            try
            {
                string procedureName = StoredProcedures.GET_FASTLANE_SALECOMPLETIONSTATUSCHECK;

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "PartnerCode", objClass.PartnerCode },
                    { "TransactionNumber", objClass.TransactionNumber }
                };

                DynamicParameters Parameters = new DynamicParameters(parameters);

                using IDbConnection connection = _context.CreateConnection();
                IEnumerable<dynamic> result = await connection.QueryAsync<CheckStatus_Output>(procedureName, Parameters, commandType: CommandType.StoredProcedure);
                results = result.Cast<CheckStatus_Output>().ToList();
                if (results is null || results.Count == 0) // || Results?[0] is null || Results[0]?.CustomerId is null
                {
                    return null;
                }

                return results[0];
            }
            catch (Exception ex)
            {
                CheckStatus_Output checkStatus_Failure = new CheckStatus_Output()
                {
                    ResponseCode = 1,
                    ResponseMessage = $"Exception - {Convert.ToString(ex.Message)}",
                    ErrorCode = 500,
                };

                return checkStatus_Failure;
            }
        }
    }
}
