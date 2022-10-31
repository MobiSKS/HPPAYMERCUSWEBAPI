using Dapper;
using HPPay.DataModel.CountryRegion;
using HPPay.DataRepository.DBDapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.CountryRegion
{
    public class CountryRegionRepository: ICountryRegionRepository
    {
        private readonly DapperContext _context;
        public CountryRegionRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetCountryRegionModelOutput>> GetCountryRegion([FromBody] GetCountryRegionModelInput ObjClass)
        {
            var procedureName = "UspGetRegion";
            var parameters = new DynamicParameters();
            parameters.Add("ZoneID", ObjClass.ZoneID, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCountryRegionModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<DeleteCountryRegionModelOutput>> DeleteCountryRegion([FromBody] DeleteCountryRegionModelInput ObjClass)
        {
            var procedureName = "UspInactiveCountryRegion";
            var parameters = new DynamicParameters();
            parameters.Add("RegionID", ObjClass.RegionID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DeleteCountryRegionModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
