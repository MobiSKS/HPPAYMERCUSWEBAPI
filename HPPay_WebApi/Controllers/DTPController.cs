using HPPay.DataModel.DTP;
using HPPay.DataModel.SMSGetSend;
using HPPay.DataRepository.DTP;
using HPPay.DataRepository.SMSGetSend;
using HPPay_WebApi.ActionFilters;
using HPPay_WebApi.ExtensionMethod;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPPay_WebApi.Controllers
{
    [ApiController]
    [Route("/api/hppay/dtp")]
    public class DTPController : ControllerBase
    {
        private readonly ILogger<DTPController> _logger;

        private readonly IDTPRepository _dtpRepo;
        private readonly ISMSGetSendRepository _GetSendRepo;

        public DTPController(ILogger<DTPController> logger, IDTPRepository dtpRepo, ISMSGetSendRepository GetSendRepo)
        {
            _logger = logger;
            _dtpRepo = dtpRepo;
            _GetSendRepo = GetSendRepo;
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_block_unblock_customer_ccms_account_by_customerid")]
        public async Task<IActionResult> GetBlockUnBlockCustomerCCMSAccountByCustomerId([FromBody] GetBlockUnBlockCustomerCCMSAccountByCustomerIdModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _dtpRepo.GetBlockUnBlockCustomerCCMSAccountByCustomerId(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetBlockUnBlockCustomerCCMSAccountByCustomerIdModelOutput> item = result.Cast<GetBlockUnBlockCustomerCCMSAccountByCustomerIdModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("block_unblock_customer_ccms_account")]
        public async Task<IActionResult> BlockUnBlockCustomerCCMSAccount([FromBody] BlockUnBlockCustomerCCMSAccountInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _dtpRepo.BlockUnBlockCustomerCCMSAccount(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<BlockUnBlockCustomerCCMSAccountOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<BlockUnBlockCustomerCCMSAccountOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("card_balance_transfer")]
        public async Task<IActionResult> CardBalanceTransfer([FromBody] CardBalanceTransferModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _dtpRepo.CardBalanceTransfer(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<CardBalanceTransferModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<CardBalanceTransferModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("insert_team_mapping")]
        public async Task<IActionResult> InsertTeamMapping([FromBody] InsertTeamMappingModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _dtpRepo.InsertTeamMapping(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<InsertTeamMappingModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<InsertTeamMappingModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_team_mapping")]
        public async Task<IActionResult> GetTeamMapping([FromBody] GetTeamMappingModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _dtpRepo.GetTeamMapping(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetTeamMappingModelOutput> item = result.Cast<GetTeamMappingModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);

                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_team_mapping")]
        public async Task<IActionResult> UpdateTeamMapping([FromBody] UpdateTeamMappingModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _dtpRepo.UpdateTeamMapping(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateTeamMappingModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<UpdateTeamMappingModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("delete_team_mapping")]
        public async Task<IActionResult> DeleteTeamMapping([FromBody] DeleteTeamMappingModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _dtpRepo.DeleteTeamMapping(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<DeleteTeamMappingModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<DeleteTeamMappingModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_entity_for_general_updates")]
        public async Task<IActionResult> GetEntityForGeneralUpdates([FromBody] GetEntityForGeneralUpdatesModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _dtpRepo.GetEntityGeneralUpdates(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetEntityForGeneralUpdatesModelOutput> item = result.Cast<GetEntityForGeneralUpdatesModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_entity_field_by_entity_type_id")]
        public async Task<IActionResult> GetEntityFieldByEntityTypeId([FromBody] GetEntityFieldByEntityTypeIdModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _dtpRepo.GetEntityFieldByEntityTypeId(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    List<GetEntityFieldByEntityTypeIdModelOutput> item = result.Cast<GetEntityFieldByEntityTypeIdModelOutput>().ToList();
                    if (item.Count > 0)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("update_general_entity_field")]
        public async Task<IActionResult> UpdateGeneralEntityField([FromBody] UpdateGeneralEntityFieldModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _dtpRepo.UpdateGeneralEntityField(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<UpdateGeneralEntityFieldModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, result.Cast<UpdateGeneralEntityFieldModelOutput>().ToList()[0].Reason);
                    }
                }
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_entity_old_field_value")]
        public async Task<IActionResult> GetEntityOldFieldValue([FromBody] GetEntityOldFieldValueModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _dtpRepo.GetEntityOldFieldValue(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);

                }
                else
                {

                    if (result.Count() > 0 && result.Cast<GetEntityOldFieldValueModelOutput>().ToList()[0].Status == 1)
                    {
                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger, "");

                    }
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_detail_for_user_unblock_by_customerid_or_username")]
        public async Task<IActionResult> GetDetailForUserUnblockByCustomerIdOrUserName([FromBody] GetDetailForUserUnblockByCustomerIdOrUserNameModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _dtpRepo.GetDetailForUserUnblockByCustomerIdOrUserName(ObjClass);
                if (result == null || result.Count() == 0)
                {
                    return this.Fail(ObjClass, null, _logger);
                }
                else
                {
                    List<GetDetailForUserUnblockByCustomerIdOrUserNameModelOutput> item = result.Cast<GetDetailForUserUnblockByCustomerIdOrUserNameModelOutput>().ToList();
                    if (item.Count > 0 && result.ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("user_unblock")]
        public async Task<IActionResult> UserUnBlock([FromBody] UserUnBlockModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _dtpRepo.UserUnBlock(ObjClass);
                if (result == null)
                {
                    return this.Fail(ObjClass, null, _logger);
                }
                else
                {
                    List<UserUnBlockModelOutput> item = result.Cast<UserUnBlockModelOutput>().ToList();
                    if (item.Count > 0 && result.ToList()[0].Status == 1)
                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("regenerate_iac")]
        public async Task<IActionResult> RegenerateIAC([FromBody] RegenerateIACModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _dtpRepo.RegenerateIAC(ObjClass);
                if (result == null)
                {
                    return this.Fail(ObjClass, null, _logger);
                }
                else
                {

                    if (result.Cast<RegenerateIACModelOutput>().ToList()[0].Status == 1)
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
                                        getandInsertSendInputModel.CreatedBy = ObjClass.Userid;
                                        getandInsertSendInputModel.CTID = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].CTID;

                                        string TemplateMessage = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].TemplateMessage;

                                        TemplateMessage = TemplateMessage.Replace("[TerminalId]", ObjClass.TerminalID)
                                        .Replace("[MerchantId]", result.Cast<RegenerateIACModelOutput>().ToList()[0].MerchantId).Replace("[UserId]", ObjClass.Userid)
                                        .Replace("[OutletName]", result.Cast<RegenerateIACModelOutput>().ToList()[0].OutletName)
                                        .Replace("[Location]", result.Cast<RegenerateIACModelOutput>().ToList()[0].Location)
                                        .Replace("[IAC]", result.Cast<RegenerateIACModelOutput>().ToList()[0].IACID);

                                        getandInsertSendInputModel.SMSText = TemplateMessage;//database
                                        getandInsertSendInputModel.MobileNo = result.Cast<RegenerateIACModelOutput>().ToList()[0].Mobile;//database
                                        getandInsertSendInputModel.OfficerMobileNo = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].OfficerMobileNo;//database
                                        getandInsertSendInputModel.HeaderTemplate = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].Header;//database
                                        getandInsertSendInputModel.Userip = ObjClass.Userip;
                                        getandInsertSendInputModel.Userid = ObjClass.Userid;
                                        getandInsertSendInputModel.Useragent = ObjClass.Useragent;
                                        getandInsertSendInputModel.SenderId = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SenderId;
                                        getandInsertSendInputModel.SMSAPIURL = SMSResult.Cast<GetSMSValueOutputModel>().ToList()[i].SMSAPIURL;
                                        await _GetSendRepo.InsertSMSTextEntry(getandInsertSendInputModel);

                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ControllerContext.ActionDescriptor.ActionName + " :: Email and SMS Error :" + ex.Message);
                        }

                        return this.OkCustom(ObjClass, result, _logger);
                    }
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }

        }
        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("get_enable_dealer_credit_sale_details")]
        public async Task<IActionResult> GetEnableDealerCreditSaleDetails([FromBody] GetEnableDealerCreditSaleDetailsModelInput ObjClass)
        {

            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _dtpRepo.GetEnableDealerCreditSaleDetails(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.MerchantDetail.Count > 0 && result.CustomerDetail.Count > 0 && result.MerchantDetail.ToList()[0].Status == 1
                        && result.CustomerDetail.ToList()[0].Status == 1)

                        return this.OkCustom(ObjClass, result, _logger);
                    else
                        return this.Fail(ObjClass, result, _logger);
                }
            }
        }


        [HttpPost]
        [ServiceFilter(typeof(CustomAuthenticationFilter))]
        [Route("allocate_enable_dealer_credit_sale")]
        public async Task<IActionResult> AllocateEnableDealerCreditSale([FromBody] AllocateEnableDealerCreditSaleModelInput ObjClass)
        {
            if (ObjClass == null)
            {
                return this.BadRequestCustom(ObjClass, null, _logger);
            }
            else
            {
                var result = await _dtpRepo.AllocateEnableDealerCreditSale(ObjClass);
                if (result == null)
                {
                    return this.NotFoundCustom(ObjClass, null, _logger);
                }
                else
                {
                    if (result.Cast<AllocateEnableDealerCreditSaleModelOutput>().ToList()[0].Status == 1)
                    {

                        return this.OkCustom(ObjClass, result, _logger);

                    }
                    else
                    {
                        return this.FailCustom(ObjClass, result, _logger,
                            result.Cast<AllocateEnableDealerCreditSaleModelOutput>().ToList()[0].Reason);
                    }
                }
            }

        }
    }
}
