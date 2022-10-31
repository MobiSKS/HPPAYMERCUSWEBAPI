using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.IVR;
using HPPay.DataRepository.DBDapper;
using HPPay.Infrastructure.TokenManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HPPay.Infrastructure.CommonClass.StatusMessage;

namespace HPPay.DataRepository.IVR
{
    public class IVRDriverRepository : IIVRDriverRepository
    {
        private readonly DapperContext _context;
        private readonly IConfiguration _configuration;

        public IVRDriverRepository(DapperContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<IEnumerable<DriverCheckCardBalanceOutput>> DriverCheckCardBalance([FromBody] DriverCheckCardBalanceInput ObjClass)
        {
            var procedureName = "UspDriverCheckCardBalance";
            var parameters = new DynamicParameters();
            parameters.Add("InputType", ObjClass.InputType, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerIdentifier", ObjClass.CustomerIdentifier, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DriverCheckCardBalanceOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DriverCheckCardLimitOutput>> DriverCheckCardLimit([FromBody] DriverCheckCardLimitInput ObjClass)
        {
            var procedureName = "UspDriverCheckCardLimit";
            var parameters = new DynamicParameters();
            parameters.Add("InputType", ObjClass.InputType, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerIdentifier", ObjClass.CustomerIdentifier, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DriverCheckCardLimitOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DriverLastTransactionDetailsOutput>> DriverLastTransactionDetails([FromBody] DriverLastTransactionDetailsInput ObjClass)
        {
            var procedureName = "UspDriverLastTransactionDetails";
            var parameters = new DynamicParameters();
            parameters.Add("InputType", ObjClass.InputType, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerIdentifier", ObjClass.CustomerIdentifier, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DriverLastTransactionDetailsOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        byte[] bytes = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54, 56, 58, 60, 62, 64, 66, 68, 70 };

        public async Task<IEnumerable<ValidateDriverCardPinOutput>> ValidateDriverCardPin([FromBody] ValidateDriverCardPinInput ObjClass)
        {
            var procedureName = "UspValidateDriverCardPin";
            var parameters = new DynamicParameters();
            parameters.Add("DriverCardNo", ObjClass.DriverCardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("DriverCardPIN", ObjClass.DriverCardPIN, DbType.String, ParameterDirection.Input);
            parameters.Add("ValidationMode", ObjClass.ValidationMode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<ValidateDriverCardPinOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            if (string.IsNullOrEmpty(ObjClass.DriverCardPIN) || (ObjClass.DriverCardPIN == "string"))
            {
                return result;
            }
            else
            {
                StatusInformation.API_Key_Is_Null.GetDisplayName();
                TokenManager.Secret = Convert.ToBase64String(bytes);
                List<ValidateDriverCardPinOutput> ObjValMobile = result.ToList();
                ObjValMobile[0].SecurityToken = TokenManager.GenerateToken(_configuration.GetSection("IVR:Useragent").Value, _configuration.GetSection("ivr:Userid").Value, "");
                return ObjValMobile;
            }
        }

        public async Task<IEnumerable<ValidateDriverMobileNumberOutput>> ValidateDriverMobileNumber([FromBody] ValidateDriverMobileNumberInput ObjClass)
        {
            var procedureName = "UspValidateDriverMobileNumber";
            var parameters = new DynamicParameters();
            parameters.Add("MobileNumber", ObjClass.MobileNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
            parameters.Add("ValidationMode", ObjClass.ValidationMode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<ValidateDriverMobileNumberOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            if (string.IsNullOrEmpty(ObjClass.OTP) || (ObjClass.OTP == "string"))
            {
                return result;
            }
            else
            {
                StatusInformation.API_Key_Is_Null.GetDisplayName();
                TokenManager.Secret = Convert.ToBase64String(bytes);
                List<ValidateDriverMobileNumberOutput> ObjValMobile = result.ToList();
                ObjValMobile[0].SecurityToken = TokenManager.GenerateToken(_configuration.GetSection("IVR:Useragent").Value, _configuration.GetSection("ivr:Userid").Value, "");
                return ObjValMobile;
            }
        }       
    }
}
