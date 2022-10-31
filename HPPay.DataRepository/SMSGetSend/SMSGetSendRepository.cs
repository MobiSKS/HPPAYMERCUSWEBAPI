using Dapper;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataRepository.DBDapper;
using HPPay.Infrastructure.CommonClass;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;

namespace HPPay.DataRepository.SMSGetSend
{
    public class SMSGetSendRepository : ISMSGetSendRepository
    {
        private readonly Variables ObjVariable;
        private readonly DapperContext _context;
        public SMSGetSendRepository(DapperContext context, IConfiguration configuration)
        {
            _context = context;
            ObjVariable = new Variables(configuration);
        }

        #region Unused Code
        //public async Task<IEnumerable<SMSGetOutputModel>> GetSMSTemplate([FromBody] SMSGetInputModel ObjClass)
        //{
        //    var procedureName = "UspGetSMSTemplate";
        //    using var connection = _context.CreateConnection();
        //    return await connection.QueryAsync<SMSGetOutputModel>(procedureName, null, commandType: CommandType.StoredProcedure);
        //}

        //public async Task<IEnumerable<SMSSendOutputModel>> SendSMSTemplate([FromBody] SMSSendInputModel ObjClass)
        //{
        //    var procedureName = "UspGetSMSConfiguration";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("CTID", ObjClass.CTID, DbType.String, ParameterDirection.Input);
        //    using var connection = _context.CreateConnection();
        //    return await connection.QueryAsync<SMSSendOutputModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        //}

        //public async Task<IEnumerable<InsertSMSTextEntryOutputModel>> InsertSMSTextEntry([FromBody] InsertSMSTextEntryInputModel ObjClass)
        //{
        //    var procedureName = "UspInsertSMSTextEntry";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
        //    parameters.Add("HeaderTemplate", ObjClass.HeaderTemplate, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CTID", ObjClass.CTID, DbType.String, ParameterDirection.Input);
        //    parameters.Add("SMSText", ObjClass.SMSText, DbType.String, ParameterDirection.Input);
        //    parameters.Add("SMSStatus", ObjClass.SMSStatus, DbType.String, ParameterDirection.Input);
        //    parameters.Add("SMSStatusDesc", ObjClass.SMSStatusDesc, DbType.String, ParameterDirection.Input);
        //    parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
        //    using var connection = _context.CreateConnection();
        //    return await connection.QueryAsync<InsertSMSTextEntryOutputModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        //}

        #endregion

        #region InsertSMSandEmailBackup Code
        //public async Task<IEnumerable<GetSMSValueOutputModel>> InsertSMSandEmailBackup([FromBody] GetSMSValueInputModel ObjClass)
        //{
        //    try
        //    {
        //        var procedureName = "UspGetSMSValue";
        //        var parameters = new DynamicParameters();
        //        parameters.Add("MethodName", ObjClass.MethodName, DbType.String, ParameterDirection.Input);
        //        using var connection = _context.CreateConnection();
        //        var SMSResult = await connection.QueryAsync<GetSMSValueOutputModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);

        //        if (SMSResult != null)
        //        {
        //            List<GetSMSValueOutputModel> item = SMSResult.Cast<GetSMSValueOutputModel>().ToList();
        //            if (item.Count > 0)
        //            {
        //                if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].SMSStatus == 1 &&
        //                    SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].EmailStatus == 0)
        //                {
        //                    string TemplateName = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].TemplateName;
        //                    string CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].CTID;

        //                    GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
        //                    getandInsertSendInputModel.CreatedBy = ObjClass.CreatedBy;
        //                    getandInsertSendInputModel.CTID = CTID;
        //                    getandInsertSendInputModel.SMSText = ObjClass.SMSText;
        //                    getandInsertSendInputModel.MobileNo = ObjClass.MobileNo;
        //                    getandInsertSendInputModel.HeaderTemplate = TemplateName;
        //                    getandInsertSendInputModel.Userip = ObjClass.Userip;
        //                    getandInsertSendInputModel.Userid = ObjClass.Userid;
        //                    getandInsertSendInputModel.Useragent = ObjClass.Useragent;
        //                    var SMSSendResult = await connection.QueryAsync<GetandInsertSendOutputModel>(procedureName, parameters,
        //                        commandType: CommandType.StoredProcedure);

