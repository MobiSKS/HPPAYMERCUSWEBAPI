using Dapper;
using HPCL.DataModel.Hotlist;
using HPCL.DataRepository.DBDapper;
using HPPay.DataModel.Hotlist;
using HPPay.DataRepository.Hotlist;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;
using static HPCL.DataModel.Hotlist.HotlistUpdatePermanentlyHotlistCardsModel;
using static HPPay.DataModel.Hotlist.HotlistUpdatePermanentlyHotlistCardsModel;

namespace HPCL.DataRepository.Hotlist
{
    public class HotlistRepository : IHotlistRepository
    {
        private readonly DapperContext _context;
        public HotlistRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetActionListOutput>> GetActionList([FromBody] GetActionListInput ObjClass)
        {
            var procedureName = "UspGetActionListHPPay";
            var parameters = new DynamicParameters();
            parameters.Add("EntityTypeId", ObjClass.EntityTypeId, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetActionListOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetEntityTypeListOutput>> GetEntityTypeList([FromBody] GetEntityTypeListInput ObjClass)
        {
            var procedureName = "UspGetEntityTypeListHPPay";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetEntityTypeListOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetReasonListForEntitiesOutput>> GetReasonListForEntities([FromBody] GetReasonListForEntitiesInput ObjClass)
        {
            var procedureName = "UspGetReasonListForEntitiesHPPay";
            var parameters = new DynamicParameters();
            parameters.Add("EntityTypeId", ObjClass.EntityTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Actionid", ObjClass.Actionid, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetReasonListForEntitiesOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetHotlistedOrReactivatedDetailsOutput>> GetHotlistedOrReactivatedDetails([FromBody] GetHotlistedOrReactivatedDetailsInput ObjClass)
        {
            var procedureName = "UspGetHotlistedOrReactivatedDetailsHPPay";
            var parameters = new DynamicParameters();
            parameters.Add("EntityTypeId", ObjClass.EntityTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("EntityIdVal", ObjClass.EntityIdVal, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetHotlistedOrReactivatedDetailsOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<HotlistUpdateModelOutput>> UpdateHotlistOrReactivate([FromBody] HotlistUpdateModelInput ObjClass)
        {
            var procedureName = "UspUpdateHotlistOrReactivateHPPay";
            var parameters = new DynamicParameters();
            parameters.Add("EntityTypeId", ObjClass.EntityTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("EntityIdVal", ObjClass.EntityIdVal, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionId", ObjClass.ActionId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ReasonId", ObjClass.ReasonId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ReasonDetails", ObjClass.ReasonDetails, DbType.String, ParameterDirection.Input);
            parameters.Add("Remarks", ObjClass.Remarks, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HotlistUpdateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<GetHotlistApprovalModelOutput>> GetHotlistApproval([FromBody] GetHotlistApprovalModelInput ObjClass)
        {
            var procedureName = "UspGetHotlistOrReactivateApprovalHPPay";
            var parameters = new DynamicParameters();
            parameters.Add("EntityTypeId", ObjClass.EntityTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ActionId", ObjClass.ActionId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetHotlistApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateHotlistApprovalModelOutput>> UpdateHotlistApproval([FromBody] UpdateHotlistApprovalModelInput ObjClass)
        {
            var dtDBR = new DataTable("EntityCodes");
            dtDBR.Columns.Add("EntityCode", typeof(string));


            if (ObjClass.ObjUpdateHotlistApprovalEntityCode != null)
            {
                foreach (UpdateHotlistApprovalEntityCodeModelInput ObjDetail in ObjClass.ObjUpdateHotlistApprovalEntityCode)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["EntityCode"] = ObjDetail.EntityCode;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspUpdateHotlistOrReactivateApprovalHPPay";
            var parameters = new DynamicParameters();
            parameters.Add("EntityTypeId", ObjClass.EntityTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ActionId", ObjClass.ActionId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ActionOnRequest", ObjClass.ActionOnRequest, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("EntityTypeCodes", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateHotlistApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<HotlistGetHotlistCardsDetailsModelOutput>> GetHotlistCardsDetails([FromBody] HotlistGetHotlistCardsDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetHotlistCardsDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HotlistGetHotlistCardsDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<HotlistGetHotlistReasonModelOutput>> GetHotlistReason([FromBody] HotlistGetHotlistReasonModelInput ObjClass)
        {
            var procedureName = "UspGetHotlistReason";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HotlistGetHotlistReasonModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<HotlistUpdatePermanentlyHotlistCardsModelOutput>> UpdatePermanentlyHotlistCards([FromBody] HotlistUpdatePermanentlyHotlistCardsModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypePermanentlyHotlistCards");
            // dtDBR.Columns.Add("CustomerId", typeof(string));
            dtDBR.Columns.Add("CardNo", typeof(string));
            dtDBR.Columns.Add("StatusId", typeof(int));

            if (ObjClass.TypePermanentlyHotlistCards != null)
            {
                foreach (TypePermanentlyHotlistCards ObjDetail in ObjClass.TypePermanentlyHotlistCards)
                {
                    DataRow dr = dtDBR.NewRow();

                    dr["CardNo"] = ObjDetail.CardNo;
                    dr["StatusId"] = ObjDetail.StatusId;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspUpdatePermanentlyHotlistCards";
            var parameters = new DynamicParameters();
            //parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            //parameters.Add("cardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("TypePermanentlyHotlistCards", dtDBR, DbType.Object, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HotlistUpdatePermanentlyHotlistCardsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CheckEntityAlreadyHotlistedModelOutput>> CheckEntityAlreadyHotlisted([FromBody] CheckEntityAlreadyHotlistedModelInput ObjClass)
        {
            var procedureName = "UspCheckEntityAlreadyHotlistedHPPay";
            var parameters = new DynamicParameters();
            parameters.Add("EntityTypeId", ObjClass.EntityTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("EntityIdVal", ObjClass.EntityIdVal, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckEntityAlreadyHotlistedModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<HotlistGetHotlistReissueCardsModelOutput>> GetHotlistReissueCards([FromBody] HotlistGetHotlistReissueCardsModelInput ObjClass)
        {
            var procedureName = "UspGetHotlistReissueCards";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HotlistGetHotlistReissueCardsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
