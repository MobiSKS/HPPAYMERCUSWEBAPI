using Dapper;
using HPPay.DataModel.Login;
using HPPay.DataRepository.DBDapper;
using HPPay.Infrastructure.TokenManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using static HPPay.Infrastructure.CommonClass.StatusMessage;

namespace HPPay.DataRepository.Login
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DapperContext _context;
        public LoginRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetLoginModelOutput>> GetLogin([FromBody] GetLoginModelInput ObjClass)
        {
            var procedureName = "UspGetUserLogin";
            var parameters = new DynamicParameters();
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Password", ObjClass.Password, DbType.String, ParameterDirection.Input);
            parameters.Add("DeviceId", ObjClass.DeviceId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            //return await connection.QueryAsync<GetLoginModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var result = await connection.QueryAsync<GetLoginModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            StatusInformation.API_Key_Is_Null.GetDisplayName();
            //bool IsResult = this.Return_Key(_accountRepo, out string UserMessage, 0, out int IntStatusCode, ObjClass.Useragent, ObjClass.Userip, ObjClass.Userid);
            string API_Key = string.Empty;
            string Secret_Key = string.Empty;
            byte[] bytes = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54, 56, 58, 60, 62, 64, 66, 68, 70 };
            TokenManager.Secret = Convert.ToBase64String(bytes);
            List<GetLoginModelOutput> ObjUserLogin = result.ToList();
            ObjUserLogin[0].Token = TokenManager.GenerateToken(ObjClass.Useragent, ObjClass.Userid, ObjClass.Userip);
            return ObjUserLogin;

        }

        public async Task<IEnumerable<GetMenuDetailsForUserModelOutput>> GetMenuDetailsForUser([FromBody] GetMenuDetailsForUserModelInput ObjClass)
        {
            var procedureName = "UspGetMenuDetailsForUser";
            var parameters = new DynamicParameters();
            parameters.Add("UserType", ObjClass.UserType, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetMenuDetailsForUserModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetMobileMenuDetailsForUserModelOutput>> GetMobileMenuDetailsForUser([FromBody] GetMobileMenuDetailsForUserModelInput ObjClass)
        {
            var procedureName = "UspGetMobileMenuDetailsForUser";
            var parameters = new DynamicParameters();
            parameters.Add("UserType", ObjClass.UserType, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetMobileMenuDetailsForUserModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ManageUsersTokenModelBaseOutput>> InsertUpdateManageUsersToken([FromBody] InsertUpdateManageUsersTokenModelInput ObjClass)
        {
            var procedureName = "UspInsertUpdateManageUsersToken";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Token", ObjClass.Token, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("UserIp", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ManageUsersTokenModelBaseOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            //var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            //var storedProcedureResult = new InsertUpdateManageUsersTokenModelOutput();
            //List<ManageUsersTokenModelBaseOutput> manageUsersTokenModelBaseOutputs = new List<ManageUsersTokenModelBaseOutput>();
            //manageUsersTokenModelBaseOutputs = (List<ManageUsersTokenModelBaseOutput>)await result.ReadAsync<ManageUsersTokenModelBaseOutput>();
            //storedProcedureResult.ManageUsersTokenModelBaseOutput = manageUsersTokenModelBaseOutputs.FirstOrDefault();
            //storedProcedureResult.MenuDetails = (List<MenuDetails>)await result.ReadAsync<MenuDetails>();
            //return storedProcedureResult;
        }

        public async Task<CheckManageUsersTokenModelOutput> CheckManageUsersToken([FromBody] CheckManageUsersTokenModelInput ObjClass)
        {
            var procedureName = "UspCheckManageUsersToken";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("UserIp", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new CheckManageUsersTokenModelOutput();
            List<CHeckManageUsersTokenModelBaseOutput> manageUsersTokenModelBaseOutputs = new List<CHeckManageUsersTokenModelBaseOutput>();
            manageUsersTokenModelBaseOutputs = (List<CHeckManageUsersTokenModelBaseOutput>)await result.ReadAsync<CHeckManageUsersTokenModelBaseOutput>();
            storedProcedureResult.CheckManageUsersTokenModelBaseOutput = manageUsersTokenModelBaseOutputs.FirstOrDefault();
            storedProcedureResult.MenuDetails = (List<MenuDetails>)await result.ReadAsync<MenuDetails>();
            return storedProcedureResult;
        }
    }
}
