using Dapper;
using HPPay.DataModel.RegionalOffice;
using HPPay.DataRepository.DBDapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.RegionalOffice
{
    public class RegionalOfficeRepository : IRegionalOfficeRepository
    {
        private readonly DapperContext _context;
        public RegionalOfficeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetRegionalOfficeModelOutput>> GetRegionalOffice([FromBody] GetRegionalOfficeModelInput ObjClass)
        {
            var procedureName = "UspGetRegionalOffice";
            var parameters = new DynamicParameters();
            parameters.Add("ZonalID", ObjClass.ZonalID, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetRegionalOfficeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DeleteRegionalOfficeModelOutput>> DeleteRegionalOffice([FromBody] DeleteRegionalOfficeModelInput ObjClass)
        {
            var procedureName = "UspInactiveRegionalOffice";
            var parameters = new DynamicParameters();
            parameters.Add("RegionalOfficeID", ObjClass.RegionalOfficeID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DeleteRegionalOfficeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetRegionalOfficeModelOutput>> GetRegionalOfficeByMultipleZone([FromBody] GetRegionalOfficebyMultipleZoneModelInput ObjClass)
        {
            var procedureName = "UspGetRegionalOfficeByMultipleZone";
            var parameters = new DynamicParameters();
            parameters.Add("ZonalID", ObjClass.ZonalID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetRegionalOfficeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetRegionalOfficeOnlyRetailModelOutput>> GetRegionalOfficeOnlyRetail([FromBody] GetRegionalOfficeOnlyRetailModelInput ObjClass)
        {
            var procedureName = "UspGetRegionalOfficeOnlyRetail";
            var parameters = new DynamicParameters();
            parameters.Add("ZonalID", ObjClass.ZonalID, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetRegionalOfficeOnlyRetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
