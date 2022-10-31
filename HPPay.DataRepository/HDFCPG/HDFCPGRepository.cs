using CCA.Util;
using Dapper;
using HPPay.DataModel;
using HPPay.DataModel.HDFCPG;
using HPPay.DataRepository.DBDapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.HDFCPG
{
    public  class HDFCPGRepository : IHDFCPGRepository
    {
        private readonly DapperContext _context;
        private readonly IConfiguration _configuration;
        public HDFCPGRepository(DapperContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IEnumerable<GetHDFCPaymentStatusModelOutput>> GetHDFCPaymentStatus([FromBody] GetHDFCPaymentStatusModelInput ObjClass)
        {
            
            var procedureName = "UspGetHDFCRechargeStatus";
            var parameters = new DynamicParameters();
            parameters.Add("orderId", ObjClass.orderId, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetHDFCPaymentStatusModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetHDFCPGResponseModelOutput>> GetHDFCPGResponse([FromBody] GetHDFCPGResponseModelInput ObjClass)
        {
             if (ObjClass.trans_date== null)
            {
                ObjClass.trans_date = DateTime.Today.ToString();
            }
            var procedureName = "UspInsertCPPGApiResponse";
            var parameters = new DynamicParameters();
            parameters.Add("orderId", ObjClass.orderId, DbType.String, ParameterDirection.Input);
            parameters.Add("Amt", ObjClass.Amount, DbType.Decimal, ParameterDirection.Input);
            parameters.Add("tracking_id", ObjClass.tracking_id, DbType.String, ParameterDirection.Input);
            parameters.Add("transactionId", ObjClass.transactionId, DbType.String, ParameterDirection.Input);
            parameters.Add("status_message", ObjClass.status_message, DbType.String, ParameterDirection.Input);
            parameters.Add("bank_ref_no", ObjClass.bank_ref_no, DbType.String, ParameterDirection.Input); 
            parameters.Add("order_status", ObjClass.order_status, DbType.String, ParameterDirection.Input);
            parameters.Add("failure_message", ObjClass.failure_message, DbType.String, ParameterDirection.Input);
            parameters.Add("payment_mode", ObjClass.payment_mode, DbType.String, ParameterDirection.Input);
            parameters.Add("mer_amount", ObjClass.mer_amount, DbType.Decimal, ParameterDirection.Input); 
            parameters.Add("trans_date", ObjClass.trans_date, DbType.String, ParameterDirection.Input);
            parameters.Add("Response", ObjClass.Response, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetHDFCPGResponseModelOutput>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public GetHDFCPGResponseModelInput DecryptResponse(GetHDFCPGEncResponseModelInput objRes)
        {
            GetHDFCPGResponseModelInput PGresponse = new GetHDFCPGResponseModelInput();
            try
            {
                // var encResps = "2f1ddba3af73394a76f2fd9d99e6aa3239917b0ce76799dd88a9023b122e13122addf110a6e4d292412a81f138133ba3aa6eb619859b754b6c33788e810408e9eb0c56a397dcbf264ae98715fa36c58fef98a258d76f912d45e01e65c752c0c81cc5147c5d49325ee4c39e3efd0cd83468caf46c5aaafa98633dbe5d1d9fffc3735a23dd9703715f13279c1cae5a61639b87d205fb03721473d97ce69b6ac0092472bda3187aee777f5b26c5ce2197cbbed37529cb771c8052f98a8546a9410de4e33b136738ae2c4abd3e3c7621bc50a205064ee92812748fa2e122604508f0f8d47e8e53b33998dff3eb150692df384e593755a21eeff67b2e5acb681b71d1d5d2c2aca9b7d338f9533d314b55a125da72f3e94e13078509b784938357b9474752825fa8813ca1440d5d793aa3517f9ebb36b21b89da6599fd9839ae45ac8da8eedd3cdb9263a549c8984669702b1b6b9703fcc74d1477293eec77f712848e6644291422da0a7d4a56a89c62e40822d49017a41323ab26a7951bfa26ed588fe1e65ee519ec80b21836c40a512e4baa85cb6014c6aac441369e6389928a89abdebba83dcd8d237669e5ad93b47df7fd5ac989420f967e3bb58948c4b536c5247f687e6ac2019cd580582b6b76ab0be52ddee052098525bb3f6f96d652213d70dd5546a2723ab2b1f73c701846c396048e8650bc06de5d7860aff6482cabc0ea113849a8a8975eb6ea131b08a32ad8f313e04fe17a10e44497a9b0661a992843003db3de683888ada96f02bb34cfd52e6f7b6dac935e2515aec7c95aa1aee37f597cd47143814daf7bd0c82025d776023bf1f1fe5d3318243c974869a43eafb15d31beb1a5f1a05c2d9015001b60539fd0bd46210d61ce016eeea638820c191b596df4c525e3e35e11e069177ce2e679ed0e0bfd9b475aa552845f516de19c96b10359cb54ab4da786778fb39c3ac7b57ece308347fe86caa05d240696773888e058566c11a5455df71df74efb93900c43aca19298d7de0643092453b9d55588682a01f98dd75130e326080e3185249c3e7bedabf3c2a20a339f5740636d3cc7c3571e71a44c27648f0cdceec44e6156e3d4f676af5abd10046537eabe2df0de1f590dc426b175e4b531427008aa1f5fbf0e35bd0442b01b0e0ef1f9bb89e42c15a97a3ed1eefe5c0f4cffb370b90e511d28679a54890ab6d1350af84c16a787f3b74b592f58bb424c5f755b9b9ba5923460ca221eb777b1913da9e76208a34065ed1db6fb7c344025743826890e0f0595ae029058b62a0cf810a48be3c95968";
                // CreateLogFiles objCreateLogFiles = new CreateLogFiles();
                // objCreateLogFiles.UpdateLog("Started");
                string workingKey = _configuration.GetSection("HDFCPG:Key").Value; 
                CCACrypto ccaCrypto = new CCACrypto();
                ////string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);           
                
                string encResponse = ccaCrypto.Decrypt(objRes.EncResponse, workingKey);         
                NameValueCollection Params = new NameValueCollection();
                string[] segments = encResponse.Split('&');

                foreach (string seg in segments)
                {
                    string[] parts = seg.Split('=');
                    if (parts.Length > 0)
                    {
                        string Key = parts[0].Trim();
                        string Value = parts[1].Trim();

                        Params.Add(Key, Value);
                    }
                }
                for (int i = 0; i < Params.Count; i++)
                {

                    // Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");
                    PGresponse.Response = encResponse;
                    if (Params.Keys[i].Contains("order_id"))
                    {
                        PGresponse.orderId = Params[i];
                    }
                    if (Params.Keys[i].Contains("tracking_id"))
                    {
                        PGresponse.tracking_id = Params[i];
                        PGresponse.transactionId = Params[i];
                    }
                    if (Params.Keys[i].Contains("amount"))
                    {
                        PGresponse.Amount = Convert.ToDecimal(Params[i]);
                    }
                    if (Params.Keys[i].Contains("bank_ref_no"))
                    {
                        PGresponse.bank_ref_no = Params[i];
                    }
                    if (Params.Keys[i].Contains("order_status"))
                    {
                        PGresponse.order_status = Params[i];
                    }
                    if (Params.Keys[i].Contains("status_message"))
                    {
                        PGresponse.status_message = Params[i];
                    }
                    if (Params.Keys[i].Contains("failure_message"))
                    {
                        PGresponse.failure_message = Params[i];
                    }
                    if (Params.Keys[i].Contains("payment_mode"))
                    {
                        PGresponse.payment_mode = Params[i];
                    }
                    if (Params.Keys[i].Contains("mer_amount"))
                    {
                        PGresponse.mer_amount = Convert.ToDecimal(Params[i]);
                    }
                    if (Params.Keys[i].Contains("trans_date"))
                    {
                        PGresponse.trans_date = Params[i];
                    }
                    if (Params.Keys[i].Contains("payment_mode"))
                    {
                        PGresponse.payment_mode = Params[i];
                    }
                }
                

                //objCreateLogFiles.UpdateLog("OrderId: " + orderId);
                //objCreateLogFiles.UpdateLog("Bank Ref No: " + bank_ref_no);
                //objCreateLogFiles.UpdateLog("Bank Response: " + encResponse);
                //objCreateLogFiles.UpdateLog("Completed with " + message);
                //objCreateLogFiles.UpdateLog("--------------------------------------------------- ");
            }
            catch (Exception ex)
            {
                // objCreateLogFiles.UpdateLog("Error: " + ex.Message);
            }
            return PGresponse;
        }

    }
}
