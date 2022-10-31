using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.CustomerFeedback;
using HPPay.DataRepository.DBDapper;
using HPPay.Infrastructure.CommonClass;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace HPPay.DataRepository.CustomerFeedbackRepository
{
    public class CustomerFeedbackRepositary : ICustomerFeedbackRepository
    {
        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        //private readonly Variables ObjVariable;
        public CustomerFeedbackRepositary(DapperContext context, IHostingEnvironment hostingEnvironment) // , IConfiguration configuration
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            //ObjVariable = new Variables(configuration);
        }
        public async Task<IEnumerable<CustomerFeedbackDropdownModelOutput>> CustomerFeedbackDropdown([FromBody] CustomerFeedbackDropdownModelInput ObjClass)
        {
            var procedureName = "UspCustomerFeedbackDropdown";
            var parameters = new DynamicParameters();
            parameters.Add("EntityType", ObjClass.EntityType, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CustomerFeedbackDropdownModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
