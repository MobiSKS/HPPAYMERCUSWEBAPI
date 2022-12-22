using Dapper;
using HPPay.DataModel.City;
using HPPay.DataRepository.DBDapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.City
{
    public class CityRepository: ICityRepository
    {
        private readonly DapperContext _context;
        public CityRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetCityModelOutput>> GetCity([FromBody] GetCityModelInput ObjClass)
        {
            var procedureName = "UspGetCityHPPay";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCityModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<DeleteCityModelOutput>> DeleteCity([FromBody] DeleteCityModelInput ObjClass)
        {
            var procedureName = "UspInactiveCityHPPay";
            var parameters = new DynamicParameters();
            parameters.Add("CityID", ObjClass.CityID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DeleteCityModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
