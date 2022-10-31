using Dapper;
using HPPay.DataModel.MerchantDashboard;
using HPPay.DataRepository.DBDapper;
using HPPay.DataRepository.MerchantDashboard;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.MerchantDashboard
{
    public class MerchantDashboardRepository : IMerchantDashboardRepository
    {
        private readonly DapperContext _context;
        public string Status = "Initited";
        public MerchantDashboardRepository(DapperContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<MerchantDashboardKeyInformationModelOutput>> MerchantDashboardKeyInformation([FromBody] MerchantDashboardKeyInformationModelInput ObjClass)
        {
            var procedureName = "UspMerchantDashboardKeyInformation";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantDashboardKeyInformationModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<MerchantDashboardLastTransactionModelOutput>> MerchantDashboardLastTransaction([FromBody] MerchantDashboardLastTransactionModelInput ObjClass)
        {
            var procedureName = "UspMerchantDashboardLastTransaction";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantDashboardLastTransactionModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantDashboardLastBatchDeatilsModelOutput>> MerchantDashboardLastBatchDeatils([FromBody] MerchantDashboardLastBatchDeatilsModelInput ObjClass)
        {
            var procedureName = "UspMerchantDashboardLastBatchDeatils";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantDashboardLastBatchDeatilsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<MerchantDashboardLastSaleReloadEarningDetailsModelOutput>> MerchantDashboardLastSaleReloadEarningDetails([FromBody] MerchantDashboardLastSaleReloadEarningDetailsModelInput ObjClass)
        {
            var procedureName = "UspMerchantDashboardLastSaleReloadEarningDetails";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantDashboardLastSaleReloadEarningDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MerchantDashboardKeyEventsAndFiguresModelOutput>> MerchantDashboardKeyEventsAndFigures([FromBody] MerchantDashboardKeyEventsAndFiguresModelInput ObjClass)
        {
            var procedureName = "UspMerchantDashboardKeyEventsAndFigures";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantDashboardKeyEventsAndFiguresModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<MerchantDashboardTodaysTransactionSummaryModelOutput>> MerchantDashboardTodaysTransactionSummary([FromBody] MerchantDashboardTodaysTransactionSummaryModelInput ObjClass)
        {
            var procedureName = "UspMerchantDashboardTodaysTransactionSummary";
            var parameters = new DynamicParameters();
            parameters.Add("MerchantId", ObjClass.MerchantId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MerchantDashboardTodaysTransactionSummaryModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


    }
}