        //                    var result_Output = new List<GetSMSValueOutputModel>();
        //                    result_Output.Add(new GetSMSValueOutputModel
        //                    {
        //                        Status = 1,
        //                        Reason = "Sent."
        //                    });
        //                    return result_Output;

        //                }

        //                else if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].EmailStatus == 1 &&
        //                     SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].SMSStatus == 0)
        //                {

        //                    InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
        //                    insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].Host;
        //                    insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].HostPWd;
        //                    insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].FromEmail;
        //                    insertEmailTextEntryInputModel.EmailIdTo = ObjClass.EmailIdTo;
        //                    insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].EmailTemplateSubject;
        //                    insertEmailTextEntryInputModel.EmailTemplate = ObjClass.EmailText;
        //                    insertEmailTextEntryInputModel.CreatedBy = ObjClass.CreatedBy;

        //                    var EmailSendResult = await connection.QueryAsync<InsertEmailTextEntryOutputModel>(procedureName, parameters,
        //                       commandType: CommandType.StoredProcedure);

        //                    var result_Output = new List<GetSMSValueOutputModel>();
        //                    result_Output.Add(new GetSMSValueOutputModel
        //                    {
        //                        Status = 1,
        //                        Reason = "Sent."
        //                    });
        //                    return result_Output;
        //                }

        //                else if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].EmailStatus == 1 &&
        //                    SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].SMSStatus == 1)
        //                {
        //                    string TemplateName = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].TemplateName;
        //                    string CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].CTID;

        //                    GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
        //                    getandInsertSendInputModel.CreatedBy = ObjClass.CreatedBy;
        //                    getandInsertSendInputModel.CTID = CTID;
        //                    getandInsertSendInputModel.SMSText = ObjClass.SMSText;
        //                    getandInsertSendInputModel.MobileNo = ObjClass.MobileNo;
        //                    getandInsertSendInputModel.HeaderTemplate = TemplateName;
        //                    getandInsertSendInputModel.Userip = ObjClass.Userip;
        //                    getandInsertSendInputModel.Userid = ObjClass.Userid;
        //                    getandInsertSendInputModel.Useragent = ObjClass.Useragent;
        //                    _ = GetandInsertSendSMS(getandInsertSendInputModel);

        //                    InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
        //                    insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].Host;
        //                    insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].HostPWd;
        //                    insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].FromEmail;
        //                    insertEmailTextEntryInputModel.EmailIdTo = ObjClass.EmailIdTo;
        //                    insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[0].EmailTemplateSubject;
        //                    insertEmailTextEntryInputModel.EmailTemplate = ObjClass.EmailText;
        //                    insertEmailTextEntryInputModel.CreatedBy = ObjClass.CreatedBy;
        //                    _ = InsertEmailTextEntry(insertEmailTextEntryInputModel);

        //                    var result_Output = new List<GetSMSValueOutputModel>();
        //                    result_Output.Add(new GetSMSValueOutputModel
        //                    {
        //                        Status = 1,
        //                        Reason = "Sent."
        //                    });
        //                    return result_Output;
        //                }

        //                else
        //                {
        //                    var result_Output = new List<GetSMSValueOutputModel>();
        //                    result_Output.Add(new GetSMSValueOutputModel
        //                    {
        //                        Status = 0,
        //                        Reason = "SMS or Email not configured"
        //                    });
        //                    return result_Output;
        //                }


        //            }
        //            else
        //            {
        //                var result_Output = new List<GetSMSValueOutputModel>();
        //                result_Output.Add(new GetSMSValueOutputModel
        //                {
        //                    Status = 0,
        //                    Reason = "SMS or Email not configured"
        //                });
        //                return result_Output;
        //            }
        //        }

        //        else
        //        {
        //            var result_Output = new List<GetSMSValueOutputModel>();
        //            result_Output.Add(new GetSMSValueOutputModel
        //            {
        //                Status = 0,
        //                Reason = "SMS or Email not configured"
        //            });
        //            return result_Output;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var result_Output = new List<GetSMSValueOutputModel>();
        //        result_Output.Add(new GetSMSValueOutputModel
        //        {
        //            Status = 0,
        //            Reason = ex.Message
        //        });
        //        return result_Output;
        //    }

        //}
        #endregion

