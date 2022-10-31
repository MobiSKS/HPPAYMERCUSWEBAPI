using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace HPPay.DataRepository.DBDapper
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("HPPayConnectionString");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);

        public SqlConnection CreateSqlConnection()
           => new SqlConnection(_connectionString);

        public void Dispose()
        {

        }

#pragma warning disable IDE0060 // Remove unused parameter
        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            if (sp is null)
            {
                throw new ArgumentNullException(nameof(sp));
            }

            if (parms is null)
            {
                throw new ArgumentNullException(nameof(parms));
            }

            throw new NotImplementedException();
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
        {
            using IDbConnection db = new SqlConnection(_configuration.GetConnectionString(_connectionString));
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }

        //public async Task<IEnumerable<T>>  GetAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text)
        //{
        //    IEnumerable<T> result;
        //    using IDbConnection db = new SqlConnection(_configuration.GetConnectionString(_connectionString));
        //    result= await  db.QueryAsync<IEnumerable<T>>(sp, parms, commandType: commandType);
        //    result.FirstOrDefault();
        //    return result;
        //}

        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new SqlConnection(_configuration.GetConnectionString(_connectionString));
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }


        public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = new SqlConnection(_configuration.GetConnectionString(_connectionString));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }

        public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = new SqlConnection(_configuration.GetConnectionString(_connectionString));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }


    }
}
