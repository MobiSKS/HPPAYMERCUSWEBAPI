using Dapper;
using HPPay.DataRepository.DBDapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using static HPPay.DataModel.BasicSearchByCard.BasicSearchByModelCard;

namespace HPPay.DataRepository.BasicSearchByCard
{
    public class BasicSearchByCardRepository : IBasicSearchByCardRepository
    {
        private readonly DapperContext _context;

        public BasicSearchByCardRepository(DapperContext context)
        {
            _context = context;
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
            parameters.Add("ExpiryDate", ObjClass.ExpiryDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BasicSearchByCardOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}

    