        public async Task<IEnumerable<GetSMSValueOutputModel>> GetSMSValue([FromBody] GetSMSValueInputModel ObjClass)
        {
            var procedureName = "UspGetSMSValue";
            var parameters = new DynamicParameters();
            parameters.Add("MethodName", ObjClass.MethodName, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetSMSValueOutputModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<GetDetailsSMSValueOutputModel>> GetDetailsSMSValue([FromBody] GetDetailsSMSValueInputModel ObjClass)
        {
            var procedureName = "UspGetDetailsSMSValue";
            var parameters = new DynamicParameters();
            parameters.Add("MethodName", ObjClass.MethodName, DbType.String, ParameterDirection.Input);
            parameters.Add("ApiRefNo", ObjClass.APIRefNo, DbType.String, ParameterDirection.Input);
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<GetDetailsSMSValueOutputModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<GetandInsertSendOutputModel>> InsertSMSTextEntry([FromBody] GetandInsertSendInputModel ObjClass)
        {
            //var procedureName = "UspGetSenderId";
            //using var connection = _context.CreateConnection();
            //var result = await connection.QueryAsync<GetandInsertSendOutputModel>(procedureName, null, commandType: CommandType.StoredProcedure);
            //List<GetandInsertSendOutputModel> item = result.Cast<GetandInsertSendOutputModel>().ToList();
            //SenderId = item[0].SenderId;
            //string SMSAPIURL = item[0].SMSAPIURL;
            //string getmobileno = Variables.RightString(ObjClass.MobileNo, 10);
            //bool checkNo = Variables.IsPhoneNumber(getmobileno);
            //if (checkNo == true)

            if (ObjClass.MobileNo != "")
            {
                if (!ObjClass.MobileNo.Contains(","))
                    ObjClass.MobileNo = ObjClass.MobileNo + ",";
                ObjClass.MobileNo = ObjClass.MobileNo.Remove(ObjClass.MobileNo.Length - 1);
            }
            //ObjClass.MobileNo = ObjClass.MobileNo.Substring(1, ObjClass.MobileNo.Length - 2);
            string SenderId = ObjClass.SenderId;
            string SMSAPIURL = ObjClass.SMSAPIURL;
            if (ObjClass.MobileNo != "" || ObjClass.MobileNo != ",")
            {

                string URL = SMSAPIURL.Replace("[senderid]", SenderId).Replace("[mob]", ObjClass.MobileNo).Replace("[msg]",
                  System.Web.HttpUtility.UrlEncode(ObjClass.SMSText)).Replace("[CTID]", ObjClass.CTID);
                string SMSOutput;
                Variables.PostSMSRequest(URL, out SMSOutput);
                string[] MobileNo = ObjClass.MobileNo.Split(",");
                string SMSStatus;
                if ((SMSOutput.ToUpper().Contains("ACCEPTED")) || (SMSOutput.ToUpper().Contains("TRUE")) || (SMSOutput.ToUpper().Contains("SUCCESS"))
                 || (SMSOutput.ToUpper().Contains("DELIVER")) || (SMSOutput.ToUpper().Contains("SENT")))
                    SMSStatus = "Sent.";
                else
                    SMSStatus = "Failed.";

                for (int k = 0; k < MobileNo.Length; k++)
                {
                    var procedureName = "UspInsertSMSTextEntry";
                    var parameters = new DynamicParameters();
                    parameters.Add("MobileNo", MobileNo[k], DbType.String, ParameterDirection.Input);
                    parameters.Add("HeaderTemplate", ObjClass.HeaderTemplate, DbType.String, ParameterDirection.Input);
                    parameters.Add("CTID", ObjClass.CTID, DbType.String, ParameterDirection.Input);
                    parameters.Add("SMSText", ObjClass.SMSText, DbType.String, ParameterDirection.Input);
                    parameters.Add("SMSStatus", SMSStatus, DbType.String, ParameterDirection.Input);
                    parameters.Add("SMSStatusDesc", SMSOutput, DbType.String, ParameterDirection.Input);
                    parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
                    using var connection1 = _context.CreateConnection();
                    await connection1.QueryAsync<GetandInsertSendOutputModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                }

                var result_Output1 = new List<GetandInsertSendOutputModel>();
                result_Output1.Add(new GetandInsertSendOutputModel { Status = 1, Reason = "Success" });
                return result_Output1;
            }
            else
            {
                var procedureName = "UspInsertSMSTextEntry";
                var parameters = new DynamicParameters();
                parameters.Add("MobileNo", ObjClass.MobileNo, DbType.String, ParameterDirection.Input);
                parameters.Add("HeaderTemplate", ObjClass.HeaderTemplate, DbType.String, ParameterDirection.Input);
                parameters.Add("CTID", ObjClass.CTID, DbType.String, ParameterDirection.Input);
                parameters.Add("SMSText", ObjClass.SMSText, DbType.String, ParameterDirection.Input);
                parameters.Add("SMSStatus", "Failed.", DbType.String, ParameterDirection.Input);
                parameters.Add("SMSStatusDesc", "Invalid Mobile No", DbType.String, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
                using var connection1 = _context.CreateConnection();
                await connection1.QueryAsync<GetandInsertSendOutputModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);

                var result_Output1 = new List<GetandInsertSendOutputModel>();
                result_Output1.Add(new GetandInsertSendOutputModel { Status = 1, Reason = "Invalid Mobile No" });
                return result_Output1;
            }
        }

        public async Task<IEnumerable<InsertEmailTextEntryOutputModel>> InsertEmailTextEntry([FromBody] InsertEmailTextEntryInputModel ObjClass)
        {
            if (ObjClass.EmailIdTo != "")
            {
                MailMessage objMailMessage = new MailMessage();

                objMailMessage.To.Add(ObjClass.EmailIdTo);

                if (ObjClass.EmailIdCC != "" && ObjClass.EmailIdCC != null)
                    objMailMessage.CC.Add(ObjClass.EmailIdCC);

                if (ObjClass.EmailIdBCC != "" && ObjClass.EmailIdBCC != null)
                    objMailMessage.Bcc.Add(ObjClass.EmailIdBCC);

                objMailMessage.From = new MailAddress(ObjClass.EmailIdFrom);
                objMailMessage.Subject = ObjClass.Subject;
                objMailMessage.IsBodyHtml = true;
                objMailMessage.Body = ObjClass.EmailTemplate;
                SmtpClient objSmtpClient = new SmtpClient
                {
                    Host = ObjClass.Host,
                    Credentials = new NetworkCredential(ObjClass.EmailIdFrom, ObjClass.HostPWd)
                };
                objSmtpClient.Send(objMailMessage);


                var procedureName = "UspInsertEmailTextEntry";
                var parameters = new DynamicParameters();
                parameters.Add("EmailIdFrom", ObjClass.EmailIdFrom, DbType.String, ParameterDirection.Input);
                parameters.Add("EmailIdTo", ObjClass.EmailIdTo, DbType.String, ParameterDirection.Input);
                parameters.Add("Subject", ObjClass.Subject, DbType.String, ParameterDirection.Input);
                parameters.Add("EmailTemplate", ObjClass.EmailTemplate, DbType.String, ParameterDirection.Input);
                parameters.Add("EmailStatus", "Sent.", DbType.String, ParameterDirection.Input);
                parameters.Add("EmailStatusDesc", "Success", DbType.String, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
                parameters.Add("EmailIdCC", ObjClass.EmailIdCC, DbType.String, ParameterDirection.Input);
                parameters.Add("EmailIdBCC", ObjClass.EmailIdBCC, DbType.String, ParameterDirection.Input);
                using var connection = _context.CreateConnection();
                return await connection.QueryAsync<InsertEmailTextEntryOutputModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
            else
            {
                var procedureName = "UspInsertEmailTextEntry";
                var parameters = new DynamicParameters();
                parameters.Add("EmailIdFrom", ObjClass.EmailIdFrom, DbType.String, ParameterDirection.Input);
                parameters.Add("EmailIdTo", ObjClass.EmailIdTo, DbType.String, ParameterDirection.Input);
                parameters.Add("Subject", ObjClass.Subject, DbType.String, ParameterDirection.Input);
                parameters.Add("EmailTemplate", ObjClass.EmailTemplate, DbType.String, ParameterDirection.Input);
                parameters.Add("EmailStatus", "Fail.", DbType.String, ParameterDirection.Input);
                parameters.Add("EmailStatusDesc", "Email Id is not present", DbType.String, ParameterDirection.Input);
                parameters.Add("CreatedBy", ObjClass.CreatedBy, DbType.String, ParameterDirection.Input);
                parameters.Add("EmailIdCC", ObjClass.EmailIdCC, DbType.String, ParameterDirection.Input);
                parameters.Add("EmailIdBCC", ObjClass.EmailIdBCC, DbType.String, ParameterDirection.Input);
                using var connection = _context.CreateConnection();
                return await connection.QueryAsync<InsertEmailTextEntryOutputModel>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }


    }
}
