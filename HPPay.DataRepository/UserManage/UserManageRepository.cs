using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.UserManage;
using HPPay.DataRepository.DBDapper;
using HPPay.Infrastructure.CommonClass;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.UserManage
{
    public class UserManageRepository : IUserManageRepository
    {
        private readonly DapperContext _context;
         public UserManageRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetUserRoleModelOutput>> SelectUserManageRolesRequest([FromBody] GetUserRoleModelInput ObjClass)
        {
            var procedureName = "UspSelectUserManageRolesRequestHPPay";
            var parameters = new DynamicParameters();
            parameters.Add("RoleName", ObjClass.RoleName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetUserRoleModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<ResetPasswordUserManageModelOutput>> ResetPasswordUserManage([FromBody] ResetPasswordUserManageModelInput ObjClass)
        {
            var procedureName = "UspResetPasswordUserManageHPPay";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ResetPasswordUserManageModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetManageUsersModelOutput>> GetManageUsers(GetManageUsersModelInput objClass)
        {
            var procedureName = "UspGetManageUsersHPpay";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", objClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("Email", objClass.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("LastLoginTime", objClass.LastLoginTime, DbType.String, ParameterDirection.Input);
            parameters.Add("ShowDisabled", objClass.ShowDisabled, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserRole", objClass.UserRole, DbType.String, ParameterDirection.Input);
            parameters.Add("ForAll", objClass.ForAll, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetManageUsersModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<UserManagerCheckUserModelOutput>> CheckUser([FromBody] UserManagerCheckUserModelInput ObjClass)
        {
            var procedureName = "UspCheckUser";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UserManagerCheckUserModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UserManagerAddUserModelOutput>> AddUser([FromBody] UserManagerAddUserModelInput ObjClass)
        {
            var procedureName = "UspAddUserHPPay";
            var parameters = new DynamicParameters();

            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("Email", ObjClass.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("Password", ObjClass.Password, DbType.String, ParameterDirection.Input);
            parameters.Add("ConfirmPassword", ObjClass.ConfirmPassword, DbType.String, ParameterDirection.Input);
            parameters.Add("SecretQuestion", ObjClass.SecretQuestion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("SecretQuestionAnswer", ObjClass.SecretQuestionAnswer, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("FirstName", ObjClass.FirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("LastName", ObjClass.LastName, DbType.String, ParameterDirection.Input);
            parameters.Add("StateId", ObjClass.StateId, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UserManagerAddUserModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        

        public async Task<IEnumerable<UserCustomerAddUserModelOutput>> AddUserWithMultipleCustomer([FromBody] UserCustomerAddUserModelInput ObjClass)
        {
            var procedureName = "UspAddUserWithMultipleCustomer";
            var parameters = new DynamicParameters();



            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("Email", ObjClass.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("Password", ObjClass.Password, DbType.String, ParameterDirection.Input);
            parameters.Add("ConfirmPassword", ObjClass.ConfirmPassword, DbType.String, ParameterDirection.Input);
            parameters.Add("SecretQuestion", ObjClass.SecretQuestion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("SecretQuestionAnswer", ObjClass.SecretQuestionAnswer, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UserCustomerAddUserModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MapUserWithMultipleCustomerOutput>> MapUserWithMultipleCustomer([FromBody] MapUserWithMultipleCustomerInput ObjClass)
        {
            var procedureName = "UspMapUserWithMultipleCustomer";
            var parameters = new DynamicParameters();
            string customerIds = ObjClass.CustomerId[0];
            for (int i = 1; i < ObjClass.CustomerId.Count; i++)
            {
                customerIds= customerIds + ','+ ObjClass.CustomerId[i];
            }



            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerId", customerIds, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            
            using var connection = _context.CreateConnection();
            dynamic result = "";
            return await connection.QueryAsync<MapUserWithMultipleCustomerOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            
        }

        public async Task<IEnumerable<ViewUserWithMultipleCustomerOutput>> ViewUserWithMultipleCustomer([FromBody] ViewUserWithMultipleCustomerInput ObjClass)
        {
            var procedureName = "UspViewUserWithMultipleCustomer";
            var parameters = new DynamicParameters();
            
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            dynamic result = "";
            return await connection.QueryAsync<ViewUserWithMultipleCustomerOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);


        }
        public async Task<IEnumerable<GetUserManageMenuListOutput>> GetUserManageMenuList([FromBody] GetUserManageMenuListInput ObjClass)
        {
            var procedureName = "UspGetManageMenuListHPPay";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetUserManageMenuListOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UserManageDeleteManageUsersModelOutput>> DeleteManageUsers([FromBody] UserManageDeleteManageUsersModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeDeleteUserManage");
            dtDBR.Columns.Add("UserName", typeof(string));
            ;
            var procedureName = "UspDeleteManageUsersHPPay";
            var parameters = new DynamicParameters();

            foreach (TypeDeleteUserManage objdtl in ObjClass.TypeDeleteUserManage)
            {
                DataRow dr = dtDBR.NewRow();
                dr["UserName"] = objdtl.UserName;

                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }

            parameters.Add("TypeDeleteUserManage", dtDBR, DbType.Object, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UserManageDeleteManageUsersModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateManageUsersModelOutput>> UpdateManageUsers(UpdateManageUsersModelInput objClass)
        {
            var procedureName = "UspUpdateManageUsersHPPay";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", objClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("Actions", objClass.Actions, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateManageUsersModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetUserRolesAndRegionsModelOutput> GetUserRolesAndRegions([FromBody] GetUserRolesAndRegionsModelInput ObjClass)
        {
            var procedureName = "UspGetUserRolesAndRegionsHPPay";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            var storedProcedureResult = new GetUserRolesAndRegionsModelOutput();
            storedProcedureResult.UserRoles = (List<UserRolesModelOutput>)await result.ReadAsync<UserRolesModelOutput>();
            storedProcedureResult.Locations = (List<UserRegionsModelOutput>)await result.ReadAsync<UserRegionsModelOutput>();
            return storedProcedureResult;
        }

        public async Task<UserManageGetUserManageRoleListModelOutput> GetUserManageRoleList([FromBody] UserManageGetUserManageRoleListModelInput ObjClass)
        {
            var procedureName = "UspGetUserManageRoleListHPPay";
            var parameters = new DynamicParameters();
            parameters.Add("RoleId", ObjClass.RoleId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new UserManageGetUserManageRoleListModelOutput();
            storedProcedureResult.tblMainAndSubLevelRoleMap = (List<GetMainAndSubLevelRoleMap>)await result.ReadAsync<GetMainAndSubLevelRoleMap>();
            storedProcedureResult.tblMenuDetails = (List<GetSubLevelRoleMenuMap>)await result.ReadAsync<GetSubLevelRoleMenuMap>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<InsertAddManageRoleModelOutput>> InsertAddManageRole([FromBody] InsertAddManageRoleModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeInsertAddManageUsers");
            dtDBR.Columns.Add("MenuId", typeof(int));
            dtDBR.Columns.Add("AllowedAction", typeof(int));

            var procedureName = "UspInsertAddManageRoleHPPay";
            var parameters = new DynamicParameters();


            foreach (TypeInsertAddManageUsers ObjInsert in ObjClass.TypeInsertAddManageUsers)
            {
                DataRow dr = dtDBR.NewRow();
                dr["MenuId"] = ObjInsert.MenuId;
                dr["AllowedAction"] = ObjInsert.AllowedAction;

                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }
           
            parameters.Add("RoleName", ObjClass.RoleName, DbType.String, ParameterDirection.Input);
            parameters.Add("RoleDescription", ObjClass.RoleDescription, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeInsertAddManageUsers", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertAddManageRoleModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<RoleNameAndRoleDescriptionMappingModelOutput>> DeleteRoles([FromBody] RoleNameAndRoleDescriptionMappingModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeRoleNameAndRoleDescriptionMapping");
            dtDBR.Columns.Add("RoleName", typeof(string));
            dtDBR.Columns.Add("RoleDescription", typeof(string));

            var procedureName = "UspDeleteRolesHPPay";
            var parameters = new DynamicParameters();

            foreach (TypeRoleNameAndRoleDescriptionMapping objdtl in ObjClass.TypeRoleNameAndRoleDescriptionMapping)
            {
                DataRow dr = dtDBR.NewRow();
                dr["RoleName"] = objdtl.RoleName;
                dr["RoleDescription"] = objdtl.RoleDescription;

                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }

            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeRoleNameAndRoleDescriptionMapping", dtDBR, DbType.Object, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<RoleNameAndRoleDescriptionMappingModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateInsertManageRoleModelOutput>> UpdateInsertManageRole([FromBody] UpdateInsertManageRoleModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeInsertAddManageUsers");
            dtDBR.Columns.Add("MenuId", typeof(int));
            dtDBR.Columns.Add("AllowedAction", typeof(int));

            var procedureName = "UspUpdateInsertManageRoleHPPay";
            var parameters = new DynamicParameters();

            foreach (TypeUpdateInsertManageUsersTable ObjUpdate in ObjClass.ObjUpdate)
            {
                DataRow dr = dtDBR.NewRow();
                dr["MenuId"] = ObjUpdate.MenuId;
                dr["AllowedAction"] = ObjUpdate.AllowedAction;

                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }

            parameters.Add("RoleId", ObjClass.RoleId, DbType.String, ParameterDirection.Input);
            parameters.Add("RoleName", ObjClass.RoleName, DbType.String, ParameterDirection.Input);
            parameters.Add("RoleDescription", ObjClass.RoleDescription, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeInsertAddManageUsers", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateInsertManageRoleModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UserManageUserCreationRequestModelOutput>> UserCreationRequest([FromBody] UserManageUserCreationRequestModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeUserCreationDetails");
            dtDBR.Columns.Add("ZO", typeof(int));
            dtDBR.Columns.Add("RO", typeof(int));

            var procedureName = "UspUserCreationRequest";
            var parameters = new DynamicParameters();


            foreach (TypeUserCreationDetails ObjInsert in ObjClass.TypeUserCreationDetails)
            {
                DataRow dr = dtDBR.NewRow();
                dr["ZO"] = ObjInsert.ZO;
                dr["RO"] = ObjInsert.RO;

                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }
            parameters.Add("Email", ObjClass.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("FirstName", ObjClass.FirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("MiddleName", ObjClass.MiddleName, DbType.String, ParameterDirection.Input);
            parameters.Add("LastName", ObjClass.LastName, DbType.String, ParameterDirection.Input);
            parameters.Add("Comments", ObjClass.Comments, DbType.String, ParameterDirection.Input);
            parameters.Add("UserRole", ObjClass.UserRole, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeUserCreationDetails", dtDBR, DbType.Object, ParameterDirection.Input);
          

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UserManageUserCreationRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }
        public async Task<IEnumerable<UserCreationApprovalModelOutput>> UserCreationApproval([FromBody] UserCreationApprovalModelInput ObjClass)
        {

            var procedureName = "UspUserCreationApproval";
            var parameters = new DynamicParameters();
            parameters.Add("FirstName", ObjClass.FirstName, DbType.String, ParameterDirection.Input);
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
                
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UserCreationApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<ManageUsersAddUserRoleModelOutput>> ManageUsersAddUserRole([FromBody] ManageUsersAddUserRoleModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeManageUsersAddUserRole");
            dtDBR.Columns.Add("ZO", typeof(int));
            dtDBR.Columns.Add("RO", typeof(int));

            var procedureName = "UspManageUsersAddUserRole";
            var parameters = new DynamicParameters();

            foreach (TypeManageUsersAddUserRole objdtl in ObjClass.TypeManageUsersAddUserRole)
            {
                DataRow dr = dtDBR.NewRow();
                dr["ZO"] = objdtl.ZO;
                dr["RO"] = objdtl.RO;

                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }

            parameters.Add("UserRole", ObjClass.UserRole, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeManageUsersAddUserRole", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ManageUsersAddUserRoleModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<UserCreationRequestViewModelOutput>>UserCreationRequestView(UserCreationRequestViewModelInput objClass)
        {
            var procedureName = "UspUserCreationRequestView";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", objClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("Status", objClass.Status, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", objClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", objClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UserCreationRequestViewModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<UserManageGetUserCreationApprovalModelOutput>> GetUserCreationApproval(UserManageGetUserCreationApprovalModelInput objClass)
        {
            var procedureName = "UspGetUserCreationApproval";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", objClass.UserName, DbType.String, ParameterDirection.Input);        
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UserManageGetUserCreationApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UserApprovalRejectionModelOutput>>UserApprovalRejection([FromBody] UserApprovalRejectionModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeApprovalRejectionList");
            dtDBR.Columns.Add("UserName", typeof(string));
            dtDBR.Columns.Add("Email", typeof(string));
            dtDBR.Columns.Add("Comments", typeof(string));



            var procedureName = "UspUserApprovalRejection";
            var parameters = new DynamicParameters();

            foreach (TypeApprovalRejectionList objdtl in ObjClass.TypeApprovalRejectionList)
            {
                DataRow dr = dtDBR.NewRow();
                dr["UserName"] = objdtl.UserName;
                dr["Email"] = objdtl.Email;
                dr["Comments"] = objdtl.Comments;



                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }


            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeApprovalRejectionList", dtDBR, DbType.Object, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UserApprovalRejectionModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<ManageAPIRoleListModelOutput>> ManageAPIRoleList([FromBody] ManageAPIRoleListModelInput ObjClass)
        {

            var procedureName = "UspManageAPIRoleList";
            var parameters = new DynamicParameters();
            parameters.Add("RoleName", ObjClass.RoleName, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ManageAPIRoleListModelOutput>(procedureName,parameters , commandType: CommandType.StoredProcedure);
        }

        
        public async Task<IEnumerable<DeleteManageAPIRoleModelOutput>> DeleteManageAPIRole([FromBody] DeleteManageAPIRoleModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeRoleNameAndRoleDescriptionMapping");
            dtDBR.Columns.Add("RoleName", typeof(string));
            dtDBR.Columns.Add("RoleDescription", typeof(string));



            var procedureName = "UspDeleteManageAPIRole";
            var parameters = new DynamicParameters();

            foreach (TypeDeleteRoleNameAndRoleDescriptionMappings objdtl in ObjClass.TypeRoleNameAndRoleDescriptionMapping)
            {
                DataRow dr = dtDBR.NewRow();
                dr["RoleName"] = objdtl.RoleName;
                dr["RoleDescription"] = objdtl.RoleDescription;


                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }


            parameters.Add("TypeRoleNameAndRoleDescriptionMapping", dtDBR, DbType.Object, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DeleteManageAPIRoleModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetAddAPIRoleAndPermissionsModelOutput>> GetAddAPIRoleAndPermissions([FromBody] GetAddAPIRoleAndPermissionsModelInput ObjClass)
        {
            var procedureName = "UspGetAddAPIRoleAndPermissions";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAddAPIRoleAndPermissionsModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetEditManageAPIRoleModelOutput> GetEditManageAPIRole([FromBody] GetEditManageAPIRoleModelInput ObjClass)
        {
            var procedureName = "UspGetEditManageAPIRole";
            var parameters = new DynamicParameters();
            parameters.Add("RoleName", ObjClass.RoleName, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetEditManageAPIRoleModelOutput();
            storedProcedureResult.tblThirdPartyApiMainAndSubLevelRoleMap = (List<GetThirdPartyApiMainAndSubLevelRoleMap>)await result.ReadAsync<GetThirdPartyApiMainAndSubLevelRoleMap>();
            storedProcedureResult.tblThirdPartyApiDetails = (List<GetThirdPartyApiDetails>)await result.ReadAsync<GetThirdPartyApiDetails>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<AddManageAggregatorUsersModelOutput>> AddManageAggregatorUsers([FromBody] AddManageAggregatorUsersModelInput ObjClass)
        {
            var procedureName = "UspAddManageAggregatorUsers";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AddManageAggregatorUsersModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetUserCreationApprovalRoleLocationModelOutput>> GetUserCreationApprovalRoleLocation(GetUserCreationApprovalRoleLocationModelInput objClass)
        {
            var procedureName = "UspGetUserCreationApprovalRoleLocation";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", objClass.UserName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetUserCreationApprovalRoleLocationModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ManageAggregatorUsersModelOutput>> ManageAggregatorUsers(ManageAggregatorUsersModelInput objClass)
        {
            var procedureName = "UspManageAggregatorUsers";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", objClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("Email", objClass.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("LastLoginTime", objClass.LastLoginTime, DbType.String, ParameterDirection.Input);
            parameters.Add("UserRole", objClass.UserRole, DbType.String, ParameterDirection.Input);
            parameters.Add("ShowDisabled", objClass.ShowDisabled, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ManageAggregatorUsersModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ManageEditUsersModelOutput>> ManageEditUsers(ManageEditUsersModelInput objClass)
        {
            var procedureName = "UspManageEditUsersHPPay";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", objClass.UserName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ManageEditUsersModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<DisableEnableManageAggregatorUsersModelOutput>> DisableEnableManageAggregatorUsers(DisableEnableManageAggregatorUsersModelInput objClass)
        {
            var procedureName = "UspDisableEnableManageAggregatorUsers";
            var parameters = new DynamicParameters();
            parameters.Add("ActionType", objClass.ActionType, DbType.String, ParameterDirection.Input);
            parameters.Add("LoginKey", objClass.LoginKey, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DisableEnableManageAggregatorUsersModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<AddUsersManageAggregatorUsersModelOutput>> AddUsersManageAggregatorUsers([FromBody] AddUsersManageAggregatorUsersModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeAddManageAggregatorUsers");
            dtDBR.Columns.Add("RoleName", typeof(string));
            dtDBR.Columns.Add("RoleDescription", typeof(string));
            dtDBR.Columns.Add("ControlType", typeof(string));



            var procedureName = "UspAddUsersManageAggregatorUsers";
            var parameters = new DynamicParameters();

            foreach (TypeAddManageAggregatorUsers objdtl in ObjClass.TypeAddManageAggregatorUsers)
            {
                DataRow dr = dtDBR.NewRow();
                dr["RoleName"] = objdtl.RoleName;
                dr["RoleDescription"] = objdtl.RoleDescription;
                dr["ControlType"] = objdtl.ControlType;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("Email", ObjClass.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("Password", ObjClass.Password, DbType.String, ParameterDirection.Input);
            parameters.Add("ConfirmPassword", ObjClass.ConfirmPassword, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeAddManageAggregatorUsers", dtDBR, DbType.Object, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AddUsersManageAggregatorUsersModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateAggregatorUserDetailsWithRolesModelOutput>> UpdateAggregatorUserDetailsWithRoles([FromBody] UpdateAggregatorUserDetailsWithRolesModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeUpdateManageAggregatorUsers");
            dtDBR.Columns.Add("RoleName", typeof(string));
            dtDBR.Columns.Add("RoleDescription", typeof(string));
            dtDBR.Columns.Add("ControlType", typeof(string));
            dtDBR.Columns.Add("StatusFlag", typeof(int));

            var procedureName = "UspUpdateAggregatorUserDetailsWithRoles";
            var parameters = new DynamicParameters();

            foreach (TypeUpdateManageAggregatorUsers objdtl in ObjClass.TypeUpdateManageAggregatorUsers)
            {
                DataRow dr = dtDBR.NewRow();
                dr["RoleName"] = objdtl.RoleName;
                dr["RoleDescription"] = objdtl.RoleDescription;
                dr["ControlType"] = objdtl.ControlType;
                dr["StatusFlag"] = objdtl.StatusFlag;

                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }


            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("Email", ObjClass.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeUpdateManageAggregatorUsers", dtDBR, DbType.Object, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateAggregatorUserDetailsWithRolesModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetAddManageUsersModelOutput> GetAddManageUsers([FromBody] GetAddManageUsersModelInput ObjClass)
        {
            var procedureName = "UspGetAddManageUsers";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            var storedProcedureResult = new GetAddManageUsersModelOutput();
            storedProcedureResult.KeyDeatil = (List<mstKeyDetail>)await result.ReadAsync<mstKeyDetail>();
            storedProcedureResult.Location = (List<ZonalandRegionalLocation>)await result.ReadAsync<ZonalandRegionalLocation>();
            return storedProcedureResult;
        }


        public async Task<UserManageGetManageAggregatorUsersModelOutput> GetManageAggregatorUsers(UserManageGetManageAggregatorUsersModelInput objClass)
        {
            var procedureName = "UspGetManageAggregatorUsers";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", objClass.UserName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);


            var storedProcedureResult = new UserManageGetManageAggregatorUsersModelOutput();
            storedProcedureResult.UserDetails = (List<UserDetails>)await result.ReadAsync<UserDetails>();
            storedProcedureResult.RoleDetails = (List<RoleDetails>)await result.ReadAsync<RoleDetails>();
            return storedProcedureResult;
        }

        public async Task<UserManageEditUserModelOutput> ManageEditUser([FromBody] UserManageEditUserModelInput ObjClass)
        {
            var procedureName = "UspManageEditUserHPPay";            
            var parameters = new DynamicParameters();
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new UserManageEditUserModelOutput();
            storedProcedureResult.mstKeyDetail = (List<GetmstKeyDetail>)await result.ReadAsync<GetmstKeyDetail>();
            storedProcedureResult.tblMainAndSubLevel = (List<GetRoleMap>)await result.ReadAsync<GetRoleMap>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<ManageUsersRoleLocationDeleteModelOutput>> ManageUsersRoleLocationDelete([FromBody] ManageUsersRoleLocationDeleteModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeManageUsersAddUserRole");
            dtDBR.Columns.Add("ZO", typeof(int));
            dtDBR.Columns.Add("RO", typeof(int));



            var procedureName = "UspManageUsersRoleLocationDelete";
            var parameters = new DynamicParameters();

            foreach (TypeManageUsersAddUserRole objdtl in ObjClass.TypeManageUsersAddUserRole)
            {
                DataRow dr = dtDBR.NewRow();
                dr["ZO"] = objdtl.ZO;
                dr["RO"] = objdtl.RO;

                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }
            parameters.Add("Username", ObjClass.Username, DbType.String, ParameterDirection.Input);
            parameters.Add("RoleId", ObjClass.RoleId, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeManageUsersAddUserRole", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ManageUsersRoleLocationDeleteModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateUserRoleLocationModelOutput>> UpdateUserRoleLocation([FromBody] UpdateUserRoleLocationModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeManageUsersAddUserRoleWithStatusFlag");
            dtDBR.Columns.Add("ZO", typeof(int));
            dtDBR.Columns.Add("RO", typeof(int));
            dtDBR.Columns.Add("StatusFlag", typeof(int));


            var procedureName = "UspUpdateUserRoleLocation";
            var parameters = new DynamicParameters();

            foreach (TypeManageUsersAddUserRoleWithStatusFlag objdtl in ObjClass.TypeManageUsersAddUserRoleWithStatusFlag)
            {
                DataRow dr = dtDBR.NewRow();
                dr["ZO"] = objdtl.ZO;
                dr["RO"] = objdtl.RO;
                dr["StatusFlag"] = objdtl.StatusFlag;



                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }


            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("UserRole", ObjClass.UserRole, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Email", ObjClass.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeManageUsersAddUserRoleWithStatusFlag", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateUserRoleLocationModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UserManageAddUserMultipleCustomerModelOutput>> AddUserMultipleCustomer([FromBody] UserManageAddUserMultipleCustomerModelInput ObjClass)
        {
            var procedureName = "UspAddUserMultipleCustomer";
            var parameters = new DynamicParameters();

            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("Email", ObjClass.Email, DbType.String, ParameterDirection.Input);
            parameters.Add("Password", ObjClass.Password, DbType.String, ParameterDirection.Input);
            parameters.Add("ConfirmPassword", ObjClass.ConfirmPassword, DbType.String, ParameterDirection.Input);
            parameters.Add("SecretQuestion", ObjClass.SecretQuestion, DbType.Int32, ParameterDirection.Input);
            parameters.Add("SecretQuestionAnswer", ObjClass.SecretQuestionAnswer, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UserManageAddUserMultipleCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
