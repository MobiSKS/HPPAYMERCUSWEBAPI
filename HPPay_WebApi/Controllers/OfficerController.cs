using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using HPPay_WebApi.ExtensionMethod;
using HPPay_WebApi.ActionFilters;
using HPPay.DataRepository.Officer;
using HPPay.DataModel.Officer;
using System.Linq;
using HPPay.Infrastructure.CommonClass;
using System.Collections.Generic;
using HPPay.DataRepository.SMSGetSend;
using HPPay.DataModel.SMSGetSend;
using System;

namespace HPPay_WebApi.Controllers
{

    [ApiController]
    [Route("/api/hppay/officer")]
    public class OfficerController : ControllerBase
    {
        private readonly ILogger<OfficerController> _logger;

        private readonly IOfficerRepository _officerRepo;
        private readonly ISMSGetSendRepository _GetSendRepo;
        public OfficerController(ILogger<OfficerController> logger, IOfficerRepository officerRepo, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _officerRepo = officerRepo;
            _GetSendRepo = GetSendRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_officer_type")]
        public async Task<IActionResult> GetOfficerType([FromBody] GetOfficerTypeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _officerRepo.GetOfficerType(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetOfficerTypeModelOutput> item = result.Cast<GetOfficerTypeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_officer_sub_type")]
        public async Task<IActionResult> GetOfficerSubType([FromBody] GetOfficerSubTypeModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _officerRepo.GetOfficerSubType(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetOfficerSubTypeModelOutput> item = result.Cast<GetOfficerSubTypeModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_username")]
        public async Task<IActionResult> ChkUserName([FromBody] CheckOfficerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _officerRepo.ChkUserName(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CheckOfficerModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<CheckOfficerModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("check_username_for_login")]
        public async Task<IActionResult> ChkUserNameForLogin([FromBody] ChkUserNameForLoginModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _officerRepo.ChkUserNameForLogin(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<ChkUserNameForLoginModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<ChkUserNameForLoginModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_officer")]
        public async Task<IActionResult> InsertOfficer([FromBody] OfficerInsertModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _officerRepo.InsertOfficer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<OfficerInsertModelOutput>().ToList()[0].Status == 1)
                    {
                        if (ObjClass.OfficerType != 4)
                        {
                            try
                            {
                                GetSMSValueInputModel ObjSMSValue = new GetSMSValueInputModel();
                                ObjSMSValue.MethodName = ControllerContext.ActionDescriptor.ActionName;
                                var SMSResult = await _GetSendRepo.GetSMSValue(ObjSMSValue);
                                if (SMSResult != null)
                                {
                                    List<GetSMSValueOutputModel> item = SMSResult.Cast<GetSMSValueOutputModel>().ToList();
                                    for (int i = 0; i < item.Count; i++)
                                    {
                                        if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                                        {
                                            GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                                            getandInsertSendInputModel.CreatedBy = ObjClass.CreatedBy;
                                            getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                            string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                            TemplateMessage = TemplateMessage.Replace("@DealerID", ObjClass.UserName)
                                                .Replace("@password", result.Cast<OfficerInsertModelOutput>().ToList()[0].Password).Replace
                                                ("@Role", result.Cast<OfficerInsertModelOutput>().ToList()[0].OfficerName).Replace("JCB", "");

                                            getandInsertSendInputModel.SMSText = TemplateMessage;
                                            getandInsertSendInputModel.MobileNo = ObjClass.MobileNo;
                                            getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo;
                                            getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateName;
                                            getandInsertSendInputModel.Userip = ObjClass.Userip;
                                            getandInsertSendInputModel.Userid = ObjClass.Userid;
                                            getandInsertSendInputModel.Useragent = ObjClass.Useragent;
                                            getandInsertSendInputModel.SenderId = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SenderId;
                                            getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSAPIURL;
                                            await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);

                                        }

                                        if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailStatus == 1)
                                        {
                                            string ZOROEmaild = string.Empty; //database

                                            InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                                            insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                                            insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                                            insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                                            insertEmailTextEntryInputModel.EmailIdTo = ObjClass.EmailId;
                                            insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                                            insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                                            insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                                            string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                                            if (ObjClass.EmailId == "")
                                            {
                                                ObjClass.EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                                            }

                                            EmailTemplateMessage = EmailTemplateMessage.Replace("@DealerID", ObjClass.UserName)
                                                .Replace("@password", result.Cast<OfficerInsertModelOutput>().ToList()[0].Password).Replace
                                                ("@Role", result.Cast<OfficerInsertModelOutput>().ToList()[0].OfficerName).Replace("JCB", "");

                                            insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage;
                                            insertEmailTextEntryInputModel.CreatedBy = ObjClass.CreatedBy;
                                            await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ControllerContext.ActionDescriptor.ActionName + " :: Email and SMS Error :" + ex.Message);
                            }
                        }
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<OfficerInsertModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("bind_officer")]
        public async Task<IActionResult> BindOfficer([FromBody] BindOfficerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _officerRepo.BindOfficer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetOfficerModelOutput> item = result.Cast<GetOfficerModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_officer_detail")]
        public async Task<IActionResult> GetOfficerDetail([FromBody] GetOfficerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _officerRepo.GetOfficerDetail(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetOfficerModelOutput> item = result.Cast<GetOfficerModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_officer")]
        public async Task<IActionResult> UpdateOfficer([FromBody] OfficerUpdateModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _officerRepo.UpdateOfficer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<OfficerUpdateModelOutput>().ToList()[0].Status == 1)
                    {

                        #region 23-08-2022

                        //if (result.Cast<OfficerInsertModelOutput>().ToList()[0].OfficerID != 4)
                        //{
                        //    try
                        //    {
                        //        GetSMSValueInputModel ObjSMSValue = new GetSMSValueInputModel();
                        //        ObjSMSValue.MethodName = ControllerContext.ActionDescriptor.ActionName;
                        //        var SMSResult = await _GetSendRepo.GetSMSValue(ObjSMSValue);
                        //        if (SMSResult != null)
                        //        {
                        //            List<GetSMSValueOutputModel> item = SMSResult.Cast<GetSMSValueOutputModel>().ToList();
                        //            for (int i = 0; i < item.Count; i++)
                        //            {
                        //                if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSStatus == 1)
                        //                {
                        //                    GetandInsertSendInputModel getandInsertSendInputModel = new GetandInsertSendInputModel();
                        //                    getandInsertSendInputModel.CreatedBy = ObjClass.Userid;//Added
                        //                    getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                        //                    string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                        //                    TemplateMessage = TemplateMessage.Replace("", "");

                        //                    getandInsertSendInputModel.SMSText = TemplateMessage.Replace("'", "");//database
                        //                    getandInsertSendInputModel.MobileNo = "";//database
                        //                    getandInsertSendInputModel.OfficerMobileNo = "";//database
                        //                    getandInsertSendInputModel.HeaderTemplate = "";//database
                        //                    getandInsertSendInputModel.Userip = ObjClass.Userip;
                        //                    getandInsertSendInputModel.Userid = ObjClass.Userid;
                        //                    getandInsertSendInputModel.Useragent = ObjClass.Useragent;
                        //                    await _GetSendRepo.GetandInsertSendSMS(getandInsertSendInputModel);

                        //                }

                        //                if (SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailStatus == 1)
                        //                {
                        //                    string ZOROEmaild = String.Empty; //database

                        //                    InsertEmailTextEntryInputModel insertEmailTextEntryInputModel = new InsertEmailTextEntryInputModel();
                        //                    insertEmailTextEntryInputModel.Host = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Host;
                        //                    insertEmailTextEntryInputModel.HostPWd = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].HostPWd;
                        //                    insertEmailTextEntryInputModel.EmailIdFrom = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].FromEmail;
                        //                    insertEmailTextEntryInputModel.EmailIdTo = "";//database
                        //                    insertEmailTextEntryInputModel.Subject = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateSubject;
                        //                    insertEmailTextEntryInputModel.EmailIdCC = ZOROEmaild + SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerCCEmailId;
                        //                    insertEmailTextEntryInputModel.EmailIdBCC = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerBCCEmailId;
                        //                    string EmailTemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].EmailTemplateMessage;

                        //                    //database
                        //                    if (result.Cast<OfficerInsertModelOutput>().ToList()[0].EmailId == "")
                        //                    {
                        //                        result.Cast<OfficerInsertModelOutput>().ToList()[0].EmailId = insertEmailTextEntryInputModel.EmailIdCC;
                        //                    }

                        //                    EmailTemplateMessage = EmailTemplateMessage.Replace("", ""); // database

                        //                    insertEmailTextEntryInputModel.EmailTemplate = EmailTemplateMessage.Replace("'", "");
                        //                    insertEmailTextEntryInputModel.CreatedBy = ObjClass.Userid;//Added
                        //                    await _GetSendRepo.InsertEmailTextEntry(insertEmailTextEntryInputModel);
                        //                }
                        //            }
                        //        }
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        _logger.LogError(ControllerContext.ActionDescriptor.ActionName + " :: Email and SMS Error :" + ex.Message);
                        //    }
                        //}

                        #endregion
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<OfficerUpdateModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("delete_officer")]
        public async Task<IActionResult> DeleteOfficer([FromBody] DeleteOfficerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _officerRepo.DeleteOfficer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<DeleteOfficerModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<DeleteOfficerModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_officer_location_mapping")]
        public async Task<IActionResult> InsertOfficerLocationMapping([FromBody] OfficerLocationMappingModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _officerRepo.InsertOfficerLocationMapping(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<OfficerLocationMappingModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<OfficerLocationMappingModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("delete_officer_location_mapping")]
        public async Task<IActionResult> DeleteOfficerLocationMapping([FromBody] OfficerDeleteLocationMappingModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _officerRepo.DeleteOfficerLocationMapping(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<OfficerDeleteLocationMappingModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<OfficerDeleteLocationMappingModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_officer_location_mapping")]
        public async Task<IActionResult> GetOfficerLocationMapping([FromBody] BindOfficerModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _officerRepo.GetOfficerLocationMapping(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetOfficerLocationMappingModelOutput> item = result.Cast<GetOfficerLocationMappingModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_officer_detail_by_location")]
        public async Task<IActionResult> GetOfficerDetailByLocation([FromBody] GetOfficerDetailModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _officerRepo.GetOfficerDetailByLocation(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetOfficerDetailModelOutput> item = result.Cast<GetOfficerDetailModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }



    }

}
