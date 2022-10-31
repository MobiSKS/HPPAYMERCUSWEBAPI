using Dapper;
using HPPay.DataModel.CustomerDashboard;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository
{
    public class CustomerDashboardRepository : ICustomerDashboardRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CustomerDashboardRepository(DapperContext context, IHostingEnvironment hostingEnvironment) // , IConfiguration configuration
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;

        }
        public async Task<IEnumerable<CustomerDashBoardVerifyYourDetailsModelOutput>> CustomerDashBoardVerifyYourDetails(CustomerDashBoardVerifyYourDetailsModelInput objClass)
        {
            var procedureName = "UspCustomerDashBoardVerifyYourDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", objClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerDashBoardVerifyYourDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CustomerDashBoardAccountSummaryModelOutput>> CustomerDashBoardAccountSummary(CustomerDashBoardAccountSummaryModelInput objClass)
        {
            var procedureName = "UspCustomerDashBoardAccountSummary";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", objClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerDashBoardAccountSummaryModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CustomerDashBoardLastTransactionsModelOutput>> CustomerDashBoardLastTransactions(CustomerDashBoardLastTransactionsModelInput objClass)
        {
            var procedureName = "UspCustomerDashBoardLastTransactions";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", objClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerDashBoardLastTransactionsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CustomerDashBoardKeyEventModelOutput>> CustomerDashBoardKeyEvent(CustomerDashBoardKeyEventModelInput objClass)
        {
            var procedureName = "UspCustomerDashBoardKeyEvent";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", objClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerDashBoardKeyEventModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CustomerDashBoardReminderModelOutput>> CustomerDashBoardReminder([FromBody] CustomerDashBoardReminderModelInput ObjClass)
        {
            var procedureName = "UspCustomerDashBoardReminder";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerDashBoardReminderModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CustomerDashboardUpdateVerifyYourDetailsModelOutput>> CustomerDashboardUpdateVerifyYourDetails(CustomerDashboardUpdateVerifyYourDetailsModelInput objClass)
        {
            var procedureName = "UspCustomerDashboardUpdateVerifyYourDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", objClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationEmailid", objClass.CommunicationEmailid, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationMobileNo", objClass.CommunicationMobileNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerDashboardUpdateVerifyYourDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetNotificationContentModelOutput>> GetNotificationContent(GetNotificationContentModelInput objClass)
        {
            var procedureName = "UspGetNotificationContent";
            var parameters = new DynamicParameters();
            parameters.Add("UserType", objClass.UserType, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetNotificationContentModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CustomerDashBoardLatestDrivestarsTransactionsModelOutput>> CustomerDashBoardLatestDrivestarsTransactions([FromBody] CustomerDashBoardLatestDrivestarsTransactionsModelInput ObjClass)
        {
            var procedureName = "UspCustomerDashBoardLatestDrivestarsTransactions";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerDashBoardLatestDrivestarsTransactionsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
