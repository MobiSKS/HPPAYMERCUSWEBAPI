using HPPay.DataModel.UserManage;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.UserManage
{
    public interface IUserManageRepository
    {
        public Task<IEnumerable<GetUserRoleModelOutput>> SelectUserManageRolesRequest([FromBody] GetUserRoleModelInput ObjClass);
        public Task<IEnumerable<ResetPasswordUserManageModelOutput>> ResetPasswordUserManage([FromBody] ResetPasswordUserManageModelInput ObjClass); 
        public Task<IEnumerable<GetManageUsersModelOutput>> GetManageUsers(GetManageUsersModelInput objClass);
        public  Task<IEnumerable<UserManagerCheckUserModelOutput>> CheckUser([FromBody] UserManagerCheckUserModelInput ObjClass);
        public Task<IEnumerable<UserManagerAddUserModelOutput>> AddUser([FromBody] UserManagerAddUserModelInput ObjClass);

        public Task<IEnumerable<UserCustomerAddUserModelOutput>> AddUserWithMultipleCustomer([FromBody] UserCustomerAddUserModelInput ObjClass);

        public Task<IEnumerable<MapUserWithMultipleCustomerOutput>> MapUserWithMultipleCustomer([FromBody] MapUserWithMultipleCustomerInput ObjClass);

        public Task<IEnumerable<ViewUserWithMultipleCustomerOutput>> ViewUserWithMultipleCustomer([FromBody] ViewUserWithMultipleCustomerInput ObjClass);

        public Task<IEnumerable<GetUserManageMenuListOutput>> GetUserManageMenuList([FromBody] GetUserManageMenuListInput ObjClass);

        public Task<IEnumerable<UserManageDeleteManageUsersModelOutput>> DeleteManageUsers([FromBody] UserManageDeleteManageUsersModelInput ObjClass);

 
        public Task<IEnumerable<UpdateManageUsersModelOutput>> UpdateManageUsers([FromBody] UpdateManageUsersModelInput ObjClass);

        public Task<GetUserRolesAndRegionsModelOutput> GetUserRolesAndRegions([FromBody] GetUserRolesAndRegionsModelInput ObjClass);

        public Task<UserManageGetUserManageRoleListModelOutput> GetUserManageRoleList([FromBody] UserManageGetUserManageRoleListModelInput ObjClass);
        public Task<IEnumerable<InsertAddManageRoleModelOutput>> InsertAddManageRole([FromBody] InsertAddManageRoleModelInput ObjClass);
        public Task<IEnumerable<UpdateInsertManageRoleModelOutput>> UpdateInsertManageRole([FromBody] UpdateInsertManageRoleModelInput ObjClass);


        public Task<IEnumerable<RoleNameAndRoleDescriptionMappingModelOutput>> DeleteRoles([FromBody] RoleNameAndRoleDescriptionMappingModelInput ObjClass);
        public Task<IEnumerable<ManageUsersAddUserRoleModelOutput>> ManageUsersAddUserRole([FromBody] ManageUsersAddUserRoleModelInput ObjClass);
        public Task<IEnumerable<UserManageUserCreationRequestModelOutput>> UserCreationRequest([FromBody] UserManageUserCreationRequestModelInput ObjClass);

        public Task<IEnumerable<UserCreationRequestViewModelOutput>> UserCreationRequestView(UserCreationRequestViewModelInput objClass);
        public Task<IEnumerable<UserCreationApprovalModelOutput>> UserCreationApproval([FromBody] UserCreationApprovalModelInput ObjClass);

        public Task<IEnumerable<UserManageGetUserCreationApprovalModelOutput>> GetUserCreationApproval(UserManageGetUserCreationApprovalModelInput objClass);
        public Task<IEnumerable<UserApprovalRejectionModelOutput>> UserApprovalRejection([FromBody] UserApprovalRejectionModelInput ObjClass);
        public Task<IEnumerable<ManageAPIRoleListModelOutput>> ManageAPIRoleList([FromBody] ManageAPIRoleListModelInput ObjClass);
        public Task<IEnumerable<DeleteManageAPIRoleModelOutput>> DeleteManageAPIRole([FromBody] DeleteManageAPIRoleModelInput ObjClass);
        public Task<IEnumerable<UpdateUserRoleLocationModelOutput>> UpdateUserRoleLocation([FromBody] UpdateUserRoleLocationModelInput ObjClass);

        public Task<IEnumerable<GetAddAPIRoleAndPermissionsModelOutput>> GetAddAPIRoleAndPermissions([FromBody] GetAddAPIRoleAndPermissionsModelInput ObjClass);

        public Task<GetEditManageAPIRoleModelOutput> GetEditManageAPIRole([FromBody] GetEditManageAPIRoleModelInput ObjClass);

        public Task<IEnumerable<AddManageAggregatorUsersModelOutput>> AddManageAggregatorUsers([FromBody] AddManageAggregatorUsersModelInput ObjClass);


        public Task<IEnumerable<GetUserCreationApprovalRoleLocationModelOutput>> GetUserCreationApprovalRoleLocation(GetUserCreationApprovalRoleLocationModelInput objClass);


        public Task<IEnumerable<ManageAggregatorUsersModelOutput>> ManageAggregatorUsers(ManageAggregatorUsersModelInput objClass);


        public Task<IEnumerable<ManageEditUsersModelOutput>> ManageEditUsers(ManageEditUsersModelInput objClass);
        public Task<IEnumerable<DisableEnableManageAggregatorUsersModelOutput>> DisableEnableManageAggregatorUsers(DisableEnableManageAggregatorUsersModelInput objClass);

        public Task<IEnumerable<AddUsersManageAggregatorUsersModelOutput>> AddUsersManageAggregatorUsers([FromBody] AddUsersManageAggregatorUsersModelInput ObjClass);
        public Task<IEnumerable<UpdateAggregatorUserDetailsWithRolesModelOutput>> UpdateAggregatorUserDetailsWithRoles([FromBody] UpdateAggregatorUserDetailsWithRolesModelInput ObjClass);
        public Task<GetAddManageUsersModelOutput> GetAddManageUsers([FromBody] GetAddManageUsersModelInput ObjClass);

        public Task<UserManageGetManageAggregatorUsersModelOutput> GetManageAggregatorUsers(UserManageGetManageAggregatorUsersModelInput objClass);
        public Task<UserManageEditUserModelOutput> ManageEditUser([FromBody] UserManageEditUserModelInput ObjClass);

        public Task<IEnumerable<ManageUsersRoleLocationDeleteModelOutput>> ManageUsersRoleLocationDelete([FromBody] ManageUsersRoleLocationDeleteModelInput ObjClass);
        public Task<IEnumerable<UserManageAddUserMultipleCustomerModelOutput>> AddUserMultipleCustomer([FromBody] UserManageAddUserMultipleCustomerModelInput ObjClass);


    }


}
