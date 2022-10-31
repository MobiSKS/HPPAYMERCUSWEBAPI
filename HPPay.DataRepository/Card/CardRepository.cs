using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.Card;
using HPPay.DataRepository.DBDapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Http;


namespace HPPay.DataRepository.Card
{
    public class CardRepository : ICardRepository
    {
        private readonly DapperContext _context;
        public CardRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ManageSearchCardsModelOutput>> SearchManageCard([FromBody] ManageSearchCardsModelInput ObjClass)
        {
            var procedureName = "UspGetCardInfo";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("Vehiclenumber", ObjClass.Vehiclenumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Statusflag", ObjClass.Statusflag, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ManageSearchCardsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<CardManageSearchWithVahanInfoModelOutput>> GetCardInfowithVahanInfo([FromBody] CardManageSearchWithVahanInfoModelnput ObjClass)
        {
            var procedureName = "UspGetCardInfowithVahanInfo";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("Vehiclenumber", ObjClass.Vehiclenumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Statusflag", ObjClass.Statusflag, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CardManageSearchWithVahanInfoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<GetCardLimtModelOutput> GetCardLimitFeatures([FromBody] GetCardLimtModelInput ObjClass)
        {
            var procedureName = "UspGetCardFeatures";
            var parameters = new DynamicParameters();
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetCardLimtModelOutput();
            storedProcedureResult.GetCardsDetails = (List<GetCardsDetailsModelOutput>)await result.ReadAsync<GetCardsDetailsModelOutput>();
            storedProcedureResult.GetCardLimt = (List<CardLimtModelOutput>)await result.ReadAsync<CardLimtModelOutput>();
            //storedProcedureResult.CardReminingLimt = (List<CardReminingLimtModelOutput>)await result.ReadAsync<CardReminingLimtModelOutput>();
            //storedProcedureResult.CardReminingCCMSLimt = (List<CardReminingCCMSLimtModelOutput>)await result.ReadAsync<CardReminingCCMSLimtModelOutput>();
            storedProcedureResult.CardServices = (List<CardServicesModelOutput>)await result.ReadAsync<CardServicesModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<UpdateMobileInCardModelOutput>> UpdateMobileInCard([FromBody] UpdateMobileInCardModelInput ObjClass)
        {
            var procedureName = "UspUpdateMobileInCard";
            var parameters = new DynamicParameters();
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateMobileInCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateServiveOnCardModelOutput>> UpdateServiveOnCard([FromBody] UpdateServiveOnCardModelInput ObjClass)
        {
            var procedureName = "UspUpdateServiveOnCard";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Serviceid", ObjClass.Serviceid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Flag", ObjClass.Flag, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateServiveOnCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateCardLimitsModelOutput>> UpdateCardLimits([FromBody] UpdateCardLimitsModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeUpdateCardLimits");
            dtDBR.Columns.Add("Cardno", typeof(string));
            // dtDBR.Columns.Add("Cashpurse", typeof(decimal));
            dtDBR.Columns.Add("SaleTxnLimit", typeof(decimal));
            dtDBR.Columns.Add("DailySaleLimit", typeof(decimal));
            dtDBR.Columns.Add("MonthlySaleLimit", typeof(decimal));

            var procedureName = "UspUpdateCardLimits";
            var parameters = new DynamicParameters();

            //parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            //parameters.Add("Cashpurse", ObjClass.Cashpurse, DbType.Decimal, ParameterDirection.Input);
            //parameters.Add("Saletxn", ObjClass.Saletxn, DbType.Int32, ParameterDirection.Input);
            //parameters.Add("Dailysale", ObjClass.Dailysale, DbType.Int32, ParameterDirection.Input);
            //parameters.Add("Monthlysale", ObjClass.Monthlysale, DbType.Int32, ParameterDirection.Input);

            foreach (CardLimitsModelInput ObjCardLimits in ObjClass.ObjCardLimits)
            {
                DataRow dr = dtDBR.NewRow();
                dr["Cardno"] = ObjCardLimits.Cardno;
                // dr["Cashpurse"] = ObjCardLimits.Cashpurse;
                dr["SaleTxnLimit"] = ObjCardLimits.SaleTxnLimit;
                dr["DailySaleLimit"] = ObjCardLimits.DailySaleLimit;
                dr["MonthlySaleLimit"] = ObjCardLimits.MonthlySaleLimit;

                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }

            parameters.Add("TypeUpdateCardLimits", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCardLimitsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateCCMSLimitsModelOutput>> UpdateCCMSLimits([FromBody] UpdateCCMSLimitsModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeUpdateCCMSLimits");
            dtDBR.Columns.Add("Cardno", typeof(string));
            dtDBR.Columns.Add("Limittype", typeof(int));
            dtDBR.Columns.Add("Amount", typeof(decimal));
            dtDBR.Columns.Add("MobileNo", typeof(string));


            var procedureName = "UspUpdateCCMSLimits";
            var parameters = new DynamicParameters();
            //parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            //parameters.Add("Limittype", ObjClass.Limittype, DbType.Int32, ParameterDirection.Input);
            //parameters.Add("Amount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);

            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);

            foreach (CCMSLimitsModelInput ObjCardLimits in ObjClass.ObjCCMSLimits)
            {
                DataRow dr = dtDBR.NewRow();
                dr["Cardno"] = ObjCardLimits.Cardno;
                dr["Limittype"] = ObjCardLimits.Limittype;
                dr["Amount"] = ObjCardLimits.Amount;
                dr["MobileNo"] = ObjCardLimits.MobileNo;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }

            parameters.Add("TypeUpdateCCMSLimits", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCCMSLimitsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetCCMSLimitsModelOutput> GetCCMSLimits([FromBody] GetCCMSLimitsModelInput ObjClass)
        {
            var procedureName = "UspGetCCMSLimits";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("VechileNo", ObjClass.VechileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);

            var storedProcedureResult = new GetCCMSLimitsModelOutput();
            storedProcedureResult.CCMSBalanceDetail = (List<GetCCMSLimitsForAllCardsModelOutput>)await result.ReadAsync<GetCCMSLimitsForAllCardsModelOutput>(); ;
            storedProcedureResult.CCMSBasicDetail = (List<CCMSLimitsModelOutput>)await result.ReadAsync<CCMSLimitsModelOutput>(); ;
            return storedProcedureResult;
        }

        public async Task<IEnumerable<GetCardLimitsModelOutput>> GetCardLimits([FromBody] GetCardLimitsModelInput ObjClass)
        {
            var procedureName = "UspGetCardLimits";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("Statusflag", ObjClass.Statusflag, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCardLimitsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<UpdateCCMSLimitForAllCardsModelOutput>> UpdateCCMSLimitForAllCards([FromBody] UpdateCCMSLimitForAllCardsModelInput ObjClass)
        {
            var procedureName = "UspUpdateCCMSLimitForAllCards";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Limittype", ObjClass.Limittype, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Amount", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCCMSLimitForAllCardsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateCardLimitForAllCardsModelOutput>> UpdateCardLimitForAllCards([FromBody] UpdateCardLimitForAllCardsModelInput ObjClass)
        {
            var procedureName = "UspUpdateCardLimitForAllCards";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Cashpurse", ObjClass.Cashpurse, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("Saletxn", ObjClass.Saletxn, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Dailysale", ObjClass.Dailysale, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Monthlysale", ObjClass.Monthlysale, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCardLimitForAllCardsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetLimitMasterModelOutput>> GetCCMSLimitMaster([FromBody] GetLimitMasterModelInput ObjClass)
        {
            var procedureName = "UspGetCCMSLimitMaster";
            var parameters = new DynamicParameters();
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetLimitMasterModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetAllCardWithStatusModelOutput>> GetAllCardWithStatus([FromBody] GetAllCardWithStatusModelInput ObjClass)
        {
            var procedureName = "UspGetAllCardWithStatus";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAllCardWithStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateCardStatusModelOutput>> UpdateCardStatus([FromBody] UpdateCardStatusModelInput ObjClass)
        {
            var procedureName = "UspUpdateCardStatus";
            var parameters = new DynamicParameters();
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Statusflag", ObjClass.Statusflag, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCardStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ViewCardLimitsModelOutput>> ViewCardLimits([FromBody] ViewCardLimitsModelInput ObjClass)
        {
            var procedureName = "UspGetCustomerAllCardAllLimits";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ViewCardLimitsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetCCMSLimitsForAllCardsModelOutput>> GetCCMSLimitsForAllCards([FromBody] GetCCMSLimitsForAllCardsModelInput ObjClass)
        {
            var procedureName = "UspGetCCMSLimitsForAllCards";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("Statusflag", ObjClass.Statusflag, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCCMSLimitsForAllCardsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<AddCardModelOutput>> AddCard([FromBody] AddCardModelInput ObjClass)
        {
            var dtDBR = new DataTable("UserDTNoofCards");
            dtDBR.Columns.Add("CardIdentifier", typeof(string));
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("VehicleMake", typeof(string));
            dtDBR.Columns.Add("VehicleType", typeof(string));
            dtDBR.Columns.Add("YearOfRegistration", typeof(int));
            dtDBR.Columns.Add("MobileNo", typeof(string));

            var procedureName = "UspAddCard";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("NoOfCards", ObjClass.NoOfCards, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RBEId", ObjClass.RBEId, DbType.String, ParameterDirection.Input);
            parameters.Add("FeePaymentsCollectFeeWaiver", ObjClass.FeePaymentsCollectFeeWaiver, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FeePaymentNo", ObjClass.FeePaymentNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FeePaymentDate", ObjClass.FeePaymentDate, DbType.DateTime, ParameterDirection.Input);

            if (ObjClass.NoOfCards > 0 && ObjClass.ObjCardDetail != null)
            {
                foreach (CardDetail ObjCardDetails in ObjClass.ObjCardDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CardIdentifier"] = ObjCardDetails.CardIdentifier;
                    dr["VechileNo"] = ObjCardDetails.VechileNo;
                    dr["VehicleMake"] = ObjCardDetails.VehicleMake;
                    dr["VehicleType"] = ObjCardDetails.VehicleType;
                    dr["YearOfRegistration"] = ObjCardDetails.YearOfRegistration;
                    dr["MobileNo"] = ObjCardDetails.MobileNo;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }
            parameters.Add("CardDetails", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CardPreference", ObjClass.CardPreference, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("NoofVechileforAllCards", ObjClass.NoofVechileforAllCards, DbType.Int32, ParameterDirection.Input);
            parameters.Add("VehicleNoVerifiedManually", ObjClass.VehicleNoVerifiedManually, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AddCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ApproveRejectCardModelOutput>> ApproveRejectCard([FromBody] ApproveRejectCardModelInput ObjClass)
        {
            var dtDBR = new DataTable("UserDTNoofCardsforApproveRejectCard");
            dtDBR.Columns.Add("CardIdentifier", typeof(string));
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("VehicleMake", typeof(string));
            dtDBR.Columns.Add("VehicleType", typeof(string));
            dtDBR.Columns.Add("YearOfRegistration", typeof(int));
            dtDBR.Columns.Add("MobileNo", typeof(string));
            dtDBR.Columns.Add("CardId", typeof(int));

            if (ObjClass.ObjCardDetail != null)
            {
                foreach (CardDetail ObjCardDetails in ObjClass.ObjCardDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CardIdentifier"] = ObjCardDetails.CardIdentifier;
                    dr["VechileNo"] = ObjCardDetails.VechileNo;
                    dr["VehicleMake"] = ObjCardDetails.VehicleMake;
                    dr["VehicleType"] = ObjCardDetails.VehicleType;
                    dr["YearOfRegistration"] = ObjCardDetails.YearOfRegistration;
                    dr["MobileNo"] = ObjCardDetails.MobileNo;
                    dr["CardId"] = ObjCardDetails.CardId;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            //var procedureName = "UspUserApproveCard";
            var procedureName = "UspUserApproveRejectCard";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("Comments", ObjClass.Comments, DbType.String, ParameterDirection.Input);
            parameters.Add("Approvalstatus", ObjClass.Approvalstatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("CardDetails", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ApproveRejectCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ApproveRejectAddOnCardModelOutput>> ApproveRejectAddOnCard([FromBody] ApproveRejectAddOnCardModelInput ObjClass)
        {

            var dtDBR = new DataTable("UserDTNoofCardsforApproveRejectCard");
            dtDBR.Columns.Add("CardIdentifier", typeof(string));
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("VehicleMake", typeof(string));
            dtDBR.Columns.Add("VehicleType", typeof(string));
            dtDBR.Columns.Add("YearOfRegistration", typeof(int));
            dtDBR.Columns.Add("MobileNo", typeof(string));
            dtDBR.Columns.Add("CardId", typeof(int));

            if (ObjClass.ObjCardDetail != null)
            {
                foreach (CardDetail ObjCardDetails in ObjClass.ObjCardDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CardIdentifier"] = ObjCardDetails.CardIdentifier;
                    dr["VechileNo"] = ObjCardDetails.VechileNo;
                    dr["VehicleMake"] = ObjCardDetails.VehicleMake;
                    dr["VehicleType"] = ObjCardDetails.VehicleType;
                    dr["YearOfRegistration"] = ObjCardDetails.YearOfRegistration;
                    dr["MobileNo"] = ObjCardDetails.MobileNo;
                    dr["CardId"] = ObjCardDetails.CardId;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspUserApproveRejectAddOnCard";
            //var procedureName = "UspUserApproveAddOnCard";
            var parameters = new DynamicParameters();
            //parameters.Add("CustomerReferenceNo", ObjClass.CustomerReferenceNo, DbType.Int64, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("Comments", ObjClass.Comments, DbType.String, ParameterDirection.Input);
            parameters.Add("Approvalstatus", ObjClass.Approvalstatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("CardDetails", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ApproveRejectAddOnCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<UpdateMobileandFastagNoInCardModelOutput>> UpdateMobileandFastagNoInCard([FromBody] UpdateMobileandFastagNoInCardModelInput ObjClass)
        {
            string APIRefNo = StaticClass.APIReferenceNo;
            var dtDBR = new DataTable("TypeUpdateMobileInCard");
            dtDBR.Columns.Add("Cardno", typeof(string));
            dtDBR.Columns.Add("Mobileno", typeof(string));
            dtDBR.Columns.Add("FastagNo", typeof(string));

            var procedureName = "UspUpdateMobileandFastagNoInCard";
            var parameters = new DynamicParameters();

            if (ObjClass.ObjUpdateMobileandFastagNoInCard != null)
            {
                foreach (UpdateMobileandFastagNoInCard ObjCardDetails in ObjClass.ObjUpdateMobileandFastagNoInCard)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["Cardno"] = ObjCardDetails.Cardno;
                    dr["Mobileno"] = ObjCardDetails.Mobileno;
                    dr["FastagNo"] = ObjCardDetails.FastagNo;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            parameters.Add("UpdateMobileInCard", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", APIRefNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateMobileandFastagNoInCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<BindPendingCustomerforCardModelOutput>> BindPendingCustomerForCardApproval([FromBody] BindPendingCustomerforCardModelInput ObjClass)
        {
            var procedureName = "UspBindPendingCustomerForCardApproval";
            var parameters = new DynamicParameters();
            parameters.Add("StateId", ObjClass.StateId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("Createdby", ObjClass.Createdby, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BindPendingCustomerforCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<BindPendingCustomerforCardModelOutput>> BindPendingCustomerForAddOnCardApproval([FromBody] BindPendingCustomerforCardModelInput ObjClass)
        {
            var procedureName = "UspBindPendingCustomerForAddOnCardApproval";
            var parameters = new DynamicParameters();
            parameters.Add("StateId", ObjClass.StateId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("Createdby", ObjClass.Createdby, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BindPendingCustomerforCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<BindRejectedCustomerforAddOnCardModelOutput>> BindRejectedCustomerForAddOnCardApproval([FromBody] BindPendingCustomerforCardModelInput ObjClass)
        {
            var procedureName = "UspBindRejectedCustomerForAddOnCardApproval";
            var parameters = new DynamicParameters();
            parameters.Add("StateId", ObjClass.StateId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("Createdby", ObjClass.Createdby, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BindRejectedCustomerforAddOnCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }




        public async Task<IEnumerable<BindPendingCustomerForAddOnCardApprovalModelOutput>> BindPendingCustomerForAddOnCardApproval([FromBody] BindPendingCustomerForAddOnCardApprovalModelInput ObjClass)
        {
            var procedureName = "UspBindPendingCustomerForAddonCardApproval";
            var parameters = new DynamicParameters();
            parameters.Add("StateId", ObjClass.StateId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("Createdby", ObjClass.Createdby, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BindPendingCustomerForAddOnCardApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCardDetailForCardApprovalModelOutput>> GetCardDetailForCardApproval([FromBody] GetCardDetailForCardApprovalModelInput ObjClass)
        {
            var procedureName = "UspGetCardDetailForCardApproval";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCardDetailForCardApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCardDetailForCardApprovalModelOutput>> GetCardDetailForAddOnCardApproval([FromBody] GetCardDetailForCardApprovalModelInput ObjClass)
        {
            var procedureName = "UspGetCardDetailForAddOnCardApproval";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCardDetailForCardApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CardSearchMappingDetailModelOutput>> SearchCardMappingDetail([FromBody] CardSearchMappingDetailModelInput ObjClass)
        {
            var procedureName = "UspGetMappingDetails";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("Vehiclenumber", ObjClass.Vehiclenumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Type", ObjClass.Type, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CardSearchMappingDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CardSearchMappingDetailsWithBlankMobileModelOutput>> SearchCardMappingDetailsWithBlankMobile([FromBody] CardSearchMappingDetailsWithBlankMobileModelInput ObjClass)
        {
            var procedureName = "UspGetMappingDetailsWithBlankMobile";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("Vehiclenumber", ObjClass.Vehiclenumber, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CardSearchMappingDetailsWithBlankMobileModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetCCMSLimitsForAllCardsModelOutput>> OTCCardRequestEntry([FromBody] GetCCMSLimitsForAllCardsModelInput ObjClass)
        {
            var procedureName = "UspGetCCMSLimitsForAllCards";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("Statusflag", ObjClass.Statusflag, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCCMSLimitsForAllCardsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetCardtoCCMSBalanceTransferModelOutput>> GetCardtoCCMSBalanceTransfer([FromBody] GetCardtoCCMSBalanceTransferModelInput ObjClass)
        {
            var procedureName = "UspGetCardtoCCMSBalanceTransfer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCardtoCCMSBalanceTransferModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<GetCcmsToCardBalanceTransferModelOutput> GetCCMSToCardBalanceTransfer([FromBody] GetCcmsToCardBalanceTransferModelInput ObjClass)
        {
            var procedureName = "UspGetCcmsToCardBalanceTransferDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetCcmsToCardBalanceTransferModelOutput();
            storedProcedureResult.ObjAvailableCcmsBalance = (List<AvailableCcmsBalanceModelOutput>)await result.ReadAsync<AvailableCcmsBalanceModelOutput>();
            storedProcedureResult.ObjCcmsToCardBalanceTransferDetail = (List<GetCcmsToCardBalanceTransferDetailModelOutput>)await result.ReadAsync<GetCcmsToCardBalanceTransferDetailModelOutput>();
            return storedProcedureResult;
        }

        public async Task<IEnumerable<GetCardtoCardBalanceTransferModelOutput>> GetCardtoCardBalanceTransfer([FromBody] GetCardtoCardBalanceTransferModelInput ObjClass)
        {
            var procedureName = "UspGetCardtoCardBalanceTransfer";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCardtoCardBalanceTransferModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CardCheckVechileNoModelOutput>> CheckVechileNo([FromBody] CardCheckVechileNoModelInput ObjClass)
        {
            var procedureName = "UspCheckVechileNo";
            var parameters = new DynamicParameters();
            parameters.Add("VehicleRegistrationNumber", ObjClass.VechileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("MethodName", "CheckVechileNo", DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CardCheckVechileNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CheckFastagNoDuplicacyInCardModelOutput>> CheckFastagNoDuplicacyInCard([FromBody] CheckFastagNoDuplicacyInCardModelInput ObjClass)
        {
            var procedureName = "UspCheckFastagNoDuplicacyInCard";
            var parameters = new DynamicParameters();
            parameters.Add("FastagNo", ObjClass.FastagNo, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckFastagNoDuplicacyInCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<AddOnCardModelOutput>> AddOnCard([FromBody] AddOnCardModelInput ObjClass)
        {
            var dtDBR = new DataTable("UserDTNoofCards");
            dtDBR.Columns.Add("CardIdentifier", typeof(string));
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("VehicleMake", typeof(string));
            dtDBR.Columns.Add("VehicleType", typeof(string));
            dtDBR.Columns.Add("YearOfRegistration", typeof(int));
            dtDBR.Columns.Add("MobileNo", typeof(string));

            var procedureName = "UspAddOnCard";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("NoOfCards", ObjClass.NoOfCards, DbType.Int32, ParameterDirection.Input);
            parameters.Add("RBEId", ObjClass.RBEId, DbType.String, ParameterDirection.Input);
            parameters.Add("FeePaymentsCollectFeeWaiver", ObjClass.FeePaymentsCollectFeeWaiver, DbType.Int16, ParameterDirection.Input);
            parameters.Add("FeePaymentNo", ObjClass.FeePaymentNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FeePaymentDate", ObjClass.FeePaymentDate, DbType.DateTime, ParameterDirection.Input);

            if (ObjClass.NoOfCards > 0 && ObjClass.ObjCardDetail != null)
            {
                foreach (AddonCardDetails ObjCardDetails in ObjClass.ObjCardDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CardIdentifier"] = ObjCardDetails.CardIdentifier;
                    dr["VechileNo"] = ObjCardDetails.VechileNo;
                    dr["VehicleMake"] = ObjCardDetails.VehicleMake;
                    dr["VehicleType"] = ObjCardDetails.VehicleType;
                    dr["YearOfRegistration"] = ObjCardDetails.YearOfRegistration;
                    //dr["YearOfRegistration"] = ObjCardDetails.YearOfRegistration;
                    dr["MobileNo"] = ObjCardDetails.MobileNo;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }
            parameters.Add("CardDetails", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CardPreference", ObjClass.CardPreference, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("NoofVechileforAllCards", ObjClass.NoofVechileforAllCards, DbType.Int32, ParameterDirection.Input);
            parameters.Add("VehicleNoVerifiedManually", ObjClass.VehicleNoVerifiedManually, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AddOnCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CheckAddOnFormNumberModelOutput>> CheckAddOnFormNumber([FromBody] CheckAddOnFormNumberModelInput ObjClass)
        {
            var procedureName = "UspCheckAddOnFormNumber";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckAddOnFormNumberModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }




        public async Task<IEnumerable<CardCheckMobileNoModelOutput>> CheckMobileNo([FromBody] CardCheckMobileNoModelInput ObjClass)
        {
            var procedureName = "UspCheckMobileNo";
            var parameters = new DynamicParameters();
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CardCheckMobileNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CheckCardIdentifierNoModelOutput>> CheckCardIdentifierNo([FromBody] CheckCardIdentifierNoModelInput ObjClass)
        {
            var procedureName = "UspCheckCardIdentifierNo";
            var parameters = new DynamicParameters();
            parameters.Add("CardIdentifier", ObjClass.CardIdentifier, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckCardIdentifierNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TransferAmountCCMSToCardModelOutput>> TransferAmountCCMSToCard([FromBody] TransferAmountCCMSToCardModelInput ObjClass)
        {
            var dtDBR = new DataTable("CCMSToCardTransfer");
            dtDBR.Columns.Add("CardNo", typeof(string));
            dtDBR.Columns.Add("TransferAmount", typeof(string));
            dtDBR.Columns.Add("MobileNo", typeof(string));

            foreach (var item in ObjClass.CCMSToCardTransfer)
            {
                DataRow dr = dtDBR.NewRow();
                dr["CardNo"] = item.CardNo;
                dr["TransferAmount"] = item.TransferAmount;
                dr["MobileNo"] = item.MobileNo;

                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();

            }

            var procedureName = "UspTransferAmountCCMSToCard";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("CCMSToCardTransfer", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("ReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<TransferAmountCCMSToCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TransferAmountCardToCCMSModeloutput>> TransferAmountCardToCCMS([FromBody] TransferAmountCardToCCMSModelInput ObjClass)
        {
            var dtDBR = new DataTable("CardToCCMSTransfer");
            dtDBR.Columns.Add("CardNo", typeof(string));
            dtDBR.Columns.Add("TransferAmount", typeof(string));
            dtDBR.Columns.Add("MobileNo", typeof(string));

            foreach (var item in ObjClass.CardToCCMSTransfer)
            {
                DataRow dr = dtDBR.NewRow();
                dr["CardNo"] = item.CardNo;
                dr["TransferAmount"] = item.TransferAmount;
                dr["MobileNo"] = item.MobileNo;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();

            }

            var procedureName = "UspTransferAmountCardToCCMS";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("CardToCCMSTransfer", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("ReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<TransferAmountCardToCCMSModeloutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TransferAmountCardToCardModelOutput>> TransferAmountCardToCard([FromBody] TransferAmountCardToCardModelInput ObjClass)
        {
            var dtDBR = new DataTable("CardToCardTransfer");
            dtDBR.Columns.Add("FromCardNo", typeof(string));
            dtDBR.Columns.Add("ToCardNo", typeof(string));
            dtDBR.Columns.Add("TransferAmount", typeof(string));
            dtDBR.Columns.Add("FromMobileNo", typeof(string));
            dtDBR.Columns.Add("ToMobileNo", typeof(string));

            foreach (var item in ObjClass.CardToCardTransfer)
            {
                DataRow dr = dtDBR.NewRow();
                dr["FromCardNo"] = item.FromCardNo;
                dr["ToCardNo"] = item.ToCardNo;
                dr["TransferAmount"] = item.TransferAmount;
                dr["FromMobileNo"] = item.FromMobileNo;
                dr["ToMobileNo"] = item.ToMobileNo;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();

            }

            var procedureName = "UspTransferAmountCardToCard";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("CardToCardTransfer", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("ReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<TransferAmountCardToCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetCardsForLimitUpdateForSingleRechargeModelOutput>> GetCardsForLimitUpdateForSingleRecharge([FromBody] GetCardsForLimitUpdateForSingleRechargeModelInput ObjClass)
        {
            var procedureName = "UspGetCardsForLimitUpdateForSingleRecharge";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCardsForLimitUpdateForSingleRechargeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<LimitUpdateForSingleRechargeCardModelOutput>> LimitUpdateForSingleRecharge([FromBody] LimitUpdateForSingleRechargeCardModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeLimitUpdateForSingleRechargeCard");
            dtDBR.Columns.Add("Cardno", typeof(string));
            dtDBR.Columns.Add("Limittype", typeof(int));
            dtDBR.Columns.Add("Amount", typeof(decimal));


            var procedureName = "UspLimitUpdateForSingleRechargeCard";
            var parameters = new DynamicParameters();

            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);

            foreach (SinglerecgargeCCMSLimitsModelInput ObjCardLimits in ObjClass.ObjCCMSLimits)
            {
                DataRow dr = dtDBR.NewRow();
                dr["Cardno"] = ObjCardLimits.Cardno;
                dr["Limittype"] = ObjCardLimits.Limittype;
                dr["Amount"] = ObjCardLimits.Amount;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }

            parameters.Add("TypeLimitUpdateForSingleRechargeCard", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<LimitUpdateForSingleRechargeCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetDetailForCorpMultiRechargeLimitConfigModelOutput>> GetDetailForCorpMultiRechargeLimitConfig([FromBody] GetDetailForCorpMultiRechargeLimitConfigModelInput ObjClass)
        {
            var procedureName = "UspGetDetailForCorpMultiRechargeLimitConfig";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDetailForCorpMultiRechargeLimitConfigModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CorpMultiRechargeLimitConfigModelOutput>> CorpMultiRechargeLimitConfig([FromBody] CorpMultiRechargeLimitConfigModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeCorpMultiRechargeLimitConfig");
            dtDBR.Columns.Add("CustomerId", typeof(string));
            dtDBR.Columns.Add("Limittype", typeof(int));
            dtDBR.Columns.Add("StatusFlag", typeof(decimal));


            var procedureName = "UspCorpMultiRechargeLimitConfig";
            var parameters = new DynamicParameters();

            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);

            foreach (MultiRechargeLimitConfigModelInpu ObjCardLimits in ObjClass.ObjLimitConfig)
            {
                DataRow dr = dtDBR.NewRow();
                dr["CustomerID"] = ObjCardLimits.CustomerID;
                dr["Limittype"] = ObjCardLimits.Limittype;
                dr["StatusFlag"] = ObjCardLimits.StatusFlag;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }

            parameters.Add("TypeCorpMultiRechargeLimitConfig", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CorpMultiRechargeLimitConfigModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<EmergencyReplacementCardModelOutput>> GetDetailForEmergencyReplacementCards([FromBody] EmergencyReplacementCardModelInput ObjClass)
        {
            var procedureName = "UspGetDetailForEmergencyReplacementCards";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<EmergencyReplacementCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<EmergencyReplacementCardsModelOutput>> EmergencyReplacementCards([FromBody] UpdateEmergencyReplacementCardsModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeEmergencyReplacementCard");
            dtDBR.Columns.Add("CustomerId", typeof(string));
            dtDBR.Columns.Add("OldCardNo", typeof(string));
            dtDBR.Columns.Add("NewCardNo", typeof(string));

            var procedureName = "UspEmergencyReplacementCards";
            var parameters = new DynamicParameters();


            foreach (EmergencyReplacementCardsModelInput objdtl in ObjClass.objEmergencyReplacementCards)
            {
                DataRow dr = dtDBR.NewRow();
                dr["CustomerId"] = objdtl.CustomerId;
                dr["OldCardNo"] = objdtl.OldCardNo;
                dr["NewCardNo"] = objdtl.NewCardNo;


                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }

            parameters.Add("TypeEmergencyReplacementCard", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ReferenceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<EmergencyReplacementCardsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CardGetCardRenewalRequestDetailModelOutput>> GetCardRenewalRequestDetail([FromBody] CardGetCardRenewalRequestDetailModelInput ObjClass)
        {
            var procedureName = "UspGetCardRenewalRequestDetail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CardGetCardRenewalRequestDetailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CardUpdateCardRenewalRequestModelOutput>> UpdateCardRenewalRequest([FromBody] CardUpdateCardRenewalRequestModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeCardRenewalRequest");
            dtDBR.Columns.Add("CardNo", typeof(string));
            dtDBR.Columns.Add("VechileNo", typeof(string));


            var procedureName = "UspUpdateCardRenewalRequest";
            var parameters = new DynamicParameters();

            foreach (TypeCardRenewalRequest objdtl in ObjClass.TypeCardRenewalRequest)
            {
                DataRow dr = dtDBR.NewRow();
                dr["CardNo"] = objdtl.CardNo;
                dr["VechileNo"] = objdtl.VechileNo;



                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }
            parameters.Add("TypeCardRenewalRequest", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CardUpdateCardRenewalRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CardApproveCardRenewalRequestsModelOutput>> ApproveCardRenewalRequests([FromBody] CardApproveCardRenewalRequestsModelInput ObjClass)
        {
            var procedureName = "UspApproveCardRenewalRequests";
            var parameters = new DynamicParameters();
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CardApproveCardRenewalRequestsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<GetDetailForEnableDisableProductsAndTransactionsModelOutput> GetDetailForEnableDisableProductsAndTransactions([FromBody] GetDetailForEnableDisableProductsAndTransactionsModelInput ObjClass)
        {
            var procedureName = "UspGetDetailForEnableDisableProductsAndTransactions";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new GetDetailForEnableDisableProductsAndTransactionsModelOutput();
            storedProcedureResult.GetProductsTransactionsStatus = (List<GetProductsTransactionsStatusModelOutput>)await result.ReadAsync<GetProductsTransactionsStatusModelOutput>();
            storedProcedureResult.GetProductsType = (List<GetProductsTypeModelOutput>)await result.ReadAsync<GetProductsTypeModelOutput>();
            storedProcedureResult.GetTransactionsType = (List<GetTransactionsTypeModelOutput>)await result.ReadAsync<GetTransactionsTypeModelOutput>();
            return storedProcedureResult;
        }


        public async Task<IEnumerable<EnableDisableProductsAndTransactionsModelOutput>> EnableDisableProductsAndTransactions([FromBody] EnableDisableProductsAndTransactionsModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeEnablDisableProducts");
            dtDBR.Columns.Add("ProductID", typeof(int));
            dtDBR.Columns.Add("StatusFlag", typeof(int));

            var dtDBR2 = new DataTable("TypeEnablDisableTransactions");
            dtDBR2.Columns.Add("TransactionID", typeof(int));
            dtDBR2.Columns.Add("StatusFlag", typeof(int));

            var procedureName = "UspEnableDisableProductsAndTransactions";
            var parameters = new DynamicParameters();

            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);

            foreach (ProductStatusModelInput ObjProductStatus in ObjClass.ObjProducts)
            {
                DataRow dr = dtDBR.NewRow();
                dr["ProductID"] = ObjProductStatus.ProductID;
                dr["StatusFlag"] = ObjProductStatus.StatusFlag;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }
            foreach (TransactionModelInput ObjTransactionStatus in ObjClass.ObjTransactions)
            {
                DataRow dr = dtDBR2.NewRow();
                dr["TransactionID"] = ObjTransactionStatus.TransactionID;
                dr["StatusFlag"] = ObjTransactionStatus.StatusFlag;
                dtDBR2.Rows.Add(dr);
                dtDBR2.AcceptChanges();
            }

            parameters.Add("TypeEnablDisableProducts", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("TypeEnablDisableTransactions", dtDBR2, DbType.Object, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<EnableDisableProductsAndTransactionsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CardUpdateApproveCardRenewalRequestsModelOutput>> UpdateApproveCardRenewalRequests([FromBody] CardUpdateApproveCardRenewalRequestsModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeApproveCardRenewalRequests");
            dtDBR.Columns.Add("CardNo", typeof(string));
            dtDBR.Columns.Add("RenewalRemark", typeof(string));


            var procedureName = "UspUpdateApproveCardRenewalRequests";
            var parameters = new DynamicParameters();

            foreach (TypeApproveCardRenewalRequests objdtl in ObjClass.TypeApproveCardRenewalRequests)
            {
                DataRow dr = dtDBR.NewRow();
                dr["CardNo"] = objdtl.CardNo;
                dr["RenewalRemark"] = objdtl.RenewalRemark;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeApproveCardRenewalRequests", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("RefernceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CardUpdateApproveCardRenewalRequestsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<UpdateHotlistReissueCardRequestModelOutput>> UpdateHotlistReissueCardRequest([FromBody] UpdateHotlistReissueCardRequestModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeHotlistReissueCardRequest");
            dtDBR.Columns.Add("CardNo", typeof(string));
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("ReasonId", typeof(int));

            var procedureName = "UspUpdateHotlistReissueCardRequest";
            var parameters = new DynamicParameters();

            foreach (TypeHotlistReissueCardRequest objdtl in ObjClass.TypeHotlistReissueCardRequest)
            {
                DataRow dr = dtDBR.NewRow();
                dr["CardNo"] = objdtl.CardNo;
                dr["VechileNo"] = objdtl.VechileNo;
                dr["ReasonId"] = objdtl.ReasonId;


                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }


            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeHotlistReissueCardRequest", dtDBR, DbType.Object, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateHotlistReissueCardRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetGenericAttachedVehicleModelOutput>> GetGenericAttachedVehicle([FromBody] GetGenericAttachedVehicleModelInput ObjClass)
        {
            var procedureName = "UspGetGenericAttachedVehicle";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("Vehiclenumber", ObjClass.Vehiclenumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Statusflag", ObjClass.Statusflag, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetGenericAttachedVehicleModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetApproveCardReissuanceRequestModelOutput>> GetApproveCardReissuanceRequest([FromBody] GetApproveCardReissuanceRequestModelInput ObjClass)
        {
            var procedureName = "UspGetApproveCardReissuanceRequest";
            var parameters = new DynamicParameters();
            parameters.Add("CardNumber", ObjClass.CardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("Status", ObjClass.Status, DbType.Int32, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetApproveCardReissuanceRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetLimitTypeModelOutput>> GetLimitType([FromBody] GetLimitTypeModelInput ObjClass)
        {
            var procedureName = "UspGetLimitType";

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetLimitTypeModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CardwiseLimitAuditTrailModelOutput>> CardwiseLimitAuditTrail([FromBody] CardwiseLimitAuditTrailModelInput ObjClass)
        {
            var procedureName = "UspCardWiseLimitAuditTrail";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("CardNumber", ObjClass.CardNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("LimitType", ObjClass.LimitType, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CardwiseLimitAuditTrailModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<UpdateApproveCardReissuanceRequestModelOutput>> UpdateApproveCardReissuanceRequest([FromBody] UpdateApproveCardReissuanceRequestModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeApproveRejectCardReissuanceRequest");
            dtDBR.Columns.Add("Cardno", typeof(string));
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("Remarks", typeof(string));
            // dtDBR.Columns.Add("HotlistReasonId", typeof(int));

            var procedureName = "UspUpdateApproveCardReissuanceRequest";
            var parameters = new DynamicParameters();

            if (ObjClass.TypeApproveRejectCardReissuanceRequest != null)
            {
                foreach (TypeApproveRejectCardReissuanceRequest ObjCardDetails in ObjClass.TypeApproveRejectCardReissuanceRequest)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["Cardno"] = ObjCardDetails.CardNo;
                    dr["VechileNo"] = ObjCardDetails.VechileNo;
                    dr["Remarks"] = ObjCardDetails.Remarks;
                    // dr["HotlistReasonId"] = ObjCardDetails.Remarks;

                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }



            parameters.Add("ActionType", ObjClass.ActionType, DbType.String, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("RefernceId", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("TypeApproveRejectCardReissuanceRequest", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateApproveCardReissuanceRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetAddOnCardRequestDetailsModelOutput>> GetAddOnCardRequestDetails([FromBody] GetAddOnCardRequestDetailsModelInput ObjClass)
        {
            var procedureName = "UspGetAddOnCardRequestDetails";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetAddOnCardRequestDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<IEnumerable<CheckCustomerDriverStarsCCMSBalanceModelOutput>> CheckCustomerDriverStarsCCMSBalance([FromBody] CheckCustomerDriverStarsCCMSBalanceModelInput ObjClass)
        {
            var procedureName = "UspCheckCustomerDriverStarsCCMSBalance";
            var parameters = new DynamicParameters();
            parameters.Add("PaymentMethod", ObjClass.PaymentMethod, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.Int32, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckCustomerDriverStarsCCMSBalanceModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<AddOnCardRequestWithPaymentModelOutput>> AddOnCardRequestWithPayment([FromBody] AddOnCardRequestWithPaymentModelInput ObjClass)
        {
            var dtDBR = new DataTable("UserDTNoofCards");
            dtDBR.Columns.Add("CardIdentifier", typeof(string));
            dtDBR.Columns.Add("VechileNo", typeof(string));
            dtDBR.Columns.Add("VehicleMake", typeof(string));
            dtDBR.Columns.Add("VehicleType", typeof(string));
            dtDBR.Columns.Add("YearOfRegistration", typeof(int));
            dtDBR.Columns.Add("MobileNo", typeof(string));

            var procedureName = "UspAddOnCardRequestWithPayment";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("NoOfCards", ObjClass.NoOfCards, DbType.Int32, ParameterDirection.Input);

            if (ObjClass.NoOfCards > 0 && ObjClass.ObjAddOnCardDetail != null)
            {
                foreach (CustomerAddonCardDetails ObjAddOnCardDetail in ObjClass.ObjAddOnCardDetail)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["CardIdentifier"] = ObjAddOnCardDetail.CardIdentifier;
                    dr["VechileNo"] = ObjAddOnCardDetail.VechileNo;
                    dr["VehicleMake"] = ObjAddOnCardDetail.VehicleMake;
                    dr["VehicleType"] = ObjAddOnCardDetail.VehicleType;
                    dr["YearOfRegistration"] = ObjAddOnCardDetail.YearOfRegistration;
                    dr["MobileNo"] = ObjAddOnCardDetail.MobileNo;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }
            parameters.Add("CardDetails", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("CardPreference", ObjClass.CardPreference, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("PaymentMethod", ObjClass.PaymentMethod, DbType.Int32, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("NoofVechileforAllCards", ObjClass.NoofVechileforAllCards, DbType.Int32, ParameterDirection.Input);
            parameters.Add("VehicleNoVerifiedManually", ObjClass.VehicleNoVerifiedManually, DbType.Int32, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<AddOnCardRequestWithPaymentModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ApproveRejectAddOnCardWithPaymentModelOutput>> ApproveRejectAddOnCardWithPayment([FromBody] ApproveRejectAddOnCardWithPaymentModelInput ObjClass)
        {
            var procedureName = "UspApproveRejectAddOnCardWithPayment";
            var parameters = new DynamicParameters();
            //parameters.Add("CustomerReferenceNo", ObjClass.CustomerReferenceNo, DbType.Int64, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            parameters.Add("Comments", ObjClass.Comments, DbType.String, ParameterDirection.Input);
            parameters.Add("Approvalstatus", ObjClass.Approvalstatus, DbType.Int32, ParameterDirection.Input);
            parameters.Add("ApprovedBy", ObjClass.ApprovedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ApproveRejectAddOnCardWithPaymentModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<BindPendingCustomerForAddOnCardWithPaymentApprovalModelOutput>> BindPendingCustomerForAddOnCardWithPaymentApproval([FromBody] BindPendingCustomerForAddOnCardWithPaymentApprovalModelInput ObjClass)
        {
            var procedureName = "UspBindPendingCustomerForAddOnCardWithPaymentApproval";
            var parameters = new DynamicParameters();
            //parameters.Add("StateId", ObjClass.StateId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            // parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("Status", ObjClass.Status, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BindPendingCustomerForAddOnCardWithPaymentApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCardDetailForAddOnCardWithPaymentApprovalModelOutput>> GetCardDetailForAddOnCardWithPaymentApproval([FromBody] GetCardDetailForAddOnCardWithPaymentApprovalModelInput ObjClass)
        {
            var procedureName = "UspGetCardDetailForAddOnCardWithPaymentApproval";
            var parameters = new DynamicParameters();
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.Int64, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCardDetailForAddOnCardWithPaymentApprovalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }




        public async Task<IEnumerable<CardPinUnblockMobileRequestModelOutput>> CardPinUnblockMobileRequest([FromBody] CardPinUnblockMobileRequestModelInput ObjClass)
        {
            var procedureName = "UspCardPinUnblockMobileRequest";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", ObjClass.UserName, DbType.String, ParameterDirection.Input);
            parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CardPinUnblockMobileRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetCardLimitsByVehicleNoModelOutput>> GetCardLimitsByVehicleNo([FromBody] GetCardLimitsByVehicleNoModelInput ObjClass)
        {
            var procedureName = "UspGetCardLimitsByVehicleNo";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleNo", ObjClass.VehicleNo, DbType.String, ParameterDirection.Input);
            // parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("Statusflag", ObjClass.Statusflag, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCardLimitsByVehicleNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<UpdateCardLimitsLimitTypeWiseModelOutput>> UpdateCardLimitsLimitTypeWise([FromBody] UpdateCardLimitsLimitTypeWiseModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeUpdateCardLimitsLimitTypeWise");
            dtDBR.Columns.Add("Cardno", typeof(string));
            dtDBR.Columns.Add("LimitType", typeof(int));
            dtDBR.Columns.Add("Amount", typeof(decimal));
            //dtDBR.Columns.Add("DailySaleLimit", typeof(decimal));
            //dtDBR.Columns.Add("MonthlySaleLimit", typeof(decimal));

            var procedureName = "UspUpdateCardLimitsLimitTypeWise";
            var parameters = new DynamicParameters();



            foreach (CardLimitModelInput ObjCardLimits in ObjClass.ObjCardLimits)
            {
                DataRow dr = dtDBR.NewRow();
                dr["Cardno"] = ObjCardLimits.Cardno;
                dr["LimitType"] = ObjCardLimits.LimitType;
                dr["Amount"] = ObjCardLimits.Amount;
                //dr["DailySaleLimit"] = ObjCardLimits.DailySaleLimit;
                //dr["MonthlySaleLimit"] = ObjCardLimits.MonthlySaleLimit;

                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }

            parameters.Add("TypeUpdateCardLimitsLimitTypeWise", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCardLimitsLimitTypeWiseModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetCCMSLimitsByVehicleNoModelOutput>> GetCCMSLimitsByVehicleNo([FromBody] GetCCMSLimitsByVehicleNoModelInput ObjClass)
        {
            var procedureName = "UspGetCCMSLimitsByVehicleNo";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("VehicleNo", ObjClass.VehicleNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            //   parameters.Add("Statusflag", ObjClass.Statusflag, DbType.Int32, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCCMSLimitsByVehicleNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<UpdateCCMSLimitsCardWiseModelOutput>> UpdateCCMSLimitsCardWise([FromBody] UpdateCCMSLimitsCardWiseModelInput ObjClass)
        {

            var dtDBR = new DataTable("TypeUpdateCCMSLimitsCardWise");
            dtDBR.Columns.Add("Cardno", typeof(string));
            dtDBR.Columns.Add("Limittype", typeof(int));
            dtDBR.Columns.Add("Amount", typeof(decimal));
            //dtDBR.Columns.Add("MobileNo", typeof(string));


            var procedureName = "UspUpdateCCMSLimitsCardWise";
            var parameters = new DynamicParameters();

            parameters.Add("ModifiedBy", ObjClass.ModifiedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);

            foreach (CCMSLimitsCardWiseModelInput ObjCardLimits in ObjClass.ObjCCMSLimitsCardWise)
            {
                DataRow dr = dtDBR.NewRow();
                dr["Cardno"] = ObjCardLimits.Cardno;
                dr["Limittype"] = ObjCardLimits.Limittype;
                dr["Amount"] = ObjCardLimits.Amount;
                //dr["MobileNo"] = ObjCardLimits.MobileNo;
                dtDBR.Rows.Add(dr);
                dtDBR.AcceptChanges();
            }

            parameters.Add("TypeUpdateCCMSLimitsCardWise", dtDBR, DbType.Object, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateCCMSLimitsCardWiseModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<GetCardBalanceModelOutput>> GetCardBalance([FromBody] GetCardBalanceModelInput ObjClass)
        {
            var procedureName = "UspGetCardBalance";
            var parameters = new DynamicParameters();

            parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
            parameters.Add("Customerid", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCardBalanceModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetCardIssueTypeModelOutput>> GetCardIssueType([FromBody] GetCardIssueTypeModelInput ObjClass)
        {
            var procedureName = "UspGetCardIssueType";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCardIssueTypeModelOutput>(procedureName, null, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ShowOTPModelOutput>> ShowOTP([FromBody] ShowOTPModelInput ObjClass)
        {
            var procedureName = "UspShowOTP";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ShowOTPModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetVehicleNoModelOutput>> GetVehicleNo([FromBody] GetVehicleNoModelInput ObjClass)
        {
            var procedureName = "UspGetVehicleNo";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetVehicleNoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CheckCCMSBalanceDriverstarsforAddOnCardRequestModelOutput>> CheckCCMSBalanceDriverstarsforAddOnCardRequest([FromBody] CheckCCMSBalanceDriverstarsforAddOnCardRequestModelInput ObjClass)
        {

            var procedureName = "UspCheckCCMSBalanceDriverstarsforAddOnCardRequest";
            var parameters = new DynamicParameters();
            parameters.Add("Customerid", ObjClass.Customerid, DbType.String, ParameterDirection.Input);
            parameters.Add("NoOfCards", ObjClass.NoOfCards, DbType.Int32, ParameterDirection.Input);
            parameters.Add("PaymentMethod", ObjClass.PaymentMethod, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CardPreference", ObjClass.CardPreference, DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckCCMSBalanceDriverstarsforAddOnCardRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }
        public async Task<IEnumerable<GetVehicleDetailsModelOutput>> GetVehicleDetails([FromBody] GetVehicleDetailsModelInput ObjClass)
        {

            var procedureName = "UspGetVehicleDetails";
            var parameters = new DynamicParameters();
            parameters.Add("VehicleNo", ObjClass.VehicleNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetVehicleDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        }
        public async Task<IEnumerable<CheckVechileNoThroughVahanModelOutput>> CheckVechileNoThroughVahan([FromBody] CheckVechileNoThroughVahanModelInput ObjClass)
        {
            var procedureName = "UspCheckVechileNoThroughVahan";
            var parameters = new DynamicParameters();
            parameters.Add("VehicleRegistrationNumber", ObjClass.VechileNo, DbType.String, ParameterDirection.Input);
            // parameters.Add("MethodName", "CheckVechileNo", DbType.String, ParameterDirection.Input);

            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckVechileNoThroughVahanModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetVehicleDetailsModelOutput>> InsertVehicleDetails([FromBody] InsertVehicleDetailsModelInput ObjClass)
        {
            var procedureName = "UspInsertVehicleDetails";
            var parameters = new DynamicParameters();
            parameters.Add("seatingCapacity", ObjClass.seatingCapacity, DbType.String, ParameterDirection.Input);
            parameters.Add("taxPaidUpto", ObjClass.taxPaidUpto, DbType.String, ParameterDirection.Input);
            parameters.Add("vehicleClassDescription", ObjClass.vehicleClassDescription, DbType.String, ParameterDirection.Input);
            parameters.Add("grossVehicleWeight", ObjClass.grossVehicleWeight, DbType.String, ParameterDirection.Input);
            parameters.Add("unladenWeight", ObjClass.unladenWeight, DbType.String, ParameterDirection.Input);
            parameters.Add("permanentAddress", ObjClass.permanentAddress, DbType.String, ParameterDirection.Input);
            parameters.Add("ownerSerialNumber", ObjClass.ownerSerialNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("statusAsOn", ObjClass.statusAsOn, DbType.String, ParameterDirection.Input);
            parameters.Add("wheelbase", ObjClass.wheelbase, DbType.String, ParameterDirection.Input);
            parameters.Add("registrationDate", ObjClass.registrationDate, DbType.String, ParameterDirection.Input);
            parameters.Add("fatherName", ObjClass.fatherName, DbType.String, ParameterDirection.Input);
            parameters.Add("financier", ObjClass.financier, DbType.String, ParameterDirection.Input);
            parameters.Add("registrationNumber", ObjClass.registrationNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("chassisNumber", ObjClass.chassisNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("numberOfCylinders", ObjClass.numberOfCylinders, DbType.String, ParameterDirection.Input);
            parameters.Add("bodyTypeDescription", ObjClass.bodyTypeDescription, DbType.String, ParameterDirection.Input);
            parameters.Add("makerDescription", ObjClass.makerDescription, DbType.String, ParameterDirection.Input);
            parameters.Add("sleeperCapacity", ObjClass.sleeperCapacity, DbType.String, ParameterDirection.Input);
            parameters.Add("fuelDescription", ObjClass.fuelDescription, DbType.String, ParameterDirection.Input);
            parameters.Add("makerModel", ObjClass.makerModel, DbType.String, ParameterDirection.Input);
            parameters.Add("cubicCapacity", ObjClass.cubicCapacity, DbType.String, ParameterDirection.Input);
            parameters.Add("color", ObjClass.color, DbType.String, ParameterDirection.Input);
            parameters.Add("ownerName", ObjClass.ownerName, DbType.String, ParameterDirection.Input);
            parameters.Add("normsDescription", ObjClass.normsDescription, DbType.String, ParameterDirection.Input);
            parameters.Add("standingCapacity", ObjClass.standingCapacity, DbType.String, ParameterDirection.Input);
            parameters.Add("insuranceUpto", ObjClass.insuranceUpto, DbType.String, ParameterDirection.Input);
            parameters.Add("engineNumber", ObjClass.engineNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("presentAddress", ObjClass.presentAddress, DbType.String, ParameterDirection.Input);
            parameters.Add("insurancePolicyNumber", ObjClass.insurancePolicyNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("registeredAt", ObjClass.registeredAt, DbType.String, ParameterDirection.Input);
            parameters.Add("fitnessUpto", ObjClass.fitnessUpto, DbType.String, ParameterDirection.Input);
            parameters.Add("manufacturedMonthYear", ObjClass.manufacturedMonthYear, DbType.String, ParameterDirection.Input);
            parameters.Add("insuranceCompany", ObjClass.insuranceCompany, DbType.String, ParameterDirection.Input);
            parameters.Add("pucNumber", ObjClass.pucNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("pucExpiryDate", ObjClass.pucExpiryDate, DbType.String, ParameterDirection.Input);
            parameters.Add("blackListStatus", ObjClass.blackListStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("nationalPermitIssuedBy", ObjClass.nationalPermitIssuedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("nationalPermitNumber", ObjClass.nationalPermitNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("nationalPermitExpiryDate", ObjClass.nationalPermitExpiryDate, DbType.String, ParameterDirection.Input);
            parameters.Add("statePermitNumber", ObjClass.statePermitNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("statePermitType", ObjClass.statePermitType, DbType.String, ParameterDirection.Input);
            parameters.Add("statePermitIssuedDate", ObjClass.statePermitIssuedDate, DbType.String, ParameterDirection.Input);
            parameters.Add("statePermitExpiryDate", ObjClass.statePermitExpiryDate, DbType.String, ParameterDirection.Input);
            parameters.Add("nonUseFrom", ObjClass.nonUseFrom, DbType.String, ParameterDirection.Input);
            parameters.Add("nocDetails", ObjClass.nocDetails, DbType.String, ParameterDirection.Input);
            parameters.Add("nonUseTo", ObjClass.nonUseTo, DbType.String, ParameterDirection.Input);
            parameters.Add("stateCd", ObjClass.stateCd, DbType.String, ParameterDirection.Input);
            parameters.Add("vehicleCatgory", ObjClass.vehicleCatgory, DbType.String, ParameterDirection.Input);
            parameters.Add("rcStatus", ObjClass.rcStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("stautsMessage", ObjClass.stautsMessage, DbType.String, ParameterDirection.Input);
            parameters.Add("rcMobileNo", ObjClass.rcMobileNo, DbType.String, ParameterDirection.Input);
            parameters.Add("rcNonUseStatus", ObjClass.rcNonUseStatus, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetVehicleDetailsModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetCustomerTCSBalanceInfoModelOutput>> CustomerTCSBalanceInfo([FromBody] GetCustomerTCSBalanceInfoModelInput ObjClass)
        {
            var procedureName = "UspCustomerTCSBalanceInfo";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", ObjClass.CustomerID, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetCustomerTCSBalanceInfoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<BindRejectedCustomerforCardModelOutput>> BindRejectedCustomerForCardApproval([FromBody] BindRejectedCustomerforCardModelInput ObjClass)
        {
            var procedureName = "UspBindRejectedCustomerForCardApproval";
            var parameters = new DynamicParameters();
            parameters.Add("StateId", ObjClass.StateId, DbType.String, ParameterDirection.Input);
            parameters.Add("FormNumber", ObjClass.FormNumber, DbType.String, ParameterDirection.Input);
            parameters.Add("CustomerName", ObjClass.CustomerName, DbType.String, ParameterDirection.Input);
            parameters.Add("FromDate", ObjClass.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("ToDate", ObjClass.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("Createdby", ObjClass.Createdby, DbType.String, ParameterDirection.Input);
            parameters.Add("RegionalOfficeId", ObjClass.RegionalOfficeId, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("UserAgent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<BindRejectedCustomerforCardModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateRawCardSendbackModelOutput>> UpdateRawCardSendback([FromBody] UpdateRawCardSendbackModelInput ObjClass)
        {

            var procedureName = "UspUpdateRawCardSendback";
            var parameters = new DynamicParameters();
            parameters.Add("CardFormNumber", ObjClass.CardFormNumber, DbType.String, ParameterDirection.Input);


            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateRawCardSendbackModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<CheckInvalidCustomerIDForLoginUserModelOutput>> CheckInvalidCustomerIDForLoginUser([FromBody] CheckInvalidCustomerIDForLoginUserModelInput ObjClass)
        {
            var procedureName = "UspCheckInvalidCustomerIDForLoginUser";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerId", ObjClass.CustomerId, DbType.String, ParameterDirection.Input);
            parameters.Add("Userid", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<CheckInvalidCustomerIDForLoginUserModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
