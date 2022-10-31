using Dapper;
using HPPay.DataModel.MODashboard;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPPay.DataRepository
{
    public class MODashboardRepository : IMODashboardRepository
    {
        private readonly DapperContext _context;
        //private readonly IHostingEnvironment _hostingEnvironment;

        public MODashboardRepository(DapperContext context)//, IHostingEnvironment hostingEnvironment) // , IConfiguration configuration
        {
            _context = context;
            //_hostingEnvironment = hostingEnvironment;

        }
        public async Task<IEnumerable<MODashboardPendingTerminalModelOutput>> MODashboardPendingTerminal(MODashboardPendingTerminalModelInput objClass)
        {
            var procedureName = "UspMODashboardPendingTerminal";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", objClass.UserName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MODashboardPendingTerminalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MODashboardRegionInformationModelOutput>> MODashboardRegionInformation(MODashboardRegionInformationModelInput objClass)
        {
            var procedureName = "UspMODashboardRegionInformation";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", objClass.UserName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MODashboardRegionInformationModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MODashboardUserInformationModelOutput>> MODashboardUserInformation(MODashboardUserInformationModelInput objClass)
        {
            var procedureName = "UspMODashboardUserInformation";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", objClass.UserName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<MODashboardUserInformationModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
