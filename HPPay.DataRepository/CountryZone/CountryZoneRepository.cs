using Dapper;
using HPPay.DataModel.CountryZone;
using HPPay.DataRepository.DBDapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.CountryZone
{
    public class CountryZoneRepository: ICountryZoneRepository
    {
        private readonly DapperContext _context;
        public CountryZoneRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetCountryZoneModelOutput>> GetCountryZone([FromBody] GetCountryZoneModelInput ObjClass)
        {
            var procedureName = "UspGetZone";
            var parameters = new DynamicParameters();
            parameters.Add("HQID", ObjClass.HQID, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCountryZoneModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<DeleteCountryZoneModelOutput>> DeleteCountryZone([FromBody] DeleteCountryZoneModelInput ObjClass)
        {
            var procedureName = "UspInactiveCountryZone";
            var parameters = new DynamicParameters();
            parameters.Add("ZoneID", ObjClass.ZoneID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DeleteCountryZoneModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
