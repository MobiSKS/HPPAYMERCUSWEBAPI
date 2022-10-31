using Dapper;
using HPPay.DataModel.BasicSearchByCustomer;
using HPPay.DataRepository.DBDapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using static HPPay.DataModel.BasicSearchByCard.BasicSearchByModelCard;

namespace HPPay.DataRepository.BasicSearch
{
    public class BasicSearchByCustomerRepository : IBasicSearchByCustomerRepository
    {
        private readonly DapperContext _context;
         
        public BasicSearchByCustomerRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BasicSearchByCustomerOutput>>GetBasicSearchByModelCustomers ([FromBody] BasicSearchByCustomerInput ObjClass)
        {
            var procedureName = "UspBasicSearch";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("NameonCard", ObjClass.NameonCard, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationStateId", ObjClass.CommunicationStateId, DbType.String, ParameterDirection.Input);
            parameters.Add("CommunicationCityName", ObjClass.CommunicationCityName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BasicSearchByCustomerOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<BasicSearchByCardOutput>> GetBasicSearchByModelCards([FromBody] BasicSearchByCardInput ObjClass)
        {

            var procedureName = "UspBasicCardSearch";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("CardType", ObjClass.CardType, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleNo", ObjClass.VehicleNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNumber", ObjClass.CardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("IssueDate", ObjClass.IssueDate, DbType.String, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BasicSearchByCardOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ViewBasicSearchByCustomerModelOutput>> ViewBasicSearchByModelCustomers([FromBody] ViewBasicSearchByCustomerModelInput ObjClass)
        {
            var procedureName = "UspViewBasicSearchByCardDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
           
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ViewBasicSearchByCustomerModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}

