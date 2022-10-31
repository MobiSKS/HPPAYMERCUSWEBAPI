using Dapper;
using HPPay.DataModel.Country;
using HPPay.DataRepository.DBDapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.Country
{
    public class CountryRepository: ICountryRepository
    {
        private readonly DapperContext _context;
        public CountryRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetCountryModelOutput>> GetCountry([FromBody] GetCountryModelInput ObjClass)
        {
            var procedureName = "UspGetCountry";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCountryModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DeleteCountryModelOutput>> DeleteCountry([FromBody] DeleteCountryModelInput ObjClass)
        {
            var procedureName = "UspInactiveCountry";
            var parameters = new DynamicParameters();
            parameters.Add("CountryID", ObjClass.CountryID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DeleteCountryModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
