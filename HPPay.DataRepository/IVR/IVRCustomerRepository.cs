using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.Card;
using HPPay.DataModel.IVR;
using HPPay.DataModel.Login;
using HPPay.DataRepository.DBDapper;
using HPPay.Infrastructure.TokenManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HPPay.Infrastructure.CommonClass.StatusMessage;

namespace HPPay.DataRepository.IVR
{
    public class IVRCustomerRepository : IIVRCustomerRepository
    {
        private readonly DapperContext _context;
        private readonly IConfiguration _configuration;

        public IVRCustomerRepository(DapperContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<IEnumerable<CustomerBlockUnblockCardOutput>> CustomerBlockUnblockCard([FromBody] CustomerBlockUnblockCardInput ObjClass)
        {
            var procedureName = "UspCustomerBlockUnblockCard";
            var parameters = new DynamicParameters();
            parameters.Add("InputType", ObjClass.InputType, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerIdentifier", ObjClass.CustomerIdentifier, DbType.String, ParameterDirection.Input);
            parameters.Add("RequestType", ObjClass.RequestType, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNumber", ObjClass.CardNumber, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerBlockUnblockCardOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerCCMSBalanceInquiryOutput>> CustomerCCMSBalanceInquiry([FromBody] CustomerCCMSBalanceInquiryInput ObjClass)
        {
            var procedureName = "UspCustomerCCMSBalanceInquiry";
            var parameters = new DynamicParameters();
            parameters.Add("InputType", ObjClass.InputType, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerIdentifier", ObjClass.CustomerIdentifier, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerCCMSBalanceInquiryOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }    

        public async Task<IEnumerable<CustomerGenerateStatementOutput>> CustomerGenerateStatement([FromBody] CustomerGenerateStatementInput ObjClass)
        {
            var procedureName = "UspCustomerGenerateStatement";
            var parameters = new DynamicParameters();
            parameters.Add("InputType", ObjClass.InputType, DbType.Int64, ParameterDirection.Input);
            parameters.Add("CustomerIdentifier", ObjClass.CustomerIdentifier, DbType.String, ParameterDirection.Input);
            parameters.Add("StatementPeriod", ObjClass.StatementPeriod, DbType.Int64, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerGenerateStatementOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerLoyaltyRedemptionOutput>> CustomerLoyaltyRedemption([FromBody] CustomerloyaltyRedemptionInput ObjClass)
        {
            var procedureName = "UspCustomerLoyaltyRedemption";
            var parameters = new DynamicParameters();
            parameters.Add("InputType", ObjClass.InputType, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerIdentifier", ObjClass.CustomerIdentifier, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerLoyaltyRedemptionOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerResetCardPinOutput>> CustomerResetCardPin([FromBody] CustomerResetCardPinInput ObjClass)
        {
            var procedureName = "UspCustomerResetCardPin";
            var parameters = new DynamicParameters();
            parameters.Add("InputType", ObjClass.InputType, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerIdentifier", ObjClass.CustomerIdentifier, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNumber", ObjClass.CardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CardPIN", ObjClass.CardPIN, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerResetCardPinOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerResetControlCardPinOutput>> CustomerResetControlCardPin([FromBody] CustomerResetControlCardPinInput ObjClass)
        {
            var procedureName = "UspCustomerResetControlCardPin";
            var parameters = new DynamicParameters();
            parameters.Add("InputType", ObjClass.InputType, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerIdentifier", ObjClass.CustomerIdentifier, DbType.String, ParameterDirection.Input);
            parameters.Add("CardPIN", ObjClass.CardPIN, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerResetControlCardPinOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerResetPasswordOutput>> CustomerResetPassword([FromBody] CustomerResetPasswordInput ObjClass)
        {
            var procedureName = "UspCustomerResetPassword";
            var parameters = new DynamicParameters();
            parameters.Add("InputType", ObjClass.InputType, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerIdentifier", ObjClass.CustomerIdentifier, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerResetPasswordOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }        

        public async Task<IEnumerable<CustomerStarRewardsOutput>> CustomerStarRewards([FromBody] CustomerStarRewardsInput ObjClass)
        {
            var procedureName = "UspCustomerStarRewards";
            var parameters = new DynamicParameters();
            parameters.Add("InputType", ObjClass.InputType, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerIdentifier", ObjClass.CustomerIdentifier, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
             return await connection.QueryAsync<CustomerStarRewardsOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        byte[] bytes = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54, 56, 58, 60, 62, 64, 66, 68, 70 };

        public async Task<IEnumerable<ValidateCustomerControlCardOutput>> ValidateCustomerControlCard([FromBody] ValidateCustomerConrolCardInput ObjClass)
        {
            var procedureName = "UspValidateCustomerControlCard";
            var parameters = new DynamicParameters();
            parameters.Add("ControlCardNo", ObjClass.ControlCardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("ControlCardPIN", ObjClass.ControlCardPIN, DbType.String, ParameterDirection.Input);
            parameters.Add("ValidationMode", ObjClass.ValidationMode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<ValidateCustomerControlCardOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            if (string.IsNullOrEmpty(ObjClass.ControlCardPIN) || (ObjClass.ControlCardPIN == "string"))
            {              
                return result;
            }
            else
            {
                StatusInformation.API_Key_Is_Null.GetDisplayName();
                TokenManager.Secret = Convert.ToBase64String(bytes);
                List<ValidateCustomerControlCardOutput> ObjValMobile = result.ToList();
                ObjValMobile[0].SecurityToken = TokenManager.GenerateToken(_configuration.GetSection("IVR:Useragent").Value, _configuration.GetSection("ivr:Userid").Value,"");
                return ObjValMobile;
            }            
        }
        
        public async Task<IEnumerable<ValidateCustomerMobileOutput>> ValidateCustomerMobile([FromBody] ValidateCustomerMobileInput ObjClass)
        {
            var procedureName = "UspValidateCustomerMobile";
            var parameters = new DynamicParameters();
            parameters.Add("MobileNumber", ObjClass.MobileNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
            parameters.Add("ValidationMode", ObjClass.ValidationMode, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<ValidateCustomerMobileOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            if (string.IsNullOrEmpty(ObjClass.OTP) || (ObjClass.OTP == "string"))
            {
                return result;
            }
            else
            {
                StatusInformation.API_Key_Is_Null.GetDisplayName();                
                TokenManager.Secret = Convert.ToBase64String(bytes);
                List<ValidateCustomerMobileOutput> ObjValMobile = result.ToList();
                ObjValMobile[0].SecurityToken = TokenManager.GenerateToken(_configuration.GetSection("IVR:Useragent").Value, _configuration.GetSection("ivr:Userid").Value, "");
                return ObjValMobile;
            }
        }

        public async Task<IEnumerable<ValidateCustomerMobileOutput>> GenerateIVROTP([FromBody] ValidateCustomerMobileInput ObjClass)
        {
            var procedureName = "UspGenerateIVROTP";
            var parameters = new DynamicParameters();
            parameters.Add("Mobileno", ObjClass.MobileNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", _configuration.GetSection("IVR:Useragent").Value, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", _configuration.GetSection("ivr:Userid").Value, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", _configuration.GetSection("ivr:Userid").Value, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ValidateCustomerMobileOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);                        
        }

        public async Task<IEnumerable<ValidateCustomerMobileOutput>> ValidateIVROTP([FromBody] ValidateCustomerMobileInput ObjClass)
        {
            var procedureName = "UspValidateIVROTP";
            var parameters = new DynamicParameters();
            parameters.Add("MobileNumber", ObjClass.MobileNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", _configuration.GetSection("ivr:Userid").Value, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ValidateCustomerMobileOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ValidateCustomerControlCardOutput>> InsertUpdateIVRSecurityToken(string Token)
        {
            var procedureName = "UspInsertUpdateIVRSecurityToken";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", _configuration.GetSection("ivr:Userid").Value, DbType.String, ParameterDirection.Input);
            parameters.Add("Token", Token, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", _configuration.GetSection("IVR:Useragent").Value, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ValidateCustomerControlCardOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);            
        }
    }
} 
