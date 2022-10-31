using Dapper;
using HPPay.DataModel.District;
using HPPay.DataRepository.DBDapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.District
{
    public class DistrictRepository: IDistrictRepository
    {
        private readonly DapperContext _context;
        public DistrictRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetDistrictModelOutput>> GetDistrict([FromBody] GetDistrictModelInput ObjClass)
        {
            var procedureName = "UspGetDistrict";
            var parameters = new DynamicParameters();
            parameters.Add("StateID", ObjClass.StateID, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDistrictModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DeleteDistrictModelOutput>> DeleteDistrict([FromBody] DeleteDistrictModelInput ObjClass)
        {
            var procedureName = "UspInactiveDistrict";
            var parameters = new DynamicParameters();
            parameters.Add("DistrictID", ObjClass.DistrictID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DeleteDistrictModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetDistrictModelOutput>> GetDistrictByMultipleStateID([FromBody] GetDistrictByMultipleStateIDModelInput ObjClass)
        {
            var procedureName = "UspGetDistrictByMultipleState";
            var parameters = new DynamicParameters();
            parameters.Add("StateID", ObjClass.StateID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDistrictModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
