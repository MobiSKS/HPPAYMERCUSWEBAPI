using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.DICV;
using HPPay.DataModel.SadakKeSathi;
using HPPay.DataRepository.DBDapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace HPPay.DataRepository.SadakKeSathi
{
    public class SadakKeSathiRepository : ISadakKeSathiRepository
    {

        private readonly DapperContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public SadakKeSathiRepository(DapperContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IEnumerable<GetSKSVehicleDetailModelOutput>> GetSKSVehicleDetail(GetSKSVehicleDetailModelInput objClass)
        {
            var procedureName = "UspGetSKSVehicleDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", objClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetSKSVehicleDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetSKSChargesPerVehicleModelOutput>> GetSKSMonthlyChargesPerVehicle()
        {
            var procedureName = "UspGetSKSMonthlyChargesPerVehicle";
            var parameters = new DynamicParameters();           
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetSKSChargesPerVehicleModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<InsertSKSVehicleEnrolmentDetailModelOutput>> InsertSKSVehicleEnrolmentDetail(InsertSKSVehicleEnrolmentDetailModelInput objClass)
        {
            var dtDBR = new DataTable("SKSVehicles");
            
            dtDBR.Columns.Add("Vehicle", typeof(string));
            dtDBR.Columns.Add("CardNo", typeof(string));
            dtDBR.Columns.Add("Period", typeof(int));
            dtDBR.Columns.Add("Amount", typeof(decimal));

            if (objClass.SKSVehicles != null)
            {
                foreach (SKSVehicle ObjDetails in objClass.SKSVehicles)
                {
                    DataRow dr = dtDBR.NewRow();
                   
                    dr["Vehicle"] =ObjDetails.VehicleNo;
                    dr["CardNo"] = ObjDetails.CardNo;
                    dr["Period"] = ObjDetails.ServicePeriod;
                    dr["Amount"] = ObjDetails.Amount;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "uspvehicleEnrollmentforSKSInsurance";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", objClass.CustomerID, DbType.String, ParameterDirection.Input);
            //parameters.Add("VehicleNo", objClass.VehicleNo, DbType.String, ParameterDirection.Input);
            //parameters.Add("CardNo", objClass.CardNo, DbType.String, ParameterDirection.Input);
            //parameters.Add("Period", objClass.ServicePeriod, DbType.Int32, ParameterDirection.Input);
            //parameters.Add("Amount", objClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("SKSVehicles", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertSKSVehicleEnrolmentDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetSKSVehicleEnrolmentDetailModelOutput>> GetSKSVehicleEnrolmentDetail(GetSKSVehicleEnrolmentDetailModelInput objClass)
        {
            var procedureName = "UspGetSKSMappedVehicleDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", objClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetSKSVehicleEnrolmentDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
