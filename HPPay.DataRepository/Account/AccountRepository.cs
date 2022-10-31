using HPPay.DataRepository.DBDapper;
using Microsoft.Extensions.Logging;

namespace HPPay.DataRepository.Account
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DapperContext _context;
        private readonly ILogger<AccountRepository> _logger;
        public AccountRepository(DapperContext context, ILogger<AccountRepository> logger)
        {
            _context = context;
            _logger = logger;
        }


    }
    //using (var connectio1n = _context.CreateConnection())
    // {
    //  //   var companies = await connection.QueryAsync<Company>(query);
    //     //return companies.ToList();
    // }

    //  var procedureName = "sp_Test";
    //var parameters = new DynamicParameters();
    //parameters.Add("username", ObjUser.Username, DbType.String, ParameterDirection.Input);
    //parameters.Add("Mobileno", ObjUser.Mobileno, DbType.String, ParameterDirection.Input);
    //parameters.Add("password", ObjUser.Password, DbType.String, ParameterDirection.Input);

    //var parameters = new DynamicParameters();
    //parameters.Add("Mobileno", ObjUser.Mobileno, DbType.String, ParameterDirection.Input);

    //using (var connection = _context.CreateConnection())
    //{
    //    var login_input = await connection.QueryFirstOrDefaultAsync<LoginModel>
    //        (procedureName, parameters, commandType: CommandType.StoredProcedure);
    //    return login_input;
    //}

    // return true;
}
//}
