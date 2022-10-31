using Dapper;
using HPPay.DataModel.HQ;
using HPPay.DataRepository.DBDapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.HQ
{
    public class HQRepository : IHQRepository
    {
        private readonly DapperContext _context;
        public HQRepository(DapperContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<InsertHQModelOutput>> InsertHQ([FromBody] InsertHQModelInput ObjClass)
        {
            var procedureName = "UspInsertHQ";
            var parameters = new DynamicParameters();
            parameters.Add("HQCode", ObjClass.HQCode, DbType.String, ParameterDirection.Input);
            parameters.Add("HQName", ObjClass.HQName, DbType.String, ParameterDirection.Input);
            parameters.Add("HQShortName", ObjClass.HQShortName, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertHQModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetHQModelOutput>> GetHQ([FromBody] GetHQModelInput ObjClass)
        {
            var procedureName = "UspGetHQ";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetHQModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateHQModelOutput>> UpdateHQ([FromBody] UpdateHQModelInput ObjClass)
        {
            var procedureName = "UspUpdateHQ";
            var parameters = new DynamicParameters();
            parameters.Add("HQID", ObjClass.HQID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("HQCode", ObjClass.HQCode, DbType.String, ParameterDirection.Input);
            parameters.Add("HQName", ObjClass.HQName, DbType.String, ParameterDirection.Input);
            parameters.Add("HQShortName", ObjClass.HQShortName, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateHQModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DeleteHQModelOutput>> DeleteHQ([FromBody] DeleteHQModelInput ObjClass)
        {
            var procedureName = "UspInactiveHQ";
            var parameters = new DynamicParameters();
            parameters.Add("HQID", ObjClass.HQID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<DeleteHQModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
