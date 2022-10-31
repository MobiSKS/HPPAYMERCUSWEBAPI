using HPPay.DataModel.Login;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.Login
{
    public interface ILoginRepository
    {
        public Task<IEnumerable<GetLoginModelOutput>> GetLogin([FromBody] GetLoginModelInput ObjClass);
        public Task<IEnumerable<GetMenuDetailsForUserModelOutput>> GetMenuDetailsForUser([FromBody] GetMenuDetailsForUserModelInput ObjClass);

        public Task<IEnumerable<GetMobileMenuDetailsForUserModelOutput>> GetMobileMenuDetailsForUser([FromBody] GetMobileMenuDetailsForUserModelInput ObjClass);

        public Task<IEnumerable<ManageUsersTokenModelBaseOutput>> InsertUpdateManageUsersToken([FromBody] InsertUpdateManageUsersTokenModelInput ObjClass);

        public Task<CheckManageUsersTokenModelOutput> CheckManageUsersToken([FromBody] CheckManageUsersTokenModelInput ObjClass);

        //public Task<IEnumerable<GetMobileUserLoginOutput>> GetMobileUserLogin([FromBody] GetMobileUserLoginInput ObjClass);
    }
}
