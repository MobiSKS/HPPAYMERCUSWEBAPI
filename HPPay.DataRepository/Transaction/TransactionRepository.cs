using AtallaHSM;
using AtallaHSM.Model;
using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.Transaction;
using HPPay.DataRepository.DBDapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.Transaction
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DapperContext _context;
        //private static string MFKAKB;
        //private static string DEKAKB;
        //private static string KEKAKB;
        //private static string PMKAKB;
        private static string HSMIP;
        private static string HSMPORT;
        private static string CardPlainorEncryptStatus;
        private readonly IConfiguration _configuration;
        public TransactionRepository(DapperContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            //MFKAKB = _configuration.GetSection("HSMAppSettings:MFKAKB").Value.ToString();
            //DEKAKB = _configuration.GetSection("HSMAppSettings:DEKAKB").Value.ToString();
            //KEKAKB = _configuration.GetSection("HSMAppSettings:KEKAKB").Value.ToString();
            //PMKAKB = _configuration.GetSection("HSMAppSettings:PMKAKB").Value.ToString();
            HSMIP = _configuration.GetSection("HSMAppSettings:HSMIP").Value.ToString();
            HSMPORT = _configuration.GetSection("HSMAppSettings:HSMPORT").Value.ToString();
            CardPlainorEncryptStatus = _configuration.GetSection("HSMAppSettings:CardPlainorEncryptStatus").Value.ToString();
        }

        public string PlainCardNoAsync(string CardNo, string TerminalId, out int StatusValue)
        {
            int Status = 0;
            string CardNoStr = string.Empty;
            try
            {
                var procedureName = "UspGetPEKAKB";
                var parameters = new DynamicParameters();
                parameters.Add("TerminalId", TerminalId, DbType.String, ParameterDirection.Input);
                using var connection = _context.CreateConnection();
                string OutDPKAKB = connection.Query<TransactionGetPEKAKBModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure).Cast<TransactionGetPEKAKBModelOutput>().ToList()[0].DPKAKB;
                string Track2Encrypted = CardNo;
                HSMResponseInfo hsmresponse = new HSMResponseInfo();
                // Connect HSM
                AtallaHSMProvider athp = new AtallaHSMProvider(HSMIP, HSMPORT);
                // Decrypt Track2/PAN data with session key AKB
                hsmresponse = athp.DecryptTrack2PAN(OutDPKAKB, Track2Encrypted);
                AT97ResponseInfo DecPAN = (AT97ResponseInfo)hsmresponse.ResponseData;
                CardNoStr = DecPAN.encKey;
                Status = 1;
            }
            catch (Exception ex)
            {
                CardNoStr = ex.Message;
                Status = 0;
            }
            StatusValue = Status;
            return CardNoStr;
        }

        public async Task<IEnumerable<TransactionSalebyTerminalModelOutput>> SaleByTerminal([FromBody] TransactionSalebyTerminalModelInput ObjClass)
        {
            int StatusValue;
            if ((ObjClass.Formfactor == 1 || ObjClass.Formfactor == 2) && ObjClass.Paycode == "")
            {
                if (CardPlainorEncryptStatus != "1")
                {
                    StatusValue = 1;
                }
                else
                {
                    string CardNo = PlainCardNoAsync(ObjClass.Cardno, ObjClass.Terminalid, out StatusValue);
                    if (StatusValue == 1)
                        ObjClass.Cardno = CardNo;
                }
            }
            else
            {
                StatusValue = 1;
            }

            if (StatusValue == 1)
            {
                string APIReferenceNo = StaticClass.APIReferenceNo;
                var procedureName = "UspSaleByTerminal";
                var parameters = new DynamicParameters();
                parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
                parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
                parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
                parameters.Add("Batchid", ObjClass.Batchid, DbType.Int64, ParameterDirection.Input);
                parameters.Add("Invoiceamount", ObjClass.Invoiceamount, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("Transtype", ObjClass.Transtype, DbType.String, ParameterDirection.Input);
                parameters.Add("Invoiceid", ObjClass.Invoiceid, DbType.String, ParameterDirection.Input);
                parameters.Add("Invoicedate", ObjClass.Invoicedate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
                parameters.Add("Productid", ObjClass.Productid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Odometerreading", ObjClass.Odometerreading, DbType.String, ParameterDirection.Input);
                parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
                parameters.Add("Pin", ObjClass.Pin, DbType.String, ParameterDirection.Input);
                parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
                parameters.Add("DCSTokenNo", ObjClass.DCSTokenNo, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Stan", ObjClass.Stan, DbType.Int32, ParameterDirection.Input);
                parameters.Add("OtherCardNo", ObjClass.OtherCardNo, DbType.String, ParameterDirection.Input);
                parameters.Add("TxnRefId", ObjClass.TxnRefId, DbType.String, ParameterDirection.Input);
                parameters.Add("Paymentmode", ObjClass.Paymentmode, DbType.String, ParameterDirection.Input);
                parameters.Add("Gatewayname", ObjClass.Gatewayname, DbType.String, ParameterDirection.Input);
                parameters.Add("Bankname", ObjClass.Bankname, DbType.String, ParameterDirection.Input);
                parameters.Add("Paycode", ObjClass.Paycode, DbType.String, ParameterDirection.Input);
                parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
                parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
                parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                parameters.Add("StatusCode", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 2);
                parameters.Add("Reason", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("Balance", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("RSP", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("InvAmt", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("Volume", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("CardNoOutput", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("ProductName", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("RetailOutletName", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("VechileNo", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("Address", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("LimitType", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("CCMSLimit", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("CurrentCardBalance", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("CurrentCCMSBalance", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("GetMultipleMobileNo", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                using var connection = _context.CreateConnection();
                var Result = await connection.QueryAsync<TransactionSalebyTerminalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                List<TransactionSalebyTerminalModelOutput> Outputdata = new List<TransactionSalebyTerminalModelOutput>();

                Outputdata.Add(new TransactionSalebyTerminalModelOutput()
                {
                    Status = parameters.Get<int>("StatusCode"),
                    Reason = parameters.Get<string>("Reason"),
                    Balance = parameters.Get<string>("Balance"),
                    RSP = parameters.Get<string>("RSP"),
                    InvAmt = parameters.Get<string>("InvAmt"),
                    Volume = parameters.Get<string>("Volume"),
                    RefNo = APIReferenceNo,// StaticClass.APIReferenceNo,
                    CardNoOutput = parameters.Get<string>("CardNoOutput"),
                    ProductName = parameters.Get<string>("ProductName"),
                    RetailOutletName = parameters.Get<string>("RetailOutletName"),
                    VechileNo = parameters.Get<string>("VechileNo"),
                    Address = parameters.Get<string>("Address"),
                    LimitType = parameters.Get<string>("LimitType"),
                    CCMSLimit = parameters.Get<string>("CCMSLimit"),
                    CurrentCardBalance = parameters.Get<string>("CurrentCardBalance"),
                    CurrentCCMSBalance = parameters.Get<string>("CurrentCCMSBalance"),
                    APIReferenceNo = APIReferenceNo,
                    GetMultipleMobileNo = parameters.Get<string>("GetMultipleMobileNo"),
                });
                return Outputdata;
            }
            else
            {
                List<TransactionSalebyTerminalModelOutput> Outputdata = new List<TransactionSalebyTerminalModelOutput>();
                Outputdata.Add(new TransactionSalebyTerminalModelOutput()
                {
                    Status = 0,
                    Reason = "Invalid Card No",
                    Balance = "",
                    RSP = "",
                    InvAmt = "",
                    RefNo = "",
                    CardNoOutput = "",
                    ProductName = "",
                    RetailOutletName = "",
                    VechileNo = "",
                    Address = "",
                    LimitType = "",
                    CCMSLimit = "",
                    CurrentCardBalance = "",
                    CurrentCCMSBalance = "",
                    APIReferenceNo = "",
                    GetMultipleMobileNo = "",
                });
                return Outputdata;
            }

        }

        public async Task<IEnumerable<RechargeCCMSAccountModelOutput>> RechargeCCMSAccount([FromBody] RechargeCCMSAccountModelInput ObjClass)
        {
            int StatusValue;
            if (ObjClass.Formfactor == 1 || ObjClass.Formfactor == 2)
            {
                if (CardPlainorEncryptStatus != "1")
                {
                    StatusValue = 1;
                }
                else
                {
                    string CardNo = PlainCardNoAsync(ObjClass.Cardno, ObjClass.Terminalid, out StatusValue);
                    if (StatusValue == 1)
                        ObjClass.Cardno = CardNo;
                }
            }
            else
            {
                StatusValue = 1;
            }

            if (StatusValue == 1)
            {
                string APIReferenceNo = StaticClass.APIReferenceNo;
                var procedureName = "UspRechargeCCMSAccount";
                var parameters = new DynamicParameters();
                parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
                parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
                parameters.Add("CCN", ObjClass.CCN, DbType.String, ParameterDirection.Input);
                parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
                parameters.Add("Batchid", ObjClass.Batchid, DbType.Int64, ParameterDirection.Input);
                parameters.Add("Invoiceamount", ObjClass.Invoiceamount, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("Transtype", ObjClass.Transtype, DbType.String, ParameterDirection.Input);
                parameters.Add("Invoiceid", ObjClass.Invoiceid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Invoicedate", ObjClass.Invoicedate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("Chequeno", ObjClass.Chequeno, DbType.String, ParameterDirection.Input);
                parameters.Add("MICR", ObjClass.MICR, DbType.String, ParameterDirection.Input);
                parameters.Add("MUtrno", ObjClass.MUtrno, DbType.String, ParameterDirection.Input);
                //parameters.Add("Paymentmode", ObjClass.Paymentmode, DbType.String, ParameterDirection.Input);
                //parameters.Add("Currency", ObjClass.Currency, DbType.String, ParameterDirection.Input);
                parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
                parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
                parameters.Add("Pin", ObjClass.Pin, DbType.String, ParameterDirection.Input);
                parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
                parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
                parameters.Add("Points", ObjClass.Points, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("Stan", ObjClass.Stan, DbType.Int32, ParameterDirection.Input);
                parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                parameters.Add("StatusCode", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 2);
                parameters.Add("Reason", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("Balance", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("CardNoOutput", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("ProductName", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("RetailOutletName", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("VechileNo", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("Address", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("LimitType", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("CCMSLimit", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("CurrentCardBalance", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("CurrentCCMSBalance", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("GetMultipleMobileNo", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                using var connection = _context.CreateConnection();
                var Result = await connection.QueryAsync<RechargeCCMSAccountModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                List<RechargeCCMSAccountModelOutput> Outputdata = new List<RechargeCCMSAccountModelOutput>();

                Outputdata.Add(new RechargeCCMSAccountModelOutput()
                {
                    Status = parameters.Get<int>("StatusCode"),
                    Reason = parameters.Get<string>("Reason"),
                    Balance = parameters.Get<string>("Balance"),
                    RefNo = StaticClass.APIReferenceNo,
                    CardNoOutput = parameters.Get<string>("CardNoOutput"),
                    ProductName = parameters.Get<string>("ProductName"),
                    RetailOutletName = parameters.Get<string>("RetailOutletName"),
                    VechileNo = parameters.Get<string>("VechileNo"),
                    Address = parameters.Get<string>("Address"),
                    LimitType = parameters.Get<string>("LimitType"),
                    CCMSLimit = parameters.Get<string>("CCMSLimit"),
                    CurrentCardBalance = parameters.Get<string>("CurrentCardBalance"),
                    CurrentCCMSBalance = parameters.Get<string>("CurrentCCMSBalance"),
                    APIReferenceNo = APIReferenceNo,
                    GetMultipleMobileNo = parameters.Get<string>("GetMultipleMobileNo"),

                });

                return Outputdata;
            }
            else
            {
                List<RechargeCCMSAccountModelOutput> Outputdata = new List<RechargeCCMSAccountModelOutput>();
                Outputdata.Add(new RechargeCCMSAccountModelOutput()
                {
                    Status = 0,
                    Reason = "Invalid Card No",
                    Balance = "",
                    RefNo = "",
                    CardNoOutput = "",
                    ProductName = "",
                    RetailOutletName = "",
                    VechileNo = "",
                    Address = "",
                    LimitType = "",
                    CCMSLimit = "",
                    CurrentCardBalance = "",
                    CurrentCCMSBalance = "",
                    APIReferenceNo = "",
                    GetMultipleMobileNo = "",
                });
                return Outputdata;
            }
        }

        public async Task<IEnumerable<GetBatchnoModelOutput>> GetBatchno([FromBody] GetBatchnoModelInput ObjClass)
        {
            var procedureName = "UspGetBatchno";
            var parameters = new DynamicParameters();
            parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
            parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetBatchnoModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<TransactionBalanceTransferModelOutput>> BalanceTransfer([FromBody] TransactionBalanceTransferModelInput ObjClass)
        {
            int StatusValue;
            if (ObjClass.Formfactor == 1 || ObjClass.Formfactor == 2)
            {
                if (CardPlainorEncryptStatus != "1")
                {
                    StatusValue = 1;
                }
                else
                {
                    string CardNo = PlainCardNoAsync(ObjClass.Cardno, ObjClass.Terminalid, out StatusValue);
                    if (StatusValue == 1)
                        ObjClass.Cardno = CardNo;
                }
            }
            else
            {
                StatusValue = 1;
            }

            if (StatusValue == 1)
            {
                var procedureName = "UspBalanceTransfer";
                var parameters = new DynamicParameters();
                parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
                parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
                parameters.Add("CCN", ObjClass.CCN, DbType.String, ParameterDirection.Input);
                parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
                parameters.Add("Batchid", ObjClass.Batchid, DbType.Int64, ParameterDirection.Input);
                parameters.Add("Transtype", ObjClass.Transtype, DbType.String, ParameterDirection.Input);
                parameters.Add("Invoiceid", ObjClass.Invoiceid, DbType.String, ParameterDirection.Input);
                parameters.Add("Invoicedate", ObjClass.Invoicedate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("Invoiceamount", ObjClass.Invoiceamount, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
                parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
                parameters.Add("Pin", ObjClass.Pin, DbType.String, ParameterDirection.Input);
                parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
                parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
                parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                parameters.Add("Stan", ObjClass.Stan, DbType.Int32, ParameterDirection.Input);
                parameters.Add("StatusCode", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 2);
                parameters.Add("Reason", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("CardNoOutput", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("CardBal", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                using var connection = _context.CreateConnection();
                var Result = await connection.QueryAsync<TransactionBalanceTransferModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                List<TransactionBalanceTransferModelOutput> Outputdata = new List<TransactionBalanceTransferModelOutput>();

                Outputdata.Add(new TransactionBalanceTransferModelOutput()
                {
                    Status = parameters.Get<int>("StatusCode"),
                    Reason = parameters.Get<string>("Reason"),
                    RefNo = StaticClass.APIReferenceNo,
                    CardNoOutput = parameters.Get<string>("CardNoOutput"),
                    CardBal = parameters.Get<string>("CardBal"),
                });

                return Outputdata;
            }

            else
            {
                List<TransactionBalanceTransferModelOutput> Outputdata = new List<TransactionBalanceTransferModelOutput>();
                Outputdata.Add(new TransactionBalanceTransferModelOutput()
                {
                    Status = 0,
                    Reason = "Invalid Card No",
                    RefNo = "",
                    CardNoOutput = "",
                    CardBal = "",

                });
                return Outputdata;
            }
        }

        public async Task<IEnumerable<TransactionGenerateOTPModelOutput>> GenerateOTP([FromBody] TransactionGenerateOTPModelInput ObjClass)
        {
            var procedureName = "UspGenerateOTP";
            var parameters = new DynamicParameters();
            parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
            parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
            parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
            parameters.Add("OTPtype", ObjClass.OTPtype, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("CCN", ObjClass.CCN, DbType.String, ParameterDirection.Input);
            parameters.Add("TransTypeId", ObjClass.TransTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Invoiceamount", ObjClass.Invoiceamount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
            parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<TransactionGenerateOTPModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TransactionCardFeePaymentModelOutput>> CardFeePayment([FromBody] TransactionCardFeePaymentModelInput ObjClass)
        {
            var procedureName = "UspCardFeePayment";
            var parameters = new DynamicParameters();
            parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
            parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
            parameters.Add("Formno", ObjClass.Formno, DbType.String, ParameterDirection.Input);
            parameters.Add("Batchid", ObjClass.Batchid, DbType.Int64, ParameterDirection.Input);
            parameters.Add("Noofcards", ObjClass.Noofcards, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Invoiceamount", ObjClass.Invoiceamount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("Transtype", ObjClass.Transtype, DbType.String, ParameterDirection.Input);
            parameters.Add("Invoiceid", ObjClass.Invoiceid, DbType.String, ParameterDirection.Input);
            parameters.Add("Invoicedate", ObjClass.Invoicedate, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
            parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
            parameters.Add("Stan", ObjClass.Stan, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<TransactionCardFeePaymentModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            //RefNo = StaticClass.APIReferenceNo,
        }


        public async Task<IEnumerable<TranscationsCheckForBatchSettlementModelOutput>> CheckTranscationsForBatchSettlement([FromBody] TranscationsCheckForBatchSettlementModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeTranscationsForBatchSettlement");
            dtDBR.Columns.Add("Trantype", typeof(string));
            dtDBR.Columns.Add("Transcount", typeof(int));
            dtDBR.Columns.Add("Totalamount", typeof(decimal));

            if (ObjClass.ObjTranscationsForBatchSettlement != null)
            {
                foreach (TranscationsForBatchSettlement ObjDetail in ObjClass.ObjTranscationsForBatchSettlement)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["Trantype"] = ObjDetail.Trantype;
                    dr["Transcount"] = ObjDetail.Transcount;
                    dr["Totalamount"] = ObjDetail.Totalamount;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspCheckTranscationsForBatchSettlement";
            var parameters = new DynamicParameters();
            parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
            parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
            parameters.Add("Batchid", ObjClass.Batchid, DbType.Int64, ParameterDirection.Input);
            parameters.Add("TypeCheckTranscationsForBatchSettlement", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<TranscationsCheckForBatchSettlementModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<TransactionBatchSettlementModelOutput>> BatchSettlement([FromBody] TransactionBatchSettlementModelInput ObjClass)
        {
            var procedureName = "UspBatchSettlement";
            var parameters = new DynamicParameters();
            parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
            parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
            parameters.Add("Batchid", ObjClass.Batchid, DbType.Int64, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
            parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<TransactionBatchSettlementModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        #region comment code
        //public async Task<TransactionGetRegistrationProcessModelOutput> GetRegistrationParametersArrayWise([FromBody] TransactionGetRegistrationProcessModelInput ObjClass)
        //{
        //    var procedureName = "UspGetRegistrationProcess";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
        //    parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
        //    parameters.Add("HWSerialNo", ObjClass.HWSerialNo, DbType.String, ParameterDirection.Input);
        //    using var connection = _context.CreateConnection();
        //    var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
        //    var storedProcedureResult = new TransactionGetRegistrationProcessModelOutput();
        //    storedProcedureResult.ObjGetRegistrationProcessMerchant = (List<TransactionGetRegistrationProcessMerchantModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessMerchantModelOutput>();
        //    storedProcedureResult.ObjGetRegistrationProcessTransBalanceEnquiry = (List<TransactionGetRegistrationProcessTransBalanceEnquiryModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransBalanceEnquiryModelOutput>();
        //    storedProcedureResult.ObjGetRegistrationProcessTransBalanceTransfer = (List<TransactionGetRegistrationProcessTransBalanceTransferModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransBalanceTransferModelOutput>();

        //    storedProcedureResult.ObjGetRegistrationProcessTransCardFee = (List<TransactionGetRegistrationProcessTransCardFeeModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransCardFeeModelOutput>();
        //    storedProcedureResult.ObjGetRegistrationProcessTransCardUnblocking = (List<TransactionGetRegistrationProcessTransCardUnblockingModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransCardUnblockingModelOutput>();
        //    storedProcedureResult.ObjGetRegistrationProcessTransCCMSBalance = (List<TransactionGetRegistrationProcessTransCCMSBalanceModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransCCMSBalanceModelOutput>();
        //    storedProcedureResult.ObjGetRegistrationProcessTransCCMSRecharge = (List<TransactionGetRegistrationProcessTransCCMSRechargeModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransCCMSRechargeModelOutput>();
        //    storedProcedureResult.ObjGetRegistrationProcessTransChangePin = (List<TransactionGetRegistrationProcessTransChangePinModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransChangePinModelOutput>();
        //    storedProcedureResult.ObjGetRegistrationProcessTransControlPinChange = (List<TransactionGetRegistrationProcessTransControlPinChangeModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransControlPinChangeModelOutput>();
        //    storedProcedureResult.ObjGetRegistrationProcessTransDriverLoyalty = (List<TransactionGetRegistrationProcessTransDriverLoyaltyModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransDriverLoyaltyModelOutput>();
        //    storedProcedureResult.ObjGetRegistrationProcessTransLoyaltyBalance = (List<TransactionGetRegistrationProcessTransLoyaltyBalanceModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransLoyaltyBalanceModelOutput>();
        //    storedProcedureResult.ObjGetRegistrationProcessTransLoyaltyRedeem = (List<TransactionGetRegistrationProcessTransLoyaltyRedeemModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransLoyaltyRedeemModelOutput>();
        //    storedProcedureResult.ObjGetRegistrationProcessTransOTCDriverRedeem = (List<TransactionGetRegistrationProcessTransOTCDriverRedeemModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransOTCDriverRedeemModelOutput>();
        //    storedProcedureResult.ObjGetRegistrationProcessTransPayback = (List<TransactionGetRegistrationProcessTransPaybackModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransPaybackModelOutput>();
        //    storedProcedureResult.ObjGetRegistrationProcessTransPaycode = (List<TransactionGetRegistrationProcessTransPaycodeModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransPaycodeModelOutput>();
        //    storedProcedureResult.ObjGetRegistrationProcessTransReload = (List<TransactionGetRegistrationProcessTransReloadModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransReloadModelOutput>();
        //    storedProcedureResult.ObjGetRegistrationProcessTransSale = (List<TransactionGetRegistrationProcessTransSaleModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransSaleModelOutput>();
        //    storedProcedureResult.ObjGetRegistrationProcessTransSaleComplete = (List<TransactionGetRegistrationProcessTransSaleCompleteModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransSaleCompleteModelOutput>();
        //    storedProcedureResult.ObjGetRegistrationProcessTransTracking = (List<TransactionGetRegistrationProcessTransTrackingModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransTrackingModelOutput>();
        //    storedProcedureResult.ObjGetRegistrationProcessTransUnblockPin = (List<TransactionGetRegistrationProcessTransUnblockPinModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransUnblockPinModelOutput>();
        //    storedProcedureResult.ObjGetRegistrationProcessTransVoid = (List<TransactionGetRegistrationProcessTransVoidModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransVoidModelOutput>();
        //    storedProcedureResult.ObjBanks = (List<TransactionBanksModelOutput>)await result.ReadAsync<TransactionBanksModelOutput>();
        //    storedProcedureResult.ObjFormFactors = (List<TransactionFormFactorsModelOutput>)await result.ReadAsync<TransactionFormFactorsModelOutput>();
        //    storedProcedureResult.ObjProduct = (List<ProductModelOutput>)await result.ReadAsync<ProductModelOutput>();
        //    return storedProcedureResult;
        //}
        #endregion

        public async Task<TransactionGetRegistrationModelOutput> GetRegistrationParameters([FromBody] TransactionGetRegistrationProcessModelInput ObjClass)
        {
            var procedureName = "UspGetRegistrationProcess";
            var parameters = new DynamicParameters();
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("HWSerialNo", ObjClass.HWSerialNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
            parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            var result = await connection.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            var storedProcedureResult = new TransactionGetRegistrationModelOutput();
            storedProcedureResult.ObjGetMerchantDetail = (List<TransactionGetRegistrationProcessMerchantModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessMerchantModelOutput>();
            storedProcedureResult.ObjGetTransTypeDetail = (List<TransactionGetRegistrationProcessTransModelOutput>)await result.ReadAsync<TransactionGetRegistrationProcessTransModelOutput>();
            int StatusCode = storedProcedureResult.ObjGetMerchantDetail.Cast<TransactionGetRegistrationProcessMerchantModelOutput>().ToList()[0].Status;
            if (StatusCode == 1)
            {
                storedProcedureResult.ObjGetTransTypeDetail[1].ObjGetParentTransTypeDetail = (List<TransactionGetTransTypeDetailByParentidModelOutput>)await result.ReadAsync<TransactionGetTransTypeDetailByParentidModelOutput>();
                storedProcedureResult.ObjGetTransTypeDetail[2].ObjGetParentTransTypeDetail = (List<TransactionGetTransTypeDetailByParentidModelOutput>)await result.ReadAsync<TransactionGetTransTypeDetailByParentidModelOutput>();
                storedProcedureResult.ObjGetTransTypeDetail[4].ObjGetParentTransTypeDetail = (List<TransactionGetTransTypeDetailByParentidModelOutput>)await result.ReadAsync<TransactionGetTransTypeDetailByParentidModelOutput>();
                storedProcedureResult.ObjGetTransTypeDetail[11].ObjGetParentTransTypeDetail = (List<TransactionGetTransTypeDetailByParentidModelOutput>)await result.ReadAsync<TransactionGetTransTypeDetailByParentidModelOutput>();
                storedProcedureResult.ObjGetTransTypeDetail[5].ObjGetParentTransTypeDetail = (List<TransactionGetTransTypeDetailByParentidModelOutput>)await result.ReadAsync<TransactionGetTransTypeDetailByParentidModelOutput>();
                storedProcedureResult.ObjGetTransTypeDetail[0].ObjGetParentTransTypeDetail = (List<TransactionGetTransTypeDetailByParentidModelOutput>)await result.ReadAsync<TransactionGetTransTypeDetailByParentidModelOutput>();

            }
            storedProcedureResult.ObjBanks = (List<TransactionBanksModelOutput>)await result.ReadAsync<TransactionBanksModelOutput>();
            storedProcedureResult.ObjFormFactors = (List<TransactionFormFactorsModelOutput>)await result.ReadAsync<TransactionFormFactorsModelOutput>();
            storedProcedureResult.ObjProduct = (List<ProductModelOutput>)await result.ReadAsync<ProductModelOutput>();
            return storedProcedureResult;
        }


        public async Task<IEnumerable<TransactionReloadAccountModelOutput>> ReloadAccount([FromBody] TransactionReloadAccountModelInput ObjClass)
        {

            int StatusValue;
            if (ObjClass.Formfactor == 1 || ObjClass.Formfactor == 2)
            {
                if (CardPlainorEncryptStatus != "1")
                {
                    StatusValue = 1;
                }
                else
                {
                    string CardNo = PlainCardNoAsync(ObjClass.Cardno, ObjClass.Terminalid, out StatusValue);
                    if (StatusValue == 1)
                        ObjClass.Cardno = CardNo;
                }
            }
            else
            {
                StatusValue = 1;
            }

            if (StatusValue == 1)
            {
                string APIReferenceNo = StaticClass.APIReferenceNo;
                var procedureName = "UspReloadAccount";
                var parameters = new DynamicParameters();
                parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
                parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
                parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
                parameters.Add("Batchid", ObjClass.Batchid, DbType.Int64, ParameterDirection.Input);
                parameters.Add("Invoiceamount", ObjClass.Invoiceamount, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("Transtype", ObjClass.Transtype, DbType.String, ParameterDirection.Input);
                parameters.Add("Invoiceid", ObjClass.Invoiceid, DbType.String, ParameterDirection.Input);
                parameters.Add("Invoicedate", ObjClass.Invoicedate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
                parameters.Add("Chequeno", ObjClass.Chequeno, DbType.String, ParameterDirection.Input);
                parameters.Add("MICR", ObjClass.MICR, DbType.String, ParameterDirection.Input);
                parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
                parameters.Add("Pin", ObjClass.Pin, DbType.String, ParameterDirection.Input);
                parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
                parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
                parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                parameters.Add("Stan", ObjClass.Stan, DbType.Int32, ParameterDirection.Input);
                parameters.Add("StatusCode", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 2);
                parameters.Add("Reason", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("Balance", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("CardNoOutput", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("ProductName", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("RetailOutletName", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("VechileNo", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("Address", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("LimitType", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("CCMSLimit", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("CurrentCardBalance", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("CurrentCCMSBalance", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("GetMultipleMobileNo", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                using var connection = _context.CreateConnection();
                var Result = await connection.QueryAsync<TransactionReloadAccountModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                List<TransactionReloadAccountModelOutput> Outputdata = new List<TransactionReloadAccountModelOutput>();

                Outputdata.Add(new TransactionReloadAccountModelOutput()
                {
                    Status = parameters.Get<int>("StatusCode"),
                    Reason = parameters.Get<string>("Reason"),
                    Balance = parameters.Get<string>("Balance"),
                    RefNo = APIReferenceNo,
                    CardNoOutput = parameters.Get<string>("CardNoOutput"),
                    ProductName = parameters.Get<string>("ProductName"),
                    RetailOutletName = parameters.Get<string>("RetailOutletName"),
                    VechileNo = parameters.Get<string>("VechileNo"),
                    Address = parameters.Get<string>("Address"),
                    LimitType = parameters.Get<string>("LimitType"),
                    CCMSLimit = parameters.Get<string>("CCMSLimit"),
                    CurrentCardBalance = parameters.Get<string>("CurrentCardBalance"),
                    CurrentCCMSBalance = parameters.Get<string>("CurrentCCMSBalance"),
                    APIReferenceNo = APIReferenceNo,
                    GetMultipleMobileNo = parameters.Get<string>("GetMultipleMobileNo"),

                });

                return Outputdata;
            }

            else
            {
                List<TransactionReloadAccountModelOutput> Outputdata = new List<TransactionReloadAccountModelOutput>();
                Outputdata.Add(new TransactionReloadAccountModelOutput()
                {
                    Status = 0,
                    Reason = "Invalid Card No",
                    Balance = "",
                    RefNo = "",
                    CardNoOutput = "",
                    ProductName = "",
                    RetailOutletName = "",
                    VechileNo = "",
                    Address = "",
                    LimitType = "",
                    CCMSLimit = "",
                    CurrentCardBalance = "",
                    CurrentCCMSBalance = "",
                    APIReferenceNo = "",
                    GetMultipleMobileNo = "",

                });
                return Outputdata;
            }

        }


        public async Task<IEnumerable<TransactionBalanceEnquiryModelOutput>> BalanceEnquiry([FromBody] TransactionBalanceEnquiryModelInput ObjClass)
        {
            int StatusValue;
            if (ObjClass.Formfactor == 1 || ObjClass.Formfactor == 2)
            {
                if (CardPlainorEncryptStatus != "1")
                {
                    StatusValue = 1;
                }
                else
                {
                    string CardNo = PlainCardNoAsync(ObjClass.Cardno, ObjClass.Terminalid, out StatusValue);
                    if (StatusValue == 1)
                        ObjClass.Cardno = CardNo;
                }
            }
            else
            {
                StatusValue = 1;
            }

            if (StatusValue == 1)
            {
                var procedureName = "UspBalanceEnquiry";
                var parameters = new DynamicParameters();
                parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
                parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
                parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
                parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
                parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
                parameters.Add("Pin", ObjClass.Pin, DbType.String, ParameterDirection.Input);
                parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
                parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
                parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                using var connection = _context.CreateConnection();
                return await connection.QueryAsync<TransactionBalanceEnquiryModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }

            else
            {
                List<TransactionBalanceEnquiryModelOutput> Outputdata = new List<TransactionBalanceEnquiryModelOutput>();
                Outputdata.Add(new TransactionBalanceEnquiryModelOutput()
                {
                    Status = 0,
                    Reason = "Invalid Card No",

                });
                return Outputdata;
            }
        }

        public async Task<IEnumerable<TransactionCCMSBalanceEnquiryModelOutput>> CCMSBalanceEnquiry([FromBody] TransactionCCMSBalanceEnquiryModelInput ObjClass)
        {
            var procedureName = "UspCCMSBalanceEnquiry";
            var parameters = new DynamicParameters();
            parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
            parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
            parameters.Add("CCN", ObjClass.CCN, DbType.String, ParameterDirection.Input);
            parameters.Add("Pin", ObjClass.Pin, DbType.String, ParameterDirection.Input);
            parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
            parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<TransactionCCMSBalanceEnquiryModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TransactionContrlCardPinChangeOutput>> ContrlCardPinChange([FromBody] TransactionContrlCardPinChangeInput ObjClass)
        {
            var procedureName = "UspContrlCardPinChange";
            var parameters = new DynamicParameters();
            parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
            parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
            parameters.Add("CCN", ObjClass.CCN, DbType.String, ParameterDirection.Input);
            parameters.Add("CCNPinold", ObjClass.CCNPinold, DbType.String, ParameterDirection.Input);
            parameters.Add("CCNPinnew", ObjClass.CCNPinnew, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
            parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
            parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
            parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
            parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
            parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<TransactionContrlCardPinChangeOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TransactionUnblockCardPinModelOutput>> UnblockCardPin([FromBody] TransactionUnblockCardPinModelInput ObjClass)
        {

            int StatusValue;

            if (CardPlainorEncryptStatus != "1")
            {
                StatusValue = 1;
            }
            else
            {
                string CardNo = PlainCardNoAsync(ObjClass.CardNo, ObjClass.Terminalid, out StatusValue);
                if (StatusValue == 1)
                    ObjClass.CardNo = CardNo;
            }


            if (StatusValue == 1)
            {

                var procedureName = "UspUnblockCardPin";
                var parameters = new DynamicParameters();
                parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
                parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
                parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Pinnew", ObjClass.Pinnew, DbType.String, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
                parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
                parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                using var connection = _context.CreateConnection();
                return await connection.QueryAsync<TransactionUnblockCardPinModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
            else
            {

                List<TransactionUnblockCardPinModelOutput> Outputdata = new List<TransactionUnblockCardPinModelOutput>();
                Outputdata.Add(new TransactionUnblockCardPinModelOutput()
                {
                    Status = 0,
                    Reason = "Invalid Card No",

                });
                return Outputdata;

            }
        }


        public async Task<IEnumerable<TransactionUnblockCardPinThroughCCNModelOutput>> UnblockCardPinThroughCCN([FromBody] TransactionUnblockCardPinThroughCCNModelInput ObjClass)
        {
            int StatusValue;
            if (CardPlainorEncryptStatus != "1")
            {
                StatusValue = 1;
            }
            else
            {
                string CardNo = PlainCardNoAsync(ObjClass.CardNo, ObjClass.Terminalid, out StatusValue);
                if (StatusValue == 1)
                    ObjClass.CardNo = CardNo;
            }


            if (StatusValue == 1)
            {
                var procedureName = "UspUnblockCardPinThroughCCN";
                var parameters = new DynamicParameters();
                parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
                parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
                parameters.Add("CCN", ObjClass.CCN, DbType.String, ParameterDirection.Input);
                parameters.Add("CCNPin", ObjClass.CCNPin, DbType.String, ParameterDirection.Input);
                parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Cardpin", ObjClass.Cardpin, DbType.String, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
                parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
                parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
                using var connection = _context.CreateConnection();
                return await connection.QueryAsync<TransactionUnblockCardPinThroughCCNModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }

            else
            {

                List<TransactionUnblockCardPinThroughCCNModelOutput> Outputdata = new List<TransactionUnblockCardPinThroughCCNModelOutput>();
                Outputdata.Add(new TransactionUnblockCardPinThroughCCNModelOutput()
                {
                    Status = 0,
                    Reason = "Invalid Card No",

                });
                return Outputdata;

            }
        }


        public async Task<IEnumerable<TransactionUnblockCardPinCheckStatusThroughCCNModelOutput>> UnblockCardPinCheckStatusThroughCCN([FromBody] TransactionUnblockCardPinCheckStatusThroughCCNModelInput ObjClass)
        {

            int StatusValue;
            if (CardPlainorEncryptStatus != "1")
            {
                StatusValue = 1;
            }
            else
            {
                string CardNo = PlainCardNoAsync(ObjClass.CardNo, ObjClass.Terminalid, out StatusValue);
                if (StatusValue == 1)
                    ObjClass.CardNo = CardNo;
            }


            if (StatusValue == 1)
            {

                var procedureName = "UspUnblockCardPinCheckStatusThroughCCN";
                var parameters = new DynamicParameters();
                parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
                parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
                parameters.Add("CCN", ObjClass.CCN, DbType.String, ParameterDirection.Input);
                parameters.Add("CCNPin", ObjClass.CCNPin, DbType.String, ParameterDirection.Input);
                parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
                parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
                parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
                using var connection = _context.CreateConnection();
                return await connection.QueryAsync<TransactionUnblockCardPinCheckStatusThroughCCNModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }

            else
            {

                List<TransactionUnblockCardPinCheckStatusThroughCCNModelOutput> Outputdata = new List<TransactionUnblockCardPinCheckStatusThroughCCNModelOutput>();
                Outputdata.Add(new TransactionUnblockCardPinCheckStatusThroughCCNModelOutput()
                {
                    Status = 0,
                    Reason = "Invalid Card No",

                });
                return Outputdata;

            }
        }



        public async Task<IEnumerable<TransactionChangeCardPinModelOutput>> ChangeCardPin([FromBody] TransactionChangeCardPinModelInput ObjClass)
        {
            int StatusValue;
            if (CardPlainorEncryptStatus != "1")
            {
                StatusValue = 1;
            }
            else
            {
                string CardNo = PlainCardNoAsync(ObjClass.CardNo, ObjClass.Terminalid, out StatusValue);
                if (StatusValue == 1)
                    ObjClass.CardNo = CardNo;
            }


            if (StatusValue == 1)
            {

                var procedureName = "UspChangeCardPin";
                var parameters = new DynamicParameters();
                parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
                parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
                parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Pinold", ObjClass.Pinold, DbType.String, ParameterDirection.Input);
                parameters.Add("Pinnew", ObjClass.Pinnew, DbType.String, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
                parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
                parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                using var connection = _context.CreateConnection();
                return await connection.QueryAsync<TransactionChangeCardPinModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
            else
            {

                List<TransactionChangeCardPinModelOutput> Outputdata = new List<TransactionChangeCardPinModelOutput>();
                Outputdata.Add(new TransactionChangeCardPinModelOutput()
                {
                    Status = 0,
                    Reason = "Invalid Card No",

                });
                return Outputdata;

            }
        }


        public async Task<IEnumerable<TransactionPinUnblockRequestModelOutput>> PinUnblockRequest([FromBody] TransactionPinUnblockRequestModelInput ObjClass)
        {
            int StatusValue;
            if (CardPlainorEncryptStatus != "1")
            {
                StatusValue = 1;
            }
            else
            {
                string CardNo = PlainCardNoAsync(ObjClass.CardNo, ObjClass.Terminalid, out StatusValue);
                if (StatusValue == 1)
                    ObjClass.CardNo = CardNo;
            }


            if (StatusValue == 1)
            {
                var procedureName = "UspPinUnblockRequest";
                var parameters = new DynamicParameters();
                parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
                parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
                parameters.Add("CardNo", ObjClass.CardNo, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
                parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
                parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
                using var connection = _context.CreateConnection();
                return await connection.QueryAsync<TransactionPinUnblockRequestModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

            }
            else
            {

                List<TransactionPinUnblockRequestModelOutput> Outputdata = new List<TransactionPinUnblockRequestModelOutput>();
                Outputdata.Add(new TransactionPinUnblockRequestModelOutput()
                {
                    Status = 0,
                    Reason = "Invalid Card No",

                });
                return Outputdata;

            }
        }

        public async Task<IEnumerable<GetTerminalAppUpdateModelOutput>> GetTerminalAppUpdate([FromBody] GetTerminalAppUpdateModelInput ObjClass)
        {
            var procedureName = "UspGetAppTerminalUpdate";
            var parameters = new DynamicParameters();
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetTerminalAppUpdateModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<HMSKeyExchangeModelOutput>> HMSKeyExchange([FromBody] HMSKeyExchangeModelInput ObjClass)
        {
            var procedureName = "UspCheckValidTerminalId";
            var parameters = new DynamicParameters();
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("IACId", ObjClass.IACId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HMSKeyExchangeModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<InsertUpdateHSMMasterKeyModelOutput>> InsertUpdateHSMMasterKey([FromBody] InsertUpdateHSMMasterKeyModelInput ObjClass)
        {
            var procedureName = "UspInsertUpdateHSMMasterKey";
            var parameters = new DynamicParameters();
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalUniqueId", ObjClass.TerminalUniqueId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("MKAKB", ObjClass.MKAKB, DbType.String, ParameterDirection.Input);
            parameters.Add("MKKCV", ObjClass.MKKCV, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalPK", ObjClass.TerminalPK, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<InsertUpdateHSMMasterKeyModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<HMSLogOnModelOutput>> LogOn([FromBody] HMSLogOnModelInput ObjClass)
        {
            var procedureName = "UspCheckValidandGetHSMKey";
            var parameters = new DynamicParameters();
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            //parameters.Add("IACId", ObjClass.IACId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<HMSLogOnModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UpdateSessionKeyModelOutput>> UpdateHSMSessionKey([FromBody] UpdateSessionKeyModelInput ObjClass)
        {
            var procedureName = "UspUpdateHSMSessionKey";
            var parameters = new DynamicParameters();
            parameters.Add("TerminalId", ObjClass.TerminalId, DbType.String, ParameterDirection.Input);
            parameters.Add("TerminalUniqueId", ObjClass.TerminalUniqueId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("DPKAKB", ObjClass.DPKAKB, DbType.String, ParameterDirection.Input);
            parameters.Add("DPKKCV", ObjClass.DPKKCV, DbType.String, ParameterDirection.Input);
            parameters.Add("PEKAKB", ObjClass.PEKAKB, DbType.String, ParameterDirection.Input);
            parameters.Add("PEKKCV", ObjClass.PEKKCV, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<UpdateSessionKeyModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TransactionReversalFinancialModelOutput>> ReversalFinancialTransactions([FromBody] TransactionReversalFinancialModelInput ObjClass)
        {
            int StatusValue;
            if (ObjClass.Formfactor == 1 || ObjClass.Formfactor == 2)
            {
                if (CardPlainorEncryptStatus != "1")
                {
                    StatusValue = 1;
                }
                else
                {
                    string CardNo = PlainCardNoAsync(ObjClass.Cardno, ObjClass.Terminalid, out StatusValue);
                    if (StatusValue == 1)
                        ObjClass.Cardno = CardNo;
                }
            }
            else
            {
                StatusValue = 1;
            }
            if (StatusValue == 1)
            {
                var procedureName = "UspReversalFinancialTransactions";
                var parameters = new DynamicParameters();
                parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
                parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
                parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
                parameters.Add("Batchid", ObjClass.Batchid, DbType.Int64, ParameterDirection.Input);
                parameters.Add("Invoiceamount", ObjClass.Invoiceamount, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("Transtype", ObjClass.Transtype, DbType.String, ParameterDirection.Input);
                parameters.Add("Invoiceid", ObjClass.Invoiceid, DbType.String, ParameterDirection.Input);
                parameters.Add("Invoicedate", ObjClass.Invoicedate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
                parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
                parameters.Add("Pin", ObjClass.Pin, DbType.String, ParameterDirection.Input);
                parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Stan", ObjClass.Stan, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
                parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
                parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                parameters.Add("StatusCode", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 2);
                parameters.Add("Reason", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("Balance", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("RSP", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("CardNoOutput", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                using var connection = _context.CreateConnection();
                var Result = await connection.QueryAsync<TransactionReversalFinancialModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                List<TransactionReversalFinancialModelOutput> Outputdata = new List<TransactionReversalFinancialModelOutput>();

                Outputdata.Add(new TransactionReversalFinancialModelOutput()
                {
                    Status = parameters.Get<int>("StatusCode"),
                    Reason = parameters.Get<string>("Reason"),
                    Balance = parameters.Get<string>("Balance"),
                    RSP = parameters.Get<string>("RSP"),
                    CardNoOutput = parameters.Get<string>("CardNoOutput"),
                });

                return Outputdata;
            }

            else
            {
                List<TransactionReversalFinancialModelOutput> Outputdata = new List<TransactionReversalFinancialModelOutput>();
                Outputdata.Add(new TransactionReversalFinancialModelOutput()
                {
                    Status = 0,
                    Reason = "Invalid Card No",
                    Balance = "",
                    RSP = "",
                    CardNoOutput = ""
                });
                return Outputdata;
            }

        }

        public async Task<IEnumerable<TransactionVoidFinancialModelOutput>> VoidFinancialTransactions([FromBody] TransactionVoidFinancialModelInput ObjClass)
        {
            int StatusValue;
            if (ObjClass.Formfactor == 1 || ObjClass.Formfactor == 2)
            {
                if (CardPlainorEncryptStatus != "1")
                {
                    StatusValue = 1;
                }
                else
                {
                    string CardNo = PlainCardNoAsync(ObjClass.Cardno, ObjClass.Terminalid, out StatusValue);
                    if (StatusValue == 1)
                        ObjClass.Cardno = CardNo;
                }
            }
            else
            {
                StatusValue = 1;
            }

            if (StatusValue == 1)
            {
                var procedureName = "UspVoidFinancialTransactions";
                var parameters = new DynamicParameters();
                parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
                parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
                parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
                parameters.Add("Batchid", ObjClass.Batchid, DbType.Int64, ParameterDirection.Input);
                parameters.Add("Invoiceamount", ObjClass.Invoiceamount, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("Transtype", ObjClass.Transtype, DbType.String, ParameterDirection.Input);
                parameters.Add("Invoiceid", ObjClass.Invoiceid, DbType.String, ParameterDirection.Input);
                parameters.Add("Invoicedate", ObjClass.Invoicedate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
                parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
                parameters.Add("Pin", ObjClass.Pin, DbType.String, ParameterDirection.Input);
                parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Stan", ObjClass.Stan, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
                parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
                parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                parameters.Add("StatusCode", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 2);
                parameters.Add("Reason", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("Balance", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("RSP", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("CardNoOutput", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                using var connection = _context.CreateConnection();
                var Result = await connection.QueryAsync<TransactionVoidFinancialModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                List<TransactionVoidFinancialModelOutput> Outputdata = new List<TransactionVoidFinancialModelOutput>();

                Outputdata.Add(new TransactionVoidFinancialModelOutput()
                {
                    Status = parameters.Get<int>("StatusCode"),
                    Reason = parameters.Get<string>("Reason"),
                    Balance = parameters.Get<string>("Balance"),
                    RSP = parameters.Get<string>("RSP"),
                    RefNo = StaticClass.APIReferenceNo,
                    CardNoOutput = parameters.Get<string>("CardNoOutput"),
                });

                return Outputdata;
            }

            else
            {
                List<TransactionVoidFinancialModelOutput> Outputdata = new List<TransactionVoidFinancialModelOutput>();
                Outputdata.Add(new TransactionVoidFinancialModelOutput()
                {
                    Status = 0,
                    Reason = "Invalid Card No",
                    Balance = "",
                    RSP = "",
                    RefNo = "",
                    CardNoOutput = "",
                });
                return Outputdata;
            }

        }

        public async Task<IEnumerable<TransactionLoyaltyBalanceCheckModelOutput>> LoyaltyBalanceCheck([FromBody] TransactionLoyaltyBalanceCheckModelInput ObjClass)
        {
            var procedureName = "UspLoyaltyBalanceCheck";
            var parameters = new DynamicParameters();
            parameters.Add("CCN", ObjClass.CCN, DbType.String, ParameterDirection.Input);
            parameters.Add("CCNPin", ObjClass.CCNPin, DbType.String, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<TransactionLoyaltyBalanceCheckModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TranscationsCheckForBatchUploadModelOutput>> BatchUpload([FromBody] TranscationsCheckForBatchUploadModelInput ObjClass)
        {
            var dtDBR = new DataTable("TypeCheckTranscationsForBatchUpload");
            dtDBR.Columns.Add("Cardno", typeof(string));
            dtDBR.Columns.Add("Mobileno", typeof(string));
            dtDBR.Columns.Add("OtherCardNo", typeof(string));
            dtDBR.Columns.Add("Transtype", typeof(string));
            dtDBR.Columns.Add("Invoiceid", typeof(string));
            dtDBR.Columns.Add("Invoicedate", typeof(DateTime));
            dtDBR.Columns.Add("Invoiceamount", typeof(decimal));
            dtDBR.Columns.Add("Sourceid", typeof(int));
            dtDBR.Columns.Add("Formfactor", typeof(int));
            dtDBR.Columns.Add("Stan", typeof(int));
            dtDBR.Columns.Add("APIReferenceNo", typeof(string));

            if (ObjClass.ObjTranscationsForBatchUpload != null)
            {
                foreach (TranscationsForBatchUpload ObjDetail in ObjClass.ObjTranscationsForBatchUpload)
                {
                    DataRow dr = dtDBR.NewRow();
                    dr["Trantype"] = ObjDetail.Trantype;
                    dr["Transcount"] = ObjDetail.Transcount;
                    dr["Totalamount"] = ObjDetail.Totalamount;
                    dtDBR.Rows.Add(dr);
                    dtDBR.AcceptChanges();
                }
            }

            var procedureName = "UspBatchUpload";
            var parameters = new DynamicParameters();
            parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
            parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
            parameters.Add("Batchid", ObjClass.Batchid, DbType.Int64, ParameterDirection.Input);
            parameters.Add("TypeCheckTranscationsForBatchUpload", dtDBR, DbType.Object, ParameterDirection.Input);
            parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
            parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<TranscationsCheckForBatchUploadModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TransactionTrackingByTerminalModelOutput>> TrackingByTerminal([FromBody] TransactionTrackingByTerminalModelInput ObjClass)
        {
            int StatusValue;
            if (ObjClass.Formfactor == 1 || ObjClass.Formfactor == 2)
            {
                if (CardPlainorEncryptStatus != "1")
                {
                    StatusValue = 1;
                }
                else
                {
                    string CardNo = PlainCardNoAsync(ObjClass.Cardno, ObjClass.Terminalid, out StatusValue);
                    if (StatusValue == 1)
                        ObjClass.Cardno = CardNo;
                }
            }
            else
            {
                StatusValue = 1;
            }

            if (StatusValue == 1)
            {
                var procedureName = "UspTrackingByTerminal";
                var parameters = new DynamicParameters();
                parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
                parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
                parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
                parameters.Add("Transtype", ObjClass.Transtype, DbType.String, ParameterDirection.Input);
                parameters.Add("Trackingdate", ObjClass.Trackingdate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
                parameters.Add("Odometerreading", ObjClass.Odometerreading, DbType.String, ParameterDirection.Input);
                parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
                parameters.Add("Pin", ObjClass.Pin, DbType.String, ParameterDirection.Input);
                parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", StaticClass.APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
                parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
                parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                parameters.Add("StatusCode", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 2);
                parameters.Add("Reason", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("Balance", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                using var connection = _context.CreateConnection();
                var result = await connection.QueryAsync<TransactionTrackingByTerminalModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                List<TransactionTrackingByTerminalModelOutput> Outputdata = new List<TransactionTrackingByTerminalModelOutput>();

                Outputdata.Add(new TransactionTrackingByTerminalModelOutput()
                {
                    Status = parameters.Get<int>("StatusCode"),
                    Reason = parameters.Get<string>("Reason"),
                    Balance = parameters.Get<string>("Balance"),
                });

                return Outputdata;
            }

            else
            {
                List<TransactionTrackingByTerminalModelOutput> Outputdata = new List<TransactionTrackingByTerminalModelOutput>();
                Outputdata.Add(new TransactionTrackingByTerminalModelOutput()
                {
                    Status = 0,
                    Reason = "Invalid Card No",
                    Balance = "",
                });
                return Outputdata;
            }
        }

        public async Task<IEnumerable<TransactionInsertDriverLoyaltyModelOutput>> InsertDriverLoyalty([FromBody] TransactionInsertDriverLoyaltyModelInput ObjClass)
        {
            int StatusValue;
            if (ObjClass.Formfactor == 1 || ObjClass.Formfactor == 2)
            {
                if (CardPlainorEncryptStatus != "1")
                {
                    StatusValue = 1;
                }
                else
                {
                    string CardNo = PlainCardNoAsync(ObjClass.Cardno, ObjClass.Terminalid, out StatusValue);
                    if (StatusValue == 1)
                        ObjClass.Cardno = CardNo;
                }
            }
            else
            {
                StatusValue = 1;
            }

            if (StatusValue == 1)
            {
                string APIReferenceNo = StaticClass.APIReferenceNo;
                var procedureName = "UspInsertDriverLoyalty";
                var parameters = new DynamicParameters();
                parameters.Add("Merchantid", ObjClass.Merchantid, DbType.String, ParameterDirection.Input);
                parameters.Add("Terminalid", ObjClass.Terminalid, DbType.String, ParameterDirection.Input);
                parameters.Add("Cardno", ObjClass.Cardno, DbType.String, ParameterDirection.Input);
                parameters.Add("Batchid", ObjClass.Batchid, DbType.Int64, ParameterDirection.Input);
                parameters.Add("Invoiceamount", ObjClass.Invoiceamount, DbType.Decimal, ParameterDirection.Input);
                parameters.Add("Transtype", ObjClass.Transtype, DbType.String, ParameterDirection.Input);
                parameters.Add("Invoiceid", ObjClass.Invoiceid, DbType.String, ParameterDirection.Input);
                parameters.Add("Invoicedate", ObjClass.Invoicedate, DbType.DateTime, ParameterDirection.Input);
                parameters.Add("Mobileno", ObjClass.Mobileno, DbType.String, ParameterDirection.Input);
                parameters.Add("OTP", ObjClass.OTP, DbType.String, ParameterDirection.Input);
                parameters.Add("Pin", ObjClass.Pin, DbType.String, ParameterDirection.Input);
                parameters.Add("Sourceid", ObjClass.Sourceid, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Formfactor", ObjClass.Formfactor, DbType.Int32, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
                parameters.Add("APIReferenceNo", APIReferenceNo, DbType.String, ParameterDirection.Input);
                parameters.Add("Stan", ObjClass.Stan, DbType.Int32, ParameterDirection.Input);
                parameters.Add("Latitude", ObjClass.Latitude, DbType.String, ParameterDirection.Input);
                parameters.Add("Longitude", ObjClass.Longitude, DbType.String, ParameterDirection.Input);
                parameters.Add("UserId", ObjClass.Userid, DbType.String, ParameterDirection.Input);
                parameters.Add("Useragent", ObjClass.Useragent, DbType.String, ParameterDirection.Input);
                parameters.Add("Userip", ObjClass.Userip, DbType.String, ParameterDirection.Input);
                parameters.Add("StatusCode", dbType: DbType.Int32, direction: ParameterDirection.Output, size: 2);
                parameters.Add("Reason", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("CardNoOutput", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("Points", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                parameters.Add("BalancePoints", dbType: DbType.String, direction: ParameterDirection.Output, size: 500);
                using var connection = _context.CreateConnection();

                var Result = await connection.QueryAsync<TransactionInsertDriverLoyaltyModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                List<TransactionInsertDriverLoyaltyModelOutput> Outputdata = new List<TransactionInsertDriverLoyaltyModelOutput>();

                Outputdata.Add(new TransactionInsertDriverLoyaltyModelOutput()
                {
                    Status = parameters.Get<int>("StatusCode"),
                    Reason = parameters.Get<string>("Reason"),
                    CardNoOutput = parameters.Get<string>("CardNoOutput"),
                    Points = parameters.Get<string>("Points"),
                    BalancePoints = parameters.Get<string>("BalancePoints"),
                    RefNo = APIReferenceNo,
                });
                return Outputdata;
            }

            else
            {
                List<TransactionInsertDriverLoyaltyModelOutput> Outputdata = new List<TransactionInsertDriverLoyaltyModelOutput>();
                Outputdata.Add(new TransactionInsertDriverLoyaltyModelOutput()
                {
                    Status = 0,
                    Reason = "Invalid Card No",
                    CardNoOutput = "",
                    Points = "",
                    RefNo = "",
                });
                return Outputdata;
            }
        }
    }
}
